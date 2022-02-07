 
using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI; 

//  Connection.Close();投降用
namespace WindBot.Game.AI.Decks
{
    [Deck("Tenmu", "AI_Tenmu")]
    public class PayAsukaExecutor : DefaultExecutor
    {
        public class CardId
        { 
            //怪兽卡
            public const int Little_Bunny = 30300;
            public const int Nishida_Satono = 160550;
            public const int Teireida_Mai = 160500;
            public const int Nagae_Iku = 1230700;
            public const int Kaku_Seiga = 130202;
            public const int Iizunamaru_Megumu = 180500;
            public const int Suitokuin_Tenmu = 180599;
            public const int Shameimaru_Aya = 1230800;
            public const int Inubashiri_Momiji = 100300;
            public const int Toyosatomimi_no_Miko = 130403;
            public const int Kijin_Seija = 140700; 
            public const int AsukaLegend_EarthDragon_Suanni = 130906;  //sarvainai
            //魔法卡
            public const int Ten_Judge = 90512;
            public const int Devils_Citation = 50610;
            public const int E_Forgotten_Ritual = 1231610;
            public const int Dao_Fetal_Movement = 130210;
            public const int V_Prestige_of_Shoutoku = 130410;
            public const int H_Colors_of_Twelve_Levels = 130415;   
            public const int E_Star_Ritual_of_the_Godly_Winds = 1231611; //好家伙这么长的变量名 2021年12月25日23:55:28
            public const int Stars_Falling_Shinreibyou = 130000;
            public const int Emperor_Land_Rising_Sun = 130412; //以后变量名通通省略介词、连接词和定冠词，英语真的傻逼我真的无语子 2021年12月26日11:15:46 
            public const int Clear_Tranquil_Wind_Moon = 180510;
            //陷阱
            public const int M_Exspellees_Canaan = 100310;
            //屁股额外
            public const int Konpaku_Youmu = 70502;
        }


        bool FirstP = false; //灵摆的头次效果不康
        int PrepareToRitual = 0;
        int IsRitualStepRelease = 0;
        bool HasCache = false;
        bool DevilsCitationED = false;
        bool summoned = false;
        bool ShinreibyouED = true;
        bool SeigaEd = false;
        bool ForgottenRitualED = false;
        bool Advanced = false;
        bool MegumuED = false; //龙了
        public PayAsukaExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            //压制  
            AddExecutor(ExecutorType.Activate, CardId.Kijin_Seija, BasicEAndS);
            AddExecutor(ExecutorType.Activate, CardId.Nishida_Satono, BasicEAndS);
            AddExecutor(ExecutorType.Activate, CardId.Teireida_Mai, BasicEAndS);

            AddExecutor(ExecutorType.Activate, CardId.Inubashiri_Momiji, InubashiriEffect);
            AddExecutor(ExecutorType.Activate, CardId.Ten_Judge, Ten_JudgeEffect);
            AddExecutor(ExecutorType.Activate, CardId.Devils_Citation, Devils_CitationEffect);
            AddExecutor(ExecutorType.Activate, CardId.Little_Bunny, Little_BunnyEffect);
            AddExecutor(ExecutorType.Activate, CardId.M_Exspellees_Canaan, Exspellees_CanaanEffectA);

            AddExecutor(ExecutorType.Activate, CardId.Kaku_Seiga, Kaku_SeigaEffectB); //霍青娥打人看见过没？
            //展开 
            AddExecutor(ExecutorType.SpSummon, CardId.Nagae_Iku, BasicEAndS);
            //AddExecutor(ExecutorType.SpSummon, CardId.Konpaku_Youmu);
            AddExecutor(ExecutorType.Activate, CardId.Nagae_Iku, BasicEAndS);
            AddExecutor(ExecutorType.Activate, CardId.Stars_Falling_Shinreibyou, Stars_Falling_ShinreibyouEffectA);
            AddExecutor(ExecutorType.Activate, CardId.E_Forgotten_Ritual, E_Forgotten_RitualEffect);
            AddExecutor(ExecutorType.Activate, CardId.Dao_Fetal_Movement, BasicEAndS);
            AddExecutor(ExecutorType.Activate, CardId.Kaku_Seiga, Kaku_SeigaEffect);
            AddExecutor(ExecutorType.Activate, CardId.Iizunamaru_Megumu, Iizunamaru_MegumuEffectA);
            AddExecutor(ExecutorType.Activate, CardId.Iizunamaru_Megumu, Iizunamaru_MegumuEffectB);
            AddExecutor(ExecutorType.Summon, CardId.Inubashiri_Momiji, TenGuSummon);
            AddExecutor(ExecutorType.Summon, CardId.Shameimaru_Aya, TenGuSummon2);
            AddExecutor(ExecutorType.Summon, CardId.AsukaLegend_EarthDragon_Suanni, SuanniSummon);
            AddExecutor(ExecutorType.Activate, CardId.E_Forgotten_Ritual, E_Forgotten_RitualEffectB);
            AddExecutor(ExecutorType.Activate, CardId.E_Star_Ritual_of_the_Godly_Winds, E_Star_Ritual_of_the_Godly_WindsEffect);
            AddExecutor(ExecutorType.Activate, CardId.M_Exspellees_Canaan, Exspellees_CanaanEffectB); 

            AddExecutor(ExecutorType.Activate, CardId.Shameimaru_Aya, Shameimaru_AyaEffect);
            //仪式
            AddExecutor(ExecutorType.Activate, CardId.V_Prestige_of_Shoutoku, V_Prestige_of_ShoutokuEffect);
            AddExecutor(ExecutorType.Activate, CardId.H_Colors_of_Twelve_Levels, H_Colors_of_Twelve_LevelsEffect);
            AddExecutor(ExecutorType.Activate, CardId.Stars_Falling_Shinreibyou, Stars_Falling_ShinreibyouEffect);
            AddExecutor(ExecutorType.Activate, CardId.Suitokuin_Tenmu, Suitokuin_TenmuAyaEffect);
            AddExecutor(ExecutorType.Activate, CardId.Suitokuin_Tenmu, Suitokuin_TenmuMomijiEffect);

            //实在不行出阿龙
            AddExecutor(ExecutorType.Activate, CardId.Clear_Tranquil_Wind_Moon, Clear_Tranquil_Wind_MoonEffect); 

            AddExecutor(ExecutorType.SpellSet, CardId.M_Exspellees_Canaan);
        }


