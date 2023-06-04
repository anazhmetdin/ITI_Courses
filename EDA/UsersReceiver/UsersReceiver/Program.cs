using Azure.Messaging.ServiceBus;
using System.Diagnostics;

namespace UsersReceiver
{
    internal class Program
    {
        const string connectionString = "Endpoint=sb://edatest.servicebus.windows.net/;SharedAccessKeyName=usersConsumer;SharedAccessKey=tLQEKz6IAdettKPsKhIlIGOQD2fuBeFls+ASbL7/IhI=;EntityPath=users";
        const string queueName = "users";

        static ServiceBusClient? ServiceBusClient;

        static void Main(string[] args)
        {
            var clientOptions = new ServiceBusClientOptions
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets
            };

            ServiceBusClient = new ServiceBusClient(
                connectionString,
            clientOptions);

            var processor = ServiceBusClient.CreateProcessor(queueName, new ServiceBusProcessorOptions());

            try
            {
                // add handler to process messages
                processor.ProcessMessageAsync += MessageHandler;

                // add handler to process any errors
                processor.ProcessErrorAsync += ErrorHandler;

                // start processing 
                processor.StartProcessingAsync();

                Console.WriteLine("Wait for a minute and then press any key to end the processing");
                Console.ReadKey();

                // stop processing 
                Console.WriteLine("\nStopping the receiver...");
                processor.StopProcessingAsync();
                Console.WriteLine("Stopped receiving messages");
            }
            finally
            {
                // Calling DisposeAsync on client types is required to ensure that network
                // resources and other unmanaged objects are properly cleaned up.
                processor.DisposeAsync();
                ServiceBusClient.DisposeAsync();
            }
        }

        // handle received messages
        static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            Console.WriteLine($"Received: {body}");

            // complete the message. message is deleted from the queue. 
            await args.CompleteMessageAsync(args.Message);
        }

        // handle any errors when receiving messages
        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }
    }
}