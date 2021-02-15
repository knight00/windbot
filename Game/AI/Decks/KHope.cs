using System;
using System.Collections.Generic;
using System.Linq;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
using YGOSharp.OCGWrapper.Enums;

namespace WindBot.Game.AI.Decks
{
    [Deck("AI_Hope", "AI_Hope")]
    class KHopeExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int StarDrawing = 24610207;
            public const int Goblindbergh = 25259669;
            public const int Honest = 37742478;
            public const int GagagaLeader = 511015114;
            public const int GagagaMagician = 511013003;
            public const int GagagaGuard = 12423762;
            public const int GagagaKing = 511013027;
            public const int Dondondon = 59724555;
            public const int UtopiaMini = 8512558;
            public const int ZwHorseSword = 32164201;
            public const int ZsAscent = 4647954;
            public const int ZsArmsSage = 68258355;
            public const int ZwTornadoBringer = 266;
            public const int ZwLightningBlade = 264;
            public const int RRRUM = 511001625;
            public const int RRBlur = 511002857;
            public const int RRLoud = 511002676;
            public const int GodPheonix = 824;

            public const int ClosedGod = 98127546;
            public const int Number41 = 90590303;
            public const int Number86 = 63504681;
            public const int Number39Double = 62517849;
            public const int ZwLionArms = 265;
            public const int ZwDragon = 2896663;
            public const int Number39Utopia = 60;
            public const int NumberC39Utopia = 61;
            public const int NumberC39UtopiaVictory = 63;
            public const int NumberS39UtopiaOne = 65;
            public const int NumberS39UtopiatheLightning = 326;
            public const int Number39 = 13719;
            public const int Number99 = 210;
            public const int Number93 = 389;
            public const int FNo0 = 209;
            public const int SNo0 = 364;