        //--------以下为基操类-------- 
        public override BattlePhaseAction OnSelectAttackTarget(ClientCard attacker, IList<ClientCard> defenders)
        {
            if (attacker.IsCode(CardId.Suitokuin_Tenmu))
            {
                for (int i = 0; i < defenders.Count; i++)
                {
                    ClientCard defender = defenders[i]; 
                    if (defender.HasPosition(CardPosition.Attack) && attacker.Attack > defender.Attack)
                    {
                        return AI.Attack(attacker, defender);
                    }
                }
            }
            return base.OnSelectAttackTarget(attacker, defenders);
        }
        public override bool OnSelectHand()
        {
            // go first
            return false;
        }
        public override int OnSelectOption(IList<long> options)
        {
            Logger.DebugWriteLine("进入了Option选择"); //不同类的通招通过这个来操控 
            if (Enemy.GetGraveyardMonsters().Count > 0)
            {
                for (int i = 0; i < options.Count; i = i + 1) { if (options[i] == Util.GetStringId(CardId.Kaku_Seiga, 1)) return i; }
            }
            for (int i = 0; i < options.Count; i = i + 1) { if (options[i] == Util.GetStringId(CardId.Kaku_Seiga, 2)) return i; }
            if (Bot.HasInMonstersZone(new[] { CardId.Nagae_Iku, CardId.Konpaku_Youmu, CardId.Nishida_Satono, CardId.Teireida_Mai })) {
                Advanced = true;
                return 0; 
            } 
            for (int i = 0; i < options.Count; i = i + 1)
            {
                if (options[i] == Util.GetStringId(CardId.Inubashiri_Momiji, 2)) return i;
                if (options[i] == Util.GetStringId(CardId.Shameimaru_Aya, 2)) return i;
                if (options[i] == Util.GetStringId(CardId.AsukaLegend_EarthDragon_Suanni, 0)) return i;
            }
            return options.Count == 2 ? 1 : 0;
        }
        public override bool OnSelectYesNo(long desc)
        {
            if (desc == Util.GetStringId(CardId.Nishida_Satono, 1) || desc == Util.GetStringId(CardId.Teireida_Mai, 1))
            {
                if (Duel.Player == 1 && Bot.HasInHand(CardId.Nagae_Iku) && ((Bot.GetMonsterCount() + Bot.GetSpellCount()) == 0)) return true;
                return false;
            }
            if (desc == Util.GetStringId(CardId.Emperor_Land_Rising_Sun, 1)) { return true; }
            if (desc == Util.GetStringId(CardId.Clear_Tranquil_Wind_Moon, 2)) { return true; }
            return base.OnSelectYesNo(desc);
        }
        public override IList<ClientCard> OnSelectCard(IList<ClientCard> cards, int min, int max, long hint, bool cancelable)
        {
            if (HasCache) { HasCache = false; return null; }
            if (PrepareToRitual > 0)
            { 
                foreach (ClientCard card in cards)
                {
                    if (card.IsCode(PrepareToRitual))
                    {
                        Logger.DebugWriteLine("仪式测试-要准备仪式召唤的怪兽是" + PrepareToRitual);
                        IsRitualStepRelease = PrepareToRitual;
                        PrepareToRitual = 0;
                        return new List<ClientCard>(new[] { card });
                    }
                }
            }
            Logger.DebugWriteLine("hint是  " + hint);
            if (hint == Util.GetStringId(CardId.Dao_Fetal_Movement, 0))
            {
                return Dao_Fetal_Movement_Search(cards);
            } 
            if (hint == Util.GetStringId(CardId.Iizunamaru_Megumu, 6) || hint == Util.GetStringId(CardId.Shameimaru_Aya, 5))
            {
                return Tengu_Search(cards);
            }
            if (hint == Util.GetStringId(CardId.Kaku_Seiga, 5))
            { 
                List<ClientCard> MlistP = new List<ClientCard>();
                foreach (ClientCard card in cards)
                {
                    MlistP.Add(card);
                }
                quickSort3(0, MlistP.Count, MlistP); 
                
                return new List<ClientCard>(new[] { MlistP[0] });
            }
            if (hint == 505)  //请选择要返回手卡的卡
            {
                return Shameimaru_Aya_Select(cards);
            }
            if (hint == Util.GetStringId(CardId.Toyosatomimi_no_Miko, 0))
            {
                foreach (ClientCard card in cards) { if (card.IsCode(CardId.Suitokuin_Tenmu)) { return new List<ClientCard>(new[] { card }); } }
                foreach (ClientCard card in cards) { if (card.IsCode(CardId.Iizunamaru_Megumu)) { return new List<ClientCard>(new[] { card }); } }
            }
            if (hint == Util.GetStringId(CardId.Stars_Falling_Shinreibyou, 2))
            {
                return Shinreibyou_Select(cards);
            }
            return base.OnSelectCard(cards, min, max, hint, cancelable);
        }
        public override IList<ClientCard> OnSelectRitualTribute(IList<ClientCard> cards, int sum, int min, int max)
        { 
            if (IsRitualStepRelease > 0)
            {
                int j = 0;
                if ((IsRitualStepRelease == CardId.Suitokuin_Tenmu) || (IsRitualStepRelease == CardId.Iizunamaru_Megumu)) 
                {
                    j = CaCulator(cards, 10);
                    IsRitualStepRelease = 0;

                }
                if ((IsRitualStepRelease == CardId.Kaku_Seiga) || (IsRitualStepRelease == CardId.Toyosatomimi_no_Miko))
                {
                    j = CaCulator(cards, 8);
                    IsRitualStepRelease = 0;

                }
                PRINT("场上所有合法的卡片是", cards);
                Logger.DebugWriteLine("场上最小的一组等级和是  " + j);
                List<ClientCard> cardsX = CaCulator2(cards, j);
                PRINT("得到的一组合法的仪式素材是", cardsX);
                return cardsX;
            }
            return null;
        } 
        public override void OnNewTurn()
        {
            DevilsCitationED = false;
            ForgottenRitualED = false;
            summoned = false;
            ShinreibyouED = false;
            Advanced = false;
            MegumuED = false;
            SeigaEd = false;
            base.OnNewTurn();
        } 
        public override void OnChainEnd()
        {
            PrepareToRitual = 0;
            IsRitualStepRelease = 0;
            HasCache = false;
            base.OnChainEnd();
        }

