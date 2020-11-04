using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Webkit;
using Android.Graphics;

namespace SPMI_CHD
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/spmi_ico", Theme = "@style/AppTheme", MainLauncher = true, ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize | Android.Content.PM.ConfigChanges.Orientation, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var txtaddress = FindViewById<TextView>(Resource.Id.txtaddress);
            var txttitle = FindViewById<TextView>(Resource.Id.txttitle);
            var txtcopyright = FindViewById<TextView>(Resource.Id.txtcopyright);
            var btngoto = FindViewById<Button>(Resource.Id.btngoto);
            var txtBibleverse = FindViewById<TextView>(Resource.Id.txtBibleverse);
            var txtBookof = FindViewById<TextView>(Resource.Id.txtBookof);

            Typeface font1 = Typeface.CreateFromAsset(Assets, "Poppins-Thin.ttf");
            txtaddress.SetTypeface(font1, TypefaceStyle.Normal);

            Typeface font2 = Typeface.CreateFromAsset(Assets, "Poppins-Medium.ttf");
            txttitle.SetTypeface(font2, TypefaceStyle.Normal);

            Typeface font3 = Typeface.CreateFromAsset(Assets, "Poppins-Light.ttf");
            txtcopyright.SetTypeface(font3, TypefaceStyle.Normal);

            Typeface font4 = Typeface.CreateFromAsset(Assets, "Poppins-Regular.ttf");
            btngoto.SetTypeface(font4, TypefaceStyle.Normal);

            Typeface font5 = Typeface.CreateFromAsset(Assets, "Poppins-LightItalic.ttf");
            txtBibleverse.SetTypeface(font5, TypefaceStyle.Normal);

            Typeface font6 = Typeface.CreateFromAsset(Assets, "Poppins-Regular.ttf");
            txtBookof.SetTypeface(font6, TypefaceStyle.Normal);

            Button btnGoto = FindViewById<Button>(Resource.Id.btngoto);
            btnGoto.Click += delegate { StartActivity(typeof(WebApplicationView)); };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}