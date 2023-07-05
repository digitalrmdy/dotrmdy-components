using System.Threading.Tasks;
using JetBrains.Annotations;

namespace dotRMDY.Components.Helpers
{
	[PublicAPI]
	public interface INeedAsyncInitialization
	{
		Task Initialize();
	}
}