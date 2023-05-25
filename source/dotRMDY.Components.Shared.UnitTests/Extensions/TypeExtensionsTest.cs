using System;
using dotRMDY.Components.Shared.Extensions;
using FluentAssertions;
using Xunit;

namespace dotRMDY.Components.Shared.UnitTests.Extensions
{
    public class TypeExtensionsTest
    {
        [Fact]
        public void GetRealTypeName()
        {
            // Arrange
            var type = typeof(Func<TypeExtensionsTest, bool>);
            
            // Act
            var result = type.GetRealTypeName();
            
            // Assert
            result.Should().Be("Func<TypeExtensionsTest, Boolean>");
        }
    }
}