using System;
using System.Linq;
using System.Collections.Generic;
using YGOSharp.OCGWrapper.Enums;

namespace WindBot.Game.AI.Decks
{
    // Token: 0x02000032 RID: 50
    [Deck("Niaojun", "AI_Niaojun", "NotFinished")]
    public class NiaojunExecutor : DefaultExecutor
    {
        // Token: 0x060003F8 RID: 1016 RVA: 0x00021DC4 File Offset: 0x0001FFC4
        public NiaojunExecutor(GameAI ai, Duel duel) : base(ai, duel)
        {
            base.AddExecutor(ExecutorType.Activate, 9981675, new Func<bool>(this.EyiEffect));
            base.AddExecutor(ExecutorType.Activate, 9981724, new Func<bool>(this.DefaultTorrentialTribute));
            base.AddExecutor(ExecutorType.SpSummon, 9981418, new Func<bool>(this.DijiaSummon));
            base.AddExecutor(ExecutorType.Activate, 9981418, new Func<bool>(this.DijiaEffect));
            base.AddExecutor(ExecutorType.Activate, 9982053, new Func<bool>(this.PohuaijianEffect));
            base.AddExecutor(ExecutorType.SpSummon, 9982055);
            base.AddExecutor(ExecutorType.Activate, 9982055, new Func<bool>(this.PohuaijianzhanshiEffect));
            base.AddExecutor(ExecutorType.SpSummon, 9950484);
            base.AddExecutor(ExecutorType.Activate, 9950484, new Func<bool>(this.ZuihuopuEffect));
            base.AddExecutor(ExecutorType.Summon, 9951605, new Func<bool>(this.ShuizhaoSummon));
            base.AddExecutor(ExecutorType.Activate, 9951605, new Func<bool>(this.ShuizhaoEffect));
            base.AddExecutor(ExecutorType.Activate, 9950697);
            base.AddExecutor(ExecutorType.Activate, 9951558);
            base.AddExecutor(ExecutorType.Activate, 9981632, new Func<bool>(this.DDzhanshouEffect));
            base.AddExecutor(ExecutorType.Activate, 9982077, new Func<bool>(this.DSEffect));
            base.AddExecutor(ExecutorType.Activate, 9982377, new Func<bool>(this.JiushifangzhouEffect));
            base.AddExecutor(ExecutorType.Activate, 9982051, new Func<bool>(this.PohuaijianxietongEffect));
            base.AddExecutor(ExecutorType.Activate, 9981725);
            base.AddExecutor(ExecutorType.Activate, 50954680, new Func<bool>(this.ZuihuopuEffect));
            base.AddExecutor(ExecutorType.Activate, 8824601, new Func<bool>(this.IEffect));
            base.AddExecutor(ExecutorType.Activate, 8824602, new Func<bool>(this.IEffect));
            base.AddExecutor(ExecutorType.Activate, 8824590, new Func<bool>(this.HundunjuheEffect));
            base.AddExecutor(ExecutorType.Activate, 9980715);
            base.AddExecutor(ExecutorType.Activate, 8824591);
            base.AddExecutor(ExecutorType.Activate, 8824594, new Func<bool>(this.X9Effect));
            base.AddExecutor(ExecutorType.Activate, 8824596, new Func<bool>(this.X11Effect));
            base.AddExecutor(ExecutorType.Activate, 8824598, new Func<bool>(this.X13Effect));
            base.AddExecutor(ExecutorType.Activate, 8824584);
            base.AddExecutor(ExecutorType.Repos, new Func<bool>(base.DefaultMonsterRepos));
            base.AddExecutor(ExecutorType.SpellSet, new Func<bool>(base.DefaultSpellSet));
        }

        // Token: 0x060003F9 RID: 1017 RVA: 0x00022086 File Offset: 0x00020286
        public override void OnNewTurn()
        {
            this.Hundunjuhe = false;
            this.Pohuaijian = false;
            this.Heidijia = false;

        }

        // Token: 0x060003FA RID: 1018 RVA: 0x000220A0 File Offset: 0x000202A0
        private bool DijiaSummon()
        {
            base.AI.SelectCard(9981423);
            base.AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }

