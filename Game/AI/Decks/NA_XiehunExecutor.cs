using System;
using System.Collections.Generic;
using YGOSharp.OCGWrapper.Enums;
using System.Linq;

namespace WindBot.Game.AI.Decks
{
    // Token: 0x02000051 RID: 81
    [Deck("Xiehun", "AI_Xiehun", "NotFinished")]
    public class XiehunExecutor : DefaultExecutor
    {
        // Token: 0x06000828 RID: 2088 RVA: 0x0005AC74 File Offset: 0x00058E74
        public XiehunExecutor(GameAI ai, Duel duel) : base(ai, duel)
        {

            base.AddExecutor(ExecutorType.SpSummon, 3040496);
            base.AddExecutor(ExecutorType.Activate, 30000067, XlalinsaiEffect);
            base.AddExecutor(ExecutorType.Activate, 30010000, Xyeffect);
            base.AddExecutor(ExecutorType.Activate, 14001007, XEffect);
            base.AddExecutor(ExecutorType.Activate, 3040496, new Func<bool>(this.HundunEffect));
            base.AddExecutor(ExecutorType.Activate, 30000995, new Func<bool>(this.DXjihe2Effect));
            base.AddExecutor(ExecutorType.Activate, 30000993, new Func<bool>(this.DXyuanxing2Effect));
            base.AddExecutor(ExecutorType.Activate, 30000997, new Func<bool>(this.DXzhencetianma2Effect));
            base.AddExecutor(ExecutorType.Activate, 30000991, new Func<bool>(this.DXtulusanxing2Effect));
            base.AddExecutor(ExecutorType.SpellSet, new Func<bool>(this.SpellSet));
            base.AddExecutor(ExecutorType.SpSummon, 1426500142, new Func<bool>(this.XYhuanying2Summon));
            base.AddExecutor(ExecutorType.Activate, 30000075, new Func<bool>(this.XkaliteEffect));
            base.AddExecutor(ExecutorType.Activate, 115848157);
            base.AddExecutor(ExecutorType.Activate, 91800273);
            base.AddExecutor(ExecutorType.Activate, 1426500142, new Func<bool>(this.XYhuanyingEffect));
            base.AddExecutor(ExecutorType.Activate, 30000033, new Func<bool>(this.XZkaliteEffect));
            base.AddExecutor(ExecutorType.Activate, 111011901);
            base.AddExecutor(ExecutorType.SpSummon, 30000660, new Func<bool>(this.XZwudingxingSummon));
            base.AddExecutor(ExecutorType.SpSummon, 111011904);
            base.AddExecutor(ExecutorType.Activate, 30000660, new Func<bool>(this.XZwudingxing2Effect));
            base.AddExecutor(ExecutorType.SpSummon, 27552504, new Func<bool>(this.ShunvSummon));
            base.AddExecutor(ExecutorType.Activate, 27552504, new Func<bool>(this.ShunvEffect));
            base.AddExecutor(ExecutorType.Activate, 30000660, new Func<bool>(this.XZwudingxingEffect));
            base.AddExecutor(ExecutorType.SpSummon, 30000615, new Func<bool>(this.XsaiweiSummon));
            base.AddExecutor(ExecutorType.Activate, 30000615, new Func<bool>(this.XsaiweiEffect));
            base.AddExecutor(ExecutorType.Activate, 30001009, new Func<bool>(this.XshikongyunshuEffect));
            base.AddExecutor(ExecutorType.Activate, 30000051, new Func<bool>(this.XbowenEffect));
            base.AddExecutor(ExecutorType.Activate, 30012000);
            base.AddExecutor(ExecutorType.Activate, 8824709);
            base.AddExecutor(ExecutorType.Activate, 1475311, new Func<bool>(this.AnzhiyouhuoEffect));
            base.AddExecutor(ExecutorType.Activate, 130000325);
            base.AddExecutor(ExecutorType.Activate, 8824680, new Func<bool>(this.YguairenEffect));
            base.AddExecutor(ExecutorType.Activate, 9950670, new Func<bool>(this.AjiedeEffect));
            base.AddExecutor(ExecutorType.Activate, 9950732, new Func<bool>(this.FyujinEffect));
            base.AddExecutor(ExecutorType.Activate, 30001005);
            base.AddExecutor(ExecutorType.Activate, 30000993, new Func<bool>(this.DXyuanxingEffect));
            base.AddExecutor(ExecutorType.Activate, 30000997, new Func<bool>(this.DXzhencetianmaEffect));
            base.AddExecutor(ExecutorType.Activate, 30000991, new Func<bool>(this.DXtulusanxingEffect));
            base.AddExecutor(ExecutorType.SpSummon, 30000029, new Func<bool>(this.XZanhunSummon));
            base.AddExecutor(ExecutorType.SpSummon, 60150802, new Func<bool>(this.ASxuwutansuoSummon));
            base.AddExecutor(ExecutorType.Activate, 60150802, new Func<bool>(this.ASxuwutansuoEffect));
            base.AddExecutor(ExecutorType.Activate, 130000699, new Func<bool>(this.ZminlongEffect));
            base.AddExecutor(ExecutorType.SpSummon, 130000699, new Func<bool>(this.ZminlongSummon));
            base.AddExecutor(ExecutorType.Activate, 30000029, new Func<bool>(this.XZanhunEffect));
            base.AddExecutor(ExecutorType.SpSummon, 30000027, new Func<bool>(this.XZanshiSummon));
            base.AddExecutor(ExecutorType.SpSummon, 30001007, new Func<bool>(this.DXshikonghuixuanSummon));
            base.AddExecutor(ExecutorType.Activate, 30001007, new Func<bool>(this.DXshikonghuixuanEffect));
            base.AddExecutor(ExecutorType.SpSummon, 30000031, new Func<bool>(this.XZxienvSummon));
            base.AddExecutor(ExecutorType.SpSummon, 30000033, new Func<bool>(this.XZkaliteSummon));
            base.AddExecutor(ExecutorType.Activate, 30000019, new Func<bool>(this.XqiangxiEffect));
            base.AddExecutor(ExecutorType.Activate, 30000015, new Func<bool>(this.XciyuandaohangEffect));
            base.AddExecutor(ExecutorType.Activate, 30000053, new Func<bool>(this.XZzaiqiEffect));
            base.AddExecutor(ExecutorType.Activate, 30000600, new Func<bool>(this.XsaluobakaEffect));
            base.AddExecutor(ExecutorType.Activate, 30004788, new Func<bool>(this.XzhatuosiEffect));
            base.AddExecutor(ExecutorType.Activate, 30000001, new Func<bool>(this.XZanyingmonvEffect));
            base.AddExecutor(ExecutorType.Activate, 30000995, new Func<bool>(this.DXjiheEffect));
            base.AddExecutor(ExecutorType.Activate, 111011904, new Func<bool>(this.YitaiEffect));
            base.AddExecutor(ExecutorType.Activate, 60150811, new Func<bool>(this.ASzhuanshengzhiyiEffect));
            base.AddExecutor(ExecutorType.SpSummon, 10086166, new Func<bool>(this.DusheSummon));
            base.AddExecutor(ExecutorType.Activate, 10086166);
            base.AddExecutor(ExecutorType.SpSummon, 30001002, new Func<bool>(this.DXciyuanSummon));
            base.AddExecutor(ExecutorType.Activate, 30001002, new Func<bool>(this.DXciyuanEffect));
            base.AddExecutor(ExecutorType.SpSummon, 30000600, new Func<bool>(this.XzhatuosiSummon));
            base.AddExecutor(ExecutorType.SpSummon, 30000075, new Func<bool>(this.XkaliteSummon));
            //扎托斯
            base.AddExecutor(ExecutorType.SpSummon, 30004788, new Func<bool>(this.XdalusikeSummon));
            base.AddExecutor(ExecutorType.Summon, 30000045);
            base.AddExecutor(ExecutorType.Activate, 60150822, new Func<bool>(this.ASxuwuyinduEffect));
            base.AddExecutor(ExecutorType.SpSummon, 41999284, new Func<bool>(this.LiziqiuSummon));
            base.AddExecutor(ExecutorType.Activate, 41999284);
            base.AddExecutor(ExecutorType.Activate, 30000045, new Func<bool>(this.XZchuanbozheEffect));
            base.AddExecutor(ExecutorType.Activate, 30000200, new Func<bool>(this.AnmoliEffect));
            base.AddExecutor(ExecutorType.Activate, 30012000, new Func<bool>(this.XjitanEffect));
            base.AddExecutor(ExecutorType.Activate, 28297833, new Func<bool>(this.SilingzhiyanEffect));
            base.AddExecutor(ExecutorType.Activate, 30000021, new Func<bool>(this.XlisanaEffect));
            base.AddExecutor(ExecutorType.Activate, 30000004, new Func<bool>(this.XZganransanboEffect));
            base.AddExecutor(ExecutorType.Activate, 30000027, new Func<bool>(this.XZanshiEffect));
            base.AddExecutor(ExecutorType.Activate, 30000031, new Func<bool>(this.XZxienvEffect));
            base.AddExecutor(ExecutorType.Activate, 30000085, new Func<bool>(this.XZsalisiEffect));
            base.AddExecutor(ExecutorType.SpSummon, 30000010, new Func<bool>(this.XZhuimiemozhuSummon));
            base.AddExecutor(ExecutorType.SpSummon, 30000042, new Func<bool>(this.XZganranyuanheSummon));
            base.AddExecutor(ExecutorType.Activate, 30000013, new Func<bool>(this.XsasaliteEffect));
            base.AddExecutor(ExecutorType.SpSummon, 30000605, new Func<bool>(this.XdalusikeSummon));
            base.AddExecutor(ExecutorType.Activate, 30000007, new Func<bool>(this.XZfeixuEffect));
            base.AddExecutor(ExecutorType.Activate, 30000047, new Func<bool>(this.XZganranEffect));
            base.AddExecutor(ExecutorType.Activate, 30000615, new Func<bool>(this.Xsaiwei2Effect));
            base.AddExecutor(ExecutorType.Activate, 30000615, new Func<bool>(this.Xsaiwei3Effect));
            base.AddExecutor(ExecutorType.Activate, 30000470, new Func<bool>(this.XZsilanwoSummon));
            base.AddExecutor(ExecutorType.Activate, 30000040, new Func<bool>(this.XZbeiqingshiEffect));
            base.AddExecutor(ExecutorType.Activate, 30000011, new Func<bool>(this.XladaluoEffect));
            base.AddExecutor(ExecutorType.SpSummon, 30000023, new Func<bool>(this.XZmohualongpuSummon));
            base.AddExecutor(ExecutorType.Activate, 30000023, new Func<bool>(this.XZmohualongpuEffect));
            base.AddExecutor(ExecutorType.Activate, 30000025, new Func<bool>(this.XZchongjiboEffect));
            base.AddExecutor(ExecutorType.Activate, 30000007);
            base.AddExecutor(ExecutorType.Activate, 30000017, new Func<bool>(this.XZganrankuosanEffect));
            base.AddExecutor(ExecutorType.Summon, 30000995);
            base.AddExecutor(ExecutorType.Summon, 28297833);
            base.AddExecutor(ExecutorType.SpSummon, 30000001, new Func<bool>(this.XZanyingmonvSummon));
            base.AddExecutor(ExecutorType.SpSummon, 30000430);
            base.AddExecutor(ExecutorType.Activate, 30000430, new Func<bool>(this.XshenliEffect));
            base.AddExecutor(ExecutorType.SpSummon, 30001012, DXshikongzhongcaiSummon);
            base.AddExecutor(ExecutorType.Activate, 30001012);
            base.AddExecutor(ExecutorType.SpSummon, 1426500142, new Func<bool>(this.XYhuanyingSummon));
            base.AddExecutor(ExecutorType.Summon, 30000067);
            base.AddExecutor(ExecutorType.Summon, 115848157);
            base.AddExecutor(ExecutorType.Summon, 30000021);
            //base.AddExecutor(ExecutorType.Activate, 14001007);
            base.AddExecutor(ExecutorType.Repos, new Func<bool>(base.DefaultMonsterRepos));
            base.AddExecutor(ExecutorType.SpellSet, new Func<bool>(base.DefaultSpellSet));

        }
        //表
        List<int> select_list = new List<int>
        {
           30000660, 28297833,30001005, 30000013, 30000991,9950732,30000001,30000997,30000993,91800273,30000085,130000325,30000040,130000699,60150802,
30000991,9950670,30000047,30000023,30000045,30000021,30000067,30000995,115848157,1475311,8824709,14001007,30000025,30000200,300000080,30000470,
30000033,30000075,30000605,60150802,111011901,300000015,30000017,30000019,30000007,60150811,30000051,30000053,8824680,
3040496,1426500142,30000430,111011904,30000615,27552504,30001012,30000042,30001007,30000029,30000031,41999284,30000027
        };
        // Token: 0x06000829 RID: 2089 RVA: 0x0005B670 File Offset: 0x00059870
        public int Link(int id)
        {
            bool flag = id == 30000042 || id == 30010000;
            int result;
            if (flag)
            {
                result = 4;
            }
            else
            {
                bool flag2 = id == 30001007 || id == 30000010;
                if (flag2)
                {
                    result = 3;
                }
                else
                {
                    bool flag3 = id == 30000029 || id == 30001002 || id == 30000031;
                    if (flag3)
                    {
                        result = 2;
                    }
                    else
                    {
                        result = 1;
                    }
                }
            }
            return result;
        }

