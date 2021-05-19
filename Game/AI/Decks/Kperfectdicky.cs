using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using System.Linq;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

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
            public const int Cyclone = 5318639;

            //ST1732Executor
            public const int Digitron = 32295838;
            public const int Bitron = 36211150;
            public const int DualAssembloom = 7445307;
            public const int BootStagguard = 70950698;
            public const int Linkslayer = 35595518;
            public const int RAMClouder = 9190563;
            public const int ROMCloudia = 44956694;
            public const int BalancerLord = 8567955;
            public const int Backlinker = 71172240;
            public const int Kleinant = 45778242;
            public const int Draconnet = 62706865;
            public const int DotScaper = 18789533;
            public const int MindControl = 37520316;
            public const int DarkHole = 53129443;
            public const int MonsterReborn = 83764718;
            public const int MysticalSpaceTyphoon = 5318639;
            public const int CosmicCyclone = 8267140;
            public const int BookOfMoon = 14087893;
            public const int CynetBackdoor = 43839002;
            public const int MoonMirrorShield = 19508728;
            public const int CynetUniverse = 61583217;
            public const int BottomlessTrapHole = 29401950;
            public const int MirrorForce = 44095762;
            public const int TorrentialTribute = 53582587;
            public const int RecodedAlive = 70238111;
            public const int CompulsoryEvacuationDevice = 94192409;
            public const int SolemnStrike = 40605147;
            public const int DecodeTalker = 1861629;
            public const int EncodeTalker = 6622715;
            public const int TriGateWizard = 32617464;
            public const int Honeybot = 34472920;
            public const int BinarySorceress = 79016563;
            public const int LinkSpider = 98978921;
            public const int StagToken = 70950699;

            //AltergeistExecutor
            public const int Kunquery = 52927340;
            public const int Marionetter = 53143898;
            public const int Multifaker = 42790071;
            public const int AB_JS = 14558127;
            public const int GO_SR = 59438930;
            public const int GR_WC = 62015408;
            public const int GB_HM = 73642296;
            public const int Silquitous = 89538537;
            public const int MaxxC = 23434538;
            public const int Meluseek = 25533642;
            public const int OneForOne = 2295440;
            public const int PotofDesires = 35261759;
            public const int PotofIndulgence = 49238328;
            public const int Impermanence = 10045474;
            public const int WakingtheDragon = 10813327;
            public const int EvenlyMatched = 15693423;
            public const int Storm = 23924608;
            public const int Manifestation = 35146019;
            public const int Protocol = 27541563;
            public const int Spoofing = 53936268;
            public const int ImperialOrder = 61740673;
            public const int SolemnJudgment = 41420027;
            public const int NaturalExterio = 99916754;
            public const int UltimateFalcon = 86221741;
            public const int Borrelsword = 85289965;
            public const int FWD = 05043010;
            public const int TripleBurstDragon = 49725936;
            public const int HeavymetalfoesElectrumite = 24094258;
            public const int Isolde = 59934749;
            public const int Hexstia = 1508649;
            public const int Needlefiber = 50588353;
            public const int Kagari = 63288573;
            public const int Shizuku = 90673288;
            public const int Linkuriboh = 41999284;
            public const int Anima = 94259633;
            public const int SecretVillage = 68462976;
            public const int NaturalBeast = 33198837;
            public const int SwordsmanLV7 = 37267041;
            public const int RoyalDecreel = 51452091;
            public const int Anti_Spell = 58921041;
            public const int Hayate = 8491308;
            public const int Raye = 26077387;
            public const int Drones_Token = 52340445;
            public const int Iblee = 10158145;

            //BlackwingExecutor
            public const int KrisTheCrackOfDawn = 81105204;
            public const int SiroccoTheDawn = 75498415;
            public const int ShuraTheBlueFlame = 58820853;
            public const int BoraTheSpear = 49003716;
            public const int KalutTheMoonShadow = 85215458;
            public const int GaleTheWhirlwind = 2009101;
            public const int BlizzardTheFarNorth = 22835145;
            public const int MistralTheSilverShield = 46710683;
            public const int Raigeki = 12580477;
            public const int BlackWhirlwind = 91351370;
            public const int DeltaCrowAntiReverse = 59839761;
            public const int DimensionalPrison = 70342110;
            public const int SilverwindTheAscendant = 33236860;
            public const int BlackWingedDragon = 9012916;
            public const int ArmorMaster = 69031175;
            public const int ArmedWing = 76913983;
            public const int GramTheShiningStar = 17377751;

            //BlueEyesExecutor
            public const int WhiteDragon = 89631139;
            public const int AlternativeWhiteDragon = 38517737;
            public const int DragonSpiritOfWhite = 45467446;
            public const int WhiteStoneOfAncients = 71039903;
            public const int WhiteStoneOfLegend = 79814787;
            public const int SageWithEyesOfBlue = 8240199;
            public const int EffectVeiler = 97268402;
            public const int GalaxyCyclone = 5133471;
            public const int HarpiesFeatherDuster = 18144506;
            public const int ReturnOfTheDragonLords = 6853254;
            public const int PotOfDesires = 35261759;
            public const int TradeIn = 38120068;
            public const int CardsOfConsonance = 39701395;
            public const int DragonShrine = 41620959;
            public const int MelodyOfAwakeningDragon = 48800175;
            public const int SoulCharge = 54447022;
            public const int SilversCry = 87025064;
            public const int Giganticastle = 63422098;
            public const int AzureEyesSilverDragon = 40908371;
            public const int BlueEyesSpiritDragon = 59822133;
            public const int GalaxyEyesDarkMatterDragon = 58820923;
            public const int GalaxyEyesCipherBladeDragon = 2530830;
            public const int GalaxyEyesFullArmorPhotonDragon = 39030163;
            public const int GalaxyEyesPrimePhotonDragon = 31801517;
            public const int GalaxyEyesCipherDragon = 18963306;
            public const int HopeHarbingerDragonTitanicGalaxy = 63767246;
            public const int SylvanPrincessprite = 33909817;

            //BlueEyesMaxDragonExecutor
            public const int BlueEyesWhiteDragon = 89631139;
            public const int BlueEyesAlternativeWhiteDragon = 38517737;
            public const int DeviritualTalismandra = 80701178;
            public const int ManguOfTheTenTousandHands = 95492061;
            public const int DevirrtualCandoll = 53303460;
            public const int AshBlossom = 14558127;
            public const int BlueEyesChaosMaxDragon = 55410871;
            public const int CreatureSwap = 31036355;
            public const int TheMelodyOfAwakeningDragon = 48800175;
            public const int UpstartGoblin = 70368879;
            public const int ChaosForm = 21082832;
            public const int AdvancedRitualArt = 46052429;
            public const int CalledByTheGrave = 24224830;
            public const int Scapegoat = 73915051;
            public const int InfiniteImpermanence = 10045474;
            public const int RecklessGreed = 37576645;
            public const int BorreloadDragon = 31833038;
            public const int BirrelswordDragon = 85289965;
            public const int KnightmareGryphon = 65330383;
            public const int MissusRadiant = 3987233;
            public const int LockBird = 94145021;
            public const int Ghost = 59438930;

            //CyberDragonExecutor
            public const int CyberLaserDragon = 4162088;
            public const int CyberBarrierDragon = 68774379;
            public const int CyberDragon = 70095154;
            public const int CyberDragonDrei = 59281922;
            public const int CyberPhoenix = 3370104;
            public const int ArmoredCybern = 67159705;
            public const int ProtoCyberDragon = 26439287;
            public const int CyberKirin = 76986005;
            public const int CyberDragonCore = 23893227;
            public const int CyberValley = 3657444;
            public const int DifferentDimensionCapsule = 11961740;
            public const int Polymerization = 24094653;
            public const int PowerBond = 37630732;
            public const int EvolutionBurst = 52875873;
            public const int PhotonGeneratorUnit = 66607691;
            public const int DeFusion = 95286165;
            public const int AttackReflectorUnit = 91989718;
            public const int CyberneticHiddenTechnology = 92773018;
            public const int CallOfTheHaunted = 97077563;
            public const int SevenToolsOfTheBandit = 3819470;
            public const int CyberTwinDragon = 74157028;
            public const int CyberEndDragon = 1546123;
            public const int CyberDragonNova = 58069384;


            //DarkMagicianExecutor
            public const int DarkMagician = 46986414;
            public const int GrinderGolem = 75732622;
            public const int MagicianOfLllusion = 35191415;
            public const int ApprenticeLllusionMagician = 30603688;
            public const int WindwitchGlassBell = 71007216;
            public const int MagiciansRod = 7084129;
            public const int WindwitchIceBell = 43722862;
            public const int SpellbookMagicianOfProphecy = 14824019;
            public const int WindwitchSnowBell = 70117860;

            public const int TheEyeOfTimaeus = 1784686;
            public const int DarkMagicAttack = 2314238;
            public const int SpellbookOfKnowledge = 23314220;
            public const int SpellbookOfSecrets = 89739383;
            public const int DarkMagicInheritance = 41735184;
            public const int LllusionMagic = 73616671;
            //public const int Scapegoat = 73915051;
            public const int DarkMagicalCircle = 47222536;
            public const int WonderWand = 67775894;
            public const int MagicianNavigation = 7922915;
            public const int EternalSoul = 48680970;

            public const int DarkMagicianTheDragonKnight = 41721210;
            public const int CrystalWingSynchroDragon = 50954680;
            public const int OddEyesWingDragon = 58074177;
            public const int ClearWingFastDragon = 90036274;
            public const int WindwitchWinterBell = 14577226;
            public const int OddEyesAbsoluteDragon = 16691074;
            public const int Dracossack = 22110647;
            public const int BigEye = 80117527;
            public const int TroymarePhoenix = 2857636;
            public const int TroymareCerberus = 75452921;
            public const int ApprenticeWitchling = 71384012;
            public const int VentriloauistsClaraAndLucika = 1482001;
            /*public const int EbonLllusionMagician = 96471335;
            public const int BorreloadDragon = 31833038;
            public const int SaryujaSkullDread = 74997493;
            public const int Hidaruma = 64514892;
            public const int AkashicMagician = 28776350;
            public const int SecurityDragon = 99111753;
            public const int LinkSpider = 98978921;
            public const int Linkuriboh = 41999284;*/

            public const int ElShaddollWinda = 94977269;
            public const int Ultimate = 86221741;
            public const int GiantRex = 80280944;
            public const int UltimateConductorTytanno = 18940556;
            public const int SummonSorceress = 61665245;
            public const int CrystronNeedlefiber = 50588353;
            public const int FirewallDragon = 5043010;
            public const int JackKnightOfTheLavenderDust = 28692962;
            public const int JackKnightOfTheCobaltDepths = 92204263;
            public const int JackKnightOfTheCrimsonLotus = 56809158;
            public const int JackKnightOfTheGoldenBlossom = 29415459;
            public const int JackKnightOfTheVerdantGale = 66022706;
            public const int JackKnightOfTheAmberShade = 93020401;
            public const int JackKnightOfTheAzureSky = 20537097;
            public const int MekkKnightMorningStar = 72006609;
            public const int JackKnightOfTheWorldScar = 38502358;
            public const int WhisperOfTheWorldLegacy = 62530723;
            public const int TrueDepthsOfTheWorldLegacy = 98935722;
            public const int KeyToTheWorldLegacy = 2930675;

            //ToadallyAwesomeExecutor
            public const int CryomancerOfTheIceBarrier = 23950192;
            public const int DewdarkOfTheIceBarrier = 90311614;
            public const int SwapFrog = 9126351;
            public const int PriorOfTheIceBarrier = 50088247;
            public const int Ronintoadin = 1357146;
            public const int DupeFrog = 46239604;
            public const int GraydleSlimeJr = 80250319;
            public const int Surface = 33057951;
            public const int CardDestruction = 72892473;
            public const int FoolishBurial = 81439173;
            public const int MedallionOfTheIceBarrier = 84206435;
            public const int Salvage = 96947648;
            public const int AquariumStage = 29047353;
            public const int HeraldOfTheArcLight = 79606837;
            public const int ToadallyAwesome = 90809975;
            public const int SkyCavalryCentaurea = 36776089;
            public const int DaigustoPhoenix = 2766877;
            public const int CatShark = 84224627;

            //ZexalWeaponsExecutor
            public const int ZwTornadoBringer = 81471108;
            public const int ZwLightningBlade = 45082499;
            public const int ZwAsuraStrike = 40941889;
            public const int SolarWindJammer = 33911264;
            public const int PhotonTrasher = 65367484;
            public const int StarDrawing = 24610207;
            public const int SacredCrane = 30914564;
            public const int Goblindbergh = 25259669;
            public const int Honest = 37742478;
            public const int Kagetokage = 94656263;
            public const int HeroicChallengerExtraSword = 34143852;
            public const int TinGoldfish = 18063928;
            public const int SummonerMonk = 423585;
            public const int InstantFusion = 1845204;
            public const int ReinforcementOfTheArmy = 32807846;
            public const int BreakthroughSkill = 78474168;
            public const int SolemnWarning = 84749824;
            public const int XyzChangeTactics = 11705261;
            public const int FlameSwordsman = 45231177;
            public const int DarkfireDragon = 17881964;
            public const int GaiaDragonTheThunderCharger = 91949988;
            public const int ZwLionArms = 60992364;
            public const int AdreusKeeperOfArmageddon = 94119480;
            public const int Number61Volcasaurus = 29669359;
            public const int GemKnightPearl = 71594310;
            public const int Number39Utopia = 84013237;
            public const int NumberS39UtopiaOne = 86532744;
            public const int NumberS39UtopiatheLightning = 56832966;
            public const int MaestrokeTheSymphonyDjinn = 25341652;
            public const int GagagaCowboy = 12014404;


            //OldSchoolExecutor
            public const int AncientGearGolem = 83104731;
            public const int Frostosaurus = 6631034;
            public const int AlexandriteDragon = 43096270;
            public const int GeneWarpedWarwolf = 69247929;
            public const int GearGolemTheMovingFortress = 30190809;
            public const int EvilswarmHeliotrope = 77542832;
            public const int LusterDragon = 11091375;
            public const int InsectKnight = 35052053;
            public const int ArchfiendSoldier = 49881766;
            public const int HeavyStorm = 19613556;
            public const int HammerShot = 26412047;
            public const int Fissure = 66788016;
            public const int SwordsOfRevealingLight = 72302403;


            //Level8Executor
            public const int AngelTrumpeter = 87979586;
            public const int ScrapGolem = 82012319;
            public const int PhotonThrasher = 65367484;
            public const int WorldCarrotweightChampion = 44928016;
            public const int RaidenHandofTheLightsworn = 77558536;
            public const int ScrapBeast = 19139516;
            public const int PerformageTrickClown = 67696066;
            public const int MaskedChameleon = 53573406;
            public const int WhiteRoseDragon = 12213463;
            public const int RedRoseDragon = 26118970;
            public const int ScrapRecycler = 4334811;
            public const int MechaPhantomBeastOLion = 72291078;
            public const int MechaPhantomBeastOLionToken = 72291079;
            public const int JetSynchron = 9742784;

            public const int UnexpectedDai = 911883;
            public const int ReinforcementofTheArmy = 32807846;
            public const int ChargeofTheLightBrigade = 94886282;
            public const int CalledbyTheGrave = 24224830;
            public const int WhiteAuraBihamut = 89907227;
            public const int BorreloadSavageDragon = 27548199;
            public const int ScarlightRedDragonArchfiend = 80666118;
            public const int PSYFramelordOmega = 74586817;
            public const int ScrapDragon = 76774528;
            public const int BlackRoseMoonlightDragon = 33698022;
            public const int ShootingRiserDragon = 68431965;
            public const int CoralDragon = 42566602;
            public const int GardenRoseMaiden = 53325667;
            public const int Number41BagooskaTheTerriblyTiredTapir = 90590303;
            public const int MekkKnightCrusadiaAstram = 21887175;
            public const int ScrapWyvern = 47363932;

            public const int GhostOgreAndSnowRabbit = 59438930;
            public const int GhostBelle = 73642296;
            public const int SmashingGround = 97169186;
        }

        private int CrossSacrifaceCount = 0;
        //ST1732Executor
        bool BalancerLordUsed = false;

        //AltergeistExecutor
        List<int> Impermanence_list = new List<int>();
        bool Multifaker_ssfromhand = false;
        bool Multifaker_ssfromdeck = false;
        bool Marionetter_reborn = false;
        bool Hexstia_searched = false;
        bool Meluseek_searched = false;
        bool summoned = false;
        bool Silquitous_bounced = false;
        bool Silquitous_recycled = false;
        bool ss_other_monster = false;
        List<ClientCard> attacked_Meluseek = new List<ClientCard>();

        List<int> SkyStrike_list = new List<int> {
            CardId.Raye, CardId.Hayate, CardId.Kagari, CardId.Shizuku,
            21623008, 25955749, 63166095, 99550630,
            25733157, 51227866, CardId.Drones_Token-1,98338152,
            24010609, 97616504, 50005218
        };

        List<int> cards_improper = new List<int>
        {
            0,CardId.WakingtheDragon, CardId.SolemnStrike, CardId.Spoofing,   CardId.OneForOne, CardId.PotofDesires,
            CardId.Manifestation, CardId.SecretVillage, CardId.ImperialOrder,   _CardId.HarpiesFeatherDuster, CardId.GR_WC,
            CardId.Protocol, CardId.SolemnJudgment, CardId.Storm, CardId.GO_SR, CardId.Silquitous,
            CardId.MaxxC,  CardId.Impermanence, CardId.Meluseek,   CardId.AB_JS, CardId.Kunquery,
            CardId.Marionetter, CardId.Multifaker
        };

        List<int> normal_counter = new List<int>
        {
            53262004, 98338152, 32617464, 45041488, CardId.SolemnStrike,
            61257789, 23440231, 27354732, 12408276, 82419869, CardId.Impermanence,
            49680980, 18621798, 38814750, 17266660, 94689635,CardId.AB_JS,
            74762582, 75286651, 4810828,  44665365, 21123811, _CardId.CrystalWingSynchroDragon,
            82044279, 82044280, 79606837, 10443957, 1621413,  CardId.Protocol,
            90809975, 8165596,  9753964,  53347303, 88307361, _CardId.GamecieltheSeaTurtleKaiju,
            5818294,  2948263,  6150044,  26268488, 51447164, _CardId.JizukirutheStarDestroyingKaiju,
            97268402
        };

        //BlueEyesExecutor
        private List<ClientCard> UsedAlternativeWhiteDragon = new List<ClientCard>();
        ClientCard UsedGalaxyEyesCipherDragon;
        bool AlternativeWhiteDragonSummoned = false;
        bool SoulChargeUsed = false;

        //BlueEyesMaxDragonExecutor
        int Talismandra_count = 0;
        int Candoll_count = 0;
        bool Talismandra_used = false;
        bool Candoll_used = false;
        int RitualArt_count = 0;
        int ChaosForm_count = 0;
        int MaxDragon_count = 0;
        int TheMelody_count = 0;

        //CyberDragonExecutor
        bool PowerBondUsed = false;

        //ZexalWeaponsExecutor
        private int ZwCount = 0;

        public KperfectdickyExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            IList<int> activatem = new List<int>();
            AddExecutor(ExecutorType.Activate, CardId.Cyclone, OtherSpellEffect);
            activatem.Add(CardId.Cyclone);

            //ST1732Executor
            AddExecutor(ExecutorType.Activate, CardId.CosmicCyclone, DefaultCosmicCyclone);
            activatem.Add(CardId.CosmicCyclone);
            AddExecutor(ExecutorType.Activate, CardId.MysticalSpaceTyphoon, DefaultMysticalSpaceTyphoon);
            activatem.Add(CardId.MysticalSpaceTyphoon);
            AddExecutor(ExecutorType.Activate, CardId.DarkHole, DefaultDarkHole);
            activatem.Add(CardId.DarkHole);
            AddExecutor(ExecutorType.Activate, CardId.BookOfMoon, DefaultBookOfMoon);
            activatem.Add(CardId.BookOfMoon);
            AddExecutor(ExecutorType.Activate, CardId.CynetUniverse, CynetUniverseEffect);
            activatem.Add(CardId.CynetUniverse);
            AddExecutor(ExecutorType.SpSummon, CardId.Linkslayer);
            AddExecutor(ExecutorType.Activate, CardId.Linkslayer, LinkslayerEffect);
            activatem.Add(CardId.Linkslayer);
            AddExecutor(ExecutorType.Activate, CardId.MindControl, MindControlEffect);
            activatem.Add(CardId.MindControl);
            AddExecutor(ExecutorType.SpSummon, CardId.Backlinker);
            AddExecutor(ExecutorType.Activate, CardId.Backlinker, BacklinkerEffect);
            activatem.Add(CardId.Backlinker);
            AddExecutor(ExecutorType.Activate, CardId.BootStagguard, BootStagguardEffect);
            activatem.Add(CardId.BootStagguard);
            AddExecutor(ExecutorType.Activate, CardId.MonsterReborn, MonsterRebornEffect);
            activatem.Add(CardId.MonsterReborn);
            AddExecutor(ExecutorType.Activate, CardId.MoonMirrorShield, MoonMirrorShieldEffect);
            activatem.Add(CardId.MoonMirrorShield);
            AddExecutor(ExecutorType.Activate, CardId.CynetBackdoor, CynetBackdoorEffect);
            activatem.Add(CardId.CynetBackdoor);
            AddExecutor(ExecutorType.Activate, CardId.RecodedAlive);
            activatem.Add(CardId.RecodedAlive);
            AddExecutor(ExecutorType.Summon, CardId.BalancerLord, BalancerLordSummon);
            AddExecutor(ExecutorType.Summon, CardId.ROMCloudia, ROMCloudiaSummon);
            AddExecutor(ExecutorType.Activate, CardId.ROMCloudia, ROMCloudiaEffect);
            activatem.Add(CardId.ROMCloudia);
            AddExecutor(ExecutorType.Summon, CardId.Draconnet, DraconnetSummon);
            AddExecutor(ExecutorType.Activate, CardId.Draconnet, DraconnetEffect);
            activatem.Add(CardId.Draconnet);
            AddExecutor(ExecutorType.Summon, CardId.Kleinant);
            AddExecutor(ExecutorType.Activate, CardId.Kleinant, KleinantEffect);
            activatem.Add(CardId.Kleinant);
            AddExecutor(ExecutorType.Summon, CardId.RAMClouder);
            AddExecutor(ExecutorType.Activate, CardId.RAMClouder, RAMClouderEffect);
            activatem.Add(CardId.RAMClouder);
            AddExecutor(ExecutorType.SummonOrSet, CardId.DotScaper);
            AddExecutor(ExecutorType.Activate, CardId.DotScaper, DotScaperEffect);
            activatem.Add(CardId.DotScaper);
            AddExecutor(ExecutorType.Summon, CardId.BalancerLord);
            AddExecutor(ExecutorType.Summon, CardId.ROMCloudia);
            AddExecutor(ExecutorType.Summon, CardId.Draconnet);
            AddExecutor(ExecutorType.SummonOrSet, CardId.Backlinker);
            AddExecutor(ExecutorType.SummonOrSet, CardId.Digitron);
            AddExecutor(ExecutorType.SummonOrSet, CardId.Bitron);
            AddExecutor(ExecutorType.Activate, CardId.BalancerLord, BalancerLordEffect);
            activatem.Add(CardId.BalancerLord);
            AddExecutor(ExecutorType.SpSummon, CardId.DecodeTalker, LinkSummon);
            AddExecutor(ExecutorType.Activate, CardId.DecodeTalker);
            activatem.Add(CardId.DecodeTalker);
            AddExecutor(ExecutorType.SpSummon, CardId.TriGateWizard, LinkSummon);
            AddExecutor(ExecutorType.Activate, CardId.TriGateWizard);
            activatem.Add(CardId.TriGateWizard);
            AddExecutor(ExecutorType.SpSummon, CardId.EncodeTalker, LinkSummon);
            AddExecutor(ExecutorType.Activate, CardId.EncodeTalker);
            activatem.Add(CardId.EncodeTalker);
            AddExecutor(ExecutorType.SpSummon, CardId.Honeybot, LinkSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.BinarySorceress, LinkSummon);
            AddExecutor(ExecutorType.Activate, CardId.BinarySorceress);
            activatem.Add(CardId.BinarySorceress);
            AddExecutor(ExecutorType.SpellSet, CardId.CynetBackdoor, DefaultSpellSet);
            AddExecutor(ExecutorType.SpellSet, CardId.RecodedAlive, DefaultSpellSet);
            AddExecutor(ExecutorType.SpellSet, CardId.CompulsoryEvacuationDevice, DefaultSpellSet);
            AddExecutor(ExecutorType.SpellSet, CardId.BottomlessTrapHole, DefaultSpellSet);
            AddExecutor(ExecutorType.SpellSet, CardId.CosmicCyclone, DefaultSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.CompulsoryEvacuationDevice, DefaultCompulsoryEvacuationDevice);
            activatem.Add(CardId.CompulsoryEvacuationDevice);
            AddExecutor(ExecutorType.Activate, _CardId.DimensionalBarrier, DefaultDimensionalBarrier);
            activatem.Add(_CardId.DimensionalBarrier);
            AddExecutor(ExecutorType.Activate, CardId.TorrentialTribute, DefaultTorrentialTribute);
            activatem.Add(CardId.TorrentialTribute);
            AddExecutor(ExecutorType.Activate, CardId.MirrorForce, DefaultUniqueTrap);
            activatem.Add(CardId.MirrorForce);
            AddExecutor(ExecutorType.Activate, CardId.BottomlessTrapHole, DefaultUniqueTrap);
            activatem.Add(CardId.BottomlessTrapHole);

            //AltergeistExecutor
            AddExecutor(ExecutorType.Activate, _CardId.ChickenGame, ChickenGame);
            activatem.Add(_CardId.ChickenGame);
            AddExecutor(ExecutorType.Repos, EvenlyMatched_Repos);
            AddExecutor(ExecutorType.Activate, CardId.MaxxC, G_activate);
            activatem.Add(CardId.MaxxC);
            AddExecutor(ExecutorType.Activate, CardId.Anti_Spell, Anti_Spell_activate);
            activatem.Add(CardId.Anti_Spell);
            AddExecutor(ExecutorType.Activate, CardId.PotofIndulgence, PotofIndulgence_activate);
            activatem.Add(CardId.PotofIndulgence);
            AddExecutor(ExecutorType.Activate, CardId.SecretVillage, SecretVillage_activate);
            activatem.Add(CardId.SecretVillage);
            AddExecutor(ExecutorType.Activate, CardId.Hexstia, Hexstia_eff);
            activatem.Add(CardId.Hexstia);
            AddExecutor(ExecutorType.Activate, CardId.NaturalExterio, NaturalExterio_eff);
            activatem.Add(CardId.NaturalExterio);
            AddExecutor(ExecutorType.Activate, CardId.TripleBurstDragon, TripleBurstDragon_eff);
            activatem.Add(CardId.TripleBurstDragon);
            AddExecutor(ExecutorType.Activate, CardId.ImperialOrder, ImperialOrder_activate);
            activatem.Add(CardId.ImperialOrder);
            AddExecutor(ExecutorType.Activate, CardId.SolemnJudgment, SolemnJudgment_activate);
            activatem.Add(CardId.SolemnJudgment);
            AddExecutor(ExecutorType.Activate, CardId.Protocol, Protocol_negate_better);
            AddExecutor(ExecutorType.Activate, CardId.Impermanence, Impermanence_activate);
            activatem.Add(CardId.Impermanence);
            AddExecutor(ExecutorType.Activate, CardId.Protocol, Protocol_negate);
            AddExecutor(ExecutorType.Activate, CardId.Protocol, Protocol_activate_not_use);
            activatem.Add(CardId.Protocol);
            AddExecutor(ExecutorType.Activate, CardId.AB_JS, Hand_act_eff);
            activatem.Add(CardId.AB_JS);
            AddExecutor(ExecutorType.Activate, CardId.GB_HM, Hand_act_eff);
            activatem.Add(CardId.GB_HM);
            AddExecutor(ExecutorType.Activate, CardId.GO_SR, Hand_act_eff);
            activatem.Add(CardId.GO_SR);
            AddExecutor(ExecutorType.Activate, CardId.GR_WC, GR_WC_activate);
            activatem.Add(CardId.GR_WC);
            AddExecutor(ExecutorType.Activate, CardId.WakingtheDragon, WakingtheDragon_eff);
            activatem.Add(CardId.WakingtheDragon);
            AddExecutor(ExecutorType.Activate, CardId.EvenlyMatched, EvenlyMatched_activate);
            activatem.Add(CardId.EvenlyMatched);
            AddExecutor(ExecutorType.Activate, _CardId.HarpiesFeatherDuster, Feather_activate);
            activatem.Add(_CardId.HarpiesFeatherDuster);
            AddExecutor(ExecutorType.Activate, CardId.Storm, Storm_activate);
            activatem.Add(CardId.Storm);
            AddExecutor(ExecutorType.Activate, CardId.Meluseek, Meluseek_eff);
            activatem.Add(CardId.Meluseek);
            AddExecutor(ExecutorType.Activate, CardId.Silquitous, Silquitous_eff);
            activatem.Add(CardId.Silquitous);
            AddExecutor(ExecutorType.Activate, CardId.Borrelsword, Borrelsword_eff);
            activatem.Add(CardId.Borrelsword);
            AddExecutor(ExecutorType.Activate, CardId.Multifaker, Multifaker_handss);
            activatem.Add(CardId.Multifaker);
            AddExecutor(ExecutorType.Activate, CardId.Manifestation, Manifestation_eff);
            activatem.Add(CardId.Manifestation);
            AddExecutor(ExecutorType.SpSummon, CardId.Anima, Anima_ss);
            AddExecutor(ExecutorType.Activate, CardId.Anima);
            activatem.Add(CardId.Anima);
            AddExecutor(ExecutorType.Activate, CardId.Needlefiber, Needlefiber_eff);
            activatem.Add(CardId.Needlefiber);
            AddExecutor(ExecutorType.Activate, CardId.Spoofing, Spoofing_eff);
            activatem.Add(CardId.Spoofing);
            AddExecutor(ExecutorType.Activate, CardId.Kunquery, Kunquery_eff);
            activatem.Add(CardId.Kunquery);
            AddExecutor(ExecutorType.Activate, CardId.Multifaker, Multifaker_deckss);
            activatem.Add(CardId.Multifaker);
            AddExecutor(ExecutorType.SpSummon, CardId.Hexstia, Hexstia_ss);
            AddExecutor(ExecutorType.SpSummon, CardId.Linkuriboh, Linkuriboh_ss);
            AddExecutor(ExecutorType.Activate, CardId.Linkuriboh, Linkuriboh_eff);
            activatem.Add(CardId.Linkuriboh);
            AddExecutor(ExecutorType.Activate, CardId.Marionetter, Marionetter_eff);
            activatem.Add(CardId.Marionetter);
            AddExecutor(ExecutorType.Activate, CardId.OneForOne, OneForOne_activate);
            activatem.Add(CardId.OneForOne);
            AddExecutor(ExecutorType.Summon, CardId.Meluseek, Meluseek_summon);
            AddExecutor(ExecutorType.Summon, CardId.Marionetter, Marionetter_summon);
            AddExecutor(ExecutorType.Summon, CardId.GR_WC, tuner_summon);
            AddExecutor(ExecutorType.SpSummon, CardId.Needlefiber, Needlefiber_ss);
            AddExecutor(ExecutorType.SpSummon, CardId.Borrelsword, Borrelsword_ss);
            AddExecutor(ExecutorType.SpSummon, CardId.TripleBurstDragon, TripleBurstDragon_ss);
            AddExecutor(ExecutorType.Activate, CardId.PotofDesires, PotofDesires_activate);
            activatem.Add(CardId.PotofDesires);
            AddExecutor(ExecutorType.Summon, CardId.Silquitous, Silquitous_summon);
            AddExecutor(ExecutorType.Summon, CardId.Multifaker, Multifaker_summon);

            //BlackwingExecutor
            AddExecutor(ExecutorType.Activate, CardId.Raigeki, DefaultRaigeki);
            activatem.Add(CardId.Raigeki);
            AddExecutor(ExecutorType.Activate, CardId.BlackWhirlwind, BlackWhirlwindEffect);
            activatem.Add(CardId.BlackWhirlwind);
            AddExecutor(ExecutorType.SpSummon, CardId.KrisTheCrackOfDawn);
            AddExecutor(ExecutorType.SummonOrSet, CardId.KrisTheCrackOfDawn);
            AddExecutor(ExecutorType.Summon, CardId.SiroccoTheDawn, SiroccoTheDawnSummon);
            activatem.Add(CardId.SiroccoTheDawn);
            AddExecutor(ExecutorType.Summon, CardId.ShuraTheBlueFlame, ShuraTheBlueFlameSummon);
            activatem.Add(CardId.ShuraTheBlueFlame);
            AddExecutor(ExecutorType.SummonOrSet, CardId.ShuraTheBlueFlame);
            AddExecutor(ExecutorType.SpSummon, CardId.BoraTheSpear);
            AddExecutor(ExecutorType.SummonOrSet, CardId.BoraTheSpear);
            AddExecutor(ExecutorType.SummonOrSet, CardId.KalutTheMoonShadow, KalutTheMoonShadowSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.GaleTheWhirlwind);
            AddExecutor(ExecutorType.SummonOrSet, CardId.GaleTheWhirlwind);
            AddExecutor(ExecutorType.Summon, CardId.BlizzardTheFarNorth, BlizzardTheFarNorthSummon);
            activatem.Add(CardId.BlackWhirlwind);
            AddExecutor(ExecutorType.MonsterSet, CardId.MistralTheSilverShield);
            AddExecutor(ExecutorType.SpSummon, CardId.SilverwindTheAscendant);
            AddExecutor(ExecutorType.SpSummon, CardId.ArmorMaster);
            AddExecutor(ExecutorType.SpSummon, CardId.GramTheShiningStar);
            AddExecutor(ExecutorType.SpSummon, CardId.ArmedWing);
            AddExecutor(ExecutorType.SpSummon, CardId.BlackWingedDragon);
            AddExecutor(ExecutorType.Activate, CardId.DimensionalPrison, DefaultUniqueTrap);
            activatem.Add(CardId.DimensionalPrison);
            AddExecutor(ExecutorType.Activate, CardId.DeltaCrowAntiReverse, DeltaCrowAntiReverseEffect);
            activatem.Add(CardId.DeltaCrowAntiReverse);
            AddExecutor(ExecutorType.Activate, CardId.BoraTheSpear, BoraTheSpearEffect);
            activatem.Add(CardId.BoraTheSpear);
            AddExecutor(ExecutorType.Activate, CardId.KalutTheMoonShadow, AttackUpEffect);
            activatem.Add(CardId.KalutTheMoonShadow);
            AddExecutor(ExecutorType.Activate, CardId.SiroccoTheDawn, AttackUpEffect);
            activatem.Add(CardId.SiroccoTheDawn);
            AddExecutor(ExecutorType.Activate, CardId.GaleTheWhirlwind, GaleTheWhirlwindEffect);
            activatem.Add(CardId.GaleTheWhirlwind);

            //BlueEyesExecutor
            // destroy traps
            AddExecutor(ExecutorType.Activate, CardId.GalaxyCyclone, DefaultGalaxyCyclone);
            activatem.Add(CardId.GalaxyCyclone);
            AddExecutor(ExecutorType.Activate, CardId.DragonShrine, DragonShrineEffect);
            activatem.Add(CardId.DragonShrine);
            // Sage search
            AddExecutor(ExecutorType.Summon, CardId.SageWithEyesOfBlue, SageWithEyesOfBlueSummon);

            // search Alternative White Dragon
            AddExecutor(ExecutorType.Activate, CardId.MelodyOfAwakeningDragon, MelodyOfAwakeningDragonEffect);
            activatem.Add(CardId.MelodyOfAwakeningDragon);
            AddExecutor(ExecutorType.Activate, CardId.CardsOfConsonance, CardsOfConsonanceEffect);
            activatem.Add(CardId.CardsOfConsonance);
            AddExecutor(ExecutorType.Activate, CardId.TradeIn, TradeInEffect);
            activatem.Add(CardId.TradeIn);
            AddExecutor(ExecutorType.Activate, CardId.PotOfDesires, DefaultPotOfDesires);
            activatem.Add(CardId.PotOfDesires);
            // spsummon Alternative White Dragon if possible
            AddExecutor(ExecutorType.SpSummon, CardId.AlternativeWhiteDragon, AlternativeWhiteDragonSummon);

            // reborn
            AddExecutor(ExecutorType.Activate, CardId.ReturnOfTheDragonLords, RebornEffect);
            activatem.Add(CardId.ReturnOfTheDragonLords);
            AddExecutor(ExecutorType.Activate, CardId.SilversCry, RebornEffect);
            activatem.Add(CardId.SilversCry);
            AddExecutor(ExecutorType.Activate, CardId.MonsterReborn, RebornEffect);
            // monster effects
            AddExecutor(ExecutorType.Activate, CardId.AlternativeWhiteDragon, AlternativeWhiteDragonEffect);
            activatem.Add(CardId.AlternativeWhiteDragon);
            AddExecutor(ExecutorType.Activate, CardId.SageWithEyesOfBlue, SageWithEyesOfBlueEffect);
            activatem.Add(CardId.SageWithEyesOfBlue);
            AddExecutor(ExecutorType.Activate, CardId.WhiteStoneOfAncients, WhiteStoneOfAncientsEffect);
            activatem.Add(CardId.WhiteStoneOfAncients);
            AddExecutor(ExecutorType.Activate, CardId.DragonSpiritOfWhite, DragonSpiritOfWhiteEffect);
            activatem.Add(CardId.DragonSpiritOfWhite);
            AddExecutor(ExecutorType.Activate, CardId.BlueEyesSpiritDragon, BlueEyesSpiritDragonEffect);
            activatem.Add(CardId.BlueEyesSpiritDragon);
            AddExecutor(ExecutorType.Activate, CardId.HopeHarbingerDragonTitanicGalaxy, HopeHarbingerDragonTitanicGalaxyEffect);
            activatem.Add(CardId.HopeHarbingerDragonTitanicGalaxy);
            AddExecutor(ExecutorType.Activate, CardId.GalaxyEyesCipherDragon, GalaxyEyesCipherDragonEffect);
            activatem.Add(CardId.GalaxyEyesCipherDragon);
            AddExecutor(ExecutorType.Activate, CardId.GalaxyEyesPrimePhotonDragon, GalaxyEyesPrimePhotonDragonEffect);
            activatem.Add(CardId.GalaxyEyesPrimePhotonDragon);
            AddExecutor(ExecutorType.Activate, CardId.GalaxyEyesFullArmorPhotonDragon, GalaxyEyesFullArmorPhotonDragonEffect);
            activatem.Add(CardId.GalaxyEyesFullArmorPhotonDragon);
            AddExecutor(ExecutorType.Activate, CardId.GalaxyEyesCipherBladeDragon, GalaxyEyesCipherBladeDragonEffect);
            activatem.Add(CardId.GalaxyEyesCipherBladeDragon);
            AddExecutor(ExecutorType.Activate, CardId.GalaxyEyesDarkMatterDragon, GalaxyEyesDarkMatterDragonEffect);
            activatem.Add(CardId.GalaxyEyesDarkMatterDragon);
            AddExecutor(ExecutorType.Activate, CardId.AzureEyesSilverDragon, AzureEyesSilverDragonEffect);
            activatem.Add(CardId.AzureEyesSilverDragon);
            AddExecutor(ExecutorType.Activate, CardId.SylvanPrincessprite, SylvanPrincesspriteEffect);
            activatem.Add(CardId.SylvanPrincessprite);
            // normal summon
            AddExecutor(ExecutorType.Summon, CardId.SageWithEyesOfBlue, WhiteStoneSummon);
            AddExecutor(ExecutorType.Summon, CardId.WhiteStoneOfAncients, WhiteStoneSummon);
            AddExecutor(ExecutorType.Summon, CardId.WhiteStoneOfLegend, WhiteStoneSummon);

            // special summon from extra
            AddExecutor(ExecutorType.SpSummon, CardId.GalaxyEyesCipherDragon, GalaxyEyesCipherDragonSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.GalaxyEyesPrimePhotonDragon, GalaxyEyesPrimePhotonDragonSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.GalaxyEyesFullArmorPhotonDragon, GalaxyEyesFullArmorPhotonDragonSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.GalaxyEyesCipherBladeDragon, GalaxyEyesCipherBladeDragonSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.GalaxyEyesDarkMatterDragon, GalaxyEyesDarkMatterDragonSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Giganticastle, GiganticastleSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.BlueEyesSpiritDragon, BlueEyesSpiritDragonSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.HopeHarbingerDragonTitanicGalaxy, HopeHarbingerDragonTitanicGalaxySummon);
            AddExecutor(ExecutorType.SpSummon, CardId.SylvanPrincessprite, SylvanPrincesspriteSummon);

            // if we don't have other things to do...
            AddExecutor(ExecutorType.Activate, CardId.SoulCharge, SoulChargeEffect);
            activatem.Add(CardId.SoulCharge);
            // summon White Stone to use the hand effect of Sage
            AddExecutor(ExecutorType.Summon, CardId.WhiteStoneOfLegend, WhiteStoneSummonForSage);
            AddExecutor(ExecutorType.Summon, CardId.WhiteStoneOfAncients, WhiteStoneSummonForSage);
            AddExecutor(ExecutorType.Summon, CardId.SageWithEyesOfBlue, WhiteStoneSummonForSage);
            AddExecutor(ExecutorType.Activate, CardId.SageWithEyesOfBlue, SageWithEyesOfBlueEffectInHand);
            activatem.Add(CardId.SageWithEyesOfBlue);

            //BlueEyesMaxDragonExecutor
            //counter
            AddExecutor(ExecutorType.Activate, CardId.AshBlossom, DefaultAshBlossomAndJoyousSpring);
            activatem.Add(CardId.AshBlossom);
            AddExecutor(ExecutorType.Activate, CardId.MaxxC, MaxxCeff);
            AddExecutor(ExecutorType.Activate, CardId.InfiniteImpermanence, DefaultInfiniteImpermanence);
            activatem.Add(CardId.InfiniteImpermanence);
            AddExecutor(ExecutorType.Activate, CardId.CalledByTheGrave, CalledByTheGraveeff);
            activatem.Add(CardId.CalledByTheGrave);
            activatem.Add(CardId.UpstartGoblin);
            AddExecutor(ExecutorType.Activate, CardId.BlueEyesAlternativeWhiteDragon, BlueEyesAlternativeWhiteDragoneff);
            activatem.Add(CardId.BlueEyesAlternativeWhiteDragon);
            AddExecutor(ExecutorType.Activate, CardId.CreatureSwap, CreatureSwapeff);
            activatem.Add(CardId.CreatureSwap);
            AddExecutor(ExecutorType.Activate, CardId.TheMelodyOfAwakeningDragon, TheMelodyOfAwakeningDragoneff);
            activatem.Add(CardId.TheMelodyOfAwakeningDragon);
            AddExecutor(ExecutorType.Summon, CardId.ManguOfTheTenTousandHands);
            AddExecutor(ExecutorType.Activate, CardId.ManguOfTheTenTousandHands, TenTousandHandseff);
            activatem.Add(CardId.ManguOfTheTenTousandHands);
            AddExecutor(ExecutorType.Activate, DeviritualCheck);
            activatem.Add(CardId.Scapegoat);
            AddExecutor(ExecutorType.Activate, CardId.AdvancedRitualArt);
            activatem.Add(CardId.AdvancedRitualArt);
            AddExecutor(ExecutorType.Activate, CardId.ChaosForm, ChaosFormeff);
            activatem.Add(CardId.ChaosForm);
            AddExecutor(ExecutorType.SpSummon, CardId.MissusRadiant, MissusRadiantsp);
            AddExecutor(ExecutorType.Activate, CardId.MissusRadiant, MissusRadianteff);
            activatem.Add(CardId.MissusRadiant);
            AddExecutor(ExecutorType.Activate, CardId.Linkuriboh, Linkuriboheff);
            activatem.Add(CardId.Linkuriboh);
            AddExecutor(ExecutorType.SpSummon, CardId.Linkuriboh, Linkuribohsp);
            AddExecutor(ExecutorType.SpSummon, CardId.LinkSpider);
            AddExecutor(ExecutorType.SpSummon, CardId.BirrelswordDragon, BirrelswordDragonsp);
            AddExecutor(ExecutorType.Activate, CardId.BirrelswordDragon, BirrelswordDragoneff);
            activatem.Add(CardId.BirrelswordDragon);
            AddExecutor(ExecutorType.Activate, CardId.TheMelodyOfAwakeningDragon, TheMelodyOfAwakeningDragoneffsecond);
            activatem.Add(CardId.TheMelodyOfAwakeningDragon);
            AddExecutor(ExecutorType.Activate, CardId.RecklessGreed, RecklessGreedeff);
            activatem.Add(CardId.RecklessGreed);
            AddExecutor(ExecutorType.Activate, CardId.Scapegoat, Scapegoateff);
            activatem.Add(CardId.Scapegoat);

            //CyberDragonExecutor
            AddExecutor(ExecutorType.Activate, CardId.DifferentDimensionCapsule, Capsule);
            activatem.Add(CardId.DifferentDimensionCapsule);
            AddExecutor(ExecutorType.Activate, CardId.Polymerization, PolymerizationEffect);
            activatem.Add(CardId.Polymerization);
            AddExecutor(ExecutorType.Activate, CardId.PowerBond, PowerBondEffect);
            activatem.Add(CardId.PowerBond);
            AddExecutor(ExecutorType.Activate, CardId.EvolutionBurst, EvolutionBurstEffect);
            activatem.Add(CardId.EvolutionBurst);
            AddExecutor(ExecutorType.Activate, CardId.PhotonGeneratorUnit);
            activatem.Add(CardId.PhotonGeneratorUnit);
            AddExecutor(ExecutorType.Activate, CardId.DeFusion, DeFusionEffect);
            activatem.Add(CardId.DeFusion);
            AddExecutor(ExecutorType.Activate, CardId.BottomlessTrapHole, DefaultUniqueTrap);
            activatem.Add(CardId.BottomlessTrapHole);
            AddExecutor(ExecutorType.Activate, CardId.AttackReflectorUnit);
            activatem.Add(CardId.AttackReflectorUnit);
            AddExecutor(ExecutorType.Activate, CardId.SevenToolsOfTheBandit, DefaultTrap);
            activatem.Add(CardId.SevenToolsOfTheBandit);
            AddExecutor(ExecutorType.Activate, CardId.CallOfTheHaunted, DefaultCallOfTheHaunted);
            activatem.Add(CardId.CallOfTheHaunted);
            AddExecutor(ExecutorType.SummonOrSet, CardId.CyberDragonDrei, NoCyberDragonSpsummon);
            AddExecutor(ExecutorType.SummonOrSet, CardId.CyberPhoenix, NoCyberDragonSpsummon);
            AddExecutor(ExecutorType.Summon, CardId.CyberValley, NoCyberDragonSpsummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.CyberDragonCore, NoCyberDragonSpsummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.ArmoredCybern, ArmoredCybernSet);
            AddExecutor(ExecutorType.SummonOrSet, CardId.ProtoCyberDragon, ProtoCyberDragonSummon);
            AddExecutor(ExecutorType.Summon, CardId.CyberKirin, CyberKirinSummon);

            AddExecutor(ExecutorType.SpSummon, CardId.CyberDragon);
            AddExecutor(ExecutorType.SpSummon, CardId.CyberEndDragon);
            AddExecutor(ExecutorType.SpSummon, CardId.CyberTwinDragon);
            AddExecutor(ExecutorType.SpSummon, CardId.CyberBarrierDragon);
            AddExecutor(ExecutorType.SpSummon, CardId.CyberLaserDragon);

            AddExecutor(ExecutorType.Activate, CardId.CyberBarrierDragon);
            activatem.Add(CardId.CyberBarrierDragon);
            AddExecutor(ExecutorType.Activate, CardId.CyberLaserDragon);
            activatem.Add(CardId.CyberLaserDragon);
            AddExecutor(ExecutorType.Activate, CardId.CyberDragonDrei);
            activatem.Add(CardId.CyberDragonDrei);
            AddExecutor(ExecutorType.Activate, CardId.CyberPhoenix);
            activatem.Add(CardId.CyberPhoenix);
            AddExecutor(ExecutorType.Activate, CardId.CyberKirin);
            activatem.Add(CardId.CyberKirin);
            AddExecutor(ExecutorType.Activate, CardId.ArmoredCybern, ArmoredCybernEffect);
            activatem.Add(CardId.ArmoredCybern);
            AddExecutor(ExecutorType.Activate, CardId.CyberValley);
            activatem.Add(CardId.CyberValley);
            
            //DarkMagicianExecutor
            //counter
            AddExecutor(ExecutorType.Activate, CardId.AshBlossom, ChainEnemy);
            activatem.Add(CardId.AshBlossom);
            AddExecutor(ExecutorType.Activate, CardId.CrystalWingSynchroDragon, CrystalWingSynchroDragoneff);
            activatem.Add(CardId.CrystalWingSynchroDragon);
            AddExecutor(ExecutorType.Activate, CardId.UpstartGoblin, UpstartGoblineff);
            activatem.Add(CardId.UpstartGoblin);
            AddExecutor(ExecutorType.Activate, CardId.DarkMagicalCircle, DarkMagicalCircleeff);
            activatem.Add(CardId.DarkMagicalCircle);
            AddExecutor(ExecutorType.Activate, CardId.SpellbookOfSecrets, SpellbookOfSecreteff);
            activatem.Add(CardId.SpellbookOfSecrets);
            AddExecutor(ExecutorType.Activate, CardId.DarkMagicInheritance, DarkMagicInheritanceeff);
            activatem.Add(CardId.DarkMagicInheritance);
            AddExecutor(ExecutorType.Activate, CardId.DarkMagicAttack, DarkMagicAttackeff);
            activatem.Add(CardId.DarkMagicAttack);
            //trap set
            AddExecutor(ExecutorType.SpellSet, CardId.MagicianNavigation, MagicianNavigationset);
            AddExecutor(ExecutorType.SpellSet, CardId.EternalSoul, EternalSoulset);
            /*AddExecutor(ExecutorType.SpellSet, CardId.Scapegoat, Scapegoatset);            
            //sheep
            AddExecutor(ExecutorType.SpSummon, CardId.Hidaruma, Hidarumasp);
            AddExecutor(ExecutorType.SpSummon, CardId.Linkuriboh, Linkuribohsp);
            AddExecutor(ExecutorType.Activate, CardId.Linkuriboh, Linkuriboheff);
            AddExecutor(ExecutorType.SpSummon, CardId.LinkSpider, Linkuribohsp);
            AddExecutor(ExecutorType.SpSummon, CardId.BorreloadDragon, BorreloadDragonsp);
            AddExecutor(ExecutorType.SpSummon, CardId.BorreloadDragon, BorreloadDragoneff);*/
            //plan A             
            AddExecutor(ExecutorType.Activate, CardId.WindwitchIceBell, WindwitchIceBelleff);
            activatem.Add(CardId.WindwitchIceBell);
            AddExecutor(ExecutorType.Activate, CardId.WindwitchGlassBell, WindwitchGlassBelleff);
            activatem.Add(CardId.WindwitchGlassBell);
            AddExecutor(ExecutorType.Activate, CardId.WindwitchSnowBell, WindwitchSnowBellsp);
            activatem.Add(CardId.WindwitchSnowBell);
            AddExecutor(ExecutorType.SpSummon, CardId.WindwitchWinterBell, WindwitchWinterBellsp);
            AddExecutor(ExecutorType.Activate, CardId.WindwitchWinterBell, WindwitchWinterBelleff);
            activatem.Add(CardId.WindwitchWinterBell);
            
            AddExecutor(ExecutorType.SpSummon, CardId.CrystalWingSynchroDragon, CrystalWingSynchroDragonsp);
            // if fail
            AddExecutor(ExecutorType.SpSummon, CardId.ClearWingFastDragon, ClearWingFastDragonsp);
            AddExecutor(ExecutorType.Activate, CardId.ClearWingFastDragon, ClearWingFastDragoneff);
            activatem.Add(CardId.ClearWingFastDragon);
            // plan B
            //AddExecutor(ExecutorType.Activate, CardId.GrinderGolem, GrinderGolemeff);
            // AddExecutor(ExecutorType.SpSummon, CardId.Linkuriboh, Linkuribohsp);
            //AddExecutor(ExecutorType.SpSummon, CardId.LinkSpider, LinkSpidersp);
            //AddExecutor(ExecutorType.SpSummon, CardId.AkashicMagician);
            //plan C
            AddExecutor(ExecutorType.SpSummon, CardId.OddEyesAbsoluteDragon, OddEyesAbsoluteDragonsp);
            AddExecutor(ExecutorType.Activate, CardId.OddEyesAbsoluteDragon, OddEyesAbsoluteDragoneff);
            activatem.Add(CardId.OddEyesAbsoluteDragon);
            AddExecutor(ExecutorType.Activate, CardId.OddEyesWingDragon);
            activatem.Add(CardId.OddEyesWingDragon);
            //summon
            AddExecutor(ExecutorType.Summon, CardId.WindwitchGlassBell, WindwitchGlassBellsummonfirst);
            AddExecutor(ExecutorType.Summon, CardId.SpellbookMagicianOfProphecy, SpellbookMagicianOfProphecysummon);
            AddExecutor(ExecutorType.Activate, CardId.SpellbookMagicianOfProphecy, SpellbookMagicianOfProphecyeff);
            activatem.Add(CardId.SpellbookMagicianOfProphecy);
            AddExecutor(ExecutorType.Summon, CardId.MagiciansRod, MagiciansRodsummon);
            AddExecutor(ExecutorType.Activate, CardId.MagiciansRod, MagiciansRodeff);
            activatem.Add(CardId.MagiciansRod);
            AddExecutor(ExecutorType.Summon, CardId.WindwitchGlassBell, WindwitchGlassBellsummon);
            //activate
            AddExecutor(ExecutorType.Activate, CardId.LllusionMagic, LllusionMagiceff);
            activatem.Add(CardId.LllusionMagic);
            AddExecutor(ExecutorType.SpellSet, CardId.LllusionMagic, LllusionMagicset);
            AddExecutor(ExecutorType.Activate, CardId.SpellbookOfKnowledge, SpellbookOfKnowledgeeff);
            activatem.Add(CardId.SpellbookOfKnowledge);
            AddExecutor(ExecutorType.Activate, CardId.WonderWand, WonderWandeff);
            activatem.Add(CardId.WonderWand);
            AddExecutor(ExecutorType.Activate, CardId.TheEyeOfTimaeus, TheEyeOfTimaeuseff);
            activatem.Add(CardId.TheEyeOfTimaeus);
            AddExecutor(ExecutorType.SpSummon, CardId.ApprenticeLllusionMagician, ApprenticeLllusionMagiciansp);
            AddExecutor(ExecutorType.Activate, CardId.ApprenticeLllusionMagician, ApprenticeLllusionMagicianeff);
            activatem.Add(CardId.ApprenticeLllusionMagician);
            //other thing                     
            AddExecutor(ExecutorType.Activate, CardId.MagicianOfLllusion);
            activatem.Add(CardId.MagicianOfLllusion);
            AddExecutor(ExecutorType.Activate, CardId.MagicianNavigation, MagicianNavigationeff);
            activatem.Add(CardId.MagicianNavigation);
            AddExecutor(ExecutorType.Activate, CardId.EternalSoul, EternalSouleff);
            activatem.Add(CardId.EternalSoul);
            AddExecutor(ExecutorType.SpSummon, CardId.BigEye, BigEyesp);
            AddExecutor(ExecutorType.Activate, CardId.BigEye, BigEyeeff);
            activatem.Add(CardId.BigEye);
            AddExecutor(ExecutorType.SpSummon, CardId.Dracossack, Dracossacksp);
            AddExecutor(ExecutorType.Activate, CardId.Dracossack, Dracossackeff);
            activatem.Add(CardId.Dracossack);
            AddExecutor(ExecutorType.SpSummon, CardId.ApprenticeWitchling, ApprenticeWitchlingsp);
            AddExecutor(ExecutorType.Activate, CardId.ApprenticeWitchling, ApprenticeWitchlingeff);
            activatem.Add(CardId.ApprenticeWitchling);
            AddExecutor(ExecutorType.SpSummon, CardId.VentriloauistsClaraAndLucika, VentriloauistsClaraAndLucikasp);

            //ToadallyAwesomeExecutor
            AddExecutor(ExecutorType.Activate, CardId.AquariumStage, AquariumStageEffect);
            activatem.Add(CardId.AquariumStage);
            AddExecutor(ExecutorType.Activate, CardId.MedallionOfTheIceBarrier, MedallionOfTheIceBarrierEffect);
            activatem.Add(CardId.MedallionOfTheIceBarrier);
            AddExecutor(ExecutorType.Activate, CardId.FoolishBurial, FoolishBurialEffect);
            activatem.Add(CardId.FoolishBurial);
            
            AddExecutor(ExecutorType.SpSummon, CardId.PriorOfTheIceBarrier);
            AddExecutor(ExecutorType.Summon, CardId.GraydleSlimeJr, GraydleSlimeJrSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.SwapFrog, SwapFrogSpsummon);

            AddExecutor(ExecutorType.Activate, CardId.SwapFrog, SwapFrogEffect);
            activatem.Add(CardId.SwapFrog);
            AddExecutor(ExecutorType.Activate, CardId.GraydleSlimeJr, GraydleSlimeJrEffect);
            activatem.Add(CardId.GraydleSlimeJr);
            AddExecutor(ExecutorType.Activate, CardId.Ronintoadin, RonintoadinEffect);
            activatem.Add(CardId.Ronintoadin);
            AddExecutor(ExecutorType.Activate, CardId.PriorOfTheIceBarrier);
            activatem.Add(CardId.PriorOfTheIceBarrier);
            AddExecutor(ExecutorType.Activate, CardId.DupeFrog);
            activatem.Add(CardId.DupeFrog);
            
            AddExecutor(ExecutorType.Activate, CardId.Surface, SurfaceEffect);
            activatem.Add(CardId.Surface);
            AddExecutor(ExecutorType.Activate, CardId.MonsterReborn, SurfaceEffect);
            activatem.Add(CardId.MonsterReborn);
            AddExecutor(ExecutorType.Activate, CardId.Salvage, SalvageEffect);
            activatem.Add(CardId.Salvage);
            
            AddExecutor(ExecutorType.Summon, CardId.SwapFrog);
            AddExecutor(ExecutorType.Summon, CardId.DewdarkOfTheIceBarrier, IceBarrierSummon);
            AddExecutor(ExecutorType.Summon, CardId.CryomancerOfTheIceBarrier, IceBarrierSummon);

            AddExecutor(ExecutorType.Activate, CardId.CardDestruction);
            activatem.Add(CardId.CardDestruction);
            
            AddExecutor(ExecutorType.Summon, CardId.GraydleSlimeJr, NormalSummon);
            AddExecutor(ExecutorType.Summon, CardId.PriorOfTheIceBarrier, NormalSummon);
            AddExecutor(ExecutorType.Summon, CardId.Ronintoadin, NormalSummon);
            AddExecutor(ExecutorType.Summon, CardId.DupeFrog, NormalSummon);
            AddExecutor(ExecutorType.Summon, CardId.PriorOfTheIceBarrier, PriorOfTheIceBarrierSummon);

            AddExecutor(ExecutorType.SpSummon, CardId.CatShark, CatSharkSummon);
            AddExecutor(ExecutorType.Activate, CardId.CatShark, CatSharkEffect);
            activatem.Add(CardId.CatShark);
            AddExecutor(ExecutorType.SpSummon, CardId.SkyCavalryCentaurea, SkyCavalryCentaureaSummon);
            AddExecutor(ExecutorType.Activate, CardId.SkyCavalryCentaurea);
            activatem.Add(CardId.SkyCavalryCentaurea);
            AddExecutor(ExecutorType.SpSummon, CardId.DaigustoPhoenix, DaigustoPhoenixSummon);
            AddExecutor(ExecutorType.Activate, CardId.DaigustoPhoenix);
            activatem.Add(CardId.DaigustoPhoenix);
            AddExecutor(ExecutorType.SpSummon, CardId.ToadallyAwesome);
            AddExecutor(ExecutorType.Activate, CardId.ToadallyAwesome, ToadallyAwesomeEffect);
            activatem.Add(CardId.ToadallyAwesome);
            AddExecutor(ExecutorType.SpSummon, CardId.HeraldOfTheArcLight, HeraldOfTheArcLightSummon);
            AddExecutor(ExecutorType.Activate, CardId.HeraldOfTheArcLight);
            activatem.Add(CardId.HeraldOfTheArcLight);
            
            AddExecutor(ExecutorType.MonsterSet, CardId.GraydleSlimeJr);
            AddExecutor(ExecutorType.MonsterSet, CardId.DupeFrog);
            AddExecutor(ExecutorType.MonsterSet, CardId.Ronintoadin);

            // cards got by Toadally Awesome
            AddExecutor(ExecutorType.Activate, CardId.CallOfTheHaunted, SurfaceEffect);
            activatem.Add(CardId.CallOfTheHaunted);

            //ZexalWeaponsExecutor
            // Spell cards
            AddExecutor(ExecutorType.Activate, CardId.ReinforcementOfTheArmy, ReinforcementOfTheArmy);
            activatem.Add(CardId.ReinforcementOfTheArmy);
            AddExecutor(ExecutorType.Activate, CardId.XyzChangeTactics, XyzChangeTactics);
            activatem.Add(CardId.XyzChangeTactics);
            
            // XYZ summons
            AddExecutor(ExecutorType.SpSummon, CardId.Number39Utopia);
            AddExecutor(ExecutorType.SpSummon, CardId.NumberS39UtopiaOne);
            AddExecutor(ExecutorType.SpSummon, CardId.NumberS39UtopiatheLightning);
            AddExecutor(ExecutorType.SpSummon, CardId.Number61Volcasaurus, Number61Volcasaurus);
            AddExecutor(ExecutorType.SpSummon, CardId.ZwLionArms);
            AddExecutor(ExecutorType.SpSummon, CardId.AdreusKeeperOfArmageddon);

            // XYZ effects
            AddExecutor(ExecutorType.Activate, CardId.Number39Utopia, Number39Utopia);
            activatem.Add(CardId.Number39Utopia);
            AddExecutor(ExecutorType.Activate, CardId.NumberS39UtopiaOne);
            activatem.Add(CardId.NumberS39UtopiaOne);
            AddExecutor(ExecutorType.Activate, CardId.NumberS39UtopiatheLightning, DefaultNumberS39UtopiaTheLightningEffect);
            activatem.Add(CardId.NumberS39UtopiatheLightning);
            AddExecutor(ExecutorType.Activate, CardId.ZwLionArms, ZwLionArms);
            activatem.Add(CardId.ZwLionArms);
            AddExecutor(ExecutorType.Activate, CardId.AdreusKeeperOfArmageddon);
            activatem.Add(CardId.AdreusKeeperOfArmageddon);
            AddExecutor(ExecutorType.Activate, CardId.Number61Volcasaurus);
            activatem.Add(CardId.Number61Volcasaurus);
            
            // Weapons
            AddExecutor(ExecutorType.Activate, CardId.ZwTornadoBringer, ZwWeapon);
            activatem.Add(CardId.ZwTornadoBringer);
            AddExecutor(ExecutorType.Activate, CardId.ZwLightningBlade, ZwWeapon);
            activatem.Add(CardId.ZwLightningBlade);
            AddExecutor(ExecutorType.Activate, CardId.ZwAsuraStrike, ZwWeapon);
            activatem.Add(CardId.ZwAsuraStrike);
            

            // Special summons
            AddExecutor(ExecutorType.SpSummon, CardId.PhotonTrasher);
            AddExecutor(ExecutorType.SpSummon, CardId.SolarWindJammer, SolarWindJammer);

            AddExecutor(ExecutorType.Activate, CardId.InstantFusion, InstantFusion);
            activatem.Add(CardId.InstantFusion);
            
            // Normal summons
            AddExecutor(ExecutorType.Summon, CardId.Goblindbergh, GoblindberghFirst);
            AddExecutor(ExecutorType.Summon, CardId.TinGoldfish, GoblindberghFirst);
            AddExecutor(ExecutorType.Summon, CardId.StarDrawing);
            AddExecutor(ExecutorType.Summon, CardId.SacredCrane);
            AddExecutor(ExecutorType.Summon, CardId.HeroicChallengerExtraSword);
            AddExecutor(ExecutorType.Summon, CardId.Goblindbergh);
            AddExecutor(ExecutorType.Summon, CardId.TinGoldfish);
            AddExecutor(ExecutorType.Summon, CardId.SummonerMonk);

            // Summons: Effects
            AddExecutor(ExecutorType.Activate, CardId.Goblindbergh, GoblindberghEffect);
            activatem.Add(CardId.Goblindbergh);
            AddExecutor(ExecutorType.Activate, CardId.TinGoldfish, GoblindberghEffect);
            activatem.Add(CardId.TinGoldfish);
            AddExecutor(ExecutorType.Activate, CardId.Kagetokage, KagetokageEffect);
            activatem.Add(CardId.Kagetokage);
            AddExecutor(ExecutorType.Activate, CardId.SummonerMonk, SummonerMonkEffect);
            activatem.Add(CardId.SummonerMonk);
            AddExecutor(ExecutorType.Activate, CardId.Honest, DefaultHonestEffect);
            activatem.Add(CardId.Honest);
            
            // Spummon GaiaDragonTheThunderCharger if Volcasaurus or ZwLionArms had been used
            AddExecutor(ExecutorType.SpSummon, CardId.GaiaDragonTheThunderCharger);

            AddExecutor(ExecutorType.Activate, CardId.BreakthroughSkill, DefaultBreakthroughSkill);
            activatem.Add(CardId.BreakthroughSkill);
            AddExecutor(ExecutorType.Activate, CardId.SolemnWarning, DefaultSolemnWarning);
            activatem.Add(CardId.SolemnWarning);
            
            //OldSchoolExecutor
            AddExecutor(ExecutorType.Activate, CardId.HeavyStorm, DefaultHeavyStorm);
            activatem.Add(CardId.HeavyStorm);
            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.HammerShot, DefaultHammerShot);
            activatem.Add(CardId.HammerShot);
            AddExecutor(ExecutorType.Activate, CardId.Fissure);
            activatem.Add(CardId.Fissure);
            AddExecutor(ExecutorType.Activate, CardId.SwordsOfRevealingLight, SwordsOfRevealingLight);
            activatem.Add(CardId.SwordsOfRevealingLight);
            AddExecutor(ExecutorType.Activate, CardId.DoubleSummon, DoubleSummon);
            activatem.Add(CardId.DoubleSummon);
            
            AddExecutor(ExecutorType.Summon, CardId.AncientGearGolem, DefaultMonsterSummon);
            AddExecutor(ExecutorType.Summon, CardId.Frostosaurus, DefaultMonsterSummon);
            AddExecutor(ExecutorType.SummonOrSet, CardId.AlexandriteDragon);
            AddExecutor(ExecutorType.SummonOrSet, CardId.GeneWarpedWarwolf);
            AddExecutor(ExecutorType.MonsterSet, CardId.GearGolemTheMovingFortress);
            AddExecutor(ExecutorType.SummonOrSet, CardId.EvilswarmHeliotrope);
            AddExecutor(ExecutorType.SummonOrSet, CardId.LusterDragon);
            AddExecutor(ExecutorType.SummonOrSet, CardId.InsectKnight);
            AddExecutor(ExecutorType.SummonOrSet, CardId.ArchfiendSoldier);

            //Level8Executor
            AddExecutor(ExecutorType.Activate, CardId.CalledbyTheGrave, DefaultCalledByTheGrave);
            activatem.Add(CardId.CalledbyTheGrave);
            AddExecutor(ExecutorType.Repos, CardId.Number41BagooskaTheTerriblyTiredTapir, MonsterRepos);
            AddExecutor(ExecutorType.Activate, CardId.BorreloadSavageDragon, BorreloadSavageDragonEffect);
            activatem.Add(CardId.BorreloadSavageDragon);
            AddExecutor(ExecutorType.Activate, CardId.ScrapGolem, ScrapGolemEffect);
            activatem.Add(CardId.ScrapGolem);
            
            // empty field
            AddExecutor(ExecutorType.Activate, CardId.UnexpectedDai, UnexpectedDaiFirst);
            AddExecutor(ExecutorType.SpSummon, CardId.PhotonThrasher, PhotonThrasherSummonFirst);
            AddExecutor(ExecutorType.Activate, CardId.UnexpectedDai);
            activatem.Add(CardId.UnexpectedDai);
            AddExecutor(ExecutorType.SpSummon, CardId.PhotonThrasher);

            // 
            AddExecutor(ExecutorType.Activate, CardId.ReinforcementofTheArmy, ReinforcementofTheArmyEffect);
            activatem.Add(CardId.ReinforcementofTheArmy);
            
            // scrap combo
            AddExecutor(ExecutorType.Summon, CardId.ScrapRecycler, ScrapRecyclerSummonFirst);
            AddExecutor(ExecutorType.Activate, CardId.ScrapRecycler, ScrapRecyclerEffect);
            activatem.Add(CardId.ScrapRecycler);
            AddExecutor(ExecutorType.Activate, CardId.MechaPhantomBeastOLion, MechaPhantomBeastOLionEffect);
            activatem.Add(CardId.MechaPhantomBeastOLion);
            AddExecutor(ExecutorType.SpSummon, CardId.ScrapWyvern, ScrapWyvernSummon);
            AddExecutor(ExecutorType.Activate, CardId.ScrapWyvern, ScrapWyvernEffect);
            activatem.Add(CardId.ScrapWyvern);
            
            AddExecutor(ExecutorType.Activate, CardId.JetSynchron, JetSynchronEffect);
            activatem.Add(CardId.JetSynchron);
            AddExecutor(ExecutorType.SpSummon, CardId.CrystronNeedlefiber, CrystronNeedlefiberSummon);
            AddExecutor(ExecutorType.Activate, CardId.CrystronNeedlefiber, CrystronNeedlefiberEffect);
            activatem.Add(CardId.CrystronNeedlefiber);
            
            AddExecutor(ExecutorType.SpSummon, CardId.MekkKnightCrusadiaAstram, MekkKnightCrusadiaAstramSummon);
            AddExecutor(ExecutorType.Activate, CardId.MekkKnightCrusadiaAstram, MekkKnightCrusadiaAstramEffect);
            activatem.Add(CardId.MekkKnightCrusadiaAstram);
            
            //
            AddExecutor(ExecutorType.Activate, CardId.ChargeofTheLightBrigade);
            activatem.Add(CardId.ChargeofTheLightBrigade);
            
            // other summon
            AddExecutor(ExecutorType.Summon, CardId.MaskedChameleon, MaskedChameleonSummonFirst);
            AddExecutor(ExecutorType.Activate, CardId.MaskedChameleon, MaskedChameleonEffect);
            activatem.Add(CardId.MaskedChameleon);
            
            AddExecutor(ExecutorType.SpSummon, CardId.WhiteRoseDragon);
            AddExecutor(ExecutorType.Summon, CardId.WhiteRoseDragon, WhiteRoseDragonSummonFirst);
            AddExecutor(ExecutorType.Activate, CardId.WhiteRoseDragon, WhiteRoseDragonEffect);
            activatem.Add(CardId.WhiteRoseDragon);
            
            //
            AddExecutor(ExecutorType.Summon, CardId.RaidenHandofTheLightsworn, L4TunerSummonFirst);
            AddExecutor(ExecutorType.Summon, CardId.ScrapBeast, L4TunerSummonFirst);
            AddExecutor(ExecutorType.Summon, CardId.AngelTrumpeter, L4TunerSummonFirst);
            AddExecutor(ExecutorType.Summon, CardId.MaskedChameleon, L4TunerSummonFirst);

            AddExecutor(ExecutorType.Summon, CardId.PerformageTrickClown, L4NonTunerSummonFirst);
            AddExecutor(ExecutorType.Summon, CardId.Goblindbergh, L4NonTunerSummonFirst);
            AddExecutor(ExecutorType.Summon, CardId.WorldCarrotweightChampion, L4NonTunerSummonFirst);
            AddExecutor(ExecutorType.Summon, CardId.WhiteRoseDragon, L4NonTunerSummonFirst);

            AddExecutor(ExecutorType.Summon, CardId.RedRoseDragon, OtherTunerSummonFirst);
            AddExecutor(ExecutorType.Summon, CardId.JetSynchron, OtherTunerSummonFirst);
            AddExecutor(ExecutorType.Summon, CardId.MechaPhantomBeastOLion, OtherTunerSummonFirst);

            AddExecutor(ExecutorType.Summon, CardId.RaidenHandofTheLightsworn);
            AddExecutor(ExecutorType.Summon, CardId.ScrapBeast);
            AddExecutor(ExecutorType.Summon, CardId.PerformageTrickClown);
            AddExecutor(ExecutorType.Summon, CardId.AngelTrumpeter);
            AddExecutor(ExecutorType.Summon, CardId.WorldCarrotweightChampion);
            AddExecutor(ExecutorType.Summon, CardId.MaskedChameleon);
            AddExecutor(ExecutorType.Summon, CardId.WhiteRoseDragon);

            AddExecutor(ExecutorType.Summon, CardId.RedRoseDragon);
            AddExecutor(ExecutorType.Summon, CardId.JetSynchron);
            AddExecutor(ExecutorType.Summon, CardId.MechaPhantomBeastOLion);

            AddExecutor(ExecutorType.Summon, CardId.ScrapRecycler);

            AddExecutor(ExecutorType.Activate, CardId.RedRoseDragon);
            activatem.Add(CardId.RedRoseDragon);
            AddExecutor(ExecutorType.Activate, CardId.RaidenHandofTheLightsworn);
            activatem.Add(CardId.RaidenHandofTheLightsworn);
            AddExecutor(ExecutorType.Activate, CardId.PerformageTrickClown, PerformageTrickClownEffect);
            activatem.Add(CardId.PerformageTrickClown);
            
            AddExecutor(ExecutorType.Activate, CardId.WorldCarrotweightChampion, WorldCarrotweightChampionEffect);
            activatem.Add(CardId.WorldCarrotweightChampion);
            
            // extra monsters
            AddExecutor(ExecutorType.SpSummon, CardId.BorreloadSavageDragon, BorreloadSavageDragonSummon);

            AddExecutor(ExecutorType.SpSummon, CardId.ScrapDragon, ScrapDragonSummon);
            AddExecutor(ExecutorType.Activate, CardId.ScrapDragon, ScrapDragonEffect);
            activatem.Add(CardId.ScrapDragon);
            AddExecutor(ExecutorType.SpSummon, CardId.ScarlightRedDragonArchfiend, DefaultScarlightRedDragonArchfiendSummon);
            AddExecutor(ExecutorType.Activate, CardId.ScarlightRedDragonArchfiend, DefaultScarlightRedDragonArchfiendEffect);
            activatem.Add(CardId.ScarlightRedDragonArchfiend);
            
            AddExecutor(ExecutorType.SpSummon, CardId.PSYFramelordOmega);
            AddExecutor(ExecutorType.Activate, CardId.PSYFramelordOmega, PSYFramelordOmegaEffect);
            activatem.Add(CardId.PSYFramelordOmega);
            
            AddExecutor(ExecutorType.SpSummon, CardId.WhiteAuraBihamut);
            AddExecutor(ExecutorType.Activate, CardId.WhiteAuraBihamut);
            activatem.Add(CardId.WhiteAuraBihamut);
            
            AddExecutor(ExecutorType.SpSummon, CardId.GardenRoseMaiden);
            AddExecutor(ExecutorType.Activate, CardId.GardenRoseMaiden);
            activatem.Add(CardId.GardenRoseMaiden);
            
            AddExecutor(ExecutorType.SpSummon, CardId.CoralDragon);
            AddExecutor(ExecutorType.Activate, CardId.CoralDragon, CoralDragonEffect);
            activatem.Add(CardId.CoralDragon);
            
            AddExecutor(ExecutorType.SpSummon, CardId.ShootingRiserDragon, ShootingRiserDragonSummon);
            AddExecutor(ExecutorType.Activate, CardId.ShootingRiserDragon, ShootingRiserDragonEffect);
            activatem.Add(CardId.ShootingRiserDragon);
            
            AddExecutor(ExecutorType.SpSummon, CardId.BlackRoseMoonlightDragon);

            AddExecutor(ExecutorType.SpSummon, CardId.Number41BagooskaTheTerriblyTiredTapir, Number41BagooskaTheTerriblyTiredTapirSummon);

            AddExecutor(ExecutorType.Summon, CardId.ScrapGolem, ScrapGolemSummon);

            AddExecutor(ExecutorType.SpellSet, CardId.CalledbyTheGrave);
            AddExecutor(ExecutorType.SpellSet, CardId.SolemnStrike);



            AddExecutor(ExecutorType.Activate, CardId.Scapegoat, DefaultScapegoat);
            activatem.Add(CardId.Scapegoat);
            AddExecutor(ExecutorType.Activate, _CardId.GhostOgreAndSnowRabbit, DefaultGhostOgreAndSnowRabbit);
            activatem.Add(CardId.GhostOgreAndSnowRabbit);
            AddExecutor(ExecutorType.Activate, _CardId.GhostBelle, DefaultGhostBelleAndHauntedMansion);
            activatem.Add(CardId.GhostBelle);
            AddExecutor(ExecutorType.Activate, _CardId.EffectVeiler, DefaultEffectVeiler);
            activatem.Add(CardId.EffectVeiler);
            AddExecutor(ExecutorType.Activate, _CardId.SmashingGround, DefaultSmashingGround);
            activatem.Add(CardId.SmashingGround);
            AddExecutor(ExecutorType.Activate, _CardId.AllureofDarkness, DefaultAllureofDarkness);
            activatem.Add(_CardId.AllureofDarkness);
            AddExecutor(ExecutorType.Activate, _CardId.InterruptedKaijuSlumber, DefaultInterruptedKaijuSlumber);
            activatem.Add(_CardId.InterruptedKaijuSlumber);
            AddExecutor(ExecutorType.SpSummon, _CardId.JizukirutheStarDestroyingKaiju, DefaultKaijuSpsummon);
            AddExecutor(ExecutorType.SpSummon, _CardId.GadarlatheMysteryDustKaiju, DefaultKaijuSpsummon);
            AddExecutor(ExecutorType.SpSummon, _CardId.GamecieltheSeaTurtleKaiju, DefaultKaijuSpsummon);
            AddExecutor(ExecutorType.SpSummon, _CardId.RadiantheMultidimensionalKaiju, DefaultKaijuSpsummon);
            AddExecutor(ExecutorType.SpSummon, _CardId.KumongoustheStickyStringKaiju, DefaultKaijuSpsummon);
            AddExecutor(ExecutorType.SpSummon, _CardId.ThunderKingtheLightningstrikeKaiju, DefaultKaijuSpsummon);
            AddExecutor(ExecutorType.SpSummon, _CardId.DogorantheMadFlameKaiju, DefaultKaijuSpsummon);
            AddExecutor(ExecutorType.SpSummon, _CardId.SuperAntiKaijuWarMachineMechaDogoran, DefaultKaijuSpsummon);

            AddExecutor(ExecutorType.SpSummon, _CardId.EvilswarmExcitonKnight, DefaultEvilswarmExcitonKnightSummon);
            AddExecutor(ExecutorType.Activate, _CardId.EvilswarmExcitonKnight, DefaultEvilswarmExcitonKnightEffect);
            activatem.Add(_CardId.EvilswarmExcitonKnight);

            AddExecutor(ExecutorType.Summon, _CardId.SandaionTheTimelord, DefaultTimelordSummon);
            AddExecutor(ExecutorType.Summon, _CardId.GabrionTheTimelord, DefaultTimelordSummon);
            AddExecutor(ExecutorType.Summon, _CardId.MichionTheTimelord, DefaultTimelordSummon);
            AddExecutor(ExecutorType.Summon, _CardId.ZaphionTheTimelord, DefaultTimelordSummon);
            AddExecutor(ExecutorType.Summon, _CardId.HailonTheTimelord, DefaultTimelordSummon);
            AddExecutor(ExecutorType.Summon, _CardId.RaphionTheTimelord, DefaultTimelordSummon);
            AddExecutor(ExecutorType.Summon, _CardId.SadionTheTimelord, DefaultTimelordSummon);
            AddExecutor(ExecutorType.Summon, _CardId.MetaionTheTimelord, DefaultTimelordSummon);
            AddExecutor(ExecutorType.Summon, _CardId.KamionTheTimelord, DefaultTimelordSummon);
            AddExecutor(ExecutorType.Summon, _CardId.LazionTheTimelord, DefaultTimelordSummon);

            AddExecutor(ExecutorType.Summon, _CardId.LeftArmofTheForbiddenOne, JustDontIt);
            AddExecutor(ExecutorType.Summon, _CardId.RightLegofTheForbiddenOne, JustDontIt);
            AddExecutor(ExecutorType.Summon, _CardId.LeftLegofTheForbiddenOne, JustDontIt);
            AddExecutor(ExecutorType.Summon, _CardId.RightArmofTheForbiddenOne, JustDontIt);
            AddExecutor(ExecutorType.Summon, _CardId.ExodiaTheForbiddenOne, JustDontIt);

            //KCG
            AddExecutor(ExecutorType.Activate, CardId.Costdown, Costdown);
            activatem.Add(CardId.Costdown);
            AddExecutor(ExecutorType.Activate, CardId.CrossSacriface, CrossSacriface);
            activatem.Add(CardId.CrossSacriface);
            AddExecutor(ExecutorType.Activate, CardId.Oricha, Oricha);
            activatem.Add(CardId.Oricha);

            AddExecutor(ExecutorType.SpSummon);
            AddExecutor(ExecutorType.Activate, () => !Card.IsCode(activatem) && OtherSpellEffect());
            AddExecutor(ExecutorType.Activate, () => !Card.IsCode(activatem) && OtherTrapEffect());
            AddExecutor(ExecutorType.Activate, () => !Card.IsCode(activatem) && OtherMonsterEffect());

            AddExecutor(ExecutorType.SummonOrSet, Advancesummon);
            AddExecutor(ExecutorType.SpellSet, Spellset);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);

            AddExecutor(ExecutorType.Activate, CardId.TreasureDraw, TreasureDraw);
        }

        List<int> should_not_negate = new List<int>
        {
            81275020, 28985331
        };

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
            BalancerLordUsed = false;
            Multifaker_ssfromhand = false;
            Multifaker_ssfromdeck = false;
            Marionetter_reborn = false;
            Hexstia_searched = false;
            Meluseek_searched = false;
            summoned = false;
            Silquitous_bounced = false;
            Silquitous_recycled = false;
            ss_other_monster = false;
            Impermanence_list.Clear();
            attacked_Meluseek.Clear();

            UsedAlternativeWhiteDragon.Clear();
            UsedGalaxyEyesCipherDragon = null;
            AlternativeWhiteDragonSummoned = false;
            SoulChargeUsed = false;

            Talismandra_used = false;
            Candoll_used = false;

            CrystalWingSynchroDragon_used = false;
            Secret_used = false;
            maxxc_used = false;
            lockbird_used = false;
            ghost_used = false;
            WindwitchGlassBelleff_used = false;
            Spellbook_summon = false;
            Rod_summon = false;
            GlassBell_summon = false;
            magician_sp = false;
            big_attack = false;
            big_attack_used = false;
            soul_used = false;

            ZwCount = 0;

            BeastOLionUsed = false;
            JetSynchronUsed = false;
            ScrapWyvernUsed = false;
            MaskedChameleonUsed = false;
            ShootingRiserDragonCount = 0;

            base.OnNewTurn();
        }

        public override CardPosition OnSelectPosition(int cardId, IList<CardPosition> positions)
        {
            if (Util.IsTurn1OrMain2()
               && (cardId == CardId.Meluseek || cardId == CardId.Silquitous))
            {
                return CardPosition.FaceUpDefence;
            }

            YGOSharp.OCGWrapper.NamedCard cardData = YGOSharp.OCGWrapper.NamedCard.Get(cardId);
            if (cardData != null)
            {
                if ((cardId == 78371393 || cardId == 4779091 || cardId == 31764700 || cardId == 24 || cardId == 900000098) && !Card.IsDisabled())
                    return CardPosition.FaceUpAttack;
                if (Util.IsAllEnemyBetterThanValue(cardData.Attack, true) && !cardData.HasType(CardType.Xyz))
                    return CardPosition.FaceUpDefence;
                return CardPosition.FaceUpAttack;
            }

            return 0;
        }

        public override bool OnSelectYesNo(long desc)
        {
            if ((desc == Util.GetStringId(826, 12) && Duel.Player == 1) || desc == Util.GetStringId(827, 6) || desc == Util.GetStringId(827, 1) || desc == Util.GetStringId(13709, 11) || desc == Util.GetStringId(123106, 8) || desc == Util.GetStringId(123106, 7) || desc == Util.GetStringId(13709, 12) || desc == Util.GetStringId(826, 6) || desc == Util.GetStringId(13713, 8) || desc == Util.GetStringId(827, 1))
                return false;
            if (desc == 210) // Continue selecting? (Link Summoning)
                return false;
            if (desc == 31) // Direct Attack?
                return true;
            return base.OnSelectYesNo(desc);
        }

        public override IList<ClientCard> OnSelectCard(IList<ClientCard> _cards, int min, int max, long hint, bool cancelable)
        {
            IList<ClientCard> selected = new List<ClientCard>();
            IList<ClientCard> cards = new List<ClientCard>(_cards);

            if (max == 2 && cards[0].Location == CardLocation.Deck)
            {
                Logger.DebugWriteLine("OnSelectCard MelodyOfAwakeningDragon");
                List<ClientCard> result = new List<ClientCard>();
                if (!Bot.HasInHand(CardId.WhiteDragon))
                    result.AddRange(cards.Where(card => card.IsCode(CardId.WhiteDragon)).Take(1));
                result.AddRange(cards.Where(card => card.IsCode(CardId.AlternativeWhiteDragon)));
                return Util.CheckSelectCount(result, cards, min, max);
            }

            if (Duel.Phase == DuelPhase.BattleStart)
                return null;
            if (AI.HaveSelectedCards())
                return null;
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

        public override int OnSelectPlace(long cardId, int player, CardLocation location, int available)
        {
            if (location == CardLocation.SpellZone)
            {
                if (cardId == CardId.MekkKnightCrusadiaAstram || cardId == CardId.ScrapWyvern || cardId == CardId.CrystronNeedlefiber)
                {
                    ClientCard b = Bot.MonsterZone.GetFirstMatchingCard(card => card.Id == CardId.BorreloadSavageDragon);
                    int zone = (1 << (b?.Sequence ?? 0)) & available;
                    if (zone > 0)
                        return zone;
                }
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

            if (player == 0)
            {
                if (location == CardLocation.SpellZone)
                {
                    //undefined
                }
                else if (location == CardLocation.MonsterZone)
                {
                    if (cardId == CardId.Linkuriboh)
                    {
                        if ((Zones.z5 & available) > 0) return Zones.z5;
                        if ((Zones.z6 & available) > 0) return Zones.z6;
                        for (int i = 4; i >= 0; --i)
                        {
                            if (Bot.MonsterZone[i] == null)
                            {
                                int place = (int)System.Math.Pow(2, i);
                                return place;
                            }
                        }
                    }
                    if (isAltergeist(cardId))
                    {
                        if (Bot.HasInMonstersZone(CardId.Hexstia))
                        {
                            for (int i = 0; i < 7; ++i)
                            {
                                if (i == 4) continue;
                                if (Bot.MonsterZone[i] != null && Bot.MonsterZone[i].IsCode(CardId.Hexstia))
                                {
                                    int next_index = get_Hexstia_linkzone(i);
                                    if (next_index != -1 && (available & (int)(System.Math.Pow(2, next_index))) > 0)
                                    {
                                        return (int)(System.Math.Pow(2, next_index));
                                    }
                                }
                            }
                        }
                        if (cardId == CardId.Hexstia)
                        {
                            // ex zone
                            if ((Zones.z5 & available) > 0 && Bot.MonsterZone[1] != null && isAltergeist(Bot.MonsterZone[1].Id)) return Zones.z5;
                            if ((Zones.z6 & available) > 0 && Bot.MonsterZone[3] != null && isAltergeist(Bot.MonsterZone[3].Id)) return Zones.z6;
                            if (((Zones.z6 & available) > 0 && Bot.MonsterZone[3] != null && !isAltergeist(Bot.MonsterZone[3].Id))
                                || ((Zones.z5 & available) > 0 && Bot.MonsterZone[1] == null)) return Zones.z5;
                            if (((Zones.z5 & available) > 0 && Bot.MonsterZone[1] != null && !isAltergeist(Bot.MonsterZone[1].Id))
                                || ((Zones.z6 & available) > 0 && Bot.MonsterZone[3] == null)) return Zones.z6;
                            // main zone
                            for (int i = 1; i < 5; ++i)
                            {
                                if (Bot.MonsterZone[i] != null && isAltergeist(Bot.MonsterZone[i].Id))
                                {
                                    if ((available & (int)System.Math.Pow(2, i - 1)) > 0) return (int)System.Math.Pow(2, i - 1);
                                }
                            }
                        }
                        // 1 or 3
                        if ((Zones.z1 & available) > 0) return Zones.z1;
                        if ((Zones.z3 & available) > 0) return Zones.z3;
                    }
                }
            }

            return base.OnSelectPlace(cardId, player, location, available);
        }

        public override int OnAnnounceCard(IList<int> avail)
        {
            ClientCard last_card = Util.GetLastChainCard();
            ClientCard orica = Bot.GetFieldSpellCard();
            if (orica == null)
                return 12201;
            if (avail.Contains(802))
                return 802;
            return Program.Rand.Next(avail.Count);
        }

        public override int OnAnnounceNumber(IList<int> numbers)
        {
            return numbers.Count > 1 ? numbers.Count - 1 : 0;
        }

        public override int OnSelectOption(IList<long> options)
        {
            if (options[0] == Util.GetStringId(826, 15))
                return 0;
            return options.Count > 1 ? options.Count - 1 : 0;
        }

        public override bool OnSelectHand()
        {
            // go first
            return true;
        }

        public bool MonsterRepos()
        {
            if (Card.Attack == 0) return (Card.IsAttack() && Card.Id != 78371393 && Card.Id != 4779091 && Card.Id != 31764700 && Card.Id != 24 && Card.Id != 900000098);
            if (Card.Id == 78371393 || Card.Id == 4779091 || Card.Id == 31764700 || Card.Id == 24 || Card.Id == 900000098) return (Card.IsDefense());

            if (Card.IsCode(CardId.Meluseek) || Bot.HasInMonstersZone(CardId.Meluseek))
            {
                return Card.HasPosition(CardPosition.Defence);
            }

            if (isAltergeist(Card) && Bot.HasInHandOrInSpellZone(CardId.Protocol) && Card.IsFacedown())
                return true;

            if (Card.IsFacedown())
                return true;
            if (Card.IsCode(CardId.Number41BagooskaTheTerriblyTiredTapir) && Card.IsDefense())
                return Card.Overlays.Count == 0;

            bool enemyBetter = Util.IsAllEnemyBetter(true);
            if (Card.IsAttack() && enemyBetter)
                return true;
            if (Card.IsFacedown())
                return true;
            if (Card.IsDefense() && !enemyBetter && Card.Attack >= Card.Defense)
                return true;
            if (Card.IsDefense() && Card.IsCode(CardId.BlueEyesSpiritDragon, CardId.AzureEyesSilverDragon))
                return true;
            if (Card.IsAttack() && Card.IsCode(CardId.SageWithEyesOfBlue, CardId.WhiteStoneOfAncients, CardId.WhiteStoneOfLegend))
                return true;

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

        public bool MonsterSummon()
        {
            if (Enemy.GetMonsterCount() + Bot.GetMonsterCount() > 0) return false;
            return Card.Attack >= Enemy.LifePoints;
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
            if (attacker.IsCode(CardId.BlueEyesChaosMaxDragon) && !attacker.IsDisabled() &&
               Enemy.HasInMonstersZone(new[] { CardId.DeviritualTalismandra, CardId.DevirrtualCandoll }))
            {
                for (int i = 0; i < defenders.Count; i++)
                {
                    ClientCard defender = defenders[i];
                    attacker.RealPower = attacker.Attack;
                    defender.RealPower = defender.GetDefensePower();
                    if (attacker.IsCode(CardId.Borrelsword) && !attacker.IsDisabled())
                        return AI.Attack(attacker, defender);
                    if (!OnPreBattleBetween(attacker, defender))
                        continue;
                    if (defender.IsCode(CardId.DevirrtualCandoll, CardId.DeviritualTalismandra))
                    {
                        return AI.Attack(attacker, defender);
                    }
                }
            }

            for (int i = 0; i < defenders.Count; ++i)
            {
                ClientCard defender = defenders[i];
                attacker.RealPower = attacker.Attack;
                defender.RealPower = defender.GetDefensePower();
                if (defender.IsCode(732) && defender.IsAttack())
                    defender.RealPower = defender.Attack * 2;
                if (attacker.RealPower >= defender.RealPower || (attacker.RealPower >= defender.RealPower && ((attacker.HasSetcode(0x48) && !attacker.IsDisabled() && !(defender.HasSetcode(0x48) && !defender.IsDisabled())) || attacker.IsLastAttacker && defender.IsAttack())))
                    return AI.Attack(attacker, defender);
                if ((attacker.Id == 78371393 || attacker.Id == 4779091 || attacker.Id == 31764700 || attacker.Id == 24 || attacker.Id == 900000098) && !attacker.IsDisabled())
                    return AI.Attack(attacker, defender);
            }

            if (Enemy.GetMonsterCount() == 0 || attacker.CanDirectAttack)
                return AI.Attack(attacker, null);
            return null;
        }

        public override IList<ClientCard> OnSelectXyzMaterial(IList<ClientCard> cards, int min, int max)
        {
            Logger.DebugWriteLine("OnSelectXyzMaterial " + cards.Count + " " + min + " " + max);
            IList<ClientCard> result = Util.SelectPreferredCards(UsedAlternativeWhiteDragon, cards, min, max);
            return Util.CheckSelectCount(result, cards, min, max);
        }

        public override IList<ClientCard> OnSelectSynchroMaterial(IList<ClientCard> cards, int sum, int min, int max)
        {
            Logger.DebugWriteLine("OnSelectSynchroMaterial " + cards.Count + " " + sum + " " + min + " " + max);
            if (sum != 8)
                return null;

            foreach (ClientCard AlternativeWhiteDragon in UsedAlternativeWhiteDragon)
            {
                if (cards.IndexOf(AlternativeWhiteDragon) > 0)
                {
                    UsedAlternativeWhiteDragon.Remove(AlternativeWhiteDragon);
                    Logger.DebugWriteLine("select UsedAlternativeWhiteDragon");
                    return new[] { AlternativeWhiteDragon };
                }
            }

            return null;
        }

        private bool Advancesummon()
        {
            if (Card.Level > 4 && DefaultMonsterSummon() && (Bot.MonsterZone.GetMonsters().GetMatchingCardsCount(card => card.Level > 0 || card.IsDisabled() || (card.Attack == 0 && card.BaseAttack > 0)) > 0 || Bot.SpellZone.GetMonsters().GetMatchingCardsCount(card => card.Level > 0 || card.IsDisabled() || (card.Attack == 0 && card.BaseAttack > 0)) > 0))
            {
                List<ClientCard> monster_sorted = new List<ClientCard>();
                List<ClientCard> monster_sorted0 = new List<ClientCard>();
                IList<ClientCard> monster_sorted01 = Bot.MonsterZone.GetMonsters();
                IList<ClientCard> monster_sorted02 = Bot.SpellZone.GetMonsters();
                IList<ClientCard> monster_sorted1 = Bot.MonsterZone.GetMonsters().GetMatchingCards(card => card.IsDisabled() || (card.Attack < card.BaseAttack -500));
                IList<ClientCard> monster_sorted2 = Bot.SpellZone.GetMonsters().GetMatchingCards(card => card.IsDisabled() || (card.Attack < card.BaseAttack -500));
                foreach (ClientCard monster in monster_sorted01)
                {
                    monster_sorted.Add(monster);
                }
                foreach (ClientCard monster in monster_sorted02)
                {
                    monster_sorted.Add(monster);
                }
                foreach (ClientCard card in monster_sorted)
                {
                    if (card.IsDisabled() || (card.Attack < card.BaseAttack - 500))
                    {
                        monster_sorted.Remove(card);
                        monster_sorted0.Add(card);
                    }
                }
                foreach (ClientCard card in monster_sorted0)
                {
                    monster_sorted.Add(card);
                }
                monster_sorted0.Sort(CardContainer.CompareCardAttack);
                List<ClientCard> tribute = new List<ClientCard>();
                foreach (ClientCard monster in monster_sorted0)
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

        private bool TreasureDraw()
        {
            if (6 - Bot.GetHandCount() > 0 && Bot.Deck.Count <= 6 - Bot.GetHandCount())
                return false;
            return true;
        }

        //ST1732Executor
        private bool LinkslayerEffect()
        {
            IList<ClientCard> targets = Enemy.GetSpells();
            if (targets.Count > 0)
            {
                AI.SelectCard(
                    CardId.DualAssembloom,
                    CardId.Bitron,
                    CardId.Digitron,
                    CardId.RecodedAlive
                    );
                AI.SelectNextCard(targets);
                return true;
            }
            return false;
        }

        private bool MindControlEffect()
        {
            ClientCard target = Util.GetBestEnemyMonster();
            if (target != null)
            {
                AI.SelectCard(target);
                return true;
            }
            return false;
        }

        private bool BacklinkerEffect()
        {
            return (Bot.MonsterZone[5] == null) && (Bot.MonsterZone[6] == null);
        }

        private bool BootStagguardEffect()
        {
            if (Card.Location != CardLocation.Hand)
                AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }

        private bool MonsterRebornEffect()
        {
            IList<int> targets = new[] {
                    CardId.DecodeTalker,
                    CardId.EncodeTalker,
                    CardId.TriGateWizard,
                    CardId.BinarySorceress,
                    CardId.Honeybot,
                    CardId.DualAssembloom,
                    CardId.BootStagguard,
                    CardId.BalancerLord,
                    CardId.ROMCloudia,
                    CardId.Linkslayer,
                    CardId.RAMClouder,
                    CardId.Backlinker,
                    CardId.Kleinant
                };
            if (!Bot.HasInGraveyard(targets))
            {
                return false;
            }
            AI.SelectCard(targets);
            return true;
        }

        private bool MoonMirrorShieldEffect()
        {
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                AI.SelectCard(monster);
                return true;
            }
            return false;
        }

        private bool CynetUniverseEffect()
        {
            if (Card.Location == CardLocation.Hand)
                return DefaultField();
            foreach (ClientCard card in Enemy.Graveyard)
            {
                if (card.IsMonster())
                {
                    AI.SelectCard(card);
                    return true;
                }
            }
            return false;
        }

        private bool CynetBackdoorEffect()
        {
            if (!(Duel.Player == 0 && Duel.Phase == DuelPhase.Main2) &&
                !(Duel.Player == 1 && (Duel.Phase == DuelPhase.BattleStart || Duel.Phase == DuelPhase.End)))
            {
                return false;
            }
            if (!UniqueFaceupSpell())
                return false;
            bool selected = false;
            foreach (ClientCard monster in Bot.GetMonstersInExtraZone())
            {
                if (monster.Attack > 1000)
                {
                    AI.SelectCard(monster);
                    selected = true;
                    break;
                }
            }
            if (!selected)
            {
                List<ClientCard> monsters = Bot.GetMonsters();
                foreach (ClientCard monster in monsters)
                {
                    if (monster.IsCode(CardId.BalancerLord))
                    {
                        AI.SelectCard(monster);
                        selected = true;
                        break;
                    }
                }
                if (!selected)
                {
                    foreach (ClientCard monster in monsters)
                    {
                        if (monster.Attack >= 1700)
                        {
                            AI.SelectCard(monster);
                            selected = true;
                            break;
                        }
                    }
                }
            }
            if (selected)
            {
                AI.SelectNextCard(
                    CardId.ROMCloudia,
                    CardId.BalancerLord,
                    CardId.Kleinant,
                    CardId.Draconnet,
                    CardId.Backlinker
                    );
                return true;
            }
            return false;
        }

        private bool BalancerLordSummon()
        {
            return !BalancerLordUsed;
        }

        private bool BalancerLordEffect()
        {
            if (Card.Location == CardLocation.Removed)
                return true;
            bool hastarget = Bot.HasInHand(new[] {
                    CardId.Draconnet,
                    CardId.Kleinant,
                    CardId.BalancerLord,
                    CardId.ROMCloudia,
                    CardId.RAMClouder,
                    CardId.DotScaper
                });
            if (hastarget && !BalancerLordUsed)
            {
                BalancerLordUsed = true;
                return true;
            }
            return false;
        }

        private bool ROMCloudiaSummon()
        {
            return Bot.HasInGraveyard(new[] {
                    CardId.BootStagguard,
                    CardId.BalancerLord,
                    CardId.Kleinant,
                    CardId.Linkslayer,
                    CardId.Draconnet,
                    CardId.RAMClouder
                });
        }

        private bool ROMCloudiaEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(
                    CardId.BootStagguard,
                    CardId.BalancerLord,
                    CardId.Kleinant,
                    CardId.Linkslayer,
                    CardId.Draconnet,
                    CardId.RAMClouder
                    );
                return true;
            }
            else
            {
                AI.SelectCard(
                    CardId.BalancerLord,
                    CardId.Kleinant,
                    CardId.RAMClouder,
                    CardId.DotScaper
                    );
                return true;
            }
        }

        private bool DraconnetSummon()
        {
            return Bot.GetRemainingCount(CardId.Digitron, 1) > 0
                || Bot.GetRemainingCount(CardId.Bitron, 1) > 0;
        }

        private bool DraconnetEffect()
        {
            AI.SelectCard(CardId.Bitron);
            return true;
        }

        private bool KleinantEffect()
        {
            IList<int> targets = new[] {
                CardId.DualAssembloom,
                CardId.Bitron,
                CardId.Digitron,
                CardId.DotScaper
            };
            foreach (ClientCard monster in Bot.Hand)
            {
                if (monster.IsCode(targets))
                {
                    AI.SelectCard(targets);
                    return true;
                }
            }
            IList<int> targets2 = new[] {
                CardId.StagToken,
                CardId.Bitron,
                CardId.Digitron,
                CardId.DotScaper
            };
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if (monster.IsCode(targets2))
                {
                    AI.SelectCard(targets2);
                    return true;
                }
            }
            return false;
        }

        private bool RAMClouderEffect()
        {
            AI.SelectCard(
                CardId.StagToken,
                CardId.Bitron,
                CardId.Digitron,
                CardId.DotScaper,
                CardId.Draconnet,
                CardId.Backlinker,
                CardId.RAMClouder
                );
            AI.SelectNextCard(
                CardId.DecodeTalker,
                CardId.EncodeTalker,
                CardId.TriGateWizard,
                CardId.BinarySorceress,
                CardId.Honeybot,
                CardId.DualAssembloom,
                CardId.BootStagguard,
                CardId.BalancerLord,
                CardId.ROMCloudia,
                CardId.Linkslayer,
                CardId.RAMClouder
                );
            return true;
        }

        private bool DotScaperEffect()
        {
            AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }

        private bool LinkSummon()
        {
            return (Util.IsTurn1OrMain2() || Util.IsOneEnemyBetter())
                && Util.GetBestAttack(Bot) < Card.Attack;
        }

        //AltergeistExecutor
        public bool EvenlyMatched_ready()
        {
            if (Bot.HasInHand(CardId.EvenlyMatched) && Bot.GetSpellCount() == 0)
            {
                if (Duel.Phase < DuelPhase.Main2 && Enemy.GetFieldCount() >= 3
                    && Bot.HasInMonstersZone(CardId.Iblee)) return true;
            }
            return false;
        }

        public bool has_altergeist_left()
        {
            return (Bot.GetRemainingCount(CardId.Marionetter, 3) > 0
                || Bot.GetRemainingCount(CardId.Multifaker, 2) > 0
                || Bot.GetRemainingCount(CardId.Meluseek, 3) > 0
                || Bot.GetRemainingCount(CardId.Silquitous, 2) > 0
                || Bot.GetRemainingCount(CardId.Kunquery, 1) > 0);
        }

        public bool EvenlyMatched_Repos()
        {
            if (EvenlyMatched_ready())
            {
                return (!Card.HasPosition(CardPosition.Attack));
            }
            return false;
        }

        public bool isAltergeist(long id)
        {
            return (id == CardId.Marionetter || id == CardId.Hexstia || id == CardId.Protocol
                || id == CardId.Multifaker || id == CardId.Meluseek || id == CardId.Kunquery
                || id == CardId.Manifestation || id == CardId.Silquitous);
        }

        public bool isAltergeist(ClientCard card)
        {
            return card.IsCode(CardId.Marionetter, CardId.Hexstia, CardId.Protocol, CardId.Multifaker, CardId.Meluseek,
                CardId.Kunquery, CardId.Manifestation, CardId.Silquitous);
        }

        public int GetSequence(ClientCard card)
        {
            if (Card.Location != CardLocation.MonsterZone) return -1;
            for (int i = 0; i < 7; ++i)
            {
                if (Bot.MonsterZone[i] == card) return i;
            }
            return -1;
        }

        public bool trap_can_activate(int id)
        {
            if (id == CardId.WakingtheDragon || id == CardId.EvenlyMatched) return false;
            if (id == CardId.SolemnStrike && Bot.LifePoints <= 1500) return false;
            return true;
        }

        public bool Should_counter()
        {
            if (Duel.CurrentChain.Count < 2) return true;
            if (!Protocol_activing()) return true;
            ClientCard self_card = Duel.CurrentChain[Duel.CurrentChain.Count - 2];
            if (self_card?.Controller != 0
                || !(self_card.Location == CardLocation.MonsterZone || self_card.Location == CardLocation.SpellZone)
                || !isAltergeist(self_card)) return true;
            ClientCard enemy_card = Duel.CurrentChain[Duel.CurrentChain.Count - 1];
            if (enemy_card?.Controller != 1
                || !enemy_card.IsCode(normal_counter)) return true;
            return false;
        }

        public bool Should_activate_Protocol()
        {
            if (Duel.CurrentChain.Count < 2) return false;
            if (Protocol_activing()) return false;
            ClientCard self_card = Duel.CurrentChain[Duel.CurrentChain.Count - 2];
            if (self_card?.Controller != 0
                || !(self_card.Location == CardLocation.MonsterZone || self_card.Location == CardLocation.SpellZone)
                || !isAltergeist(self_card)) return false;
            ClientCard enemy_card = Duel.CurrentChain[Duel.CurrentChain.Count - 1];
            if (enemy_card?.Controller != 1
                || !enemy_card.IsCode(normal_counter)) return false;
            return true;
        }

        public bool is_should_not_negate()
        {
            ClientCard last_card = Util.GetLastChainCard();
            if (last_card != null
                && last_card.Controller == 1 && last_card.IsCode(should_not_negate))
                return true;
            return false;
        }

        public bool Multifaker_can_ss()
        {
            foreach (ClientCard sp in Bot.GetSpells())
            {
                if (sp.IsTrap() && sp.IsFacedown() && trap_can_activate(sp.Id))
                {
                    return true;
                }
            }
            foreach (ClientCard h in Bot.Hand)
            {
                if (h.IsTrap() && trap_can_activate(h.Id))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Multifaker_candeckss()
        {
            return (!Multifaker_ssfromdeck && !ss_other_monster);
        }

        public bool Protocol_activing()
        {
            foreach (ClientCard card in Bot.GetSpells())
            {
                if (card.IsCode(CardId.Protocol) && card.IsFaceup() && !card.IsDisabled() && !Duel.CurrentChain.Contains(card)) return true;
            }
            return false;
        }

        public int GetTotalATK(IList<ClientCard> list)
        {
            int atk = 0;
            foreach (ClientCard c in list)
            {
                if (c == null) continue;
                atk += c.Attack;
            }
            return atk;
        }

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

        public int SelectSetPlace(List<int> avoid_list = null)
        {
            List<int> list = new List<int>();
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
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
                    if (avoid_list != null && avoid_list.Contains(seq)) continue;
                    return zone;
                };
            }
            return 0;
        }

        public bool spell_trap_activate(bool isCounter = false, ClientCard target = null)
        {
            if (target == null) target = Card;
            if (target.Location != CardLocation.SpellZone && target.Location != CardLocation.Hand) return true;
            if (Enemy.HasInMonstersZone(CardId.NaturalExterio, true) && !Bot.HasInHandOrHasInMonstersZone(CardId.GO_SR) && !isCounter && !Bot.HasInSpellZone(CardId.SolemnStrike)) return false;
            if (target.IsSpell())
            {
                if (Enemy.HasInMonstersZone(CardId.NaturalBeast, true) && !Bot.HasInHandOrHasInMonstersZone(CardId.GO_SR) && !isCounter && !Bot.HasInSpellZone(CardId.SolemnStrike)) return false;
                if (Enemy.HasInSpellZone(CardId.ImperialOrder, true) || Bot.HasInSpellZone(CardId.ImperialOrder, true)) return false;
                if (Enemy.HasInMonstersZone(CardId.SwordsmanLV7, true) || Bot.HasInMonstersZone(CardId.SwordsmanLV7, true)) return false;
                return true;
            }
            if (target.IsTrap())
            {
                if (Enemy.HasInSpellZone(CardId.RoyalDecreel, true) || Bot.HasInSpellZone(CardId.RoyalDecreel, true)) return false;
                return true;
            }
            // how to get here?
            return false;
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

        public int get_Hexstia_linkzone(int zone)
        {
            if (zone >= 0 && zone < 4) return zone + 1;
            if (zone == 5) return 1;
            if (zone == 6) return 3;
            return -1;
        }

        public bool get_linked_by_Hexstia(int place)
        {
            if (place == 0) return false;
            if (place == 2 || place == 4)
            {
                int last_place = place - 1;
                return (Bot.MonsterZone[last_place] != null && Bot.MonsterZone[last_place].IsCode(CardId.Hexstia));
            }
            if (place == 1 || place == 3)
            {
                int last_place_1, last_place_2;
                if (place == 1)
                {
                    last_place_1 = 0;
                    last_place_2 = 5;
                }
                else
                {
                    last_place_1 = 2;
                    last_place_2 = 6;
                }
                if (Bot.MonsterZone[last_place_1] != null && Bot.MonsterZone[last_place_1].IsCode(CardId.Hexstia)) return true;
                if (Bot.MonsterZone[last_place_2] != null && Bot.MonsterZone[last_place_2].IsCode(CardId.Hexstia)) return true;
                return false;
            }
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

        public bool bot_can_s_Meluseek()
        {
            if (Duel.Player != 0) return false;
            foreach (ClientCard card in Bot.GetMonsters())
            {
                if (card.IsCode(CardId.Meluseek) && !card.IsDisabled() && !card.Attacked) return true;
            }
            if (Bot.HasInMonstersZone(CardId.Meluseek)) return true;
            if (Bot.HasInMonstersZone(CardId.Marionetter) && !Marionetter_reborn && Bot.HasInGraveyard(CardId.Meluseek)) return true;
            if (!summoned
                && (Bot.HasInHand(CardId.Meluseek)
                || (Bot.HasInHand(CardId.Marionetter) && Bot.HasInGraveyard(CardId.Meluseek)))
                ) return true;
            return false;
        }

        public bool SpellSet()
        {
            if (Duel.Phase == DuelPhase.Main1 && Bot.HasAttackingMonster() && Duel.Turn > 1) return false;
            if (Card.IsCode(CardId.EvenlyMatched) && !Bot.HasInHandOrInSpellZone(CardId.Spoofing)
                && !Bot.HasInHandOrInSpellZone(CardId.Protocol) && !Bot.HasInHandOrInSpellZone(CardId.ImperialOrder)) return false;
            if (Card.IsCode(CardId.EvenlyMatched) && Bot.HasInSpellZone(CardId.EvenlyMatched)) return false;
            if (Card.IsCode(CardId.SolemnStrike) && Bot.LifePoints <= 1500) return false;
            if (Card.IsCode(CardId.Spoofing) && Bot.HasInSpellZone(CardId.Spoofing)) return false;
            if (Card.IsCode(CardId.Manifestation) && Bot.HasInHandOrInSpellZone(CardId.Spoofing))
            {
                bool can_activate = false;
                foreach (ClientCard g in Bot.GetGraveyardMonsters())
                {
                    if (g.IsMonster() && isAltergeist(g))
                    {
                        can_activate = true;
                        break;
                    }
                }
                Logger.DebugWriteLine("Manifestation_set: " + can_activate.ToString());
                if (!can_activate) return false;
            }
            if ((Card.IsTrap() || Card.HasType(CardType.QuickPlay)))
            {
                List<int> avoid_list = new List<int>();
                int Impermanence_set = 0;
                for (int i = 0; i < 5; ++i)
                {
                    if (Enemy.SpellZone[i] != null && Enemy.SpellZone[i].IsFaceup() && Bot.SpellZone[4 - i] == null)
                    {
                        avoid_list.Add(4 - i);
                        Impermanence_set += (int)System.Math.Pow(2, 4 - i);
                    }
                }
                if (Bot.HasInHand(CardId.Impermanence))
                {
                    if (Card.IsCode(CardId.Impermanence))
                    {
                        AI.SelectPlace(Impermanence_set);
                        return true;
                    }
                    else
                    {
                        AI.SelectPlace(SelectSetPlace(avoid_list));
                        return true;
                    }
                }
                else
                {
                    AI.SelectPlace(SelectSTPlace());
                }
                return true;
            }
            else if (Enemy.HasInSpellZone(CardId.Anti_Spell, true) || Bot.HasInSpellZone(CardId.Anti_Spell, true))
            {
                if (Card.IsSpell() && (!Card.IsCode(CardId.OneForOne) || Bot.GetRemainingCount(CardId.Meluseek, 3) > 0))
                {
                    AI.SelectPlace(SelectSTPlace());
                    return true;
                }
            }
            return false;
        }

        public bool field_activate()
        {
            if (Card.HasPosition(CardPosition.FaceDown) && Card.HasType(CardType.Field) && Card.Location == CardLocation.SpellZone)
            {
                // field spells that forbid other fields' activate
                return !Card.IsCode(71650854, 78082039);
            }
            return false;
        }

        public bool ChickenGame()
        {
            Logger.DebugWriteLine("Use override");
            if (!spell_trap_activate()) return false;
            if (Bot.LifePoints <= 1000)
                return false;
            if (Bot.LifePoints - 1000 <= Enemy.LifePoints && ActivateDescription == Util.GetStringId(_CardId.ChickenGame, 0))
            {
                return true;
            }
            if (Bot.LifePoints - 1000 > Enemy.LifePoints && ActivateDescription == Util.GetStringId(_CardId.ChickenGame, 1))
            {
                return true;
            }
            return false;
        }

        public bool Anti_Spell_activate()
        {
            foreach (ClientCard card in Bot.GetSpells())
            {
                if (card.IsCode(CardId.Anti_Spell) && card.IsFaceup() && Duel.LastChainPlayer == 0) return false;
            }
            return true;
        }

        public bool SecretVillage_activate()
        {
            if (!spell_trap_activate()) return false;
            if (Bot.SpellZone[5] != null && Bot.SpellZone[5].IsFaceup() && Bot.SpellZone[5].IsCode(CardId.SecretVillage) && Bot.SpellZone[5].Disabled == 0) return false;

            if (Multifaker_can_ss() && Bot.HasInHand(CardId.Multifaker)) return true;
            foreach (ClientCard card in Bot.GetMonsters())
            {
                if (card != null && card.IsFaceup() && (card.Race & (int)CardRace.SpellCaster) != 0 && !card.IsCode(CardId.Meluseek)) return true;
            }
            return false;
        }

        public bool G_activate()
        {
            return (Duel.Player == 1);
        }

        public bool NaturalExterio_eff()
        {
            if (Duel.LastChainPlayer != 0)
            {
                AI.SelectCard(
                    _CardId.HarpiesFeatherDuster,
                    CardId.PotofDesires,
                    CardId.OneForOne,
                    CardId.GO_SR,
                    CardId.AB_JS,
                    CardId.GR_WC,
                    CardId.MaxxC,
                    CardId.Spoofing,
                    CardId.SolemnJudgment,
                    CardId.SolemnStrike,
                    CardId.ImperialOrder,
                    CardId.Spoofing,
                    CardId.Storm,
                    CardId.EvenlyMatched,
                    CardId.WakingtheDragon,
                    CardId.Impermanence,
                    CardId.Marionetter
                    );
                return true;
            }
            return false;
        }

        public bool SolemnStrike_activate()
        {
            if (!Should_counter()) return false;
            return (DefaultSolemnStrike() && spell_trap_activate(true));
        }

        public bool SolemnJudgment_activate()
        {
            if (Util.IsChainTargetOnly(Card) && (Bot.HasInHand(CardId.Multifaker) || Multifaker_candeckss())) return false;
            if (!Should_counter()) return false;
            if ((DefaultSolemnJudgment() && spell_trap_activate(true)))
            {
                ClientCard target = Util.GetLastChainCard();
                if (target != null && !target.IsMonster() && !spell_trap_activate(false, target)) return false;
                return true;
            }
            return false;
        }

        public bool Impermanence_activate()
        {
            if (!Should_counter()) return false;
            if (!spell_trap_activate()) return false;
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

            if (LastChainCard == null
                && !(Duel.Player == 1 && Duel.Phase > DuelPhase.Main2 && Bot.HasInHand(CardId.Multifaker) && Multifaker_candeckss() && !Multifaker_ssfromhand))
                return false;
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
                    || (LastChainCard != null && LastChainCard.Controller == 1 && LastChainCard.IsCode(_CardId.HarpiesFeatherDuster))
                    || (Duel.Player == 1 && Duel.Phase > DuelPhase.Main2 && Bot.HasInHand(CardId.Multifaker) && Multifaker_candeckss() && !Multifaker_ssfromhand))
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
                || LastChainCard.IsDisabled() || LastChainCard.IsShouldNotBeTarget() || LastChainCard.IsShouldNotBeSpellTrapTarget())
                && !(Duel.Player == 1 && Duel.Phase > DuelPhase.Main2 && Bot.HasInHand(CardId.Multifaker) && Multifaker_candeckss() && !Multifaker_ssfromhand))
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

        public bool Hand_act_eff()
        {
            if (Card.IsCode(CardId.AB_JS) && Util.GetLastChainCard().HasSetcode(0x11e) && Util.GetLastChainCard().Location == CardLocation.Hand) // Danger! archtype hand effect
                return false;
            if (Card.IsCode(CardId.GO_SR) && Card.Location == CardLocation.Hand && Bot.HasInMonstersZone(CardId.GO_SR)) return false;
            return (Duel.LastChainPlayer == 1);
        }

        public bool WakingtheDragon_eff()
        {
            if (Bot.HasInExtra(CardId.NaturalExterio) && !Multifaker_ssfromdeck)
            {
                bool has_skystriker = false;
                foreach (ClientCard card in Enemy.Graveyard)
                {
                    if (card != null && card.IsCode(SkyStrike_list))
                    {
                        has_skystriker = true;
                        break;
                    }
                }
                if (!has_skystriker)
                {
                    foreach (ClientCard card in Enemy.GetSpells())
                    {
                        if (card != null && card.IsCode(SkyStrike_list))
                        {
                            has_skystriker = true;
                            break;
                        }
                    }
                }
                if (!has_skystriker)
                {
                    foreach (ClientCard card in Enemy.GetSpells())
                    {
                        if (card != null && card.IsCode(SkyStrike_list))
                        {
                            has_skystriker = true;
                            break;
                        }
                    }
                }
                if (has_skystriker)
                {
                    AI.SelectCard(CardId.NaturalExterio);
                    ss_other_monster = true;
                    return true;
                }
            }
            IList<int> ex_list = new[] {
                CardId.UltimateFalcon,
                CardId.Borrelsword,
                CardId.NaturalExterio,
                CardId.FWD,
                CardId.TripleBurstDragon,
                CardId.HeavymetalfoesElectrumite,
                CardId.Isolde,
                CardId.Hexstia,
                CardId.Needlefiber,
                CardId.Multifaker,
                CardId.Kunquery
            };
            foreach (int id in ex_list)
            {
                if (Bot.HasInExtra(id))
                {
                    if (!isAltergeist(id))
                    {
                        if (Multifaker_ssfromdeck) continue;
                        ss_other_monster = true;
                    }
                    Logger.DebugWriteLine(id.ToString());
                    AI.SelectCard(id);
                    return true;
                }
            }
            return true;
        }

        public bool GR_WC_activate()
        {
            int warrior_count = 0;
            int pendulum_count = 0;
            int link_count = 0;
            int altergeis_count = 0;
            bool has_skystriker_acer = false;
            bool has_tuner = false;
            bool has_level_1 = false;
            foreach (ClientCard card in Enemy.MonsterZone)
            {
                if (card == null) continue;
                if (card.IsCode(CardId.Kagari, CardId.Shizuku, CardId.Hayate, CardId.Raye, CardId.Drones_Token)) has_skystriker_acer = true;
                if (card.HasType(CardType.Pendulum)) pendulum_count++;
                if ((card.Race & (int)CardRace.Warrior) != 0) warrior_count++;
                if (card.IsTuner() && (Enemy.GetMonsterCount() >= 2)) has_tuner = true;
                if (isAltergeist(card)) altergeis_count++;
                if (!card.HasType(CardType.Link) && !card.HasType(CardType.Xyz) && card.Level == 1) has_level_1 = true;
                link_count += (card.HasType(CardType.Link) ? card.LinkCount : 1);
            }
            if (has_skystriker_acer)
            {
                if (!Enemy.HasInBanished(CardId.Kagari) && Bot.HasInExtra(CardId.Kagari))
                {
                    AI.SelectCard(CardId.Kagari);
                    return true;
                }
                else if (!Enemy.HasInBanished(CardId.Shizuku) && Bot.HasInExtra(CardId.Shizuku))
                {
                    AI.SelectCard(CardId.Shizuku);
                    return true;
                }
            }
            if (pendulum_count >= 2 && !(Enemy.HasInMonstersZoneOrInGraveyard(CardId.HeavymetalfoesElectrumite) || Enemy.HasInBanished(CardId.HeavymetalfoesElectrumite)) && Bot.HasInExtra(CardId.HeavymetalfoesElectrumite))
            {
                AI.SelectCard(CardId.HeavymetalfoesElectrumite);
                return true;
            }
            if (warrior_count >= 2 && !(Enemy.HasInMonstersZoneOrInGraveyard(CardId.Isolde) || Enemy.HasInBanished(CardId.Isolde)) && Bot.HasInExtra(CardId.Isolde))
            {
                AI.SelectCard(CardId.Isolde);
                return true;
            }
            if (has_tuner && !Enemy.HasInBanished(CardId.Needlefiber) && Bot.HasInExtra(CardId.Needlefiber) && !Enemy.HasInMonstersZone(CardId.Needlefiber))
            {
                AI.SelectCard(CardId.Needlefiber);
                return true;
            }
            if (has_level_1 && !Enemy.HasInHandOrInMonstersZoneOrInGraveyard(CardId.Linkuriboh) && !Enemy.HasInBanished(CardId.Linkuriboh) && Bot.HasInExtra(CardId.Linkuriboh))
            {
                AI.SelectCard(CardId.Linkuriboh);
                return true;
            }
            if (altergeis_count > 0 && !Enemy.HasInBanished(CardId.Hexstia) && Bot.HasInExtra(CardId.Hexstia))
            {
                AI.SelectCard(CardId.Hexstia);
                return true;
            }
            if (link_count >= 4)
            {
                if ((Bot.HasInMonstersZone(CardId.UltimateFalcon) || Bot.HasInMonstersZone(CardId.NaturalExterio)) && !(Enemy.HasInMonstersZoneOrInGraveyard(CardId.Borrelsword) || Enemy.HasInBanished(CardId.Borrelsword)) && Bot.HasInExtra(CardId.Borrelsword))
                {
                    AI.SelectCard(CardId.Borrelsword);
                    return true;
                }
                if (!(Enemy.HasInMonstersZoneOrInGraveyard(CardId.FWD) || Enemy.HasInBanished(CardId.FWD)) && Bot.HasInExtra(CardId.FWD))
                {
                    AI.SelectCard(CardId.FWD);
                    return true;
                }
            }

            return false;
        }

        public bool ImperialOrder_activate()
        {
            if (!Card.HasPosition(CardPosition.FaceDown)) return true;
            foreach (ClientCard card in Enemy.GetSpells())
            {
                if (card.IsSpell() && spell_trap_activate()) return true;
            }
            if (Duel.Player == 1 && Duel.Phase > DuelPhase.Main2 && Bot.HasInHand(CardId.Multifaker) && (!Multifaker_ssfromhand && Multifaker_candeckss())) return true;
            return false;
        }

        public bool EvenlyMatched_activate()
        {
            if (!spell_trap_activate()) return false;
            return true;

            // use after ToBattle fix
            int bot_count = Bot.GetFieldCount();
            if (Card.Location == CardLocation.Hand) bot_count += 1;
            int enemy_count = Enemy.GetFieldCount();
            if (enemy_count - bot_count < 2) return false;

            if (Card.Location == CardLocation.Hand) AI.SelectPlace(SelectSTPlace(Card, true));
            return true;
        }

        public bool Feather_activate()
        {
            if (!spell_trap_activate()) return false;
            if (Util.GetProblematicEnemySpell() != null)
            {
                AI.SelectPlace(SelectSTPlace(Card, true));
                return true;
            }
            // activate when more than 2 cards
            if (Enemy.GetSpellCount() <= 1)
                return false;
            AI.SelectPlace(SelectSTPlace(Card, true));
            return true;
        }

        public bool Storm_activate()
        {
            if (!spell_trap_activate()) return false;
            List<ClientCard> select_list = new List<ClientCard>();
            int activate_immediately = 0;
            List<ClientCard> spells = Enemy.GetSpells();
            RandomSort(spells);
            foreach (ClientCard card in spells)
            {
                if (card != null)
                {
                    if (card.IsFaceup())
                    {
                        if (card.HasType(CardType.Equip) || card.HasType(CardType.Pendulum) || card.HasType(CardType.Field) || card.HasType(CardType.Continuous))
                        {
                            select_list.Add(card);
                            activate_immediately += 1;
                        }
                    }
                }
            }
            foreach (ClientCard card in spells)
            {
                if (card != null && card.IsFacedown())
                {
                    select_list.Add(card);
                }
            }
            foreach (ClientCard card in spells)
            {
                if (card != null && card.IsFaceup() && !select_list.Contains(card))
                {
                    select_list.Add(card);
                }
            }
            if (Duel.Phase == DuelPhase.End
                || activate_immediately >= 2
                || (Util.IsChainTarget(Card)
                    || (Util.GetLastChainCard() != null && Util.GetLastChainCard().Controller == 1 && Util.GetLastChainCard().IsCode(_CardId.HarpiesFeatherDuster))))
            {
                if (select_list.Count > 0)
                {
                    AI.SelectCard(select_list);
                    return true;
                }
            }
            return false;
        }

        public bool Kunquery_eff()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Duel.Phase > DuelPhase.Main1 && Duel.Phase < DuelPhase.Main2)
                {
                    if (Util.ChainContainsCard(CardId.Linkuriboh)) return false;
                    if (Bot.BattlingMonster == null || (Enemy.BattlingMonster.Attack >= Bot.BattlingMonster.GetDefensePower()) || Enemy.BattlingMonster.IsMonsterDangerous())
                    {
                        AI.SelectPosition(CardPosition.FaceUpDefence);
                        return true;
                    }
                }
                return false;
            }
            else
            {
                ClientCard target = GetProblematicEnemyCard_Alter(true, false);
                if (target != null)
                {
                    AI.SelectCard(target);
                    return true;
                }
                List<ClientCard> spells = Enemy.GetSpells();
                RandomSort(spells);
                foreach (ClientCard card in spells)
                {
                    if (card.IsFaceup() && !card.IsDisabled())
                    {
                        AI.SelectCard(card);
                        return true;
                    }
                }
                List<ClientCard> monsters = Enemy.GetMonsters();
                RandomSort(monsters);
                foreach (ClientCard card in monsters)
                {
                    if (card.IsFaceup() && !card.IsDisabled()
                        && !(card.IsShouldNotBeMonsterTarget() || card.IsShouldNotBeTarget()))
                    {
                        AI.SelectCard(card);
                        return true;
                    }
                }
                return false;
            }
        }

        public bool Marionetter_eff()
        {
            if (ActivateDescription == -1)
            {
                if (!Bot.HasInHandOrInSpellZone(CardId.Protocol) && Bot.GetRemainingCount(CardId.Protocol, 2) > 0)
                {
                    AI.SelectCard(CardId.Protocol, CardId.Manifestation);
                    AI.SelectPlace(SelectSetPlace());
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Manifestation, CardId.Protocol);
                    AI.SelectPlace(SelectSetPlace());
                    return true;
                }
            }
            else
            {
                if (Card.IsDisabled() && !Protocol_activing()) return false;
                int next_card = 0;
                bool choose_other = false;
                bool can_choose_other = false;
                foreach (ClientCard card in Bot.GetSpells())
                {
                    if (card.IsFaceup() && isAltergeist(card))
                    {
                        can_choose_other = true;
                        break;
                    }
                }
                if (!can_choose_other)
                {
                    foreach (ClientCard card in Bot.GetMonsters())
                    {
                        if (card.IsFaceup() && card != Card && isAltergeist(card))
                        {
                            can_choose_other = true;
                        }
                    }
                }
                if (!Util.IsTurn1OrMain2())
                {
                    ClientCard self_best = Util.GetBestBotMonster();
                    ClientCard enemy_best = Util.GetProblematicEnemyCard(self_best.Attack, true);
                    ClientCard enemy_target = GetProblematicEnemyCard_Alter(true, false);

                    if ((enemy_best != null || enemy_target != null)
                        && Bot.HasInGraveyard(CardId.Meluseek)) next_card = CardId.Meluseek;
                    else if (Enemy.GetMonsterCount() <= 1 && Bot.HasInGraveyard(CardId.Meluseek) && Enemy.GetFieldCount() > 0) next_card = CardId.Meluseek;
                    else if (Bot.HasInGraveyard(CardId.Hexstia) && Util.GetProblematicEnemySpell() == null && Util.GetOneEnemyBetterThanValue(3100, true) == null && can_choose_other)
                    {
                        next_card = CardId.Hexstia;
                        choose_other = (Util.GetOneEnemyBetterThanMyBest(true) != null);
                    }
                }
                else
                {
                    if (!Meluseek_searched && !Bot.HasInMonstersZone(CardId.Meluseek) && Bot.HasInGraveyard(CardId.Meluseek))
                    {
                        if (Multifaker_candeckss() && Bot.HasInGraveyard(CardId.Multifaker) && Bot.GetRemainingCount(CardId.Meluseek, 3) > 0)
                        {
                            next_card = CardId.Multifaker;
                        }
                        else
                        {
                            next_card = CardId.Meluseek;
                        }
                    }
                    else if (Multifaker_candeckss() && Bot.HasInGraveyard(CardId.Multifaker) && has_altergeist_left())
                    {
                        next_card = CardId.Multifaker;
                    }
                    else if (Bot.HasInGraveyard(CardId.Hexstia))
                    {
                        next_card = CardId.Hexstia;
                        choose_other = !(Bot.GetMonsterCount() > 1 || Bot.HasInHand(CardId.Multifaker));
                    }
                    else if (Bot.HasInGraveyard(CardId.Silquitous))
                    {
                        int alter_count = 0;
                        foreach (ClientCard card in Bot.Hand)
                        {
                            if (isAltergeist(card) && (card.IsTrap() || (!summoned && card.IsMonster()))) alter_count++;
                        }
                        foreach (ClientCard s in Bot.GetSpells())
                        {
                            if (isAltergeist(s)) alter_count++;
                        }
                        foreach (ClientCard m in Bot.GetMonsters())
                        {
                            if (isAltergeist(m) && m != Card) alter_count++;
                        }
                        if (alter_count > 0)
                        {
                            next_card = CardId.Silquitous;
                        }
                    }
                }
                if (next_card != 0)
                {
                    int Protocol_count = 0;
                    foreach (ClientCard h in Bot.Hand)
                    {
                        if (h.IsCode(CardId.Protocol)) Protocol_count++;
                    }
                    foreach (ClientCard s in Bot.GetSpells())
                    {
                        if (s.IsCode(CardId.Protocol)) Protocol_count += (s.IsFaceup() ? 11 : 1);
                    }
                    if (Protocol_count >= 12)
                    {
                        AI.SelectCard(CardId.Protocol);
                        AI.SelectNextCard(next_card);
                        Marionetter_reborn = true;
                        if (next_card == CardId.Meluseek && Util.IsTurn1OrMain2()) AI.SelectPosition(CardPosition.FaceUpDefence);
                        return true;
                    }
                    List<ClientCard> list = Bot.GetMonsters();
                    list.Sort(CardContainer.CompareCardAttack);
                    foreach (ClientCard card in list)
                    {
                        if (isAltergeist(card) && !(choose_other && card == Card))
                        {
                            AI.SelectCard(card);
                            AI.SelectNextCard(next_card);
                            if (next_card == CardId.Meluseek && Util.IsTurn1OrMain2()) AI.SelectPosition(CardPosition.FaceUpDefence);
                            Marionetter_reborn = true;
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                };
            }
            return false;
        }

        public bool Hexstia_eff()
        {
            if (Card.Location == CardLocation.MonsterZone && Duel.LastChainPlayer != 0 && (Protocol_activing() || !Card.IsDisabled()))
            {
                ClientCard target = Util.GetLastChainCard();
                if (target != null && !spell_trap_activate(false, target)) return false;
                if (!Should_counter()) return false;
                // check
                int this_seq = GetSequence(Card);
                if (this_seq != -1) this_seq = get_Hexstia_linkzone(this_seq);
                if (this_seq != -1)
                {
                    ClientCard linked_card = Bot.MonsterZone[this_seq];
                    if (linked_card != null && linked_card.IsCode(CardId.Hexstia))
                    {
                        int next_seq = get_Hexstia_linkzone(this_seq);
                        if (next_seq != -1 && Bot.MonsterZone[next_seq] != null && isAltergeist(Bot.MonsterZone[next_seq].Id)) return false;
                    }
                }
                return true;
            }
            if (ActivateDescription == Util.GetStringId(CardId.Hexstia, 0)) return false;
            if (Enemy.HasInSpellZone(82732705) && Bot.GetRemainingCount(CardId.Protocol, 3) > 0 && !Bot.HasInHandOrInSpellZone(CardId.Protocol))
            {
                AI.SelectCard(CardId.Protocol);
                return true;
            }
            if (Duel.Player == 0 && !summoned && Bot.GetRemainingCount(CardId.Marionetter, 3) > 0)
            {
                AI.SelectCard(CardId.Marionetter);
                return true;
            }
            if (!Bot.HasInHandOrHasInMonstersZone(CardId.Multifaker) && Bot.GetRemainingCount(CardId.Multifaker, 2) > 0 && Multifaker_can_ss())
            {
                AI.SelectCard(CardId.Multifaker);
                return true;
            }
            if (!Bot.HasInHand(CardId.Marionetter) && Bot.GetRemainingCount(CardId.Marionetter, 3) > 0)
            {
                AI.SelectCard(CardId.Marionetter);
                return true;
            }
            if (!Bot.HasInHandOrInSpellZone(CardId.Manifestation) && Bot.GetRemainingCount(CardId.Manifestation, 2) > 0)
            {
                AI.SelectCard(CardId.Manifestation);
                return true;
            }
            if (!Bot.HasInHandOrInSpellZone(CardId.Protocol) && Bot.GetRemainingCount(CardId.Protocol, 2) > 0)
            {
                AI.SelectCard(CardId.Protocol);
                return true;
            }
            AI.SelectCard(
                CardId.Meluseek,
                CardId.Kunquery,
                CardId.Marionetter,
                CardId.Multifaker,
                CardId.Manifestation,
                CardId.Protocol,
                CardId.Silquitous
                );
            return true;
        }

        public bool Meluseek_eff()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Meluseek, 0)
                || (ActivateDescription == -1 && Card.Location == CardLocation.MonsterZone))
            {
                attacked_Meluseek.Add(Card);
                ClientCard target = GetProblematicEnemyCard_Alter(true);
                if (target != null)
                {
                    AI.SelectCard(target);
                    return true;
                }
                target = Util.GetOneEnemyBetterThanMyBest(true, true);
                if (target != null)
                {
                    AI.SelectCard(target);
                    return true;
                }
                List<ClientCard> targets = Enemy.GetSpells();
                RandomSort(targets);
                if (targets.Count > 0)
                {
                    AI.SelectCard(targets[0]);
                    return true;
                }
                target = GetBestEnemyCard_random();
                if (target != null)
                {
                    AI.SelectCard(target);
                    return true;
                }
            }
            else
            {
                if (Duel.Player == 1)
                {
                    if (!Bot.HasInHandOrHasInMonstersZone(CardId.Multifaker) && Bot.GetRemainingCount(CardId.Multifaker, 2) > 0 && Multifaker_candeckss() && Multifaker_can_ss())
                    {
                        foreach (ClientCard set_card in Bot.GetSpells())
                        {
                            if (set_card.IsFacedown() && !set_card.IsCode(CardId.WakingtheDragon))
                            {
                                AI.SelectCard(CardId.Multifaker);
                                return true;
                            }
                        }
                    }
                    if (Bot.GetRemainingCount(CardId.Marionetter, 3) > 0)
                    {
                        AI.SelectCard(CardId.Marionetter);
                        return true;
                    }
                }
                else
                {
                    if (!summoned && !Bot.HasInHand(CardId.Marionetter) && Bot.GetRemainingCount(CardId.Marionetter, 3) > 0)
                    {
                        AI.SelectCard(CardId.Marionetter);
                        return true;
                    }
                    if (!Bot.HasInHandOrHasInMonstersZone(CardId.Multifaker) && Bot.GetRemainingCount(CardId.Multifaker, 2) > 0 && Multifaker_can_ss())
                    {
                        AI.SelectCard(CardId.Multifaker);
                        return true;
                    }
                    if (!Bot.HasInHand(CardId.Marionetter) && Bot.GetRemainingCount(CardId.Marionetter, 3) > 0)
                    {
                        AI.SelectCard(CardId.Marionetter);
                        return true;
                    }
                }
                AI.SelectCard(
                    CardId.Kunquery,
                    CardId.Marionetter,
                    CardId.Multifaker,
                    CardId.Silquitous
                    );
                return true;
            }
            return false;
        }

        public bool Multifaker_handss()
        {
            if (!Multifaker_candeckss() || Card.Location != CardLocation.Hand) return false;
            Multifaker_ssfromhand = true;
            if (Duel.Player != 0 && Util.GetOneEnemyBetterThanMyBest() != null) AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }

        public bool Multifaker_deckss()
        {
            if (Card.Location != CardLocation.Hand)
            {
                ClientCard Silquitous_target = GetProblematicEnemyCard_Alter(true);
                if (Duel.Player == 1 && Duel.Phase >= DuelPhase.Main2 && GetProblematicEnemyCard_Alter(true) == null && Bot.GetRemainingCount(CardId.Meluseek, 3) > 0)
                {
                    AI.SelectCard(CardId.Meluseek);
                    Multifaker_ssfromdeck = true;
                    return true;
                }
                else if (!Silquitous_bounced && !Bot.HasInMonstersZone(CardId.Silquitous) && Bot.GetRemainingCount(CardId.Silquitous, 2) > 0
                    && !(Duel.Player == 0 && Silquitous_target == null))
                {
                    AI.SelectCard(CardId.Silquitous);
                    Multifaker_ssfromdeck = true;
                    return true;
                }
                else if (!Meluseek_searched && !Bot.HasInMonstersZone(CardId.Meluseek) && Bot.GetRemainingCount(CardId.Meluseek, 3) > 0)
                {
                    AI.SelectCard(CardId.Meluseek);
                    Multifaker_ssfromdeck = true;
                    return true;
                }
                else if (Bot.GetRemainingCount(CardId.Kunquery, 1) > 0)
                {
                    AI.SelectCard(CardId.Kunquery);
                    Multifaker_ssfromdeck = true;
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Marionetter);
                    Multifaker_ssfromdeck = true;
                    return true;
                }
            }
            return false;
        }

        public bool Silquitous_eff()
        {
            if (ActivateDescription != Util.GetStringId(CardId.Silquitous, 0))
            {
                if (!Bot.HasInHandOrInSpellZone(CardId.Manifestation) && Bot.HasInGraveyard(CardId.Manifestation))
                {
                    AI.SelectCard(CardId.Manifestation);
                }
                else
                {
                    AI.SelectCard(CardId.Protocol);
                }
                Silquitous_recycled = true;
                return true;
            }
            else
            {
                ClientCard bounce_self = null;
                int Protocol_count = 0;
                ClientCard faceup_Protocol = null;
                ClientCard faceup_Manifestation = null;
                ClientCard selected_target = null;
                foreach (ClientCard spell in Bot.GetSpells())
                {
                    if (spell.IsCode(CardId.Protocol))
                    {
                        if (spell.IsFaceup())
                        {
                            faceup_Protocol = spell;
                            Protocol_count += 11;
                        }
                        else
                        {
                            Protocol_count++;
                        }
                    }
                    if (spell.IsCode(CardId.Manifestation) && spell.IsFaceup()) faceup_Manifestation = spell;
                    if (Duel.LastChainPlayer != 0 && Util.IsChainTarget(spell) && spell.IsFaceup() && isAltergeist(spell))
                    {
                        selected_target = spell;
                    }
                }
                if (Protocol_count >= 12)
                {
                    bounce_self = faceup_Protocol;
                }
                else if (Duel.Player == 0 && faceup_Protocol != null)
                {
                    bounce_self = faceup_Protocol;
                }
                else if (faceup_Manifestation != null)
                {
                    bounce_self = faceup_Manifestation;
                }
                ClientCard faceup_Multifaker = null;
                ClientCard faceup_monster = null;
                List<ClientCard> monster_list = Bot.GetMonsters();
                monster_list.Sort(CardContainer.CompareCardAttack);
                foreach (ClientCard card in monster_list)
                {
                    if (card.IsFaceup() && isAltergeist(card) && card != Card)
                    {
                        if (Duel.LastChainPlayer != 0 && Util.IsChainTarget(card) && card.IsFaceup())
                        {
                            selected_target = card;
                        }
                        if (faceup_Multifaker == null && card.IsCode(CardId.Multifaker)) faceup_Multifaker = card;
                        if (faceup_monster == null && !card.IsCode(CardId.Hexstia)) faceup_monster = card;
                    }
                }
                if (bounce_self == null)
                {
                    if (selected_target != null && selected_target != Card) bounce_self = selected_target;
                    else if (faceup_Multifaker != null) bounce_self = faceup_Multifaker;
                    else bounce_self = faceup_monster;
                }

                ClientCard card_should_bounce_immediately = GetProblematicEnemyCard_Alter(true);
                if (card_should_bounce_immediately != null && Duel.LastChainPlayer != 0 && !bot_can_s_Meluseek())
                {
                    Logger.DebugWriteLine("Silquitous: dangerous");
                    AI.SelectCard(bounce_self);
                    AI.SelectNextCard(card_should_bounce_immediately);
                    return true;
                }
                if (Duel.Phase > DuelPhase.Main1 && Duel.Phase < DuelPhase.Main2)
                {
                    if (Duel.LastChainPlayer != 0)
                    {
                        Logger.DebugWriteLine("Silquitous: battle");
                        if (Util.ChainContainsCard(CardId.Linkuriboh) || Bot.HasInHand(CardId.Kunquery)) return false;
                        if (Enemy.BattlingMonster != null && Bot.BattlingMonster != null && Enemy.BattlingMonster.GetDefensePower() >= Bot.BattlingMonster.GetDefensePower())
                        {
                            if (Bot.HasInMonstersZone(CardId.Kunquery)) AI.SelectCard(CardId.Kunquery);
                            else AI.SelectCard(bounce_self);
                            List<ClientCard> enemy_list = Enemy.GetMonsters();
                            enemy_list.Sort(CardContainer.CompareCardAttack);
                            enemy_list.Reverse();
                            foreach (ClientCard target in enemy_list)
                            {
                                if (target.IsAttack() && !target.IsShouldNotBeMonsterTarget() && !target.IsShouldNotBeTarget())
                                {
                                    AI.SelectNextCard(target);
                                    return true;
                                }
                            }
                            AI.SelectNextCard(Enemy.BattlingMonster);
                            return true;
                        }
                    }
                }
                else if (Duel.Phase > DuelPhase.Main2)
                {
                    if (Duel.LastChainPlayer != 0)
                    {
                        Logger.DebugWriteLine("Silquitous: end");
                        ClientCard enemy_card = GetBestEnemyCard_random();
                        if (enemy_card != null)
                        {
                            AI.SelectCard(bounce_self);
                            AI.SelectNextCard(enemy_card);
                            return true;
                        }
                    }
                }
                else if (Duel.Player == 0)
                {
                    Logger.DebugWriteLine("Silquitous: orenoturn");
                    if (Duel.Phase < DuelPhase.Main2 && summoned && bounce_self.IsMonster()) return false;
                    ClientCard enemy_card = GetBestEnemyCard_random();
                    if (enemy_card != null)
                    {
                        Logger.DebugWriteLine("Silquitous decide:" + bounce_self?.Name);
                        AI.SelectCard(bounce_self);
                        AI.SelectNextCard(enemy_card);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Manifestation_eff()
        {
            if (Card.Location == CardLocation.Grave)
            {
                if (Util.ChainContainsCard(CardId.Silquitous)) return false;
                if (!Bot.HasInHandOrInSpellZone(CardId.Protocol) && !Util.ChainContainsCard(CardId.Protocol))
                {
                    AI.SelectCard(CardId.Protocol);
                    return true;
                }
                return false;
            }
            else
            {
                if (Util.ChainContainsCard(CardId.Manifestation) || Util.ChainContainsCard(CardId.Spoofing)) return false;
                if (Duel.LastChainPlayer == 0 && !(Util.GetLastChainCard() != null && Util.GetLastChainCard().IsCode(CardId.Hexstia))) return false;

                if (Bot.HasInMonstersZone(CardId.Hexstia))
                {
                    bool has_position = false;
                    for (int i = 0; i < 7; ++i)
                    {
                        ClientCard target = Bot.MonsterZone[i];
                        if (target != null && target.IsCode(CardId.Hexstia))
                        {
                            int next_id = get_Hexstia_linkzone(i);
                            if (next_id != -1)
                            {
                                ClientCard next_card = Bot.MonsterZone[next_id];
                                if (next_card == null)
                                {
                                    has_position = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!has_position) return false;
                }

                if (Enemy.HasInMonstersZone(94977269) && Bot.HasInGraveyard(CardId.Silquitous))
                {
                    AI.SelectCard(CardId.Silquitous);
                    return true;
                }

                if (Multifaker_candeckss() && Bot.HasInGraveyard(CardId.Multifaker) && has_altergeist_left())
                {
                    if (Bot.HasInHand(CardId.Multifaker) && Bot.HasInGraveyard(CardId.Silquitous) && Bot.GetRemainingCount(CardId.Silquitous, 2) == 0)
                    {
                        AI.SelectCard(CardId.Silquitous);
                        return true;
                    }
                    else
                    {
                        AI.SelectCard(CardId.Multifaker);
                        return true;
                    }
                }
                List<int> choose_list = new List<int>();
                choose_list.Add(CardId.Hexstia);
                choose_list.Add(CardId.Silquitous);
                choose_list.Add(CardId.Meluseek);
                choose_list.Add(CardId.Marionetter);
                choose_list.Add(CardId.Kunquery);
                foreach (int id in choose_list)
                {
                    if (Bot.HasInGraveyard(id))
                    {
                        if (id == CardId.Kunquery
                            && (!Bot.HasInHand(CardId.Multifaker) || !Multifaker_candeckss())) continue;
                        AI.SelectCard(id);
                        return true;
                    }
                }

            }
            return false;
        }

        public bool Protocol_negate_better()
        {
            // skip if no one of enemy's monsters is better
            if (ActivateDescription == Util.GetStringId(CardId.Protocol, 1))
            {
                if (Util.GetOneEnemyBetterThanMyBest(true) == null) return false;
            }
            return Protocol_negate();
        }

        public bool Protocol_negate()
        {
            // negate
            if (ActivateDescription == Util.GetStringId(CardId.Protocol, 1) && (!Card.IsDisabled() || Protocol_activing()))
            {
                if (!Should_counter()) return false;
                if (is_should_not_negate()) return false;
                if (Should_activate_Protocol()) return false;
                foreach (ClientCard card in Bot.GetSpells())
                {
                    if (card.IsCode(CardId.Protocol) && card.IsFaceup() && card != Card
                        && (Card.IsFacedown() || !Card.IsDisabled()))
                    {
                        AI.SelectCard(card);
                        return true;
                    }
                }
                if (Bot.HasInMonstersZone(CardId.Hexstia))
                {
                    for (int i = 0; i < 7; ++i)
                    {
                        ClientCard target = Bot.MonsterZone[i];
                        if (target != null && isAltergeist(target) && target.IsFaceup())
                        {
                            if (target.IsCode(CardId.Hexstia))
                            {
                                int next_index = get_Hexstia_linkzone(i);
                                if (next_index != -1 && Bot.MonsterZone[next_index] != null && Bot.MonsterZone[next_index].IsFaceup() && isAltergeist(Bot.MonsterZone[next_index].Id)) continue;
                            }
                            if (!get_linked_by_Hexstia(i))
                            {
                                Logger.DebugWriteLine("negate_index: " + i.ToString());
                                AI.SelectCard(target);
                                return true;
                            }
                        }
                    }
                }
                List<int> cost_list = new List<int>();
                if (Util.ChainContainsCard(CardId.Manifestation)) cost_list.Add(CardId.Manifestation);
                if (!Card.IsDisabled()) cost_list.Add(CardId.Protocol);
                cost_list.Add(CardId.Multifaker);
                cost_list.Add(CardId.Marionetter);
                cost_list.Add(CardId.Kunquery);
                if (Meluseek_searched) cost_list.Add(CardId.Meluseek);
                if (Silquitous_bounced) cost_list.Add(CardId.Silquitous);
                for (int i = 0; i < 7; ++i)
                {
                    ClientCard card = Bot.MonsterZone[i];
                    if (card != null && card.IsCode(CardId.Hexstia))
                    {
                        int nextzone = get_Hexstia_linkzone(i);
                        if (nextzone != -1)
                        {
                            ClientCard linkedcard = Bot.MonsterZone[nextzone];
                            if (linkedcard == null || !isAltergeist(linkedcard))
                            {
                                cost_list.Add(CardId.Hexstia);
                            }
                        }
                        else
                        {
                            cost_list.Add(CardId.Hexstia);
                        }
                    }
                }
                if (!Silquitous_bounced) cost_list.Add(CardId.Silquitous);
                if (!Meluseek_searched) cost_list.Add(CardId.Meluseek);
                if (!Util.ChainContainsCard(CardId.Manifestation)) cost_list.Add(CardId.Manifestation);
                AI.SelectCard(cost_list);
                return true;
            }
            return false;
        }

        public bool Protocol_activate_not_use()
        {
            if (Util.GetLastChainCard() != null && Util.GetLastChainCard().Controller == 0 && Util.GetLastChainCard().IsTrap()) return false;
            if (ActivateDescription != Util.GetStringId(CardId.Protocol, 1))
            {
                if (Util.IsChainTarget(Card) && Card.IsFacedown()) return true;
                if (Should_activate_Protocol()) return true;
                if (!Multifaker_ssfromhand && Multifaker_candeckss() && (Bot.HasInHand(CardId.Multifaker) || Bot.HasInSpellZone(CardId.Spoofing)))
                {
                    if (!Bot.HasInMonstersZone(CardId.Hexstia)) return true;
                    for (int i = 0; i < 7; ++i)
                    {
                        if (i == 4) continue;
                        if (Bot.MonsterZone[i] != null && Bot.MonsterZone[i].IsCode(CardId.Hexstia))
                        {
                            int next_id = get_Hexstia_linkzone(i);
                            if (next_id != -1)
                            {
                                if (Bot.MonsterZone[next_id] == null) return true;
                            }
                        }
                    }
                }
                int can_bounce = 0;
                bool should_disnegate = false;
                foreach (ClientCard card in Bot.GetMonsters())
                {
                    if (isAltergeist(card))
                    {
                        if (card.IsCode(CardId.Silquitous) && card.IsFaceup() && !Silquitous_bounced) can_bounce += 10;
                        else if (card.IsFaceup() && !card.IsCode(CardId.Hexstia)) can_bounce++;
                        if (card.IsDisabled() && !Protocol_activing()) should_disnegate = true;
                    }
                }
                if (can_bounce == 10 || should_disnegate) return true;
                if (Duel.Phase > DuelPhase.Main1 && Duel.Phase < DuelPhase.Main2 && Bot.HasInHand(CardId.Kunquery) && Util.GetOneEnemyBetterThanMyBest() != null) return true;
            }
            return false;
        }

        public void Spoofing_select(IList<int> list)
        {
            foreach (ClientCard card in Duel.CurrentChain)
            {
                if (card != null
                    && card.Location == CardLocation.SpellZone && card.Controller == 0 && card.IsFaceup())
                {
                    if (card.IsCode(CardId.Manifestation))
                    {
                        AI.SelectCard(card);
                        return;
                    }
                }
            }
            foreach (ClientCard card in Bot.Hand)
            {
                foreach (int id in list)
                {
                    if (card.IsCode(id) && !(id == CardId.Multifaker && Util.GetLastChainCard() == card))
                    {
                        AI.SelectCard(card);
                        return;
                    }
                }
            }
            foreach (ClientCard card in Bot.GetSpells())
            {
                foreach (int id in list)
                {
                    if (card.IsFaceup() && card.IsCode(id))
                    {
                        AI.SelectCard(card);
                        return;
                    }
                }
            }
            foreach (ClientCard card in Bot.GetMonsters())
            {
                foreach (int id in list)
                {
                    if (card.IsFaceup() && card.IsCode(id))
                    {
                        AI.SelectCard(card);
                        return;
                    }
                }
            }
            AI.SelectCard((ClientCard)null);
        }

        public bool Spoofing_eff()
        {
            if (Util.ChainContainsCard(CardId.Spoofing)) return false;
            if (Card.IsDisabled()) return false;
            if (!Util.ChainContainPlayer(0) && !Multifaker_ssfromhand && Multifaker_candeckss() && Bot.HasInHand(CardId.Multifaker) && Card.HasPosition(CardPosition.FaceDown))
            {
                AI.SelectYesNo(false);
                return true;
            }
            bool has_cost = false;
            bool can_ss_Multifaker = Multifaker_can_ss() || Card.IsFacedown();
            // cost check(not select)
            if (Card.IsFacedown())
            {
                foreach (ClientCard card in Bot.Hand)
                {
                    if (isAltergeist(card))
                    {
                        has_cost = true;
                        break;
                    }
                }
                if (!has_cost)
                {
                    foreach (ClientCard card in Bot.GetSpells())
                    {
                        if (isAltergeist(card) && card.IsFaceup())
                        {
                            has_cost = true;
                            break;
                        }
                    }
                }
                if (!has_cost)
                {
                    foreach (ClientCard card in Bot.GetMonsters())
                    {
                        if (isAltergeist(card) && card.IsFaceup())
                        {
                            has_cost = true;
                            break;
                        }
                    }
                }
                if (!has_cost)
                {
                    foreach (ClientCard card in Bot.GetSpells())
                    {
                        if (isAltergeist(card) && card.IsFaceup())
                        {
                            has_cost = true;
                            break;
                        }
                    }
                }
                if (!has_cost) return false;
            }
            if (Duel.Player == 1)
            {
                if (!Multifaker_ssfromhand && Multifaker_candeckss() && !Bot.HasInHand(CardId.Multifaker) && can_ss_Multifaker)
                {
                    if (Bot.HasInHand(CardId.Silquitous))
                    {
                        foreach (ClientCard card in Bot.Hand)
                        {
                            if (card.IsCode(CardId.Silquitous))
                            {
                                AI.SelectCard(card);
                                AI.SelectNextCard(CardId.Multifaker, CardId.Kunquery);
                                return true;
                            }
                        }
                    }
                    else
                    {
                        Spoofing_select(new[]
                        {
                            CardId.Silquitous,
                            CardId.Manifestation,
                            CardId.Kunquery,
                            CardId.Marionetter,
                            CardId.Multifaker,
                            CardId.Protocol,
                            CardId.Meluseek
                        });
                        AI.SelectNextCard(
                            CardId.Multifaker,
                            CardId.Marionetter,
                            CardId.Meluseek,
                            CardId.Kunquery,
                            CardId.Silquitous
                            );
                        return true;
                    }
                }
            }
            else
            {
                ClientCard self_best = Util.GetBestBotMonster();
                int best_atk = self_best == null ? 0 : self_best.Attack;
                ClientCard enemy_best = Util.GetProblematicEnemyCard(best_atk, true);
                ClientCard enemy_target = GetProblematicEnemyCard_Alter(true, false);

                if (!Multifaker_ssfromhand && Multifaker_candeckss() && can_ss_Multifaker)
                {
                    Spoofing_select(new[]{
                        CardId.Silquitous,
                        CardId.Manifestation,
                        CardId.Kunquery,
                        CardId.Marionetter,
                        CardId.Multifaker,
                        CardId.Protocol,
                        CardId.Meluseek
                    });
                    AI.SelectNextCard(
                        CardId.Multifaker,
                        CardId.Marionetter,
                        CardId.Meluseek,
                        CardId.Kunquery,
                        CardId.Silquitous
                        );
                }
                else if (!summoned && !Bot.HasInGraveyard(CardId.Meluseek) && Bot.GetRemainingCount(CardId.Meluseek, 3) > 0 && !Bot.HasInHand(CardId.Meluseek)
                    && (enemy_best != null || enemy_target != null))
                {
                    if (Bot.HasInHand(CardId.Silquitous))
                    {
                        foreach (ClientCard card in Bot.Hand)
                        {
                            if (card.IsCode(CardId.Silquitous))
                            {
                                AI.SelectCard(card);
                                AI.SelectNextCard(
                                    CardId.Meluseek,
                                    CardId.Marionetter
                                    );
                                return true;
                            }
                        }
                    }
                    else
                    {
                        Spoofing_select(new[]
                        {
                            CardId.Silquitous,
                            CardId.Manifestation,
                            CardId.Kunquery,
                            CardId.Multifaker,
                            CardId.Protocol,
                            CardId.Meluseek,
                            CardId.Marionetter,
                        });
                        AI.SelectNextCard(
                            CardId.Meluseek,
                            CardId.Marionetter,
                            CardId.Multifaker,
                            CardId.Kunquery
                            );
                        return true;
                    }
                }
                else if (!summoned && !Bot.HasInHand(CardId.Marionetter) && Bot.GetRemainingCount(CardId.Marionetter, 3) > 0)
                {
                    if (Bot.HasInHand(CardId.Silquitous))
                    {
                        foreach (ClientCard card in Bot.Hand)
                        {
                            if (card.IsCode(CardId.Silquitous))
                            {
                                AI.SelectCard(card);
                                AI.SelectNextCard(
                                    CardId.Marionetter,
                                    CardId.Meluseek
                                    );
                                return true;
                            }
                        }
                    }
                    else
                    {
                        Spoofing_select(new[]
                        {
                            CardId.Silquitous,
                            CardId.Manifestation,
                            CardId.Kunquery,
                            CardId.Multifaker,
                            CardId.Protocol,
                            CardId.Meluseek,
                            CardId.Marionetter,
                        });
                        AI.SelectNextCard(
                            CardId.Marionetter,
                            CardId.Meluseek,
                            CardId.Multifaker,
                            CardId.Kunquery
                            );
                        return true;
                    }
                }
            }
            // target protect
            bool go = false;
            foreach (ClientCard card in Bot.GetSpells())
            {
                if ((Util.ChainContainsCard(_CardId.HarpiesFeatherDuster) || Util.IsChainTarget(card))
                    && card.IsFaceup() && Duel.LastChainPlayer != 0 && isAltergeist(card))
                {
                    AI.SelectCard(card);
                    go = true;
                    break;
                }
            }
            if (!go)
            {
                foreach (ClientCard card in Bot.GetMonsters())
                {
                    if ((Util.IsChainTarget(card) || Util.ChainContainsCard(CardId.DarkHole) || (!Protocol_activing() && card.IsDisabled()))
                        && card.IsFaceup() && Duel.LastChainPlayer != 0 && isAltergeist(card))
                    {
                        Logger.DebugWriteLine("Spoofing target:" + card?.Name);
                        AI.SelectCard(card);
                        go = true;
                        break;
                    }
                }
            }
            if (go)
            {
                AI.SelectNextCard(
                    CardId.Marionetter,
                    CardId.Meluseek,
                    CardId.Multifaker,
                    CardId.Kunquery
                    );
                return true;
            }
            return false;
        }

        public bool OneForOne_activate()
        {
            if (!spell_trap_activate()) return false;
            if (!Bot.HasInHandOrInMonstersZoneOrInGraveyard(CardId.Meluseek) && !Bot.HasInHandOrInMonstersZoneOrInGraveyard(CardId.Multifaker))
            {
                AI.SelectCard(
                    CardId.GR_WC,
                    CardId.MaxxC,
                    CardId.Kunquery,
                    CardId.GO_SR
                    );
                if (Util.IsTurn1OrMain2()) AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            if (!summoned && !Meluseek_searched && !Bot.HasInHand(CardId.Marionetter))
            {
                AI.SelectCard(
                    CardId.GR_WC,
                    CardId.MaxxC,
                    CardId.Kunquery,
                    CardId.GO_SR
                    );
                return true;
            }
            return false;
        }

        public bool Meluseek_summon()
        {
            if (EvenlyMatched_ready()) return false;
            if (Bot.HasInHand(CardId.Marionetter) && Bot.HasInGraveyard(CardId.Meluseek) && !Marionetter_reborn) return false;
            summoned = true;
            return true;
        }

        public bool Marionetter_summon()
        {
            if (EvenlyMatched_ready()) return false;
            summoned = true;
            return true;
        }

        public bool Silquitous_summon()
        {
            if (EvenlyMatched_ready()) return false;
            bool can_summon = false;
            if (Enemy.GetMonsterCount() == 0 && Enemy.LifePoints <= 800) return true;
            foreach (ClientCard card in Bot.Hand)
            {
                if (isAltergeist(card) && card.IsTrap())
                {
                    can_summon = true;
                    break;
                }
            }
            foreach (ClientCard card in Bot.GetMonstersInMainZone())
            {
                if (isAltergeist(card))
                {
                    can_summon = true;
                    break;
                }
            }
            foreach (ClientCard card in Bot.GetSpells())
            {
                if (isAltergeist(card))
                {
                    can_summon = true;
                    break;
                }
            }
            if (can_summon)
            {
                summoned = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Multifaker_summon()
        {
            if (EvenlyMatched_ready()) return false;
            if (Enemy.GetMonsterCount() == 0 && Enemy.LifePoints <= 1200) return true;
            if (Bot.HasInMonstersZone(CardId.Silquitous) || Bot.HasInHandOrInSpellZone(CardId.Spoofing))
            {
                summoned = true;
                return true;
            }
            return false;
        }

        public bool PotofDesires_activate()
        {
            if (Bot.Deck.Count > 15 && spell_trap_activate())
            {
                AI.SelectPlace(SelectSTPlace(Card, true));
                return true;
            }
            return false;
        }

        public bool PotofIndulgence_activate()
        {
            if (!spell_trap_activate()) return false;
            if (!Bot.HasInGraveyard(CardId.Linkuriboh) && !Bot.HasInGraveyard(CardId.Hexstia))
            {
                int important_count = 0;
                foreach (ClientCard card in Bot.ExtraDeck)
                {
                    if (card.Id == CardId.Linkuriboh || card.Id == CardId.Hexstia)
                    {
                        important_count++;
                    }
                }
                if (important_count > 0)
                {
                    AI.SelectPlace(SelectSTPlace(Card, true));
                    AI.SelectOption(1);
                    return true;
                }
                return false;
            }
            AI.SelectPlace(SelectSTPlace(Card, true));
            AI.SelectOption(1);
            return true;
        }

        public bool Anima_ss()
        {
            if (Duel.Phase != DuelPhase.Main2) return false;
            ClientCard card_ex_left = Enemy.MonsterZone[6];
            ClientCard card_ex_right = Enemy.MonsterZone[5];
            if (card_ex_left != null && card_ex_left.HasLinkMarker((int)CardLinkMarker.Top))
            {
                ClientCard self_card_1 = Bot.MonsterZone[1];
                if (self_card_1 == null)
                {
                    AI.SelectMaterials(CardId.Meluseek);
                    AI.SelectPlace(Zones.z1);
                    ss_other_monster = true;
                    return true;
                }
                else if (self_card_1.IsCode(CardId.Meluseek))
                {
                    AI.SelectMaterials(self_card_1);
                    AI.SelectPlace(Zones.z1);
                    ss_other_monster = true;
                    return true;
                }
            }
            if (card_ex_right != null && card_ex_right.HasLinkMarker((int)CardLinkMarker.Top))
            {
                ClientCard self_card_2 = Bot.MonsterZone[3];
                if (self_card_2 == null)
                {
                    AI.SelectMaterials(CardId.Meluseek);
                    AI.SelectPlace(Zones.z3);
                    ss_other_monster = true;
                    return true;
                }
                else if (self_card_2.IsCode(CardId.Meluseek))
                {
                    AI.SelectMaterials(self_card_2);
                    AI.SelectPlace(Zones.z3);
                    ss_other_monster = true;
                    return true;
                }
            }
            ClientCard card_left = Enemy.MonsterZone[3];
            ClientCard card_right = Enemy.MonsterZone[1];
            if (card_left != null && card_left.IsFacedown()) card_left = null;
            if (card_right != null && card_right.IsFacedown()) card_right = null;
            if (card_left != null && (card_left.IsShouldNotBeMonsterTarget() || card_left.IsShouldNotBeTarget())) card_left = null;
            if (card_right != null && (card_right.IsShouldNotBeMonsterTarget() || card_right.IsShouldNotBeTarget())) card_right = null;
            if (Enemy.MonsterZone[6] != null) card_left = null;
            if (Enemy.MonsterZone[5] != null) card_right = null;
            if (card_left == null && card_right != null)
            {
                if (Bot.MonsterZone[6] == null)
                {
                    AI.SelectMaterials(CardId.Meluseek);
                    AI.SelectPlace(Zones.z6);
                    ss_other_monster = true;
                    return true;
                }
            }
            if (card_left != null && card_right == null)
            {
                if (Bot.MonsterZone[5] == null)
                {
                    AI.SelectMaterials(CardId.Meluseek);
                    AI.SelectPlace(Zones.z5);
                    ss_other_monster = true;
                    return true;
                }
            }
            if (card_left != null && card_right != null && Bot.GetMonstersExtraZoneCount() == 0)
            {
                int selection = 0;
                if (card_left.IsFloodgate() && !card_right.IsFloodgate()) selection = Zones.z5;
                else if (!card_left.IsFloodgate() && card_right.IsFloodgate()) selection = Zones.z6;
                else
                {
                    if (card_left.GetDefensePower() >= card_right.GetDefensePower()) selection = Zones.z5;
                    else selection = Zones.z6;
                }
                AI.SelectPlace(selection);
                AI.SelectMaterials(CardId.Meluseek);
                ss_other_monster = true;
                return true;
            }
            return false;
        }

        public bool Linkuriboh_ss()
        {
            if (Bot.GetMonstersExtraZoneCount() > 0) return false;
            if (Util.IsTurn1OrMain2() && !Meluseek_searched)
            {
                AI.SelectPlace(Zones.z5);
                ss_other_monster = true;
                return true;
            }
            return false;
        }

        public bool Linkuriboh_eff()
        {
            if (Util.ChainContainsCard(CardId.Linkuriboh)) return false;
            if (Util.ChainContainsCard(CardId.Multifaker)) return false;
            if (Duel.Player == 1)
            {
                if (Card.Location == CardLocation.Grave)
                {
                    AI.SelectCard(new[] { CardId.Meluseek });
                    ss_other_monster = true;
                    return true;
                }
                else
                {
                    if (Card.IsDisabled() && !Enemy.HasInSpellZone(82732705, true)) return false;
                    ClientCard enemy_card = Enemy.BattlingMonster;
                    if (enemy_card == null) return false;
                    ClientCard self_card = Bot.BattlingMonster;
                    if (self_card == null) return (!enemy_card.IsCode(CardId.Hayate));
                    return (enemy_card.Attack > self_card.GetDefensePower());
                }
            }
            else
            {
                if (!summoned && !Bot.HasInHand(CardId.Marionetter) && !Meluseek_searched && (Duel.Phase == DuelPhase.Main1 || Duel.Phase == DuelPhase.Main2))
                {
                    AI.SelectCard(new[] { CardId.Meluseek });
                    ss_other_monster = true;
                    AI.SelectPlace(Zones.z0 | Zones.z4);
                    return true;
                }
                else if (Util.IsTurn1OrMain2())
                {
                    AI.SelectCard(new[] { CardId.Meluseek });
                    ss_other_monster = true;
                    AI.SelectPlace(Zones.z0 | Zones.z4);
                    return true;
                }
                else if (Duel.Phase > DuelPhase.Main1 && Duel.Phase < DuelPhase.Main2)
                {
                    if (Duel.Player != 0 || attacked_Meluseek.Count == 0 || Enemy.GetMonsterCount() > 0) return false;
                    foreach (ClientCard card in attacked_Meluseek)
                    {
                        if (card != null && card.Location == CardLocation.MonsterZone)
                        {

                            ss_other_monster = true;
                            AI.SelectPlace(Zones.z0 | Zones.z4);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool Hexstia_ss()
        {
            List<ClientCard> targets = new List<ClientCard>();
            List<ClientCard> list = Bot.GetMonsters();
            list.Sort(CardContainer.CompareCardAttack);
            //list.Reverse();
            bool Meluseek_selected = false;
            bool Silquitous_selected = false;
            bool Hexstia_selected = false;
            int altergeist_count = 0;
            foreach (ClientCard card in list)
            {
                if (isAltergeist(card)) altergeist_count++;
                if (card.IsCode(CardId.Meluseek) && targets.Count < 2 && card.IsFaceup())
                {
                    if ((!Meluseek_searched || !Meluseek_selected) && (!summoned || Duel.Phase == DuelPhase.Main2))
                    {
                        Meluseek_selected = true;
                        targets.Add(card);
                    }
                }
                else if (card.IsCode(CardId.Silquitous) && targets.Count < 2 && card.IsFaceup() && !Bot.HasInGraveyard(CardId.Silquitous))
                {
                    if (!Silquitous_recycled || !Silquitous_selected)
                    {
                        Silquitous_selected = true;
                        targets.Add(card);
                    }
                }
                else if (card.IsCode(CardId.Hexstia) && targets.Count < 2 && card.IsFaceup())
                {
                    if ((!Hexstia_searched || !Hexstia_selected) && !summoned && !Bot.HasInHand(CardId.Marionetter) && Bot.GetRemainingCount(CardId.Marionetter, 3) > 0)
                    {
                        Hexstia_selected = true;
                        targets.Add(card);
                    }
                }
                else if (isAltergeist(card) && targets.Count < 2 && card.IsFaceup()) targets.Add(card);
                else if (card.IsCode(CardId.Silquitous) && targets.Count < 2 && card.IsFaceup())
                {
                    if (!Silquitous_recycled || !Silquitous_selected)
                    {
                        Silquitous_selected = true;
                        targets.Add(card);
                    }
                }
            }
            if (targets.Count >= 2)
            {
                if (Duel.Phase < DuelPhase.Main2)
                {
                    if (GetTotalATK(targets) >= 1500 && (summoned || (!Meluseek_selected && !Hexstia_selected))) return false;
                }
                bool can_have_Multifaker = (Bot.HasInHand(CardId.Multifaker)
                    || (Bot.GetRemainingCount(CardId.Multifaker, 2) > 0
                        && ((Meluseek_selected && !Meluseek_searched)
                            || (Hexstia_selected && !Hexstia_searched))));
                if (can_have_Multifaker && Multifaker_can_ss()) altergeist_count++;
                if (Bot.HasInHandOrInSpellZone(CardId.Manifestation)) altergeist_count++;
                Logger.DebugWriteLine("Multifaker_ss_check: count = " + altergeist_count.ToString());
                if (altergeist_count <= 2) return false;
                AI.SelectMaterials(targets);
                return true;
            }
            return false;
        }

        public bool TripleBurstDragon_eff()
        {
            if (ActivateDescription != Util.GetStringId(CardId.TripleBurstDragon, 0)) return false;
            return (Duel.LastChainPlayer != 0);
        }

        public bool TripleBurstDragon_ss()
        {
            if (!Enemy.HasInGraveyard(CardId.Raye))
            {
                ClientCard self_best = Util.GetBestBotMonster(true);
                int self_power = (self_best != null) ? self_best.Attack : 0;
                ClientCard enemy_best = Util.GetBestEnemyMonster(true);
                int enemy_power = (enemy_best != null) ? enemy_best.GetDefensePower() : 0;
                if (enemy_power <= self_power) return false;
                Logger.DebugWriteLine("Three: enemy: " + enemy_power.ToString() + ", bot: " + self_power.ToString());
                if (enemy_power >= 2401) return false;
            };
            foreach (ClientCard card in Bot.GetMonstersInExtraZone())
            {
                if (!card.HasType(CardType.Link)) return false;
            }
            int link_count = 0;
            if (Enemy.HasInMonstersZone(CardId.Shizuku) && Enemy.GetGraveyardSpells().Count >= 9) return false;
            List<ClientCard> list = new List<ClientCard>();
            if (Bot.HasInMonstersZone(CardId.Needlefiber))
            {
                foreach (ClientCard card in Bot.GetMonsters())
                {
                    if (card.IsCode(CardId.Needlefiber))
                    {
                        list.Add(card);
                        link_count += 2;
                    }
                }
            }
            List<ClientCard> monsters = Bot.GetMonsters();
            monsters.Sort(CardContainer.CompareCardAttack);
            //monsters.Reverse();
            foreach (ClientCard card in monsters)
            {
                if (!list.Contains(card) && card.LinkCount < 3)
                {
                    list.Add(card);
                    link_count += (card.HasType(CardType.Link) ? card.LinkCount : 1);
                    if (link_count >= 3) break;
                }
            }
            if (link_count >= 3)
            {
                AI.SelectMaterials(list);
                ss_other_monster = true;
                return true;
            }
            return false;

        }

        public bool Needlefiber_ss()
        {
            if (!Enemy.HasInGraveyard(CardId.Raye))
            {
                ClientCard self_best = Util.GetBestBotMonster(true);
                int self_power = (self_best != null) ? self_best.Attack : 0;
                ClientCard enemy_best = Util.GetBestEnemyMonster(true);
                int enemy_power = (enemy_best != null) ? enemy_best.GetDefensePower() : 0;
                if (enemy_power < self_power) return false;
                if (Bot.GetMonsterCount() <= 2 && enemy_power >= 2401) return false;
            }
            foreach (ClientCard card in Bot.GetMonstersInExtraZone())
            {
                if (!card.HasType(CardType.Link)) return false;
            }
            List<ClientCard> material_list = new List<ClientCard>();
            List<ClientCard> monsters = Bot.GetMonsters();
            monsters.Sort(CardContainer.CompareCardAttack);
            //monsters.Reverse();
            foreach (ClientCard t in monsters)
            {
                if (t.IsTuner())
                {
                    material_list.Add(t);
                    break;
                }
            }
            foreach (ClientCard m in monsters)
            {
                if (!material_list.Contains(m) && m.LinkCount <= 2)
                {
                    material_list.Add(m);
                    if (material_list.Count >= 2) break;
                }
            }
            AI.SelectMaterials(material_list);
            ss_other_monster = true;
            return true;
        }

        public bool Needlefiber_eff()
        {
            AI.SelectCard(
                CardId.GR_WC,
                CardId.GO_SR,
                CardId.AB_JS
                );
            return true;
        }

        public bool Borrelsword_ss()
        {
            if (Duel.Phase != DuelPhase.Main1) return false;

            ClientCard self_best = Util.GetBestBotMonster(true);
            int self_power = (self_best != null) ? self_best.Attack : 0;
            ClientCard enemy_best = Util.GetBestEnemyMonster(true);
            int enemy_power = (enemy_best != null) ? enemy_best.GetDefensePower() : 0;
            if (enemy_power < self_power) return false;

            foreach (ClientCard card in Bot.GetMonstersInExtraZone())
            {
                if (!card.HasType(CardType.Link)) return false;
            }

            List<ClientCard> material_list = new List<ClientCard>();
            List<ClientCard> bot_monster = Bot.GetMonsters();
            bot_monster.Sort(CardContainer.CompareCardAttack);
            //bot_monster.Reverse();
            int link_count = 0;
            foreach (ClientCard card in bot_monster)
            {
                if (card.IsFacedown()) continue;
                if (!material_list.Contains(card) && card.LinkCount < 3)
                {
                    material_list.Add(card);
                    link_count += (card.HasType(CardType.Link)) ? card.LinkCount : 1;
                    if (link_count >= 4) break;
                }
            }
            if (link_count >= 4)
            {
                AI.SelectMaterials(material_list);
                ss_other_monster = true;
                return true;
            }
            return false;
        }

        public bool Borrelsword_eff()
        {
            if (ActivateDescription == -1) return true;
            else if ((Duel.Phase > DuelPhase.Main1 && Duel.Phase < DuelPhase.Main2) || Util.IsChainTarget(Card))
            {
                List<ClientCard> enemy_list = Enemy.GetMonsters();
                enemy_list.Sort(CardContainer.CompareCardAttack);
                enemy_list.Reverse();
                foreach (ClientCard card in enemy_list)
                {
                    if (card.HasPosition(CardPosition.Attack) && !card.HasType(CardType.Link))
                    {
                        AI.SelectCard(card);
                        return true;
                    }
                }
                List<ClientCard> bot_list = Bot.GetMonsters();
                bot_list.Sort(CardContainer.CompareCardAttack);
                //bot_list.Reverse();
                foreach (ClientCard card in bot_list)
                {
                    if (card.HasPosition(CardPosition.Attack) && !card.HasType(CardType.Link))
                    {
                        AI.SelectCard(card);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool tuner_summon()
        {
            if (EvenlyMatched_ready()) return false;
            foreach (ClientCard card in Bot.GetMonstersInExtraZone())
            {
                if (card != null && !card.HasType(CardType.Link)) return false;
            }
            if (!Enemy.HasInGraveyard(CardId.Raye))
            {
                ClientCard self_best = Util.GetBestBotMonster(true);
                int self_power = (self_best != null) ? self_best.Attack : 0;
                ClientCard enemy_best = Util.GetBestEnemyMonster(true);
                int enemy_power = (enemy_best != null) ? enemy_best.GetDefensePower() : 0;
                Logger.DebugWriteLine("Tuner: enemy: " + enemy_power.ToString() + ", bot: " + self_power.ToString());
                if (enemy_power < self_power || enemy_power == 0) return false;
                int real_count = (Bot.HasInExtra(CardId.Needlefiber)) ? Bot.GetMonsterCount() + 2 : Bot.GetMonsterCount() + 1;
                if ((real_count <= 3 && enemy_power >= 2400)
                    || !(Bot.HasInExtra(CardId.TripleBurstDragon) || Bot.HasInExtra(CardId.Borrelsword))) return false;
            }
            if (Multifaker_ssfromdeck) return false;
            foreach (ClientCard card in Bot.GetMonsters())
            {
                if (card.IsFaceup())
                {
                    summoned = true;
                    AI.SelectPlace(Zones.z5);
                    return true;
                }
            }
            return false;
        }

        //BlackwingExecutor
        private bool ShuraTheBlueFlameSummon()
        {
            if (Bot.HasInMonstersZone(CardId.SiroccoTheDawn) && Bot.GetMonsters().GetHighestAttackMonster().Attack < 3800)
                return true;
            return false;
        }

        private bool BlackWhirlwindEffect()
        {
            if (Card.Location == CardLocation.Hand && Bot.HasInSpellZone(Card.Id))
                return false;
            if (ActivateDescription == Util.GetStringId((int)Card.Id, 0))
                AI.SelectCard(CardId.GaleTheWhirlwind);
            return true;
        }

        private bool SiroccoTheDawnSummon()
        {
            int OpponentMonster = Enemy.GetMonsterCount();
            int AIMonster = Bot.GetMonsterCount();
            if (OpponentMonster != 0 && AIMonster == 0)
                return true;
            return false;
        }

        private bool BoraTheSpearEffect()
        {
            List<ClientCard> monster = Bot.GetMonsters();
            foreach (ClientCard card in monster)
                if (card != null && card.IsCode(CardId.KrisTheCrackOfDawn, CardId.KalutTheMoonShadow, CardId.GaleTheWhirlwind, CardId.BoraTheSpear, CardId.SiroccoTheDawn, CardId.ShuraTheBlueFlame, CardId.BlizzardTheFarNorth))
                    return true;
            return false;
        }

        private bool KalutTheMoonShadowSummon()
        {
            foreach (ClientCard card in Bot.Hand)
                if (card != null && card.IsCode(CardId.KrisTheCrackOfDawn, CardId.GaleTheWhirlwind, CardId.BoraTheSpear, CardId.SiroccoTheDawn, CardId.ShuraTheBlueFlame, CardId.BlizzardTheFarNorth))
                    return false;
            return true;
        }

        private bool BlizzardTheFarNorthSummon()
        {
            foreach (ClientCard card in Bot.Graveyard)
                if (card != null && card.IsCode(CardId.KalutTheMoonShadow, CardId.BoraTheSpear, CardId.ShuraTheBlueFlame, CardId.KrisTheCrackOfDawn))
                    return true;
            return false;
        }

        private bool DeltaCrowAntiReverseEffect()
        {
            int Count = 0;

            List<ClientCard> monster = Bot.GetMonsters();
            foreach (ClientCard card in monster)
                if (card != null && card.IsCode(CardId.KrisTheCrackOfDawn, CardId.KalutTheMoonShadow, CardId.GaleTheWhirlwind, CardId.BoraTheSpear, CardId.SiroccoTheDawn, CardId.ShuraTheBlueFlame, CardId.BlizzardTheFarNorth))
                    Count++;

            if (Count == 3)
                return true;
            return false;
        }

        private bool GaleTheWhirlwindEffect()
        {
            if (Card.Position == (int)CardPosition.FaceUp)
            {
                AI.SelectCard(Enemy.GetMonsters().GetHighestAttackMonster());
                return true;
            }
            return false;
        }

        private bool AttackUpEffect()
        {
            ClientCard bestMy = Bot.GetMonsters().GetHighestAttackMonster();
            ClientCard bestEnemyATK = Enemy.GetMonsters().GetHighestAttackMonster();
            ClientCard bestEnemyDEF = Enemy.GetMonsters().GetHighestDefenseMonster();
            if (bestMy == null || (bestEnemyATK == null && bestEnemyDEF == null))
                return false;
            if (bestEnemyATK != null && bestMy.Attack < bestEnemyATK.Attack)
                return true;
            if (bestEnemyDEF != null && bestMy.Attack < bestEnemyDEF.Defense)
                return true;
            return false;
        }

        //BlueEyesExecutor
        private bool DragonShrineEffect()
        {
            AI.SelectCard(
                CardId.DragonSpiritOfWhite,
                CardId.WhiteDragon,
                CardId.WhiteStoneOfAncients,
                CardId.WhiteStoneOfLegend
                );
            if (!Bot.HasInHand(CardId.WhiteDragon))
            {
                AI.SelectNextCard(CardId.WhiteStoneOfLegend);
            }
            else
            {
                AI.SelectNextCard(
                    CardId.WhiteStoneOfAncients,
                    CardId.DragonSpiritOfWhite,
                    CardId.WhiteStoneOfLegend
                    );
            }
            return true;
        }

        private bool MelodyOfAwakeningDragonEffect()
        {
            AI.SelectCard(
                CardId.WhiteStoneOfAncients,
                CardId.DragonSpiritOfWhite,
                CardId.WhiteStoneOfLegend,
                CardId.GalaxyCyclone,
                CardId.EffectVeiler,
                CardId.TradeIn,
                CardId.SageWithEyesOfBlue
                );
            return true;
        }

        private bool CardsOfConsonanceEffect()
        {
            if (!Bot.HasInHand(CardId.WhiteDragon))
            {
                AI.SelectCard(CardId.WhiteStoneOfLegend);
            }
            else if (Bot.HasInHand(CardId.TradeIn))
            {
                AI.SelectCard(CardId.WhiteStoneOfLegend);
            }
            else
            {
                AI.SelectCard(CardId.WhiteStoneOfAncients);
            }
            return true;
        }

        private bool TradeInEffect()
        {
            if (Bot.HasInHand(CardId.DragonSpiritOfWhite))
            {
                AI.SelectCard(CardId.DragonSpiritOfWhite);
                return true;
            }
            else if (HasTwoInHand(CardId.WhiteDragon))
            {
                AI.SelectCard(CardId.WhiteDragon);
                return true;
            }
            else if (HasTwoInHand(CardId.AlternativeWhiteDragon))
            {
                AI.SelectCard(CardId.AlternativeWhiteDragon);
                return true;
            }
            else if (!Bot.HasInHand(CardId.WhiteDragon) || !Bot.HasInHand(CardId.AlternativeWhiteDragon))
            {
                AI.SelectCard(CardId.WhiteDragon, CardId.AlternativeWhiteDragon);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool AlternativeWhiteDragonEffect()
        {
            ClientCard target = Util.GetProblematicEnemyMonster(Card.GetDefensePower());
            if (target != null)
            {
                AI.SelectCard(target);
                UsedAlternativeWhiteDragon.Add(Card);
                return true;
            }
            if (Util.GetBotAvailZonesFromExtraDeck(Card) > 0
                && (Bot.HasInMonstersZone(new[]
                {
                    CardId.SageWithEyesOfBlue,
                    CardId.WhiteStoneOfAncients,
                    CardId.WhiteStoneOfLegend,
                    CardId.WhiteDragon,
                    CardId.DragonSpiritOfWhite
                }) || Bot.GetCountCardInZone(Bot.MonsterZone, CardId.AlternativeWhiteDragon) >= 2))
            {
                target = Util.GetBestEnemyMonster(false, true);
                AI.SelectCard(target);
                UsedAlternativeWhiteDragon.Add(Card);
                return true;
            }
            return false;
        }

        private bool RebornEffect()
        {
            if (Duel.Player == 0 && Duel.CurrentChain.Count > 0)
            {
                // Silver's Cry spsummon Dragon Spirit at chain 2 will miss the timing
                return false;
            }
            if (Duel.Player == 0 && (Duel.Phase == DuelPhase.Draw || Duel.Phase == DuelPhase.Standby))
            {
                // Let Azure-Eyes spsummon first
                return false;
            }
            IList<int> targets = new[] {
                    CardId.HopeHarbingerDragonTitanicGalaxy,
                    CardId.GalaxyEyesDarkMatterDragon,
                    CardId.AlternativeWhiteDragon,
                    CardId.AzureEyesSilverDragon,
                    CardId.BlueEyesSpiritDragon,
                    CardId.WhiteDragon,
                    CardId.DragonSpiritOfWhite
                };
            if (!Bot.HasInGraveyard(targets))
            {
                return false;
            }
            ClientCard floodgate = Enemy.SpellZone.GetFloodgate();
            if (floodgate != null && Bot.HasInGraveyard(CardId.DragonSpiritOfWhite))
            {
                AI.SelectCard(CardId.DragonSpiritOfWhite);
            }
            else
            {
                AI.SelectCard(targets);
            }
            return true;
        }

        private bool AzureEyesSilverDragonEffect()
        {
            if (Enemy.GetSpellCount() > 0)
            {
                AI.SelectCard(CardId.DragonSpiritOfWhite);
            }
            else
            {
                AI.SelectCard(CardId.WhiteDragon);
            }
            return true;
        }

        private bool SageWithEyesOfBlueSummon()
        {
            return !Bot.HasInHand(new[]
                {
                    CardId.WhiteStoneOfAncients,
                    CardId.WhiteStoneOfLegend
                });
        }

        private bool SageWithEyesOfBlueEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                return false;
            }
            AI.SelectCard(
                CardId.WhiteStoneOfAncients,
                CardId.EffectVeiler,
                CardId.WhiteStoneOfLegend
                );
            return true;
        }

        private bool WhiteStoneSummonForSage()
        {
            return Bot.HasInHand(CardId.SageWithEyesOfBlue);
        }

        private bool SageWithEyesOfBlueEffectInHand()
        {
            if (Card.Location != CardLocation.Hand)
            {
                return false;
            }
            if (!Bot.HasInMonstersZone(new[]
                {
                    CardId.WhiteStoneOfLegend,
                    CardId.WhiteStoneOfAncients
                }) || Bot.HasInMonstersZone(new[]
                {
                    CardId.AlternativeWhiteDragon,
                    CardId.WhiteDragon,
                    CardId.DragonSpiritOfWhite
                }))
            {
                return false;
            }
            AI.SelectCard(CardId.WhiteStoneOfLegend, CardId.WhiteStoneOfAncients);
            if (Enemy.GetSpellCount() > 0)
            {
                AI.SelectNextCard(CardId.DragonSpiritOfWhite);
            }
            else
            {
                AI.SelectNextCard(CardId.WhiteDragon);
            }
            return true;
        }

        private bool DragonSpiritOfWhiteEffect()
        {
            if (ActivateDescription == -1)
            {
                ClientCard target = Util.GetBestEnemySpell();
                AI.SelectCard(target);
                return true;
            }
            else if (HaveEnoughWhiteDragonInHand())
            {
                if (Duel.Player == 0 && Duel.Phase == DuelPhase.BattleStart)
                {
                    return Card.Attacked;
                }
                if (Duel.Player == 1 && Duel.Phase == DuelPhase.End)
                {
                    return Bot.HasInMonstersZone(CardId.AzureEyesSilverDragon, true)
                        && !Bot.HasInGraveyard(CardId.DragonSpiritOfWhite)
                        && !Bot.HasInGraveyard(CardId.WhiteDragon);
                }
                if (Util.IsChainTarget(Card))
                {
                    return true;
                }
            }
            return false;
        }

        private bool BlueEyesSpiritDragonEffect()
        {
            if (ActivateDescription == -1 || ActivateDescription == Util.GetStringId(CardId.BlueEyesSpiritDragon, 0))
            {
                return Duel.LastChainPlayer == 1;
            }
            else if (Duel.Player == 1 && (Duel.Phase == DuelPhase.BattleStart || Duel.Phase == DuelPhase.End))
            {
                AI.SelectCard(CardId.AzureEyesSilverDragon);
                return true;
            }
            else
            {
                if (Util.IsChainTarget(Card))
                {
                    AI.SelectCard(CardId.AzureEyesSilverDragon);
                    return true;
                }
                return false;
            }
        }

        private bool HopeHarbingerDragonTitanicGalaxyEffect()
        {
            if (ActivateDescription == -1 || ActivateDescription == Util.GetStringId(CardId.HopeHarbingerDragonTitanicGalaxy, 0))
            {
                return Duel.LastChainPlayer == 1;
            }
            return true;
        }

        private bool WhiteStoneOfAncientsEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.WhiteStoneOfAncients, 0))
            {
                if (Bot.HasInHand(CardId.TradeIn)
                    && !Bot.HasInHand(CardId.WhiteDragon)
                    && !Bot.HasInHand(CardId.AlternativeWhiteDragon))
                {
                    AI.SelectCard(CardId.WhiteDragon);
                    return true;
                }
                if (AlternativeWhiteDragonSummoned)
                {
                    return false;
                }
                if (Bot.HasInHand(CardId.WhiteDragon)
                    && !Bot.HasInHand(CardId.AlternativeWhiteDragon)
                    && Bot.HasInGraveyard(CardId.AlternativeWhiteDragon))
                {
                    AI.SelectCard(CardId.AlternativeWhiteDragon);
                    return true;
                }
                if (Bot.HasInHand(CardId.AlternativeWhiteDragon)
                    && !Bot.HasInHand(CardId.WhiteDragon)
                    && Bot.HasInGraveyard(CardId.WhiteDragon))
                {
                    AI.SelectCard(CardId.WhiteDragon);
                    return true;
                }
                return false;
            }
            else
            {
                if (Enemy.GetSpellCount() > 0)
                {
                    AI.SelectCard(CardId.DragonSpiritOfWhite);
                }
                else
                {
                    AI.SelectCard(CardId.WhiteDragon);
                }
                return true;
            }
        }

        private bool AlternativeWhiteDragonSummon()
        {
            AlternativeWhiteDragonSummoned = true;
            return true;
        }

        private bool WhiteStoneSummon()
        {
            return Bot.HasInMonstersZone(new[]
                {
                    CardId.SageWithEyesOfBlue,
                    CardId.WhiteStoneOfAncients,
                    CardId.WhiteStoneOfLegend,
                    CardId.AlternativeWhiteDragon,
                    CardId.WhiteDragon,
                    CardId.DragonSpiritOfWhite
                });
        }

        private bool GalaxyEyesCipherDragonSummon()
        {
            if (Duel.Turn == 1 || SoulChargeUsed)
            {
                return false;
            }
            List<ClientCard> monsters = Enemy.GetMonsters();
            if (monsters.Count == 1 && !monsters[0].IsFacedown() && ((monsters[0].IsDefense() && monsters[0].GetDefensePower() >= 3000) && monsters[0].HasType(CardType.Xyz)))
            {
                return true;
            }
            if (monsters.Count >= 3)
            {
                foreach (ClientCard monster in monsters)
                {
                    if (!monster.IsFacedown() && ((monster.IsDefense() && monster.GetDefensePower() >= 3000) || monster.HasType(CardType.Xyz)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool GalaxyEyesPrimePhotonDragonSummon()
        {
            if (Duel.Turn == 1)
            {
                return false;
            }
            if (Util.IsOneEnemyBetterThanValue(2999, false))
            {
                return true;
            }
            return false;
        }

        private bool GalaxyEyesFullArmorPhotonDragonSummon()
        {
            if (Bot.HasInMonstersZone(CardId.GalaxyEyesCipherDragon))
            {
                foreach (ClientCard monster in Bot.GetMonsters())
                {
                    if ((monster.IsDisabled() && monster.HasType(CardType.Xyz) && !monster.Equals(UsedGalaxyEyesCipherDragon))
                        || (Duel.Phase == DuelPhase.Main2 && monster.Equals(UsedGalaxyEyesCipherDragon)))
                    {
                        AI.SelectCard(monster);
                        return true;
                    }
                }
            }
            if (Bot.HasInMonstersZone(CardId.GalaxyEyesPrimePhotonDragon))
            {
                if (!Util.IsOneEnemyBetterThanValue(4000, false))
                {
                    AI.SelectCard(CardId.GalaxyEyesPrimePhotonDragon);
                    return true;
                }
            }
            return false;
        }

        private bool GalaxyEyesCipherBladeDragonSummon()
        {
            if (Bot.HasInMonstersZone(CardId.GalaxyEyesFullArmorPhotonDragon) && Util.GetProblematicEnemyCard() != null)
            {
                AI.SelectCard(CardId.GalaxyEyesFullArmorPhotonDragon);
                return true;
            }
            return false;
        }

        private bool GalaxyEyesDarkMatterDragonSummon()
        {
            if (Bot.HasInMonstersZone(CardId.GalaxyEyesFullArmorPhotonDragon))
            {
                AI.SelectCard(CardId.GalaxyEyesFullArmorPhotonDragon);
                return true;
            }
            return false;
        }

        private bool GalaxyEyesPrimePhotonDragonEffect()
        {
            return true;
        }

        private bool GalaxyEyesCipherDragonEffect()
        {
            List<ClientCard> monsters = Enemy.GetMonsters();
            foreach (ClientCard monster in monsters)
            {
                if (monster.HasType(CardType.Xyz))
                {
                    AI.SelectCard(monster);
                    UsedGalaxyEyesCipherDragon = Card;
                    return true;
                }
            }
            foreach (ClientCard monster in monsters)
            {
                if (monster.IsDefense())
                {
                    AI.SelectCard(monster);
                    UsedGalaxyEyesCipherDragon = Card;
                    return true;
                }
            }
            UsedGalaxyEyesCipherDragon = Card;
            return true;
        }

        private bool GalaxyEyesFullArmorPhotonDragonEffect()
        {
            ClientCard target = Util.GetProblematicEnemySpell();
            if (target != null)
            {
                AI.SelectCard(target);
                return true;
            }
            target = Util.GetProblematicEnemyMonster();
            if (target != null)
            {
                AI.SelectCard(target);
                return true;
            }
            foreach (ClientCard spell in Enemy.GetSpells())
            {
                if (spell.IsFaceup())
                {
                    AI.SelectCard(spell);
                    return true;
                }
            }
            List<ClientCard> monsters = Enemy.GetMonsters();
            if (monsters.Count >= 2)
            {
                foreach (ClientCard monster in monsters)
                {
                    if (monster.IsDefense())
                    {
                        AI.SelectCard(monster);
                        return true;
                    }
                }
                return true;
            }
            if (monsters.Count == 2)
            {
                foreach (ClientCard monster in monsters)
                {
                    if (monster.IsMonsterInvincible() || monster.IsMonsterDangerous() || monster.GetDefensePower() > 4000)
                    {
                        AI.SelectCard(monster);
                        return true;
                    }
                }
            }
            if (monsters.Count == 1)
            {
                return true;
            }
            return false;
        }

        private bool GalaxyEyesCipherBladeDragonEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                return true;
            }
            ClientCard target = Util.GetProblematicEnemyCard();
            if (target != null)
            {
                AI.SelectCard(target);
                return true;
            }
            List<ClientCard> monsters = Enemy.GetMonsters();
            foreach (ClientCard monster in monsters)
            {
                if (monster.IsDefense())
                {
                    AI.SelectCard(monster);
                    return true;
                }
            }
            foreach (ClientCard monster in monsters)
            {
                AI.SelectCard(monster);
                return true;
            }
            List<ClientCard> spells = Enemy.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (spell.IsFacedown())
                {
                    AI.SelectCard(spell);
                    return true;
                }
            }
            foreach (ClientCard spell in spells)
            {
                AI.SelectCard(spell);
                return true;
            }
            return false;
        }

        private bool GalaxyEyesDarkMatterDragonEffect()
        {
            AI.SelectCard(
                CardId.WhiteStoneOfAncients,
                CardId.WhiteStoneOfLegend,
                CardId.DragonSpiritOfWhite,
                CardId.WhiteDragon
                );
            AI.SelectNextCard(
                CardId.WhiteStoneOfAncients,
                CardId.WhiteStoneOfLegend,
                CardId.DragonSpiritOfWhite,
                CardId.WhiteDragon
                );
            return true;
        }

        private bool GiganticastleSummon()
        {
            if (Duel.Phase != DuelPhase.Main1 || Duel.Turn == 1 || SoulChargeUsed)
                return false;
            int bestSelfAttack = Util.GetBestAttack(Bot);
            int bestEnemyAttack = Util.GetBestPower(Enemy);
            return bestSelfAttack <= bestEnemyAttack && bestEnemyAttack > 2500 && bestEnemyAttack <= 3100;
        }

        private bool BlueEyesSpiritDragonSummon()
        {
            if (Duel.Phase == DuelPhase.Main1)
            {
                if (UsedAlternativeWhiteDragon.Count > 0)
                {
                    return true;
                }
                if (Duel.Turn == 1 || SoulChargeUsed)
                {
                    AI.SelectPosition(CardPosition.FaceUpDefence);
                    return true;
                }
            }
            if (Duel.Phase == DuelPhase.Main2)
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }

        private bool HopeHarbingerDragonTitanicGalaxySummon()
        {
            if (Duel.Phase == DuelPhase.Main1)
            {
                if (UsedAlternativeWhiteDragon.Count > 0)
                {
                    return true;
                }
                if (Duel.Turn == 1 || SoulChargeUsed)
                {
                    return true;
                }
            }
            if (Duel.Phase == DuelPhase.Main2)
            {
                return true;
            }
            return false;
        }

        private bool SylvanPrincesspriteSummon()
        {
            if (Duel.Turn == 1)
            {
                return true;
            }
            if (Duel.Phase == DuelPhase.Main1 && !Bot.HasInMonstersZone(new[]
                {
                    CardId.AlternativeWhiteDragon,
                    CardId.WhiteDragon,
                    CardId.DragonSpiritOfWhite
                }))
            {
                return true;
            }
            if (Duel.Phase == DuelPhase.Main2 || SoulChargeUsed)
            {
                return true;
            }
            return false;
        }

        private bool SylvanPrincesspriteEffect()
        {
            AI.SelectCard(CardId.WhiteStoneOfLegend, CardId.WhiteStoneOfAncients);
            return true;
        }

        private bool SoulChargeEffect()
        {
            if (Bot.HasInMonstersZone(CardId.BlueEyesSpiritDragon, true))
                return false;
            int count = Bot.GetGraveyardMonsters().Count;
            int space = 5 - Bot.GetMonstersInMainZone().Count;
            if (count < space)
                count = space;
            if (count < 2 || Bot.LifePoints < count * 1000)
                return false;
            if (Duel.Turn != 1)
            {
                int attack = 0;
                int defence = 0;
                foreach (ClientCard monster in Bot.GetMonsters())
                {
                    if (!monster.IsDefense())
                    {
                        attack += monster.Attack;
                    }
                }
                foreach (ClientCard monster in Enemy.GetMonsters())
                {
                    defence += monster.GetDefensePower();
                }
                if (attack - defence > Enemy.LifePoints)
                    return false;
            }
            AI.SelectCard(
                CardId.BlueEyesSpiritDragon,
                CardId.HopeHarbingerDragonTitanicGalaxy,
                CardId.AlternativeWhiteDragon,
                CardId.WhiteDragon,
                CardId.DragonSpiritOfWhite,
                CardId.AzureEyesSilverDragon,
                CardId.WhiteStoneOfAncients,
                CardId.WhiteStoneOfLegend
                );
            SoulChargeUsed = true;
            return true;
        }

        private bool HasTwoInHand(int id)
        {
            int num = 0;
            foreach (ClientCard card in Bot.Hand)
            {
                if (card != null && card.IsCode(id))
                    num++;
            }
            return num >= 2;
        }

        private bool HaveEnoughWhiteDragonInHand()
        {
            return HasTwoInHand(CardId.WhiteDragon) || (
                Bot.HasInGraveyard(CardId.WhiteDragon)
                && Bot.HasInGraveyard(CardId.WhiteStoneOfAncients)
                );
        }

        //BlueEyesMaxDragonExecutor
        private void Count_check()
        {
            TheMelody_count = 0;
            Talismandra_count = 0;
            Candoll_count = 0;
            RitualArt_count = 0;
            ChaosForm_count = 0;
            MaxDragon_count = 0;
            foreach (ClientCard check in Bot.Hand)
            {
                if (check.IsCode(CardId.AdvancedRitualArt))
                    RitualArt_count++;
                if (check.IsCode(CardId.ChaosForm))
                    ChaosForm_count++;
                if (check.IsCode(CardId.DevirrtualCandoll))
                    Candoll_count++;
                if (check.IsCode(CardId.DeviritualTalismandra))
                    Talismandra_count++;
                if (check.IsCode(CardId.BlueEyesChaosMaxDragon))
                    MaxDragon_count++;
                if (check.IsCode(CardId.TheMelodyOfAwakeningDragon))
                    TheMelody_count++;
            }
        }

        private bool MaxxCeff()
        {
            return Duel.Player == 1;
        }

        private bool CalledByTheGraveeff()
        {
            if (Duel.LastChainPlayer == 1)
            {
                ClientCard lastCard = Util.GetLastChainCard();
                if (lastCard.IsCode(CardId.MaxxC))
                {
                    AI.SelectCard(CardId.MaxxC);
                    if (Util.ChainContainsCard(CardId.TheMelodyOfAwakeningDragon))
                        AI.SelectNextCard(CardId.BlueEyesChaosMaxDragon, CardId.BlueEyesChaosMaxDragon, CardId.BlueEyesAlternativeWhiteDragon);
                    return UniqueFaceupSpell();
                }
                if (lastCard.IsCode(CardId.LockBird))
                {
                    AI.SelectCard(CardId.LockBird);
                    if (Util.ChainContainsCard(CardId.TheMelodyOfAwakeningDragon))
                        AI.SelectNextCard(CardId.BlueEyesChaosMaxDragon, CardId.BlueEyesChaosMaxDragon, CardId.BlueEyesAlternativeWhiteDragon);
                    return UniqueFaceupSpell();
                }
                if (lastCard.IsCode(CardId.Ghost))
                {
                    AI.SelectCard(CardId.Ghost);
                    if (Util.ChainContainsCard(CardId.TheMelodyOfAwakeningDragon))
                        AI.SelectNextCard(CardId.BlueEyesChaosMaxDragon, CardId.BlueEyesChaosMaxDragon, CardId.BlueEyesAlternativeWhiteDragon);
                    return UniqueFaceupSpell();
                }
                if (lastCard.IsCode(CardId.AshBlossom))
                {
                    AI.SelectCard(CardId.AshBlossom);
                    if (Util.ChainContainsCard(CardId.TheMelodyOfAwakeningDragon))
                        AI.SelectNextCard(CardId.BlueEyesChaosMaxDragon, CardId.BlueEyesChaosMaxDragon, CardId.BlueEyesAlternativeWhiteDragon);
                    return UniqueFaceupSpell();
                }
            }
            return false;
        }
        private bool BlueEyesAlternativeWhiteDragoneff()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Duel.Turn == 1)
                    return false;
                return true;
            }
            else
            {
                if (Util.GetProblematicEnemyMonster(3000, true) != null)
                {
                    AI.SelectCard(Util.GetProblematicEnemyMonster(3000, true));
                    return true;
                }
            }
            return false;
        }

        private bool CreatureSwapeff()
        {
            if (Bot.HasInMonstersZone(CardId.BlueEyesChaosMaxDragon, true) && Duel.Phase == DuelPhase.Main1 &&
                (Bot.HasInMonstersZone(CardId.DeviritualTalismandra) || Bot.HasInMonstersZone(CardId.DevirrtualCandoll)))
            {
                AI.SelectCard(CardId.DevirrtualCandoll, CardId.DeviritualTalismandra);
                return true;
            }
            return false;
        }
        private bool TheMelodyOfAwakeningDragoneff()
        {
            Count_check();
            if (TheMelody_count >= 2 && Bot.GetRemainingCount(CardId.BlueEyesChaosMaxDragon, 3) > 0)
            {
                AI.SelectCard(CardId.TheMelodyOfAwakeningDragon);
                AI.SelectNextCard(CardId.BlueEyesChaosMaxDragon, CardId.BlueEyesChaosMaxDragon, CardId.BlueEyesAlternativeWhiteDragon);
                return true;
            }
            if (Bot.HasInHand(CardId.BlueEyesWhiteDragon) && Bot.GetRemainingCount(CardId.BlueEyesChaosMaxDragon, 3) > 0)
            {
                AI.SelectCard(CardId.BlueEyesWhiteDragon);
                AI.SelectNextCard(CardId.BlueEyesChaosMaxDragon, CardId.BlueEyesChaosMaxDragon, CardId.BlueEyesAlternativeWhiteDragon);
                return true;
            }
            return false;
        }
        private bool TheMelodyOfAwakeningDragoneffsecond()
        {
            Count_check();
            if (RitualArtCanUse() && Bot.GetRemainingCount(CardId.BlueEyesChaosMaxDragon, 3) > 0 &&
                !Bot.HasInHand(CardId.BlueEyesChaosMaxDragon) && Bot.Hand.Count >= 3)
            {
                if (RitualArt_count >= 2)
                {
                    foreach (ClientCard m in Bot.Hand)
                    {
                        if (m.IsCode(CardId.AdvancedRitualArt))
                            AI.SelectCard(m);
                    }
                }
                foreach (ClientCard m in Bot.Hand)
                {
                    if (!m.IsCode(CardId.AdvancedRitualArt))
                        AI.SelectCard(m);
                }
                AI.SelectNextCard(CardId.BlueEyesChaosMaxDragon, CardId.BlueEyesChaosMaxDragon, CardId.BlueEyesAlternativeWhiteDragon);
                return true;
            }
            return false;
        }
        private bool TenTousandHandseff()
        {
            Count_check();
            if (Talismandra_count >= 2 && Bot.GetRemainingCount(CardId.BlueEyesChaosMaxDragon, 3) > 0)
            {
                AI.SelectCard(CardId.BlueEyesChaosMaxDragon);
                return true;
            }
            if (Candoll_count >= 2 || MaxDragon_count >= 2)
            {
                if (RitualArtCanUse() && Bot.GetRemainingCount(CardId.AdvancedRitualArt, 3) > 0)
                {
                    AI.SelectCard(CardId.AdvancedRitualArt);
                    return true;
                }
                if (ChaosFormCanUse() && Bot.GetRemainingCount(CardId.ChaosForm, 1) > 0)
                {
                    AI.SelectCard(CardId.ChaosForm);
                    return true;
                }
            }
            if (RitualArt_count + ChaosForm_count >= 2)
            {
                AI.SelectCard(CardId.BlueEyesChaosMaxDragon);
                return true;
            }
            if (Candoll_count + Talismandra_count > 1)
            {
                if (MaxDragon_count >= 1)
                {
                    if (RitualArtCanUse() && Bot.GetRemainingCount(CardId.AdvancedRitualArt, 3) > 0)
                    {
                        AI.SelectCard(CardId.AdvancedRitualArt);
                        return true;
                    }
                    if (ChaosFormCanUse() && Bot.GetRemainingCount(CardId.ChaosForm, 1) > 0)
                    {
                        AI.SelectCard(CardId.ChaosForm);
                        return true;
                    }
                }
                if (Bot.HasInHand(CardId.AdvancedRitualArt) || Bot.HasInHand(CardId.ChaosForm))
                {
                    AI.SelectCard(CardId.BlueEyesChaosMaxDragon);
                    return true;
                }
            }
            if (ChaosForm_count >= 1)
            {
                if (RitualArtCanUse() && Bot.GetRemainingCount(CardId.AdvancedRitualArt, 3) > 0)
                {
                    AI.SelectCard(CardId.AdvancedRitualArt);
                    return true;
                }
                if (ChaosFormCanUse() && Bot.GetRemainingCount(CardId.ChaosForm, 1) > 0)
                {
                    AI.SelectCard(CardId.ChaosForm);
                    return true;
                }
            }
            if (Talismandra_count >= 1)
            {
                AI.SelectCard(CardId.BlueEyesChaosMaxDragon);
                return true;
            }
            if (MaxDragon_count >= 1)
            {
                if (RitualArtCanUse() && Bot.GetRemainingCount(CardId.AdvancedRitualArt, 3) > 0)
                {
                    AI.SelectCard(CardId.AdvancedRitualArt);
                    return true;
                }
                if (ChaosFormCanUse() && Bot.GetRemainingCount(CardId.ChaosForm, 1) > 0)
                {
                    AI.SelectCard(CardId.ChaosForm);
                    return true;
                }
            }
            if (RitualArtCanUse() && Bot.GetRemainingCount(CardId.AdvancedRitualArt, 3) > 0)
            {
                AI.SelectCard(CardId.AdvancedRitualArt);
            }
            if (ChaosFormCanUse() && Bot.GetRemainingCount(CardId.ChaosForm, 1) > 0)
            {
                AI.SelectCard(CardId.ChaosForm);
            }
            return true;
        }

        private bool RitualArtCanUse()
        {
            return Bot.GetRemainingCount(CardId.BlueEyesWhiteDragon, 2) > 0;
        }

        private bool ChaosFormCanUse()
        {
            ClientCard check = null;
            foreach (ClientCard m in Bot.GetGraveyardMonsters())
            {
                if (m.IsCode(CardId.BlueEyesAlternativeWhiteDragon, CardId.BlueEyesChaosMaxDragon, CardId.BlueEyesWhiteDragon))
                    check = m;
            }

            foreach (ClientCard m in Bot.Hand)
            {
                if (m.IsCode(CardId.BlueEyesWhiteDragon))
                    check = m;
            }
            if (check != null)
            {

                return true;
            }
            return false;
        }

        private bool DeviritualCheck()
        {
            Count_check();
            if (Card.IsCode(CardId.DeviritualTalismandra, CardId.DevirrtualCandoll))
            {
                if (Card.Location == CardLocation.MonsterZone)
                {
                    if (RitualArtCanUse())
                    {
                        AI.SelectCard(CardId.AdvancedRitualArt);
                    }
                    else
                    {
                        AI.SelectCard(CardId.ChaosForm);
                    }
                    return true;
                }
                if (Card.Location == CardLocation.Hand)
                {
                    if (Card.IsCode(CardId.DevirrtualCandoll))
                    {
                        if (MaxDragon_count >= 2 && Talismandra_count >= 1 || Candoll_used)
                            return false;
                    }
                    if (Card.IsCode(CardId.DeviritualTalismandra))
                    {
                        if (RitualArt_count + ChaosForm_count >= 2 && Candoll_count >= 1 || Talismandra_used)
                            return false;
                        Talismandra_used = true;
                        return true;
                    }
                    if (RitualArtCanUse())
                    {
                        Candoll_used = true;
                        AI.SelectCard(CardId.AdvancedRitualArt);
                        return true;
                    }
                    if (ChaosFormCanUse())
                    {
                        Candoll_used = true;
                        AI.SelectCard(CardId.ChaosForm);
                        return true;
                    }
                    return true;
                }
            }
            return false;

        }
        private bool ChaosFormeff()
        {
            ClientCard check = null;
            foreach (ClientCard m in Bot.Graveyard)
            {
                if (m.IsCode(CardId.BlueEyesAlternativeWhiteDragon, CardId.BlueEyesChaosMaxDragon, CardId.BlueEyesWhiteDragon))
                    check = m;

            }

            if (check != null)
            {
                AI.SelectCard(CardId.BlueEyesChaosMaxDragon);
                AI.SelectNextCard(check);
                return true;
            }
            foreach (ClientCard m in Bot.Hand)
            {
                if (m.IsCode(CardId.BlueEyesWhiteDragon))
                    check = m;
            }
            if (check != null)
            {
                AI.SelectCard(CardId.BlueEyesChaosMaxDragon);
                AI.SelectNextCard(check);
                return true;
            }
            return false;
        }
        private bool MissusRadiantsp()
        {
            IList<ClientCard> material_list = new List<ClientCard>();
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if (monster.HasAttribute(CardAttribute.Earth) && monster.Level == 1)
                    material_list.Add(monster);
                if (material_list.Count == 2) break;
            }
            if (material_list.Count < 2) return false;
            if (Bot.HasInMonstersZone(CardId.MissusRadiant)) return false;
            AI.SelectMaterials(material_list);
            if (Bot.MonsterZone[0] == null && Bot.MonsterZone[2] == null && Bot.MonsterZone[5] == null)
                AI.SelectPlace(Zones.z5);
            else
                AI.SelectPlace(Zones.z6);
            return true;
        }

        private bool MissusRadianteff()
        {
            AI.SelectCard(CardId.MaxxC, CardId.MissusRadiant);
            return true;
        }

        private bool Linkuribohsp()
        {
            foreach (ClientCard c in Bot.GetMonsters())
            {
                if (!c.IsCode(CardId.Linkuriboh) && c.Level == 1)
                {
                    AI.SelectMaterials(c);
                    return true;
                }
            }
            return false;
        }

        private bool Linkuriboheff()
        {
            if (Duel.LastChainPlayer == 0 && Util.GetLastChainCard().IsCode(CardId.Linkuriboh)) return false;
            return true;
        }
        private bool BirrelswordDragonsp()
        {

            IList<ClientCard> material_list = new List<ClientCard>();
            foreach (ClientCard m in Bot.GetMonsters())
            {
                if (m.IsCode(CardId.MissusRadiant))
                {
                    material_list.Add(m);
                    break;
                }
            }
            foreach (ClientCard m in Bot.GetMonsters())
            {
                if (m.IsCode(CardId.Linkuriboh) || m.Level == 1)
                {
                    material_list.Add(m);
                    if (material_list.Count == 3)
                        break;
                }
            }
            if (material_list.Count == 3)
            {
                AI.SelectMaterials(material_list);
                return true;
            }
            return false;
        }

        private bool BirrelswordDragoneff()
        {
            if (ActivateDescription == Util.GetStringId(CardId.BirrelswordDragon, 0))
            {
                if (Util.IsChainTarget(Card) && Util.GetBestEnemyMonster(true, true) != null)
                {
                    AI.SelectCard(Util.GetBestEnemyMonster(true, true));
                    return true;
                }
                if (Duel.Player == 1 && Bot.BattlingMonster == Card)
                {
                    AI.SelectCard(Enemy.BattlingMonster);
                    return true;
                }
                if (Duel.Player == 1 && Bot.BattlingMonster != null &&
                    (Enemy.BattlingMonster.Attack - Bot.BattlingMonster.Attack) >= Bot.LifePoints)
                {
                    AI.SelectCard(Enemy.BattlingMonster);
                    return true;
                }
                if (Duel.Player == 0 && Duel.Phase == DuelPhase.BattleStart)
                {
                    foreach (ClientCard check in Enemy.GetMonsters())
                    {
                        if (check.IsAttack())
                        {
                            AI.SelectCard(check);
                            return true;
                        }
                    }
                }
                return false;
            }
            return true;
        }

        private bool RecklessGreedeff()
        {
            int count = 0;
            foreach (ClientCard card in Bot.GetSpells())
            {
                if (card.IsCode(CardId.RecklessGreed))
                    count++;
            }
            if (DefaultOnBecomeTarget()) return true;
            if (Duel.Player == 0 && Duel.Phase >= DuelPhase.Main1)
            {
                if (Bot.LifePoints <= 4000 || count >= 2)
                    return true;
            }
            return false;
        }

        private bool Scapegoateff()
        {
            if (Duel.Player == 0) return false;
            if (Duel.Phase == DuelPhase.End) return true;
            if (Duel.LastChainPlayer == 1 && DefaultOnBecomeTarget()) return true;
            if (Duel.Phase > DuelPhase.Main1 && Duel.Phase < DuelPhase.Main2)
            {
                int total_atk = 0;
                List<ClientCard> enemy_monster = Enemy.GetMonsters();
                foreach (ClientCard m in enemy_monster)
                {
                    if (m.IsAttack() && !m.Attacked) total_atk += m.Attack;
                }
                if (total_atk >= Bot.LifePoints) return true;
            }
            return false;
        }

        //CyberDragonExecutor
        private bool CyberDragonInHand() { return Bot.HasInHand(CardId.CyberDragon); }
        private bool CyberDragonInGraveyard() { return Bot.HasInGraveyard(CardId.CyberDragon); }
        private bool CyberDragonInMonsterZone() { return Bot.HasInMonstersZone(CardId.CyberDragon); }
        private bool CyberDragonIsBanished() { return Bot.HasInBanished(CardId.CyberDragon); }

        private bool Capsule()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.PowerBond);
            SelectedCard.Add(CardId.DarkHole);
            SelectedCard.Add(CardId.Raigeki);
            AI.SelectCard(SelectedCard);
            return true;
        }

        private bool PolymerizationEffect()
        {
            if (Bot.GetCountCardInZone(Bot.MonsterZone, CardId.CyberDragon) + Bot.GetCountCardInZone(Bot.MonsterZone, CardId.ProtoCyberDragon) + Bot.GetCountCardInZone(Bot.MonsterZone, CardId.CyberDragonDrei) + Bot.GetCountCardInZone(Bot.MonsterZone, CardId.CyberDragonDrei) + Bot.GetCountCardInZone(Bot.Hand, CardId.CyberDragon) >= 3)
                AI.SelectCard(CardId.CyberEndDragon);
            else
                AI.SelectCard(CardId.CyberTwinDragon);
            return true;
        }

        private bool PowerBondEffect()
        {
            PowerBondUsed = true;
            if (Bot.GetCountCardInZone(Bot.MonsterZone, CardId.CyberDragon) + Bot.GetCountCardInZone(Bot.MonsterZone, CardId.ProtoCyberDragon) + Bot.GetCountCardInZone(Bot.Hand, CardId.CyberDragon) + Bot.GetCountCardInZone(Bot.Graveyard, CardId.CyberDragon) + Bot.GetCountCardInZone(Bot.Hand, CardId.CyberDragonCore) + Bot.GetCountCardInZone(Bot.Graveyard, CardId.CyberDragonCore) + Bot.GetCountCardInZone(Bot.Graveyard, CardId.CyberDragonDrei) + Bot.GetCountCardInZone(Bot.MonsterZone, CardId.CyberDragonDrei) >= 3)
                AI.SelectCard(CardId.CyberEndDragon);
            else
                AI.SelectCard(CardId.CyberTwinDragon);
            return true;
        }

        private bool EvolutionBurstEffect()
        {
            ClientCard bestMy = Bot.GetMonsters().GetHighestAttackMonster();
            if (bestMy == null || !Util.IsOneEnemyBetterThanValue(bestMy.Attack, false))
                return false;
            else
                AI.SelectCard(Enemy.MonsterZone.GetHighestAttackMonster());
            return true;
        }

        private bool NoCyberDragonSpsummon()
        {
            if (CyberDragonInHand() && (Bot.GetMonsterCount() == 0 && Enemy.GetMonsterCount() != 0))
                return false;
            return true;
        }

        private bool ArmoredCybernSet()
        {
            if (CyberDragonInHand() && (Bot.GetMonsterCount() == 0 && Enemy.GetMonsterCount() != 0) || (Bot.HasInHand(CardId.CyberDragonDrei) || Bot.HasInHand(CardId.CyberPhoenix)) && !Util.IsOneEnemyBetterThanValue(1800, true))
                return false;
            return true;
        }

        private bool ProtoCyberDragonSummon()
        {
            if (Bot.GetCountCardInZone(Bot.Hand, CardId.CyberDragon) + Bot.GetCountCardInZone(Bot.MonsterZone, CardId.CyberDragon) + Bot.GetCountCardInZone(Bot.MonsterZone, CardId.CyberDragonCore) >= 1 && Bot.HasInHand(CardId.Polymerization) || Bot.GetCountCardInZone(Bot.Hand, CardId.CyberDragon) + Bot.GetCountCardInZone(Bot.MonsterZone, CardId.CyberDragon) + Bot.GetCountCardInZone(Bot.Graveyard, CardId.CyberDragon) + Bot.GetCountCardInZone(Bot.Graveyard, CardId.CyberDragonCore) >= 1 && Bot.HasInHand(CardId.PowerBond))
                return true;
            if (CyberDragonInHand() && (Bot.GetMonsterCount() == 0 && Enemy.GetMonsterCount() != 0) || (Bot.HasInHand(CardId.CyberDragonDrei) || Bot.HasInHand(CardId.CyberPhoenix)) && !Util.IsOneEnemyBetterThanValue(1800, true))
                return false;
            return true;
        }

        private bool CyberKirinSummon()
        {
            return PowerBondUsed;
        }

        private bool ArmoredCybernEffect()
        {
            if (Card.Location == CardLocation.Hand)
                return true;
            else if (Card.Location == CardLocation.SpellZone)
            {
                if (Util.IsOneEnemyBetterThanValue(Bot.GetMonsters().GetHighestAttackMonster().Attack, true))
                    if (ActivateDescription == Util.GetStringId(CardId.ArmoredCybern, 2))
                        return true;
                return false;
            }
            return false;
        }

        private bool DeFusionEffect()
        {
            if (Duel.Phase == DuelPhase.Battle)
            {
                if (!Bot.HasAttackingMonster())
                    return true;
            }
            return false;
        }

        //DarkMagicianExecutor
        private void EternalSoulSelect()
        {
            AI.SelectPosition(CardPosition.FaceUpAttack);
            /*
            if (Enemy.HasInMonstersZone(CardId.MekkKnightMorningStar))
            {
                int MekkKnightZone = 0;
                int BotZone = 0;
                for (int i = 0; i <= 6; i++)
                {
                    if (Enemy.MonsterZone[i] != null && Enemy.MonsterZone[i].IsCode(CardId.MekkKnightMorningStar))
                    {
                        MekkKnightZone = i;
                        break;
                    }
                }
                if (Bot.MonsterZone[GetReverseColumnMainZone(MekkKnightZone)] == null)
                {
                    BotZone = GetReverseColumnMainZone(MekkKnightZone);
                    AI.SelectPlace(ReverseZoneTo16bit(BotZone));
                }
                else
                {
                    for (int i = 0; i <= 6; i++)
                    {
                        if (!NoJackKnightColumn(i))
                        {
                            if (Bot.MonsterZone[GetReverseColumnMainZone(i)] == null)
                            {
                                AI.SelectPlace(ReverseZoneTo16bit(GetReverseColumnMainZone(i)));
                                break;
                            }
                        }
                    }
                }                
                Logger.DebugWriteLine("******************MekkKnightMorningStar");
            }
            else
            {
                for (int i = 0; i <= 6; i++)
                {
                    if (!NoJackKnightColumn(i))
                    {
                        if (Bot.MonsterZone[GetReverseColumnMainZone(i)] == null)
                        {
                            AI.SelectPlace(ReverseZoneTo16bit(GetReverseColumnMainZone(i)));
                            break;
                        } 
                    }
                }
            }
            */
        }
        int attackerzone = -1;
        int defenderzone = -1;
        bool Secret_used = false;
        bool plan_A = false;
        bool plan_C = false;
        int maxxc_done = 0;
        int lockbird_done = 0;
        int ghost_done = 0;
        bool maxxc_used = false;
        bool lockbird_used = false;
        bool ghost_used = false;
        bool WindwitchGlassBelleff_used = false;
        int ApprenticeLllusionMagician_count = 0;
        bool Spellbook_summon = false;
        bool Rod_summon = false;
        bool GlassBell_summon = false;
        bool magician_sp = false;
        bool soul_used = false;
        bool big_attack = false;
        bool big_attack_used = false;
        bool CrystalWingSynchroDragon_used = false;
        public override void OnNewPhase()
        {
            //Util.UpdateLinkedZone();
            //Logger.DebugWriteLine("Zones.CheckLinkedPointZones= " + Zones.CheckLinkedPointZones);
            //Logger.DebugWriteLine("Zones.CheckMutualEnemyZoneCount= " + Zones.CheckMutualEnemyZoneCount);
            plan_C = false;
            ApprenticeLllusionMagician_count = 0;
            foreach (ClientCard count in Bot.GetMonsters())
            {
                if (count.IsCode(CardId.ApprenticeLllusionMagician) && count.IsFaceup())
                    ApprenticeLllusionMagician_count++;
            }
            foreach (ClientCard dangerous in Enemy.GetMonsters())
            {
                if (dangerous != null && dangerous.IsShouldNotBeTarget() && dangerous.Attack > 2500 &&
                    !Bot.HasInHandOrHasInMonstersZone(CardId.ApprenticeLllusionMagician))
                {
                    plan_C = true;
                    Logger.DebugWriteLine("*********dangerous = " + dangerous.Id);
                }
            }
            if (Bot.HasInHand(CardId.SpellbookMagicianOfProphecy) &&
              Bot.HasInHand(CardId.MagiciansRod) &&
              Bot.HasInHand(CardId.WindwitchGlassBell))
            {
                if (Bot.HasInHand(CardId.SpellbookOfKnowledge) ||
                    Bot.HasInHand(CardId.WonderWand))
                    Rod_summon = true;
                else
                    Spellbook_summon = true;
            }
            else if
                 (Bot.HasInHand(CardId.SpellbookMagicianOfProphecy) &&
                 Bot.HasInHand(CardId.MagiciansRod))
            {
                if (Bot.HasInSpellZone(CardId.EternalSoul) &&
                    !(Bot.HasInHand(CardId.DarkMagician) || Bot.HasInHand(CardId.DarkMagician)))
                    Rod_summon = true;
                else if (Bot.HasInHand(CardId.SpellbookOfKnowledge) ||
                    Bot.HasInHand(CardId.WonderWand))
                    Rod_summon = true;
                else
                    Spellbook_summon = true;
            }
            else if
                  (Bot.HasInHand(CardId.SpellbookMagicianOfProphecy) &&
                 Bot.HasInHand(CardId.WindwitchGlassBell))
            {
                if (plan_A)
                    Rod_summon = true;
                else
                    GlassBell_summon = true;
            }
            else if
                  (Bot.HasInHand(CardId.MagiciansRod) &&
                 Bot.HasInHand(CardId.WindwitchGlassBell))
            {
                if (plan_A)
                    Rod_summon = true;
                else
                    GlassBell_summon = true;
            }
            else
            {
                Spellbook_summon = true;
                Rod_summon = true;
                GlassBell_summon = true;
            }
        }

        private bool WindwitchIceBelleff()
        {
            if (lockbird_used) return false;
            if (Enemy.HasInMonstersZone(CardId.ElShaddollWinda)) return false;
            if (maxxc_used) return false;
            if (WindwitchGlassBelleff_used) return false;
            //AI.SelectPlace(Zones.z2, 1);
            if (Bot.GetRemainingCount(CardId.WindwitchGlassBell, 2) >= 1)
                AI.SelectCard(CardId.WindwitchGlassBell);
            else if (Bot.HasInHand(CardId.WindwitchGlassBell))
                AI.SelectCard(CardId.WindwitchSnowBell);
            AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }

        private bool WindwitchGlassBelleff()
        {
            if (Bot.HasInMonstersZone(CardId.WindwitchIceBell))
            {
                int ghost_count = 0;
                foreach (ClientCard check in Enemy.Graveyard)
                {
                    if (check.IsCode(CardId.Ghost))
                        ghost_count++;
                }
                if (ghost_count != ghost_done)
                    AI.SelectCard(CardId.WindwitchIceBell);
                else
                    AI.SelectCard(CardId.WindwitchSnowBell);
            }
            else
                AI.SelectCard(CardId.WindwitchIceBell);
            WindwitchGlassBelleff_used = true;
            return true;
        }

        private bool WindwitchSnowBellsp()
        {
            if (maxxc_used) return false;
            if (Bot.HasInMonstersZone(CardId.WindwitchIceBell) &&
                Bot.HasInMonstersZone(CardId.WindwitchGlassBell))
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }

        private bool WindwitchWinterBellsp()
        {
            if (maxxc_used) return false;
            if (Bot.HasInMonstersZone(CardId.WindwitchIceBell) &&
                 Bot.HasInMonstersZone(CardId.WindwitchGlassBell) &&
                 Bot.HasInMonstersZone(CardId.WindwitchSnowBell))
            {
                //AI.SelectPlace(Zones.z5, Zones.ExtraMonsterZones);
                AI.SelectCard(CardId.WindwitchIceBell, CardId.WindwitchGlassBell);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }

            return false;
        }

        private bool WindwitchWinterBelleff()
        {
            AI.SelectCard(CardId.WindwitchGlassBell);
            return true;
        }

        private bool ClearWingFastDragonsp()
        {
            if (Bot.HasInMonstersZone(CardId.WindwitchIceBell) &&
                Bot.HasInMonstersZone(CardId.WindwitchGlassBell))
            {

                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }

            return false;
        }

        private bool ClearWingFastDragoneff()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (Duel.Player == 1)
                    return DefaultTrap();
                return true;
            }
            return false;
        }
        private bool CrystalWingSynchroDragonsp()
        {
            if (Bot.HasInMonstersZone(CardId.WindwitchSnowBell) && Bot.HasInMonstersZone(CardId.WindwitchWinterBell))
            {
                //AI.SelectPlace(Zones.z5, Zones.ExtraMonsterZones);
                plan_A = true;
                return true;
            }
            return false;
        }

        /* private bool GrinderGolemeff()
         {

             if (plan_A) return false;
             AI.SelectPosition(CardPosition.FaceUpDefence);
             if (Bot.GetMonstersExtraZoneCount() == 0)
                 return true;
             if (Bot.HasInMonstersZone(CardId.AkashicMagician) ||
                 Bot.HasInMonstersZone(CardId.SecurityDragon))
                 return true;
             return false;
         }*/

        /*  private bool Linkuribohsp()
          {
              if (Bot.HasInMonstersZone(CardId.GrinderGolem + 1))
              {
                  AI.SelectCard(CardId.GrinderGolem + 1);
                  return true;
              }
              return false;
          }

          private bool LinkSpidersp()
          {
              if(Bot.HasInMonstersZone(CardId.GrinderGolem+1))
              {
                  AI.SelectCard(CardId.GrinderGolem + 1);
                  return true;
              }
              return false;
          }*/

        private bool OddEyesAbsoluteDragonsp()
        {
            if (plan_C)
            {
                return true;
            }
            return false;
        }

        private bool OddEyesAbsoluteDragoneff()
        {
            Logger.DebugWriteLine("OddEyesAbsoluteDragonef 1");
            if (Card.Location == CardLocation.MonsterZone/*ActivateDescription == Util.GetStringId(CardId.OddEyesAbsoluteDragon, 0)*/)
            {
                Logger.DebugWriteLine("OddEyesAbsoluteDragonef 2");
                return Duel.Player == 1;
            }
            else if (Card.Location == CardLocation.Grave/*ActivateDescription == Util.GetStringId(CardId.OddEyesAbsoluteDragon, 0)*/)
            {
                Logger.DebugWriteLine("OddEyesAbsoluteDragonef 3");
                AI.SelectCard(CardId.OddEyesWingDragon);
                return true;
            }
            return false;
        }

        private bool SolemnStrikeeff()
        {
            if (Bot.LifePoints > 1500 && Duel.LastChainPlayer == 1)
                return true;
            return false;
        }

        private bool ChainEnemy()
        {
            if (Util.GetLastChainCard() != null &&
                Util.GetLastChainCard().IsCode(CardId.UpstartGoblin))
                return false;
            return Duel.LastChainPlayer == 1;
        }

        private bool CrystalWingSynchroDragoneff()
        {
            if (Duel.LastChainPlayer == 1)
            {
                CrystalWingSynchroDragon_used = true;
                return true;
            }
            return false;
        }

        /*
        private bool Scapegoatset()
        {
            if (Bot.HasInSpellZone(CardId.Scapegoat)) return false;
            return (Bot.GetMonsterCount() - Bot.GetMonstersExtraZoneCount()) < 2;
        }

        public bool Scapegoateff()
        {
            if (Duel.Player == 0) return false;           
            if (DefaultOnBecomeTarget() && !Enemy.HasInMonstersZone(CardId.UltimateConductorTytanno))
            {
                Logger.DebugWriteLine("*************************sheepeff");
                return true;
            }
            if (Bot.HasInMonstersZone(CardId.CrystalWingSynchroDragon)) return false;     
            if(Duel.Phase == DuelPhase.End)
            {
                Logger.DebugWriteLine("*************************sheepeff");
                return true;
            }
            if (Duel.Phase > DuelPhase.Main1 && Duel.Phase < DuelPhase.Main2)
            {
                
                int total_atk = 0;
                List<ClientCard> enemy_monster = Enemy.GetMonsters();
                foreach (ClientCard m in enemy_monster)
                {
                    if (m.IsAttack() && !m.Attacked) total_atk += m.Attack;
                }
                if (total_atk >= Bot.LifePoints && !Enemy.HasInMonstersZone(CardId.UltimateConductorTytanno)) return true;
            }
            return false;
        }
        
        private bool Hidarumasp()
        {
            if (!Bot.HasInMonstersZone(CardId.Scapegoat + 1)) return false;
            if(Bot.MonsterZone[5]==null)
            {
                AI.SelectCard(new[] { CardId.Scapegoat + 1, CardId.Scapegoat + 1 });               
                return true;
            }
            if (Bot.MonsterZone[6] == null)
            {
                AI.SelectCard(new[] { CardId.Scapegoat + 1, CardId.Scapegoat + 1 });                
                return true;
            }
            return false;

        }

        private bool Linkuribohsp()
        {
            foreach (ClientCard c in Bot.GetMonsters())
            {
                if (!c.IsCode(CardId.WindwitchSnowBell) && c.Level == 1 && !c.IsCode(CardId.LinkSpider) && !c.IsCode(CardId.Linkuriboh))
                {
                    AI.SelectCard(c);
                    return true;
                }
            }
            return false;
        }


        private bool Linkuriboheff()
        {
            if (Duel.LastChainPlayer == 0 && Util.GetLastChainCard().IsCode(CardId.Linkuriboh)) return false;
            if (Bot.HasInMonstersZone(CardId.WindwitchSnowBell)) return false;
            return true;
        }
        private bool BorreloadDragonsp()
        {
            if(Bot.HasInMonstersZone(CardId.Hidaruma)&&
                Bot.HasInMonstersZone(CardId.Linkuriboh))
            {
                AI.SelectCard(new[] { CardId.Hidaruma, CardId.Linkuriboh, CardId.LinkSpider ,CardId.Linkuriboh});
                return true;
            }
            
            return false;
        }

       
        private bool BorreloadDragoneff()
        {
            if (ActivateDescription == -1)
            {
                ClientCard enemy_monster = Enemy.BattlingMonster;
                if (enemy_monster != null && enemy_monster.HasPosition(CardPosition.Attack))
                {
                    return enemy_monster.Attack > 2000;
                }
                return true;
            };
            ClientCard BestEnemy = Util.GetBestEnemyMonster(true,true);            
            if (BestEnemy == null || BestEnemy.HasPosition(CardPosition.FaceDown)) return false;
            AI.SelectCard(BestEnemy);
            return true;  
        }*/
        private bool EternalSoulset()
        {
            if (Bot.GetHandCount() > 6) return true;
            if (!Bot.HasInSpellZone(CardId.EternalSoul))
                return true;
            return false;
        }

        private bool EternalSouleff()
        {
            IList<ClientCard> grave = Bot.Graveyard;
            IList<ClientCard> magician = new List<ClientCard>();
            foreach (ClientCard check in grave)
            {
                if (check.IsCode(CardId.DarkMagician))
                {
                    magician.Add(check);
                }
            }
            if (Util.IsChainTarget(Card) && Bot.GetMonsterCount() == 0)
            {
                AI.SelectYesNo(false);
                return true;
            }
            if (Util.ChainCountPlayer(0) > 0) return false;

            if (Enemy.HasInSpellZone(CardId.HarpiesFeatherDuster) && Card.IsFacedown())
                return false;

            foreach (ClientCard target in Duel.ChainTargets)
            {
                if ((target.IsCode(CardId.DarkMagician, CardId.DarkMagicianTheDragonKnight))
                    && Card.IsFacedown())
                {
                    AI.SelectYesNo(false);
                    return true;
                }
            }

            if (Enemy.HasInSpellZone(CardId.DarkHole) && Card.IsFacedown() &&
                (Bot.HasInMonstersZone(CardId.DarkMagician) || Bot.HasInMonstersZone(CardId.DarkMagicianTheDragonKnight)))
            {
                AI.SelectYesNo(false);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.DarkMagicianTheDragonKnight) &&
                !Bot.HasInMonstersZone(CardId.DarkMagicianTheDragonKnight) && !plan_C)
            {
                EternalSoulSelect();
                AI.SelectCard(CardId.DarkMagicianTheDragonKnight);
                return true;
            }
            if (Duel.Player == 1 && Bot.HasInSpellZone(CardId.DarkMagicalCircle) &&
                (Enemy.HasInMonstersZone(CardId.SummonSorceress) || Enemy.HasInMonstersZone(CardId.FirewallDragon)))
            {
                soul_used = true;
                magician_sp = true;
                EternalSoulSelect();
                AI.SelectCard(magician);
                return true;
            }
            if (Duel.Player == 1 && Duel.Phase == DuelPhase.BattleStart && Enemy.GetMonsterCount() > 0)
            {
                if (Card.IsFacedown() && Bot.HasInMonstersZone(CardId.VentriloauistsClaraAndLucika))
                {
                    AI.SelectYesNo(false);
                    return true;
                }
                if (Card.IsFacedown() &&
                (Bot.HasInMonstersZone(CardId.DarkMagician) || Bot.HasInMonstersZone(CardId.DarkMagicianTheDragonKnight)))
                {
                    AI.SelectYesNo(false);
                    return true;
                }
                if (Bot.HasInGraveyard(CardId.DarkMagicianTheDragonKnight) ||
                    Bot.HasInGraveyard(CardId.DarkMagician))
                {
                    soul_used = true;
                    magician_sp = true;
                    EternalSoulSelect();
                    AI.SelectCard(magician);
                    return true;
                }
                if (Bot.HasInHand(CardId.DarkMagician))
                {
                    soul_used = true;
                    magician_sp = true;
                    AI.SelectCard(CardId.DarkMagician);
                    EternalSoulSelect();
                    return true;
                }
            }
            if (Duel.Player == 0 && Duel.Phase == DuelPhase.Main1)
            {
                if (Bot.HasInHand(CardId.DarkMagicalCircle) && !Bot.HasInSpellZone(CardId.DarkMagicalCircle))
                    return false;
                if (Bot.HasInGraveyard(CardId.DarkMagicianTheDragonKnight) ||
                    Bot.HasInGraveyard(CardId.DarkMagician))
                {
                    soul_used = true;
                    magician_sp = true;
                    AI.SelectCard(magician);
                    EternalSoulSelect();
                    return true;
                }
                if (Bot.HasInHand(CardId.DarkMagician))
                {
                    soul_used = true;
                    magician_sp = true;
                    AI.SelectCard(CardId.DarkMagician);
                    EternalSoulSelect();
                    return true;
                }
            }
            if (Duel.Phase == DuelPhase.End)
            {
                if (Card.IsFacedown() && Bot.HasInMonstersZone(CardId.VentriloauistsClaraAndLucika))
                {
                    AI.SelectYesNo(false);
                    return true;
                }
                if (Bot.HasInGraveyard(CardId.DarkMagicianTheDragonKnight) ||
                    Bot.HasInGraveyard(CardId.DarkMagician))
                {
                    soul_used = true;
                    magician_sp = true;
                    AI.SelectCard(magician);
                    EternalSoulSelect();
                    return true;
                }
                if (Bot.HasInHand(CardId.DarkMagician))
                {
                    soul_used = true;
                    magician_sp = true;
                    AI.SelectCard(CardId.DarkMagician);
                    EternalSoulSelect();
                    return true;
                }
                return true;
            }
            return false;
        }

        private bool MagicianNavigationset()
        {
            if (Bot.GetHandCount() > 6) return true;
            if (Bot.HasInSpellZone(CardId.LllusionMagic)) return true;
            if (Bot.HasInHand(CardId.DarkMagician) && !Bot.HasInSpellZone(CardId.MagicianNavigation))
                return true;
            return false;
        }

        private bool MagicianNavigationeff()
        {
            bool spell_act = false;
            IList<ClientCard> spell = new List<ClientCard>();
            if (Duel.LastChainPlayer == 1)
            {
                foreach (ClientCard check in Enemy.GetSpells())
                {
                    if (Util.GetLastChainCard() == check)
                    {
                        spell.Add(check);
                        spell_act = true;
                        break;
                    }
                }
            }
            bool soul_faceup = false;
            foreach (ClientCard check in Bot.GetSpells())
            {
                if (check.IsCode(CardId.EternalSoul) && check.IsFaceup())
                {
                    soul_faceup = true;
                }
            }
            if (Card.Location == CardLocation.Grave && spell_act)
            {
                Logger.DebugWriteLine("**********************Navigationeff***********");
                AI.SelectCard(spell);
                return true;
            }
            if (Util.IsChainTarget(Card))
            {
                AI.SelectPlace(Zones.z0 | Zones.z4);
                AI.SelectCard(CardId.DarkMagician);
                ClientCard check = Util.GetOneEnemyBetterThanValue(2500, true);
                if (check != null)
                    AI.SelectNextCard(CardId.ApprenticeLllusionMagician, CardId.DarkMagician, CardId.MagicianOfLllusion);
                else
                    AI.SelectNextCard(CardId.ApprenticeLllusionMagician, CardId.DarkMagician, CardId.MagicianOfLllusion);
                magician_sp = true;
                return UniqueFaceupSpell();
            }
            if (DefaultOnBecomeTarget() && !soul_faceup)
            {
                AI.SelectPlace(Zones.z0 | Zones.z4);
                AI.SelectCard(CardId.DarkMagician);
                ClientCard check = Util.GetOneEnemyBetterThanValue(2500, true);
                if (check != null)
                    AI.SelectNextCard(CardId.ApprenticeLllusionMagician, CardId.DarkMagician, CardId.MagicianOfLllusion);
                else
                    AI.SelectNextCard(CardId.ApprenticeLllusionMagician, CardId.DarkMagician, CardId.MagicianOfLllusion);
                magician_sp = true;
                return true;
            }
            if (Duel.Player == 0 && Card.Location == CardLocation.SpellZone && !maxxc_used && Bot.HasInHand(CardId.DarkMagician))
            {
                AI.SelectPlace(Zones.z0 | Zones.z4);
                AI.SelectCard(CardId.DarkMagician);
                ClientCard check = Util.GetOneEnemyBetterThanValue(2500, true);
                if (check != null)
                    AI.SelectNextCard(CardId.ApprenticeLllusionMagician, CardId.DarkMagician, CardId.MagicianOfLllusion);
                else
                    AI.SelectNextCard(CardId.ApprenticeLllusionMagician, CardId.DarkMagician, CardId.MagicianOfLllusion);
                magician_sp = true;
                return UniqueFaceupSpell();
            }
            if (Duel.Player == 1 && Bot.HasInSpellZone(CardId.DarkMagicalCircle) &&
                (Enemy.HasInMonstersZone(CardId.SummonSorceress) || Enemy.HasInMonstersZone(CardId.FirewallDragon))
                && Card.Location == CardLocation.SpellZone)
            {
                AI.SelectPlace(Zones.z0 | Zones.z4);
                AI.SelectCard(CardId.DarkMagician);
                ClientCard check = Util.GetOneEnemyBetterThanValue(2500, true);
                if (check != null)
                    AI.SelectNextCard(CardId.ApprenticeLllusionMagician, CardId.DarkMagician, CardId.MagicianOfLllusion);
                else
                    AI.SelectNextCard(CardId.ApprenticeLllusionMagician, CardId.DarkMagician, CardId.MagicianOfLllusion);
                magician_sp = true;
                return UniqueFaceupSpell();
            }
            if (Enemy.GetFieldCount() > 0 &&
                (Duel.Phase == DuelPhase.BattleStart || Duel.Phase == DuelPhase.End) &&
                Card.Location == CardLocation.SpellZone && !maxxc_used)
            {
                AI.SelectPlace(Zones.z0 | Zones.z4);
                AI.SelectCard(CardId.DarkMagician);
                ClientCard check = Util.GetOneEnemyBetterThanValue(2500, true);
                if (check != null)
                    AI.SelectNextCard(CardId.ApprenticeLllusionMagician, CardId.DarkMagician, CardId.MagicianOfLllusion);
                else
                    AI.SelectNextCard(CardId.ApprenticeLllusionMagician, CardId.DarkMagician, CardId.MagicianOfLllusion);
                magician_sp = true;
                return UniqueFaceupSpell();
            }

            return false;
        }
        private bool DarkMagicalCircleeff()
        {
            if (Card.Location == CardLocation.Hand)
            {
                //AI.SelectPlace(Zones.z2, 2);
                if (Bot.LifePoints <= 4000)
                    return true;
                return UniqueFaceupSpell();
            }
            else
            {
                if (magician_sp)
                {
                    AI.SelectCard(Util.GetBestEnemyCard(false, true));
                    if (Util.GetBestEnemyCard(false, true) != null)
                        Logger.DebugWriteLine("*************SelectCard= " + Util.GetBestEnemyCard(false, true).Id);
                    magician_sp = false;
                }
            }
            return true;
        }
        private bool LllusionMagicset()
        {
            if (Bot.GetMonsterCount() >= 1 &&
                !(Bot.GetMonsterCount() == 1 && Bot.HasInMonstersZone(CardId.CrystalWingSynchroDragon)) &&
                !(Bot.GetMonsterCount() == 1 && Bot.HasInMonstersZone(CardId.ClearWingFastDragon)) &&
                !(Bot.GetMonsterCount() == 1 && Bot.HasInMonstersZone(CardId.VentriloauistsClaraAndLucika)))
                return true;
            return false;
        }
        private bool LllusionMagiceff()
        {
            if (lockbird_used) return false;
            if (Duel.LastChainPlayer == 0) return false;
            ClientCard target = null;
            bool soul_exist = false;
            //AI.SelectPlace(Zones.z2, 2);
            foreach (ClientCard m in Bot.GetSpells())
            {
                if (m.IsCode(CardId.EternalSoul) && m.IsFaceup())
                    soul_exist = true;
            }
            if (!soul_used && soul_exist)
            {
                if (Bot.HasInMonstersZone(CardId.MagiciansRod))
                {
                    AI.SelectCard(CardId.MagiciansRod);
                    AI.SelectNextCard(CardId.DarkMagician, CardId.DarkMagician);
                    return true;
                }
            }
            if (Duel.Player == 0)
            {
                int ghost_count = 0;
                foreach (ClientCard check in Enemy.Graveyard)
                {
                    if (check.IsCode(CardId.Ghost))
                        ghost_count++;
                }
                if (ghost_count != ghost_done)
                {
                    if (Duel.CurrentChain.Count >= 2 && Util.GetLastChainCard().IsCode(0))
                    {
                        AI.SelectCard(CardId.MagiciansRod);
                        AI.SelectNextCard(CardId.DarkMagician, CardId.DarkMagician);
                        return true;
                    }
                }
                int count = 0;
                foreach (ClientCard m in Bot.GetMonsters())
                {
                    if (Util.IsChainTarget(m))
                    {
                        count++;
                        target = m;
                        Logger.DebugWriteLine("************IsChainTarget= " + target.Id);
                        break;
                    }
                }
                if (count == 0) return false;
                if ((target.IsCode(CardId.WindwitchGlassBell, CardId.WindwitchIceBell)) &&
                    Bot.HasInMonstersZone(CardId.WindwitchIceBell) &&
                    Bot.HasInMonstersZone(CardId.WindwitchGlassBell))
                    return false;
                AI.SelectCard(target);
                AI.SelectNextCard(CardId.DarkMagician, CardId.DarkMagician);
                return true;
            }

            if (Bot.HasInMonstersZone(CardId.MagiciansRod) || Bot.HasInMonstersZone(CardId.SpellbookMagicianOfProphecy))
            {
                AI.SelectCard(CardId.MagiciansRod, CardId.SpellbookMagicianOfProphecy);
                AI.SelectNextCard(CardId.DarkMagician, CardId.DarkMagician);
                return true;
            }
            if (Duel.Player == 1 && Bot.HasInMonstersZone(CardId.WindwitchGlassBell))
            {
                AI.SelectCard(CardId.WindwitchGlassBell);
                AI.SelectNextCard(CardId.DarkMagician, CardId.DarkMagician);
                return true;
            }
            if (Duel.Player == 1 && Bot.HasInMonstersZone(CardId.WindwitchIceBell))
            {
                AI.SelectCard(CardId.WindwitchIceBell);
                AI.SelectNextCard(CardId.DarkMagician, CardId.DarkMagician);
                return true;
            }
            if (Duel.Player == 1 && Bot.HasInMonstersZone(CardId.WindwitchSnowBell))
            {
                AI.SelectCard(CardId.WindwitchSnowBell);
                AI.SelectNextCard(CardId.DarkMagician, CardId.DarkMagician);
                return true;
            }
            if (Duel.Player == 1 && Bot.HasInMonstersZone(CardId.SpellbookMagicianOfProphecy))
            {
                AI.SelectCard(CardId.SpellbookMagicianOfProphecy);
                AI.SelectNextCard(CardId.DarkMagician, CardId.DarkMagician);
                return true;
            }
            if (Duel.Player == 1 && Bot.HasInMonstersZone(CardId.ApprenticeLllusionMagician) &&
               (Bot.HasInSpellZone(CardId.EternalSoul) || Bot.HasInSpellZone(CardId.MagicianNavigation)))
            {
                AI.SelectCard(CardId.ApprenticeLllusionMagician);
                AI.SelectNextCard(CardId.DarkMagician, CardId.DarkMagician);
                return true;
            }

            if ((Bot.GetRemainingCount(CardId.DarkMagician, 3) > 1 || Bot.HasInGraveyard(CardId.DarkMagician)) &&
                Bot.HasInSpellZone(CardId.MagicianNavigation) &&
                (Bot.HasInMonstersZone(CardId.DarkMagician) || Bot.HasInMonstersZone(CardId.ApprenticeLllusionMagician)) &&
                Duel.Player == 1 && !Bot.HasInHand(CardId.DarkMagician))
            {
                AI.SelectCard(CardId.DarkMagician, CardId.ApprenticeLllusionMagician);
                AI.SelectNextCard(CardId.DarkMagician, CardId.DarkMagician);
                return true;
            }
            return false;
        }
        private bool SpellbookMagicianOfProphecyeff()
        {
            Logger.DebugWriteLine("*********Secret_used= " + Secret_used);
            if (Secret_used)
                AI.SelectCard(CardId.SpellbookOfKnowledge);
            else
                AI.SelectCard(CardId.SpellbookOfSecrets, CardId.SpellbookOfKnowledge);
            return true;
        }

        private bool TheEyeOfTimaeuseff()
        {
            //AI.SelectPlace(Zones.z2, 2);
            return true;
        }

        private bool UpstartGoblineff()
        {
            //AI.SelectPlace(Zones.z2, 2);
            return true;
        }
        private bool SpellbookOfSecreteff()
        {
            if (lockbird_used) return false;
            //AI.SelectPlace(Zones.z2, 2);
            Secret_used = true;
            if (Bot.HasInHand(CardId.SpellbookMagicianOfProphecy))
                AI.SelectCard(CardId.SpellbookOfKnowledge);
            else
                AI.SelectCard(CardId.SpellbookMagicianOfProphecy);
            return true;
        }

        private bool SpellbookOfKnowledgeeff()
        {
            int count = 0;
            foreach (ClientCard check in Bot.GetMonsters())
            {
                if (!check.IsCode(CardId.CrystalWingSynchroDragon))
                    count++;
            }
            Logger.DebugWriteLine("%%%%%%%%%%%%%%%%SpellCaster= " + count);
            if (lockbird_used) return false;
            if (Bot.HasInSpellZone(CardId.LllusionMagic) && count < 2)
                return false;
            //AI.SelectPlace(Zones.z2, 2);
            if (Bot.HasInMonstersZone(CardId.SpellbookMagicianOfProphecy) ||
                Bot.HasInMonstersZone(CardId.MagiciansRod) ||
                Bot.HasInMonstersZone(CardId.WindwitchGlassBell) ||
                Bot.HasInMonstersZone(CardId.WindwitchIceBell))
            {
                AI.SelectCard(CardId.SpellbookMagicianOfProphecy, CardId.MagiciansRod, CardId.WindwitchGlassBell);
                return true;
            }
            if (Bot.HasInMonstersZone(CardId.ApprenticeLllusionMagician) && Bot.GetSpellCount() < 2 && Duel.Phase == DuelPhase.Main2)
            {
                AI.SelectCard(CardId.ApprenticeLllusionMagician);
                return true;
            }
            if (Bot.HasInMonstersZone(CardId.DarkMagician) &&
                    Bot.HasInSpellZone(CardId.EternalSoul) && Duel.Phase == DuelPhase.Main2)
            {
                AI.SelectCard(CardId.DarkMagician);
                return true;
            }
            return false;
        }

        private bool WonderWandeff()
        {
            if (lockbird_used) return false;
            int count = 0;
            foreach (ClientCard check in Bot.GetMonsters())
            {
                if (!check.IsCode(CardId.CrystalWingSynchroDragon))
                    count++;
            }
            Logger.DebugWriteLine("%%%%%%%%%%%%%%%%SpellCaster= " + count);
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.HasInSpellZone(CardId.LllusionMagic) && count < 2)
                    return false;
                //AI.SelectPlace(Zones.z2, 2);
                if (Bot.HasInMonstersZone(CardId.SpellbookMagicianOfProphecy) ||
                Bot.HasInMonstersZone(CardId.MagiciansRod) ||
                Bot.HasInMonstersZone(CardId.WindwitchGlassBell) ||
                Bot.HasInMonstersZone(CardId.WindwitchIceBell))
                {
                    AI.SelectCard(
                        CardId.SpellbookMagicianOfProphecy,
                        CardId.MagiciansRod,
                        CardId.WindwitchGlassBell,
                        CardId.WindwitchIceBell
                        );
                    return UniqueFaceupSpell();
                }

                if (Bot.HasInMonstersZone(CardId.DarkMagician) &&
                    Bot.HasInSpellZone(CardId.EternalSoul) && Duel.Phase == DuelPhase.Main2)
                {
                    AI.SelectCard(CardId.DarkMagician);
                    return UniqueFaceupSpell();
                }
                if (Bot.HasInMonstersZone(CardId.ApprenticeLllusionMagician) && Bot.GetSpellCount() < 2 && Duel.Phase == DuelPhase.Main2)
                {
                    AI.SelectCard(CardId.ApprenticeLllusionMagician);
                    return UniqueFaceupSpell();
                }
                if (Bot.HasInMonstersZone(CardId.ApprenticeLllusionMagician) && Bot.GetHandCount() <= 3 && Duel.Phase == DuelPhase.Main2)
                {
                    AI.SelectCard(CardId.ApprenticeLllusionMagician);
                    return UniqueFaceupSpell();
                }
            }
            else
            {
                if (Duel.Turn != 1)
                {
                    if (Duel.Phase == DuelPhase.Main1 && Enemy.GetSpellCountWithoutField() == 0 &&
                    Util.GetBestEnemyMonster(true, true) == null)
                        return false;
                    if (Duel.Phase == DuelPhase.Main1 && Enemy.GetSpellCountWithoutField() == 0 &&
                        Util.GetBestEnemyMonster().IsFacedown())
                        return true;
                    if (Duel.Phase == DuelPhase.Main1 && Enemy.GetSpellCountWithoutField() == 0 &&
                        Util.GetBestBotMonster(true) != null &&
                        Util.GetBestBotMonster(true).Attack > Util.GetBestEnemyMonster(true).Attack)
                        return false;
                }
                return true;
            }
            return false;
        }

        private bool ApprenticeLllusionMagiciansp()
        {
            //AI.SelectPlace(Zones.z2, 1);
            if (Bot.HasInHand(CardId.DarkMagician) && !Bot.HasInSpellZone(CardId.MagicianNavigation))
            {
                if (Bot.GetRemainingCount(CardId.DarkMagician, 3) > 0)
                {
                    AI.SelectCard(CardId.DarkMagician);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                return false;
            }
            if ((Bot.HasInHand(CardId.SpellbookOfSecrets) ||
                  Bot.HasInHand(CardId.DarkMagicAttack)))
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                AI.SelectCard(CardId.SpellbookOfSecrets, CardId.DarkMagicAttack);
                return true;
            }
            if (Bot.HasInMonstersZone(CardId.ApprenticeLllusionMagician))
                return false;
            int count = 0;
            foreach (ClientCard check in Bot.Hand)
            {
                if (check.IsCode(CardId.WonderWand))
                    count++;
            }
            if (count >= 2)
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                AI.SelectCard(CardId.WonderWand);
                return true;
            }
            if (!Bot.HasInHandOrInSpellZone(CardId.EternalSoul) &&
                Bot.HasInHandOrInSpellZone(CardId.MagicianNavigation) &&
                !Bot.HasInHand(CardId.DarkMagician) && Bot.GetHandCount() > 2 &&
                Bot.GetMonsterCount() == 0)
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                AI.SelectCard(CardId.MagicianOfLllusion, CardId.ApprenticeLllusionMagician, CardId.TheEyeOfTimaeus, CardId.DarkMagicInheritance, CardId.WonderWand);
                return true;
            }
            if (!Bot.HasInHandOrInMonstersZoneOrInGraveyard(CardId.DarkMagician))
            {
                if (Bot.HasInHandOrInSpellZone(CardId.LllusionMagic) && Bot.GetMonsterCount() >= 1)
                    return false;
                AI.SelectPosition(CardPosition.FaceUpAttack);
                int Navigation_count = 0;
                foreach (ClientCard Navigation in Bot.Hand)
                {
                    if (Navigation.IsCode(CardId.MagicianNavigation))
                        Navigation_count++;
                }
                if (Navigation_count >= 2)
                {
                    AI.SelectCard(CardId.MagicianNavigation);
                    return true;
                }
                AI.SelectCard(CardId.MagicianOfLllusion, CardId.ApprenticeLllusionMagician, CardId.TheEyeOfTimaeus, CardId.DarkMagicInheritance, CardId.WonderWand);
                return true;
            }
            return false;
        }
        private bool ApprenticeLllusionMagicianeff()
        {
            if (Util.ChainContainsCard(CardId.ApprenticeLllusionMagician)) return false;
            if (Duel.Phase == DuelPhase.Battle ||
                Duel.Phase == DuelPhase.BattleStart ||
                Duel.Phase == DuelPhase.BattleStep ||
                Duel.Phase == DuelPhase.Damage ||
                Duel.Phase == DuelPhase.DamageCal
               )
            {
                if (ActivateDescription == -1)
                {
                    Logger.DebugWriteLine("ApprenticeLllusionMagicianadd");
                    return true;
                }
                if (Card.IsDisabled()) return false;
                if ((Bot.BattlingMonster == null)) return false;
                if ((Enemy.BattlingMonster == null)) return false;
                if (Bot.BattlingMonster.Attack < Enemy.BattlingMonster.Attack)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }
        private bool SpellbookMagicianOfProphecysummon()
        {
            //AI.SelectPlace(Zones.z2, 1);
            if (lockbird_used) return false;
            if (Spellbook_summon)
            {
                if (Secret_used)
                    AI.SelectCard(CardId.SpellbookOfKnowledge);
                else
                    AI.SelectCard(CardId.SpellbookOfSecrets, CardId.SpellbookOfKnowledge);
                return true;
            }
            return false;
        }
        private bool MagiciansRodsummon()
        {
            if (lockbird_used) return false;
            //AI.SelectPlace(Zones.z2, 1);
            if (Rod_summon) return true;
            return true;
        }

        private bool DarkMagicAttackeff()
        {
            //AI.SelectPlace(Zones.z1, 2);
            return DefaultHarpiesFeatherDusterFirst();
        }
        private bool DarkMagicInheritanceeff()
        {
            if (lockbird_used) return false;
            IList<ClientCard> grave = Bot.Graveyard;
            IList<ClientCard> spell = new List<ClientCard>();
            int count = 0;
            foreach (ClientCard check in grave)
            {
                if (Card.HasType(CardType.Spell))
                {
                    spell.Add(check);
                    count++;
                }
            }
            if (count >= 2)
            {
                //AI.SelectPlace(Zones.z2, 2);
                AI.SelectCard(spell);
                if (Bot.HasInHandOrInSpellZone(CardId.EternalSoul) && Bot.HasInHandOrInSpellZone(CardId.DarkMagicalCircle))
                    if (Bot.GetRemainingCount(CardId.DarkMagician, 3) >= 2 && !Bot.HasInHandOrInSpellZoneOrInGraveyard(CardId.LllusionMagic))
                    {
                        AI.SelectNextCard(CardId.LllusionMagic);
                        return true;
                    }

                if (Bot.HasInHand(CardId.ApprenticeLllusionMagician) &&
                  (!Bot.HasInHandOrInSpellZone(CardId.EternalSoul) || !Bot.HasInHandOrInSpellZone(CardId.MagicianNavigation)))
                {
                    AI.SelectNextCard(CardId.MagicianNavigation);
                    return true;
                }
                if (Bot.HasInHandOrInSpellZone(CardId.EternalSoul) && !Bot.HasInHandOrInMonstersZoneOrInGraveyard(CardId.DarkMagician) &&
                    !Bot.HasInHandOrInSpellZoneOrInGraveyard(CardId.LllusionMagic))
                {
                    AI.SelectNextCard(CardId.LllusionMagic);
                    return true;
                }

                if (Bot.HasInHandOrInSpellZone(CardId.MagicianNavigation) &&
                    !Bot.HasInHand(CardId.DarkMagician) &&
                    !Bot.HasInHandOrInSpellZone(CardId.EternalSoul) &&
                    Bot.GetRemainingCount(CardId.LllusionMagic, 1) > 0)
                {
                    AI.SelectNextCard(CardId.LllusionMagic);
                    return true;
                }

                if ((Bot.HasInHandOrInSpellZone(CardId.EternalSoul) || Bot.HasInHandOrInSpellZone(CardId.MagicianNavigation)) &&
                    !Bot.HasInHandOrInSpellZone(CardId.DarkMagicalCircle))
                {
                    AI.SelectNextCard(CardId.DarkMagicalCircle);
                    return true;
                }
                if (Bot.HasInHandOrInSpellZone(CardId.DarkMagicalCircle))
                {
                    if (Bot.HasInGraveyard(CardId.MagicianNavigation))
                    {
                        AI.SelectNextCard(CardId.EternalSoul, CardId.MagicianNavigation, CardId.DarkMagicalCircle);
                    }
                    else
                        AI.SelectNextCard(CardId.EternalSoul, CardId.MagicianNavigation, CardId.DarkMagicalCircle);
                    return true;
                }
                if (Bot.HasInGraveyard(CardId.MagicianNavigation))
                {
                    AI.SelectNextCard(CardId.EternalSoul, CardId.DarkMagicalCircle, CardId.MagicianNavigation);
                }
                else
                    AI.SelectNextCard(CardId.MagicianNavigation, CardId.DarkMagicalCircle, CardId.EternalSoul);
                return true;
            }
            return false;
        }
        private bool MagiciansRodeff()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (Bot.HasInHandOrInSpellZone(CardId.EternalSoul) && Bot.HasInHandOrInSpellZone(CardId.DarkMagicalCircle))
                    if (Bot.GetRemainingCount(CardId.DarkMagician, 3) >= 2 && Bot.GetRemainingCount(CardId.LllusionMagic, 1) > 0)
                    {
                        AI.SelectCard(CardId.LllusionMagic);
                        return true;
                    }

                if (Bot.HasInHand(CardId.ApprenticeLllusionMagician) &&
                  !Bot.HasInHandOrInSpellZone(CardId.MagicianNavigation) &&
                  Bot.GetRemainingCount(CardId.MagicianNavigation, 3) > 0)
                {
                    AI.SelectCard(CardId.MagicianNavigation);
                    return true;
                }

                if (Bot.HasInHandOrInSpellZone(CardId.EternalSoul) &&
                    !Bot.HasInHandOrInMonstersZoneOrInGraveyard(CardId.DarkMagician) &&
                    Bot.GetRemainingCount(CardId.LllusionMagic, 1) > 0)
                {
                    AI.SelectCard(CardId.LllusionMagic);
                    return true;
                }

                if (Bot.HasInHandOrInSpellZone(CardId.MagicianNavigation) &&
                    !Bot.HasInHand(CardId.DarkMagician) &&
                    !Bot.HasInHandOrInSpellZone(CardId.EternalSoul) &&
                    Bot.GetRemainingCount(CardId.LllusionMagic, 1) > 0)
                {
                    AI.SelectCard(CardId.LllusionMagic);
                    return true;
                }
                if (!Bot.HasInHandOrInSpellZone(CardId.EternalSoul) &&
                    Bot.HasInHandOrInSpellZone(CardId.DarkMagicalCircle) &&
                    Bot.HasInHandOrInSpellZone(CardId.MagicianNavigation) &&
                    Bot.GetRemainingCount(CardId.EternalSoul, 3) > 0)
                {
                    AI.SelectCard(CardId.EternalSoul);
                    return true;
                }
                if ((Bot.HasInHandOrInSpellZone(CardId.EternalSoul) || Bot.HasInHandOrInSpellZone(CardId.MagicianNavigation)) &&
                    !Bot.HasInHandOrInSpellZone(CardId.DarkMagicalCircle) &&
                    Bot.GetRemainingCount(CardId.DarkMagicalCircle, 3) > 0)
                {
                    AI.SelectCard(CardId.DarkMagicalCircle);
                    return true;
                }
                if (!Bot.HasInHandOrInSpellZone(CardId.EternalSoul) &&
                    !Bot.HasInHandOrInSpellZone(CardId.MagicianNavigation))
                {
                    if (Bot.HasInHand(CardId.DarkMagician) &&
                        !Bot.HasInGraveyard(CardId.MagicianNavigation) &&
                        Bot.GetRemainingCount(CardId.MagicianNavigation, 3) > 0
                        )
                        AI.SelectCard(CardId.MagicianNavigation);
                    else if (!Bot.HasInHandOrInSpellZone(CardId.DarkMagicalCircle))
                        AI.SelectCard(CardId.DarkMagicalCircle);
                    else
                        AI.SelectCard(CardId.EternalSoul);
                    return true;
                }
                if (!Bot.HasInHand(CardId.MagicianNavigation))
                {
                    AI.SelectCard(CardId.MagicianNavigation);
                    return true;
                }
                if (!Bot.HasInHand(CardId.DarkMagicalCircle))
                {
                    AI.SelectCard(CardId.DarkMagicalCircle);
                    return true;
                }
                if (!Bot.HasInHand(CardId.EternalSoul))
                {
                    AI.SelectCard(CardId.EternalSoul);
                    return true;
                }
                AI.SelectCard(CardId.LllusionMagic, CardId.EternalSoul, CardId.DarkMagicalCircle, CardId.MagicianNavigation);
                return true;
            }
            else
            {
                if (Bot.HasInMonstersZone(CardId.VentriloauistsClaraAndLucika))
                {
                    AI.SelectCard(CardId.VentriloauistsClaraAndLucika);
                    return true;
                }
                int Enemy_atk = 0;
                IList<ClientCard> list = new List<ClientCard>();
                foreach (ClientCard monster in Enemy.GetMonsters())
                {
                    if (monster.IsAttack())
                        list.Add(monster);
                }
                Enemy_atk = GetTotalATK(list);
                int bot_atk = 0;
                IList<ClientCard> list_1 = new List<ClientCard>();
                foreach (ClientCard monster in Bot.GetMonsters())
                {
                    if (Util.GetWorstBotMonster(true) != null)
                    {
                        if (monster.IsAttack() && monster.Id != Util.GetWorstBotMonster(true).Id)
                            list_1.Add(monster);
                    }
                }
                bot_atk = GetTotalATK(list);
                if (Bot.HasInHand(CardId.MagiciansRod)) return false;
                if (Bot.HasInMonstersZone(CardId.ApprenticeWitchling) && Bot.GetMonsterCount() == 1 && Bot.HasInSpellZone(CardId.EternalSoul))
                    return false;
                if (Bot.LifePoints <= (Enemy_atk - bot_atk) &&
                    Bot.GetMonsterCount() > 1) return false;
                if ((Bot.LifePoints - Enemy_atk <= 1000) &&
                    Bot.GetMonsterCount() == 1) return false;
                AI.SelectCard(CardId.VentriloauistsClaraAndLucika, CardId.SpellbookMagicianOfProphecy, CardId.WindwitchGlassBell, CardId.WindwitchIceBell, CardId.MagiciansRod, CardId.DarkMagician, CardId.MagicianOfLllusion);
                return true;
            }
        }

        private bool WindwitchGlassBellsummonfirst()
        {
            if (Bot.HasInMonstersZone(CardId.WindwitchIceBell) &&
                Bot.HasInMonstersZone(CardId.WindwitchSnowBell) &&
                !Bot.HasInMonstersZone(CardId.WindwitchGlassBell))
                return true;
            return false;
        }
        private bool WindwitchGlassBellsummon()
        {
            if (lockbird_used) return false;
            if (!plan_A && (Bot.HasInGraveyard(CardId.WindwitchGlassBell) || Bot.HasInMonstersZone(CardId.WindwitchGlassBell)))
                return false;
            //AI.SelectPlace(Zones.z2, 1);
            if (GlassBell_summon && Bot.HasInMonstersZone(CardId.WindwitchIceBell) &&
                !Bot.HasInMonstersZone(CardId.WindwitchGlassBell))
                return true;
            if (WindwitchGlassBelleff_used) return false;
            if (GlassBell_summon) return true;
            return false;
        }
        private bool BigEyesp()
        {
            if (plan_C) return false;
            if (Util.IsOneEnemyBetterThanValue(2500, false) &&
                !Bot.HasInHandOrHasInMonstersZone(CardId.ApprenticeLllusionMagician))
            {
                //AI.SelectPlace(Zones.z5, Zones.ExtraMonsterZones);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }

        private bool BigEyeeff()
        {
            ClientCard target = Util.GetBestEnemyMonster(false, true);
            if (target != null && target.Attack >= 2500)
            {
                AI.SelectCard(CardId.DarkMagician);
                AI.SelectNextCard(target);
                return true;
            }
            return false;

        }
        private bool Dracossacksp()
        {
            if (plan_C) return false;
            if (Util.IsOneEnemyBetterThanValue(2500, false) &&
                !Bot.HasInHandOrHasInMonstersZone(CardId.ApprenticeLllusionMagician))
            {
                //AI.SelectPlace(Zones.z5, Zones.ExtraMonsterZones);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }

        private bool Dracossackeff()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Dracossack, 0))
            {
                AI.SelectCard(CardId.DarkMagician);
                return true;

            }
            ClientCard target = Util.GetBestEnemyCard(false, true);
            if (target != null)
            {
                AI.SelectCard(CardId.Dracossack + 1);
                AI.SelectNextCard(target);
                return true;
            }
            return false;
        }

        private bool ApprenticeWitchlingsp()
        {
            int rod_count = 0;
            foreach (ClientCard rod in Bot.GetMonsters())
            {
                if (rod.IsCode(CardId.MagiciansRod))
                    rod_count++;
            }
            if (rod_count >= 2)
            {
                AI.SelectCard(CardId.MagiciansRod, CardId.MagiciansRod);
                return true;
            }
            if (Bot.HasInMonstersZone(CardId.DarkMagician) &&
                Bot.HasInMonstersZone(CardId.MagiciansRod) &&
                (Bot.HasInSpellZone(CardId.EternalSoul) || Bot.GetMonsterCount() >= 4)
                && Duel.Phase == DuelPhase.Main2)
            {
                if (rod_count >= 2)
                    AI.SelectCard(CardId.MagiciansRod, CardId.MagiciansRod);
                else
                    AI.SelectCard(CardId.MagiciansRod, CardId.DarkMagician);
                return true;
            }
            if (Bot.HasInMonstersZone(CardId.MagiciansRod) &&
                Bot.HasInMonstersZone(CardId.ApprenticeLllusionMagician) &&
                (Bot.HasInSpellZone(CardId.EternalSoul) || Bot.HasInSpellZone(CardId.MagicianNavigation))
                && Duel.Phase == DuelPhase.Main2)
            {
                if (rod_count >= 2)
                    AI.SelectCard(CardId.MagiciansRod, CardId.MagiciansRod);
                else
                    AI.SelectCard(CardId.MagiciansRod, CardId.DarkMagician);
                return true;
            }
            return false;
        }

        private bool ApprenticeWitchlingeff()
        {
            AI.SelectCard(CardId.MagiciansRod, CardId.DarkMagician, CardId.ApprenticeLllusionMagician);
            return true;
        }

        private bool VentriloauistsClaraAndLucikasp()
        {
            if (Bot.HasInSpellZone(CardId.LllusionMagic)) return false;
            if (Bot.HasInMonstersZone(CardId.MagiciansRod) && !Bot.HasInGraveyard(CardId.MagiciansRod) &&
                (Bot.HasInSpellZone(CardId.EternalSoul) || Bot.HasInSpellZone(CardId.MagicianNavigation)))
            {
                AI.SelectCard(CardId.MagiciansRod);
                return true;
            }
            return false;
        }
        public override void OnChaining(int player, ClientCard card)
        {
            base.OnChaining(player, card);
        }


        public override void OnChainEnd()
        {
            /*if (Enemy.MonsterZone[5] != null)
            {
                Logger.DebugWriteLine("%%%%%%%%%%%%%%%%Enemy.MonsterZone[5].LinkMarker= " + Enemy.MonsterZone[5].LinkMarker);
                Logger.DebugWriteLine("%%%%%%%%%%%%%%%%Enemy.MonsterZone[5].LinkLevel= " + Enemy.MonsterZone[5].LinkLevel);                
            }
                
            if (Enemy.MonsterZone[6] != null)
            {
                Logger.DebugWriteLine("%%%%%%%%%%%%%%%%Enemy.MonsterZone[6].LinkMarker= " + Enemy.MonsterZone[6].LinkMarker);
                Logger.DebugWriteLine("%%%%%%%%%%%%%%%%Enemy.MonsterZone[6].LinkLevel= " + Enemy.MonsterZone[6].LinkLevel);
            }
            for (int i = 0; i < 6; i++)
            {
                if (Enemy.MonsterZone[i] != null)
                    Logger.DebugWriteLine("++++++++MONSTER ZONE[" + i + "]= " + Enemy.MonsterZone[i].Attack);
            }
            for (int i = 0; i < 6; i++)
            {
                if (Bot.MonsterZone[i] != null)
                    Logger.DebugWriteLine("++++++++MONSTER ZONE[" + i + "]= " + Bot.MonsterZone[i].Id);
            }
            for (int i = 0; i < 4; i++)
            {
                if (Bot.SpellZone[i] != null)
                    Logger.DebugWriteLine("++++++++SpellZone[" + i + "]= " + Bot.SpellZone[i].Id);
            }*/
            if (Util.ChainContainsCard(CardId.MaxxC))
                maxxc_used = true;
            if ((Duel.CurrentChain.Count >= 1 && Util.GetLastChainCard().Id == 0) ||
                (Duel.CurrentChain.Count == 2 && !Util.ChainContainPlayer(0) && Duel.CurrentChain[0].Id == 0))
            {
                Logger.DebugWriteLine("current chain = " + Duel.CurrentChain.Count);
                Logger.DebugWriteLine("******last chain card= " + Util.GetLastChainCard().Id);
                int maxxc_count = 0;
                foreach (ClientCard check in Enemy.Graveyard)
                {
                    if (check.IsCode(CardId.MaxxC))
                        maxxc_count++;
                }
                if (maxxc_count != maxxc_done)
                {
                    Logger.DebugWriteLine("************************last chain card= " + Util.GetLastChainCard().Id);
                    maxxc_used = true;
                }
                int lockbird_count = 0;
                foreach (ClientCard check in Enemy.Graveyard)
                {
                    if (check.IsCode(CardId.LockBird))
                        lockbird_count++;
                }
                if (lockbird_count != lockbird_done)
                {
                    Logger.DebugWriteLine("************************last chain card= " + Util.GetLastChainCard().Id);
                    lockbird_used = true;
                }
                int ghost_count = 0;
                foreach (ClientCard check in Enemy.Graveyard)
                {
                    if (check.IsCode(CardId.Ghost))
                        ghost_count++;
                }
                if (ghost_count != ghost_done)
                {
                    Logger.DebugWriteLine("************************last chain card= " + Util.GetLastChainCard().Id);
                    ghost_used = true;
                }
                if (ghost_used && Util.ChainContainsCard(CardId.WindwitchGlassBell))
                {
                    AI.SelectCard(CardId.WindwitchIceBell);
                    Logger.DebugWriteLine("***********WindwitchGlassBell*********************");
                }

            }
            foreach (ClientCard dangerous in Enemy.GetMonsters())
            {
                if (dangerous != null && dangerous.IsShouldNotBeTarget() &&
                    (dangerous.Attack > 2500 || dangerous.Defense > 2500) &&
                    !Bot.HasInHandOrHasInMonstersZone(CardId.ApprenticeLllusionMagician))
                {
                    plan_C = true;
                    Logger.DebugWriteLine("*********dangerous = " + dangerous.Id);
                }
            }
            int count = 0;
            foreach (ClientCard check in Enemy.Graveyard)
            {
                if (check.IsCode(CardId.MaxxC))
                    count++;
            }
            maxxc_done = count;
            count = 0;
            foreach (ClientCard check in Enemy.Graveyard)
            {
                if (check.IsCode(CardId.LockBird))
                    count++;
            }
            lockbird_done = count;
            count = 0;
            foreach (ClientCard check in Enemy.Graveyard)
            {
                if (check.IsCode(CardId.Ghost))
                    count++;
            }
            ghost_done = count;
            base.OnChainEnd();
        }


        public override bool OnPreBattleBetween(ClientCard attacker, ClientCard defender)
        {
            //Logger.DebugWriteLine("@@@@@@@@@@@@@@@@@@@ApprenticeLllusionMagician= " + ApprenticeLllusionMagician_count);            
            if (Bot.HasInSpellZone(CardId.OddEyesWingDragon))
                big_attack = true;
            if (Duel.Player == 0 && Bot.GetMonsterCount() >= 2 && plan_C)
            {
                Logger.DebugWriteLine("*********dangerous********************* ");
                if (attacker.IsCode(CardId.OddEyesAbsoluteDragon, CardId.OddEyesWingDragon))
                    attacker.RealPower = 999999;
            }
            if ((attacker.IsCode(CardId.DarkMagician, CardId.MagiciansRod, CardId.BigEye, CardId.ApprenticeWitchling)) &&
                Bot.HasInHandOrHasInMonstersZone(CardId.ApprenticeLllusionMagician))
            {
                attacker.RealPower += 2000;
            }
            if (attacker.IsCode(CardId.ApprenticeLllusionMagician) && ApprenticeLllusionMagician_count >= 2)
            {
                attacker.RealPower += 2000;
            }
            if (attacker.IsCode(CardId.DarkMagician, CardId.DarkMagicianTheDragonKnight) && Bot.HasInSpellZone(CardId.EternalSoul))
            {
                return true;
            }
            if (attacker.IsCode(CardId.CrystalWingSynchroDragon))
            {
                if (defender.Level >= 5)
                    attacker.RealPower = 999999;
                if (CrystalWingSynchroDragon_used == false)
                    return true;
            }
            if (!big_attack_used && big_attack)
            {
                attacker.RealPower = 999999;
                big_attack_used = true;
                return true;
            }
            if (attacker.IsCode(CardId.ApprenticeLllusionMagician))
                Logger.DebugWriteLine("@@@@@@@@@@@@@@@@@@@ApprenticeLllusionMagician= " + attacker.RealPower);
            if (Bot.HasInSpellZone(CardId.EternalSoul) && attacker.IsCode(CardId.DarkMagician, CardId.DarkMagicianTheDragonKnight, CardId.MagicianOfLllusion))
                return true;

            if (!defender.IsMonsterHasPreventActivationEffectInBattle())
            {
                if (!attacker.IsDisabled() && (attacker.IsCode(CardId.MekkKnightCrusadiaAstram) && defender.IsSpecialSummoned
                                            || attacker.IsCode(CardId.CrystalWingSynchroDragon) && defender.Level>=5))
                {
                    attacker.RealPower = attacker.RealPower + defender.Attack;
                }
            }

            return base.OnPreBattleBetween(attacker, defender);
        }


        //ToadallyAwesomeExecutor
        private bool MedallionOfTheIceBarrierEffect()
        {
            if (Bot.HasInHand(new[]
                {
                    CardId.CryomancerOfTheIceBarrier,
                    CardId.DewdarkOfTheIceBarrier
                }) || Bot.HasInMonstersZone(new[]
                {
                    CardId.CryomancerOfTheIceBarrier,
                    CardId.DewdarkOfTheIceBarrier
                }))
            {
                AI.SelectCard(CardId.PriorOfTheIceBarrier);
            }
            else
            {
                AI.SelectCard(
                    CardId.CryomancerOfTheIceBarrier,
                    CardId.DewdarkOfTheIceBarrier
                    );
            }
            return true;
        }

        private bool SurfaceEffect()
        {
            AI.SelectCard(
                CardId.ToadallyAwesome,
                CardId.HeraldOfTheArcLight,
                CardId.SwapFrog,
                CardId.DewdarkOfTheIceBarrier,
                CardId.CryomancerOfTheIceBarrier,
                CardId.DupeFrog,
                CardId.Ronintoadin,
                CardId.GraydleSlimeJr
                );
            return true;
        }

        private bool AquariumStageEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return SurfaceEffect();
            }
            return true;
        }

        private bool FoolishBurialEffect()
        {
            if (Bot.HasInHand(CardId.GraydleSlimeJr) && !Bot.HasInGraveyard(CardId.GraydleSlimeJr))
                AI.SelectCard(CardId.GraydleSlimeJr);
            else if (Bot.HasInGraveyard(CardId.Ronintoadin) && !Bot.HasInGraveyard(CardId.DupeFrog))
                AI.SelectCard(CardId.DupeFrog);
            else if (Bot.HasInGraveyard(CardId.DupeFrog) && !Bot.HasInGraveyard(CardId.Ronintoadin))
                AI.SelectCard(CardId.Ronintoadin);
            else
                AI.SelectCard(
                    CardId.GraydleSlimeJr,
                    CardId.Ronintoadin,
                    CardId.DupeFrog,
                    CardId.CryomancerOfTheIceBarrier,
                    CardId.DewdarkOfTheIceBarrier,
                    CardId.PriorOfTheIceBarrier,
                    CardId.SwapFrog
                    );
            return true;
        }

        private bool SalvageEffect()
        {
            AI.SelectCard(
                CardId.SwapFrog,
                CardId.PriorOfTheIceBarrier,
                CardId.GraydleSlimeJr
                );
            return true;
        }

        private bool SwapFrogSpsummon()
        {
            if (Bot.GetCountCardInZone(Bot.Hand, CardId.GraydleSlimeJr)>=2 && !Bot.HasInGraveyard(CardId.GraydleSlimeJr))
                AI.SelectCard(CardId.GraydleSlimeJr);
            else if (Bot.HasInGraveyard(CardId.Ronintoadin) && !Bot.HasInGraveyard(CardId.DupeFrog))
                AI.SelectCard(CardId.DupeFrog);
            else if (Bot.HasInGraveyard(CardId.DupeFrog) && !Bot.HasInGraveyard(CardId.Ronintoadin))
                AI.SelectCard(CardId.Ronintoadin);
            else
                AI.SelectCard(
                    CardId.Ronintoadin,
                    CardId.DupeFrog,
                    CardId.CryomancerOfTheIceBarrier,
                    CardId.DewdarkOfTheIceBarrier,
                    CardId.PriorOfTheIceBarrier,
                    CardId.GraydleSlimeJr,
                    CardId.SwapFrog
                    );
            return true;
        }

        private bool SwapFrogEffect()
        {
            if (ActivateDescription == -1)
            {
                return FoolishBurialEffect();
            }
            else
            {
                if (Bot.HasInHand(CardId.DupeFrog))
                {
                    AI.SelectCard(
                        CardId.PriorOfTheIceBarrier,
                        CardId.GraydleSlimeJr,
                        CardId.SwapFrog
                        );
                    return true;
                }
            }
            return false;
        }

        private bool GraydleSlimeJrSummon()
        {
            return Bot.HasInGraveyard(CardId.GraydleSlimeJr);
        }

        private bool GraydleSlimeJrEffect()
        {
            AI.SelectCard(CardId.GraydleSlimeJr);
            AI.SelectPosition(CardPosition.FaceUpDefence);
            AI.SelectNextCard(
                CardId.SwapFrog,
                CardId.CryomancerOfTheIceBarrier,
                CardId.DewdarkOfTheIceBarrier,
                CardId.Ronintoadin,
                CardId.DupeFrog,
                CardId.PriorOfTheIceBarrier,
                CardId.GraydleSlimeJr
                );
            return true;
        }

        private bool RonintoadinEffect()
        {
            AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }

        private bool NormalSummon()
        {
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if (monster.Level==2)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IceBarrierSummon()
        {
            return Bot.GetCountCardInZone(Bot.Hand, CardId.PriorOfTheIceBarrier) > 0;
        }

        private bool PriorOfTheIceBarrierSummon()
        {
            return Bot.GetCountCardInZone(Bot.Hand, CardId.PriorOfTheIceBarrier) >= 2;
        }

        private bool ToadallyAwesomeEffect()
        {
            if (Duel.CurrentChain.Count > 0)
            {
                // negate effect, select a cost for it
                List<ClientCard> monsters = Bot.GetMonsters();
                IList<int> suitableCost = new[] {
                    CardId.SwapFrog,
                    CardId.Ronintoadin,
                    CardId.GraydleSlimeJr,
                    CardId.CryomancerOfTheIceBarrier,
                    CardId.DewdarkOfTheIceBarrier
                };
                foreach (ClientCard monster in monsters)
                {
                    if (monster.IsCode(suitableCost))
                    {
                        AI.SelectCard(monster);
                        return true;
                    }
                }
                if (!Bot.HasInSpellZone(CardId.AquariumStage, true))
                {
                    foreach (ClientCard monster in monsters)
                    {
                        if (monster.IsCode(CardId.DupeFrog))
                        {
                            AI.SelectCard(monster);
                            return true;
                        }
                    }
                }
                List<ClientCard> hands = Bot.Hand.GetMonsters();
                if (Bot.GetCountCardInZone(Bot.Hand, CardId.GraydleSlimeJr) >= 2)
                {
                    foreach (ClientCard monster in hands)
                    {
                        if (monster.IsCode(CardId.GraydleSlimeJr))
                        {
                            AI.SelectCard(monster);
                            return true;
                        }
                    }
                }
                if (Bot.HasInGraveyard(CardId.Ronintoadin) && !Bot.HasInGraveyard(CardId.DupeFrog) && !Bot.HasInGraveyard(CardId.SwapFrog))
                {
                    foreach (ClientCard monster in hands)
                    {
                        if (monster.IsCode(CardId.DupeFrog))
                        {
                            AI.SelectCard(monster);
                            return true;
                        }
                    }
                }
                foreach (ClientCard monster in hands)
                {
                    if (monster.IsCode(CardId.Ronintoadin, CardId.DupeFrog))
                    {
                        AI.SelectCard(monster);
                        return true;
                    }
                }
                foreach (ClientCard monster in hands)
                {
                    AI.SelectCard(monster);
                    return true;
                }
                return true;
            }
            else if (Card.Location == CardLocation.Grave)
            {
                if (!Bot.HasInExtra(CardId.ToadallyAwesome))
                {
                    AI.SelectCard(CardId.ToadallyAwesome);
                }
                else
                {
                    AI.SelectCard(
                        CardId.SwapFrog,
                        CardId.PriorOfTheIceBarrier,
                        CardId.GraydleSlimeJr
                        );
                }
                return true;
            }
            else if (Duel.Phase == DuelPhase.Standby)
            {
                SelectXYZDetach(Card.Overlays);
                if (Duel.Player == 0)
                {
                    AI.SelectNextCard(
                        CardId.SwapFrog,
                        CardId.CryomancerOfTheIceBarrier,
                        CardId.DewdarkOfTheIceBarrier,
                        CardId.Ronintoadin,
                        CardId.DupeFrog,
                        CardId.GraydleSlimeJr
                        );
                }
                else
                {
                    AI.SelectNextCard(
                        CardId.DupeFrog,
                        CardId.SwapFrog,
                        CardId.Ronintoadin,
                        CardId.GraydleSlimeJr,
                        CardId.CryomancerOfTheIceBarrier,
                        CardId.DewdarkOfTheIceBarrier
                        );
                    AI.SelectPosition(CardPosition.FaceUpDefence);
                }
                return true;
            }
            return true;
        }

        private bool CatSharkSummon()
        {
            if (Bot.HasInMonstersZone(CardId.ToadallyAwesome)
                && ((Util.IsOneEnemyBetter(true)
                    && !Bot.HasInMonstersZone(new[]
                        {
                            CardId.CatShark,
                            CardId.SkyCavalryCentaurea
                        }, true, true))
                    || !Bot.HasInExtra(CardId.ToadallyAwesome)))
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }

        private bool CatSharkEffect()
        {
            List<ClientCard> monsters = Bot.GetMonsters();
            foreach (ClientCard monster in monsters)
            {
                if (monster.IsCode(CardId.ToadallyAwesome) && monster.Attack <= 2200)
                {
                    SelectXYZDetach(Card.Overlays);
                    AI.SelectNextCard(monster);
                    return true;
                }
            }
            foreach (ClientCard monster in monsters)
            {
                if (monster.IsCode(CardId.SkyCavalryCentaurea) && monster.Attack <= 2000)
                {
                    SelectXYZDetach(Card.Overlays);
                    AI.SelectNextCard(monster);
                    return true;
                }
            }
            foreach (ClientCard monster in monsters)
            {
                if (monster.IsCode(CardId.DaigustoPhoenix) && monster.Attack <= 1500)
                {
                    SelectXYZDetach(Card.Overlays);
                    AI.SelectNextCard(monster);
                    return true;
                }
            }
            return false;
        }

        private bool SkyCavalryCentaureaSummon()
        {
            int num = 0;
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if (monster.Level ==2)
                {
                    num++;
                }
            }
            return Util.IsOneEnemyBetter(true)
                   && Util.GetBestAttack(Enemy) > 2200
                   && num < 4
                   && !Bot.HasInMonstersZone(new[]
                        {
                            CardId.SkyCavalryCentaurea
                        }, true, true);
        }

        private bool DaigustoPhoenixSummon()
        {
            if (Duel.Turn != 1)
            {
                int attack = 0;
                int defence = 0;
                foreach (ClientCard monster in Bot.GetMonsters())
                {
                    if (!monster.IsDefense())
                    {
                        attack += monster.Attack;
                    }
                }
                foreach (ClientCard monster in Enemy.GetMonsters())
                {
                    defence += monster.GetDefensePower();
                }
                if (attack - 2000 - defence > Enemy.LifePoints && !Util.IsOneEnemyBetter(true))
                    return true;
            }
            return false;
        }

        private bool HeraldOfTheArcLightSummon()
        {
            AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }

        private bool OtherSpellEffect()
        {
            if (Enemy.GetSpellCount()==0)
                return false;
            AI.SelectCard(Enemy.GetSpells());
            return Card.IsSpell() && Program.Rand.Next(9) >= 3 && DefaultDontChainMyself();
        }

        private bool OtherTrapEffect()
        {
            return Card.IsTrap() && Program.Rand.Next(9) >= 3 && DefaultTrap() && DefaultDontChainMyself();
        }

        private bool OtherMonsterEffect()
        {
            return Card.IsMonster() && Program.Rand.Next(9) >= 3 && DefaultDontChainMyself();
        }

        private void SelectXYZDetach(List<int> Overlays)
        {
            if (Overlays.Contains(CardId.GraydleSlimeJr) && Bot.HasInHand(CardId.GraydleSlimeJr) && !Bot.HasInGraveyard(CardId.GraydleSlimeJr))
                AI.SelectCard(CardId.GraydleSlimeJr);
            else if (Overlays.Contains(CardId.DupeFrog) && Bot.HasInGraveyard(CardId.Ronintoadin) && !Bot.HasInGraveyard(CardId.DupeFrog))
                AI.SelectCard(CardId.DupeFrog);
            else if (Overlays.Contains(CardId.Ronintoadin) && Bot.HasInGraveyard(CardId.DupeFrog) && !Bot.HasInGraveyard(CardId.Ronintoadin))
                AI.SelectCard(CardId.Ronintoadin);
            else
                AI.SelectCard(
                    CardId.GraydleSlimeJr,
                    CardId.Ronintoadin,
                    CardId.DupeFrog,
                    CardId.CryomancerOfTheIceBarrier,
                    CardId.DewdarkOfTheIceBarrier,
                    CardId.PriorOfTheIceBarrier,
                    CardId.SwapFrog
                    );
        }


        //ZexalWeaponsExecutor
        private bool Number39Utopia()
        {
            if (!Util.HasChainedTrap(0) && Duel.Player == 1 && Duel.Phase == DuelPhase.BattleStart && Card.HasXyzMaterial(2))
                return true;
            return false;
        }

        private bool Number61Volcasaurus()
        {
            return Util.IsOneEnemyBetterThanValue(2000, false);
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
            return ZwCount < 10;
        }

        private bool ReinforcementOfTheArmy()
        {
            AI.SelectCard(
                CardId.Goblindbergh,
                CardId.TinGoldfish,
                CardId.StarDrawing,
                CardId.Kagetokage,
                CardId.SacredCrane
                );
            return true;
        }

        private bool InstantFusion()
        {
            if (Bot.LifePoints <= 1000)
                return false;
            int count4 = 0;
            int count5 = 0;
            foreach (ClientCard card in Bot.GetMonsters())
            {
                if (card.Level == 5)
                    ++count5;
                if (card.Level == 4)
                    ++count4;
            }
            if (count5 == 1)
            {
                AI.SelectCard(CardId.FlameSwordsman);
                return true;
            }
            else if (count4 == 1)
            {
                AI.SelectCard(CardId.DarkfireDragon);
                return true;
            }
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

        private bool GoblindberghSummonFirst()
        {
            if (Bot.HasInHand(L4Tuners))
                return true;
            return false;
        }

        private bool GoblindberghEffect()
        {
            AI.SelectCard(
                CardId.SacredCrane,
                CardId.HeroicChallengerExtraSword,
                CardId.StarDrawing,
                CardId.SummonerMonk
                );
            return true;
        }

        private bool KagetokageEffect()
        {
            var lastChainCard = Util.GetLastChainCard();
            if (lastChainCard == null) return true;
            return !lastChainCard.IsCode(CardId.Goblindbergh, CardId.TinGoldfish);
        }

        private bool SummonerMonkEffect()
        {
            IList<int> costs = new[]
                {
                    CardId.XyzChangeTactics,
                    CardId.DarkHole,
                    CardId.MysticalSpaceTyphoon,
                    CardId.InstantFusion
                };
            if (Bot.HasInHand(costs))
            {
                AI.SelectCard(costs);
                AI.SelectNextCard(
                    CardId.SacredCrane,
                    CardId.StarDrawing,
                    CardId.Goblindbergh,
                    CardId.TinGoldfish
                    );
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }

        private bool SolarWindJammer()
        {
            if (!Bot.HasInHand(new[] {
                    CardId.StarDrawing,
                    CardId.InstantFusion
                }))
                return false;
            AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }


        //OldSchoolExecutor
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

        private bool SwordsOfRevealingLight()
        {
            foreach (ClientCard handCard in Enemy.GetMonsters())
            {
                if (handCard.IsFacedown())
                    return true;
            }
            return Util.IsOneEnemyBetter(true);
        }


        //Level8Executor
        private bool BeastOLionUsed = false;
        private bool JetSynchronUsed = false;
        private bool ScrapWyvernUsed = false;
        private bool MaskedChameleonUsed = false;
        private int ShootingRiserDragonCount = 0;

        private int[] HandCosts = new[]
        {
            CardId.PerformageTrickClown,
            CardId.JetSynchron,
            CardId.MechaPhantomBeastOLion,
            CardId.ScrapGolem,
            CardId.WorldCarrotweightChampion
        };

        private int[] L4NonTuners = new[]
        {
            CardId.PhotonThrasher,
            CardId.WorldCarrotweightChampion,
            CardId.PerformageTrickClown,
            CardId.Goblindbergh,
            CardId.WhiteRoseDragon
        };

        private int[] L4Tuners = new[]
        {
            CardId.RaidenHandofTheLightsworn,
            CardId.ScrapBeast,
            CardId.AngelTrumpeter,
            CardId.MaskedChameleon
        };


        private bool UnexpectedDaiFirst()
        {
            if (Bot.HasInHand(CardId.ScrapRecycler))
                return true;
            if (Bot.HasInHand(new[] {
                CardId.WorldCarrotweightChampion,
                CardId.PerformageTrickClown,
                CardId.Goblindbergh,
                CardId.WhiteRoseDragon
            }))
                return true;
            return false;
        }

        private bool PhotonThrasherSummonFirst()
        {
            if (Bot.HasInHand(CardId.ScrapRecycler))
                return true;
            if (Bot.HasInHand(L4Tuners))
                return true;
            return false;
        }

        private bool ReinforcementofTheArmyEffect()
        {
            if (Bot.GetMonsterCount() == 0 && PhotonThrasherSummonFirst() && !Bot.HasInHand(CardId.PhotonThrasher))
            {
                AI.SelectCard(CardId.PhotonThrasher);
                return true;
            }
            if (GoblindberghSummonFirst() && !Bot.HasInHand(CardId.Goblindbergh))
            {
                AI.SelectCard(CardId.Goblindbergh);
                return true;
            }
            AI.SelectCard(new[] {
                CardId.Goblindbergh,
                CardId.RaidenHandofTheLightsworn,
                CardId.PhotonThrasher
            });
            return true;
        }

        private bool ScrapRecyclerSummonFirst()
        {
            return Bot.GetRemainingCount(CardId.ScrapGolem, 2) > 0 && Bot.GetRemainingCount(CardId.MechaPhantomBeastOLion, 2) > 0 && Bot.GetRemainingCount(CardId.JetSynchron, 2) > 0;
        }

        private bool ScrapRecyclerEffect()
        {
            if ((Bot.HasInMonstersZone(CardId.ScrapGolem) && !JetSynchronUsed) || BeastOLionUsed)
            {
                AI.SelectCard(new[] { CardId.JetSynchron, CardId.MechaPhantomBeastOLion });
            }
            else
            {
                AI.SelectCard(new[] { CardId.MechaPhantomBeastOLion, CardId.JetSynchron });
            }
            return true;
        }

        private bool MechaPhantomBeastOLionEffect()
        {
            if (ActivateDescription == -1)
            {
                BeastOLionUsed = true;
                return true;
            }
            // todo: need tuner check
            return !BeastOLionUsed;
        }

        private bool ScrapWyvernSummon()
        {
            if (ScrapWyvernUsed || MaskedChameleonUsed || Bot.HasInMonstersZone(CardId.ScrapWyvern))
                return false;
            if (!Bot.HasInMonstersZone(new[] {
                CardId.ScrapBeast,
                CardId.ScrapGolem,
                CardId.ScrapRecycler,
            }) || !Bot.HasInMonstersZoneOrInGraveyard(CardId.ScrapRecycler))
                return false;

            AI.SelectMaterials(new[] {
                CardId.MechaPhantomBeastOLionToken,
                CardId.PhotonThrasher,
                CardId.Goblindbergh,
                CardId.AngelTrumpeter,
                CardId.PerformageTrickClown,
                CardId.WorldCarrotweightChampion,
                CardId.WhiteRoseDragon,
                CardId.ScrapBeast,
                CardId.ScrapGolem,
                CardId.ScrapRecycler
            });
            return true;
        }

        private bool ScrapWyvernEffect()
        {
            if(ActivateDescription != -1)
            {
                int[] targets = new[]
                {
                    CardId.ScrapRecycler,
                    CardId.ScrapBeast,
                    CardId.ScrapGolem,
                    CardId.ScrapDragon
                };
                AI.SelectCard(targets);
                AI.SelectNextCard(targets);
                ScrapWyvernUsed = true;
                return true;
            }
            else
            {
                AI.SelectCard(new[]
                {
                    CardId.ScrapGolem,
                    CardId.ScrapBeast
                });
                ClientCard target = Util.GetBestEnemyCard();
                if (target != null)
                    AI.SelectNextCard(target);
                else
                    AI.SelectNextCard(new[]
                    {
                        CardId.CalledbyTheGrave,
                        CardId.PhotonThrasher,
                        CardId.PerformageTrickClown,
                        CardId.MechaPhantomBeastOLionToken,
                        CardId.WorldCarrotweightChampion,
                        CardId.WhiteRoseDragon,
                        CardId.Goblindbergh,
                        CardId.AngelTrumpeter,
                        CardId.ScrapWyvern
                    });
                return true;
            }
        }

        private bool ScrapGolemEffect()
        {
            if (Bot.GetMonstersInMainZone().Count == 5)
                return false;
            AI.SelectCard(CardId.ScrapRecycler);
            AI.SelectOption(0);
            return true;
        }

        private bool JetSynchronEffect()
        {
            if (!Bot.HasInMonstersZone(CardId.BlackRoseMoonlightDragon)
                && Bot.MonsterZone.GetMatchingCardsCount(card => card.IsFaceup() && card.Level >= 2 && card.Level <= 5) < 2)
                return false;
            AI.SelectCard(HandCosts);
            return true;
        }

        private bool CrystronNeedlefiberSummon()
        {
            if (MaskedChameleonUsed)
                return false;
            int nonTunerCount = Bot.MonsterZone.GetMatchingCardsCount(card => card.IsFaceup() && !card.IsTuner());
            if (Bot.GetMonsterCount() < 3 || nonTunerCount == 0)
                return false;
            if (nonTunerCount == 1)
            {
                AI.SelectMaterials(new[] {
                    CardId.JetSynchron,
                    CardId.MechaPhantomBeastOLion,
                    CardId.AngelTrumpeter,
                    CardId.RaidenHandofTheLightsworn,
                    CardId.ScrapBeast,
                    CardId.MaskedChameleon,

                    CardId.PerformageTrickClown,
                    CardId.MechaPhantomBeastOLionToken,
                    CardId.ScrapRecycler,
                    CardId.WhiteRoseDragon,
                    CardId.PhotonThrasher,
                    CardId.Goblindbergh,
                    CardId.WorldCarrotweightChampion
                });
            }
            else
            {
                AI.SelectMaterials(new[] {
                    CardId.MechaPhantomBeastOLionToken,
                    CardId.ScrapRecycler,
                    CardId.WhiteRoseDragon,
                    CardId.PhotonThrasher,
                    CardId.Goblindbergh,
                    CardId.WorldCarrotweightChampion,
                    CardId.PerformageTrickClown,

                    CardId.JetSynchron,
                    CardId.MechaPhantomBeastOLion,
                    CardId.AngelTrumpeter,
                    CardId.RaidenHandofTheLightsworn,
                    CardId.ScrapBeast,
                    CardId.MaskedChameleon
                });
            }
            return true;
        }

        private bool CrystronNeedlefiberEffect()
        {
            if (Duel.Player == 0)
            {
                AI.SelectCard(CardId.RedRoseDragon);
                return true;
            }
            else
            {
                if (Bot.HasInExtra(CardId.ShootingRiserDragon) && Bot.MonsterZone.IsExistingMatchingCard(card => card.Level >= 3 && card.Level <= 5 && card.IsFaceup() && !card.IsTuner()))
                {
                    AI.SelectCard(CardId.ShootingRiserDragon);
                    return true;
                }
                if (Util.IsOneEnemyBetterThanValue(1500, true) || DefaultOnBecomeTarget())
                {
                    AI.SelectCard(CardId.CoralDragon);
                    return true;
                }
                return false;
            }
        }

        private bool MekkKnightCrusadiaAstramSummon()
        {
            int[] matcodes = new[] {
                CardId.ScrapWyvern,
                CardId.CrystronNeedlefiber
            };
            if (Bot.MonsterZone.GetMatchingCardsCount(card => card.IsCode(matcodes)) < 2)
                return false;
            AI.SelectMaterials(matcodes);
            return true;
        }

        private bool MekkKnightCrusadiaAstramEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                return true;
            }
            else
            {
                ClientCard target = Util.GetBestEnemyCard();
                if (target == null)
                    return false;
                AI.SelectCard(target);
                return true;
            }
        }

        private bool MaskedChameleonSummonFirst()
        {
            if (Bot.HasInGraveyard(new[] {
                CardId.PhotonThrasher,
                CardId.WorldCarrotweightChampion,
                CardId.Goblindbergh
            }))
                return true;
            return false;
        }

        private bool MaskedChameleonEffect()
        {
            if (Bot.MonsterZone.GetMatchingCardsCount(card => card.IsFaceup() && !card.IsTuner()) == 0)
            {
                MaskedChameleonUsed = true;
                AI.SelectCard(L4NonTuners);
                return true;
            }
            return false;
        }

        private bool WhiteRoseDragonSummonFirst()
        {
            if (Bot.HasInGraveyard(new[] {
                CardId.RedRoseDragon
            }))
                return true;
            return false;
        }

        private bool WhiteRoseDragonEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                if (Bot.GetRemainingCount(CardId.WorldCarrotweightChampion, 1) > 0)
                {
                    AI.SelectCard(CardId.WorldCarrotweightChampion);
                    return true;
                }
                return false;
            }
            return true;
        }

        private bool L4TunerSummonFirst()
        {
            return Bot.HasInMonstersZone(L4NonTuners, faceUp: true);
        }

        private bool L4NonTunerSummonFirst()
        {
            return Bot.HasInMonstersZone(L4Tuners, faceUp: true);
        }

        private bool OtherTunerSummonFirst()
        {
            return Bot.HasInMonstersZone(L4NonTuners, faceUp: true);
        }

        private bool PerformageTrickClownEffect()
        {
            if (Bot.LifePoints <= 1000)
                return false;
            AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }

        private bool WorldCarrotweightChampionEffect()
        {
            return !Bot.HasInMonstersZone(L4NonTuners);
        }

        private bool ScrapGolemSummon()
        {
            return Bot.GetMonsterCount() <= 2 && Bot.HasInMonstersZoneOrInGraveyard(CardId.ScrapRecycler);
        }

        private bool BorreloadSavageDragonSummon()
        {
            if (!Bot.HasInGraveyard(new[] {
                CardId.ScrapWyvern,
                CardId.CrystronNeedlefiber,
                CardId.MekkKnightCrusadiaAstram
            }))
                return false;
            return true;
        }

        private bool BorreloadSavageDragonEffect()
        {
            if (ActivateDescription == -1)
            {
                AI.SelectCard(new[] { CardId.MekkKnightCrusadiaAstram, CardId.CrystronNeedlefiber, CardId.ScrapWyvern });
                return true;
            }
            else
            {
                return true;
            }
        }

        private bool ScrapDragonSummon()
        {
            if (Util.GetProblematicEnemyCard(3000) != null)
            {
                return true;
            }
            if (Bot.HasInGraveyard(new[] { CardId.ScrapBeast, CardId.ScrapRecycler, CardId.ScrapGolem, CardId.ScrapWyvern }))
            {
                return true;
            }
            return false;
        }

        private bool ScrapDragonEffect()
        {
            ClientCard invincible = Util.GetProblematicEnemyCard(3000);
            if (invincible == null && !Util.IsOneEnemyBetterThanValue(2800 - 1, false))
                return false;

            List<ClientCard> monsters = Enemy.GetMonsters();
            monsters.Sort(CardContainer.CompareCardAttack);

            ClientCard destroyCard = invincible;
            if (destroyCard == null)
            {
                for (int i = monsters.Count - 1; i >= 0; --i)
                {
                    if (monsters[i].IsAttack())
                    {
                        destroyCard = monsters[i];
                        break;
                    }
                }
            }

            if (destroyCard == null)
                return false;

            AI.SelectCard(new[] {
                CardId.CalledbyTheGrave,
                CardId.MechaPhantomBeastOLionToken,
                CardId.ScrapRecycler,
                CardId.WhiteRoseDragon,
                CardId.PhotonThrasher,
                CardId.Goblindbergh,
                CardId.WorldCarrotweightChampion,
                CardId.PerformageTrickClown,
                CardId.JetSynchron,
                CardId.MechaPhantomBeastOLion,
                CardId.AngelTrumpeter,
                CardId.RaidenHandofTheLightsworn,
                CardId.ScrapBeast,
                CardId.MaskedChameleon
            });
            AI.SelectNextCard(destroyCard);

            return true;
        }

        private bool PSYFramelordOmegaEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                // todo
                return false;
            }
            if (Duel.Player == 0)
            {
                return DefaultOnBecomeTarget();
            }
            if (Duel.Player == 1)
            {
                if (Duel.Phase == DuelPhase.Standby)
                {
                    if (Bot.HasInBanished(CardId.JetSynchron) && !Bot.HasInGraveyard(CardId.JetSynchron))
                    {
                        AI.SelectCard(CardId.JetSynchron);
                        return true;
                    }
                    if (Bot.HasInBanished(CardId.CrystronNeedlefiber))
                    {
                        AI.SelectCard(CardId.CrystronNeedlefiber);
                        return true;
                    }
                }
                else
                {
                    if (Enemy.MonsterZone.GetMatchingCards(card => card.IsAttack()).Sum(card => card.Attack) >= Bot.LifePoints)
                        return false;
                    return true;// DefaultOnBecomeTarget() || Util.IsOneEnemyBetterThanValue(2800, true);
                }
            }
            return false;
        }

        private bool CoralDragonEffect()
        {
            if (Card.Location == CardLocation.Grave)
                return true;

            ClientCard target = Util.GetProblematicEnemyCard(canBeTarget: true);
            if (target != null)
            {
                AI.SelectCard(HandCosts);
                AI.SelectNextCard(target);
                return true;
            }
            return false;
        }

        private bool ShootingRiserDragonSummon()
        {
            return Bot.MonsterZone.GetMatchingCardsCount(card => card.IsFaceup() && !card.IsTuner()) >= 2;
        }

        private bool ShootingRiserDragonEffect()
        {
            if (ActivateDescription == -1 || (ActivateDescription == Util.GetStringId(CardId.ShootingRiserDragon, 0)))
            {
                int targetLevel = 8;

                if (Bot.MonsterZone.IsExistingMatchingCard(card => card.Level == targetLevel - 5 && card.IsFaceup() && !card.IsTuner()) && Bot.GetRemainingCount(CardId.MechaPhantomBeastOLion, 2) > 0)
                {
                    AI.SelectCard(CardId.MechaPhantomBeastOLion);
                }
                else if (Bot.MonsterZone.IsExistingMatchingCard(card => card.Level == targetLevel - 4 && card.IsFaceup() && !card.IsTuner()))
                {
                    AI.SelectCard(new[] {
                        CardId.ScrapRecycler,
                        CardId.RedRoseDragon
                    });
                }
                else if (Bot.MonsterZone.IsExistingMatchingCard(card => card.Level == targetLevel - 3 && card.IsFaceup() && !card.IsTuner()))
                {
                    AI.SelectCard(new[] {
                        CardId.ScrapBeast,
                        CardId.PhotonThrasher,
                        CardId.Goblindbergh,
                        CardId.WorldCarrotweightChampion,
                        CardId.WhiteRoseDragon,
                        CardId.RaidenHandofTheLightsworn,
                        CardId.AngelTrumpeter,
                        CardId.PerformageTrickClown,
                        CardId.MaskedChameleon
                    });
                }
                else
                {
                    FoolishBurialEffect();
                }
                return true;
            }
            else
            {
                if (Duel.LastChainPlayer == 0 || ShootingRiserDragonCount >= 10)
                    return false;
                ShootingRiserDragonCount++;
                AI.SelectCard(new[] {
                    CardId.BlackRoseMoonlightDragon,
                    CardId.ScrapDragon,
                    CardId.PSYFramelordOmega
                });
                return true;
            }
        }

        private bool Number41BagooskaTheTerriblyTiredTapirSummon()
        {
            if (!Util.IsTurn1OrMain2())
                return false;
            if (Bot.GetMonsterCount() > 3)
                return false;
            AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }

        private bool JustDontIt()
        {
            return false;
        }
    }
}
