using System.Threading.Tasks;
using JetBrains.Annotations;

namespace dotRMDY.Components.Shared.Helpers
{
	[PublicAPI]
	public interface INeedAsyncInitialization
	{
		Task Initialize();
	}
}