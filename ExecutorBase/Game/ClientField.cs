using System.Collections.Generic;
using System.Linq;
using WindBot.Game.AI;
using YGOSharp.OCGWrapper.Enums;

namespace WindBot.Game
{
    public class ClientField
    {
        public IList<ClientCard> Hand { get; private set; }
        public ClientCard[] MonsterZone { get; private set; }
        public ClientCard[] SpellZone { get; private set; }
        public IList<ClientCard> Graveyard { get; private set; }
        public IList<ClientCard> Banished { get; private set; }
        public IList<ClientCard> Deck { get; private set; }
        public IList<ClientCard> ExtraDeck { get; private set; }

        public int LifePoints;
        public ClientCard BattlingMonster;
        public bool UnderAttack;

        public ClientField()
        {
        }

        public void Init(int deck, int extra)
        {
            Hand = new List<ClientCard>();
            MonsterZone = new ClientCard[7];
            SpellZone = new ClientCard[8];
            Graveyard = new List<ClientCard>();
            Banished = new List<ClientCard>();
            Deck = new List<ClientCard>();
            ExtraDeck = new List<ClientCard>();

            for (int i = 0; i < deck; ++i)
                Deck.Add(new ClientCard(0, CardLocation.Deck, -1, 0));
            for (int i = 0; i < extra; ++i)
                ExtraDeck.Add(new ClientCard(0, CardLocation.Extra, -1, 0));
        }

        public void Clear()
        {
            Deck.Clear();
            ExtraDeck.Clear();
            Hand.Clear();
            Banished.Clear();
            Graveyard.Clear();
            MonsterZone = new ClientCard[7];
            SpellZone = new ClientCard[8];
        }

        public void SwapDeckAndGrave(System.Collections.BitArray extra_buf, int extra_insert_off)
        {
            IList<ClientCard> oldgrave = Graveyard;
            Graveyard = Deck;
            Deck = oldgrave;
            foreach (ClientCard card in Graveyard)
                card.Location = CardLocation.Grave;
            int i = 0;
            foreach (ClientCard card in Deck.ToList())
            {
                if (extra_buf[i])
                {
                    card.Position = (int)CardPosition.FaceDown;
                    card.Location = CardLocation.Extra;
                    Deck.Remove(card);
                    ExtraDeck.Insert(extra_insert_off++, card);
                }
                else
                {
                    card.Location = CardLocation.Deck;
                }
                i++;
            }
        }

        public int GetMonstersExtraZoneCount()
        {
            int count = 0;
            if (MonsterZone[5] != null)
                count++;
            if (MonsterZone[6] != null)
                count++;
            return count;
        }
        public int GetMonsterCount()
        {
            return GetCount(MonsterZone);
        }

        public int GetSpellCount()
        {
            return GetCount(SpellZone);
        }

        public int GetHandCount()
        {
            return GetCount(Hand);
        }

        ////kdiy/////////////////
        public int GetdeckCount()
        {
            return GetCount(Deck);
        }
        ////kdiy/////////////////

        public int GetSpellCountWithoutField()
        {
            int count = 0;
            for (int i = 0; i < 5; ++i)
            {
                if (SpellZone[i] != null)
                    ++count;
            }
            return count;
        }

        /// <summary>
        /// Count Column
        /// </summary>
        /// <param zone>range of zone 0-4</param>
        public int GetColumnCount(int zone, bool IncludeExtraMonsterZone = true)
        {
            int count = 0;
            if (SpellZone[zone] != null)
                count++;
            if (MonsterZone[zone] != null)
                count++;
            if (zone == 1 && IncludeExtraMonsterZone)
            {
                if (MonsterZone[5] != null)
                    count++;
            }
            if (zone == 3 && IncludeExtraMonsterZone)
            {
                if (MonsterZone[6] != null)
                    count++;
            }
            return count;
        }

        public int GetFieldCount()
        {
            return GetSpellCount() + GetMonsterCount();
        }

        public int GetFieldHandCount()
        {
            return GetSpellCount() + GetMonsterCount() + GetHandCount();
        }

        public bool IsFieldEmpty()
        {
            return GetMonsters().Count == 0 && GetSpells().Count == 0;
        }

        public int GetLinkedZones()
        {
            int zones = 0;
            for (int i = 0; i < 7; i++)
            {
                zones |= MonsterZone[i]?.GetLinkedZones() ?? 0;
            }
            return zones;
        }

