using System;
using System.Threading.Tasks;
using HyperledgerFabricLedger.Services;

namespace HyperledgerFabricLedger
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("🚀 Hyperledger Fabric Ledger на C#");

            var ledger = new LedgerService("localhost:7051");

            await ledger.TestConnection(); // Проверка соединения

            // Пример записи в Ledger
            string transactionId = await ledger.WriteToLedger("user1", "100 tokens");
            Console.WriteLine($"✅ Запись завершена. ID транзакции: {transactionId}");

            // Пример чтения из Ledger
            // string balance = await ledger.ReadFromLedger("user1");
            // Console.WriteLine($"💰 Баланс: {balance}");
        }
    }
}