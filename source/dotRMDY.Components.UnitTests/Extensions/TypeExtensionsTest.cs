using System;
using dotRMDY.Components.Extensions;
using FluentAssertions;
using Xunit;

namespace dotRMDY.Components.UnitTests.Extensions
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