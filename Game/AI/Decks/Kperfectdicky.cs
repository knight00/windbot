using System;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
using YGOSharp.OCGWrapper.Enums;

namespace WindBot.Game.AI.Decks
{
    [Deck("AI_perfectdicky", "AI_perfectdicky")]
    class KperfectdickyExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int TreasureDraw = 511001126;
            public const int Oricha = 12201;
            public const int Costdown = 23265313;
            public const int DoubleSummon = 43422537;
            public const int CrossSacriface = 68005187;
        }

        public KperfectdickyExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            AddExecutor(ExecutorType.Activate, CardId.Costdown, Costdown);
            AddExecutor(ExecutorType.Activate, CardId.CrossSacriface, CrossSacriface);
            AddExecutor(ExecutorType.Activate, CardId.DoubleSummon, DoubleSummon);
            AddExecutor(ExecutorType.Activate, CardId.Oricha, Oricha);

            AddExecutor(ExecutorType.SpSummon);
            AddExecutor(ExecutorType.Activate, () => !Card.IsCode(CardId.TreasureDraw, CardId.Costdown, CardId.CrossSacriface, CardId.DoubleSummon, CardId.Oricha) && DefaultDontChainMyself());
            AddExecutor(ExecutorType.SummonOrSet, Advancesummon);
            // Reposition
            AddExecutor(ExecutorType.Repos, MonsterRepos);
            AddExecutor(ExecutorType.SpellSet, Spellset);

            AddExecutor(ExecutorType.Activate, CardId.TreasureDraw, TreasureDraw);
        }

        private int CrossSacrifaceCount = 0;

        public override void OnNewTurn()
        {
            CrossSacrifaceCount = 0;
        }

        public override CardPosition OnSelectPosition(int cardId, IList<CardPosition> positions)
        {
            YGOSharp.OCGWrapper.NamedCard cardData = YGOSharp.OCGWrapper.NamedCard.Get(cardId);
            if (cardData != null)
            {
                if (Util.IsAllEnemyBetterThanValue(cardData.Attack, true) && !cardData.HasType(CardType.Xyz))
                    return CardPosition.FaceUpDefence;
                return CardPosition.FaceUpAttack;
            }
            return 0;
        }

        public override bool OnSelectYesNo(long desc)
        {
            if ((desc == Util.GetStringId(826, 12) && Duel.Player == 1) || desc == Util.GetStringId(13712, 0))
                return false;
            if (desc == 210) // Continue selecting? (Link Summoning)
                return false;
            if (desc == 31) // Direct Attack?
                return true;
            return base.OnSelectYesNo(desc);
        }

        public override IList<ClientCard> OnSelectCard(IList<ClientCard> cards, int min, int max, long hint, bool cancelable)
        {
            if (Duel.Phase == DuelPhase.BattleStart)
                return null;

            IList<ClientCard> selected = new List<ClientCard>();
            selected.Remove(Card);

            // select the last cards
            for (int i = 1; i <= max; ++i)
                selected.Add(cards[cards.Count - i]);

            return selected;
        }

        public override int OnAnnounceCard()
        {
            ClientCard last_card = Util.GetLastChainCard();
            ClientCard orica = Bot.GetFieldSpellCard();
            if (orica == null)
                return 12201;
            return 13701;
        }

        public override int OnAnnounceNumber(IList<int> numbers)
        {
            return numbers.Count > 1 ? numbers.Count - 1 : 0;
        }

        public override int OnSelectOption(IList<long> options)
        {
            if (options[0] == Util.GetStringId(826, 15)) return 0;
            return options.Count > 1 ? options.Count - 1 : 0;
        }

        public override int OnSelectPlace(long cardId, int player, CardLocation location, int available)
        {
            if (location == CardLocation.MonsterZone)
            {
                return available & ~Bot.GetLinkedZones();
            }
            return 0;
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
                if (!OnPreBattleBetween(attacker, defender))
                    continue;
                if (attacker.RealPower >= defender.RealPower || (attacker.RealPower >= defender.RealPower && ((attacker.HasSetcode(0x48) && !attacker.IsDisabled() && !(defender.HasSetcode(0x48) && !defender.IsDisabled())) || attacker.IsLastAttacker && defender.IsAttack())))
                    return AI.Attack(attacker, defender);
            }
            if (Enemy.GetMonsterCount() == 0 || attacker.CanDirectAttack)
                return AI.Attack(attacker, null);
            return null;
        }

        private bool Advancesummon()
        {
            if (Card.Level > 4 && DefaultTributeSummon() && (Bot.MonsterZone.GetMonsters().GetMatchingCardsCount(card => card.Level > 0 || card.IsDisabled() || (card.Attack == 0 && card.BaseAttack > 0)) > 0 || Bot.SpellZone.GetMonsters().GetMatchingCardsCount(card => card.Level > 0 || card.IsDisabled() || (card.Attack == 0 && card.BaseAttack > 0)) > 0))
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
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
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
            if (ActivateDescription == Util.GetStringId(12744567, 0) || (ActivateDescription == -1 && !(Card.HasXyzMaterial(1, 12))))
            {
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
            return Bot.Hand.GetMatchingCardsCount(card => card.Level > 10) > 1;
        }

        private bool CrossSacriface()
        {
            if (Duel.Turn > 1 && Bot.Hand.GetMatchingCardsCount(card => card.Level > 4) > 0 && Enemy.GetMonsterCount() > 0 && CrossSacrifaceCount == 0)
            {
                AI.SelectCard(Enemy.GetMonsters());
                CrossSacrifaceCount++;
                return true;
            }
            return false;
        }

        private bool DoubleSummon()
        {
            return Bot.Hand.GetMatchingCardsCount(card => card.HasType(CardType.Monster)) > 0;
        }

        private bool TreasureDraw()
        {
            if (6 - Bot.GetHandCount() > 0 && Bot.Deck.Count <= 6 - Bot.GetHandCount())
                return false;
            return true;
        }
    }
}
