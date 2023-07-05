using System;
using dotRMDY.Components.Services;
using MvvmCross.IoC;

namespace dotRMDY.Components.MvvmCross.Core.Services.Implementations
{
    public class Resolver : IResolver
    {
        private readonly IMvxIoCProvider _iocProvider;

        public Resolver(IMvxIoCProvider iocProvider)
        {
            _iocProvider = iocProvider;
        }

        public T Resolve<T>() where T : class
        {
            return _iocProvider.Resolve<T>();
        }

        public T Resolve<T>(Type type) where T : class
        {
            if (!typeof(T).IsAssignableFrom(type))
            {
                throw new InvalidOperationException("The type to resolve is not assignable from the generic type.");
            }

            return (T) Resolve(type);
        }

        public object Resolve(Type type)
        {
            return _iocProvider.Resolve(type);
        }
    }
}