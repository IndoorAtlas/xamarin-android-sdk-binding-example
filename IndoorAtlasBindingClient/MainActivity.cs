using Android.App;
using Android.Widget;
using Android.OS;
using Com.Indooratlas.Android.Sdk;

namespace IndoorAtlasBindingClient
{
    [Activity(Label = "IndoorAtlasBindingClient", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity, IALocationListener
    {
        IALocationManager locationManager;
		TextView textViewStatus;
		TextView textViewLocation;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			textViewStatus = FindViewById(Resource.Id.textViewStatus) as TextView;
			textViewLocation = FindViewById(Resource.Id.textViewLocation) as TextView;

			locationManager = IALocationManager.Create(this);

           
        }


		protected override void OnResume()
        {
            base.OnResume();
            locationManager.RequestLocationUpdates(IALocationRequest.Create(),
                                                   this);
        }

        protected override void OnPause()
        {
            base.OnPause();
            locationManager.RemoveLocationUpdates(this);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            locationManager.Destroy();
        }

		public void OnLocationChanged(IALocation location)
        {
			textViewLocation.Text = location.ToString();
        }

        public void OnStatusChanged(string provider, int status, Bundle extras)
        {
			textViewStatus.Text = provider + ":" + status + ", " + extras;
        }
    }
}

