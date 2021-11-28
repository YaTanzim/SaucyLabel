using System;
using System.IO;
using CoreTweet;
using Newtonsoft.Json;

namespace SaucyLabel
{
    class Program
    {
        public static Config config;
        static void Main(string[] args)
        {
            Console.WriteLine("SaucyLabel 1.0.0");

            if (File.Exists("config.json"))
            {
                config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
            }
            else
            {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(config));
                Console.WriteLine("Config JSON created. Make sure to fill it in with your tokens.");
            }

            Tokens tokens = new Tokens
            {
                ConsumerKey = config.ConsumerKey,
                ConsumerSecret = config.ConsumerKeySecret,
                AccessToken = config.AccessToken,
                AccessTokenSecret = config.AccessTokenSecret
            };

            // Tweet
            Console.WriteLine("Enter tweet here: ");
            tokens.Statuses.Update(Console.ReadLine());

        }

        public class Config
        {
            public string ConsumerKey = "";
            public string ConsumerKeySecret = "";
            public string AccessToken = "";
            public string AccessTokenSecret = "";
        }
    }
}
