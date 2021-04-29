using System;
using Xamarin.Forms;

namespace SampleAppWebApi
{
    public partial class MainPage : ContentPage
    {
        bool turnon = true;
        public MainPage()
        {
            InitializeComponent();

            LightButton.BtnImage = "resource://SampleAppWebApi.Assets.Images.light-off.svg";
        }

        private async void LightButton_Clicked(object sender, EventArgs e)
        {
            if (turnon)
            {
                bool result = await LightingsPanel.Services.LightingService.TurnOnLights();
                if (result)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        LightButton.BtnBackgroundColor = Color.FromHex("#FEFE3B");
                        LightButton.BtnImage = "resource://LightingsPanel.Assets.Images.light-on.svg";
                    });

                    turnon = false;
                }

            }
            else
            {
                bool result = await LightingsPanel.Services.LightingService.TurnOffLights();

                if (result)
                {

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        LightButton.BtnBackgroundColor = Color.FromHex("#E6EDF5");
                        LightButton.BtnImage = "resource://LightingsPanel.Assets.Images.light-off.svg";
                    });
                    turnon = true;
                }
            }
        }
    }
}
