using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("Cangqiong", "AI_Cangqiong", "NotFinished")]
    public class CangqiongExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Cshendaozhe = 3000006;
            public const int Yunshi = 27204311;
            public const int Cmoshushi = 3000009;
            public const int Cshidaozhe = 3000005;
            public const int Chui = 3000000;
            public const int Cjidaozhe = 3000004;
            public const int Cousifei = 6000009;
            public const int Cnasi = 6000010;
            public const int Chuozhao = 3000007;
            public const int Cfengyu = 3000008;
            public const int Cyaomu = 3000011;
            public const int Cmobing = 3000015;
            public const int Cchitan = 3000017;
            public const int Cmei = 6000007;
            public const int Cailinna = 6000008;
            public const int Clan = 3000001;
            public const int Cming = 3000002;
            public const int Cyuanlong = 3000003;
            public const int Huiliuli = 14558128;
            public const int G = 23434538;
            public const int Cmingyunzhiyin = 9042001;
            public const int Zhimingzhe = 24224830;
            public const int Cmingyunzhuanlun = 9000000;
            public const int Cmingyunshenguo = 9000003;
            public const int Cxuwulunhui = 6000002;
            public const int Wuxianpaoying = 10045474;
            public const int Czhuanshengzhen = 6000000;
            public const int Clunhuideshenpan = 6000003;
            public const int Cyanshengwu = 3961000;
            public const int Caileiou = 6000030;
            public const int Cshadaolunhui = 6000001;
            public const int Cmingyunciyuan = 9000005;
            //额外
            public const int Cxuefeiya = 6000033;
            public const int Cbingdie = 6000032;
            public const int Cxingyao = 6000006;
            public const int Cshenyou = 6000037;
            public const int Cfeiya = 6000035;
            public const int Cailaer = 6000036;
            public const int Cfeina = 6000031;
            public const int Ctianyou = 6000005;
            public const int Cjiyan = 6000034;
            public const int Cnuyan = 6000004;
            public const int Ctianyi = 6000038;
            public const int Cyinjingongzhu = 24094258;
        }
        List<int> Impermanence_list = new List<int>();
        bool CardOfDemiseUsed = false;
        bool Cmobing = false;
        bool Cchitian = false;
        bool Cbingdie = false;
        bool Chuozhao = false;
        bool Cmingyunshenguo = false;
        bool Cmingyunzhiyin = false;
        bool Cmingyunshenguo2 = false;
        bool Cmingyunshenguofadong = false;
        bool Cmobing2 = false;
        bool Cfeina = false;
        bool Cnasi = false;
        bool Cousifei = false;
        bool Cnuyan = false;
        bool Cnuyan2 = false;
        //选择
        List<int> Cost_select = new List<int>
        {
           3000000,3000001,3000002,3000003,3000007,3000008,3000009,3000011,3000015,3000017,6000007,6000008,6000009,6000010,6000004
        };
        List<int> Cost_select2 = new List<int>
        {
           3000015,3000000,3000001,3000002,3000003,3000007,3000008,3000009,3000011,3000017,6000007,6000008,6000009,6000010,6000004
        };
        List<int> Cost_select3 = new List<int>
        {
          3000017, 3000015,3000000,3000001,3000002,3000003,3000007,3000008,3000009,3000011,6000007,6000008,6000009,6000010,6000004
        };
        List<int> A_select = new List<int>
        {
           CardId.Cmei, CardId.Cbingdie, CardId.Cnuyan, CardId.Cfeina, CardId.Cfeiya, CardId.Cxuefeiya, CardId.Cnasi, CardId.Chuozhao
        };
        public CangqiongExecutor(GameAI ai, Duel duel)
         : base(ai, duel)
        {
            //苍穹 辉
            AddExecutor(ExecutorType.SpSummon, CardId.Chui);
            //苍穹  天翼
            AddExecutor(ExecutorType.Activate, CardId.Ctianyi);
            //苍穹  神佑
            AddExecutor(ExecutorType.Activate, CardId.Cshenyou, CshenyouEffect);
            //苍穹 艾雷欧
            AddExecutor(ExecutorType.Activate, CardId.Caileiou, CaileiouEffect);
            //苍穹  轮回的神判
            AddExecutor(ExecutorType.Activate, CardId.Clunhuideshenpan);
            //苍穹 星耀
            AddExecutor(ExecutorType.Activate, CardId.Cxingyao);
            //苍穹 冰蝶
            AddExecutor(ExecutorType.Activate, CardId.Cbingdie);
            //苍穹 菲娜
            AddExecutor(ExecutorType.Activate, CardId.Cfeina, CfeinaEffect);
            //苍穹 怒焰
            AddExecutor(ExecutorType.Activate, CardId.Cnuyan);
            //苍穹  辉
            AddExecutor(ExecutorType.Activate, CardId.Chui, ChuiEffect);
            //苍穹  虚无轮回
            AddExecutor(ExecutorType.Activate, CardId.Cxuwulunhui, CxuwulunhuiEffect);
            //苍穹  极道者
            AddExecutor(ExecutorType.Activate, CardId.Cjidaozhe, CjidaozheEffect);
            //苍穹  冥
            AddExecutor(ExecutorType.Activate, CardId.Cming, CmingEffect);
            //苍穹  元龙
            AddExecutor(ExecutorType.Activate, CardId.Cyuanlong, CmingEffect);
            //苍穹  兰
            AddExecutor(ExecutorType.Activate, CardId.Clan, ClanEffect);
            //苍穹 魔术师
            AddExecutor(ExecutorType.Activate, CardId.Cmoshushi, CmoshushiEffect);
            //苍穹 纳斯
            AddExecutor(ExecutorType.Activate, CardId.Cnasi, CnasiEffect);
            //苍穹 神道者
            AddExecutor(ExecutorType.Activate, CardId.Cshendaozhe, CshendaozheEffect);
            //苍穹 始道者
            AddExecutor(ExecutorType.Activate, CardId.Cshidaozhe, CshidaozheEffect);
            //苍穹 命运指引
            AddExecutor(ExecutorType.Activate, CardId.Cmingyunzhiyin, CmingyunzhiyinEffect);
            //苍穹 发动命运转轮
            AddExecutor(ExecutorType.Activate, CardId.Cmingyunzhuanlun, CmingyunzhuanlunEffect2);
            //苍穹 命运转轮
            AddExecutor(ExecutorType.Activate, CardId.Cmingyunzhuanlun, CmingyunzhuanlunEffect);
            //苍穹 发动命运次元
            AddExecutor(ExecutorType.Activate, CardId.Cmingyunciyuan, CmingyunzhuanlunEffect2);
            //苍穹 命运次元
            AddExecutor(ExecutorType.Activate, CardId.Cmingyunciyuan, CmingyunciyuanEffect);
            //苍穹 杀道轮回
            AddExecutor(ExecutorType.Activate, CardId.Cshadaolunhui, CshadaolunhuiEffect);
            //苍穹 转生阵
            AddExecutor(ExecutorType.Activate, CardId.Czhuanshengzhen);
            //苍穹 P魔冰
            AddExecutor(ExecutorType.Activate, CardId.Cmobing, CmobingEffect);
            //苍穹 魔冰
            AddExecutor(ExecutorType.Activate, CardId.Cmobing, CmobingEffect2);
            //苍穹 火召
            AddExecutor(ExecutorType.Activate, CardId.Chuozhao, ChuozhaoEffect);
            //苍穹 赤天
            AddExecutor(ExecutorType.Summon, CardId.Cchitan, CchitanSummon);
            //苍穹 命运神国
            AddExecutor(ExecutorType.Activate, CardId.Cmingyunshenguo, CmingyunshenguoEffect);
            //苍穹 发动命运神国
            AddExecutor(ExecutorType.Activate, CardId.Cmingyunshenguo, CmingyunshenguoEffect2);
            //苍穹 P赤天
            AddExecutor(ExecutorType.Activate, CardId.Cchitan, CchitanEffect2);
            //苍穹 赤天
            AddExecutor(ExecutorType.Activate, CardId.Cchitan, CchitanEffect);
            //苍穹 P火召
            AddExecutor(ExecutorType.Activate, CardId.Chuozhao, ChuozhaoEffect2);
            //苍穹 P妖木
            AddExecutor(ExecutorType.Activate, CardId.Cyaomu, CyaomuEffect2);
            //苍穹 妖木
            AddExecutor(ExecutorType.Activate, CardId.Cyaomu, CyaomuEffect);
            //苍穹 P风御
            AddExecutor(ExecutorType.Activate, CardId.Cfengyu, CfengyuEffect2);
            //苍穹 菲亚
            AddExecutor(ExecutorType.SpSummon, CardId.Cfeiya, CfeiyaSummon);
            //苍穹 菲娜
            AddExecutor(ExecutorType.SpSummon, CardId.Cfeina, CfeinaSummon);
            //苍穹 神佑
            AddExecutor(ExecutorType.SpSummon, CardId.Cshenyou, CshenyouSummon);
            //苍穹 梅
            AddExecutor(ExecutorType.Activate, CardId.Cmei, CmeiEffect);
            //苍穹 欧丝菲
            AddExecutor(ExecutorType.Activate, CardId.Cousifei, CousifeiEffect);
            //苍穹 冰蝶
            AddExecutor(ExecutorType.SpSummon, CardId.Cbingdie, CbingdieSummon);
            //苍穹 星耀
            AddExecutor(ExecutorType.SpSummon, CardId.Cxingyao, CxingyaoSummon);
            //苍穹 雪菲亚
            AddExecutor(ExecutorType.SpSummon, CardId.Cxuefeiya, CxuefeiyaSummon);
            //苍穹 雪菲亚
            AddExecutor(ExecutorType.Activate, CardId.Cxuefeiya, CxuefeiyaEffect);
            //苍穹 天翼
            AddExecutor(ExecutorType.SpSummon, CardId.Ctianyi, CtianyiSummon);
            //苍穹 怒焰
            AddExecutor(ExecutorType.SpSummon, CardId.Cnuyan, CnuyanSummon);
            //苍穹 菲亚
            AddExecutor(ExecutorType.Activate, CardId.Cfeiya, CfeiyaEffect);
            //苍穹 风御
            AddExecutor(ExecutorType.Activate, CardId.Cfengyu, CfengyuEffect);
            //苍穹 急焰
            AddExecutor(ExecutorType.SpSummon, CardId.Cjiyan, CjiyanSummon);
            //苍穹 急焰
            AddExecutor(ExecutorType.Activate, CardId.Cjiyan, CjiyanEffect);
            //苍穹 艾雷欧
            AddExecutor(ExecutorType.SpSummon, CardId.Caileiou, CaileiouSummon);

            //P召唤
            AddExecutor(ExecutorType.SpSummon, CardId.Cfengyu, Psummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Cyaomu, Psummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Cmobing, Psummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Chuozhao, Psummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Cchitan, Psummon);

            //苍穹 天佑
            AddExecutor(ExecutorType.SpSummon, CardId.Ctianyou);
            //苍穹 天佑
            AddExecutor(ExecutorType.Activate, CardId.Ctianyou);
            //苍穹 爱拉尔
            AddExecutor(ExecutorType.SpSummon, CardId.Cailaer);
            //苍穹 爱拉尔
            AddExecutor(ExecutorType.Activate, CardId.Cailaer);

            AddExecutor(ExecutorType.SpellSet, DefaultSpellSetEffect);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
        }
        //计数专用
        public override void OnNewTurn()
        {
            // reset
            CardOfDemiseUsed = false;
            Cmobing = false;
            Cchitian = false;
            Cbingdie = false;
            Chuozhao = false;
            Cmingyunshenguo = false;
            Cmingyunzhiyin = false;
            Cmingyunshenguo2 = false;
            Cmingyunshenguofadong = false;
            Cmobing2 = false;
            Cfeina = false;
            Cnasi = false;
            Cousifei = false;
            Cnuyan = false;
            Cnuyan2 = false;
        }
        //卡组检查
        public int CheckRemainInDeck(int id)
        {
            switch (id)
            {
                case CardId.Cshendaozhe:
                    return Bot.GetRemainingCount(CardId.Cshendaozhe, 2);
                case CardId.Cmoshushi:
                    return Bot.GetRemainingCount(CardId.Cmoshushi, 1);
                case CardId.Cshidaozhe:
                    return Bot.GetRemainingCount(CardId.Cshidaozhe, 1);
                case CardId.Chui:
                    return Bot.GetRemainingCount(CardId.Chui, 2);
                case CardId.Cjidaozhe:
                    return Bot.GetRemainingCount(CardId.Cjidaozhe, 1);
                case CardId.Cousifei:
                    return Bot.GetRemainingCount(CardId.Cousifei, 1);
                case CardId.Cnasi:
                    return Bot.GetRemainingCount(CardId.Cnasi, 1);
                case CardId.Chuozhao:
                    return Bot.GetRemainingCount(CardId.Chuozhao, 3);
                case CardId.Cfengyu:
                    return Bot.GetRemainingCount(CardId.Cfengyu, 2);
                case CardId.Cyaomu:
                    return Bot.GetRemainingCount(CardId.Cyaomu, 3);
                case CardId.Cmobing:
                    return Bot.GetRemainingCount(CardId.Cmobing, 3);
                case CardId.Cchitan:
                    return Bot.GetRemainingCount(CardId.Cchitan, 2);
                case CardId.Cmei:
                    return Bot.GetRemainingCount(CardId.Cmei, 1);
                case CardId.Cailinna:
                    return Bot.GetRemainingCount(CardId.Cailinna, 1);
                case CardId.Clan:
                    return Bot.GetRemainingCount(CardId.Clan, 1);
                case CardId.Cming:
                    return Bot.GetRemainingCount(CardId.Cming, 2);
                case CardId.Cyuanlong:
                    return Bot.GetRemainingCount(CardId.Cyuanlong, 3);
                case CardId.Cmingyunzhiyin:
                    return Bot.GetRemainingCount(CardId.Cmingyunzhiyin, 2);
                case CardId.Cmingyunzhuanlun:
                    return Bot.GetRemainingCount(CardId.Cmingyunzhuanlun, 1);
                case CardId.Cmingyunshenguo:
                    return Bot.GetRemainingCount(CardId.Cmingyunshenguo, 2);
                case CardId.Cxuwulunhui:
                    return Bot.GetRemainingCount(CardId.Cxuwulunhui, 1);
                case CardId.Czhuanshengzhen:
                    return Bot.GetRemainingCount(CardId.Czhuanshengzhen, 1);
                case CardId.Cshadaolunhui:
                    return Bot.GetRemainingCount(CardId.Cshadaolunhui, 1);
                case CardId.Clunhuideshenpan:
                    return Bot.GetRemainingCount(CardId.Clunhuideshenpan, 2);
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
        private bool DefaultSpellSetEffect()
        {
              return (Card.IsTrap() || Card.HasType(CardType.QuickPlay)) && Bot.GetSpellCountWithoutField() <= 4;
        }
        //灵摆召唤
        private bool ScaleActivate()
        {
          /*  if (!Card.HasType(CardType.Pendulum) || Card.Location != CardLocation.Hand)
                return false;
                */
            int count = 0;
            foreach (ClientCard card in Bot.Hand.GetMonsters())
            {
                if (!Card.Equals(card))
                    count++;
            }
            foreach (ClientCard card in Bot.ExtraDeck.GetFaceupPendulumMonsters())
            {
                count++;
            }
            ClientCard l = Util.GetPZone(0, 0);
            ClientCard r = Util.GetPZone(0, 1);
            if (l == null && r == null)
            {
                if (CardOfDemiseUsed)
                    return true;
                bool pair = false;
                foreach (ClientCard card in Bot.Hand.GetMonsters())
                {
                    if (card.RScale != Card.LScale)
                    {
                        pair = true;
                        count--;
                        break;
                    }
                }
                return pair && count > 1;
            }
            if (l == null && r.RScale != Card.LScale)
                return count > 1 || CardOfDemiseUsed;
            if (r == null && l.LScale != Card.RScale)
                return count > 1 || CardOfDemiseUsed;
            return false;
        }
        //检测灵摆召唤
        private bool ShouldPendulum()
        {
            ClientCard l = Util.GetPZone(0, 0);
            ClientCard r = Util.GetPZone(0, 1);
            if (l != null && r != null && l.LScale != r.RScale)
            {
                int count = 0;
                foreach (ClientCard card in Bot.Hand.GetMonsters())
                {
                    count++;
                }
                foreach (ClientCard card in Bot.ExtraDeck.GetFaceupPendulumMonsters())
                {
                    count++;
                }
                return count > 1;
            }
            return false;
        }
        //苍穹 命运次元
        private bool CmingyunciyuanEffect()
        {
            return true;
        }
        //苍穹 菲娜
        private bool CfeinaEffect()
        {
            ClientCard LastChainCard = base.Util.GetLastChainCard();
            bool flag = LastChainCard != null && LastChainCard.Location == CardLocation.MonsterZone && !LastChainCard.IsDisabled();
            bool result;
            if (flag)
            {
                base.AI.SelectCard(CardId.Cmei);
                base.AI.SelectNextCard(LastChainCard);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;

        }
        //苍穹 神佑
        private bool CshenyouEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (Bot.GetMonsterCount()> Enemy.GetMonsterCount() && Enemy.GetMonsterCount()<=2) return false;
                return true;
            }
            else if (Card.Location == CardLocation.Grave) return true;
            return false;
        }
        //苍穹 兰
        private bool ClanEffect()
        {
            return Duel.LastChainPlayer == 1;
        }
        //苍穹 极道者
        private bool CjidaozheEffect()
        {
            if (Card.Location == CardLocation.Hand) return false;
            return true;
        }
        //苍穹 艾雷欧
        private bool CaileiouEffect()
        {
            if (Duel.CurrentChain.Count > 0)
            {
                return Duel.LastChainPlayer == 1;
            }
            return false;
        }
        //苍穹 冥
        private bool CmingEffect()
        {
            return Duel.LastChainPlayer == 1;
        }
        //苍穹 雪菲亚
        private bool CxuefeiyaEffect()
        {
            if (Duel.CurrentChain.Count > 0)
            {
                return Duel.LastChainPlayer == 1;
            }
            return false;
        }
        //苍穹 辉
        private bool ChuiEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                AI.SelectCard(CardId.Cshendaozhe);
                return true;
            }
            else return true;
        }
        //苍穹 虚无轮回
        private bool CxuwulunhuiEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                if (Bot.HasInGraveyard(CardId.Cshendaozhe)) return true;
                return false;
            }
            else if (Card.Location == CardLocation.SpellZone) return true;
            return false;
        }
        //苍穹 魔术师
        private bool CmoshushiEffect()
        {
            if (Card.Location == CardLocation.Grave || Card.Location == CardLocation.Hand)
            {
                if (ActivateDescription == Util.GetStringId(CardId.Cmoshushi, 0))
                {
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                else if(ActivateDescription == Util.GetStringId(CardId.Cmoshushi, 3))
                {
                    return true;
                }
                return false;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Cmoshushi, 1))
            {
                AI.SelectCard(CardId.Cmingyunciyuan, CardId.Cmingyunzhuanlun, CardId.Cshadaolunhui, CardId.Clunhuideshenpan, CardId.Cmingyunzhiyin);
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Cmoshushi, 2))
            {
                if (Duel.CurrentChain.Count > 0)
                {
                    return Duel.LastChainPlayer == 1;
                }
                return false;
            }
            return false;
        }
        //苍穹 赤天
        private bool CchitanSummon()
        {
            if (Cmobing && !Bot.HasInHandOrInSpellZone(CardId.Cmingyunshenguo) && !Cchitian) return true;
            else if (!Cchitian && !Cmobing) return true;
            return false;
        }
        //苍穹 始道者
        private bool CshidaozheEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.HasInGraveyard(CardId.Cshendaozhe)) return true;
                return false;
            }
            else if (Card.Location == CardLocation.MonsterZone)
            {
                return Duel.LastChainPlayer == 1;
            }
            return false;
        }
        //苍穹 杀道轮回
        private bool CshadaolunhuiEffect()
        {
            ClientCard target = Util.GetBestEnemyCard();
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.Cmingyunciyuan, CardId.Cmingyunzhuanlun, CardId.Clunhuideshenpan);
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Cshadaolunhui, 1))
            {
                foreach (ClientCard card in Bot.GetSpells())
                    if (card != null)
                    {
                        AI.SelectCard(card);
                        AI.SelectNextCard(target);
                        AI.SelectThirdCard(target);
                        return true;
                    }
                return false;
            }
            else if (Card.Location == CardLocation.SpellZone)
            {
                return true;
            }
            return false;
        }
        //苍穹 艾雷欧
        private bool CaileiouSummon()
        {
            if (!Bot.HasInMonstersZoneOrInGraveyard(A_select) || (!Cnuyan2)) return false;
            AI.SelectCard(CardId.Cmei, CardId.Cbingdie, CardId.Cnuyan, CardId.Cfeina, CardId.Cfeiya, CardId.Cxuefeiya, CardId.Cnasi, CardId.Chuozhao,CardId.Cyaomu,CardId.Cchitan);
            AI.SelectNextCard(CardId.Cmei, CardId.Cbingdie, CardId.Cnuyan, CardId.Cfeina, CardId.Cfeiya, CardId.Cxuefeiya, CardId.Cnasi, CardId.Chuozhao, CardId.Cyaomu, CardId.Cchitan);
            AI.SelectThirdCard(CardId.Cmei, CardId.Cbingdie, CardId.Cnuyan, CardId.Cfeina, CardId.Cfeiya, CardId.Cxuefeiya, CardId.Cnasi, CardId.Chuozhao, CardId.Cyaomu, CardId.Cchitan);
            AI.SelectFourthCard(CardId.Cmei, CardId.Cbingdie, CardId.Cnuyan, CardId.Cfeina, CardId.Cfeiya, CardId.Cxuefeiya, CardId.Cnasi, CardId.Chuozhao, CardId.Cyaomu, CardId.Cchitan);
            return true;
        }
        //p召唤
        private bool Psummon()
        {
            AI.SelectCard(CardId.Cyaomu, CardId.Cfengyu, CardId.Chuozhao, CardId.Cchitan, CardId.Cmobing);
            AI.SelectNextCard(CardId.Cyaomu, CardId.Cfengyu, CardId.Chuozhao, CardId.Cchitan, CardId.Cmobing);
            AI.SelectThirdCard(CardId.Cyaomu, CardId.Cfengyu, CardId.Chuozhao, CardId.Cchitan, CardId.Cmobing);
            return true;
        }
        //苍穹 命运转轮
        private bool CmingyunzhuanlunEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Cmingyunzhuanlun, 2))
            {
                if (CheckRemainInDeck(CardId.Cousifei) > 0 && !Cousifei)
                {
                    AI.SelectCard(CardId.Cousifei, CardId.Cshadaolunhui, CardId.Clunhuideshenpan, CardId.Cmoshushi);
                    return true;
                }
                else if (CheckRemainInDeck(CardId.Cmingyunciyuan) > 0)
                {
                    AI.SelectCard(CardId.Cmingyunciyuan, CardId.Cshendaozhe, CardId.Cshadaolunhui, CardId.Clunhuideshenpan, CardId.Cmoshushi);
                    return true;
                }
                else if (CheckRemainInDeck(CardId.Cshendaozhe) > 1)
                {
                    AI.SelectCard(CardId.Cshendaozhe, CardId.Cshadaolunhui, CardId.Clunhuideshenpan, CardId.Cmoshushi);
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Cshadaolunhui, CardId.Clunhuideshenpan, CardId.Cmoshushi);
                    return true;
                }
            }
             return false;
            

        }
        //苍穹 P赤天
        private bool CchitanEffect2()
        {
            if (Card.Location != CardLocation.Removed) return false;
             return true;
        }
        //苍穹 神道者
        private bool CshendaozheEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.LifePoints <= 500) return false;
                {
                    if (!Bot.HasInHandOrInSpellZone(CardId.Cmobing) && !Cmobing && CheckRemainInDeck(CardId.Cmobing) > 0)
                    {
                        AI.SelectCard(CardId.Cmobing);
                        return true;
                    }
                    else if (CheckRemainInDeck(CardId.Cousifei) > 0 && !Cousifei)
                    {
                        AI.SelectCard(CardId.Cousifei);
                        return true;
                    }
                    else if (Bot.HasInHandOrInSpellZone(CardId.Cmobing) || Cmobing)
                    {
                        AI.SelectCard(CardId.Cmingyunzhuanlun,CardId.Cmingyunciyuan,CardId.Cmobing,CardId.Cchitan,CardId.Chuozhao);
                        return true;
                    }
                    return false;

                }
            }
            return false;
        }
        private bool DefaultPendulumZone()
        {
            return Bot.SpellZone[0] == null || Bot.SpellZone[4] == null;
        }
        //苍穹 P魔冰
        private bool CmobingEffect()
        {
         if (Card.Location == CardLocation.Hand && !Bot.HasInSpellZone(CardId.Cmobing) &&!Cmobing)
                return DefaultPendulumZone();
            return false;
        }
        //苍穹 P妖木
        private bool CyaomuEffect2()
        {
            if (Card.Location == CardLocation.Hand && !Bot.HasInSpellZone(CardId.Cyaomu))
                return DefaultPendulumZone();
            return false;
        }
        //苍穹 P风御
        private bool CfengyuEffect2()
        {
            if (Card.Location == CardLocation.Hand && !Bot.HasInSpellZone(CardId.Cfengyu))
                return DefaultPendulumZone();
            return false;
        }
        private bool DefaultSpellZone()
        {
            return Bot.SpellZone[0] == null || Bot.SpellZone[1] == null || Bot.SpellZone[2] == null || Bot.SpellZone[3] == null || Bot.SpellZone[4] == null;
        }
        //苍穹 发动命运转轮
        private bool CmingyunzhuanlunEffect2()
        {
            if (Card.Location == CardLocation.Hand)
                return DefaultSpellZone();
            return false;
        }
        //苍穹 命运神国
        private bool CmingyunshenguoEffect2()
        {
            foreach (ClientCard card in Bot.GetSpells())
                if (Card.Location == CardLocation.Hand)
                {
                    if (!Cmingyunshenguofadong)
                    {
                        Cmingyunshenguofadong = true;
                        return true;
                    }
                    else if (Bot.HasInSpellZone(CardId.Cmobing) && !Cmobing2)
                    {
                        Cmingyunshenguofadong = true;
                        return true;
                    }
                    else if (Cmingyunshenguofadong && !Bot.HasInSpellZone(CardId.Cmobing)) return false;
                    return false;
                }
                else if (card != null && card.Location == CardLocation.FieldZone && card.IsCode(CardId.Cmingyunshenguo) && card.IsFacedown())
                {
                    Cmingyunshenguofadong = true;
                    return true;
                }
            return false;
        }
        //苍穹 P火召
        private bool ChuozhaoEffect2()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (!Bot.HasInSpellZone(CardId.Chuozhao) && !Chuozhao)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        //苍穹 菲亚
        private bool CfeiyaEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.Czhuanshengzhen, CardId.Cmingyunciyuan, CardId.Cshadaolunhui, CardId.Clunhuideshenpan);
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Cfeiya, 0)) return true;
            else if (ActivateDescription == Util.GetStringId(CardId.Cfeiya, 1))
            {
                return Duel.LastChainPlayer == 1;
            }
            return false;
        }
        //苍穹 火召
        private bool ChuozhaoEffect()
        {
            if (Card.Location == CardLocation.SpellZone)
            {
                if (!Cmobing && CheckRemainInDeck(CardId.Cmobing) > 0)
                {
                    AI.SelectCard(CardId.Cmobing);
                    AI.SelectOption(0);
                    Chuozhao = true;
                    return true;
                }
                else if (!Cchitian && CheckRemainInDeck(CardId.Cchitan) > 0)
                {
                    AI.SelectCard(CardId.Cchitan);
                    AI.SelectOption(1);
                    AI.SelectPosition(CardPosition.FaceUpDefence);
                    Chuozhao = true;
                    return true;

                }
                else
                {
                    AI.SelectCard(CardId.Cfengyu);
                    AI.SelectOption(1);
                    AI.SelectPosition(CardPosition.FaceUpDefence);
                    Chuozhao = true;
                    return true;
                }

            }
            else if (Card.Location == CardLocation.MonsterZone)
            {
                if (Card.IsDisabled()) return false;
                {
                    AI.SelectCard(CardId.Cmobing);
                    AI.SelectPosition(CardPosition.FaceUpDefence);
                    return true;
                }
            }
            return false;

        }
        //苍穹 风御
        private bool CfengyuEffect()
        {
            if (Card.Location == CardLocation.SpellZone)
            {
                AI.SelectCard(CardId.Cmobing);
                return true;
            }
            return false;
        }
        //苍穹 命运指引
        private bool CmingyunzhiyinEffect()
        {
            if (Card.Location != CardLocation.Grave)
            {
                AI.SelectCard(CardId.Cousifei, CardId.Cxuwulunhui,CardId.Cshidaozhe, CardId.Chuozhao,CardId.Clunhuideshenpan,CardId.Cmei, CardId.Chui, CardId.Cchitan);
                if (Cmobing)
                {
                    if (Bot.HasInHandOrInSpellZone(CardId.Cfengyu))
                    {
                        if (!Bot.HasInHandOrInSpellZone(CardId.Cyaomu))
                        {
                            if (CheckRemainInDeck(CardId.Cousifei) > 0 && !Cousifei && !Bot.HasInHandOrInGraveyard(CardId.Cousifei))
                            {
                                AI.SelectNextCard(CardId.Cousifei, CardId.Cshendaozhe);
                            }
                            else
                            {
                                AI.SelectNextCard(CardId.Cshendaozhe);
                            }
                            AI.SelectThirdCard(CardId.Cyaomu);
                            Cmingyunzhiyin = true;
                            return true;
                        }
                        
                        else
                        {
                            AI.SelectNextCard(CardId.Cshendaozhe);
                            if (CheckRemainInDeck(CardId.Cousifei) > 0 && !Cousifei && !Bot.HasInHandOrInGraveyard(CardId.Cousifei))
                            {
                                AI.SelectThirdCard(CardId.Cousifei, CardId.Cmobing);
                            }
                            else
                            {
                                AI.SelectThirdCard(CardId.Cmobing);
                            }
                            Cmingyunzhiyin = true;
                            return true;
                        }
                    }
                    else
                    {
                        if (!Bot.HasInHandOrInSpellZone(CardId.Cyaomu))
                        {
                            AI.SelectNextCard(CardId.Cfengyu);
                            AI.SelectThirdCard(CardId.Cyaomu);
                            Cmingyunzhiyin = true;
                            return true;
                        }
                        else
                        {
                            AI.SelectNextCard(CardId.Cfengyu);
                            if (CheckRemainInDeck(CardId.Cousifei) > 0 && !Cousifei && !Bot.HasInHandOrInGraveyard(CardId.Cousifei))
                            {
                                AI.SelectThirdCard(CardId.Cousifei, CardId.Cmobing);
                            }
                            else
                            {
                                AI.SelectThirdCard(CardId.Cmobing);
                            }
                            Cmingyunzhiyin = true;
                            return true;
                        }
                    }
                }
                else if (!Cmobing)
                {
                    AI.SelectNextCard(CardId.Cmobing);
                    AI.SelectThirdCard(CardId.Cshendaozhe);
                    Cmingyunzhiyin = true;
                    return true;
                }
                return false;
            }
            else
            {
                if (Bot.HasInBanished(CardId.Cxuefeiya) || Bot.HasInBanished(CardId.Cbingdie) || Bot.HasInBanished(CardId.Cousifei))
                {
                    AI.SelectCard(CardId.Cbingdie, CardId.Cxuefeiya, CardId.Cousifei);
                    return true;
                }
                return false;
            }
        }
        //苍穹 神佑
        private bool CshenyouSummon()
        {
            AI.SelectMaterials(new List<int>() {
                CardId.Cfeina,
                CardId.Cfeiya
            });
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //苍穹 急焰
        private bool CjiyanSummon()
        {
            if (Bot.GetCountCardInZone(Bot.MonsterZone, CardId.Cnuyan)<=1) return false;
            AI.SelectPosition(CardPosition.FaceUpAttack);
            AI.SelectPlace(Zones.z5 | Zones.z6);
            AI.SelectMaterials(new List<int>() {
                CardId.Cnuyan,
                CardId.Cnuyan
            });
            AI.SelectPlace(Zones.z5 | Zones.z6);
            AI.SelectOption(1);
            AI.SelectPlace(Zones.z5 | Zones.z6);
            return true;

        }
        //苍穹 急焰
        private bool CjiyanEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Cjiyan, 3))
            {
                AI.SelectCard(CardId.Cnuyan, CardId.Cnuyan);
                AI.SelectNextCard(CardId.Cshendaozhe, CardId.Cshidaozhe, CardId.Cjidaozhe);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Cjiyan, 1))
            {
                return true;
            }
            return false;
        }
        //苍穹 怒焰
        private bool CnuyanSummon()
        {
            if (!Cnuyan)
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                AI.SelectMaterials(new List<int>() {
                CardId.Chuozhao,
                CardId.Cmobing,
                CardId.Cfengyu
            });
                Cnuyan = true;
                return true;
            }
            else
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                AI.SelectMaterials(new List<int>() {
                CardId.Chuozhao,
                CardId.Cmobing,
                CardId.Cfengyu
            });
                Cnuyan2 = true;
                return true;
            }
        }
        //苍穹 雪菲亚
        private bool CxuefeiyaSummon()
        {
           foreach (ClientCard card in Bot.GetGraveyardMonsters())
            AI.SelectCard(CardId.Cbingdie, CardId.Cousifei);
            AI.SelectMaterials(new List<int>() {
                CardId.Cbingdie,
                CardId.Cousifei
            });
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;

        }
        //苍穹 妖木
        private bool CyaomuEffect()
        {
            if (Card.Location != CardLocation.Hand)
            {
                if (Card.Location == CardLocation.SpellZone)
                {
                    if (!Cmobing && CheckRemainInDeck(CardId.Cmobing) > 0)
                    {
                        AI.SelectCard(CardId.Cmobing);
                    }
                    else if (!Chuozhao && !Bot.HasInMonstersZone(CardId.Chuozhao))
                    {
                        AI.SelectCard(CardId.Chuozhao);
                    }
                    else if (!Cnasi)
                    {
                        AI.SelectCard(CardId.Cnasi, CardId.Cshendaozhe, CardId.Cousifei, CardId.Cmoshushi);
                    }
                    else if (CheckRemainInDeck(CardId.Cshendaozhe) > 1)
                    {
                        AI.SelectCard(CardId.Cshendaozhe);
                    }
                    else
                    {
                        AI.SelectCard(CardId.Cousifei, CardId.Cmoshushi);
                    }
                    return true;
                }
                else if (Card.Location != CardLocation.SpellZone)
                {
                    return false;
                }
                return false;
            }
            return false;
        }
        //苍穹 欧丝菲
        private bool CousifeiEffect()
        {
            AI.SelectCard(CardId.Cyuanlong,CardId.Cshidaozhe,CardId.Cchitan,CardId.Cjidaozhe,CardId.Clan, CardId.Cming, CardId.Cmoshushi);
            AI.SelectPosition(CardPosition.FaceUpDefence);
            Cousifei = true;
            return true;
        }
        //苍穹 赤天
        private bool CchitanEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (Cmobing)
                {
                    if (CheckRemainInDeck(CardId.Cnasi) > 0)
                    {
                        AI.SelectCard(CardId.Cnasi);
                    }
                    else if (CheckRemainInDeck(CardId.Cshendaozhe) > 1)
                    {
                        AI.SelectCard(CardId.Cshendaozhe);
                    }
                    else
                    {
                        AI.SelectCard(CardId.Cousifei,CardId.Cmoshushi);
                    }
                    Cchitian = true;
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Cmobing);
                }
                Cchitian = true;
                return true;
            }
            return false;
        }
        //苍穹 梅
        private bool CmeiEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Cmei, 0))
            {
                AI.SelectCard(CardId.Cshendaozhe);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Cmei, 1)) return true;
            return false;
        }
        //苍穹 冰蝶
        private bool CbingdieSummon()
        {
            if (Bot.GetMonsterCount() <= 3 && !Bot.HasInMonstersZone(CardId.Cousifei)) return false;
            if (Cbingdie) return false;
            AI.SelectMaterials(new List<int>() {
                CardId.Cousifei,
                CardId.Cyanshengwu,
                CardId.Cming,
                CardId.Clan,
                CardId.Cyuanlong,
                CardId.Chuozhao,
                CardId.Cmobing,
                CardId.Cfengyu,
                CardId.Cyaomu,
                3000002,3000003,3000007,3000008,3000009,3000011,3000015,3000017,6000007,6000008,6000009,6000010,6000004

            });
            AI.SelectPosition(CardPosition.FaceUpAttack);
            Cbingdie = true;
            return true;
        }
        //苍穹 星耀
        private bool CxingyaoSummon()
        {
            if (!Cbingdie) return false;
            AI.SelectMaterials(new List<int>() {
                CardId.Cbingdie,
                CardId.Cfengyu,
                CardId.Cchitan,
                CardId.Cmobing,
                CardId.Cyaomu,
                CardId.Cming,
                CardId.Clan,
                CardId.Cyuanlong,
                CardId.Cailinna,
                CardId.Cmoshushi,
                CardId.Chui,
                CardId.Cmei,
                CardId.Chuozhao,
                CardId.Cchitan,
                CardId.Cmobing
            });
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //苍穹 天翼
        private bool CtianyiSummon()
        {
            if ((Bot.HasInMonstersZone(CardId.Cbingdie) || Bot.HasInMonstersZone(CardId.Cxingyao) )  && Bot.HasInMonstersZone(CardId.Cxuefeiya))
            {
                AI.SelectMaterials(new List<int>() {
                CardId.Cbingdie,
                CardId.Cxuefeiya,
            });
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }
        //苍穹 菲亚
        private bool CfeiyaSummon()
        {
            AI.SelectPosition(CardPosition.FaceUpAttack);
            AI.SelectMaterials(new List<int>() {
                CardId.Cnasi,
                CardId.Cyanshengwu
            });
            return true;
        }
        //苍穹 菲娜
        private bool CfeinaSummon()
        {
            if (!Cfeina)
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                AI.SelectMaterials(new List<int>() {
                CardId.Cmei,
                CardId.Cyanshengwu
            });
                Cfeina = true;
                return true;
            }
            return false;
        }

        
        //苍穹 纳斯
        private bool CnasiEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Cnasi, 0))
            {   if (CheckRemainInDeck(CardId.Cmei) > 0)
                {
                    AI.SelectCard(CardId.Cmei);
                    Cnasi = true;
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Cousifei,CardId.Cxuwulunhui);
                    Cnasi = true;
                    return true;
                }
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Cnasi, 1))
            {
                int a = 0;
                if (Bot.GetMonsterCount() == 2 && Bot.HasInMonstersZone(CardId.Cmei) && Bot.HasInMonstersZone(CardId.Cyanshengwu)) return false;
                else if (Bot.GetMonsterCount() == 1) return false;
                do
                {
                    if (a == 0)
                    {
                        if (Bot.GetMonsters().Count >=4 || !Bot.HasInMonstersZone(Cost_select)) return false;
                        AI.SelectCard(Cost_select3);
                        AI.SelectPosition(CardPosition.FaceUpDefence);
                        a++;
                        return true;
                    }
                    else if (a == 1)
                    { 
                        return true;
                    }
                }
                while (a >= 2); return false;
            }
            return false;
        }
        //苍穹 魔冰
        private bool CmobingEffect2()
        {
            if (Card.Location != CardLocation.Hand)
            {
                if (ActivateDescription == Util.GetStringId(CardId.Cmobing, 0))
                {
                    if (!Bot.HasInHandOrInSpellZone(CardId.Cmingyunshenguo) && !Cmingyunshenguo)
                    {
                        AI.SelectCard(CardId.Cmingyunshenguo,CardId.Cmingyunciyuan,  CardId.Cmingyunzhuanlun, CardId.Cshadaolunhui, CardId.Clunhuideshenpan);
                    }
                    else if (Bot.HasInHandOrInSpellZone(CardId.Cmingyunshenguo) && Cmingyunshenguo && !Cmobing2)
                    {
                        AI.SelectCard(CardId.Cmingyunshenguo, CardId.Cmingyunciyuan, CardId.Cmingyunzhuanlun, CardId.Cshadaolunhui, CardId.Clunhuideshenpan);
                    }
                    else
                    {
                        AI.SelectCard(CardId.Cmingyunciyuan, CardId.Cmingyunzhuanlun, CardId.Cshadaolunhui, CardId.Clunhuideshenpan);
                    }
                    Cmobing = true;
                    return true;
                }
                else
                {
                    int a = 0;
                    do
                    {
                        if (a == 0)
                        {
                            if (!Cchitian)
                            {
                                AI.SelectCard(CardId.Cchitan, CardId.Chuozhao);
                            }
                            else
                            {
                                AI.SelectCard(CardId.Chuozhao);
                            }
                            AI.SelectPosition(CardPosition.FaceUpDefence);
                            a++;
                            Cmobing2 = true;
                            return true;
                        }
                        else if (a == 1)
                        {
                            AI.SelectPosition(CardPosition.FaceUpDefence);
                            a++;
                            return true;
                        }
                    }
                    while (a >= 2); return false;

                }
            }
            return false;
        }
        //苍穹 命运神国
        private bool CmingyunshenguoEffect()
        {
                /*
                int option;
                if (Bot.HasInMonstersZone(CardId.Cmobing))
                {
                    option = 0;
                }
                else if (Bot.HasInGraveyard(CardId.Cmobing))
                {
                    option = 1;
                }
                else
                {
                    option = 2;
                }
                if (ActivateDescription != Util.GetStringId(CardId.Cmingyunshenguo, option))
                    return false;
                    */
                if (ActivateDescription == Util.GetStringId(CardId.Cmingyunshenguo, 0))
                {
                   AI.SelectCard(Cost_select2);
                if (!Bot.HasInHand(CardId.Cmingyunzhiyin) && !Cmingyunzhiyin)
                {
                    AI.SelectNextCard(CardId.Cmingyunzhiyin);
                }
                else if (CheckRemainInDeck(CardId.Cyaomu) == 3 || CheckRemainInDeck(CardId.Cfengyu) == 2)
                {
                    AI.SelectNextCard(CardId.Cmingyunzhiyin);
                }
                else if (!Cmingyunshenguo2)
                {
                    AI.SelectNextCard(CardId.Cshendaozhe);
                }
                else if (CheckRemainInDeck(CardId.Cmei) == 0)
                {
                    AI.SelectNextCard(CardId.Cmoshushi);
                }
                else
                {
                    AI.SelectNextCard(CardId.Cousifei);
                }
                     Cmingyunshenguo = true;
                    return true;
                }
                else if (ActivateDescription == Util.GetStringId(CardId.Cmingyunshenguo, 1))
                {
                  if (Bot.HasInGraveyard(CardId.Cshendaozhe))
                  {
                    AI.SelectCard(CardId.Cshendaozhe);
                    Cmingyunshenguo2 = true;
                    return true;
                  }
                  return false;
                }
                return false;
        }
    }
}
