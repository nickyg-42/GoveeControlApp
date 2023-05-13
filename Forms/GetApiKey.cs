using System.Windows.Forms;
using GoveeControl.Interfaces;
using GoveeControl.Services;

namespace GoveeControl.Forms
{
    public partial class GetApiKey : Form
    {
        public GetApiKey()
        {
            InitializeComponent();
        }

        public string GetApiKeyText()
        {
            return apiKeyTextBox.Text;
        }

        private async void EnterButton_Click(object sender, EventArgs e)
        {

            bool valid = await TestApiKey(apiKeyTextBox.Text);

            if (valid)
            {
                errorLabel.Visible = false;
                DialogResult = DialogResult.OK;
            }
            else
            {
                errorLabel.Visible = true;
            }
        }

        /// <summary>
        /// Helper method to validate the API key
        /// </summary>
        /// <param name="apiKey">The API key entered in the form</param>
        /// <returns>True if the request is successful and false otherwise</returns>
        private static async Task<bool> TestApiKey(string apiKey)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Govee-API-Key", apiKey);

                var res = await client.GetAsync("https://developer-api.govee.com/v1/devices");

                if (res.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;
            };
        }
    }
}
