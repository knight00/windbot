using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("Luanyu", "AI_Luanyu", "NotFinished")]
    public class LuanyuExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Zhonglong = 9950480;
            public const int Dongfengyoulong = 87100001;
            public const int Kuihaishouying = 14000149;
            public const int Lxiaohuolong = 79201014;
            public const int Lwomendeguang = 79201015;
            public const int Lyongbing = 79201003;
            public const int Lshixie = 79201004;
            public const int Zhaohe = 9980665;
            public const int Caiwenji = 20062;
            public const int Baisizhileimi = 9950321;
            public const int Buzhimingzhuzi = 60000001;
            public const int Sanhualing = 72100051;
            public const int Huanmiao = 83000087;
            public const int Dianwang = 9981292;
            public const int Yiduiyi = 2295440;
            public const int Zengyuan = 32807846;
            public const int Yuchundefuzang = 35726888;
            public const int Anheijiedequyin = 74117290;
            public const int Lcunqubeiju = 79201010;
            public const int Yinlingchaoliu = 83000084;
            public const int Xianrendezhaohuan = 14010079;
            public const int Wzhenlaikuyi = 70700101;
            public const int Wzhenlaiouyi = 70700102;
            public const int Lfashujiaoliu = 79201012;
            public const int Sbuzhihuo = 97820003;
            public const int Lbishuilantian = 79201017;
            public const int Eyi = 9981675;
            public const int Shanxian = 14010075;
            public const int Taiben = 65010099;
            public const int Shanguang = 118038143;
            public const int Ljinjuliguancha = 79201013;
            public const int Buzhihuoshan = 97820005;
            public const int Gxingxiong = 79029326;
            public const int Ghei = 79029429;
            public const int Glapulande = 79029309;
            public const int Gleimu = 79029345;
            public const int Lzhoushu = 79201016;
            public const int DDDerwai = 63790509;
            public const int Lheiermo = 79201007;
            public const int LD32 = 79201006;
            public const int Kbingdu = 8824601;
            public const int Fengmo = 9981152;
            public const int Zhaohuanzhishengong = 4280259;
            public const int Gshitu = 79029097;
            public const int Shuijingjiqiao = 50588353;
            public const int Gsaergong = 79029426;
            public const int KbingduII = 8824602;
            public const int Huiliuli = 14558128;
            public const int G = 23434538;
            public const int Wuxianpaoying = 10045474;
            public const int Zhimingzhe = 24224830;
            public const int X9 = 8824594;
            public const int X11 = 8824596;
            public const int X13 = 8824598;
            public const int Kelai = 8824591;
            public const int D1 = 18897163;
            public const int D2 = 79559912;
            public const int D3 = 03758046;
            public const int D4 = 72402069;
            public const int D5 = 06766208;
            public const int D6 = 00987311;
            public const int D7 = 84569886;
            public const int D8 = 16006416;
            public const int D9 = 74583607;
            public const int D10 = 09024198;
            public const int Huiliuli2 = 14558127;
            public const int Suoniao = 94145021;

            //18897163, 79559912, 03758046, 72402069, 06766208, 00987311, 84569886, 16006416, 74583607, 09024198
        }
        public int Link(int id)
        {
            if (id == CardId.Fengmo) return 8;
            else if (id == CardId.Zhaohuanzhishengong) return 4;
            else if (id == CardId.Gshitu) return 3;
            else if (id == CardId.Shuijingjiqiao || id == CardId.Gsaergong) return 2;
            return 1;
        }
        List<int> Impermanence_list = new List<int>();
        bool Lyongbing = false;
        bool Lxiaohuolong = false;
        bool Yuchundefuzang = false;
        bool Ld32 = false;
        bool X13 = false;
        bool Buzhimingzhuzi = false;

        List<int> Duiqi_list = new List<int> {
          CardId.Lfashujiaoliu, CardId.Lcunqubeiju, CardId.Buzhihuoshan, CardId.Yiduiyi
        };
        public LuanyuExecutor(GameAI ai, Duel duel)
           : base(ai, duel)
        {
            //DDD额外卡库
            AddExecutor(ExecutorType.Activate, CardId.DDDerwai);
            //灰流丽
            AddExecutor(ExecutorType.Activate, CardId.Huiliuli, Hand_act_eff2);
            //锁鸟
            AddExecutor(ExecutorType.Activate, CardId.Suoniao, G_activate);
            //灰流丽
            AddExecutor(ExecutorType.Activate, CardId.Huiliuli2, Hand_act_eff2);
            //墓指
            AddExecutor(ExecutorType.Activate, CardId.Zhimingzhe, DefaultCalledByTheGrave);
            //G
            AddExecutor(ExecutorType.Activate, CardId.G, G_activate);
            //无限泡影
            AddExecutor(ExecutorType.Activate, CardId.Wuxianpaoying, Impermanence_activate);
            //昭和骑士
            AddExecutor(ExecutorType.SpSummon, CardId.Zhaohe);
            //罪 虹龙
            AddExecutor(ExecutorType.SpSummon, CardId.Zhonglong, ZhonglongSummon);
            //罪 虹龙
            // AddExecutor(ExecutorType.Activate, CardId.Zhonglong);
            //卡欧斯 克莱
            AddExecutor(ExecutorType.Activate, CardId.Kelai);
            //X9
            AddExecutor(ExecutorType.Activate, CardId.X9, X9Effect);
            //X11
            AddExecutor(ExecutorType.Activate, CardId.X11, X11Effect);
            //X13
            AddExecutor(ExecutorType.Activate, CardId.X13, X13Effect);
            //卡欧斯病毒I
            AddExecutor(ExecutorType.Activate, CardId.Kbingdu, IEffect);
            //卡欧斯病毒II
            AddExecutor(ExecutorType.Activate, CardId.KbingduII, IEffect);
            //卡欧斯病毒I
            AddExecutor(ExecutorType.Activate, CardId.Kbingdu, IE2ffect);
            //卡欧斯病毒II
            AddExecutor(ExecutorType.Activate, CardId.KbingduII, IE2ffect);
            //欧一
            AddExecutor(ExecutorType.Activate, CardId.Wzhenlaiouyi, WzhenlaiouyiEffect);
            //仙人的召还
            AddExecutor(ExecutorType.Activate, CardId.Xianrendezhaohuan, XianrendezhaohuanEffect);
            //引领潮流
            AddExecutor(ExecutorType.Activate, CardId.Yinlingchaoliu);
            //一对一
            AddExecutor(ExecutorType.Activate, CardId.Yiduiyi, YiduiyiEffect);
            //增援
            AddExecutor(ExecutorType.Activate, CardId.Zengyuan);
            //召唤神弓
            AddExecutor(ExecutorType.Activate, CardId.Zhaohuanzhishengong);
            //干员 黑
            AddExecutor(ExecutorType.Activate, CardId.Ghei);
            //库一
            AddExecutor(ExecutorType.Activate, CardId.Wzhenlaikuyi, WzhenlaikuyiEffect);
            //愚蠢的副葬
            AddExecutor(ExecutorType.Activate, CardId.Yuchundefuzang, YuchundefuzangEffect);
            //乱欲 法术交流
            AddExecutor(ExecutorType.Activate, CardId.Lfashujiaoliu, LfashijiaoliuEffect);
            //闪刀 逢魔不知火
            AddExecutor(ExecutorType.Activate, CardId.Sbuzhihuo);
            //电王
            AddExecutor(ExecutorType.Activate, CardId.Dianwang, DianwangEffect);
            //乱欲 碧水蓝天
            AddExecutor(ExecutorType.Activate, CardId.Lbishuilantian, LbishuilantianEffect);
            //乱欲 咒术
            AddExecutor(ExecutorType.SpSummon, CardId.Lzhoushu, LzhoushuSummon);
            //乱欲 咒术
            AddExecutor(ExecutorType.Activate, CardId.Lzhoushu, LzhoushuEffect);
            //乱欲 黑恶魔
            AddExecutor(ExecutorType.SpSummon, CardId.Lheiermo);
            //乱欲 D
            AddExecutor(ExecutorType.SpSummon, CardId.LD32, LD32Summon);
            //乱欲 D
            AddExecutor(ExecutorType.Activate, CardId.LD32, LD32Effect);
            //乱欲 黑恶魔
            AddExecutor(ExecutorType.Activate, CardId.Lheiermo, LheiermoEffect);
            //恶意
            AddExecutor(ExecutorType.Activate, CardId.Eyi);
            //乱欲 存款被拒
            AddExecutor(ExecutorType.Activate, CardId.Lcunqubeiju, LcunqubeijuEffect);
            //台本
            AddExecutor(ExecutorType.Activate, CardId.Taiben, Hand_act_eff);
            //闪现
            AddExecutor(ExecutorType.Activate, CardId.Shanxian, ShanxianEffect);
            //闪光
            AddExecutor(ExecutorType.Activate, CardId.Shanguang, ShanguangEffect);
            //乱欲 近距离观察
            AddExecutor(ExecutorType.Activate, CardId.Ljinjuliguancha, LjinjuliguanchaEffect);
            //不知火流 闪刀 
            AddExecutor(ExecutorType.Activate, CardId.Buzhihuoshan, BuzhihuoshanEffect);
            //暗黑界
            AddExecutor(ExecutorType.Activate, CardId.Anheijiedequyin, AnheijiedequyinEffect);
            //蔡文姬
            AddExecutor(ExecutorType.SpSummon, CardId.Caiwenji);
            //蔡文姬
            AddExecutor(ExecutorType.Activate, CardId.Caiwenji);
            //白丝之雷米
            AddExecutor(ExecutorType.Activate, CardId.Baisizhileimi, BaisizhileimiEffect);
            //不知名的竹子
            AddExecutor(ExecutorType.Activate, CardId.Buzhimingzhuzi, BuzhimingzhuziEffect);
            //散华灵
            AddExecutor(ExecutorType.Activate, CardId.Sanhualing, SanhualingEffect);
            //幻秒
            AddExecutor(ExecutorType.Activate, CardId.Huanmiao, HuanmiaoEffect);
            //东风幼龙
            AddExecutor(ExecutorType.SpSummon, CardId.Dongfengyoulong);
            //隗海兽影
            AddExecutor(ExecutorType.SpSummon, CardId.Kuihaishouying);
            //隗海兽影
            AddExecutor(ExecutorType.Activate, CardId.Kuihaishouying, KuihaishouyingEffect);
            //乱欲 兵
            AddExecutor(ExecutorType.Activate, CardId.Lyongbing, LyongbingEffct);
            //乱欲 小火龙
            AddExecutor(ExecutorType.Activate, CardId.Lxiaohuolong, LxiaohuolongEffct);
            //干员 星熊
            AddExecutor(ExecutorType.Activate, CardId.Gxingxiong, GxingxiongEffect);
            //不知名的竹子
            AddExecutor(ExecutorType.Summon, CardId.Buzhimingzhuzi, BuzhimingzhuziSummon);
            //幻秒
            AddExecutor(ExecutorType.Summon, CardId.Huanmiao, BuzhimingzhuziSummon);
            //干员 蕾姆
            AddExecutor(ExecutorType.SpSummon, CardId.Gleimu, GleimuSummon);
            //干员 蕾姆
            AddExecutor(ExecutorType.Activate, CardId.Gleimu, GleimuEffect);
            //逢魔
            AddExecutor(ExecutorType.SpSummon, CardId.Fengmo, FengmoSummon);
            //逢魔
            AddExecutor(ExecutorType.Activate, CardId.Fengmo);
            //乱欲 佣兵
            AddExecutor(ExecutorType.Summon, CardId.Lyongbing, LSummon);
            //乱欲 小火龙
            AddExecutor(ExecutorType.Summon, CardId.Lxiaohuolong, LSummon);
            //乱欲 狮蝎
            AddExecutor(ExecutorType.Summon, CardId.Lshixie, LSummon);
            //干员 萨尔贡
            AddExecutor(ExecutorType.SpSummon, CardId.Gsaergong, GsaergongSummon);
            //干员 萨尔贡
            AddExecutor(ExecutorType.Activate, CardId.Gsaergong);
            //干员 使徒
            AddExecutor(ExecutorType.SpSummon, CardId.Gshitu, GshituSummon);
            //干员 使徒
            AddExecutor(ExecutorType.Activate, CardId.Gshitu, GshituEffect);
            //水晶机巧 
            AddExecutor(ExecutorType.SpSummon, CardId.Shuijingjiqiao, ShuijingjiqiaoSummon);
            //水晶机巧 
            AddExecutor(ExecutorType.Activate, CardId.Shuijingjiqiao, ShuijingjiqiaoEffect);
            //召唤神弓
            AddExecutor(ExecutorType.SpSummon, CardId.Zhaohuanzhishengong, ZhaohuanzhishengongSummon);
            //干员 拉普兰德            
            AddExecutor(ExecutorType.SpSummon, CardId.Glapulande,GlapulandeSummon);
            //干员 拉普兰德     
            AddExecutor(ExecutorType.Activate, CardId.Glapulande);
            //白丝之雷米
           // AddExecutor(ExecutorType.Summon, CardId.Baisizhileimi);
            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);
            AddExecutor(ExecutorType.SpellSet, AllSpellSet);
            AddExecutor(ExecutorType.Activate, AllEffect);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);

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
            Lyongbing = false;
            Lxiaohuolong = false;
            Yuchundefuzang = false;
            Ld32 = false;
            X13 = false;
            Buzhimingzhuzi = false;
        }
        //G
        public bool G_activate()
        {
            return (Duel.Player == 1);
        }
        //灰流丽
        public bool Hand_act_eff()
        {
            return (Duel.LastChainPlayer == 1);
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
        public bool Hand_act_eff2()
        {
            if (Card.IsCode(CardId.Huiliuli) && Util.GetLastChainCard().HasSetcode(0x11e) && Util.GetLastChainCard().Location == CardLocation.Hand)
                return false;
            return (Duel.LastChainPlayer == 1);
        }
        //对方卡
        public bool AllEffect()
        {

            if (Card.IsCode(CardId.Kuihaishouying) || Card.IsCode(CardId.Kbingdu) || Card.IsCode(CardId.KbingduII) || Card.IsCode(CardId.Shanguang) || Card.IsCode(CardId.G) || Card.IsCode(CardId.Taiben) || Card.IsCode(CardId.Shanxian) || Card.IsCode(CardId.Lbishuilantian) || Card.IsCode(CardId.Zhimingzhe) || Card.IsCode(CardId.Wuxianpaoying) || Card.IsCode(CardId.Sanhualing) || Card.IsCode(CardId.Baisizhileimi) || Card.IsCode(CardId.Zhonglong) || Card.IsCode(CardId.Huanmiao) || Card.IsCode(CardId.X9) || Card.IsCode(CardId.X11) || Card.IsCode(CardId.X13) || Card.IsCode(CardId.Buzhihuoshan)) return false;
            else if (Card.IsCode(CardId.Huiliuli))
            {
                return (Duel.LastChainPlayer == 1);
            }
            else if (Card.IsCode(CardId.Sanhualing))
            {
                if (Duel.Player == 0) return false;
                foreach (ClientCard card in Enemy.GetMonsters())
                    if (Duel.Player == 1)
                    {
                        if (card != null)
                        {
                            if (card.HasType(CardType.Link))
                            {
                                AI.SelectOption(4);
                                return true;
                            }
                            else if (card.HasType(CardType.Fusion))
                            {
                                AI.SelectOption(1);
                                return true;
                            }
                            else if (card.HasType(CardType.Synchro))
                            {
                                AI.SelectOption(2);
                                return true;
                            }
                            else if (card.HasType(CardType.Ritual))
                            {
                                AI.SelectOption(0);
                                return true;
                            }
                            else if (card.HasType(CardType.Xyz))
                            {
                                AI.SelectOption(3);
                                return true;
                            }
                            return false;
                        }
                        return false;
                    }
                return false;
            }
            else if (!Card.IsCode(CardId.Kbingdu) && !Card.IsCode(CardId.KbingduII)) return true;
            return false;
        }
        //闪光
        private bool ShanguangEffect()
        {
            if (Bot.HasInHand(CardId.Lyongbing) || Bot.HasInHand(CardId.Lxiaohuolong) || Bot.HasInHand(CardId.Lshixie) || Bot.HasInHand(CardId.Lwomendeguang))
            {
                AI.SelectCard(CardId.Lyongbing, CardId.Lxiaohuolong, CardId.Lwomendeguang, CardId.Lshixie);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }
        //逢魔
        private bool FengmoSummon()
        {
            foreach (ClientCard card in Enemy.GetMonsters())
                if (card != null) return true;
            return false;
        }
        //病毒
        private bool K1bingduEffect()
        {
            if (Duel.Phase == DuelPhase.End && Duel.Player == 0)
            {
                AI.SelectCard(new int[] { 18897163, 79559912, 03758046, 72402069, 06766208, 00987311, 84569886, 16006416, 74583607, 09024198 });
                return true;
            }
            else if (Duel.Phase == DuelPhase.Standby && Duel.Player == 1)
            {
                if ((Bot.GetMonstersExtraZoneCount() > 0 && Bot.GetMonsterCount() >= 4) || (Bot.GetMonstersExtraZoneCount() > 0 && Bot.GetMonsterCount() >= 4)) return false;
                else return true;
            }
            return false;
        }
        //不知名的竹子
        public bool BuzhimingzhuziEffect()
        {
            if (!Buzhimingzhuzi)
            {
                Buzhimingzhuzi = true;
                return true;
            }
            else if (Buzhimingzhuzi) return false;
            return false;
        }
        //乱欲 近距离
        private bool LjinjuliguanchaEffect()
        {
            if (Util.ChainContainsCard(CardId.Eyi) && Duel.LastChainPlayer == 0) return false;
            return true;
        }
        //病毒
        private bool K2bingduEffect()
        {
            if (Duel.Phase == DuelPhase.End && Duel.Player == 1)
            {
                AI.SelectCard(new int[] { 18897163, 79559912, 03758046, 72402069, 06766208, 00987311, 84569886, 16006416, 74583607, 09024198 });
                return true;
            }
            else if (Duel.Phase == DuelPhase.Standby && Duel.Player == 0)
            {
                if ((Bot.GetMonstersExtraZoneCount() > 0 && Bot.GetMonsterCount() >= 4) || (Bot.GetMonstersExtraZoneCount() > 0 && Bot.GetMonsterCount() >= 4)) return false;
                else return true;
            }
            return false;
        }
        private bool AllSpellSet()
        {
            if (Bot.GetHandCount() >= 6)
                return true;
            return false;
        }
        //散华灵
        private bool SanhualingEffect()
        {
            if (Duel.Player == 0) return false;
            foreach (ClientCard card in Enemy.GetMonsters())
            if (Duel.Player == 1)
            {
                    if (card != null)
                    {
                        if (card.HasType(CardType.Link))
                        {
                            AI.SelectOption(4);
                            return true;
                        }
                        else if (card.HasType(CardType.Fusion))
                        {
                            AI.SelectOption(1);
                            return true;
                        }
                        else if (card.HasType(CardType.Synchro))
                        {
                            AI.SelectOption(2);
                            return true;
                        }
                        else if (card.HasType(CardType.Ritual))
                        {
                            AI.SelectOption(0);
                            return true;
                        }
                        else if (card.HasType(CardType.Xyz))
                        {
                            AI.SelectOption(3);
                            return true;
                        }
                        return false;
                    }
                    return false;
            }
            return false;

        }
        // X13
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
                    bool flag3 = base.Duel.CurrentChain.Count > 0 && base.Util.ChainContainsCard(CardType.Spell);
                    if (flag3)
                    {
                        base.AI.SelectCard(8824590);
                        base.AI.SelectAnnounceID(8824590);
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
                                bool flag7 = base.Duel.Player == 0;
                                if (flag7)
                                {
                                    base.AI.SelectAnnounceID(8824591);
                                    result = true;
                                }
                                else
                                {
                                    base.AI.SelectAnnounceID(8824584);
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
        //X9
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
        //闪现
        private bool ShanxianEffect()
        {
                foreach (ClientCard card in Bot.Hand)
                if (Card.Location == CardLocation.Hand)
                {
                    if (!card.HasSetcode(0x790b)) return false;
                    if (card.HasSetcode(0x790b) && Duel.Phase == DuelPhase.Standby)
                    {
                        AI.SelectCard(Duiqi_list);
                        AI.SelectNextCard(card);
                        return true;
                    }
                    else if (Duel.Phase == DuelPhase.Standby) return false;
                    else if (Duel.Phase != DuelPhase.Standby)
                    {
                        AI.SelectCard(Duiqi_list);
                        AI.SelectNextCard(card);
                        return true;
                    }
                    return false;

                }
                else if (Card.Location == CardLocation.SpellZone) return true;
            return false;
        }
        //X13
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
                            base.AI.SelectAnnounceID(9951088);
                            base.AI.SelectPosition(CardPosition.FaceUpDefence);
                            this.X13 = true;
                            result = true;
                        }
                        else
                        {
                            base.AI.SelectAnnounceID(8824591);
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
                        base.AI.SelectAnnounceID(8824584);
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

        //干员 拉普兰德
        private bool GlapulandeSummon()
        {
            List<ClientCard> targets = new List<ClientCard>();
            List<ClientCard> list = Enemy.GetMonsters();
            foreach (ClientCard card2 in list)
            if (card2 == null && (Bot.HasInMonstersZone(CardId.Zhaohuanzhishengong) || Bot.HasInMonstersZone(CardId.Ghei))) return false;
            if (Bot.GetMonsterCount() >= 2) return false;
            foreach (ClientCard card in list)
            {
                if (card != null)
                {
                    {
                        targets.Add(card);
                    }
                    AI.SelectMaterials(targets);
                    AI.SelectPosition(CardPosition.FaceUpDefence);
                    return true;
                }
                else if (card == null)
                {
                    AI.SelectMaterials(new List<int>() {
                    CardId.Wzhenlaikuyi,
                    CardId.Wzhenlaiouyi,
                    CardId.Gshitu,
                    CardId.Gleimu,
                    CardId.Lxiaohuolong,
                    CardId.Lyongbing,
                    CardId.Dongfengyoulong,
                    CardId.Dianwang,
                    CardId.LD32,
                    CardId.Shuijingjiqiao
                    });
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                return false;
            }
            return false;
        }
        private bool LSummon()
        {
            if (Bot.GetMonsterCount() == 1 && Bot.HasInMonstersZone(CardId.Fengmo)) return false;
            if ((!Lyongbing)) return true;
            return false;
        }
        //召唤神弓
        private bool ZhaohuanzhishengongSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Gshitu) && Bot.HasInMonstersZone(CardId.Ghei) && Bot.HasInMonstersZone(CardId.Gleimu)) return false;
            AI.SelectMaterials(new List<int>() {
                    CardId.Gshitu,
                    CardId.Wzhenlaikuyi,
                    CardId.Wzhenlaiouyi,
                    CardId.Gshitu,
                    CardId.Gleimu,
                    CardId.Lxiaohuolong,
                    CardId.Lyongbing,
                    CardId.Lshixie,
                    CardId.Lheiermo,
                    CardId.Dianwang,
                    CardId.Shuijingjiqiao,
                    CardId.LD32,
                    CardId.Lzhoushu
                    });
            return true;
        }
        //病毒
        private bool IEffect()
        {
            bool flag = (base.Bot.GetMonstersExtraZoneCount() > 0 && base.Bot.GetMonsterCount() >= 4) || (base.Bot.GetMonstersExtraZoneCount() == 0 && base.Bot.GetMonsterCount() >= 3);
            return !flag;
        }
        //病毒2
        private bool IE2ffect()
        {
            if (Duel.Phase == DuelPhase.Standby) return false;
            {
                AI.SelectCard(CardId.D1, CardId.D2, CardId.D3, CardId.D4, CardId.D5, CardId.D6, CardId.D7, CardId.D8, CardId.D9, CardId.D10);
                return true;
            }
        }
        //白丝之雷米
        private bool BaisizhileimiEffect()
        {
            if (Duel.CurrentChain.Count > 0)
            {
                return Duel.LastChainPlayer == 1;
            }
            else if(Card.Location==CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.Lyongbing);
                return true;
            }
            return false;
        }
        //水晶机巧
        private bool ShuijingjiqiaoEffect()
        {
            if (Bot.HasInMonstersZone(CardId.Zhaohuanzhishengong))
            {
                AI.SelectCard(CardId.Caiwenji, CardId.Dianwang);
                return true;
            }
            else
            {
                AI.SelectCard(CardId.Dianwang, CardId.Caiwenji);
                return true;
            }
        }
        //水晶机巧
        private bool ShuijingjiqiaoSummon()
        {
            if ((Bot.HasInMonstersZone(CardId.Ghei) && Bot.HasInMonstersZone(CardId.Zhaohuanzhishengong)) || ((Bot.HasInMonstersZone(CardId.Ghei) || Bot.HasInMonstersZone(CardId.Zhaohuanzhishengong)) && Bot.GetMonsterCount() <= 2)) return false;
            AI.SelectMaterials(new List<int>() {
                    CardId.Sanhualing,
                    CardId.Dongfengyoulong,
                    CardId.LD32,
                    CardId.Gleimu,
                    CardId.Caiwenji
                    });
            return true;
        }
        //隗海兽影
        private bool KuihaishouyingEffect()
        {
            if (Bot.HasInMonstersZone(CardId.Zhaohuanzhishengong) || Bot.HasInMonstersZone(CardId.Ghei) || Bot.HasInMonstersZone(CardId.Fengmo)) return false;
            if (Bot.GetCountCardInZone(Bot.SpellZone, CardId.Lbishuilantian) >= 2) return true;
            return false;
        }
        //暗黑界
        private bool AnheijiedequyinEffect()
        {
            AI.SelectCard(CardId.Lfashujiaoliu,CardId.Sbuzhihuo, CardId.Lyongbing);
            return true;
        }
        //竹子
        private bool BuzhimingzhuziSummon()
        {
            if (Bot.HasInExtra(CardId.Gsaergong) && Bot.GetMonsterCount() == 2) return true;
            return false;

        }
        //一对一
        private bool YiduiyiEffect()
        {
            foreach (ClientCard card in Bot.Hand.GetMonsters())
            if (card !=null  && card.IsCode(CardId.Buzhimingzhuzi)) return false;
            {
                AI.SelectCard(CardId.Lcunqubeiju, CardId.Dianwang, CardId.Wzhenlaikuyi, CardId.Wzhenlaiouyi, CardId.Ljinjuliguancha);
                AI.SelectNextCard(CardId.Dianwang);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
        }
        //乱欲 黑恶魔
        private bool LheiermoEffect()
        {

            List<ClientCard> targets = new List<ClientCard>();
            List<ClientCard> list = Bot.GetDeck();
                if (Card.Location == CardLocation.MonsterZone)
                {
                  if (Bot.HasInExtra(CardId.LD32)) return false;
                  else if (Duel.Phase != DuelPhase.Battle)
                  {
                    foreach (ClientCard card in list)
                    {
                        AI.SelectCard(CardId.Lxiaohuolong);
                        targets.Add(card);
                    }
                    AI.SelectNextCard(targets);
                    return true;
                  }
                  else
                  {
                    AI.SelectCard(CardId.LD32);
                    return true;
                  }
                }
                else if (Card.Location == CardLocation.Grave) return true;
            return false;

        }
        //乱欲 D32
        private bool LD32Effect()
        {
                List<ClientCard> targets = new List<ClientCard>();
                List<ClientCard> list = Enemy.GetDeck();
           
                if (Card.Location == CardLocation.MonsterZone)
                {
                    if (Duel.Phase != DuelPhase.BattleStart)
                    {
                        foreach (ClientCard card in list)
                        {
                            AI.SelectCard(CardId.Lzhoushu);
                            targets.Add(card);
                        }
                        AI.SelectNextCard(targets);
                        return true;
                    }
                    else if (Duel.Phase == DuelPhase.BattleStart) return true;
                    return false;
                }
                else if (Card.Location == CardLocation.Grave) return true;
            return false;
        }
        //欧一
        private bool WzhenlaiouyiEffect()
        {
            if (Bot.HasInHand(CardId.Yuchundefuzang) && !Yuchundefuzang) return false;
            return true;

        }
        //库一
        private bool WzhenlaikuyiEffect()
        {
            int a=0;
            ClientCard target = Util.GetBestEnemyMonster();
            if (Card.Location == CardLocation.Hand || Card.Location == CardLocation.SpellZone)
            {
                do
                {
                    if (a == 0)
                    {
                        if (target != null)
                        {
                            AI.SelectCard(target);
                            AI.SelectPosition(CardPosition.FaceUpAttack);
                            a++;
                            return true;
                        }
                        else if (target == null)
                        {
                            AI.SelectCard(CardId.Wzhenlaiouyi,CardId.Zhonglong);
                            AI.SelectPosition(CardPosition.FaceUpAttack);
                            a++;
                            return true;
                        }
                        a++;
                        return false;
                    }
                    else if (a >= 1)
                    {
                        if (target != null)
                        {
                            AI.SelectCard(target);
                            a++;
                            return true;
                        }
                        a++;
                        return false;

                    }
                }
                while (a >= 2); return false;

            }
            else if (Card.Location != CardLocation.MonsterZone)
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }
        //干员 使徒
        private bool GshituEffect()
        {
            AI.SelectCard(CardId.Gleimu);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //电王
        private bool DianwangEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                AI.SelectCard(CardId.Dianwang);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            else if (Card.Location == CardLocation.MonsterZone || Card.Location == CardLocation.Grave) return true;
            return false;
        }
        //原罪 究极宝玉神
        private bool ZhonglongSummon()
        {
            foreach (ClientCard card in Bot.Hand)
                if (Card.Location == CardLocation.Hand)
                {
                    if (card != null && card.IsCode(CardId.Zhonglong))
                    {
                        AI.SelectCard(card);
                        return true;
                    }
                    return false;
                }
            return false;
        }
        //乱欲 小火龙
        private bool LxiaohuolongEffct()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.Lshixie);
                return true;
            }
            else if (Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.LD32, CardId.Lheiermo, CardId.Lzhoushu, CardId.Lxiaohuolong, CardId.Lyongbing);
                return true;
            }
            return false;
        }
        //乱欲 咒术
        private bool LzhoushuEffect()
        {
            foreach (ClientCard card in Enemy.Hand)
                foreach (ClientCard card2 in Enemy.GetDeck())
                    if (Card.Location == CardLocation.MonsterZone)
                    {
                        if (card != null && card.HasType(CardType.Monster))
                        {
                            AI.SelectCard(card);
                            AI.SelectPosition(CardPosition.FaceUpDefence);
                            return true;
                        }
                        else if (card2 != null && card2.HasType(CardType.Tuner) && Bot.HasInExtra(CardId.Shuijingjiqiao))
                        {
                            AI.SelectCard(card2);
                            AI.SelectPosition(CardPosition.FaceUpDefence);
                            return true;
                        }
                        else return true;


                    }
                    else if (Card.Location == CardLocation.Grave) return true;
            return false;
        }
        //干员 萨尔贡
        private bool GsaergongSummon()
        {
            AI.SelectMaterials(new List<int>() {
                CardId.Lheiermo,
                CardId.LD32,
                CardId.Zhaohe,
                CardId.Dongfengyoulong,
                CardId.Caiwenji,
                CardId.Dianwang,
                CardId.Lyongbing,
                CardId.Zhonglong
                });
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        private bool LD32Summon()
        {
            AI.SelectPosition(CardPosition.FaceUpAttack);
            AI.SelectMaterials(new List<int>() {
             CardId.Lzhoushu,
             CardId.Lshixie
                });
            return true;
        }
        //乱欲 佣兵
        private bool LyongbingEffct()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.Lbishuilantian, CardId.Lcunqubeiju);
                Lyongbing = true;
                return true;
            }
            else if (Card.Location == CardLocation.Grave) return true;
            return false;
        }
        //干员 使徒
        private bool GshituSummon()
        {
            AI.SelectMaterials(new List<int>() {
                    CardId.Gsaergong,
                    CardId.Gleimu,
                    CardId.Lheiermo,
                    CardId.LD32,
                    });
            return true;
        }
        //干员 使徒
        private bool Gshitu2Summon()
        {
            if (Bot.HasInMonstersZone(CardId.Gsaergong) && Bot.HasInMonstersZone(CardId.Gleimu))
            {
                    AI.SelectMaterials(new List<int>() {
                    CardId.Gsaergong,
                    CardId.Gleimu
                    });
                return true;
            }
            else if (Bot.HasInMonstersZone(CardId.Gsaergong) && Bot.HasInMonstersZone(CardId.Gsaergong + 1))
            {
                AI.SelectCard(CardId.Gsaergong, CardId.Gsaergong + 1);
                return true;
            }
            foreach (ClientCard extra_card in Bot.GetMonstersInExtraZone())
            {
                if (Link(extra_card.Id) >= 4) return false;
            }
            IList<ClientCard> targets = new List<ClientCard>();
            foreach (ClientCard t_check in Bot.GetMonsters())
            {
                if (t_check.IsFacedown()) continue;
                if (t_check.IsCode(CardId.Gsaergong))
                {
                    targets.Add(t_check);
                    break;
                }
            }
            if (targets.Count == 0) return false;
            List<ClientCard> m_list = new List<ClientCard>(Bot.GetMonsters());
            m_list.Sort(CardContainer.CompareCardAttack);
            foreach (ClientCard e_check in m_list)
            {
                if (e_check.IsFacedown()) continue;
                if (Link(e_check.Id) <= 2 && !e_check.IsCode(CardId.Fengmo))
                {
                    targets.Add(e_check);
                    break;
                }
            }
            if (targets.Count <= 1) return false;
            AI.SelectMaterials(targets);
            return true;
        }
        //乱欲 咒术
        private bool LzhoushuSummon()
        {
            AI.SelectMaterials(new List<int>() {
                CardId.Lyongbing,
                CardId.Lxiaohuolong
                });
            AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }
        //仙人的召还
        private bool XianrendezhaohuanEffect()
        {
            AI.SelectCard(CardId.Lfashujiaoliu);
            return true;
        }
        //干员 星熊
        private bool GxingxiongEffect()
        {
            AI.SelectCard(CardId.Ghei);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //蕾姆
        private bool GleimuEffect()
        {
            AI.SelectCard(CardId.Gxingxiong);
            return true;
        }
        //不知火 闪刀
        private bool BuzhihuoshanEffect()
        {
            if (Duel.CurrentChain.Count > 0)
            {
                return Duel.LastChainPlayer == 1;
            }
            else if (Card.Location == CardLocation.Grave) return true;
            return false;
            
        }
        //幻秒
        private bool HuanmiaoEffect()
        {
            if (Enemy.GetMonsterCount() != 0)
            {
                return Duel.LastChainPlayer == 1;
            }
            return false;
        }
        //干员 蕾姆
        private bool GleimuSummon()
        {
            ClientCard target = Util.GetBestEnemyMonster();
            if (target != null)
            {
                AI.SelectCard(target);
                return true;
            }
            else if (target == null)
            {
                AI.SelectCard(CardId.Zhonglong,CardId.Lshixie, CardId.Lxiaohuolong,CardId.Lyongbing,CardId.Sanhualing);
                return true;
            }
            return false;
        }
        //愚蠢的副葬
        private bool YuchundefuzangEffect()
        {
            AI.SelectCard(CardId.Lfashujiaoliu,CardId.Lcunqubeiju);
            Yuchundefuzang = true;
            return true;
        }
        //乱欲 碧水蓝天
        private bool LbishuilantianEffect()
        {
            int i=0;
            do
            {
                if (i == 0)
                {
                    if (!Lyongbing)
                    {
                        AI.SelectCard(CardId.Lyongbing, CardId.Lxiaohuolong);
                        AI.SelectOption(1);
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                        i++;
                        return true;
                    }
                    else if (!Lxiaohuolong && !Bot.HasInMonstersZone(CardId.Lxiaohuolong))
                    {
                        AI.SelectCard(CardId.Lxiaohuolong, CardId.Lyongbing, CardId.Lshixie);
                        AI.SelectOption(1);
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                        i++;
                        return true;
                    }
                    else if (!Lxiaohuolong && Bot.HasInMonstersZone(CardId.Lxiaohuolong))
                    {
                        AI.SelectCard(CardId.Lshixie, CardId.Lxiaohuolong, CardId.Lyongbing);
                        AI.SelectOption(1);
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                        i++;
                        return true;

                    }
                    else
                    {
                        AI.SelectCard(CardId.Lxiaohuolong, CardId.Lshixie, CardId.Lyongbing);
                        AI.SelectOption(1);
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                        i++;
                        return true;
                    }
                }
                else if (i == 1)
                {
                    foreach (ClientCard card in Bot.GetGraveyardMonsters())
                        if (!card.HasSetcode(0x790b)) return false;
                        else if (Bot.HasInMonstersZone(CardId.LD32) && Bot.HasInMonstersZone(CardId.Lheiermo)) return false;
                        else if (!Lxiaohuolong && Bot.GetMonsterCount() >= 4 && !Bot.HasInHand(CardId.Lbishuilantian)) return false;
                        else if (!Lxiaohuolong && Bot.GetMonsterCount() >= 3 && Bot.HasInHand(CardId.Lbishuilantian)) return false;
                        else if (Bot.HasInMonstersZone(CardId.Lheiermo) && Bot.HasInMonstersZone(CardId.LD32)) return false;
                        else if (!Bot.HasInMonstersZone(CardId.Lheiermo))
                        {
                            AI.SelectCard(CardId.Lxiaohuolong, CardId.Lyongbing);
                            AI.SelectPosition(CardPosition.FaceUpAttack);
                            i++;
                            return true;
                        }
                        else if (Bot.HasInMonstersZone(CardId.Lheiermo))
                        {
                            AI.SelectCard(CardId.Lyongbing, CardId.Lxiaohuolong);
                            AI.SelectPosition(CardPosition.FaceUpAttack);
                            i++;
                            return true;
                        }
                    return false;
                }

            }
            while (i >= 2); return false;
        }
        //乱欲 存款被拒
        private bool LcunqubeijuEffect()
        {
            if (Card.Location != CardLocation.Grave) return true;
            else if (Card.Location == CardLocation.Grave)
            {
                if((Util.ChainContainsCard(CardId.Lheiermo) || Util.ChainContainsCard(CardId.LD32))  && Duel.LastChainPlayer == 0) return false;
                return true;
            }
            return false;
        }
        //乱欲 法术交流
        private bool LfashijiaoliuEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.Lbishuilantian,CardId.Lfashujiaoliu);
                return true;
            }
            return false;
        }
    }
}
