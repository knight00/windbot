using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using System.Linq;
using System;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
namespace WindBot.Game.AI.Decks
{
    [Deck("Armor", "AI_Armor", "NotFinished")]
    public class ArmorExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Zpilizhanche = 77240273;
            public const int Zdongfengdaqi = 77240271;
            public const int Zjiqiangzhishengji = 77240272;
            public const int Zzhandilongxia = 77240143;
            public const int Zjuxing3 = 77240140;
            public const int Zjuxing2 = 77240276;
            public const int Zjuxing1 = 77240139;
            public const int Zpaoshouxia = 77240300;

            public const int Zganlan1 = 77240277;
            public const int Zganlan2 = 77240278;
            public const int Zganlan3 = 77240279;
            public const int Zmufangshuimu = 77240266;
            public const int Zzhadanbing = 77240142;
            public const int Zyidongchengbao = 77240268;
            public const int Mmuxiechengdapao = 77240289;
            public const int Mnengyuangongji = 77239835;

            public const int Mzibaoshi = 77239840;
            public const int Mqianxiandazuozhan = 77240291;
            public const int Myanjiutai = 77240293;
            public const int Mzhibaohuangjincha = 77240294;
            public const int Mkongjianjidi = 77240287;
            public const int Msanjiaodun = 77240292;
            public const int Xjinjizhunbei = 77240295;
            public const int Xbanxienenggaizao = 77240296;

