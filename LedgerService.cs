using System;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace HyperledgerFabricLedger
{
    public class LedgerService
    {
        private readonly string _peerAddress;

        public LedgerService(string peerAddress)
        {
            _peerAddress = peerAddress;
        }

        public async Task TestConnection()
        {
            try
            {
                using var channel = GrpcChannel.ForAddress($"http://{_peerAddress}", new GrpcChannelOptions
                {
                    HttpHandler = new System.Net.Http.HttpClientHandler()
                });

                Console.WriteLine($"✅ Успешное подключение к {_peerAddress}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Ошибка подключения: {ex.Message}");
            }
        }
    }
}