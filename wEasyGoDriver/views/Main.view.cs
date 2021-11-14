using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibClassEasyGo;
using wEasyGoDriver.controllers;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Device.Location;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace wEasyGoDriver.views
{
    public partial class frmMain : Form
    {

        #region [Controladores y variables de datos]

        UserController userController;
        IUser dataUser;

        MotorcycleControlller motoControlller = new MotorcycleControlller();
        IMotorcycle dataMoto;

        TravelController travelController;
        ITravel actualTravel;

        #endregion

        #region [Variables de mapas]

        GMarkerGoogle markerStart;
        GMarkerGoogle markerEnd;
        GMarkerGoogle markerPosition;
        // Capas
        GMapOverlay markerOverlay;
        GMapOverlay routeOver = new GMapOverlay("route");

        PointLatLng startPoint;
        PointLatLng endPoint;
        PointLatLng actualPoint;

        GMapRoute travelRoute;
        GMapRoute startRoute;

        GDirections direction;

        #endregion

        #region [Variables de signalR]

        private string _baseUrl = "https://localhost:7173";
        private string _url = "https://localhost:7173/travelHub";
        HubConnection signalConn;
        private string _groupID = null;

        #endregion

        int panelCant = 0;

        public frmMain(long phone)
        {
            userController = new UserController(phone);
            dataUser = userController.getDataUser();
            dataMoto = motoControlller.ExecuteGetMotorcycle(dataUser.IntIdUser);

            InitializeComponent();
            initializeSignal();
            InicializeForm();

        }

        public async void InicializeForm()
        {
            pnlViajeAceptado.Visible = false;
            btnTerminarViaje.Visible = false;

            if (dataMoto != null && dataUser != null)
            {
                dtgHistorialViajes.DataSource = userController.GetDriverHistory(dataMoto.StrLicensePlateMoto);
                lblEstadoMoto.Text = dataMoto.StrStateMoto;
                dataMoto.StrStateMoto = "inactive";
            }

            #region [Configuración de signalR]

            try
            {
                await signalConn.StartAsync();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            signalConn.On<int, string, double[], double[], DateTime, string>("ReceiveTravel", async (idUser, customerName, startPlace, endPlace, dateRequest, connectId) =>
            {

                ITravel travel = new Travel();
                //travel.StrStartingPlaceTravel = startPlace;
                //travel.StrDestinationPlaceTravel = endPlace;
                travel.DateRequestTravel = dateRequest;
                travel.Customer = new User();
                travel.Customer.IntIdUser = idUser;
                travel.Customer.StrNamePerson = customerName;

                notifyViaje.Text = $"Solicitud de viaje de {customerName}";
                notifyViaje.ShowBalloonTip(4000, notifyViaje.Text, "Podrás aceptar o rechazar la solicitud", ToolTipIcon.Info);

                // MessageBox.Show(travel.ToString());

                flpViajes.Controls.Add(await generateTravelRequest(panelCant, travel, connectId, startPlace, endPlace));

                panelCant++;

            });

            signalConn.On<int, string>("RemoveTravel", async (idUser, customerName) =>
            {
                flpViajes.Controls.Remove(flpViajes.Controls.Find($"pnlViaje{idUser}", false)[0]);
                notifyViaje.ShowBalloonTip(2000, $"{customerName} ha cancelado el viaje", "Se eliminará de tu panel de viajes", ToolTipIcon.Error);

            });

            signalConn.On<string, int>("CancelAcceptTravel", async (groupName, idTravel) =>
            {
                notifyViaje.ShowBalloonTip(5000, $"{lblNombreAceptado.Text} Ha cancelado el viaje", "El usuario ha cancelado el viaje ya aceptado", ToolTipIcon.Error);               
                this.ClearMap();

                await signalConn.InvokeAsync("RemoveGroup", groupName);
                _groupID = null;
                actualTravel = null;
                await signalConn.InvokeAsync("AddAvailable");

                pnlViajeAceptado.Visible = false;

                motoControlller.ExecuteChangeState("available", dataMoto.StrLicensePlateMoto);

                MessageBox.Show("Viaje cancelado", "El viaje ha sido cancelado", MessageBoxButtons.OK);

            });

            #endregion
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {

            #region [Configuración inicial de mapas]

            GMapProviders.GoogleMap.ApiKey = "AIzaSyD53-lwKKlRgkrmqM2kb19laYtq_BdG_RY";
            gMapPrincipal.DragButton = MouseButtons.Left;
            gMapPrincipal.CanDragMap = true;
            gMapPrincipal.MapProvider = GMapProviders.GoogleMap;
            gMapPrincipal.MinZoom = 3;
            gMapPrincipal.MaxZoom = 24;
            gMapPrincipal.Zoom = 20;
            gMapPrincipal.AutoScroll = true;

            // Obtener ubicación actual del usuario
            GeoCoordinateWatcher positionWatcher = new GeoCoordinateWatcher();
            double latitude = 0;
            double longitude = 0;

            // Crear marcador de la ubicación

            markerOverlay = new GMapOverlay("Marcador");

            markerStart = new GMarkerGoogle(new PointLatLng(latitude, longitude), GMarkerGoogleType.red);
            markerOverlay.Markers.Add(markerStart);
            markerStart.ToolTipMode = MarkerTooltipMode.Always;

            positionWatcher.PositionChanged += (sen, evt) =>
            {

                latitude = evt.Position.Location.Latitude;
                longitude = evt.Position.Location.Longitude;

                actualPoint = new PointLatLng(latitude, longitude);

                if (gMapPrincipal.Position.IsEmpty) gMapPrincipal.Position = new PointLatLng(latitude, longitude);

                if (markerPosition == null)
                {
                    markerPosition = new GMarkerGoogle(actualPoint, GMarkerGoogleType.purple_pushpin);
                    markerOverlay.Markers.Add(markerPosition);
                    markerPosition.ToolTipMode = MarkerTooltipMode.Always;
                    markerPosition.ToolTipText = "Tu ubicación actual";

                    gMapPrincipal.Overlays.Add(markerOverlay);
                }
                else
                {
                    markerPosition.Position = actualPoint;
                }

                if(_groupID != null)
                {
                    signalConn.InvokeAsync("SendPosition", latitude, longitude, _groupID);
                }

            };

            positionWatcher.Start();
            
            #endregion

        }

        public void initializeSignal()
        {
            signalConn = new HubConnectionBuilder().WithUrl(_url).Build();

            signalConn.Closed += async (error) =>
            {
                System.Threading.Thread.Sleep(5000);
                await signalConn.StartAsync();
            };

        }


        // PANEL DEL MAPA --------------------------------------------------------------

        public async Task<Panel> generateTravelRequest(int name, ITravel travel, string connectId, double[] startPlace, double[] endPlace)
        {

            PointLatLng travelPointStart = new PointLatLng(startPlace[0], startPlace[1]);
            PointLatLng travelPointEnd = new PointLatLng(endPlace[0], endPlace[1]);

            //GeoCoderStatusCode statusStart;
            //GeoCoderStatusCode statusEnd;

            //var travelPointStart = GMapProviders.GoogleMap.GetPoint(travel.StrStartingPlaceTravel, out statusStart);
            //var travelPointEnd = GMapProviders.GoogleMap.GetPoint(travel.StrDestinationPlaceTravel, out statusEnd);

            // Ruta de viaje solicitada

            GDirections directionTravel = getRoute(travelPointStart, travelPointEnd);

            //GDirections directionTravel = (statusEnd == GeoCoderStatusCode.OK && statusStart == GeoCoderStatusCode.OK) ? getRoute(travelPointStart.Value, travelPointEnd.Value) : null;

            travel.StrStartingPlaceTravel = directionTravel.StartAddress;
            travel.StrDestinationPlaceTravel = directionTravel.EndAddress;
            travel.IntTotalPriceTravel = TravelController.CalculePriceTravel((int)directionTravel.DistanceValue);
            travel.NumKMPriceTravel = (int)directionTravel.DistanceValue;
            travel.StrRuteTravel = JsonConvert.SerializeObject(directionTravel.Route);

            #region [Generación de datos de solicitud]

            System.Windows.Forms.Panel pnlViaje = new Panel();
            System.Windows.Forms.Button btnRechazarViaje = new Button();
            System.Windows.Forms.Button btnAceptarViaje = new Button();
            System.Windows.Forms.Button btnVerDetalles = new Button();
            System.Windows.Forms.Label lblCantDinero = new Label();
            System.Windows.Forms.Label lblLugarDestinoValue = new Label();
            System.Windows.Forms.Label lblLugarDestino = new Label();
            System.Windows.Forms.Label lblLugarInicioValue = new Label();
            System.Windows.Forms.Label lblLugarInicio = new Label();
            System.Windows.Forms.Label lblSolicitudViaje = new Label();
            // 
            // panel1
            // 
            pnlViaje.Controls.Add(btnRechazarViaje);
            pnlViaje.Controls.Add(btnAceptarViaje);
            pnlViaje.Controls.Add(btnVerDetalles);
            pnlViaje.Controls.Add(lblCantDinero);
            pnlViaje.Controls.Add(lblLugarDestinoValue);
            pnlViaje.Controls.Add(lblLugarDestino);
            pnlViaje.Controls.Add(lblLugarInicioValue);
            pnlViaje.Controls.Add(lblLugarInicio);
            pnlViaje.Controls.Add(lblSolicitudViaje);
            pnlViaje.Location = new System.Drawing.Point(698, 13);
            pnlViaje.Name = "pnlViaje" + travel.Customer.IntIdUser;
            pnlViaje.Tag = travel.Customer.IntIdUser;
            pnlViaje.Size = new System.Drawing.Size(318, 150);
            //pnlViaje.BorderStyle = BorderStyle.FixedSingle;
            pnlViaje.TabIndex = 1;
            pnlViaje.Padding = new Padding(20);
            // 
            // label2
            // 
            lblSolicitudViaje.AutoSize = true;
            lblSolicitudViaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblSolicitudViaje.Location = new System.Drawing.Point(7, 9);
            lblSolicitudViaje.Name = "lblSolicitudViaje" + name;
            lblSolicitudViaje.Size = new System.Drawing.Size(115, 20);
            lblSolicitudViaje.TabIndex = 0;
            lblSolicitudViaje.Text = $"{travel.Customer.StrNamePerson} solicita un viaje";
            // 
            // label3
            // 
            lblLugarInicio.AutoSize = true;
            lblLugarInicio.Location = new System.Drawing.Point(10, 41);
            lblLugarInicio.Name = "lblLugarInicio" + name;
            lblLugarInicio.Size = new System.Drawing.Size(80, 15);
            lblLugarInicio.TabIndex = 1;
            lblLugarInicio.Text = "Lugar de inicio:";
            // 
            // label4
            // 
            lblLugarInicioValue.AutoSize = true;
            lblLugarInicioValue.Location = new System.Drawing.Point(95, 41);
            lblLugarInicioValue.Name = "lblLugarInicioValue" + name;
            lblLugarInicioValue.Size = new System.Drawing.Size(100, 15);
            lblLugarInicioValue.TabIndex = 2;
            lblLugarInicioValue.Text = travel.StrStartingPlaceTravel;
            // 
            // label5
            // 
            lblLugarDestinoValue.AutoSize = true;
            lblLugarDestinoValue.Location = new System.Drawing.Point(105, 63);
            lblLugarDestinoValue.Name = "lblLugarDestinoValue" + name;
            lblLugarDestinoValue.Size = new System.Drawing.Size(100, 15);
            lblLugarDestinoValue.TabIndex = 4;
            lblLugarDestinoValue.Text = travel.StrDestinationPlaceTravel;
            // 
            // label6
            // 
            lblLugarDestino.AutoSize = true;
            lblLugarDestino.Location = new System.Drawing.Point(10, 63);
            lblLugarDestino.Name = "lblLugarDestino" + name;
            lblLugarDestino.Size = new System.Drawing.Size(90, 15);
            lblLugarDestino.TabIndex = 3;
            lblLugarDestino.Text = "Lugar de destino:";
            // 
            // label7
            // 
            lblCantDinero.AutoSize = true;
            lblCantDinero.Location = new System.Drawing.Point(194, 13);
            lblCantDinero.Name = "lblCantDinero" + name;
            lblCantDinero.Size = new System.Drawing.Size(95, 15);
            lblCantDinero.TabIndex = 5;
            lblCantDinero.Text = travel.IntTotalPriceTravel.ToString() + " pesos";
            lblCantDinero.TextAlign = ContentAlignment.TopRight;

            #endregion

            // 
            // Button VER DETALLES ---------------------------------------------------------------
            // 
            btnVerDetalles.Location = new System.Drawing.Point(10, 89);
            btnVerDetalles.Name = "btnVerDetalles" + name;
            btnVerDetalles.Size = new System.Drawing.Size(288, 25);
            btnVerDetalles.TabIndex = 6;
            btnVerDetalles.Text = "Ver detalles";
            btnVerDetalles.UseVisualStyleBackColor = true;
            btnVerDetalles.Click += new System.EventHandler((object sender, EventArgs e) => {

                // RUTA PROVISIONAL ------------------------------------------------------------------

                //if (statusStart == GeoCoderStatusCode.OK)
                //{
                    changeStartMarker(travelPointStart);
                    gMapPrincipal.Position = travelPointStart;

                //}

                //if (statusEnd == GeoCoderStatusCode.OK)
                //{
                    changeEndMarker(travelPointEnd);
                    gMapPrincipal.Zoom = 15;
                //}

                travelRoute = new GMapRoute(directionTravel.Route, "Ruta de viaje");

                routeOver.Clear();
                routeOver.Routes.Add(travelRoute);
                gMapPrincipal.Overlays.Add(routeOver);

                gMapPrincipal.Zoom = gMapPrincipal.Zoom += 1;
                gMapPrincipal.Zoom = gMapPrincipal.Zoom -= 1;

            });

            // 
            // Button ACEPTAR VIAJE ---------------------------------------------------------------
            // 
            btnAceptarViaje.Location = new System.Drawing.Point(10, 118);
            btnAceptarViaje.Name = "btnAceptarViaje" + name;
            btnAceptarViaje.Size = new System.Drawing.Size(172, 25);
            btnAceptarViaje.TabIndex = 7;
            btnAceptarViaje.Text = "Aceptar viaje";
            btnAceptarViaje.UseVisualStyleBackColor = true;

            btnAceptarViaje.Click += new System.EventHandler(async (object sender, EventArgs e) =>
            {

                //if (statusEnd == GeoCoderStatusCode.OK && statusStart == GeoCoderStatusCode.OK)
                //{

                    #region [Rutas de viaje y de inicio, marcadores y mapas]

                    // RUTA DEL CONDUCTOR HASTA EL USUARIO -------------------------

                    GDirections dirPositionToStart = getRoute(actualPoint, travelPointStart);

                    startRoute = new GMapRoute(dirPositionToStart.Route, "Ruta de llegada de conductor");
                    startRoute.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    startRoute.Stroke.Color = Color.Red;

                    // Marcador inicial del usuario
                    changeStartMarker(dirPositionToStart.EndLocation);

                    // RUTA DEL USUARIO -------------------------

                    travelRoute = new GMapRoute(directionTravel.Route, "Ruta de viaje");
                    travelRoute.Stroke.Color = Color.BlueViolet;
                    travelRoute.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                    // Marcador final
                    changeEndMarker(directionTravel.EndLocation);

                    routeOver.Routes.Clear();
                    routeOver.Routes.Add(startRoute);
                    // routeOver.Routes.Add(travelRoute);

                    if (gMapPrincipal.Overlays.Contains(routeOver)) gMapPrincipal.Overlays.Remove(routeOver);

                    gMapPrincipal.Overlays.Add(routeOver);
                    gMapPrincipal.Overlays.Remove(markerOverlay);
                    gMapPrincipal.Overlays.Add(markerOverlay);

                    gMapPrincipal.Zoom = gMapPrincipal.Zoom += 1;
                    gMapPrincipal.Zoom = gMapPrincipal.Zoom -= 1;

                    #endregion

                    #region [Registro de viaje, movimientos en SIGNALR]

                    // Instanciamos el viaje para luego crearlo 

                    travel.StrStateTravel = "waiting";
                    this.travelController = new TravelController(travel.StrStartingPlaceTravel, travel.StrDestinationPlaceTravel, travel.IntTotalPriceTravel, travel.NumKMPriceTravel, travel.DateRequestTravel, travel.StrRuteTravel, travel.StrStateTravel, travel.Customer, dataMoto);

                    if (this.travelController.ExecuteCreateTravel())
                    {

                        // Cambiar estado de la moto/conductor en base de datos
                        motoControlller.ExecuteChangeState("busy", dataMoto.StrLicensePlateMoto);
                        _groupID = $"{dataUser.IntIdUser}{connectId}";
                        dataMoto.StrStateMoto = "busy";

                        actualTravel = this.travelController.GetTravel();

                        // Desconectar de el grupo de disponibles
                        await signalConn.InvokeAsync("RemoveAvailable");
                        await signalConn.InvokeAsync("AcceptTravel", dataUser.IntIdUser, connectId, actualTravel.IntIdTravel);

                        #region [Habilitar panel para manejo del viaje]

                        lblTitleViajeAceptado.Text = "Recogiendo a " + travel.Customer.StrNamePerson;
                        lblPrecioAceptado.Text = travel.IntTotalPriceTravel.ToString() + " pesos";
                        lblInicioAceptado.Text = travel.StrStartingPlaceTravel;
                        lblDestinoAceptado.Text = travel.StrDestinationPlaceTravel;
                        lblTelefonoAceptado.Text = travel.Customer.IntPhoneUser.ToString();
                        lblNombreAceptado.Text = $"{travel.Customer.StrNamePerson} {travel.Customer.StrLastNamePerson}";

                        flpViajes.Controls.Clear();
                        pnlViajeAceptado.Visible = true;
                        flpViajes.Controls.Add(pnlViajeAceptado);

                        #endregion

                    }
                    else
                    {
                        throw new Exception("No ha sido posible registrar el viaje, intente nuevamente");
                    }

                //}

                    #endregion
                    
            });

            // 
            // button RECHAZAR VIAJE ---------------------------------------------------------------
            // 
            btnRechazarViaje.Location = new System.Drawing.Point(188, 118);
            btnRechazarViaje.Name = "btnRechazarViaje" + name;
            btnRechazarViaje.Size = new System.Drawing.Size(110, 25);
            btnRechazarViaje.TabIndex = 8;
            btnRechazarViaje.Text = "Rechazar viaje";
            btnRechazarViaje.UseVisualStyleBackColor = true;
            btnRechazarViaje.Click += new System.EventHandler((object sender, EventArgs e) => {

                if(startPoint == travelPointStart && endPoint == travelPointEnd)
                {
                    routeOver.Clear();
                    markerOverlay.Markers.Remove(markerStart);
                    markerOverlay.Markers.Remove(markerEnd);
                    gMapPrincipal.Position = actualPoint;
                    gMapPrincipal.Zoom = 20;
                }

                this.flpViajes.Controls.Remove(btnRechazarViaje.Parent);

            });

            return pnlViaje;
        }

        #region [Funciones de marcadores y rutas (Mapas)]

        public GDirections getRoute(PointLatLng start, PointLatLng end)
        {
            GDirections direction;

            var routeDirections = GMapProviders.GoogleMap.GetDirections(out direction, start, end, false, false, false, false, false);

            if(routeDirections == DirectionsStatusCode.OK)
            {
                return direction;
            } else
            {
                throw new Exception("Error al generar ruta");
                return null;
            }
        }

        public void changeStartMarker(PointLatLng position)
        {
            startPoint = position;

            if (!markerOverlay.Markers.Contains(markerStart))
            {
                markerStart = new GMarkerGoogle(startPoint, GMarkerGoogleType.red);
                markerOverlay.Markers.Add(markerStart);
                markerStart.ToolTipMode = MarkerTooltipMode.Always;
            }
            else
            {
                markerStart.Position = startPoint;
                markerStart.ToolTipText = "Ubicación de inicio seleccionada";
            }

        }

        public void changeEndMarker(PointLatLng position)
        {
            endPoint = position;

            if (!markerOverlay.Markers.Contains(markerEnd))
            {
                markerEnd = new GMarkerGoogle(endPoint, GMarkerGoogleType.red);
                markerOverlay.Markers.Add(markerEnd);
                markerEnd.ToolTipMode = MarkerTooltipMode.Always;
                markerEnd.ToolTipText = "Ubicación de llegada seleccionada";
            }
            else
            {
                markerEnd.Position = endPoint;
            }
        }

        #endregion

        #region [Configuración y botones de viaje aceptado]

        // Viaje aceptado -----------------------------------------------------------

        private async void btnCancelarAceptado_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas cancelar el viaje ya aceptado?", "Cancelación de viaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (this.travelController.ExecuteCancelTravel())
                {

                    pnlViajeAceptado.Visible = false;
                         
                    flpViajes.Controls.Clear();
                    flpViajes.Controls.Add(lblAvisoViajes);
                    lblAvisoViajes.Visible = true;

                    gMapPrincipal.Overlays.Remove(routeOver);
                    markerOverlay.Markers.Remove(markerStart);
                    markerOverlay.Markers.Remove(markerEnd);
                    this.enfocarPosicion();


                    await signalConn.InvokeAsync("CancelAcceptedTravel", this._groupID, actualTravel.IntIdTravel);

                    await signalConn.InvokeAsync("AddAvailable");

                    motoControlller.ExecuteChangeState("available", dataMoto.StrLicensePlateMoto);

                } else
                {
                    throw new Exception("No ha sido posible cancelar el viaje, intente nuevamente");
                }
            }

        }

        private void btnViajeAceptado_Click(object sender, EventArgs e)
        {
            if (actualTravel.StrStateTravel == "waiting")
            {

                if (this.travelController.StartTravel())
                {
                    actualTravel = this.travelController.GetTravel();

                    signalConn.InvokeAsync("StartTravel", this._groupID);

                    this.routeOver.Routes.Clear();
                    this.routeOver.Routes.Add(travelRoute);

                    gMapPrincipal.Zoom += 1;
                    gMapPrincipal.Zoom -= 1;

                    btnTerminarViaje.Enabled = true;
                    btnTerminarViaje.Visible = true;

                    btnEnInicioAceptado.Enabled = false;
                    btnViajeAceptado.Enabled = false;
                    btnCancelarAceptado.Enabled = false;

                } else
                {
                    throw new Exception("Error al comenzar viaje, intente nuevamente");
                }
            }
            
        }

        private async void btnEnInicioAceptado_Click(object sender, EventArgs e)
        {
            await signalConn.InvokeAsync("SendInStart", _groupID);
            btnEnInicioAceptado.Enabled = false;
        }

        private async void btnTerminarViaje_Click(object sender, EventArgs e)
        {
            if(actualTravel.StrStateTravel == "traveling")
            {
                if (this.travelController.FinishTravel())
                {
                    motoControlller.ExecuteChangeState("available", dataMoto.StrLicensePlateMoto);

                    await signalConn.InvokeAsync("FinishTravel", _groupID);
                    MessageBox.Show("Viaje finalizado con éxito", "Recuerda cobrarle el dinero correspondiente al usuario");

                    await signalConn.InvokeAsync("AddAvailable");

                    actualTravel = null;
                    dataMoto.StrStateMoto = "available";
                    btnEstado.Text = "Terminar jornada";
                    ClearMap();


                    btnTerminarViaje.Visible = false;
                    pnlViajeAceptado.Visible = false;
                    if (!this.Controls.Contains(lblAvisoViajes)) this.Controls.Add(lblAvisoViajes);
                    lblAvisoViajes.Visible = true;

                }

                else
                {
                    throw new Exception("Error al terminar viaje, intente nuevamente");
                }

               

            }

        }

        #endregion


        private async void cerrarForm_Click(object sender, EventArgs e)
        {
            await signalConn.InvokeAsync("RemoveAvailable");
            this.Close();
        }

        private void flpViajes_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (flpViajes.Controls.Count == 2) this.lblAvisoViajes.Visible = true;
        }

        private void btnEnfocarPosicion_Click(object sender, EventArgs e)
        {
            this.enfocarPosicion();
        }

        public void enfocarPosicion()
        {
            this.gMapPrincipal.Position = actualPoint;

        }

        public void ClearMap()
        {
            gMapPrincipal.Overlays.Clear();
            markerOverlay.Markers.Clear();

            markerOverlay.Markers.Add(markerPosition);
            gMapPrincipal.Overlays.Add(markerOverlay);
            gMapPrincipal.Zoom += 1;
            gMapPrincipal.Zoom -= 1;

            enfocarPosicion();

        }










        // Primer TAB -----------------------------------------------------------------------

        private async void btnEstado_Click(object sender, EventArgs e)
        {

            switch (dataMoto.StrStateMoto)
            {
                case "inactive":
                    if (motoControlller.ExecuteChangeState("available", dataMoto.StrLicensePlateMoto))
                    {
                        await signalConn.InvokeAsync("AddAvailable");
                        dataMoto.StrStateMoto = "available";
                        btnEstado.Text = "Terminar jornada";
                        tabsMain.SelectedTab = tabMainViajes;
                    }

                    break;

                case "available":

                    if (motoControlller.ExecuteChangeState("inactive", dataMoto.StrLicensePlateMoto))
                    {
                        await signalConn.InvokeAsync("RemoveAvailable");
                        dataMoto.StrStateMoto = "inactive";
                        btnEstado.Text = "Iniciar jornada";
                    }

                    break;

                case "disabled":
                    btnEstado.Text = "";
                    break;

                /*case "busy":

                    btnEstado.Enabled = false;
                    break; */

                default:
                    if (motoControlller.ExecuteChangeState("available", dataMoto.StrLicensePlateMoto))
                    {
                        await signalConn.InvokeAsync("AddAvailable");
                        dataMoto.StrStateMoto = "available";
                        btnEstado.Text = "Terminar jornada";
                        tabsMain.SelectedTab = tabMainViajes;
                    }

                    break;

            }

            lblEstadoMoto.Text = dataMoto.StrStateMoto;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new frmPerfilConductor(3127022532).Show();

           
        }

    }

}
