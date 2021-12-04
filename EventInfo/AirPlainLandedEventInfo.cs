using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTowerWindow.EventInfo
{
    //The Airplain Land event information class
    public class AirPlainLandedEventInfo :EventArgs
    {

        private string m_code;
        private Status m_status;
        private DateTime m_tim;



        //3 parameters are of interest here, the flight code, status of the flight and the date/time it landed
        public AirPlainLandedEventInfo(string code, Status status, DateTime t)
        {
            m_code = code;
            m_status = status;
            m_tim = t;


        }

        public DateTime MTim
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
