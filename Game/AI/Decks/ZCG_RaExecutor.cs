using System;
using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
using System.Linq;
using YGOSharp.Network.Enums;
using YGOSharp.OCGWrapper;

namespace WindBot.Game.AI.Decks
{
    [Deck("Ra", "AI_Ra")]
    class RaExecutor : DefaultExecutor
    {
        public class CardId
        {
            //主卡组
            public const int Tlvmax = 77239945;
            public const int Taolihagang = 77239233;
            public const int Tdiyuyishenlong = 77239925;
            public const int Xjinglingshe = 77240160;
            public const int Tyinengcaijue = 77238323;
            public const int Tjiangshiliang = 77240111;
            public const int Tyanshilong = 77238328;
            public const int Ttoushi = 77240180;
            public const int Tleilong = 77238341;
            public const int Mtyizhi = 77238365;
            public const int Mtguanghui = 77238367;
            public const int Mxieershenlong = 77239686;
            public const int Mtquanlifanji = 77240114;
            public const int Mtbuzu = 77240107;
            public const int Mtmudisusheng = 77240113;
            public const int Xtheiniaokongju = 77238375;
            public const int Xtlingyushenghua = 77238376;
            public const int Xtermoqudai = 77240109;
            //额外
            public const int Tianshenzhanjijiyue = 77239694;
            public const int Liuxingheilong = 77239693;
        }
        List<int> Impermanence_list = new List<int>();
        bool Tlvmax = false;
        bool Tlvmax2 = false;
        bool Tlvmax3 = false;
        bool Taolihagang = false;

