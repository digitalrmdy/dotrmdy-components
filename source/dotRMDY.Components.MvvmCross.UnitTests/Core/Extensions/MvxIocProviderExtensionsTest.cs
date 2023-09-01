using CommunityToolkit.Mvvm.Messaging;
using dotRMDY.Components.MvvmCross.Core.Extensions;
using dotRMDY.Components.MvvmCross.Core.Services.Implementations;
using dotRMDY.Components.MvvmCross.UnitTests.TestHelpers;
using dotRMDY.Components.Services;
using dotRMDY.Components.Services.Implementations;
using FakeItEasy;
using MvvmCross.IoC;
using Xunit;

namespace dotRMDY.Components.MvvmCross.UnitTests.Core.Extensions
{
	public class MvxIocProviderExtensionsTest
	{
		[Fact]
		public void RegisterAllComponentsCore()
		{
			// Arrange
			var mvxIocProvider = A.Fake<IMvxIoCProvider>();

			// Act
			mvxIocProvider.RegisterAllComponentsCore();

			// Assert
			VerifyIoCHelpersRegistrations(mvxIocProvider);
			VerifyMessengerRegistrations(mvxIocProvider);
			VerifyUtilityServicesRegistrations(mvxIocProvider);
		}

		[Fact]
		public void RegisterIoCHelpers()
		{
			// Arrange
			var mvxIocProvider = A.Fake<IMvxIoCProvider>();

			// Act
			mvxIocProvider.RegisterIoCHelpers();

			// Assert
			VerifyIoCHelpersRegistrations(mvxIocProvider);
		}

		[Fact]
		public void RegisterMessenger()
		{
			// Arrange
			var mvxIocProvider = A.Fake<IMvxIoCProvider>();

			// Act
			mvxIocProvider.RegisterMessenger();

			// Assert
			VerifyMessengerRegistrations(mvxIocProvider);
		}

		[Fact]
		public void RegisterUtilityServices()
		{
			// Arrange
			var mvxIocProvider = A.Fake<IMvxIoCProvider>();

			// Act
			mvxIocProvider.RegisterUtilityServices();

			// Assert
			VerifyUtilityServicesRegistrations(mvxIocProvider);
		}

		private static void VerifyIoCHelpersRegistrations(IMvxIoCProvider mvxIocProvider)
		{
			mvxIocProvider.VerifyLazySingletonRegistration<IFactory, Factory>()
				.MustHaveHappenedOnceExactly();
			mvxIocProvider.VerifyLazySingletonRegistration<IResolver, Resolver>()
				.MustHaveHappenedOnceExactly();
		}

		private static void VerifyMessengerRegistrations(IMvxIoCProvider mvxIocProvider)
		{
			mvxIocProvider.VerifySingletonRegistration<CommunityToolkit.Mvvm.Messaging.IMessenger, WeakReferenceMessenger>()
				.MustHaveHappenedOnceExactly();
			mvxIocProvider.VerifyLazySingletonRegistration<Components.Services.IMessenger, Messenger>()
				.MustHaveHappenedOnceExactly();
		}

		private static void VerifyUtilityServicesRegistrations(IMvxIoCProvider mvxIocProvider)
		{
			mvxIocProvider.VerifyLazySingletonRegistration<ITimeKeeper, TimeKeeper>()
				.MustHaveHappenedOnceExactly();
			mvxIocProvider.VerifyLazySingletonRegistration<ITaskRunner, TaskRunner>()
				.MustHaveHappenedOnceExactly();
		}
	}
}