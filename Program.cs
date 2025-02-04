using System;
using System.Threading.Tasks;

namespace HyperledgerFabricLedger
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("🚀 Запуск Hyperledger Fabric Ledger на C#...");

            var ledger = new LedgerService("localhost:7051"); // Адрес вашего Fabric Peer

            await ledger.TestConnection(); // Проверяем соединение с Peer

            Console.WriteLine("✅ Проверка завершена.");
        }
    }
}