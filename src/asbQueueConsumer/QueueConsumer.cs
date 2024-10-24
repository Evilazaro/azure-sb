using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace asbQueueConsumer
{
    public class QueueConsumer
    {
        private readonly ILogger<QueueConsumer> _logger;

        public QueueConsumer(ILogger<QueueConsumer> logger)
        {
            _logger = logger;
        }

        [Function(nameof(QueueConsumer))]
        public async Task Run(
            [ServiceBusTrigger("queue-test", Connection = "sbConnection")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Subject: {body}", message.Subject);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