        //--------以上为基操类--------   
        private bool Shameimaru_AyaEffect()
        {
            if (DontAct()) return false;
            if (Enemy.GetMonsters().Count + Enemy.GetSpellCount() > 0) return true;
            return false;
        }
        private bool Clear_Tranquil_Wind_MoonEffect()
        {
            if (DontAct()) return false;
            if (!Advanced) return false;
            return true;
        }
        private bool BasicEAndS()
        {
            if (DontAct()) return false; 
            return true;
        }
        private bool InubashiriEffect()
        {
            if (DontAct()) return false;
            if (ActivateDescription == -1 || ActivateDescription == Util.GetStringId(CardId.Iizunamaru_Megumu, 2))
            {
                if ((Duel.LastChainPlayer == 1) && (Duel.CurrentChain.Count > 0))
                {
                    if (DontCounter(Duel.CurrentChain[Duel.CurrentChain.Count - 1])) return false;
                    return true;
                }
                return false;
            }
            return false;
        }
        private bool Exspellees_CanaanEffectA()
        {
            if (DontAct()) return false;
            if (Card.Location == CardLocation.Hand) return false;
            return true;
        }
        private bool Exspellees_CanaanEffectB()
        {
            if (DontAct()) return false;
            if (!Bot.HasInHandOrHasInMonstersZone(CardId.Suitokuin_Tenmu) && !summoned)
            {
                return true;
            }
            return false;
        }
        private bool Devils_CitationEffect()
        {
            if (DontAct()) return false;
            if (DevilsCitationED) return false;
            DevilsCitationED = true;
            return true;
        }
        private bool Iizunamaru_MegumuEffectA()
        {
            if (DontAct()) return false;
            if (Card.Location == CardLocation.Hand) { MegumuED = true; return true; }
            return false;
        }
        private bool Iizunamaru_MegumuEffectB()
        {
            if (DontAct()) return false;
            if (Card.Location == CardLocation.Hand) return false; 
            if (ActivateDescription == Util.GetStringId(CardId.Iizunamaru_Megumu, 1))
            { 
                foreach (ClientCard grave_monster in Bot.GetGraveyardMonsters())
                {
                    if (grave_monster.Id == CardId.Inubashiri_Momiji) { AI.SelectCard(grave_monster); return true; }
                }
                foreach (ClientCard grave_monster in Bot.GetGraveyardMonsters())
                {
                    if (grave_monster.Id == CardId.Shameimaru_Aya) { AI.SelectCard(grave_monster); return true; }
                }
                AI.SelectCard(new[] {
                    CardId.Inubashiri_Momiji,
                    CardId.Shameimaru_Aya,
                });
                return true;
            }
            if (ActivateDescription == -1 || ActivateDescription == Util.GetStringId(CardId.Iizunamaru_Megumu, 2))
            {
                if ((Duel.LastChainPlayer == 1) && (Duel.CurrentChain.Count > 0))
                {
                    if (DontCounter(Duel.CurrentChain[Duel.CurrentChain.Count - 1])) return false;
                    return true;
                }
                return false;
            }
            return false;
        }
        private bool SuanniSummon()
        {
            if (DontAct()) return false;
            if (Timian()) return true;
            List<ClientCard> cardsX = Enemy.GetMonsters(); 
            foreach (ClientCard card in cardsX)
            {
                if (GetCardAttractValue(card, false, false) > 4) { summoned = true; return true; }
            }
            
            return false;
        }
        private bool TenGuSummon()
        {
            if (DontAct()) return false;
            if (Bot.HasInHand(CardId.E_Forgotten_Ritual) && !ForgottenRitualED)
            {
                AI.SelectCard(new[] {
                    CardId.Shameimaru_Aya,
                    CardId.Inubashiri_Momiji,
                });
            }
            else
            {
                AI.SelectCard(new[] {
                    CardId.Suitokuin_Tenmu,
                    CardId.Iizunamaru_Megumu,
                });
            }
            summoned = true;
            return true;
        }
        private bool TenGuSummon2()
        {
            if (DontAct()) return false; 
            if (Duel.Turn == 1 && !MegumuED && GetCountInDeck(CardId.Clear_Tranquil_Wind_Moon, 1) > 0)
            {
                AI.SelectCard(new[] {
                    CardId.Iizunamaru_Megumu,
                    CardId.Suitokuin_Tenmu,
                });
                return true;
            }
            AI.SelectCard(new[] {
                CardId.Suitokuin_Tenmu,
                CardId.Iizunamaru_Megumu,
            }); 
            summoned = true;
            return true;
        }
        private bool Stars_Falling_ShinreibyouEffectA()
        {
            if (DontAct()) return false;
            if (Bot.HasInSpellZone(CardId.Stars_Falling_Shinreibyou) && !ShinreibyouED) return false;
            if(Card.Location == CardLocation.Hand) { return true; }
            return false;
        }
        private bool Stars_Falling_ShinreibyouEffect()
        {
            if (DontAct()) return false;
            if (Bot.HasInHand(CardId.Kaku_Seiga) && Bot.Hand.Count == 1) return false;
            if (!Bot.HasInHand(CardId.Suitokuin_Tenmu))
            {
                if (Bot.HasInHand(CardId.Kaku_Seiga) && Duel.Turn == 1 && !SeigaEd)
                {
                    if (GetLevelCountInOpGrave() > 7 && GetLevelCountInOpGrave(true) > 9 && GetCountInDeck(CardId.V_Prestige_of_Shoutoku, 1) > 0)
                        { AI.SelectCard(CardId.V_Prestige_of_Shoutoku); PrepareToRitual = CardId.Kaku_Seiga; HasCache = true; ShinreibyouED = true; return true; }
                    if (GetCountInDeck(CardId.H_Colors_of_Twelve_Levels, 2) > 0)
                        { AI.SelectCard(CardId.H_Colors_of_Twelve_Levels); PrepareToRitual = CardId.Kaku_Seiga; HasCache = true; ShinreibyouED = true; return true; }
                    AI.SelectCard(new[] {
                        CardId.H_Colors_of_Twelve_Levels,
                        CardId.V_Prestige_of_Shoutoku,
                    });
                    PrepareToRitual = CardId.Kaku_Seiga;
                    HasCache = true;
                    ShinreibyouED = true;
                    return true;
                }
                if (Bot.HasInHand(CardId.Toyosatomimi_no_Miko) && Duel.Turn == 1) 
                {
                    if (GetLevelCountInOpGrave() > 7 && GetLevelCountInOpGrave(true) > 9 && GetCountInDeck(CardId.V_Prestige_of_Shoutoku, 1) > 0)
                        { AI.SelectCard(CardId.V_Prestige_of_Shoutoku); PrepareToRitual = CardId.Toyosatomimi_no_Miko; HasCache = true; ShinreibyouED = true; return true; }
                    if (GetCountInDeck(CardId.H_Colors_of_Twelve_Levels, 2) > 0)
                        { AI.SelectCard(CardId.H_Colors_of_Twelve_Levels); PrepareToRitual = CardId.Toyosatomimi_no_Miko; HasCache = true; ShinreibyouED = true; return true; }
                    AI.SelectCard(new[] {
                        CardId.H_Colors_of_Twelve_Levels,
                        CardId.V_Prestige_of_Shoutoku,
                    });
                    PrepareToRitual = CardId.Toyosatomimi_no_Miko;
                    HasCache = true;
                    ShinreibyouED = true;
                    return true;
                }
                if (GetCountInDeck(CardId.E_Star_Ritual_of_the_Godly_Winds, 1) > 0)
                {
                    AI.SelectCard(CardId.E_Star_Ritual_of_the_Godly_Winds);
                    AI.SelectNextCard(new[] {
                        CardId.E_Forgotten_Ritual,
                    });
                    AI.SelectThirdCard(new[] {
                        CardId.Suitokuin_Tenmu,
                        CardId.Iizunamaru_Megumu,
                    });
                    HasCache = true;
                    ShinreibyouED = true;
                    return true;
                }
                if (GetCountInDeck(CardId.E_Forgotten_Ritual, 2) > 0)
                    { AI.SelectCard(CardId.E_Forgotten_Ritual); HasCache = true; ShinreibyouED = true; return true; }
            }
            if (Bot.HasInHand(CardId.Suitokuin_Tenmu) && Duel.Turn > 1)
            {
                if (GetLevelCountInOpGrave() > 7 && GetLevelCountInOpGrave(true) > 9)
                {
                    AI.SelectCard(new[] {
                        CardId.V_Prestige_of_Shoutoku,
                        CardId.H_Colors_of_Twelve_Levels,
                    });
                }
                else
                {
                    AI.SelectCard(new[] {
                        CardId.H_Colors_of_Twelve_Levels,
                        CardId.V_Prestige_of_Shoutoku,
                    });
                }
                PrepareToRitual = CardId.Suitokuin_Tenmu;
                HasCache = true;
                ShinreibyouED = true;
                return true;
            }
            if (GetCountInDeck(CardId.Clear_Tranquil_Wind_Moon, 1) > 0 && GetCountInDeck(CardId.Iizunamaru_Megumu, 2) > 0
                && GetCountInDeck(CardId.E_Star_Ritual_of_the_Godly_Winds, 1) > 0)
            { 
                AI.SelectCard(CardId.E_Star_Ritual_of_the_Godly_Winds);
                AI.SelectNextCard(new[] {
                    CardId.E_Forgotten_Ritual,
                });
                AI.SelectThirdCard(new[] {
                    CardId.Suitokuin_Tenmu,
                    CardId.Iizunamaru_Megumu,
                });
                HasCache = true; 
                ShinreibyouED = true; 
                return true; 
            }
            return false;
        }
        private bool E_Star_Ritual_of_the_Godly_WindsEffect()
        {
            if (DontAct()) return false;
            if (!Bot.HasInHandOrHasInMonstersZone(CardId.Suitokuin_Tenmu))
            { 
                if ((Duel.Turn == 1 && Bot.HasInHand(CardId.E_Forgotten_Ritual) && GetCountInDeck(CardId.E_Forgotten_Ritual, 2) > 0)
                    || Bot.GetCountCardInZone(Bot.Hand, CardId.E_Forgotten_Ritual) == 2)
                {
                    AI.SelectCard(CardId.E_Forgotten_Ritual);
                }
                else
                { 
                    AI.SelectCard(new[] {
                        CardId.Nagae_Iku,
                        CardId.Iizunamaru_Megumu,
                        CardId.Devils_Citation,
                        CardId.Stars_Falling_Shinreibyou,
                        CardId.Shameimaru_Aya,
                        CardId.M_Exspellees_Canaan,
                        CardId.AsukaLegend_EarthDragon_Suanni, 
                    }); 
                }
                AI.SelectNextCard(new[] {
                    CardId.E_Forgotten_Ritual,
                }); 
                if ((GetCountInDeck(CardId.Shameimaru_Aya, 1) + GetCountInDeck(CardId.Inubashiri_Momiji) > 1) && !summoned)
                {
                    AI.SelectThirdCard(new[] {
                        CardId.Shameimaru_Aya,
                        CardId.Inubashiri_Momiji,
                    });
                }
                else
                {
                    AI.SelectThirdCard(new[] {
                        CardId.Suitokuin_Tenmu,
                        CardId.Iizunamaru_Megumu,
                    });
                }
                return true;
            }
            return false;
        }
        private bool V_Prestige_of_ShoutokuEffect() //圣德威望
        {
            if (DontAct()) return false;
            if (Bot.HasInHand(CardId.Kaku_Seiga) && (Duel.Turn == 1)
                && ((GetLevelCountInOpGrave() > 7 && GetLevelCountInOpGrave(true) > 9) || Bot.HasInHand(CardId.Toyosatomimi_no_Miko)))
            {
                AI.SelectCard(CardId.Kaku_Seiga);
                PrepareToRitual = CardId.Kaku_Seiga;
                return true;
            }
            if (Bot.HasInHand(CardId.Toyosatomimi_no_Miko) && (Duel.Turn == 1) && (GetLevelCountInOpGrave() > 7 && GetLevelCountInOpGrave(true) > 9))
            {
                AI.SelectCard(CardId.Toyosatomimi_no_Miko);
                PrepareToRitual = CardId.Toyosatomimi_no_Miko;
                return true;
            }
            if (!ShinreibyouED && Bot.HasInSpellZone(CardId.Stars_Falling_Shinreibyou) && GetCountInDeck(CardId.Suitokuin_Tenmu) > 0) return false;
            if (Bot.HasInHand(CardId.Suitokuin_Tenmu) && GetLevelCountInOpGrave() > 7 && GetLevelCountInOpGrave(true) > 9)
            {
                AI.SelectCard(CardId.Suitokuin_Tenmu);
                PrepareToRitual = CardId.Suitokuin_Tenmu;
                return true;
            }
            if (Bot.HasInHand(CardId.Kaku_Seiga) && ((GetLevelCountInOpGrave() > 7 && GetLevelCountInOpGrave(true) > 9) || Bot.HasInHand(CardId.Toyosatomimi_no_Miko)))
            {
                AI.SelectCard(CardId.Kaku_Seiga);
                PrepareToRitual = CardId.Kaku_Seiga;
                return true;
            }
            return false;
        }

