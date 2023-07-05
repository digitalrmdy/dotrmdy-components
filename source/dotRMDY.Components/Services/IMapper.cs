using JetBrains.Annotations;

namespace dotRMDY.Components.Services
{
	[PublicAPI]
	public interface IMapper<in TFrom, out TTo>
	{
		TTo Map(TFrom from);
	}
}