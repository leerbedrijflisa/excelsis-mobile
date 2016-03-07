using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Lisa.Excelsis.Mobile.Droid
{
    [Activity(Label = "Excelsis", Theme = "@android:style/Theme.Holo.Light", Icon = "@drawable/logo_excelsis_beeld_rgb_2016", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
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