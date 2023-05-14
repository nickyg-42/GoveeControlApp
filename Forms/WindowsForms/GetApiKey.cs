namespace GoveeControl.Forms.WindowsForms
{
    public partial class GetApiKey : Form
    {
        public GetApiKey()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Helper to return textbox content
        /// </summary>
        /// <returns></returns>
        public string GetApiKeyText()
        {
            return apiKeyTextBox.Text;
        }

        /// <summary>
        /// Enter button click event, validates API key
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
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
