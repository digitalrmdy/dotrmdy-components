using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotRMDY.Components.Extensions;
using FluentAssertions;
using Xunit;

namespace dotRMDY.Components.UnitTests.Extensions
{
    public class TaskExtensionsTest
    {
        [Fact]
        public async Task ToListAsync()
        {
            // Arrange
            var enumerableTask = Task.FromResult(Enumerable.Range(1, 3));

            // Act
            var list = await enumerableTask.ToListAsync();

            // Assert
            list.Should().BeOfType<List<int>>();
            list.Should().ContainInOrder(1, 2, 3);
        }
    }
}