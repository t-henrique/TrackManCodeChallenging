using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.ApplicationModel;
using Presentation.ViewModels;

namespace InterviewApp.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private MainViewModel? _viewModel;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _viewModel = MainApplication.ServiceProvider?.GetRequiredService<MainViewModel>();

            SetContentView(Resource.Layout.activity_main);

            Toolbar? toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            Title = _viewModel?.Title;

            RecyclerView? recyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_friends);
            if (recyclerView != null)
            {
                recyclerView.SetLayoutManager(new LinearLayoutManager(this) { Orientation = RecyclerView.Vertical });
                recyclerView.SetAdapter(new FriendsAdapter(this, _viewModel?.Friends));
            }
        }

        protected override void OnResume()
        {
            base.OnResume();

            _viewModel?.LoadFriends();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

