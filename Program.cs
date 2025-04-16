using System;
using System.Globalization;

namespace modul8_103022300046
{
    class Program
    {
        static void Main(string[] args)
        {
            //membuat objek BankTransferConfig
            BankTransferConfig bankTransferConfig = new BankTransferConfig();
            Config config = bankTransferConfig.ReadConfigFile();

            //menampilkan menu bahasa
            Console.WriteLine("pilih bahasa:");
            Console.WriteLine("1.english");
            Console.WriteLine("2.indonesia");

            //memilih bahasa
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                config.lang = "en";
            }
            else if (choice == 2)
            {
                config.lang = "id";
            }

            //insert amount
            if (config.lang == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer:");
            }
            else
            {
                Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
            }

            //input amount
            int amount = int.Parse(Console.ReadLine());
            int biayaTransfer = 0;

            //mengecek transfer fee
            if (amount < config.transfer.threshold)
            {
                biayaTransfer = config.transfer.low_fee;
            }
            else if (amount > config.transfer.threshold)
            {
                biayaTransfer = config.transfer.high_fee;
            }

            //menampilkan transfer fee
            if (config.lang == "en")
            {
                Console.WriteLine($"Transfer fee = {biayaTransfer} and Total amount {amount + biayaTransfer}");
            }
            else if (config.lang == "id")
            {
                Console.WriteLine($"Biaya transfer = {biayaTransfer} dan Total biaya {amount + biayaTransfer}");
            }

            //menampilkan metode transfer
            if (config.lang == "en")
            {
                Console.WriteLine("Select transfer method");
            }
            else if (config.lang == "id")
            {
                Console.WriteLine("Pilih metode transfer");
            }

            //menampilkan metode transfer
            for (int i = 0; i < config.methods.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {config.methods[i]}");
            }
            //memilih metode transfer
            int methodChoice = int.Parse(Console.ReadLine());

            //konfirmasi transfer
            if (config.lang == "en")
            {
                Console.WriteLine($"Please type {config.confirmation.en} to confirm the transaction");
            }
            else if (config.lang == "id")
            {
                Console.WriteLine($"Ketik {config.confirmation.id} untuk mengkonfirmasi transaksi");
            }
            string confirmation = Console.ReadLine();

            //menampilkan hasil konfirmasi
            if (config.lang == "en")
            {
                if (confirmation == config.confirmation.en)
                {
                    Console.WriteLine("Transaction success");
                }
                else
                {
                    Console.WriteLine("Transfer is cancelled");
                }
            }
            else if (config.lang == "id")
            {
                if (confirmation == config.confirmation.id)
                {
                    Console.WriteLine("Transaksi berhasil");
                }
                else
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }


            Console.WriteLine();
        }
    }
}
