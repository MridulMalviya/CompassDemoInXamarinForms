using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CompassDemoInXamarinForms
{
    public partial class MainPage : ContentPage
    {
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;
        public MainPage()
        {
            InitializeComponent();
            
            Compass.ReadingChanged += Compass_ReadingChanged;
        }

         void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            var data = e.Reading;
            lbl.Text = $"Reading: {data.HeadingMagneticNorth} degrees";           
        }

        public void ToggleCompass()
        {
            try
            {
                if (Compass.IsMonitoring)
                {
                    Compass.Stop();                   
                }
                else
                {
                    Compass.Start(speed);                    
                }
                    
            }
            catch (FeatureNotSupportedException ex)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {               
                // Some other exception has occurred
            }
        }

        private void Press_Clicked(object sender, EventArgs e)
        {
            ToggleCompass();                
        }
    }
}
