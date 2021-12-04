using ControlTowerWindow.EventInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControlTowerWindow
{
    /// <summary>
    /// This class is the Publisher class where events are raised and fired
    /// </summary>
    public partial class FlightWindow : Window
    {
        //Create an empty reference to the airline object
        private Airplain m_newAirlineObject = null;
        
        

        public FlightWindow(Airplain newObj)
        {
            InitializeComponent();
            m_newAirlineObject = newObj; //The new airline object becomes the instance object of the airplain
           
            InitializeGUI();
        }

        public void InitializeGUI()
        {
            //Initializations
            btnStart.IsEnabled = true;
            btnLanded.IsEnabled = false;
            btnChangeRoute.IsEnabled = false;
            btnTakeOff.IsEnabled = false;
            btn30deg.IsEnabled = false;
            this.Title = m_newAirlineObject.Mflight;
            SelectImagePic(m_newAirlineObject.Mflight);


        }

        //Select the airline picture to display in the flight window based on the flight code
        public void SelectImagePic(string flightCode)
        {
            if (flightCode == "KLM3755")  //if the flight code use is KLM3755
            {
                // ReadImageFile for KLM airline KLM3755
                 Image1.Source = new BitmapImage(new Uri(@"/ControlTowerWindow;component/Images/KLM3755.bmp", UriKind.Relative));
            }
            else if(flightCode == "GRW5567") //if the flight code use is GRW5567
            {
                // ReadImageFile for Germanwings airline GRW3755
                Image1.Source = new BitmapImage(new Uri(@"/ControlTowerWindow;component/Images/GRW5567.bmp", UriKind.Relative));
            }
            else if (flightCode == "LFZ0789")  //if the flight code use is LFZ0789
            {
                // ReadImageFile for Lufthansa airline LFZ0789
                Image1.Source = new BitmapImage(new Uri(@"/ControlTowerWindow;component/Images/LFZ0789.bmp", UriKind.Relative));
            }
            else
            {
                // ReadImageFile for SDV0001 //if the flight code use is SDV0001 or Any other code . Default picture
                Image1.Source = new BitmapImage(new Uri(@"/ControlTowerWindow;component/Images/SDV0001.bmp", UriKind.Relative));
            }
            

        }




        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        //The events for the Airplain - Started, Head To 30 deg, TakeOff, ChangeRoute and Landed

        public event EventHandler<AirPlainStartTimeEventInfo> Started;  //To be logged in text file
        public event EventHandler<AirPlainTakeOffEventInfo> Headto30deg;
        public event EventHandler<AirPlainTakeOffEventInfo> TakeOff;
        public event EventHandler<AirPlainChangeRouteEventInfo> ChangeRoute;
        public event EventHandler<AirPlainLandedEventInfo> Landed;  //To be logged in the text file


        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        //For the start button and to raise the event for it.
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure this flight want to Start? Continue?",
                    "Sure?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if ((btnStart.IsEnabled == true) && (btnChangeRoute.IsEnabled == false)
               && (btnLanded.IsEnabled == false) && (btnTakeOff.IsEnabled == false) && (btn30deg.IsEnabled == false))
                {
                    Status status = Status.Started;
                    AirPlainStartTimeEventInfo startedInfo = new AirPlainStartTimeEventInfo(this.Title, status, DateTime.Now);
                    OnStarted(startedInfo);   //Raise the event
                }
                //Already disabled
                btnTakeOff.IsEnabled = false;
                btnStart.IsEnabled = false;
                btn30deg.IsEnabled = true;
            }
            else
            {
                return;
            }
                
        }

        //For the Take off button and to raise the event for it.
        private void btnTakeOff_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure this flight want to take Off? Continue?",
                    "Sure?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if ((btnStart.IsEnabled == false) && (btnChangeRoute.IsEnabled == false)
               && (btnLanded.IsEnabled == false) && (btnTakeOff.IsEnabled == true))
                {
                    Status status = Status.TookOff;
                    AirPlainTakeOffEventInfo takeOffInfo = new AirPlainTakeOffEventInfo(this.Title, status);
                    OnTakeOff(takeOffInfo);   //Raise the event
                }

                btnTakeOff.IsEnabled = false;
                btnChangeRoute.IsEnabled = true;

            }
            else
            {
                return;
            }

        }

       
        


        //For the Landed button and to raise the event
        private void btnLanded_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure this flight want to Land? Continue?",
                    "Sure?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if ((btnStart.IsEnabled == false) && (btnTakeOff.IsEnabled == false) &&
                (btnChangeRoute.IsEnabled == false) && (btnLanded.IsEnabled == true))
                {
                    Status status = Status.Landed;
                    AirPlainLandedEventInfo landedInfo = new AirPlainLandedEventInfo(this.Title, status, DateTime.Now);
                    OnLanded(landedInfo);   //Raise the event
                }
                Close();

            }
            else
            {
                return;
            }
                
        }

        //For the Change route button and to raise the event
        private void btnChangeRoute_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure this flight want to Change route?. Continue?",
                    "Sure?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if ((btnStart.IsEnabled == false) && (btnTakeOff.IsEnabled == false) &&
                (btnLanded.IsEnabled == false) && (btnChangeRoute.IsEnabled == true))
                {
                    Status status = Status.ChangeRoute;
                    AirPlainChangeRouteEventInfo changeRouteInfo = new AirPlainChangeRouteEventInfo(this.Title, status);
                    OnChangeRoute(changeRouteInfo);   //Raise the event
                }

                btnLanded.IsEnabled = true;
                btnStart.IsEnabled = false;
                btnTakeOff.IsEnabled = false;
                btnChangeRoute.IsEnabled = false;

            }
            else
            {
                return;
            }

        }


        //The method that fires the Start event
        private void OnStarted(AirPlainStartTimeEventInfo e)
        {
            if (Started != null)
                Started(this, e);

        }


        //Method that fires the Take off event
        private void OnTakeOff(AirPlainTakeOffEventInfo e)  
        {
            if (TakeOff != null)
                TakeOff(this, e);

        }

        //The method that fires the Change route event
        private void OnChangeRoute(AirPlainChangeRouteEventInfo e)
        {
            if (ChangeRoute != null)
                ChangeRoute(this, e);
        }

        //Method  that fires the Landed event
        private void OnLanded(AirPlainLandedEventInfo e)
        {
            if (Landed != null)
                Landed(this, e);
        }




        //Method that fires the Head to 30 deg event

        private void OnHeadTo30deg(AirPlainTakeOffEventInfo e)
        {
            if (Headto30deg != null)
                Headto30deg(this, e);
        }



        
        //For the Head to 30 deg button and to raise the event
        private void btn30deg_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure this flight want to Head to 30 deg?. Continue?",
                    "Sure?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if ((btnStart.IsEnabled == false) && (btnChangeRoute.IsEnabled == false)
               && (btnLanded.IsEnabled == false) && (btnTakeOff.IsEnabled == false) && (btn30deg.IsEnabled == true))
                {
                    Status status = Status.Now_heading_To_30_deg;
                    AirPlainTakeOffEventInfo headto30degInfo = new AirPlainTakeOffEventInfo(this.Title, status);
                    OnHeadTo30deg(headto30degInfo);   //Raise the event

                }

                btnTakeOff.IsEnabled = true;
                btn30deg.IsEnabled = false;

            }
            else
            {
                return;
            }

        }




    }
}