        public RaExecutor(GameAI ai, Duel duel)
               : base(ai, duel)
        {
            //卡组特召
            AddExecutor(ExecutorType.SpSummon, Decksummon);
            //太阳神 LVMAX选择
            AddExecutor(ExecutorType.Activate, CardId.Tlvmax, TlvmaxEffect2);
            //太阳神 LVMAX
            AddExecutor(ExecutorType.Activate, CardId.Tlvmax, TlvmaxEffect);
            //太阳神 LVMAX 特殊召唤
            AddExecutor(ExecutorType.Activate, CardId.Tlvmax, TlvmaxSpsummon);
            //魔 全力反击
            AddExecutor(ExecutorType.Activate, CardId.Mtquanlifanji, MtquanlifanjiEffect);
            //太阳神 僵尸娘
            AddExecutor(ExecutorType.Activate, CardId.Tjiangshiliang, TjiangshiliangEffect);
            //奥利哈刚 翼神龙选择
            AddExecutor(ExecutorType.Activate, CardId.Taolihagang, TaolihagangEffect2);
            //太阳神 地狱翼神龙
            AddExecutor(ExecutorType.SpSummon, CardId.Tdiyuyishenlong, TdiyuyishenlongSummon);
            //流星黑龙
            AddExecutor(ExecutorType.Activate, CardId.Liuxingheilong, LiuxingheilongEffect);
            //太阳神 异能裁决
            AddExecutor(ExecutorType.Activate, CardId.Tyinengcaijue, TyinengcaijueEffect);
            //陷 黑鸟恐惧
            AddExecutor(ExecutorType.Activate, CardId.Xtheiniaokongju, XtheiniaokongjuEffect);
            //陷 领域升华
            AddExecutor(ExecutorType.Activate, CardId.Xtlingyushenghua, XtlingyushenghuaEffect);
            //陷 恶魔取代
            AddExecutor(ExecutorType.Activate, CardId.Xtermoqudai, XtermoqudaiEffect);
            //魔 补足
            AddExecutor(ExecutorType.Activate, CardId.Mtbuzu, MtbuzuEffect);
            //魔 邪恶神龙
            AddExecutor(ExecutorType.Activate, CardId.Mxieershenlong, MxieershenlongEffect);
            //魔 光辉 
            AddExecutor(ExecutorType.Activate, CardId.Mtguanghui, MtguanghuiEffect);
            //魔 太阳神复生发动
            AddExecutor(ExecutorType.Activate, CardId.Mtmudisusheng, MtmudisushengActive);
            //魔 太阳神复生
            AddExecutor(ExecutorType.Activate, CardId.Mtmudisusheng, MtmudisushengEffect);
            //奥利哈刚 翼神龙
            AddExecutor(ExecutorType.Activate, CardId.Taolihagang, TaolihagangEffect);
            //奥利哈刚 翼神龙召唤
            AddExecutor(ExecutorType.SpSummon, CardId.Taolihagang, TaolihagangSummon);
            //太阳神 LVMAX召唤
            AddExecutor(ExecutorType.SpSummon, CardId.Tlvmax, TlvmaxSummon);
            //太阳神 雷龙
            AddExecutor(ExecutorType.Activate, CardId.Tleilong, TleilongEffect);
            //太阳神 头饰召唤
            AddExecutor(ExecutorType.Summon, CardId.Ttoushi, TtoushiSummon);
            //太阳神 头饰
            AddExecutor(ExecutorType.Activate, CardId.Ttoushi, TtoushiEffect);
            //流星黑龙
            AddExecutor(ExecutorType.SpSummon, CardId.Liuxingheilong, LiuxingheilongSummon);
            //魔 意志
            AddExecutor(ExecutorType.Activate, CardId.Mtyizhi);
            //奥利哈刚 翼神龙选择3
            AddExecutor(ExecutorType.Activate, CardId.Taolihagang, TaolihagangEffect3);
            //太阳神 雷龙
            AddExecutor(ExecutorType.SummonOrSet, CardId.Tleilong, TtoushiSummon);
            //太阳神 僵尸娘
            AddExecutor(ExecutorType.Summon, CardId.Tjiangshiliang, TjiangshiliangSummon);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
            AddExecutor(ExecutorType.SpellSet, SpellSetEffect);


        }
        //计数专用
        public override void OnNewTurn()
        {
            Tlvmax = false;
            Tlvmax2 = false;
            Tlvmax3 = false;
            Taolihagang = false;
        }
        //选择表示形式设置
        public override CardPosition OnSelectPosition(int cardId, IList<CardPosition> positions)
        {
            switch (cardId)
            {
                case CardId.Tdiyuyishenlong:
                case CardId.Liuxingheilong:
                    return CardPosition.FaceUpDefence;
                default:
                    return base.OnSelectPosition(cardId, positions);
            }
        }
        //奥利哈刚 翼神龙召唤
        private bool TaolihagangSummon()
        {
            if (Taolihagang) return false;
            return true;
        }
        //流星黑龙
        private bool LiuxingheilongEffect()
        {
            if (Duel.LastChainPlayer != 0)
            {
                List<ClientCard> monsters = Bot.GetMonsters();
                foreach (ClientCard card in monsters)
                {
                    if (card.IsFaceup() && card.IsCode(CardId.Tlvmax) && !card.IsDisabled()) return false;
                    return true;
                }
            }
            return true;
        }
        //太阳神 LVMAX
        private bool TlvmaxSpsummon()
        {
            if (Duel.Player == 1 && Bot.GetMonstersInMainZone().Count < 5) return true;
            return false;
        }
        //太阳神 僵尸娘
        private bool TjiangshiliangSummon()
        {
            if (!Tlvmax && !Taolihagang && Bot.GetMonstersInMainZone().Count<=2)
            {
                AI.SelectCard(CardId.Taolihagang, CardId.Tdiyuyishenlong);
                return true;
            }
            return false;
        }
        //太阳神 头饰召唤
        private bool TtoushiSummon()
        {
            if (Tlvmax && !Tlvmax2 && !Tlvmax3) return Bot.GetMonstersInMainZone().Count <= 3;
            else if(Tlvmax2 || Tlvmax3) return Bot.GetMonstersInMainZone().Count <= 2;
            return Bot.GetMonstersInMainZone().Count <= 4;
        }
        //选择卡片
        public override IList<ClientCard> OnSelectCard(IList<ClientCard> cards, int min, int max, long hint, bool cancelable)
        {
            if (ActivateDescription != Util.GetStringId(CardId.Tlvmax, 0) || ActivateDescription != Util.GetStringId(CardId.Tlvmax, 1)) return null;
            else if (Bot.GetMonstersInMainZone().Count < 5)
            {
                foreach (ClientCard card in cards)
                {
                    if (card.IsCode(should_select1))
                    {
                        return new List<ClientCard>(new[] { card });
                    }
                }
            }
            else
            {
                if (Bot.GetCountCardInZone(Bot.Hand, CardType.Spell, 0xa210) > Bot.GetCountCardInZone(Bot.Hand, CardType.Trap, 0xa210) || Bot.GetCountCardInZone(Bot.Hand, CardType.Trap, 0xa210) <= 0)
                {
                    foreach (ClientCard card in cards)
                    {
                        if (card.IsCode(should_select2))
                        {
                            return new List<ClientCard>(new[] { card });
                        }
                    }
                }
                else if (Bot.GetCountCardInZone(Bot.Hand, CardType.Trap, 0xa210) > Bot.GetCountCardInZone(Bot.Hand, CardType.Spell, 0xa210) || Bot.GetCountCardInZone(Bot.Hand, CardType.Spell, 0xa210) <= 0)
                {
                    foreach (ClientCard card in cards)
                    {
                        if (card.IsCode(should_select3))
                        {
                            return new List<ClientCard>(new[] { card });
                        }
                    }
                }
                else
                {
                    foreach (ClientCard card in cards)
                    {
                        if (card.IsCode(should_select4))
                        {
                            return new List<ClientCard>(new[] { card });
                        }
                    }
                }
            }
            return null;
        }
        //卡组检查
        public int CheckRemainInDeck(int id)
        {
            switch (id)
            {
                case CardId.Tlvmax:
                    return Bot.GetRemainingCount(CardId.Tlvmax, 3);
                case CardId.Taolihagang:
                    return Bot.GetRemainingCount(CardId.Taolihagang, 3);
                case CardId.Tdiyuyishenlong:
                    return Bot.GetRemainingCount(CardId.Tdiyuyishenlong, 1);
                case CardId.Xjinglingshe:
                    return Bot.GetRemainingCount(CardId.Xjinglingshe, 3);
                case CardId.Tyinengcaijue:
                    return Bot.GetRemainingCount(CardId.Tyinengcaijue, 1);
                case CardId.Tjiangshiliang:
                    return Bot.GetRemainingCount(CardId.Tjiangshiliang, 2);
                case CardId.Tyanshilong:
                    return Bot.GetRemainingCount(CardId.Tyanshilong, 1);
                case CardId.Ttoushi:
                    return Bot.GetRemainingCount(CardId.Ttoushi, 3);
                case CardId.Tleilong:
                    return Bot.GetRemainingCount(CardId.Tleilong, 3);
                case CardId.Mtyizhi:
                    return Bot.GetRemainingCount(CardId.Mtyizhi, 2);
                case CardId.Mtguanghui:
                    return Bot.GetRemainingCount(CardId.Mtguanghui, 3);
                case CardId.Mxieershenlong:
                    return Bot.GetRemainingCount(CardId.Mxieershenlong, 3);
                case CardId.Mtquanlifanji:
                    return Bot.GetRemainingCount(CardId.Mtquanlifanji, 3);
                case CardId.Mtbuzu:
                    return Bot.GetRemainingCount(CardId.Mtbuzu, 1);
                case CardId.Mtmudisusheng:
                    return Bot.GetRemainingCount(CardId.Mtmudisusheng, 1);
                case CardId.Xtheiniaokongju:
                    return Bot.GetRemainingCount(CardId.Xtheiniaokongju, 3);
                case CardId.Xtlingyushenghua:
                    return Bot.GetRemainingCount(CardId.Xtlingyushenghua, 2);
                case CardId.Xtermoqudai:
                    return Bot.GetRemainingCount(CardId.Xtermoqudai, 2);
                default:
                    return 0;
            }
        }
        //太阳神 异能裁决
        private bool TyinengcaijueEffect()
        {
            if (Duel.LastChainPlayer != 0)
            {
                List<ClientCard> monsters = Bot.GetMonsters();
                foreach (ClientCard card in monsters)
                {
                    if (card.IsFaceup() && card.IsCode(CardId.Tlvmax) && !card.IsDisabled()) return false;
                    return true;
                }
            }
            return false;
        }
        //太阳神 黑鸟恐惧
        private bool  XtheiniaokongjuEffect()
        {
            ClientCard LastChainCard = Util.GetLastChainCard();
            if (LastChainCard != null && Duel.LastChainPlayer != 0 && (LastChainCard.HasType(CardType.Spell) || LastChainCard.HasType(CardType.Trap)))
            {
                if (!Bot.HasInMonstersZone(CardId.Tlvmax))
                {
                    if (Bot.HasInSpellZone(CardId.Xtermoqudai, false, false) && Bot.LifePoints > 500) return false;
                    return true;
                }
                else
                {
                    List<ClientCard> monsters = Bot.GetMonsters();
                    foreach (ClientCard card in monsters)
                    {
                        if (card.IsFaceup() && card.IsCode(CardId.Tlvmax) && !card.IsDisabled()) return false;
                        return true;
                    }

                }
            }
            return false;
        }
        //太阳神 墓地复生 发动
        private bool MtmudisushengActive()
        {
            if (Card.Location == CardLocation.Hand && (Bot.HasInGraveyard(CardId.Tjiangshiliang) || Bot.HasInGraveyard(CardId.Tyinengcaijue) || Bot.HasInGraveyard(CardId.Tleilong)) && Bot.GetSpellCountWithoutField() < 5 && Bot.GetMonstersInMainZone().Count<5)
            {
                return true;
            }
            else if (Card.IsFacedown() && Card.Location == CardLocation.SpellZone) return true;
            return false;
        }
        //覆盖魔陷
        private bool SpellSetEffect()
        {
            return (Card.IsTrap() || Card.HasType(CardType.QuickPlay) || DefaultSpellMustSetFirst()) && Bot.GetSpellCountWithoutField() < 5;
        }
        //太阳神 LVMAX
        private bool TlvmaxSummon()
        {
            if ((Bot.GetMonsterCount() <= 4 && Tlvmax && !Tlvmax2 && !Tlvmax3) || (Bot.GetMonsterCount() <= 3 && Tlvmax2)) return false;
            return true;
        }
        //太阳神 LVMAX
        private bool TlvmaxEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Tlvmax, 0)) return true;
            else if (ActivateDescription == Util.GetStringId(CardId.Tlvmax, 1)) return true;
            else if (ActivateDescription == Util.GetStringId(CardId.Tlvmax, 2)) return true;
            return false;
        }
        //太阳神 LVMAX选择
        private bool TlvmaxEffect2()
        {
            int option;
            if (Enemy.GetMonsterCount()>0)
            {
                option = 0;
            }
            else if (Enemy.Deck.Count>1)
            {
                option = 2;
            }
            else
            {
                option = 1;
            }
            if (ActivateDescription != Util.GetStringId(CardId.Tlvmax, option))
                return false;
            if (!Tlvmax)
            {
                Tlvmax = true;
            }
            else if (!Tlvmax2)
            {
                Tlvmax2 = true;
            }
            else if (!Tlvmax3)
            {
                Tlvmax3 = true;
            }
            return true;
        }
        //奥利哈刚 翼神龙 选择
        private bool TaolihagangEffect2()
        {
            int option;
            if (Bot.GetMonsterCount()+Enemy.GetMonsterCount() == 1) return false;
            else if (Enemy.LifePoints>1)
            {
                option = 1;
            }
            else if (Enemy.GetMonsterCount()+Enemy.GetSpellCount()>=2 && Bot.LifePoints>1000)
            {
                option = 2;
            }
            else
            {
                option = 0;
            }
            if (ActivateDescription != Util.GetStringId(CardId.Taolihagang, option))
                return false;
            Taolihagang = true;
            return true;
        }
        //奥利哈刚 翼神龙 选择2
        private bool TaolihagangEffect3()
        {
            int option;
            if (Enemy.LifePoints > 1)
            {
                option = 1;
            }
            else if (Enemy.GetMonsterCount() + Enemy.GetSpellCount() >= 2 && Bot.LifePoints > 1000)
            {
                option = 2;
            }
            else
            {
                option = 0;
            }
            if (ActivateDescription != Util.GetStringId(CardId.Taolihagang, option))
                return false;
            return true;
        }
        //奥利哈刚 翼神龙 
        private bool TaolihagangEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Taolihagang, 0) && Bot.GetMonsterCount() + Enemy.GetMonsterCount() == 1) return false;
            else if (ActivateDescription == Util.GetStringId(CardId.Taolihagang, 1)) return true;
            else if (ActivateDescription == Util.GetStringId(CardId.Taolihagang, 2))
            {
                ClientCard best = Util.GetBestEnemyCard();
                if (Enemy.GetMonsterCount() + Enemy.GetSpellCount() < 2 || Bot.LifePoints <= 1000) return false;
                AI.SelectCard(best);
                return true;
            }
            return false;
     }
    //流星黑龙
    private bool LiuxingheilongSummon()
    {
            AI.SelectCard(CardId.Liuxingheilong);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            AI.SelectPlace(Zones.z5 | Zones.z6);
            return true;
    }
    public int CheckRemainInDeck(params int[] ids)
    {
        int result = 0;
        foreach (int cardid in ids)
        {
            result += CheckRemainInDeck(cardid);
        }
        return result;
    }
        //陷 领域升华
        private bool XtlingyushenghuaEffect()
        {
            if (Bot.LifePoints <= 600) return false;
            else if (!Bot.HasInMonstersZone(CardId.Tlvmax)) return true;
            else
            {
                List<ClientCard> monsters = Bot.GetMonsters();
                foreach (ClientCard card in monsters)
                {
                    if (card.IsFaceup() && card.IsCode(CardId.Tlvmax) && !card.IsDisabled()) return false;
                    return true;
                }
            }
            return false;
        }
        //陷 恶魔取代
        private bool XtermoqudaiEffect()
        {
            if (Bot.LifePoints <= 500) return false;
            else if (!Bot.HasInMonstersZone(CardId.Tlvmax)) return true;
            else
            {
                List<ClientCard> monsters = Bot.GetMonsters();
                foreach (ClientCard card in monsters)
                {
                    if (card.IsFaceup() && card.IsCode(CardId.Tlvmax) && !card.IsDisabled()) return false;
                    return true;
                }
            }
            return false;
        }
        //卡组特召
        private bool Decksummon()
        {
            if (Card.Location == CardLocation.Deck)
            {
                if (Tlvmax)
                {
                    return Bot.GetMonstersInMainZone().Count <= 3;
                }
                else if (Tlvmax2)
                {
                    return Bot.GetMonstersInMainZone().Count <= 2;
                }
                else if (Tlvmax3)
                {
                    return Bot.GetMonstersInMainZone().Count <= 1;
                }
                return Bot.GetMonstersInMainZone().Count <= 4;
            }
            return false;
        }
        //太阳神 地狱翼神龙
        private bool TdiyuyishenlongSummon()
        {
            if (Card.Location == CardLocation.Hand || Card.Location == CardLocation.Grave)
            {
                if (Tlvmax)
                {
                    return Bot.GetMonstersInMainZone().Count <= 3;
                }
                else if (Tlvmax2)
                {
                    return Bot.GetMonstersInMainZone().Count <= 2;
                }
                else if (Tlvmax3)
                {
                    return Bot.GetMonstersInMainZone().Count <= 1;
                }
                return Bot.GetMonstersInMainZone().Count <= 4;
            }
            return false;
        }
        //太阳神 雷龙
        private bool TleilongEffect()
        {
            if (!Tlvmax && !Tlvmax2 && !Tlvmax3)
            {
                if (CheckRemainInDeck(CardId.Tjiangshiliang) > 0 && Bot.GetMonstersInMainZone().Count < 5)
                {
                    AI.SelectCard(CardId.Tjiangshiliang);
                    return true;
                }
                else if (CheckRemainInDeck(CardId.Tyinengcaijue) > 0 && Bot.GetMonstersInMainZone().Count < 5)
                {
                    AI.SelectCard(CardId.Tyinengcaijue);
                    return true;
                }
            }
            else if (Tlvmax && !Tlvmax2 && !Tlvmax3)
            {
                if (CheckRemainInDeck(CardId.Tjiangshiliang) > 0 && Bot.GetMonstersInMainZone().Count < 4)
                {
                    AI.SelectCard(CardId.Tjiangshiliang);
                    return true;
                }
                else if (CheckRemainInDeck(CardId.Tyinengcaijue) > 0 && Bot.GetMonstersInMainZone().Count < 4)
                {
                    AI.SelectCard(CardId.Tyinengcaijue);
                    return true;
                }
            }
            else if (Tlvmax && !Tlvmax2 && Tlvmax3)
            {
                if (CheckRemainInDeck(CardId.Tjiangshiliang) > 0 && Bot.GetMonstersInMainZone().Count < 3)
                {
                    AI.SelectCard(CardId.Tjiangshiliang);
                    return true;
                }
                else if (CheckRemainInDeck(CardId.Tyinengcaijue) > 0 && Bot.GetMonstersInMainZone().Count < 3)
                {
                    AI.SelectCard(CardId.Tyinengcaijue);
                    return true;
                }
            }
            return false;
        }
        //魔 复生 
        private bool MtmudisushengEffect()
        {
            if (Card.Location == CardLocation.SpellZone && Card.IsFaceup())
            {
                AI.SelectCard(CardId.Tyinengcaijue, CardId.Tjiangshiliang);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }
        //邪恶神龙
        private bool MxieershenlongEffect()
        {
            if (Bot.Deck.Count <= 6 || Bot.GetHandCount()>=6 || (Tlvmax && Bot.GetMonstersInMainZone().Count>0 && Bot.GetHandCount()>=2)) return false;
            return true;
        }
        //魔 全力反击
        private bool MtquanlifanjiEffect()
        {
            int selfBestAttack = Util.GetBestAttack(Bot);
            int oppoBestAttack = Util.GetBestAttack(Enemy);
            if (Bot.GetMonstersInMainZone().Count >= 4 && Bot.GetHandCount() >= 4) return false;
            else if (selfBestAttack <= oppoBestAttack && Bot.GetMonstersInMainZone().Count < 5 && CheckRemainInDeck(CardId.Tlvmax) > 0)
            {
                AI.SelectCard(CardId.Tlvmax, CardId.Tleilong);
                return true;
            }
            else if (Bot.GetCountCardInZone(Bot.Graveyard, CardType.Monster, 0xa210) >= 3 && Enemy.GetHandCount() >= 2 && CheckRemainInDeck(CardId.Mtyizhi) > 0)
            {
                AI.SelectCard(CardId.Mtyizhi);
                return true;
            }
            else if (Bot.GetHandCount() <= 2 && CheckRemainInDeck(CardId.Mtguanghui) > 0)
            {
                AI.SelectCard(CardId.Mtguanghui);
                return true;
            }
            else
            {
                AI.SelectCard(CardId.Tleilong, CardId.Xtheiniaokongju, CardId.Xtlingyushenghua, CardId.Xtermoqudai);
                return true;
            }

        }
        //魔 光辉
        private bool MtguanghuiEffect()
        {
            if (Bot.Deck.Count <= 4 || Bot.GetHandCount()>=6) return false;
            return true;
        }
        //魔 补足
        private bool MtbuzuEffect()
        {
            if (Bot.Deck.Count <= 3) return false;
            return true;
        }
        List<int> should_select1 = new List<int>
        {
           CardId.Tlvmax, CardId.Taolihagang, CardId.Mxieershenlong, CardId.Tleilong,CardId.Mtguanghui,CardId.Mtbuzu
        };
        List<int> should_select2 = new List<int>
        {
          CardId.Xtermoqudai, CardId.Xtheiniaokongju, CardId.Xtlingyushenghua, CardId.Mxieershenlong, CardId.Mtguanghui, CardId.Mtbuzu
        };
        List<int> should_select3 = new List<int>
        {
          CardId.Mxieershenlong, CardId.Mtguanghui, CardId.Mtbuzu, CardId.Xtermoqudai, CardId.Xtheiniaokongju, CardId.Xtlingyushenghua
        };
        List<int> should_select4 = new List<int>
        {
         CardId.Mxieershenlong, CardId.Mtguanghui, CardId.Mtbuzu, CardId.Xtermoqudai, CardId.Xtheiniaokongju, CardId.Xtlingyushenghua
        };
        //太阳神 头饰 
        private bool TtoushiEffect()
        {
            if (Bot.GetMonstersInMainZone().Count < 5)
            {
                AI.SelectCard(CardId.Tlvmax, CardId.Taolihagang, CardId.Mxieershenlong, CardId.Tleilong,CardId.Mtguanghui,CardId.Mtbuzu);
                return true;
            }
            else
            {
                if (Bot.GetCountCardInZone(Bot.Hand, CardType.Spell, 0xa210) > Bot.GetCountCardInZone(Bot.Hand, CardType.Trap, 0xa210) || Bot.GetCountCardInZone(Bot.Hand, CardType.Trap, 0xa210) <= 0)
                {
                    AI.SelectCard(CardId.Xtermoqudai, CardId.Xtheiniaokongju, CardId.Xtlingyushenghua, CardId.Mxieershenlong, CardId.Mtguanghui, CardId.Mtbuzu);
                    return true;
                }
                else if (Bot.GetCountCardInZone(Bot.Hand, CardType.Trap, 0xa210) > Bot.GetCountCardInZone(Bot.Hand, CardType.Spell, 0xa210) || Bot.GetCountCardInZone(Bot.Hand, CardType.Spell, 0xa210) <= 0)
                {
                    AI.SelectCard(CardId.Mxieershenlong, CardId.Mtguanghui, CardId.Mtbuzu, CardId.Xtermoqudai, CardId.Xtheiniaokongju, CardId.Xtlingyushenghua);
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Mxieershenlong, CardId.Mtguanghui, CardId.Mtbuzu, CardId.Xtermoqudai, CardId.Xtheiniaokongju, CardId.Xtlingyushenghua);
                    return true;
                }
            }
        }
        //太阳神 僵尸娘
        private bool TjiangshiliangEffect()
        {
            AI.SelectCard(CardId.Tlvmax, CardId.Tdiyuyishenlong,CardId.Tdiyuyishenlong);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
    }
} 
