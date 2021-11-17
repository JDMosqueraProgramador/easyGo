using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibClassEasyGo
{
    public class Papers
    {
        int intnumlicense;
        DateTime datevaliditylicense;
        string strimagelicense;
        int intidsoat;
        DateTime datevaliduntilsoat;
        string strurlsoat;
        DateTime datevaliduntiltechnomechanical;
        string strurltechnomechanical;
        string strlicenseplatemoto;

        public int Intnumlicense { get => intnumlicense; set => intnumlicense = value; }
        public DateTime Datevaliditylicense { get => datevaliditylicense; set => datevaliditylicense = value; }
        public string Strimagelicense { get => strimagelicense; set => strimagelicense = value; }
        public int Intidsoat { get => intidsoat; set => intidsoat = value; }
        public DateTime Datevaliduntilsoat { get => datevaliduntilsoat; set => datevaliduntilsoat = value; }
        public string Strurlsoat { get => strurlsoat; set => strurlsoat = value; }
        public DateTime Datevaliduntiltechnomechanical { get => datevaliduntiltechnomechanical; set => datevaliduntiltechnomechanical = value; }
        public string Strurltechnomechanical { get => strurltechnomechanical; set => strurltechnomechanical = value; }
        public string Strlicenseplatemoto { get => strlicenseplatemoto; set => strlicenseplatemoto = value; }

        public Papers(int intnumlicense, DateTime datevaliditylicense, string strimagelicense, int intidsoat, DateTime datevaliduntilsoat, string strurlsoat, DateTime datevaliduntiltechnomechanical, string strurltechnomechanical, string strlicenseplatemoto)
        {
            Intnumlicense = intnumlicense;
            Datevaliditylicense = datevaliditylicense;
            Strimagelicense = strimagelicense;
            Intidsoat = intidsoat;
            Datevaliduntilsoat = datevaliduntilsoat;
            Strurlsoat = strurlsoat;
            Datevaliduntiltechnomechanical = datevaliduntiltechnomechanical;
            Strurltechnomechanical = strurltechnomechanical;
            Strlicenseplatemoto = strlicenseplatemoto;
        }

    }
}

