using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace SPMI_CHD
{
    [Activity(Label = "WebApplicationView")]
    public class WebApplicationView : Activity
    {
        WebView webView1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.web_application_view);

            // Create your application here

            //akong gideclare ang url sa official website
            string sourceURL = "https://spmi-health-declaration.vercel.app/login";

            //akong gitawag ang id sa webview gikan sa xml
            webView1 = FindViewById<WebView>(Resource.Id.webView1);

            //akong gitawag ang internal class na WebViewClientClass
            webView1.SetWebViewClient(new WebViewClientClass());
            //gipasa dire ang url string na ako gideclara
            webView1.LoadUrl(sourceURL);

            //gi configure ang javascript para mugana sa akong application
            WebSettings websettings = webView1.Settings;
            websettings.JavaScriptEnabled = true;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
    internal class WebViewClientClass : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            view.LoadUrl(url);
            return true;
        }
    }
}