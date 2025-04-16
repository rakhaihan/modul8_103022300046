using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022300046
{
    //class untuk konfigurasi transfer bank
    class BankTransferConfig
    {
        public Config config;
        public const String filePath = @"D:\Rakha\modul8_103022300046\bank_transfer_config.json";
       //method untuk membaca file dan menulis file baru jika belum ada
        public BankTransferConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception ex)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }

        //membuat method untuk membaca file config
        public Config ReadConfigFile()
        {
            String configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<Config>(configJsonData);
            return config;
        }

        //membuat method untuk menulis file config
        public void SetDefault()
        {
            config = new Config
            {
                lang = "en",
                transfer = new Config.Transfer
                {
                    threshold = 2500000,
                    low_fee = 6500,
                    high_fee = 15000
                },
                methods = ["RTO (real-time)", "SKN", "RTGS", "BI FAST"],
                confirmation = new Config.Confirmation
                {
                    en = "yes",
                    id = "ya"
                }
            };
        }

        public void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
