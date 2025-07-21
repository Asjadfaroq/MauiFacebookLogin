using MauiFacebookLogin.Common;

namespace MauiFacebookLogin
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnFacebookLoginClicked(object sender, EventArgs e)
        {
           

            try
            {
                await SocialLoginManager.FaceBookAuthenticate();
            }
            catch (Exception ex)
            {
                await Dialogs.Alert(
               "Facebook Integration Setup",
               "To complete Facebook integration, please:\n\n1. Create a Facebook Developer account\n2. Generate your App ID and App Secret\n3. Add these keys to the Constants.cs file\n\nAll other Facebook integration code is already configured and ready to use.",
               "Got it");
            }
        }
    }

}
