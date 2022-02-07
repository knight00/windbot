using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    // NOT FINISHED YET
    [Deck("Galaxy", "AI_Galaxy", "NotFinished")]
    public class GalaxyExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int X10 = 15000473;
            public const int Heiyanlong = 48229808;
            public const int X8 = 15000472;
            public const int X5 = 15000471;
            public const int Huiliuli = 14558128;
            public const int G = 23434538;
            public const int X2 = 15000470;
            public const int Geshitantuyu = 50366775;
            public const int Diannaowang = 57160136;
            public const int Xingqiugaizao = 73628505;
            public const int Xheiye = 15000480;
            public const int Xleng = 15000483;
            public const int Zhimingzhe = 24224830;
            public const int Yinhe = 15000691;
            public const int Wuxianpaoying = 10045474;
            public const int Xzhongdan = 15000481;
            public const int YinheS = 15000685;
            public const int Xxuxiang = 15000477;
            public const int Sqiang = 15000681;
            public const int Sjian = 15000682;
            public const int Sshan = 15000683;
            public const int Sjing = 15000684;
            public const int Quanseng = 32519092;
            public const int Xxiaolong = 15000474;
        }
        List<int> Impermanence_list = new List<int>();
        bool X5 = false;
        bool X8 = false;
        bool X10 = false;
        bool X102 = false;
        bool Geshitantuyu = false;
        bool Geshitantuyu2 = false;
        bool Sjing = false;
        bool Sshan = false;
        bool Sshan2 = false;
        bool Xxiaolong = false;
        bool Xxiaolong2 = false;
        bool X2 = false;
        bool Yinhe = false;
        bool Xheiye = false;
        //无效
        List<int> should_not_negate = new List<int>
        {
            81275020, 28985331
        };
        public GalaxyExecutor(GameAI ai, Duel duel)
          : base(ai, duel)
        {
            //星球改造
            AddExecutor(ExecutorType.Activate, CardId.Xingqiugaizao);
            //灰流丽
            AddExecutor(ExecutorType.Activate, CardId.Huiliuli, Hand_act_eff);
            //G
            AddExecutor(ExecutorType.Activate, CardId.G, G_activate);
            //无限泡影
            AddExecutor(ExecutorType.Activate, CardId.Wuxianpaoying, Impermanence_activate);
            //墓指
            AddExecutor(ExecutorType.Activate, CardId.Zhimingzhe, DefaultCalledByTheGrave);
            //黑炎
            AddExecutor(ExecutorType.Activate, CardId.Heiyanlong, HeiyanlongEffect);
            //星拟10
            AddExecutor(ExecutorType.Activate, CardId.X10, X10Effect);
            //星拟5
            AddExecutor(ExecutorType.Activate, CardId.X5, X5Effect);
            //星拟2
            AddExecutor(ExecutorType.Activate, CardId.X2, X2Effect);
            //星拟小龙
            AddExecutor(ExecutorType.SpSummon, CardId.Xxiaolong, XxiaolongSummon);
            //星拟小龙效果
            AddExecutor(ExecutorType.Activate, CardId.Xxiaolong, XxiaolongEffect);
            //星拟的终诞
            AddExecutor(ExecutorType.Activate, CardId.Xzhongdan, XzhongdanEffect);
            //星拟虚像
            AddExecutor(ExecutorType.SpSummon, CardId.Xxuxiang, XxuxiangSummon);
            //星拟虚像
            AddExecutor(ExecutorType.Activate, CardId.Xxuxiang);
            //星拟8
            AddExecutor(ExecutorType.Activate, CardId.X8, X8Effect);
            //鱼
            AddExecutor(ExecutorType.Activate, CardId.Geshitantuyu, GeshitantuyuEffect);
            //天威
            AddExecutor(ExecutorType.SpSummon, CardId.Quanseng, QuansengSummon);
            //神枪
            AddExecutor(ExecutorType.SpSummon, CardId.Sqiang, SqiangSummon);
            //神剑
            AddExecutor(ExecutorType.SpSummon, CardId.Sjian, SjianSummon);
            //神剑
            AddExecutor(ExecutorType.Activate, CardId.Sjian, SjianEffect);
            //神枪
            AddExecutor(ExecutorType.Activate, CardId.Sqiang, SqiangEffect);
            //神扇
            AddExecutor(ExecutorType.Activate, CardId.Sshan, SshanEffect);
            //神镜
            AddExecutor(ExecutorType.Activate, CardId.Sjing, SjingEffect);
            //银河S
            AddExecutor(ExecutorType.Activate, CardId.YinheS);
            //电脑网
            AddExecutor(ExecutorType.Activate, CardId.Diannaowang, DiannaowangEffect);
            //银河
            AddExecutor(ExecutorType.Activate, CardId.Yinhe, YinheEffect);
            //星拟 冷
            AddExecutor(ExecutorType.Activate, CardId.Xleng, XlengEffect);
            //星拟 黑夜
            AddExecutor(ExecutorType.Activate, CardId.Xheiye, XheiyeEffect);
            //鱼
            AddExecutor(ExecutorType.Summon, CardId.Geshitantuyu, GeshitantuyuSummon);
            //星拟2
            AddExecutor(ExecutorType.Summon, CardId.X2, X2Summon);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);
        }
        public bool is_should_not_negate()
        {
            ClientCard last_card = Util.GetLastChainCard();
            if (last_card != null
                && last_card.Controller == 1 && last_card.IsCode(should_not_negate))
                return true;
            return false;
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
        //计数专用
        public override void OnNewTurn()
        {
            // reset
            X5 = false;
            X8 = false;
            X10 = false;
            X102 = false;
            Geshitantuyu = false;
            Geshitantuyu2 = false;
            Sjing = false;
            Sshan = false;
            Sshan2 = false;
            Xxiaolong = false;
            Xxiaolong2 = false;
            X2 = false;
            Yinhe = false;
            Xheiye = false;
        }
        //黑炎
        private bool HeiyanlongEffect()
        {
            if (Duel.CurrentChain.Count > 0)
            {
                return Duel.LastChainPlayer == 1;
            }
            return false;
        }
            //星拟 黑夜
            private bool XheiyeEffect()
            {
            if ((Util.ChainContainsCard(CardId.Xheiye) && Duel.LastChainPlayer == 0) || (Duel.CurrentChain.Count > 1 && Duel.LastChainPlayer == 1 && Xheiye) ) return false;
            if (Card.Location != CardLocation.Grave)
            {
                if (Bot.HasInExtra(CardId.Xxiaolong) && !Xxiaolong && !(Bot.HasInBanished(CardId.Xxiaolong) && Bot.HasInGraveyard(CardId.Xxiaolong)) && X5)
                {
                    Xheiye = true;
                    AI.SelectCard(CardId.X2, CardId.X5, CardId.X8);
                    AI.SelectPosition(CardPosition.FaceUpDefence);
                    int a = 0;
                    ClientCard self_card_0 = Bot.MonsterZone[0];
                    ClientCard self_card_1 = Bot.MonsterZone[1];
                    ClientCard self_card_2 = Bot.MonsterZone[2];
                    ClientCard self_card_3 = Bot.MonsterZone[3];
                    ClientCard self_card_4 = Bot.MonsterZone[4];
                    do
                    {
                        if (a == 0 && self_card_0 == null)
                        {
                            AI.SelectPlace(Zones.z0);
                            a++;
                            return true;
                        }
                        else if (a == 0 && self_card_0 != null)
                        {
                            int b = 0;
                            do
                            {
                                if (b == 0 && self_card_1 == null)
                                {
                                    AI.SelectPlace(Zones.z1);
                                    b++;
                                    return true;
                                }
                                else if (b == 0 && self_card_3 == null)
                                {
                                    AI.SelectPlace(Zones.z3);
                                    b++;
                                    return true;
                                }
                                else if (b == 0 && self_card_4 == null)
                                {
                                    AI.SelectPlace(Zones.z4);
                                    b++;
                                    return true;
                                }
                                else if (b == 0 && self_card_2 == null)
                                {
                                    AI.SelectPlace(Zones.z2);
                                    b++;
                                    return true;
                                }

                            }
                            while (b >= 1); return false;

                        }
                        else if (a == 0 && self_card_0 != null && self_card_1 != null)
                        {
                            int b = 0;
                            do
                            {
                                if (b == 0 && self_card_3 == null)
                                {
                                    AI.SelectPlace(Zones.z3);
                                    b++;
                                    return true;
                                }
                                else if (b == 0 && self_card_4 == null)
                                {
                                    AI.SelectPlace(Zones.z4);
                                    b++;
                                    return true;
                                }
                                else if (b == 0 && self_card_2 == null)
                                {
                                    AI.SelectPlace(Zones.z2);
                                    b++;
                                    return true;
                                }
                            }
                            while (b >= 1); return false;
                        }
                        else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null)
                        {
                            int b = 0;
                            do
                            {
                                if (b == 0 && self_card_4 == null)
                                {
                                    AI.SelectPlace(Zones.z4);
                                    b++;
                                    return true;
                                }
                                else if (b == 0 && self_card_2 == null)
                                {
                                    AI.SelectPlace(Zones.z2);
                                    b++;
                                    return true;
                                }
                            }
                            while (b >= 1); return false;
                        }
                        else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null && self_card_4 != null)
                        {
                            int b = 0;
                            do
                            {
                                if (b == 0 && self_card_2 == null)
                                {
                                    AI.SelectPlace(Zones.z2);
                                    b++;
                                    return true;
                                }
                            }
                            while (b >= 1); return false;
                        }


                    }
                    while (a >= 1); return false;

                }
                else if (!X5)
                {
                    Xheiye = true;
                    AI.SelectCard(CardId.X5, CardId.X8, CardId.X2);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    int a = 0;
                    ClientCard self_card_0 = Bot.MonsterZone[0];
                    ClientCard self_card_1 = Bot.MonsterZone[1];
                    ClientCard self_card_2 = Bot.MonsterZone[2];
                    ClientCard self_card_3 = Bot.MonsterZone[3];
                    ClientCard self_card_4 = Bot.MonsterZone[4];
                    do
                    {
                        if (a == 0 && self_card_0 == null)
                        {
                            AI.SelectPlace(Zones.z0);
                            a++;
                            return true;
                        }
                        else if (a == 0 && self_card_0 != null)
                        {
                            int b = 0;
                            do
                            {
                                if (b == 0 && self_card_1 == null)
                                {
                                    AI.SelectPlace(Zones.z1);
                                    b++;
                                    return true;
                                }
                                else if (b == 0 && self_card_3 == null)
                                {
                                    AI.SelectPlace(Zones.z3);
                                    b++;
                                    return true;
                                }
                                else if (b == 0 && self_card_4 == null)
                                {
                                    AI.SelectPlace(Zones.z4);
                                    b++;
                                    return true;
                                }
                                else if (b == 0 && self_card_2 == null)
                                {
                                    AI.SelectPlace(Zones.z2);
                                    b++;
                                    return true;
                                }

                            }
                            while (b >= 1); return false;

                        }
                        else if (a == 0 && self_card_0 != null && self_card_1 != null)
                        {
                            int b = 0;
                            do
                            {
                                if (b == 0 && self_card_3 == null)
                                {
                                    AI.SelectPlace(Zones.z3);
                                    b++;
                                    return true;
                                }
                                else if (b == 0 && self_card_4 == null)
                                {
                                    AI.SelectPlace(Zones.z4);
                                    b++;
                                    return true;
                                }
                                else if (b == 0 && self_card_2 == null)
                                {
                                    AI.SelectPlace(Zones.z2);
                                    b++;
                                    return true;
                                }
                            }
                            while (b >= 1); return false;
                        }
                        else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null)
                        {
                            int b = 0;
                            do
                            {
                                if (b == 0 && self_card_4 == null)
                                {
                                    AI.SelectPlace(Zones.z4);
                                    b++;
                                    return true;
                                }
                                else if (b == 0 && self_card_2 == null)
                                {
                                    AI.SelectPlace(Zones.z2);
                                    b++;
                                    return true;
                                }
                            }
                            while (b >= 1); return false;
                        }
                        else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null && self_card_4 != null)
                        {
                            int b = 0;
                            do
                            {
                                if (b == 0 && self_card_2 == null)
                                {
                                    AI.SelectPlace(Zones.z2);
                                    b++;
                                    return true;
                                }
                            }
                            while (b >= 1); return false;
                        }


                    }
                    while (a >= 1); return false;
                }
                return false;
            }
            else if (Card.Location == CardLocation.Grave)
            {
                if (!X2)
                {
                    AI.SelectCard(CardId.X2, CardId.X10, CardId.X8, CardId.X5);
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.X10, CardId.X8, CardId.X5);
                    return true;
                }
            }
            return false;
        }
        //星2
        private bool X2Summon()
        {
            if (Bot.HasInMonstersZone(CardId.X2) || (Bot.HasInMonstersZone(CardId.X5) && X2)) return false;
            return true;
        }
        //小鱼
        private bool GeshitantuyuSummon()
        {
            if (Xxiaolong2 || !Bot.HasInExtra(CardId.Quanseng) || Bot.HasInMonstersZone(CardId.YinheS)) return false;
            else if (!Xxiaolong2)
            {
                Geshitantuyu2 = true;
                return true;
            }
            return false;
        }
        //星10
        private bool X10Effect()
        {
               if (Duel.CurrentChain.Count > 0)
               {
                         return Duel.LastChainPlayer == 1;
               }
               else
               {
                   AI.SelectCard(CardId.X2);
                   return true;
               }
        }
        //星10
        private bool X102Effect()
        {
            AI.SelectYesNo(true);
            AI.SelectCard(CardId.X10, CardId.X8, CardId.X5);
            X102 = true;
            return true;
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
        public bool Hand_act_eff()
        {
            if (Card.IsCode(CardId.Huiliuli) && Util.GetLastChainCard().HasSetcode(0x11e) && Util.GetLastChainCard().Location == CardLocation.Hand)
            return false;
            return (Duel.LastChainPlayer == 1);
        }
        //G
        public bool G_activate()
        {
            return (Duel.Player == 1);
        }
        //星2
        private bool X2Effect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.HasInMonstersZone(CardId.X2)) return false;
                {
                    AI.SelectPosition(CardPosition.FaceUpDefence);
                    int a = 0;
                    ClientCard self_card_0 = Bot.MonsterZone[0];
                    ClientCard self_card_1 = Bot.MonsterZone[1];
                    ClientCard self_card_2 = Bot.MonsterZone[2];
                    ClientCard self_card_3 = Bot.MonsterZone[3];
                    ClientCard self_card_4 = Bot.MonsterZone[4];
                    do
                    {
                        if (a == 0 && self_card_0 == null)
                        {
                            AI.SelectPlace(Zones.z0);
                            a++;
                            X2 = true;
                            return true;
                        }
                        else if (a == 0 && self_card_0 != null)
                        {
                            int b = 0;
                            do
                            {
                                if (b == 0 && self_card_1 == null)
                                {
                                    AI.SelectPlace(Zones.z1);
                                    b++;
                                    X2 = true;
                                    return true;
                                }
                                else if (b == 0 && self_card_3 == null)
                                {
                                    AI.SelectPlace(Zones.z3);
                                    b++;
                                    X2 = true;
                                    return true;
                                }
                                else if (b == 0 && self_card_4 == null)
                                {
                                    AI.SelectPlace(Zones.z4);
                                    b++;
                                    X2 = true;
                                    return true;
                                }
                                else if (b == 0 && self_card_2 == null)
                                {
                                    AI.SelectPlace(Zones.z2);
                                    b++;
                                    X2 = true;
                                    return true;
                                }

                            }
                            while (b >= 1); return false;

                        }
                        else if (a == 0 && self_card_0 != null && self_card_1 != null)
                        {
                            int b = 0;
                            do
                            {
                                if (b == 0 && self_card_3 == null)
                                {
                                    AI.SelectPlace(Zones.z3);
                                    b++;
                                    X2 = true;
                                    return true;
                                }
                                else if (b == 0 && self_card_4 == null)
                                {
                                    AI.SelectPlace(Zones.z4);
                                    b++;
                                    X2 = true;
                                    return true;
                                }
                                else if (b == 0 && self_card_2 == null)
                                {
                                    AI.SelectPlace(Zones.z2);
                                    b++;
                                    X2 = true;
                                    return true;
                                }
                            }
                            while (b >= 1); return false;
                        }
                        else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null)
                        {
                            int b = 0;
                            do
                            {
                                if (b == 0 && self_card_4 == null)
                                {
                                    AI.SelectPlace(Zones.z4);
                                    b++;
                                    X2 = true;
                                    return true;
                                }
                                else if (b == 0 && self_card_2 == null)
                                {
                                    AI.SelectPlace(Zones.z2);
                                    b++;
                                    X2 = true;
                                    return true;
                                }
                            }
                            while (b >= 1); return false;
                        }
                        else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null && self_card_4 != null)
                        {
                            int b = 0;
                            do
                            {
                                if (b == 0 && self_card_2 == null)
                                {
                                    AI.SelectPlace(Zones.z2);
                                    b++;
                                    X2 = true;
                                    return true;
                                }
                            }
                            while (b >= 1); return false;
                        }


                    }
                    while (a >= 1); return false;
                }
            }
            else
            {
                AI.SelectCard(CardId.X5);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                int a = 0;
                ClientCard self_card_0 = Bot.MonsterZone[0];
                ClientCard self_card_1 = Bot.MonsterZone[1];
                ClientCard self_card_2 = Bot.MonsterZone[2];
                ClientCard self_card_3 = Bot.MonsterZone[3];
                ClientCard self_card_4 = Bot.MonsterZone[4];
                do
                {
                    if (a == 0 && self_card_0 == null)
                    {
                        AI.SelectPlace(Zones.z0);
                        a++;
                        return true;
                    }
                    else if (a == 0 && self_card_0 != null)
                    {
                        int b = 0;
                        do
                        {
                            if (b == 0 && self_card_1 == null)
                            {
                                AI.SelectPlace(Zones.z1);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_3 == null)
                            {
                                AI.SelectPlace(Zones.z3);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_4 == null)
                            {
                                AI.SelectPlace(Zones.z4);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_2 == null)
                            {
                                AI.SelectPlace(Zones.z2);
                                b++;
                                return true;
                            }

                        }
                        while (b >= 1); return false;

                    }
                    else if (a == 0 && self_card_0 != null && self_card_1 != null)
                    {
                        int b = 0;
                        do
                        {
                            if (b == 0 && self_card_3 == null)
                            {
                                AI.SelectPlace(Zones.z3);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_4 == null)
                            {
                                AI.SelectPlace(Zones.z4);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_2 == null)
                            {
                                AI.SelectPlace(Zones.z2);
                                b++;
                                return true;
                            }
                        }
                        while (b >= 1); return false;
                    }
                    else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null)
                    {
                        int b = 0;
                        do
                        {
                            if (b == 0 && self_card_4 == null)
                            {
                                AI.SelectPlace(Zones.z4);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_2 == null)
                            {
                                AI.SelectPlace(Zones.z2);
                                b++;
                                return true;
                            }
                        }
                        while (b >= 1); return false;
                    }
                    else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null && self_card_4 != null)
                    {
                        int b = 0;
                        do
                        {
                            if (b == 0 && self_card_2 == null)
                            {
                                AI.SelectPlace(Zones.z2);
                                b++;
                                return true;
                            }
                        }
                        while (b >= 1); return false;
                    }


                }
                while (a >= 1); return false;
            }
        }
        //星拟 冷
        private bool XlengEffect()
        {
            ClientCard target = Util.GetBestEnemyCard();
            if (Card.Location == CardLocation.SpellZone)
            {
                if (Bot.HasInMonstersZone(CardId.X10) && !X102) return false;
                if (target != null && (target.HasType(CardType.Continuous) || target.HasType(CardType.Monster)))
                {
                    AI.SelectCard(target);
                    AI.SelectNextCard(CardId.Xxiaolong, CardId.Xxuxiang);
                    return true;
                }
                return false;
            }
            else if (Card.Location == CardLocation.Grave)
            {
                if (!Bot.HasInSpellZone(CardId.Xzhongdan))
                {
                    AI.SelectCard(CardId.Xzhongdan);
                    return true;
                }
                else if (!Bot.HasInSpellZone(CardId.Xheiye))
                {
                    AI.SelectCard(CardId.Xheiye);
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Xheiye,CardId.Xzhongdan);
                    return true;
                }
            }
            return false;
        }
        //神枪
        private bool SqiangSummon()
        {
            if (!Bot.HasInMonstersZone(CardId.Quanseng)) return false;
            AI.SelectMaterials(new[]
               {
                    CardId.Quanseng,
                });
            return true;
        }
        //神剑
        private bool SjianSummon()
        {
            if (!Sjing)
            {
                AI.SelectMaterials(new[]
               {
                    CardId.Sqiang,
                    CardId.Sjing,
                    CardId.Sshan,
                });
                return true;
            }
            else if (Sjing)
            {
                AI.SelectMaterials(new[]
              {
                    CardId.Sjing,
                    CardId.Sshan,
                });
                return true;
            }
            else if (Sshan)
            {
                AI.SelectMaterials(new[]
              {
                    CardId.Sshan,
                });
                return true;
            }
            return false;
        }
        //神剑效果
        private bool SjianEffect()
        {
            foreach (ClientCard card in Bot.MonsterZone)
                if (Card.Location == CardLocation.MonsterZone)
                {
                    if (Bot.HasInMonstersZone(CardId.YinheS)) return false;
                    if (!Sjing)
                    {
                        AI.SelectNumber(1);
                        AI.SelectCard(CardId.Sjing);
                        Sjing = true;
                        return true;
                    }
                    else if (Sjing && !Sshan)
                    {
                        AI.SelectNumber(1);
                        AI.SelectCard(CardId.Sshan);
                        Sshan = true;
                        return true;
                    }
                    else if (Sshan && !Sshan2)
                    {
                        AI.SelectNumber(1);
                        AI.SelectCard(CardId.Sshan);
                        Sshan2 = true;
                        return true;
                    }
                    else if (Sshan2) return false;
                    return false;
                }
                else if (Card.Location == CardLocation.SpellZone)
                {
                    if (Bot.HasInGraveyard(CardId.Xheiye) && Duel.Player == 1) return false;
                    if (Enemy.LifePoints <= 300 && Duel.Player == 1)
                    {
                        if (!Bot.HasInMonstersZone(CardId.Sqiang))
                        {
                            AI.SelectCard(CardId.Sqiang, CardId.Sshan, CardId.Sjian);
                            return true;
                        }
                        else if (!Bot.HasInMonstersZone(CardId.Sshan))
                        {
                            AI.SelectCard(CardId.Sshan, CardId.Sqiang, CardId.Sjian);
                            return true;
                        }
                        else if (!Bot.HasInMonstersZone(CardId.Sjing))
                        {
                            AI.SelectCard(CardId.Sjing, CardId.Sjian, CardId.Sqiang, CardId.Sshan);
                            return true;
                        }
                        else if (!Bot.HasInMonstersZone(CardId.Sjian))
                        {
                            AI.SelectCard(CardId.Sjian, CardId.Sqiang, CardId.Sshan);
                            return true;
                        }
                        return false;
                    }
                    else if (Duel.Player == 0 && !Bot.HasInMonstersZone(CardId.YinheS))
                    {
                        if (!Bot.HasInMonstersZone(CardId.Sqiang))
                        {
                            AI.SelectCard(CardId.Sqiang, CardId.Sshan, CardId.Sjian);
                            return true;
                        }
                        else if (!Bot.HasInMonstersZone(CardId.Sshan))
                        {
                            AI.SelectCard(CardId.Sshan, CardId.Sqiang, CardId.Sjian);
                            return true;
                        }
                        else if (!Bot.HasInMonstersZone(CardId.Sjing))
                        {
                            AI.SelectCard(CardId.Sjing, CardId.Sjian, CardId.Sqiang, CardId.Sshan);
                            return true;
                        }
                        else if (!Bot.HasInMonstersZone(CardId.Sjian))
                        {
                            AI.SelectCard(CardId.Sjian, CardId.Sqiang, CardId.Sshan);
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
            return false;
        }
        //神枪
        private bool SqiangEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (Bot.HasInMonstersZone(CardId.YinheS)) return false;
                if (Bot.GetMonsterCount() >= 4 && Bot.GetMonsterCount()<6)
                {
                    AI.SelectNumber(4);
                    AI.SelectCard(CardId.YinheS);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                else if (Bot.GetMonsterCount() >= 4 && Bot.GetMonsterCount() >=6)
                {
                    AI.SelectNumber(3);
                    AI.SelectCard(CardId.YinheS);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                else if (Bot.GetMonsterCount() == 3)
                {
                    AI.SelectNumber(3);
                    AI.SelectCard(CardId.YinheS);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                return false;
            }
            else if (Card.Location == CardLocation.SpellZone) return true;
            return false;
        }
        //神扇
        private bool SshanEffect()
        {
             ClientCard target = Util.GetBestEnemyCard();
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (Bot.HasInMonstersZone(CardId.YinheS)) return false;
                if (Bot.GetMonsterCount() >= 4 && Bot.GetMonsterCount() < 6)
                {
                    AI.SelectNumber(4);
                    AI.SelectCard(CardId.YinheS);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                else if (Bot.GetMonsterCount() >= 4 && Bot.GetMonsterCount() >= 6)
                {
                    AI.SelectNumber(3);
                    AI.SelectCard(CardId.YinheS);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                else if (Bot.GetMonsterCount() == 3)
                {
                    AI.SelectNumber(3);
                    AI.SelectCard(CardId.YinheS);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                return false;
            }
            else if (Card.Location == CardLocation.SpellZone)
            {
                if (Bot.HasInMonstersZone(CardId.X10) && !X102) return false;
                if (target != null && (target.HasType(CardType.Continuous) || target.HasType(CardType.Monster)))
                {
                    AI.SelectCard(target);
                    return true;
                }
                return false;
            }
            return false;
        }
        //神镜
        private bool SjingEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (Bot.HasInMonstersZone(CardId.YinheS)) return false;
                if (Bot.GetMonsterCount() >= 4 && Bot.GetMonsterCount() < 6)
                {
                    AI.SelectNumber(4);
                    AI.SelectCard(CardId.YinheS);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                else if (Bot.GetMonsterCount() >= 4 && Bot.GetMonsterCount() >= 6)
                {
                    AI.SelectNumber(3);
                    AI.SelectCard(CardId.YinheS);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                else if (Bot.GetMonsterCount() == 3)
                {
                    AI.SelectNumber(3);
                    AI.SelectCard(CardId.YinheS);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                return false;
            }
            else if (Card.Location == CardLocation.SpellZone)
            {
                if (Duel.CurrentChain.Count > 0)
                {
                    return Duel.LastChainPlayer == 1;
                }
                return false;
            }
            return false;
        }
        //星拟小龙
        private bool XxiaolongSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Quanseng)) return false;
            if (Bot.HasInHand(CardId.Yinhe) && !Yinhe) return false;
            if ((Bot.HasInHand(CardId.Geshitantuyu) || Bot.HasInMonstersZone(CardId.Geshitantuyu)) && !Geshitantuyu && Bot.HasInExtra(CardId.Quanseng)) return false;
            else if (Bot.HasInMonstersZone(CardId.X2) || Bot.HasInMonstersZone(CardId.X5) || Bot.HasInMonstersZone(CardId.X8))
            {
                AI.SelectMaterials(new[]
               {
                    CardId.X2,
                    CardId.X5,
                    CardId.X8,
                });
                Xxiaolong = true;
                return true;
            }
            return false;
        }
        //拳僧
        private bool QuansengSummon()
        {
            if (!Bot.HasInMonstersZone(CardId.Geshitantuyu)) return false;
            AI.SelectMaterials(new[]
               {
                    CardId.Geshitantuyu
                });
            return true;
        }
        //星拟虚像
        private bool XxuxiangSummon()
        {
            if (Bot.HasInExtra(CardId.Xxiaolong) && !Xxiaolong) return false;
            if (Bot.GetMonsterCount() == 2 && !Bot.HasInMonstersZone(CardId.X2)) return false;
            AI.SelectMaterials(new[]
               {
                    CardId.Xxiaolong,
                    CardId.X5,
                    CardId.X2,
                });
            return true;
        }
        //电脑网
        private bool DiannaowangEffect()
        {
            if (!Bot.HasInExtra(CardId.Quanseng)) return false;
            if (!Geshitantuyu)
            {
                if (Bot.HasInHand(CardId.Xheiye))
                {
                    AI.SelectCard(CardId.X2, CardId.Xheiye);
                    AI.SelectNextCard(CardId.Geshitantuyu);
                    return true;
                }
                else 
                {
                    AI.SelectCard(CardId.Xheiye,CardId.X2);
                    AI.SelectNextCard(CardId.Geshitantuyu);
                    return true;
                }

            }
            return false;
        }
        //星拟小龙效果
        private bool XxiaolongEffect()
        {
            AI.SelectCard(CardId.X5);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            int a = 0;
            ClientCard self_card_0 = Bot.MonsterZone[0];
            ClientCard self_card_1 = Bot.MonsterZone[1];
            ClientCard self_card_2 = Bot.MonsterZone[2];
            ClientCard self_card_3 = Bot.MonsterZone[3];
            ClientCard self_card_4 = Bot.MonsterZone[4];
            do
            {
                if (a == 0 && self_card_0 == null)
                {
                    AI.SelectPlace(Zones.z0);
                    a++;
                    Xxiaolong2 = true;
                    return true;
                }
                else if (a == 0 && self_card_0 != null)
                {
                    int b = 0;
                    do
                    {
                        if (b == 0 && self_card_1 == null)
                        {
                            AI.SelectPlace(Zones.z1);
                            b++;
                            Xxiaolong2 = true;
                            return true;
                        }
                        else if (b == 0 && self_card_3 == null)
                        {
                            AI.SelectPlace(Zones.z3);
                            b++;
                            Xxiaolong2 = true;
                            return true;
                        }
                        else if (b == 0 && self_card_4 == null)
                        {
                            AI.SelectPlace(Zones.z4);
                            b++;
                            Xxiaolong2 = true;
                            return true;
                        }
                        else if (b == 0 && self_card_2 == null)
                        {
                            AI.SelectPlace(Zones.z2);
                            b++;
                            Xxiaolong2 = true;
                            return true;
                        }

                    }
                    while (b >= 1); return false;

                }
                else if (a == 0 && self_card_0 != null && self_card_1 != null)
                {
                    int b = 0;
                    do
                    {
                        if (b == 0 && self_card_3 == null)
                        {
                            AI.SelectPlace(Zones.z3);
                            b++;
                            Xxiaolong2 = true;
                            return true;
                        }
                        else if (b == 0 && self_card_4 == null)
                        {
                            AI.SelectPlace(Zones.z4);
                            b++;
                            Xxiaolong2 = true;
                            return true;
                        }
                        else if (b == 0 && self_card_2 == null)
                        {
                            AI.SelectPlace(Zones.z2);
                            b++;
                            Xxiaolong2 = true;
                            return true;
                        }
                    }
                    while (b >= 1); return false;
                }
                else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null)
                {
                    int b = 0;
                    do
                    {
                        if (b == 0 && self_card_4 == null)
                        {
                            AI.SelectPlace(Zones.z4);
                            b++;
                            Xxiaolong2 = true;
                            return true;
                        }
                        else if (b == 0 && self_card_2 == null)
                        {
                            AI.SelectPlace(Zones.z2);
                            b++;
                            Xxiaolong2 = true;
                            return true;
                        }
                    }
                    while (b >= 1); return false;
                }
                else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null && self_card_4 != null)
                {
                    int b = 0;
                    do
                    {
                        if (b == 0 && self_card_2 == null)
                        {
                            AI.SelectPlace(Zones.z2);
                            b++;
                            Xxiaolong2 = true;
                            return true;
                        }
                    }
                    while (b >= 1); return false;
                }


            }
            while (a >= 1); return false;

        }
        //银河
        private bool YinheEffect()
        {
            if (!Yinhe)
            {
                AI.SelectCard(CardId.Sqiang);
                Yinhe = true;
                return true;
            }
            else
            {
                AI.SelectCard(CardId.YinheS);
                AI.SelectNextCard(CardId.Sjian, CardId.Sqiang);
                return true;
            }
        }
        //鱼
        private bool GeshitantuyuEffect()
        {
            AI.SelectCard(CardId.Quanseng);
            return true;
        }
        //星5
        private bool X5Effect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.HasInHand(CardId.X2) && Bot.HasInExtra(CardId.Xxiaolong) && !Xxiaolong)
                {
                    return X2Summon();
                }
                else if (Bot.HasInExtra(CardId.Xxiaolong) && Bot.HasInMonstersZone(CardId.X2) && !Xxiaolong)
                {
                    return XxiaolongSummon();
                }
                else
                {
                    AI.SelectCard(CardId.X2);
                    X5 = true;
                    return true;
                }
            }
            else if (Card.Location == CardLocation.MonsterZone)
            {
                if (!X5)
                {
                    if (!Bot.HasInHandOrInSpellZone(CardId.Xzhongdan))
                    {
                        AI.SelectCard(CardId.Xzhongdan, CardId.Xleng, CardId.Xheiye);
                        X5 = true;
                        return true;
                    }
                    else
                    {
                        AI.SelectCard(CardId.Xleng, CardId.Xheiye, CardId.Xzhongdan);
                        X5 = true;
                        return true;
                    }
                }
                else if(X5 || Duel.Phase==DuelPhase.End)
                {
                    if (!Bot.HasInMonstersZone(CardId.X10))
                    {
                        AI.SelectCard(CardId.X8, CardId.Heiyanlong);
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                        int a = 0;
                        ClientCard self_card_0 = Bot.MonsterZone[0];
                        ClientCard self_card_1 = Bot.MonsterZone[1];
                        ClientCard self_card_2 = Bot.MonsterZone[2];
                        ClientCard self_card_3 = Bot.MonsterZone[3];
                        ClientCard self_card_4 = Bot.MonsterZone[4];
                        do
                        {
                            if (a == 0 && self_card_0 == null)
                            {
                                AI.SelectPlace(Zones.z0);
                                a++;
                                return true;
                            }
                            else if (a == 0 && self_card_0 != null)
                            {
                                int b = 0;
                                do
                                {
                                    if (b == 0 && self_card_1 == null)
                                    {
                                        AI.SelectPlace(Zones.z1);
                                        b++;
                                        return true;
                                    }
                                    else if (b == 0 && self_card_3 == null)
                                    {
                                        AI.SelectPlace(Zones.z3);
                                        b++;
                                        return true;
                                    }
                                    else if (b == 0 && self_card_4 == null)
                                    {
                                        AI.SelectPlace(Zones.z4);
                                        b++;
                                        return true;
                                    }
                                    else if (b == 0 && self_card_2 == null)
                                    {
                                        AI.SelectPlace(Zones.z2);
                                        b++;
                                        return true;
                                    }

                                }
                                while (b >= 1); return false;

                            }
                            else if (a == 0 && self_card_0 != null && self_card_1 != null)
                            {
                                int b = 0;
                                do
                                {
                                    if (b == 0 && self_card_3 == null)
                                    {
                                        AI.SelectPlace(Zones.z3);
                                        b++;
                                        return true;
                                    }
                                    else if (b == 0 && self_card_4 == null)
                                    {
                                        AI.SelectPlace(Zones.z4);
                                        b++;
                                        return true;
                                    }
                                    else if (b == 0 && self_card_2 == null)
                                    {
                                        AI.SelectPlace(Zones.z2);
                                        b++;
                                        return true;
                                    }
                                }
                                while (b >= 1); return false;
                            }
                            else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null)
                            {
                                int b = 0;
                                do
                                {
                                    if (b == 0 && self_card_4 == null)
                                    {
                                        AI.SelectPlace(Zones.z4);
                                        b++;
                                        return true;
                                    }
                                    else if (b == 0 && self_card_2 == null)
                                    {
                                        AI.SelectPlace(Zones.z2);
                                        b++;
                                        return true;
                                    }
                                }
                                while (b >= 1); return false;
                            }
                            else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null && self_card_4 != null)
                            {
                                int b = 0;
                                do
                                {
                                    if (b == 0 && self_card_2 == null)
                                    {
                                        AI.SelectPlace(Zones.z2);
                                        b++;
                                        return true;
                                    }
                                }
                                while (b >= 1); return false;
                            }


                        }
                        while (a >= 1); return false;
                    }
                    else if (Bot.HasInMonstersZone(CardId.X10))
                    {
                        AI.SelectCard(CardId.Heiyanlong, CardId.X8);
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                        int a = 0;
                        ClientCard self_card_0 = Bot.MonsterZone[0];
                        ClientCard self_card_1 = Bot.MonsterZone[1];
                        ClientCard self_card_2 = Bot.MonsterZone[2];
                        ClientCard self_card_3 = Bot.MonsterZone[3];
                        ClientCard self_card_4 = Bot.MonsterZone[4];
                        do
                        {
                            if (a == 0 && self_card_0 == null)
                            {
                                AI.SelectPlace(Zones.z0);
                                a++;
                                return true;
                            }
                            else if (a == 0 && self_card_0 != null)
                            {
                                int b = 0;
                                do
                                {
                                    if (b == 0 && self_card_1 == null)
                                    {
                                        AI.SelectPlace(Zones.z1);
                                        b++;
                                        return true;
                                    }
                                    else if (b == 0 && self_card_3 == null)
                                    {
                                        AI.SelectPlace(Zones.z3);
                                        b++;
                                        return true;
                                    }
                                    else if (b == 0 && self_card_4 == null)
                                    {
                                        AI.SelectPlace(Zones.z4);
                                        b++;
                                        return true;
                                    }
                                    else if (b == 0 && self_card_2 == null)
                                    {
                                        AI.SelectPlace(Zones.z2);
                                        b++;
                                        return true;
                                    }

                                }
                                while (b >= 1); return false;

                            }
                            else if (a == 0 && self_card_0 != null && self_card_1 != null)
                            {
                                int b = 0;
                                do
                                {
                                    if (b == 0 && self_card_3 == null)
                                    {
                                        AI.SelectPlace(Zones.z3);
                                        b++;
                                        return true;
                                    }
                                    else if (b == 0 && self_card_4 == null)
                                    {
                                        AI.SelectPlace(Zones.z4);
                                        b++;
                                        return true;
                                    }
                                    else if (b == 0 && self_card_2 == null)
                                    {
                                        AI.SelectPlace(Zones.z2);
                                        b++;
                                        return true;
                                    }
                                }
                                while (b >= 1); return false;
                            }
                            else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null)
                            {
                                int b = 0;
                                do
                                {
                                    if (b == 0 && self_card_4 == null)
                                    {
                                        AI.SelectPlace(Zones.z4);
                                        b++;
                                        return true;
                                    }
                                    else if (b == 0 && self_card_2 == null)
                                    {
                                        AI.SelectPlace(Zones.z2);
                                        b++;
                                        return true;
                                    }
                                }
                                while (b >= 1); return false;
                            }
                            else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null && self_card_4 != null)
                            {
                                int b = 0;
                                do
                                {
                                    if (b == 0 && self_card_2 == null)
                                    {
                                        AI.SelectPlace(Zones.z2);
                                        b++;
                                        return true;
                                    }
                                }
                                while (b >= 1); return false;
                            }


                        }
                        while (a >= 1); return false;
                    }
         
       
                  
                }
                return false;

            }
            return false;
        }
        //星拟终诞
        private bool XzhongdanEffect()
        {
            if (Duel.CurrentChain.Count == 0 && Card.Location == CardLocation.SpellZone) return false;
            else if (Duel.CurrentChain.Count > 0 && Card.Location == CardLocation.SpellZone)
            {
                return Duel.LastChainPlayer == 1;
            }
            else if (!X5 && Card.Location != CardLocation.SpellZone)
            {
                AI.SelectCard(CardId.X5, CardId.X8, CardId.X10, CardId.X2);
                AI.SelectNextCard(CardId.X5);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                int a = 0;
                ClientCard self_card_0 = Bot.MonsterZone[0];
                ClientCard self_card_1 = Bot.MonsterZone[1];
                ClientCard self_card_2 = Bot.MonsterZone[2];
                ClientCard self_card_3 = Bot.MonsterZone[3];
                ClientCard self_card_4 = Bot.MonsterZone[4];
                do
                {
                    if (a == 0 && self_card_0 == null)
                    {
                        AI.SelectPlace(Zones.z0);
                        a++;
                        return true;
                    }
                    else if (a == 0 && self_card_0 != null)
                    {
                        int b = 0;
                        do
                        {
                            if (b == 0 && self_card_1 == null)
                            {
                                AI.SelectPlace(Zones.z1);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_3 == null)
                            {
                                AI.SelectPlace(Zones.z3);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_4 == null)
                            {
                                AI.SelectPlace(Zones.z4);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_2 == null)
                            {
                                AI.SelectPlace(Zones.z2);
                                b++;
                                return true;
                            }

                        }
                        while (b >= 1); return false;

                    }
                    else if (a == 0 && self_card_0 != null && self_card_1 != null)
                    {
                        int b = 0;
                        do
                        {
                            if (b == 0 && self_card_3 == null)
                            {
                                AI.SelectPlace(Zones.z3);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_4 == null)
                            {
                                AI.SelectPlace(Zones.z4);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_2 == null)
                            {
                                AI.SelectPlace(Zones.z2);
                                b++;
                                return true;
                            }
                        }
                        while (b >= 1); return false;
                    }
                    else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null)
                    {
                        int b = 0;
                        do
                        {
                            if (b == 0 && self_card_4 == null)
                            {
                                AI.SelectPlace(Zones.z4);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_2 == null)
                            {
                                AI.SelectPlace(Zones.z2);
                                b++;
                                return true;
                            }
                        }
                        while (b >= 1); return false;
                    }
                    else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null && self_card_4 != null)
                    {
                        int b = 0;
                        do
                        {
                            if (b == 0 && self_card_2 == null)
                            {
                                AI.SelectPlace(Zones.z2);
                                b++;
                                return true;
                            }
                        }
                        while (b >= 1); return false;
                    }


                }
                while (a >= 1); return false;
            }
            else if (X5 && Card.Location != CardLocation.SpellZone)
            {
                AI.SelectCard(CardId.X8, CardId.X10, CardId.X5, CardId.X2);
                AI.SelectNextCard(CardId.X2);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                int a = 0;
                ClientCard self_card_0 = Bot.MonsterZone[0];
                ClientCard self_card_1 = Bot.MonsterZone[1];
                ClientCard self_card_2 = Bot.MonsterZone[2];
                ClientCard self_card_3 = Bot.MonsterZone[3];
                ClientCard self_card_4 = Bot.MonsterZone[4];
                do
                {
                    if (a == 0 && self_card_0 == null)
                    {
                        AI.SelectPlace(Zones.z0);
                        a++;
                        return true;
                    }
                    else if (a == 0 && self_card_0 != null)
                    {
                        int b = 0;
                        do
                        {
                            if (b == 0 && self_card_1 == null)
                            {
                                AI.SelectPlace(Zones.z1);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_3 == null)
                            {
                                AI.SelectPlace(Zones.z3);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_4 == null)
                            {
                                AI.SelectPlace(Zones.z4);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_2 == null)
                            {
                                AI.SelectPlace(Zones.z2);
                                b++;
                                return true;
                            }

                        }
                        while (b >= 1); return false;

                    }
                    else if (a == 0 && self_card_0 != null && self_card_1 != null)
                    {
                        int b = 0;
                        do
                        {
                            if (b == 0 && self_card_3 == null)
                            {
                                AI.SelectPlace(Zones.z3);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_4 == null)
                            {
                                AI.SelectPlace(Zones.z4);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_2 == null)
                            {
                                AI.SelectPlace(Zones.z2);
                                b++;
                                return true;
                            }
                        }
                        while (b >= 1); return false;
                    }
                    else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null)
                    {
                        int b = 0;
                        do
                        {
                            if (b == 0 && self_card_4 == null)
                            {
                                AI.SelectPlace(Zones.z4);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_2 == null)
                            {
                                AI.SelectPlace(Zones.z2);
                                b++;
                                return true;
                            }
                        }
                        while (b >= 1); return false;
                    }
                    else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null && self_card_4 != null)
                    {
                        int b = 0;
                        do
                        {
                            if (b == 0 && self_card_2 == null)
                            {
                                AI.SelectPlace(Zones.z2);
                                b++;
                                return true;
                            }
                        }
                        while (b >= 1); return false;
                    }


                }
                while (a >= 1); return false;
            }
            return false;
            
        }
        //星8
        private bool X8Effect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (X2)
                {
                    AI.SelectCard(CardId.X5);
                    return true;
                }
                else if(!X2)
                {
                    AI.SelectCard(CardId.X2);
                    return true;
                }
                return false;
            }
            else if (Card.Location == CardLocation.MonsterZone)
            {
                    AI.SelectCard(CardId.X10);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                int a = 0;
                ClientCard self_card_0 = Bot.MonsterZone[0];
                ClientCard self_card_1 = Bot.MonsterZone[1];
                ClientCard self_card_2 = Bot.MonsterZone[2];
                ClientCard self_card_3 = Bot.MonsterZone[3];
                ClientCard self_card_4 = Bot.MonsterZone[4];
                do
                {
                    if (a == 0 && self_card_0 == null)
                    {
                        AI.SelectPlace(Zones.z0);
                        a++;
                        return true;
                    }
                    else if (a == 0 && self_card_0 != null)
                    {
                        int b = 0;
                        do
                        {
                            if (b == 0 && self_card_1 == null)
                            {
                                AI.SelectPlace(Zones.z1);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_3 == null)
                            {
                                AI.SelectPlace(Zones.z3);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_4 == null)
                            {
                                AI.SelectPlace(Zones.z4);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_2 == null)
                            {
                                AI.SelectPlace(Zones.z2);
                                b++;
                                return true;
                            }

                        }
                        while (b >= 1); return false;

                    }
                    else if (a == 0 && self_card_0 != null && self_card_1 != null)
                    {
                        int b = 0;
                        do
                        {
                            if (b == 0 && self_card_3 == null)
                            {
                                AI.SelectPlace(Zones.z3);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_4 == null)
                            {
                                AI.SelectPlace(Zones.z4);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_2 == null)
                            {
                                AI.SelectPlace(Zones.z2);
                                b++;
                                return true;
                            }
                        }
                        while (b >= 1); return false;
                    }
                    else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null)
                    {
                        int b = 0;
                        do
                        {
                            if (b == 0 && self_card_4 == null)
                            {
                                AI.SelectPlace(Zones.z4);
                                b++;
                                return true;
                            }
                            else if (b == 0 && self_card_2 == null)
                            {
                                AI.SelectPlace(Zones.z2);
                                b++;
                                return true;
                            }
                        }
                        while (b >= 1); return false;
                    }
                    else if (a == 0 && self_card_0 != null && self_card_1 != null && self_card_3 != null && self_card_4 != null)
                    {
                        int b = 0;
                        do
                        {
                            if (b == 0 && self_card_2 == null)
                            {
                                AI.SelectPlace(Zones.z2);
                                b++;
                                return true;
                            }
                        }
                        while (b >= 1); return false;
                    }


                }
                while (a >= 1); return false;
            }
            return false;
        }



    }  
}