            public const int Lightning = 12580477;
            public const int DarkHole = 53129443;
            public const int Feather = 18144507;
            public const int MysticalSpaceTyphoon = 5318639;
            public const int UtopiaRoad = 366;
            public const int SeventhSword = 11370100;
            public const int ZSSP = 100000168;
            public const int XYZTreasure = 100000239;
            public const int TreasureDraw = 511001126;
            public const int XyzChangeTactics = 11705261;
            public const int ZWTrust = 4017398;
            public const int OverlayRebirth = 511001765;
            public const int OverlayReborn = 511001632;
            public const int HRUM = 511000209;
            public const int WRUM = 13734;
            public const int ZWRUM = 36224040;
            public const int ThousandRUM = 511015134;
            public const int GetRUM = 810000033;
            public const int DoubleChance = 94770493;
            public const int CRUM = 511001426;
            public const int SpiderRUM = 100000581;
            public const int RUMAdv = 111011802;
            public const int RankGazer = 390;
            public const int Costdown = 609;
            public const int DoubleSummon = 43422537;
            public const int CrossSacriface = 26;
            public const int Numeronlead = 13707;
            public const int ZWBuild = 62623659;
            public const int HopePlace = 26493435;
            public const int Oricha = 12201;
        }

        public KHopeExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            AddExecutor(ExecutorType.SpSummon, CardId.ClosedGod, Summonplace);
            AddExecutor(ExecutorType.SpSummon, CardId.ZsAscent, Summonplace);
            AddExecutor(ExecutorType.SpSummon, CardId.ZsArmsSage, Summonplace);
            AddExecutor(ExecutorType.SpSummon, CardId.ZwHorseSword, Summonplace);
            AddExecutor(ExecutorType.Summon, CardId.Goblindbergh, GoblindberghFirst);
            AddExecutor(ExecutorType.Summon, CardId.UtopiaMini, Summonplace);
            AddExecutor(ExecutorType.Summon, CardId.Dondondon, Summonplace);
            AddExecutor(ExecutorType.Summon, CardId.GagagaLeader, GagagaLeader);
            AddExecutor(ExecutorType.Summon, CardId.StarDrawing, Summonplace);
            AddExecutor(ExecutorType.MonsterSet, CardId.Honest, Honest);
            AddExecutor(ExecutorType.SummonOrSet, CardId.ZwTornadoBringer, () => false);
            AddExecutor(ExecutorType.SummonOrSet, CardId.ZwLightningBlade, () => false);

            IList<int> activatem = new List<int>();
            AddExecutor(ExecutorType.Activate, CardId.Numeronlead, Numeronlead);
            activatem.Add(CardId.Numeronlead);
            AddExecutor(ExecutorType.Activate, CardId.XyzChangeTactics, XyzChangeTactics);
            activatem.Add(CardId.XyzChangeTactics);
            AddExecutor(ExecutorType.Activate, CardId.CrossSacriface, CrossSacriface);
            activatem.Add(CardId.CrossSacriface);
            AddExecutor(ExecutorType.Activate, CardId.DoubleSummon, DoubleSummon);
            activatem.Add(CardId.DoubleSummon);
            AddExecutor(ExecutorType.Activate, CardId.Goblindbergh, GoblindberghEffect);
            activatem.Add(CardId.Goblindbergh);
            AddExecutor(ExecutorType.Activate, CardId.GagagaGuard, GagagaGuardEffect);
            activatem.Add(CardId.GagagaGuard);
            AddExecutor(ExecutorType.Activate, CardId.GagagaMagician, GagagaMagicianEffect);
            activatem.Add(CardId.GagagaMagician);
            AddExecutor(ExecutorType.Activate, CardId.GagagaKing, GagagaKingEffect);
            activatem.Add(CardId.GagagaKing);
            AddExecutor(ExecutorType.Activate, CardId.Honest, DefaultHonestEffect);
            activatem.Add(CardId.Honest);
            AddExecutor(ExecutorType.Activate, CardId.MysticalSpaceTyphoon, DefaultMysticalSpaceTyphoon);
            activatem.Add(CardId.MysticalSpaceTyphoon);
            AddExecutor(ExecutorType.Activate, CardId.DarkHole, DefaultDarkHole);
            activatem.Add(CardId.DarkHole);

            AddExecutor(ExecutorType.SpSummon, CardId.Number39Double, Number39UtopiaDouble);
            AddExecutor(ExecutorType.SpSummon, CardId.Number39Utopia, Summonplace);
            AddExecutor(ExecutorType.SpSummon, CardId.NumberS39UtopiaOne, NumberS39UtopiaOne);
            AddExecutor(ExecutorType.Activate, CardId.NumberS39UtopiaOne, NumberS39UtopiaOneEffects);
            activatem.Add(CardId.NumberS39UtopiaOne);
            AddExecutor(ExecutorType.SpSummon, CardId.NumberS39UtopiatheLightning, NumberS39UtopiatheLightning);
            AddExecutor(ExecutorType.SpSummon, CardId.Number39, Summonplace);
            AddExecutor(ExecutorType.SpSummon, CardId.Number41, Summonplace);
            AddExecutor(ExecutorType.SpSummon, CardId.Number86, Summonplace);
            AddExecutor(ExecutorType.SpSummon, CardId.SNo0, SNo0);
            AddExecutor(ExecutorType.SpSummon, CardId.ZwDragon, Summonplace);
            AddExecutor(ExecutorType.SpSummon, CardId.ZwLionArms, Summonplace);

            AddExecutor(ExecutorType.Activate, CardId.Number39Double, Number39UtopiaDoubleEffects);
            AddExecutor(ExecutorType.Activate, CardId.NumberS39UtopiatheLightning, DefaultNumberS39UtopiaTheLightningEffect);
            activatem.Add(CardId.NumberS39UtopiatheLightning);
            AddExecutor(ExecutorType.Activate, CardId.ZwLionArms, ZwLionArms);
            activatem.Add(CardId.ZwLionArms);
            AddExecutor(ExecutorType.Activate, CardId.ZwTornadoBringer, ZwWeapon);
            activatem.Add(CardId.ZwTornadoBringer);
            AddExecutor(ExecutorType.Activate, CardId.ZwLightningBlade, ZwWeapon);
            activatem.Add(CardId.ZwLightningBlade);

            AddExecutor(ExecutorType.Activate, CardId.Oricha, Oricha);
            activatem.Add(CardId.Oricha);
            AddExecutor(ExecutorType.Summon, CardId.GodPheonix, GodPheonix);
            AddExecutor(ExecutorType.Activate, CardId.GodPheonix, GodPheonixEffects);
            activatem.Add(CardId.GodPheonix);

            AddExecutor(ExecutorType.SpSummon, () => Summonplace() && !Card.HasType(CardType.Xyz));
            AddExecutor(ExecutorType.Activate, () => !Card.IsCode(activatem) && DefaultDontChainMyself());
            AddExecutor(ExecutorType.Summon, Advancesummon);
            AddExecutor(ExecutorType.MonsterSet, Advancesummon);
            AddExecutor(ExecutorType.Repos, MonsterRepos);
            AddExecutor(ExecutorType.SpellSet, Spellset);

            AddExecutor(ExecutorType.Activate, CardId.TreasureDraw, TreasureDraw);
        }

        private int ZwCount = 0;
        private int UtopiaCount = 0;
        private int CrossSacrifaceCount = 0;

        public override void OnNewTurn()
        {
            ZwCount = 0;
            UtopiaCount = 0;
            CrossSacrifaceCount = 0;
        }

        public override CardPosition OnSelectPosition(int cardId, IList<CardPosition> positions)
        {
            YGOSharp.OCGWrapper.NamedCard cardData = YGOSharp.OCGWrapper.NamedCard.Get(cardId);
            if (cardData != null)
            {
                if (Util.IsAllEnemyBetterThanValue(cardData.Attack, true) && !Card.HasType(CardType.Xyz))
                    return CardPosition.FaceUpDefence;
                return CardPosition.FaceUpAttack;
            }
            return 0;
        }

        public override bool OnSelectYesNo(long desc)
        {
            if ((desc == Util.GetStringId(826, 12) && Duel.Player == 1) || desc == Util.GetStringId(13712, 0))
                return false;
            return base.OnSelectYesNo(desc);
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
                        && (Bot.GetMonsters().GetMatchingCardsCount(card => card.IsAttack() && card.HasSetcode(0x14b)) > 0 && (attacker.HasXyzMaterial() || (Bot.GetFieldSpellCard().IsFaceup() && !Bot.GetFieldSpellCard().IsDisabled() && Bot.GetFieldSpellCard().IsCode(12201, 13706)))
                        || Bot.SpellZone.GetMatchingCardsCount(card => card.IsAttack() && card.HasSetcode(0x14b)) > 0 && (attacker.HasXyzMaterial() || (Bot.GetFieldSpellCard().IsFaceup() && !Bot.GetFieldSpellCard().IsDisabled() && Bot.GetFieldSpellCard().IsCode(12201, 13706)))))
                    {
                        att.Remove(attacker); att.Add(attacker); attackers.Remove(attacker); attackers.Add(attacker);
                    }
                }
                for (int i = 0; i < attackers.Count; i++)
                {
                    ClientCard attacker = attackers[i];
                    if ((attacker.IsCode(13702) || attacker.IsCode(13703) || attacker.IsCode(13704)) && !attacker.IsDisabled()
                        && Bot.GetMonsters().GetMatchingCardsCount(card => card.IsAttack() && card.HasSetcode(0x14b)) > 0 && (attacker.HasXyzMaterial() || (Bot.GetFieldSpellCard().IsFaceup() && !Bot.GetFieldSpellCard().IsDisabled() && Bot.GetFieldSpellCard().IsCode(12201, 13706)))
                        || (Bot.SpellZone.GetMatchingCardsCount(card => card.IsAttack() && card.HasSetcode(0x14b)) > 0 && (attacker.HasXyzMaterial() || (Bot.GetFieldSpellCard().IsFaceup() && !Bot.GetFieldSpellCard().IsDisabled() && Bot.GetFieldSpellCard().IsCode(12201, 13706)))))
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
                if (attacker.IsCode(13701) && attacker.RealPower < defender.RealPower && Bot.LifePoints > defender.RealPower - attacker.RealPower && Bot.HasInHand(13717) && Bot.HasInExtra(13715) && Bot.Graveyard.GetMatchingCardsCount(card => card.HasSetcode(0x48) || card.IsCode(12201, 13706)) + Bot.Banished.GetMatchingCardsCount(card => (card.HasSetcode(0x48) || card.IsCode(12201, 13706)) && card.IsFaceup()) > 4)
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

        private bool GodPheonix()
        {
            if (Card.Controller == 0)
                AI.SelectOption(0);
            else AI.SelectOption(1);
            return true;
        }
        private bool GodPheonixEffects()
        {
            if (ActivateDescription == Util.GetStringId(824, 0))
                return false;
            return true;
        }

        private bool ZwLionArms()
        {
            if (ActivateDescription == Util.GetStringId(CardId.ZwLionArms, 0))
                return true;
            if (ActivateDescription == Util.GetStringId(CardId.ZwLionArms, 1))
                return !Card.IsDisabled() && ZwWeapon();
            return false;
        }

        private bool ZwWeapon()
        {
            ZwCount++;
            return true;
        }

        private bool Number39UtopiaDouble()
        {
            if (Duel.Player == 0 && Bot.ExtraDeck.ContainsCardWithId(CardId.Number39Utopia) && Bot.GetRemainingCount(CardId.DoubleChance, 2) > 0)
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }

        private bool Number39UtopiaDoubleEffects()
        {
            if (Bot.MonsterZone.GetMonsters().GetMatchingCardsCount(card => card.Id == CardId.Number39) + Bot.SpellZone.GetMonsters().GetMatchingCardsCount(card => card.Id == CardId.Number39) == 0)
                AI.SelectAnnounceID(CardId.Number39);
            AI.SelectAnnounceID(CardId.Number39Utopia);
            return true;
        }

        private bool Number39UtopiaEffects()
        {
            if (Util.ChainContainsCard(CardId.Number39Utopia))
                return false;
            if (Duel.Player == 1
                || (Bot.BattlingMonster == Card && (Bot.HasInHand(CardId.DoubleChance) || Bot.Deck.ContainsCardWithId(CardId.DoubleChance))))
            {
                if (Duel.Player == 1) return true;
                else
                {
                    UtopiaCount++;
                    return UtopiaCount < 2;
                }
            }
            return false;
        }

        private bool NumberS39UtopiaOne()
        {
            if (Bot.MonsterZone.GetMatchingCardsCount(card => card.Id == CardId.Number39Utopia && card.IsFaceup() && card.Attack < 5000 && !card.HasXyzMaterial()) + Bot.SpellZone.GetMatchingCardsCount(card => card.Id == CardId.Number39Utopia && card.IsFaceup() && card.Attack < 5000 && !card.HasXyzMaterial()) > 0 && !Bot.HasInHand(CardId.DoubleChance))
            {
                IList<ClientCard> Xyzmat = Bot.MonsterZone.GetMatchingCards(card => card.Id == CardId.Number39Utopia && card.IsFaceup() && card.Attack < 5000 && !card.HasXyzMaterial());
                IList<ClientCard> Xyzmat2 = Bot.SpellZone.GetMatchingCards(card => card.Id == CardId.Number39Utopia && card.IsFaceup() && card.Attack < 5000 && !card.HasXyzMaterial());
                foreach (ClientCard monster in Xyzmat2)
                    Xyzmat.Add(monster);
                AI.SelectCard(Xyzmat);
                return true;
            }
            return false;
        }

        private bool NumberS39UtopiaOneEffects()
        {
            int atk = 0;
            for (int i = 0; i < 7; ++i)
            {
                if (Enemy.MonsterZone[i] != null && Enemy.MonsterZone[i].RealPower > 0 && Enemy.MonsterZone[i].IsFaceup())
                    atk += atk;
            }
            return atk >= Enemy.LifePoints && Bot.LifePoints <= 3000;
        }

        private bool NumberS39UtopiatheLightning()
        {
            if ((Bot.MonsterZone.GetMatchingCardsCount(card => card.Id == CardId.Number39Utopia && card.IsFaceup() && card.Attack < 5000 && !card.HasXyzMaterial()) + Bot.SpellZone.GetMatchingCardsCount(card => card.Id == CardId.Number39Utopia && card.IsFaceup() && card.Attack < 5000 && !card.HasXyzMaterial()) > 0 && Bot.HasInHand(CardId.DoubleChance))
                || (Bot.MonsterZone.GetMatchingCardsCount(card => card.Id == CardId.NumberS39UtopiaOne && card.IsFaceup()) + Bot.SpellZone.GetMatchingCardsCount(card => card.Id == CardId.NumberS39UtopiaOne && card.IsFaceup()) > 0))
            {
                IList<ClientCard> Xyzmat = Bot.MonsterZone.GetMatchingCards(card => card.Id == CardId.Number39Utopia && card.IsFaceup() && card.Attack < 5000 && !card.HasXyzMaterial());
                IList<ClientCard> Xyzmat2 = Bot.SpellZone.GetMatchingCards(card => card.Id == CardId.Number39Utopia && card.IsFaceup() && card.Attack < 5000 && !card.HasXyzMaterial());
                IList<ClientCard> Xyzmat3 = Bot.MonsterZone.GetMatchingCards(card => card.Id == CardId.NumberS39UtopiaOne && card.IsFaceup());
                IList<ClientCard> Xyzmat4 = Bot.SpellZone.GetMatchingCards(card => card.Id == CardId.NumberS39UtopiaOne && card.IsFaceup());
                foreach (ClientCard monster in Xyzmat2)
                    Xyzmat.Add(monster);
                foreach (ClientCard monster in Xyzmat3)
                    Xyzmat.Add(monster);
                foreach (ClientCard monster in Xyzmat4)
                    Xyzmat.Add(monster);
                AI.SelectCard(Xyzmat);
                return true;
            }
            return false;
        }

        private bool NumberC39Utopia()
        {
            if (Bot.LifePoints <= 1000 || Bot.Graveyard.GetMatchingCardsCount(card => card.HasSetcode(0x48)) > 2 && Bot.HasInHand(366))
                return true;
            return false;
        }

        private bool Number39Effects()
        {
            if ((Duel.Phase != DuelPhase.Main2 && Duel.Phase != DuelPhase.Battle) || Duel.Player != 0)
                return false;
            int atk = 0;
            if (Bot.MonsterZone.GetMatchingCardsCount(card => card.HasType(CardType.Xyz) && (card.IsFacedown() || card.Attack < 3000)) + Bot.SpellZone.GetMatchingCardsCount(card => card.HasType(CardType.Xyz) && (card.IsFacedown() || card.Attack < 3000)) > 0)
            {
                IList<ClientCard> Xyzmat = Bot.MonsterZone.GetMatchingCards(card => card.HasType(CardType.Xyz) && (card.IsFacedown() || card.Attack < 3000));
                IList<ClientCard> Xyzmat2 = Bot.SpellZone.GetMatchingCards(card => card.HasType(CardType.Xyz) && (card.IsFacedown() || card.Attack < 3000));
                foreach (ClientCard monster in Xyzmat2)
                    Xyzmat.Add(monster);
                AI.SelectCard(Xyzmat);
            }
            return atk >= Enemy.LifePoints && Bot.LifePoints <= 3000;
        }

        private bool FNo0()
        {
            if (Util.ChainContainPlayer(1) && Duel.Player == 1)
                return true;
            return false;
        }

        private bool SNo0()
        {
            if (Bot.MonsterZone.GetMatchingCardsCount(card => card.HasSetcode(0x107f) && card.IsFaceup() && card.HasXyzMaterial(3)) + Bot.SpellZone.GetMatchingCardsCount(card=>card.HasSetcode(0x107f) && card.IsFaceup() && card.HasXyzMaterial(3)) > 0)
            {
                List<ClientCard> Xyzmat = new List<ClientCard>();
                IList <ClientCard> Xyzmat1 = Bot.MonsterZone.GetMatchingCards(card => card.HasSetcode(0x107f) && card.IsFaceup() && card.HasXyzMaterial(3));
                IList<ClientCard> Xyzmat2 = Bot.SpellZone.GetMatchingCards(card => card.HasSetcode(0x107f) && card.IsFaceup() && card.HasXyzMaterial(3));
                foreach (ClientCard monster in Xyzmat1)
                    Xyzmat.Add(monster);
                foreach (ClientCard monster in Xyzmat2)
                    Xyzmat.Add(monster);
                Xyzmat.Sort(CardContainer.CompareCardAttack);
                AI.SelectCard(Xyzmat);
                return true;
            }
            return false;
        }

        private bool Number41()
        {
            if (Util.IsAllEnemyBetter())
                return true;
            return false;
        }

        private bool Number100DragonEffects()
        {
            if (Duel.Player == 0)
                return true;
            else
                return Card.IsFaceup() && Bot.UnderAttack && Bot.BattlingMonster == Card;
        }

        private bool Number6Effects()
        {
            if (ActivateDescription == -1 || ActivateDescription == Util.GetStringId(9161357, 0))
            {
                IList<ClientCard> targets = Bot.Graveyard.GetMatchingCards(card => card.HasSetcode(0x48));
                IList<ClientCard> equiptg = new List<ClientCard>();
                foreach (ClientCard target in targets)
                {
                    if (targets.Count >= 1)
                        break;
                    if (target.Attack == targets.GetHighestAttackMonster(true).Attack)
                    {
                        equiptg.Add(target);
                        break;
                    }
                    equiptg.Add(target);
                }
                if (targets.Count == 0)
                    return false;
                AI.SelectCard(targets);
                return true;
            }
            return true;
        }

        private bool Abyss()
        {
            return Duel.Player == 0 || Duel.Turn > 1;
        }

        private bool Number61Volcasaurus()
        {
            return Util.IsOneEnemyBetterThanValue(2000, false);
        }

        private bool Zwhorse()
        {
            return (Card.Location != CardLocation.SpellZone && ZwWeapon()) || (Enemy.BattlingMonster != null && Enemy.BattlingMonster.IsFaceup() && Enemy.BattlingMonster.RealPower > Card.RealPower);
        }

        private bool DoubleChance()
        {
            if (!Util.ChainContainsCard(CardId.DoubleChance) && ((Bot.BattlingMonster.IsAttack() && (Bot.BattlingMonster?.RealPower * 2 > Enemy.BattlingMonster?.RealPower || Bot.BattlingMonster.CanDirectAttack || Enemy.GetMonsterCount() == 0) && Enemy.UnderAttack)))
            {
                return true;
            }
            return false;
        }

        private bool Reservation()
        {
            if (Bot.Hand.GetMatchingCardsCount(card => card.HasType(CardType.QuickPlay)) > 0)
                return true;
            return false;
        }

        private bool WRUM()
        {
            if (ActivateDescription != -1)
            {
                if (ActivateDescription == Util.GetStringId(13717, 7))
                    return false;
                if (ActivateDescription == Util.GetStringId(13714, 13))
                {
                    IList<ClientCard> targets = Bot.MonsterZone.GetMatchingCards(card => card.IsFaceup() && card.HasSetcode(0x7f));
                    IList<ClientCard> utopia = new List<ClientCard>();
                    foreach (ClientCard target in targets)
                    {
                        if (targets.Count >= 1)
                            break;
                        if (target.Rank == 4)
                        {
                            utopia.Add(target);
                            break;
                        }
                        utopia.Add(target);
                    }
                    if (targets.Count == 0)
                        return false;
                    AI.SelectCard(targets);
                    int opt1 = 2, opt2 = 4;
                    if (targets.ContainsMonsterWithRank(4))
                    {
                        opt1 -= 1; opt2 -= 1;
                        if (!(!Bot.HasInExtra(62) && !Bot.HasInMonstersZoneOrInGraveyard(62) && !Bot.HasInBanished(62)))
                        { opt1 -= 1; opt2 -= 1; }
                        if (!(!Bot.HasInExtra(326) && !Bot.HasInMonstersZoneOrInGraveyard(326) && !Bot.HasInBanished(326)))
                            opt2 -= 1;
                    }
                    else
                    {
                        if (!(!Bot.HasInExtra(61) && !Bot.HasInMonstersZoneOrInGraveyard(61) && !Bot.HasInBanished(61)))
                        { opt1 -= 1; opt2 -= 1; }
                        if (!(!Bot.HasInExtra(62) && !Bot.HasInMonstersZoneOrInGraveyard(62) && !Bot.HasInBanished(62)))
                        { opt1 -= 1; opt2 -= 1; }
                    }
                    return true;
                }
            }
            return true;
        }

        private bool GagagaLeader()
        {
            if (Bot.Graveyard.GetMatchingCardsCount(card => card.HasSetcode(0x54) && card.HasType(CardType.Monster)) > 1)
                return true;
            if (Bot.Graveyard.GetMatchingCardsCount(card => card.HasSetcode(0x54) && card.HasType(CardType.Monster)) + Bot.MonsterZone.GetMatchingCardsCount(card => card.HasSetcode(0x54) && card.HasType(CardType.Monster)) + Bot.SpellZone.GetMatchingCardsCount(card => card.HasSetcode(0x54) && card.HasType(CardType.Monster)) > 1)
            {
                IList<ClientCard> Gagagatemp = Bot.MonsterZone.GetMatchingCards(card => card.HasSetcode(0x54) && card.HasType(CardType.Monster));
                IList<ClientCard> Gagaga = Bot.SpellZone.GetMatchingCards(card => card.HasSetcode(0x54) && card.HasType(CardType.Monster));
                foreach (ClientCard monster in Gagagatemp)
                {
                    Gagaga.Add(monster);
                }
                AI.SelectCard(Gagaga);
                return true;
            }
            return false;
        }

        private bool Honest() {
            if (Bot.MonsterZone.GetMonsters().Count() + Bot.SpellZone.GetMonsters().Count() == 0)
                return true;
            return false;
        }

        private bool XyzChangeTactics()
        {
            return Bot.LifePoints > 500;
        }

        private bool GoblindberghFirst()
        {
            foreach (ClientCard card in Bot.Hand.GetMonsters())
            {
                if (!card.Equals(Card) && card.Level == 4)
                    return true;
            }
            return false;
        }
        private bool GoblindberghEffect()
        {
            AI.SelectCard(
                CardId.UtopiaMini,
                CardId.Dondondon,
                CardId.RRRUM,
                CardId.StarDrawing,
                CardId.GagagaKing
                );
            return true;
        }

        private bool GagagaGuardEffect()
        {
            if(Util.GetTotalAttackingMonsterAttack(1)>Bot.LifePoints)
                return true;
            return false;
        }
  
        private bool GagagaMagicianEffect()
        {
            if (Bot.MonsterZone.GetMatchingCardsCount(card => card.Level != 4 && card.Level >0 && card.Position != (int)CardPosition.FaceUp && card.IsFaceup()) > 0)
            {
                IList<ClientCard> Gagaga = Bot.MonsterZone.GetMatchingCards(card => card.Level != 4 && card.Level > 0 && card.Position != (int)CardPosition.FaceUp && card.IsFaceup());
                IList<ClientCard> Gagaga2 = Bot.SpellZone.GetMatchingCards(card => card.Level != 4 && card.Level > 0 && card.Position != (int)CardPosition.FaceUp && card.IsFaceup());
                foreach (ClientCard monster in Gagaga2)
                {
                    Gagaga.Add(monster);
                }
                AI.SelectNumber(Gagaga[0].Level);
                return true;
            }
            return false;
        }

        private bool GagagaKingEffect()
        {
            if (Bot.MonsterZone.GetMatchingCardsCount(card => card.Level != Card.Level && card.Level > 0 && card.Position != (int)CardPosition.FaceUp && card.IsFaceup()) > 0)
            {
                IList<ClientCard> Gagaga = Bot.MonsterZone.GetMatchingCards(card => card.Level != Card.Level && card.Level > 0 && card.Position != (int)CardPosition.FaceUp && card.IsFaceup());
                IList<ClientCard> Gagaga2 = Bot.SpellZone.GetMatchingCards(card => card.Level != Card.Level && card.Level > 0 && card.Position != (int)CardPosition.FaceUp && card.IsFaceup());
                foreach (ClientCard monster in Gagaga2)
                {
                    Gagaga.Add(monster);
                }
                foreach (ClientCard monster in Gagaga)
                {
                    foreach (ClientCard lvmonster in Bot.Graveyard.GetMatchingCards(card => card.Level > 0))
                    {
                        if (lvmonster.Level == monster.Level)
                        {
                            AI.SelectCard(lvmonster);
                            return true;
                        }
                    }
                }
            }
            return false;
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
                if (!(Card.HasXyzMaterial(1, 13706)))
                {
                    AI.SelectAnnounceID(13706);
                    return true;
                }
                if (!(Card.HasXyzMaterial(1, 160000107)))
                {
                    AI.SelectAnnounceID(160000107);
                    return true;
                }
                if (!(Card.HasXyzMaterial(1, 26493435)))
                {
                    AI.SelectAnnounceID(26493435);
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
                if (!(Card.HasXyzMaterial(1, 511001271)))
                {
                    AI.SelectAnnounceID(511001271);
                    return true;
                }
                AI.SelectAnnounceID(11);
                return true;
            }

            if (Duel.Player == 0 && Duel.Phase == DuelPhase.Main1 && Bot.Deck.ContainsCardWithId(CardId.Numeronlead) && (ActivateDescription == Util.GetStringId(41418852, 0) || ActivateDescription == -1))
            {
                AI.SelectCard(CardId.Numeronlead, 595, 588, 597, 13717, 13708, 13709, 13710, 13713, 596);
                AI.SelectAnnounceID(13701);
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

        private bool Numeronlead()
        {
            AI.SelectAnnounceID(13701);
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
