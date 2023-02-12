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
            public const int GagagaLeader = 511015114;
            public const int GagagaMagician = 511013003;
            public const int GagagaGuard = 12423762;
            public const int GagagaKing = 511013027;
            public const int Dondondon = 59724555;
            public const int UtopiaMini = 8512558;
            public const int ZwHorseSword = 32164201;
            public const int ZsAscent = 503;
            public const int ZsArmsSage = 505;
            public const int ZwTornadoBringer = 266;
            public const int ZwLightningBlade = 264;
            public const int Astralball = 501;
            public const int Astralhope = 502;
            public const int RRRUM = 511001625;
            public const int RRBlur = 511002857;
            public const int RRLoud = 511002676;
            public const int GodPheonix = 824;
            public const int NoEvo = 511001611;

            public const int ClosedGod = 98127546;
            public const int Number86 = 63504681;
            public const int Number39Double = 62517849;
            public const int ZwLionArms = 265;
            public const int ZwDragon = 2896663;
            public const int Number39Utopia = 60;
            public const int NumberC39Utopia = 61;
            public const int NumberC39UtopiaVictory = 63;
            public const int NumberS39UtopiaOne = 65;
            public const int NumberS39UtopiatheLightning = 326;
            public const int Number6 = 511002090;
            public const int Number39 = 13719;
            public const int Number99 = 210;
            public const int Number93 = 389;
            public const int NumberN99 = 110;
            public const int Number100 = 13714;
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
            public const int HRUM = 109;
            public const int WRUM = 13734;
            public const int ZWRUM = 36224040;
            public const int RDM = 87;
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
            public const int Cyclone = 5318639;

            public const int Anti_Spell = 58921041;
            public const int ImperialOrder = 61740673;
            public const int Kagari = 63288573;
            public const int Shizuku = 90673288;
        }

        public KHopeExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            IList<int> activatem = new List<int>();
            IList<int> spsummonm = new List<int>();

            AddExecutor(ExecutorType.Activate, CardId.SeventhSword);
            activatem.Add(CardId.SeventhSword);
            AddExecutor(ExecutorType.Activate, 98);
            activatem.Add(98);

            AddExecutor(ExecutorType.Activate, _CardId.AshBlossom, Hand_act_eff);
            activatem.Add(_CardId.AshBlossom);
            AddExecutor(ExecutorType.Activate, _CardId.GhostBelle, Hand_act_eff);
            activatem.Add(_CardId.GhostBelle);
            AddExecutor(ExecutorType.Activate, _CardId.GhostOgreAndSnowRabbit, Hand_act_eff);
            activatem.Add(_CardId.GhostOgreAndSnowRabbit);
            AddExecutor(ExecutorType.Activate, _CardId.GR_WC, Hand_act_eff);
            activatem.Add(_CardId.GR_WC);
            AddExecutor(ExecutorType.Activate, 67750322, Hand_act_eff);
            activatem.Add(67750322);
            AddExecutor(ExecutorType.Activate, 18964575, Hand_act_eff);
            activatem.Add(18964575);
            AddExecutor(ExecutorType.Activate, 19665973, Hand_act_eff);
            activatem.Add(19665973);
            AddExecutor(ExecutorType.Activate, 27204311, Hand_act_eff);
            activatem.Add(27204311);
            AddExecutor(ExecutorType.Activate, 55063751, Hand_act_eff);
            activatem.Add(55063751);
            AddExecutor(ExecutorType.Activate, _CardId.EffectVeiler, DefaultEffectVeiler);
            activatem.Add(_CardId.EffectVeiler);

            AddExecutor(ExecutorType.Activate, CardId.DarkHole, DefaultDarkHole);
            activatem.Add(CardId.DarkHole);
            AddExecutor(ExecutorType.SpSummon, CardId.ClosedGod, DefaultMonsterSummon);
            spsummonm.Add(CardId.ClosedGod);
            AddExecutor(ExecutorType.SpSummon, CardId.ZsAscent, DefaultMonsterSummon);
            spsummonm.Add(CardId.ZsAscent);
            AddExecutor(ExecutorType.SpSummon, CardId.ZsArmsSage, DefaultMonsterSummon);
            spsummonm.Add(CardId.ZsArmsSage);
            AddExecutor(ExecutorType.SpSummon, CardId.ZwHorseSword, DefaultMonsterSummon);
            spsummonm.Add(CardId.ZwHorseSword);
            AddExecutor(ExecutorType.Summon, CardId.Goblindbergh, GoblindberghFirst);
            AddExecutor(ExecutorType.Summon, CardId.UtopiaMini, DefaultMonsterSummon);
            AddExecutor(ExecutorType.Summon, CardId.Dondondon, DefaultMonsterSummon);
            AddExecutor(ExecutorType.Summon, CardId.GagagaLeader, GagagaLeader);
            AddExecutor(ExecutorType.Summon, CardId.StarDrawing, DefaultMonsterSummon);
            AddExecutor(ExecutorType.MonsterSet, _CardId.Honest, Honest);
            AddExecutor(ExecutorType.SummonOrSet, CardId.ZwTornadoBringer, () => false);
            AddExecutor(ExecutorType.SummonOrSet, CardId.ZwLightningBlade, () => false);

            AddExecutor(ExecutorType.Activate, CardId.Cyclone, OtherSpellEffect);
            activatem.Add(CardId.Cyclone);        
            AddExecutor(ExecutorType.Activate, CardId.Numeronlead, Numeronlead);
            activatem.Add(CardId.Numeronlead);
            AddExecutor(ExecutorType.Activate, CardId.ZsAscent, ZsAscent);
            activatem.Add(CardId.ZsAscent);
            AddExecutor(ExecutorType.Activate, CardId.ZsArmsSage);
            activatem.Add(CardId.ZsArmsSage);
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
            AddExecutor(ExecutorType.Activate, _CardId.Honest, DefaultHonestEffect);
            activatem.Add(_CardId.Honest);
            AddExecutor(ExecutorType.Activate, CardId.MysticalSpaceTyphoon, DefaultMysticalSpaceTyphoon);
            activatem.Add(CardId.MysticalSpaceTyphoon);

            AddExecutor(ExecutorType.SpSummon, CardId.Astralball, Astralball);
            spsummonm.Add(CardId.Astralball);
            AddExecutor(ExecutorType.Activate, CardId.Astralball, Astralball);
            activatem.Add(CardId.Astralball);
            AddExecutor(ExecutorType.SpSummon, CardId.Astralhope, Astralhope);
            activatem.Add(CardId.Astralhope);
            AddExecutor(ExecutorType.Activate, CardId.Astralhope, Astralhope);
            activatem.Add(CardId.Astralhope);
            AddExecutor(ExecutorType.SpSummon, CardId.Number39Double, Number39UtopiaDouble);
            spsummonm.Add(CardId.Number39Double);
            AddExecutor(ExecutorType.Activate, CardId.Number39Double, Number39UtopiaDoubleEffects);
            activatem.Add(CardId.Number39Double);
            AddExecutor(ExecutorType.Activate, CardId.NumberN99, NumberN99);
            activatem.Add(CardId.NumberN99);
            AddExecutor(ExecutorType.Activate, CardId.Number93, Number93);
            activatem.Add(CardId.Number93);
            spsummonm.Add(CardId.Number93);
            AddExecutor(ExecutorType.Activate, CardId.Number6, Number6);
            activatem.Add(CardId.Number6);
            AddExecutor(ExecutorType.SpSummon, CardId.Number39Utopia, DefaultMonsterSummon);
            spsummonm.Add(CardId.Number39Utopia);
            AddExecutor(ExecutorType.SpSummon, CardId.NumberS39UtopiaOne, NumberS39UtopiaOne);
            spsummonm.Add(CardId.NumberS39UtopiaOne);
            AddExecutor(ExecutorType.Activate, CardId.NumberS39UtopiaOne, NumberS39UtopiaOneEffects);
            activatem.Add(CardId.NumberS39UtopiaOne);
            AddExecutor(ExecutorType.SpSummon, CardId.NumberS39UtopiatheLightning, NumberS39UtopiatheLightning);
            spsummonm.Add(CardId.NumberS39UtopiatheLightning);
            AddExecutor(ExecutorType.SpSummon, CardId.Number39, DefaultMonsterSummon);
            spsummonm.Add(CardId.Number39);
            AddExecutor(ExecutorType.SpSummon, CardId.Number86, DefaultMonsterSummon);
            spsummonm.Add(CardId.Number86);
            AddExecutor(ExecutorType.SpSummon, CardId.SNo0, SNo0);
            spsummonm.Add(CardId.SNo0);
            AddExecutor(ExecutorType.SpSummon, CardId.ZwDragon, DefaultMonsterSummon);
            spsummonm.Add(CardId.ZwDragon);
            AddExecutor(ExecutorType.SpSummon, CardId.ZwLionArms, DefaultMonsterSummon);
            spsummonm.Add(CardId.ZwLionArms);

            AddExecutor(ExecutorType.Activate, CardId.NumberS39UtopiatheLightning, DefaultNumberS39UtopiaTheLightningEffect);
            activatem.Add(CardId.NumberS39UtopiatheLightning);
            AddExecutor(ExecutorType.Activate, CardId.Number39Utopia, Number39UtopiaEffects);
            activatem.Add(CardId.Number39Utopia);
            AddExecutor(ExecutorType.Activate, CardId.ZwLionArms, ZwLionArms);
            activatem.Add(CardId.ZwLionArms);
            AddExecutor(ExecutorType.Activate, CardId.ZwTornadoBringer, ZwWeapon);
            activatem.Add(CardId.ZwTornadoBringer);
            AddExecutor(ExecutorType.Activate, CardId.ZwLightningBlade, ZwWeapon);
            activatem.Add(CardId.ZwLightningBlade);
            AddExecutor(ExecutorType.SpSummon, 723, FNo0_Slash);
            spsummonm.Add(723);
            AddExecutor(ExecutorType.Activate, 723, FNo0_Slash_Effects);
            activatem.Add(723);
            AddExecutor(ExecutorType.Activate, CardId.WRUM, WRUM);
            activatem.Add(CardId.WRUM);
            AddExecutor(ExecutorType.Activate, CardId.HRUM, HRUM);
            activatem.Add(CardId.HRUM);
            AddExecutor(ExecutorType.Activate, CardId.RDM, RDM);
            activatem.Add(CardId.RDM);
            AddExecutor(ExecutorType.SpSummon, CardId.NumberC39Utopia, () => false);
            spsummonm.Add(CardId.NumberC39Utopia);
            AddExecutor(ExecutorType.Activate, CardId.NoEvo, NoEvo);
            activatem.Add(CardId.NoEvo);

            AddExecutor(ExecutorType.Activate, CardId.Oricha, DefaultOrica);
            activatem.Add(CardId.Oricha);
            AddExecutor(ExecutorType.Summon, CardId.GodPheonix, GodPheonix);
            AddExecutor(ExecutorType.Activate, CardId.GodPheonix, GodPheonixEffects);
            activatem.Add(CardId.GodPheonix);

            activatem.Add(CardId.TreasureDraw);
            activatem.Add(157);
            AddExecutor(ExecutorType.SpSummon, ()=> !spsummonm.Contains(Card.Id) && DefaultMonsterSummon());
            AddExecutor(ExecutorType.Activate, ()=>!activatem.Contains(Card.Id) && OtherSpellEffect());
            AddExecutor(ExecutorType.Activate, ()=>!activatem.Contains(Card.Id) && OtherTrapEffect());
            AddExecutor(ExecutorType.Activate, ()=>!activatem.Contains(Card.Id) && OtherMonsterEffect());
            AddExecutor(ExecutorType.Summon, DefaultMonsterSummon);
            AddExecutor(ExecutorType.MonsterSet, DefaultMonsterSummon);
            AddExecutor(ExecutorType.Repos, MonsterRepos);
            AddExecutor(ExecutorType.SpellSet, Spellset);

            AddExecutor(ExecutorType.Activate, CardId.TreasureDraw, TreasureDraw);
        }

        private int ZwCount = 0;
        private int UtopiaCount = 0;
        private int WRUMCount = 0;
        private int CrossSacrifaceCount = 0;

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
            ZwCount = 0;
            UtopiaCount = 0;
            WRUMCount = 0;
            CrossSacrifaceCount = 0;
        }

        public override int OnSelectPlace(long cardId, int player, CardLocation location, int available)
        {
            if (player == 0)
            {
                YGOSharp.OCGWrapper.NamedCard cardData = YGOSharp.OCGWrapper.NamedCard.Get((int)cardId);
                if (cardData != null && (location & CardLocation.SpellZone) == CardLocation.SpellZone)
                {
                    ClientCard field = Bot.GetFieldSpellCard();
                    if (cardData.HasType(CardType.Monster) && field != null && !field.IsDisabled() && (field.HasXyzMaterial(1, 10) || field.IsCode(10)) && available > 0xff)
                    {
                        if ((available & Zones.z3 << 8) > 0)
                            return Zones.z3 << 8;
                        if ((available & Zones.z2 << 8) > 0)
                            return Zones.z2 << 8;
                        if ((available & Zones.z1 << 8) > 0)
                            return Zones.z1 << 8;
                        if ((available & Zones.z4 << 8) > 0)
                            return Zones.z4 << 8;
                        if ((available & Zones.z0 << 8) > 0)
                            return Zones.z0 << 8;
                    }
                    else if (location == CardLocation.SpellZone)
                    {
                        if ((available & Zones.z4) > 0)
                            return Zones.z4;
                        if ((available & Zones.z3) > 0)
                            return Zones.z3;
                        if ((available & Zones.z2) > 0)
                            return Zones.z2;
                        if ((available & Zones.z1) > 0)
                            return Zones.z1;
                        if ((available & Zones.z0) > 0)
                            return Zones.z0;
                    }
                }
                else if (location == CardLocation.MonsterZone)
                {
                    ClientCard card_ex_left = Enemy.MonsterZone[6];
                    ClientCard card_ex_right = Enemy.MonsterZone[5];
                    if (cardData != null && card_ex_left != null && card_ex_left.IsCode(1948619) && cardData.HasSetcode(0x8))
                        return Zones.z1;
                    else if (cardData != null && card_ex_right != null && card_ex_left.IsCode(1948619) && cardData.HasSetcode(0x8))
                        return Zones.z3;
                    else if ((card_ex_left != null && card_ex_left.IsCode(1948619)) || (card_ex_right != null && card_ex_left.IsCode(1948619)))
                        return Zones.z0 | Zones.z2 | Zones.z4 | Zones.z5 | Zones.z6;
                    else
                        return available & ~Bot.GetLinkedZones();
                }
            }
            return base.OnSelectPlace(cardId, player, location, available);
        }

        public override CardPosition OnSelectPosition(int cardId, IList<CardPosition> positions)
        {
            YGOSharp.OCGWrapper.NamedCard cardData = YGOSharp.OCGWrapper.NamedCard.Get(cardId);
            if (cardData != null)
            {
                if (Card.Location == CardLocation.SpellZone)
                    return CardPosition.FaceUpAttack;
                if (Util.IsAllEnemyBetterThanValue(cardData.Attack, true) && !(cardData.HasType(CardType.Xyz) && !Card.IsDisabled()))
                    return CardPosition.FaceUpDefence;
                return CardPosition.FaceUpAttack;
            }
            return 0;
        }

        public override bool OnSelectYesNo(long desc)
        {
            if ((desc == Util.GetStringId(826, 12) && Duel.Player == 1) || desc == Util.GetStringId(827, 6) || desc == Util.GetStringId(827, 1) || desc == Util.GetStringId(13709, 11) || desc == Util.GetStringId(123106, 8) || desc == Util.GetStringId(123106, 7) || desc == Util.GetStringId(13709, 12) || desc == Util.GetStringId(826, 6) || desc == Util.GetStringId(13713, 8) || desc == Util.GetStringId(827, 1))
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

            if (_cards.ContainsCardWithId(CardId.Number86))
                return _cards.GetMatchingCards(card => card.IsCode(CardId.Number86));

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
            if (orica == null && avail.Contains(CardId.Oricha))
                return CardId.Oricha;

            IList<ClientCard> last_cards = Bot.Graveyard.GetMatchingCards(card => card.Sequence == Bot.Graveyard.Count - 1);
            if (orica != null && orica.IsCode(CardId.Oricha) && last_chain_card != null && last_chain_card == orica)
            {
                if (ActivateDescription == Util.GetStringId(12744567, 0) || (ActivateDescription == -1 && !(orica.HasXyzMaterial(1, 12))))
                {
                    if (!(Card.HasXyzMaterial(1, 12)) && avail.Contains(12))
                        return 12;
                    else if (!(Card.HasXyzMaterial(1, 95856586)) && avail.Contains(95856586))
                        return 95856586;
                    else if (!(Card.HasXyzMaterial(1, 10)) && avail.Contains(10))
                        return 10;
                    else if (!(Card.HasXyzMaterial(1, CardId.XyzChangeTactics)) && avail.Contains(CardId.XyzChangeTactics))
                        return CardId.XyzChangeTactics;
                    else if (!(Card.HasXyzMaterial(1, 26493435)) && avail.Contains(26493435))
                        return 26493435;
                    else if (!(Card.HasXyzMaterial(1, 100000382)) && avail.Contains(100000382))
                        return 100000382;
                    else if (!(Card.HasXyzMaterial(1, 160000107)) && avail.Contains(160000107))
                        return 160000107;
                    else if (!(Card.HasXyzMaterial(1, 100000097)) && avail.Contains(100000097))
                        return 100000097;
                    else if (!(Card.HasXyzMaterial(1, 100000096)) && avail.Contains(100000096))
                        return 100000096;
                    else if (!(Card.HasXyzMaterial(1, 100000098)) && avail.Contains(100000098))
                        return 100000098;
                    else if (!(Card.HasXyzMaterial(1, 146)) && avail.Contains(146))
                        return 146;
                    else if (!(Card.HasXyzMaterial(1, 511001271)) && avail.Contains(511001271))
                        return 511001271;
                    else if (avail.Contains(11))
                        return 11;
                }
            }

            if (last_cards.Count > 0)
                    return 13701;

            if (last_chain_card != null && last_chain_card.IsCode(CardId.WRUM))
            {
                WRUMCount++;
                if (Bot.HasInMonstersZone(CardId.Number39) || WRUMCount%2==0)
                    return CardId.NumberC39UtopiaVictory;
                return CardId.Number39;
            }

            if (last_chain_card != null && last_chain_card.IsCode(CardId.SeventhSword))
            {
                IList<ClientCard> targets = Bot.MonsterZone.GetMatchingCards(card => card.IsFaceup() && card.IsCode(99) && !Card.IsDisabled());
                if (targets.Count == 0)
                {
                    if (Bot.HasInMonstersZone(99))
                        return 98;
                    return 99;
                }
                else
                {
                    if (Bot.HasInMonstersZone(97))
                        return 96;
                    return 97;
                }
            }

            if (avail.Contains(264))
            {
                if (Bot.HasInSpellZone(264))
                    return 266;
                else return 264;
            }
            return Program.Rand.Next(avail.Count);
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

        public override IList<ClientCard> OnSelectXyzMaterial(IList<ClientCard> cards, int min, int max)
        {
            IList<ClientCard> result = Util.SelectPreferredCards(new[] {
                CardId.ZsAscent,
                CardId.ZsArmsSage
            }, cards, min, max);
            return Util.CheckSelectCount(result, cards, min, max);
        }

        private void SelectXYZDetach(List<int> Overlays)
        {
            AI.SelectCard(
                CardId.ZsAscent,
                CardId.ZsArmsSage,
                CardId.Number39,
                CardId.Number39Double,
                CardId.Number39Utopia,
                CardId.NumberC39Utopia,
                CardId.NumberC39UtopiaVictory,
                CardId.NumberS39UtopiaOne,
                CardId.NumberS39UtopiatheLightning
                );
        }

        private bool FNo0_Slash()
        {
            return false;
            if (Duel.Player == 0 && Duel.Turn == 1)
                return false;
            return true;
        }

        private bool FNo0_Slash_Effects()
        {
            if (Duel.Player == 1 && !Bot.UnderAttack)
                return false;
            SelectXYZDetach(Card.Overlays);
            return true;
        }

        private bool GodPheonix()
        {
            AI.SelectAnnounceID(802);
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

        private bool HopeZSEffects()
        {
            return true;
        }

        private bool Astralball()
        {
            if (Bot.ExtraDeck.GetMatchingCardsCount(card => card.Rank == 4) > 0)
            {
                AI.SelectCard(Bot.ExtraDeck.GetMatchingCards(card => card.Rank == 4));
                return true;
            }
            return false;
        }

        private bool Astralhope()
        {
            if (!(Card.Location == CardLocation.MonsterZone || Card.Location == CardLocation.SpellZone))
                return true;
            if (Bot.GetHandCount() > 0)
                return true;
            return false;
        }

        private bool Number39UtopiaDouble()
        {
            if (Duel.Player == 0 && Bot.GetRemainingCount(CardId.DoubleChance, 1) > 0)
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }

        private bool Number39UtopiaDoubleEffects()
        {
            SelectXYZDetach(Card.Overlays);
            AI.SelectAnnounceID(CardId.Number39Utopia);
            return true;
        }

        private bool NumberN99()
        {
            SelectXYZDetach(Card.Overlays);
            if (Bot.GetMonsters().GetMatchingCardsCount(card => card.IsCode(CardId.Number93) && !card.IsDisabled() && card.IsFaceup()) == 0)
                AI.SelectAnnounceID(CardId.Number93);
            else
            {
                List<int> announce_numbers = new List<int> { CardId.Number6, CardId.Number100, CardId.Number39, CardId.Number99, CardId.NumberN99, 37, 81, 150, 240, CardId.SNo0, 13716 };
                int no = Program.Rand.Next(11);
                AI.SelectAnnounceID(announce_numbers[no]);
            }
            return true;
        }

        private bool Number93()
        {
            SelectXYZDetach(Card.Overlays);
            List<int> announce_numbers = new List<int> { CardId.Number93, CardId.Number6, CardId.Number100, CardId.Number39, CardId.Number99, CardId.NumberN99, 37, 81, 150, 240, CardId.SNo0, 13716 };
            int no = Program.Rand.Next(12);
            AI.SelectAnnounceID(announce_numbers[no]);
            return true;
        }

        private bool Number6()
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

        private bool Number39UtopiaEffects()
        {
            if (Util.ChainContainsCard(CardId.Number39Utopia))
                return false;
            if (Duel.Player == 1
                || (Bot.BattlingMonster == Card && (Bot.HasInHand(CardId.DoubleChance) || Bot.GetRemainingCount(CardId.DoubleChance,2) > 0)))
            {
                if (Duel.Player == 1)
                {
                    SelectXYZDetach(Card.Overlays);
                    return true;
                }
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
            if (Enemy.GetSpellCount()>0)
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

        private bool Number100DragonEffects()
        {
            if (Duel.Player == 0)
                return true;
            else
                return Card.IsFaceup() && Bot.UnderAttack && Bot.BattlingMonster == Card;
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
            //if (targets.ContainsMonsterWithRank(4))
            //{
            //    AI.SelectAnnounceID(63);
            //    AI.SelectAnnounceID(13719);
            //}
            //else if (targets.ContainsMonsterWithRank(5))
            //{
            //    AI.SelectAnnounceID(13719);
            //    AI.SelectAnnounceID(13719);
            //}
            //else if (targets.ContainsMonsterWithRank(10))
            //{
            //    AI.SelectAnnounceID(389);
            //    AI.SelectAnnounceID(110);
            //}
            return true;
        }

        private bool HRUM()
        {
            IList<ClientCard> targets = Bot.MonsterZone.GetMatchingCards(card => card.IsFaceup() && card.IsCode(CardId.Number39Utopia));
            if (targets.Count == 0)
                return false;
            AI.SelectCard(targets);
            AI.SelectAnnounceID(CardId.NumberN99);
            return true;
        }

        private bool RDM()
        {
            IList<ClientCard> targets = Bot.MonsterZone.GetMatchingCards(card => card.IsFaceup() && card.HasSetcode(0x7f) && !((card.IsCode(CardId.Number39) || card.IsCode(CardId.NumberN99)) && !Card.IsDisabled()));
            if (targets.Count == 0)
                return false;
            AI.SelectCard(targets);
            AI.SelectAnnounceID(CardId.Number100);
            return true;
        }

        private bool NoEvo()
        {
            AI.SelectCard(511001781);
            AI.SelectNextCard(511010011);
            AI.SelectThirdCard(511002054);
            return true;
        }

        private bool SeventhSword()
        {
            AI.SelectCard(99);
            AI.SelectNextCard(98);
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
            if (Bot.MonsterZone.GetMatchingCardsCount(card => card.Level != 4 && card.Level >0 && card.Position != (int)CardPosition.FaceUp && card.IsFaceup()) + Bot.SpellZone.GetMatchingCardsCount(card => card.Level != 4 && card.Level >0 && card.Position != (int)CardPosition.FaceUp && card.IsFaceup()) > 0)
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

        private bool Numeronlead()
        {
            AI.SelectAnnounceID(13701);
            return true;
        }

        private bool ZsAscent()
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
    }
}
