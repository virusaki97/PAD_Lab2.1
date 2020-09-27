using Grpc.Net.Client;
using System;
using Part2;
using System.Threading.Tasks;
using GrpcServer;

namespace Receiver
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            
            var client = new GetData.GetDataClient(channel);
            Console.WriteLine("Receiver");
            Console.Write("Please enter the topic: ");
            string topic = Console.ReadLine();
            
            while(true)
            {
                Task.Delay(200);

                var input = new ReceiveData1 { Topic1 = topic };
                
                var reply = await client.SendDataInfoAsync(input);
                if (reply.Message1 != "")
                    Console.WriteLine(reply.Message1);
            }
        }
    }
}
