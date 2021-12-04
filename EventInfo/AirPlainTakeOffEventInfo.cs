using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Done by Ngozi Henry Chukwueweniwe 2021-07-06

namespace ControlTowerWindow.EventInfo
{
    //This class handles the airplain take off events
    public class AirPlainTakeOffEventInfo : EventArgs
    {
        private string m_code;
        private Status m_status;
       



        //The parameters of interest is the flight code and its status
        public AirPlainTakeOffEventInfo(string code, Status status)
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

    public enum Status
    {
        
        Started,
        TookOff    ,
        ChangeRoute,
        Landed     ,
        Now_heading_To_30_deg,
        SentToRunway


    }
}
