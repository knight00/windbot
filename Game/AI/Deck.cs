using System;
using System.Collections.Generic;
using System.IO;
using YGOSharp.OCGWrapper;

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

        ////kdiy/////////
        //public static Deck Load(string name)
        public static Deck Load(string name, int seed)
        ////kdiy/////////
        {
            StreamReader reader = null;
            Deck deck = new Deck();
            try
            {
                reader = new StreamReader(new FileStream(Path.IsPathRooted(name) ? name : Path.Combine(Program.AssetPath, "Decks/", name + ".ydk"), FileMode.Open, FileAccess.Read));

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
                reader.Close();
            }
            catch (Exception)
            {
                Logger.WriteLine("Failed to load deck: " + name + ".");
                reader?.Close();
            }
            return deck;
        }
    }
}