        private bool Little_BunnyEffect()  //小兔姬
        {
            if (DontAct()) return false;
            if ((Duel.LastChainPlayer == 1) && (Duel.CurrentChain.Count > 0))
            { 
                if (DontCounter(Util.GetLastChainCard())) return false;
                return true;
            }
            if (Card.Location == CardLocation.SpellZone)
            {
                return true;
            }
            return false;
        }
        private bool H_Colors_of_Twelve_LevelsEffect() //十二阶之冠位
        {
            if (DontAct()) return false;
            if (Bot.HasInHand(CardId.Kaku_Seiga) && Duel.Turn == 1) { AI.SelectCard(CardId.Kaku_Seiga); return true; }
            if (Bot.HasInHand(CardId.Toyosatomimi_no_Miko) && Duel.Turn == 1) { AI.SelectCard(CardId.Toyosatomimi_no_Miko); return true; }
            if (!ShinreibyouED && Bot.HasInSpellZone(CardId.Stars_Falling_Shinreibyou) && GetCountInDeck(CardId.Suitokuin_Tenmu) > 0) return false;
            if (Bot.HasInHand(CardId.Suitokuin_Tenmu)) { AI.SelectCard(CardId.Suitokuin_Tenmu); return true; }
            if (Bot.HasInHand(CardId.Kaku_Seiga)) { AI.SelectCard(CardId.Kaku_Seiga); return true; }
            if (Bot.HasInHand(CardId.Toyosatomimi_no_Miko)) { AI.SelectCard(CardId.Toyosatomimi_no_Miko); return true; }
            return false;
        }
        private bool E_Forgotten_RitualEffect() //秘術「忘却の祭儀」
        {
            if (DontAct()) return false;
            if (ActivateDescription == Util.GetStringId(CardId.E_Forgotten_Ritual, 0))
            {
                if (Bot.HasInHand(CardId.E_Star_Ritual_of_the_Godly_Winds) && GetCountInDeck(CardId.E_Forgotten_Ritual) > 0) return false;
                if (Bot.HasInMonstersZone(new[] { CardId.Nagae_Iku, CardId.Inubashiri_Momiji, CardId.Nishida_Satono, CardId.Teireida_Mai, CardId.Shameimaru_Aya })
                    && (Bot.HasInHand(CardId.Shameimaru_Aya) || Bot.HasInHand(CardId.Inubashiri_Momiji)) && Duel.Turn == 1) return false;
                if (GetCountInDeck(CardId.Iizunamaru_Megumu, 2) > 0 && GetCountInDeck(CardId.Clear_Tranquil_Wind_Moon, 1) > 0
                    && (Bot.HasInHand(CardId.Inubashiri_Momiji) || Bot.HasInHand(CardId.Shameimaru_Aya))) return false;
                if (Duel.Turn == 1 && !summoned && Bot.HasInHand(CardId.Clear_Tranquil_Wind_Moon) && Bot.HasInGraveyard(CardId.Iizunamaru_Megumu)
                        && (GetCountInDeck(CardId.Shameimaru_Aya, 1) > 0 || GetCountInDeck(CardId.Inubashiri_Momiji) > 0))
                {
                    AI.SelectCard(new[] {
                        CardId.Inubashiri_Momiji,
                        CardId.Shameimaru_Aya
                    });
                    ForgottenRitualED = true;
                    return true;
                }
                if (Duel.Turn == 1 && !summoned && (GetCountInDeck(CardId.Shameimaru_Aya, 1) > 0))
                    { AI.SelectCard(CardId.Shameimaru_Aya); ForgottenRitualED = true; return true; }
                if (GetCountInDeck(CardId.Suitokuin_Tenmu, 1) == 0 && GetCountInDeck(CardId.Shameimaru_Aya, 1) == 0 && GetCountInDeck(CardId.Iizunamaru_Megumu, 1) == 0
                     && GetCountInDeck(CardId.Inubashiri_Momiji) < 3) return false;
                if (Bot.HasInHand(CardId.Suitokuin_Tenmu)) return false;
                if (Card.Location == CardLocation.Hand && (ActivateDescription == Util.GetStringId(CardId.E_Forgotten_Ritual, 0) || ActivateDescription == -1))
                {
                    AI.SelectCard(new[] {
                        CardId.Suitokuin_Tenmu,
                        CardId.Shameimaru_Aya,
                        CardId.Inubashiri_Momiji,
                    });
                    ForgottenRitualED = true;
                    return true;
                }
            }
            return false;
        }
        private bool E_Forgotten_RitualEffectB() //秘術「忘却の祭儀」
        {
            if (DontAct()) return false;
            if (ActivateDescription == Util.GetStringId(CardId.E_Forgotten_Ritual, 1))
            { 
                if (GetCountInDeck(CardId.Iizunamaru_Megumu, 2) > 0 && GetCountInDeck(CardId.Clear_Tranquil_Wind_Moon, 1) > 0)
                {
                    return true;
                }
            }
            return false;
        }
        private bool Kaku_SeigaEffectB()
        {
            if (DontAct()) return false;
            if (Card.Location == CardLocation.Hand) return false;
            if (ActivateDescription == -1)
            {
                List<ClientCard> cardsX = Enemy.GetMonsters();
                quickSort3(0, cardsX.Count - 1, cardsX);
                PRINT("按攻击力从大到小的排序结果", cardsX);
                foreach (ClientCard card in cardsX)
                {
                    if (card.IsFaceup() && !card.IsDisabled()) { AI.SelectCard(card); return true; }
                }
                List<ClientCard> cardsY = Enemy.GetSpells();
                foreach (ClientCard card in cardsY)
                {
                    if (card.IsFaceup() && !card.IsDisabled() && card.HasType(CardType.Continuous)) { AI.SelectCard(card); return true; }
                }
                if (Enemy.GetFieldSpellCard() != null && Enemy.GetFieldSpellCard().IsFaceup() 
                    && !Enemy.GetFieldSpellCard().IsDisabled()) { AI.SelectCard(Enemy.GetFieldSpellCard()); return true; }
                foreach (ClientCard card in cardsY)
                {
                    if (card.IsFaceup() && !card.IsDisabled()) { AI.SelectCard(card); return true; }
                }
                return false;
            }
            if (ActivateDescription == Util.GetStringId(CardId.Kaku_Seiga, 3))
            {
                SeigaEd = true;
                return true;
            } 
            return false;
        }
        private bool Kaku_SeigaEffect() //霍青娥  
        {
            if (DontAct()) return false;
            if (Card.Location == CardLocation.Hand)
            {
                if (SeigaEd) return false;
                if (IfRitual() && Duel.Turn == 1) return false;
                if (!Bot.HasInSpellZone(CardId.Stars_Falling_Shinreibyou) && GetCountInDeck(CardId.Toyosatomimi_no_Miko, 1) > 0)
                {
                    AI.SelectCard(CardId.Stars_Falling_Shinreibyou);
                    return true;
                }
                if (Bot.HasInHand(CardId.Suitokuin_Tenmu) || Bot.HasInHand(CardId.E_Star_Ritual_of_the_Godly_Winds))
                {
                    IList<int> ListA = new[] {
                        CardId.H_Colors_of_Twelve_Levels,
                        CardId.V_Prestige_of_Shoutoku,
                        CardId.Emperor_Land_Rising_Sun,
                        CardId.Stars_Falling_Shinreibyou
                    };
                    if(GetCountInDeck(CardId.Toyosatomimi_no_Miko, 1) == 1) {
                        ListA = new[] {
                        CardId.Stars_Falling_Shinreibyou,
                        CardId.H_Colors_of_Twelve_Levels,
                        CardId.V_Prestige_of_Shoutoku,
                        CardId.Emperor_Land_Rising_Sun
                        };
                    } 
                    AI.SelectCard(ListA);
                    return true;
                }
                AI.SelectCard(new[] {
                        CardId.Dao_Fetal_Movement, 
                    });
                return true;
            }
            return false;
        }
        private List<ClientCard> Dao_Fetal_Movement_Search(IList<ClientCard> cards) //道胎动的检索
        {
            bool PPP = (Bot.HasInHand(CardId.Shameimaru_Aya) || Bot.HasInHand(CardId.Inubashiri_Momiji)) && GetCountInDeck(CardId.Suitokuin_Tenmu, 1) > 0
                && (!summoned || (Bot.HasInHand(CardId.E_Forgotten_Ritual) && !ForgottenRitualED));
            if (Bot.HasInHand(CardId.Suitokuin_Tenmu) || Bot.HasInHand(CardId.E_Star_Ritual_of_the_Godly_Winds) || PPP
                || (Bot.HasInHand(CardId.Kaku_Seiga) || Bot.HasInHand(CardId.Toyosatomimi_no_Miko) && (Duel.Turn == 1)))
            {
                if ((GetLevelCountInOpGrave() > 7 && GetLevelCountInOpGrave(true) > 9)
                    || (Bot.HasInHand(CardId.Kaku_Seiga) && Bot.HasInHand(CardId.Toyosatomimi_no_Miko) && (Duel.Turn == 1)))
                {
                    ClientCard CardX = CheckList(cards, new[] {
                            CardId.V_Prestige_of_Shoutoku,
                            CardId.H_Colors_of_Twelve_Levels,
                            CardId.Emperor_Land_Rising_Sun,
                            CardId.E_Star_Ritual_of_the_Godly_Winds,
                            CardId.E_Forgotten_Ritual
                        });
                    if (CardX != null) { return new List<ClientCard>(new[] { CardX }); }
                }
                else
                {
                    ClientCard CardX = CheckList(cards, new[] {
                            CardId.H_Colors_of_Twelve_Levels,
                            CardId.V_Prestige_of_Shoutoku,
                            CardId.Emperor_Land_Rising_Sun,
                            CardId.E_Star_Ritual_of_the_Godly_Winds,
                            CardId.E_Forgotten_Ritual
                        });
                    if (CardX != null) { return new List<ClientCard>(new[] { CardX }); }
                }
            }
            //if (Bot.HasInSpellZone(CardId.Stars_Falling_Shinreibyou))
            //{
                ClientCard CardY = CheckList(cards, new[] {
                            CardId.E_Forgotten_Ritual,
                            CardId.E_Star_Ritual_of_the_Godly_Winds, 
                        });
                if (CardY != null) { return new List<ClientCard>(new[] { CardY }); }
            //}
            return null;
        } 
        private bool Suitokuin_TenmuMomijiEffect() //那个人
        {
            if (DontAct()) return false;
            if (ActivateDescription == Util.GetStringId(CardId.Iizunamaru_Megumu, 2))
            {
                if ((Duel.LastChainPlayer == 1) && (Duel.CurrentChain.Count > 0))
                {
                    if (DontCounter(Duel.CurrentChain[Duel.CurrentChain.Count - 1])) return false;
                    return true;
                }
                return false;
            }
            if (ActivateDescription == Util.GetStringId(CardId.Suitokuin_Tenmu, 0))
            {
                HasCache = true;
                return true;
            }
            return false;
        }
        private bool Suitokuin_TenmuAyaEffect() //那个人
        {
            if (DontAct()) return false;
            if (ActivateDescription == Util.GetStringId(CardId.Suitokuin_Tenmu, 2) && Timian())
            {
                HasCache = true;
                return true;
            }
            return false;
        }
        private List<ClientCard> Shameimaru_Aya_Select(IList<ClientCard> cards)
        {
            if (Timian())
            {
                Logger.DebugWriteLine("进入了弹手测试");
                foreach (ClientCard card in cards)
                {
                    if (card.HasPosition(CardPosition.Defence) && card.Controller == 1) { return new List<ClientCard>(new[] { card }); }
                }
            }
            quickSort2(0, cards.Count - 1, cards, true, false);
            PRINT("按嘲讽从大到小的排序结果", cards);
            return new List<ClientCard>(new[] { cards[0] });
        }
        private List<ClientCard> Tengu_Search(IList<ClientCard> cards)
        {
            if (Duel.Turn == 1 && !MegumuED && GetCountInDeck(CardId.Clear_Tranquil_Wind_Moon, 1) > 0)
            {
                foreach (ClientCard card in cards) { if (card.IsCode(CardId.Iizunamaru_Megumu)) { return new List<ClientCard>(new[] { card }); } }
                foreach (ClientCard card in cards) { if (card.IsCode(CardId.Suitokuin_Tenmu)) { return new List<ClientCard>(new[] { card }); } }
            } 
            foreach (ClientCard card in cards) { if (card.IsCode(CardId.Suitokuin_Tenmu)) { return new List<ClientCard>(new[] { card }); } }
            foreach (ClientCard card in cards) { if (card.IsCode(CardId.Iizunamaru_Megumu)) { return new List<ClientCard>(new[] { card }); } }
            return new List<ClientCard>(new[] { cards[0] });
        }
        private List<ClientCard> Shinreibyou_Select(IList<ClientCard> cards)
        { 
            foreach (ClientCard card in cards) { if (card.IsCode(CardId.Nagae_Iku)) { return new List<ClientCard>(new[] { card }); } }
            foreach (ClientCard card in cards) { if (card.IsCode(CardId.Devils_Citation)) { return new List<ClientCard>(new[] { card }); } }
            foreach (ClientCard card in cards) { if (card.IsCode(CardId.Stars_Falling_Shinreibyou)) { return new List<ClientCard>(new[] { card }); } }
            foreach (ClientCard card in cards) { if (card.IsCode(CardId.Inubashiri_Momiji)) { return new List<ClientCard>(new[] { card }); } }
            foreach (ClientCard card in cards) { if (card.IsCode(CardId.Shameimaru_Aya)) { return new List<ClientCard>(new[] { card }); } }
            foreach (ClientCard card in cards) { if (card.IsCode(CardId.M_Exspellees_Canaan)) { return new List<ClientCard>(new[] { card }); } }
            foreach (ClientCard card in cards) { if (card.IsCode(CardId.AsukaLegend_EarthDragon_Suanni)) { return new List<ClientCard>(new[] { card }); } }
            foreach (ClientCard card in cards) { if (card.IsCode(CardId.Iizunamaru_Megumu)) { return new List<ClientCard>(new[] { card }); } }
            foreach (ClientCard card in cards) { if (card.IsCode(CardId.Ten_Judge)) { return new List<ClientCard>(new[] { card }); } }
            foreach (ClientCard card in cards) { if (card.IsCode(CardId.V_Prestige_of_Shoutoku)) { return new List<ClientCard>(new[] { card }); } }
            foreach (ClientCard card in cards) { if (card.IsCode(CardId.H_Colors_of_Twelve_Levels)) { return new List<ClientCard>(new[] { card }); } }
            foreach (ClientCard card in cards) { if (card.IsCode(CardId.M_Exspellees_Canaan)) { return new List<ClientCard>(new[] { card }); } }
            foreach (ClientCard card in cards) { if (card.IsCode(CardId.Dao_Fetal_Movement)) { return new List<ClientCard>(new[] { card }); } }
            return null;
        }
        //----------========  泛用类效果  =========-----------------  
        private bool IfRitual()
        {
            if ((Bot.HasInSpellZone(CardId.Stars_Falling_Shinreibyou) && !ShinreibyouED) || Bot.HasInHand(CardId.H_Colors_of_Twelve_Levels)) return true;
            if (Bot.HasInHand(CardId.V_Prestige_of_Shoutoku) && GetLevelCountInOpGrave() > 7 && GetLevelCountInOpGrave(true) > 9) return true;  
            return false;
        }
        private bool Timian() //他要是不体面，你就帮他体面
        {
            bool ShouldTimian = true;
            if (Duel.Turn == 1) return false;
            if (Enemy.GetMonsterCount() > 0)
            {
                List<ClientCard> Mosters = Enemy.GetMonsters();
                foreach (ClientCard monster in Mosters)
                {
                    if (monster.HasPosition(CardPosition.Attack)) { ShouldTimian = false; }
                }
            }
            return ShouldTimian;
        } 
        private ClientCard CheckList(IList<ClientCard> cardsA, IList<int> cardsB) // 找到表A里面和表B相同的元素，返回第一个
        {
            foreach (int cardBId in cardsB)
            {
                foreach (ClientCard cardA in cardsA)
                {
                    if (cardA.IsCode(cardBId))
                    {
                        return cardA;
                    }
                }
            }
            return null;
        }
        private int GetLevelCountInOpGrave(bool IncSelf = false) //统计对面墓地里怪兽的等级合计值,填true再加上自己墓地里的
        {
            int count = 0;
            List<ClientCard> Mosters = Enemy.GetGraveyardMonsters();
            foreach (ClientCard grave_monster in Mosters)
            {
                count = count + grave_monster.Level;
            }
            if (IncSelf)
            {
                List<ClientCard> Mosters2 = Bot.GetGraveyardMonsters();
                foreach (ClientCard grave_monster in Mosters2)
                {
                    count = count + grave_monster.Level;
                }
            }
            return count;

        }
        private bool Ten_JudgeEffect() //十王审判
        {
            if (Bot.LifePoints < 1501) return false;
            if ((Duel.LastChainPlayer == 1) && (Duel.CurrentChain.Count > 0))
            {
                if (DontCounter(Duel.CurrentChain[Duel.CurrentChain.Count - 1])) return false;
                return true;
            }
            IList<ClientCard> LSC = Duel.LastSummonedCards;
            if (LSC.Count < 1) return false;
            if (LSC[0].Controller != 0) return true;
            return false;
        }
        private bool IsCardlistContains(List<ClientCard> cardsB, ClientCard CardX) 
        {  
            foreach (ClientCard cardAAA in cardsB)
            {
                if (cardAAA.Equals(CardX)) return true;
            } 
            return false;
        }
        private int GetCountInDeck(int cardId, int count = 3) //对于一卡名，统计其在卡组中同名卡数量
        {
            count = count - Bot.GetCountCardInZone(Bot.GetMonsters(), cardId) - Bot.GetCountCardInZone(Bot.GetSpells(), cardId);
            count = count - Bot.GetCountCardInZone(Bot.Banished, cardId) - Bot.GetCountCardInZone(Bot.Graveyard, cardId);
            count = count - Bot.GetCountCardInZone(Bot.Hand, cardId) - Bot.GetCountCardInZone(Bot.ExtraDeck, cardId);
            count = count - GetCountInOverLay(cardId);
            if (count < 0) count = 0;
            return count;
        }

