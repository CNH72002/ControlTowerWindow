using ControlTowerWindow.EventInfo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Done by Ngozi Henry Chukwueweniwe 2021-07-06

namespace ControlTowerWindow
{
    //This class is enables the program to write the start time and land time for the airplain
    public class WriteLogStartLandTime 
    {
        private static string strInfoS;
        private static string strInfoL;

        public string StrInfoS
        {
            get { return strInfoS; }
            set { strInfoS = value; }
        }

        public string StrInfoL
        {
            get { return strInfoL; }
            set { strInfoL = value; }
        }



        //The method that executes the airplain start event logg information when the event is fired
        //by the publisher class
        public static void OnStartedSent2(object sender, AirPlainStartTimeEventInfo e)
        { 
            strInfoS =  $"TimeStarted: {e.Mtim.ToString(),5}";
              
        }




        //The method execute the the airplain land event logg information to a text file when the event is fired
        //by the publisher class
        public static void OnLandedSent2(object sender, AirPlainLandedEventInfo e)
        {
             strInfoL =  $"FlightCode :{e.Mcode, 5}" + $", " + strInfoS  + $", " + $"TimeLanded: {e.MTim.ToString() ,5}";

            StreamWriter file = new StreamWriter("text.txt", true);
            file.WriteLine(strInfoL);
            file.Close();

        }










    }
}
