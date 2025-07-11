using Data.Repositories;
using Domain.Repositories;
using Foundation;
using Microsoft.Extensions.DependencyInjection;
using ObjCRuntime;
using Presentation.ViewModels;
using UIKit;

namespace InterviewApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register ("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate {

        [Export("window")]
        public UIWindow Window { get; set; }

        public static ServiceProvider? ServiceProvider { get; private set; }

        public AppDelegate(NativeHandle handle) : base(handle)
        {
        }

        [Export ("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
        {
            SetupIoC();

            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            Window.RootViewController = new UINavigationController(new ViewController());

            Window.MakeKeyAndVisible();

            return true;
        }

        private static void SetupIoC()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<MainViewModel>();
            serviceCollection.AddSingleton<IFriendsRepository, DemoFriendsRepository>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}


