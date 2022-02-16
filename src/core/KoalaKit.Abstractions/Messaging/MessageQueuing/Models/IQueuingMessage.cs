﻿namespace KoalaKit.Messaging
{
    /// <summary>
    /// the message being removed upon being dequeued
    /// </summary>
    public interface IQueuingMessage : IKoalaMessage
    {
        string QueueName { get; }
    }
}