        // Token: 0x0600082A RID: 2090 RVA: 0x0005B6D4 File Offset: 0x000598D4
        public override void OnNewTurn()
        {
            this.Fyujin = false;
            this.Ajiede = false;
            this.XZkalite = false;
            this.Xsaiwei = false;
            this.Xsaiwei2 = false;
            this.Anmoli = false;
            this.XZganran = false;
            this.Xqiangxi = false;
            this.DXjianmie = false;
            this.XZwudingxing = false;
            this.XZganransanbo = false;
            this.DXciyuan = false;
            this.XZmohualongpu = false;
            this.XZmohualongpu2 = false;
            this.XZanshi = false;
            this.Zminglong = false;
            this.Banyingxiong = false;
            this.Ciyuanxiyin = false;
            this.Xzhatuosi = false;
            this.Xshikongyunshu = false;
            this.Shunv = false;
            this.XZanhun = false;
            this.Xzhatuosi2 = false;
            this.Yitai = false;
            this.XZganrankuosan = false;
            this.Xkalite = false;
            this.DXyuanxing = false;
            XZanhun2 = false;
        }
        //拉林赛
        private bool XlalinsaiEffect()
        {
            return Duel.Player == 1;
        }
        //邪魂之源
        private bool Xyeffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (Card.Overlays.Count == 1)
                {
                    if ((Bot.Hand.Count + Bot.Graveyard.Count) * 300 >= Enemy.LifePoints) return true;
                    return false;
                }
                return true;
            }
            return false;
        }
        private bool XEffect()
        {
            if (Bot.Banished.Count >= 29) return true;
            return false;
        }
        //邪魂 时空仲裁机关
        private bool DXshikongzhongcaiSummon()
        {
            int link_count = 0;
            if (Bot.GetMonstersInExtraZone().Count + Bot.GetMonstersMainZoneCount() - Bot.GetCountCardInZone(Bot.MonsterZone, CardId.XZwudingxing) - 1 < 4 && Bot.HasInMonstersZone(CardId.XYyaaosike)) return false;
            else
            {
                IList<ClientCard> list = new List<ClientCard>();
                foreach (ClientCard l_check in Bot.GetMonstersInExtraZone())
                {
                    if (l_check.IsFacedown() || Link(l_check.Id) >= 4) continue;
                    if (Link(l_check.Id) == 2)
                    {
                        list.Add(l_check);
                        link_count += 1;
                    }
                    else if (Link(l_check.Id) == 3)
                    {
                        list.Add(l_check);
                        link_count += 1;
                    }
                    else break;
                }
                foreach (ClientCard t_check in Bot.GetMonstersInMainZone())
                {
                    if (t_check.IsFacedown() || Link(t_check.Id) >= 4 || Link(t_check.Id) >= 3 || t_check.IsCode(CardId.XZwudingxing, CardId.XYyaaosike, CardId.Xshenli)) continue;
                    if (Link(t_check.Id) == 1)
                    {
                        if (t_check.IsFacedown() || Link(t_check.Id) >= 4 || Link(t_check.Id) >= 3 || t_check.IsCode(CardId.XZwudingxing, CardId.XYyaaosike, CardId.Xshenli)) continue;
                        list.Add(t_check);
                        link_count += 1;
                        if (link_count >= 4) break;
                    }
                    else if (Link(t_check.Id) == 2)
                    {
                        if (t_check.IsFacedown() || Link(t_check.Id) >= 4 || Link(t_check.Id) >= 3 || t_check.IsCode(CardId.XZwudingxing, CardId.XYyaaosike, CardId.Xshenli)) continue;
                        list.Add(t_check);
                        link_count += 1;
                        if (link_count >= 4) break;
                    }

                }
                if (link_count >= 4)
                {
                    AI.SelectMaterials(list);
                    return true;
                }
                return false;
            }
        }

        // Token: 0x0600082B RID: 2091 RVA: 0x0005B7A0 File Offset: 0x000599A0
        public bool SpellSet()
        {
            bool flag = base.Bot.HasInHand(111011901);
            bool result;
            if (flag)
            {
                bool flag2 = base.Card.IsCode(111011901);
                result = flag2;
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x0600082C RID: 2092 RVA: 0x0005B7E4 File Offset: 0x000599E4
        private bool XZganranEffect()
        {
            List<ClientCard> targets = new List<ClientCard>();
            List<ClientCard> list = base.Bot.GetGraveyardMonsters();
            List<ClientCard> targets2 = new List<ClientCard>();
            List<ClientCard> list2 = base.Bot.GetGraveyardSpells();
            List<ClientCard> targets3 = new List<ClientCard>();
            List<ClientCard> list3 = base.Bot.GetGraveyardTraps();
            bool flag = base.Card.Location == CardLocation.MonsterZone;
            bool result;
            if (flag)
            {
                bool flag2 = targets == null && targets2 == null && targets3 == null;
                if (flag2)
                {
                    base.AI.SelectCard(30000015);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                bool flag3 = base.Card.Location == CardLocation.Removed;
                if (flag3)
                {
                    base.AI.SelectCard(new int[]
                    {
                        111011901,
                        30000047,
                        30000001,
                        130000325,
                        30000047,
                        30000045,
                        28297833,
                        30000067,
                        130000325,
                        30000075
                    });
                    base.AI.SelectNextCard(30000470);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        // Token: 0x0600082D RID: 2093 RVA: 0x0005B8C0 File Offset: 0x00059AC0
        private bool YguairenEffect()
        {
            ClientCard target = base.Bot.Banished.GetFirstMatchingFaceupCard((ClientCard card) => card.IsFacedown());
            bool flag = base.Card.Location == CardLocation.Extra;
            bool result;
            if (flag)
            {
                result = true;
            }
            else
            {
                bool flag2 = base.Card.Location == CardLocation.Removed;
                if (flag2)
                {
                    bool flag3 = target != null;
                    if (flag3)
                    {
                        base.AI.SelectCard(target);
                        result = true;
                    }
                    else
                    {
                        bool flag4 = base.Bot.HasInExtra(30000615) && target == null;
                        if (flag4)
                        {
                            base.AI.SelectCard(new int[]
                            {
                                111011901,
                                30000997,
                                30000085,
                                30000470,
                                30000033,
                                30000001,
                                28297833,
                                27552504,
                                28297833,
                                30000031,
                                30000015,
                                30000019,
                                30000021,
                                9950670,
                                115848157,
                                30000011,
                                30000007,
                                30012000
                            });
                            result = true;
                        }
                        else
                        {
                            bool flag5 = !base.Bot.HasInExtra(30000615) && target == null;
                            if (flag5)
                            {
                                base.AI.SelectCard(new int[]
                                {
                                    111011901,
                                    30000997,
                                    30000085,
                                    28297833,
                                    30000470,
                                    30000033,
                                    30000001,
                                    28297833,
                                    27552504,
                                    28297833,
                                    30000031,
                                    30000015,
                                    30000019,
                                    30000021,
                                    9950670,
                                    115848157,
                                    30000011,
                                    30000007,
                                    30012000
                                });
                                result = true;
                            }
                            else
                            {
                                base.AI.SelectPosition(CardPosition.FaceUpAttack);
                                result = true;
                            }
                        }
                    }
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        // Token: 0x0600082E RID: 2094 RVA: 0x0005B9EC File Offset: 0x00059BEC
        private bool XshenliEffect()
        {
            bool flag = base.Card.Location == CardLocation.MonsterZone;
            bool result;
            if (flag)
            {
                bool flag2 = base.Duel.Phase == DuelPhase.End;
                if (flag2)
                {
                    base.AI.SelectOption(1);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                bool flag3 = base.Card.Location != CardLocation.MonsterZone;
                result = flag3;
            }
            return result;
        }

        // Token: 0x0600082F RID: 2095 RVA: 0x0005BA58 File Offset: 0x00059C58
        private bool ZminlongEffect()
        {
            bool flag = base.Card.Location == CardLocation.Hand;
            bool result;
            if (flag)
            {
                this.Zminglong = true;
                result = true;
            }
            else
            {
                bool flag2 = base.Card.Location == CardLocation.Removed;
                if (flag2)
                {
                    base.AI.SelectCard(new int[]
                    {
                        30000033,
                        30000075,
                        130000325
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

        // Token: 0x06000830 RID: 2096 RVA: 0x0005BAC0 File Offset: 0x00059CC0
        private bool HundunEffect()
        {
            bool flag = base.Card.Location == CardLocation.MonsterZone;
            bool result;
            if (flag)
            {
                base.AI.SelectCard(new int[]
                {
                    60150802,
                    30000660,
                    130000699
                });
                result = true;
            }
            else
            {
                bool flag2 = base.Card.Location == CardLocation.Grave;
                result = flag2;
            }
            return result;
        }

        // Token: 0x06000831 RID: 2097 RVA: 0x0005BB20 File Offset: 0x00059D20
        private bool XZmohualongpuSummon()
        {
            base.AI.SelectPosition(CardPosition.FaceUpDefence);
            this.XZmohualongpu = true;
            return true;
        }

        // Token: 0x06000832 RID: 2098 RVA: 0x0005BB48 File Offset: 0x00059D48
        private bool YitaiEffect()
        {
            ClientCard LastChainCard = base.Util.GetLastChainCard();
            bool flag = LastChainCard != null;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                bool flag2 = !base.Bot.HasInMonstersZone(30010000, false, false, false);
                if (flag2)
                {
                    base.AI.SelectCard(new int[]
                    {
                        111011901,
                        8824709,
                        1475311
                    });
                    result = true;
                }
                else
                {
                    base.AI.SelectCard(new int[]
                    {
                        8824709,
                        1475311
                    });
                    result = true;
                }
            }
            return result;
        }

        // Token: 0x06000833 RID: 2099 RVA: 0x0005BBD4 File Offset: 0x00059DD4
        private bool SilingzhiyanEffect()
        {
            bool flag = base.Bot.Deck.Count <= 5 && base.Duel.Player == 1;
            return !flag;
        }

        // Token: 0x06000834 RID: 2100 RVA: 0x0005BC14 File Offset: 0x00059E14
        private bool AnmoliEffect()
        {
            base.AI.SelectCard(14001007);
            base.AI.SelectNextCard(new int[]
            {
                60150802,
                60150802
            });
            return true;
        }

        // Token: 0x06000835 RID: 2101 RVA: 0x0005BC5C File Offset: 0x00059E5C
        private bool AnzhiyouhuoEffect()
        {
            foreach (ClientCard card in base.Bot.Hand)
            {
                bool flag = !card.HasAttribute(CardAttribute.Dark);
                if (flag)
                {
                    return false;
                }
                bool flag2 = card.HasAttribute(CardAttribute.Dark);
                if (flag2)
                {
                    base.AI.SelectCard(new int[]
                    {
                        30000013,
                        28297833,
                        30000053,
                        30000005,
                        30000991,
                        91800273,
                        30000033,
                        30000007,
                        30000023,
                        91800273,
                        130000699
                    });
                    return true;
                }
            }
            return false;
        }

        // Token: 0x06000836 RID: 2102 RVA: 0x0005BCFC File Offset: 0x00059EFC
        //暗魂效果
        private bool XZanhunEffect()
        {
            bool flag = base.Card.Location == CardLocation.MonsterZone;
            bool result;
            if (flag)
            {
                base.AI.SelectCard(30000033);
                XZanhun2 = true;
                result = true;
            }
            else
            {
                bool flag2 = base.Card.Location == CardLocation.Removed;
                if (flag2)
                {
                    base.AI.SelectCard(new int[]
                    {
                        30000013,
                        30000997,
                        28297833,
                        30000053,
                        30000005,
                        30000991,
                        30000033,
                        30000007,
                        60150802,
                        30000995,
                        30000045,
                        130000699
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

        // Token: 0x06000837 RID: 2103 RVA: 0x0005BD70 File Offset: 0x00059F70
        private bool XZmohualongpuEffect()
        {
            base.AI.SelectCard(30000001);
            base.AI.SelectPosition(CardPosition.FaceUpAttack);
            this.XZmohualongpu2 = true;
            return true;
        }

        // Token: 0x06000838 RID: 2104 RVA: 0x0005BDA8 File Offset: 0x00059FA8
        private bool XZbeiqingshiEffect()
        {
            bool flag = base.Card.Location == CardLocation.Removed;
            bool result;
            if (flag)
            {
                base.AI.SelectCard(new int[]
                {
                    30000051,
                    30000053,
                    30001009,
                    30000004
                });
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x06000839 RID: 2105 RVA: 0x0005BDF0 File Offset: 0x00059FF0
        private bool XYhuanyingEffect()
        {
            base.AI.SelectCard(new int[]
            {
                28297833,
                60150802,
                30000053,
                30001009,
                30000660,
                30000004,
                30000660,
                28297833,
                30000053,
                30001009,
                30000004,
                30000605,
                30000075
            });
            return true;
        }

        // Token: 0x0600083A RID: 2106 RVA: 0x0005BE24 File Offset: 0x0005A024
        private bool XladaluoEffect()
        {
            ClientCard target = base.Util.GetBestEnemySpell(false);
            bool flag = target != null;
            bool result;
            if (flag)
            {
                base.AI.SelectCard(target);
                result = true;
            }
            else
            {
                result = true;
            }
            return result;
        }

        // Token: 0x0600083B RID: 2107 RVA: 0x0005BE60 File Offset: 0x0005A060
        private bool XZsilanwoSummon()
        {
            bool flag = !base.Bot.HasInMonstersZone(30000615, false, false, false);
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                bool flag2 = base.Card.Location == CardLocation.Hand || base.Card.Location == CardLocation.Grave;
                if (flag2)
                {
                    base.AI.SelectCard(new int[]
                    {
                        30000615,
                        30000029,
                        30000013,
                        30000001,
                        30000045,
                        30000013,
                        30000007
                    });
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

        // Token: 0x0600083C RID: 2108 RVA: 0x0005BEE4 File Offset: 0x0005A0E4
        //达卢斯克
        private bool XdalusikeSummon()
        {
            foreach (ClientCard card in Bot.GetGraveyard())
            {
                bool flag = base.Card.Location == CardLocation.Hand || base.Card.Location == CardLocation.Grave;
                if (flag)
                {
                    bool flag2 = (base.Bot.GetMonsterCount() >= 6 && base.Bot.GetMonstersExtraZoneCount() >= 1) || (base.Bot.GetMonsterCount() >= 5 && base.Bot.GetMonstersExtraZoneCount() == 0);
                    if (flag2)
                    {
                        return false;
                    }
                    bool flag3 = base.Bot.GetGraveyardCount() >= 5;
                    if (flag3)
                    {
                        int spell_count = 0;
                        IList<ClientCard> grave = base.Bot.Graveyard;
                        IList<ClientCard> all = new List<ClientCard>();
                        foreach (ClientCard check in grave)
                        {
                            bool flag4 = check.IsCode(28297833);
                            if (flag4)
                            {
                                all.Add(check);
                            }
                        }
                        foreach (ClientCard check2 in grave)
                        {
                            bool flag5 = check2.HasType(CardType.Spell) || check2.HasType(CardType.Trap);
                            if (flag5)
                            {
                                spell_count++;
                                all.Add(check2);
                            }
                        }
                        foreach (ClientCard check3 in grave)
                        {
                            bool flag6 = check3.HasType(CardType.Monster);
                            if (flag6)
                            {
                                all.Add(check3);
                            }
                        }
                        base.AI.SelectCard(all);
                        base.AI.SelectPosition(CardPosition.FaceUpAttack);
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        // Token: 0x0600083D RID: 2109 RVA: 0x0005C154 File Offset: 0x0005A354
        private bool XjitanEffect()
        {
            int a = 0;
            for (; ; )
            {
                bool flag = a == 0;
                if (flag)
                {
                    break;
                }
                base.AI.SelectCard(30000015);
                a++;
                if (a <= 1)
                {
                    goto Block_4;
                }
            }
            bool flag2 = base.Bot.HasInExtra(30001012);
            if (!flag2)
            {
                return false;
            }
            int option = 3;
            base.AI.SelectCard(30001012);
            bool flag3 = base.ActivateDescription != base.Util.GetStringId(30012000, option);
            if (flag3)
            {
                return false;
            }
            base.AI.SelectCard(30001012);
            a++;
            return true;
        Block_4:
            return false;
        }

        // Token: 0x0600083E RID: 2110 RVA: 0x0005C20C File Offset: 0x0005A40C
        //邪魂 卡利特效果
        private bool XkaliteEffect()
        {
            bool flag = base.Card.Location == CardLocation.MonsterZone;
            bool result;
            if (flag)
            {
                foreach (ClientCard card in base.Bot.GetGraveyard())
                {
                    foreach (ClientCard card2 in base.Bot.Hand)
                    {
                        bool flag2 = base.Bot.ExtraDeck.GetMonsters() != null;
                        if (flag2)
                        {
                            bool flag3 = (base.Bot.GetMonsterCount() >= 3 && base.Bot.GetMonstersExtraZoneCount() == 0) || (base.Bot.GetMonsterCount() >= 4 && base.Bot.GetMonstersExtraZoneCount() != 0);
                            if (!flag3)
                            {
                                return false;
                            }
                            bool flag4 = card != null;
                            if (flag4 || Bot.GetHandCount() > 0 || Bot.Graveyard.Count > 0 || Bot.GetSpells().Count > 0)
                            {
                                base.AI.SelectCard(CardLocation.Grave | CardLocation.Hand | CardLocation.SpellZone);
                                bool flag5 = base.Bot.HasInExtra(30000615);
                                if (flag5)
                                {
                                    base.AI.SelectNextCard(new int[]
                                    {
                                        130000699,
                                        30000033,
                                        30000470,
                                        30000075
                                    });
                                }
                                else
                                {
                                    base.AI.SelectNextCard(new int[]
                                    {
                                        30000033,
                                        30000470,
                                        30000075,
                                        130000699
                                    });
                                }
                                this.Xkalite = true;
                                return true;
                            }
                            bool flag6 = card2 != null;
                            if (flag6)
                            {
                                base.AI.SelectCard(card2);
                                bool flag7 = base.Bot.HasInExtra(30000615);
                                if (flag7)
                                {
                                    base.AI.SelectNextCard(new int[]
                                    {
                                        130000699,
                                        30000033,
                                        30000470,
                                        30000075
                                    });
                                }
                                else
                                {
                                    base.AI.SelectNextCard(new int[]
                                    {
                                        30000033,
                                        30000470,
                                        30000075,
                                        130000699
                                    });
                                }
                                this.Xkalite = true;
                                return true;
                            }
                            base.AI.SelectCard(new int[]
                            {
                                30000021,
                                30000013,
                                28297833,
                                30000025,
                                30000053,
                                30000005,
                                30000991,
                                91800273,
                                30000033,
                                30000007,
                                30001009,
                                30000051,
                                30000997
                            });
                            bool flag8 = base.Bot.HasInExtra(30000615);
                            if (flag8)
                            {
                                base.AI.SelectNextCard(new int[]
                                {
                                    130000699,
                                    30000033,
                                    30000470,
                                    30000075
                                });
                            }
                            else
                            {
                                base.AI.SelectNextCard(new int[]
                                {
                                    30000033,
                                    30000470,
                                    30000075,
                                    130000699
                                });
                            }
                            this.Xkalite = true;
                            return true;
                        }
                    }
                }
                result = false;
            }
            else
            {
                bool flag9 = base.Card.Location == CardLocation.Removed;
                if (flag9)
                {
                    base.AI.SelectCard(30004788);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        // Token: 0x0600083F RID: 2111 RVA: 0x0005C4F8 File Offset: 0x0005A6F8
        private bool XsasaliteEffect()
        {
            ClientCard target = base.Util.GetBestEnemyMonster(true, false);
            bool flag = target != null;
            bool result;
            if (flag)
            {
                base.AI.SelectCard(target);
                result = true;
            }
            else
            {
                base.AI.SelectCard(30001012);
                result = true;
            }
            return result;
        }

        // Token: 0x06000840 RID: 2112 RVA: 0x0005C548 File Offset: 0x0005A748
        private bool XsaiweiSummon()
        {
            base.AI.SelectPosition(CardPosition.FaceUpAttack);
            base.AI.SelectMaterials(new int[]
            {
                30000660,
                30000660,
                30000075
            });
            return true;
        }

        // Token: 0x06000841 RID: 2113 RVA: 0x0005C588 File Offset: 0x0005A788
        private bool Xsaiwei3Effect()
        {
            bool xsaiwei = this.Xsaiwei2;
            bool result;
            if (xsaiwei)
            {
                base.AI.SelectCard(new int[]
                {
                    30000075,
                    30000660
                });
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        List<int> Xciyuandaohang_list = new List<int>
        {
             91800273, 30000660,  30000660, 28297833, 30001005,30000013,30000991, 30000991,30000660, 28297833,30001005, 30000013, 30000991,9950732,30000001,30000997,30000993,91800273,30000085,130000325,30000040,130000699,60150802,
30000991,9950670,30000047,30000023,30000045,30000021,30000067,30000995,115848157,1475311,8824709,14001007,30000025,30000200,300000080,30000470,
30000033,30000075,30000605,60150802,111011901,300000015,30000017,30000019,30000007,60150811,30000051,30000053,8824680,
3040496,1426500142,30000430,111011904,30000615,27552504,30001012,30000042,30001007,30000029,30000031,41999284,30000027
        };

        // Token: 0x06000842 RID: 2114 RVA: 0x0005C5CC File Offset: 0x0005A7CC
        //邪魂次元导航
        private bool XciyuandaohangEffect()
        {
            if (Bot.GetMonsterCount() + Bot.Hand.Count + Bot.Graveyard.Count <= 3 && Bot.HasInMonstersZone(CardId.XYyaaosike)) return false;
            foreach (ClientCard card in base.Bot.GetMonsters())
            {
                bool flag = card == null;
                if (flag)
                {
                    bool flag2 = !this.XZganrankuosan;
                    if (flag2)
                    {
                        if (Bot.GetGraveyard().Count >= 2)
                        {
                            AI.SelectCard(CardLocation.Grave);
                        }
                        else if (Bot.GetGraveyard().Count > 0 && Bot.Graveyard.Count + Bot.Hand.Count >= 2)
                        {
                            AI.SelectCard(CardLocation.Grave | CardLocation.Hand);
                        }
                        else if (Bot.Hand.Count >= 3)
                        {
                            AI.SelectCard(CardLocation.Hand);
                        }
                        else
                        {
                            AI.SelectCard(Xciyuandaohang_list);
                        }
                        AI.SelectNextCard(new int[]
                        {
                            30000017,
                            30000019,
                            30000007
                        });
                        return true;
                    }
                    else
                    {
                        if (Bot.GetGraveyard().Count >= 2)
                        {
                            AI.SelectCard(CardLocation.Grave);
                        }
                        else if (Bot.GetGraveyard().Count > 0 && Bot.Graveyard.Count + Bot.Hand.Count >= 2)
                        {
                            AI.SelectCard(CardLocation.Grave | CardLocation.Hand);
                        }
                        else if (Bot.Hand.Count >= 3)
                        {
                            AI.SelectCard(CardLocation.Hand);
                        }
                        else
                        {
                            AI.SelectCard(Xciyuandaohang_list);
                        }
                        base.AI.SelectNextCard(new int[]
                        {
                        30000017,
                        30012000,
                        30000007
                        });
                        return true;
                    }
                }
                else
                {
                    bool flag3 = card != null;
                    if (flag3)
                    {
                        bool flag4 = !this.XZganrankuosan;
                        if (flag4)
                        {
                            if (Bot.GetGraveyard().Count >= 2)
                            {
                                AI.SelectCard(CardLocation.Grave);
                            }
                            else if (Bot.GetGraveyard().Count > 0 && Bot.Graveyard.Count + Bot.Hand.Count >= 2)
                            {
                                AI.SelectCard(CardLocation.Grave | CardLocation.Hand);
                            }
                            else if (Bot.Hand.Count >= 3)
                            {
                                AI.SelectCard(CardLocation.Hand);
                            }
                            else
                            {
                                AI.SelectCard(Xciyuandaohang_list);
                            }
                            base.AI.SelectNextCard(new int[]
                            {
                                30000017,
                                30012000,
                                30000007
                            });
                            return true;
                        }
                        else
                        {
                            if (Bot.GetGraveyard().Count >= 2)
                            {
                                AI.SelectCard(CardLocation.Grave);
                            }
                            else if (Bot.GetGraveyard().Count > 0 && Bot.Graveyard.Count + Bot.Hand.Count >= 2)
                            {
                                AI.SelectCard(CardLocation.Grave | CardLocation.Hand);
                            }
                            else if (Bot.Hand.Count >= 3)
                            {
                                AI.SelectCard(CardLocation.Hand);
                            }
                            else
                            {
                                AI.SelectCard(Xciyuandaohang_list);
                            }
                            base.AI.SelectNextCard(new int[]
                            {
                            30012000,
                            30000007
                            });
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // Token: 0x06000843 RID: 2115 RVA: 0x0005C77C File Offset: 0x0005A97C
        private bool Xsaiwei2Effect()
        {
            bool flag = this.Xsaiwei && !this.Xsaiwei2;
            bool result;
            if (flag)
            {
                base.AI.SelectCard(new int[]
                {
                    30000075,
                    30000660
                });
                this.Xsaiwei2 = true;
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x06000844 RID: 2116 RVA: 0x0005C7D8 File Offset: 0x0005A9D8
        private bool XsaiweiEffect()
        {
            bool flag = base.Card.Location == CardLocation.MonsterZone;
            bool result;
            if (flag)
            {
                int a = 0;
                for (; ; )
                {
                    bool flag2 = a == 0;
                    if (flag2)
                    {
                        break;
                    }
                    bool flag3 = !this.Xsaiwei && a == 1;
                    if (!flag3)
                    {
                        goto IL_91;
                    }
                    base.AI.SelectCard(new int[]
                    {
                        30000075,
                        30000660
                    });
                    a++;
                    this.Xsaiwei = true;
                    if (a <= 1)
                    {
                        goto Block_5;
                    }
                }
                base.AI.SelectCard(new int[]
                {
                    30000470,
                    30000605,
                    30000001,
                    30000470
                });
                a++;
                return true;
            IL_91:
                a++;
                return false;
            Block_5:
                result = false;
            }
            else
            {
                bool flag4 = base.Card.Location == CardLocation.Removed;
                if (flag4)
                {
                    base.AI.SelectCard(30000660);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        // Token: 0x06000845 RID: 2117 RVA: 0x0005C8C4 File Offset: 0x0005AAC4
        private bool DXshikongEffect()
        {
            bool flag = base.Card.Location == CardLocation.MonsterZone;
            bool result;
            if (flag)
            {
                result = true;
            }
            else
            {
                bool flag2 = base.Card.Location == CardLocation.Removed;
                if (flag2)
                {
                    bool flag3 = base.Duel.Player == 0 && base.Enemy.Deck.Count == 0;
                    result = !flag3;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        // Token: 0x06000846 RID: 2118 RVA: 0x0005C930 File Offset: 0x0005AB30
        private bool XZfeixuEffect()
        {
            bool flag = base.Card.Location == CardLocation.FieldZone;
            bool result;
            if (flag)
            {
                result = true;
            }
            else
            {
                bool flag2 = base.Card.Location == CardLocation.Removed;
                if (flag2)
                {
                    base.AI.SelectCard(new int[]
                    {
                        60150802,
                        28297833,
                        30000997,
                        91800273,
                        30000021,
                        30000033
                    });
                    base.AI.SelectNextCard(new int[]
                    {
                        60150802,
                        1475311,
                        30004788,
                        30000017,
                        30000015,
                        30000200,
                        30000007
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

        // Token: 0x06000847 RID: 2119 RVA: 0x0005C9B0 File Offset: 0x0005ABB0
        private bool XZhuimiemozhuSummon()
        {
            base.AI.SelectMaterials(new int[]
            {
                30000027,
                30000029,
                30000031
            });
            return true;
        }

        // Token: 0x06000848 RID: 2120 RVA: 0x0005C9E0 File Offset: 0x0005ABE0
        //恶邪女 召唤
        private bool XZxienvSummon()
        {
            bool flag = !this.XZanhun || (base.Bot.HasInMonstersZone(30001007, false, false, false) && base.Bot.GetMonsterCount() == 2);
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                /*  foreach (ClientCard t_check in base.Bot.GetMonsters())
                   {
                       bool flag2 = t_check.LinkCount >= 2 || t_check.HasType(CardType.Xyz);
                       if (flag2)
                       {
                       }
                   }
                   base.AI.SelectMaterials(new int[]
                   {
                       30000021,
                       9950732,
                       41999284,
                       30000040,
                       30000023,
                       30000045,
                       30004788,
                       111011904,
                       9950670,
                       111011904,
                       111011904,
                       30000993,
                       130000699
                   });
                   result = true;
               }
               return result;
               */
                if ((GetCountAttributeCardInZone(Bot.MonsterZone, CardAttribute.Dark) - Bot.GetCountCardInZone(Bot.MonsterZone, CardId.XZwudingxing) <= 1) && Bot.HasInMonstersZone(CardId.XYyaaosike)) return false;
                else if ((Bot.GetMonsterCount() - Bot.GetCountCardInZone(Bot.MonsterZone, CardId.XZwudingxing)) <= 2 && Bot.HasInMonstersZone(CardId.XYyaaosike)) return false;
                {
                    List<ClientCard> bot_monsters = Bot.GetMonsters();
                    bot_monsters.Sort(CardContainer.CompareCardAttack);
                    AI.SelectMaterials(bot_monsters);
                    return true;
                }
            }
            return result;
        }
        //diy//
        public int GetCountAttributeCardInZone(IEnumerable<ClientCard> cards, CardAttribute attribute)
        {
            return cards.Count(card => card != null && card.HasAttribute(attribute));
        }
        //diy//
        // Token: 0x06000849 RID: 2121 RVA: 0x0005CAB0 File Offset: 0x0005ACB0
        //感染源核
        private bool XZganranyuanheSummon()
        {/*
            List<ClientCard> mats = new List<ClientCard>(base.Bot.GetMonstersInMainZone());
            mats.Sort(new Comparison<ClientCard>(CardContainer.CompareCardAttack));
            mats.Reverse();
            int link = 0;
            bool doubleused = false;
            IList<ClientCard> selected = new List<ClientCard>();
            foreach (ClientCard card in mats)
            {
                bool flag = card.IsFacedown();
                if (!flag)
                {
                    selected.Add(card);
                    bool flag2 = !doubleused && card.LinkCount == 2;
                    if (flag2)
                    {
                        doubleused = true;
                        link += 2;
                    }
                    else
                    {
                        link++;
                    }
                    bool flag3 = link >= 4;
                    if (flag3)
                    {
                        break;
                    }
                }
            }
            foreach (ClientCard card2 in mats)
            {
                bool flag4 = link >= 4;
                if (flag4)
                {
                    base.AI.SelectMaterials(selected);
                    return true;
                }
            }
            return false;
            */
            if ((GetCountAttributeCardInZone(Bot.MonsterZone, CardAttribute.Dark) - Bot.GetCountCardInZone(Bot.MonsterZone, CardId.XZwudingxing)) <= 3 && Bot.HasInMonstersZone(CardId.XYyaaosike)) return false;
            else
            {/*
                List<ClientCard> bot_monsters = Bot.GetMonsters();
                bot_monsters.Sort(CardContainer.CompareCardAttack);
                AI.SelectMaterials(bot_monsters);
                return true;
                */
                int link_count = 0;
                IList<ClientCard> list = new List<ClientCard>();
                foreach (ClientCard l_check in Bot.GetMonstersInExtraZone())
                {
                    if (l_check.IsFacedown() || Link(l_check.Id) >= 4) continue;
                    if (Link(l_check.Id) == 1 && l_check.HasAttribute(CardAttribute.Dark))
                    {
                        list.Add(l_check);
                        link_count += 1;
                    }
                    if (Link(l_check.Id) == 2 && l_check.HasAttribute(CardAttribute.Dark))
                    {
                        list.Add(l_check);
                        link_count += 2;
                    }
                    else if (Link(l_check.Id) == 3 && l_check.HasAttribute(CardAttribute.Dark))
                    {
                        list.Add(l_check);
                        link_count += 2;
                    }
                    else break;
                }
                foreach (ClientCard t_check in Bot.GetMonstersInMainZone())
                {
                    if (t_check.IsFacedown() || Link(t_check.Id) >= 4 || Link(t_check.Id) >= 3 || t_check.IsCode(CardId.XZwudingxing, CardId.XYyaaosike, CardId.Xshenli)) continue;
                    if (Link(t_check.Id) == 1 && t_check.HasAttribute(CardAttribute.Dark))
                    {
                        if (t_check.IsFacedown() || Link(t_check.Id) >= 4 || Link(t_check.Id) >= 3 || t_check.IsCode(CardId.XZwudingxing, CardId.XYyaaosike, CardId.Xshenli)) continue;
                        list.Add(t_check);
                        link_count += 1;
                        if (link_count >= 4) break;
                    }
                    else if (Link(t_check.Id) == 2 && t_check.HasAttribute(CardAttribute.Dark))
                    {
                        if (t_check.IsFacedown() || Link(t_check.Id) >= 4 || Link(t_check.Id) >= 3 || t_check.IsCode(CardId.XZwudingxing, CardId.XYyaaosike, CardId.Xshenli)) continue;
                        list.Add(t_check);
                        link_count += 1;
                        if (link_count >= 4) break;
                    }

                }
                if (link_count >= 4)
                {
                    AI.SelectMaterials(list);
                    return true;
                }
                return false;
            }
        }

        // Token: 0x0600084A RID: 2122 RVA: 0x0005CBE0 File Offset: 0x0005ADE0
        //暗尸
        private bool XZanshiSummon()
        {
            if ((!Bot.HasInMonstersZone(30000029) && !Bot.HasInMonstersZone(30000031) && !Bot.HasInMonstersZone(30001007)) || Bot.GetMonstersInMainZone().Count >= 5) return false;
            {
                base.AI.SelectMaterials(new int[]
                {
                30000029,
                30000031,
                30001007
                });
                this.XZanshi = true;
                return true;
            }
        }
        // Token: 0x0600084B RID: 2123 RVA: 0x0005CC1C File Offset: 0x0005AE1C
        private bool XZxienvEffect()
        {
            bool flag = base.Card.Location == CardLocation.Removed;
            bool result;
            if (flag)
            {
                base.AI.SelectCard(30000015);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x0600084C RID: 2124 RVA: 0x0005CC58 File Offset: 0x0005AE58
        private bool XZsalisiEffect()
        {
            bool flag = base.Card.Location == CardLocation.Hand;
            bool result;
            if (flag)
            {
                base.AI.SelectCard(91800273);
                result = true;
            }
            else
            {
                bool flag2 = base.Card.Location == CardLocation.Removed;
                if (flag2)
                {
                    bool xkalite = this.Xkalite;
                    if (xkalite)
                    {
                        result = false;
                    }
                    else
                    {
                        bool flag3 = base.Bot.HasInMonstersZone(30000075, false, false, false);
                        if (flag3)
                        {
                            base.AI.SelectCard(30000075);
                            base.AI.SelectNumber(3);
                            base.AI.SelectOption(1);
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        // Token: 0x0600084D RID: 2125 RVA: 0x0005CD04 File Offset: 0x0005AF04
        private bool XZanshiEffect()
        {
            bool flag = base.Card.Location == CardLocation.MonsterZone;
            bool result;
            if (flag)
            {
                base.AI.SelectCard(new int[]
                {
                    30000031,
                    30000029
                });
                base.AI.SelectPosition(CardPosition.FaceUpAttack);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x0600084E RID: 2126 RVA: 0x0005CD60 File Offset: 0x0005AF60
        private bool AjiedeEffect()
        {
            bool flag = base.Card.Location == CardLocation.Hand;
            bool result;
            if (flag)
            {
                base.AI.SelectPosition(CardPosition.FaceUpAttack);
                this.Ajiede = true;
                result = true;
            }
            else
            {
                bool flag2 = base.Card.Location == CardLocation.Grave;
                if (flag2)
                {
                    int a = 0;
                    for (; ; )
                    {
                        bool flag3 = a == 0;
                        if (flag3)
                        {
                            break;
                        }
                        bool flag4 = a == 1;
                        if (flag4)
                        {
                            goto Block_4;
                        }
                        if (a <= 1)
                        {
                            goto Block_5;
                        }
                    }
                    base.AI.SelectPosition(CardPosition.FaceUpAttack);
                    a++;
                    this.Ajiede = true;
                    return true;
                Block_4:
                    a++;
                    return true;
                Block_5:
                    result = false;
                }
                else
                {
                    bool flag5 = base.Card.Location == CardLocation.MonsterZone || base.Card.Location == CardLocation.Removed;
                    result = flag5;
                }
            }
            return result;
        }

        // Token: 0x0600084F RID: 2127 RVA: 0x0005CE2C File Offset: 0x0005B02C
        private bool FyujinEffect()
        {
            bool flag = (base.Card.Location == CardLocation.Hand || base.Card.Location == CardLocation.Grave) && !this.Fyujin;
            bool result;
            if (flag)
            {
                base.AI.SelectPosition(CardPosition.FaceUpAttack);
                this.Fyujin = true;
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x06000850 RID: 2128 RVA: 0x0005CE88 File Offset: 0x0005B088
        private bool DXyuanxing2Effect()
        {
            bool flag = base.Card.Location == CardLocation.Removed;
            bool result;
            if (flag)
            {
                bool flag2 = base.Bot.HasInBanished(111011901);
                if (flag2)
                {
                    base.AI.SelectCard(new int[]
                    {
                        111011901,
                        30000997,
                        30000085,
                        30000470,
                        30000033,
                        30000001,
                        28297833,
                        27552504,
                        28297833,
                        30000031,
                        30000015,
                        30000019,
                        30000021,
                        9950670,
                        115848157,
                        30000011,
                        30000007,
                        30012000
                    });
                    base.AI.SelectPosition(CardPosition.FaceUpDefence);
                    this.DXyuanxing = true;
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = true;
            }
            return result;
        }

        // Token: 0x06000851 RID: 2129 RVA: 0x0005CF00 File Offset: 0x0005B100
        private bool DXyuanxingEffect()
        {
            ClientCard target = base.Bot.Banished.GetFirstMatchingFaceupCard((ClientCard card) => card.IsFacedown());
            bool flag = base.Card.Location == CardLocation.Removed;
            bool result;
            if (flag)
            {
                bool flag2 = base.Bot.HasInBanished(111011901);
                if (flag2)
                {
                    base.AI.SelectCard(new int[]
                    {
                        111011901,
                        30000997,
                        30000085,
                        30000470,
                        30000033,
                        30000001,
                        28297833,
                        27552504,
                        28297833,
                        30000031,
                        30000015,
                        30000019,
                        30000021,
                        9950670,
                        115848157,
                        30000011,
                        30000007,
                        30012000
                    });
                }
                else
                {
                    bool flag3 = target != null;
                    if (flag3)
                    {
                        base.AI.SelectCard(target);
                    }
                    else
                    {
                        bool flag4 = base.Bot.HasInExtra(30000615) && target == null;
                        if (flag4)
                        {
                            base.AI.SelectCard(new int[]
                            {
                                111011901,
                                30000997,
                                30000085,
                                30000470,
                                30000033,
                                30000001,
                                28297833,
                                27552504,
                                28297833,
                                30000031,
                                30000015,
                                30000019,
                                30000021,
                                9950670,
                                115848157,
                                30000011,
                                30000007,
                                30012000
                            });
                        }
                        else
                        {
                            bool flag5 = !base.Bot.HasInExtra(30000615) && target == null;
                            if (flag5)
                            {
                                base.AI.SelectCard(new int[]
                                {
                                    111011901,
                                    30000997,
                                    30000085,
                                    28297833,
                                    30000470,
                                    30000033,
                                    30000001,
                                    28297833,
                                    27552504,
                                    28297833,
                                    30000031,
                                    30000015,
                                    30000019,
                                    30000021,
                                    9950670,
                                    115848157,
                                    30000011,
                                    30000007,
                                    30012000
                                });
                            }
                            else
                            {
                                base.AI.SelectCard(new int[]
                                {
                                    111011901,
                                    30000997,
                                    30000085,
                                    28297833,
                                    30000470,
                                    30000033,
                                    30000001,
                                    28297833,
                                    27552504,
                                    28297833,
                                    30000031,
                                    30000015,
                                    30000019,
                                    30000021,
                                    9950670,
                                    115848157,
                                    30000011,
                                    30000007,
                                    30012000
                                });
                            }
                        }
                    }
                }
                base.AI.SelectPosition(CardPosition.FaceUpDefence);
                this.DXyuanxing = true;
                result = true;
            }
            else
            {
                result = true;
            }
            return result;
        }

        // Token: 0x06000852 RID: 2130 RVA: 0x0005D070 File Offset: 0x0005B270
        private bool DXtulusanxing2Effect()
        {
            ClientCard target = base.Util.GetBestEnemyCard(false, false);
            bool flag = base.Card.Location == CardLocation.Removed;
            bool result;
            if (flag)
            {
                bool flag2 = base.Bot.HasInBanished(111011901);
                if (Bot.Banished.Count <= 24) return false;
                else if (flag2)
                {
                    base.AI.SelectCard(new int[]
                    {
                        111011901,
                        30000997,
                        30000085,
                        30000470,
                        30000033,
                        30000001,
                        28297833,
                        27552504,
                        28297833,
                        30000031,
                        30000015,
                        30000019,
                        30000021,
                        9950670,
                        115848157,
                        30000011,
                        30000007,
                        30012000
                    });
                    bool flag3 = target != null;
                    if (flag3)
                    {
                        base.AI.SelectNextCard(target);
                    }
                    else
                    {
                        base.AI.SelectNextCard(new int[]
                        {
                            30000053,
                            30000051,
                            30000007,
                            30001009
                        });
                    }
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x06000853 RID: 2131 RVA: 0x0005D11C File Offset: 0x0005B31C
        private bool DXtulusanxingEffect()
        {
            ClientCard target = base.Util.GetBestEnemyCard(false, false);
            bool flag = base.Card.Location == CardLocation.Removed;
            bool result;
            if (flag)
            {
                bool flag2 = base.Bot.HasInBanished(111011901);
                if (Bot.Banished.Count <= 24) return false;
                else if (flag2)
                {
                    base.AI.SelectCard(new int[]
                    {
                        111011901,
                        30000997,
                        30000085,
                        30000470,
                        30000033,
                        30000001,
                        28297833,
                        27552504,
                        28297833,
                        30000031,
                        30000015,
                        30000019,
                        30000021,
                        9950670,
                        115848157,
                        30000011,
                        30000007,
                        30012000,
                        8824709,
                        1475311,
                        30000040,
                        30000045,
                        91800273,
                        130000699,
                        130000325
                    });
                    base.AI.SelectNextCard(new int[]
                    {
                        30000053,
                        30000051,
                        30000007,
                        30001009
                    });
                    result = true;
                }
                else
                {
                    bool flag3 = target != null;
                    if (flag3)
                    {
                        base.AI.SelectCard(new int[]
                        {
                            111011901,
                            30000997,
                            30000085,
                            30000470,
                            30000033,
                            30000001,
                            28297833,
                            27552504,
                            28297833,
                            30000031,
                            30000015,
                            30000019,
                            30000021,
                            9950670,
                            115848157,
                            30000011,
                            30000007,
                            30012000,
                            8824709,
                            1475311,
                            30000040,
                            30000045,
                            91800273,
                            130000699,
                            130000325
                        });
                        base.AI.SelectNextCard(target);
                        result = true;
                    }
                    else
                    {
                        bool flag4 = base.Bot.HasInExtra(30000615) && target == null;
                        if (flag4)
                        {
                            base.AI.SelectCard(new int[]
                            {
                                111011901,
                                30000997,
                                30000085,
                                30000470,
                                30000033,
                                30000001,
                                28297833,
                                27552504,
                                28297833,
                                30000031,
                                30000015,
                                30000019,
                                30000021,
                                9950670,
                                115848157,
                                30000011,
                                30000007,
                                30012000,
                                8824709,
                                1475311,
                                30000040,
                                30000045,
                                91800273,
                                130000699,
                                130000325
                            });
                            base.AI.SelectNextCard(new int[]
                            {
                                30000053,
                                30000051,
                                30000007,
                                30001009
                            });
                            result = true;
                        }
                        else
                        {
                            bool flag5 = !base.Bot.HasInExtra(30000615) && target == null;
                            if (flag5)
                            {
                                base.AI.SelectCard(new int[]
                                {
                                    111011901,
                                    30000997,
                                    30000085,
                                    28297833,
                                    30000470,
                                    30000033,
                                    30000001,
                                    28297833,
                                    27552504,
                                    28297833,
                                    30000031,
                                    30000015,
                                    30000019,
                                    30000021,
                                    9950670,
                                    115848157,
                                    30000011,
                                    30000007,
                                    30012000,
                                    8824709,
                                    1475311,
                                    30000040,
                                    30000045,
                                    91800273,
                                    130000699,
                                    130000325
                                });
                                base.AI.SelectNextCard(new int[]
                                {
                                    30000053,
                                    30000051,
                                    30000007,
                                    30001009
                                });
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                    }
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x06000854 RID: 2132 RVA: 0x0005D2AC File Offset: 0x0005B4AC
        private bool DXzhencetianma2Effect()
        {
            bool flag = base.Card.Location == CardLocation.Removed;
            bool result;
            if (flag)
            {
                bool flag2 = base.Bot.HasInBanished(111011901);
                if (flag2)
                {
                    base.AI.SelectCard(new int[]
                    {
                        111011901,
                        30000997,
                        30000085,
                        30000470,
                        30000033,
                        30000001,
                        28297833,
                        27552504,
                        28297833,
                        30000031,
                        30000015,
                        30000019,
                        30000021,
                        9950670,
                        115848157,
                        30000011,
                        30000007,
                        30012000
                    });
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x06000855 RID: 2133 RVA: 0x0005D310 File Offset: 0x0005B510
        private bool DXzhencetianmaEffect()
        {
            ClientCard target = base.Bot.Banished.GetFirstMatchingFaceupCard((ClientCard card) => card.IsFacedown());
            bool flag = base.Card.Location == CardLocation.Removed;
            if (flag)
            {
                bool flag2 = base.Bot.HasInBanished(111011901);
                if (flag2)
                {
                    base.AI.SelectCard(new int[]
                    {
                        111011901,
                        30000997,
                        30000085,
                        30000470,
                        30000033,
                        30000001,
                        28297833,
                        27552504,
                        28297833,
                        30000031,
                        30000015,
                        30000019,
                        30000021,
                        9950670,
                        115848157,
                        30000011,
                        30000007,
                        30012000
                    });
                    return true;
                }
                bool flag3 = target != null;
                if (flag3)
                {
                    base.AI.SelectCard(target);
                    return true;
                }
                bool flag4 = base.Bot.HasInExtra(30000615) && target == null;
                if (flag4)
                {
                    base.AI.SelectCard(new int[]
                    {
                        111011901,
                        30000997,
                        30000085,
                        30000470,
                        30000033,
                        30000001,
                        28297833,
                        27552504,
                        28297833,
                        30000031,
                        30000015,
                        30000019,
                        30000021,
                        9950670,
                        115848157,
                        30000011,
                        30000007,
                        30012000
                    });
                    return true;
                }
                bool flag5 = !base.Bot.HasInExtra(30000615) && target == null;
                if (flag5)
                {
                    base.AI.SelectCard(new int[]
                    {
                        111011901,
                        30000997,
                        30000085,
                        28297833,
                        30000470,
                        30000033,
                        30000001,
                        28297833,
                        27552504,
                        28297833,
                        30000031,
                        30000015,
                        30000019,
                        30000021,
                        9950670,
                        115848157,
                        30000011,
                        30000007,
                        30012000
                    });
                    return true;
                }
            }
            return false;
        }

        // Token: 0x06000856 RID: 2134 RVA: 0x0005D44C File Offset: 0x0005B64C
        private bool XZkaliteSummon()
        {
            foreach (ClientCard card in base.Bot.Hand)
            {
                bool flag = base.Card.Location == CardLocation.Hand || base.Card.Location == CardLocation.Grave;
                if (flag)
                {
                    bool flag2 = base.Bot.GetHandCount() < 2;
                    if (flag2)
                    {
                        return false;
                    }
                    base.AI.SelectCard(card);
                    return true;
                }
            }
            return false;
        }

        // Token: 0x06000857 RID: 2135 RVA: 0x0005D4F8 File Offset: 0x0005B6F8
        private bool XsaluobakaEffect()
        {
            base.AI.SelectCard(new int[]
            {
                30001007,
                28297833
            });
            return true;
        }

        // Token: 0x06000858 RID: 2136 RVA: 0x0005D530 File Offset: 0x0005B730
        private bool XZkaliteEffect()
        {
            List<ClientCard> targets = new List<ClientCard>();
            List<ClientCard> list = base.Bot.GetGraveyardMonsters();
            List<ClientCard> targets2 = new List<ClientCard>();
            List<ClientCard> list2 = base.Bot.GetGraveyardSpells();
            List<ClientCard> targets3 = new List<ClientCard>();
            List<ClientCard> list3 = base.Bot.GetGraveyardTraps();
            bool flag = base.Card.Location == CardLocation.MonsterZone && !this.XZkalite;
            bool result;
            if (flag)
            {
                base.AI.SelectCard(30000053);
                base.AI.SelectNextCard(9950670);
                result = true;
            }
            else
            {
                bool flag2 = base.Card.Location == CardLocation.MonsterZone && this.XZkalite;
                if (flag2)
                {
                    bool flag3 = targets.Count == 0 && targets2.Count == 0 && targets3.Count == 0;
                    if (flag3)
                    {
                        base.AI.SelectYesNo(true);
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    bool flag4 = base.Card.Location == CardLocation.Removed;
                    result = flag4;
                }
            }
            return result;
        }

        // Token: 0x06000859 RID: 2137 RVA: 0x0005D638 File Offset: 0x0005B838
        private bool XZzaiqiEffect()
        {
            bool flag = base.Card.Location == CardLocation.Removed;
            bool result;
            if (flag)
            {
                result = true;
            }
            else
            {
                bool flag2 = base.Card.Location == CardLocation.SpellZone;
                if (flag2)
                {
                    bool flag3 = base.Bot.GetGraveyardCount() >= 5;
                    if (flag3)
                    {
                        base.AI.SelectCard(new int[]
                        {
                            30004788,
                            60150811,
                            28297833,
                            30000075,
                            60150802,
                            14001007,
                            30000067,
                            30000660
                        });
                        result = true;
                    }
                    else
                    {
                        bool flag4 = !this.Fyujin || !this.Ajiede;
                        if (flag4)
                        {
                            bool flag5 = this.Ajiede || this.Fyujin;
                            if (flag5)
                            {
                                base.AI.SelectCard(new int[]
                                {
                                    60150811,
                                    28297833,
                                    30000075,
                                    60150802,
                                    14001007,
                                    30000067,
                                    30000660
                                });
                                result = true;
                            }
                            else
                            {
                                base.AI.SelectCard(new int[]
                                {
                                    9950670,
                                    9950732,
                                    30000075,
                                    60150811,
                                    28297833,
                                    60150802,
                                    30000067,
                                    14001007,
                                    30000660
                                });
                                result = true;
                            }
                        }
                        else
                        {
                            base.AI.SelectCard(new int[]
                            {
                                60150811,
                                30000075,
                                60150802,
                                14001007,
                                30000067,
                                30000660
                            });
                            result = true;
                        }
                    }
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        // Token: 0x0600085A RID: 2138 RVA: 0x0005D750 File Offset: 0x0005B950
        private bool XzhatuosiEffect()
        {
            foreach (ClientCard card in base.Bot.GetGraveyardMonsters())
            {
                bool flag = base.Card.Location == CardLocation.Removed;
                if (flag)
                {
                    ClientCard target = base.Util.GetBestEnemyMonster(false, false);
                    ClientCard target2 = base.Util.GetBestEnemySpell(false);
                    bool flag2 = target != null;
                    if (flag2)
                    {
                        base.AI.SelectCard(new int[]
                        {
                            30000021,
                            30000013,
                            28297833,
                            30000025,
                            30000053,
                            30000005,
                            30000991,
                            91800273,
                            30000033,
                            30000007,
                            30001009,
                            30000051,
                            30000997
                        });
                        this.Xzhatuosi = true;
                        return true;
                    }
                    bool flag3 = target2 != null;
                    if (flag3)
                    {
                        base.AI.SelectCard(new int[]
                        {
                            30000011,
                            28297833,
                            30000021,
                            30000025,
                            30000053,
                            30000991,
                            30000005,
                            30000991,
                            30000033,
                            91800273,
                            30000007,
                            30001009,
                            30000051,
                            30000997
                        });
                        this.Xzhatuosi = true;
                        return true;
                    }
                    bool flag4 = card != null && card.IsCode(new int[]
                    {
                        60150803,
                        30000025,
                        60150802,
                        60150822,
                        60150817
                    });
                    if (flag4)
                    {
                        base.AI.SelectCard(new int[]
                        {
                            60150822,
                            28297833,
                            30000021,
                            30000025,
                            30000053,
                            30000991,
                            30000005,
                            30000991,
                            91800273,
                            30000033,
                            30000007,
                            30001009,
                            30000051,
                            30000997
                        });
                        this.Xzhatuosi = true;
                        return true;
                    }
                    base.AI.SelectCard(new int[]
                    {
                        28297833,
                        30000053,
                        30000021,
                        30000025,
                        30000005,
                        30000991,
                        30000991,
                        30000033,
                        91800273,
                        30000007,
                        30001009,
                        30000051,
                        30000997
                    });
                    this.Xzhatuosi = true;
                    return true;
                }
            }
            return false;
        }
        List<int> Xqiangxi_list = new List<int>
        {
        30004788, 30000013, 28297833, 30000053, 30000005,30000991, 30000033, 30000007, 30000660, 28297833,30001005, 30000013, 30000991,9950732,30000001,30000997,30000993,91800273,30000085,130000325,30000040,130000699,60150802,
        30000991,9950670,30000047,30000023,30000045,30000021,30000067,30000995,115848157,1475311,8824709,14001007,30000025,30000200,300000080,30000470,
        30000033,30000075,30000605,60150802,111011901,300000015,30000017,30000019,30000007,60150811,30000051,30000053,8824680,
        3040496,1426500142,30000430,111011904,30000615,27552504,30001012,30000042,30001007,30000029,30000031,41999284,30000027
        };
        // Token: 0x0600085B RID: 2139 RVA: 0x0005D8DC File Offset: 0x0005BADC
        //强袭的邪魂
        private bool XqiangxiEffect()
        {
            foreach (ClientCard card in base.Bot.GetGraveyard())
            {
                bool flag = base.Bot.GetGraveyardCount() >= 1;
                if (flag)
                {
                    base.AI.SelectCard(card);
                }
                else if (Bot.Hand.Count >= 2)
                {
                    AI.SelectCard(CardLocation.Hand);
                }
                else
                {
                    AI.SelectCard(Xqiangxi_list);
                }
            }
            base.AI.SelectNextCard(new int[]
            {
                30000045,
                30000045,
                30000040
            });
            base.AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }

        // Token: 0x0600085C RID: 2140 RVA: 0x0005D9A4 File Offset: 0x0005BBA4
        private bool ASxuwutansuoEffect()
        {
            bool flag = base.Card.Location == CardLocation.Removed;
            bool result;
            if (flag)
            {
                bool flag2 = base.Bot.HasInBanished(9950732) && !this.Fyujin;
                if (flag2)
                {
                    base.AI.SelectOption(2);
                    base.AI.SelectCard(new int[]
                    {
                        14001007,
                        9950732,
                        30000660,
                        60150811,
                        30000075,
                        30000470,
                        130000699,
                        30004788
                    });
                    result = true;
                }
                else
                {
                    bool fyujin = this.Fyujin;
                    if (fyujin)
                    {
                        base.AI.SelectOption(2);
                        base.AI.SelectCard(new int[]
                        {
                            14001007,
                            9950732,
                            30000660,
                            60150811,
                            30000075,
                            30000470,
                            130000699,
                            30004788
                        });
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x0600085D RID: 2141 RVA: 0x0005DA5C File Offset: 0x0005BC5C
        private bool ASxuwutansuoSummon()
        {
            bool flag = base.Card.Location == CardLocation.Hand;
            if (flag)
            {
                bool flag2 = !this.Fyujin;
                if (flag2)
                {
                    base.AI.SelectCard(9950732);
                    base.AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                bool fyujin = this.Fyujin;
                if (fyujin)
                {
                    base.AI.SelectCard(new int[]
                    {
                        30000660,
                        60150811,
                        30004788
                    });
                    base.AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
            }
            return false;
        }

        // Token: 0x0600085E RID: 2142 RVA: 0x0005DAEC File Offset: 0x0005BCEC
        private bool XZanyingmonvEffect()
        {
            ClientCard target = base.Enemy.Banished.GetFirstMatchingFaceupCard((ClientCard card) => card.HasType(CardType.Trap) || card.HasType(CardType.Spell));
            bool flag = base.Card.Location == CardLocation.Removed;
            if (flag)
            {
                bool flag2 = target != null;
                if (flag2)
                {
                    base.AI.SelectCard(target);
                    return true;
                }
                bool flag3 = target == null;
                if (flag3)
                {
                    bool flag4 = base.Duel.Player == 1;
                    if (flag4)
                    {
                        base.AI.SelectCard(new int[]
                        {
                            30000015,
                            30012000,
                            30000025,
                            30000019,
                            30000047,
                            30000200
                        });
                        return true;
                    }
                    bool flag5 = base.Duel.Player == 0;
                    if (flag5)
                    {
                        bool flag6 = !this.Anmoli || !this.XZganran || !this.Xqiangxi || !this.DXjianmie;
                        if (flag6)
                        {
                            bool flag7 = base.Bot.HasInBanished(30000200);
                            if (flag7)
                            {
                                base.AI.SelectCard(new int[]
                                {
                                    30000200,
                                    30000047,
                                    30000019,
                                    30001005,
                                    30000025,
                                    30012000,
                                    30000015
                                });
                                return true;
                            }
                            bool flag8 = base.Bot.HasInBanished(30000047);
                            if (flag8)
                            {
                                base.AI.SelectCard(new int[]
                                {
                                    30000047,
                                    30000019,
                                    30001005,
                                    30000025,
                                    30012000,
                                    30000015
                                });
                                return true;
                            }
                            bool flag9 = base.Bot.HasInBanished(30000019);
                            if (flag9)
                            {
                                base.AI.SelectCard(new int[]
                                {
                                    30000019,
                                    30001005,
                                    30000025,
                                    30012000,
                                    30000015
                                });
                                return true;
                            }
                            bool flag10 = base.Bot.HasInBanished(30001005);
                            if (flag10)
                            {
                                base.AI.SelectCard(new int[]
                                {
                                    30001005,
                                    30000025,
                                    30012000,
                                    30000015
                                });
                                return true;
                            }
                            base.AI.SelectCard(new int[]
                            {
                                30000025,
                                30012000,
                                30000015
                            });
                            return true;
                        }
                        else
                        {
                            bool flag11 = this.Anmoli && this.XZganran && this.Xqiangxi && this.DXjianmie;
                            if (flag11)
                            {
                                base.AI.SelectCard(new int[]
                                {
                                    30000025,
                                    30012000,
                                    30000015
                                });
                                return true;
                            }
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        // Token: 0x0600085F RID: 2143 RVA: 0x0005DD4C File Offset: 0x0005BF4C
        //暗魂召唤
        private bool XZanhunSummon2()
        {
            if (Bot.HasInMonstersZone(CardId.XYyaaosike)) return false;
            foreach (ClientCard card in base.Bot.MonsterZone)
            {
                bool flag = card != null && card.IsCode(new int[]
                {
                    30000021,
                    30000033,
                    9950670,
                    9950732,
                    27552504,
                    30000995,
                    60150802,
                    28297833,
                    130000699,
                    130000325
                });
                if (flag)
                {
                    bool flag2 = card.IsCode(1426500142);
                    if (!flag2)
                    {
                        base.AI.SelectMaterials(card);
                        this.XZanhun = true;
                        return true;
                    }
                }
            }
            return false;
        }
        //暗魂召唤
        private bool XZanhunSummon()
        {
            if ((GetCountAttributeCardInZone(Bot.MonsterZone, CardAttribute.Dark) - Bot.GetCountCardInZone(Bot.MonsterZone, CardId.XZwudingxing) <= 1) && Bot.HasInMonstersZone(CardId.XYyaaosike)) return false;
            else if (Bot.GetMonsterCount() <= 3 && Bot.HasInMonstersZone(CardId.XYyaaosike)) return false;
            else if (XZanhun2 || ((Bot.GetMonsterCount() - Bot.GetCountCardInZone(Bot.MonsterZone, CardId.XZwudingxing)) <= 2 && Bot.HasInMonstersZone(CardId.XYyaaosike))) return false;
            {
                List<ClientCard> bot_monsters = Bot.GetMonsters();
                bot_monsters.Sort(CardContainer.CompareCardAttack);
                AI.SelectMaterials(bot_monsters);
                XZanhun = true;
                return true;
            }
        }

        // Token: 0x06000860 RID: 2144 RVA: 0x0005DDD0 File Offset: 0x0005BFD0
        private bool XYhuanying2Summon()
        {
            foreach (ClientCard card in base.Bot.GetMonsters())
            {
                bool flag = card.Level == 11 && card.HasAttribute(CardAttribute.Dark) && base.Bot.GetMonsterCount() >= 4;
                if (flag)
                {
                    return false;
                }
            }
            bool flag2 = base.Bot.HasInSpellZone(111011901, false, false) || base.Bot.HasInHand(111011901);
            bool result;
            if (flag2)
            {
                base.AI.SelectCard(new int[]
                {
                    30000660,
                    28297833,
                    30000053,
                    30001009,
                    30000004
                });
                base.AI.SelectPosition(CardPosition.FaceUpAttack);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x06000861 RID: 2145 RVA: 0x0005DEB8 File Offset: 0x0005C0B8
        private bool XYhuanyingSummon()
        {
            foreach (ClientCard card in base.Bot.GetMonsters())
            {
                bool flag = card.Level == 11 && card.HasAttribute(CardAttribute.Dark) && base.Bot.GetMonsterCount() >= 4;
                if (flag)
                {
                    return false;
                }
                bool flag2 = base.Bot.HasInSpellZone(111011901, false, false) || base.Bot.HasInHand(111011901);
                if (flag2)
                {
                    base.AI.SelectCard(new int[]
                    {
                        30000660,
                        28297833,
                        30000053,
                        30001009,
                        30000004
                    });
                    base.AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                bool flag3 = base.Bot.Banished.Count != 0;
                if (flag3)
                {
                    base.AI.SelectCard(new int[]
                    {
                        30000660,
                        28297833,
                        30000053,
                        30001009,
                        30000004
                    });
                    base.AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
            }
            return false;
        }

        // Token: 0x06000862 RID: 2146 RVA: 0x0005DFEC File Offset: 0x0005C1EC
        private bool ASzhuanshengzhiyiEffect()
        {
            bool flag = base.Card.Location == CardLocation.Grave;
            if (flag)
            {
                base.AI.SelectCard(new int[]
                {
                    30000040,
                    30000051,
                    60150822,
                    28297833,
                    30000047
                });
            }
            return true;
        }

        // Token: 0x06000863 RID: 2147 RVA: 0x0005E034 File Offset: 0x0005C234
        private bool XbowenEffect()
        {
            List<ClientCard> targets = new List<ClientCard>();
            List<ClientCard> list = base.Bot.GetGraveyardMonsters();
            List<ClientCard> targets2 = new List<ClientCard>();
            List<ClientCard> list2 = base.Bot.GetGraveyardSpells();
            List<ClientCard> targets3 = new List<ClientCard>();
            List<ClientCard> list3 = base.Bot.GetGraveyardTraps();
            bool flag = base.Card.Location == CardLocation.SpellZone;
            bool result;
            if (flag)
            {
                bool flag2 = targets == null && targets2 == null && targets3 == null && !this.XZwudingxing;
                if (flag2)
                {
                    base.AI.SelectCard(30000660);
                    base.AI.SelectOption(1);
                    result = true;
                }
                else
                {
                    bool xzwudingxing = this.XZwudingxing;
                    if (xzwudingxing)
                    {
                        base.AI.SelectCard(new int[]
                        {
                            30000040,
                            30000045,
                            30000660,
                            30004788,
                            30000001
                        });
                        base.AI.SelectOption(1);
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = true;
            }
            return result;
        }

        // Token: 0x06000864 RID: 2148 RVA: 0x0005E11C File Offset: 0x0005C31C
        private bool XZwudingxingSummon()
        {
            bool flag = base.Card.Location == CardLocation.Grave || base.Card.Location == CardLocation.Hand;
            bool result;
            if (Bot.GetMonstersInMainZone().Count >= 4 && Bot.GetCountCardInZone(Bot.MonsterZone, CardId.XZwudingxing) <= 1 && (Bot.HasInExtra(CardId.Xsaiwei) || Bot.HasInExtra(CardId.Xshenli)) && !Bot.HasInExtra(CardId.Yitai)) return false;
            else if (flag)
            {
                bool flag2 = base.Bot.Banished.Count <= 38;
                if (flag2)
                {
                    base.AI.SelectCard(new int[]
                    {
                        30000660,
                        30000075,
                        14001007,
                        30000470,
                        30000001,
                        30000067,
                        30004788,
                        30000075,
                        30000023,
                        28297833,
                        30000085,
                        60150802
                    });
                    base.AI.SelectPosition(CardPosition.FaceUpDefence);
                    result = true;
                }
                else
                {
                    base.AI.SelectCard(new int[]
                    {
                        14001007,
                        30000660,
                        30000075,
                        30000470,
                        30000001,
                        30000067,
                        30004788,
                        30000075,
                        30000023,
                        28297833,
                        30000085,
                        60150802
                    });
                    base.AI.SelectPosition(CardPosition.FaceUpDefence);
                    result = true;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x06000865 RID: 2149 RVA: 0x0005E1CC File Offset: 0x0005C3CC
        private bool XZwudingxing2Effect()
        {
            bool flag = base.Card.Location == CardLocation.MonsterZone;
            bool result;
            if (flag)
            {
                bool flag2 = (base.Bot.HasInMonstersZone(9950670, false, false, false) || base.Bot.HasInMonstersZone(3040496, false, false, false)) && base.Bot.HasInExtra(111011904);
                if (flag2)
                {
                    base.AI.SelectNumber(8);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x06000866 RID: 2150 RVA: 0x0005E24C File Offset: 0x0005C44C
        private bool XZwudingxingEffect()
        {
            foreach (ClientCard card2 in base.Bot.GetMonsters())
            {
                bool flag = base.Card.Location == CardLocation.Removed;
                if (flag)
                {
                    this.XZwudingxing = true;
                    base.AI.SelectPosition(CardPosition.FaceUpDefence);
                    return true;
                }
                bool flag2 = base.Card.Location == CardLocation.MonsterZone;
                if (flag2)
                {
                    bool flag3 = !this.DXyuanxing && (base.Bot.HasInBanished(30000993) || base.Bot.HasInMonstersZone(30000993, false, false, false)) && base.Bot.HasInExtra(27552504);
                    if (flag3)
                    {
                        return false;
                    }
                    bool flag4 = base.Bot.HasInMonstersZone(130000699, false, false, false);
                    if (flag4)
                    {
                        base.AI.SelectNumber(7);
                        return true;
                    }
                    bool flag5 = !base.Bot.HasInHand(111011901) && !base.Bot.HasInSpellZone(111011901, false, false) && !base.Bot.HasInGraveyard(111011901) && !base.Bot.HasInBanished(111011901) && base.Bot.HasInExtra(111011904);
                    if (flag5)
                    {
                        base.AI.SelectNumber(8);
                        return true;
                    }
                    bool flag6 = base.Bot.HasInExtra(111011904) && base.Bot.HasInMonstersZone(9950670, false, false, false);
                    if (flag6)
                    {
                        base.AI.SelectNumber(8);
                        return true;
                    }
                    bool flag7 = !base.Bot.HasInExtra(111011904) && !base.Bot.HasInExtra(30000615) && base.Bot.HasInExtra(30000430);
                    if (flag7)
                    {
                        base.AI.SelectNumber(10);
                        return true;
                    }
                    base.AI.SelectNumber(7);
                    return true;
                }
            }
            return false;
        }

        // Token: 0x06000867 RID: 2151 RVA: 0x0005E498 File Offset: 0x0005C698
        private bool ShunvSummon()
        {
            base.AI.SelectPosition(CardPosition.FaceUpAttack);
            base.AI.SelectMaterials(new int[]
            {
                30000660,
                30000660
            });
            this.Shunv = true;
            return true;
        }

        // Token: 0x06000868 RID: 2152 RVA: 0x0005E4E4 File Offset: 0x0005C6E4
        private bool DusheSummon()
        {
            bool flag = !this.Shunv;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                bool shunv = this.Shunv;
                if (shunv)
                {
                    base.AI.SelectPosition(CardPosition.FaceUpAttack);
                    base.AI.SelectMaterials(new int[]
                    {
                        30000660,
                        30000660
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

        // Token: 0x06000869 RID: 2153 RVA: 0x0005E548 File Offset: 0x0005C748
        private bool ShunvEffect()
        {
            bool flag = !base.Bot.HasInSpellZone(30000004, false, false);
            bool result;
            if (flag)
            {
                bool flag2 = !this.Banyingxiong && !this.Ciyuanxiyin;
                if (flag2)
                {
                    base.AI.SelectCard(30000660);
                    base.AI.SelectNextCard(new int[]
                    {
                        30000660,
                        30000075,
                        30000605,
                        30000067,
                        30000045
                    });
                    result = true;
                }
                else
                {
                    base.AI.SelectCard(30000660);
                    base.AI.SelectNextCard(new int[]
                    {
                        30000075,
                        30000605,
                        30000067,
                        30000045
                    });
                    result = true;
                }
            }
            else
            {
                bool flag3 = base.Bot.HasInSpellZone(30000004, false, false);
                if (flag3)
                {
                    bool flag4 = !this.Banyingxiong && !this.Ciyuanxiyin;
                    if (flag4)
                    {
                        base.AI.SelectCard(30000660);
                        base.AI.SelectNextCard(new int[]
                        {
                            30000660,
                            60150802,
                            30000045,
                            28297833,
                            30000997
                        });
                        result = true;
                    }
                    else
                    {
                        base.AI.SelectCard(30000660);
                        base.AI.SelectNextCard(new int[]
                        {
                            60150802,
                            30000045,
                            28297833,
                            30000997
                        });
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

        // Token: 0x0600086A RID: 2154 RVA: 0x0005E698 File Offset: 0x0005C898
        private bool DXciyuanSummon()
        {
            bool flag = !this.DXciyuan;
            bool result;
            if (flag)
            {
                base.AI.SelectMaterials(new List<int>
                {
                    9950732,
                    30000660,
                    27552504
                });
                this.DXciyuan = true;
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x0600086B RID: 2155 RVA: 0x0005E6FC File Offset: 0x0005C8FC
        private bool DXciyuanEffect()
        {
            ClientCard target = base.Bot.Banished.GetFirstMatchingFaceupCard((ClientCard card) => card.IsFacedown());
            bool flag = base.Card.Location == CardLocation.MonsterZone;
            bool result;
            if (flag)
            {
                base.AI.SelectCard(30000995);
                base.AI.SelectNextCard(30001005);
                result = true;
            }
            else
            {
                bool flag2 = base.Card.Location == CardLocation.Removed;
                if (flag2)
                {
                    bool flag3 = target != null;
                    if (flag3)
                    {
                        base.AI.SelectCard(target);
                        return true;
                    }
                    bool flag4 = base.Bot.HasInExtra(30000615) && target == null;
                    if (flag4)
                    {
                        base.AI.SelectCard(new int[]
                        {
                            30000997,
                            30000085,
                            30000470,
                            30000033,
                            30000001,
                            28297833,
                            27552504,
                            28297833,
                            30000031,
                            30000015,
                            30000019,
                            30000021,
                            9950670
                        });
                        return true;
                    }
                    bool flag5 = !base.Bot.HasInExtra(30000615) && target == null;
                    if (flag5)
                    {
                        base.AI.SelectCard(new int[]
                        {
                            30000997,
                            30000085,
                            28297833,
                            30000470,
                            30000033,
                            30000001,
                            28297833,
                            27552504,
                            28297833,
                            30000031,
                            30000015,
                            30000019,
                            30000021,
                            9950670
                        });
                        return true;
                    }
                }
                result = false;
            }
            return result;
        }

        // Token: 0x0600086C RID: 2156 RVA: 0x0005E838 File Offset: 0x0005CA38
        private bool XZchongjiboEffect()
        {
            ClientCard target = base.Util.GetBestEnemySpell(false);
            base.AI.SelectCard(new int[]
            {
                30000001,
                9950732,
                30000470,
                60150802,
                30000029,
                30000013
            });
            bool flag = target != null;
            if (flag)
            {
                base.AI.SelectYesNo(true);
                base.AI.SelectNextCard(target);
            }
            else
            {
                base.AI.SelectYesNo(false);
            }
            return true;
        }

        // Token: 0x0600086D RID: 2157 RVA: 0x0005E8AC File Offset: 0x0005CAAC
        private bool ZminlongSummon()
        {
            bool flag = base.Card.Location == CardLocation.Hand;
            if (flag)
            {
                bool flag2 = !this.Zminglong;
                if (flag2)
                {
                    return false;
                }
                bool zminglong = this.Zminglong;
                if (zminglong)
                {
                    IList<ClientCard> grave = base.Bot.Graveyard;
                    IList<ClientCard> hand = base.Bot.Hand;
                    IList<ClientCard> all = new List<ClientCard>();
                    foreach (ClientCard check in grave)
                    {
                        bool flag3 = check.IsCode(28297833);
                        if (flag3)
                        {
                            all.Add(check);
                        }
                    }
                    foreach (ClientCard check2 in grave)
                    {
                        bool flag4 = check2.HasType(CardType.Monster) && check2.Attribute == 32;
                        if (flag4)
                        {
                            all.Add(check2);
                        }
                    }
                    foreach (ClientCard check3 in hand)
                    {
                        bool flag5 = check3.HasType(CardType.Monster) && check3.Attribute == 32;
                        if (flag5)
                        {
                            all.Add(check3);
                        }
                    }
                    base.AI.SelectCard(all);
                    base.AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
            }
            else
            {
                bool flag6 = base.Card.Location == CardLocation.Grave;
                if (flag6)
                {
                    IList<ClientCard> grave2 = base.Bot.Graveyard;
                    IList<ClientCard> hand2 = base.Bot.Hand;
                    IList<ClientCard> all2 = new List<ClientCard>();
                    foreach (ClientCard check4 in grave2)
                    {
                        bool flag7 = check4.IsCode(28297833);
                        if (flag7)
                        {
                            all2.Add(check4);
                        }
                    }
                    foreach (ClientCard check5 in grave2)
                    {
                        bool flag8 = check5.HasType(CardType.Monster) && check5.Attribute == 32;
                        if (flag8)
                        {
                            all2.Add(check5);
                        }
                    }
                    foreach (ClientCard check6 in hand2)
                    {
                        bool flag9 = check6.HasType(CardType.Monster) && check6.Attribute == 32;
                        if (flag9)
                        {
                            all2.Add(check6);
                        }
                    }
                    base.AI.SelectCard(all2);
                    base.AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
            }
            return false;
        }

        // Token: 0x0600086E RID: 2158 RVA: 0x0005EBE4 File Offset: 0x0005CDE4
        //邪魂 扎托斯
        private bool XzhatuosiSummon()
        {
            bool flag = base.Card.Location == CardLocation.Grave || base.Card.Location == CardLocation.Hand;
            bool result;
            if (flag)
            {
                bool flag2 = base.Bot.GetMonsterCount() >= 5 || (base.Bot.HasInMonstersZone(30001012, false, false, false) && base.Bot.GetMonsterCount() <= 3);
                if (flag2)
                {
                    result = false;
                }
                else
                {
                    if ((Bot.GetGraveyard().Count + Bot.Hand.Count) <= 6 && Bot.GetMonsterCount() <= 3) return false;
                    else if (Bot.GetGraveyard().Count >= 6 || (Bot.GetGraveyard().Count + Bot.Hand.Count) >= 6)
                    {
                        AI.SelectCard(CardLocation.Grave | CardLocation.Hand);
                        //AI.SelectNextCard(CardLocation.Grave | CardLocation.Hand);
                        // AI.SelectThirdCard(CardLocation.Grave | CardLocation.Hand);
                        // AI.SelectFourthCard(CardLocation.Grave | CardLocation.Hand);
                        // AI.SelectFifthCard(CardLocation.Grave | CardLocation.Hand);
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                        return true;
                    }
                    else
                    {
                        AI.SelectCard(select_list);
                        //   AI.SelectNextCard(select_list);
                        //  AI.SelectThirdCard(select_list);
                        //  AI.SelectFourthCard(select_list);
                        //  AI.SelectFifthCard(select_list);
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                        return true;
                    }
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x0600086F RID: 2159 RVA: 0x0005ED80 File Offset: 0x0005CF80
        private bool XZanyingmonvSummon()
        {
            bool flag = base.Card.Location == CardLocation.Grave || base.Card.Location == CardLocation.Hand;
            bool result;
            if (flag)
            {
                base.AI.SelectCard(new int[]
                {
                    30000001,
                    9950732,
                    30000470,
                    60150802,
                    30000029,
                    30000013,
                    30000660,
                    30000997
                });
                base.AI.SelectPosition(CardPosition.FaceUpAttack);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        List<int> XZganrankuosan_list = new List<int>
        {
            30000001,9950732, 30000470,60150802,30000029,30000013,30000085,30000995 ,30000660, 28297833,30001005, 30000013, 30000991,9950732,30000001,30000997,30000993,91800273,30000085,130000325,30000040,130000699,60150802,
30000991,9950670,30000047,30000023,30000045,30000021,30000067,30000995,115848157,1475311,8824709,14001007,30000025,30000200,300000080,30000470,
30000033,30000075,30000605,60150802,111011901,300000015,30000017,30000019,30000007,60150811,30000051,30000053,8824680,
3040496,1426500142,30000430,111011904,30000615,27552504,30001012,30000042,30001007,30000029,30000031,41999284,30000027
        };
        // Token: 0x06000870 RID: 2160 RVA: 0x0005EDE8 File Offset: 0x0005CFE8
        //邪魂 感染扩散
        private bool XZganrankuosanEffect()
        {
            foreach (ClientCard card in base.Bot.GetGraveyard())
            {
                foreach (ClientCard card2 in base.Bot.Hand)
                {
                    bool flag = base.Bot.GetGraveyardCount() >= 1;
                    if (flag)
                    {
                        base.AI.SelectCard(card);
                    }
                    else
                    {
                        bool flag2 = base.Bot.GetHandCount() >= 1;
                        if (flag2)
                        {
                            base.AI.SelectCard(card2);
                        }
                        else
                        {
                            AI.SelectCard(XZganrankuosan_list);
                        }
                    }
                }
            }
            bool flag3 = !this.Xzhatuosi;
            bool result;
            if (flag3)
            {
                base.AI.SelectNextCard(new int[]
                {
                    30004788,
                    30000001,
                    30000470,
                    30000029,
                    30000005
                });
                this.XZganrankuosan = true;
                result = true;
            }
            else
            {
                base.AI.SelectNextCard(new int[]
                {
                    30004788,
                    30000001,
                    30000470,
                    30000029,
                    30000005
                });
                this.XZganrankuosan = true;
                result = true;
            }
            return result;
        }

        // Token: 0x06000871 RID: 2161 RVA: 0x0005EF58 File Offset: 0x0005D158
        //机核
        private bool DXjihe2Effect()
        {
            bool flag = base.Card.Location == CardLocation.Removed;
            bool result;
            if (flag)
            {
                bool flag2 = base.Bot.HasInBanished(111011901);
                if (Bot.Banished.Count <= 24) return false;
                if (flag2)
                {
                    base.AI.SelectCard(new int[]
                    {
                        111011901,
                        30000997,
                        30000085,
                        30000470,
                        30000033,
                        30000001,
                        28297833,
                        27552504,
                        28297833,
                        30000031,
                        30000015,
                        30000019,
                        30000021,
                        9950670
                    });
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x06000872 RID: 2162 RVA: 0x0005EFBC File Offset: 0x0005D1BC
        private bool DXjiheEffect()
        {
            bool flag = base.Card.Location == CardLocation.Removed;
            bool result;
            if (flag)
            {
                bool flag2 = base.Bot.HasInBanished(111011901);
                if (flag2)
                {
                    base.AI.SelectCard(new int[]
                    {
                        111011901,
                        30000997,
                        30000085,
                        30000470,
                        30000033,
                        30000001,
                        28297833,
                        27552504,
                        28297833,
                        30000031,
                        30000015,
                        30000019,
                        30000021,
                        9950670
                    });
                    result = true;
                }
                else
                {
                    bool flag3 = base.Bot.HasInExtra(30000615);
                    if (flag3)
                    {
                        base.AI.SelectCard(new int[]
                        {
                            111011901,
                            30000997,
                            30000085,
                            30000470,
                            30000033,
                            30000001,
                            28297833,
                            27552504,
                            28297833,
                            30000031,
                            30000015,
                            30000019,
                            30000021,
                            9950670
                        });
                        result = true;
                    }
                    else
                    {
                        bool flag4 = !base.Bot.HasInExtra(30000615);
                        if (flag4)
                        {
                            base.AI.SelectCard(new int[]
                            {
                                111011901,
                                30000997,
                                30000085,
                                28297833,
                                30000470,
                                30000033,
                                30000001,
                                28297833,
                                27552504,
                                28297833,
                                30000031,
                                30000015,
                                30000019,
                                30000021,
                                9950670
                            });
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
            }
            else
            {
                bool flag5 = base.Card.Location == CardLocation.MonsterZone;
                result = flag5;
            }
            return result;
        }

        // Token: 0x06000873 RID: 2163 RVA: 0x0005F0B0 File Offset: 0x0005D2B0
        //时空回旋
        //表
        List<int> DXshikonghuixuan = new List<int>
        {
           30000029, 30000027, 30000013,30004788,30000660, 28297833,30001005, 30000013, 30000991,9950732,30000001,30000997,30000993,91800273,30000085,130000325,30000040,130000699,60150802,
30000991,9950670,30000047,30000023,30000045,30000021,30000067,30000995,115848157,1475311,8824709,14001007,30000025,30000200,300000080,30000470,
30000033,30000075,30000605,60150802,111011901,300000015,30000017,30000019,30000007,60150811,30000051,30000053,8824680,
3040496,1426500142,30000430,111011904,30000615,27552504,30001012,30000042,30001007,30000029,30000031,41999284,30000027
        };
        private bool DXshikonghuixuanSummon()
        {
            bool flag = base.Bot.HasInMonstersZone(30001002, false, false, false) && !base.Bot.HasInMonstersZone(30000029, false, false, false);
            bool result;
            if ((Bot.GetMonsterCount() - 1 - Bot.GetCountCardInZone(Bot.MonsterZone, CardId.XZwudingxing)) <= 1 && Bot.HasInMonstersZone(CardId.XYyaaosike)) return false;
            if (flag)
            {
                base.AI.SelectMaterials(DXshikonghuixuan);
                result = true;
            }
            else
            {
                bool flag2 = base.Bot.HasInMonstersZone(30000029, false, false, false) && !base.Bot.HasInMonstersZone(30001002, false, false, false);
                if (flag2)
                {
                    base.AI.SelectMaterials(DXshikonghuixuan
                    /*
                    30000029,
                    30000027,
                    30000013,
                    30004788
                    */
                    );
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        // Token: 0x06000874 RID: 2164 RVA: 0x0005F1B4 File Offset: 0x0005D3B4
        //卡利特 召唤
        private bool XkaliteSummon()
        {
            /*
            List<ClientCard> mats = new List<ClientCard>(base.Bot.GetMonstersInMainZone());
            bool flag = base.Card.Location == CardLocation.Grave || base.Card.Location == CardLocation.Hand;
            bool result;
            if (flag)
            {
                foreach (ClientCard card in mats)
                {
                    bool flag2 = card.IsCode(1426500142);
                    if (flag2)
                    {
                    }
                }
                base.AI.SelectCard(new int[]
                {
                    30000660,
                    30000660,
                    30001005,
                    30000013,
                    30000991,
                    30000991
                });
                base.AI.SelectPosition(CardPosition.FaceUpAttack);
                result = true;
            }
            else
            {
                result = false;
            }
            //return result;
            */
            if (Card.Location == CardLocation.Hand || Card.Location == CardLocation.Grave)
            {
                if (Bot.GetMonstersInMainZone().Count >= 5) return false;
                else if ((Bot.Hand.Count < 2) && Card.Location == CardLocation.Grave) return false;
                else if ((Bot.Hand.Count < 3) && Card.Location == CardLocation.Hand) return false;
                else if ((Bot.Hand.Count + Bot.GetSpells().Count) < 3) return false;
                else if ((Bot.Hand.Count + Bot.GetSpells().Count) >= 3)
                {
                    AI.SelectCard(CardLocation.Hand | CardLocation.SpellZone | CardLocation.MonsterZone);
                    AI.SelectNextCard(CardLocation.Hand | CardLocation.SpellZone | CardLocation.MonsterZone);
                }
                else if (Bot.HasInMonstersZone(CardId.XYyaaosike) && Bot.GetMonsterCount() + Bot.GetSpellCount() <= 2) return false;
                else
                {
                    AI.SelectCard(select_list);
                    AI.SelectNextCard(select_list);
                }
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }

        // Token: 0x06000875 RID: 2165 RVA: 0x0005F280 File Offset: 0x0005D480
        private bool ASxuwuyinduEffect()
        {
            using (List<ClientCard>.Enumerator enumerator = base.Bot.GetGraveyardMonsters().GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    ClientCard card = enumerator.Current;
                    bool flag = card.IsCode(new int[]
                    {
                        60150803,
                        60150802,
                        60150822,
                        60150811,
                        60150817
                    });
                    if (flag)
                    {
                        base.AI.SelectCard(card);
                        base.AI.SelectPosition(CardPosition.FaceUpAttack);
                        return true;
                    }
                    base.AI.SelectCard(60150802);
                    return true;
                }
            }
            return false;
        }

        // Token: 0x06000876 RID: 2166 RVA: 0x0005F32C File Offset: 0x0005D52C
        private bool LiziqiuSummon()
        {
            base.AI.SelectMaterials(new List<int>
            {
                30000045
            });
            return true;
        }

        // Token: 0x06000877 RID: 2167 RVA: 0x0005F35C File Offset: 0x0005D55C
        private bool XZchuanbozheEffect()
        {
            foreach (ClientCard card in base.Bot.Graveyard)
            {
                bool flag = base.Card.Location == CardLocation.MonsterZone;
                if (flag)
                {
                    bool flag2 = card == null;
                    if (flag2)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    bool flag3 = base.Card.Location == CardLocation.Removed;
                    if (flag3)
                    {
                        bool flag4 = card == null;
                        if (flag4)
                        {
                            base.AI.SelectCard(30012000);
                            return true;
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        // Token: 0x06000878 RID: 2168 RVA: 0x0005F414 File Offset: 0x0005D614
        private bool DXshikonghuixuanEffect()
        {
            bool flag = base.Card.Location == CardLocation.MonsterZone;
            //bool result;
            if (flag)
            {
                base.AI.SelectCard(30000995);
                bool flag2 = !this.XZwudingxing;
                if (flag2)
                {
                    base.AI.SelectNextCard(new int[]
                    {
                        30000660,
                        28297833,
                        30000021,
                        30000013,
                        28297833,
                        30000025,
                        30000053,
                        30000005,
                        30000991,
                        91800273,
                        30000033,
                        30000007,
                        30001009,
                        30000051,
                        30000997
                    });
                }
                else
                {
                    base.AI.SelectNextCard(new int[]
                    {
                        28297833,
                        30000021,
                        30000013,
                        28297833,
                        30000025,
                        30000053,
                        30000005,
                        30000991,
                        91800273,
                        30000033,
                        30000007,
                        30001009,
                        30000051,
                        30000997
                    });
                }
                return true;
            }
            else
            {
                // bool flag3 = base.Card.Location == CardLocation.Removed;
                // if (flag3)
                // {
                /*0base.AI.SelectCard(new int[]
                {
                    111011901,
                    30000997,
                    30000085,
                    30000470,
                    30000033,
                    30000001,
                    28297833,
                    27552504,
                    28297833,
                    30000031,
                    30000015,
                    30000019,
                    30000021,
                    9950670,
                    115848157,
                    30000011,
                    30000007,
                    30012000
                });
                result = true;
            */
                //  }
                //  else
                //   {
                //       result = false;
                //    }
                return true;
            }

        }

        // Token: 0x06000879 RID: 2169 RVA: 0x0005F4D4 File Offset: 0x0005D6D4
        private bool XlisanaEffect()
        {
            bool flag = base.Card.Location == CardLocation.Removed;
            bool result;
            if (flag)
            {
                base.AI.SelectPosition(CardPosition.FaceUpDefence);
                result = true;
            }
            else
            {
                bool flag2 = base.Card.Location == CardLocation.MonsterZone;
                result = (flag2 && false);
            }
            return result;
        }

        // Token: 0x0600087A RID: 2170 RVA: 0x0005F524 File Offset: 0x0005D724
        private bool XshikongyunshuEffect()
        {
            bool flag = base.Card.Location == CardLocation.Removed || base.Card.Location == CardLocation.Hand;
            bool result;
            if (flag)
            {
                result = true;
            }
            else
            {
                bool flag2 = base.Card.Location == CardLocation.SpellZone;
                if (flag2)
                {
                    bool flag3 = !this.Xshikongyunshu;
                    if (flag3)
                    {
                        base.AI.SelectCard(new int[]
                        {
                            30000997,
                            30000013,
                            28297833,
                            30000053,
                            30000005,
                            30000991,
                            91800273,
                            30000033,
                            30000007
                        });
                        this.Xshikongyunshu = true;
                        result = true;
                    }
                    else
                    {
                        bool xshikongyunshu = this.Xshikongyunshu;
                        if (xshikongyunshu)
                        {
                            base.AI.SelectCard(new int[]
                            {
                                30000013,
                                28297833,
                                30000053,
                                30000005,
                                30000991,
                                91800273,
                                30000033,
                                30000007
                            });
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        // Token: 0x0600087B RID: 2171 RVA: 0x0005F5E0 File Offset: 0x0005D7E0
        private bool XZganransanboEffect()
        {
            List<ClientCard> mats = new List<ClientCard>(base.Bot.GetGraveyardMonsters());
            List<ClientCard> mats2 = new List<ClientCard>(base.Bot.GetGraveyardSpells());
            List<ClientCard> mats3 = new List<ClientCard>(base.Bot.GetGraveyardTraps());
            foreach (ClientCard card in mats)
            {
                foreach (ClientCard card2 in mats2)
                {
                    foreach (ClientCard card3 in mats3)
                    {
                        bool flag = base.Card.Location == CardLocation.Removed;
                        if (flag)
                        {
                            return true;
                        }
                        bool flag2 = base.Card.Location == CardLocation.SpellZone;
                        if (flag2)
                        {
                            bool flag3 = card != null && card.IsCode(new int[]
                            {
                                60150802,
                                28297833,
                                30000997
                            });
                            if (flag3)
                            {
                                base.AI.SelectCard(card);
                                return true;
                            }
                            bool flag4 = (card2 != null || card3 != null) && card == null && card.IsCode(new int[]
                            {
                                60150802,
                                28297833,
                                30000997
                            });
                            if (flag4)
                            {
                                return false;
                            }
                            bool flag5 = (base.Duel.Phase == DuelPhase.Main1 || base.Duel.Phase == DuelPhase.Main2) && !this.XZganransanbo;
                            if (flag5)
                            {
                                base.AI.SelectCard(new int[]
                                {
                                    28297833,
                                    60150802,
                                    30004788,
                                    30000040
                                });
                                this.XZganransanbo = true;
                                return true;
                            }
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        // Token: 0x0400036C RID: 876
        private List<int> Impermanence_list = new List<int>();

        // Token: 0x0400036D RID: 877
        private bool Fyujin = false;
        private bool XZanhun2 = false;

        // Token: 0x0400036E RID: 878
        private bool Ajiede = false;

        // Token: 0x0400036F RID: 879
        private bool XZkalite = false;

        // Token: 0x04000370 RID: 880
        private bool Xsaiwei = false;

        // Token: 0x04000371 RID: 881
        private bool Xsaiwei2 = false;

        // Token: 0x04000372 RID: 882
        private bool Anmoli = false;

        // Token: 0x04000373 RID: 883
        private bool XZganran = false;

        // Token: 0x04000374 RID: 884
        private bool Xqiangxi = false;

        // Token: 0x04000375 RID: 885
        private bool DXjianmie = false;

        // Token: 0x04000376 RID: 886
        private bool XZwudingxing = false;

        // Token: 0x04000377 RID: 887
        private bool XZganransanbo = false;

        // Token: 0x04000378 RID: 888
        private bool DXciyuan = false;

        // Token: 0x04000379 RID: 889
        private bool XZmohualongpu = false;

        // Token: 0x0400037A RID: 890
        private bool XZmohualongpu2 = false;

        // Token: 0x0400037B RID: 891
        private bool XZanshi = false;

        // Token: 0x0400037C RID: 892
        private bool Zminglong = false;

        // Token: 0x0400037D RID: 893
        private bool Banyingxiong = false;

        // Token: 0x0400037E RID: 894
        private bool Ciyuanxiyin = false;

        // Token: 0x0400037F RID: 895
        private bool Xzhatuosi = false;

        // Token: 0x04000380 RID: 896
        private bool Xshikongyunshu = false;

        // Token: 0x04000381 RID: 897
        private bool Shunv = false;

        // Token: 0x04000382 RID: 898
        private bool XZanhun = false;

        // Token: 0x04000383 RID: 899
        private bool Xzhatuosi2 = false;

        // Token: 0x04000384 RID: 900
        private bool Yitai = false;

        // Token: 0x04000385 RID: 901
        private bool XZganrankuosan = false;

        // Token: 0x04000386 RID: 902
        private bool Xkalite = false;

        // Token: 0x04000387 RID: 903
        private bool DXyuanxing = false;

        // Token: 0x020000D8 RID: 216
        public class CardId
        {
            // Token: 0x04000B3C RID: 2876
            public const int Xzhatuosi = 30004788;

            // Token: 0x04000B3D RID: 2877
            public const int XZsilanwo = 30000470;

            // Token: 0x04000B3E RID: 2878
            public const int XZkalite = 30000033;

            // Token: 0x04000B3F RID: 2879
            public const int Xkalite = 30000075;

            // Token: 0x04000B40 RID: 2880
            public const int Xdalusike = 30000605;

            // Token: 0x04000B41 RID: 2881
            public const int Ajiede = 9950670;

            // Token: 0x04000B42 RID: 2882
            public const int DXtulusanxing = 30000991;

            // Token: 0x04000B43 RID: 2883
            public const int ASxuwutansuo = 60150802;

            // Token: 0x04000B44 RID: 2884
            public const int ASzuijiapaidang = 60150817;

            // Token: 0x04000B45 RID: 2885
            public const int ASxingjieyouxing = 60150803;

            // Token: 0x04000B46 RID: 2886
            public const int ASxuwuyindu = 60150822;

            // Token: 0x04000B47 RID: 2887
            public const int Fyujin = 9950732;

            // Token: 0x04000B48 RID: 2888
            public const int XZanyingmonv = 30000001;

            // Token: 0x04000B49 RID: 2889
            public const int DXzhencetianma = 30000997;

            // Token: 0x04000B4A RID: 2890
            public const int Ciyuanxiyin = 91800273;

            // Token: 0x04000B4B RID: 2891
            public const int XZwudingxing = 30000660;

            // Token: 0x04000B4C RID: 2892
            public const int XZsalisi = 30000085;

            // Token: 0x04000B4D RID: 2893
            public const int XZbeiqingshi = 30000040;

            // Token: 0x04000B4E RID: 2894
            public const int Silingzhiyan = 28297833;

            // Token: 0x04000B4F RID: 2895
            public const int XZganran = 30000047;

            // Token: 0x04000B50 RID: 2896
            public const int Xladaluo = 30000011;

            // Token: 0x04000B51 RID: 2897
            public const int Xsasalite = 30000013;

            // Token: 0x04000B52 RID: 2898
            public const int XZmohualongpu = 30000023;

            // Token: 0x04000B53 RID: 2899
            public const int XZchuanbozhe = 30000045;

            // Token: 0x04000B54 RID: 2900
            public const int Xlisana = 30000021;

            // Token: 0x04000B55 RID: 2901
            public const int Xlalinsai = 30000067;

            // Token: 0x04000B56 RID: 2902
            public const int DXjihe = 30000995;

            // Token: 0x04000B57 RID: 2903
            public const int Banyingxiong = 115848157;

            // Token: 0x04000B58 RID: 2904
            public const int XGchongneng = 14001007;

            // Token: 0x04000B59 RID: 2905
            public const int XZchongjibo = 30000025;

            // Token: 0x04000B5A RID: 2906
            public const int Anmoli = 30000200;

            // Token: 0x04000B5B RID: 2907
            public const int Xciyuandaohang = 30000015;

            // Token: 0x04000B5C RID: 2908
            public const int XZganrankuosan = 30000017;

            // Token: 0x04000B5D RID: 2909
            public const int Xqiangxi = 30000019;

            // Token: 0x04000B5E RID: 2910
            public const int DXkaishi = 30001005;

            // Token: 0x04000B5F RID: 2911
            public const int XZganransanbo = 30000004;

            // Token: 0x04000B60 RID: 2912
            public const int Xshikongyunshu = 30001009;

            // Token: 0x04000B61 RID: 2913
            public const int XZfeixu = 30000007;

            // Token: 0x04000B62 RID: 2914
            public const int Xjitan = 30012000;

            // Token: 0x04000B63 RID: 2915
            public const int ASzhuanshengzhiyi = 60150811;

            // Token: 0x04000B64 RID: 2916
            public const int XZanzhipucong = 30000005;

            // Token: 0x04000B65 RID: 2917
            public const int Xbowen = 30000051;

            // Token: 0x04000B66 RID: 2918
            public const int XZzaiqi = 30000053;

            // Token: 0x04000B67 RID: 2919
            public const int XYyaaosike = 30010000;

            // Token: 0x04000B68 RID: 2920
            public const int XYhuanying = 1426500142;

            // Token: 0x04000B69 RID: 2921
            public const int Xshenli = 30000430;

            // Token: 0x04000B6A RID: 2922
            public const int Xsaiwei = 30000615;

            // Token: 0x04000B6B RID: 2923
            public const int Shunv = 27552504;

            // Token: 0x04000B6C RID: 2924
            public const int DXshikong = 30001012;

            // Token: 0x04000B6D RID: 2925
            public const int XZganranyuanhe = 30000042;

            // Token: 0x04000B6E RID: 2926
            public const int XZhuimiemozhu = 30000010;

            // Token: 0x04000B6F RID: 2927
            public const int DXshikonghuixuan = 30001007;

            // Token: 0x04000B70 RID: 2928
            public const int DXciyuan = 30001002;

            // Token: 0x04000B71 RID: 2929
            public const int KDA = 9981580;

            // Token: 0x04000B72 RID: 2930
            public const int XZanhun = 30000029;

            // Token: 0x04000B73 RID: 2931
            public const int XZxienv = 30000031;

            // Token: 0x04000B74 RID: 2932
            public const int Liziqiu = 41999284;

            // Token: 0x04000B75 RID: 2933
            public const int XZanshi = 30000027;

            // Token: 0x04000B76 RID: 2934
            public const int DXjianmie = 30001005;

            // Token: 0x04000B77 RID: 2935
            public const int Xyansheng = 30000009;

            // Token: 0x04000B78 RID: 2936
            public const int Linjiachucao = 8824709;

            // Token: 0x04000B79 RID: 2937
            public const int Zminlong = 130000699;

            // Token: 0x04000B7A RID: 2938
            public const int Zyinglong = 130000325;

            // Token: 0x04000B7B RID: 2939
            public const int Anzhiyouhuo = 1475311;

            // Token: 0x04000B7C RID: 2940
            public const int Dushe = 10086166;

            // Token: 0x04000B7D RID: 2941
            public const int Yitai = 111011904;

            // Token: 0x04000B7E RID: 2942
            public const int Xingguang = 111011901;

            // Token: 0x04000B7F RID: 2943
            public const int Xsaluobaka = 30000600;

            // Token: 0x04000B80 RID: 2944
            public const int Yguairen = 8824680;

            // Token: 0x04000B81 RID: 2945
            public const int DXyuanxing = 30000993;

            // Token: 0x04000B82 RID: 2946
            public const int Hundun = 3040496;
        }
    }
}
