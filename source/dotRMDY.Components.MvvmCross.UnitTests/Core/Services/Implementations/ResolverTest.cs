using System;
using dotRMDY.Components.MvvmCross.Core.Services.Implementations;
using dotRMDY.TestingTools;
using FakeItEasy;
using FluentAssertions;
using MvvmCross.IoC;
using Xunit;

namespace dotRMDY.Components.MvvmCross.UnitTests.Core.Services.Implementations
{
    public class ResolverTest : SutSupportingTest<Resolver>
    {
        private IMvxIoCProvider _mvxIocProvider = null!;

        protected override void SetupCustomSutDependencies(SutBuilder builder)
        {
            base.SetupCustomSutDependencies(builder);

            _mvxIocProvider = builder.AddFakedDependency<IMvxIoCProvider>();
        }

        [Fact]
        public void ResolveGeneric()
        {
            // Arrange
            A.CallTo(() => _mvxIocProvider.Resolve<ISimpleInterface>())
                .Returns(new SpecializedClass());

            // Act
            var resolvedObject = Sut.Resolve<ISimpleInterface>();

            // Assert
            A.CallTo(() => _mvxIocProvider.Resolve<ISimpleInterface>())
                .MustHaveHappenedOnceExactly();

            resolvedObject.Should().BeOfType<SpecializedClass>();
        }

        [Fact]
        public void ResolveGenericWithType()
        {
            // Arrange
            A.CallTo(() => _mvxIocProvider.Resolve(typeof(ISpecializedInterface)))
                .Returns(new SpecializedClass());

            // Act
            var resolvedObject = Sut.Resolve<ISimpleInterface>(typeof(ISpecializedInterface));

            // Assert
            A.CallTo(() => _mvxIocProvider.Resolve(typeof(ISpecializedInterface)))
                .MustHaveHappenedOnceExactly();

            resolvedObject.Should().BeOfType<SpecializedClass>();
        }

        [Fact]
        public void ResolveGenericWithType_ThrowsExceptionWhenTypeIsNotAssignable()
        {
            // Act
            Action act = () => Sut.Resolve<ISpecializedInterface>(typeof(ISimpleInterface));

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }

        private interface ISimpleInterface
        {
        }

        private interface ISpecializedInterface : ISimpleInterface
        {
        }

        private class SpecializedClass : ISpecializedInterface
        {
        }
    }
}