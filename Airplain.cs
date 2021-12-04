using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Done by Ngozi Henry Chukwueweniwe 2021-07-06

namespace ControlTowerWindow
{
    //The Airplain class
    public class Airplain
    {

        private string m_flightCode; // Instance field


        public Airplain()
        {

        }

        public Airplain(string code)
        {
            m_flightCode = code;
        }

        public string Mflight
        {
            get { return m_flightCode; }
            set { m_flightCode = value; }
        }








        public override string ToString()
        {
            string newL = Environment.NewLine;

            return string.Format("Flight code : {0}", m_flightCode);
        }

    }
}
