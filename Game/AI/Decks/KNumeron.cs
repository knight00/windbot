using System;
using System.Collections.Generic;
using System.Linq;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
using YGOSharp.OCGWrapper.Enums;

namespace WindBot.Game.AI.Decks
{
    [Deck("AI_Numeron", "AI_Numeron")]
    class KNumeronExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Number100Dragon = 13714;
            public const int CNumber100Dragon = 494;
            public const int TreasureDraw = 511001126;
            public const int Oricha = 12201;
            public const int Costdown = 609;
            public const int Numeronlead = 13707;
            public const int CNo1 = 13705;
            public const int No1000 = 586;
            public const int CNo1000 = 13715;
            public const int CiNo1000 = 13716;
            public const int DoubleSummon = 43422537;
            public const int CrossSacriface = 26;
            public const int Cyclone = 5318639;

            public const int Anti_Spell = 58921041;
            public const int ImperialOrder = 61740673;
            public const int Kagari = 63288573;
            public const int Shizuku = 90673288;
        }

        public KNumeronExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            AddExecutor(ExecutorType.SpSummon, () => !Card.IsCode(CardId.CNo1) && Summonplace());
            AddExecutor(ExecutorType.Activate, OtherSpellEffect);
            AddExecutor(ExecutorType.Activate, OtherTrapEffect);
            AddExecutor(ExecutorType.Activate, OtherMonsterEffect);

            AddExecutor(ExecutorType.SpSummon, ImFeelingUnlucky);
            AddExecutor(ExecutorType.Activate, ImFeelingUnlucky);

            AddExecutor(ExecutorType.Summon, () => Advancesummon() && !Card.IsCode(13711));
            // Reposition
            AddExecutor(ExecutorType.Repos, MonsterRepos);
            AddExecutor(ExecutorType.SpellSet, Spellset);

            IList<int> activatem = new List<int>();
            AddExecutor(ExecutorType.Activate, CardId.Cyclone, OtherSpellEffect);
            activatem.Add(CardId.Cyclone);

            AddExecutor(ExecutorType.SpSummon, 602, Summonplace);
            AddExecutor(ExecutorType.SpSummon, 603, Summonplace);
            AddExecutor(ExecutorType.Activate, 603, Summonplace);
            activatem.Add(603);
            AddExecutor(ExecutorType.SpSummon, 612, Summonplace);
            AddExecutor(ExecutorType.SpSummon, CardId.CNo1, CNo1);
            AddExecutor(ExecutorType.Activate, CardId.CNo1);
            activatem.Add(CardId.CNo1);
            AddExecutor(ExecutorType.Activate, CardId.Number100Dragon);
            activatem.Add(CardId.Number100Dragon);
            AddExecutor(ExecutorType.Activate, CardId.No1000, CNo1000Effects);
            activatem.Add(CardId.No1000);
            AddExecutor(ExecutorType.Activate, CardId.CNo1000, CNo1000Effects);
            activatem.Add(CardId.CNo1000);
            AddExecutor(ExecutorType.Activate, CardId.CiNo1000, CiNo1000Effects);
            activatem.Add(CardId.CiNo1000);

            AddExecutor(ExecutorType.Activate, CardId.Costdown, Costdown);
            activatem.Add(CardId.Costdown);
            AddExecutor(ExecutorType.Activate, CardId.CrossSacriface, CrossSacriface);
            activatem.Add(CardId.CrossSacriface);
            AddExecutor(ExecutorType.Activate, CardId.DoubleSummon, DoubleSummon);
            activatem.Add(CardId.DoubleSummon);
            AddExecutor(ExecutorType.Activate, CardId.Numeronlead, Numeronlead);
            activatem.Add(CardId.Numeronlead);
            AddExecutor(ExecutorType.Activate, 588, RUM1000);
            activatem.Add(588);
            AddExecutor(ExecutorType.Activate, 13717, RUM1000);
            activatem.Add(13717);
            AddExecutor(ExecutorType.Activate, 593, RUM_DonThousand);
            activatem.Add(593);
            AddExecutor(ExecutorType.SpSummon, 209, FNo0);
            AddExecutor(ExecutorType.Activate, 209, FNo0_Effects);
            AddExecutor(ExecutorType.SpSummon, 723, FNo0_Slash);
            AddExecutor(ExecutorType.Activate, 723, FNo0_Slash_Effects);
            activatem.Add(723);
            AddExecutor(ExecutorType.Activate, CardId.Oricha, Oricha);
            activatem.Add(CardId.Oricha);

            AddExecutor(ExecutorType.Activate, CardId.TreasureDraw, TreasureDraw);
        }

        private int CrossSacrifaceCount = 0;
        private int CNo1summon = 0;
        private int No1annouce = 0;

        private List<long> HintMsgForEnemy = new List<long>
        {
            HintMsg.Release, HintMsg.Destroy, HintMsg.Remove, HintMsg.ToGrave, HintMsg.ReturnToHand, HintMsg.ToDeck,
            HintMsg.FusionMaterial, HintMsg.SynchroMaterial, HintMsg.XyzMaterial, HintMsg.LinkMaterial
        };

        private List<long> HintMsgForDeck = new List<long>
        {
            HintMsg.SpSummon, HintMsg.ToGrave, HintMsg.Remove, HintMsg.AddToHand, HintMsg.FusionMaterial
        };

        private List<long> HintMsgForSelf = new List<long>
        {
            HintMsg.Equip
        };

        private List<long> HintMsgForMaterial = new List<long>
        {
            HintMsg.FusionMaterial, HintMsg.SynchroMaterial, HintMsg.XyzMaterial, HintMsg.LinkMaterial, HintMsg.Release
        };

        private List<long> HintMsgForMaxSelect = new List<long>
        {
            HintMsg.SpSummon, HintMsg.ToGrave, HintMsg.AddToHand, HintMsg.FusionMaterial, HintMsg.Destroy
        };

        public override void OnNewTurn()
        {
            CrossSacrifaceCount = 0;
            CNo1summon = 0;
            No1annouce = 0;
        }

        public override CardPosition OnSelectPosition(int cardId, IList<CardPosition> positions)
        {
            YGOSharp.OCGWrapper.NamedCard cardData = YGOSharp.OCGWrapper.NamedCard.Get(cardId);
            if (cardData != null)
            {
                if (Util.IsAllEnemyBetterThanValue(cardData.Attack, true) && !(cardData.HasType(CardType.Xyz) && !Card.IsDisabled()))
                    return CardPosition.FaceUpDefence;
                return CardPosition.FaceUpAttack;
            }
            return 0;
        }

        public override bool OnSelectYesNo(long desc)
        {
            if ((desc == Util.GetStringId(826, 12) && (Duel.Player == 1 || No1annouce>=10)) || desc == Util.GetStringId(13712, 0))
                return false;
            if (desc == Util.GetStringId(827, 6) || desc == Util.GetStringId(827, 1) || desc == Util.GetStringId(13709, 11) || desc == Util.GetStringId(123106, 8) || desc == Util.GetStringId(123106, 7) || desc == Util.GetStringId(13709, 12) || desc == Util.GetStringId(826, 6) || desc == Util.GetStringId(13713, 8) || desc == Util.GetStringId(827, 1))
                return false;
            if (desc == 210) // Continue selecting? (Link Summoning)
                return false;
            if (desc == 31) // Direct Attack?
                return true;
            return base.OnSelectYesNo(desc);
        }

        public override IList<ClientCard> OnSelectCard(IList<ClientCard> _cards, int min, int max, long hint, bool cancelable)
        {
            if (Duel.Phase == DuelPhase.BattleStart)
                return null;
            if (AI.HaveSelectedCards())
                return null;

            IList<ClientCard> selected = new List<ClientCard>();
            IList<ClientCard> cards = new List<ClientCard>(_cards);
            if (max > cards.Count)
                max = cards.Count;

            if (HintMsgForEnemy.Contains(hint))
            {
                IList<ClientCard> enemyCards = cards.Where(card => card.Controller == 1).ToList();

                // select enemy's card first
                while (enemyCards.Count > 0 && selected.Count < max)
                {
                    ClientCard card = enemyCards[Program.Rand.Next(enemyCards.Count)];
                    selected.Add(card);
                    enemyCards.Remove(card);
                    cards.Remove(card);
                }
            }

            if (HintMsgForDeck.Contains(hint))
            {
                IList<ClientCard> deckCards = cards.Where(card => card.Location == CardLocation.Deck).ToList();

                // select deck's card first
                while (deckCards.Count > 0 && selected.Count < max)
                {
                    ClientCard card = deckCards[Program.Rand.Next(deckCards.Count)];
                    selected.Add(card);
                    deckCards.Remove(card);
                    cards.Remove(card);
                }
            }

            if (HintMsgForSelf.Contains(hint))
            {
                IList<ClientCard> botCards = cards.Where(card => card.Controller == 0).ToList();

                // select bot's card first
                while (botCards.Count > 0 && selected.Count < max)
                {
                    ClientCard card = botCards[Program.Rand.Next(botCards.Count)];
                    selected.Add(card);
                    botCards.Remove(card);
                    cards.Remove(card);
                }
            }

            if (HintMsgForMaterial.Contains(hint))
            {
                IList<ClientCard> materials = cards.OrderBy(card => card.Attack).ToList();

                // select low attack first
                while (materials.Count > 0 && selected.Count < min)
                {
                    ClientCard card = materials[0];
                    selected.Add(card);
                    materials.Remove(card);
                    cards.Remove(card);
                }
            }

            // select random cards
            while (selected.Count < min)
            {
                ClientCard card = cards[Program.Rand.Next(cards.Count)];
                selected.Add(card);
                cards.Remove(card);
            }

            if (HintMsgForMaxSelect.Contains(hint))
            {
                // select max cards
                while (selected.Count < max)
                {
                    ClientCard card = cards[Program.Rand.Next(cards.Count)];
                    selected.Add(card);
                    cards.Remove(card);
                }
            }

            return selected;
        }

        public override int OnAnnounceCard(IList<int> avail)
        {
            ClientCard orica = Bot.GetFieldSpellCard();
            ClientCard last_chain_card = Util.GetLastChainCard();
            if (orica == null && avail.Contains(12201))
                return 12201;
            if (last_chain_card != null && last_chain_card.IsCode(CardId.CNo1000))
            {
                if ((Bot.MonsterZone.GetMonsters().ContainsCardWithId(CardId.CNumber100Dragon) || Bot.SpellZone.GetMonsters().ContainsCardWithId(CardId.CNumber100Dragon)))
                    return CardId.CNo1000;
                return CardId.CNumber100Dragon;
            }

            IList<ClientCard> last_cards = Bot.Graveyard.GetMatchingCards(card => card.IsFaceup() && card.Sequence == Bot.Graveyard.Count - 1);
            if (last_chain_card != null && last_chain_card.IsCode(CardId.Oricha) && last_cards.Count > 0)
            {
                ClientCard last_card = last_cards[0];
                if (last_card.IsCode(593))
                    return CardId.No1000;
                else if (last_card.IsCode(588))
                    return CardId.CNo1000;
                else
                {
                    return 13701;
                    No1annouce++;
                }
            }
            return avail[0];
        }

        public override int OnAnnounceNumber(IList<int> numbers)
        {
            return numbers.Count > 1 ? numbers.Count - 1 : 0;
        }

        public override int OnSelectOption(IList<long> options)
        {
            if (options[0] == Util.GetStringId(826, 12))
                return 0;
            return options.Count > 1 ? options.Count - 1 : 0;
        }

        public override bool OnPreBattleBetween(ClientCard attacker, ClientCard defender)
        {
            return base.OnPreBattleBetween(attacker, defender);
        }

        public override ClientCard OnSelectAttacker(IList<ClientCard> attackers, IList<ClientCard> defenders)
        {
            List<ClientCard> att = new List<ClientCard>();
            foreach (ClientCard tc in attackers)
            {
                att.Add(tc);
            }
            if (att.Count > 0)
            {
                att.Sort(CardContainer.CompareCardAttack);
                att.Reverse();
                for (int i = 0; i < attackers.Count; i++)
                {
                    ClientCard attacker = attackers[i];
                    if (attacker.IsCode(13701) && !attacker.IsDisabled()
                        && (Bot.GetMonsters().GetMatchingCardsCount(card => card.IsAttack() && card.HasSetcode(0x14b)) > 0 && (attacker.HasXyzMaterial() || (Bot.GetFieldSpellCard().IsFaceup() && !Bot.GetFieldSpellCard().IsDisabled() && Bot.GetFieldSpellCard().IsCode(12201,13706)))
                        || Bot.SpellZone.GetMatchingCardsCount(card => card.IsAttack() && card.HasSetcode(0x14b)) > 0 && (attacker.HasXyzMaterial() || (Bot.GetFieldSpellCard().IsFaceup() && !Bot.GetFieldSpellCard().IsDisabled() && Bot.GetFieldSpellCard().IsCode(12201, 13706)))) )
                    {
                        att.Remove(attacker); att.Add(attacker); attackers.Remove(attacker); attackers.Add(attacker);
                    }
                }
                for (int i = 0; i < attackers.Count; i++)
                {
                    ClientCard attacker = attackers[i];
                    if ((attacker.IsCode(13702) || attacker.IsCode(13703) || attacker.IsCode(13704)) && !attacker.IsDisabled()
                        && Bot.GetMonsters().GetMatchingCardsCount(card => card.IsAttack() && card.HasSetcode(0x14b)) > 0 && (attacker.HasXyzMaterial() || (Bot.GetFieldSpellCard().IsFaceup() && !Bot.GetFieldSpellCard().IsDisabled() && Bot.GetFieldSpellCard().IsCode(12201,13706)))
                        || (Bot.SpellZone.GetMatchingCardsCount(card => card.IsAttack() && card.HasSetcode(0x14b)) > 0 && (attacker.HasXyzMaterial() || (Bot.GetFieldSpellCard().IsFaceup() && !Bot.GetFieldSpellCard().IsDisabled() && Bot.GetFieldSpellCard().IsCode(12201, 13706)))) )
                    {
                        att.Remove(attacker); att.Add(attacker); attackers.Remove(attacker); attackers.Add(attacker);
                    }
                }
                att.Reverse();
            }
            for (int i = 0; i < att.Count; ++i)
            {
                ClientCard attacker = attackers[i];
                Logger.DebugWriteLine(attacker.Name);
                return attacker;
            }
            return base.OnSelectAttacker(attackers, defenders);
        }

        public override BattlePhaseAction OnSelectAttackTarget(ClientCard attacker, IList<ClientCard> defenders)
        {
            for (int i = 0; i < defenders.Count; ++i)
            {
                ClientCard defender = defenders[i];
                attacker.RealPower = attacker.Attack;
                defender.RealPower = defender.GetDefensePower();
                if (defender.IsCode(732) && defender.IsAttack())
                    defender.RealPower = defender.Attack * 2;
                if (attacker.IsCode(CardId.Number100Dragon, CardId.CNumber100Dragon, 592) && !attacker.IsDisabled())
                {
                    defender.RealPower = 0;
                }
                if (defender.IsCode(CardId.Number100Dragon, CardId.CNumber100Dragon, 592) && !defender.IsDisabled())
                {
                    attacker.RealPower = 0;
                }
                if (attacker.IsCode(13701) && attacker.RealPower < defender.RealPower && Bot.LifePoints > defender.RealPower - attacker.RealPower && Bot.HasInHand(13717) && Bot.HasInExtra(CardId.CNo1000) && Bot.Graveyard.GetMatchingCardsCount(card => card.HasSetcode(0x48) || card.IsCode(12201,13706)) + Bot.Banished.GetMatchingCardsCount(card => (card.HasSetcode(0x48) || card.IsCode(12201, 13706)) && card.IsFaceup()) > 4)
                    return AI.Attack(attacker, defender);
                if (!OnPreBattleBetween(attacker, defender))
                    continue;
                if (attacker.RealPower >= defender.RealPower || (attacker.RealPower >= defender.RealPower && ((attacker.HasSetcode(0x48) && !attacker.IsDisabled() && !(defender.HasSetcode(0x48) && !defender.IsDisabled())) || attacker.IsLastAttacker && defender.IsAttack())))
                    return AI.Attack(attacker, defender);
            }
            if (Enemy.GetMonsterCount() == 0 || attacker.CanDirectAttack)
                return AI.Attack(attacker, null);
            return null;
        }

        private bool Summonplace()
        {
            if (Bot.GetFieldSpellCard() != null && Bot.GetFieldSpellCard().HasXyzMaterial(1, 10))
            {
                for (int i = 4; i >= 0; --i)
                {
                    if (Bot.SpellZone[i] == null)
                    {
                        int place = (int)System.Math.Pow(2, i) * 256;
                        AI.SelectPlace(place);
                        return true;
                    }
                }
                return true;
            }
            return true;
        }

        private bool Advancesummon()
        {
            if (Card.Level > 4 && DefaultMonsterSummon() && (Bot.MonsterZone.GetMonsters().GetMatchingCardsCount(card => card.Level > 0 || card.IsDisabled() || (card.Attack == 0 && card.BaseAttack > 0)) > 0 || Bot.SpellZone.GetMonsters().GetMatchingCardsCount(card => card.Level > 0 || card.IsDisabled() || (card.Attack == 0 && card.BaseAttack > 0)) > 0))
            {
                List<ClientCard> monster_sorted = new List<ClientCard>();
                IList<ClientCard> monster_sorted1 = Bot.MonsterZone.GetMonsters().GetMatchingCards(card => card.Level > 0 || card.IsDisabled() || (card.Attack == 0 && card.BaseAttack > 0));
                IList<ClientCard> monster_sorted2 = Bot.SpellZone.GetMonsters().GetMatchingCards(card => card.Level > 0 || card.IsDisabled() || (card.Attack == 0 && card.BaseAttack > 0));
                foreach (ClientCard monster in monster_sorted1)
                {
                    monster_sorted.Add(monster);
                }
                foreach (ClientCard monster in monster_sorted2)
                {
                    monster_sorted.Add(monster);
                }
                monster_sorted.Sort(CardContainer.CompareCardAttack);
                List<ClientCard> tribute = new List<ClientCard>();
                foreach (ClientCard monster in monster_sorted)
                {
                    if (monster.Rank < 1 || monster.IsDisabled() || (monster.Attack == 0 && monster.BaseAttack > 0))
                        tribute.Add(monster);
                    else continue;
                }
                AI.SelectMaterials(tribute);

                if (Bot.GetFieldSpellCard() != null && Bot.GetFieldSpellCard().HasXyzMaterial(1, 10))
                {
                    for (int i = 4; i >= 0; --i)
                    {
                        if (Bot.SpellZone[i] == null)
                        {
                            int place = (int)System.Math.Pow(2, i) * 256;
                            AI.SelectPlace(place);
                            AI.SelectPosition(CardPosition.FaceUpDefence);
                            return true;
                        }
                    }
                    AI.SelectPosition(CardPosition.FaceUpDefence);
                    return true;
                }
            }

            if (Card.Level > 4)
                return false;
            AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }

        private bool Spellset()
        {
            if (Card.HasType(CardType.QuickPlay) && Duel.Player == 0 && Duel.Phase == DuelPhase.Main2)
                return Bot.GetSpellCountWithoutField() < 4;
            return !Card.HasType(CardType.QuickPlay) && DefaultSpellSet();
        }

        private bool MonsterRepos()
        {
            if (!Card.IsAttack() && (Card.HasXyzMaterial() || !Bot.IsFieldEmpty()) && !Card.IsDisabled())
                return true;
            if (Card.IsAttack() && (Card.HasXyzMaterial() || !Bot.IsFieldEmpty()) && !Card.IsDisabled())
                return false;
            return base.DefaultMonsterRepos();
        }

        private bool Oricha()
        {
            if (Util.ChainContainsCard(CardId.Oricha)) return false;
            if (ActivateDescription == Util.GetStringId(12744567, 0) || (ActivateDescription == -1 && !(Card.HasXyzMaterial(1, 13706))))
            {
                if (!(Card.HasXyzMaterial(1, 13706)))
                {
                    AI.SelectAnnounceID(13706);
                    return true;
                }
                if (!(Card.HasXyzMaterial(1, 12)))
                {
                    AI.SelectAnnounceID(12);
                    return true;
                }
                if (!(Card.HasXyzMaterial(1, 10)))
                {
                    AI.SelectAnnounceID(10);
                    return true;
                }
                if (!(Card.HasXyzMaterial(1, 160000107)))
                {
                    AI.SelectAnnounceID(160000107);
                    return true;
                }
                if (!(Card.HasXyzMaterial(1, 100000382)))
                {
                    AI.SelectAnnounceID(100000382);
                    return true;
                }
                if (!(Card.HasXyzMaterial(1, 146)))
                {
                    AI.SelectAnnounceID(146);
                    return true;
                }
                AI.SelectAnnounceID(11);
                return true;
            }

            IList<ClientCard> selected = Bot.Deck.GetMatchingCards(card=>card.HasSetcode(0x14b) && (card.IsSpell() || card.IsTrap()));
            if (Duel.Player == 1 && (Bot.HasInGraveyard(13705) || Bot.HasInBanished(13705) || Enemy.HasInGraveyard(13705) || Enemy.HasInBanished(13705)))
                AI.SelectCard(588, 593, CardId.Numeronlead, 595, 13717, 13708, 13709, 13710, 13713, 596, 597);
            else if (Duel.Player == 0)
                AI.SelectCard(CardId.Numeronlead, 588, 593, 595, 13717, 13708, 13709, 13710, 13713, 596, 597);
            else if (Duel.Player == 1)
                AI.SelectCard(595, 588, 593, 13717, 13708, 13709, 13710, 13713, 596, 597);

            List<ClientCard> NumeronNo = Bot.ExtraDeck.GetMonsters();
            ClientCard NumeronNo1 = Bot.ExtraDeck.GetFirstMatchingCard(card => card.IsCode(13701));
            ClientCard NumeronNo2 = Bot.ExtraDeck.GetFirstMatchingCard(card => card.IsCode(13702));
            ClientCard NumeronNo3 = Bot.ExtraDeck.GetFirstMatchingCard(card => card.IsCode(13703));
            ClientCard NumeronNo4 = Bot.ExtraDeck.GetFirstMatchingCard(card => card.IsCode(13704));
            if (NumeronNo1 != null)
                NumeronNo.Remove(NumeronNo1); NumeronNo.Add(NumeronNo1);
            if (NumeronNo2 != null)
                NumeronNo.Remove(NumeronNo2); NumeronNo.Add(NumeronNo2);
            if (NumeronNo3 != null)
                NumeronNo.Remove(NumeronNo3); NumeronNo.Add(NumeronNo3);
            if (NumeronNo4 != null)
                NumeronNo.Remove(NumeronNo4); NumeronNo.Add(NumeronNo4);
            NumeronNo.Reverse();
            AI.SelectNextCard(NumeronNo);

            //int count = Util.GetBotAvailZonesFromExtraDeck();
            //if (Card.HasXyzMaterial(1, 10)) count += 5 - Bot.GetSpellCountWithoutField();
            //if (count > 3)
            //{
            //    for (int i = 0; i < 4; i++)
            //    {
            //        if (CNo1summon > 0 && Duel.Turn > 1)
            //            AI.SelectAnnounceID(13714);
            //        No1annouce++;
            //        AI.SelectAnnounceID(13701);
            //    }
            //}

            if (Card.HasXyzMaterial(1, 10))
            {
                List<ClientCard> Oricamonster = Bot.GetMonsters();
                List<ClientCard> Oricamonster2 = Bot.SpellZone.GetMonsters();
                foreach (ClientCard mon in Oricamonster2)
                    Oricamonster.Add(mon);
                ClientCard topmon = Oricamonster.GetHighestAttackMonster();
                Oricamonster.Remove(topmon);
                Oricamonster.Sort(CardContainer.CompareCardAttack);
                Oricamonster.Reverse();
                AI.SelectCard(Oricamonster);
            }

            return true;
        }

        private bool Costdown()
        {
            return Bot.Hand.GetMatchingCardsCount(card=>card.Level>10)> 1;
        }

        private bool CrossSacriface()
        {
            if (Duel.Turn > 1 && Bot.Hand.GetMatchingCardsCount(card=>card.Level>4)>0 && Enemy.GetMonsterCount()>0 && CrossSacrifaceCount==0)
            {
                AI.SelectCard(Enemy.GetMonsters());
                CrossSacrifaceCount++;
                return true;
            }
            return false;
        }

        private int _lastDoubleSummon;
        private bool DoubleSummon()
        {
            if (_lastDoubleSummon == Duel.Turn)
                return false;

            if (Main.SummonableCards.Count == 0)
                return false;

            if (Main.SummonableCards.Count == 1 && Main.SummonableCards[0].Level < 5)
            {
                bool canTribute = false;
                foreach (ClientCard handCard in Bot.Hand)
                {
                    if (handCard.IsMonster() && handCard.Level > 4 && handCard.Level < 6)
                        canTribute = true;
                }
                if (!canTribute)
                    return false;
            }

            int monsters = 0;
            foreach (ClientCard handCard in Bot.Hand)
            {
                if (handCard.IsMonster())
                    monsters++;
            }
            if (monsters <= 1)
                return false;

            _lastDoubleSummon = Duel.Turn;
            return true;
        }

        private bool TreasureDraw()
        {
            if (6 - Bot.GetHandCount() > 0 && Bot.Deck.Count <= 6 - Bot.GetHandCount())
                return false;
            return true;
        }

        private bool Numeronlead()
        {
            List<ClientCard> NumeronNo = Bot.ExtraDeck.GetMonsters();
            ClientCard NumeronNo1 = Bot.ExtraDeck.GetFirstMatchingCard(card => card.IsCode(13701));
            ClientCard NumeronNo2 = Bot.ExtraDeck.GetFirstMatchingCard(card => card.IsCode(13702));
            ClientCard NumeronNo3 = Bot.ExtraDeck.GetFirstMatchingCard(card => card.IsCode(13703));
            ClientCard NumeronNo4 = Bot.ExtraDeck.GetFirstMatchingCard(card => card.IsCode(13704));
            if (NumeronNo1 != null)
                NumeronNo.Remove(NumeronNo1); NumeronNo.Add(NumeronNo1);
            if (NumeronNo2 != null)
                NumeronNo.Remove(NumeronNo2); NumeronNo.Add(NumeronNo2);
            if (NumeronNo3 != null)
                NumeronNo.Remove(NumeronNo3); NumeronNo.Add(NumeronNo3);
            if (NumeronNo4 != null)
                NumeronNo.Remove(NumeronNo4); NumeronNo.Add(NumeronNo4);
            NumeronNo.Reverse();
            AI.SelectCard(NumeronNo);

            for (int i = 0; i < 4; i++)
            {
                if (CNo1summon > 0 && Duel.Turn > 1 && i==0)
                    AI.SelectAnnounceID(13714);
                AI.SelectAnnounceID(13701);
                No1annouce++;
            }
            return true;
        }

        private bool CNo1()
        {
            if ((Duel.Player == 0 && Duel.Phase == DuelPhase.Main2) || Duel.Player == 1 || Duel.Turn < 2)
            {
                CNo1summon++;
                if (Bot.GetFieldSpellCard() != null && Bot.GetFieldSpellCard().HasXyzMaterial(1, 10))
                {
                    for (int i = 4; i >= 0; --i)
                    {
                        if (Bot.SpellZone[i] == null)
                        {
                            int place = (int)System.Math.Pow(2, i) * 256;
                            AI.SelectPlace(place);
                            AI.SelectPosition(CardPosition.FaceUpAttack);
                            return true;
                        }
                    }
                }
                else
                {
                    for (int i = 4; i >= 0; --i)
                    {
                        if (Bot.MonsterZone[i] == null)
                        {
                            int place = (int)System.Math.Pow(2, i);
                            AI.SelectPlace(place);
                            AI.SelectPosition(CardPosition.FaceUpAttack);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool Number100DragonEffects()
        {
            if (Duel.Player == 0)
                return true;
            else
                return Card.IsFaceup() && Bot.UnderAttack && Bot.BattlingMonster== Card;
        }

        private bool RUM1000()
        {
            if (Card.IsCode(588) && Card.Location==CardLocation.Grave)
                AI.SelectAnnounceID(594);
            AI.SelectAnnounceID(CardId.CNo1000);
            return true;
        }

        private bool RUM_DonThousand()
        {
            AI.SelectAnnounceID(CardId.No1000);
            return true;
        }

        private bool FNo0()
        {
            if (CNo1summon == 0)
                return false;
            List<ClientCard> mat1 = Bot.MonsterZone.GetMonsters();
            List<ClientCard> mat2 = Bot.SpellZone.GetMonsters();
            foreach (ClientCard mon in mat2)
                mat1.Add(mon);
            AI.SelectCard(mat1);
            return true;
        }

        private bool FNo0_Effects()
        {
            return false;
        }

        private bool FNo0_Slash()
        {
            if (Duel.Player == 0 && Duel.Turn == 1)
                return false;
            return true;
        }

        private bool FNo0_Slash_Effects()
        {
            if (Duel.Player == 1 && !Bot.UnderAttack)
                return false;
            return true;
        }

        private bool CNo1000Effects()
        {
            IList<ClientCard> Destg = Enemy.GetMonsters().GetMatchingCards(card => !card.IsMonsterInvincible());
            List<ClientCard> Destg2 = new List<ClientCard>();
            foreach (ClientCard des in Destg)
                Destg2.Add(des);
            Destg2.Sort(CardContainer.CompareCardAttack);
            Destg2.Reverse();
            if (Destg2.Count > 0)
                return true;
            return false;
        }

        private bool CiNo1000Effects()
        {
            if (Bot.UnderAttack && Bot.BattlingMonster == Card && Enemy.BattlingMonster.RealPower>=Card.RealPower)
                return true;
            return false;
        }

        public ClientCard GetFloodgate_Alter(bool canBeTarget = false, bool is_bounce = true)
        {
            foreach (ClientCard card in Enemy.GetSpells())
            {
                if (card != null && card.IsFloodgate() && card.IsFaceup() &&
                    !card.IsCode(CardId.Anti_Spell, CardId.ImperialOrder)
                    && (!is_bounce || card.IsTrap())
                    && (!canBeTarget || !card.IsShouldNotBeTarget()))
                    return card;
            }
            return null;
        }

        public ClientCard GetProblematicEnemyCard_Alter(bool canBeTarget = false, bool is_bounce = true)
        {
            ClientCard card = Enemy.MonsterZone.GetFloodgate(canBeTarget);
            if (card != null)
                return card;

            card = GetFloodgate_Alter(canBeTarget, is_bounce);
            if (card != null)
                return card;

            card = Enemy.MonsterZone.GetDangerousMonster(canBeTarget);
            if (card != null
                && (Duel.Player == 0 || (Duel.Phase > DuelPhase.Main1 && Duel.Phase < DuelPhase.Main2)))
                return card;

            card = Enemy.MonsterZone.GetInvincibleMonster(canBeTarget);
            if (card != null)
                return card;
            List<ClientCard> enemy_monsters = Enemy.GetMonsters();
            enemy_monsters.Sort(CardContainer.CompareCardAttack);
            enemy_monsters.Reverse();
            foreach (ClientCard target in enemy_monsters)
            {
                if (target.HasType(CardType.Fusion) || target.HasType(CardType.Ritual) || target.HasType(CardType.Synchro) || target.HasType(CardType.Xyz) || (target.HasType(CardType.Link) && target.LinkCount >= 2))
                {
                    if (target.IsCode(CardId.Kagari, CardId.Shizuku)) continue;
                    if (!canBeTarget || !(target.IsShouldNotBeTarget() || target.IsShouldNotBeMonsterTarget())) return target;
                }
            }

            return null;
        }

        public ClientCard GetBestEnemyCard_random()
        {
            // monsters
            ClientCard card = Util.GetProblematicEnemyMonster(0, true);
            if (card != null)
                return card;
            if (Util.GetOneEnemyBetterThanMyBest() != null)
            {
                card = Enemy.MonsterZone.GetHighestAttackMonster(true);
                if (card != null)
                    return card;
            }

            // spells
            List<ClientCard> enemy_spells = Enemy.GetSpells();
            RandomSort(enemy_spells);
            foreach (ClientCard sp in enemy_spells)
            {
                if (sp.IsFaceup() && !sp.IsDisabled()) return sp;
            }
            if (enemy_spells.Count > 0) return enemy_spells[0];

            List<ClientCard> monsters = Enemy.GetMonsters();
            if (monsters.Count > 0)
            {
                RandomSort(monsters);
                return monsters[0];
            }

            return null;
        }
        public void RandomSort(List<ClientCard> list)
        {

            int n = list.Count;
            while (n-- > 1)
            {
                int index = Program.Rand.Next(n + 1);
                ClientCard temp = list[index];
                list[index] = list[n];
                list[n] = temp;
            }
        }

        private bool OtherSpellEffect()
        {
            if (Enemy.GetSpellCount()==0)
                return false;
            ClientCard target = GetProblematicEnemyCard_Alter(true);
            AI.SelectCard(target);
            return Card.IsSpell() && Program.Rand.Next(9) >= 3 && DefaultDontChainMyself();
        }

        private bool OtherTrapEffect()
        {
            ClientCard target = GetProblematicEnemyCard_Alter(true);
            AI.SelectCard(target);
            return Card.IsTrap() && Program.Rand.Next(9) >= 3 && DefaultTrap() && DefaultDontChainMyself();
        }

        private bool OtherMonsterEffect()
        {
            ClientCard target = GetProblematicEnemyCard_Alter(true);
            AI.SelectCard(target);
            return Card.IsMonster() && Program.Rand.Next(9) >= 3 && DefaultDontChainMyself();
        }

        private bool ImFeelingUnlucky()
        {
            return DefaultDontChainMyself();
        }
    }
}
