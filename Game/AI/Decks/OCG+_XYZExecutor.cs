using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("XYZ", "AI_XYZ", "NotFinished")]
    public class XYZExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Gshenzhang = 20292186;
            public const int Lshixie = 79201004;
            public const int Y = 65622692;
            public const int Z = 64500000;
            public const int X = 9952000;
            public const int Tciyuanpao = 9952001;
            public const int Zhuzi = 60000001;
            public const int Mozhu = 60000004;
            public const int Sanhualing = 72100051;
            public const int Tongmengshaonv = 9950817;
            public const int Xingqiugaizao = 73628505;
            public const int Tongmengdaolai = 9982557;
            public const int Zhimingzhe = 24224830;
            public const int Ciyuangenaku = 9952021;
            public const int Tongmenggelaku = 66399653;
            public const int Gbaowuku = 129223325;
            public const int Lapulande = 79029309;
            public const int VWXYZ = 84243274;
            public const int XYZshenlong = 9952003;
            public const int XYZji = 9952008;
            public const int YY = 9952006;
            public const int Xshoulingjianong = 9952002;
            public const int Dianzilongwuxian = 10443957;
            public const int Dianzilong = 58069384;
            public const int Yinjianren = 50002301;
            public const int Pomiezhiyan = 14010199;
            public const int Secha = 54719828;
            public const int VTO = 9982558;
        }
        List<int> Impermanence_list = new List<int>();
        bool Tciyuanpao = false;
        bool Xshoulingjianong = false;
        bool Buzhimingzhuzi = false;
        bool VTO = false;
        bool Yinjianren = false;
        //选择
        List<int> should_select = new List<int>
        {
            CardId.Y,CardId.Z,CardId.Tciyuanpao,CardId.Tongmengshaonv,CardId.Xingqiugaizao,CardId.Tongmengdaolai,CardId.Tongmenggelaku,CardId.Ciyuangenaku
        };
        public XYZExecutor(GameAI ai, Duel duel)
        : base(ai, duel)
        {
            //同盟少女
            AddExecutor(ExecutorType.Activate, CardId.Tongmengshaonv, TongmengshaonvEffect);
            //X 素体
            AddExecutor(ExecutorType.Activate, CardId.X, XEffect);
            //VTOZ
            AddExecutor(ExecutorType.Activate, CardId.VTO, VTOEffect);
            //电子龙 无限
            AddExecutor(ExecutorType.Activate, CardId.Dianzilongwuxian, CyberDragonInfinityEffect);
            //双重龙头
            AddExecutor(ExecutorType.Activate, CardId.YY);
            //VWXYZ
            AddExecutor(ExecutorType.Activate, CardId.VWXYZ);
            //阴间人
            AddExecutor(ExecutorType.Activate, CardId.Yinjianren, YinjianrenEffect);
            //墓指
            AddExecutor(ExecutorType.Activate, CardId.Zhimingzhe, DefaultCalledByTheGrave);
            //乱欲 狮蝎
            AddExecutor(ExecutorType.Activate, CardId.Lshixie);
            //竹子
            AddExecutor(ExecutorType.Activate, CardId.Zhuzi, BuzhimingzhuziEffect);
            //墨竹
            AddExecutor(ExecutorType.Activate, CardId.Mozhu);
            //散华灵
            AddExecutor(ExecutorType.Activate, CardId.Sanhualing, SanhualingEffect);
            //星球改造
            AddExecutor(ExecutorType.Activate, CardId.Xingqiugaizao, XingqiugaizaoEffect);
            //同盟库
            AddExecutor(ExecutorType.Activate, CardId.Tongmenggelaku, TongmenggelakuEffect);
            //同盟到来
            AddExecutor(ExecutorType.Activate, CardId.Tongmengdaolai, TongmengdaolaiEffect);
            //古遗物的宝物库
            AddExecutor(ExecutorType.Activate, CardId.Gbaowuku, GbaowukuEffect);
            //次元库
            AddExecutor(ExecutorType.Activate, CardId.Ciyuangenaku, CiyuangenakuEffect);
            //发动次元库
            AddExecutor(ExecutorType.Activate, CardId.Ciyuangenaku, CiyuangenakuEffect2);
            //同盟少女
            AddExecutor(ExecutorType.Summon, CardId.Tongmengshaonv);
            //X 加农
            AddExecutor(ExecutorType.Summon, CardId.X);
            //同盟 次元破坏炮
            AddExecutor(ExecutorType.Activate, CardId.Tciyuanpao, TciyuanpaoEffect);
            //VTOZ
            AddExecutor(ExecutorType.SpSummon, CardId.VTO,VTOSummon);

            //X首领加农
            AddExecutor(ExecutorType.SpSummon, CardId.Xshoulingjianong, XshoulingjianongSummon);
            //X首领加农
            AddExecutor(ExecutorType.Activate, CardId.Xshoulingjianong, XshoulingjianongEffect);
            //三色叉
            AddExecutor(ExecutorType.SpSummon, CardId.Secha, SechaSummon);
            //破灭之眼
            AddExecutor(ExecutorType.SpSummon, CardId.Pomiezhiyan, PomiezhiyanSummon);
            //破灭之眼
            AddExecutor(ExecutorType.Activate, CardId.VTO);
            //阴间人
            AddExecutor(ExecutorType.SpSummon, CardId.Yinjianren, YinjianrenSummon);
            //YY双重龙头
            AddExecutor(ExecutorType.SpSummon, CardId.YY, YYSummon);
            //电子龙
            AddExecutor(ExecutorType.SpSummon, CardId.Dianzilong);
            //电子龙
            AddExecutor(ExecutorType.Activate, CardId.Dianzilong);
            //电子龙 无限
            AddExecutor(ExecutorType.SpSummon, CardId.Dianzilongwuxian);
            //XYZ神炮龙
            AddExecutor(ExecutorType.SpSummon, CardId.XYZshenlong, XYZshenlongSummon);
            //XYZ神炮龙
            AddExecutor(ExecutorType.Activate, CardId.XYZshenlong, XYZshenlongEffect);
            //XYZ极神炮龙
            AddExecutor(ExecutorType.SpSummon, CardId.XYZji, XYZjiummon);
            //XYZ极神炮龙
            AddExecutor(ExecutorType.Activate, CardId.XYZji, XYZjiEffect);

            //破灭之眼
            AddExecutor(ExecutorType.SpSummon, CardId.Pomiezhiyan);
            //破灭之眼
            AddExecutor(ExecutorType.Activate, CardId.Pomiezhiyan);
            //色叉
            AddExecutor(ExecutorType.SpSummon, CardId.Secha);
            //色叉
            AddExecutor(ExecutorType.Activate, CardId.Secha);

            //X
            AddExecutor(ExecutorType.Activate, CardId.X, ZhuangbeiEffect);
            //首领加农
            AddExecutor(ExecutorType.Activate, CardId.Xshoulingjianong,ZhuangbeiEffect2);
            //次元破坏炮
            AddExecutor(ExecutorType.Activate, CardId.Tciyuanpao, ZhuangbeiEffect3);
            //同盟少女
            AddExecutor(ExecutorType.Activate, CardId.Tongmengshaonv, ZhuangbeiEffect4);

            //三色叉
            AddExecutor(ExecutorType.Activate, CardId.Secha);

            //Y
            AddExecutor(ExecutorType.SummonOrSet, CardId.Y);
            //Z
            AddExecutor(ExecutorType.SummonOrSet, CardId.Z);

            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
        }
        //计数专用
        public override void OnNewTurn()
        {
            // reset
            Tciyuanpao = false;
            Xshoulingjianong = false;
            Buzhimingzhuzi = false;
            VTO = false;
            Yinjianren = false;
        }
        private bool SpellSetEffect()
        {
            return ((Card.IsTrap() && !Card.IsCode(CardId.Gbaowuku))|| (Card.HasType(CardType.QuickPlay) && !Card.IsCode(CardId.Gbaowuku))) && Bot.GetSpellCountWithoutField() < 4;
        }
        //X 素体
        private bool XEffect()
            {

            if (Card.Location == CardLocation.MonsterZone)
            {
                if (Duel.CurrentChain.Count > 0)
                {
                    if (!Tciyuanpao)
                    {
                        AI.SelectCard(CardId.Tciyuanpao, CardId.Y, CardId.Z);
                    }
                    else
                    {
                        AI.SelectCard(CardId.Y, CardId.Z, CardId.Tciyuanpao);
                    }
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                else if (ActivateDescription == Util.GetStringId(CardId.X, 0)) return false;
                //  if (ActivateDescription == Util.GetStringId(CardId.X, 0))
                //{
                else  if (!Tciyuanpao)
                {
                    AI.SelectCard(CardId.Tciyuanpao, CardId.Y, CardId.Z);
                }
                else
                {
                    AI.SelectCard(CardId.Y, CardId.Z, CardId.Tciyuanpao);
                }
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
                //}
                // return false;

            }
            else if (Card.Location == CardLocation.SpellZone) return true;
            else if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.Tciyuanpao, CardId.Y, CardId.Z);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                AI.SelectPlace(Zones.NotLinkedZones);
                return true;
            }
            return false;
        }
        //VTO
        private bool PomiezhiyanSummon()
        {
            if (Enemy.LifePoints <= 2500)
            {
                AI.SelectMaterials(new List<int>() {
                CardId.Tciyuanpao,
                CardId.Z,
                CardId.Y,
                CardId.X
            });
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }
        //VTO
        private bool VTOSummon()
        {
            AI.SelectMaterials(new List<int>() {
                CardId.Tongmengshaonv,
                CardId.Tciyuanpao,
                CardId.X,
                CardId.Xshoulingjianong
            });
            return true;
        }
        //装备效果 X
        private bool ZhuangbeiEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.X, 0))
            {
                AI.SelectCard(CardId.VTO, CardId.XYZshenlong, CardId.XYZji);
                return true;
            }
            return false;

        }
        //阴间人
        private bool YinjianrenEffect()
        {
            AI.SelectCard(CardId.Tciyuanpao);
            Yinjianren = true;
            return true;
        }
        //装备效果 首领加农
        private bool ZhuangbeiEffect2()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Xshoulingjianong, 0))
            {
                AI.SelectCard(CardId.VTO, CardId.XYZshenlong, CardId.XYZji);
                return true;
            }
            return false;

        }
        //装备效果 次元破坏炮
        private bool ZhuangbeiEffect3()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Tciyuanpao, 0))
            {
                AI.SelectCard(CardId.VTO, CardId.XYZshenlong, CardId.XYZji);
                return true;
            }
            return false;

        }
        //装备效果 同盟少女
        private bool ZhuangbeiEffect4()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Tongmengshaonv, 0))
            {
                AI.SelectCard(CardId.VTO, CardId.XYZshenlong, CardId.XYZji);
                return true;
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
        //电子龙无限
        private bool CyberDragonInfinityEffect()
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

        //阴间人
        private bool YinjianrenSummon()
        {
            AI.SelectMaterials(new List<int>() {
                CardId.Tciyuanpao,
                CardId.Z,
                CardId.Y,
                CardId.X
            });
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        private bool SechaSummon()
        {
            if (!VTO)
            {
                AI.SelectMaterials(new List<int>() {
                CardId.Tciyuanpao,
                CardId.Z,
                CardId.Y,
                CardId.X
            });
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }
        //VTOZ
        private bool VTOEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.VTO, 0))
            {
                if (!Bot.HasInHand(CardId.Y))
                {
                    AI.SelectCard(CardId.Y, CardId.Z, CardId.Tciyuanpao, CardId.X);
                }
                else if (Bot.HasInHand(CardId.Y))
                {
                    AI.SelectCard(CardId.Z, CardId.Tciyuanpao, CardId.Y, CardId.X);
                }
                else
                {
                    AI.SelectCard(CardId.Z, CardId.Y, CardId.Tciyuanpao, CardId.X);
                }
                if (Bot.HasInMonstersZone(CardId.Y) || Bot.HasInSpellZone(CardId.Y))
                {
                    AI.SelectNextCard(CardId.Z, CardId.Y, CardId.Tciyuanpao, CardId.X);
                }
                else if (Bot.HasInMonstersZone(CardId.Z) || Bot.HasInSpellZone(CardId.Z))
                {
                    AI.SelectNextCard(CardId.Y, CardId.Z, CardId.Tciyuanpao, CardId.X);
                }
                else
                { 
                    AI.SelectNextCard(CardId.Y, CardId.Z, CardId.Tciyuanpao, CardId.X);
                }
                AI.SelectThirdCard(CardId.X, CardId.Y, CardId.Z, CardId.Tciyuanpao);
                VTO = true;
                return true;
            }
            else
            {
                ClientCard target =Util.GetBestEnemyCard();
                if (Util.ChainContainsCard(CardId.Dianzilongwuxian) && Duel.LastChainPlayer == 0) return false;
                else if (Util.ChainContainsCard(CardId.Lshixie) && Duel.LastChainPlayer == 0) return false;
                else if (Bot.HasInMonstersZone(CardId.Yinjianren, true, true, true) && !Yinjianren && Duel.Player == 0 && target != null) return false;
                foreach (ClientCard card in Enemy.GetMonsters())
                    foreach (ClientCard card2 in Enemy.GetSpells())
                        if (card != null)
                        {
                            AI.SelectCard(card);
                            return true;
                        }
                        else if (card2 != null && card2.HasType(CardType.Continuous))
                        {
                            AI.SelectCard(card2);
                            return true;
                        }
                return false;
            } 

        }
        //散华灵
        private bool SanhualingEffect()
        {
            if (Duel.Player == 0) return false;
            foreach (ClientCard card in Enemy.GetMonsters())
            foreach (ClientCard card2 in Bot.GetMonsters())
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
                                if (card2 != null && card2.HasType(CardType.Fusion))
                                {
                                    AI.SelectOption(2);
                                    return true;
                                }
                                else
                                {
                                    AI.SelectOption(1);
                                    return true;
                                }
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
        //X首领加农
        private bool XshoulingjianongSummon()
        {
            if (Bot.GetMonstersInMainZone().Count == 5) return false;
            if (Xshoulingjianong) return false;
            AI.SelectCard(CardId.Tciyuanpao,CardId.Y,CardId.Z);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            AI.SelectPlace(Zones.MainMonsterZones);
            return true;
        }
        //XYZ神炮龙
        private bool XYZshenlongEffect()
        {
            ClientCard target1 = Util.GetBestEnemyMonster();
            ClientCard target2 = Util.GetBestEnemySpell();
            if (ActivateDescription == Util.GetStringId(CardId.XYZshenlong, 0))
            {
                ClientCard target = Util.GetBestEnemyCard();
                if (Bot.HasInMonstersZone(CardId.Yinjianren, true, true, true) && !Yinjianren && Duel.Player == 0 && target != null) return false;
                else if (Util.ChainContainsCard(CardId.Dianzilongwuxian) && Duel.LastChainPlayer == 0) return false;
                else if (Util.ChainContainsCard(CardId.Lshixie) && Duel.LastChainPlayer == 0) return false;
                else if ((Util.ChainContainsCard(CardId.VTO) && Duel.LastChainPlayer == 0) || (Util.ChainContainsCard(CardId.XYZshenlong) && Duel.LastChainPlayer == 0)) return false;
                else if (!Bot.HasInHand(should_select)) return false;
                else if (Bot.HasInHand(should_select))
                {
                    if (target1 != null)
                    {
                        AI.SelectCard(should_select);
                        AI.SelectNextCard(target1);
                        return true;
                    }
                    else if (target2 != null)
                    {
                        AI.SelectCard(should_select);
                        AI.SelectNextCard(target2);
                        return true;
                    }
                    return false;
                }
                return false;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.XYZshenlong, 1))
            {
                if (Util.ChainContainsCard(CardId.YY) && Duel.LastChainPlayer == 0) return false;
                return true;
            }
            return false;
        }
        //XYZ极
        private bool XYZjiEffect()
        {
            return true;
        }
        //同盟 次元破坏炮
        private bool TciyuanpaoEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (ActivateDescription == Util.GetStringId(CardId.Tciyuanpao, 0)) return false;             
                    AI.SelectCard(CardId.VWXYZ);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    Tciyuanpao = true;
                    return true;
               
            }
            else if (Card.Location == CardLocation.SpellZone) return true;
            return false;
        }
        //星球改造
        private bool XingqiugaizaoEffect()
        {
            if (!Bot.HasInHandOrInSpellZone(CardId.Tongmenggelaku))
            {
                AI.SelectCard(CardId.Tongmenggelaku, CardId.Gbaowuku);
            }
            else
            {
                AI.SelectCard(CardId.Gbaowuku,CardId.Tongmenggelaku);
            }
            return true;
        }
        //YY双重龙头
        private bool YYSummon()
        {
            foreach (ClientCard card in Bot.GetMonstersInMainZone())
                if (Bot.GetMonstersInMainZone().Count >= 5)
                {
                    if (card.IsCode(CardId.Z) || card.IsCode(CardId.Y) || card.IsCode(CardId.Tongmengshaonv) || card.IsCode(CardId.Tciyuanpao) || card.IsCode(CardId.X))
                    {
                        AI.SelectCard(card);
                    }
                    else
                    {
                        AI.SelectCard(CardId.Z, CardId.Y, CardId.Tongmengshaonv, CardId.Tciyuanpao, CardId.X);
                    }
                }
                else
                {
                     AI.SelectCard(CardLocation.Grave);
                }
            AI.SelectNextCard(CardLocation.Grave);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            AI.SelectPlace(Zones.MainMonsterZones);
            return true;
        }
        //YY
        private bool XYZjiummon()
        {
            AI.SelectCard(CardLocation.Removed);
            AI.SelectNextCard(CardLocation.Removed);
            AI.SelectThirdCard(CardLocation.Removed);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        private bool XYZshenlongSummon()
        {
            AI.SelectCard(CardLocation.Grave | CardLocation.SpellZone | CardLocation.MonsterZone);
            AI.SelectNextCard(CardLocation.Grave | CardLocation.SpellZone | CardLocation.MonsterZone);
            AI.SelectThirdCard(CardLocation.Grave | CardLocation.SpellZone | CardLocation.MonsterZone);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //X首领加农
        private bool XshoulingjianongEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {

                if (ActivateDescription == Util.GetStringId(CardId.Xshoulingjianong, 0)) return false;
                {
                    if (Bot.GetMonstersInMainZone().Count <= 3)
                    {
                        AI.SelectCard(CardId.X, CardId.Z, CardId.Y, CardId.Tciyuanpao);
                    }
                    else
                    {
                        if (!Bot.HasInMonstersZoneOrInGraveyard(CardId.Z) && !Bot.HasInSpellZone(CardId.Z))
                        {
                            AI.SelectCard(CardId.Z, CardId.Y, CardId.Tciyuanpao);
                        }
                        else if (!Bot.HasInMonstersZoneOrInGraveyard(CardId.Y) && !Bot.HasInSpellZone(CardId.Y))
                        {
                            AI.SelectCard(CardId.Y, CardId.Z, CardId.Tciyuanpao);
                        }
                        else
                        {
                            AI.SelectCard(CardId.Y, CardId.Z, CardId.Tciyuanpao);
                        }
                    }
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    Xshoulingjianong = true;
                    return true;
                }             

            }
            else if (Card.Location == CardLocation.SpellZone)
            {
                return true;
            }
            return false;
        }
        //发动同盟库
        private bool TongmenggelakuEffect2()
        {
            if (Card.Location == CardLocation.Hand)
                return DefaultField();
            return false;
        }
        //发动古遗物的宝物库
        private bool GbaowukuEffect2()
        {
            if (Card.Location == CardLocation.Hand)
                return true;
            return false;
        }
        //古遗物的宝物库
        private bool GbaowukuEffect()
        {
            if (Duel.Player == 0) return false;
            {
                if (ActivateDescription == Util.GetStringId(CardId.Gbaowuku, 2))
                {
                    AI.SelectCard(CardId.Gshenzhang);
                    return true;
                }
                else if (ActivateDescription == Util.GetStringId(CardId.Gbaowuku, 1))
                {
                    if (!Bot.HasInSpellZone(CardId.Gshenzhang)) return false;
                    AI.SelectCard(CardId.Gshenzhang);
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Gshenzhang, CardId.Gbaowuku);
                    return true;
                }
            }
        }
        //同盟库
        private bool TongmenggelakuEffect()
        {
            if (ActivateDescription != Util.GetStringId(CardId.Tongmenggelaku, 1))
            {
                if (!Bot.HasInHand(CardId.X) && !Bot.HasInMonstersZone(CardId.X))
                {
                    AI.SelectCard(CardId.X, CardId.Tciyuanpao);
                }
                else
                {
                    AI.SelectCard(CardId.Tciyuanpao, CardId.X);
                }
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Tongmenggelaku, 1))
            {

                AI.SelectCard(CardId.X,CardId.Y,CardId.Z);
                return true;
            }
            return false;
        }
        //次元库
        private bool CiyuangenakuEffect2()
        {
            if (Card.Location == CardLocation.Hand)
                return DefaultSpellZone();
            else if (Card.Location == CardLocation.SpellZone && Card.IsFacedown())
            {
                return true;
            }
            return false;
        }
        private bool DefaultSpellZone()
        {
            return Bot.SpellZone[0] == null || Bot.SpellZone[1] == null || Bot.SpellZone[2] == null || Bot.SpellZone[3] == null || Bot.SpellZone[4] == null;
        }
        //次元库
        private bool CiyuangenakuEffect()
        {
            if (ActivateDescription != Util.GetStringId(CardId.Ciyuangenaku, 1))
            {
                if (!Bot.HasInHand(CardId.X))
                {
                    AI.SelectCard(CardId.X, CardId.Tciyuanpao);
                }
                else
                {
                    AI.SelectCard(CardId.Tciyuanpao,CardId.X);
                }
                return true;
            }
            else if(ActivateDescription == Util.GetStringId(CardId.Ciyuangenaku, 1))
            {
                return true;
            }
            return false;
        }
        //同盟到来
        private bool TongmengdaolaiEffect()
        {
            if (Card.Location != CardLocation.Grave)
            {
                AI.SelectCard(CardId.X,CardId.Tciyuanpao);
                AI.SelectNextCard(CardId.Z,CardId.Y);
                return true;
            }
            else
            {
                return false;
            }
        }
        //同盟少女
        private bool TongmengshaonvEffect()
        {
           
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (ActivateDescription == Util.GetStringId(CardId.Tongmengshaonv, 0)) return false;      
                    AI.SelectCard(CardId.X);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;                                
            }
            else if (Card.Location == CardLocation.SpellZone) return true;
            else if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.Tciyuanpao);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }
    }
}
