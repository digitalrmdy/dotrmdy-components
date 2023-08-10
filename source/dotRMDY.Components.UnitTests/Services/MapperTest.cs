using dotRMDY.Components.Services;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace dotRMDY.Components.UnitTests.Services
{
	public class MapperTest
	{
		[Fact]
		public void MapOrDefault()
		{
			// Arrange
			IMapper<From, To> sut = A.Fake<TestMapper>();

			var originalObject = A.Dummy<From>();

			// Act
			var result = sut.MapOrDefault(originalObject);

			// Assert
			A.CallTo(() => sut.Map(originalObject))
				.MustHaveHappenedOnceExactly();

			result.Should().NotBeNull();
		}

		[Fact]
		public void MapOrDefault_MapNull()
		{
			// Arrange
			IMapper<From, To> sut = A.Fake<TestMapper>();

			// Act
			var result = sut.MapOrDefault(null);

			// Assert
			A.CallTo(() => sut.Map(A<From>._))
				.MustNotHaveHappened();

			result.Should().BeNull();
		}

		public class TestMapper : IMapper<From, To>
		{
			public virtual To Map(From from) => new();
		}

		public class From
		{
		}

		public class To
		{
		}
	}
}