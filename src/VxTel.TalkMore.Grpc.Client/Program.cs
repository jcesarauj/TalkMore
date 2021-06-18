using Grpc.Net.Client;
using VxTel.TalkMore.Grpc.Client;
using System;
using System.Threading.Tasks;

namespace VxTel.TalkMore.Grpc.Client
{
	class Program
	{
		static async Task Main(string[] args)
		{
			using var channel = GrpcChannel.ForAddress("https://localhost:5001");
			var client = new CalculateValueCall.CalculateValueCallClient(channel);
			Console.WriteLine(DateTime.Now);
			var reply = await client.CalculateValueCallAsync(new CalculateValueCallRequest { Origin = 11, Destiny = 16, PlanId = 2, CallTimeInMinutes = 120 });
			Console.WriteLine(DateTime.Now);
		}
	}
}
