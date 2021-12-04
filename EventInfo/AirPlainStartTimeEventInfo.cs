using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Done by Ngozi Henry Chukwueweniwe 2021-07-06

namespace ControlTowerWindow.EventInfo
{
    //This class is the Airplain Start time event Information
    public class AirPlainStartTimeEventInfo : EventArgs
    {


        private string m_code;
        private Status m_status;
        private DateTime m_tim;

        //Here we are interested in only the flight code, status and the date/time it landed
        public AirPlainStartTimeEventInfo(string code, Status status, DateTime t)
        {
            m_code = code;
            m_status = status;
            m_tim = t;

        }


        public DateTime Mtim
        {
            get { return m_tim; }
            set { m_tim = value; }
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