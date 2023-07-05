using dotRMDY.Components.Services;
using MvvmCross.IoC;

namespace dotRMDY.Components.MvvmCross.Core.Services.Implementations
{
	public class Factory : IFactory
	{
		private readonly IMvxIoCProvider _iocProvider;

		public Factory(IMvxIoCProvider iocProvider)
		{
			_iocProvider = iocProvider;
		}

		public T Construct<T>(params object[] constructorParameters) where T : class
		{
			return _iocProvider.IoCConstruct<T>(constructorParameters);
		}
	}
}