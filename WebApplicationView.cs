using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Transitions;
using Android.Transitions;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace SPMI_CHD
{
    [Activity(Label = "WebApplicationView")]
    public class WebApplicationView : Activity
    {
        WebView webView1;
        ImageView imageView1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.web_application_view);

            // Create your application here

            //akong gideclare ang url sa official website
            string sourceURL = "https://spmi-health-declaration.vercel.app/login";

            //akong gitawag ang id gikan sa xml
            webView1 = FindViewById<WebView>(Resource.Id.webView1);
            imageView1 = FindViewById<ImageView>(Resource.Id.imageView1);
            //loadingBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            //akong gitawag ang internal class na WebViewClientClass
            webView1.SetWebViewClient(new WebViewClientClass(this));
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
        internal class WebViewClientClass : WebViewClient
        {
            public Activity mActivity;
            public WebViewClientClass(Activity mActivity)
            {
                this.mActivity = mActivity;
                //imageView1 = FindViewsWith<ImageView>(Resource.Id.loadbarimage);
            }
            ProgressDialog loadingBar;
            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                view.LoadUrl(url);
                return true;
            }
            public override void OnPageStarted(WebView view, string url, Android.Graphics.Bitmap favicon)
            {
                loadingBar = ProgressDialog.Show(mActivity, "Loading...", "Please wait it depends on your internet connection...", true);
                if (loadingBar != null)
                {
                    if (loadingBar.IsShowing == false)
                        Toast.MakeText(mActivity, "Loading...", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(mActivity, "Processing...", ToastLength.Long).Show();
                }
                base.OnPageStarted(view, url, favicon);
            }
            public override void OnPageFinished(WebView view, string url)
            {
                if (loadingBar != null)
                    if (loadingBar.IsShowing)
                        loadingBar.Dismiss();
                base.OnPageFinished(view, url);
            }
        }
        public override bool OnKeyDown(Android.Views.Keycode keyCode, Android.Views.KeyEvent e)
        {
            if (keyCode == Keycode.Back && webView1.CanGoBack())
            {
                webView1.GoBack();
                return true;
            }

            return base.OnKeyDown(keyCode, e);
        }
    }
}