        public List<ClientCard> GetMonsters()
        {
            return GetCards(MonsterZone);
        }
        ///kdiy///
        public List<ClientCard> GetRealMonsters()
        {
            List<ClientCard> monsters = new List<ClientCard>();
            foreach (ClientCard card in GetMonsters())
            {
                if(card.EquipTarget == null && (!(card.HasType(CardType.Spell | CardType.Trap)) || (card.HasType(CardType.TrapMonster) && card.HasType(CardType.Monster))))
                    monsters.Add(card);
            }
            foreach (ClientCard card in GetSpells())
            {
                if(card.EquipTarget == null && (!(card.HasType(CardType.Spell | CardType.Trap)) || (card.HasType(CardType.TrapMonster) && card.HasType(CardType.Monster))))
                    monsters.Add(card);
            }
            if (monsters.Count() <= 0) monsters = null;
            return monsters;
        }
        ///kdiy///
        public List<ClientCard> GetGraveyardMonsters()
        {
            return GetCards(Graveyard, CardType.Monster);
        }

        public List<ClientCard> GetGraveyardSpells()
        {
            return GetCards(Graveyard, CardType.Spell);
        }

        public List<ClientCard> GetGraveyardTraps()
        {
            return GetCards(Graveyard, CardType.Trap);
        }

        public List<ClientCard> GetSpells()
        {
            return GetCards(SpellZone);
        }
        /////diy/////
        public List<ClientCard> GetGraveyard()
        {
            return GetCards(Graveyard);
        }
        /////diy/////

        /////diy/////
        public List<ClientCard> GetDeck()
        {
            return GetCards(Deck);
        }
        /////diy/////

        /////diy /////
        public List<ClientCard> GetHands()
        {
            return GetCards(Hand);
        }
        /////diy /////

        /////diy /////
        public List<ClientCard> GetExtra()
        {
            return GetCards(ExtraDeck);
        }
        /////diy /////

        /////diy /////
        public int GetMonstersMainZoneCount()
        {
            int count = 0;
            if (MonsterZone[0] != null)
                count++;
            if (MonsterZone[1] != null)
                count++;
            if (MonsterZone[2] != null)
                count++;
            if (MonsterZone[3] != null)
                count++;
            if (MonsterZone[4] != null)
                count++;
            return count;
        }
        /////diy /////

        /////diy /////
        public int GetGraveyardCount()
        {
            return GetCount(Graveyard);
        }

        public List<ClientCard> GetFields()
        {
            List<ClientCard> cards = new List<ClientCard>();
            cards.AddRange(GetCards(MonsterZone));
            cards.AddRange(GetCards(SpellZone));
            if (cards.Count() <= 0) cards = null;
            return cards;
        }

        /////diy /////

        public List<ClientCard> GetMonstersInExtraZone()
        {
            return GetMonsters().Where(card => card.Sequence >= 5).ToList();
        }

        public List<ClientCard> GetMonstersInMainZone()
        {
            return GetMonsters().Where(card => card.Sequence < 5).ToList();
        }

        public ClientCard GetFieldSpellCard()
        {
            return SpellZone[5];
        }

        public bool HasInHand(int cardId)
        {
            return HasInCards(Hand, cardId);
        }

        public bool HasInHand(IList<int> cardId)
        {
            return HasInCards(Hand, cardId);
        }

        public bool HasInGraveyard(int cardId)
        {
            return HasInCards(Graveyard, cardId);
        }

        public bool HasInGraveyard(IList<int> cardId)
        {
            return HasInCards(Graveyard, cardId);
        }

        public bool HasInBanished(int cardId)
        {
            return HasInCards(Banished, cardId);
        }

        public bool HasInBanished(IList<int> cardId)
        {
            return HasInCards(Banished, cardId);
        }

        public bool HasInExtra(int cardId)
        {
            return HasInCards(ExtraDeck, cardId);
        }

        public bool HasInExtra(IList<int> cardId)
        {
            return HasInCards(ExtraDeck, cardId);
        }

        public bool HasAttackingMonster()
        {
            return GetMonsters().Any(card => card.IsAttack());
        }

        public bool HasDefendingMonster()
        {
            return GetMonsters().Any(card => card.IsDefense());
        }

        public bool HasInMonstersZone(int cardId, bool notDisabled = false, bool hasXyzMaterial = false, bool faceUp = false)
        {
            return HasInCards(MonsterZone, cardId, notDisabled, hasXyzMaterial, faceUp);
        }

        public bool HasInMonstersZone(IList<int> cardId, bool notDisabled = false, bool hasXyzMaterial = false, bool faceUp = false)
        {
            return HasInCards(MonsterZone, cardId, notDisabled, hasXyzMaterial, faceUp);
        }

        public bool HasInSpellZone(int cardId, bool notDisabled = false, bool faceUp = false)
        {
            return HasInCards(SpellZone, cardId, notDisabled, false, faceUp);
        }

        public bool HasInSpellZone(IList<int> cardId, bool notDisabled = false, bool faceUp = false)
        {
            return HasInCards(SpellZone, cardId, notDisabled, false, faceUp);
        }

        public bool HasInHandOrInSpellZone(int cardId)
        {
            return HasInHand(cardId) || HasInSpellZone(cardId);
        }

        public bool HasInHandOrHasInMonstersZone(int cardId)
        {
            return HasInHand(cardId) || HasInMonstersZone(cardId);
        }

