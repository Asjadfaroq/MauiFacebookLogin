using CommunityToolkit.Maui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiFacebookLogin.Common;
public static class Dialogs
{
    public static async Task Toast(string message)
    {
        await CommunityToolkit.Maui.Alerts.Toast.Make(message, ToastDuration.Short, 14).Show();
    }
    public static async Task Alert(string title, string message, string okText = "Ok")
    {
        await Application.Current.MainPage.DisplayAlert(title, message, okText);
    }
    public static async Task Confirm(string message, string title = "Confirm", string okText = "Ok", string cancelText = "Cancel", Action ok = null, Action cancel = null)
    {
        bool answer = await Application.Current.MainPage.DisplayAlert(title, message, okText, cancelText);
        if (answer) ok?.Invoke();
        else cancel?.Invoke();
    }
}


