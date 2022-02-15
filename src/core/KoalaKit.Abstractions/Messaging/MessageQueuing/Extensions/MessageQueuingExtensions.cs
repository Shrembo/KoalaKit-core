﻿using KoalaKit.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KoalaKit.Messaging
{
    public static class MessageQueuingExtensions
    {
        public static KoalaOptionsBuilder AddMessageQueuingCore(this KoalaOptionsBuilder koala)
        {
            if(koala.Configuration == null )
                throw new ArgumentNullException();

            koala.Services.Configure<MessageQueuingOptions>(options => koala.Configuration.GetSection(nameof(MessageQueuingOptions)).Bind(options));
            koala.Services.AddScoped(typeof(IMessageQueueFactory<>), typeof(DefaultMessageQueueFactory<>));
            koala.Services.AddScoped(typeof(IMessageQueuingConnectionSelector<>), typeof(DefaultMessageQueuingConnectionSelector<>));
            return koala;
        }
    }
}
