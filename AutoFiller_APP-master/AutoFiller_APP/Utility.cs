using AutoFiller_APP.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFiller_APP
{
    class Utility
    {
        public const string SETTINGS_FILENAME = "./webSettings.txt";        
        public const string PRIVATE_KEY = "";
        public static string SERVER_IP = "localhost";
        public static string SERVER_PORT = "57112";

        public class Constants
        {
            public const string NO_ENTRY_SELECTED = "Please select an Entry";
            public const string UNABLE_TO_DELETE = "Unable to Delete the Entry";
            public const string UNABLE_TO_RETRIEVE_DATA = "Unable to Retrieve any Server Data";
        }

        public static void SaveServer(string ip)
        {
            var file = File.CreateText(SETTINGS_FILENAME);
            SERVER_IP = ip;
            file.WriteLine(ip);
            file.Close();
        }

        public static void LoadServer()
        {
            if (!File.Exists(SETTINGS_FILENAME))
            {
                var f = File.CreateText(SETTINGS_FILENAME);
                f.WriteLine("localhost");
                f.Close();
            }
            var line = File.ReadAllLines(SETTINGS_FILENAME)[0];
            SERVER_IP = line;
            Main._instance._serverIP.Text = line;
        }

        public static string GetServerString()
        {
            return "http://" + SERVER_IP + ":" + SERVER_PORT;
        }

        public static Random _random = new Random();

        public static string GenerateSringToken()
        {
            Random rnd = new Random();
            string token = "";
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            for (int i = 0; i < 64; i++)
            {
                token += characters[_random.Next(characters.Length)];
            }
            return token;
        }
    }
}