        // Token: 0x060003FB RID: 1019 RVA: 0x000220D4 File Offset: 0x000202D4
        private bool DijiaEffect()
        {
            ClientCard LastChainCard = base.Util.GetLastChainCard();
            bool flag = LastChainCard != null && LastChainCard.Location == CardLocation.MonsterZone && !LastChainCard.IsDisabled();
            bool result;
            if (flag)
            {
                base.AI.SelectCard(LastChainCard);
                this.Heidijia = true;
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x060003FC RID: 1020 RVA: 0x00022128 File Offset: 0x00020328
        private bool IEffect()
        {
            bool flag = (base.Bot.GetMonstersExtraZoneCount() > 0 && base.Bot.GetMonsterCount() >= 4) || (base.Bot.GetMonstersExtraZoneCount() == 0 && base.Bot.GetMonsterCount() >= 3);
            return !flag;
        }

        // Token: 0x060003FD RID: 1021 RVA: 0x00022184 File Offset: 0x00020384
        private bool PohuaijianEffect()
        {
            bool flag = base.Card.Location == CardLocation.Hand;
            bool result;
            if (flag)
            {
                base.AI.SelectPosition(CardPosition.FaceUpAttack);
                result = true;
            }
            else
            {
                base.AI.SelectCard(76218313);
                this.Pohuaijian = true;
                result = true;
            }
            return result;
        }

        // Token: 0x060003FE RID: 1022 RVA: 0x000221D4 File Offset: 0x000203D4
        private bool PohuaijianzhanshiEffect()
        {
            bool flag = base.Duel.CurrentChain.Count > 0;
            bool result;
            if (flag)
            {
                result = (base.Duel.LastChainPlayer == 1);
            }
            else
            {
                base.AI.SelectCard(new int[]
                {
                    9982053,
                    9982051
                });
                result = true;
            }
            return result;
        }

        // Token: 0x060003FF RID: 1023 RVA: 0x00022234 File Offset: 0x00020434
        private bool DDzhanshouEffect()
        {
            ClientCard target = base.Util.GetBestEnemyMonster(false, false);
            return target != null;
        }

        // Token: 0x06000400 RID: 1024 RVA: 0x00022264 File Offset: 0x00020464
        private bool EyiEffect()
        {
            bool flag = (base.Util.ChainContainsCard(9981675) && base.Duel.LastChainPlayer == 0) || (base.Util.ChainContainsCard(8824590) && base.Duel.LastChainPlayer == 0);
            return !flag;
        }

        // Token: 0x06000401 RID: 1025 RVA: 0x000222C4 File Offset: 0x000204C4
        private bool ZuihuopuEffect()
        {
            bool flag = base.Util.ChainContainsCard(8824590) && base.Duel.LastChainPlayer == 1;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                bool flag2 = base.Duel.CurrentChain.Count > 0;
                result = (flag2 && base.Duel.LastChainPlayer == 1);
            }
            return result;
        }

        // Token: 0x06000402 RID: 1026 RVA: 0x0002232C File Offset: 0x0002052C
        private bool X9Effect()
        {
            base.AI.SelectCard(new int[]
            {
                8824591,
                8824584,
                8824590,
                8824601,
                8824602
            });
            base.AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }
        public bool ChainContainsSpellCard()
        {
            return Duel.CurrentChain.Any(card => card.HasType(CardType.Spell));
        }
        public override int OnAnnounceCard(IList<int> avail)
        {
            if (selectCardX11 && avail.Contains(8824590))
            {
                selectCardX11 = false;
                return 8824590;
            }
            else if (selectCardX111 && avail.Contains(8824591))
            {
                selectCardX111 = false;
                return 8824591;
            }
            else if (selectCardX112 && avail.Contains(8824584))
            {
                selectCardX112 = false;
                return 8824584;
            }
            else if(announceIDX13 && avail.Contains(9951088))
            {
                announceIDX13 = false;
                return 9951088; 
            }
            else if (announceIDX132 && avail.Contains(8824591))
            {
                announceIDX132 = false;
                return 8824591;
            }
            else if (announceIDX133 && avail.Contains(8824584))
            {
                announceIDX133 = false;
                return 8824584;
            }
            return avail[0];
        }
        // Token: 0x06000403 RID: 1027 RVA: 0x0002236C File Offset: 0x0002056C
        private bool X11Effect()
        {
            bool flag = base.Util.ChainContainsCard(8824590) && base.Duel.LastChainPlayer != 1;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                bool flag2 = base.Card.Overlays.Count >= 1;
                if (flag2)
                {
                    bool flag3 = Duel.CurrentChain.Count > 0 && ChainContainsSpellCard() && Duel.LastChainPlayer == 1;
                    if (flag3)
                    {
                        base.AI.SelectCard(8824590);
                        selectCardX11 = true;
                        //base.AI.SelectAnnounceID(8824590);
                        result = true;
                    }
                    else
                    {
                        result = true;
                    }
                }
                else
                {
                    bool flag4 = base.Duel.Phase == DuelPhase.Battle;
                    if (flag4)
                    {
                        result = true;
                    }
                    else
                    {
                        bool flag5 = base.Card.Location == CardLocation.Grave;
                        if (flag5)
                        {
                            result = true;
                        }
                        else
                        {
                            bool flag6 = base.Card.Location == CardLocation.MonsterZone;
                            if (flag6)
                            {
                                bool flag7 = Duel.Player == 0;
                                if (flag7)
                                {
                                    selectCardX111 = true;
                                    //base.AI.SelectAnnounceID(8824591);
                                    result = true;
                                }
                                else
                                {
                                    selectCardX112 = true;
                                    //base.AI.SelectAnnounceID(8824584);
                                    result = true;
                                }
                            }
                            else
                            {
                                result = false;
                            }
                        }
                    }
                }
            }
            return result;
        }

