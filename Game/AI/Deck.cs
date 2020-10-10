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
        //public static Deck Load(string name,string deckpath)
        public static Deck Load(string name,string deckpath)
        ////kdiy/////////
        {
            StreamReader reader = null;
            try
            {
#if !LIBWINDBOT
                ////////kdiy///////
                if (name.Contains("AI_perfectdicky")) {
                reader = new StreamReader(new FileStream("../deck/" + deckpath + ".ydk", FileMode.Open, FileAccess.Read));
                } else
                ////////kdiy///////
                reader = new StreamReader(new FileStream("Decks/" + name + ".ydk", FileMode.Open, FileAccess.Read));
#else
                reader = new StreamReader(new FileStream(Path.Combine(Program.AssetPath, "Decks/", name + ".ydk"), FileMode.Open, FileAccess.Read));
#endif

                Deck deck = new Deck();
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

                return deck;
            }
            catch (Exception)
            {
                reader?.Close();
                return null;
            }
        }
    }
}
