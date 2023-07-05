using System;
using JetBrains.Annotations;

namespace dotRMDY.Components.Services
{
    [PublicAPI]
    public interface IResolver
    {
        T Resolve<T>() where T : class;
        T Resolve<T>(Type type) where T : class;
        object Resolve(Type type);  
    }
}