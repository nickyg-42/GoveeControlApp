using System.Configuration;
using GoveeControl.Interfaces;
using Newtonsoft.Json.Linq;

namespace GoveeControl.Forms.WindowsForms
{
    public partial class Settings : Form
    {
        private readonly IGoveeService _goveeService;
        private readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json");

        public Settings(IGoveeService goveeService)
        {
            InitializeComponent();
            _goveeService = goveeService;
            ApiKeyTextBox.Text = GetJsonApiKey(_path);
        }

        /// <summary>
        /// Method to stop app upon form closure
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Method to redirect back to the home page
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            Home homePage = new(_goveeService);
            homePage.StartPosition = FormStartPosition.Manual;
            homePage.Location = new Point(this.Location.X + (this.Width - homePage.Width) / 2, this.Location.Y + (this.Height - homePage.Height) / 2);
            homePage.Show();
            this.Hide();
        }

        // TODO: Make generic save method to reuse once more settings are added
        /// <summary>
        /// Checks validity of field and writes to disk
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private async void SaveApiKeyBtn_Click(object sender, EventArgs e)
        {
            SaveApiKeyBtn.Enabled = false;

            string newKey = ApiKeyTextBox.Text;

            if (await TestApiKey(newKey))
            {
                StatusLabel.Text = "Saved!";
                StatusLabel.ForeColor = Color.Green;
                SetApiKey(newKey, _path);
                _goveeService.SetApiKey(newKey);
            }
            else
            {
                StatusLabel.Text = "Error: Please enter a valid API key!";
                StatusLabel.ForeColor = Color.Red;
            }

            SaveApiKeyBtn.Enabled = true;
        }

        /// <summary>
        /// Helper to set the json API key to the desired string
        /// </summary>
        /// <param name="apiKey">The string representation of the new API key value</param>
        private static void SetApiKey(string apiKey, string path)
        {
            string jsonString = File.ReadAllText(path);
            JObject json = JObject.Parse(jsonString);

            json["ApiKey"] = apiKey;

            File.WriteAllText(path, json.ToString());
        }

        /// <summary>
        /// Helper to read the API key from json
        /// </summary>
        /// <returns>A string representation of the json API key</returns>
        private static string GetJsonApiKey(string path)
        {
            string jsonString = File.ReadAllText(path);
            JObject json = JObject.Parse(jsonString);

            return json["ApiKey"]!.ToString();
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
