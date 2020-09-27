using Grpc.Net.Client;
using System;
using Part2;
using System.Threading.Tasks;
using GrpcServer;

namespace Sender
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new GetData.GetDataClient(channel);
            while (true)
            {
                Console.Write("Please enter the topic: ");
                string topic = Console.ReadLine();
                Console.Write("Please enter the message: ");
                string message = Console.ReadLine();
                var input = new ReceiveData { Topic = topic, Message = message };
                var reply = await client.GetDataInfoAsync(input);
                //Console.WriteLine($"{reply.Message}");
            }
            /*var input = new HelloRequest { topic = "Nigga" };
            var reply = await client.SayHelloAsync(input);
            Console.WriteLine(reply.Message);*/
            Console.ReadLine();
        }
    }
}
