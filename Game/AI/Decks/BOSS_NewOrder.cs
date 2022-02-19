using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using System;
using System.Linq;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("BossOrder", "AI_BossOrder", "NotFinished")]
    public class BossOrderExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Senlinenhui = 9951558;
            public const int Hu = 55144522;
            public const int BossDuel = 94720008;
            public const int Shenmishibei = 98710005;
            public const int Xingguangzhili = 98710019;
            public const int NO4 = 98710003;
            public const int NO6 = 98710011;
            public const int NO8 = 98710012;
            public const int NO10 = 98710013;
            public const int NO12 = 98710014;
            public const int NO13 = 98710015;
            public const int Jiejitongzhi = 98710009;
            public const int Shengjiezengyi = 98710016;
            public const int Yitaijiejing = 98710020;
            public const int Xinxuxidanganguan = 98710001;
            public const int Shenghualuoxuan = 98710017;
            public const int Jiejizhibi = 98710018;
            public const int Chaoliangfanshe = 2371506;
            public const int shenmizhijing = 98710022;

            public const int Y13 = 98710010;
            public const int Y12 = 98710008;
            public const int Y10 = 98710007;
            public const int Y8 = 98710006;
            public const int Y6 = 98710004;
            public const int Y4 = 98710002;
            public const int Y0 = 98710021;

            //作弊加卡
            public const int Tianshen = 10010;
            public const int Huigui = 79029456;
            public const int WSzhaohuan = 50007862;
            public const int WSchangdi = 50007866;
            public const int WSjian = 50007873;
            public const int WSN = 50007876;
            public const int WShaima = 50007872;
            public const int WSbianjie = 50007890;
            public const int WSshen = 950038;
            public const int WSS = 50007867;
            public const int Bianhua = 9951559;
            public const int Tonghua = 8824603;
            public const int Yefu = 9950806;

            public const int Mohelp = 8824690;
            public const int Xianhelp = 8824692;
            public const int Guaihelp = 8824693;
        }
        List<int> Impermanence_list = new List<int>();
        bool NO4 = false;
        bool Shenghualuoxuan = false;
        bool Bossduel = false;
        public BossOrderExecutor(GameAI ai, Duel duel)
       : base(ai, duel)
        {
            //人机作弊

            //卡组特召
            AddExecutor(ExecutorType.SpSummon, SummonInDeckEffect);
            //彼岸花
            AddExecutor(ExecutorType.Activate, CardId.Bianhua);
            //夜腐
            AddExecutor(ExecutorType.Activate, CardId.Yefu);
            //同化
            AddExecutor(ExecutorType.Activate, CardId.Tonghua);
            //奥利哈刚 天神荡
            AddExecutor(ExecutorType.Activate, CardId.Tianshen);
            //回归逐流
            AddExecutor(ExecutorType.Activate, CardId.Huigui);
            //无视召唤
            AddExecutor(ExecutorType.Activate, CardId.WSzhaohuan, WSzhaohuanEffect);
            //无视场地
            AddExecutor(ExecutorType.Activate, CardId.WSchangdi);
            //无视海马
            AddExecutor(ExecutorType.SpSummon, CardId.WShaima);
            AddExecutor(ExecutorType.Activate, CardId.WShaima);
            //无视海马之剑
            AddExecutor(ExecutorType.Activate, CardId.WSjian);
            //我要回农村
            AddExecutor(ExecutorType.Activate, CardId.WSN);
            //魔法援助
            AddExecutor(ExecutorType.Activate, CardId.Mohelp);
            //陷阱援助
            AddExecutor(ExecutorType.Activate, CardId.Xianhelp);
            //怪兽援助
            AddExecutor(ExecutorType.Activate, CardId.Guaihelp, GuaihelpEffect);
            //无视边界
            AddExecutor(ExecutorType.Activate, CardId.WSbianjie);
            //无视神
            AddExecutor(ExecutorType.Activate, CardId.WSS);

            //壶
            AddExecutor(ExecutorType.Activate, CardId.Hu);
            //恩惠
            AddExecutor(ExecutorType.Activate, CardId.Senlinenhui);
            //阶级之壁
            AddExecutor(ExecutorType.Activate, CardId.Jiejizhibi);
            //NO13
            AddExecutor(ExecutorType.Activate, CardId.NO13, NO13Effect);
            //神秘之境
            AddExecutor(ExecutorType.Activate, CardId.shenmizhijing, shenmizhijingEffect);
            //升华螺旋
            AddExecutor(ExecutorType.Activate, CardId.Shenghualuoxuan, ShenghualuoxuanEffect);
            //超量反射
            AddExecutor(ExecutorType.Activate, CardId.Chaoliangfanshe);
            //BOSS规则代替抽卡
           AddExecutor(ExecutorType.Activate, CardId.BossDuel, BossDuelEffect2);
            //BOSS规则
           AddExecutor(ExecutorType.Activate, CardId.BossDuel, BossDuelEffect);
            //BOSS规则宣言
            //AddExecutor(ExecutorType.Activate, CardId.BossDuel, BossDuelEffect3);
            //新序4
            AddExecutor(ExecutorType.SpSummon, CardId.Y4, Y4Summon);
            //NO4
            AddExecutor(ExecutorType.Activate, CardId.NO4, NO4Effect);
            //以太档案馆 发动
            AddExecutor(ExecutorType.Activate, CardId.Xinxuxidanganguan, XinxuxidanganguanEffect2);
            //以太档案馆
            AddExecutor(ExecutorType.Activate, CardId.Xinxuxidanganguan, XinxuxidanganguanEffect);
            //以太结晶
            AddExecutor(ExecutorType.Activate, CardId.Yitaijiejing, YitaijiejingEffect);
            //升阶增益
            AddExecutor(ExecutorType.Activate, CardId.Shengjiezengyi, ShengjiezengyiEffect);
            //阶级统治
            AddExecutor(ExecutorType.Activate, CardId.Jiejitongzhi, JiejitongzhiEffect);
            //星光之力
            AddExecutor(ExecutorType.Activate, CardId.Xingguangzhili, XingguangzhiliEffect);
            //神秘石碑不发动
            // AddExecutor(ExecutorType.Activate, CardId.Shenmishibei, ShenmishibeiEffect2);
            //神秘石碑
            AddExecutor(ExecutorType.Activate, CardId.Shenmishibei, ShenmishibeiEffect);
            //NO12
            AddExecutor(ExecutorType.Activate, CardId.NO12, NO12Effect);
            //NO10
            AddExecutor(ExecutorType.Activate, CardId.NO10, NO10Effect);
            //NO8
            AddExecutor(ExecutorType.Activate, CardId.NO8, NO8Effect);
            //NO6
            AddExecutor(ExecutorType.Activate, CardId.NO6, NO6Effect);

            //新序0
            AddExecutor(ExecutorType.SpSummon, CardId.Y0, Y0Summon);
            //新序0
            AddExecutor(ExecutorType.Activate, CardId.Y0, Y0Effect);
            //新序4
            AddExecutor(ExecutorType.Activate, CardId.Y4, Y4Effect);
            //新序6
            AddExecutor(ExecutorType.Activate, CardId.Y6, Y6Effect);
            //新序6 对方回合
            //AddExecutor(ExecutorType.Activate, CardId.Y6, Y6Effect3);
            //新序6 特殊召唤
            // AddExecutor(ExecutorType.Activate, CardId.Y6, Y6Effect2);
            //新序8
            AddExecutor(ExecutorType.Activate, CardId.Y8, Y8Effect);
            //新序检索
            // AddExecutor(ExecutorType.Activate, CardId.Y8, Y8Effect2);
            //新序10
            AddExecutor(ExecutorType.Activate, CardId.Y10, Y10Effect);
            //新序12
            AddExecutor(ExecutorType.Activate, CardId.Y12, Y12Effect);
            //新序13
            AddExecutor(ExecutorType.Activate, CardId.Y13, Y13Effect);
            //放置
            AddExecutor(ExecutorType.SpellSet, SpellSetEffect);
    
        }
        //超量选择
        List<int> should_select = new List<int>
        {
           CardId.NO4,CardId.NO6,CardId.NO8,CardId.NO10,CardId.NO12,
        };
        //发动选择
        List<int> active_select = new List<int>
        {
           CardId.Senlinenhui,CardId.Hu,CardId.Jiejitongzhi,CardId.Shengjiezengyi
        };
        //超量检查
        public int Rank(int id)
        {
            if (id == CardId.NO13) return 13;
            else if (id == CardId.NO12) return 12;
            else if (id == CardId.NO10) return 10;
            else if (id == CardId.NO8) return 8;
            else if (id == CardId.NO6) return 6;
            else if (id == CardId.NO4) return 4;
            return 0;
        }
        //计数专用
        public override void OnNewTurn()
        {
            NO4 = false;
            Shenghualuoxuan = false;
            Bossduel = false;
        }
        //选择表示形式设置 
        public override CardPosition OnSelectPosition(int cardId, IList<CardPosition> positions)
        {
            switch (cardId)
            {
                case CardId.Y0:
                    return CardPosition.FaceUpAttack;
                default:
                    return base.OnSelectPosition(cardId, positions);
            }
        }
        //卡组检查
        public int CheckRemainInDeck(int id)
        {
            switch (id)
            {
                case CardId.Senlinenhui:
                    return Bot.GetRemainingCount(CardId.Senlinenhui, 3);
                case CardId.Hu:
                    return Bot.GetRemainingCount(CardId.Hu, 3);
                case CardId.BossDuel:
                    return Bot.GetRemainingCount(CardId.BossDuel, 1);
                case CardId.Shenmishibei:
                    return Bot.GetRemainingCount(CardId.Shenmishibei, 3);
                case CardId.Xingguangzhili:
                    return Bot.GetRemainingCount(CardId.Xingguangzhili, 3);
                case CardId.NO4:
                    return Bot.GetRemainingCount(CardId.NO4, 3);
                case CardId.NO6:
                    return Bot.GetRemainingCount(CardId.NO6, 2);
                case CardId.NO8:
                    return Bot.GetRemainingCount(CardId.NO8, 2);
                case CardId.NO10:
                    return Bot.GetRemainingCount(CardId.NO10, 2);
                case CardId.NO12:
                    return Bot.GetRemainingCount(CardId.NO12, 2);
                case CardId.NO13:
                    return Bot.GetRemainingCount(CardId.NO13, 2);
                case CardId.Jiejitongzhi:
                    return Bot.GetRemainingCount(CardId.Jiejitongzhi, 2);
                case CardId.Shengjiezengyi:
                    return Bot.GetRemainingCount(CardId.Shengjiezengyi, 2);
                case CardId.Yitaijiejing:
                    return Bot.GetRemainingCount(CardId.Yitaijiejing, 1);
                case CardId.Xinxuxidanganguan:
                    return Bot.GetRemainingCount(CardId.Xinxuxidanganguan, 2);
                case CardId.Shenghualuoxuan:
                    return Bot.GetRemainingCount(CardId.Shenghualuoxuan, 2);
                case CardId.Jiejizhibi:
                    return Bot.GetRemainingCount(CardId.Jiejizhibi, 3);
                case CardId.Chaoliangfanshe:
                    return Bot.GetRemainingCount(CardId.Chaoliangfanshe, 2);
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
        //卡组特召
        private bool SummonInDeckEffect()
        {
            if (Card.Location == CardLocation.Deck) return true;
            return false;
        }
        //以太档案馆应该破坏的卡
        List<int> should_destory = new List<int>
        {
            CardId.Xingguangzhili,CardId.Hu,CardId.Senlinenhui,CardId.Jiejizhibi,CardId.Chaoliangfanshe,
            CardId.Shenghualuoxuan
        };
        //阶级统治
        private bool JiejitongzhiEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.HasInSpellZone(CardId.Jiejitongzhi, true, true)) return false;
                return true;
            }
            return false;
        }
        //怪兽援助
        private bool GuaihelpEffect()
        {
            if (Duel.Phase == DuelPhase.Standby || Bot.GetMonstersInMainZone().Count >= 5) return false;
            {
                AI.SelectAnnounceID(CardId.WSS);
                return true;
            }
        }
        //无视召唤
        private bool WSzhaohuanEffect()
        {
            AI.SelectCard(CardId.NO4);
            AI.SelectNextCard(CardId.Y13, CardId.Y12, CardId.Y10, CardId.Y8, CardId.Y6, CardId.Y4);
            return true;
        }
        //魔陷放置
        private bool SpellSetEffect()
        {
            if (Bot.Hand.Count > 6)
            {
                return Card.IsTrap() && Bot.GetSpellCountWithoutField() < 4;
            }
            return false;
        }
        //神秘之镜
        private bool shenmizhijingEffect()
        {
            if (Duel.Phase > DuelPhase.Main1 && Duel.Phase < DuelPhase.Main2 && Duel.Player == 1 && Bot.GetMonsterCount() > 0)
            {
                if (Enemy.BattlingMonster.Attack > Bot.BattlingMonster.GetDefensePower()) return true;
                return false;
            }
            return false;
        }
        //以太结晶
        private bool YitaijiejingEffect()
        {
            if (Duel.Player != 0 || Duel.Phase != DuelPhase.End || Bot.HasInMonstersZone(CardId.Y13)) return false;
            return true;
        }
        //以太档案馆 发动
        private bool XinxuxidanganguanEffect2()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.HasInSpellZone(CardId.Xinxuxidanganguan, true) || Bot.HasInSpellZone(CardId.Huigui, true) || Bot.HasInSpellZone(CardId.WSchangdi, true)) return false;
                return true;

            }
            return false;
        }
        //新序0
        private bool Y0Summon()
        {
            if (!Bot.HasInExtra(CardId.Y13) || Bot.GetCountCardInZone(Bot.MonsterZone, CardId.Y13) >= 2) return false;
            {
                foreach (ClientCard card in Bot.GetMonsters())
                    foreach (ClientCard card2 in Bot.GetMonsters())
                        //if (Rank(card.Id) < 13 && Rank(card.Id) >= 4 && Rank(card2.Id) < 13 && Rank(card2.Id) >= 4 && Rank(card2.Id) != Rank(card.Id))
                        if ((card.Rank == 4 || card.Rank == 6 || card.Rank == 8 || card.Rank == 10 || card.Rank == 12) && (card2.Rank == 4 || card2.Rank == 6 || card2.Rank == 8 || card2.Rank == 10 || card2.Rank == 12) && card.Rank != card2.Rank && card.HasSetcode(0xd107) && card2.HasSetcode(0xd107))
                        {
                            AI.SelectPosition(CardPosition.FaceUpAttack);
                            List<ClientCard> bot_monsters = Bot.GetMonsters();
                            bot_monsters.Sort(CardContainer.CompareCardAttack);
                            //bot_monsters.Reverse();
                            AI.SelectPosition(CardPosition.FaceUpAttack);
                            AI.SelectMaterials(bot_monsters);
                            AI.SelectPosition(CardPosition.FaceUpAttack);
                            AI.SelectPlace(Zones.z5 | Zones.z6);
                            return true;
                            //  }
                        }
            }
            return false;
        }
        private bool CheckDifferent(List<ClientCard> clients)
        {
            int check = 0; 
            int check2 = 0; 
            bool result = false;
            for (int num = 1; num < clients.Count; num++)
            {
                //8 8 4 4
                check = clients[num-1].Rank;
                check2 = clients[num].Rank;
                if (check != check2)
                {
                    result = true;
                    break;
                }

            }
            return result;
        }
        //新序0 效果
        private bool Y0Effect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Y0, 0))
            {
                AI.SelectCard(CardId.Y12, CardId.Y10, CardId.Y8, CardId.Y6, CardId.Y4);
                return true;
            }
            else
            {
                AI.SelectCard(CardId.Y10);
                AI.SelectNextCard(CardId.Y13);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                AI.SelectPlace(Zones.z5 | Zones.z6);
                return true;
            }
        }
        //新序13
        private bool Y13Effect()
        {
            if (Bot.HasInExtra(CardId.Y13))
            {
                AI.SelectCard(CardId.Guaihelp, CardId.Tianshen, CardId.Y13, CardId.Jiejitongzhi, CardId.Shengjiezengyi, CardId.NO12, CardId.NO10);
            }
            else if (!Bot.HasInHandOrInSpellZone(CardId.Jiejizhibi))
            {
                AI.SelectCard(CardId.Guaihelp, CardId.Tianshen, CardId.Jiejizhibi, CardId.Jiejitongzhi, CardId.Shengjiezengyi, CardId.NO12, CardId.NO10);
            }
            else
            {
                AI.SelectCard(CardId.Guaihelp, CardId.Tianshen, CardId.Jiejitongzhi, CardId.Shengjiezengyi, CardId.NO12, CardId.NO10);
            }
            return true;
        }
        //星光之力
        private bool XingguangzhiliEffect()
        {
            if (Bot.HasInMonstersZone(CardId.Y13)) return false;
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                AI.SelectCard(CardId.NO4);
                AI.SelectNextCard(CardId.NO6);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
        }
        //升阶增益
        private bool ShengjiezengyiEffect()
        {
            if (Bot.Deck.Count >= 1) return true;
            return false;
        }
        //以太档案馆
        private bool XinxuxidanganguanEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Xinxuxidanganguan, 0))
            {
                ClientCard last_card = Util.GetLastChainCard();
                if (last_card != null && last_card.Controller == 0 && last_card.IsCode(should_destory)) return true;
                else if (Duel.Player == 1 && !Bot.HasInMonstersZone(CardId.Yitaijiejing) && CheckRemainInDeck(CardId.Yitaijiejing) > 0) return true;
                else if (last_card != null && last_card.Controller == 1 && (last_card.HasType(CardType.Field) || last_card.HasType(CardType.Continuous)) && !last_card.IsCode(CardId.Jiejitongzhi)) return true;
                return false;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Xinxuxidanganguan, 1))
            {
                AI.SelectCard(CardId.Y4);
                AI.SelectNextCard(CardId.Y6);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }
        //升华螺旋
        private bool ShenghualuoxuanEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                Shenghualuoxuan = true;
                return Duel.LastChainPlayer == -1 && Duel.LastSummonPlayer != 0;
            }
            else
            {
                if (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0 && Bot.GetMonstersInMainZone().Count >= 4) return false;
                AI.SelectCard(CardId.NO10);
                AI.SelectNextCard(CardId.NO12);
                return true;
            }
        }
        //新序4
        private bool Y4Summon()
        {
            AI.SelectMaterials(CardId.Shenmishibei);
            AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }
        //新序4
        private bool Y4Effect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Y4, 0)) return true;
            else if (ActivateDescription != Util.GetStringId(CardId.Y4, 0))
            {
                AI.SelectCard(CardId.Shenmishibei);
                if ((!Bot.HasInHandOrInSpellZone(CardId.Jiejitongzhi) && !Enemy.HasInHandOrInSpellZone(CardId.Jiejitongzhi)) && CheckRemainInDeck(CardId.Jiejitongzhi) > 0)
                {
                    if (!Bot.HasInHandOrInSpellZone(CardId.Jiejizhibi) && CheckRemainInDeck(CardId.Jiejizhibi) > 0)
                    {
                        AI.SelectNextCard(CardId.Jiejitongzhi);
                        AI.SelectThirdCard(CardId.Jiejizhibi);
                    }
                    else
                    {
                        AI.SelectNextCard(CardId.Jiejitongzhi);
                        if (Duel.Player == 0)
                        {
                            AI.SelectThirdCard(CardId.Xingguangzhili, CardId.Shenghualuoxuan);
                        }
                        else
                        {
                            AI.SelectThirdCard(CardId.NO13, CardId.shenmizhijing);
                        }
                    }
                }
                else if (!Bot.HasInGraveyard(CardId.Shenghualuoxuan) && !Shenghualuoxuan && CheckRemainInDeck(CardId.Shenghualuoxuan) > 0)
                {

                    if (!Bot.HasInHandOrInSpellZone(CardId.Jiejizhibi) && CheckRemainInDeck(CardId.Jiejizhibi) > 0)
                    {
                        AI.SelectNextCard(CardId.Shenghualuoxuan);
                        AI.SelectThirdCard(CardId.Jiejizhibi);
                    }
                    else
                    {
                        AI.SelectNextCard(CardId.Shenghualuoxuan);
                        if (Duel.Player == 0)
                        {
                            AI.SelectThirdCard(CardId.Xingguangzhili);
                        }
                        else
                        {
                            AI.SelectThirdCard(CardId.NO13, CardId.shenmizhijing);
                        }
                    }
                }
                else
                {
                    AI.SelectNextCard(CardId.Shenghualuoxuan);
                    AI.SelectThirdCard(CardId.NO6, CardId.NO8);
                }
                return true;
            }
            return false;
        }
        //新序12
        private bool Y12Effect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Y12, 0))
            {
                if (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0) return false;
                else if (Bot.HasInHand(CardId.NO13) && Bot.HasInExtra(CardId.Y13)) return false;
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Y12, 1)) return true;
            else if (ActivateDescription == Util.GetStringId(CardId.Y12, 2))
            {
                if ((Enemy.GetSpellCount() == 1 && Enemy.HasInSpellZone(CardId.Jiejitongzhi)) || (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0)) return false;
                else if (Enemy.HasInSpellZone(CardId.Jiejitongzhi, true, true) && !Bot.HasInSpellZone(CardId.Jiejitongzhi, true, true) && Duel.Player == 1 && Duel.Phase != DuelPhase.End) return false;
                else if (Enemy.HasInSpellZone(CardId.Jiejitongzhi, true, true) && Enemy.GetSpellCount() <= 1) return false;
                return true;
            }
            return false;
        }
        //新序10
        private bool Y10Effect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Y10, 0))
            {
                if (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0 && (Util.ChainContainsCard(CardId.Y13) || Util.ChainContainsCard(CardId.Y10) || Util.ChainContainsCard(CardId.Xinxuxidanganguan) || Util.ChainContainsCard(CardId.NO4) || Util.ChainContainsCard(CardId.Jiejizhibi))) return false;
                else if (Enemy.GetMonsterCount() + Enemy.GetSpellCount() >= 2) return true;
                return false;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Y10, 1))
            {
                AI.SelectCard(CardId.Y8);
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Y10, 2))
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }
        //新序6 
        private bool Y6Effect2()
        {
            //2是复制效果
            if (ActivateDescription == Util.GetStringId(CardId.Y6, 3))
            {
                // if (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0 && !Util.ChainContainsCard(CardId.Y6)) return false;
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }
        //新序6 对方回合
        private bool Y6Effect3()
        {
            if (Duel.Player == 1)
            {
                ClientCard LastChainCard = Util.GetLastChainCard();
                if (ActivateDescription == Util.GetStringId(CardId.Y6, 0))
                {
                    if (LastChainCard != null && LastChainCard.Location == CardLocation.MonsterZone && !LastChainCard.IsDisabled())
                    {
                        AI.SelectCard(CardId.Y4);
                        AI.SelectNextCard(LastChainCard);
                        return true;
                    }
                    return false;
                }
                else
                {
                    if (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0 && Util.ChainContainsCard(CardId.Y8)) return false;
                    else if (CheckRemainInDeck(CardId.Xingguangzhili) > 0)
                    {
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                        AI.SelectCard(CardId.Xingguangzhili);
                        AI.SelectNextCard(CardId.NO6);
                        AI.SelectThirdCard(CardId.NO8);
                        return true;
                    }
                    else if (CheckRemainInDeck(CardId.Shenmishibei) > 0)
                    {
                        AI.SelectCard(CardId.Shenmishibei);
                        AI.SelectNextCard(CardId.Xingguangzhili, CardId.NO13);
                        AI.SelectYesNo(false);
                        return true;
                    }
                    else if (!Bot.HasInHandOrInGraveyard(CardId.NO13))
                    {
                        AI.SelectCard(CardId.NO13);
                        return true;
                    }
                    else
                    {
                        AI.SelectCard(CardId.NO8, CardId.NO12, CardId.NO10);
                        return true;
                    }
                }
            }
            return false;
        }
        //新序6
        private bool Y6Effect()
        {
            ClientCard LastChainCard = Util.GetLastChainCard();
            //
            if (ActivateDescription == Util.GetStringId(CardId.Y6, 0))
            {
                if (LastChainCard != null && LastChainCard.Location == CardLocation.MonsterZone && !LastChainCard.IsDisabled())
                {
                    AI.SelectCard(CardId.Y4);
                    AI.SelectNextCard(LastChainCard);
                    return true;
                }
                return false;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Y6, 2))
            {
                if (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0 && Util.ChainContainsCard(CardId.Y8)) return false;
                else if (CheckRemainInDeck(CardId.Xingguangzhili) > 0)
                {
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    AI.SelectCard(CardId.Xingguangzhili);
                    AI.SelectNextCard(CardId.NO6);
                    AI.SelectThirdCard(CardId.NO8);
                    return true;
                }
                else if (CheckRemainInDeck(CardId.Shenmishibei) > 0)
                {
                    AI.SelectCard(CardId.Shenmishibei);
                    AI.SelectNextCard(CardId.Xingguangzhili, CardId.NO13);
                    AI.SelectYesNo(false);
                    return true;
                }
                else if (!Bot.HasInHandOrInGraveyard(CardId.NO13))
                {
                    AI.SelectCard(CardId.NO13);
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.NO8, CardId.NO12, CardId.NO10);
                    return true;
                }
            }
            else
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
        }
        //新序8 
        private bool Y8Effect2()
        {
            if (CheckRemainInDeck(CardId.Xingguangzhili) > 0)
            {
                AI.SelectCard(CardId.Xingguangzhili);
                return true;
            }
            else if (!Bot.HasInHandOrInSpellZone(CardId.Jiejizhibi) && CheckRemainInDeck(CardId.Jiejizhibi) > 0)
            {
                AI.SelectCard(CardId.Jiejizhibi);
                return true;
            }
            else if (!Bot.HasInHand(CardId.Shenghualuoxuan) && CheckRemainInDeck(CardId.Shenghualuoxuan) > 0)
            {
                AI.SelectCard(CardId.Shenghualuoxuan);
                return true;
            }
            else if (!Bot.HasInHandOrInSpellZone(CardId.Shengjiezengyi) && CheckRemainInDeck(CardId.Shengjiezengyi) > 0)
            {
                AI.SelectCard(CardId.Shengjiezengyi);
                return true;
            }
            else
            {
                AI.SelectCard(CardId.NO12, CardId.NO10, CardId.NO8);
                return true;
            }
        }
        //新序8
        private bool Y8Effect()
        {
            //1 是手卡发动  2是特殊召唤 0都不是 
            if (ActivateDescription == Util.GetStringId(CardId.Y8, 2))
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Y8, 1))
            {
                if (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0 && !Util.ChainContainsCard(CardId.Y8))
                {
                    if (!Bot.HasInHandOrInGraveyard(CardId.NO13)) return false;
                    {
                        AI.SelectCard(CardId.Y6);
                        AI.SelectNextCard(CardId.NO13, CardId.Xingguangzhili);
                    }
                    return true;
                }
                return false;
            }
            else
            {
                if (!Bot.HasInHandOrInGraveyard(CardId.NO13) && CheckRemainInDeck(CardId.NO13) > 0)
                {
                    AI.SelectCard(CardId.NO13);
                    return true;
                }
                if (CheckRemainInDeck(CardId.Xingguangzhili) > 0)
                {
                    AI.SelectCard(CardId.Xingguangzhili);
                    return true;
                }
                else if (!Bot.HasInHandOrInSpellZone(CardId.Jiejizhibi) && CheckRemainInDeck(CardId.Jiejizhibi) > 0)
                {
                    AI.SelectCard(CardId.Jiejizhibi);
                    return true;
                }
                else if (!Bot.HasInHandOrInSpellZone(CardId.Shenghualuoxuan) && CheckRemainInDeck(CardId.Shenghualuoxuan) > 0)
                {
                    AI.SelectCard(CardId.Shenghualuoxuan);
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.NO12, CardId.NO10, CardId.NO8);
                    return true;
                }
            }

        }
        //神秘石碑不发动
        private bool ShenmishibeiEffect2()
        {
            return true;
        }
        //神秘石碑
        private bool ShenmishibeiEffect()
        {
            if (Duel.Player == 1)
            {
                if (Duel.Player == 0 && CheckRemainInDeck(CardId.Shenmishibei) > 0)
                {
                    AI.SelectYesNo(true);
                    AI.SelectCard(CardId.Shenmishibei);
                }
                else if (!Bot.HasInHand(CardId.NO4) && !NO4 && CheckRemainInDeck(CardId.NO4) > 0)
                {
                    AI.SelectYesNo(true);
                    AI.SelectCard(CardId.NO4);
                }
                else if (CheckRemainInDeck(CardId.Xingguangzhili) > 0)
                {
                    AI.SelectYesNo(true);
                    AI.SelectCard(CardId.Xingguangzhili);
                }
                else
                {
                    AI.SelectYesNo(true);
                    AI.SelectCard(CardId.Shenmishibei);
                }
                AI.SelectYesNo(true);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            else if (Duel.Player == 0)
            {
                if (Duel.Player == 0 && CheckRemainInDeck(CardId.Shenmishibei) > 0)
                {
                    if ((CheckRemainInDeck(CardId.Shenmishibei) == 0 && Bot.GetCountCardInZone(Bot.MonsterZone, CardId.Shenmishibei) >= 2 || (Bot.GetMonstersInMainZone().Count >= 4 && Bot.GetCountCardInZone(Bot.MonsterZone, CardId.Shenmishibei) == 0)))
                    {
                        AI.SelectCard(CardId.Shenmishibei);
                        AI.SelectYesNo(false);
                        return true;
                    }
                    else
                    {
                        AI.SelectCard(CardId.Shenmishibei);
                        AI.SelectYesNo(true);
                        AI.SelectPosition(CardPosition.FaceUpDefence);
                        return true;
                    }
                }
                else if (Bot.GetCountCardInZone(Bot.MonsterZone, CardId.Shenmishibei) >= 2)
                {
                    if (CheckRemainInDeck(CardId.Xingguangzhili) > 0)
                    {
                        AI.SelectCard(CardId.Xingguangzhili);
                    }
                    else if (CheckRemainInDeck(CardId.Jiejizhibi) > 0 && !Bot.HasInHandOrInSpellZone(CardId.Jiejizhibi))
                    {
                        AI.SelectCard(CardId.Jiejizhibi);
                    }
                    else if (CheckRemainInDeck(CardId.Shengjiezengyi) > 0 && !Bot.HasInHandOrInSpellZone(CardId.Shengjiezengyi))
                    {
                        AI.SelectCard(CardId.Shengjiezengyi);
                    }
                    else if (!Bot.HasInHand(CardId.NO13) && CheckRemainInDeck(CardId.NO13) > 0)
                    {
                        AI.SelectCard(CardId.Shenghualuoxuan);
                    }
                    else
                    {
                        AI.SelectCard(CardId.Shenghualuoxuan);
                    }
                    AI.SelectYesNo(false);
                    return true;
                }
                else if (CheckRemainInDeck(CardId.Xingguangzhili) > 0)
                {
                    if ((CheckRemainInDeck(CardId.Shenmishibei) == 0 && Bot.GetCountCardInZone(Bot.MonsterZone, CardId.Shenmishibei) >= 2 || (Bot.GetMonstersInMainZone().Count >= 4 && Bot.GetCountCardInZone(Bot.MonsterZone, CardId.Shenmishibei) == 0)))
                    {
                        AI.SelectCard(CardId.Xingguangzhili);
                        AI.SelectYesNo(false);
                        return true;
                    }
                    else
                    {
                        AI.SelectCard(CardId.Xingguangzhili);
                        AI.SelectYesNo(true);
                        AI.SelectPosition(CardPosition.FaceUpDefence);
                        return true;
                    }
                }
                else if (!Bot.HasInHand(CardId.NO4) && !NO4 && CheckRemainInDeck(CardId.NO4) > 0)
                {
                    if ((CheckRemainInDeck(CardId.Shenmishibei) == 0 && Bot.GetCountCardInZone(Bot.MonsterZone, CardId.Shenmishibei) >= 2 || (Bot.GetMonstersInMainZone().Count >= 4 && Bot.GetCountCardInZone(Bot.MonsterZone, CardId.Shenmishibei) == 0)))
                    {
                        AI.SelectCard(CardId.NO4);
                        AI.SelectYesNo(false);
                        return true;
                    }
                    else
                    {
                        AI.SelectCard(CardId.NO4);
                        AI.SelectYesNo(true);
                        AI.SelectPosition(CardPosition.FaceUpDefence);
                        return true;
                    }
                }
                else
                {
                    if ((CheckRemainInDeck(CardId.Shenmishibei) == 0 && Bot.GetCountCardInZone(Bot.MonsterZone, CardId.Shenmishibei) >= 2 || (Bot.GetMonstersInMainZone().Count >= 4 && Bot.GetCountCardInZone(Bot.MonsterZone, CardId.Shenmishibei) == 0)))
                    {
                        AI.SelectCard(CardId.Shenmishibei);
                        AI.SelectYesNo(false);
                        return true;
                    }
                    else
                    {
                        AI.SelectCard(CardId.Shenmishibei);
                        AI.SelectYesNo(true);
                        AI.SelectPosition(CardPosition.FaceUpDefence);
                        return true;
                    }
                }
            }
            return false;
        }
        //Boss规则代替抽卡
        private bool BossDuelEffect2()
        {
            //ClientCard card = Util.GetLastChainCard();
            if (Duel.Player == 0)
            {
                if (ActivateDescription != Util.GetStringId(CardId.BossDuel, 7) && ActivateDescription != Util.GetStringId(CardId.BossDuel, 8) && ActivateDescription != Util.GetStringId(CardId.BossDuel, 4) && ActivateDescription != Util.GetStringId(CardId.BossDuel, 5) && !Bossduel)
                {
                    AI.SelectCard(CardId.Shenmishibei, CardId.NO4, CardId.Xingguangzhili);
                    Bossduel = true;
                    return true;
                }
                return false;
            }
            return false;
        }
        //Boss规则
        private bool BossDuelEffect()
        {
            //放置宣言发动
            /* if (ActivateDescription == Util.GetStringId(CardId.BossDuel, 8) && Bot.GetFieldSpellCard() == null && Duel.Phase == DuelPhase.Standby)
             {
                 AI.SelectAnnounceID(CardId.Xinxuxidanganguan);
                 return true;
             }
             */
            if (ActivateDescription == Util.GetStringId(CardId.BossDuel, 7))
            {
                if (!Bot.HasInHand(active_select) && !Bot.HasInHand(CardId.Shenmishibei)) return false;
                {
                    //Bot.HasInHand(CardId.Shenmishibei) || 
                    if (Duel.CurrentChain.Count > 0 && Util.ChainContainsCard(CardId.BossDuel) && Duel.LastChainPlayer == 0) return false;
                    else if (!Bot.HasInHand(active_select) && (Bot.HasInHand(CardId.Xinxuxidanganguan) || Bot.HasInHand(CardId.Shenmishibei)) && Duel.Player == 0) return false;
                    else if (!Bot.HasInHand(active_select) && Bot.HasInHand(CardId.Xinxuxidanganguan) && Duel.Player == 1) return false;
                    else if (Bot.HasInHand(CardId.Shenmishibei) && Duel.Player == 1)
                    {
                        if (CheckRemainInDeck(CardId.Shenmishibei) > 0)
                        {
                            AI.SelectCard(CardId.Shenmishibei);
                            AI.SelectNextCard(CardId.Shenmishibei, CardId.Xingguangzhili, CardId.Jiejizhibi);
                            AI.SelectYesNo(false);
                            return true;
                        }
                        else if (!Bot.HasInHand(CardId.NO4) && !NO4)
                        {
                            AI.SelectCard(CardId.Shenmishibei);
                            AI.SelectNextCard(CardId.NO4, CardId.Xingguangzhili, CardId.Jiejizhibi);
                            AI.SelectYesNo(false);
                            return true;
                        }
                        else if (!Bot.HasInHandOrInSpellZone(CardId.Jiejitongzhi) && !Enemy.HasInSpellZone(CardId.Jiejitongzhi))
                        {
                            AI.SelectCard(CardId.Shenmishibei);
                            AI.SelectNextCard(CardId.Jiejitongzhi, CardId.Xingguangzhili, CardId.Jiejizhibi);
                            AI.SelectYesNo(false);
                            return true;
                        }
                        else if (!Bot.HasInHandOrInSpellZone(CardId.Shengjiezengyi))
                        {
                            AI.SelectCard(CardId.Shenmishibei);
                            AI.SelectNextCard(CardId.Shengjiezengyi, CardId.Xingguangzhili, CardId.Jiejizhibi);
                            AI.SelectYesNo(false);
                            return true;
                        }
                        else
                        {
                            AI.SelectCard(CardId.Shenmishibei);
                            AI.SelectNextCard(CardId.Xingguangzhili, CardId.Jiejizhibi);
                            AI.SelectYesNo(false);
                            return true;
                        }
                    }
                    else if (Bot.HasInHand(CardId.Shengjiezengyi))
                    {
                        if (Bot.HasInSpellZone(CardId.Shengjiezengyi)) return false;
                        {
                            AI.SelectCard(CardId.Shengjiezengyi);
                            return true;
                        }
                    }
                    else if (Bot.HasInHand(CardId.Jiejitongzhi))
                    {
                        if (Bot.HasInSpellZone(CardId.Jiejitongzhi)) return false;
                        {
                            AI.SelectCard(CardId.Jiejitongzhi);
                            return true;
                        }
                    }
                    else if (Bot.HasInHand(CardId.Hu))
                    {
                        AI.SelectCard(CardId.Hu, CardId.Senlinenhui, CardId.Xingguangzhili);
                        return true;
                    }
                    else if (Bot.HasInHand(CardId.Senlinenhui))
                    {
                        AI.SelectCard(CardId.Senlinenhui);
                        return true;
                    }
                    else if (Bot.HasInHand(CardId.Xingguangzhili) && !Bot.HasInMonstersZone(CardId.Y13))
                    {
                        AI.SelectCard(CardId.Xingguangzhili);
                        return true;
                    }
                    return false;
                }
            }
            else if (ActivateDescription == Util.GetStringId(CardId.BossDuel, 4) && Duel.Phase == DuelPhase.Main1 && Duel.Player == 0)
            {
                ClientCard target = Util.GetBestEnemyCard();
                if (Enemy.GetMonsterCount() + Enemy.GetSpellCount() == 1 && Enemy.HasInSpellZone(CardId.Jiejitongzhi)) return false;
                else if (target != null && !target.IsCode(CardId.Jiejitongzhi))
                {
                    AI.SelectCard(target);
                    return true;
                }
                return false;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.BossDuel, 5) && Duel.Phase == DuelPhase.Main1 && Duel.Player == 0)
            {
                if (Enemy.GetMonsterCount() >= Bot.GetMonsterCount() && Bot.GetMonstersInMainZone().Count <= 4)
                {
                    AI.SelectAnnounceID(CardId.Y13);
                    return true;
                }
                else if (Enemy.LifePoints <= 1500)
                {
                    AI.SelectAnnounceID(CardId.Bianhua);
                    return true;
                }
                else if (!Bot.HasInMonstersZone(CardId.Yefu) && Bot.GetMonstersInMainZone().Count <= 4)
                {
                    AI.SelectAnnounceID(CardId.Yefu);
                    return true;
                }
                else if (!Bot.HasInSpellZone(CardId.Xinxuxidanganguan))
                {
                    AI.SelectAnnounceID(CardId.WSchangdi);
                    return true;
                }
                else if (Bot.HasInExtra(CardId.Y13) && Bot.GetMonstersInMainZone().Count <= 4)
                {
                    AI.SelectAnnounceID(CardId.WSS);
                    return true;
                }
                else if (Enemy.ExtraDeck.Count >= 10)
                {
                    if (!Bot.HasInGraveyard(CardId.Mohelp) && !Bot.HasInBanished(CardId.Mohelp))
                    {
                        AI.SelectAnnounceID(CardId.Mohelp);
                    }
                    else
                    {
                        AI.SelectAnnounceID(CardId.Xianhelp);
                    }
                    return true;
                }
                else if (Enemy.GetMonsterCount() < Bot.GetMonsterCount())
                {
                    AI.SelectCard(CardId.Mohelp);
                }
                else if (Bot.LifePoints <= 0)
                {
                    AI.SelectAnnounceID(CardId.Huigui);
                    return true;
                }
                else
                {
                    AI.SelectAnnounceID(CardId.Tianshen);
                    return true;
                }

            }
            else if ((Duel.Player == 1 || Duel.Player == 0) && ActivateDescription != Util.GetStringId(CardId.BossDuel, 7))
            {
                AI.SelectAnnounceID(CardId.Xinxuxidanganguan);
                return true;
            }
            return false;
        }
        //NO 4
        private bool NO4Effect()
        {
            if (Card.Location != CardLocation.Grave && !NO4)
            {
                if (Bot.GetMonsterCount() >= 6 || (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0 && Bot.GetMonsterCount() >= 5)) return false;
                AI.SelectCard(CardId.Y4);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                NO4 = true;
                return true;
            }
            else
            {
                ClientCard target = Util.GetBestEnemyCard();
                if (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0 && Util.ChainContainsCard(CardId.Jiejizhibi)) return false;
                else if (Duel.CurrentChain.Count > 0 && Util.ChainContainsCard(CardId.Y13)) return false;
                else if (target != null && !target.IsCode(CardId.Jiejitongzhi) && (target.HasType(CardType.Monster) || target.HasType(CardType.Continuous) || target.HasType(CardType.Field)))
                {
                    AI.SelectCard(target);
                    return true;
                }
                return false;
            }
        }
        //NO6
        private bool NO6Effect()
        {
            if (Card.Location != CardLocation.Grave)
            {
                if (Bot.GetMonsterCount() >= 6 || (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0 && Bot.GetMonsterCount() >= 5)) return false;
                AI.SelectCard(CardId.Y6);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            else
            {
                if (CheckRemainInDeck(CardId.NO13) > 0 && !Bot.HasInHandOrInSpellZone(CardId.NO13) && Bot.HasInExtra(CardId.Y13))
                {
                    AI.SelectCard(CardId.NO13);
                }
                else if (CheckRemainInDeck(CardId.Shengjiezengyi) > 0 && !Bot.HasInHandOrInSpellZone(CardId.Shengjiezengyi))
                {
                    AI.SelectCard(CardId.Shengjiezengyi);
                }
                else if (CheckRemainInDeck(CardId.Jiejizhibi) > 0 && !Bot.HasInHandOrInSpellZone(CardId.Jiejizhibi))
                {
                    AI.SelectCard(CardId.Jiejizhibi);
                }
                else if (CheckRemainInDeck(CardId.Shenghualuoxuan) > 0 && !Bot.HasInHandOrInSpellZone(CardId.Shenghualuoxuan))
                {
                    AI.SelectCard(CardId.Shenghualuoxuan);
                }
                else
                {
                    AI.SelectCard(CardId.Xingguangzhili, CardId.NO12, CardId.NO10);
                }
                return true;
            }
        }
        //NO8
        private bool NO8Effect()
        {
            if (Card.Location != CardLocation.Grave)
            {
                if (Bot.GetMonsterCount() >= 6 || (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0 && Bot.GetMonsterCount() >= 5)) return false;
                AI.SelectCard(CardId.Y8);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            else return true;
        }
        //NO10
        private bool NO10Effect()
        {
            if (Card.Location != CardLocation.Grave)
            {
                if (Bot.GetMonsterCount() >= 6 || (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0 && Bot.GetMonsterCount() >= 5)) return false;
                AI.SelectCard(CardId.Y10);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            else return true;
        }
        //NO12
        private bool NO12Effect()
        {
            if (Card.Location != CardLocation.Grave)
            {
                if (Bot.GetMonsterCount() >= 6 || (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0 && Bot.GetMonsterCount() >= 5)) return false;
                AI.SelectCard(CardId.Y12);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            else return true;
        }
        //NO13
        private bool NO13Effect()
        {
            if (Card.Location != CardLocation.Grave)
            {
                if (Bot.GetMonsterCount() >= 6 || (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0 && Bot.GetMonsterCount() >= 5)) return false;
                AI.SelectCard(CardId.Y13);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                AI.SelectPlace(Zones.z5 | Zones.z6);
                return true;
            }
            else return true;
        }
    }
}
