using System;

namespace WindBot
{
    public class WindBotInfo
    {
        public string Name { get; set; }
        public string Deck { get; set; }
        public string Dialog { get; set; }
        /////////kdiy/////
        public string Deckfolder { get; set; }
        public string Deckpath { get; set; }
        /////////kdiy/////       
        public string Host { get; set; }
        public int Port { get; set; }
        public string HostInfo { get; set; }
        public int Version { get; set; }
        public int Hand { get; set; }
        public bool Debug { get; set; }
        public bool Chat { get; set; }
        public WindBotInfo()
        {
            Name = "WindBot";
            Deck = null;
            Dialog = "default";
            /////////kdiy/////
            Deckfolder = "";
            Deckpath = "";
            /////////kdiy/////           
            Host = "127.0.0.1";
            Port = 7911;
            HostInfo = "";
            Version = 38|1<<8|9<<16;
            Hand = 0;
            Debug = false;
            Chat = true;
        }
    }
}