        private int GetCountInOverLay(int cardId, int count = 0) //对于一卡名，统计其在叠光区域中同名卡数量
        {
            List<ClientCard> Mosters = Bot.GetMonsters();
            foreach (ClientCard extra_monster in Mosters)
                if (extra_monster.HasType(CardType.Xyz) && extra_monster.HasXyzMaterial(0, cardId))
                    count += 1;
            return count;
        }
        private ClientCard GetHighestAttractValueCard(List<ClientCard> material_list)
        { 
            ClientCard maxCard = new ClientCard(0, CardLocation.Deck, -1,0);
            foreach (ClientCard cardA in material_list)
            {
                if (GetCardAttractValue(cardA) > GetCardAttractValue(maxCard)) { maxCard = cardA; }
            }
            return maxCard;
        }
        private List<ClientCard> GetEnemyFieldGroup(bool req_not_invincible = true, bool req_face_up = true)
        {
            List<ClientCard> material_list = Enemy.GetMonsters();
            foreach (ClientCard monster in Enemy.GetMonsters())
            {
                if (!(req_not_invincible && IsImmuneEffec(monster)) && !(req_face_up && monster.IsFaceup())) { material_list.Add(monster); }
            }
            foreach (ClientCard spell in Enemy.GetSpells())
            {
                if (!(req_not_invincible && IsImmuneEffec(spell)) && !(req_face_up && spell.IsFaceup())) { material_list.Add(spell); }
            }
            return material_list;
        }
        private int RitualMatAttract(ClientCard CardA)
        {
            if (CardA.Controller == 1) { return 32; }
            if (CardA.Controller == 0 && CardA.Location == CardLocation.Grave) { return 16; }
            if (CardA.Id == CardId.Toyosatomimi_no_Miko && CardA.Location == CardLocation.Hand) { return 8; }
            if (CardA.Level <= 5 && CardA.Location == CardLocation.MonsterZone) { return 4; }
            if (CardA.IsCode(CardId.Iizunamaru_Megumu) && CardA.Location == CardLocation.Hand && MegumuED) { return 2; }
            if (CardA.Controller == 0 && CardA.Location == CardLocation.Hand) { return 1; } 
            return 0;
        }
        private int RitualMatAttractL(List<ClientCard> material_list)
        {
            int count = 0;
            foreach (ClientCard cardA in material_list)
            {
                count = count + RitualMatAttract(cardA);
            }
            return count;
        }
        private int GetCardAttractValue(ClientCard CardA, bool req_not_invincible = true, bool req_face_up = true)  //得到卡牌嘲讽值
        {
            int count = 0;
            if (CardA.Id == 0) { return 0; }
            if (CardA.Controller == 0) { return -1; }
            if (CardA.HasType(CardType.Monster)) { count = count + 2; }
            if (CardA.HasType(CardType.Spell)) { count = count + 3; } 
            if (CardA.HasType(CardType.Trap)) { count = count + 4; }
            if (CardA.HasType(CardType.Continuous)) { count = count + 2; }
            if (CardA.Attack > 2000) { count = count + 1; } 
            if (CardA.Attack >= 3000) { count = count + 1; }
            if (CardA.Level > 4) { count = count + 1; }
            if (CardA.IsExtraCard()) { count = count + 2; }
            if (req_not_invincible && IsImmuneEffec(CardA)) { count = 0; }
            if (!req_not_invincible && IsImmuneEffec(CardA)) { count = count + 3; }
            if (req_face_up && CardA.IsFacedown()) { count = 0; }

            return count;
        }

