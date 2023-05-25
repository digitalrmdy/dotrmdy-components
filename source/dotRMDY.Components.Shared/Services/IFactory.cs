using JetBrains.Annotations;

namespace dotRMDY.Components.Shared.Services
{
    [PublicAPI]
    public interface IFactory
    {
        T Construct<T>(params object[] constructorParameters) where T : class;
    }
}