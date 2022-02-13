using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("Operator", "AI_Operator")]
    public class OperatorExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int S1 = 79029101;
            public const int S2 = 79029029;
            public const int S3 = 79029377;

            public const int S4 = 79029045;
            public const int S5 = 79029360;
            public const int S6 = 79029466;
            public const int S7 = 79029046;
            public const int S8 = 79029902;
            public const int S9 = 79029174;
            public const int S10 = 79029374;
            public const int S11 = 79029151;
            public const int S12 = 79029140;
            public const int S13 = 79029085;
            public const int S14 = 79029038;

            public const int S15 = 79029031;
            public const int S16 = 79029220;
            public const int S17 = 79029219;
            public const int S18 = 79029042;
            public const int S19 = 79029047;
            public const int S20 = 79029451;
            public const int S21 = 79029253;
            public const int S22 = 79029461;
            public const int S23 = 79029479;
            public const int S24 = 79029482;
            public const int S25 = 79029057;
            public const int S26 = 79029354;
            public const int S27 = 79029223;
            public const int S28 = 79029100;

            public const int S29 = 79029258;
            public const int S30 = 79029437;
            public const int S31 = 79029164;
            public const int S32 = 79029364;
            public const int S33 = 79029032;
            public const int S34 = 79029097;
            public const int S35 = 79029359;
            public const int stormeye = 79029318;
            public const int S36 = 79029225;
            public const int S37 = 79029061;
            public const int Chenjueying = 79029480;
            public const int Kekeke = 79029292;

            public const int Diannaowang = 57160136;
            public const int SolemnStrike = 40605147;
            public const int Impermanence = 10045474;
            public const int AshBlossom = 14558127;
        }
        List<int> normal_counter = new List<int>
        {
            53262004, 98338152, 32617464, 45041488, CardId.SolemnStrike,
            61257789, 23440231, 27354732, 12408276, 82419869, CardId.Impermanence,
            49680980, 18621798, 38814750, 17266660, 94689635,CardId.AshBlossom,
            74762582, 75286651, 4810828,  44665365, 21123811, _CardId.CrystalWingSynchroDragon,
            82044279, 82044280, 79606837, 10443957, 1621413,
            90809975, 8165596,  9753964,  53347303, 88307361, _CardId.GamecieltheSeaTurtleKaiju,
            5818294,  2948263,  6150044,  26268488, 51447164, _CardId.JizukirutheStarDestroyingKaiju,
            97268402
        };

        List<int> should_not_negate = new List<int>
        {
            81275020, 28985331
        };

        private int RockCount = 0;

        public OperatorExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            AddExecutor(ExecutorType.Activate, CardId.Diannaowang, DiannaowangEffect);
            AddExecutor(ExecutorType.Summon, CardId.S4, S4Summon);
            AddExecutor(ExecutorType.Activate, CardId.S4, S41Spsummon);
            AddExecutor(ExecutorType.SpSummon, CardId.S29, S29Summon);
            AddExecutor(ExecutorType.Activate, CardId.S29, S291Eff);
            AddExecutor(ExecutorType.Activate, CardId.S7, S72Eff);
            AddExecutor(ExecutorType.Activate, CardId.S15, S152E);
            AddExecutor(ExecutorType.SpSummon, CardId.S30, S30S);
            AddExecutor(ExecutorType.Activate, CardId.S17, S172E);
            AddExecutor(ExecutorType.Activate, CardId.S30, S301E);
            AddExecutor(ExecutorType.Activate, CardId.S19, S191E2);
            AddExecutor(ExecutorType.Activate, CardId.S20, S202E);
            AddExecutor(ExecutorType.Activate, CardId.S8, S81S);
            AddExecutor(ExecutorType.Activate, CardId.S8, S82E);
            AddExecutor(ExecutorType.SpSummon, CardId.S11, S11S);
            AddExecutor(ExecutorType.SpSummon, CardId.stormeye, stormeyeS);
            AddExecutor(ExecutorType.SpSummon, CardId.S31, S31linkS);
            AddExecutor(ExecutorType.Activate, CardId.S31, S311E); 
            AddExecutor(ExecutorType.Activate, CardId.S27, S27EE);
            AddExecutor(ExecutorType.SpSummon, CardId.S32, S32link);
            AddExecutor(ExecutorType.Activate, CardId.S32, S32EEf);
            AddExecutor(ExecutorType.Activate, CardId.S28, S28token);
            AddExecutor(ExecutorType.SpSummon, CardId.S34, S34linkS);
            AddExecutor(ExecutorType.Activate, CardId.S34, S341S);
            AddExecutor(ExecutorType.SpSummon, CardId.S35, S35linkS);
            AddExecutor(ExecutorType.Activate, CardId.S35, S352EEE);
            AddExecutor(ExecutorType.Activate, CardId.S23, S23Effect);
            AddExecutor(ExecutorType.Summon, CardId.S6, S6Summon);
            AddExecutor(ExecutorType.Activate, CardId.S6, S61eff);
            AddExecutor(ExecutorType.SpSummon, CardId.S36, S36efff);
            AddExecutor(ExecutorType.Activate, CardId.S36, S36Eff);
            AddExecutor(ExecutorType.Summon, CardId.S13, Summons);
            AddExecutor(ExecutorType.Activate, CardId.S13, S13Suu);
            AddExecutor(ExecutorType.Summon, CardId.S5, S5ssw);
            AddExecutor(ExecutorType.Activate, CardId.S5, S5sssww);
            AddExecutor(ExecutorType.Activate, CardId.S25, S25effect);
            AddExecutor(ExecutorType.Activate, CardId.S22, S22efffec);
            AddExecutor(ExecutorType.SpSummon, CardId.S33, S33linsss);
            AddExecutor(ExecutorType.SpSummon, CardId.S37, S37xyz);
            AddExecutor(ExecutorType.Activate, CardId.S37, S37effect);
            AddExecutor(ExecutorType.Activate, CardId.stormeye, stormeyeeffect);
            AddExecutor(ExecutorType.Activate, CardId.S18, S182effect);
            AddExecutor(ExecutorType.Activate, CardId.S14, S14effect);
            AddExecutor(ExecutorType.Activate, CardId.Chenjueying, Chenjueyingeffect);
            AddExecutor(ExecutorType.Summon, CardId.S7, S7summons);
            AddExecutor(ExecutorType.SpSummon, CardId.Kekeke, Kekekelinksummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Kekeke, Kekekeeffect);
            AddExecutor(ExecutorType.Repos, MonsterRepos);
            AddExecutor(ExecutorType.SpellSet, CardId.S17, S17sset);
            AddExecutor(ExecutorType.Activate, CardId.S17, S171effects);
            AddExecutor(ExecutorType.MonsterSet, MonsterSet);
        }
        private bool NormalSummoned = false;
        private bool S41oe = false;
        private bool S311oe = false;
        private bool S321oe = false;
        private bool S322oe = false;
        private bool S323oe = false;
        private bool S341oe = false;
        private bool S61oe = false;
        private bool S353oe = false;
        private bool S353oeee = false;
        private bool S29os = false;
        private bool S30os = false;
        private bool stormeyeos = false;
        private bool S36ox = false;


        public override void OnNewTurn()
        {
            NormalSummoned = false;
            S41oe = false;
            S311oe = false;
            S321oe = false;
            S322oe = false;
            S323oe = false;
            S341oe = false;
            S61oe = false;
            S353oe = false;
            S353oeee = false;
            S29os = false;
            S30os = false;
            stormeyeos = false;
            S36ox = false;

        }
        public bool MonsterRepos()
        {
            if (Card.Attack == 0) return (Card.IsAttack());

            if (Card.IsFacedown())
                return true;

            bool enemyBetter = Util.IsAllEnemyBetter(true);
            if (Card.IsAttack() && enemyBetter)
                return true;
            if (Card.IsDefense() && !enemyBetter)
                return true;
            return false;
        }
        private bool S4Summon()
        {
            NormalSummoned = true;
            return true;
        }
        private bool S6Summon()
        {
            NormalSummoned = true;
            return true;
        }
        private bool Summons()
        {
            NormalSummoned = true;
            return true;
        }
        private bool S5ssw()
        {
            NormalSummoned = true;
            return true;
        }
        private bool S7summons()
        {
            NormalSummoned = true;
            return true;
        }
        private bool S29Summon()
        {
            if (Duel.Phase == DuelPhase.Main1)
            {
               return true;
            }
            if (Duel.Phase == DuelPhase.Main2)
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }
        private bool S30S()
        {
            if (S30os == true) 
            {
                return false;
            }
            else
            {
                S30os = true;
                    return true;
            }
        }
        private bool stormeyeS()
        {
            if (stormeyeos == true)
            {
                return false;
            }
            else
            {
                stormeyeos = true;
                return true;
            }
        }
        private bool S11S()
        {
                return true;
        }
        private bool S36efff()
        {
            if (S36ox == true)
            {
                return false;
            }
            else if (Bot.HasInMonstersZone(CardId.S31) || Bot.HasInMonstersZone(CardId.S32))
            {
                AI.SelectMaterials(new List<int>() {
                        CardId.S31,
                        CardId.S32
                    });
                S36ox = true;
                return true;
            }
            return false;
        }
        private bool S37xyz()
        {
            if (Bot.HasInMonstersZone(CardId.S33))
            {
                AI.SelectMaterials(new List<int>() {
                        CardId.S33
                });
                return true;
            }
            return false;
        }
        private bool S31linkS()
        {
            if (S311oe == true)
            {
                return false;
            }
            else if (Bot.HasInMonstersZone(CardId.S4) || Bot.HasInMonstersZone(CardId.S7) || Bot.HasInMonstersZone(CardId.S5) || Bot.HasInMonstersZone(CardId.S11))
            {
                AI.SelectMaterials(new List<int>() {
                        CardId.S4,
                        CardId.S7,
                        CardId.S5,
                        CardId.S11
                    });
                return true;
            }
            return false;
        }
        private bool S32link()
        {
            if (S321oe == true)
            {
                return false;
            }
            else if (Bot.HasInMonstersZone(CardId.S4) || Bot.HasInMonstersZone(CardId.S7) || Bot.HasInMonstersZone(CardId.S5) || Bot.HasInMonstersZone(CardId.S11) || Bot.HasInMonstersZone(CardId.S31))
            {
                AI.SelectMaterials(new List<int>() {
                        CardId.S31,
                        CardId.S4,
                        CardId.S7,
                        CardId.S5,
                        CardId.S11
                    });
                return true;
            }
            return false;
        }
        private bool S33linsss()
        {
            if (Bot.HasInMonstersZone(CardId.S13))
            {
                AI.SelectMaterials(new List<int>() {
                        CardId.S13
                });
                return true;
            }
            return false;
        }
        private bool S34linkS()
        {
            if (S341oe == true)
            {
                return false;
            }
            else if (Bot.HasInMonstersZone(CardId.S1) || Bot.HasInMonstersZone(CardId.S4) || Bot.HasInMonstersZone(CardId.S7) || Bot.HasInMonstersZone(CardId.S5) || Bot.HasInMonstersZone(CardId.S11) || Bot.HasInMonstersZone(CardId.S31) || Bot.HasInMonstersZone(CardId.S32))
            {
                AI.SelectMaterials(new List<int>() {
                        CardId.S1,
                        CardId.S32,
                        CardId.S31,
                        CardId.S4,
                        CardId.S7,
                        CardId.S5,
                        CardId.S11
                    });
                return true;
            }
            return false;
        }
        private bool Kekekelinksummon()
        {
            if (Bot.HasInMonstersZone(CardId.S4) && Bot.HasInMonstersZone(CardId.S7))
            {
                AI.SelectMaterials(new List<int>() {
                        CardId.S34,
                        CardId.S1,
                        CardId.S32,
                        CardId.S31,
                        CardId.S4,
                        CardId.S7,
                        CardId.S5,
                        CardId.S11,
                        CardId.S37
                    });
                return true;
            }
            return false;
        }
        private bool S35linkS()
        {
            if (S353oe == true)
            {
                return false;
            }
            else
            {
                AI.SelectMaterials(new List<int>() {
                        CardId.S1,
                        CardId.S34,
                        CardId.S32,
                        CardId.S31,
                        CardId.S4,
                        CardId.S7,
                        CardId.S5,
                        CardId.S6,
                        CardId.S11
                    });
                return true;
            }
        }
        private bool S41Spsummon()
        {
            S41oe = true;
            if (Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.S17);
                AI.SelectNextCard(CardId.S7);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool DiannaowangEffect()
        {
            AI.SelectCard(CardId.S15,
                CardId.S20,
                CardId.S28
                );
            AI.SelectNextCard(CardId.S4,
                CardId.S6,
                CardId.S7,
                CardId.S5,
                CardId.S11
                );
            return true;
        }
        private bool S291Eff()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.S15);
                AI.SelectNextCard(CardId.S8);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool S72Eff()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.S18);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool S172E()
        {
            if (Card.Location == CardLocation.Removed)
            {
                AI.SelectCard(
                    CardId.S19,
                    CardId.S15
                    );
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool S152E()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(
                    CardId.S30,
                    CardId.S7,
                    CardId.S29
                    );
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool S301E()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.S15);
                AI.SelectNextCard(CardId.S20);
                AI.SelectOption(1);
                return true;
            }
            else
            {
                return true;
            }
        }
        private bool S191E2()
        {
            if (Card.Location == CardLocation.Grave)
            {
                return true;
            }
            else if (Card.Location == CardLocation.SpellZone)
            {
                if (S353oeee == true && Duel.LastChainPlayer == 1)
                {
                    return true;
                }
                else if (S353oeee == false)
                {
                    S353oeee = true;
                    return false;
                } 
            }
            return false;
        }
        private bool S202E()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.S29);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool S81S()
        {
            if (Card.Location == CardLocation.Hand)
            {
                AI.SelectCard(CardId.S15);
                AI.SelectCard(CardId.S18);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool S82E()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.S15);
                var x = ActivateDescription;
                if (ActivateDescription == Util.GetStringId(CardId.S8, 1) || ActivateDescription == 1)
                    AI.SelectOption(1);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool S311E()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                S311oe = true;
                AI.SelectCard(CardId.S27);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool S27EE()
        {
            if (Card.Location == CardLocation.FieldZone)
            {
                AI.SelectCard(
                        CardId.S21,
                        CardId.S22,
                        CardId.S26,
                        CardId.S10,
                        CardId.S5
                        );
                return true;
            }
            else
            {
                return true;
            }
        }
        private bool S32EEf()
        {
            if (Card.Location == CardLocation.MonsterZone && S321oe == false)
            {
                S321oe = true;
                int target = S321pa();
                if (target > 0)
                    AI.SelectCard(target);
                else
                    AI.SelectCard(
                    CardId.S28,
                    CardId.S27
                    );
                return true;
            }
            else if (Card.Location == CardLocation.Grave && S322oe == false)
            {
                S322oe = true;
                return true;
            }
            else if (Card.Location == CardLocation.MonsterZone && Bot.HasInHand(CardId.S28) && S323oe == false)
            {
                AI.SelectCard(CardId.S28);
            }
            return false;
        }
        private int S321pa()
        {
            if (!Bot.HasInSpellZone(CardId.S27) && !Bot.HasInHand(CardId.S27) )
            {
                return CardId.S27;
            }
            else 
            {
                return CardId.S28;
            }

        }
        private bool S28token()
        {
            if (Card.Location == CardLocation.SpellZone)
            {
                AI.SelectCard(
                        CardId.S22,
                        CardId.S13
                        );
                return true;
            }
                return false;
        }
        private bool S341S()
        {
            if (Bot.HasInGraveyard(CardId.S4))
            {
                S341oe = true;
                AI.SelectCard(CardId.S4);
                return true;
            }
            else if (Bot.HasInGraveyard(CardId.S7))
            {
                S341oe = true;
                AI.SelectCard(CardId.S7);
                return true;
            }
            else if (Bot.HasInGraveyard(CardId.S6))
            {
                S341oe = true;
                AI.SelectCard(CardId.S6);
                return true;
            }
            else if (Bot.HasInGraveyard(CardId.S7))
            {
                S341oe = true;
                AI.SelectCard(CardId.S7);
                return true;
            }
            else if (Bot.HasInGraveyard(CardId.S5))
            {
                S341oe = true;
                AI.SelectCard(CardId.S5);
                return true;
            }
            else if (Bot.HasInGraveyard(CardId.S14))
            {
                S341oe = true;
                AI.SelectCard(CardId.S14);
                return true;
            }
            else if (Bot.HasInGraveyard(CardId.S11))
            {
                S341oe = true;
                AI.SelectCard(CardId.S11);
                return true;
            }
            else
            {
                S341oe = true;
                return true;
            }
        }
        private bool S352EEE()
        {
            if (S353oe == false)
            {
             S353oe = true;
              return true;
            }
            else if (Duel.CurrentChain.Count != 0 && Duel.Player == 1)
            {
                S353oeee = true;
                return true;
            }
              return false;
        }
        private bool S61eff()
        {
            if (S61oe == false)
            {
                S61oe = true;
                AI.SelectNumber(8); 
                return true;
            }
            else if (S61oe == true || Bot.HasInHand(CardId.S12))
            {
                AI.SelectCard(CardId.S15,
                CardId.S20,
                CardId.S28
                );
                AI.SelectNextCard(CardId.S11,
                CardId.S6
                );
                return true;
            }
            return false;
        }
        private bool S36Eff()
        {
            AI.SelectCard(CardId.S23,
            CardId.S25,
            CardId.S22
            );
            return true;
        }
        private bool S25effect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.S23,
            CardId.S22);
                return true;
            }
            else if (Card.Location == CardLocation.Hand && Bot.HasInMonstersZone(CardId.S35) && Bot.HasInMonstersZone(CardId.Chenjueying))
            {
                AI.SelectCard(CardId.S35);
                return true;
            }
                return false;
        }
        private bool S22efffec()
        {
            AI.SelectCard(CardId.S13,
            CardId.S28);
            return true;
        }
        private bool S5sssww()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.S14);
                return true;
            }
            else if (Card.Location == CardLocation.Hand && (Bot.HasInHand(CardId.S4) || Bot.HasInHand(CardId.S7) || Bot.HasInHand(CardId.S5)))
            {
                ClientCard target = Util.GetProblematicEnemyMonster(Card.GetDefensePower());
                if (target != null)
                {
                    AI.SelectCard(
                        CardId.S5,
                        CardId.S7,
                        CardId.S4
                        );
                    AI.SelectNextCard(target);
                    return true;
                }
            }
            return false;
        }
        private bool S13Suu()
        {
            return true;
        }
        private bool S23Effect()
        {
            if (Bot.HasInMonstersZone(CardId.S35) && Bot.HasInExtra(CardId.Chenjueying))
            { 
             AI.SelectCard(CardId.Chenjueying);
            return true;
            }
            else if (Duel.LastChainPlayer == 1)
            {
                return true;
            }
            return false;
        }
        private bool S37effect()
        {
            if (Duel.Turn != 1 && Duel.Player == 0)
            {
                return true;
            }
            else if (Duel.Player ==1 && Duel.Phase == DuelPhase.Battle)
            {
                return true;
            }
            return false;
        }
        private bool stormeyeeffect()
        {
                return true;
        }
        private bool S182effect()
        {
            if (Duel.Phase == DuelPhase.End)
            {
                AI.SelectCard(
                    CardId.S8,
                    CardId.S33,
                    CardId.S5,
                    CardId.S11,
                    CardId.S14,
                    CardId.S7
                    );
                return true;
            }
            return false;
        }
        private bool S14effect()
        {
            if (S353oeee == true && Duel.LastChainPlayer == 1)
            {
                return true;
            }
            else if (S353oeee == false)
            {
                S353oeee = true;
                return false;
            }
            return false;
        }
        private bool Chenjueyingeffect()
        {
            if (Bot.HasInBanished(CardId.S35))
            {
                AI.SelectCard(CardId.Chenjueying);
                return true;
            }
            else if (Duel.LastChainPlayer == 1 && Duel.Player == 1)
            {
                return true;
            }
            return false;
        }
        public bool MonsterSet()
        {
            if (Util.GetOneEnemyBetterThanMyBest() == null && Bot.GetMonsterCount() > 0) return false;
            if (Card.Level > 4) return false;
            int rest_lp = Bot.LifePoints;
            int count = Bot.GetMonsterCount();
            List<ClientCard> list = Enemy.GetMonsters();
            list.Sort(CardContainer.CompareCardAttack);
            foreach (ClientCard card in list)
            {
                if (!card.HasPosition(CardPosition.Attack)) continue;
                if (count-- > 0) continue;
                rest_lp -= card.Attack;
            }
            if (rest_lp < 1700)
            {
                AI.SelectPosition(CardPosition.FaceDownDefence);
                return true;
            }
            return false;
        }
        private bool S17sset()
        {
            if (Duel.Turn == 1 || Duel.Phase == DuelPhase.Main2)
            {
                return true;
            }
            return false;
        }
        private bool S171effects()
        {
            if (Card.Location == CardLocation.SpellZone)
            {
                AI.SelectCard(
                    CardId.Chenjueying,
                    CardId.S35,
                    CardId.S37,
                    CardId.S34
                    );
                return true;
            }
            return false;
        }
        public bool Kekekeeffect()
        {
            return true;
        }
    }
}



