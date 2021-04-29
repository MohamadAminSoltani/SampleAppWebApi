#region namespaces
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
#endregion

namespace LightingsPanel.Services
{
    public class LightingService
    {
        #region local variables
        //static http client for multiple uses
        static HttpClient client;
        #endregion

        #region Services
        //turn on lightings
        public static async Task<bool> TurnOnLights()
        {
            client = new HttpClient();

            string serverIP = "212.80.30.147";
            string serverPort = "8116";

            if (serverIP != null && serverPort != null)
            {
                try
                {
                    string query = $"http://{serverIP}:{serverPort}/light/Action/onLightDevice?floor=2&serialNumber=1/0/44";
                   
                    HttpResponseMessage response = await client.PostAsync(query, null);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Services.Models.LightDeviceActionsModel>(content);
                        if (result.lightStatus == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("خطا", "مشکلی حین ارتباط با سرور پیش آمده است", "تایید");
                        return false;
                    }
                }
                catch
                {
                    await Application.Current.MainPage.DisplayAlert("خطا", "خطا در برقراری ارتباط با سرور", "تایید");
                    return false;
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("خطا", "متاسفانه تنظیمات سرور یافت نشد", "تایید");
                return false;
            }
        }
        //turn off lightings
        public static async Task<bool> TurnOffLights()
        {
            client = new HttpClient();

            string serverIP = "212.80.30.147";
            string serverPort = "8116";

            if (serverIP != null && serverPort != null)
            {
                string query = $"http://{serverIP}:{serverPort}/light/Action/offLightDevice?floor=2&serialNumber=1/0/44";
                
                try
                {
                    HttpResponseMessage response = await client.PostAsync(query, null);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Services.Models.LightDeviceActionsModel>(content);
                        if (result.lightStatus == 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("خطا", "مشکلی حین ارتباط با سرور پیش آمده است", "تایید");
                        return false;
                    }
                }
                catch
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("خطا", "خطا در برقراری ارتباط با سرور", "تایید");
                    return false;
                }

            }
            else
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("خطا", "متاسفانه تنظیمات سرور یافت نشد", "تایید");
                return false;
            }
        }
       
        #endregion
    }
}
