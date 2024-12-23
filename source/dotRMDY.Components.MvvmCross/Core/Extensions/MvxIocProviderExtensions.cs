using CommunityToolkit.Mvvm.Messaging;
using dotRMDY.Components.MvvmCross.Core.Services.Implementations;
using dotRMDY.Components.Services;
using dotRMDY.Components.Services.Implementations;
using JetBrains.Annotations;
using MvvmCross.IoC;

namespace dotRMDY.Components.MvvmCross.Core.Extensions
{
    [PublicAPI]
    public static class MvxIocProviderExtensions
    {
        public static IMvxIoCProvider RegisterAllComponentsCore(this IMvxIoCProvider ioCProvider)
        {
            return ioCProvider
                .RegisterIoCHelpers()
                .RegisterMessenger()
                .RegisterUtilityServices();
        }

        public static IMvxIoCProvider RegisterIoCHelpers(this IMvxIoCProvider iocProvider)
        {
            iocProvider.LazyConstructAndRegisterSingleton<IFactory, Factory>();
            iocProvider.LazyConstructAndRegisterSingleton<IResolver, Resolver>();

            return iocProvider;
        }

        public static IMvxIoCProvider RegisterMessenger(this IMvxIoCProvider iocProvider)
        {
            iocProvider.ConstructAndRegisterSingleton<CommunityToolkit.Mvvm.Messaging.IMessenger, WeakReferenceMessenger>();
            iocProvider.LazyConstructAndRegisterSingleton<Components.Services.IMessenger, Messenger>();

            return iocProvider;
        }

        public static IMvxIoCProvider RegisterUtilityServices(this IMvxIoCProvider iocProvider)
        {
            iocProvider.LazyConstructAndRegisterSingleton<ITimeKeeper, TimeKeeper>();
            iocProvider.LazyConstructAndRegisterSingleton<ITaskRunner, TaskRunner>();

            return iocProvider;
        }
    }
}