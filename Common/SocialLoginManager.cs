using System.Security.Authentication;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MauiFacebookLogin.Common;
public static class SocialLoginManager
{
    public static async Task FaceBookAuthenticate()
    {
        try
        {
            var authUrl = new Uri(
            $"{Constants.FACEBOOK_AUTH_URL}" +
            $"?client_id={Constants.FACEBOOK_CLIENT_ID}" +
            $"&redirect_uri={WebUtility.UrlEncode(Constants.FACEBOOK_REDIRECT_URL)}" +
            $"&response_type=token" +
            $"&scope={WebUtility.UrlEncode(Constants.FACEBOOK_SCOPE)}");

            var result = await Authenticate(authUrl, Constants.FACEBOOK_REDIRECT_URL);
            if (result != null && result.Properties.ContainsKey("access_token"))
            {
                String Token = result.Properties["access_token"];
                if (string.IsNullOrEmpty(Token))
                {
                    await Dialogs.Toast("Failed to Login");
                    return;
                }
                return;
            }
            else
            {
                await Dialogs.Toast("Failed to Login");
                return;
            }
        }
        catch (TaskCanceledException ex)
        {
            return;
        }
        catch (Exception e)
        {
            return;
        }
    }
    public static async Task<WebAuthenticatorResult> Authenticate(Uri AuthUrl, string CallBackurl)
    {
        try
        {
            var authResult = await WebAuthenticator.AuthenticateAsync(
                new WebAuthenticatorOptions
                {
                    Url = AuthUrl,
                    CallbackUrl = new Uri(CallBackurl)
                });
            return authResult;
        }
        catch (Exception e)
        {
            await Dialogs.Toast(e.Message);
            return null;
        }
    }
}

