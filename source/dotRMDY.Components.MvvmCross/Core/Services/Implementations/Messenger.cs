using System;
using CommunityToolkit.Mvvm.Messaging;

namespace dotRMDY.Components.MvvmCross.Core.Services.Implementations
{
    public class Messenger : dotRMDY.Components.Shared.Services.IMessenger
    {
        private readonly IMessenger _messenger;

        public Messenger(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void Register<TMessage>(object recipient, Action<object, TMessage> handler) where TMessage : class
        {
            if (_messenger.IsRegistered<TMessage>(recipient))
            {
                return;
            }

            _messenger.Register(recipient, new MessageHandler<object, TMessage>(handler));
        }

        public TMessage Send<TMessage>(TMessage message) where TMessage : class
        {
            return _messenger.Send(message);
        }

        public void Unregister<TMessage>(object recipient) where TMessage : class
        {
            if (_messenger.IsRegistered<TMessage>(recipient))
            {
                _messenger.Unregister<TMessage>(recipient);
            }
        }
    }
}