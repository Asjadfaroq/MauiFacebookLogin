using Android.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Xamarin.Google.Crypto.Tink.Proto;

namespace MauiFacebookLogin.Platforms.Android;
[Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
[IntentFilter(new[] { Intent.ActionView },
                  Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
                  DataScheme = Common.Constants.FB_DATA_SCHEME,
                  DataHost = Common.Constants.FB_DATA_HOST)]
public class WebAuthenticatorCallbackActivity : Microsoft.Maui.Authentication.WebAuthenticatorCallbackActivity
{
    
}

