using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Lisa.Excelsis.Mobile.Droid
{
    [Activity(Label = "Lisa.Excelsis.Mobile", Theme = "@android:style/Theme.Holo.Light", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}