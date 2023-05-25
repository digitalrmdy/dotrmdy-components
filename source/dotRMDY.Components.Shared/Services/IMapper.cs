using JetBrains.Annotations;

namespace dotRMDY.Components.Shared.Services
{
	[PublicAPI]
	public interface IMapper<in TFrom, out TTo>
	{
		TTo Map(TFrom from);
	}
}