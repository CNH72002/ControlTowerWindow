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
using System.Windows.Navigation;
using System.Windows.Shapes;
//Done by Ngozi Henry Chukwueweniwe 2021-07-06

namespace ControlTowerWindow
{
    /// <summary>
    /// This class is a subscriber class that subscribe to the Publisher's fired events (FlightWindow)
    /// </summary>
    public partial class MainWindow : Window
    {
        private Airplain m_CurrentObject;

        public MainWindow()
        {
            InitializeComponent();
            m_CurrentObject = GetTestObject();
            InitializeGUI();
        }

        //This buttons enables all the fight to be sent to the runway so that further flight process can start
        private void btnStartFligth_Click(object sender, RoutedEventArgs e)
        {
            Airplain airline = SetupCurrentObject();  //Create an object of the Airplain

            if(airline == null)  // validate it not to be null
            {
                return;
            }

            FlightWindow newFlightMngr = new FlightWindow (airline);  //Publisher class
          
            newFlightMngr.Show();
           

            string strInfo = $"{m_CurrentObject.Mflight,-18}" + $"{"Sent to runway",60}" + $"{DateTime.Now.ToLongTimeString(),54}";
            lstFligthStatus.Items.Add(strInfo);

            //Subscribe to the publisher's events
            newFlightMngr.Started += OnStartedSent; //subscibing For the Control Tower to be notified
            newFlightMngr.Started += WriteLogStartLandTime.OnStartedSent2; //For logging subscription

            newFlightMngr.Headto30deg += OnHeadTo30deg;
            newFlightMngr.TakeOff += OnTakeOffSent;
            newFlightMngr.ChangeRoute += OnChangeRouteSent;

            newFlightMngr.Landed += OnLandedSent;
            newFlightMngr.Landed += WriteLogStartLandTime.OnLandedSent2;

        }


        //Read, validate and setup the Airplain object
        private Airplain SetupCurrentObject()
        {
            string flightstr = ReadFlight();

            if(flightstr != string.Empty)
            {
                m_CurrentObject.Mflight = flightstr;
                return m_CurrentObject;
            }
            else
            {
                return null;
            }

            

        }

        private string ReadFlight()
        {
            
            txtNextFight.Text.Trim();

            if (string.IsNullOrEmpty(txtNextFight.Text))
            {
                MessageBox.Show("Must provide a flight code!");
                return string.Empty;
            }
            return txtNextFight.Text;
        }




        private void InitializeGUI()
        {
            lstFligthStatus.Items.Clear();
            UpdateGUI();
        }

        private void UpdateGUI()
        {
            txtNextFight.Text = m_CurrentObject.Mflight;
        }


        private Airplain GetTestObject()
        {
            string flightCode = "GRW5567";

            return new Airplain(flightCode);
        }


        //The method that executes the fired Start event
        private void OnStartedSent(object sender, AirPlainStartTimeEventInfo e)
        {
            string strInfo = $"{e.Mcode,-18}" + $"{e.Mstatus,60}" + $"{DateTime.Now.ToLongTimeString(),60}";
            lstFligthStatus.Items.Add(strInfo);

        }


        //The method that executes the fired Take off event
        private void OnTakeOffSent(object sender, AirPlainTakeOffEventInfo e)
        {
            string strInfo = $"{e.Mcode,-18}" + $"{e.Mstatus,60}" + $"{DateTime.Now.ToLongTimeString(),60}";
            lstFligthStatus.Items.Add(strInfo);  

        }


        //The method that executes the fired chnage route event
        private void OnChangeRouteSent(object sender, AirPlainChangeRouteEventInfo e)
        {
            string strInfo = $"{e.Mcode,-18}" + $"{e.Mstatus,60}" + $"{DateTime.Now.ToLongTimeString(),55}";
            lstFligthStatus.Items.Add(strInfo);

        }


        //The method that executes the fired Landed event
        private void OnLandedSent(object sender, AirPlainLandedEventInfo e)
        {
            string strInfo = $"{e.Mcode,-18}" + $"{e.Mstatus,60}" + $"{DateTime.Now.ToLongTimeString(),60}";
            lstFligthStatus.Items.Add(strInfo);

        }


        //The method that executes the fired Head to 30 deg event
        private void OnHeadTo30deg(object sender, AirPlainTakeOffEventInfo e)
        {
            string strInfo = $"{e.Mcode,-18}" + $"{e.Mstatus,60}" + $"{DateTime.Now.ToLongTimeString(),45}";
            lstFligthStatus.Items.Add(strInfo);

        }

        //Method to exit the application
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit this application? Continue?",
                    "Sure?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                App.Current.Shutdown();
                

            }



        }






    }
}
