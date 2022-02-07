using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using System.Linq;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
namespace WindBot.Game.AI.Decks
{
    // NOT FINISHED YET
    [Deck("PointStar", "AI_PointStar", "NotFinished")]
    public class PointStarExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Dilong = 98710310;
            public const int Hailong = 98710330;
            public const int Huolong = 98710308;
            public const int Fenglong = 98710312;
            public const int Shuilong = 98710313;
            public const int Guanglong = 98710309;
            public const int Anlong = 98710311;
            public const int Longwushi = 98710307;
            public const int Longqishi = 98710304;
            public const int Longkuangshi = 98710305;
            public const int Youlong = 98710300;
            public const int Riguanglong = 98710301;
            public const int Yuanlaowang = 98710302;
            public const int Mfengzhixiang = 98710314;
            public const int Mlongshenqishu = 98710325;
            public const int Mlongxue = 98710328;
            public const int Mdijie = 98710315;
            public const int Myuan = 98710317;
            public const int Maoyi = 98710326;
            public const int Xcaijue = 98710318;
            public const int Xheihaifuchen = 98710329;
            public const int Xsuipian = 98710322;
            public const int Xshuiji = 98710323;
            //extra 
            public const int Tiejiayanlong = 98710320;
            public const int Tiejiefeilong = 98710319;
            public const int Julongshen = 98710321;

        }
        bool DilongTrue = false;
        bool HuolongTrue = false;
        bool LongBattle = false;
        public PointStarExecutor(GameAI ai, Duel duel)
        : base(ai, duel)
        {
            //巨龙神效果
            AddExecutor(ExecutorType.Activate, CardId.Julongshen, JulongshenEffect);
            //元老王
            AddExecutor(ExecutorType.Summon, CardId.Yuanlaowang);
            //凤之乡
            AddExecutor(ExecutorType.Activate, CardId.Mfengzhixiang);
            //龙穴
            AddExecutor(ExecutorType.Activate, CardId.Mlongxue, MlongxueEffect);
            //日光龙
            AddExecutor(ExecutorType.Activate, CardId.Riguanglong, RiguanglongEffect);
            //魔陷放置
            AddExecutor(ExecutorType.SpellSet, SpellSetEffect);
            //奥义
            AddExecutor(ExecutorType.Activate, CardId.Maoyi, MaoyiEffect);
            //裁决
            AddExecutor(ExecutorType.Activate, CardId.Xcaijue, XcaijueEffect);
            //黑海浮沉
            AddExecutor(ExecutorType.Activate, CardId.Xheihaifuchen);
            //幼龙召唤 优先元老王
            AddExecutor(ExecutorType.Summon, CardId.Youlong, YoulongFirstSummon);
            //铁甲炎龙
            AddExecutor(ExecutorType.SpSummon, CardId.Tiejiayanlong, TiejiayanlongSummon);
            //铁甲炎龙发动
            AddExecutor(ExecutorType.Activate, CardId.Tiejiayanlong, TiejiayanlongEffect);
            //龙神骑术
            AddExecutor(ExecutorType.Activate, CardId.Mlongshenqishu);
            //元老王
            AddExecutor(ExecutorType.Activate, CardId.Yuanlaowang, YuanlaowangEffect);

            //水龙
            AddExecutor(ExecutorType.Summon, CardId.Shuilong, DragonSummon);
            //火龙
            AddExecutor(ExecutorType.Summon, CardId.Huolong, DragonSummon);
            //光龙
            AddExecutor(ExecutorType.Summon, CardId.Guanglong, DragonSummon);
            //暗龙
            AddExecutor(ExecutorType.Summon, CardId.Anlong, DragonSummon);
            //地龙
            AddExecutor(ExecutorType.Summon, CardId.Dilong, DragonSummon);
            //风龙
            AddExecutor(ExecutorType.Summon, CardId.Fenglong, DragonSummon);
            //海龙
            AddExecutor(ExecutorType.Summon, CardId.Hailong, DragonSummon);

            //幼龙召唤
            AddExecutor(ExecutorType.Summon, CardId.Youlong);
            //碎片
            AddExecutor(ExecutorType.Activate, CardId.Xsuipian);
            //水祭
            AddExecutor(ExecutorType.Activate, CardId.Xshuiji);
            //源 发动
            AddExecutor(ExecutorType.Activate, CardId.Myuan, MyuanActive);
            //源
            //AddExecutor(ExecutorType.Activate, CardId.Myuan, MyuanEffect);
            //地界
            AddExecutor(ExecutorType.Activate, CardId.Mdijie, MdijieEffect);
            //龙骑士
            AddExecutor(ExecutorType.SpSummon, CardId.Longqishi);
            //龙武士
            AddExecutor(ExecutorType.SpSummon, CardId.Longwushi);
            //龙狂士
            AddExecutor(ExecutorType.SpSummon, CardId.Longkuangshi);
            //巨龙神
            AddExecutor(ExecutorType.SpSummon, CardId.Julongshen, JulongshenSummon);
            //幼龙
            AddExecutor(ExecutorType.Activate, CardId.Youlong, YoulongEffect);

            //日光龙
            AddExecutor(ExecutorType.SummonOrSet, CardId.Riguanglong);

            //风龙效果
            AddExecutor(ExecutorType.Activate, CardId.Fenglong, FenglongEffect);

            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);

            //暗龙效果
            AddExecutor(ExecutorType.Activate, CardId.Anlong, AnlongEffect);


        }
        public override void OnNewTurn()
        {
            DilongTrue = false;
            HuolongTrue = false;
            LongBattle = false;
        }
        //战斗回卷
        public override bool OnSelectBattleReplay()
        {
            if (LongBattle)
            {
                LongBattle = false;
                return true;
            }
            return base.OnSelectBattleReplay();
        }
        //AI选择是否(火龙，地龙，源)
        public override bool OnSelectYesNo(long desc)
        {
            if (desc == Util.GetStringId(98710308, 5))
            {
                if (Enemy.GetMonsterCount()> 0)
                {
                    HuolongTrue = true;
                    return true;
                }
                return false;
            }
            else if (desc == Util.GetStringId(98710310, 4))
            {
                if (Enemy.GetMonsterCount()+Enemy.GetSpellCount()>=2)
                {
                    DilongTrue = true;
                    return true;
                }
                return false;
            }
            else if (desc == Util.GetStringId(98710317, 1))
            {
                return false;
            }
            return base.OnSelectYesNo(desc);
        }
        //地火龙选择卡片
        public override IList<ClientCard> OnSelectCard(IList<ClientCard> cards, int min, int max, long hint, bool cancelable)
        {
            if (DilongTrue)
            {
                IList<ClientCard> targets = new List<ClientCard>();
                foreach (ClientCard target in Enemy.GetMonsters())
                {
                    if (targets.Count >= 2)
                        break;
                    if (!targets.Contains(target))
                        targets.Add(target);
                }
                foreach (ClientCard target in Enemy.GetSpells())
                {
                    if (targets.Count >= 2)
                        break;
                    if (!targets.Contains(target))
                        targets.Add(target);
                }
                cards = targets;
                DilongTrue = false;
                LongBattle = true;
                return cards;
            }
            if (HuolongTrue)
            {
                IList<ClientCard> targets = new List<ClientCard>();
                foreach (ClientCard target in Enemy.GetMonsters())
                {
                    if (targets.Count >= 2 || targets.Count>=Enemy.GetMonsterCount())
                        break;
                    if (!targets.Contains(target))
                        targets.Add(target);
                }
                cards = targets;
                HuolongTrue = false;
                LongBattle = true;
                return cards;
            }
            return null;

        }
        //暗龙效果
        private bool AnlongEffect()
        {
            if (Card.IsAttack() && !Card.IsDisabled())
            {
                IList<ClientCard> cards= new List<ClientCard>();
                foreach (ClientCard card in Bot.Hand)
                {
                    if(cards.Count>=2 || cards.Count>=Bot.Hand.Count)
                    break;
                    if (!cards.Contains(card))
                        cards.Add(card);
                }
                AI.SelectNextCard(cards);
                return true;
            }
            return false;
        }
        //风龙效果
        private bool FenglongEffect()
        {
            if (!Card.IsDisabled())
            {
                AI.SelectCard(CardLocation.Hand);
                AI.SelectNextCard(CardLocation.MonsterZone | CardLocation.SpellZone);
                return true;
            }
            return false;
        }
        public int GetCountAttributeCardInZone(IEnumerable<ClientCard> cards, CardAttribute attribute)
        {
            return cards.Count(card => card != null && card.HasAttribute(attribute));
        }
        public int GetCountSetCodeCardInZone(IEnumerable<ClientCard> cards, int setcode)
        {
            return cards.Count(card => card != null && card.HasSetcode(setcode));
        }
        //龙召唤 
        private  bool DragonSummon()
         {
            int attribute = Card.Attribute;
            if (GetCountAttributeCardInZone(Bot.MonsterZone, (CardAttribute)attribute) > 2 && GetCountSetCodeCardInZone(Bot.MonsterZone, 0x6551) >= 1)
            {
                AI.SelectOption(1);
                return true;
            }
            else
            {
                AI.SelectCard(CardId.Riguanglong, CardId.Youlong, CardId.Longkuangshi, CardId.Longqishi, CardId.Longwushi, CardId.Tiejiayanlong);
                return true;
            }
         }
        //龙穴
        private bool MlongxueEffect()
        {
            if (Duel.Player == 0)
            {
                if (GetCountSetCodeCardInZone(Bot.Graveyard, 0x6550) > 1 && Duel.Phase == DuelPhase.Battle) return true;
                return false;
            }
            else if (Duel.Player == 1)
            {
                int selfBestAttack = Util.GetBestAttack(Bot);
                int oppoBestAttack = Util.GetBestAttack(Enemy);
                if ((Bot.HasInGraveyard(CardId.Huolong) || Bot.HasInGraveyard(CardId.Shuilong) || Bot.HasInGraveyard(CardId.Anlong)) && Bot.GetMonsterCount() < Enemy.GetMonsterCount()) return true;
                else if (Bot.HasInGraveyard(CardId.Shuilong)) return true;
                else if (Bot.GetMonsterCount() < Enemy.GetMonsterCount() || selfBestAttack < oppoBestAttack) return true;
                return false;
            }
            return false;
        }
        //卡组检查
        public int CheckRemainInDeck(int id)
        {
            switch (id)
            {
                case CardId.Dilong:
                    return Bot.GetRemainingCount(CardId.Dilong, 1);
                case CardId.Hailong:
                    return Bot.GetRemainingCount(CardId.Hailong, 1);
                case CardId.Huolong:
                    return Bot.GetRemainingCount(CardId.Huolong, 1);
                case CardId.Fenglong:
                    return Bot.GetRemainingCount(CardId.Fenglong, 1);
                case CardId.Shuilong:
                    return Bot.GetRemainingCount(CardId.Shuilong, 1);
                case CardId.Guanglong:
                    return Bot.GetRemainingCount(CardId.Guanglong, 1);
                case CardId.Anlong:
                    return Bot.GetRemainingCount(CardId.Anlong, 1);
                case CardId.Longwushi:
                    return Bot.GetRemainingCount(CardId.Longwushi, 3);
                case CardId.Longqishi:
                    return Bot.GetRemainingCount(CardId.Longqishi, 3);
                case CardId.Youlong:
                    return Bot.GetRemainingCount(CardId.Youlong, 3);
                case CardId.Riguanglong:
                    return Bot.GetRemainingCount(CardId.Riguanglong, 3);
                case CardId.Yuanlaowang:
                    return Bot.GetRemainingCount(CardId.Yuanlaowang, 3);
                case CardId.Mfengzhixiang:
                    return Bot.GetRemainingCount(CardId.Mfengzhixiang, 2);
                case CardId.Mlongshenqishu:
                    return Bot.GetRemainingCount(CardId.Mlongshenqishu, 1);
                case CardId.Mlongxue:
                    return Bot.GetRemainingCount(CardId.Mlongxue, 3);
                case CardId.Mdijie:
                    return Bot.GetRemainingCount(CardId.Mdijie, 3);
                case CardId.Myuan:
                    return Bot.GetRemainingCount(CardId.Myuan, 1);
                case CardId.Maoyi:
                    return Bot.GetRemainingCount(CardId.Maoyi, 3);
                case CardId.Xcaijue:
                    return Bot.GetRemainingCount(CardId.Xcaijue, 2);
                case CardId.Xheihaifuchen:
                    return Bot.GetRemainingCount(CardId.Xheihaifuchen, 1);
                case CardId.Xsuipian:
                    return Bot.GetRemainingCount(CardId.Xsuipian, 1);
                case CardId.Xshuiji:
                    return Bot.GetRemainingCount(CardId.Xshuiji, 1);
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
        //巨龙神效果
        private bool JulongshenEffect()
        {
               int option;
                if (Enemy.GetSpellCount() >= Bot.GetSpellCount() && !Bot.HasInSpellZone(CardId.Mdijie, true, true))
                {
                    option = 1;
                }
                else if (Duel.Phase == DuelPhase.Main2 && Bot.GetMonsterCount() == 1 && Bot.GetMonsterCount() < Enemy.GetMonsterCount())
                {
                    option = 0;
                }
                else return false;
            if (ActivateDescription != Util.GetStringId(CardId.Julongshen, option)) return false;
            return true;
        }
        public int GetCountStateCardInZone(IEnumerable<ClientCard> cards, bool atk, bool defen)
        {
            if (atk && !defen)
            {
                return cards.Count(card => card != null && card.IsAttack());
            }
            if (!atk && defen)
            {
                return cards.Count(card => card != null && card.IsDefense());
            }
            if (atk && defen)
            {
                return cards.Count(card => card != null && card.IsFaceup());
            }
            if (!atk && !defen)
            {
                return cards.Count(card => card != null && card.IsFacedown());
            }
            return 0;
        }
        //巨龙神
        private bool JulongshenSummon()
        {
            int selfBestAttack = Util.GetBestAttack(Bot);
            int oppoBestAttack = Util.GetBestAttack(Enemy);
            if (Duel.Turn != 1 && GetCountStateCardInZone(Enemy.MonsterZone, true, false) > 0 && (selfBestAttack <= oppoBestAttack))
            {
                AI.SelectMaterials(new int[] { CardId.Tiejiayanlong, CardId.Tiejiayanlong, CardId.Fenglong, CardId.Guanglong, CardId.Hailong, CardId.Dilong });
                return true;
            }
            return false;
        }
        //幼龙召唤
         private bool YoulongFirstSummon()
         {
            if (Bot.HasInHandOrHasInMonstersZone(CardId.Longkuangshi) || Bot.HasInHandOrHasInMonstersZone(CardId.Longqishi) || Bot.HasInHandOrHasInMonstersZone(CardId.Longwushi))
            {
                if ((GetCountSetCodeCardInZone(Bot.Hand, 0x6550) <= 0 || GetCountSetCodeCardInZone(Bot.MonsterZone, 0x6550) <= 0) && Bot.HasInExtra(CardId.Tiejiayanlong) && (CheckRemainInDeck(CardId.Shuilong) > 0 || CheckRemainInDeck(CardId.Huolong) > 0 || CheckRemainInDeck(CardId.Fenglong) > 0 || CheckRemainInDeck(CardId.Anlong) > 0 || CheckRemainInDeck(CardId.Dilong) > 0 || CheckRemainInDeck(CardId.Hailong) > 0 || CheckRemainInDeck(CardId.Guanglong) > 0))
                {
                    return true;
                }
                return false;
            }
            else if (Bot.HasInSpellZone(CardId.Mlongshenqishu)) return true;
            else if (Bot.HasInMonstersZone(CardId.Yuanlaowang) && Bot.GetMonstersInMainZone().Count <= 3)
            {
                return true;
            }
            return false;

         }
        //铁甲炎龙
        private bool TiejiayanlongSummon()
        {
            if (GetCountSetCodeCardInZone(Bot.MonsterZone, 0x6550) > 0 && GetCountSetCodeCardInZone(Bot.Hand, 0x6550) > 0)
            {
                AI.SelectCard(CardLocation.Hand);
            }
            else if (Bot.HasInMonstersZone(CardId.Shuilong))
            {
                AI.SelectCard(CardId.Huolong, CardId.Anlong, CardId.Hailong, CardId.Fenglong, CardId.Guanglong);
            }
            else if (Bot.HasInMonstersZone(CardId.Huolong))
            {
                AI.SelectCard(CardId.Anlong, CardId.Hailong, CardId.Fenglong,CardId.Guanglong);
            }
            else if (Bot.HasInMonstersZone(CardId.Anlong))
            {
                AI.SelectCard(CardId.Hailong, CardId.Fenglong, CardId.Guanglong);
            }
            else
            {
                AI.SelectCard(CardId.Shuilong, CardId.Huolong, CardId.Anlong, CardId.Hailong, CardId.Fenglong,CardId.Guanglong);
            }
            AI.SelectNextCard(CardId.Longqishi, CardId.Longwushi,CardId.Longkuangshi);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            AI.SelectPlace(Zones.z6 | Zones.z5);
            return true;
        }
        //魔陷放置
        private bool SpellSetEffect()
        {
            if (Bot.HasInHandOrInSpellZone(CardId.Mlongshenqishu) && GetCountSetCodeCardInZone(Bot.Hand, 0x6550) > 0 && (Bot.Hand.Count - GetCountSetCodeCardInZone(Bot.Hand, 0x6550) > 1) && CheckRemainInDeck(CardId.Longqishi)>0)
            {
                return (Card.IsTrap()||Card.IsSpell()) && Bot.GetSpellCountWithoutField() < 4 ;
            }
            return false;
        }
        //地界
        private bool MdijieEffect()
        {
            if (Bot.GetMonsterCount() <= 0 || Bot.HasInSpellZone(CardId.Mdijie,true,true)) return false;
            return true;
        }
        //日光龙
        private bool RiguanglongEffect()
        {
            AI.SelectCard(CardId.Riguanglong);
            return true;
        }
        //源 效果
        private bool MyuanEffect()
        {
            if (Card.Location == CardLocation.SpellZone && Card.IsFaceup())
            {
                AI.SelectYesNo(false);
                return true;
            }
            return false;
        }
        //源 发动
        private bool MyuanActive()
        {if (Card.Location == CardLocation.Hand || (Card.Location == CardLocation.SpellZone && Card.IsFacedown()))
            {
                if (Duel.Turn == 1 || Duel.Phase == DuelPhase.Main2) return true;
                return false;
            }
            return false;
        }
        //铁甲炎龙
        private bool TiejiayanlongEffect()
        {
            if ((GetCountSetCodeCardInZone(Bot.Hand, 0x6550) > 0 || GetCountSetCodeCardInZone(Bot.MonsterZone, 0x6550) > 0) && (Bot.HasInGraveyard(CardId.Longqishi) || Bot.HasInGraveyard(CardId.Longwushi) || Bot.HasInGraveyard(CardId.Longkuangshi)) && Bot.HasInExtra(CardId.Tiejiayanlong) && Bot.GetMonstersInMainZone().Count <= 3)
            {

                AI.SelectCard(CardId.Tiejiayanlong, CardId.Longqishi, CardId.Longwushi, CardId.Longkuangshi, CardId.Shuilong, CardId.Huolong, CardId.Anlong, CardId.Yuanlaowang, CardId.Hailong, CardId.Fenglong, CardId.Dilong, CardId.Guanglong);
            }
            else
            {
                if (!Bot.HasInGraveyard(CardId.Shuilong) && !Bot.HasInGraveyard(CardId.Huolong) && Bot.HasInGraveyard(CardId.Anlong))
                {
                    AI.SelectCard(CardId.Anlong, CardId.Yuanlaowang, CardId.Hailong, CardId.Fenglong, CardId.Dilong, CardId.Guanglong);
                    if (Bot.Hand.Count != 0)
                    {
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                    }
                    else
                    {
                        AI.SelectPosition(CardPosition.FaceUpDefence);
                    }
                }
                else
                {
                    if (Bot.GetMonstersInMainZone().Count <= 3)
                    {
                        AI.SelectCard(CardId.Tiejiayanlong,CardId.Shuilong, CardId.Huolong, CardId.Anlong, CardId.Yuanlaowang, CardId.Hailong, CardId.Fenglong,CardId.Dilong,CardId.Guanglong);
                    }
                    else
                    {
                        AI.SelectCard(CardId.Shuilong, CardId.Huolong, CardId.Anlong, CardId.Yuanlaowang, CardId.Hailong, CardId.Fenglong, CardId.Dilong, CardId.Guanglong);
                    }
                }
            }
            return true;
        }
        //幼龙
        private bool YoulongEffect()
        {
            AI.SelectCard(CardId.Huolong, CardId.Shuilong);
            return true;
        }
        //奥义
        private bool MaoyiEffect()
        {
            if (Bot.HasInSpellZone(CardId.Maoyi,true,true)) return false;
            return true;
        }
        //裁决
        private bool XcaijueEffect()
        {
            if (Bot.HasInSpellZone(CardId.Xcaijue, true, true)) return false;
            return true;
        }
        public int GetCountSetCodeTypeCardInZone(IEnumerable<ClientCard> cards, int setcode, CardType type)
        {
            return cards.Count(card => card != null && card.HasSetcode(setcode) && card.HasType(type));
        }
        //元老王
        private bool YuanlaowangEffect()
        {
  
            if (Duel.CurrentChain.Count > 0) return true;
            else
            {
                if (Bot.HasInMonstersZone(CardId.Youlong) && GetCountSetCodeTypeCardInZone(Bot.MonsterZone, 0x6551, CardType.Monster) == 1) return false;
                else if (Bot.GetMonstersInMainZone().Count <= 3)
                {
                    AI.SelectCard(CardId.Yuanlaowang, CardId.Shuilong, CardId.Huolong, CardId.Anlong, CardId.Dilong, CardId.Hailong, CardId.Fenglong, CardId.Guanglong, CardId.Longqishi, CardId.Longwushi);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Shuilong, CardId.Huolong, CardId.Anlong, CardId.Dilong, CardId.Hailong, CardId.Fenglong, CardId.Guanglong, CardId.Longqishi, CardId.Longwushi);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
               
            }
        }
    }
} 
