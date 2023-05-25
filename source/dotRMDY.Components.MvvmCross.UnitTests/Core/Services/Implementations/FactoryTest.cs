using System.Diagnostics.CodeAnalysis;
using dotRMDY.Components.MvvmCross.Core.Services.Implementations;
using dotRMDY.TestingTools;
using FakeItEasy;
using FluentAssertions;
using MvvmCross.IoC;
using Xunit;

namespace dotRMDY.Components.MvvmCross.UnitTests.Core.Services.Implementations
{
    public class FactoryTest : SutSupportingTest<Factory>
    {
        private IMvxIoCProvider _mvxIocProvider = null!;

        protected override void SetupCustomSutDependencies(SutBuilder builder)
        {
            base.SetupCustomSutDependencies(builder);

            _mvxIocProvider = builder.AddFakedDependency<IMvxIoCProvider>();
        }

        [Fact]
        public void Construct()
        {
            // Act
            var constructedObject = Sut.Construct<SimpleClass>(true);

            // Assert
            A.CallTo(() => _mvxIocProvider.IoCConstruct<SimpleClass>(new object[] { true }))
                .MustHaveHappenedOnceExactly();

            constructedObject.Should().NotBeNull();
        }

        [SuppressMessage("ReSharper", "ClassNeverInstantiated.Local")]
        private class SimpleClass
        {
            [SuppressMessage("ReSharper", "UnusedParameter.Local")]
            public SimpleClass(IMvxIoCProvider iocProvider, bool value)
            {
            }
        }
    }
}