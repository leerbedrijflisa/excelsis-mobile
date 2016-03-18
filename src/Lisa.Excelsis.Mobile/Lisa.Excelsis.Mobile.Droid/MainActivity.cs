using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Graphics.Drawables;

namespace Lisa.Excelsis.Mobile.Droid
{
    [Activity(Label = "", Theme = "@android:style/Theme.Holo.Light", Icon = "@drawable/logo_excelsis_beeld_rgb_2016", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());

            ActionBar.SetIcon ( new ColorDrawable (Android.Graphics.Color.Transparent));
        }
    }
}