            public const int Zzhandoubaolei = 77240302;
            public const int Ztiefujiangjun = 77240301;
            public const int Zgudaibingqi = 77239805;
            public const int Zchaojuxingtanke = 77240284;
            public const int Zyuanshilongxia = 77240286;
            public const int Zhangtianfeichuan = 77240285;
        }
        //装甲 前线准备-计数器
        int turnNumber = 0;
        //装甲 模仿水母-计数器
        int zmufangshuimuNumber = 0;
        //效果重置
        bool Xjinjizhunbei = false;
        bool Mzibaoshi = false;
        bool Mzibao = false;

        //装甲 东风大汽-召唤提示
        bool Zdongfongdaqi = false;

        //召唤重置
        bool Zhangtianfeichuan = false;
        public ArmorExecutor(GameAI ai, Duel duel)
     : base(ai, duel)
        {
            //魔 三角盾
            AddExecutor(ExecutorType.Activate, CardId.Msanjiaodun);
            //装甲 炮手侠 效果
            AddExecutor(ExecutorType.Activate, CardId.Zpaoshouxia, ZpaoshouxiaEffect);
            //魔 至宝黄金叉
            AddExecutor(ExecutorType.Activate, CardId.Mzhibaohuangjincha, MzhibaohuangjinchaEffect);
            //装甲 炮手侠
            AddExecutor(ExecutorType.Summon, CardId.Zpaoshouxia);
            AddExecutor(ExecutorType.Activate, CardId.Mkongjianjidi, MkongjianjidiEffect);
            //卡组特召
            AddExecutor(ExecutorType.SpSummon, DeckSummon);
            //装甲 霹雳战车
            AddExecutor(ExecutorType.SpSummon, CardId.Zpilizhanche, ZpilizhancheSummon);
            //魔 自爆
            AddExecutor(ExecutorType.Activate, CardId.Mzibaoshi, MzibaoshijiEffect);
            //魔 墓械城大炮
            AddExecutor(ExecutorType.Activate, CardId.Mmuxiechengdapao, MmuxiechengdapaoEffect);
            //装甲 巨型坦克
            AddExecutor(ExecutorType.SpSummon, CardId.Zjuxing1, OnFieldSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Zjuxing2, OnFieldSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Zjuxing3, OnFieldSummon);

            //装甲 战地龙虾 效果 
            AddExecutor(ExecutorType.Activate, CardId.Zzhandilongxia);
            //装甲 战地龙虾
            AddExecutor(ExecutorType.SpSummon, CardId.Zzhandilongxia, ZzhandilongxiaSummon);
            //装甲 模仿水母
            AddExecutor(ExecutorType.Summon, CardId.Zmufangshuimu, ZmufangshuimuSummon);
            //装甲 东风大汽
            AddExecutor(ExecutorType.Summon, CardId.Zdongfengdaqi, ZdongfengdaqiSummon);
            //装甲 直升机
            AddExecutor(ExecutorType.Activate, CardId.Zjiqiangzhishengji, ZjiqiangzhishengjiEffect);
            //装甲 航天飞船 效果
            AddExecutor(ExecutorType.Activate, CardId.Zhangtianfeichuan, ZhangtianfeichuanEffect);
            //魔 墓械城大炮 发动 
            AddExecutor(ExecutorType.Activate, CardId.Mmuxiechengdapao, MmuxiechengdapaoActive);
            //魔 自爆 发动 
            AddExecutor(ExecutorType.Activate, CardId.Mzibaoshi, MzibaoshijiActive);
            //魔 前线大作战
            AddExecutor(ExecutorType.Activate, CardId.Mqianxiandazuozhan, MqianxiandazuozhanEffect);
            //魔 研究台
            AddExecutor(ExecutorType.Activate, CardId.Myanjiutai, MyanjiutaiEffect);
            //魔 空间基地
            AddExecutor(ExecutorType.Activate, CardId.Mkongjianjidi, MkongjianjidiEffect);
            //魔 能源供给
            AddExecutor(ExecutorType.Activate, CardId.Mnengyuangongji);
            //陷 进击准备 
            AddExecutor(ExecutorType.Activate, CardId.Xjinjizhunbei, XjinjizhunbeiEffect);
            //陷 半械能改造
            AddExecutor(ExecutorType.Activate, CardId.Xbanxienenggaizao, XbanxienenggaizaoEffect);

            //装甲 橄榄兵
            AddExecutor(ExecutorType.Summon, CardId.Zganlan1);
            AddExecutor(ExecutorType.Summon, CardId.Zganlan2);
            AddExecutor(ExecutorType.Summon, CardId.Zganlan3);

            AddExecutor(ExecutorType.Activate, CardId.Zganlan1);
            AddExecutor(ExecutorType.Activate, CardId.Zganlan2);
            AddExecutor(ExecutorType.Activate, CardId.Zganlan3);

            AddExecutor(ExecutorType.Activate, CardId.Zjuxing1);
            AddExecutor(ExecutorType.Activate, CardId.Zjuxing2);
            AddExecutor(ExecutorType.Activate, CardId.Zjuxing3);

            //装甲 移动城堡
            AddExecutor(ExecutorType.Summon, CardId.Zyidongchengbao);
            //装甲 移动城堡 效果
            AddExecutor(ExecutorType.Activate, CardId.Zyidongchengbao, ZyidongchengbaoEffect);

            //装甲 战斗堡垒
            AddExecutor(ExecutorType.SpSummon, CardId.Zzhandoubaolei);
            //装甲 战斗堡垒
            AddExecutor(ExecutorType.Activate, CardId.Zzhandoubaolei);

            //装甲 原始龙虾
            AddExecutor(ExecutorType.SpSummon, CardId.Zyuanshilongxia, ZyuanshilongxiaSummon);
            //装甲 原始龙虾
            AddExecutor(ExecutorType.Activate, CardId.Zyuanshilongxia);

            //装甲 铁斧将军
            AddExecutor(ExecutorType.Activate, CardId.Ztiefujiangjun, ZtiefujiangjunEffect);
            //装甲 铁斧将军
            AddExecutor(ExecutorType.SpSummon, CardId.Ztiefujiangjun, ZtiefujiangjunSummon);

            //装甲 航天飞船
            AddExecutor(ExecutorType.SpSummon, CardId.Zhangtianfeichuan, ZhangtianfeichuanSummon);


            //装甲 超巨型坦克
            AddExecutor(ExecutorType.SpSummon, CardId.Zchaojuxingtanke, ZchaojuxingtankeSummon);
            //装甲 超巨型坦克
            AddExecutor(ExecutorType.Activate, CardId.Zchaojuxingtanke);


            //装甲 古代兵器
            AddExecutor(ExecutorType.SpSummon, CardId.Zgudaibingqi);
            //装甲 古代兵器
            AddExecutor(ExecutorType.Activate, CardId.Zgudaibingqi);

            //装甲 模仿水母
            AddExecutor(ExecutorType.Summon, CardId.Zmufangshuimu, ZmufangshuimuSummon2);
            //装甲 模仿水母
            AddExecutor(ExecutorType.Summon, CardId.Zmufangshuimu, ZmufangshuimuSummon3);
            //魔陷盖放
            AddExecutor(ExecutorType.SpellSet, SpellSet);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
        }
        //新回合
        public override void OnNewTurn()
        {
            Zhangtianfeichuan = false;
            zmufangshuimuNumber = 0;
            Mzibaoshi = false;
            Mzibao = false;

            //战前准备
            if (turnNumber > 0 && turnNumber + 3 < Duel.Turn)
            {
                Xjinjizhunbei = false;
            }
        }
        //检查装甲 模仿水母是否在场
        public bool Zmufangshuimu()
        {
            foreach (ClientCard card in Bot.GetMonsters())
            {
                if (card.IsCode(CardId.Zmufangshuimu) && !card.IsDisabled())
                {
                    if (zmufangshuimuNumber == 0)
                    {
                        zmufangshuimuNumber = 1;
                        return true;
                    }
                }
            }
            return false;
        }
        public override int OnSelectOption(IList<long> options)
        {
            if (Zdongfongdaqi && Bot.GetMonsterCount()>0)
            {
                Zdongfongdaqi = false;
                return 1;
            }
            return -1;
        }
        //AI选择是否（装甲）
        public override bool OnSelectYesNo(long desc)
        {
            if (desc == Util.GetStringId(98710729, 2))
            {

                return true;
            }
            return base.OnSelectYesNo(desc);
        }
        //AI选择 装甲 模仿水母
        public override IList<ClientCard> OnSelectCard(IList<ClientCard> cards, int min, int max, long hint, bool cancelable)
        {
            if (zmufangshuimuNumber == 1)
            {
                List<ClientCard> ClientCards = new List<ClientCard>();
                foreach (ClientCard card in cards)
                {
                    if (card.HasType(CardType.Monster))
                    {
                        ClientCards.Add(card);
                    }
                }
                ClientCards.Sort(CardContainer.CompareCardAttack);
                ClientCards.Reverse();
                zmufangshuimuNumber = 2;
                return ClientCards;
            }
            return null;
        }
        //卡组检查
        public int CheckRemainInDeck(int id)
        {
            switch (id)
            {
                case CardId.Zpilizhanche:
                    return Bot.GetRemainingCount(CardId.Zpilizhanche, 3);
                case CardId.Zdongfengdaqi:
                    return Bot.GetRemainingCount(CardId.Zdongfengdaqi, 3);
                case CardId.Zjiqiangzhishengji:
                    return Bot.GetRemainingCount(CardId.Zjiqiangzhishengji, 2);
                case CardId.Zzhandilongxia:
                    return Bot.GetRemainingCount(CardId.Zzhandilongxia, 3);
                case CardId.Zjuxing3:
                    return Bot.GetRemainingCount(CardId.Zjuxing3, 1);
                case CardId.Zjuxing2:
                    return Bot.GetRemainingCount(CardId.Zjuxing2, 1);
                case CardId.Zjuxing1:
                    return Bot.GetRemainingCount(CardId.Zjuxing1, 2);
                case CardId.Zpaoshouxia:
                    return Bot.GetRemainingCount(CardId.Zpaoshouxia, 2);
                case CardId.Zganlan1:
                    return Bot.GetRemainingCount(CardId.Zganlan1, 1);
                case CardId.Zganlan2:
                    return Bot.GetRemainingCount(CardId.Zganlan2, 1);
                case CardId.Zganlan3:
                    return Bot.GetRemainingCount(CardId.Zganlan3, 1);
                case CardId.Zmufangshuimu:
                    return Bot.GetRemainingCount(CardId.Zmufangshuimu, 1);
                case CardId.Zyidongchengbao:
                    return Bot.GetRemainingCount(CardId.Zyidongchengbao, 1);
                default:
                    return 0;
            }
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
        //装甲 模仿水母
        private bool ZmufangshuimuSummon3()
        {
            return Bot.HasInHand(CardId.Mzhibaohuangjincha);
        }
        //装甲 半械能改造
        private bool XbanxienenggaizaoEffect()
        {
            if (Card.Location == CardLocation.Hand || (Card.Location == CardLocation.SpellZone && Card.IsFacedown()))
            {
                return !Bot.HasInSpellZone(CardId.Xbanxienenggaizao, true, true);
            }
            return true;
        }
        //装甲模仿水母
        private bool ZmufangshuimuSummon2()
        {
            return Bot.GetMonsterCount() + Enemy.GetMonsterCount() > 0;
        }
        //装甲 超巨型坦克
        private bool ZchaojuxingtankeSummon()
        {
            if (Bot.HasInSpellZone(CardId.Zzhandilongxia) || Bot.HasInMonstersZone(CardId.Zjiqiangzhishengji)) return false;

            else if (Enemy.GetMonsterCount() > 0)
            {
                var cards = new List<ClientCard>();
                foreach (ClientCard card in Enemy.GetMonsters())
                {
                    cards.Add(card);
                }
                var res = cards.Where(card => card.HasRace(CardRace.Machine));
                if (res == null && Duel.Phase <= DuelPhase.Battle && Enemy.LifePoints <= 5000) return true;
                else if (Bot.GetMonsterCount() > Enemy.GetMonsterCount() && Bot.GetMonsterCount() > 3)
                {
                    var materialsCardsList = new List<ClientCard>();
                    foreach (ClientCard materialsCard in Bot.GetMonsters())
                    {
                        materialsCardsList.Add(materialsCard);
                    }
                    foreach (ClientCard card in Bot.GetSpells())
                    {
                        if (card.IsCode(CardId.Mzhibaohuangjincha) && card.IsFaceup() && !card.IsDisabled())
                        {
                            materialsCardsList.Remove(card.EquipTarget);
                        }
                    }
                    if (Bot.GetCountCardInZone(materialsCardsList, CardType.Monster, 0x7c41) < 3) return false;
                    AI.SelectCard(materialsCardsList);
                    return true;
                }
                return false;
            }
            else if (Enemy.GetMonsterCount() == 0)
            {
                int number = 0;
                foreach (ClientCard card in Bot.GetMonsters())
                {
                    number = number + card.Attack;
                }
                if (number > 5000) return false;
                return true;

            }
            return false;
        }
        //装甲 原始龙虾 
        private bool ZyuanshilongxiaSummon()
        {
            if (Enemy.LifePoints <= 2000 || (Bot.HasInHandOrInSpellZone(CardId.Mzibaoshi) && !Mzibaoshi && Enemy.LifePoints <= 2000 + Card.Defense * 2)) return true;
            return false;
        }
        //装甲 铁斧将军 召唤
        private bool ZtiefujiangjunSummon()
        {
            var cards = new List<ClientCard>();
            foreach (ClientCard card in Bot.GetMonsters())
            {
                cards.Add(card);
            }
            cards.Sort(CardContainer.CompareCardAttack);
            AI.SelectMaterials(cards);
            return true;
        }
        //装甲 铁斧将军 效果
        private bool ZtiefujiangjunEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Ztiefujiangjun, 0))
            {
                var cards = new List<ClientCard>();
                foreach (ClientCard card in Enemy.GetMonsters())
                {
                    cards.Add(card);
                }
                foreach (ClientCard card2 in Enemy.GetSpells())
                {
                    cards.Add(card2);
                }
                AI.SelectCard(cards);
                return true;
            }
            else
            {
                AI.SelectCard(CardId.Zyidongchengbao, CardId.Zganlan1, CardId.Zganlan2, CardId.Zganlan3, CardId.Mnengyuangongji, CardId.Mmuxiechengdapao, CardId.Myanjiutai);
                AI.SelectNextCard(CardId.Zyidongchengbao, CardId.Zganlan1, CardId.Zganlan2, CardId.Zganlan3, CardId.Mnengyuangongji, CardId.Mmuxiechengdapao, CardId.Myanjiutai);
                return true;
            }
        }

        //装甲 空间基地
        private bool MkongjianjidiEffect()
        {
            if (Card.Location == CardLocation.Hand || (Card.Location == CardLocation.SpellZone && Card.IsFacedown()))
            {
                return true;
            }
            else if (Card.Location == CardLocation.SpellZone && Card.IsFaceup())
            {
                if (!Bot.HasInHand(CardId.Zyidongchengbao) && !Bot.HasInHand(CardId.Zganlan1) && !Bot.HasInHand(CardId.Zganlan2) && !Bot.HasInHand(CardId.Zganlan3) && !Bot.HasInHand(CardId.Mnengyuangongji) && !Bot.HasInHand(CardId.Mmuxiechengdapao) && !Bot.HasInHand(CardId.Myanjiutai)) return false;
                {
                    AI.SelectCard(CardId.Zyidongchengbao, CardId.Zganlan1, CardId.Zganlan2, CardId.Zganlan3, CardId.Mnengyuangongji, CardId.Mmuxiechengdapao, CardId.Myanjiutai);
                    return true;
                }
            }
            return false;

        }
        public int GetCountCardInZone(IEnumerable<ClientCard> cards, CardRace cardRace)
        {
            return cards.Count(card => card != null && card.HasRace(cardRace));
        }
        //装甲 研究台
        private bool MyanjiutaiEffect()
        {
            if (Card.Location == CardLocation.Hand) return true;
            else if (Card.Location == CardLocation.SpellZone)
            {
                if (ActivateDescription == Util.GetStringId(CardId.Myanjiutai, 0))
                {
                    List<ClientCard> ClientCards = Bot.GetMonsters();
                    ClientCards.Sort(CardContainer.CompareCardAttack);
                    ClientCard target = Util.GetBestEnemyMonster();
                    AI.SelectCard(ClientCards);
                    AI.SelectNextCard(target);
                    return true;
                }
                else if (ActivateDescription == Util.GetStringId(CardId.Myanjiutai, 1))
                {
                    List<ClientCard> ClientCards = Bot.GetMonsters();
                    ClientCards.Sort(CardContainer.CompareCardAttack);
                    AI.SelectCard(ClientCards);
                    AI.SelectNextCard(CardId.Zjiqiangzhishengji,CardId.Zchaojuxingtanke,CardId.Ztiefujiangjun,CardId.Zpaoshouxia,CardId.Zhangtianfeichuan);
                    return true;
                }
                else if (Bot.GetCountCardInZone(Bot.MonsterZone, CardType.Monster, 0x7c41) > 0 && Bot.GetCountCardInZone(Bot.Graveyard, CardType.Monster, 0x7c41) > 0 && Enemy.GetMonsterCount() > 0)
                {
                    int option;
                    int selfBestAttack = Util.GetBestAttack(Bot);
                    int oppoBestAttack = Util.GetBestAttack(Enemy);
                    if (selfBestAttack < oppoBestAttack && !Bot.HasInGraveyard(CardId.Zjiqiangzhishengji) && (!Bot.HasInGraveyard(CardId.Zgudaibingqi) || GetCountCardInZone(Enemy.MonsterZone, CardRace.Machine) > 0))
                    {
                        option = 0;
                    }
                    else
                    {
                        option = 1;
                    }
                    if (ActivateDescription != Util.GetStringId(CardId.Myanjiutai, option))
                        return false;
                }
                return false;
            }
            return false;
        }
        //巨型坦克特殊召唤
        private bool OnFieldSummon()
        {
            List<ClientCard> botClientCards = new List<ClientCard>();
            List<ClientCard> botClientCards2 = new List<ClientCard>();
            ClientCard equipTarget = null;
            foreach (ClientCard botCard in Bot.GetSpells())
            {
                if (!botCard.IsCode(CardId.Mzhibaohuangjincha))
                {
                    botClientCards.Add(botCard);
                }
                else
                {

                    botCard.EquipTarget = equipTarget;
                }
            }
            foreach (ClientCard botCard in Bot.GetMonsters())
            {
                botClientCards2.Add(botCard);
            }
            if (equipTarget != null)
            {
                botClientCards2.Remove(equipTarget);
            }
            botClientCards2.Sort(CardContainer.CompareCardAttack);
            botClientCards2.AddRange(botClientCards);
            List<ClientCard> enClientCards = new List<ClientCard>();
            foreach (ClientCard enCard in Enemy.GetMonsters())
            {
                enClientCards.Add(enCard);
            }
            enClientCards.Sort(CardContainer.CompareCardAttack);
            enClientCards.Reverse();
            foreach (ClientCard enCard in Enemy.GetSpells())
            {
                enClientCards.Add(enCard);
            }
            if (botClientCards.Count < 1 || enClientCards.Count < 1) return false;
            AI.SelectCard(botClientCards);
            AI.SelectNextCard(enClientCards);
            return true;
        }
        //装甲 前线准备
        private bool XjinjizhunbeiEffect()
        {
            bool TrapCard = false;
            foreach (ClientCard card in Bot.GetSpells())
            {
                if (card.IsFacedown() && card.HasType(CardType.Trap) && !card.IsCode(CardId.Xjinjizhunbei))
                {
                    TrapCard = true;
                }
            }
            if (!Xjinjizhunbei)
            {
                turnNumber = Duel.Turn;
                Xjinjizhunbei = true;
                return true;
            }
            else if (Bot.HasInHand(CardId.Zjiqiangzhishengji) && Bot.GetMonstersInMainZone().Count < 5)
            {
                if (TrapCard)
                {
                    return false;
                }
                else if (Bot.GetCountCardInZone(Bot.SpellZone, CardId.Xjinjizhunbei) > 1)
                {
                    ClientCard last_card = Util.GetLastChainCard();
                    if (last_card != null && last_card.Controller == 0 && (last_card.HasType(CardType.Trap) || last_card.IsCode(CardId.Zjiqiangzhishengji))) return false;
                    return true;
                }
                return false;
            }
            return false;
        }
        //装甲 战地龙虾
        private bool ZzhandilongxiaSummon()
        {
            return Bot.Deck.Count >= 3 && Bot.GetMonstersInMainZone().Count < 5;
        }
        //装甲 移动城堡 
        private bool ZyidongchengbaoEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.Zpaoshouxia, CardId.Zganlan1, CardId.Zganlan2, CardId.Zganlan3);
                return true;
            }
            return true;
        }
        //装甲 航天飞船
        private bool ZhangtianfeichuanSummon()
        {   if (Bot.HasInMonstersZone(CardId.Zchaojuxingtanke) && GetCountCardInZone(Enemy.MonsterZone,CardRace.Machine)==0)
            {
                return false;
            }
            else if (!Zhangtianfeichuan)
            {
                if (Bot.HasInMonstersZone(CardId.Zhangtianfeichuan) && CheckRemainInDeck(CardId.Zjiqiangzhishengji) <= 0 && CheckRemainInDeck(CardId.Zpaoshouxia) <= 0 && !Bot.HasInExtra(CardId.Ztiefujiangjun)) return false;
                else if (Bot.HasInSpellZone(CardId.Mzhibaohuangjincha))
                {
                    var materialsCardsList = new List<ClientCard>();
                    foreach (ClientCard materialsCard in Bot.GetMonsters())
                    {
                        materialsCardsList.Add(materialsCard);
                    }
                    foreach (ClientCard card in Bot.GetSpells())
                    {
                        if (card.IsCode(CardId.Mzhibaohuangjincha) && card.IsFaceup() && !card.IsDisabled())
                        {
                            materialsCardsList.Remove(card.EquipTarget);
                        }
                    }
                    if (Bot.GetCountCardInZone(materialsCardsList, CardType.Monster, 0x7c41) < 3) return false;
                    AI.SelectCard(materialsCardsList);
                    Zhangtianfeichuan = true;
                    return true;
                }
                else
                {
                    //AI.SelectMaterials(new int[] { CardId.Zpilizhanche, CardId.Zpilizhanche, CardId.Zpilizhanche, CardId.Zdongfengdaqi, CardId.Zganlan1, CardId.Zganlan2 });
                    AI.SelectCard(CardId.Zpilizhanche, CardId.Zpilizhanche, CardId.Zpilizhanche, CardId.Zdongfengdaqi, CardId.Zganlan1, CardId.Zganlan2,CardId.Zjuxing1, CardId.Zjuxing2, CardId.Zjuxing3,CardId.Zhangtianfeichuan,CardId.Zjiqiangzhishengji);
                    Zhangtianfeichuan = true;
                    return true;
                }
            }
            else if (Zhangtianfeichuan)
            {
                if (Bot.HasInMonstersZone(CardId.Zhangtianfeichuan) || Bot.GetMonstersInMainZone().Count <= 3) return false;
                AI.SelectCard(CardId.Zpilizhanche, CardId.Zpilizhanche, CardId.Zpilizhanche, CardId.Zdongfengdaqi, CardId.Zganlan1, CardId.Zganlan2);
                return true;
            }
            return false;
        }
        //装甲 航天飞船 效果
        private bool ZhangtianfeichuanEffect()
        {
            AI.SelectCard(CardId.Zganlan1);
            if (!Bot.HasInMonstersZone(CardId.Zjiqiangzhishengji) && CheckRemainInDeck(CardId.Zjiqiangzhishengji) > 0)
            {              
                AI.SelectNextCard(CardId.Zjiqiangzhishengji);
            }
            else if (CheckRemainInDeck(CardId.Zpaoshouxia) > 0 && Bot.GetCountCardInZone(Bot.MonsterZone, CardType.Monster, 0x7c41) > 1 && Bot.HasInExtra(CardId.Ztiefujiangjun))
            {
                AI.SelectNextCard(CardId.Zpaoshouxia);
            }

            else
            {
                AI.SelectNextCard(CardId.Zdongfengdaqi, CardId.Zjuxing1, CardId.Zjuxing2, CardId.Zjuxing3, CardId.Zzhandilongxia);
            }
            return true;
        }
        //装甲 霹雳战车
        private bool ZpilizhancheSummon()
        {
            return Bot.GetMonstersInMainZone().Count < 5;
        }
        //装甲 至宝黄金叉 效果
        private bool MzhibaohuangjinchaEffect()
        {
            List<ClientCard> bot_monsters = Bot.GetMonsters();
            bot_monsters.Sort(CardContainer.CompareCardAttack);
            bot_monsters.Reverse();
            if (Bot.GetMonsters().Count > 1)
            {
                for (int i = 0; i < bot_monsters.Count; i++)
                {
                    ClientCard card = bot_monsters[i];
                    if (card.IsCode(CardId.Zdongfengdaqi) && !card.IsDisabled())
                    {
                        bot_monsters.Add(card);
                    }
                }
                AI.SelectCard(bot_monsters);
                return true;
            }
            else
            {
                AI.SelectCard(bot_monsters);
                return true;
            }
        }
        //卡组特召
        private bool DeckSummon()
        {
            return Card.Location == CardLocation.Deck && Bot.GetMonstersInMainZone().Count < 5;
        }
        //魔陷盖放
        private bool SpellSet()
        {
            return Bot.GetSpellCountWithoutField()< 5 && (Card.HasType(CardType.Trap) || Card.HasType(CardType.QuickPlay));
        }
        //装甲 墓械城大炮 发动
        private bool MmuxiechengdapaoActive()
        {
            if (Card.Location == CardLocation.Hand || (Card.Location == CardLocation.SpellZone) && Card.IsFacedown())
            {
                return Bot.GetCountCardInZone(Bot.Graveyard, CardType.Monster, 0x7c41) > 1 && Bot.GetMonstersInMainZone().Count <= 3;
            }
            return false;
        }
        //装甲 墓械城大炮
        private bool MmuxiechengdapaoEffect()
        {
            if (Card.Location == CardLocation.SpellZone && Card.IsFaceup() && !Card.IsDisabled())
            {
                AI.SelectCard(CardId.Zjiqiangzhishengji, CardId.Zhangtianfeichuan, CardId.Zchaojuxingtanke);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }
        //装甲 自爆式 发动
        private bool MzibaoshijiActive()
        {
            if (Card.Location == CardLocation.Hand || (Card.Location == CardLocation.SpellZone) && Card.IsFacedown())
            {
                foreach (ClientCard card in Bot.GetSpells())
                {
                    if (card.IsFaceup() && card.IsCode(CardId.Mzibaoshi)) return false;
                }
                return true;
            }
           return false;
        }
        //装甲 自爆式
        private bool MzibaoshijiEffect()
        {
            if (!Mzibao)
            {
                if (Card.Location == CardLocation.SpellZone && Card.IsFaceup() && !Card.IsDisabled() && !Mzibaoshi)
                {
                    var cards = new List<ClientCard>();
                    foreach (ClientCard card in Bot.GetMonsters())
                    {
                        if (!card.IsCode(CardId.Zmufangshuimu) && !card.IsCode(CardId.Zjiqiangzhishengji))
                        {
                            cards.Add(card);
                        }
                    }
                    foreach (ClientCard card in Bot.GetSpells())
                    {
                        if (card.IsCode(CardId.Mzhibaohuangjincha))
                        {
                            cards.Remove(card.EquipTarget);
                        }
                    }
                    if ((cards.Count == 1 && cards[0].Attack * 2 < Enemy.LifePoints) || cards.Count <= 0) return false;
                    {
                        cards.Sort(CardContainer.CompareDefensePower);
                        cards.Reverse();
                        AI.SelectCard(cards);
                        Mzibaoshi = true;
                        Mzibao = true;
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
        //装甲 东风大汽
        private bool ZdongfengdaqiSummon()
        {
            Zdongfongdaqi = true;
            foreach (ClientCard card in Bot.GetSpells())
            {
                return (card.IsFaceup() && card.HasType(CardType.Spell) && Bot.GetMonstersInMainZone().Count<5);
                
            }
            return false;
        }
        //装甲 炮手侠 效果
        private bool ZpaoshouxiaEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                return Bot.GetMonsters().Count == 1 && Bot.GetCountCardInZone(Bot.Hand, CardType.Monster, 0x7c41) > 1;
            }
            else if (Card.Location == CardLocation.Grave)
            {
                return true;
            }
            return false;
        }
        //装甲 直升机
        private bool ZjiqiangzhishengjiEffect()
        {
            if (Card.Location == CardLocation.Hand) return true;
            else if (Card.Location == CardLocation.MonsterZone || Card.Location == CardLocation.SpellZone)
            {
                if (Duel.Phase == DuelPhase.Main1)
                {
                    int selfBestAttack = Util.GetBestAttack(Bot);
                    int oppoBestAttack = Util.GetBestAttack(Enemy);
                    if (selfBestAttack <= oppoBestAttack)
                    {
                        List<ClientCard> bot_monsters = Bot.GetMonsters();
                        bot_monsters.Sort(CardContainer.CompareCardAttack);
                        bot_monsters.Reverse();
                        AI.SelectCard(bot_monsters);
                        return true;
                    }
                    return false;
                }
                else if (Duel.Phase == DuelPhase.End && Duel.Player==0 && Bot.Hand.Count< Enemy.Hand.Count) return true;
                return false;
            }
            return false;
        }
        //装甲 前线大作战
        private bool MqianxiandazuozhanEffect()
        {
            List<ClientCard> en_monsters = Enemy.GetMonsters();
            en_monsters.Sort(CardContainer.CompareCardAttack);
            AI.SelectCard(en_monsters);
            return true;

        }
        //装甲 模仿水母
        private bool ZmufangshuimuSummon()
        {
            if (Enemy.GetMonsters().Count == 0 && Bot.GetMonsters().Count > 0)
            {
                List<ClientCard> bot_monsters = Bot.GetMonsters();
                bot_monsters.Sort(CardContainer.CompareCardAttack);
                return bot_monsters[0].Attack > 0 || bot_monsters[bot_monsters.Count - 1].Attack * 2 >= Enemy.LifePoints;

            }
            else if (Enemy.GetMonsters().Count > 0)
            {
                List<ClientCard> bot_monsters = Bot.GetMonsters();
                if (bot_monsters != null)
                {
                    bot_monsters.Sort(CardContainer.CompareCardAttack);
                    ClientCard bot_bestmonster = bot_monsters[bot_monsters.Count - 1];
                    List<ClientCard> en_monsters = Enemy.GetMonsters();
                    foreach (ClientCard card in en_monsters)
                    {
                      return card.Attack >= bot_bestmonster.Attack || card.Attack >= Enemy.LifePoints;
                    }
                    return false;
                }
                else
                {
                    List<ClientCard> en_monsters = Enemy.GetMonsters();
                    foreach (ClientCard card in en_monsters)
                    {
                        return card.Attack > 0 ;
                    }
                    return false;
                }
            }
            return false;
        }

    }
}
