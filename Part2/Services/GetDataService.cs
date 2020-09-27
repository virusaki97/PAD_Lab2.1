using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class GetDataService : GetData.GetDataBase
    {
        private readonly ILogger<GetDataService> _logger;
        public static string topic;
        public static string message;

        public GetDataService(ILogger<GetDataService> logger)
        {
            _logger = logger;
        }

        public override Task<SendData> GetDataInfo(ReceiveData request, ServerCallContext context)
        {
            SendData output = new SendData();
            output.Message = request.Message;
            output.Topic = request.Topic;
            topic = request.Topic;
            message = request.Message;

            return Task.FromResult(output);
        }
        public override Task<SendData1> SendDataInfo(ReceiveData1 request, ServerCallContext context)
        {
            SendData1 output = new SendData1();
            if (request.Topic1 == topic && message != null)
            {
                output.Message1 = message;
                message = "";
            }
            return Task.FromResult(output);
        }

    }
}
