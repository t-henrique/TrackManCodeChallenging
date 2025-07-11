using System;
using Android.App;
using Android.Runtime;
using Data.Repositories;
using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.ApplicationModel;
using Presentation.ViewModels;

namespace InterviewApp.Droid
{
    [Application(Name = "dk.trackman.interviewapp_droid.MainApplication",
#if DEBUG
        Debuggable = true
#else
        Debuggable = false
#endif
    )]
    public class MainApplication : Application
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        public MainApplication() : base() { }
        public MainApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer) { }

        public override void OnCreate()
        {
            base.OnCreate();
            Platform.Init(this);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<MainViewModel>();
            serviceCollection.AddSingleton<IFriendsRepository, DemoFriendsRepository>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}