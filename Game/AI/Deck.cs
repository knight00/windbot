using System;
using System.Collections.Generic;
using System.IO;
using YGOSharp.OCGWrapper;
using System.Text;

namespace WindBot.Game
{
    public class Deck
    {
        public IList<int> Cards { get; private set; }
        public IList<int> ExtraCards { get; private set; }
        public IList<int> SideCards { get; private set; }

        public Deck()
        {
            Cards = new List<int>();
            ExtraCards = new List<int>();
            SideCards = new List<int>();
        }

        private void AddNewCard(int cardId, bool mainDeck, bool sideDeck)
        {
            if (sideDeck)
                SideCards.Add(cardId);
            else if(mainDeck)
                Cards.Add(cardId);
            else
                ExtraCards.Add(cardId);  
        }

        private static uint[] ParseBase64DeckArray(string str)
        {
            byte[] arr = Convert.FromBase64String(str);
            uint[] decoded = new uint[arr.Length / 4];
            Buffer.BlockCopy(arr, 0, decoded, 0, arr.Length);
            return decoded;
        }

        ////kdiy/////////
        public static Deck Load(string name, int seed)
        ////kdiy/////////
        {
            StreamReader reader = null;
            Deck deck = new Deck();
            try
            {
                if (name.StartsWith("ydke://"))
                {
                    name = name.Substring("ydke://".Length);
                    string[] tokens = name.Split(new char[1] { '!' });

                    if (tokens.Length != 4)
                        throw new Exception("no");

                    foreach(int code in ParseBase64DeckArray(tokens[0]))
                    {
                        deck.AddNewCard(code, true, false);
                    }

                    foreach (int code in ParseBase64DeckArray(tokens[1]))
                    {
                        deck.AddNewCard(code, false, false);
                    }

                    foreach (int code in ParseBase64DeckArray(tokens[2]))
                    {
                        deck.AddNewCard(code, false, true);
                    }
                }
                else
                {
                    reader = new StreamReader(new FileStream(Path.IsPathRooted(name) ? name : Path.Combine(Path.Combine(Program.AssetPath, "Decks/"), name + ".ydk"), FileMode.Open, FileAccess.Read));

                    ////kdiy/////////
                    if (name.Contains("AI_Numeron") || name.Contains("AI_Hope")) {
                        deck.Cards.Add(85);
                        deck.Cards.Add(86);
                    }
                    deck.ExtraCards.Add(111);
                    if (seed == 3)
                        deck.ExtraCards.Add(211);
                    else if (seed == 2)
                        deck.ExtraCards.Add(208);
                    else if (seed == 1)
                        deck.ExtraCards.Add(112);
                    ////kdiy/////////
                    
                    bool main = true;
                    bool side = false;

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line == null)
                            continue;

                        line = line.Trim();
                        if (line.Equals("#extra"))
                            main = false;
                        else if (line.StartsWith("#"))
                            continue;
                        if (line.Equals("!side"))
                        {
                            side = true;
                            continue;
                        }

                        int id;
                        if (!int.TryParse(line, out id))
                            continue;

                        deck.AddNewCard(id, main, side);
                    }

                    reader.Close();
                }
            }
            catch (Exception)
            {
                Logger.WriteLine("Failed to load deck: " + name + ".");
                deck = null;
                reader?.Close();
            }
            return deck;
        }
    }
}
