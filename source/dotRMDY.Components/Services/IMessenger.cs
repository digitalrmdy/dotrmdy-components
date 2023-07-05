using System;
using JetBrains.Annotations;

namespace dotRMDY.Components.Services
{
	[PublicAPI]
	public interface IMessenger
	{
		void Register<TMessage>(object recipient, Action<object, TMessage> handler) where TMessage : class;
		TMessage Send<TMessage>(TMessage message) where TMessage : class;
		void Unregister<TMessage>(object recipient) where TMessage : class;
	}
}