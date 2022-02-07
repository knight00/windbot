using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    // NOT FINISHED YET
    [Deck("Operatorwd", "AI_Operatorwd", "NotFinished")]
    public class OperatorwdExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Gpaopuka = 79029161;
            public const int Gyoulingsha = 79029085;
            public const int Gcuoe = 79029384;
            public const int Gchidong = 79029467;
            public const int Ghongdou = 79029458;
            public const int Glapulande = 79029486;
            public const int Gjiexika = 79029045;
            public const int Gnengtianshi = 79029485;
            public const int Gxiangcao = 79029046;
            public const int Gkeluosi = 79029107;
            public const int Ghuanghouyihao = 79029466;
            public const int Gxingdongdiaoqian = 79029064;
            public const int Grenwujinengkapian = 79029208;
            public const int Gjijing = 79029214;
            public const int Gganyuanxunfang = 79029296;
            public const int Glaiwadingjuying = 79029324;
            public const int Ghuanghun = 79029339;
            public const int Gliujiejianglin = 79029381;
            public const int Gshuanglongchuqiao = 79029482;
            public const int Gzhanshuzhidao = 79029253;
            public const int Gronghuolianyu = 79029445;
            public const int Gqingsenuhuo = 79029479;
            public const int Gmubiaohusong = 79029042;
            public const int Gmihong = 79029031;
            public const int Gnian = 79029382;
            public const int Gjianlei = 79029111;
            public const int Gtemimi = 79029313;
            public const int Gyemo = 79029093;
            public const int Glaiyingshengming = 79029078;
            public const int Gyanyuyanrong = 79029423;
            public const int Gxingrong = 79029061;
            public const int Gyuekongchui = 79029225;
            public const int Gguangying = 79029298;
            public const int Gshierteer = 79029325;
            public const int Gxi = 79029383;
            public const int Gchixiaojueying = 79029480;
            public const int Gamiya = 79029359;
            public const int Gansuo = 79029032;
            public const int Gyumaobi = 79029915;
            public const int Ggaizhihua = 79029246;
        }
        List<int> Impermanence_list = new List<int>();
        bool Gjiexika = false;
        bool Gliujiejianglin = false;
        bool Gzhanshuzhidao = false;
        bool Gyemo = false;
        bool Gtemimi = false;
        bool Gpaopuka = false;
        bool Gyemo2 = false;
        bool Gjiexika2 = false;
        bool Gguangying = false;
        bool Glapulande = false;
        //选择
        List<int> should_select = new List<int>
        {
            79029485,79029046,79029466,79029045,79029107,79029486,79029467,79029384,79029085,79029485,79029225
        };
        //选择2
        List<int> should2_select = new List<int>
        {
            79029045,79029107,79029486,79029467,79029384,79029085,79029485
        };
        //选择3
        List<int> should3_select = new List<int>
        {
           79029085,79029485,79029046,79029466,79029045,79029107,79029486,79029467,79029384,79029085,79029225
        };
        //选择4
        List<int> should4_select = new List<int>
        {
            79029485,79029046,79029466,79029045,79029107,79029486,79029467,79029384,79029085,79029485
        };

        public OperatorwdExecutor(GameAI ai, Duel duel)
      : base(ai, duel)
        {
            //干员 钙质化
            AddExecutor(ExecutorType.Activate, CardId.Ggaizhihua, GgaizhihuaEffect);
            //干员 炎狱炎熔
            AddExecutor(ExecutorType.SpSummon, CardId.Gyanyuyanrong);
            //干员 炎狱炎熔
            //AddExecutor(ExecutorType.Activate, CardId.Gyanyuyanrong);
            //干员 嵯峨
            AddExecutor(ExecutorType.SpSummon, CardId.Gcuoe, GcuoeSummon);
            //干员 嵯峨
            AddExecutor(ExecutorType.Activate, CardId.Gcuoe);
            //干员 拉普兰德
            AddExecutor(ExecutorType.Activate, CardId.Glapulande, GlapulandeEffect);
            //干员 坚雷
            AddExecutor(ExecutorType.SpSummon, CardId.Gjianlei, GjianleiSummon);
            //干员 能天使
            AddExecutor(ExecutorType.Activate, CardId.Gnengtianshi, GnengtianshiEffect);
            //干员 红豆
            AddExecutor(ExecutorType.Activate, CardId.Ghongdou, GhongdouEffect);
            //干员 香草
            AddExecutor(ExecutorType.Activate, CardId.Gxiangcao, GxiangcaoEffect);
            //干员 赤东
            AddExecutor(ExecutorType.SpSummon, CardId.Gchidong, GchidongSummon);
            //干员 杰西卡
            AddExecutor(ExecutorType.Activate, CardId.Gjiexika, GjiexikaEffect);
            //干员 杰西卡
            AddExecutor(ExecutorType.Summon, CardId.Gjiexika, GjiexikaSummon);
            //干员 杰西卡2
            AddExecutor(ExecutorType.Activate, CardId.Gjiexika, GjiexikaEffect2);
            //干员 皇后一号
            AddExecutor(ExecutorType.Activate, CardId.Ghuanghouyihao, GhuanghouyihaoEffect);
            //干员 莱茵生命
            AddExecutor(ExecutorType.SpSummon, CardId.Glaiyingshengming, LaiyingshengmingSummon);
            //干员 莱茵生命
            AddExecutor(ExecutorType.Activate, CardId.Glaiyingshengming);
            //干员 泡普卡
            AddExecutor(ExecutorType.SpSummon, CardId.Gpaopuka, GpaopukaSummon);
            //干员 泡普卡
            AddExecutor(ExecutorType.Activate, CardId.Gpaopuka, GpaopukaEffect);
            //干员 战术指导 发动
            AddExecutor(ExecutorType.Activate, CardId.Gzhanshuzhidao, GzhanshuzhidaoZone);
            //干员 战术指导
            AddExecutor(ExecutorType.Activate, CardId.Gzhanshuzhidao, GzhanshuzhidaoEffect);
            //干员 夜魔
            AddExecutor(ExecutorType.SpSummon, CardId.Gyemo, GyemoSummon);
            //干员 夜魔
            AddExecutor(ExecutorType.Activate, CardId.Gyemo, GyemoEffect);
            //干员 霓虹
            AddExecutor(ExecutorType.Activate, CardId.Gmihong, GmihongEffect);
            //干员 光影
            AddExecutor(ExecutorType.SpSummon, CardId.Gguangying, GguangyingSummon);
            //干员 光影
            AddExecutor(ExecutorType.Activate, CardId.Gguangying, GguangyingEffect);
            //干员 熔火炼狱
            AddExecutor(ExecutorType.Activate, CardId.Gronghuolianyu, GronghuolianyuEffect);
            //干员 锤子
            AddExecutor(ExecutorType.Activate, CardId.Gyuekongchui, GyuekongchuiEffect);
            //干员 黄昏
            AddExecutor(ExecutorType.Activate, CardId.Ghuanghun, GhuanghunEffect);
            //干员 特米米
            AddExecutor(ExecutorType.SpSummon, CardId.Gtemimi, GtemimiSummon);
            //干员 特米米
            AddExecutor(ExecutorType.Activate, CardId.Gtemimi);
            //干员 暗锁
            AddExecutor(ExecutorType.SpSummon, CardId.Gansuo, GansuoSummon);
            //干员 暗锁
            AddExecutor(ExecutorType.Activate, CardId.Gansuo);
            //干员 青色怒火
            AddExecutor(ExecutorType.Activate, CardId.Gqingsenuhuo, GqingsenuhuoEffect);
            //干员 锤子
            AddExecutor(ExecutorType.SpSummon, CardId.Gyuekongchui, GyuekongchuiSummon);
            //干员 星熊
            AddExecutor(ExecutorType.SpSummon, CardId.Gxingrong, GxingrongSummon);
            //干员 星熊
            AddExecutor(ExecutorType.Activate, CardId.Gxingrong);
            //干员 幽灵鲨
            AddExecutor(ExecutorType.Summon, CardId.Gyoulingsha, GyoulingshaSummon);
            //干员 幽灵鲨
            AddExecutor(ExecutorType.Activate, CardId.Gyoulingsha);
            //干员 巨影
            AddExecutor(ExecutorType.Activate, CardId.Glaiwadingjuying, GlaiwadingjuyingEffect);
            //干员 史尔特尔
            AddExecutor(ExecutorType.Activate, CardId.Gshierteer);
            //干员 羽毛笔
            AddExecutor(ExecutorType.SpSummon, CardId.Gyumaobi, GyumaobiSummon);
            //干员 羽毛笔
            AddExecutor(ExecutorType.Activate, CardId.Gyumaobi, GyumaobiEffect);
            //干员 极境
            AddExecutor(ExecutorType.Activate, CardId.Gjijing);
            //干员 年
            AddExecutor(ExecutorType.Activate, CardId.Gnian);
            //干员 六界降临
            AddExecutor(ExecutorType.Activate, CardId.Gliujiejianglin, GliujiejianglinEffect);
            //干员 艾米亚
            AddExecutor(ExecutorType.SpSummon, CardId.Gamiya,GamiyaSummon);
            //干员 艾米亚
            AddExecutor(ExecutorType.Activate, CardId.Gamiya);
            //干员 赤霄
            AddExecutor(ExecutorType.SpSummon, CardId.Gchixiaojueying, GamiyaSummon);
            //干员 赤霄
            AddExecutor(ExecutorType.Activate, CardId.Gchixiaojueying);
            //干员 夕
            AddExecutor(ExecutorType.Activate, CardId.Gxi);
            //干员 双龙
            AddExecutor(ExecutorType.Activate, CardId.Gshuanglongchuqiao);
            //人物技能卡片
            AddExecutor(ExecutorType.Activate, CardId.Grenwujinengkapian, GrenwujinengkapianEffect);
            //干员 行动调遣
            AddExecutor(ExecutorType.Activate, CardId.Gxingdongdiaoqian, GxingdongdiaoqianEffect);
            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
        }
        //计数专用
        public override void OnNewTurn()
        {
            // reset
            Gjiexika = false;
            Gliujiejianglin = false;
            Gzhanshuzhidao = false;
            Gpaopuka = false;
            Gyemo2 = false;
            Gjiexika = false;
            Glapulande = false;
        }
        //卡组检查
        public int CheckRemainInDeck(int id)
        {
            switch (id)
            {
                case CardId.Gpaopuka:
                    return Bot.GetRemainingCount(CardId.Gpaopuka, 2);
                case CardId.Gyoulingsha:
                    return Bot.GetRemainingCount(CardId.Gyoulingsha, 1);
                case CardId.Gcuoe:
                    return Bot.GetRemainingCount(CardId.Gcuoe, 1);
                case CardId.Gchidong:
                    return Bot.GetRemainingCount(CardId.Gchidong, 1);
                case CardId.Ghongdou:
                    return Bot.GetRemainingCount(CardId.Ghongdou, 2);
                case CardId.Glapulande:
                    return Bot.GetRemainingCount(CardId.Glapulande, 3);
                case CardId.Gjiexika:
                    return Bot.GetRemainingCount(CardId.Gjiexika, 2);
                case CardId.Gnengtianshi:
                    return Bot.GetRemainingCount(CardId.Gnengtianshi, 3);
                case CardId.Gxiangcao:
                    return Bot.GetRemainingCount(CardId.Gxiangcao, 1);
                case CardId.Gkeluosi:
                    return Bot.GetRemainingCount(CardId.Gkeluosi, 3);
                case CardId.Ghuanghouyihao:
                    return Bot.GetRemainingCount(CardId.Ghuanghouyihao, 2);
                case CardId.Gxingdongdiaoqian:
                    return Bot.GetRemainingCount(CardId.Gxingdongdiaoqian, 1);
                case CardId.Grenwujinengkapian:
                    return Bot.GetRemainingCount(CardId.Grenwujinengkapian, 1);
                case CardId.Gjijing:
                    return Bot.GetRemainingCount(CardId.Gjijing, 1);
                case CardId.Gganyuanxunfang:
                    return Bot.GetRemainingCount(CardId.Gganyuanxunfang, 1);
                case CardId.Glaiwadingjuying:
                    return Bot.GetRemainingCount(CardId.Glaiwadingjuying, 1);
                case CardId.Ghuanghun:
                    return Bot.GetRemainingCount(CardId.Ghuanghun, 1);
                case CardId.Gliujiejianglin:
                    return Bot.GetRemainingCount(CardId.Gliujiejianglin, 3);
                case CardId.Gshuanglongchuqiao:
                    return Bot.GetRemainingCount(CardId.Gshuanglongchuqiao, 1);
                case CardId.Gzhanshuzhidao:
                    return Bot.GetRemainingCount(CardId.Gzhanshuzhidao, 3);
                case CardId.Gronghuolianyu:
                    return Bot.GetRemainingCount(CardId.Gronghuolianyu, 1);
                case CardId.Gqingsenuhuo:
                    return Bot.GetRemainingCount(CardId.Gqingsenuhuo, 1);
                case CardId.Gmubiaohusong:
                    return Bot.GetRemainingCount(CardId.Gmubiaohusong, 2);
                case CardId.Gmihong:
                    return Bot.GetRemainingCount(CardId.Gmihong, 2);
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
        //干员 坚雷
        private bool GjianleiSummon()
        {
            AI.SelectCard(CardId.Gnengtianshi);
            AI.SelectNextCard(CardId.Gjiexika);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //干员 杰西卡
        private bool GjiexikaEffect2()
        {
            AI.SelectCard(CardId.Gmihong);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            Gjiexika2 = true;
            return true;
        }
        //干员 行动调遣
        private bool GxingdongdiaoqianEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.Gshierteer);
                return true;
            }
            return false;
        }
        //干员 拉普兰德
        private bool GlapulandeEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                Glapulande = true;
                return true;
            }
            else
            {
                if (Util.ChainContainsCard(CardId.Gkeluosi))
                    return false;
                return true;
            }
        }
        //干员 星熊
        private bool GxingrongSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Gyumaobi) || Bot.HasInMonstersZone(CardId.Gamiya) || Bot.HasInMonstersZone(CardId.Gchixiaojueying) || Bot.HasInMonstersZone(CardId.Gxi))
                return false;
            return true;
        }
        //干员 艾米亚
        private bool GamiyaSummon()
        {
            if ((Bot.HasInMonstersZone(CardId.Glaiyingshengming) || Bot.HasInMonstersZone(CardId.Gnian)) && Bot.GetMonsterCount()>=4) return false;
            return true;
        }
        //干员 六界降临
        private bool GliujiejianglinEffect()
        {
            if ((Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer != 1) || (Bot.HasInMonstersZone(CardId.Gansuo) && Bot.HasInExtra(CardId.Gyuekongchui) && !Gyemo)) return false;
            if (Bot.HasInExtra(CardId.Gnian))
            {
                IList<ClientCard> targets = new List<ClientCard>();
                foreach (ClientCard target in Bot.GetMonstersInExtraZone())
                {
                    AI.SelectCard(CardId.Gnian);
                    targets.Add(target);
                }
                if (Bot.Deck.GetMonsters().Count <= 5)
                //if (Bot.GetGraveyardMonsters().Count>=14 || Bot.GetBanishedMonsters().Count>=14 || (Bot.GetGraveyardMonsters().Count+ Bot.GetBanishedMonsters().Count>=20))
                {
                    foreach (ClientCard target4 in Bot.Deck)
                    {
                        if (targets.Count >= Bot.Deck.GetMonsters().Count - 1)
                            break;
                        if (!targets.Contains(target4))
                            targets.Add(target4);
                    }
                    if (targets.Count == 0)
                        return false;
                    AI.SelectCard(targets);

                    /*foreach (ClientCard target1 in Bot.GetDeck())
                    {
                        if (targets.Count >= 3)
                            break;
                        if (!targets.Contains(target1))
                            targets.Add(target1);
                    }
                    if (targets.Count == 0)
                        return false;
                    AI.SelectNextCard(targets);
                    */
                }
                else
                {
                    foreach (ClientCard target1 in Bot.Deck)
                    {
                        if (targets.Count >= 7)
                            break;
                        if (!targets.Contains(target1))
                            targets.Add(target1);
                    }
                    foreach (ClientCard target2 in Bot.GetMonsters())
                    {
                        if (targets.Count >= 7)
                            break;
                        if (!targets.Contains(target2))
                            targets.Add(target2);
                    }
                    if (targets.Count == 0)
                        return false;
                }
                AI.SelectNextCard(targets);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                AI.SelectPlace(Zones.z0 | Zones.z1 | Zones.z2 | Zones.z3 | Zones.z4 | Zones.z5 | Zones.z6);
                return true;
            }
            else if (Bot.HasInExtra(CardId.Gxi))
            {
                AI.SelectCard(CardId.Gxi);
                foreach (ClientCard card in Bot.Banished)
                    AI.SelectNextCard(card);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                AI.SelectPlace(Zones.z0 | Zones.z1 | Zones.z2 | Zones.z3 | Zones.z4 | Zones.z5 | Zones.z6);
                return true;
            }
            return false;
        }
        //干员 嵯峨
        private bool GcuoeSummon()
        {
            AI.SelectCard(should_select);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //干员 巨影
        private bool GlaiwadingjuyingEffect()
        {
            //除外顺序：魔，陷，怪
            if (!Gyemo || Gyemo2 || Bot.HasInExtra(CardId.Gguangying)) return false;
            AI.SelectCard(CardId.Gxingdongdiaoqian, CardId.Gmubiaohusong, CardId.Gmihong, CardId.Gyoulingsha);
            AI.SelectNextCard(CardId.Gmubiaohusong, CardId.Gmihong);
            AI.SelectThirdCard(CardId.Gyoulingsha);
            return true;
        }
        //干员 人物技能卡片
        private bool GrenwujinengkapianEffect()
        {
            AI.SelectAnnounceID(CardId.Ggaizhihua);
            AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }
        //干员 赤东
        private bool GchidongSummon()
        {
            AI.SelectCard(CardId.Gxingdongdiaoqian, CardId.Gshuanglongchuqiao, CardId.Gjijing);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //干员 青色怒火
        private bool GqingsenuhuoEffect()
        {
            int i = 0;
            do
            {
                if (i == 0)
                {
                    if (Bot.LifePoints <= 2000)
                    {
                        i++;
                        return false;
                    }
                    else
                    {
                        if (CheckRemainInDeck(CardId.Gshuanglongchuqiao) > 0)
                        {
                            AI.SelectCard(CardId.Gshuanglongchuqiao);
                            i++;
                            return true;
                        }
                        else
                        {
                            i++;
                            return false;
                        }

                    }
                }
                else if (i == 1)
                {
                    AI.SelectCard(CardId.Gshuanglongchuqiao);
                    AI.SelectNextCard(CardId.Gyumaobi);
                    AI.SelectThirdCard(CardId.Gansuo);
                    i++;
                    return true;
                }
                else if (i == 2)
                {
                    if (Duel.CurrentChain.Count > 0)
                    {
                        i++;
                        return true;
                    }
                    else
                    {
                        i++;
                        return false;
                    }

                }

            }
            while (i >= 3); return false;
        }
        //干员 能天使
        private bool GnengtianshiEffect()
        {
            if (Card.Location == CardLocation.Hand) return true;
            else if (Card.Location == CardLocation.Grave)
            {
                if (Bot.GetMonstersInMainZone().Count >= 5) return false;
                {
                    AI.SelectCard(CardId.Gjiexika, CardId.Ghuanghouyihao, CardId.Ghongdou, CardId.Gxiangcao, CardId.Gchidong, CardId.Gyoulingsha, CardId.Gjijing);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
            }
            return false;
        }
        //干员 泡普卡
        private bool GpaopukaEffect()
        {
            foreach (ClientCard card in Bot.GetMonsters())
                if (!Gyemo)
                {
                    if (!Bot.HasInMonstersZone(should_select) || Bot.HasInMonstersZone(CardId.Ghongdou)) return false;
                    {
                        AI.SelectCard(should_select);
                        AI.SelectNumber(6);
                        return true;
                    }
                }
                else if (!Gtemimi)
                {
                    if (!Bot.HasInMonstersZone(should2_select) || Bot.HasInMonstersZone(CardId.Gjiexika)) return false;
                    {
                        AI.SelectCard(should_select);
                        AI.SelectNumber(4);
                        return true;
                    }
                }
                else if (Gtemimi)
                {
                    AI.SelectCard(should_select);
                    AI.SelectNumber(6);
                    return true;
                }
            return false;

        }
        //干员 杰西卡
        private bool GjiexikaSummon()
        {
            if (!Gjiexika) return true;
            return false;
        }
        //干员 红豆
        private bool GhongdouEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.HasInHand(CardId.Gyoulingsha)) return false;
                {
                    AI.SelectCard(CardId.Gxiangcao, CardId.Gkeluosi);
                    AI.SelectNextCard(CardId.Gyoulingsha);
                    return true;
                }

            }
            else if (Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.Gxi, CardId.Gchixiaojueying, CardId.Gamiya);
                if (CheckRemainInDeck(CardId.Gxingdongdiaoqian) > 0 && CheckRemainInDeck(CardId.Gronghuolianyu) > 0)
                {
                    if (!Bot.HasInHand(CardId.Gzhanshuzhidao))
                    {
                        if (!Bot.HasInHand(CardId.Gliujiejianglin))
                        {
                            AI.SelectNextCard(CardId.Gronghuolianyu, CardId.Gzhanshuzhidao, CardId.Gliujiejianglin, CardId.Gqingsenuhuo, CardId.Ghuanghun, CardId.Gganyuanxunfang, CardId.Gshuanglongchuqiao);
                        }
                        else
                        {
                            AI.SelectNextCard(CardId.Gronghuolianyu, CardId.Gzhanshuzhidao, CardId.Gqingsenuhuo, CardId.Ghuanghun, CardId.Gganyuanxunfang, CardId.Gshuanglongchuqiao);
                        }
                    }
                    else
                    {
                        AI.SelectNextCard(CardId.Gronghuolianyu, CardId.Gliujiejianglin, CardId.Gzhanshuzhidao, CardId.Gqingsenuhuo, CardId.Ghuanghun, CardId.Gganyuanxunfang, CardId.Gshuanglongchuqiao);
                    }
                }
                else if ((!Gjiexika2 && Bot.HasInBanished(CardId.Gmihong) && Bot.HasInHandOrInMonstersZoneOrInGraveyard(CardId.Gjiexika)) || Bot.HasInGraveyard(CardId.Gmihong))
                {
                    if (!Bot.HasInHandOrInSpellZone(CardId.Gzhanshuzhidao) && !Gzhanshuzhidao)
                    {
                        AI.SelectNextCard(CardId.Gzhanshuzhidao, CardId.Gronghuolianyu, CardId.Gliujiejianglin, CardId.Gqingsenuhuo, CardId.Ghuanghun, CardId.Gganyuanxunfang, CardId.Gshuanglongchuqiao);
                    }
                    else
                    {
                        AI.SelectNextCard(CardId.Gronghuolianyu, CardId.Gliujiejianglin, CardId.Gqingsenuhuo, CardId.Ghuanghun, CardId.Gganyuanxunfang, CardId.Gshuanglongchuqiao);
                    }
                }
                else if (!Bot.HasInHandOrInSpellZone(CardId.Gzhanshuzhidao) && !Gzhanshuzhidao)
                {
                    AI.SelectNextCard(CardId.Gzhanshuzhidao, CardId.Gronghuolianyu, CardId.Gliujiejianglin, CardId.Gqingsenuhuo, CardId.Ghuanghun, CardId.Gganyuanxunfang, CardId.Gshuanglongchuqiao);
                }
                else if (!Bot.HasInHand(CardId.Gliujiejianglin) && !Gliujiejianglin)
                {
                    AI.SelectNextCard(CardId.Gliujiejianglin, CardId.Gronghuolianyu, CardId.Gqingsenuhuo, CardId.Ghuanghun, CardId.Gganyuanxunfang, CardId.Gshuanglongchuqiao);
                }
                else
                {
                    AI.SelectNextCard(CardId.Gronghuolianyu, CardId.Gqingsenuhuo, CardId.Ghuanghun, CardId.Gganyuanxunfang, CardId.Gshuanglongchuqiao);
                }
                return true;
            }
            return false;
        }
        //干员 熔火炼狱
        private bool GronghuolianyuEffect()
        {
            int i = 0;
            do
            {
                if (i == 0)
                {
                    if (Bot.LifePoints <= 4000) return false;
                    {
                        AI.SelectCard(CardId.Gxingdongdiaoqian);
                        AI.SelectYesNo(true);
                        AI.SelectNextCard(CardId.Gshierteer);
                        i++;
                        return true;
                    }
                }
                else if (i == 1)
                {
                    AI.SelectCard(CardId.Gshierteer);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    i++;
                    return true;
                }
                else if (i == 2)
                {
                    if (Bot.LifePoints <= 4000)
                    {
                        AI.SelectYesNo(false);
                        i++;
                        return true;
                    }
                    i++;
                    return false;
                }
            }
            while (i >= 3); return false;
        }
        //干员 夜魔
        private bool GyemoEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (ActivateDescription == Util.GetStringId(2311603, 1))
                {
                    if (Bot.LifePoints <= 6000) return false;
                    Gyemo2 = true;
                    return true;
                }
                else if (ActivateDescription == Util.GetStringId(80117527, 0)) return true;
                return false;
            }
            else if (Card.Location == CardLocation.Grave) return true;
            return false;
        }
        //干员 黄昏
        private bool GhuanghunEffect()
        {
            if (Card.Location != CardLocation.Grave)
            {
                AI.SelectCard(CardId.Gguangying);
                return true;
            }
            else if (Card.Location == CardLocation.Grave)
            {
                return (Duel.Player == 1);
            }
            return false;
        }
        //干员 钙质化
        private bool GgaizhihuaEffect()
        {
            return (Duel.Player == 1);
        }
        //干员 锤子
        private bool GyuekongchuiSummon()
        {
            if (!Bot.HasInMonstersZone(CardId.Gansuo)) return false;
            AI.SelectMaterials(CardId.Gansuo);
            AI.SelectYesNo(true);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            AI.SelectPlace(Zones.z6 | Zones.z5 | Zones.z0 | Zones.z1 | Zones.z2 | Zones.z3 | Zones.z4);
            return true;
        }
        //干员 羽毛笔
        private bool GyumaobiSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Gguangying) && Bot.HasInMonstersZone(CardId.Glaiyingshengming) && Bot.HasInMonstersZone(CardId.Gtemimi)) return false;
            if (Bot.GetMonstersInMainZone().Count <= 3 && Bot.HasInHandOrHasInMonstersZone(should4_select)) return false;
            if (Gyemo2) return false;
            AI.SelectMaterials(should3_select);
            if (Bot.GetMonstersExtraZoneCount() == 0)
            {
                if (Bot.HasInExtra(CardId.Gnian))
                {
                    AI.SelectPlace(Zones.z5 | Zones.z6);
                }
                else
                {
                    AI.SelectPlace(Zones.z0 | Zones.z1 | Zones.z2 | Zones.z3 | Zones.z4);
                }
                return true;
            }
            else return true;
        }
        //干员 羽毛笔
        private bool GyumaobiEffect()
        {
            IList<ClientCard> targets = new List<ClientCard>();
            foreach (ClientCard target1 in Bot.Graveyard)
            {
                if (targets.Count >= 3)
                    break;
                if (!targets.Contains(target1))
                    targets.Add(target1);
            }
            foreach (ClientCard target2 in Bot.Deck)
            {
                if (targets.Count >= 3)
                    break;
                if (!targets.Contains(target2))
                    targets.Add(target2);
            }
            if (targets.Count == 0)
                return false;
            AI.SelectCard(targets);
            return true;
        }
        //干员 锤子
        private bool GyuekongchuiEffect()
        {
            if (!Bot.HasInGraveyard(CardId.Glaiwadingjuying))
            {
                AI.SelectCard(CardId.Gansuo);
                AI.SelectNextCard(CardId.Gzhanshuzhidao);
                return true;
            }
            else if (Bot.HasInGraveyard(CardId.Glaiwadingjuying))
            {
                AI.SelectYesNo(true);
                AI.SelectCard(CardId.Gzhanshuzhidao);
                return true;
            }
            return false;
        }
        //干员 香草
        private bool GxiangcaoEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                if (!Bot.HasInBanished(CardId.Gmihong))
                {
                    AI.SelectCard(CardId.Gmihong, CardId.Gmubiaohusong);
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Gmubiaohusong, CardId.Gmihong);
                    return true;
                }
            }
            return false;
        }
        //干员 暗锁
        private bool GansuoSummon()
        {
            if (!Gjiexika) return false;
            if (!Gpaopuka && !Gyemo)
            {
                AI.SelectMaterials(should_select);
                return true;
            }
            return false;
        }
        //干员 战术指导
        private bool GzhanshuzhidaoZone()
        {
            if (Card.Location == CardLocation.Hand)
                return DefaultSpellZone();
            return false;
        }
        private bool DefaultSpellZone()
        {
            return Bot.SpellZone[0] == null || Bot.SpellZone[1] == null || Bot.SpellZone[2] == null || Bot.SpellZone[3] == null || Bot.SpellZone[4] == null;
        }
        //干员 战术指导
        private bool GzhanshuzhidaoEffect()
        {
             if (!Gzhanshuzhidao && ActivateDescription != Util.GetStringId(CardId.Gzhanshuzhidao, 1))
             {
                if (Bot.LifePoints <= 1000) return false;
                if (!Gpaopuka && !Gyemo && !Bot.HasInMonstersZone(CardId.Gpaopuka))
                {
                    AI.SelectCard(CardId.Gpaopuka, CardId.Glapulande, CardId.Gjijing, CardId.Gnengtianshi);
                }
                else if (CheckRemainInDeck(CardId.Gronghuolianyu) > 0 && CheckRemainInDeck(CardId.Gxingdongdiaoqian) > 0)
                {
                    AI.SelectCard(CardId.Gxingdongdiaoqian ,CardId.Glapulande, CardId.Gjijing, CardId.Gnengtianshi);
                }
                else if (!Bot.HasInHand(CardId.Gliujiejianglin))
                {
                    AI.SelectCard(CardId.Gliujiejianglin, CardId.Glapulande, CardId.Gjijing, CardId.Gnengtianshi);
                }
                else
                {
                    AI.SelectCard(CardId.Glapulande, CardId.Gjijing, CardId.Gnengtianshi);
                }
                Gzhanshuzhidao = true;
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Gzhanshuzhidao, 1))
            {
                  if (!Gzhanshuzhidao || (Util.ChainContainsCard(CardId.Gzhanshuzhidao) && Duel.LastChainPlayer == 0)) return false;
                 {
                    if (!Bot.HasInHand(CardId.Gliujiejianglin))
                    {
                        AI.SelectCard(CardId.Gliujiejianglin);
                    }
                    else if (CheckRemainInDeck(CardId.Gronghuolianyu) > 0 && CheckRemainInDeck(CardId.Gxingdongdiaoqian) > 0)
                    {
                        AI.SelectCard(CardId.Gronghuolianyu, CardId.Gliujiejianglin);
                    }
                    else
                    {
                        AI.SelectCard(CardId.Ghuanghun, CardId.Gliujiejianglin);
                    }
                    return true;
                 }
            }
            return true;
            
        }
        //干员 特米米
        private bool GtemimiSummon()
        {
            AI.SelectMaterials(new List<int>() {
                CardId.Gjiexika,
                CardId.Gpaopuka
            });
            AI.SelectPosition(CardPosition.FaceUpAttack);
            Gtemimi = true;
            return true;
        }
        //干员 幽灵鲨
        private bool GyoulingshaSummon()
        {
            if (!Gyemo2) return false;
            AI.SelectMaterials(should_select);
            return true;
        }
        //干员 泡普卡
        private bool GpaopukaSummon()
        {
            if (Card.Location == CardLocation.Hand || Card.Location == CardLocation.Grave)
            {
                if (!Bot.HasInMonstersZone(CardId.Gjiexika) && !Bot.HasInMonstersZone(CardId.Ghongdou) && !Bot.HasInMonstersZone(CardId.Gcuoe) && !Bot.HasInMonstersZone(CardId.Gchidong) && !Bot.HasInMonstersZone(CardId.Glapulande) && !Gyemo) return false;
                if (!Bot.HasInMonstersZone(should_select)) return false;
                {
                    AI.SelectCard(should_select);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    Gpaopuka = true;
                    return true;
                }

            }
            return false;
        }
        //干员 莱茵生命
        private bool LaiyingshengmingSummon()
        {
            AI.SelectMaterials(new List<int>() {
                CardId.Ghuanghouyihao,
                CardId.Gjiexika,
                CardId.Gjianlei
            });
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //干员 夜魔
        private bool GyemoSummon()
        {
            AI.SelectCard(CardId.Ghongdou, CardId.Gpaopuka);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            Gyemo = true;
            return true;

        }
        //干员 光影
        private bool GguangyingSummon()
        {
            AI.SelectMaterials(new List<int>() {
                CardId.Ghongdou,
                CardId.Gyemo
            });
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //干员 霓虹
        private bool GmihongEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                if ((Bot.HasInExtra(CardId.Gyemo) && !Gyemo) || (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer != 1)) return false;
                else if(Gyemo)
                {
                    if (!Gguangying)
                    {
                        AI.SelectCard(CardId.Ghongdou, CardId.Gyemo, CardId.Ggaizhihua,CardId.Gyumaobi,CardId.Gyuekongchui);
                    }
                    else
                    {
                        AI.SelectCard(CardId.Gyemo, CardId.Ghongdou, CardId.Ggaizhihua, CardId.Gyumaobi, CardId.Gyuekongchui);
                    }
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                return false;
            }
            return false;
        }
        //干员 光影
        private bool GguangyingEffect()
        {
            AI.SelectOption(4);
            Gguangying = true;
            return true;
        }
        //干员 杰西卡
        private bool GjiexikaEffect()
        {
            foreach (ClientCard card in Bot.Banished)
                if (Card.Location == CardLocation.Hand || Card.Location == CardLocation.Grave)
                {
                    if (card.IsCode(CardId.Gmihong))
                    {
                            AI.SelectCard(card);
                            AI.SelectPosition(CardPosition.FaceUpAttack);
                            return true;
                    }
                    else if (Bot.HasInSpellZone(CardId.Gmihong) || Bot.HasInHand(CardId.Gmihong))
                    {
                        AI.SelectCard(CardId.Gmihong);
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                        return true;
                    }
                    return false;
                }
                else if (Card.Location == CardLocation.MonsterZone)
                {
                    AI.SelectCard(CardId.Gmihong);
                    AI.SelectNextCard(CardId.Ghuanghouyihao);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    Gjiexika = true;
                    return true;
                }
            return false;
        }
        //干员 皇后一号
        private bool GhuanghouyihaoEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (ActivateDescription == Util.GetStringId(CardId.Ghuanghouyihao, 0))
                {
                    if (Bot.HasInHand(CardId.Gmihong))
                    {
                        AI.SelectCard(CardId.Gmihong, CardId.Gxingdongdiaoqian, CardId.Gpaopuka, CardId.Gchidong, CardId.Gganyuanxunfang, CardId.Ghuanghun, CardId.Gnengtianshi,CardId.Ghuanghouyihao,CardId.Gmubiaohusong );
                    }
                    else if (Bot.GetCountCardInZone(Bot.Hand, CardId.Gliujiejianglin) >= 2)
                    {
                        AI.SelectCard(CardId.Gliujiejianglin, CardId.Gmihong, CardId.Gxingdongdiaoqian, CardId.Gpaopuka, CardId.Gchidong, CardId.Gganyuanxunfang, CardId.Ghuanghun, CardId.Gnengtianshi, CardId.Ghuanghouyihao, CardId.Gmubiaohusong);
                    }
                    else
                    {
                        AI.SelectCard(CardId.Gmihong, CardId.Gxingdongdiaoqian, CardId.Gpaopuka, CardId.Gganyuanxunfang, CardId.Gchidong, CardId.Ghuanghun, CardId.Gnengtianshi, CardId.Ghuanghouyihao, CardId.Gmubiaohusong);
                    }
                    AI.SelectNextCard(CardId.Ghongdou,CardId.Gcuoe);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                else if (ActivateDescription != Util.GetStringId(CardId.Ghuanghouyihao, 0)) return false;
                return false;
            }
            return false;
        }
    }
}
