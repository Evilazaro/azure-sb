using asbQueueProducer.Data;
using Azure.Core;
using Azure.Messaging.ServiceBus;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {

        var config = new ConfigurationBuilder()
            .AddJsonFile("local.settings.json")
            .Build();        
        
        // Create the Service Bus Client
        var sbClient = new ServiceBusClient(config.GetConnectionString("sbConnection"));

        // Create the Queue Sender
        var queueSender = sbClient.CreateSender("queue-test");

        Console.WriteLine("Starting sending messages to the Service Bus Queue");

        // Send 20000 messages to the queue
        for (int i = 0; i < 2000; i++)
        {
            // Message content in Json 
            var messageContent = JsonSerializer.Serialize(Dataverse.tableMetadata);
            
            // Creates a Service Bus Message object to be sent to the SB Queue
            var sbMessage = new ServiceBusMessage(messageContent);

            // Configure the Content Type of the message to Json
            sbMessage.ContentType = ContentType.ApplicationJson.ToString();
            sbMessage.Subject = $"ASB - Test for Table: {Dataverse.tableMetadata.Table.DisplayName} - {Dataverse.tableMetadata.Table.DateTime}";
            queueSender.SendMessageAsync(sbMessage).Wait();
            Console.WriteLine($"Message for the table {Dataverse.tableMetadata.Table.DisplayName} - {Dataverse.tableMetadata.Table.DateTime} has been sent!");
        }
    }
}