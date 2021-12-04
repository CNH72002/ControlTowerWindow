using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTowerWindow.EventInfo
{
    //The Airplain Change route event information class
    public class AirPlainChangeRouteEventInfo : EventArgs
    {
        private string m_code;
        private Status m_status;



        //only 2 parameters as inputs - the flight code and its status
        public AirPlainChangeRouteEventInfo(string code, Status status)
        {
            m_code = code;
            m_status = status;


        }


        public string Mcode
        {
            get { return m_code; }
            set { m_code = value; }
        }

        public Status Mstatus
        {
            get { return m_status; }
            set { m_status = value; }
        }




    }
}
