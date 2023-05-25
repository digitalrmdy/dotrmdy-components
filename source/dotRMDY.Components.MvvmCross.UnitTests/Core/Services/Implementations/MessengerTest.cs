using System;
using CommunityToolkit.Mvvm.Messaging;
using dotRMDY.Components.MvvmCross.Core.Services.Implementations;
using dotRMDY.TestingTools;
using FakeItEasy;
using FakeItEasy.Configuration;
using FluentAssertions;
using Xunit;

namespace dotRMDY.Components.MvvmCross.UnitTests.Core.Services.Implementations
{
	public class MessengerTest : SutSupportingTest<Messenger>
	{
		private IMessenger _communityToolkitMessenger = null!;

		protected override void SetupCustomSutDependencies(SutBuilder builder)
		{
			base.SetupCustomSutDependencies(builder);

			_communityToolkitMessenger = builder.AddFakedDependency<IMessenger>();
		}

		[Theory]
		[InlineData(false)]
		[InlineData(true)]
		public void Register(bool alreadyRegistered)
		{
			// Arrange
			var recipient = new object();

			var handlerExecuted = false;
			var handler = new Action<object, TestMessage>((_, _) => handlerExecuted = true);

			ACallToCommunityToolkitMessengerIsRegistered<object, TestMessage>(recipient).Returns(alreadyRegistered);

			MessageHandler<object, TestMessage>? capturedMessageHandler = null;
			ACallToCommunityToolkitMessengerRegister<object, TestMessage>(recipient)
				.Invokes(call => capturedMessageHandler = call.GetArgument<MessageHandler<object, TestMessage>>(2));

			// Act
			Sut.Register(recipient, handler);

			// Assert
			if (alreadyRegistered)
			{
				ACallToCommunityToolkitMessengerIsRegistered<object, TestMessage>(recipient).MustHaveHappenedOnceExactly();
				ACallToCommunityToolkitMessengerRegister<object, TestMessage>(recipient).MustNotHaveHappened();
			}
			else
			{
				ACallToCommunityToolkitMessengerIsRegistered<object, TestMessage>(recipient).MustHaveHappenedOnceExactly();
				ACallToCommunityToolkitMessengerRegister<object, TestMessage>(recipient).MustHaveHappenedOnceExactly();

				capturedMessageHandler.Should().NotBeNull();
				capturedMessageHandler!.Invoke(this, new TestMessage());

				handlerExecuted.Should().BeTrue();
			}
		}

		[Fact]
		public void Send()
		{
			// Arrange
			var message = new TestMessage();

			// Act
			Sut.Send(message);

			// Assert
			ACallToCommunityToolkitMessengerSend(message).MustHaveHappenedOnceExactly();
		}

		[Theory]
		[InlineData(false)]
		[InlineData(true)]
		public void Unregister(bool alreadyUnregistered)
		{
			// Arrange
			var recipient = new object();

			ACallToCommunityToolkitMessengerIsRegistered<object, TestMessage>(recipient)
				.Returns(!alreadyUnregistered);

			// Act
			Sut.Unregister<TestMessage>(recipient);

			// Assert
			if (alreadyUnregistered)
			{
				ACallToCommunityToolkitMessengerIsRegistered<object, TestMessage>(recipient).MustHaveHappenedOnceExactly();
				ACallToCommunityToolkitMessengerUnregister<object, TestMessage>(recipient).MustNotHaveHappened();
			}
			else
			{
				ACallToCommunityToolkitMessengerIsRegistered<object, TestMessage>(recipient).MustHaveHappenedOnceExactly();
				ACallToCommunityToolkitMessengerUnregister<object, TestMessage>(recipient).MustHaveHappenedOnceExactly();
			}
		}

		private IAnyCallConfigurationWithReturnTypeSpecified<bool> ACallToCommunityToolkitMessengerIsRegistered<TRecipient, TMessage>(
			TRecipient recipient)
			where TRecipient : class
			where TMessage : class
		{
			return A.CallTo(_communityToolkitMessenger)
				.Where(call => call.Method.Name == nameof(_communityToolkitMessenger.IsRegistered)
				               && call.Method.GetGenericArguments().Length == 2
				               && call.Method.GetGenericArguments()[0] == typeof(TMessage)
				               && call.GetArgument<TRecipient>(0) == recipient)
				.WithReturnType<bool>();
		}

		private IAnyCallConfigurationWithNoReturnTypeSpecified ACallToCommunityToolkitMessengerRegister<TRecipient, TMessage>(
			TRecipient recipient)
			where TRecipient : class
			where TMessage : class
		{
			return A.CallTo(_communityToolkitMessenger)
				.Where(call => call.Method.Name == nameof(_communityToolkitMessenger.Register)
				               && call.Method.GetGenericArguments().Length == 3
				               && call.GetArgument<TRecipient>(0) == recipient
				               && call.GetArgument<MessageHandler<TRecipient, TMessage>>(2) != null);
		}

		private IAnyCallConfigurationWithReturnTypeSpecified<TMessage> ACallToCommunityToolkitMessengerSend<TMessage>(
			TMessage message)
			where TMessage : class
		{
			return A.CallTo(_communityToolkitMessenger)
				.Where(call => call.Method.Name == nameof(_communityToolkitMessenger.Send)
				               && call.Method.GetGenericArguments().Length == 2
				               && call.GetArgument<TMessage>(0) == message)
				.WithReturnType<TMessage>();
		}

		private IAnyCallConfigurationWithNoReturnTypeSpecified ACallToCommunityToolkitMessengerUnregister<TRecipient, TMessage>(
			TRecipient recipient)
			where TRecipient : class
		{
			return A.CallTo(_communityToolkitMessenger)
				.Where(call => call.Method.Name == nameof(_communityToolkitMessenger.Unregister)
				               && call.Method.GetGenericArguments().Length == 2
				               && call.Method.GetGenericArguments()[0] == typeof(TMessage)
				               && call.GetArgument<TRecipient>(0) == recipient);
		}

		private class TestMessage
		{
		}
	}
}