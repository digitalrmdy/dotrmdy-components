using System.Threading.Tasks;
using dotRMDY.Components.Services.Implementations;
using FluentAssertions;
using Xunit;

namespace dotRMDY.Components.UnitTests.Services;

public class TaskRunnerTest
{
	[Fact]
	public void Run_Action()
	{
		// Arrange
		var sut = new TaskRunner();

		// Act
		var result = sut.Run(() => { });

		// Assert
		result.Should().NotBeNull();
	}

	[Fact]
	public void Run_Func()
	{
		// Arrange
		var sut = new TaskRunner();

		// Act
		var result = sut.Run(() => Task.CompletedTask);

		// Assert
		result.Should().NotBeNull();
	}

	[Fact]
	public void WhenAll()
	{
		// Arrange
		var sut = new TaskRunner();

		// Act
		var result = sut.WhenAll(Task.CompletedTask);

		// Assert
		result.Should().NotBeNull();
	}

	[Fact]
	public void WhenAll_TResult()
	{
		// Arrange
		var sut = new TaskRunner();

		// Act
		var result = sut.WhenAll(Task.FromResult(1));

		// Assert
		result.Should().NotBeNull();
	}

	[Fact]
	public void WhenAll_TResult_Array()
	{
		// Arrange
		var sut = new TaskRunner();

		// Act
		var result = sut.WhenAll(new[] { Task.FromResult(1) });

		// Assert
		result.Should().NotBeNull();
	}
}