        private bool IsImmuneEffec(ClientCard CardA)
        {
            IList<int> wudi = new[] {
                67712104, 89474727, 13073850,
                40061558, 54082269, 11738489,
                27279764, 57282724, 61307542,
                23971061, 67547370, 21377582,
                27240101, 36898537, 90885155,
                10669138, 10817524, 64496451,
                42632209, 41147577, 53315891,
                11516241, 43047672, 30270176,
                12275533, 76815942, 1516510,
                39475024, 69073023, 63504681,
                87182127, 86221741, 84025439,
                65029288, 57761191, 8062132,
                47946130, 11738489,
            };

            if (CardA.IsCode(82697249) && (Enemy.GetMonsterCount() + Enemy.GetSpellCount() == 1)) return true;
            if (CardA.IsCode(94207108) && Enemy.SpellZone[5] != null) return true;
            return CardA.IsCode(wudi);
        }
         
        private bool IsNosDestroyable(ClientCard CardA)
        {
            IList<int> wudi = new[] {
                82315403, 87054946, 95825679,
                71797713, 33545259, 61888819,
                52698008, 77610772, 97165977,
                20654247, 3611830,  92015800,
                43228023, 85908279, 49202162,
                24550676, 13331639, 55787576,
                98630720, 58601383, 42291297,
                37818794, 45148985, 74163487,
                38502358, 90590303, 66765023,
                55410871, 41456841, 180599,
                180598,   180597,
            };

            if (Enemy.HasInMonstersZone(86926989) && CardA.HasType(CardType.Synchro)) return true;
            if (Enemy.HasInMonstersZone(85080444)) return true;
            if (Enemy.HasInMonstersZone(16643334) && CardA.Attack >= 2000) return true;
            if (Enemy.HasInMonstersZone(40908371)) return true;
            if (CardA.IsCode(15419596) && CardA.Sequence == 2) return true;
            if (CardA.IsCode(140501) && CardA.Overlays.Count > 0) return true;
            if (CardA.HasSetcode(0xd0)) return true;
            return CardA.IsCode(wudi);
        }
        private bool DontCounter(ClientCard CardA)
        { 
            if (CardA.HasType(CardType.Pendulum) && !FirstP) { FirstP = true; return true; }
            if (CardA.IsCode(new[] { 70512, 70513, 70514, 70515, 70516 })) return true;
            if (CardA.IsCode(new[] { 1984019, 1984020, 1984021, 1984022, 1984023, 1984024, 1984025 })) return true; 
            return false;
        }
        private bool DontAct()
        {
            List<ClientCard> material_list = Bot.GetMonsters();
            foreach (ClientCard monster in material_list)
            {
                if (monster.IsOriginalCode(CardId.Toyosatomimi_no_Miko) && monster.IsFaceup() && !monster.IsDisabled() && monster.Attack >= 3000) return true;
            }
            return false;
        }
        private int CaCulator(IList<ClientCard> material_list, int tar_sum) //得到超过仪式等级tar_sum的情况下使得等级和的最小值N
        {
            int p = material_list.Count;
            int k = (1 << p); //表示2的p次方  
            int min_sum = 999;
            for(int i = 0; i < k; i = i + 1) 
            {
                int sum = 0;
                for (int j = 1; j <= material_list.Count; j = j + 1)
                {
                    int q = (1 << (j - 1)); // 第j个物品
                    if(((i & q) > 0) && material_list[j - 1].Level > 0) 
                    {
                        sum = sum + material_list[j - 1].Level;
                    }
                } 
                if (sum >= tar_sum && sum < min_sum) { min_sum = sum; }
            }
            return min_sum;
        }
        private List<ClientCard> CaCulator2(IList<ClientCard> material_list, int tar_sum) //返回material_list的一个且是最优化的子表listP，该子表listP的等级和为tar_sum
        {
            int p = material_list.Count;
            int k = (1 << p); //表示2的p次方   
            List<ClientCard> MlistP = new List<ClientCard>();
            for (int i = 0; i < k; i = i + 1)
            {
                List<ClientCard> listP = new List<ClientCard>();
                int sum = 0;
                for (int j = 1; j <= material_list.Count; j = j + 1)
                {
                    int q = (1 << (j - 1)); // 第j个物品
                    if (((i & q) > 0) && material_list[j - 1].Level > 0)
                    {
                        listP.Add(material_list[j - 1]);
                        sum = sum + material_list[j - 1].Level;
                    }
                } 
                if (sum == tar_sum && (RitualMatAttractL(listP) >= RitualMatAttractL(MlistP))) {
                    MlistP.Clear();
                    foreach (ClientCard cardS in listP)
                    {
                        MlistP.Add(cardS);
                    }
                }
                listP.Clear();
                if(listP.Count > 0) { Logger.DebugWriteLine("警报，未释放缓存"); }
            }
            return MlistP;
        }

