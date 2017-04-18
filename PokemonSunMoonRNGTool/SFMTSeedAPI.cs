﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace PokemonSunMoonRNGTool
{
    static public class SFMTSeedAPI
    {

        static public List<Result> request(string needle)
        {
            Root root;
            var url = $"http://49.212.217.137:19937/gen7/sfmt/seed?needle={needle}";

            string jsonStr;
            using (var webClient = new WebClient())
            {
                jsonStr = webClient.DownloadString(url);
            }

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonStr)))
            {
                var serializer = new DataContractJsonSerializer(typeof(Root));
                root = (Root)serializer.ReadObject(ms);

            }
            if (root == null) return null;
            return root.results;
        }

        public class Root
        {
            public List<Result> results { get; set; }
        }
        public class Result
        {
            public string seed { get; set; }
            public string encoded_needle { get; set; }
            public int step { get; set; }
        }
    }
}
