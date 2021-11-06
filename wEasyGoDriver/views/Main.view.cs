﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibClassEasyGo;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Device.Location;

namespace wEasyGoDriver.views
{
    public partial class frmMain : Form
    {

        //UserController userController;

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

        int panelCant = 0;

        public frmMain()
        {
            InitializeComponent();
            InicializeForm();
        }

        public void InicializeForm()
        {
            panel1.Visible = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
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

            /* markerStart = new GMarkerGoogle(new PointLatLng(latitude, longitude), GMarkerGoogleType.red);
            markerOverlay.Markers.Add(markerStart);
            markerStart.ToolTipMode = MarkerTooltipMode.Always; */

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

            };

            positionWatcher.Start();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            ITravel travel = new Travel();
            travel.StrStartingPlaceTravel = "Centro Comercial Terminal Del Sur, Carrera 65, Antioquia";
            travel.StrDestinationPlaceTravel = "Parque Recreativo Envigado INDER";
            travel.NumKMPriceTravel = 2000;
            this.flpViajes.Controls.Add(generateTravel(panelCant, travel));
            panelCant++;
        }

        public Panel generateTravel(int name, ITravel travel)
        {

            GeoCoderStatusCode statusStart;
            GeoCoderStatusCode statusEnd;

            var travelPointStart = GMapProviders.GoogleMap.GetPoint(travel.StrStartingPlaceTravel, out statusStart);
            var travelPointEnd = GMapProviders.GoogleMap.GetPoint(travel.StrDestinationPlaceTravel, out statusEnd);

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
            pnlViaje.Name = "pnlViaje" + name;
            pnlViaje.Size = new System.Drawing.Size(300, 150);
            pnlViaje.BorderStyle = BorderStyle.FixedSingle;
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
            lblSolicitudViaje.Text = "Solicitud de viaje";
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
            lblCantDinero.Text = travel.NumKMPriceTravel.ToString();
            lblCantDinero.TextAlign = ContentAlignment.TopRight;
            // 
            // button1
            // 
            btnVerDetalles.Location = new System.Drawing.Point(10, 89);
            btnVerDetalles.Name = "btnVerDetalles" + name;
            btnVerDetalles.Size = new System.Drawing.Size(280, 25);
            btnVerDetalles.TabIndex = 6;
            btnVerDetalles.Text = "Ver detalles";
            btnVerDetalles.UseVisualStyleBackColor = true;
            btnVerDetalles.Click += new System.EventHandler((object sender, EventArgs e) => {

                // RUTA PROVISIONAL ------------------------------------------------------------------

                if (statusStart == GeoCoderStatusCode.OK)
                {
                    changeStartMarker(travelPointStart.Value);
                    gMapPrincipal.Position = travelPointStart.Value;

                }

                if (statusEnd == GeoCoderStatusCode.OK)
                {
                    changeEndMarker(travelPointEnd.Value);
                    gMapPrincipal.Zoom = 15;
                }

                GDirections direction = getRoute(travelPointStart.Value, travelPointEnd.Value);

                travelRoute = new GMapRoute(direction.Route, "Ruta de viaje");

                routeOver.Clear();
                routeOver.Routes.Add(travelRoute);
                gMapPrincipal.Overlays.Add(routeOver);

                gMapPrincipal.Zoom = gMapPrincipal.Zoom += 1;
                gMapPrincipal.Zoom = gMapPrincipal.Zoom -= 1;

            });

            // 
            // button2
            // 
            btnAceptarViaje.Location = new System.Drawing.Point(10, 118);
            btnAceptarViaje.Name = "btnAceptarViaje" + name;
            btnAceptarViaje.Size = new System.Drawing.Size(164, 25);
            btnAceptarViaje.TabIndex = 7;
            btnAceptarViaje.Text = "Aceptar viaje";
            btnAceptarViaje.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            btnRechazarViaje.Location = new System.Drawing.Point(180, 118);
            btnRechazarViaje.Name = "btnRechazarViaje" + name;
            btnRechazarViaje.Size = new System.Drawing.Size(110, 25);
            btnRechazarViaje.TabIndex = 8;
            btnRechazarViaje.Text = "Rechazar viaje";
            btnRechazarViaje.UseVisualStyleBackColor = true;
            btnRechazarViaje.Click += new System.EventHandler((object sender, EventArgs e) => {

                if(startPoint == travelPointStart.Value && endPoint == travelPointEnd.Value)
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

        private void button1_Click(object sender, EventArgs e)
        {
            PointLatLng p = new PointLatLng(6.171821097107039, -75.59399111110366);
            changeStartMarker(p);
        }

        private void tabMainViajes_Click(object sender, EventArgs e)
        {

        }
    }
}
