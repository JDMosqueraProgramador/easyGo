using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime;
using System.Drawing.Printing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.OCR;
using LibClassEasyGo;
using wEasyGoDriver.models;
using System.Data;


namespace wEasyGoDriver.controllers
{
    
    class UserController
    {

        private User user;

        public UserController(long intIdCardPerson, string strNamePerson, string strLastNamePerson, DateTime dateOfBirthPerson, bool boolGenderPerson, long intPhoneUser, string strEmailUser, string strRolUser)
        {
            user = new UserModel(intIdCardPerson, strNamePerson, strLastNamePerson, dateOfBirthPerson, boolGenderPerson, intPhoneUser, strEmailUser, strRolUser);
        }

        public UserController(long intPhoneUser)
        {
            user = new UserModel().GetUserBy(intPhoneUser);
        }

        public UserController()
        {

        }

        public int ExecuteSetUser(string password, int idCity)
        {
            return user.CreateUser(password, idCity);
        }

        public bool ExecuteLogin(long phone, string password)
        {
            return new UserModel().login(phone, password);
        }

        public IUser getDataUser()
        {
            return user;
        }

        public DataTable ExecuteSearchUser(string name)
        {
            return new UserModel().SearchDriver(name);
        }

        // ------------------------------------
        // ------------------------------------
        // ------------------------------------

        public Bitmap bitImg;
        public string Text;


        public string getIdentification(string url)
        {

            string imgText = "";

            Image<Bgr, byte> img = new Image<Bgr, byte>(url);
            // bitImg = img.ToBitmap();

            /*using (var tess = new Tesseract("tessdata", "spa", OcrEngineMode.Default))
            {
                tess.SetImage(img);

                imgText = tess.GetUTF8Text(); 

            } */
            handleImage(img);

            return imgText;

        }

        public /*async*/ void handleImage(Image<Bgr, byte> img)
        {

            Image<Bgr, byte> generateImg = img;

            Image<Gray, byte> imgout = generateImg.Convert<Gray, byte>().ThresholdBinary(new Gray(70), new Gray(455));
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hier = new Mat();

            CvInvoke.FindContours(imgout, contours, hier, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

            using (var tess = new Tesseract("tessdata", "spa", OcrEngineMode.TesseractOnly))
            {
                tess.SetImage(imgout);

                Text = tess.GetUTF8Text();

                bitImg = imgout.ToBitmap();

            }

            /*  if (contours.Size > 0)
            {
                for (int i = 0; i < 10; i++)
                {
                
                    Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);
                    generateImg.ROI = rect;

                    bitImg = generateImg.Copy().ToBitmap();
                        
                    generateImg.ROI = Rectangle.Empty;

                    await Task.Delay(500);
                }

            } */

        }




    }

}
