using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    // NOT FINISHED YET
    [Deck("Chronomaly", "AI_Chronomaly", "NotFinished")]
    public class ChronomalyExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Xtaiyangdushibei = 93543806;
            public const int Xmoaishixiang = 87430304;
            public const int Xtuou = 24506253;
            public const int Xxingxiangpan = 24861088;
            public const int Xgankushoujingtougu = 84610020;
            public const int Xacitekemianjuren = 94766498;
            public const int Xmowaladiqiuyi = 97112505;
            public const int Xhuojian = 2089016;
            public const int Xshuijingtougu = 51435705;
            public const int Huiliuli = 14558128;
            public const int Yiretongxingouzhu = 62623659;
            public const int Xshiguan = 87724401;
            public const int Xyichanjishu = 90951921;
            public const int Shundunzhili = 94220427;
            public const int Sxingguangzhili = 111011901;
            public const int Xsanjushi = 98204536;
            public const int Wuxianpaoying = 10045474;
            public const int Xshiwen = 50797682;
            public const int Xdaxizhoujurens = 100000577;
            public const int Xdaxizhoujuren = 9161357;
            public const int Xqineng = 39139935;
            public const int Xweimona = 2609443;
            public const int Xchaqiu = 50260683;
            public const int Wowowo = 12014404;
            public const int Xshuijinglifangti = 84610011;
            public const int Dianzilongxinxing = 58069384;
            public const int Dianzilongwuxian = 10443957;
            public const int Xingqiugaizao = 73628505;
            public const int Xbabilun = 04357063;
            public const int Xhangtianfeiji = 88552992;
            public const int Enhui = 09951558;
            public const int Zhimingzhe = 24224830;
            public const int Suoniao = 94145021;
        }
        List<int> Impermanence_list = new List<int>();
        bool Xdiqiuyi = false;
        bool Xhuojian = false;
        bool Xxingxiangpan = false;
        bool Xshuijinglifangt = false;
        bool Xsanjushi = false;
        bool Xshuijinglifangti = false;
        bool Xyichanjishu = false;
        bool Xgankushuijingtougu = false;
        bool Xshuijingtougu = false;
        //选择
        List<int> should_select = new List<int>
        {
            87430304, 87430304,24506253,24506253,24861088,24861088,84610020,84610020,84610020,94766498,97112505,97112505,97112505,2089016,2089016,
            51435705,51435705,51435705,14558128,14558128,62623659,87724401,90951921,94220427,111011901,98204536,10045474,50797682,50260683,39139935,2609443
        };
        public ChronomalyExecutor(GameAI ai, Duel duel)
         : base(ai, duel)
        {
            //先史遗产 干枯头骨
            AddExecutor(ExecutorType.SpSummon, CardId.Xgankushoujingtougu,Xgankushoujingtougu2Summon);
            //先史遗产 水晶头骨
            AddExecutor(ExecutorType.Activate, CardId.Xshuijingtougu, XshuijingtouguEffect);
            //恩惠
            AddExecutor(ExecutorType.Activate, CardId.Enhui);
            //锁鸟
            AddExecutor(ExecutorType.Activate, CardId.Suoniao, G_activate);
            //灰流丽
            AddExecutor(ExecutorType.Activate, CardId.Huiliuli, Hand_act_eff);
            //无限泡影
            AddExecutor(ExecutorType.Activate, CardId.Wuxianpaoying, Impermanence_activate);
            //墓指
            AddExecutor(ExecutorType.Activate, CardId.Zhimingzhe, DefaultCalledByTheGrave);
            //星球改造
            AddExecutor(ExecutorType.Activate, CardId.Xingqiugaizao);
            //先史遗产 巴比伦
            AddExecutor(ExecutorType.Activate, CardId.Xbabilun);
            //先史遗产 石纹
            AddExecutor(ExecutorType.Activate, CardId.Xshiwen, XshiwenEffect);
            //先史遗产 巨人
            AddExecutor(ExecutorType.SpSummon, CardId.Xacitekemianjuren);
            //先史遗产 石像
            AddExecutor(ExecutorType.SpSummon, CardId.Xmoaishixiang, XmoaishixiangSummon);
            //先史遗产 干枯头骨
            AddExecutor(ExecutorType.Summon, CardId.Xgankushoujingtougu);
            //先史遗产 星象盘
            AddExecutor(ExecutorType.Summon, CardId.Xxingxiangpan);
            //先史遗产 星象盘
            AddExecutor(ExecutorType.Activate, CardId.Xxingxiangpan, XxingxiangpanEffect);
            //电子龙 新星
            AddExecutor(ExecutorType.SpSummon, CardId.Dianzilongwuxian);
            //电子龙 无限
            AddExecutor(ExecutorType.SpSummon, CardId.Dianzilongwuxian);
            //先史遗产 黄金航天飞机
            AddExecutor(ExecutorType.Activate, CardId.Xhangtianfeiji);
            //先史遗产 干枯头骨
            AddExecutor(ExecutorType.Activate, CardId.Xgankushoujingtougu, XgankushoujingtouguEffect);
            //先史遗产 地球仪
            AddExecutor(ExecutorType.Activate, CardId.Xmowaladiqiuyi, XmowaladiqiuyiEffect);
            //先史遗产 火箭
            AddExecutor(ExecutorType.Activate, CardId.Xhuojian, XhuojianEffect);
            //先史遗产 土偶
            AddExecutor(ExecutorType.Activate, CardId.Xtuou, XtuouEffect);
            //先史遗产 石棺
            AddExecutor(ExecutorType.Activate, CardId.Xshiguan);
            //先史遗产 技术
            AddExecutor(ExecutorType.Activate, CardId.Xyichanjishu, XyichanjishuEffect);
            //先史遗产 水晶立方体
            AddExecutor(ExecutorType.SpSummon, CardId.Xshuijinglifangti, XshuijinglifangtiSummon);
            //先史遗产 维摩那
            AddExecutor(ExecutorType.SpSummon, CardId.Xweimona);
            //电子龙 无限
            AddExecutor(ExecutorType.Activate, CardId.Dianzilongwuxian, DianzilongwuxianEffect);
            //先史遗产 维摩那
            AddExecutor(ExecutorType.Activate, CardId.Xweimona,XweimonaEffect);
            //先史遗产 水晶立方体
            AddExecutor(ExecutorType.Activate, CardId.Xshuijinglifangti, XshuijinglifangtiEffect);
            //升阶魔法 混沌
            AddExecutor(ExecutorType.Activate, CardId.Shundunzhili);
            //升阶魔法 星光
            AddExecutor(ExecutorType.Activate, CardId.Sxingguangzhili, SxingguangzhiliEffect);
            //先史遗产 三巨石
            AddExecutor(ExecutorType.Activate, CardId.Xsanjushi, XsanjushiEffect);
            //先史遗产 三巨石效果
            AddExecutor(ExecutorType.Activate, CardId.Xsanjushi, XsanjushiEffect2);
            //先史遗产 大西洲巨人
            AddExecutor(ExecutorType.Activate, CardId.Xdaxizhoujuren);
            //先史遗产 大西洲巨人S
            AddExecutor(ExecutorType.Activate, CardId.Xdaxizhoujurens);
            //先史遗产 地球仪
            AddExecutor(ExecutorType.Summon, CardId.Xmowaladiqiuyi);
            //先史遗产 火箭
            AddExecutor(ExecutorType.Summon, CardId.Xhuojian);
            //先史遗产 叉丘
            AddExecutor(ExecutorType.SpSummon, CardId.Xchaqiu);
            //先史遗产 叉丘
            AddExecutor(ExecutorType.Activate, CardId.Xchaqiu,XchaqiuEffect);
            //先史遗产 气能
            AddExecutor(ExecutorType.SpSummon, CardId.Xqineng);
            //先史遗产 气能
            AddExecutor(ExecutorType.Activate, CardId.Xqineng);
            //异热同心
            AddExecutor(ExecutorType.Activate, CardId.Yiretongxingouzhu, YiretongxingouzhuEffect);
            //先史遗产 巨人
            AddExecutor(ExecutorType.Summon, CardId.Xacitekemianjuren);
            //先史遗产 水晶头骨
            AddExecutor(ExecutorType.Summon, CardId.Xshuijingtougu);
            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
        }
        //计数专用
        public override void OnNewTurn()
        {
            // reset
            Xdiqiuyi = false;
            Xhuojian = false;
            Xxingxiangpan = false;
            Xshuijinglifangt = false;
            Xsanjushi = false;
            Xshuijinglifangti = false;
            Xyichanjishu = false;
            Xgankushuijingtougu = false;
            Xshuijingtougu = false;
        }
        //格子
        public int SelectSTPlace(ClientCard card = null, bool avoid_Impermanence = false)
        {
            List<int> list = new List<int> { 0, 1, 2, 3, 4 };
            int n = list.Count;
            while (n-- > 1)
            {
                int index = Program.Rand.Next(n + 1);
                int temp = list[index];
                list[index] = list[n];
                list[n] = temp;
            }
            foreach (int seq in list)
            {
                int zone = (int)System.Math.Pow(2, seq);
                if (Bot.SpellZone[seq] == null)
                {
                    if (card != null && card.Location == CardLocation.Hand && avoid_Impermanence && Impermanence_list.Contains(seq)) continue;
                    return zone;
                };
            }
            return 0;
        }
        //无效
        List<int> should_not_negate = new List<int>
        {
            81275020, 28985331
        };
        public bool is_should_not_negate()
        {
            ClientCard last_card = Util.GetLastChainCard();
            if (last_card != null
                && last_card.Controller == 1 && last_card.IsCode(should_not_negate))
                return true;
            return false;
        }
        //锁鸟
        public bool G_activate()
        {
            return (Duel.Player == 1);
        }
        //无限泡影
        public bool Impermanence_activate()
        {
            // negate before effect used
            foreach (ClientCard m in Enemy.GetMonsters())
            {
                if (m.IsMonsterShouldBeDisabledBeforeItUseEffect() && !m.IsDisabled() && Duel.LastChainPlayer != 0)
                {
                    if (Card.Location == CardLocation.SpellZone)
                    {
                        for (int i = 0; i < 5; ++i)
                        {
                            if (Bot.SpellZone[i] == Card)
                            {
                                Impermanence_list.Add(i);
                                break;
                            }
                        }
                    }
                    if (Card.Location == CardLocation.Hand)
                    {
                        AI.SelectPlace(SelectSTPlace(Card, true));
                    }
                    AI.SelectCard(m);
                    return true;
                }
            }

            ClientCard LastChainCard = Util.GetLastChainCard();

            // negate spells
            if (Card.Location == CardLocation.SpellZone)
            {
                int this_seq = -1;
                int that_seq = -1;
                for (int i = 0; i < 5; ++i)
                {
                    if (Bot.SpellZone[i] == Card) this_seq = i;
                    if (LastChainCard != null
                        && LastChainCard.Controller == 1 && LastChainCard.Location == CardLocation.SpellZone && Enemy.SpellZone[i] == LastChainCard) that_seq = i;
                    else if (Duel.Player == 0 && Util.GetProblematicEnemySpell() != null
                        && Enemy.SpellZone[i] != null && Enemy.SpellZone[i].IsFloodgate()) that_seq = i;
                }
                if ((this_seq * that_seq >= 0 && this_seq + that_seq == 4)
                    || (Util.IsChainTarget(Card))
                    || (LastChainCard != null && LastChainCard.Controller == 1 && LastChainCard.IsCode(_CardId.HarpiesFeatherDuster)))
                {
                    List<ClientCard> enemy_monsters = Enemy.GetMonsters();
                    enemy_monsters.Sort(CardContainer.CompareCardAttack);
                    enemy_monsters.Reverse();
                    foreach (ClientCard card in enemy_monsters)
                    {
                        if (card.IsFaceup() && !card.IsShouldNotBeTarget() && !card.IsShouldNotBeSpellTrapTarget())
                        {
                            AI.SelectCard(card);
                            Impermanence_list.Add(this_seq);
                            return true;
                        }
                    }
                }
            }
            if ((LastChainCard == null || LastChainCard.Controller != 1 || LastChainCard.Location != CardLocation.MonsterZone
                || LastChainCard.IsDisabled() || LastChainCard.IsShouldNotBeTarget() || LastChainCard.IsShouldNotBeSpellTrapTarget()))
                return false;
            // negate monsters
            if (is_should_not_negate() && LastChainCard.Location == CardLocation.MonsterZone) return false;
            if (Card.Location == CardLocation.SpellZone)
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (Bot.SpellZone[i] == Card)
                    {
                        Impermanence_list.Add(i);
                        break;
                    }
                }
            }
            if (Card.Location == CardLocation.Hand)
            {
                AI.SelectPlace(SelectSTPlace(Card, true));
            }
            if (LastChainCard != null) AI.SelectCard(LastChainCard);
            else
            {
                List<ClientCard> enemy_monsters = Enemy.GetMonsters();
                enemy_monsters.Sort(CardContainer.CompareCardAttack);
                enemy_monsters.Reverse();
                foreach (ClientCard card in enemy_monsters)
                {
                    if (card.IsFaceup() && !card.IsShouldNotBeTarget() && !card.IsShouldNotBeSpellTrapTarget())
                    {
                        AI.SelectCard(card);
                        return true;
                    }
                }
            }
            return true;
        }
        //灰流丽
        public bool Hand_act_eff()
        {
            return (Duel.LastChainPlayer == 1);
        }
        //干枯头骨
        private bool Xgankushoujingtougu2Summon()
        {
            if (Bot.HasInMonstersZone(CardId.Xshuijinglifangti) && (Bot.GetMonsterCount() >= 4 && Bot.GetMonstersExtraZoneCount() == 0) || (Bot.GetMonsterCount() >= 5 && Bot.GetMonstersExtraZoneCount() >= 1))
            {
                AI.SelectPosition(CardPosition.FaceDownDefence);
                return true;
            }
            else if (Bot.GetMonsterCount() == 1 && !Xshuijinglifangti)
            {
                AI.SelectPosition(CardPosition.FaceDownDefence);
                return true;
            }
            return false;
        }
        //先史遗产 石像
        private bool XmoaishixiangSummon()
        {
            AI.SelectPosition(CardPosition.FaceDownDefence);
            return true;
        }
        //三巨石效果
        private bool XsanjushiEffect2()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Xsanjushi, 0))
            {
                if (Bot.LifePoints <= 500) return false;
                else if (Bot.GetMonstersInMainZone().Count >= 5) return false;
                foreach (ClientCard card in Bot.Hand)
                {
                    if (card != null && card.HasSetcode(0x70) && card.Level <= 4)
                    {
                        AI.SelectCard(card);
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        //先史遗产三巨石
        private bool XsanjushiEffect()
        {
            if (Bot.GetMonsterCount() >= 5 && !Bot.HasInHand(CardId.Xtaiyangdushibei)) return false;
            if (Bot.HasInSpellZone(CardId.Xsanjushi)) return false;
            if (!Xsanjushi) return true;
            return false;
        }
        //先史遗产技术
        private bool XyichanjishuEffect()
        {
            AI.SelectCard(CardId.Xshuijingtougu, CardId.Xhuojian);
            AI.SelectNextCard(CardId.Xshiguan,CardId.Wuxianpaoying,CardId.Zhimingzhe,CardId.Huiliuli);
            Xyichanjishu = true;
            return true;
        }
        //先史遗产 水晶立方体
        //Enemy.GetMonsters().Any(monster => !monster.Equals(defender) && monster.HasType(CardType.Synchro))
        private bool XshuijinglifangtiSummon()
        {
            foreach (ClientCard card in Bot.GetMonsters())
               foreach (ClientCard card2 in Bot.GetMonsters())
                    foreach (ClientCard card3 in Bot.GetMonsters())
                    if ((card.Level == 4 && card != card2 && card2.Level == 4) || (card.Level == 5 && card != card2 && card2.Level == 5))
                    {
                        AI.SelectMaterials(new List<int>() {
                             CardId.Xgankushoujingtougu,
                             CardId.Xhuojian
                          });
                        Xshuijinglifangti = true;
                        return true;
                    }
                    else if (Bot.GetMonsterCount() == 2 && !Bot.HasInMonstersZone(CardId.Xshuijinglifangti) && !Bot.HasInMonstersZone(CardId.Xweimona) && !Bot.HasInMonstersZone(CardId.Xdaxizhoujurens) && !Bot.HasInMonstersZone(CardId.Xdaxizhoujuren))
                    {
                        AI.SelectMaterials(new List<int>() {
                             CardId.Xgankushoujingtougu,
                             CardId.Xhuojian,
                             CardId.Xmoaishixiang,
                             CardId.Xxingxiangpan,
                             CardId.Xmowaladiqiuyi,
                             CardId.Xtuou,
                             CardId.Xacitekemianjuren,
                             CardId.Xshuijingtougu
                          });
                        Xshuijinglifangti = true;
                        return true;
                    }
                    else if(Bot.GetMonsterCount()==3 && card != card2 && card2 !=card3 && card!=card3 && card.Level!=card2.Level && card.Level != card3.Level && card3.Level != card2.Level)
                    {
                            AI.SelectMaterials(new List<int>() {
                             CardId.Xgankushoujingtougu,
                             CardId.Xhuojian,
                             CardId.Xmoaishixiang,
                             CardId.Xxingxiangpan,
                             CardId.Xmowaladiqiuyi,
                             CardId.Xtuou,
                             CardId.Xacitekemianjuren,
                             CardId.Xshuijingtougu
                            });
                            Xshuijinglifangti = true;
                            return true;
                    }
                            return false;
        }
        //先史遗产 干枯头骨
        private bool XgankushoujingtouguEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (!Xdiqiuyi && !Xhuojian)
                {
                    AI.SelectCard(CardId.Xmowaladiqiuyi, CardId.Xxingxiangpan);
                    return true;

                }
                else if (Xdiqiuyi || Xhuojian)
                {
                    AI.SelectCard(CardId.Xxingxiangpan, CardId.Xhuojian);
                    Xxingxiangpan = true;
                    return true;
                }
                else if (Xxingxiangpan)
                {
                    AI.SelectCard(CardId.Xxingxiangpan, CardId.Xhuojian);
                    return true;
                }
                return false;
            }
            else if (Card.Location == CardLocation.Grave)
            {
                if (Util.ChainContainsCard(CardId.Wuxianpaoying) && Duel.LastChainPlayer == 0) return false;
                if (!Xgankushuijingtougu)
                {
                    Xgankushuijingtougu = true;
                    return true;
                }
                return false;
            }
            return false;
        }
        //先史遗产 地球仪
        private bool XmowaladiqiuyiEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (Card.IsDisabled()) return false;
                else  if (!Xhuojian)
                {
                    AI.SelectCard(CardId.Xhuojian, CardId.Xxingxiangpan,CardId.Xmoaishixiang);
                    AI.SelectPosition(CardPosition.FaceUpDefence);
                    Xdiqiuyi = true;
                    return true;
                }
                else if(Xhuojian)
                {
                    AI.SelectCard(CardId.Xxingxiangpan, CardId.Xhuojian, CardId.Xmoaishixiang);
                    AI.SelectPosition(CardPosition.FaceUpDefence);
                    Xdiqiuyi = true;
                    return true;
                }
                return false;
            }
            else if (Card.Location == CardLocation.Grave) return true;
            return false;
        }
        //先史遗产 石纹
        private bool XshiwenEffect()
        {
            AI.SelectCard(CardId.Xchaqiu);
            AI.SelectNextCard(CardId.Xmoaishixiang);
            AI.SelectThirdCard(CardId.Xweimona);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //先史遗产 星象盘
        private bool XxingxiangpanEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (Xshuijinglifangt)
                {
                    AI.SelectCard(CardId.Xshiguan);
                    Xxingxiangpan = true;
                    return true;
                }
                else if(!Xshuijinglifangt)
                {
                    if (Bot.HasInHand(CardId.Xgankushoujingtougu))
                    {
                        AI.SelectCard(CardId.Xshiguan);
                        Xxingxiangpan = true;
                        return true;
                    }
                    else if(!Bot.HasInHand(CardId.Xgankushoujingtougu))
                    {
                        AI.SelectCard(CardId.Xgankushoujingtougu, CardId.Xshiguan);
                        Xxingxiangpan = true;
                        return true;

                    }
                    return false;
                }
                return false;
            }
            else if (Card.Location == CardLocation.Grave)
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }
        //先史遗产 火箭
        private bool XhuojianEffect()
        {
            ClientCard target = Util.GetBestEnemyMonster(true, true);
            AI.SelectCard(CardId.Xtuou);
            if (target != null)
            {
                AI.SelectNextCard(target);
            }
            else
            {
                AI.SelectNextCard(CardId.Xhuojian);
            }
            AI.SelectPosition(CardPosition.FaceUpDefence);
            Xhuojian = true;
            return true;
        }
        //电子龙 无限
        private bool DianzilongwuxianEffect()
        {
            if (Duel.CurrentChain.Count > 0)
            {
                return Duel.LastChainPlayer == 1;
            }
            else
            {
                ClientCard bestmonster = null;
                foreach (ClientCard monster in Enemy.GetMonsters())
                {
                    if (monster.IsAttack() && (bestmonster == null || monster.Attack >= bestmonster.Attack))
                        bestmonster = monster;
                }
                if (bestmonster != null)
                {
                    AI.SelectCard(bestmonster);
                    return true;
                }
            }
            return false;
        }
        //升阶 星光之力
        private bool SxingguangzhiliEffect()
        {
            if (!Bot.HasInMonstersZone(CardId.Xdaxizhoujuren))
            {
                if (Bot.HasInMonstersZone(CardId.Xqineng) || Bot.HasInMonstersZone(CardId.Xchaqiu))
                {
                    AI.SelectCard(CardId.Xqineng, CardId.Xchaqiu);
                    AI.SelectNextCard(CardId.Xdaxizhoujuren);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                return false;
            }
            else if(Bot.HasInMonstersZone(CardId.Xdaxizhoujuren))
            {
                AI.SelectCard(CardId.Xdaxizhoujuren);
                AI.SelectNextCard(CardId.Xdaxizhoujurens);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }
        //异热同心构筑
        private bool YiretongxingouzhuEffect()
        {
            if (Bot.HasInHand(CardId.Shundunzhili) || Bot.HasInHand(CardId.Sxingguangzhili)) return false;
            {
                if (Xyichanjishu)
                {
                    AI.SelectCard(CardId.Xyichanjishu, CardId.Xshiwen);
                    AI.SelectNextCard(CardId.Sxingguangzhili, CardId.Shundunzhili);
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Xshiwen);
                    AI.SelectNextCard(CardId.Sxingguangzhili, CardId.Shundunzhili);
                    return true;
                }
            }
        }
        //先史遗产 水晶立方体
        private bool XshuijinglifangtiEffect()
        {
            foreach (ClientCard card in Bot.GetMonsters())
            foreach (ClientCard card2 in Bot.Hand)
            if (ActivateDescription != Util.GetStringId(CardId.Xshuijinglifangti, 0) && ActivateDescription != Util.GetStringId(CardId.Xshuijinglifangti, 1) && ActivateDescription != Util.GetStringId(CardId.Xshuijinglifangti, 2))
            {
                int i = 0;
                do
                {
                    if (i == 0)
                    {
                        //超量拉怪
                        AI.SelectCard(CardId.Xtuou, CardId.Xmoaishixiang, CardId.Xhuojian, CardId.Xmowaladiqiuyi, CardId.Xxingxiangpan);
                        AI.SelectNextCard(CardId.Xtuou, CardId.Xmoaishixiang, CardId.Xhuojian, CardId.Xmowaladiqiuyi, CardId.Xxingxiangpan);
                        AI.SelectThirdCard(CardId.Xweimona, CardId.Xchaqiu);
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                        i++;
                        return true;
                    }
                    else if (i == 1)
                    {
                            //连接检索
                            if (!Xshuijingtougu)
                            {
                                AI.SelectCard(CardId.Xshuijingtougu, CardId.Xsanjushi, CardId.Xshiguan, CardId.Xgankushoujingtougu);
                            }
                            else if (!Bot.HasInHand(CardId.Xsanjushi) && !Bot.HasInSpellZone(CardId.Xsanjushi) && (!Bot.HasInBanished(CardId.Xsanjushi) && !Bot.HasInGraveyard(CardId.Xsanjushi) ))
                            {
                                AI.SelectCard(CardId.Xsanjushi, CardId.Xshiguan, CardId.Xgankushoujingtougu);
                            }
                            else
                            {
                                AI.SelectCard(CardId.Xshiguan, CardId.Xgankushoujingtougu);
                            }
                        i++;
                        return true;
                    }
                } while (i >= 2); return false;

            }
            else if (ActivateDescription == Util.GetStringId(CardId.Xshuijinglifangti, 0))
            {
                    //检索
                if (!Bot.HasInSpellZone(CardId.Xsanjushi, false, true))
                {
                    AI.SelectCard(CardId.Xmowaladiqiuyi);
                    if ((Bot.GetMonsterCount() <= 3 && Bot.GetMonstersExtraZoneCount() == 0) || (Bot.GetMonsterCount() <= 4 && Bot.GetMonstersExtraZoneCount() >= 1))
                    {
                        if (!Bot.HasInHand(CardId.Xgankushoujingtougu))
                        {
                            AI.SelectNextCard(CardId.Xgankushoujingtougu, CardId.Xtaiyangdushibei);
                        }
                        else
                        {
                            AI.SelectNextCard(CardId.Xtaiyangdushibei, CardId.Xgankushoujingtougu);
                        }
                    }
                    else
                    {
                        AI.SelectNextCard(CardId.Xtaiyangdushibei,CardId.Xgankushoujingtougu);
                    }
                    Xshuijinglifangt = true;
                    return true;
                }
                else if (Bot.HasInSpellZone(CardId.Xsanjushi, false, true))
                {
                    AI.SelectCard(CardId.Xgankushoujingtougu, CardId.Xtaiyangdushibei);
                    if ((Bot.GetMonsterCount() <= 3 && Bot.GetMonstersExtraZoneCount() == 0) || (Bot.GetMonsterCount() <= 4 && Bot.GetMonstersExtraZoneCount() >= 1))
                    {
                        AI.SelectNextCard(CardId.Xgankushoujingtougu,CardId.Xtaiyangdushibei);
                    }
                    else
                    {
                        if (Bot.HasInHand(CardId.Sxingguangzhili) || Bot.HasInHand(CardId.Shundunzhili))
                        {
                            AI.SelectNextCard(CardId.Xtaiyangdushibei, CardId.Xgankushoujingtougu);
                        }
                        else
                        {

                            AI.SelectNextCard(CardId.Xmoaishixiang, CardId.Xgankushoujingtougu, CardId.Xtaiyangdushibei);
                        }
                    }
                    Xshuijinglifangt = true;
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Xmowaladiqiuyi);
                    if ((Bot.GetMonsterCount() <= 3 && Bot.GetMonstersExtraZoneCount() == 0) || (Bot.GetMonsterCount() <= 4 && Bot.GetMonstersExtraZoneCount() >= 1))
                    {
                        AI.SelectNextCard(CardId.Xgankushoujingtougu, CardId.Xtaiyangdushibei);
                    }
                    else
                    {
                        if (Bot.HasInHand(CardId.Sxingguangzhili) || Bot.HasInHand(CardId.Shundunzhili))
                        {
                                if (card.HasType(CardType.Effect) && Bot.HasInHand(CardId.Xtaiyangdushibei))
                                {
                                    AI.SelectNextCard(CardId.Xtaiyangdushibei, CardId.Xgankushoujingtougu);
                                }
                                return false;
                        }
                        else
                        {
                                if(Bot.HasInHand(CardId.Xtaiyangdushibei)) return false;
                                {
                                    AI.SelectNextCard(CardId.Xmoaishixiang, CardId.Xgankushoujingtougu, CardId.Xtaiyangdushibei);
                                }
                        }
                    }
                    Xshuijinglifangt = true;
                    return true;
                }
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Xshuijinglifangti, 1))
            {
                //召唤
                if ((!Xshuijinglifangt && Duel.Player==0) || (Util.ChainContainsCard(CardId.Xshuijinglifangti) && Duel.LastChainPlayer == 0)) return false;
                {
                    if (card2.Level >= 5 ||Bot.GetMonsterCount()>=5 ) return false;
                    else if ((Bot.GetMonsterCount() <= 3 && Bot.GetMonstersExtraZoneCount() == 0) || (Bot.GetMonsterCount() <= 4 && Bot.GetMonstersExtraZoneCount() >= 1))
                    {
                        AI.SelectCard(CardId.Xgankushoujingtougu, CardId.Xxingxiangpan, CardId.Xacitekemianjuren,CardId.Xmowaladiqiuyi,CardId.Xhuojian,CardId.Xshuijingtougu);
                        return true;
                    }
                    else
                    {
                        AI.SelectCard(CardId.Xxingxiangpan, CardId.Xtaiyangdushibei);
                        return true;
                    }
                }
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Xshuijinglifangti, 2))
            {
                if (Duel.LastChainPlayer != 0)
                {
                            ClientCard target = Util.GetLastChainCard();
                            if (target.HasType(CardType.Monster) && target.Attack == 0) return false;
                            {
                                AI.SelectCard(should_select);
                                return true;
                            }
                }
                return false;
            }
            return false;
        }
        //先史遗产 叉丘
        private bool XchaqiuEffect()
        {
            if (Util.ChainContainsCard(CardId.Xgankushoujingtougu) && Duel.LastChainPlayer == 0) return false;
            else if (ActivateDescription == Util.GetStringId(CardId.Xchaqiu, 0)) return true;
            else if (ActivateDescription == Util.GetStringId(CardId.Xchaqiu, 1))
            {
                return false;
            }
            return false;
        }
        //先史遗产 维摩那
        private bool XweimonaEffect()
        {
            foreach (ClientCard card in Bot.GetMonsters())
            if (ActivateDescription == Util.GetStringId(CardId.Xweimona, 0))
            {
                AI.SelectCard(CardId.Xweimona, CardId.Xshuijinglifangti);
                AI.SelectNextCard(CardId.Xmoaishixiang, CardId.Xhuojian, CardId.Xmowaladiqiuyi, CardId.Xxingxiangpan);
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Xweimona, 1))
            {
                ClientCard target = Util.GetLastChainCard();
                if (target.HasType(CardType.Monster) && target.Attack == 0 && card.IsCode(CardId.Xshuijinglifangti) && !card.IsDisabled()) return false;
                return true;
            }
            return false;
        }
        //先史遗产 水晶头骨
        private bool XshuijingtouguEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                AI.SelectCard(CardId.Xgankushoujingtougu);
                Xshuijingtougu = true;
                return true;
            }
            return false;
        }
        //先史遗产 土偶
        private bool XtuouEffect()
        {
            if(Card.Location == CardLocation.Grave)
            {
                if (Bot.LifePoints <= 1000) return false;
                {
                    AI.SelectPosition(CardPosition.FaceDownDefence);
                    return true;
                }
            }
            return false;
        }

    }
}
