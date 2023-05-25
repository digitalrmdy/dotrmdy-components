using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace dotRMDY.Components.Shared.Extensions
{
    [PublicAPI]
    public static class TaskExtensions
    {
        public static async Task<List<T>> ToListAsync<T>(this Task<IEnumerable<T>> enumerableTask)
        {
            var enumerable = await enumerableTask;
            return enumerable.ToList();
        }
    }
}