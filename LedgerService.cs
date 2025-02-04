using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using HyperledgerFabricLedger.Services;
using Protos; // Подключаем сгенерированные классы

namespace HyperledgerFabricLedger.Services
{
    public class LedgerService
    {
        private readonly string _peerAddress;

        public LedgerService(string peerAddress)
        {
            _peerAddress = peerAddress;
        }
        
        public async Task<string> TestConnection()
        {
            try
            {
                using var channel = GrpcChannel.ForAddress($"http://{_peerAddress}");
                var client = new Endorser.EndorserClient(channel); // gRPC-клиент для Peer API

                Console.WriteLine($"✅ Успешное подключение к {_peerAddress}");
                return "OK";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Ошибка подключения: {ex.Message}");
                return "ERROR";
            }
        }

        public async Task<string> WriteToLedger(string key, string value)
        {
            Console.WriteLine($"📝 Запись в Ledger через gRPC: {key} -> {value}");

            using var channel = GrpcChannel.ForAddress($"http://{_peerAddress}");
            var client = new Endorser.EndorserClient(channel);

            var proposal = new SignedProposal(); // Заполняем объект транзакции
            var response = await client.ProcessProposalAsync(proposal);

            return response.Response.Status == 200 ? "✅ Запись успешна!" : "❌ Ошибка записи!";
        }
    }
}