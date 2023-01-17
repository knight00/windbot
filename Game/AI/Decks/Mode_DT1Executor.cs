using YGOSharp.OCGWrapper;
using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using System.Linq;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
namespace WindBot.Game.AI.Decks
{
    [Deck("ModeDT1", "AI_ModeDT1")]
    class Mode_DT1Executor : DefaultExecutor
    {
        public class CardId
        {
            public const int Longxia = 97240270;
            public const int DT = 100000143;
            public const int Dawang = 83239739;
            public const int Gui = 80233946;
            public const int Chuan = 51534754;
            public const int Xiyi = 100000157;
            public const int Xueren = 91133740;
            public const int Hu = 22123627;
            public const int Ditu = 33907039;
            public const int Bingjing = 100000158;
            public const int Xianzhi = 3136426;
            public const int Hepingshizhe = 44656491;
            public const int Shuizhang = 49669730;
            public const int Hufu = 61258740;
            public const int Quanliyiji = 511000197;
            public const int Huosiren = 97077563;

            public const int Bingjie = 100000155;
        }
        bool MODE_RULE_5DS_DARK_TUNER = true;
        bool summon = false;
            public Mode_DT1Executor(GameAI ai, Duel duel)
       : base(ai, duel)
        {
            AddExecutor(ExecutorType.SpSummon, CardId.Bingjie, BingjieSummon);
            AddExecutor(ExecutorType.Activate, CardId.Ditu,DituEffect);
            AddExecutor(ExecutorType.Activate, CardId.Xianzhi, DengjiEffect);
            AddExecutor(ExecutorType.Activate, CardId.Hu, HuEffect);
            AddExecutor(ExecutorType.Activate, CardId.Bingjing, BingjingEffect);
            AddExecutor(ExecutorType.Activate, CardId.Hepingshizhe, HepingEffect);
            AddExecutor(ExecutorType.Activate, CardId.Shuizhang, ShuizhangEffect);
            AddExecutor(ExecutorType.Activate, CardId.Huosiren, HuosirenEffect);
            AddExecutor(ExecutorType.Activate, CardId.Hufu, () => { return Bot.GetMonsters().Count(card => card != null && card.IsFaceup() && card.HasAttribute(CardAttribute.Water) )>0; });
            AddExecutor(ExecutorType.Activate, CardId.Quanliyiji, QuanliyijiEffect);
            AddExecutor(ExecutorType.Activate, CardId.DT, DTEffect);
            AddExecutor(ExecutorType.Activate, CardId.Dawang);
            //AddExecutor(ExecutorType.Activate, CardId.Xueren, XuerenEffect);
            AddExecutor(ExecutorType.Summon, CardId.DT, DTsummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.Xueren, () => { summon = true;return true; });
            if (!MODE_RULE_5DS_DARK_TUNER)
            {
                AddExecutor(ExecutorType.MonsterSet, CardId.Chuan, DSet);
            }
            AddExecutor(ExecutorType.Summon, CardId.Chuan, Dsummon);
            if (!MODE_RULE_5DS_DARK_TUNER)
            {
                AddExecutor(ExecutorType.MonsterSet, CardId.Longxia, DSet);
            }
            AddExecutor(ExecutorType.Summon, CardId.Longxia, Dsummon);
            if (!MODE_RULE_5DS_DARK_TUNER)
            {
                AddExecutor(ExecutorType.MonsterSet, CardId.Dawang, DSet);
            }
            AddExecutor(ExecutorType.Summon, CardId.Dawang, Dsummon);
            if (!MODE_RULE_5DS_DARK_TUNER)
            {
                AddExecutor(ExecutorType.MonsterSet, CardId.Xiyi, DSet);
            }
            AddExecutor(ExecutorType.Summon, CardId.Xiyi, Dsummon);
            AddExecutor(ExecutorType.Summon, CardId.Gui, Guisummon);
            if (!MODE_RULE_5DS_DARK_TUNER)
            {
                AddExecutor(ExecutorType.MonsterSet, CardId.Gui, DSet);
            }
            AddExecutor(ExecutorType.Repos, _Repos);
            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);
        }
        public override CardPosition OnSelectPosition(int cardId, IList<CardPosition> positions)
        {
            NamedCard Data = NamedCard.Get(cardId);
            if(Data == null) return base.OnSelectPosition(cardId, positions);
            if (Enemy.GetMonsterCount() <= 0)
            {
                if(Data.Attack < 1500) return CardPosition.FaceUpDefence;
            }
            if (Data.Attack == 0) return CardPosition.FaceUpDefence;
            int b = Util.GetBestAttack(Bot);
            int e = Util.GetBestAttack(Enemy);
            if (e >= b)
            {
                if (Data.Attack >= e) return CardPosition.FaceUpAttack;
                if(Bot.HasInSpellZone(CardId.Hepingshizhe,true,true) && e >= 1900) return CardPosition.FaceUpAttack;
                return CardPosition.FaceUpDefence;
            }
            return base.OnSelectPosition(cardId, positions);
        }
        public override bool OnSelectYesNo(long desc)
        {
            if (desc == Util.GetStringId(CardId.Hepingshizhe, 0))
            {
                if (Bot.LifePoints <= 100) return false;
                int b = Util.GetBestAttack(Bot);
                int e = Util.GetBestAttack(Enemy);
                return b >= e ? false : true;
            }
            return base.OnSelectYesNo(desc);
        }
        private int CheckRemainInDeck(int id)
        {
            switch (id)
            {
                case CardId.DT:
                    return Bot.GetRemainingCount(CardId.DT, 3);
                case CardId.Xueren:
                    return Bot.GetRemainingCount(CardId.Xueren, 3);
                default:
                    return 0;
            }
        }
        private bool SpellActivate(int cardsid)
        {
            if (Card.Location == CardLocation.Hand
                || (Card.Location == CardLocation.SpellZone && Card.IsFacedown()))
            {
                int count = Bot.GetSpells().Count(card => card != null
                && !card.IsDisabled() && card.IsFaceup() && card.Id == cardsid);
                if (count > 0) return false;
            }
            return true;
        }
        private bool HuosirenEffect()
        {
            ClientCard chain = Util.GetLastChainCard();
            if (chain != null && chain.Id == CardId.Huosiren) return false;
            if (Bot.HasInMonstersZone(CardId.Bingjie, false, false,true)) return false;
            if (Bot.HasInExtra(CardId.Bingjie) && Bot.GetMonsters().Count(card => card != null
             && card.Level == 3) > 0 && Bot.HasInGraveyard(CardId.DT))
            {
                select = true;
                AI.SelectCard(CardId.DT);
                return true;
            }
            else if (Bot.HasInExtra(CardId.Bingjie) && Bot.HasInMonstersZone(CardId.DT)
                && Bot.GetMonsters().Count(card => card != null
             && card.IsFaceup() && card.Level == 3) <= 0)
            {
                List<ClientCard> cards = Bot.GetGraveyard().Where(_card => _card != null
                 && _card.Level == 3).ToList();
                if (cards.Count > 0)
                {
                    select = true;
                    AI.SelectCard(cards);
                    return true;
                }
            }
            else if (Bot.HasInGraveyard(CardId.Gui))
            {
                int b = Util.GetBestAttack(Bot);
                int e = Util.GetBestAttack(Enemy);
                bool res = false;
                if (b > e && b > 1900) res = false;
                if (b <= e && e > 1900) res = true;
                if (res)
                {
                    select = true;
                    AI.SelectCard(CardId.Gui);
                    return true;
                }
            }
            List<int> cardsId = new List<int>()
            { CardId.Bingjie,CardId.Chuan,CardId.Dawang,CardId.Longxia};
            int count = Bot.GetGraveyard().Count(card => card != null && cardsId.Contains(card.Id));
            if (count <= 0) return false;
            AI.SelectCard(cardsId);
            select = true;
            return true;
        }
        private bool BingjieSummon()
        {
            AI.SelectCard(CardId.DT, CardId.Gui,CardId.Xueren,CardId.Dawang, CardId.Xiyi);
            return true;
        }
        private bool DTEffect()
        {
            ClientCard card = Util.GetBestEnemyCard();
            if (card != null) AI.SelectCard(card);
            select = true;
            return true;
        }
        bool select = false;
        public override IList<ClientCard> OnSelectCard(IList<ClientCard> cards, int min, int max, long hint, bool cancelable)
        {
            if (select) { select = false; return null; }
            if (cards.Any(card=>card != null && card.Location==CardLocation.MonsterZone))
            {
                XueRen = false;
                List<ClientCard> mcards = cards.Where(card => card != null && card.Controller == 0).ToList();
                List<ClientCard> ecards = cards.Where(card => card != null && card.Controller != 0).ToList();
                ecards.Sort(CardContainer.CompareCardAttack);
                ecards.Reverse();
                mcards.Sort(CardContainer.CompareCardAttack);
                ecards.AddRange(mcards);
                return Util.CheckSelectCount(ecards, cards, min, max);
            }
            return base.OnSelectCard(cards, min, max, hint, cancelable);
        }
        bool XueRen = false;
        private bool XuerenEffect()
        {
            XueRen = true;
            return true;
        }
        private bool _Repos()
        {
            if (Card.Id == CardId.Xueren)
            {
                List<ClientCard> cards = Enemy.GetMonsters().Where(card => card != null && card.IsFaceup() && !card.IsShouldNotBeTarget()).ToList();
                if (cards?.Count <= 0) return false;
                return true;
            }
            return DefaultMonsterRepos();
        }
        private bool BingjingEffect()
        {
            AI.SelectCard(CardId.Chuan, CardId.Longxia);
            select = true;
            return true;
        }
        private IList<ClientCard> CardsIdToClientCards(IList<int> cardsId, IList<ClientCard> cardsList, bool uniqueId = true, bool alias = true)
        {
            if (cardsList?.Count() <= 0 || cardsId?.Count() <= 0) return new List<ClientCard>();
            List<ClientCard> res = new List<ClientCard>();
            foreach (var cardid in cardsId)
            {
                List<ClientCard> cards = cardsList.Where(card => card != null && (card.Id == cardid || ((card.Alias != 0 && cardid == card.Alias) & alias))).ToList();
                if (cards?.Count <= 0) continue;
                cards.Sort(CardContainer.CompareCardAttack);
                if (uniqueId) res.Add(cards.First());
                else res.AddRange(cards);
            }
            return res;
        }
        private bool DTsummon()
        {
            if (Bot.HasInMonstersZone(CardId.Bingjie, false, false, true)) return false;
            if (!Bot.HasInExtra(CardId.Bingjie)) return false;
            if (Bot.GetMonsterCount() < 3) return false;
            List<ClientCard> cards = Bot.GetMonsters();
            List<ClientCard> m1 = cards.Where(card => card != null && card.IsFaceup() && card.Level == 3).ToList();
            if (m1.Count() <= 0) return false;
            List<ClientCard> m2 = cards.Where(card => card != null && ((card.Level != 3 && card.Id!=CardId.Bingjie) || card.IsFacedown())).ToList();
            List<int> cardsId = new List<int>() {CardId.Gui,CardId.Dawang
            ,CardId.Longxia,CardId.Xiyi};
            IList<ClientCard> m3 = CardsIdToClientCards(cardsId, cards,false);
            m2.AddRange(m3);
            AI.SelectCard(m2);
            return true;
        }
        private bool Dsummon()
        {
            if (Bot.HasInMonstersZone(CardId.Bingjie, false, false, true)) return false;
            summon = true;
            return true;
        }
        private bool Guisummon()
        {
            if (Bot.HasInMonstersZone(CardId.Bingjie, false, false, true)) return false;
            int b = Util.GetBestAttack(Bot);
            int e = Util.GetBestAttack(Enemy);
            if (b > e && b > 1900) return false;
            if (b <= e && e < 1900) return false;
            summon = true;
            return true;
        }
        private bool DSet()
        {
            if (Bot.HasInMonstersZone(CardId.Bingjie, false, false, true)) return false;
            List<ClientCard> cards = Enemy.GetMonsters().Where(card => card != null && card.IsAttack()).ToList();
            if (cards.Count <= 0) return false;
            if (Bot.HasInSpellZone(CardId.Xianzhi,true,true))
            {
                cards = cards.Where(card => card != null && card.IsAttack() && card.Level < 4).ToList();
            }
            if (Bot.HasInSpellZone(CardId.Hepingshizhe, true, true))
            {
                cards = cards.Where(card => card != null && card.IsAttack() && card.Attack < 1500).ToList();
            }
            if (cards.Count <= 0) return false;
            cards.Sort(CardContainer.CompareCardAttack);
            cards.Reverse();
            if (cards[cards.Count - 1].Attack > Card.Attack)
            {
                summon = true;
                return true;
            }
            return false; 
        }
        private bool HuEffect()
        {
            AI.SelectCard(CardId.Xiyi,CardId.Dawang,CardId.Gui,CardId.Longxia,CardId.Chuan,
                CardId.Xueren);
            return true;
        }
        private bool ShuizhangEffect()
        {
            if (!SpellActivate(Card.Id)) return false;
            List<int> cardsId = new List<int>() {
            CardId.Gui,CardId.Longxia,CardId.Chuan,CardId.Dawang,CardId.Xiyi};
            int count = Bot.GetHands().Count(card => card != null
            && cardsId.Contains(card.Id));
            if (count <= 0) return false;
            select = true;
            AI.SelectCard(cardsId);
            return true;
        }
        private bool QuanliyijiEffect()
        {
            if (Bot.HasInMonstersZone(CardId.Bingjie, false, false, true))
            {
                AI.SelectCard(CardId.Bingjie);
                select = true;
                return true;
            }
            int b_attack = Util.GetBestAttack(Bot);
            int e_attack = Util.GetBestAttack(Enemy);
            if (b_attack < e_attack) return false;
            ClientCard m = Util.GetBestBotMonster(true);
            if (m == null || m.Attack < 1500) return false;
            AI.SelectCard(m);
            return true;
        }
        private bool HepingEffect()
        {
            if (!SpellActivate(Card.Id)) return false;
            int b_attack = Util.GetBestAttack(Bot);
            int e_attack = Util.GetBestAttack(Enemy);
            if (b_attack > e_attack) return false;
            return true;
        }
        private bool DengjiEffect()
        {
            if (!SpellActivate(Card.Id)) return false;
            select = true; 
            return true;
        }
        private bool DituEffect()
        {
            if (!Bot.HasInExtra(CardId.Bingjie) && CheckRemainInDeck(CardId.Xueren) <= 0) return false;
            if (Bot.HasInExtra(CardId.Bingjie) && !Bot.HasInHandOrHasInMonstersZone(CardId.DT)
                && CheckRemainInDeck(CardId.DT) > 0)
            {
                select = true;
                AI.SelectCard(CardId.DT);
                return true;
            }
            if (CheckRemainInDeck(CardId.Xueren) > 0)
            {
                select = true;
                AI.SelectCard(CardId.Xueren);
                return true;
            }
            return false;
        }
    }

}