        public bool HasInHandOrInGraveyard(int cardId)
        {
            return HasInHand(cardId) || HasInGraveyard(cardId);
        }

        public bool HasInGraveyardOrInBanished(int cardId)
        {
            return HasInBanished(cardId) || HasInGraveyard(cardId);
        }

        public bool HasInMonstersZoneOrInGraveyard(int cardId)
        {
            return HasInMonstersZone(cardId) || HasInGraveyard(cardId);
        }

        public bool HasInSpellZoneOrInGraveyard(int cardId)
        {
            return HasInSpellZone(cardId) || HasInGraveyard(cardId);
        }

        public bool HasInHandOrInMonstersZoneOrInGraveyard(int cardId)
        {
            return HasInHand(cardId) || HasInMonstersZone(cardId) || HasInGraveyard(cardId);
        }

        public bool HasInHandOrInSpellZoneOrInGraveyard(int cardId)
        {
            return HasInHand(cardId) || HasInSpellZone(cardId) || HasInGraveyard(cardId);
        }

        public bool HasInHandOrInSpellZone(IList<int> cardId)
        {
            return HasInHand(cardId) || HasInSpellZone(cardId);
        }

        public bool HasInHandOrHasInMonstersZone(IList<int> cardId)
        {
            return HasInHand(cardId) || HasInMonstersZone(cardId);
        }

        public bool HasInHandOrInGraveyard(IList<int> cardId)
        {
            return HasInHand(cardId) || HasInGraveyard(cardId);
        }

        public bool HasInMonstersZoneOrInGraveyard(IList<int> cardId)
        {
            return HasInMonstersZone(cardId) || HasInGraveyard(cardId);
        }

        public bool HasInSpellZoneOrInGraveyard(IList<int> cardId)
        {
            return HasInSpellZone(cardId) || HasInGraveyard(cardId);
        }

        public bool HasInHandOrInMonstersZoneOrInGraveyard(IList<int> cardId)
        {
            return HasInHand(cardId) || HasInMonstersZone(cardId) || HasInGraveyard(cardId);
        }

        public bool HasInHandOrInSpellZoneOrInGraveyard(IList<int> cardId)
        {
            return HasInHand(cardId) || HasInSpellZone(cardId) || HasInGraveyard(cardId);
        }

        public int GetRemainingCount(int cardId, int initialCount)
        {
            int remaining = initialCount;
            remaining = remaining - Hand.Count(card => card != null && card.IsOriginalCode(cardId));
            remaining = remaining - SpellZone.Count(card => card != null && card.IsOriginalCode(cardId));
            remaining = remaining - MonsterZone.Count(card => card != null && card.IsOriginalCode(cardId));
            remaining = remaining - Graveyard.Count(card => card != null && card.IsOriginalCode(cardId));
            remaining = remaining - Banished.Count(card => card != null && card.IsOriginalCode(cardId));
            return (remaining < 0) ? 0 : remaining;
        }

        private static int GetCount(IEnumerable<ClientCard> cards)
        {
            return cards.Count(card => card != null);
        }

        public int GetCountCardInZone(IEnumerable<ClientCard> cards, int cardId)
        {
            return cards.Count(card => card != null && card.IsCode(cardId));
        }

        public int GetCountCardInZone(IEnumerable<ClientCard> cards, List<int> cardId)
        {
            return cards.Count(card => card != null && card.IsCode(cardId));
        }
        ///// diy /////
        public int GetCountCardInZone(IEnumerable<ClientCard> cards, CardType type, int setcode)
        {
            return cards.Count(card => card != null && card.HasType(type) && card.HasSetcode(setcode));
        }
        ///// diy /////
        private static List<ClientCard> GetCards(IEnumerable<ClientCard> cards, CardType type)
        {
            return cards.Where(card => card != null && card.HasType(type)).ToList();
        }
        private static List<ClientCard> GetCards(IEnumerable<ClientCard> cards)
        {
            return cards.Where(card => card != null).ToList();
        }

        private static bool HasInCards(IEnumerable<ClientCard> cards, int cardId, bool notDisabled = false, bool hasXyzMaterial = false, bool faceUp = false)
        {
            return cards.Any(card => card != null && card.IsCode(cardId) && !(notDisabled && card.IsDisabled()) && !(hasXyzMaterial && !card.HasXyzMaterial()) && !(faceUp && card.IsFacedown()));
        }

        private static bool HasInCards(IEnumerable<ClientCard> cards, IList<int> cardId, bool notDisabled = false, bool hasXyzMaterial = false, bool faceUp = false)
        {
            return cards.Any(card => card != null && card.IsCode(cardId) && !(notDisabled && card.IsDisabled()) && !(hasXyzMaterial && !card.HasXyzMaterial()) && !(faceUp && card.IsFacedown()));
        }
    }
}