        // Token: 0x06000404 RID: 1028 RVA: 0x000224BC File Offset: 0x000206BC
        private bool X13Effect()
        {
            ClientCard target = base.Util.GetBestEnemyMonster(false, false);
            bool flag = base.Card.Location == CardLocation.MonsterZone;
            bool result;
            if (flag)
            {
                bool flag2 = base.Duel.Phase == DuelPhase.Standby;
                if (flag2)
                {
                    bool flag3 = base.Duel.Player == 0;
                    if (flag3)
                    {
                        bool flag4 = !this.X13;
                        if (flag4)
                        {
                            announceIDX13 = true;
                            //base.AI.SelectAnnounceID(9951088);
                            base.AI.SelectPosition(CardPosition.FaceUpDefence);
                            this.X13 = true;
                            result = true;
                        }
                        else
                        {
                            announceIDX132 = true;
                           // base.AI.SelectAnnounceID(8824591);
                            base.AI.SelectPosition(CardPosition.FaceUpDefence);
                            result = true;
                        }
                    }
                    else
                    {
                        bool flag5 = base.Duel.Player == 1;
                        result = (flag5 && false);
                    }
                }
                else
                {
                    bool flag6 = base.Card.Overlays.Count >= 1 && base.Duel.Phase != DuelPhase.Standby;
                    if (flag6)
                    {
                        base.AI.SelectCard(8824584);
                        announceIDX133 = true;
                        //base.AI.SelectAnnounceID(8824584);
                        result = true;
                    }
                    else
                    {
                        bool flag7 = target == null;
                        if (flag7)
                        {
                            bool flag8 = base.Bot.HasInMonstersZone(8824591, false, false, false);
                            if (flag8)
                            {
                                base.AI.SelectCard(8824591);
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                        else
                        {
                            base.AI.SelectCard(target);
                            result = true;
                        }
                    }
                }
            }
            else
            {
                bool flag9 = base.Card.Location == CardLocation.Grave;
                if (flag9)
                {
                    base.AI.SelectCard(new int[]
                    {
                        8824596,
                        8824594
                    });
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        // Token: 0x06000405 RID: 1029 RVA: 0x00022690 File Offset: 0x00020890
        private bool ShuizhaoSummon()
        {
            return !base.Bot.HasInMonstersZone(9950697, false, false, false) && !base.Bot.HasInGraveyard(9950697) && !base.Bot.HasInBanished(9950697);
        }

        // Token: 0x06000406 RID: 1030 RVA: 0x000226EC File Offset: 0x000208EC
        private bool ShuizhaoEffect()
        {
            base.AI.SelectCard(9950697);
            base.AI.SelectNextCard(9951605);
            base.AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        // Token: 0x06000407 RID: 1031 RVA: 0x00022730 File Offset: 0x00020930
        private bool PohuaijianxietongEffect()
        {
            ClientCard target = base.Util.GetBestEnemyMonster(false, false);
            bool flag = target != null;
            bool result;
            if (flag)
            {
                base.AI.SelectCard(9982055);
                base.AI.SelectNextCard(9982055);
                base.AI.SelectPosition(CardPosition.FaceUpAttack);
                result = true;
            }
            else
            {
                bool flag2 = base.Card.Location == CardLocation.Grave;
                if (flag2)
                {
                    base.AI.SelectNextCard(9982055);
                    base.AI.SelectPosition(CardPosition.FaceUpAttack);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        
        // Token: 0x06000408 RID: 1032 RVA: 0x000227C4 File Offset: 0x000209C4
        private bool DSEffect()
        {
            bool flag = base.Card.Location != CardLocation.Grave;
            bool result;
            if (flag)
            {
                base.AI.SelectCard(50954680);
                base.AI.SelectPosition(CardPosition.FaceUpAttack);
                result = true;
            }
            else
            {
                bool flag2 = base.Card.Location == CardLocation.Grave;
                if (flag2)
                {
                    bool flag3 = !this.Pohuaijian && !base.Bot.HasInHandOrInSpellZone(9982051);
                    if (flag3)
                    {
                        result = false;
                    }
                    else
                    {
                        base.AI.SelectCard(76218313);
                        base.AI.SelectPosition(CardPosition.FaceUpDefence);
                        result = true;
                    }
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        //卡组检查
        public int CheckRemainInDeck(int id)
        {
            switch (id)
            {
                case 9982378:
                    return Bot.GetRemainingCount(9982378, 1);
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
        // Token: 0x06000409 RID: 1033 RVA: 0x00022870 File Offset: 0x00020A70
        private bool JiushifangzhouEffect()
        {
            if (Card.Location != CardLocation.Grave)
            {
                if (!Bot.HasInGraveyard(9982378) && !Bot.HasInHand(9982378) && CheckRemainInDeck(9982378) <= 0 && !Bot.HasInExtra(50954680)) return false;
                {
                    AI.SelectCard(9982378);
                    AI.SelectYesNo(true);
                    AI.SelectNextCard(50954680);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
            }
            else return true;
        }

        // Token: 0x0600040A RID: 1034 RVA: 0x000228B4 File Offset: 0x00020AB4
        private bool FusheyunEffect()
        {
            ClientCard target = base.Util.GetBestEnemyCard(false, false);
            bool flag = this.Hundunjuhe || (target != null && (!target.HasType(CardType.Continuous) || !target.HasType(CardType.Monster)));
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                bool flag2 = base.Bot.GetMonsterCount() < base.Enemy.GetMonsterCount();
                result = flag2;
            }
            return result;
        }

        // Token: 0x0600040B RID: 1035 RVA: 0x00022928 File Offset: 0x00020B28
        private bool HundunjuheEffect()
        {
            ClientCard target = base.Util.GetBestEnemyMonster(false, false);
            bool flag = base.Enemy.GetMonsterCount() >= 5 && base.Enemy.GetMonstersExtraZoneCount() >= 1;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                bool flag2 = target != null;
                if (flag2)
                {
                    foreach (ClientCard card in base.Bot.MonsterZone)
                    {
                        using (IEnumerator<ClientCard> enumerator = base.Bot.Hand.GetEnumerator())
                        {
                            if (enumerator.MoveNext())
                            {
                                ClientCard card2 = enumerator.Current;
                                bool flag3 = ((card != null && card.HasType(CardType.Monster) && card.HasSetcode(214)) || (card2 != null && card2.HasType(CardType.Monster) && card2.HasSetcode(214))) && base.Bot.HasInSpellZone(9982051, false, false);
                                if (flag3)
                                {
                                    return false;
                                }
                                base.AI.SelectCard(target);
                                base.AI.SelectPosition(CardPosition.FaceUpAttack);
                                this.Hundunjuhe = true;
                                return true;
                            }
                        }
                    }
                }
                else
                {
                    bool flag4 = base.Card.Location == CardLocation.MonsterZone;
                    if (flag4)
                    {
                        bool flag5 = base.Card.IsOriginalCode(8824598);
                        if (flag5)
                        {
                            return false;
                        }
                        base.AI.SelectPosition(CardPosition.FaceUpDefence);
                        base.AI.SelectPlace(96);
                        return true;
                    }
                }
                result = false;
            }
            return result;
        }

        // Token: 0x04000294 RID: 660
        private List<int> Impermanence_list = new List<int>();

        // Token: 0x04000295 RID: 661
        private bool Hundunjuhe = false;

        // Token: 0x04000296 RID: 662
        private bool Pohuaijian = false;

        // Token: 0x04000297 RID: 663
        private bool Heidijia = false;

        // Token: 0x04000298 RID: 664
        private bool X13 = false;
        private bool selectCardX11 = false;
        private bool selectCardX111 = false;
        private bool selectCardX112 = false;
        private bool announceIDX13 = false;
        private bool announceIDX132 = false;
        private bool announceIDX133 = false;

        // Token: 0x02000092 RID: 146
        public class CardId
        {
            // Token: 0x040006BC RID: 1724
            public const int Dijia = 9981418;

            // Token: 0x040006BD RID: 1725
            public const int Pohuaijian = 9982053;

            // Token: 0x040006BE RID: 1726
            public const int Pohuaijianzhanshi = 9982055;

            // Token: 0x040006BF RID: 1727
            public const int Zhuopu = 9950484;

            // Token: 0x040006C0 RID: 1728
            public const int X3 = 9980715;

            // Token: 0x040006C1 RID: 1729
            public const int Shuizhao = 9951605;

            // Token: 0x040006C2 RID: 1730
            public const int Pohuaijianzhuangbei = 76218313;

            // Token: 0x040006C3 RID: 1731
            public const int Jiwang = 9982378;

            // Token: 0x040006C4 RID: 1732
            public const int Xingjing = 9950697;

            // Token: 0x040006C5 RID: 1733
            public const int Enhui = 9951558;

            // Token: 0x040006C6 RID: 1734
            public const int DDzhanshou = 9981632;

            // Token: 0x040006C7 RID: 1735
            public const int DS = 9982077;

            // Token: 0x040006C8 RID: 1736
            public const int Jiushifangzhou = 9982377;

            // Token: 0x040006C9 RID: 1737
            public const int Pohuaijianxietong = 9982051;

            // Token: 0x040006CA RID: 1738
            public const int Eyi = 9981675;

            // Token: 0x040006CB RID: 1739
            public const int Fusheyun = 9981724;

            // Token: 0x040006CC RID: 1740
            public const int Liwuyun = 9981725;

            // Token: 0x040006CD RID: 1741
            public const int Sdijia = 9981423;

            // Token: 0x040006CE RID: 1742
            public const int Tongtiaolong = 50954680;

            // Token: 0x040006CF RID: 1743
            public const int Huopu = 84013237;

            // Token: 0x040006D0 RID: 1744
            public const int Hundunjuhe = 8824590;

            // Token: 0x040006D1 RID: 1745
            public const int BingduI = 8824601;

            // Token: 0x040006D2 RID: 1746
            public const int BingduII = 8824602;

            // Token: 0x040006D3 RID: 1747
            public const int X9 = 8824594;

            // Token: 0x040006D4 RID: 1748
            public const int X11 = 8824596;

            // Token: 0x040006D5 RID: 1749
            public const int X13 = 8824598;

            // Token: 0x040006D6 RID: 1750
            public const int Bage = 8824584;

            // Token: 0x040006D7 RID: 1751
            public const int Saiwen = 9951088;

            // Token: 0x040006D8 RID: 1752
            public const int Kelai = 8824591;
        }
    }
}