        //快排
        //快速排序（等级从大到小)
        private void quickSort(int left, int right, IList<ClientCard> cards)
        { 
            if (left >= right)//递归边界条件
                return ;
            if (left < 0 || right >= cards.Count)
            {
                return ;
            }//非法输入判断,防止数组越界
            int i, j;
            ClientCard baseX;
            ClientCard temp;
            i = left; j = right;
            baseX = cards[left];  //取最左边的数为基准数while (i< j) 
            while (i < j)
            {
                while (cards[j].Level <= baseX.Level && i < j)
                    j--;
                while (cards[i].Level >= baseX.Level && i < j)
                    i++;
                if (i < j)
                {
                    temp = cards[i];
                    cards[i] = cards[j];
                    cards[j] = temp;
                }
            }
            //基准数归位
            cards[left] = cards[i];
            cards[i] = baseX;
            quickSort(left, i - 1, cards);//递归左边
            quickSort(i + 1, right, cards);//递归右边
        }
        //快速排序（嘲讽从大到小)
        private void quickSort2(int left, int right, IList<ClientCard> cards, bool req_not_invincible = true, bool req_face_up = true)
        {
            if (left >= right)//递归边界条件
                return;
            if (left < 0 || right >= cards.Count)
            {
                return;
            }//非法输入判断,防止数组越界
            int i, j;
            ClientCard baseX;
            ClientCard temp;
            i = left; j = right;
            baseX = cards[left];  //取最左边的数为基准数while (i< j) 
            while (i < j)
            {
                while (GetCardAttractValue(cards[j], req_not_invincible, req_face_up) <= GetCardAttractValue(baseX, req_not_invincible, req_face_up) && i < j)
                    j--;
                while (GetCardAttractValue(cards[i], req_not_invincible, req_face_up) >= GetCardAttractValue(baseX, req_not_invincible, req_face_up) && i < j)
                    i++;
                if (i < j)
                {
                    temp = cards[i];
                    cards[i] = cards[j];
                    cards[j] = temp;
                }
            }
            //基准数归位
            cards[left] = cards[i];
            cards[i] = baseX;
            quickSort2(left, i - 1, cards);//递归左边
            quickSort2(i + 1, right, cards);//递归右边
        }
        //快排
        //快速排序（攻击力从大到小)
        private void quickSort3(int left, int right, List<ClientCard> cards)
        {
            if (left >= right)//递归边界条件
                return;
            if (left < 0 || right >= cards.Count)
            {
                return;
            }//非法输入判断,防止数组越界
            int i, j;
            ClientCard baseX;
            ClientCard temp;
            i = left; j = right;
            baseX = cards[left];  //取最左边的数为基准数while (i< j) 
            while (i < j)
            {
                while (cards[j].Attack <= baseX.Attack && i < j)
                    j--;
                while (cards[i].Attack >= baseX.Attack && i < j)
                    i++;
                if (i < j)
                {
                    temp = cards[i];
                    cards[i] = cards[j];
                    cards[j] = temp;
                }
            }
            //基准数归位
            cards[left] = cards[i];
            cards[i] = baseX;
            quickSort3(left, i - 1, cards);//递归左边
            quickSort3(i + 1, right, cards);//递归右边
        }
        private void PRINT(string BBB, IList<ClientCard> cardsX)
        { 
            foreach (ClientCard card in cardsX)
            {
                BBB = BBB + "  " + card.Name;
            } 
            Logger.DebugWriteLine(BBB);
        }
    } 
}
