using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using System.Linq;
using System;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    /*
       卡池:
            94服卡池
        diy by 失智
        script by 神数不神 
        2022-9-14        
    */
    [Deck("94-DragonDisaster", "AI_94-DragonDisaster")]
    public class DragonDisasterExecutor : DefaultExecutor
    {
        public class MonsterId
        {
            //WindBot Deck=94-DragonDisaster
            //main
            public const int Z_tuoer = 10105582;
            public const int Z_badeer = 10105580;
            public const int Z_aoding = 10105584;
            public const int Z_haimudaer = 10105583;
            public const int Z_xigefuli = 10105589;
            public const int Z_luoji = 10105581;
            public const int Nibilu = 27204311;
            public const int Luxien = 79029169;
            public const int Dasuo = 79029170;
            public const int BeastNero = 9941025;
            public const int Jutuanhoushe = 79029171;
            public const int Y_TheFirey = 9941041;
            public const int Y_TheWatery = 9941043;
            public const int Y_TheMirror = 9941050;
            public const int Y_TheLight = 9941045;
            public const int Z_zhaolai = 10105585;
            public const int Tuxi = 9941177;
            public const int Huiliuli = 14558127;
            public const int G = 23434538;
            //extra
            public const int Xueli = 79029566;
            public const int X_meng = 9941058;
            public const int X_shengyou = 9941056;
            public const int X_heian = 9941059;
            public const int Z_tiyamate = 10105586;
            public const int No77 = 62541668;
            public const int Zengli = 60002059;
            public const int Shengri = 60002060;
            public const int J_fuleiya = 482038;
            public const int Azhousi = 90448279;
            public const int Z_chushi = 10105590;

        }
        public class SpellId
        {
            public const int Moli = 9941051;
            public const int Y_TheFloat = 9941052;
            public const int Huangjingui = 75500286;
            public const int Y_TheFly = 9941053;
            public const int Z_taidong = 10105587;
        }
        int BN_attack = 0;
        bool Z_chushi_1_Activated = false;
        bool Z_iigefuli_1_Summon = false;
        bool Z_taidong_1_Activated = false;
        bool Z_tiyamate_1_Summon = false;
        bool Z_azhousi_1_Summon = false;
        bool Jutuanhoushe_1_Activated = false;
        bool Dasuo_2_Activated = false;

        bool Moli_Select_1 = false;
        bool Moli_Select_2 = false;
        bool Moli_Select_3 = false;
        bool z_Active = false;
        bool Xyz_Summon = false;

        bool X_Heian_1_Summon = false;
        //bool Luxien_Activated = false;
        /////灾特殊召唤/////
        bool Z_badeer_Summon = false;
        bool Z_luoji_Summon = false;
        bool Z_aoding_Summon = false;
        bool Z_tuoer_Summon = false;
        bool Z_haimudaer_Summon = false;
        /////灾特殊召唤/////
        public DragonDisasterExecutor(GameAI ai, Duel duel)
        : base(ai, duel)
        {
            //小樱
            AddExecutor(ExecutorType.Activate, MonsterId.X_meng);
            //七罪蛛
            AddExecutor(ExecutorType.Activate, MonsterId.No77);
            //赠礼
            AddExecutor(ExecutorType.Activate, MonsterId.Zengli, Y_Effect);
            //生日
            AddExecutor(ExecutorType.Activate, MonsterId.Shengri, Y_Effect);

            //小樱
            AddExecutor(ExecutorType.SpSummon, MonsterId.X_heian, HeianSummon);

            //大锁
            AddExecutor(ExecutorType.Activate, MonsterId.Dasuo, DasuoEffect);
            //G
            AddExecutor(ExecutorType.Activate, MonsterId.G, GEffect);
            //卢西恩
            AddExecutor(ExecutorType.Activate, MonsterId.Luxien, LuxienEffect);
            //吐息
            AddExecutor(ExecutorType.Activate, MonsterId.Tuxi, HuiliuliEffect);
            //灰流丽
            AddExecutor(ExecutorType.Activate, MonsterId.Huiliuli, HuiliuliEffect);
            //尼比鲁
            AddExecutor(ExecutorType.Activate, MonsterId.Nibilu, NibiluEffect);
            //beast
            AddExecutor(ExecutorType.SpSummon, MonsterId.BeastNero, BeastNeroSummon);
            //招来
            AddExecutor(ExecutorType.Summon, MonsterId.Z_zhaolai);
            AddExecutor(ExecutorType.Activate, MonsterId.Z_zhaolai, ZhaolaiEffect);
            //剧团喉舌
            AddExecutor(ExecutorType.Activate, MonsterId.Jutuanhoushe, JutuanhousheEffect);
            //战士-西
            AddExecutor(ExecutorType.SpSummon, MonsterId.Z_xigefuli, XigefuliSummon);

            //初始永劫龙
            AddExecutor(ExecutorType.SpSummon, MonsterId.Z_chushi, ChushiSummon);
            //初始永劫龙
            AddExecutor(ExecutorType.Activate, MonsterId.Z_chushi, ChushiEffect);

            //永劫优先效果
            AddExecutor(ExecutorType.Activate, SpellId.Z_taidong, TaidongEffect_2);

            //TheMirror
            AddExecutor(ExecutorType.Activate, MonsterId.Y_TheMirror, TheMirrorEffect);
            //托尔
            AddExecutor(ExecutorType.Activate, MonsterId.Z_tuoer, ZEffect);
            //巴德尔
            AddExecutor(ExecutorType.Activate, MonsterId.Z_badeer, ZEffect);
            //奥丁
            AddExecutor(ExecutorType.Activate, MonsterId.Z_aoding, ZEffect);
            //海姆
            AddExecutor(ExecutorType.Activate, MonsterId.Z_haimudaer, ZEffect);
            //洛基
            AddExecutor(ExecutorType.Activate, MonsterId.Z_luoji, ZEffect);

            //战士-西 效果 
            AddExecutor(ExecutorType.Activate, MonsterId.Z_xigefuli, XigefuliEffect);

            //Y_TheFire
            AddExecutor(ExecutorType.Activate, MonsterId.Y_TheFirey, TheFireyEffect);
            //Y_TheLight
            AddExecutor(ExecutorType.Activate, MonsterId.Y_TheLight, TheLightEffect);

            //黄金柜
            AddExecutor(ExecutorType.Activate, SpellId.Huangjingui, HuangjinguiEffect);

            //永劫胎动效果
            AddExecutor(ExecutorType.Activate, SpellId.Z_taidong, TaidongEffect);
            //永劫胎动发动
            AddExecutor(ExecutorType.Activate, SpellId.Z_taidong, TaidongActive);

            //Y_TheWatery
            AddExecutor(ExecutorType.Activate, MonsterId.Y_TheWatery, TheWateryEffect);
            //封印之轮
            AddExecutor(ExecutorType.Activate, SpellId.Moli, MoliEffect);
            //声优
            AddExecutor(ExecutorType.Activate, MonsterId.X_shengyou, Y_Effect);

            //芙蕾雅
            AddExecutor(ExecutorType.Activate, MonsterId.J_fuleiya);

            //芙蕾雅
            AddExecutor(ExecutorType.SpSummon, MonsterId.J_fuleiya, FuleiyaSummon);

            //高达
            AddExecutor(ExecutorType.SpSummon, MonsterId.Azhousi, AzhousiSummon);

            //高达 效果
            AddExecutor(ExecutorType.Activate, MonsterId.Azhousi, AzhousiEffect);


            //灾 提亚马特
            AddExecutor(ExecutorType.SpSummon, MonsterId.Z_tiyamate, TiyamateSummon);

            //灾 提亚马特 效果 
            AddExecutor(ExecutorType.Activate, MonsterId.Z_tiyamate, TiyamateEffect);

            //the fly
            AddExecutor(ExecutorType.Activate, SpellId.Y_TheFly, TheFlyEffeect);
            //the float
            AddExecutor(ExecutorType.Activate, SpellId.Y_TheFloat);

            //赠礼
            AddExecutor(ExecutorType.SpSummon, MonsterId.Zengli, XyzSummon);
            //生日
            AddExecutor(ExecutorType.SpSummon, MonsterId.Shengri, XyzSummon);

            //七罪蛛
            AddExecutor(ExecutorType.SpSummon, MonsterId.No77, XyzSummon);

            AddExecutor(ExecutorType.SpellSet, SpellSet);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
        }

        #region 卡组检查
        private int CheckRemainInDeck(int id)
        {
            switch (id)
            {
                case MonsterId.Z_tuoer:
                    return Bot.GetRemainingCount(MonsterId.Z_tuoer, 2);
                case MonsterId.Z_badeer:
                    return Bot.GetRemainingCount(MonsterId.Z_badeer, 3);
                case MonsterId.Z_aoding:
                    return Bot.GetRemainingCount(MonsterId.Z_aoding, 2);
                case MonsterId.Z_haimudaer:
                    return Bot.GetRemainingCount(MonsterId.Z_haimudaer, 3);
                case MonsterId.Z_xigefuli:
                    return Bot.GetRemainingCount(MonsterId.Z_xigefuli, 3);
                case MonsterId.Z_luoji:
                    return Bot.GetRemainingCount(MonsterId.Z_luoji, 3);
                case MonsterId.Nibilu:
                    return Bot.GetRemainingCount(MonsterId.Nibilu, 1);
                case MonsterId.Luxien:
                    return Bot.GetRemainingCount(MonsterId.Luxien, 1);
                case MonsterId.Dasuo:
                    return Bot.GetRemainingCount(MonsterId.Dasuo, 1);
                case MonsterId.BeastNero:
                    return Bot.GetRemainingCount(MonsterId.BeastNero, 1);
                case MonsterId.Jutuanhoushe:
                    return Bot.GetRemainingCount(MonsterId.Jutuanhoushe, 3);
                case MonsterId.Y_TheFirey:
                    return Bot.GetRemainingCount(MonsterId.Y_TheFirey, 1);
                case MonsterId.Y_TheWatery:
                    return Bot.GetRemainingCount(MonsterId.Y_TheWatery, 1);
                case MonsterId.Y_TheMirror:
                    return Bot.GetRemainingCount(MonsterId.Y_TheMirror, 1);
                case MonsterId.Y_TheLight:
                    return Bot.GetRemainingCount(MonsterId.Y_TheLight, 1);
                case MonsterId.Z_zhaolai:
                    return Bot.GetRemainingCount(MonsterId.Z_zhaolai, 1);
                case MonsterId.Tuxi:
                    return Bot.GetRemainingCount(MonsterId.Tuxi, 1);
                case MonsterId.Huiliuli:
                    return Bot.GetRemainingCount(MonsterId.Huiliuli, 2);
                case MonsterId.G:
                    return Bot.GetRemainingCount(MonsterId.G, 3);
                case SpellId.Moli:
                    return Bot.GetRemainingCount(SpellId.Moli, 3);
                case SpellId.Y_TheFloat:
                    return Bot.GetRemainingCount(SpellId.Y_TheFloat, 2);
                case SpellId.Huangjingui:
                    return Bot.GetRemainingCount(SpellId.Huangjingui, 1);
                case SpellId.Y_TheFly:
                    return Bot.GetRemainingCount(SpellId.Y_TheFly, 1);
                case SpellId.Z_taidong:
                    return Bot.GetRemainingCount(SpellId.Z_taidong, 2);
                default:
                    return 0;
            }
        }
        #endregion
        public override void OnNewTurn()
        {
            Z_chushi_1_Activated = false;
            Z_badeer_Summon = false;
            Z_luoji_Summon = false;
            Z_aoding_Summon = false;
            Z_tuoer_Summon = false;
            Z_haimudaer_Summon = false;
            Jutuanhoushe_1_Activated = false;
        }
        private IList<ClientCard> GetXyzMaterial(IList<ClientCard> cards)
        {
            List<ClientCard> copy_cards = new List<ClientCard>(cards);
            List<ClientCard> res_cards = new List<ClientCard>();
            for (int i = 0; i < copy_cards.Count(); ++i)
            {
                if (copy_cards[i].IsCode(MonsterId.Z_luoji))
                {
                    res_cards.Add(copy_cards[i]);
                    copy_cards.Remove(copy_cards[i]);
                    --i;
                }
            }
            if (copy_cards.Count() > 1) copy_cards.Sort(CardContainer.CompareCardAttack);
            res_cards.AddRange(copy_cards);
            res_cards.Reverse();
            foreach (var item in res_cards)
            {
                Logger.DebugWriteLine("排序后的攻击力" + item.Attack);
            }
            return res_cards;
        }
        public override CardPosition OnSelectPosition(int cardId, IList<CardPosition> positions)
        {
            if (cardId == MonsterId.BeastNero && BN_attack > 1000)
            {
                return CardPosition.FaceUpAttack;
            }
            return base.OnSelectPosition(cardId, positions);
        }

        public override IList<ClientCard> OnSelectXyzMaterial(IList<ClientCard> cards, int min, int max)
        {
            if (Z_tiyamate_1_Summon)
            {
                Z_tiyamate_1_Summon = false;
                Logger.DebugWriteLine("进入了提亚马特的超量素材选择");
                IList<ClientCard> res_cards = GetXyzMaterial(cards);
                return Util.CheckSelectCount(res_cards, cards, min, max);
            }
            if (Z_azhousi_1_Summon)
            {
                Z_azhousi_1_Summon = false;
                Logger.DebugWriteLine("进入了高达的超量素材选择");
                IList<ClientCard> res_cards = GetXyzMaterial(cards);
                return Util.CheckSelectCount(res_cards, cards, min, max);

            }
            if (Xyz_Summon)
            {
                Xyz_Summon = false;
                IList<ClientCard> res_cards = GetXyzMaterial(cards);
                return Util.CheckSelectCount(res_cards, cards, min, max);
            }
            if (X_Heian_1_Summon)
            {
                X_Heian_1_Summon = false;
                if (!cards.Any(card => card.Controller == 1)) return null;
                List<ClientCard> en_cards = new List<ClientCard>();
                List<ClientCard> bot_cards = new List<ClientCard>();
                foreach (var card in cards)
                {
                    if (card.Controller == 1)
                    {
                        en_cards.Add(card);
                    }
                    else
                    {
                        bot_cards.Add(card);
                    }
                }
                List<ClientCard> res_cards = new List<ClientCard>();
                res_cards.AddRange(en_cards);
                res_cards.AddRange(bot_cards);
                max = en_cards.Count() - 1;
                if (max < min) max = min;
                return Util.CheckSelectCount(res_cards, cards, min, max);
            }
            return base.OnSelectXyzMaterial(cards, min, max);
        }
        public int GetCountCardInZone(IEnumerable<ClientCard> cards, int level, CardRace race, bool isLevelAbove = false, bool isContainRace = false, bool isContianLevel = false)
        {
            return cards.Count(card => card != null && ((isLevelAbove ? card.Level >= level : card.Level <= level) || !isContianLevel) && (card.Race == (ulong)race || !isContainRace));
        }
        public List<ClientCard> GetCardInZone(IEnumerable<ClientCard> cards, CardType type, int setcode, bool onlyFaceUp = false, bool canBeTarget = false)
        {
            return cards.Where(card => card != null && card.HasType(type) && card.HasSetcode(setcode) && !(onlyFaceUp && card.IsFacedown()) && !(canBeTarget && card.IsShouldNotBeTarget())).ToList();
        }
        public List<ClientCard> GetCardInZone(IEnumerable<ClientCard> cards, int setcode, bool onlyFaceUp = false, bool canBeTarget = false)
        {
            return cards.Where(card => card != null && card.HasSetcode(setcode) && !(onlyFaceUp && card.IsFacedown()) && !(canBeTarget && card.IsShouldNotBeTarget())).ToList();
        }
        public override IList<ClientCard> OnSelectCard(IList<ClientCard> cards, int min, int max, long hint, bool cancelable)
        {
            //if (Luxien_Activated) { Luxien_Activated = false; return null; }
            if (z_Active) { z_Active = false; return null; }
            if (Moli_Select_1) { Moli_Select_1 = false; return null; }
            if (Dasuo_2_Activated) { Dasuo_2_Activated = false; return null; }
            if (Z_taidong_1_Activated) { Z_taidong_1_Activated = false; return null; }
            if (cards.Any(card => card.Controller == 1)) return null;
            if (cards.All(card => card.IsCode(SpellId.Z_taidong))) return null;
            if (cards.All(card => card.Location == CardLocation.Overlay)) return null;
            Logger.DebugWriteLine("进入父类筛选");
            if (Moli_Select_2 || Moli_Select_3)
            {
                if (Moli_Select_2) Moli_Select_2 = false;
                if (Moli_Select_2) Moli_Select_3 = false;
                List<ClientCard> res_cards = new List<ClientCard>();
                IList<ClientCard> deck_cards = cards.Where(card => card.Location == CardLocation.Deck).ToList();
                if (deck_cards.Count <= 0) deck_cards = new List<ClientCard>(cards);
                for (int i = 0; i < deck_cards.Count(); ++i)
                {
                    if ((Bot.Hand.Count > 0 && deck_cards[i].Id == MonsterId.Y_TheWatery)
                          || deck_cards[i].Id == MonsterId.Y_TheMirror || (GetCountCardInZone(Bot.Banished, 7, 0, true, false) > 0
                          && deck_cards[i].Id == MonsterId.Y_TheLight))
                    {
                        res_cards.Add(deck_cards[i]);
                        deck_cards.Remove(deck_cards[i]);
                        --i;
                    }
                }
                res_cards.AddRange(deck_cards);
                return Util.CheckSelectCount(res_cards, cards, min, max);
            }
            if (cards.Any(card => card.Location == CardLocation.Deck) && Z_iigefuli_1_Summon)
            {
                Z_iigefuli_1_Summon = false;
                Logger.DebugWriteLine("西进入了特殊的特殊召唤");
                List<ClientCard> handCards = Bot.GetHands();
                IList<int> backCardsCodes = new List<int>();
                foreach (var card in handCards)
                {
                    if (card.HasSetcode(0x7cca))
                    {
                        backCardsCodes.Add(card.Id);
                        Logger.DebugWriteLine("有重复的" + card.Id);
                    }
                }
                if (backCardsCodes?.Count() > 0)
                {
                    for (int i = 0; i < cards.Count(); ++i)
                    {
                        int code = cards[i].Id;
                        if (backCardsCodes.Contains(code))
                        {
                            Logger.DebugWriteLine("筛选了" + cards[i].Id);
                            if (i == (cards.Count() - 1)) break;
                            ClientCard temp = cards[i];
                            cards[i] = cards[cards.Count() - 1];
                            cards[cards.Count() - 1] = temp;
                        }
                    }
                }
                //return new List<ClientCard>(cards);
                return Util.CheckSelectCount(cards, cards, min, max);
            }
            if (hint == HintMsg.Remove && min == 2 && cards.All(card => card.Level >= 10))
            {
                if (!cards.Any(card => card.Location == CardLocation.Grave)) return null;
                IList<ClientCard> handCards = new List<ClientCard>();
                IList<ClientCard> graveCards = new List<ClientCard>();
                List<ClientCard> res = new List<ClientCard>();
                foreach (var card in cards)
                {
                    if (card.Location == CardLocation.Grave)
                    {
                        if (card.IsCode(MonsterId.Z_xigefuli))
                        {
                            graveCards.Insert(0, card);
                        }
                        else
                        {
                            graveCards.Add(card);
                        }
                    }
                    if (card.Location == CardLocation.Hand)
                    {
                        if (card.HasSetcode(0x7cca))
                        {
                            handCards.Insert(0, card);
                        }
                        else if (card.IsCode(MonsterId.BeastNero))
                        {
                            res.Add(card);
                        }
                        else
                        {
                            handCards.Add(card);
                        }
                    }
                }
                res.AddRange(handCards.ToList());
                res.AddRange(graveCards.ToList());
                res.Reverse();
                Logger.DebugWriteLine("1================");
                foreach (var card in graveCards.ToList())
                {
                    Logger.DebugWriteLine((card.Id).ToString());
                }
                Logger.DebugWriteLine("2================");
                foreach (var card in handCards.ToList())
                {
                    Logger.DebugWriteLine((card.Id).ToString());
                }
                Logger.DebugWriteLine("3================");
                foreach (var card in res)
                {
                    Logger.DebugWriteLine((card.Id).ToString());
                }
                return Util.CheckSelectCount(res, cards, min, max);

            }
            return base.OnSelectCard(cards, min, max, hint, cancelable);
        }
        public override bool OnSelectYesNo(long desc)
        {
            if (desc == Util.GetStringId(MonsterId.Y_TheMirror, 1))
            {
                return true;
            }
            return base.OnSelectYesNo(desc);
        }
        private bool SpellSet()
        {
            return Bot.GetSpellCountWithoutField() < 5 && (Card.HasType(CardType.Trap) || Card.HasType(CardType.QuickPlay));
        }
        private bool XyzSummon()
        {
            int e_attack = Util.GetBestPower(Enemy, true);
            int b_attack = Util.GetBestPower(Bot, true);
            if (EnemyHasDangerousMonster() || (b_attack < e_attack))
            {
                Xyz_Summon = true;
                return true;
            }
            return false;
        }
        //芙蕾雅
        private bool FuleiyaSummon()
        {
            int e_attack = Util.GetBestPower(Enemy, true);
            int b_attack = Util.GetBestPower(Bot, true);
            List<ClientCard> cards = (Enemy.GetMonsters()).Where(card => card.IsAttack()).ToList();
            if (Duel.Turn > 1 && Enemy.GetMonsterCount() > 0 && (cards != null || (b_attack < e_attack)))
            {
                Xyz_Summon = true;
                return true;
            }
            return false;
        }
        private bool HeianSummon()
        {
            bool isShouldSummon = false;
            foreach (var card in Enemy.GetMonsters())
            {
                if (card.Attribute == (int)CardAttribute.Dark)
                {
                    isShouldSummon = true;
                }
            }
            if (isShouldSummon)
            {
                X_Heian_1_Summon = true;
                return true;
            }
            return false;
        }
        private bool LuxienEffect()
        {
            IList<ClientCard> cards = Duel.CurrentChain;
            List<ClientCard> targets = new List<ClientCard>();
            foreach (var card in cards)
            {
                if (card.Controller == 1)
                {
                    targets.Add(card);
                }
            }
            if (targets.Count <= 0 || (cards.Count - targets.Count > targets.Count)) return false;
            // Luxien_Activated = true;
            return true;
        }
        private bool HuiliuliEffect()
        {
            return Duel.LastChainPlayer == 1;
        }
        //The Light
        private bool TheLightEffect()
        {
            if (ActivateDescription == Util.GetStringId(MonsterId.Y_TheLight, 0))
            {
                return false;
            }
            else
            {
                AI.SelectCard(MonsterId.BeastNero, MonsterId.Y_TheMirror);
                return true;
            }
            //if (ActivateDescription == Util.GetStringId(MonsterId.Y_TheLight, 1))
            //{
            //    AI.SelectCard(MonsterId.BeastNero);
            //    return true;
            //}
            //if (Card.Location == CardLocation.Removed)
            //{
            //    AI.SelectCard(MonsterId.BeastNero, MonsterId.Y_TheMirror);
            //    return true;
            //}
            //return false;
        }
        private bool DasuoEffect()
        {
            if (Bot.LifePoints > 1000)
            {
                Dasuo_2_Activated = true;
                if (Bot.HasInGraveyardOrInBanished(MonsterId.BeastNero))
                {
                    AI.SelectCard(MonsterId.BeastNero);
                    return true;
                }
                else if (GetCountCardInZone(Bot.Banished, 10, CardRace.Fiend) > 0)
                {
                    AI.SelectCard(CardLocation.Removed);
                    return true;
                }
                else if (!Jutuanhoushe_1_Activated && Bot.HasInGraveyard(MonsterId.Jutuanhoushe))
                {
                    AI.SelectCard(MonsterId.Jutuanhoushe);
                    return true;
                }
                return false;
            }
            return false;
        }
        //尼比鲁
        private bool NibiluEffect()
        {
            return Enemy.GetMonsterCount() > Bot.GetMonsterCount();
        }
        private bool GetBeastAttack()
        {
            int sum_attack = 0;
            foreach (var card in Bot.GetMonsters())
            {
                sum_attack += card.Attack;
            }
            BN_attack = sum_attack;
            return true;
        }
        //Beast Nero
        private bool BeastNeroSummon()
        {
            if (Bot.GetMonsterCount() == 1 && GetCountCardInZone(Bot.GetMonsters(), CardType.Monster, 0x7cca, true, false) < 1) return GetBeastAttack();
            if (Bot.HasInMonstersZone(MonsterId.Z_chushi) && Bot.GetMonsterCount() == 1) return GetBeastAttack();
            if (Duel.Player == 0 && Bot.GetMonsterCount() < 2) return GetBeastAttack();
            if (Duel.Player == 0 && Bot.GetMonsterCount() <= 2 && GetCountCardInZone(Bot.GetMonsters(), CardType.Monster, 0x7cca, true, false) < 2) return GetBeastAttack();
            if (Enemy.GetMonsterCount() > 0 && Bot.GetMonsterCount() > 0)
            {
                int en_attack = Util.GetBestPower(Enemy, true);
                int bot_attack = Util.GetBestPower(Bot, true);
                int sum_attack = 0;
                foreach (var card in Bot.GetMonsters())
                {
                    sum_attack += card.Attack;
                }
                BN_attack = sum_attack;
                return (en_attack > bot_attack) && (sum_attack > en_attack);
            }
            return false;
        }
        //高达 效果
        private bool AzhousiEffect()
        {
            if (ActivateDescription == Util.GetStringId(MonsterId.Azhousi, 1))
            {
                int botAtk = Util.GetBestAttack(Bot);
                int enAtk = Util.GetBestAttack(Enemy);
                if ((Enemy.GetFieldCount() >= Bot.GetFieldCount()) || EnemyHasDangerousMonster() || enAtk > botAtk)
                {
                    return true;
                }
                return false;
            }
            if (ActivateDescription == Util.GetStringId(MonsterId.Azhousi, 2))
            {
                AI.SelectCard(CardLocation.Deck);
                return true;
            }
            return false;
        }
        private bool IsShouldSummonZ_Badeer()
        {
            return CheckRemainInDeck(MonsterId.Z_haimudaer) > 0
                    || CheckRemainInDeck(MonsterId.Z_luoji) > 0 || CheckRemainInDeck(MonsterId.Z_tuoer) > 0
                    || CheckRemainInDeck(MonsterId.Z_aoding) > 0;
        }
        //G
        private bool GEffect()
        {
            return Duel.Player == 1;
        }
        //提亚马特
        private bool TiyamateSummon()
        {
            List<ClientCard> cards = Bot.GetMonsters().Where(card => card != null && card.Level == 12).ToList();
            if (Enemy.LifePoints <= 1500) return true;
            int en_Atk = Util.GetBestPower(Enemy, false);
            int my_Atk = Util.GetBestPower(Bot, false);
            if (en_Atk > my_Atk && en_Atk <= 5000) { Z_tiyamate_1_Summon = true; return true; }
            if (cards.Count() >= 4 && Enemy.GetMonsterCount() > 0) { Z_tiyamate_1_Summon = true; return true; }
            if (cards.Count() >= 4 && Duel.Phase == DuelPhase.Main2) { Z_tiyamate_1_Summon = true; return true; }
            return false;
        }
        private bool TiyamateEffect()
        {

            if (ActivateDescription == Util.GetStringId(MonsterId.Z_tiyamate, 0))
            {
                return Bot.BattlingMonster.Attack <= Enemy.BattlingMonster.GetDefensePower();
            }
            else if (ActivateDescription == Util.GetStringId(MonsterId.Z_tiyamate, 1))
            {
                return true;
            }
            else
            {
                return Duel.LastChainPlayer == 1;
            }
        }
        private bool TheFireyEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                return true;
            }
            if (Card.Location == CardLocation.MonsterZone)
            {

                AI.SelectCard(MonsterId.Y_TheMirror, MonsterId.Y_TheWatery,
                              MonsterId.Y_TheLight, MonsterId.Z_xigefuli);
                return true;
            }
            if (Card.Location == CardLocation.Removed)
            {
                return true;
            }
            return false;
        }
        private bool EnemyHasDangerousMonster()
        {
            bool isDgs = false;
            foreach (var card in Enemy.GetMonsters())
            {
                if (card.IsMonsterDangerous()) isDgs = true;
                break;
            }
            return isDgs;
        }
        private bool AzhousiSummon()
        {
            if (Enemy.GetMonsterCount() > Bot.GetMonsterCount()
                || EnemyHasDangerousMonster() || Duel.Turn == 1 || Duel.Phase == DuelPhase.Main2) { Z_azhousi_1_Summon = true; return true; }
            return false;
        }
        private bool ChushiSummon()
        {
            if (!Z_chushi_1_Activated && CheckRemainInDeck(SpellId.Z_taidong) > 0)
            {
                Logger.DebugWriteLine("卡组中胎动的数量为" + CheckRemainInDeck(SpellId.Z_taidong));
                IList<ClientCard> _cards = new List<ClientCard>();
                foreach (var card in Bot.GetMonsters())
                {
                    if (card.Level == 12)
                    {
                        _cards.Add(card);
                    }
                }
                List<ClientCard> cards = _cards.ToList();
                cards.Sort(CardContainer.CompareCardAttack);
                cards.Reverse();
                AI.SelectMaterials(cards);
                return true;
            }
            return false;
        }
        //初始
        private bool ChushiEffect()
        {
            Z_chushi_1_Activated = true;
            return true;
        }
        //通用特殊召唤
        private bool ZEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.GetMonstersInMainZone().Count() > 4) return false;
                switch (Card.Id)
                {
                    case MonsterId.Z_badeer:
                        Z_badeer_Summon = true;
                        break;
                    case MonsterId.Z_luoji:
                        Z_luoji_Summon = true;
                        break;
                    case MonsterId.Z_aoding:
                        Z_aoding_Summon = true;
                        break;
                    case MonsterId.Z_tuoer:
                        Z_tuoer_Summon = true;
                        break;
                    case MonsterId.Z_haimudaer:
                        Z_haimudaer_Summon = true;
                        break;
                }
                AI.SelectCard(MonsterId.Z_xigefuli);
                return true;

            }
            else
            {
                z_Active = true;
                switch (Card.Id)
                {
                    case MonsterId.Z_badeer:
                        return true;
                    case MonsterId.Z_luoji:
                        ClientCard card = Util.GetLastChainCard();
                        if (card != null && card.HasType(CardType.Monster) && card.Controller == 1 && !card.IsShouldNotBeMonsterTarget() && card.Location == CardLocation.MonsterZone)
                        {
                            List<ClientCard> enCards = Enemy.GetMonsters();
                            enCards.Insert(0, card);
                            List<ClientCard> cards = new List<ClientCard>();
                            List<ClientCard> handCards = GetCardInZone(Bot.Hand, CardType.Monster, 0x7cca);
                            List<ClientCard> monsterCards = GetCardInZone(Bot.MonsterZone, CardType.Monster, 0x7cca);
                            monsterCards.Sort(CardContainer.CompareCardAttack);
                            cards.AddRange(handCards);
                            cards.AddRange(monsterCards);
                            foreach (var item in enCards)
                            {
                                Logger.DebugWriteLine("洛基的选择对象有" + item);
                            }
                            AI.SelectCard(cards);
                            AI.SelectNextCard(enCards);
                            return true;
                        }
                        return false;
                    case MonsterId.Z_haimudaer:
                        ClientCard bestCard = Util.GetBestEnemyCard(false, true);
                        if (bestCard == null) return false;
                        AI.SelectCard(bestCard);
                        AI.SelectNextCard(CardLocation.Grave);
                        return true;
                    case MonsterId.Z_aoding:
                        if (Duel.LastSummonedCards != null && Duel.LastSummonedCards.Contains(Card))
                        {
                            //可能会BUG的地方
                            while (Duel.LastSummonedCards.Contains(Card))
                            {
                                Duel.LastSummonedCards.Remove(Card);
                            }
                            Logger.DebugWriteLine("进入了奥丁的特殊召唤发动的效果");
                            ClientCard bestEnCard = Util.GetBestEnemyCard(false, true);
                            if (bestEnCard != null)
                            {
                                AI.SelectCard(bestEnCard);
                                return true;
                            }
                            return false;
                        }
                        if (Duel.Phase == DuelPhase.Main1 || Duel.Phase == DuelPhase.Main2)
                        {
                            Logger.DebugWriteLine("进入了奥丁的启动效果");
                            ClientCard bestEnCard = Util.GetBestEnemyCard(false, true);
                            if (bestEnCard == null) return false;
                            List<ClientCard> cards = new List<ClientCard>();
                            cards.AddRange(Bot.GetHands());
                            cards.AddRange(Bot.GetFields());
                            List<ClientCard> pre_costCards = GetCardInZone(cards, 0x7cca, true, false);
                            foreach (var card_22 in pre_costCards)
                            {
                                Logger.DebugWriteLine("奥丁可以筛选的卡有" + card_22.Id);
                            }
                            if (pre_costCards.Count() <= 0 || (pre_costCards.Count() == 1 && Bot.GetMonsterCount() <= Enemy.GetMonsterCount())) return false;
                            List<ClientCard> res_costCards = new List<ClientCard>();
                            foreach (var _card in pre_costCards)
                            {
                                if (_card.Location != CardLocation.Hand && _card.IsCode(SpellId.Z_taidong))
                                {
                                    res_costCards.Add(_card);
                                }
                            }
                            pre_costCards.Sort(CardContainer.CompareCardAttack);
                            res_costCards.AddRange(pre_costCards);
                            foreach (var card_2 in res_costCards)
                            {
                                Logger.DebugWriteLine("奥丁筛选的卡中有" + card_2.Id);
                            }

                            Logger.DebugWriteLine("奥丁筛选的对象是" + bestEnCard.Id);
                            AI.SelectCard(res_costCards);
                            AI.SelectNextCard(bestEnCard);
                            return true;
                        }
                        return false;
                    default:
                        return true;
                }
            }
        }
        //灾龙 召来
        private bool ZhaolaiEffect()
        {

            if (Card.Location != CardLocation.Grave)
            {
                ClientCard card = Util.GetBestEnemyCard();
                if (card != null && CheckRemainInDeck(MonsterId.Z_aoding) > 0)
                {
                    AI.SelectCard(MonsterId.Z_aoding);
                }
                else if (card != null && Enemy.Graveyard.Count() > 2 && CheckRemainInDeck(MonsterId.Z_haimudaer) > 0)
                {
                    AI.SelectCard(MonsterId.Z_haimudaer);
                }
                else if (Duel.Phase == DuelPhase.Battle && CheckRemainInDeck(MonsterId.Z_tuoer) > 0)
                {
                    AI.SelectCard(MonsterId.Z_tuoer);
                }
                else if (IsShouldSummonZ_Badeer() && CheckRemainInDeck(MonsterId.Z_badeer) > 0)
                {
                    AI.SelectCard(MonsterId.Z_badeer);
                }
                return true;
            }
            else
            {
                AI.SelectCard(CardLocation.Hand);
                if (Bot.HasInBanished(MonsterId.Z_badeer) && !Z_badeer_Summon)
                {
                    AI.SelectNextCard(MonsterId.Z_badeer);
                }
                else if (Bot.HasInBanished(MonsterId.Z_luoji) && !Z_luoji_Summon)
                {
                    AI.SelectNextCard(MonsterId.Z_luoji);
                }
                else if (Bot.HasInBanished(MonsterId.Z_tuoer) && !Z_tuoer_Summon)
                {
                    AI.SelectNextCard(MonsterId.Z_tuoer);
                }
                else if (Bot.HasInBanished(MonsterId.Z_haimudaer) && !Z_haimudaer_Summon)
                {
                    AI.SelectNextCard(MonsterId.Z_haimudaer);
                }
                else if (Bot.HasInBanished(MonsterId.Z_aoding) && !Z_aoding_Summon)
                {
                    AI.SelectNextCard(MonsterId.Z_aoding);
                }
                return true;
            }
        }
        public int GetCountCardInZone(IEnumerable<ClientCard> cards, CardType type, int setcode, bool onlyFaceUp = false, bool canBeTarget = false)
        {
            return cards.Count(card => card != null && card.HasType(type) && card.HasSetcode(setcode) && !(onlyFaceUp && card.IsFacedown()) && !(canBeTarget && card.IsShouldNotBeTarget()));
        }
        private bool TaidongActive()
        {
            return ((Card.Location == CardLocation.Hand || (Card.Location == CardLocation.Onfield
                   && Card.IsFacedown())) && Bot.GetMonstersInMainZone().Count() < 5
                   && (GetCountCardInZone(Bot.GetHands(), CardType.Monster, 0x7cca, true, false) > 0 || GetCountCardInZone(Bot.Banished, CardType.Monster, 0x7cca, true, false) > 0));
        }
        private bool TaidongEffect_2()
        {
            if (Bot.GetMonsterCount() >= 4) return TaidongEffect();
            return false;
        }
        private bool TaidongEffect()
        {
            if (Card.IsFaceup() && Card.Location != CardLocation.Hand)
            {
                Z_taidong_1_Activated = true;
                if (Bot.HasInHand(MonsterId.Z_haimudaer) || Bot.HasInBanished(MonsterId.Z_haimudaer))
                {
                    if (Enemy.Graveyard.Count >= 2)
                    {
                        List<ClientCard> cards = Enemy.GetFields();
                        if (cards != null)
                        {
                            for (int i = 0; i < cards.Count(); ++i)
                            {
                                if (cards[i].IsShouldNotBeTarget())
                                {
                                    cards.Remove(cards[i]);
                                    --i;
                                }

                            }
                            if (cards.Count() > 0)
                            {
                                AI.SelectCard(MonsterId.Z_haimudaer);
                                return true;
                            }
                        }
                    }
                }
                if (Bot.HasInHand(MonsterId.Z_aoding) || Bot.HasInBanished(MonsterId.Z_aoding))
                {
                    ClientCard card = Util.GetBestEnemyCard(false, true);
                    //List<ClientCard> cards = new List<ClientCard>();
                    //cards.AddRange(Bot.GetHands());
                    //cards.AddRange(Bot.GetOnField());  && cards != null && Bot.GetCountCardInZone(cards, 0x7cca, true, false) > 0
                    if (card != null)
                    {
                        AI.SelectCard(MonsterId.Z_aoding);
                        return true;
                    }

                }
                if ((Bot.HasInHand(MonsterId.Z_badeer) || Bot.HasInBanished(MonsterId.Z_badeer))
                    && (IsShouldSummonZ_Badeer() || CheckRemainInDeck(MonsterId.Z_badeer) > 0))
                {
                    AI.SelectCard(MonsterId.Z_badeer);
                    return true;
                }
                if (Bot.HasInBanished(MonsterId.Z_tuoer))
                {
                    AI.SelectCard(MonsterId.Z_tuoer);
                    return true;
                }
                if ((GetCountCardInZone(Bot.Banished, CardType.Monster, 0x7cca, true, false) +
                    GetCountCardInZone(Bot.Hand, CardType.Monster, 0x7cca, true, false)) > 2)
                {
                    List<ClientCard> reCards = GetCardInZone(Bot.Banished, CardType.Monster, 0x7cca, true, false);
                    List<ClientCard> resCards = new List<ClientCard>();
                    if (reCards != null && reCards.Count() > 0)
                    {
                        foreach (var _card in reCards)
                        {
                            if (_card.IsCode(MonsterId.Z_tuoer)
                                || _card.IsCode(MonsterId.Z_luoji))
                            {
                                resCards.Add(_card);
                            }
                        }
                        resCards.AddRange(Bot.GetHands());
                        AI.SelectCard(resCards);
                        return true;
                    }
                }
                else
                {
                    AI.SelectCard(CardLocation.Hand);
                    return true;
                }
            }
            return false;
        }
        private bool TheFlyEffeect()
        {
            if (Duel.Phase < DuelPhase.Main1 && Duel.LastChainPlayer == -1) return false;
            if (Duel.Phase >= DuelPhase.Main1 && Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0) return false;
            return Bot.LifePoints > 1000;
        }

        private bool JutuanhousheEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                Jutuanhoushe_1_Activated = true;
                AI.SelectCard(MonsterId.BeastNero, MonsterId.Dasuo, MonsterId.Luxien);
                return true;
            }
            else
            {
                return true;
            }

        }
        //战士-西 特殊召唤
        private bool XigefuliSummon()
        {
            //Logger.DebugWriteLine("西进入了正常的特殊召唤");
            Z_iigefuli_1_Summon = true;
            AI.SelectCard(CardLocation.Hand);
            return true;
        }
        //战士-西 发动
        private bool XigefuliEffect()
        {
            AI.SelectCard(MonsterId.Z_zhaolai);
            return true;

        }
        //黄金柜
        private bool HuangjinguiEffect()
        {
            if (Bot.Hand.Count <= 0)
            {
                AI.SelectCard(MonsterId.Y_TheMirror, MonsterId.Y_TheLight, MonsterId.Y_TheFirey, MonsterId.BeastNero
                    , MonsterId.Z_aoding, MonsterId.Z_badeer, MonsterId.Z_xigefuli, MonsterId.Z_luoji);
            }
            else
            {
                AI.SelectCard(MonsterId.Y_TheMirror, MonsterId.Y_TheWatery, MonsterId.Y_TheLight, MonsterId.BeastNero
                    , MonsterId.Z_aoding, MonsterId.Z_badeer, MonsterId.Z_xigefuli, MonsterId.Z_luoji);
            }
            return true;

        }
        //TheWatery
        private bool TheWateryEffect()
        {

            if (Card.Location == CardLocation.MonsterZone)
            {
                return true;
            }
            else
            {
                if (Bot.Hand.Count() <= 0) return false;
                List<ClientCard> cards = new List<ClientCard>();
                foreach (var card in Bot.GetHands())
                {
                    if ((card.Id == MonsterId.Z_badeer && Z_badeer_Summon)
                        || (card.Id == MonsterId.Z_tuoer && Z_tuoer_Summon)
                        || (card.Id == MonsterId.Z_haimudaer && Z_haimudaer_Summon)
                        || (card.Id == MonsterId.Z_luoji && Z_luoji_Summon)
                        || card.Id == MonsterId.Y_TheFirey
                        || card.Id == MonsterId.Y_TheLight
                        || card.Id == MonsterId.Y_TheMirror
                        || card.Id == MonsterId.Dasuo
                        || (card.Id == MonsterId.Jutuanhoushe && Jutuanhoushe_1_Activated)
                        || Bot.GetCountCardInZone(Bot.Hand, card.Id) > 1)
                    {
                        cards.Add(card);
                    }
                }
                HashSet<ClientCard> unCards = new HashSet<ClientCard>(cards);
                cards.Clear();
                cards.AddRange(unCards);
                if (cards.Count() >= 1)
                {
                    AI.SelectCard(cards);
                }
                else
                {
                    AI.SelectCard(MonsterId.Dasuo);
                }
                return true;
            }

        }
        //TheMirror
        private bool TheMirrorEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                return true;
            }
            if (Card.Location == CardLocation.Removed)
            {
                return true;
            }
            return false;
        }
        //声优
        private bool Y_Effect()
        {
            List<ClientCard> enCards = null;
            switch (Card.Id)
            {
                case MonsterId.X_shengyou:
                case MonsterId.Zengli:
                    enCards = Enemy.GetMonsters();
                    break;
                case MonsterId.Shengri:
                    enCards = Enemy.GetFields();
                    enCards = enCards.Where(card => card.IsFaceup()).ToList();
                    break;
            }
            if (enCards == null) return false;
            enCards = enCards.Where(card => !card.IsShouldNotBeTarget()).ToList();
            if (enCards.Count <= 0) return false;
            if (enCards.Count <= 1) { AI.SelectCard(enCards); return true; }
            enCards.Sort(CardContainer.CompareCardAttack);
            enCards.Reverse();
            AI.SelectCard(enCards);
            return true;
        }
        //魔力
        private bool MoliEffect()
        {
            Moli_Select_1 = true;
            Moli_Select_2 = true;
            Moli_Select_3 = true;
            return true;
        }
    }
}
