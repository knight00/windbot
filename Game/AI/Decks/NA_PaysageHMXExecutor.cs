using YGOSharp.OCGWrapper.Enums;
using System.Linq;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
using System.Reflection.Emit;
using System.Web.UI;

namespace WindBot.Game.AI.Decks
{
    [Deck("HMX", "AI_HMX")]
    public class PaysageHMXExecutor : DefaultExecutor
    {
        public class CardId
        {
            //怪兽卡
            public const int Little_Bunny = 30300;
            public const int SWRemilia = 1231300;
            public const int SWPatchouli = 1231000;
            public const int SWMeilin = 1230900;
            public const int SWSakuya = 1231100;
            public const int RDFlandre = 60700;
            public const int SWIku = 1230700;
            public const int RDMaid = 60002;
            public const int RDKoakuma = 60300;
            public const int Kijin_Seija = 140700;
            public const int Rumia = 60100;

            public const int AshBlossom = 14558127;

            //魔法卡
            public const int Wind = 1230810;
            public const int Red_Magic = 60612;
            public const int Past_Clock = 60712;
            public const int Ten_Judge = 90512;
            public const int RDMatch = 1239999;
            public const int RDHouse = 60000;
            public const int ScarletWeather = 1230000;
            public const int Mist_Lake = 1280001;
            public const int NAMERedDevil = 60001;
            public const int FumiTsuki = 60310; 
            //陷阱卡
            public const int Scarlet_Seance = 60613;
            public const int Cranberry_Trap = 60710;
            public const int Scarlet_Destiny = 60610;
            public const int Scarlet_Overlay = 60614;
            public const int Scarlet_Gensokyo = 60615;
            public const int FoK = 60711;
            public const int Fever = 110210;
            //假卡堆
            public const int KandS_Girl = 60401;
            public const int SynRenko = 900100;
            public const int Rikako = 30500;
            public const int WSynRan = 70701; 
            public const int ForbiddenWave = 60701;
            public const int BigEye = 80117527;
            public const int ReiKo = 140501;
            public const int Erin = 80601;
            public const int MKII = 547041;
            public const int SL_Sakuya = 99610002;
            public const int SL_Marisa = 99610009;
            public const int SL_Reimu = 99610012;
            public const int SL_Remilia = 99610005;
        }
        bool FirstP = false; //灵摆的头次效果不康
        bool Summoned = false;
        bool ESummoned = false;
        bool PaoChed = false; 
        bool RDHoused = false;
        bool RDMaided = false;
        bool Flandred = false;
        bool Meilined = false;
        bool Sakuyaed = false;
        bool Sakuyaed_2 = false;
        bool Patchoulied = false;
        bool Destinyed = false;
        bool Red_Magiced = false;
        bool Patchoulied_2 = false;
        bool NAMERedDeviled = false;
        bool NAMERedDeviled2 = false;
        bool Ikued = false;
        bool SWed = false;
        bool SWed2 = false;
        bool Destinying = false;
        bool KoakumaedSummoned = false;
        int Scarlet_DestinyCount = 2;
        int SWRemiliaCount = 2; 
        bool Koakumaed2 = false;
        bool RDMChainningX = false;
        bool DoNotChain = false;
        public PaysageHMXExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        { 
            AddExecutor(ExecutorType.GoToEndPhase, GoToBattlePhase);  //天才啊！天才啊！2021年12月30日01:49:50

            AddExecutor(ExecutorType.Activate, CardId.AshBlossom, Little_BunnyEffect);
            AddExecutor(ExecutorType.Activate, CardId.SL_Marisa); 
            AddExecutor(ExecutorType.Activate, CardId.Scarlet_Overlay, Scarlet_OverlayEffect);
            AddExecutor(ExecutorType.Activate, CardId.Ten_Judge, Ten_JudgeEffect);
            AddExecutor(ExecutorType.Activate, CardId.Rumia, RumiaEffect);
            AddExecutor(ExecutorType.Activate, CardId.FumiTsuki, FumiTsukiEffect);

            //压制
            AddExecutor(ExecutorType.Activate, CardId.Little_Bunny, Little_BunnyEffect);
            AddExecutor(ExecutorType.SpSummon, CardId.SL_Reimu, SL_ReimuSpSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.KandS_Girl, KandS_GirlSpSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.SL_Marisa, SLMarisaSpSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.SL_Sakuya, SL_SakuyaSpSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.WSynRan, KandS_GirlSpSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Rikako, RikakoSpSummon);
            AddExecutor(ExecutorType.Activate, CardId.Rikako, RikakoEffect);
            AddExecutor(ExecutorType.SpSummon, CardId.MKII, MKIISummon);
            AddExecutor(ExecutorType.SpSummon, CardId.SL_Remilia, SL_RemiliaSpSummon);
            AddExecutor(ExecutorType.Activate, CardId.SL_Remilia, SL_RemiliaEffect); 
            AddExecutor(ExecutorType.Activate, CardId.ReiKo, ReiKoEffect);
            AddExecutor(ExecutorType.SpSummon, CardId.ReiKo, ReiKoSpSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.ForbiddenWave, ForbiddenWaveSpSummon);
            AddExecutor(ExecutorType.Activate, CardId.SL_Reimu, SL_ReimuEffect);

            //环境准备，先清场
            AddExecutor(ExecutorType.Activate, CardId.Scarlet_Gensokyo, Scarlet_GensokyoEffect);
            AddExecutor(ExecutorType.Activate, CardId.Cranberry_Trap, Cranberry_TrapEffect);
            AddExecutor(ExecutorType.Activate, CardId.NAMERedDevil, NAMERedDevilEffect);
            AddExecutor(ExecutorType.Activate, CardId.Scarlet_Destiny, Scarlet_DestinyEffect);

            //红魔名的效果，好麻烦啊……
            AddExecutor(ExecutorType.Activate, CardId.SWRemilia, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.SWPatchouli, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.SWMeilin, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.SWSakuya, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.SWIku, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.RDMaid, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.RDKoakuma, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.RDFlandre, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.Rumia, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.KandS_Girl, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.SynRenko, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.Rikako, NAMERedDevilEffect2); 
            AddExecutor(ExecutorType.Activate, CardId.ForbiddenWave, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.Erin, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.ReiKo, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.MKII, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.SL_Remilia, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.SL_Reimu, NAMERedDevilEffect2);
            AddExecutor(ExecutorType.Activate, CardId.AshBlossom, NAMERedDevilEffect2);

            //检索，初动类先处理
            AddExecutor(ExecutorType.Activate, CardId.SWRemilia, SWRemiliaEffect);
            AddExecutor(ExecutorType.Summon, CardId.RDKoakuma, RDKoakumaSummon);
            AddExecutor(ExecutorType.Summon, CardId.RDMaid, RDMaidSummon);
            AddExecutor(ExecutorType.Activate, CardId.RDHouse, RDHouseEffect);
            AddExecutor(ExecutorType.Activate, CardId.Fever, FeverEffect);

            //展开类处理
            AddExecutor(ExecutorType.Activate, CardId.RDKoakuma, RDKoakumaEffect);
            AddExecutor(ExecutorType.Activate, CardId.RDMaid, RDMaidEffect);
            AddExecutor(ExecutorType.Activate, CardId.RDMatch, RDMatchEffect);
            AddExecutor(ExecutorType.Activate, CardId.SWPatchouli, SWPatchouliEffect);
            AddExecutor(ExecutorType.Activate, CardId.Red_Magic, Red_MagicEffect);
            AddExecutor(ExecutorType.Summon, CardId.SWSakuya, SWSakuyaSummon);
            AddExecutor(ExecutorType.Activate, CardId.ScarletWeather, ScarletWeatherEffect);
            //铺场 
            AddExecutor(ExecutorType.Activate, CardId.RDMatch, RDMatchEffect2);
            AddExecutor(ExecutorType.Activate, CardId.SWSakuya, SWSakuyaEffect);
            AddExecutor(ExecutorType.Activate, CardId.SWMeilin, SWMeilinEffect);
            AddExecutor(ExecutorType.Activate, CardId.FoK, FoKEffect);
            AddExecutor(ExecutorType.Summon, CardId.SWMeilin, SWSakuyaSummon);
            AddExecutor(ExecutorType.Summon, CardId.RDFlandre, SWSakuyaSummon);
            AddExecutor(ExecutorType.Summon, CardId.SWPatchouli, SWSakuyaSummon);
            //AddExecutor(ExecutorType.Summon, CardId.Rumia, RumiaSummon);
            //AddExecutor(ExecutorType.SpSummon, CardId.UNIV, UNIVSpSummon);  
            AddExecutor(ExecutorType.Activate, CardId.KandS_Girl, KandS_GirlEffect);
            AddExecutor(ExecutorType.Activate, CardId.RDFlandre, RDFlandreEffect);
            AddExecutor(ExecutorType.Activate, CardId.SL_Sakuya, SL_SakuyaEffect);

            //再展开
            AddExecutor(ExecutorType.Activate, CardId.Scarlet_Seance, Scarlet_SeanceEffect);
            AddExecutor(ExecutorType.Activate, CardId.MKII, MKIIEffect);

            AddExecutor(ExecutorType.Activate, CardId.WSynRan, WSynRanEffect);
            AddExecutor(ExecutorType.Activate, CardId.Scarlet_Destiny, Scarlet_DestinyEffect2);
            AddExecutor(ExecutorType.Activate, CardId.Scarlet_Destiny, Scarlet_DestinyEffect3);
            AddExecutor(ExecutorType.SpellSet, CardId.Scarlet_Destiny, Scarlet_Set);
            AddExecutor(ExecutorType.SpellSet, CardId.Scarlet_Gensokyo, Scarlet_Set);
            AddExecutor(ExecutorType.SpellSet, CardId.Cranberry_Trap);
            AddExecutor(ExecutorType.SpellSet, CardId.FoK, Scarlet_Set);
            AddExecutor(ExecutorType.SpellSet, CardId.Red_Magic, Scarlet_Set);
            AddExecutor(ExecutorType.SpellSet, CardId.Scarlet_Seance, Scarlet_Set);
            AddExecutor(ExecutorType.SpellSet, CardId.Fever);
            AddExecutor(ExecutorType.Summon, CardId.AshBlossom, AshBlossomSummon);
            //盖卡

        }
        public override bool OnSelectHand()
        {
            // go first
            return true; 
        }
        public override CardPosition OnSelectPosition(int cardId, IList<CardPosition> positions)
        {
            if (cardId == CardId.SWPatchouli) return CardPosition.FaceUpDefence;
            return CardPosition.Attack;
        }

        public override int OnSelectOption(IList<long> options)
        {
            Logger.DebugWriteLine("进入了Option选择");
            if (SWSakuyaSummonDummy())
            {
                for (int i = 0; i < options.Count; i = i + 1) { if (options[i] == Util.GetStringId(CardId.RDMaid, 0)) return i; }
                for (int i = 0; i < options.Count; i = i + 1) { if (options[i] == Util.GetStringId(CardId.SWMeilin, 0)) return i; }
                for (int i = 0; i < options.Count; i = i + 1) { if (options[i] == Util.GetStringId(CardId.SWSakuya, 0)) return i; }
                for (int i = 0; i < options.Count; i = i + 1) { if (options[i] == Util.GetStringId(CardId.SWPatchouli, 0)) return i; }
                for (int i = 0; i < options.Count; i = i + 1) { if (options[i] == Util.GetStringId(CardId.RDFlandre, 0)) return i; }
            }
            return options.Count == 2 ? 1 : 0; 
        }
        public override int OnSelectPlace(long cardId, int player, CardLocation location, int available)
        { 
            if ((cardId != CardId.KandS_Girl) && (cardId != CardId.SynRenko) && (cardId != CardId.WSynRan) 
                  && (cardId != CardId.ForbiddenWave) && (cardId != CardId.BigEye) && (cardId != CardId.ReiKo) && (cardId != CardId.Erin) && (cardId != CardId.MKII))
            {
                //int place = SelectZoneWithoutPachi();
                if (cardId == CardId.RDMaid && !RDMaided)
                { 
                    if ((GetCountInDeck(CardId.SWSakuya, 2) > 0) && (IfFlandre(false, true) < IfSakuya())) { return (int)(System.Math.Pow(2, SakuyaShouldinThisSeq())); }
                    if (GetCountInDeck(CardId.SWRemilia, SWRemiliaCount) > 0
                        && (Bot.HasInHand(CardId.Scarlet_Seance) && (GetRDMCountInMZone() == Bot.GetMonsterCount()) || (Bot.HasInHandOrInSpellZone(CardId.RDMatch) && GetDestroyCountInHand() > 0)))
                    { return (int)(System.Math.Pow(2, FlandreShouldinThisSeq())); }
                    if (GetCountInDeck(CardId.SWMeilin, 2) > 0 && IfFlandre(false, true) > 3) { return (int)(System.Math.Pow(2, FlandreShouldinThisSeq(false, true))); }
                    if (GetCountInDeck(CardId.RDFlandre, 2) > 0 && IfFlandre(false, false) > 3) { return (int)(System.Math.Pow(2, FlandreShouldinThisSeq(false, false))); }
                }
                if (cardId == CardId.SWSakuya) { return (int)(System.Math.Pow(2, SakuyaShouldinThisSeq())); }
                if (cardId == CardId.RDMatch || (cardId == CardId.Cranberry_Trap)) { return (int)(System.Math.Pow(2, RDMatchShouldinThisSeq())); }
                if ((cardId == CardId.RDFlandre) || (cardId == CardId.Past_Clock) || (cardId == CardId.Cranberry_Trap) || (cardId == CardId.FoK)) 
                    { return (int)(System.Math.Pow(2, FlandreShouldinThisSeq())); }
                if (cardId == CardId.SWMeilin) { return (int)(System.Math.Pow(2, FlandreShouldinThisSeq(false, true))); }
                if (cardId == CardId.SWPatchouli) { return (int)(System.Math.Pow(2, FlandreShouldinThisSeq(true, false))); }
                if (cardId == CardId.RDKoakuma)
                {
                    for (int i = 0; i < 5; ++i)
                    {
                        if (Enemy.MonsterZone[4 - i] != null && !ThisSeqHasPachi(i) && Enemy.MonsterZone[4 - i].Attack <= 1000) { return (int)System.Math.Pow(2, i); } 
                    } 
                    for (int i = 0; i < 5; ++i){ if (Enemy.MonsterZone[4 - i] == null && !ThisSeqHasPachi(i)) { return (int)System.Math.Pow(2, i); } }
                }
            }
            if ((cardId != CardId.Wind) && (cardId != CardId.Red_Magic) && (cardId != CardId.Ten_Judge) && (cardId != CardId.RDMatch)
                && (cardId != CardId.Scarlet_Seance) && (cardId != CardId.Cranberry_Trap) && (cardId != CardId.Scarlet_Destiny) 
                    && (cardId != CardId.Scarlet_Overlay) && (cardId != CardId.Scarlet_Gensokyo))
            {
                if (Bot.HasInHand(CardId.NAMERedDevil) && !NAMERedDeviled && (GetCountInDeck(CardId.SWMeilin, 2) > 0) && !NAMERedDeviled2)
                {
                    for (int i = 0; i < 5; ++i)
                    { 
                        if ((FlandreInt(i, false, true) > 1) && !ThisSeqHasPachi(i) && Bot.MonsterZone[i] == null) { return (int)System.Math.Pow(2, i); }
                    }
                }
                for (int i = 0; i < 5; ++i)
                { 
                    if (Bot.SpellZone[i] == null && !ThisSeqHasPachi(i) && Bot.MonsterZone[i] == null) { return (int)System.Math.Pow(2, i); } 
                }
            }
            for (int i = 0; i < 5; ++i)
            {
                //Logger.DebugWriteLine("选择区域测试 " + i + " " + ThisSeqHasPachi(i));
                if (!ThisSeqHasPachi(i) && Bot.SpellZone[i] == null) { return (int)System.Math.Pow(2, i); }

            }
            return base.OnSelectPlace(cardId, player, location, available);
        }
        public override IList<ClientCard> OnSelectCard(IList<ClientCard> cards, int min, int max, long hint, bool cancelable)
        {
            if (hint == Util.GetStringId(CardId.RDKoakuma, 3))
            {
                foreach (ClientCard card in cards) { if (card.IsCode(CardId.SL_Reimu)) { return new List<ClientCard>(new[] { card }); } }
                foreach (ClientCard card in cards) { if (card.IsCode(CardId.WSynRan)) { return new List<ClientCard>(new[] { card }); } }
                foreach (ClientCard card in cards) { if (card.IsCode(CardId.SL_Marisa)) { return new List<ClientCard>(new[] { card }); } }
            }
            if (hint == Util.GetStringId(CardId.RDMaid, 2) || hint == Util.GetStringId(CardId.Rikako, 3))
            {
                if(Bot.HasInMonstersZone(CardId.ReiKo, true, true, true))
                {
                    foreach (ClientCard card in cards) { if (card.IsCode(CardId.ForbiddenWave)) { return new List<ClientCard>(new[] { card }); } }
                }
                foreach (ClientCard card in cards) { if (card.IsCode(CardId.ReiKo)) { return new List<ClientCard>(new[] { card }); } } 
                foreach (ClientCard card in cards) { if (card.IsCode(CardId.ForbiddenWave)) { return new List<ClientCard>(new[] { card }); } }
            }
            return base.OnSelectCard(cards, min, max, hint, cancelable);
        } 
        public override void OnNewTurn()
        {
            Summoned = false; //是否已经召唤过了
            ESummoned = false; //是否发动过了小恶魔的②效果导致可以再度召唤 并且再度召唤了
            PaoChed = false; 
            RDMaided = false;
            Flandred = false;
            Meilined = false;
            RDHoused = false;
            Sakuyaed = false;
            Sakuyaed_2 = false;
            Patchoulied = false;
            Patchoulied_2 = false;
            Destinyed = false;
            NAMERedDeviled = false;
            NAMERedDeviled2 = false;
            Red_Magiced = false;
            Ikued = false;
            SWed = false;
            SWed2 = false; 
            KoakumaedSummoned = false;  //是否通招过小恶魔
            Koakumaed2 = false;  //是否发动过了小恶魔的②效果导致可以再度召唤（目前此值无实际效果） 
            FirstP = false;
            Destinying = false;
            base.OnNewTurn();
        }
        public override void OnChainEnd()
        {
            Destinying = false;
            RDMChainningX = false;
            Logger.DebugWriteLine("结束了Chaining");
            base.OnChainEnd();
        }
        public override bool OnSelectYesNo(long desc)
        {
            Logger.DebugWriteLine("进入了是否选择");
            if (desc == Util.GetStringId(130401, 1))
            {
                return false;
            }
            if (desc == Util.GetStringId(130402, 1))
            {
                return false;
            }
            return base.OnSelectYesNo(desc);
        }
        public override void OnChaining(int player, ClientCard card) //card 是正在发效的那张卡
        {
            Logger.DebugWriteLine("进入了Chaining");
            base.OnChaining(player, card);
        }
        //
        //以上为基操类
        //

        private int GetScarletWeatherValue(int loc = 1)//1表示手卡 0是卡组  2是场上
        {
            int value = 7;
            if (loc == 1)
            {
                return value;
            }
            if (loc == 0)
            {
                value += 9;
                if (Bot.HasInMonstersZone(CardId.SWIku, true, false, true)) value += 3;
                if (GetCountInDeck(CardId.ScarletWeather, 1) == 0) value = 0;
                return value;
            }
            return value;
        }
        private int GetRed_MagicValue(int loc = 1)//1表示手卡
        {
            int value = 15;
            if (loc == 1)
            {
                if ((Bot.GetCountCardInZone(Bot.Hand, CardId.Red_Magic) > 1) || Red_Magiced) value -= 7;
                return value;
            }
            return value;
        }
        private int GetKijin_SeijaValue(int loc = 1)//1表示手卡
        {
            int value = 11;
            return value;
        }
        private int GetLittle_BunnyValue(int loc = 1)//1表示手卡
        {
            int value = 12;
            return value;
        }
        private int GetScarlet_OverlayValue(int loc = 1)//1表示手卡
        {
            int value = 3;
            return value;
        }

        private int GetScarlet_SeanceValue(int loc = 1)//1表示手卡
        {
            int value = 6;
            if (loc == 1)
            {
                if (IfScarlet()) value += 4;
                if (GetRDMCountInHand() > 0) value += 1;
                if (GetRDMCountInGrave() > 0) value += 3;
                return value;
            }
            return value;
        }
        private int GetScarlet_DestinyValue(int loc = 1, bool des = true, int Which = 0, ClientCard card = null)//1表示手卡
        {
            int value = 9;
            if (loc == 2)
            {
                if (card.IsFacedown() || card.IsDisabled()) value -= 4;
                if (Util.IsChainTarget(card) && Duel.LastChainPlayer != 0) value -= 8;
                return value;
            }
            return value;
        }
        private int GetKoakumaValue(int loc = 1, bool des = true, int Which = 0, ClientCard card = null)//1表示手卡 ,des是表示考虑炸卡的情况
        {
            int value = 9;
            if (loc == 0)
            {
                if (Duel.Player == 1) value -= 4;
                if (!Summoned && (Duel.Player == 0) && (GetRDMCountInHand(true, true) > 0 || Bot.HasInHand(CardId.RDMaid))) value += 3;
                if (GetCountInDeck(CardId.RDKoakuma) == 0) value = 0;
                return value;
            }
            if (loc == 2)
            {
                value -= 3;
                if (Util.IsChainTarget(card) && Duel.LastChainPlayer != 0) value -= 8;
                return value;
            }
            return value;
        }
        //
        public bool ChainContainsCardByPlayer(int id, int player = 0)
        {
            return Duel.CurrentChain.Any(card => card.IsCode(id) && (card.Controller == player));
        }
        public bool ChainContainsCard3ByPlayer(int id, int player = 0, CardLocation loc = CardLocation.MonsterZone)
        {
            return Duel.CurrentChain.Any(card => card.IsCode(id) && (card.Controller == player) && (card.Location == loc));
        }
        public bool ChainContainsCard2ByPlayer(ClientCard card2, int player = 0)
        {
            return Duel.CurrentChain.Any(card => card.Equals(card2) && (card.Controller == player));
        }
        //
        private int GetRedMatchValue(int loc = 1, bool des = true, int Which = 0, ClientCard card = null)
        {
            int value = 11;
            if (loc == 1)
            {
                if (GetRDMCountInHand() == 0) value -= 4;
                if ((Bot.HasInHand(CardId.ScarletWeather) || (Bot.HasInSpellZone(CardId.ScarletWeather, true, true) && !SWed))) value += 2;
                if (GetRDMCountInGrave() == 0) value -= 4;
                return value;
            }
            if (loc == 2)
            {
                //炮车同一纵列有卡的场合，炮车价值降低 还有做好。
                int value_2 = value;
                if (PaoChed || (GetRDMCountInHand(false, true) == 0)) value -= 3;
                if (des && (GetRDMCountInGrave() > 0)) value -= 4;
                if (Which != 0)
                {
                    foreach (ClientCard card2 in Bot.GetSpells())
                    {
                        if (card2.IsCode(CardId.RDMatch))
                        {
                            if (((card2.IsFacedown() && !des) || card2.IsDisabled())) value_2 -= 6;
                            if (ChainContainsCard2ByPlayer(card2)) value_2 += 10;
                            if ((Which == 1) && (value_2 < value)) value = value_2;
                            if ((Which == 2) && (value_2 > value)) value = value_2;
                        }
                    }
                    return value;
                }
                if (card != null)
                {
                    if (card.IsFacedown() || card.IsDisabled()) value -= 6;
                    if (Util.IsChainTarget(card) && Duel.LastChainPlayer != 0) value -= 8;
                    if (ChainContainsCard2ByPlayer(card)) value += 10;
                }
                //Logger.DebugWriteLine("炮车测试2 " + value);
                return value;
            }
            return value;
        }

        private int GetFlandreValue(int loc = 1, bool des = false, int Which = 0, ClientCard Card = null)
        {
            int value = 10;
            if (loc == 1)
            {
                value -= 2;
                if (Flandred) value -= 6;
                return value;
            }
            if (loc == 0)
            {
                value = 8;
                if (Bot.HasInHand(CardId.Cranberry_Trap) && !Flandred && !Bot.HasInHand(CardId.RDFlandre) && IfScarlet()) value += 5;//
                if (!Flandred && !Bot.HasInHand(CardId.RDFlandre) && (GetDestroyCountInMZone() != 0)) value += 3;
                if (GetCountInDeck(CardId.RDFlandre, 1) == 0) value = 0;
                return value;
            }
            if (loc == 2)
            {
                value = 8;
                if (Which != 0)
                {
                    int value_2 = value;
                    foreach (ClientCard card2 in Bot.GetMonsters())
                    {
                        if (((card2.IsFacedown() && !des) || card2.IsDisabled()) && card2.IsCode(CardId.RDFlandre) && card2.IsSpecialSummoned) value_2 -= 5;
                        if (!card2.IsSpecialSummoned && !des) value_2 += 10;
                        if ((Which == 1) && (value_2 < value)) value = value_2;
                        if ((Which == 2) && (value_2 > value)) value = value_2;
                    }
                    return value;
                }
                if ((Card.IsFacedown() || Card.IsDisabled()) && Card.IsSpecialSummoned) value -= 5;
                if (!Card.IsSpecialSummoned && des) value -= 5;
                if (!Card.IsSpecialSummoned && !des) value += 4;
                if (Util.IsChainTarget(Card) && Duel.LastChainPlayer != 0) value -= 8;
                return value;
            }
            return value;
        }

        private int GetFoKValue(int loc = 1, bool des = false, int Which = 0, ClientCard Card = null)//1表示手卡
        {
            int value = 8;
            if (loc == 1)
            {
                if (IfScarlet()) value += 6;
                return value;
            }
            if (loc == 2)
            {
                value -= 2;
                if (Which != 0)
                {
                    int value_2 = value;
                    foreach (ClientCard card2 in Bot.GetMonsters())
                    {
                        if (((card2.IsFacedown() && !des) || card2.IsDisabled()) && card2.IsCode(CardId.FoK)) value_2 -= 2;
                        if ((Which == 1) && (value_2 < value)) value = value_2;
                        if ((Which == 2) && (value_2 > value)) value = value_2;
                    }
                    return value;
                }
                if (Card != null && (Card.IsFacedown() || Card.IsDisabled())) value -= 2;
                if (Util.IsChainTarget(Card) && Duel.LastChainPlayer != 0) value -= 8;
                if (Util.ChainContainsCard(CardId.FoK)) value += 11;
                return value;
            }
            return value;
        }

        private int GetNAMERedDevilValue(int loc = 1, bool des = false, int Which = 0, ClientCard Card = null)//1表示手卡
        {
            int value = 11;
            if (loc == 2)
            {
                if (NAMERedDeviled2) value -= 9;
            }
            return value;
        }
        private int GetForbiddenWaveValue(int loc = 1, bool des = false, int Which = 0, ClientCard Card = null)//1表示手卡
        {
            int value = 15;
            if (loc == 2)
            {
                int count = Enemy.GetSpellCount() + Enemy.GetMonsterCount();
                if (des) value -= 2 * count;
                if (Util.IsChainTarget(Card) && Duel.LastChainPlayer != 0) value -= 8;
                return value;
            }
            return value;
        }

        private int GetSWRemiliaValue(int loc = 1, bool des = false, int Which = 0, ClientCard Card = null)//1表示手卡
        {
            int value = 9;

            if (loc == 1)
            {
                return 1;
            }
            if (loc == 2)
            {
                if (Util.IsChainTarget(Card) && Duel.LastChainPlayer != 0) { Logger.DebugWriteLine("测试X " + Duel.LastChainPlayer); value -= 8; }
                return value;
            }
            return value;
        }

        private int GetRikakoValue(int loc = 1, bool des = false, int Which = 0, ClientCard Card = null)//1表示手卡
        {
            int value = 12;
            return value;
        } 
        private int GetSWMeilinValue(int loc = 1, bool des = false, int Which = 0, ClientCard Card = null)//1表示手卡
        {
            int value = 9;
            if (!Meilined && (loc != 2))
            {
                bool boa = Bot.HasInHand(CardId.SWSakuya) && !Sakuyaed && !Sakuyaed_2 && IfBotCanSpSummon();
                bool bob = Bot.HasInHand(CardId.RDMaid) && !Summoned && !RDMaided;
                if ((GetDestroyCountInMZone() > 0 || CanSpSummon()) && ((IfFlandre(false, true) > 2) || boa || bob)) value += 3;
                if ((GetDestroyCountInMZone() > 0 || CanSpSummon()) && (IfFlandre(false, true) > 5)) value += 4;
                //
            }
            if (loc == 0)
            {
                if (GetCountInDeck(CardId.SWMeilin, 2) == 0) value = 0;
                value += IfFlandre(false, true);
                return value;

            }
            if (loc == 2)
            {
                if (Which != 0)
                {
                    int value_2 = value;
                    foreach (ClientCard card2 in Bot.GetMonsters())
                    {
                        if (ChainContainsCard2ByPlayer(card2) && card2.IsCode(CardId.SWMeilin))
                        {
                            value_2 += 5;
                            int seq = card2.Sequence;
                            if (FlandreInt(seq, false, true) > 0) value_2 += 5;
                        }
                        if (((card2.IsFacedown() && !des) || card2.IsDisabled()) && card2.IsCode(CardId.SWMeilin) && !card2.IsSpecialSummoned && !des) value_2 -= 6;
                        if (!card2.IsSpecialSummoned && des && card2.IsCode(CardId.SWMeilin)) value_2 -= 6;
                        if (!card2.IsSpecialSummoned && !des && card2.IsCode(CardId.SWMeilin)) value_2 += 4;
                        if ((Which == 1) && (value_2 < value)) value = value_2;
                        if ((Which == 2) && (value_2 > value)) value = value_2;
                    }
                    return value;
                }
                if (ChainContainsCard2ByPlayer(Card) && Card.IsCode(CardId.SWMeilin) && (FlandreInt(Card.Sequence, false, true) > 0)) value += 5;
                if (Card != null && (Card.IsFacedown() || Card.IsDisabled()) && !Card.IsSpecialSummoned && !des) value -= 6;
                if (Util.IsChainTarget(Card) && Duel.LastChainPlayer != 0) value -= 8;
                if (!Card.IsSpecialSummoned && des) value -= 5;
                if (!Card.IsSpecialSummoned && !des) value += 4;
                return value;
            }
            return value;
        }

        private int GetSWSakuyaValue(int loc = 1, bool des = false, int Which = 0, ClientCard Card = null)//1表示手卡
        {
            int value = 9;
            if (!Sakuyaed && !Sakuyaed_2 && (loc != 2))
            {
                value += 2;
                if ((GetDestroyCountInMZone() > 0 || CanSpSummon()) && (IfSakuya() > 3)) value += 2;
                if ((GetDestroyCountInMZone() > 0 || CanSpSummon()) && (IfSakuya() > 5)) value += 2;
            }
            if (loc == 0)
            {
                if (GetCountInDeck(CardId.SWSakuya, 2) == 0) value = 0;
                value -= 1;
                return value;
            }
            if (loc == 2)
            {
                if (Sakuyaed_2) value -= 4;
                if (Which != 0)
                {
                    int value_2 = value;
                    foreach (ClientCard card2 in Bot.GetMonsters())
                    {
                        if (ChainContainsCard2ByPlayer(card2) && card2.IsCode(CardId.SWSakuya))
                        {
                            value_2 += 5;
                            int seq = card2.Sequence;
                            if (FlandreInt(seq, false, true) > 0) value_2 += 5;
                        }
                        if (((card2.IsFacedown() && !des) || card2.IsDisabled()) && card2.IsCode(CardId.SWSakuya) && !card2.IsSpecialSummoned && !des) value_2 -= 6;
                        if (!card2.IsSpecialSummoned && des && card2.IsCode(CardId.SWSakuya)) value_2 -= 5;
                        if (!card2.IsSpecialSummoned && !des && card2.IsCode(CardId.SWSakuya)) value_2 += 4;
                        if ((Which == 1) && (value_2 < value)) value = value_2;
                        if ((Which == 2) && (value_2 > value)) value = value_2;
                    }
                    return value;
                }
                if (ChainContainsCard2ByPlayer(Card) && Card.IsCode(CardId.SWSakuya))
                {
                    value += 5;
                    int seq = Card.Sequence;
                    if (FlandreInt(seq, false, true) > 0) value += 5;
                }
                if (Card != null && (Card.IsFacedown() || Card.IsDisabled()) && !Card.IsSpecialSummoned && !des) value -= 6;
                if (!Card.IsSpecialSummoned && des) value -= 5;
                if (!Card.IsSpecialSummoned && !des) value += 4;
                if (Util.IsChainTarget(Card) && Duel.LastChainPlayer != 0) value -= 8;
                return value;
            }
            return value;
        }

        private int GetKandSValue(int loc = 2, bool des = false, int Which = 0, ClientCard Card = null)
        {
            int value = 15;
            return value;
        } 
        private int GetCTrapValue(int loc = 1, bool des = false, int Which = 0, ClientCard Card = null)//1表示手卡
        {
            int value = 14;
            if (loc == 1)
            {
                value = 4;
                if (IfScarlet()) value += 7;
                return value;
            }
            if (loc == 0)
            {
                value = 10;
                if (IfScarlet()) value += 6;
                if (Bot.HasInHandOrInSpellZoneOrInGraveyard(CardId.Cranberry_Trap)) value -= 4;
                if (GetCountInDeck(CardId.Cranberry_Trap, 2) == 0) value = 0;
                return value;
            }
            if (loc == 2)
            {
                value = 8;
                if (Which != 0)
                {
                    int value_2 = value;
                    foreach (ClientCard card2 in Bot.GetSpells())
                    {
                        if (((card2.IsFacedown() && !des) || card2.IsDisabled()) && card2.IsCode(CardId.Cranberry_Trap)) value_2 -= 7;
                        if (card2.IsFaceup() && card2.IsCode(CardId.Cranberry_Trap) && (des == true) && (card2.Location == CardLocation.SpellZone) && (HowManySeqNHasPachi() > 1)) value_2 = 0;
                        if ((Which == 1) && (value_2 < value)) value = value_2;
                        if ((Which == 2) && (value_2 > value)) value = value_2;
                    }
                    return value;
                }
                if ((Card.IsFacedown() || Card.IsDisabled())) value -= 7;
                if (Card.IsFaceup() && (des == true) && (Card.Location == CardLocation.SpellZone) && (HowManySeqNHasPachi() > 1)) value = 0;
                if (Util.IsChainTarget(Card) && Duel.LastChainPlayer != 0) value -= 8;
                return value;
            }
            return value;
        }
        private int GetRDHouseValue(int loc = 1)//1表示手卡
        {
            int value = 10;
            if (loc == 1)
            {
                if (GetRDMCountInHand() < 1) value -= 4;
                value += 1;
                return value;
            }
            if (loc == 2)
            {
                return 5;
            }
            if (loc == 0)
            {
                if (GetRDMCountInHand(true, true) > 0 && GetRDMCountInMZone(false, true, false) == 0) value += 8;
                if (GetCountInDeck(CardId.RDHouse, 1) == 0) value = 0;
                return value;
            }
            return value;
        }
        private int GetMLakeValue(int loc = 1)//1表示手卡
        {
            int value = 17;
            if (loc == 0)
            {
                if (GetCountInDeck(CardId.Mist_Lake, 1) == 0) value = 0;
                return value;
            }
            return value;
        }

        private int GetTen_JudgeValue(int loc = 1)//1表示手卡
        {
            int value = 13;
            return value;
        }

        private int GetSWPatchouliValue(int loc = 1, bool des = false, int Which = 0, ClientCard Card = null)//1表示手卡
        {
            int value = 14;
            if (loc == 2)
            {
                value = 8;
                if (Which != 0)
                {
                    int value_2 = value;
                    foreach (ClientCard card2 in Bot.GetMonsters())
                    {
                        if (((card2.IsFacedown() && !des) || card2.IsDisabled()) && card2.IsCode(CardId.SWPatchouli)) value_2 -= 7;
                        if (!card2.IsSpecialSummoned && des && card2.IsCode(CardId.SWPatchouli)) value_2 -= 5;
                        if (!card2.IsSpecialSummoned && !des && card2.IsCode(CardId.SWPatchouli)) value_2 += 4;
                        if ((Which == 1) && (value_2 < value)) value = value_2;
                        if ((Which == 2) && (value_2 > value)) value = value_2;
                    }
                    foreach (ClientCard card3 in Bot.GetSpells())
                    {
                        value_2 = 11;
                        if (((card3.IsFacedown() && !des) || card3.IsDisabled()) && card3.IsCode(CardId.SWPatchouli)) value_2 -= 4;
                        if (Patchoulied_2 && card3.IsCode(CardId.SWPatchouli)) value_2 -= 4;
                        if (Bot.Hand.GetMonsters().Count == 0) value_2 -= 5;
                        if ((Which == 1) && (value_2 < value)) value = value_2;
                        if ((Which == 2) && (value_2 > value)) value = value_2;
                    }
                    return value;
                }
                if ((Card.IsFacedown() && !des) || Card.IsDisabled()) value -= 7;
                if (!Card.IsSpecialSummoned && des && (Card.Location == CardLocation.MonsterZone)) value -= 5;
                if (!Card.IsSpecialSummoned && !des && (Card.Location == CardLocation.MonsterZone)) value += 4;
                int zone = Card.Sequence;
                if (zone > -1 && zone < 5)
                {
                    ClientCard CardX = Enemy.MonsterZone[4 - zone];
                    if (CardX == null && Card.Sequence == 1 && Enemy.MonsterZone[5] != null) CardX = Enemy.MonsterZone[5];
                    if (CardX == null && Card.Sequence == 3 && Enemy.MonsterZone[6] != null) CardX = Enemy.MonsterZone[6];
                    if (CardX != null)
                    {
                        value += 3;
                        if (CardX.IsExtraCard()) value += 3;
                    }
                }
                if (Patchoulied_2 && (Card.Location == CardLocation.SpellZone)) value -= 4;
                if (Bot.Hand.GetMonsters().Count == 0 && (Card.Location == CardLocation.SpellZone)) value -= 5;
                return value;
            }
            if (loc == 0)
            {
                if (GetCountInDeck(CardId.SWPatchouli, 2) == 0) value = 0;
                value = 11;
                if (IfFlandre(true, false) > 3) value += 2;
                if (IfFlandre(true, false) > 5) value += 2;
                if (Duel.Player == 1) value += 2;
                return value;
            }
            return value;
        }

        private int GetRDMaidValue(int loc = 1, bool des = false, int Which = 0, ClientCard Card = null)//1表示手卡
        {
            int value = 19;
            if (loc == 0)
            {
                value -= 4;
                if (RDMaided) value -= 9;
                return value;
            }
            if (loc == 2)
            {
                value = 16;
                if (Duel.Player == 1) value -= 8;
                //if ((GetRDMCountInMZone(false) == GetFaceupMZone()) && Card2.IsFaceup() && ) value = value + 6;
                if (RDMaided) value -= 12;
                if (Bot.HasInSpellZone(CardId.Mist_Lake, true, true) && !IfBotHasBaka()) value -= 3;
                if (Which != 0)
                {
                    int value_2 = value;
                    foreach (ClientCard card2 in Bot.GetMonsters())
                    {
                        if ((card2.IsFacedown() || card2.IsDisabled()) && card2.IsCode(CardId.RDMaid)) value_2 -= 10;
                        if (card2.IsCode(CardId.RDMaid) && KoaKuma2() && !card2.IsSpecialSummoned && card2.IsCode(CardId.RDMaid)) value_2 -= 5;
                        if ((Which == 1) && (value_2 < value)) value = value_2;
                        if ((Which == 2) && (value_2 > value)) value = value_2;
                    }
                    return value;
                }
                if ((Card != null) && (Card.IsFacedown() || Card.IsDisabled())) value -= 12;
                if ((Card != null) && !Card.IsSpecialSummoned) value -= 3;
                if ((Card != null) && Card.IsCode(CardId.RDMaid) && KoaKuma2() && !Card.IsSpecialSummoned) value -= 4;
                if (Util.IsChainTarget(Card) && Duel.LastChainPlayer == 1) value -= 8;
                return value;
            }
            return value;
        }
        private bool RikakoEffect()
        {

            if (Card.IsDisabled()) return false;
            if (Duel.LastChainPlayer == 1)
            {
                int NowCode = 0;
                foreach (ClientCard monster in Bot.GetMonsters())
                {
                    if (monster.IsOriginalCode(CardId.Rikako)) { NowCode = monster.Alias; Logger.DebugWriteLine("当前里香子id是" + NowCode); continue; }
                }
                if (NowCode > 0)
                {
                    foreach (ClientCard monster in Bot.GetMonsters())
                    {
                        Logger.DebugWriteLine("里香子测试 " + monster.Id + "  " + monster.Alias);
                        if (monster.Id == NowCode && !monster.IsOriginalCode(CardId.Rikako))
                        {
                            Logger.DebugWriteLine("里香子测试"); AI.SelectCard(monster); continue;
                        }
                    }
                } 
                return true;
            }
            if (ActivateDescription == -1 || (ActivateDescription == Util.GetStringId(CardId.Rikako, 0)) && Card.Location == CardLocation.MonsterZone)
            {
                List<ClientCard> material_listX = MRanktoLevel(Bot.GetGraveyardMonsters(), 9);
                Logger.DebugWriteLine("里香子测试 " + material_listX.Count);
                if (material_listX.Count == 1 && GetCountInDeck(CardId.SWRemilia, SWRemiliaCount) > 0) { AI.SelectCard(CardId.SWRemilia); DoNotChain = true; return true; }
                List<ClientCard> material_list = MRanktoLevel(Bot.GetGraveyardMonsters(), 7);
                if (material_list.Count <= 2) { AI.SelectCard(new[] { CardId.SWMeilin, CardId.SWSakuya, CardId.RDFlandre }); DoNotChain = true; return true; }
                AI.SelectCard(new[] { CardId.RDKoakuma, CardId.SWPatchouli, CardId.SWRemilia, CardId.Cranberry_Trap });
                DoNotChain = true;
                return true;
            }
            if (ActivateDescription == -1 || (ActivateDescription == Util.GetStringId(CardId.Rikako, 2)) && Card.Location == CardLocation.Grave)
            {
                ClientCard CardA = null;
                int level = 5;
                foreach (ClientCard g2 in Bot.GetGraveyardMonsters())
                {
                    if (g2.IsMonster() && (g2.Level > level)) { level = g2.Level; CardA = g2; }
                }
                if (CardA != null)
                {
                    AI.SelectCard(CardA);
                    return true;
                }
                return true;
            }
            return false;
        }
        //
        //以上为GetValue类
        //
        private bool AshBlossomSummon()  //小兔姬
        {
            if (Bot.HasInHand(CardId.NAMERedDevil) && !NAMERedDeviled && !NAMERedDeviled2) return true;
            return false;
        }
        private bool Little_BunnyEffect()  //小兔姬
        { 
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
        private bool SL_ReimuEffect()  //灵梦 
        {
            if (ActivateDescription == Util.GetStringId(CardId.NAMERedDevil, 0)) { return false; }
            return true;
        }
        private bool Scarlet_Set()
        {
            if (GetRDMCountInMZone() == 0) return true;
            return false;
        }

        private bool RumiaEffect()
        {
            if (GetCountInDeck(CardId.RDMaid) > 0 && !Summoned)
            {
                AI.SelectCard(CardId.RDMaid);
                return true;
            }
            if ((GetRDMCountInHand() > 1 || Bot.HasInHand(CardId.RDMaid)) && !Summoned)
            {
                if (GetCountInDeck(CardId.RDKoakuma) > 0 && !KoakumaedSummoned)
                {
                    AI.SelectCard(CardId.RDKoakuma);
                    return true;
                }
            }
            if (GetCountInDeck(CardId.RDMaid) > 0)
            {
                AI.SelectCard(CardId.RDMaid);
                return true;
            }
            AI.SelectCard(CardId.RDKoakuma);
            return true;
        }

        private bool RumiaSummon()
        {
            Summoned = true;
            return true;
        }

        private bool FumiTsukiEffect()
        {
            if (!Util.ChainContainsCard(CardId.FumiTsuki))
            {
                Logger.DebugWriteLine("绝妙定理测试" + ActivateDescription);
                if (ActivateDescription == 0)
                {
                    Logger.DebugWriteLine("绝妙定理测试2");
                    Logger.WriteLine("真是精彩的论证");
                    if (Duel.LastChainPlayer == 0) return false;
                    KoakumaedSummoned = true;
                    DoNotChain = true;
                    return true;
                }
                DoNotChain = true;
                return true;
            }
            return false;
        }
         
        private bool SL_RemiliaSpSummon()
        {
            PaoChed = true; 
            return true;
        } 
        private bool GoToBattlePhase()
        {
            DoNotChain = false;
            return false;
        }  
        private bool NAMERedDevilEffect2()
        {
            if (ActivateDescription == Util.GetStringId(CardId.NAMERedDevil, 0))
            {
                int seq = Card.Sequence;
                if (seq == 6) seq = 3;
                if (seq == 5) seq = 1;
                Logger.DebugWriteLine("进入了红魔名测试");
                if ((GetCountInDeck(CardId.SWSakuya, 2) > 0) && (FlandreInt(seq, false, true) < IfSakuya()))
                {
                    AI.SelectCard(CardId.SWSakuya);
                    AI.SelectNextCard(new[] {
                        CardId.Scarlet_Destiny,
                        CardId.Scarlet_Seance,
                        CardId.Scarlet_Gensokyo
                    });
                    AI.SelectThirdCard(new[] {
                        CardId.Scarlet_Gensokyo,
                        CardId.Scarlet_Seance,
                        CardId.Scarlet_Overlay
                    });
                    NAMERedDeviled2 = true;
                    return true;
                }
                if (GetCountInDeck(CardId.SWRemilia, 2) > 0 && FlandreInt(seq, false, false) > 0
                    && (Bot.HasInHand(CardId.Scarlet_Seance) && (GetRDMCountInMZone() == Bot.GetMonsterCount()) || (Bot.HasInHandOrInSpellZone(CardId.RDMatch) && GetDestroyCountInHand() > 0)))
                {
                    AI.SelectCard(CardId.SWRemilia);
                    NAMERedDeviled2 = true;
                    return true;
                }

                if (GetCountInDeck(CardId.SWMeilin, 2) > 0 && FlandreInt(seq, false, true) > 2)
                {
                    AI.SelectCard(CardId.SWMeilin);
                    NAMERedDeviled2 = true;
                    return true;
                }

                if (GetCountInDeck(CardId.RDFlandre, 1) > 0 && FlandreInt(seq, false, false) > 2)
                {
                    AI.SelectCard(CardId.RDFlandre);
                    NAMERedDeviled2 = true;
                    return true;
                }

                if (GetCountInDeck(CardId.SWPatchouli, 2) > 0
                    && (Bot.HasInHand(CardId.Scarlet_Seance) && (GetRDMCountInMZone() == Bot.GetMonsterCount()) || (Bot.HasInHandOrInSpellZone(CardId.RDMatch) && GetDestroyCountInHand() > 0)))
                {
                    AI.SelectCard(CardId.SWPatchouli);
                    NAMERedDeviled2 = true;
                    return true;
                }
                NAMERedDeviled2 = true;
                return true;
            }
            return false;
        }
        private bool NAMERedDevilEffect()
        {
            if (GetFaceupMZone() == 0) return false;
            foreach (ClientCard MonstersCard in Bot.GetMonsters())
            {
                if (!MonstersCard.IsDisabled())
                {
                    if (MonstersCard.Attack > 3000 || (MonstersCard.Attack >= 3000 && MonstersCard.IsExtraCard()))
                    {
                        AI.SelectCard(MonstersCard);
                        NAMERedDeviled = true;
                        return true;
                    }
                }
            }
            foreach (ClientCard MonstersCard in Bot.GetMonsters())
            {
                if (!MonstersCard.IsDisabled())
                {
                    int seq = MonstersCard.Sequence;
                    if (seq == 6) seq = 3;
                    if (seq == 5) seq = 1;
                    if ((FlandreInt(seq, false, true) + 1 >= IfSakuya()) && FlandreInt(seq, false, true) > 2)
                    {
                        AI.SelectCard(MonstersCard);
                        NAMERedDeviled = true;
                        return true;
                    }
                    if ((FlandreInt(seq, false, false) >= IfSakuya()) && FlandreInt(seq, false, false) > 2)
                    {
                        AI.SelectCard(MonstersCard);
                        NAMERedDeviled = true;
                        return true;
                    }
                    if (IfSakuya() > 2)
                    {
                        AI.SelectCard(MonstersCard);
                        NAMERedDeviled = true;
                        return true;
                    }
                } 
            }
            foreach (ClientCard MonstersCard in Bot.GetMonsters())
            { 
                if (MonstersCard.Attack > 3000 || (MonstersCard.Attack >= 3000 && MonstersCard.IsExtraCard()))
                {
                    AI.SelectCard(MonstersCard);
                    NAMERedDeviled = true;
                    return true;
                } 
            }
            foreach (ClientCard MonstersCard in Bot.GetMonsters())
            {
                if (!MonstersCard.HasSetcode(0x813))
                {
                    AI.SelectCard(MonstersCard);
                    NAMERedDeviled = true;
                    return true;
                }
            }
            NAMERedDeviled = true;
            return true;
        } 
        private bool Ten_JudgeEffect()
        {
            if (Bot.LifePoints < 1501) return false;
            if (Duel.LastChainPlayer == 1) return true;
            IList<ClientCard> LSC = Duel.LastSummonedCards;
            if (LSC.Count < 1) return false; 
            if (LSC[0].Controller != 0) return true;
            return false;
        }

        private bool Scarlet_SeanceEffect()
        {
            if (RDMChainning()) return false;
            if (RDMChainning2()) return false;
            if (Duel.Player == 1)
            {
                List<ClientCard> material_list0 = Bot.GetGraveyardMonsters();
                contact2list(material_list0, Bot.Hand.GetMonsters());
                SortByValue(material_list0, 0, material_list0.Count - 1, 1);
                if (material_list0.Count > 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (material_list0[material_list0.Count - 1].Id == CardId.RDMaid && RDMaided)
                        {
                            material_list0.RemoveAt(material_list0.Count - 1);
                        }
                        if (material_list0.Count == 0) break;
                        if (material_list0[material_list0.Count - 1].Id == CardId.RDKoakuma && KoaKuma2())
                        {
                            material_list0.RemoveAt(material_list0.Count - 1);
                        }
                        if (material_list0.Count == 0) break;
                    }
                }
                if (IfFlandre(false, false, -1, true) > 1 && Bot.HasInHandOrInGraveyard(CardId.SWRemilia)) { AI.SelectCard(CardId.SWRemilia); return true; }
                if (IfFlandre(true, false, -1, true) > 3 && Bot.HasInHandOrInGraveyard(CardId.SWPatchouli)) { AI.SelectCard(CardId.SWPatchouli); return true; }
                bool abc = GetCountInDeck(CardId.Scarlet_Destiny, Scarlet_DestinyCount) > 0 || GetCountInDeck(CardId.Scarlet_Seance, 2) > 0;
                foreach (ClientCard MonstersCard in material_list0)
                {
                    if ((MonstersCard.HasType(CardType.Fusion) || MonstersCard.HasType(CardType.Synchro) || MonstersCard.HasType(CardType.Xyz) || MonstersCard.HasType(CardType.Link)) && HasSetRD(MonstersCard))
                    { AI.SelectCard(MonstersCard); return true; }
                }
                if (IfFlandre(false, true, -1, true) > 4 &&
                    (Bot.HasInHandOrInGraveyard(CardId.SWMeilin) || (Bot.HasInHandOrInGraveyard(CardId.RDMaid) && !RDMaided && (GetCountInDeck(CardId.SWMeilin, 2) > 0) && abc)))
                { AI.SelectCard(new[] { CardId.SWMeilin, CardId.RDMaid }); return true; }
                if (IfFlandre() > 4 &&
                    (Bot.HasInHandOrInGraveyard(CardId.RDFlandre) || (Bot.HasInHandOrInGraveyard(CardId.RDMaid) && !RDMaided && (GetCountInDeck(CardId.RDFlandre, 1) > 0))))

                { AI.SelectCard(new[] { CardId.RDFlandre, CardId.RDMaid }); return true; }

                //if (Duel.Phase == DuelPhase.BattleStart && (!Sakuyaed_2 || !RDMaided) && abc) { AI.SelectCard(material_list0[material_list0.Count - 1]); return true; }
                return false;
            }
            if ((GetRDMCountInGrave() > 0) || (GetRDMCountInHand() > 0))
            {
                //if (KoaKuma2()) Logger.DebugWriteLine("可以召唤的场合先召唤再发效果 调试1");
                //if (!ESummoned) Logger.DebugWriteLine("可以召唤的场合先召唤再发效果 调试2"); 

                if (KoaKuma2() && !ESummoned && ((Duel.Phase == DuelPhase.Main1) || (Duel.Phase == DuelPhase.Main2))  
                        && (GetDestroyCountInSpellZone() < 1) && GetRDMCountInHand(true, false, 1) > 0
                        && SWSakuyaSummonDummy()) { return false; }
                List<ClientCard> material_list0 = Bot.GetGraveyardMonsters();
                contact2list(material_list0, Bot.Hand.GetMonsters());
                bool hasTuner = false;
                foreach (ClientCard MonstersCard in Bot.GetMonsters())
                {
                    if (MonstersCard.HasType(CardType.Tuner)) { hasTuner = true; break; }
                }
                if (material_list0.Count > 0)
                {
                    for (int i = 0; i < material_list0.Count; i++)
                    {
                        if (material_list0[material_list0.Count - 1].Id == CardId.RDMaid && RDMaided && hasTuner)
                        {
                            material_list0.RemoveAt(material_list0.Count - 1);
                        }
                        if (material_list0.Count == 0) break;
                        if (material_list0[material_list0.Count - 1].Id == CardId.RDKoakuma && KoaKuma2() && hasTuner)
                        {
                            material_list0.RemoveAt(material_list0.Count - 1);
                        }
                        if (material_list0.Count == 0) break;
                    }
                }
                foreach (ClientCard MonstersCard in material_list0)
                {
                    if ((MonstersCard.HasType(CardType.Fusion) || MonstersCard.HasType(CardType.Synchro) || MonstersCard.HasType(CardType.Xyz) || MonstersCard.HasType(CardType.Link)) && HasSetRD(MonstersCard))
                    { AI.SelectCard(MonstersCard); return true; }
                } //
                Logger.DebugWriteLine("绯色降神测试X");
                bool abc = GetCountInDeck(CardId.Scarlet_Destiny, Scarlet_DestinyCount) > 0 || GetCountInDeck(CardId.Scarlet_Seance, 2) > 0;
                bool def = (Bot.HasInHand(CardId.SWSakuya) && !Sakuyaed && !Sakuyaed_2 && GetDestroyCountInMZone() > 0) || (Bot.HasInHand(CardId.RDMaid) && !RDMaided && !Summoned);
                //bool xyz = (Bot.HasInHand(CardId.SWPatchouli) || (Bot.HasInHand(CardId.SWMeilin) && !Meilined));
                if (abc && def) return false;
                List<ClientCard> material_list = MRanktoLevel(material_list0, 7, true);
                List<ClientCard> material_list2 = MRanktoLevel(material_list0, 9, true);
                SortByValue(material_list0, 0, material_list0.Count - 1, 1);
                SortByValue(material_list, 0, material_list.Count - 1, 1);
                SortByValue(material_list2, 0, material_list2.Count - 1, 1);
                if ((GetMosterByRank(9).Count > 0) && (GetMosterByRank(9, false).Count == 1) && (material_list2.Count > 0)) { AI.SelectCard(material_list2[material_list2.Count - 1]); return true; }
                if ((GetMosterByRank(7).Count > 0) && (GetMosterByRank(7, false).Count == 1) && (material_list.Count > 0)) { AI.SelectCard(material_list[material_list.Count - 1]); return true; }
                if (Bot.HasInHandOrInGraveyard(CardId.SWRemilia)) { AI.SelectCard(CardId.SWRemilia); return true; }
                if (material_list0.Count == 0) return false;
                AI.SelectCard(material_list0[material_list0.Count - 1]);
                return true;
            }
            return false;
        }
        private List<ClientCard> MRanktoLevel(List<ClientCard> cards, int rank, bool onlyRD = false)
        {
            List<ClientCard> MonstersCards = cards;
            List<ClientCard> material_list = new List<ClientCard>();
            foreach (ClientCard MonstersCard in MonstersCards)
            {
                if (MonstersCard.HasType(CardType.Monster) && !MonstersCard.HasType(CardType.Xyz)
                    && (HasSetRD(MonstersCard) || !onlyRD) && MonstersCard.Level == rank) material_list.Add(MonstersCard);
            }
            return material_list;
        }

        private bool SWRemiliaEffect()
        { 
            if (Card.Location == CardLocation.Hand && ActivateDescription == Util.GetStringId(CardId.SWRemilia, 0))
            { 
                if (Bot.HasInHand(CardId.SWSakuya) && !((IfFlandre(false, true) > IfSakuya()) && Bot.HasInHand(CardId.SWMeilin) && !((IfFlandre(false, false) > IfSakuya()) && Bot.HasInHand(CardId.RDFlandre)))
                        && !((IfFlandre(true, false) > IfSakuya()) && Bot.HasInHand(CardId.SWPatchouli)) && IfSakuya() > 2 && !Sakuyaed_2)
                {
                    AI.SelectCard(CardId.SWSakuya);
                    return true;
                }
                if (Bot.HasInHand(CardId.RDMaid) && !Bot.HasInHand(CardId.RDKoakuma) && !RDMaided && Summoned)
                {
                    AI.SelectCard(CardId.RDMaid);
                    return true;
                } 
                if (GetCountInDeck(CardId.RDFlandre, 1) > 0 && !Flandred && Bot.HasInHand(CardId.RDFlandre)
                    && !((IfFlandre(true, false) > 2) && Bot.HasInHand(CardId.SWPatchouli)) && !((IfFlandre(false, true) > 2) && Bot.HasInHand(CardId.SWMeilin)))
                {
                    AI.SelectCard(CardId.RDFlandre);
                    return true;
                } 
                if (GetCountInDeck(CardId.SWMeilin, 2) > 0 && !Meilined && Bot.HasInHand(CardId.SWMeilin)
                    && !((IfFlandre(true, false) > 2) && Bot.HasInHand(CardId.SWPatchouli)))
                {
                    AI.SelectCard(CardId.SWMeilin);
                    return true;
                } 
                if (Bot.HasInHand(CardId.SWPatchouli))
                { 
                    AI.SelectCard(CardId.SWPatchouli);
                    return true;
                }
                if ((Summoned || GetRDMCountInHand(true, false, 1) == 0) && Bot.HasInHand(CardId.RDKoakuma) && !KoaKuma2() && !((IfFlandre(false, true) > 2) && Bot.HasInHand(CardId.SWMeilin))
                    && !((IfFlandre(true, false) > 2) && Bot.HasInHand(CardId.SWPatchouli)) && !((IfFlandre(false, false) > 2) && Bot.HasInHand(CardId.RDFlandre)))
                {
                    if (IfSummonRemilia(1))
                    {
                        AI.SelectCard(CardId.RDKoakuma);
                        return true;
                    }
                }
                return true;
            } 
            if (Card.Location == CardLocation.Hand && ActivateDescription != Util.GetStringId(CardId.SWRemilia, 0)
                && ActivateDescription > 0)
            { 
                if (DoNotChain && Duel.Player == 0) return false;
                if (Bot.GetMonsterCount() > 4) return false;
                if (Bot.HasInHand(CardId.RDHouse) && (Util.ChainContainPlayer(0) || Util.ChainContainPlayer(1))) return false; 
                if (Bot.HasInHand(CardId.NAMERedDevil) && !NAMERedDeviled && (GetDestroyCountInMZone() < 2) && GetFaceupMZone() > 0) return false; 
                if (Bot.HasInSpellZone(CardId.NAMERedDevil) && !NAMERedDeviled2 && GetFaceupMZone() > 0) return false; 
                if (Bot.HasInSpellZone(CardId.SWPatchouli) && !Patchoulied_2 && Bot.Hand.GetMonsters().Count > 1
                        && !Summoned) return false;
                if (Util.ChainContainsCard(CardId.RDMatch)) return false; 
                if (Bot.HasInHand(CardId.RDKoakuma) && !Summoned) return false;
                if (Bot.HasInHand(CardId.SWSakuya) && !Sakuyaed_2 && !Summoned && (IfFlandre(false, true) <= IfSakuya())) return false;
                if (!Summoned && GetRDMCountInHand(true, false, 1) > 0 && ((Duel.Phase == DuelPhase.Main1) || (Duel.Phase == DuelPhase.Main2))
                    && (GetDestroyCountInSpellZone() < 1)) return false; 

                if (KoaKuma2() && !ESummoned && ((Duel.Phase == DuelPhase.Main1) || (Duel.Phase == DuelPhase.Main2)) && GetRDMCountInHand(true, false, 1) > 0
                    && SWSakuyaSummonDummy() && !Bot.HasInSpellZone(CardId.NAMERedDevil, false, true)) return false;  //&& (GetDestroyCountInSpellZone() < 1) 
                if (RDMChainning() && Card.Location == CardLocation.Hand) return false; 
                if (Bot.HasInSpellZone(CardId.RDMatch, true, true) && (IfFlandre(false, true) < 3)  && (GetRDMCountInHand() > 1) && (GetDestroyCountInMZone() <= 1)) return false;
                List<ClientCard> material_list = new List<ClientCard>();
                foreach (ClientCard monster in Bot.GetMonsters())  
                {
                    if (HasSetRD(monster) && !monster.IsExtraCard())
                    {
                        material_list.Add(monster); 
                    }
                }
                List<ClientCard> material_list4 = new List<ClientCard>();
                foreach (ClientCard spell in Bot.GetSpells())
                {
                    if (HasSetRD(spell) && spell.IsFaceup())
                    {
                        material_list4.Add(spell);
                    }
                }
                contact2list(material_list, material_list4);
                if (material_list.Count == 0) return false;
                SortByValue(material_list, 0, material_list.Count - 1, 2, true);
                AI.SelectCard(material_list[0]);
                return true;
            }
            if (Card.Location == CardLocation.MonsterZone)
            {
                int seq = Card.Sequence;
                if (Enemy.MonsterZone[4 - seq] != null)
                {
                    AI.SelectCard(Enemy.MonsterZone[4 - seq]);
                    return true;
                }
                if (Enemy.SpellZone[4 - seq] != null)
                {
                    AI.SelectCard(Enemy.SpellZone[4 - seq]);
                    return true;
                }

                if (Bot.SpellZone[seq] != null && Bot.SpellZone[seq].HasSetcode(0x813) && Bot.SpellZone[seq].IsFaceup())
                {
                    AI.SelectCard(Bot.SpellZone[seq]);
                    return true;
                }
            }
            return false;
        }

        private bool RDKoakumaSummon()
        {
            Logger.DebugWriteLine("小恶魔测试");
            if (GetRDMCountInHand() > 0 || Bot.HasInHand(CardId.Red_Magic) || Bot.HasInHand(CardId.NAMERedDevil))
            {
                Logger.DebugWriteLine("小恶魔测试2");
                Summoned = true;
                KoakumaedSummoned = true;
                return true;
            }
            return false;
        }

        private bool RDMaidSummon()
        {
            Logger.DebugWriteLine("妹抖测试");
            if (KoaKuma2() && !ESummoned && ((Duel.Phase == DuelPhase.Main1) || (Duel.Phase == DuelPhase.Main2)) && Summoned)
            {
                return SWSakuyaSummonDummy();
            }
            Logger.DebugWriteLine("妹抖测试2");
            Summoned = true;

            return true;
        }

        private bool SWIkuSummon()
        {
            Summoned = true;
            return true;
        } 
        private bool FeverEffect()
        {
            foreach (ClientCard MonstersCard in Enemy.GetMonsters())
            {
                if (MonstersCard.IsDisabled()) return false;
            }
            if (Card.Location == CardLocation.Hand)
            {
                ClientCard card0 = Enemy.GetMonsters().GetLowestAttackMonster();
                if (card0 == null) return false;
                if ((card0.HasType(CardType.Link) && Enemy.GetMonsterCount() == 1) ||
                    card0.HasType(CardType.Fusion) || (card0.HasType(CardType.Xyz) && card0.Rank > 4 && card0.Overlays.Count > 0)
                    || (card0.HasType(CardType.Synchro) && card0.Level > 5))
                {
                    List<ClientCard> material_list = Bot.GetHands();
                    SortByValue(material_list, 0, material_list.Count - 1, 1, false);
                    foreach (ClientCard cardA in material_list)
                    {
                        if (cardA != Card) { AI.SelectCard(cardA); return true; }
                    }
                }
                return false;
            }

            return true;
        }


        private bool RDHouseEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.HasInHandOrInSpellZone(CardId.ScarletWeather) && !SWed) return false;
                if (GetRDMCountInHand() > 0 || Bot.HasInHandOrInSpellZone(CardId.Red_Magic))
                {
                    RDHoused = true;
                    return true;
                }

            }
            if (Duel.Phase == DuelPhase.Standby)
            {

                return true;
            }

            return false;
        }

        private bool RDFlandreEffect()
        {
            if ((((IfFlandre() > 0) && Duel.Player == 1) || ((IfFlandre() >= 0) && Duel.Player == 0)) 
                && (Card.Location == CardLocation.Hand) && !ChainContainsCardByPlayer(CardId.MKII))
            {
                if (DoNotChain && Duel.Player == 0) return false;
                if (Bot.HasInHand(CardId.RDKoakuma) && !Summoned) return false;
                if (Bot.GetMonsterCount() >= 4 && Duel.Player == 0 && Bot.GetSpellCount() > 0) return false;
                if (Bot.GetMonsterCount() > 4 && Duel.Player == 0) return false;
                if (RDMChainning()) return false;
                if (Bot.HasInSpellZone(CardId.RDMatch) && (Bot.HasInHand(CardId.RDFlandre)) && !Flandred && GetRDMCountInGrave() > 0
                    && ((Duel.Phase == DuelPhase.Main1) || (Duel.Phase == DuelPhase.Main2)) && !PaoChed)
                {
                    List<ClientCard> material_list44 = new List<ClientCard>();
                    material_list44 = ToRDFlandreEffect(material_list44);
                    if (material_list44.Count < 1) return false;
                    SortByValue(material_list44, 0, material_list44.Count - 1, 2, true);
                    AI.SelectCard(material_list44[0]);
                    Flandred = true;
                    return true;
                }
                if (Util.ChainContainsCard(CardId.RDMatch)) return false;
                if (Bot.HasInHand(CardId.SWSakuya) && !Sakuyaed_2 && !Sakuyaed && (IfFlandre(false, false) <= IfSakuya())) return false;
                if (Bot.HasInSpellZone(CardId.SWPatchouli) && !Patchoulied_2 && Bot.Hand.GetMonsters().Count > 1
                        && !Summoned) return false;
                if (Util.ChainContainsCard(CardId.RDMatch)) return false; 
                if (Bot.HasInHand(CardId.RDKoakuma) && !Summoned) return false;
                if (KoaKuma2() && !ESummoned && ((Duel.Phase == DuelPhase.Main1) || (Duel.Phase == DuelPhase.Main2))
                        && !Bot.HasInSpellZone(CardId.NAMERedDevil, false, true)) return false;
                if (Card.Level == 11) return false;
                List<ClientCard> material_list = new List<ClientCard>();
                material_list = ToRDFlandreEffect(material_list);
                if (material_list.Count < 1) return false;
                SortByValue(material_list, 0, material_list.Count - 1, 2, true);
                AI.SelectCard(material_list[0]);
                Flandred = true;
                return true;
            }
            if (Card.Location == CardLocation.MonsterZone)
            {
                return true;
            }
            if (Card.Location == CardLocation.Grave)
            {
                return true;
            }
            return false;
        }
        private List<ClientCard> ToRDFlandreEffect(List<ClientCard> material_list)
        {
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if ((GetValueByCard(monster, 2, true, 1) < 10) && monster.IsFaceup() && !monster.IsExtraCard() && HasSetRD(monster))
                {
                    material_list.Add(monster);
                }
            }
            foreach (ClientCard spell in Bot.GetSpells())
            {
                if ((GetValueByCard(spell, 2, true, 1) < 10) && spell.IsFaceup() && HasSetRD(spell))
                {
                    material_list.Add(spell);
                }
            }
            return material_list;
        }
        private bool Scarlet_DestinyEffect3()
        {

            if ((Card.Location == CardLocation.SpellZone) && Card.IsFaceup() && (ActivateDescription == Util.GetStringId(CardId.Scarlet_Destiny, 1)))
            {
                Logger.DebugWriteLine("绯色命运测试1");
                return true;
            }
            return false;
        }
        private bool Scarlet_DestinyEffect()
        {
            if ((Card.Location == CardLocation.SpellZone) && Card.IsFaceup() && (ActivateDescription == Util.GetStringId(CardId.Scarlet_Destiny, 1)))
            {
                Logger.DebugWriteLine("绯色命运测试1 自排连锁");
                return false;
            }
            if ((((!Sakuyaed_2 && GetCountInDeck(CardId.SWSakuya, 2) > 0) || ((IfFlandre(true, false) > 5) && GetCountInDeck(CardId.SWPatchouli, 2) > 0)
                || ((IfFlandre(false, true) >= 5) && GetCountInDeck(CardId.SWMeilin, 2) > 0)) && !RDMChainning()) && Duel.Player == 0)
            {
                if (GetDestroyCountInMZone() == 0) return false; 
                //if (KoaKuma2()) Logger.DebugWriteLine("可以召唤的场合先召唤再发效果 调试1");
                //if (!ESummoned) Logger.DebugWriteLine("可以召唤的场合先召唤再发效果 调试2");
                if (KoaKuma2() && !ESummoned && ((Duel.Phase == DuelPhase.Main1) || (Duel.Phase == DuelPhase.Main2))
                        && !Bot.HasInSpellZone(CardId.NAMERedDevil, false, true) && GetRDMCountInHand(true, false, 1) > 0) return false;

                Logger.DebugWriteLine("绯色命运测试2");
                Destinying = true;

                return Scarlet_DestinySelect();
            }
            return false;
        }
        protected bool Scarlet_DestinySelect(bool selected = false, bool sakuya = true, int cardid = 0)
        {
            List<ClientCard> material_list = new List<ClientCard>();
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if ((HasSetRD(monster) || Bot.HasInSpellZone(CardId.Scarlet_Gensokyo, true, true)) && monster.IsFaceup()) material_list.Add(monster);
            }

            foreach (ClientCard spell in Bot.GetSpells())
            {
                if (HasSetRD(spell) && spell.IsFaceup()) material_list.Add(spell);
            }
            SortByValue(material_list, 0, material_list.Count - 1, 2, true);
            if (material_list.Count <= 0) return false;
            List<int> cardids = new List<int>();
            cardids.Add(CardId.SWMeilin);
            if (sakuya) cardids.Add(CardId.SWSakuya);
            cardids.Add(CardId.SWPatchouli);
            cardids.Add(CardId.SWRemilia);
            cardids.Add(CardId.RDFlandre);
            cardids.Add(CardId.RDMaid);
            cardids.Add(CardId.RDKoakuma);
            SortByValueId(cardids, 0, cardids.Count - 1, 0);
            Logger.DebugWriteLine("Destiny测试 " + material_list[0].Name);
            string abc = "Destiny测试 ";
            string def = "Destiny价值测试 ";
            for (int i = 0; i < cardids.Count; i++)
            {
                abc = abc + " " + cardids[i];
                def = def + " " + GetValueByCardId(cardids[i], 0, false, 0);
            }
            Logger.DebugWriteLine("Destiny测试 " + abc);

            abc = "";
            def = "";
            for (int i = 0; i < material_list.Count; i++)
            {
                abc = abc + " " + material_list[i].Name;
                def = def + " " + GetValueByCard(material_list[i], 2, true, 0);
            }
            Logger.DebugWriteLine("Destiny测试2 " + abc);
            Logger.DebugWriteLine("Destiny价值测试2 " + def);
            Logger.DebugWriteLine("Destiny价值测试2 " + GetValueByCard(material_list[0], 2, true, 0));
            if (GetValueByCard(material_list[0], 2, true, 0) > 9) return false;
            AI.SelectCard(material_list[0]);
            if (cardid != 0) AI.SelectNextCard(cardid);
            if (cardid == 0) AI.SelectNextCard(cardids[cardids.Count - 1]);
            Logger.WriteLine("这场对决的命运就此决定了！");
            return true;
        }
        private bool Scarlet_DestinyEffect2()
        {
            if (Duel.Player == 1)
            {
                if (!RDMChainning())
                {
                    if (GetDestroyCountInMZone() == 0) return false;
                    if (Card.Location == CardLocation.SpellZone)
                    {
                        if (needDestroyRD()) { Destinying = true; return Scarlet_DestinySelect(false, false); }
                        ClientCard Cardx = Util.GetLastChainCard();
                        if (Cardx != null) Logger.DebugWriteLine("命运测试" + Cardx.Name + " " + Duel.LastChainPlayer + " " + Cardx.Controller);
                        if (IfFlandre(true, false) > 3 && Cardx != null
                            && Duel.LastChainPlayer != 0 && Cardx.Location == CardLocation.Onfield && Cardx.Controller != 0) { Destinying = true; return Scarlet_DestinySelect(false, false, CardId.SWPatchouli); }
                        if (IfFlandre(false, true) > 3) { Destinying = true; return Scarlet_DestinySelect(false, false, CardId.SWMeilin); }
                        if (IfFlandre() > 4) { Destinying = true; return Scarlet_DestinySelect(false, false, CardId.SWMeilin); }
                        if (Duel.Phase == DuelPhase.BattleStart) { Destinying = true; return Scarlet_DestinySelect(false, true); }
                    }
                    else
                    {
                        if (needDestroyRD()) { Destinying = true; return Scarlet_DestinySelect(false, false); }
                        ClientCard Cardx = Util.GetLastChainCard();
                        if (Cardx != null) Logger.DebugWriteLine("命运测试" + Cardx.Name + " " + Duel.LastChainPlayer + " " + Cardx.Controller);
                        if (IfFlandre(true, false) > 3
                            && Duel.LastChainPlayer != 0 && Cardx.Location == CardLocation.Onfield && Cardx.Controller != 0) { Destinying = true; return Scarlet_DestinySelect(false, false, CardId.SWPatchouli); }
                        if (IfFlandre(false, true) > 3) { Destinying = true; return Scarlet_DestinySelect(false, false, CardId.SWMeilin); }
                        if (IfFlandre() > 4) { Destinying = true; return Scarlet_DestinySelect(false, false, CardId.SWMeilin); }
                        if (Duel.Phase == DuelPhase.BattleStart) { Destinying = true; return Scarlet_DestinySelect(false, true); }
                    }
                }
                return false;
            }
            return false;
        }

        private bool SWMeilinEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                return true;
            }
            if ((IfFlandre(false, true) > 0) && (Card.Location == CardLocation.Hand) && !ChainContainsCardByPlayer(CardId.MKII))
            {
                if (DoNotChain && Duel.Player == 0) return false;
                if (Card.Level == 11) return false;
                if (Bot.HasInHand(CardId.RDHouse) && (Util.ChainContainPlayer(0) || Util.ChainContainPlayer(1))) return false; 
                if (Bot.HasInHand(CardId.NAMERedDevil) && !NAMERedDeviled && (GetDestroyCountInMZone() < 2) && GetFaceupMZone() > 0) return false; 
                if (Bot.HasInSpellZone(CardId.NAMERedDevil) && !NAMERedDeviled2 && GetFaceupMZone() > 0) return false;
                if (Bot.HasInSpellZone(CardId.SWPatchouli) && !Patchoulied_2 && Bot.Hand.GetMonsters().Count > 1
                        && !Summoned) return false;
                if (Util.ChainContainsCard(CardId.RDMatch)) return false;
                if (KoaKuma2()) Logger.DebugWriteLine("可以召唤的场合先召唤再发效果 调试1" + ESummoned);
                if (!ESummoned) Logger.DebugWriteLine("可以召唤的场合先召唤再发效果 调试2");

                if (Bot.HasInHand(CardId.RDKoakuma) && !Summoned) return false;
                if (Bot.HasInHand(CardId.SWSakuya) && !Sakuyaed_2 && !Summoned && (IfFlandre(false, true) <= IfSakuya())) return false;
                if (KoaKuma2() && !ESummoned && ((Duel.Phase == DuelPhase.Main1) || (Duel.Phase == DuelPhase.Main2))
                    && !Bot.HasInSpellZone(CardId.NAMERedDevil, false, true)) return false;  //有待修复
                if (ChainContainsCardByPlayer(CardId.SWIku)) return false;
                if (RDMChainning()) return false;

                if (Bot.HasInSpellZone(CardId.RDMatch, true, true) && (IfFlandre(false, true) < 3)
                    && (GetRDMCountInHand() > 1) && (GetDestroyCountInMZone() <= 1)) return false;
                List<ClientCard> material_list = new List<ClientCard>();
                foreach (ClientCard monster in Bot.GetMonsters())
                {
                    if (HasSetRD(monster) && !monster.IsExtraCard())
                    {
                        material_list.Add(monster);
                    }
                }
                List<ClientCard> material_list4 = new List<ClientCard>();
                foreach (ClientCard spell in Bot.GetSpells())
                {
                    if (HasSetRD(spell) && spell.IsFaceup())
                    {
                        material_list4.Add(spell);
                    }
                }
                contact2list(material_list, material_list4);
                if (material_list.Count == 0) return false;
                SortByValue(material_list, 0, material_list.Count - 1, 2, true);
                AI.SelectCard(material_list[0]);
                Meilined = true;
                return true;
            }
            if (Card.Location == CardLocation.MonsterZone)
            {
                int seq = Card.Sequence;
                Logger.DebugWriteLine("当前美铃所在纵列是" + seq.ToString());
                if (FlandreInt(seq, false, true) >= 0) return true;
            }
            return false;
        }

        private bool KandS_GirlEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.KandS_Girl, 0))
            {
                foreach (ClientCard monster in Bot.GetMonsters())
                {
                    if ((monster.Attack >= 2200) || monster.HasType(CardType.Fusion)
                        || monster.HasType(CardType.Synchro) || monster.HasType(CardType.Xyz) || (monster.HasType(CardType.Link) && monster.LinkCount > 1)) return true;
                }
            }
            bool pay = (ActivateDescription == -1) && Util.ChainContainsCard(CardId.KandS_Girl) && (Duel.Player == 0);
            if ((ActivateDescription == -1) || (ActivateDescription == Util.GetStringId(CardId.KandS_Girl, 1)) && !pay)
            {
                //Logger.DebugWriteLine("进了2");
                AI.SelectCard(CardId.RDMatch);
                return true;
            }
            if ((ActivateDescription == -1) || (ActivateDescription == 0))
            {
                List<int> cardids = new List<int>();
                cardids.Add(CardId.Cranberry_Trap);
                cardids.Add(CardId.FoK);
                cardids.Add(CardId.RDFlandre);
                cardids.Add(CardId.Past_Clock);
                SortByValueId(cardids, 0, cardids.Count - 1, 0);
                AI.SelectCard(cardids[cardids.Count - 1]);
                if (ChainContainsCardByPlayer(CardId.KandS_Girl)) { Logger.DebugWriteLine("进了"); AI.SelectNextCard(CardId.RDMatch); return true; }
                return true;
            }
            return false;
        }

        private bool SL_RemiliaEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.SL_Remilia, 0))
            {
                int count = 0;
                foreach (ClientCard sdCard in Enemy.GetMonsters())
                {
                    if (sdCard.Controller == 1) count += 1;
                } 
                foreach (ClientCard sdCard in Enemy.GetSpells())
                {
                    if (sdCard.Controller == 1 && sdCard.IsFaceup()) count += 1;
                }
                if (count > 0 && (GetCountInDeck2(CardId.SL_Sakuya, 1) > 0))
                {
                    Logger.DebugWriteLine("蕾米2测试a" + count);
                    AI.SelectCard(Card.Overlays[0]); AI.SelectNextCard(CardId.SL_Sakuya);
                    return true;
                }
                Logger.DebugWriteLine("蕾米2测试q" + Card.Overlays[0]);
                if (Bot.HasInExtra(CardId.SL_Reimu)) { AI.SelectCard(Card.Overlays[0]); AI.SelectNextCard(CardId.SL_Reimu); return true; }
                if (Bot.HasInExtra(CardId.SL_Marisa)) { AI.SelectCard(Card.Overlays[0]); AI.SelectNextCard(CardId.SL_Marisa); return true; }
                Logger.DebugWriteLine("蕾米2测试w" + Bot.HasInExtra(CardId.KandS_Girl));
                AI.SelectCard(Card.Overlays[0]); AI.SelectNextCard(CardId.KandS_Girl);
                return true;
            }
            return true;
        }

        private bool SL_SakuyaEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.SL_Sakuya, 1))
            {
                ClientCard TargetC = Enemy.MonsterZone.GetHighestAttackMonster();
                if (TargetC != null)
                {
                    AI.SelectCard(TargetC);
                    return true;
                }
                foreach (ClientCard sdCard in Enemy.GetSpells())
                {
                    if (sdCard.Controller == 1 && !sdCard.HasSetcode(0x814))
                    {
                        AI.SelectCard(sdCard);
                        return true;
                    }
                }
                return false;
            }
            return true;
        }


        private bool WSynRanEffect()
        {
            ClientCard TargetC = Util.GetLastChainCard();
            if (Duel.LastChainPlayer == 1)
            {
                if (TargetC.HasType(CardType.Monster) && TargetC.Attack <= 1200 && !IsShouKen(TargetC)) return false;
                return true;
            }
            return false;
        }

        private bool MKIIEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.MKII, 2))
            {
                List<ClientCard> material_list = new List<ClientCard>();
                foreach (ClientCard monster in Bot.GetMonsters())
                {
                    if (monster.HasType(CardType.Xyz) && monster.IsFaceup() && Bot.MonsterZone.ContainsMonsterWithLevel(monster.Rank))
                    {
                        material_list.Add(monster);
                    }
                }
                if (material_list.Count < 1) return false;
                foreach (ClientCard monster2 in material_list)
                {
                    if (monster2.Rank == 9)
                    {
                        AI.SelectCard(monster2);
                        return true;
                    }
                }
                foreach (ClientCard monster2 in material_list)
                {
                    if (monster2.Rank == 8)
                    {
                        AI.SelectCard(monster2);
                        return true;
                    }
                }
                AI.SelectCard(material_list);
                return true;
            }
            if (ActivateDescription == Util.GetStringId(CardId.MKII, 0))
            {
                ClientCard CardA = null;
                int level = 5;
                foreach (ClientCard g2 in Bot.GetGraveyardMonsters())
                {
                    if (g2.IsMonster() && (g2.Level > level)) { level = g2.Level; CardA = g2; }
                }
                if (CardA != null)
                {
                    AI.SelectCard(CardA);
                    return true;
                }

            }
            return false;
        }

        private bool ScarletWeatherJudge()
        {
            bool pay = false;
            bool pay_2 = false;
            foreach (ClientCard monster2 in Bot.GetMonsters())
            {
                if (monster2.Rank == 9 && monster2.IsFaceup()) pay_2 = true;
            }
            List<ClientCard> material_list = new List<ClientCard>();
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if ((monster.Level == 9 && monster.IsFaceup() && (monster.Id != CardId.KandS_Girl)) || (Bot.HasInMonstersZone(CardId.MKII) && pay_2)) pay = true;
                if ((monster.Level == 7 && monster.IsFaceup()) && monster.HasSetcode(0xae6))
                {
                    material_list.Add(monster);
                }
            }
            return pay && (material_list.Count > 0);
        }
        private bool ScarletWeatherEffect()
        {
            //int zone = Bot.GetLinkedZones();
            //string str = zone.ToString();
            //Logger.DebugWriteLine(str);
            if (ActivateDescription == Util.GetStringId(CardId.ScarletWeather, 0))
            {

                List<ClientCard> material_list = new List<ClientCard>();
                foreach (ClientCard card in Bot.Hand)
                {
                    if ((GetValueByCard(card, 1, true, 1) < 14))
                    {
                        material_list.Add(card);
                    }
                }

                SortByValue(material_list, 0, material_list.Count - 1, 1);
                List<int> cardids = new List<int>();
                cardids.Add(CardId.SWMeilin);
                cardids.Add(CardId.SWPatchouli);
                cardids.Add(CardId.SWIku);
                cardids.Add(CardId.SWRemilia);
                cardids.Add(CardId.SWSakuya);
                SortByValueId(cardids, 0, cardids.Count - 1, 0);
                if (material_list.Count < 1) return false;
                if (cardids.Count < 1) return false;
                if (((!Sakuyaed || (Bot.HasInMonstersZone(CardId.SWIku, true, false, true) && !Ikued)) && !RDMaided && !Sakuyaed_2) || !Meilined)
                {
                    AI.SelectCard(material_list[0]);
                    AI.SelectNextCard(cardids[cardids.Count - 1]);
                    SWed = true;
                    return true;
                }
                return false;//检索先不做
            }
            if (ActivateDescription == Util.GetStringId(CardId.ScarletWeather, 1))
            {
                bool pay = false;
                bool pay_2 = false;
                foreach (ClientCard monster2 in Bot.GetMonsters())
                {
                    if (monster2.Rank == 9 && monster2.IsFaceup()) pay_2 = true;
                }
                List<ClientCard> material_list = new List<ClientCard>();
                foreach (ClientCard monster in Bot.GetMonsters())
                {
                    if ((monster.Level == 9 && monster.IsFaceup() && (monster.Id != CardId.KandS_Girl)) || (Bot.HasInMonstersZone(CardId.MKII) && pay_2)) pay = true;
                    if ((monster.Level == 7 && monster.IsFaceup()) && monster.HasSetcode(0xae6))
                    {
                        material_list.Add(monster);
                    }
                }
                if (ScarletWeatherJudge())
                {
                    AI.SelectCard(material_list);
                    //Logger.DebugWriteLine("测试3");
                    SWed2 = true;
                    return true;
                }
                if (Bot.HasInMonstersZone(CardId.SWIku, false, false, true)) { AI.SelectCard(CardId.SWIku); SWed2 = true; return true; }
                return false;//检索先不做
            }
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.HasInSpellZone(CardId.Mist_Lake) && Bot.HasInGraveyard(CardId.RDMaid)) return false;
                return true;
            }
            return false;
        }

        protected bool Scarlet_GensokyoEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Scarlet_Gensokyo, 1))
            {
                List<ClientCard> material_list = new List<ClientCard>();

                foreach (ClientCard cardQ in Bot.Graveyard)
                {
                    if ((cardQ.HasType(CardType.Spell) || cardQ.HasType(CardType.Trap)) 
                        || (!cardQ.IsExtraCard() && !(cardQ.HasSetcode(0x813) && Bot.GetCountCardInZone(Bot.Graveyard, cardQ.Id) == 1))
                        || (cardQ.IsExtraCard() && !(cardQ.IsCode(CardId.KandS_Girl) && Bot.HasInExtra(CardId.KandS_Girl))))
                        material_list.Add(cardQ);
                }
                if (material_list.Count > 4)
                {
                    AI.SelectCard(material_list);
                    return true;
                }
                return false;
            }
            else
            {
                if (RDMChainning()) return false;
                DoNotChain = true;
                Logger.WriteLine("所有的一切，都将永远被映照这轮红月之下。");
                return true;
            }

        }

        protected bool RDKoakumaEffect()
        {
            if (Card.Location == CardLocation.MonsterZone && (Duel.Player == 1))
            {
                if (ChainContainsCardByPlayer(CardId.Rikako)) return false;
                return true;
            }
            if (Card.Location == CardLocation.Grave)
            {
                KoakumaedSummoned = true;
                return true;
            }
            return false;
        }

        protected bool Cranberry_TrapEffect()
        {
            IList<ClientCard> LSC = Duel.LastSummonedCards;

            if ((LSC.Count == 0)) return false;
            Logger.DebugWriteLine("红梅测试 " + LSC[0].Name + " " + Duel.LastChainPlayer + " " + Duel.LastSummonPlayer + " " + LSC[0].Controller);
            if (ChainContainsCardByPlayer(CardId.MKII)) return false;
            if ((LSC[0].Id == CardId.SWSakuya) && (LSC[0].Controller == 0) && (!Sakuyaed || RDMChainning())) return false;
            if ((LSC[0].Id == CardId.SWMeilin) && (LSC[0].Controller == 0) && (!Meilined || RDMChainning())) return false;
            if ((LSC[0].Id == CardId.SWPatchouli) && (LSC[0].Controller == 0)) return false;
            if ((LSC[0].Id == CardId.SWRemilia) && (LSC[0].Controller == 0)) return false;
            if ((LSC[0].Id == CardId.RDFlandre) && (LSC[0].Controller == 0) && (!Flandred || RDMChainning())) return false;
            if ((LSC[0].Id == CardId.RDMaid) && (LSC[0].Controller == 0) && (!RDMaided || RDMChainning())) return false;

            if (((LSC[0].Id == CardId.SWIku) || (LSC[0].Id == CardId.FoK) || (LSC[0].Id == CardId.Past_Clock) || (LSC[0].Id == CardId.Cranberry_Trap)) && (Duel.LastSummonPlayer == 0)) return false;
            if (LSC[0].Attack >= 2000 && (LSC[0].Controller == 0)) return false;
            if (GetDestroyCountInHand() >= 0 && GetRDMCountInMZone() > 0) return true;
            if ((LSC[0].Controller != 0) && LSC[0].Attack >= 2100) return true;
            return false;
        }
         
        protected bool MKIISummon()
        {
            IList<ClientCard> material_list = new List<ClientCard>();
            bool pay = false;
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if (monster.IsExtraCard())
                {
                    if ((monster.Level == 9) && monster.IsFaceup())
                    {
                        foreach (ClientCard g2 in Bot.GetGraveyardMonsters())
                        {
                            if (g2.IsMonster() && (g2.Level == 9)) { material_list.Add(monster); break; }
                        }
                        break;
                    }
                }
            }
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if (monster.IsCode(CardId.Rikako)) { material_list.Add(monster); pay = true; break; }
            }
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if (((GetValueByCard(monster, 2, false, 1) < 10) || pay) && monster.IsFaceup() && !IsAdvancedRDM(monster) && !monster.IsExtraCard())
                {
                    material_list.Add(monster);
                }
            }

            int ECount = 0;
            foreach (ClientCard g in Bot.GetGraveyardMonsters())
            {
                int ECountB = ECount;
                if (g.IsMonster())
                {
                    foreach (ClientCard g2 in Bot.GetGraveyardMonsters())
                    {
                        if (g2.IsMonster() && (g2.Level == g.Level) && (g2.Level >= 4)) ECountB += 1;
                    }
                    foreach (ClientCard gx in Bot.GetMonsters())
                    {
                        if (gx.IsMonster() && (gx.Level == g.Level) && (gx.Level >= 4)) ECountB += 1;
                    }
                    if (ECountB > ECount) ECount = ECountB;
                }
            }
            if (ECount < 2) return false;
            if (material_list.Count < 3 && !pay) return false;
            if ((Bot.MonsterZone[5] != null) && (Bot.MonsterZone[6] != null)) return false;
            AI.SelectMaterials(material_list);
            if (!BotHasLinkMonster() && ThisSeqHasPachi(5) && ThisSeqHasPachi(6)) return false;
            EXSelectZoneWithoutPachi(CardId.MKII);
            return true;
        } 
        protected bool KandS_GirlSpSummon()
        { 
            List<ClientCard> material_list = new List<ClientCard>();
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if ((GetValueByCard(monster, 2, false, 1) < 10) && monster.IsFaceup() && !monster.IsExtraCard())
                    material_list.Add(monster);
            } 
            if (material_list.Count < 2) return false;
            SortByValue(material_list, 0, material_list.Count - 1, 2);
            IList<ClientCard> material_list2 = material_list;
            AI.SelectMaterials(material_list2); 
            if (!ThisSeqHasPachi(0))
            {
                AI.SelectPlace(Zones.z5);
            }
            PaoChed = true;
            return true;
        }
        protected bool SL_ReimuSpSummon()
        {
            PaoChed = true;
            return true;
        }
        protected bool SLMarisaSpSummon()
        {
            List<ClientCard> material_list = new List<ClientCard>();
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if ((GetValueByCard(monster, 2, false, 1) < 10) && monster.IsFaceup() && !monster.IsExtraCard() && monster.HasType(CardType.Tuner))
                    { material_list.Add(monster); break; }
            }
            if (material_list.Count < 1) return false;
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if ((GetValueByCard(monster, 2, false, 1) < 10) && monster.IsFaceup() && !monster.IsExtraCard() && (monster.Level - material_list[0].Level == 7))
                { material_list.Add(monster); break; }
            }
            if (material_list.Count < 2) return false;
            SortByValue(material_list, 0, material_list.Count - 1, 2);
            IList<ClientCard> material_list2 = material_list;
            PRINT("素材的排序结果XXXXXXXXXXXXXXXX ", material_list2);
            AI.SelectMaterials(material_list2);
            if (!ThisSeqHasPachi(0))
            {
                AI.SelectPlace(Zones.z5);
            }
            PaoChed = true;
            return true;
        }
        protected bool SL_SakuyaSpSummon()
        {
            if (Bot.HasInSpellZone(CardId.ScarletWeather) && !SWed2 && (Bot.HasInMonstersZone(CardId.SWIku, false, false, true) || ScarletWeatherJudge())) return false; 
            int count = 0;
            foreach (ClientCard sdCard in Enemy.GetMonsters())
            {
                if (sdCard.Controller == 1) count += 1;
            } 
            foreach (ClientCard sdCard in Enemy.GetSpells())
            {
                if (sdCard.Controller == 1 && !sdCard.HasSetcode(0x814)) count += 1;
            }
            if (count < 2) return false;
            if (Duel.Turn == 1) return false;
            List<ClientCard> material_list = new List<ClientCard>();
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if ((GetValueByCard(monster, 2, false, 1) < 10) && monster.IsFaceup() && !monster.IsExtraCard())
                    material_list.Add(monster);
            }
            if (material_list.Count < 2) return false;
            SortByValue(material_list, 0, material_list.Count - 1, 2);
            IList<ClientCard> material_list2 = material_list;
            if (material_list.Count < 2) return false;
            AI.SelectMaterials(material_list2);
            if (!ThisSeqHasPachi(0))
            {
                AI.SelectPlace(Zones.z5);
            }
            PaoChed = true;
            return true;
        }

        protected bool RikakoSpSummon()
        {
            PaoChed = true;
            foreach (ClientCard monster in Enemy.GetMonsters())
            {
                if (monster.Attack > 2000 && GetSynMoster().Count > 0) return false;
            }
            if (Bot.HasInSpellZone(CardId.ScarletWeather) && !SWed2 && (Bot.HasInMonstersZone(CardId.SWIku, false, false, true) || ScarletWeatherJudge())) return false;

            bool first = (GetCountInDeck(CardId.SWRemilia, SWRemiliaCount) > 0 || Bot.HasInGraveyard(CardId.SWRemilia)) && Bot.HasInExtra(CardId.MKII);

            List<ClientCard> material_list = new List<ClientCard>();
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if (((GetValueByCard(monster, 2, false, 1) < 10) || (monster.Level == 9 && first)) && monster.IsFaceup() && !monster.IsExtraCard())
                    material_list.Add(monster);
            }
            if (material_list.Count < 2) return false;

            List<ClientCard> material_list4 = new List<ClientCard>();
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if (!monster.IsExtraCard() && (monster.Level == 9) && !monster.IsCode(CardId.Scarlet_Overlay))
                    material_list4.Add(monster);
            }
            if (material_list.Count < 2) return false;
            if (material_list4.Count == 1 && GetMosterByRank(9, false).Count == 2) return false;


            Logger.DebugWriteLine("里香子调试中");
            List<ClientCard> material_list0 = Bot.GetGraveyardMonsters();
            contact2list(material_list0, Bot.GetMonsters());
            SortByValue(material_list, 0, material_list.Count - 1, 2);
            IList<ClientCard> material_list2 = material_list;
            if (material_list.Count < 2) return false;
            AI.SelectMaterials(material_list2);
            EXSelectZoneWithoutPachi(CardId.Rikako);
            return true;
        }

        protected bool ReiKoEffect()
        {
            ClientCard Target = Util.GetLastChainCard();
            if (Target != null)
            {

                if (Target.Controller == 1 && Duel.LastChainPlayer == 1 && !Target.HasSetcode(0x814) &&
                    ((Target.Location == CardLocation.MonsterZone) || (Target.Location == CardLocation.SpellZone)))
                {
                    if (Target.HasType(CardType.Monster) && Target.IsFaceup() && !Target.IsDisabled()
                        && (Target.IsExtraCard() || Target.HasType(CardType.Ritual) || Target.Attack > 2000) && Target.HasType(CardType.Effect))
                    {
                        AI.SelectCard(Card.Overlays[0]);
                        AI.SelectNextCard(Target);
                        return true;
                    }
                    if ((Target.HasType(CardType.Spell) || Target.HasType(CardType.Trap)) && Target.IsFaceup() && !Target.IsDisabled())
                    {
                        Logger.DebugWriteLine("雷鼓测试" + Target.Name + " " + Target.Owner + " " + Duel.LastChainPlayer + "  " + Target.Location + " " + Target.Controller);
                        AI.SelectCard(Card.Overlays[0]);
                        AI.SelectNextCard(Target);
                        return true;
                    }
                }
                if (!ChainContainsCardByPlayer(CardId.ReiKo, 0) && !ChainContainsCardByPlayer(CardId.WSynRan, 0))
                {
                    if (Enemy.GetMonsterCount() > 0)
                    {
                        foreach (ClientCard Target2 in Enemy.GetMonsters())
                        {
                            if (Target2.HasType(CardType.Monster) && Target2.IsFaceup() && !Target2.IsDisabled() && ChainContainsCardByPlayer(Target2.Id, 1)
                                && (Target2.IsExtraCard() || Target2.HasType(CardType.Ritual) || Target2.Attack > 2000) && Target2.HasType(CardType.Effect))
                            {
                                AI.SelectCard(Card.Overlays[0]);
                                AI.SelectNextCard(Target2);
                                return true;
                            }
                        }
                    }
                    if (Enemy.GetSpellCount() > 0)
                    {
                        foreach (ClientCard spell in Enemy.GetSpells())
                        {
                            if ((spell.HasType(CardType.Spell) || spell.HasType(CardType.Trap)) && spell.IsFaceup() && !spell.IsDisabled() && ChainContainsCardByPlayer(spell.Id, 1))
                            {
                                AI.SelectCard(Card.Overlays[0]);
                                AI.SelectNextCard(spell);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        protected bool ReiKoSpSummon()
        {
            if (Bot.HasInMonstersZone(CardId.ReiKo, true, true, true) && !Bot.HasInMonstersZone(CardId.ForbiddenWave, true, true, true))
            {
                return false;
            }
            PaoChed = true;
            return true;
        }

        protected bool ForbiddenWaveSpSummon()
        {
            if (Bot.HasInMonstersZone(CardId.ReiKo, true, true, true))
            {
                PaoChed = true;
                return true;
            }
            return false;
        }
        protected bool FoKEffect()
        {
            if (IfFlandre() >= 0 && !ChainContainsCardByPlayer(CardId.RDMaid) && !ChainContainsCardByPlayer(CardId.MKII) && !RDMChainning(true))
            {
                List<int> cardids = new List<int>();
                cardids.Add(CardId.RDFlandre);
                cardids.Add(CardId.Cranberry_Trap);
                cardids.Add(CardId.FoK);
                cardids.Add(CardId.Past_Clock);
                if (ChainContainsCardByPlayer(CardId.SWSakuya))
                { 
                    AI.CleanSelectCards();
                    AI.SelectCard(cardids[0]);
                    AI.SelectNextCard(new[] {
                    CardId.Scarlet_Destiny,
                    CardId.Scarlet_Seance,
                    CardId.Scarlet_Gensokyo
                    });
                    AI.SelectThirdCard(new[] {
                    CardId.Scarlet_Gensokyo,
                    CardId.Scarlet_Seance,
                    CardId.Scarlet_Overlay
                    });
                }
                else
                {
                    AI.SelectCard(cardids[cardids.Count - 1]);
                }
                //SeqtoZone(FlandreShouldinThisSeq());
                return true;
            }
            return false;
        }
        private bool RDMatchEffect2()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.HasInSpellZone(CardId.RDMatch)) return false;
                DoNotChain = true;
                return true;
            }
            return false;
        }
        private bool RDMatchEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                return false;
            }
            if (ActivateDescription == Util.GetStringId(CardId.RDMatch, 0))
            {
                if (Bot.HasInHand(CardId.RDMaid) && !RDMaided) { AI.SelectCard(CardId.RDMaid); return true; }
                if (GetMosterByRank(7, false).Count == 1)
                {
                    if (Bot.HasInHand(CardId.SWMeilin)){ AI.SelectCard(CardId.SWMeilin); return true; }
                    if (Bot.HasInHand(CardId.SWSakuya)) { AI.SelectCard(CardId.SWSakuya); return true; }
                    if (Bot.HasInHand(CardId.RDFlandre)) { AI.SelectCard(CardId.RDFlandre); return true; }
                }
                if (Bot.HasInHand(CardId.SWRemilia)){ AI.SelectCard(CardId.SWRemilia); return true; }
                if (Bot.HasInHand(CardId.SWMeilin) && !(Bot.HasInHand(CardId.SWSakuya) && !Sakuyaed_2)) { AI.SelectCard(CardId.SWMeilin); return true; }
                if (Bot.HasInHand(CardId.SWPatchouli) && FlandreInt(Card.Sequence, true, false) > 3) { AI.SelectCard(CardId.SWPatchouli);  return true; }
                if (Bot.HasInHand(CardId.RDFlandre) && ((IfFlandre(true, false) > 2) || GetRDMCountInGrave() > 0)) { AI.SelectCard(CardId.RDFlandre); return true; }
                if (Bot.HasInHand(CardId.SWPatchouli) && Patchoulied) { AI.SelectCard(CardId.SWPatchouli); return true; }
                if (Bot.HasInHand(CardId.RDKoakuma)) { AI.SelectCard(CardId.RDKoakuma); return true; }
                if (Bot.HasInHand(CardId.SWSakuya) && !(Bot.HasInHand(CardId.SWMeilin)) && !(Bot.HasInHand(CardId.RDFlandre) || IfFlandre() >= 0)) 
                    { AI.SelectCard(CardId.SWSakuya);  return true; }
                return false;
            }
            if(Card.Location == CardLocation.Grave)
            {
                if (Bot.HasInGraveyard(CardId.RDMaid) && !RDMaided) { AI.SelectCard(CardId.RDMaid); return true; }
                if (GetMosterByRank(7, false).Count == 1)
                {
                    if (Bot.HasInGraveyard(CardId.SWMeilin)) { AI.SelectCard(CardId.SWMeilin); return true; }
                    if (Bot.HasInGraveyard(CardId.SWSakuya)) { AI.SelectCard(CardId.SWSakuya); return true; }
                    if (Bot.HasInGraveyard(CardId.RDFlandre)) { AI.SelectCard(CardId.RDFlandre); return true; }
                }
                if (Bot.HasInGraveyard(CardId.SWRemilia)) { AI.SelectCard(CardId.SWRemilia); return true; }
                if (Bot.HasInGraveyard(CardId.SWMeilin) && !(Bot.HasInGraveyard(CardId.SWSakuya) && !Sakuyaed_2)) { AI.SelectCard(CardId.SWMeilin); return true; }
                if (Bot.HasInGraveyard(CardId.SWPatchouli) && FlandreInt(Card.Sequence, true, false) > 3) { AI.SelectCard(CardId.SWPatchouli); return true; }
                if (Bot.HasInGraveyard(CardId.RDFlandre) && ((IfFlandre(true, false) > 2) || GetRDMCountInGrave() > 0)) { AI.SelectCard(CardId.RDFlandre); return true; }
                if (Bot.HasInGraveyard(CardId.SWPatchouli) && Patchoulied) { AI.SelectCard(CardId.SWPatchouli); return true; }
                if (Bot.HasInGraveyard(CardId.RDKoakuma)) { AI.SelectCard(CardId.RDKoakuma); return true; }
                if (Bot.HasInGraveyard(CardId.SWSakuya) && !(Bot.HasInGraveyard(CardId.SWMeilin)) && !(Bot.HasInGraveyard(CardId.RDFlandre) || IfFlandre() >= 0))
                { AI.SelectCard(CardId.SWSakuya); return true; }
                return true;
            }
            if (Bot.HasInHand(CardId.Red_Magic)) return true;
            return false;
        }

        private bool SWSakuyaEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                return true;
            }
            if (Card.Location == CardLocation.MonsterZone && (ActivateDescription == -1 || ActivateDescription == Util.GetStringId(CardId.SWSakuya, 1)))
            {
                if (Bot.HasInHandOrInSpellZone(CardId.Scarlet_Destiny))
                {
                    AI.SelectCard(new[] {
                    CardId.Scarlet_Gensokyo,
                    CardId.Scarlet_Seance,
                    CardId.Scarlet_Destiny
                    });
                }
                else
                {
                    AI.SelectCard(new[] {
                    CardId.Scarlet_Destiny,
                    CardId.Scarlet_Seance,
                    CardId.Scarlet_Gensokyo
                    });
                }
                AI.SelectNextCard(new[] {
                CardId.Scarlet_Seance,
                CardId.Scarlet_Overlay,
                CardId.Scarlet_Gensokyo
                });
                Sakuyaed_2 = true;
                return true;
            }
            if (Card.Location == CardLocation.Hand)
            {
                if (Card.Level == 11) return false;
                if (DoNotChain && Duel.Player == 0) return false;
                if (Bot.HasInHand(CardId.NAMERedDevil) && !NAMERedDeviled && (GetDestroyCountInMZone() < 2) && GetFaceupMZone() > 0) return false;

                if (Bot.HasInSpellZone(CardId.NAMERedDevil) && !NAMERedDeviled2 && GetFaceupMZone() > 0) return false;
                //if (KoaKuma2()) Logger.DebugWriteLine("可以召唤的场合先召唤再发效果 调试1");
                //if (!ESummoned) Logger.DebugWriteLine("可以召唤的场合先召唤再发效果 调试2");

                if (Bot.HasInHand(CardId.RDKoakuma) && !Summoned) return false;
                if (KoaKuma2() && !ESummoned && ((Duel.Phase == DuelPhase.Main1) || (Duel.Phase == DuelPhase.Main2))
                        && !Bot.HasInSpellZone(CardId.NAMERedDevil, false, true)) return false;
                if (Bot.HasInHand(CardId.RDHouse) && ((Duel.Phase == DuelPhase.Main1) || (Duel.Phase == DuelPhase.Main2)) && !RDHoused) return false;
                if (Bot.HasInHand(CardId.RDMatch) && ((Duel.Phase == DuelPhase.Main1) || (Duel.Phase == DuelPhase.Main2)) && !PaoChed) return false;
                if (Bot.HasInSpellZone(CardId.SWPatchouli) && !Patchoulied_2 && Bot.Hand.GetMonsters().Count > 1 && !Bot.HasInHand(CardId.SWMeilin)
                        && !Summoned) return false;
                if (Bot.HasInSpellZone(CardId.RDMatch) && (Bot.HasInHand(CardId.RDFlandre)) && !Flandred && GetRDMCountInGrave() > 0
                    && ((Duel.Phase == DuelPhase.Main1) || (Duel.Phase == DuelPhase.Main2)) && !PaoChed) return false;
                if (Util.ChainContainsCard(CardId.RDMatch)) return false;
                List<ClientCard> material_list = new List<ClientCard>();
                foreach (ClientCard monster in Bot.GetMonsters())
                {
                    if (HasSetRD(monster) && !monster.IsExtraCard())
                    {
                        material_list.Add(monster);
                    }
                }
                List<ClientCard> material_list4 = new List<ClientCard>();
                foreach (ClientCard spell in Bot.GetSpells())
                {
                    if (HasSetRD(spell) && spell.IsFaceup())
                    {
                        material_list4.Add(spell);
                    }
                }
                contact2list(material_list, material_list4);
                if (ChainContainsCardByPlayer(CardId.SWIku)) return false;
                if (material_list.Count == 0) return false;
                SortByValue(material_list, 0, material_list.Count - 1, 2, true);
                if (Bot.HasInHand(CardId.RDFlandre) && (IfFlandre() > IfSakuya()) && !Flandred) return false;
                if (Bot.HasInHand(CardId.SWMeilin) && (IfFlandre(false, true) > IfSakuya()) && !Meilined) return false;
                if (Bot.HasInHand(CardId.SWPatchouli) && (IfFlandre(true, false) > IfSakuya()) && !Patchoulied) return false;
                bool pay = !RDMChainning();
                if (pay)
                {
                    AI.SelectCard(material_list[0]);
                    //if (Util.GetLastChainCard() != null) Logger.DebugWriteLine(Util.GetLastChainCard().Name);
                    Sakuyaed = true;
                    return true;
                }
                return false;
            }
            return false;
        }

        private bool Red_MagicEffect()
        {
            if (!RDMChainning())
            {
                bool pay = false;
                List<ClientCard> material_list = new List<ClientCard>();
                material_list = ToRDFlandreEffect(material_list);
                if (DoNotChain && Duel.Player == 0) return false;
                if ((Bot.HasInHand(CardId.ScarletWeather) || Bot.HasInSpellZone(CardId.ScarletWeather)) && !SWed && Bot.GetHandCount() > 1) return false; 
                if (Bot.HasInHand(CardId.SWSakuya) && !Sakuyaed && !Sakuyaed_2) return false;
                if (Bot.HasInHand(CardId.RDMatch) && (Bot.GetCountCardInZone(Bot.GetSpells(), CardId.RDMatch) == 0)) return false;
                if (Bot.HasInHand(CardId.SWMeilin) && !Meilined && ((IfFlandre(false, true) > 3) || ((IfFlandre(false, true) > 0) && IfScarlet()))) return false;
                if (Bot.HasInHand(CardId.RDFlandre) && !Flandred && (material_list.Count > 0) && (IfFlandre() > 0)) return false;
                if (Bot.HasInHand(CardId.NAMERedDevil) && !NAMERedDeviled && (GetDestroyCountInMZone() < 2) && GetFaceupMZone() > 0) return false;
                if (Bot.HasInSpellZone(CardId.NAMERedDevil) && !NAMERedDeviled2 && GetFaceupMZone() > 0) return false;
                Logger.DebugWriteLine("红魔法测试1" + NAMERedDeviled + GetDestroyCountInMZone());
                if (needDestroyRD() || (GetRDMCountInMZone(false, true, false) == 1)) { Logger.DebugWriteLine("红魔法测试1"); pay = true; }


                //if (KoaKuma2()) Logger.DebugWriteLine("可以召唤的场合先召唤再发效果 调试1");
                //if (!ESummoned) Logger.DebugWriteLine("可以召唤的场合先召唤再发效果 调试2");

                if (KoaKuma2() && !ESummoned && ((Duel.Phase == DuelPhase.Main1) || (Duel.Phase == DuelPhase.Main2))
                        && (GetDestroyCountInSpellZone() < 1)
                        && GetRDMCountInHand(true, false, 1) > 0) return false;

                List<ClientCard> material_list4 = new List<ClientCard>();
                foreach (ClientCard spell in Bot.GetSpells())
                {
                    if (HasSetRD(spell) && spell.IsFaceup())
                    {
                        material_list4.Add(spell);
                    }
                }
                SortByValue(material_list4, 0, material_list4.Count - 1, 2, true);
                if ((material_list4.Count > 0) && GetValueByCard(material_list4[0], 2, true, 0) < 8) { Logger.DebugWriteLine("红魔法测试2"); pay = true; }
                if (needDestroyRD() || (GetRDMCountInMZone(false, true, false) == 1)) { Logger.DebugWriteLine("红魔法测试3"); pay = true; }
                if (pay && Red_MagicEffectSelect(ActivateDescription)) { Red_Magiced = true; return true; }
                if (GetFaceupMZone() == 1)
                {
                    pay = true;
                    if (Bot.HasInMonstersZone(CardId.RDKoakuma, true, false) && ((GetRDMCountInHand() > 1) || ((GetRDMCountInHand() == 1) && !Bot.HasInHand(CardId.SWRemilia)) && Duel.Phase != DuelPhase.Main2)) pay = false;
                    if (Bot.HasInSpellZone(CardId.Scarlet_Destiny) && !Bot.HasInSpellZone(CardId.Scarlet_Destiny, false, true)) pay = false;
                    Logger.DebugWriteLine("红魔法测试4");
                    if (pay && Red_MagicEffectSelect(ActivateDescription)) { Red_Magiced = true; return true; }
                }
                if (GetFaceupMZone() >= 2)
                {
                    if (GetFaceupMZone() == 2)
                    {
                        if (GetSynMoster().Count > 0) return false;
                    }
                    pay = true;
                    List<ClientCard> material_list2 = new List<ClientCard>();
                    List<ClientCard> material_list6 = new List<ClientCard>();
                    foreach (ClientCard monster in Bot.GetMonsters())
                    {
                        if (HasSetRD(monster) && (monster.Level > 4) && !monster.IsExtraCard() && monster.IsFaceup())
                        {
                            material_list2.Add(monster);
                        }
                    }

                    foreach (ClientCard monster in Bot.GetMonsters())
                    {
                        if (HasSetRD(monster) && (monster.Level < 3) && !monster.HasType(CardType.Xyz))
                        {
                            material_list6.Add(monster);
                        }
                    }
                    foreach (ClientCard spell in Bot.GetSpells())
                    {
                        if (HasSetRD(spell))
                        {
                            material_list6.Add(spell);
                        }
                    }
                    Logger.DebugWriteLine("红魔法测试5");
                    if ((material_list2.Count == GetFaceupMZone()) && Bot.HasInExtra(CardId.Rikako)) return false;
                    if ((GetFaceupMZone() == 3) && Bot.HasInExtra(CardId.MKII) && material_list6.Count == 0) return false;
                    if ((GetFaceupMZone() - GetMosterByRank(7, false).Count) == 0 && (GetMosterByRank(7).Count > 0) && IfBotCanSpSummon() && (Duel.Player == 0)) return false;
                    if ((GetFaceupMZone() - GetMosterByRank(9, false).Count) == 0 && (GetMosterByRank(9).Count > 0) && IfBotCanSpSummon() && (Duel.Player == 0)) return false;
                    if (pay && Red_MagicEffectSelect(ActivateDescription)) { Red_Magiced = true; return true; }
                }
                return false;
            }
            return false;
        }
        private bool Red_MagicEffectSelect(long descript)
        {
            bool pay_sakuya = ((GetCountInDeck(CardId.SWSakuya, 2) != 0) && (GetCountInDeck(CardId.Scarlet_Destiny, Scarlet_DestinyCount) != 0)) || (Bot.HasInGraveyard(CardId.SWSakuya) && (GetCountInDeck(CardId.Scarlet_Seance, 2) != 0));
            bool pay_meilin = ((GetCountInDeck(CardId.SWMeilin, 2) != 0) && (GetCountInDeck(CardId.Scarlet_Destiny, Scarlet_DestinyCount) != 0)) || (Bot.HasInGraveyard(CardId.SWMeilin) && (GetCountInDeck(CardId.Scarlet_Seance, 2) != 0));
            bool pay = (GetRDMCountInMZone(false, true, false) > 1) && IfBotCanSpSummon() && pay_sakuya && !Sakuyaed_2 && (IfSakuya() > 5);
            bool pay2 = (GetRDMCountInMZone(false, true, false) > 1) && IfBotCanSpSummon() && pay_meilin && (IfFlandre(false, true) > 5);
            bool pay3 = GetExtraMInMZone() == 0 && (GetDestroyCountInMZone() > 1) && (GetCountInDeck(CardId.Scarlet_Destiny, 1) != 0) && !Destinyed;
            bool pay4 = (Bot.GetMonsterCount() == 0 || (GetDestroyCountInSpellZone() == 0 && Bot.GetMonsterCount() == 1))
                && (GetRDMCountInHand() > 0 && !Bot.HasInHandOrInSpellZone(CardId.RDMatch)
                && !(Bot.HasInHand(CardId.RDKoakuma) && !Summoned) && !(Bot.HasInHand(CardId.RDMaid) && !Summoned));
            if (descript == Util.GetStringId(CardId.Red_Magic, 1) && (pay || pay2 || pay3 || pay4) && (!Bot.HasInHandOrInSpellZone(CardId.Scarlet_Destiny)))
            {
                return Red_MagicEffectSelect2(descript); //发检索效果
            }
            if (descript == Util.GetStringId(CardId.Red_Magic, 0) && !((pay || pay2 || pay3 || pay4) && (!Bot.HasInHandOrInSpellZone(CardId.Scarlet_Destiny))))
            {; return Red_MagicEffectSelect2(descript); } //发第抽两张效果
            return false;
        }
        private bool Red_MagicEffectSelect2(long descript)
        {
            List<ClientCard> material_list4 = new List<ClientCard>();
            foreach (ClientCard spell in Bot.GetSpells())
            {
                if (HasSetRD(spell) && spell.IsFaceup())
                {
                    material_list4.Add(spell);
                }
            }
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if (HasSetRD(monster) && monster.IsFaceup())
                {
                    material_list4.Add(monster);
                }
            }
            SortByValue(material_list4, 0, material_list4.Count - 1, 2, true);
            if (material_list4.Count < 1) return false;
            Logger.DebugWriteLine("红魔法测试X " + GetValueByCard(material_list4[0], 2, true));
            if (GetValueByCard(material_list4[0], 2, true) > 9) return false;


            bool pay4 = (Bot.GetMonsterCount() == 0 || (GetDestroyCountInSpellZone() == 0 && Bot.GetMonsterCount() == 1))
                && (GetRDMCountInHand() > 0 && !Bot.HasInHandOrInSpellZone(CardId.RDMatch)
                && !(Bot.HasInHand(CardId.RDKoakuma) && !Summoned) && !(Bot.HasInHand(CardId.RDMaid) && !Summoned));
            AI.SelectCard(material_list4[0]);
            if (pay4 && descript == Util.GetStringId(CardId.Red_Magic, 1))
            {
                AI.SelectNextCard(CardId.Scarlet_Seance);
                Logger.DebugWriteLine("红魔法测试6 ");
                Logger.WriteLine("让本小姐给你展示真正的魔法吧！");
                return true;
            }

            if (descript == Util.GetStringId(CardId.Red_Magic, 1))
            {
                AI.SelectNextCard(new[] {
                CardId.Scarlet_Destiny,
                CardId.Scarlet_Seance,
                CardId.Scarlet_Gensokyo
                });
            }
            Logger.WriteLine("让本小姐给你展示真正的魔法吧！");
            return true;
        }
        private bool SWPatchouliEffect()
        {
            if (Card.Location == CardLocation.Hand && ((ActivateDescription == -1) || (ActivateDescription == Util.GetStringId(CardId.SWPatchouli, 2))) && !RDMChainning())
            {
                if (DoNotChain && Duel.Player == 0) return false;
                if (Card.Level == 11) return false;
                int value_K = IfFlandre(true, false);
                if (value_K < 2 && (GetMosterByRank2().Count > 0 || GetSynMoster().Count > 0)) return false;  //从额外先拍怪要紧

                //if (KoaKuma2()) Logger.DebugWriteLine("可以召唤的场合先召唤再发效果 调试1");
                //if (!ESummoned) Logger.DebugWriteLine("可以召唤的场合先召唤再发效果 调试2");

                if (Util.ChainContainsCard(CardId.RDMatch)) return false;
                if (KoaKuma2() && !ESummoned && ((Duel.Phase == DuelPhase.Main1) || (Duel.Phase == DuelPhase.Main2))
                       && !Bot.HasInSpellZone(CardId.NAMERedDevil, false, true)) return false;
                if (Bot.HasInHand(CardId.RDKoakuma) && !Summoned) return false;
                if (Bot.HasInHand(CardId.RDHouse) && ((Duel.Phase == DuelPhase.Main1) || (Duel.Phase == DuelPhase.Main2)) && !RDHoused) return false;
                if (Bot.HasInHand(CardId.RDMatch) && ((Duel.Phase == DuelPhase.Main1) || (Duel.Phase == DuelPhase.Main2)) && !PaoChed) return false;


                List<ClientCard> material_list = new List<ClientCard>();
                foreach (ClientCard monster in Bot.GetMonsters())
                {
                    if (HasSetRD(monster) && (monster.Level < 3) && !monster.HasType(CardType.Xyz) && 
                        (GetValueByCard(monster, 2, true) < 10 || (IfFlandre() > 1 && GetValueByCard(monster, 2, true) < 13)))
                    {
                        material_list.Add(monster);
                    }
                }
                List<ClientCard> material_list4 = new List<ClientCard>();
                foreach (ClientCard spell in Bot.GetSpells())
                {
                    if (HasSetRD(spell) && spell.IsFaceup() && (GetValueByCard(spell, 2, true) < 8 || IfFlandre(true, false) > 2))
                    {
                        material_list4.Add(spell);
                    }
                }
                contact2list(material_list, material_list4);
                if (material_list.Count == 0) return false;

                Logger.DebugWriteLine("帕秋莉测试" + value_K);
                if (Bot.HasInHand(CardId.RDFlandre) && (material_list4.Count == 0) && !Flandred) return false;
                if (Bot.HasInHand(CardId.Red_Magic) && (IfFlandre(true, false) < 2) && !Red_Magiced) return false;
                if (Bot.HasInHand(CardId.SWMeilin) && (material_list4.Count == 0) && !Meilined) return false;
                if (Bot.HasInHand(CardId.SWSakuya) && !Sakuyaed && !Sakuyaed_2 && (IfFlandre(true, false) <= IfSakuya())) return false;
                if (GetExtraMInMZone() > 0 && Bot.HasInGraveyard(CardId.RDKoakuma) && material_list.Count > 0
                    && (Bot.HasInExtra(CardId.KandS_Girl) || Bot.HasInExtra(CardId.SL_Remilia)) && (value_K < 2)) return false; //可以加速同调我就不拍怪，留着做康
                SortByValue(material_list, 0, material_list.Count - 1, 2, true);
                AI.SelectCard(material_list[0]);
                Patchoulied = true;
                return true;
            }
            if (ActivateDescription == 1160) //在灵摆区域发动
            {
                if ((Bot.GetMonsters().Count() == 0 && Bot.Hand.GetMonsters().Count() > 1) || (Bot.Hand.GetMonsters().Count == 1 && GetDestroyCountInHand() > 1))
                {
                    if (Bot.HasInSpellZone(CardId.RDMatch, true, true)) return false;
                    if (Bot.HasInSpellZone(CardId.SWPatchouli, true, true)) return false;

                    Logger.DebugWriteLine("帕秋莉灵摆测试");
                    return true;
                }
            }
            if (Summoned == false
                && Card.Location == CardLocation.SpellZone) //灵摆效果
            {
                List<int> cardids = new List<int>();
                cardids.Add(CardId.RDMaid);
                cardids.Add(CardId.RDKoakuma);
                cardids.Add(CardId.RDFlandre);
                cardids.Add(CardId.SWPatchouli);
                cardids.Add(CardId.SWMeilin);
                cardids.Add(CardId.SWSakuya);
                SortByValueId(cardids, 0, cardids.Count - 1, 0);
                List<ClientCard> material_list = new List<ClientCard>();
                foreach (ClientCard monster in Bot.Hand.GetMonsters())
                {
                    if (GetValueByCard(monster, 1, true, 1) < 13)
                    {
                        material_list.Add(monster);
                    }
                }
                SortByValue(material_list, 0, material_list.Count - 1, 1);
                if (Bot.GetMonsters().Count() == 0 && Bot.Hand.GetMonsters().Count() != 0)
                {
                    AI.SelectCard(material_list[0]);
                    AI.SelectNextCard(cardids[cardids.Count - 1]);
                    Patchoulied_2 = true;
                    return true;
                }
            }
            return false;
        } 
        private bool SWSakuyaSummon()
        {
            if ((GetDestroyCountInHand(Card.Id) < 1) && GetFaceupMZone() == 0) return false; 
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if ((monster.IsSpecialSummoned && !monster.IsExtraCard() && !monster.IsCode(CardId.SWRemilia)) || (!monster.IsSpecialSummoned && monster.Attack < 1800))
                {
                    Summoned = true;
                    ESummoned = true;
                    return true;
                }
            }
            return false;
        }
        private bool SWSakuyaSummonDummy()
        { 
            foreach (ClientCard MonstersCard in Bot.GetMonsters())
            {
                if (MonstersCard.HasPosition(CardPosition.FaceDown)) { return true; }
            }
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if ((monster.IsSpecialSummoned && !monster.IsExtraCard() && !monster.IsCode(CardId.SWRemilia)) || (!monster.IsSpecialSummoned && monster.Attack < 1800))
                { 
                    return true;
                }
            }
            return false;
        }
        protected bool Scarlet_OverlayEffect()
        {
            if (ActivateDescription != Util.GetStringId(CardId.Scarlet_Overlay, 0))
            {
                List<ClientCard> material_list = MRanktoLevel(Bot.GetMonsters(), 8);
                List<ClientCard> material_list2 = MRanktoLevel(Bot.GetMonsters(), 9);
                if (GetSynMoster().Count > 0)
                {
                    ClientCard CardS = GetSynMoster()[0];
                    if (CardS != null) { Logger.DebugWriteLine("绯色叠光测试 " + GetMosterByRank(9, true).Count + " " + CardS.Name); }
                    if (CardS != null && (GetMosterByRank(9, true).Count >= 1) && CardS.Level == 9 && (Duel.Player == 0)) { AI.SelectNumber(9); return true; }
                }
                if ((GetMosterByRank(9).Count > 0) && (GetMosterByRank(9, false).Count == 1) && (material_list2.Count == 1) && (Duel.Player == 0)) { AI.SelectNumber(9); return true; }
                if ((GetMosterByRank(9).Count > 0) && (Bot.GetCountCardInZone(Bot.GetMonsters(), CardId.KandS_Girl) == 2) && (Duel.Player == 0)) { AI.SelectNumber(9); return true; }
                if ((GetMosterByRank(8).Count > 0) && (GetMosterByRank(8, false).Count == 1) && (material_list.Count == 1) && (Duel.Player == 0)) { AI.SelectNumber(8); return true; }

                AI.SelectNumber(7);
                Logger.WriteLine("本小姐一样精通超量世界的术式");
                return true;
            }
            else
            {
                if (Duel.Player == 0) return false;
                if (Duel.LastChainPlayer == 0) return false;
            }
            return true;
        } 
        protected bool RDMaidEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                List<ClientCard> material_list = MRanktoLevel(Bot.GetMonsters(), 8);
                List<ClientCard> material_list2 = MRanktoLevel(Bot.GetMonsters(), 9);
                if ((GetMosterByRank(9).Count > 0) && (GetMosterByRank(9, false).Count == 1) && (material_list2.Count == 1)) { AI.SelectNumber(9); return true; }
                if ((GetMosterByRank(8).Count > 0) && (GetMosterByRank(8, false).Count == 1) && (material_list.Count == 1)) { AI.SelectNumber(8); return true; }
                AI.SelectNumber(7); 
                DoNotChain = true;
                return true;
            }
            Logger.DebugWriteLine("RDMaid测试" + GetCountInDeck(CardId.SWSakuya, 2) + " " + FlandreInt(Card.Sequence, false, true) + " " + IfSakuya());

            if ((GetCountInDeck(CardId.SWSakuya, 2) > 0) && (FlandreInt(Card.Sequence, false, true) < IfSakuya()))
            {
                AI.SelectCard(CardId.SWSakuya);
                if (!Bot.HasInHandOrInSpellZone(CardId.Scarlet_Destiny))
                {
                    AI.SelectNextCard(new[] {
                    CardId.Scarlet_Destiny,
                    CardId.Scarlet_Seance,
                    CardId.Scarlet_Gensokyo
                    });
                }
                else
                {
                    AI.SelectNextCard(new[] {
                    CardId.Scarlet_Gensokyo,
                    CardId.Scarlet_Seance,
                    CardId.Scarlet_Destiny
                    });
                }
                AI.SelectThirdCard(new[] {
                CardId.Scarlet_Seance,
                CardId.Scarlet_Overlay,
                CardId.Scarlet_Gensokyo
                });
                RDMaided = true;
                return true;
            }
            if (GetCountInDeck(CardId.SWRemilia, SWRemiliaCount) > 0 && FlandreInt(Card.Sequence, false, false) > 0
                && (Bot.HasInHand(CardId.Scarlet_Seance) && (GetRDMCountInMZone() == Bot.GetMonsterCount()) || (Bot.HasInHandOrInSpellZone(CardId.RDMatch) && GetDestroyCountInHand() > 0)))
            {
                AI.SelectCard(CardId.SWRemilia);
                RDMaided = true;
                return true;
            }

            if (GetCountInDeck(CardId.SWMeilin, 2) > 0 && FlandreInt(Card.Sequence, false, true) > 3)
            {
                AI.SelectCard(CardId.SWMeilin);
                RDMaided = true;
                return true;
            }

            if (GetCountInDeck(CardId.RDFlandre, 1) > 0 && FlandreInt(Card.Sequence, false, false) > 3)
            {
                AI.SelectCard(CardId.RDFlandre);
                RDMaided = true;
                return true;
            }

            if (GetCountInDeck(CardId.SWPatchouli, 2) > 0
                && (Bot.HasInHand(CardId.Scarlet_Seance) && (GetRDMCountInMZone() == Bot.GetMonsterCount()) || (Bot.HasInHandOrInSpellZone(CardId.RDMatch) && GetDestroyCountInHand() > 0)))
            {
                AI.SelectCard(CardId.SWPatchouli);
                RDMaided = true;
                return true;
            }


            return true;
        }

        private int IfSakuya(int level = 6) //是否应该发动咲夜效果
        {
            if (Sakuyaed_2) level -= 4;
            if (GetSCountInDeck() == 0) level = 0;
            if (GetSCountInDeck() < 4) level -= 2;
            if (ESpellSeq(true, false) == 0) level -= 2;
            if (ESpellSeq(false, false) == 0 || (GetSCountInDeck() == 1)) level -= 1;
            foreach (ClientCard monster in Enemy.GetMonsters())
            {
                if (monster.IsExtraCard() && monster.Attack > 2000) level -= 3;
            }
            if (level < 0) level = 0;
            return level;
        }

        private int IfFlandre(bool Patchouli = false, bool Meilin = false, int seq = -1, bool Empty = false) //是否芙兰朵露，一列中对方卡数量大于2且没自己卡时优先级高于咲夜。 HasSetcode
        {
            int level = 0;
            if (Meilin && Meilined) level -= 3;
            for (int i = 0; i < 5; ++i)
            {
                if (i != seq && (!Empty || Bot.MonsterZone[i] == null))
                {
                    if (!(Meilin && Bot.MonsterZone[i] != null && !Bot.MonsterZone[i].IsFaceup()))
                    {
                        int R_level = FlandreInt(i, Patchouli, Meilin);
                        if (R_level > level) level = R_level;
                    }
                }
            }
            return level;
        }

        private int FlandreInt(int i, bool Patchouli = false, bool Meilin = false) //返回某一纵列的芙兰朵露值，同样用于统计美铃。帕秋莉  
        {
            int R_level = 0;
            if (i > 4) i = 1;
            ClientCard code = Enemy.SpellZone[4 - i];
            ClientCard code2 = Bot.SpellZone[i];
            if (Enemy.MonsterZone[4 - i] != null && !IsImmuneEffec(Enemy.MonsterZone[4 - i])) R_level += 2;
            if (Enemy.MonsterZone[4 - i] != null && Enemy.MonsterZone[4 - i].Attack > 2000 && !IsImmuneEffec(Enemy.MonsterZone[4 - i])) R_level += 2;
            //if (Patchouli) Logger.DebugWriteLine("帕秋莉值测试" + i + " " + R_level);
            if ((Enemy.MonsterZone[4 - i] != null) && Enemy.MonsterZone[4 - i].IsExtraCard() && !IsImmuneEffec(Enemy.MonsterZone[4 - i])) R_level += 1;
            if ((code != null) && Meilin && (!ChainContainsCard2ByPlayer(code, 1)) && code.IsFacedown()) R_level += 1;
            if ((code != null) && (!ChainContainsCard2ByPlayer(code, 1)) && (code.Controller != 0) && Meilin && (!code.IsFacedown()) && code.HasType(CardType.Spell)) R_level -= 2; //美铃不让对面的表侧表示永续魔法弹手
            if ((code != null) && ((code.Controller != 0) || (Meilin && code.IsFacedown()))) R_level += 1;
            if ((code != null) && !Meilin && (code.Controller != 0)) R_level += 1;
            if ((code != null) && Patchouli && ChainContainsCard2ByPlayer(code, 1)) R_level += 3;
            //if (Patchouli) Logger.DebugWriteLine("帕秋莉值测试" + i + " " + R_level);
            if (i == 3)
            {
                if (Enemy.MonsterZone[5] != null && !IsImmuneEffec(Enemy.MonsterZone[5])) R_level += 4;
                if ((Enemy.MonsterZone[5] != null) && (Enemy.MonsterZone[5].Attack >= 2400) && Patchouli && !IsImmuneEffec(Enemy.MonsterZone[5])) R_level += 1;
                if (Bot.MonsterZone[6] != null) R_level -= 7;
            }
            if (i == 1)
            {

                if (Enemy.MonsterZone[6] != null && !IsImmuneEffec(Enemy.MonsterZone[6])) R_level += 4;
                if ((Enemy.MonsterZone[6] != null) && (Enemy.MonsterZone[6].Attack >= 2400) && Patchouli && !IsImmuneEffec(Enemy.MonsterZone[6])) R_level += 1;
                if (Bot.MonsterZone[5] != null) R_level -= 7;
            }
            if (code2 != null)
            {
                if (ChainContainsCard2ByPlayer(code2) && Patchouli) R_level -= 4;
                if (code2.IsCode(CardId.Fever)) R_level -= 2;
                if (code2.IsCode(CardId.Cranberry_Trap))
                {
                    if (!Patchouli && !Meilin) R_level += 4;
                    if (Patchouli) R_level -= 4;
                    if (Meilin) R_level -= 1;
                }
                else
                {
                    if (!ChainContainsCard2ByPlayer(code2) && !Meilin) R_level -= 4;
                    if (code2.IsFaceup() && !Meilin) R_level -= 2;
                    if (Meilin && !code2.IsCode(CardId.Fever))
                    {
                        R_level += 1;
                        if (Meilin && IfScarlet()) R_level += 2;
                    }
                }
            }
            //if (Patchouli) Logger.DebugWriteLine("帕秋莉值测试" + i + " " + R_level);
            if (Enemy.MonsterZone[4 - i] != null && ThisSeqHasPachi(i)) R_level = 0;
            //if (Meilin) Logger.DebugWriteLine(i.ToString() + "纵列的美铃值是" + R_level.ToString());
            return R_level;
        }

        private int ESpellSeq(bool Sakuya = false, bool Remilia = false)//返回是否有一怪兽纵列其包含空余魔陷格子 
        {
            int count = 0;
            for (int i = 0; i < 5; ++i)
            {
                if (EOneMSeq(i, true, true, false, false) && Sakuya) count += 1; //弱咲夜型
                if (EOneMSeq(i, true, false, true) && Remilia) count += 1; //蕾米型
                if (EOneMSeq(i, true, true, false) && !Sakuya && !Remilia) count += 1; //强咲夜型
            }
            return count;
        }

        private int SakuyaShouldinThisSeq() //返回一个应该咲夜的纵列
        {
            if (EOneMSeq(4, true, true, false) && Bot.MonsterZone[4] == null && !ThisSeqHasPachi(4)) return 4;
            if (EOneMSeq(0, true, true, false) && (Bot.MonsterZone[0] == null) && !ThisSeqHasPachi(0)) return 0;
            for (int i = 0; i < 5; i++)
            {
                if (EOneMSeq(i, true, true, false) && (Bot.MonsterZone[i] == null) && !ThisSeqHasPachi(i)) return i;
            }
            for (int i = 0; i < 5; i++)
            {
                if (EOneMSeq(i, true, true, false, false) && (Bot.MonsterZone[i] == null) && !ThisSeqHasPachi(i)) return i;
            }
            Logger.DebugWriteLine("即便是那样，也要点一份咲夜吗？");
            return 2;
        }

        private int RDMatchShouldinThisSeq() //返回一个应该炮车的纵列
        {
            for (int i = 0; i < 5; i++)
            {
                if (EOneMSeq(i, false, false, false) && Bot.SpellZone[i] == null) return i;
            }
            return 2;
        }
        private int FlandreShouldinThisSeq(bool Patchouli = false, bool Meilin = false) //返回一个应该芙兰的纵列
        {
            int seq = 1;
            int level = -99;
            int R_level = -99;
            for (int i = 0; i < 5; ++i)
            {
                if (Bot.MonsterZone[i] == null && !ThisSeqHasPachi(i))
                {
                    R_level = FlandreInt(i, Patchouli, Meilin);

                    if (R_level > level)
                    {
                        level = R_level;
                        seq = i;
                        if (Patchouli && !Meilin) Logger.DebugWriteLine("第" + seq.ToString() + "的帕秋莉值是" + level.ToString());
                        if (!Patchouli && !Meilin) Logger.DebugWriteLine("第" + seq.ToString() + "的芙兰值是" + level.ToString());
                        if (!Patchouli && Meilin) Logger.DebugWriteLine("第" + seq.ToString() + "的美铃值是" + level.ToString());
                    }
                }
                Logger.DebugWriteLine("FlandreShouldinThisSeq 测试  " + i + " " + ThisSeqHasPachi(i) + " " + Bot.MonsterZone[i]);
            }
            //Logger.DebugWriteLine("llll" + " " + seq.ToString());
            return seq;
        } 
        private void EXSelectZoneWithoutPachi(int cardid)
        {
            ClientCard card2 = null;
            foreach (ClientCard card3 in Bot.ExtraDeck)
            {
                if (card3.Id == cardid) card2 = card3;
            }

            if (card2 == null) { Logger.DebugWriteLine("调用EXSelectZoneWithoutPachi发生空值错误"); return; } //
            int zone = Bot.GetLinkedZones();
            int r_zone = 6;
            int count = 0;
            int count_2 = 0;
            for (int i = 0; i < 7; i++)
            {
                if ((Bot.MonsterZone[i] == null || (zone == 0)) && (((zone & (1 << i)) != 0) || (i > 4)) && (i > 4)) { count_2 = LinkZoneCount(card2, i); }
                //if (Bot.MonsterZone[i] != null)
                //{ int id = Bot.MonsterZone[i].Id; Logger.DebugWriteLine("EX" + id.ToString()); }
                if (count_2 > count) { count = count_2; r_zone = i; }
            }
            string a_zong = r_zone.ToString();
            string count_3 = count.ToString();

            SeqtoZone(r_zone);
        } 
        private int SelectZoneWithoutPachi()
        {
            int p = 2;
            int zone = Bot.GetLinkedZones();
            for (int i = 0; i < 5; i++)
            {
                if (Bot.MonsterZone[i] == null && !(((zone & (1 << i)) != 0) || (i > 4)) && !ThisSeqHasPachi(i) && ((i != 0) || (i != 4))) { p = i; return p; }
            }
            for (int i = 0; i < 5; i++)
            {
                if (Bot.MonsterZone[i] == null && !(((zone & (1 << i)) != 0) || (i > 4)) && !ThisSeqHasPachi(i)) { p = i; return p; }
            }
            for (int i = 0; i < 5; i++)
            {
                if (Bot.MonsterZone[i] == null && !ThisSeqHasPachi(i)) { p = i; return p; }
            }
            return 2;
        }
        private void SeqtoZone(int seq = 2)
        {
            if (seq == 0) AI.SelectPlace(Zones.z0);
            if (seq == 1) AI.SelectPlace(Zones.z1);
            if (seq == 2) AI.SelectPlace(Zones.z2);
            if (seq == 3) AI.SelectPlace(Zones.z3);
            if (seq == 4) AI.SelectPlace(Zones.z4);
            if (seq == 5) AI.SelectPlace(Zones.z5);
            if (seq == 6) AI.SelectPlace(Zones.z6);
        }
        private int LinkZoneCount(ClientCard card2, int seq = 5)//假设这个链接怪兽在那个位置，其所能为自己开的格子数
        {
            int count = 0;
            if (seq == 5)
            {
                if (HasLinkMarker2(card2, CardLinkMarker.BottomLeft) && (Bot.MonsterZone[0] == null)) count += 1;
                if (HasLinkMarker2(card2, CardLinkMarker.Bottom) && (Bot.MonsterZone[1] == null)) count += 1;
                if (HasLinkMarker2(card2, CardLinkMarker.BottomRight) && (Bot.MonsterZone[2] == null)) count += 1;
                Logger.DebugWriteLine("此时选择位置" + seq.ToString() + "能开" + count.ToString() + "个格子");
            }
            if (seq == 6)
            {
                if (HasLinkMarker2(card2, CardLinkMarker.BottomLeft) && (Bot.MonsterZone[2] == null)) count += 1;
                if (HasLinkMarker2(card2, CardLinkMarker.Bottom) && (Bot.MonsterZone[3] == null)) count += 1;
                if (HasLinkMarker2(card2, CardLinkMarker.BottomRight) && (Bot.MonsterZone[4] == null)) count += 1;
            }
            if (seq == 0)
            {
                if (HasLinkMarker2(card2, CardLinkMarker.Right) && (Bot.MonsterZone[1] == null)) count += 1;
            }
            if (seq == 1)
            {
                if (HasLinkMarker2(card2, CardLinkMarker.Left) && (Bot.MonsterZone[0] == null)) count += 1;
                if (HasLinkMarker2(card2, CardLinkMarker.Right) && (Bot.MonsterZone[2] == null)) count += 1;
            }
            if (seq == 2)
            {
                if (HasLinkMarker2(card2, CardLinkMarker.Left) && (Bot.MonsterZone[1] == null)) count += 1;
                if (HasLinkMarker2(card2, CardLinkMarker.Right) && (Bot.MonsterZone[3] == null)) count += 1;
            }
            if (seq == 3)
            {
                if (HasLinkMarker2(card2, CardLinkMarker.Left) && (Bot.MonsterZone[2] == null)) count += 1;
                if (HasLinkMarker2(card2, CardLinkMarker.Right) && (Bot.MonsterZone[4] == null)) count += 1;
            }
            if (seq == 4)
            {
                if (HasLinkMarker2(card2, CardLinkMarker.Left) && (Bot.MonsterZone[3] == null)) count += 1;
            }
            Logger.DebugWriteLine("22222此时选择位置" + seq.ToString() + "能开" + count.ToString() + "个格子");
            return count;
        }
        private bool HasLinkMarker2(ClientCard card2, CardLinkMarker dir)
        {
            if (card2.Id == CardId.Erin) return card2.HasLinkMarker(dir) || dir == CardLinkMarker.BottomLeft || dir == CardLinkMarker.BottomRight;
            if (card2.Id == CardId.MKII) return card2.HasLinkMarker(dir) || dir == CardLinkMarker.BottomLeft || dir == CardLinkMarker.BottomRight || dir == CardLinkMarker.Bottom;
            if (card2.Id == CardId.Rikako) return card2.HasLinkMarker(dir) || dir == CardLinkMarker.Left || dir == CardLinkMarker.Top;
            return card2.HasLinkMarker(dir);
        }
        //返回该纵列是否自己的怪兽区域为空; faceDown = false 表示里侧表示不管 
        private bool EOneMSeq(int p, bool Spell = false, bool Sakuya = false, bool Remilia = false, bool faceDown = true)
        {
            if (Bot.MonsterZone[p] == null)
            {
                if (!Spell)
                {
                    return true;
                }
                else
                {
                    bool q = (Bot.SpellZone[p] == null || ((faceDown == false) && !(Bot.SpellZone[p].IsFaceup())));
                    bool q2 = (Bot.SpellZone[p] == null || (Bot.SpellZone[p].IsCode(CardId.RDMatch)));
                    bool q3 = (Enemy.SpellZone[4 - p] != null) || (Enemy.MonsterZone[4 - p] != null) || ((p == 3) && (Enemy.MonsterZone[5] != null)) || ((p == 1) && (Enemy.MonsterZone[6] != null));
                    if (q2 && !Sakuya && Remilia) return q3;
                    if (q && Sakuya && (Enemy.SpellZone[4 - p] == null) && !Remilia) return true; //表示必须这一纵列主要区域全空
                }
            }
            return false;
        }
        private bool DontCounter(ClientCard CardA)
        {
            if (CardA.HasType(CardType.Pendulum) && !FirstP) { FirstP = true; return true; }
            if (CardA.IsCode(new[] { 70512, 70513, 70514, 70515, 70516 })) return true;
            if (CardA.IsCode(new[] { 1984019, 1984020, 1984021, 1984022, 1984023, 1984024, 1984025 })) return true;
            return false;
        }
        private int LastValueHand() //返回手卡中价值最低的卡的价值数据,由于不能使用小数，我们这里调整一律以20为最高，9及以下不合格
        {
            int value = 20;
            int value_2 = 20;
            List<ClientCard> HandCards = Bot.GetHands();
            foreach (ClientCard HandCard in HandCards)
            {
                value_2 = GetValueByCard(HandCard);
                if (value_2 < value) value = value_2;
            }
            return value;
        } 
        private ClientCard LastValueCardHand() //返回手卡中价值最低的第一张卡
        {
            ClientCard card = null;
            List<ClientCard> HandCards = Bot.GetHands();
            foreach (ClientCard HandCard in HandCards)
            {
                if (GetValueByCard(HandCard) == LastValueHand()) card = HandCard;
            }
            int code = card.Id;
            string s2 = code.ToString();
            Logger.DebugWriteLine("现在AI手卡中最没用的卡卡名是" + s2);
            return card;
        } 
        private int GetValueByCard(ClientCard Card = null, int loc = 1, bool des = false, int Which = 0)//GetSWSakuyaValue GetRedMatchValue
        {
            int value = 0;
            if (Card.IsCode(CardId.ScarletWeather))
                value = GetScarletWeatherValue(loc); ;
            if (Card.IsCode(CardId.Cranberry_Trap))
                value = GetCTrapValue(loc, des, Which, Card);
            if (Card.IsCode(CardId.SWRemilia))
                value = GetSWRemiliaValue(loc, des, Which, Card);
            if (Card.IsCode(CardId.FoK))
                value = GetFoKValue(loc, des, Which, Card);
            if (Card.IsCode(CardId.Mist_Lake))
                value = GetMLakeValue();
            if (Card.IsCode(CardId.RDMaid))
                value = GetRDMaidValue(loc, des, Which, Card);
            if (Card.IsCode(CardId.RDFlandre))
                value = GetFlandreValue(loc, des, Which, Card);
            if (Card.IsCode(CardId.KandS_Girl))
                value = GetKandSValue(loc, des, Which, Card);
            if (Card.IsCode(CardId.SWSakuya))
                value = GetSWSakuyaValue(loc, des, Which, Card);
            if (Card.IsCode(CardId.SWMeilin))
                value = GetSWMeilinValue(loc, des, Which, Card); 
            if (Card.IsCode(CardId.Red_Magic))
                value = GetRed_MagicValue(loc);
            if (Card.IsCode(CardId.RDMatch))
                value = GetRedMatchValue(loc, des, Which, Card);
            if (Card.IsCode(CardId.Scarlet_Overlay))
                value = GetRedMatchValue(loc);
            if (Card.IsCode(CardId.Ten_Judge))
                value = GetRedMatchValue(loc);
            if (Card.IsCode(CardId.Scarlet_Seance))
                value = GetScarlet_SeanceValue(loc);
            if (Card.IsCode(CardId.RDHouse))
                value = GetRDHouseValue(loc);
            if (Card.IsCode(CardId.RDKoakuma))
                value = GetKoakumaValue(loc, des, Which, Card);
            if (Card.IsCode(CardId.SWPatchouli))
                value = GetSWPatchouliValue(loc, des, Which, Card);
            if (Card.IsCode(CardId.ForbiddenWave))
                value = GetForbiddenWaveValue(loc, des, Which, Card);
            if (Card.IsCode(CardId.Rikako))
                value = GetRikakoValue(loc, des, Which, Card);
            if (Card.IsCode(CardId.Scarlet_Destiny))  //GetScarlet_DestinyValue 红幻和这个用同一个
                value = GetScarlet_DestinyValue(loc, des, Which, Card);
            if (Card.IsCode(CardId.NAMERedDevil))  //GetScarlet_DestinyValue 红幻和这个用同一个
                value = GetNAMERedDevilValue(loc, des, Which, Card);
            if (Card.IsCode(CardId.Scarlet_Gensokyo))  //GetScarlet_DestinyValue 红幻和这个用同一个
                value = GetScarlet_DestinyValue(loc, des, Which, Card);
            if (Card.IsCode(CardId.Kijin_Seija))
                value = GetKijin_SeijaValue(loc);
            if (Card.IsCode(CardId.Little_Bunny))
                value = GetLittle_BunnyValue(loc);
            if (value == 0 && Card != null && Card.IsExtraCard()) value = 12;
            return value;
        }

        private int GetValueByCardId(int CardId2, int loc = 1, bool des = false, int Which = 0)
        {
            int value = 0;
            if (CardId2 == CardId.ScarletWeather)
                value = GetScarletWeatherValue(loc);
            if (CardId2 == CardId.Cranberry_Trap)
                value = GetCTrapValue(loc, des, Which, Card);
            if (CardId2 == CardId.SWRemilia)
                value = GetSWRemiliaValue(loc, des, Which, Card);
            if (CardId2 == CardId.FoK)
                value = GetFoKValue(loc, des, Which, Card);
            if (CardId2 == CardId.Mist_Lake)
                value = GetMLakeValue();
            if (CardId2 == CardId.RDMaid)
                value = GetRDMaidValue(loc, des, Which, Card);
            if (CardId2 == CardId.RDFlandre)
                value = GetFlandreValue(loc, des, Which, Card);
            if (CardId2 == CardId.KandS_Girl)
                value = GetKandSValue(loc, des, Which, Card);
            if (CardId2 == CardId.SWSakuya)
                value = GetSWSakuyaValue(loc, des, Which, Card);
            if (CardId2 == CardId.SWMeilin)
                value = GetSWMeilinValue(loc, des, Which, Card); 
            if (CardId2 == CardId.Red_Magic)
                value = GetRed_MagicValue(loc);
            if (CardId2 == CardId.RDMatch)
                value = GetRedMatchValue(loc, des, Which, Card);
            if (CardId2 == CardId.Ten_Judge)
                value = GetTen_JudgeValue(loc);
            if (CardId2 == CardId.Scarlet_Seance)
                value = GetScarlet_SeanceValue(loc);
            if (CardId2 == CardId.RDHouse)
                value = GetRDHouseValue(loc);
            if (CardId2 == CardId.RDKoakuma)
                value = GetKoakumaValue(loc, des, Which, Card);
            if (CardId2 == CardId.ForbiddenWave)
                value = GetForbiddenWaveValue(loc, des, Which, Card);
            if (CardId2 == CardId.Rikako)
                value = GetRikakoValue(loc, des, Which, Card);
            if (CardId2 == CardId.Scarlet_Destiny)
                value = GetScarlet_DestinyValue(loc, des, Which, Card);
            if (CardId2 == CardId.Scarlet_Overlay)
                value = GetScarlet_OverlayValue();
            if (CardId2 == CardId.SWPatchouli)
                value = GetSWPatchouliValue(loc, des, Which, Card);
            if (CardId2 == CardId.NAMERedDevil)
                value = GetNAMERedDevilValue(loc, des, Which, Card);
            if (CardId2 == CardId.Scarlet_Gensokyo)  //GetLittle_BunnyValue
                value = GetScarlet_DestinyValue(loc, des, Which, Card);
            if (CardId2 == CardId.Kijin_Seija)
                value = GetKijin_SeijaValue(loc);
            if (CardId2 == CardId.Little_Bunny)
                value = GetLittle_BunnyValue(loc);
            return value;
        }

        private bool Ifbaka(ClientCard Card)
        {
            int atkdef = Card.Attack + Card.Defense;
            return atkdef == 1000;
        }

        private bool IfBotHasBaka(int loc = 1) //
        {
            bool pay = false;
            List<ClientCard> GraveCards = Bot.GetGraveyardMonsters();
            foreach (ClientCard GraveCard in GraveCards)
            {
                if (Ifbaka(GraveCard) && IfBotCanSpSummon()) pay = true;
            }
            return pay;
        } 
         
        private int GetRDMCountInHand(bool Advance = false, bool Destroy = false, int Count = 2) //统计手卡中上级召唤用红魔怪兽的数量,默认算蕾米,不算女仆队
        {
            int count = 0;
            count += Bot.GetCountCardInZone(Bot.GetHands(), CardId.SWSakuya);
            count += Bot.GetCountCardInZone(Bot.GetHands(), CardId.SWPatchouli);
            count += Bot.GetCountCardInZone(Bot.GetHands(), CardId.SWMeilin);
            count += Bot.GetCountCardInZone(Bot.GetHands(), CardId.RDFlandre);
            if (!Destroy)
            {
                if (Count > 1) count += Bot.GetCountCardInZone(Bot.GetHands(), CardId.SWRemilia);
            }
            else
            {
                if (!Advance)
                {
                    count += Bot.GetCountCardInZone(Bot.GetHands(), CardId.RDMaid);
                    count += Bot.GetCountCardInZone(Bot.GetHands(), CardId.SWRemilia);
                }
                else
                {
                    count += Bot.GetCountCardInZone(Bot.GetHands(), CardId.RDKoakuma);
                }
            }
            return count;
        }
        private int GetRDMCountInGrave(bool ressure = true)
        {
            int count = 0;
            List<ClientCard> Monsters = Bot.GetGraveyardMonsters();
            foreach (ClientCard Monster in Monsters)
            {
                if (Monster.HasSetcode(0x813)) count += 1;
            }
            if (!IfBotCanSpSummon() && ressure) count = 0;
            return count;
        }

        private int GetDestroyCountInMZone() //统计场上被炸卡点，只计红魔卡
        {
            int count = 0;
            count += GetRDMCountInMZone(false);
            List<ClientCard> Spells = Bot.GetSpells();
            foreach (ClientCard Spell in Spells)
            {
                if (HasSetRD(Spell) && !Spell.IsFacedown() && (GetValueByCard(Spell, 2, true) < 8))
                {
                    if (!ChainContainsCard2ByPlayer(Spell))
                    {
                        count += 1;
                    }
                }
            }
            return count;
        }

        private int GetDestroyCountInSpellZone() //统计场上被炸卡点，只计魔陷区域的
        {
            int count = 0;
            List<ClientCard> Spells = Bot.GetSpells();
            foreach (ClientCard Spell in Spells)
            {
                if (HasSetRD(Spell) && !Spell.IsFacedown() && (GetValueByCard(Spell, 2, true) < 8))
                {
                    if (!ChainContainsCard2ByPlayer(Spell))
                    {
                        count += 1;
                    }
                }
            }
            return count;
        } 
        private int GetDestroyCountInHand(int id = 0) //统计手卡、场上炸卡点
        {
            int count = 0;
            if (Bot.HasInHand(CardId.SWMeilin) && !Meilined && IfBotCanSpSummon())
            { count += Bot.GetCountCardInZone(Bot.GetHands(), CardId.SWMeilin); if (id == CardId.SWMeilin) count -= 1; }
            if (Bot.HasInHand(CardId.SWMeilin) && !Meilined && IfBotCanSpSummon())
            { count += Bot.GetCountCardInZone(Bot.GetHands(), CardId.SWPatchouli); if (id == CardId.SWMeilin) count -= 1; }
            if (Bot.HasInHand(CardId.SWMeilin) && !Meilined && IfBotCanSpSummon())
            { count += Bot.GetCountCardInZone(Bot.GetHands(), CardId.SWSakuya); if (id == CardId.SWMeilin) count -= 1; }
            if (Bot.HasInHand(CardId.SWMeilin) && !Meilined && IfBotCanSpSummon())
            { count += Bot.GetCountCardInZone(Bot.GetHands(), CardId.RDFlandre); if (id == CardId.SWMeilin) count -= 1; }
            if (Bot.HasInHand(CardId.Scarlet_Destiny) && !Destinyed && IfBotCanSpSummon()) count += Bot.GetCountCardInZone(Bot.GetHands(), CardId.Scarlet_Destiny);
            if (Bot.HasInHand(CardId.Red_Magic) && !Destinyed && IfBotCanSpSummon()) count += Bot.GetCountCardInZone(Bot.GetHands(), CardId.Red_Magic);
            List<ClientCard> Spells2 = new List<ClientCard>();
            List<ClientCard> Spells = Bot.GetSpells();
            foreach (ClientCard Spell in Spells)
            {
                if (Spell.IsCode(CardId.Scarlet_Destiny) && Spell.IsFacedown()) Spells2.Add(Spell);
                if (Spell.IsCode(CardId.Red_Magic) && Spell.IsFacedown()) Spells2.Add(Spell);
            }
            if (Spells2.Count > 0 && !Destinyed) count += 1;
            if (Bot.HasInSpellZone(CardId.Scarlet_Destiny) && !Sakuyaed && !RDMaided && IfBotCanSpSummon()) count += 1;
            Logger.DebugWriteLine("GetDestroyCountInHand 测试" + count);
            return count;
        }

        private int GetRDMCountInMZone(bool Advance = true, bool faceup = true, bool extra = false) //统计场上红魔怪兽数量,默认只计非特殊召唤,且是表侧表示的数量,不计额外怪兽
        {
            int count = 0;
            foreach (ClientCard card2 in Bot.GetMonsters())
            {
                if (HasSetRD(card2) && (!Advance || (!card2.IsSpecialSummoned)) && (!faceup || card2.IsFaceup())
                       && !(card2.IsCode(CardId.SWSakuya) && Sakuyaed && !Sakuyaed_2))
                {
                    if (card2.IsExtraCard() || (!extra)) count += 1;
                }
            }

            Logger.DebugWriteLine("GetDestroyCountInMZone 测试" + count);
            return count;
        }
        private bool IsAdvancedRDM(ClientCard card2)
        {
            if (HasSetRD(card2) && card2.Id != CardId.RDKoakuma && (!card2.IsSpecialSummoned) && card2.Id != CardId.RDMaid) return true;
            return false;
        }
        private bool HasSetRD(ClientCard card2)
        {
            return card2.HasSetcode(0x813) || (card2.Id == CardId.Cranberry_Trap) || (card2.Id == CardId.FoK);
        }
        private bool notMonster(ClientCard card2)
        {
            return (card2.Id == CardId.Scarlet_Overlay) || (card2.Id == CardId.Cranberry_Trap) || (card2.Id == CardId.FoK);
        }

        private int GetFaceupMZone()//返回AI场上表侧表示的怪兽数量
        {
            int count = 0;
            foreach (ClientCard card2 in Bot.GetMonsters())
            {
                if (card2.IsFaceup()) count += 1;
            }
            return count;
        }

        private int HowManySeqNHasPachi()
        {
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                if (!ThisSeqHasPachi(i)) count += 1;
            }
            return count;
        } 
        private bool ThisSeqHasPachi(int seq)
        {
            if (seq < 5)
            {
                if (Bot.MonsterZone[seq] != null && Bot.MonsterZone[seq].IsCode(CardId.SWPatchouli) && Bot.MonsterZone[seq].IsFaceup() && !Bot.MonsterZone[seq].IsDisabled()) return true;
                if (Enemy.MonsterZone[4 - seq] != null && Enemy.MonsterZone[4 - seq].IsCode(CardId.SWPatchouli) && Enemy.MonsterZone[4 - seq].IsFaceup() && !Enemy.MonsterZone[4 - seq].IsDisabled()) return true;
                if (Enemy.HasInSpellZone(98935722, true, true))
                {
                    if (Enemy.MonsterZone[4 - seq] != null && Enemy.MonsterZone[4 - seq].HasSetcode(0x10c) && Enemy.MonsterZone[4 - seq].IsFaceup()) return true;
                }
            }
            if (seq == 5)
            {
                if (Bot.MonsterZone[1] != null && Bot.MonsterZone[1].IsCode(CardId.SWPatchouli) && Bot.MonsterZone[1].IsFaceup() && !Bot.MonsterZone[1].IsDisabled()) return true;
                if (Enemy.MonsterZone[3] != null && Enemy.MonsterZone[3].IsCode(CardId.SWPatchouli) && Enemy.MonsterZone[3].IsFaceup() && !Enemy.MonsterZone[3].IsDisabled()) return true;
                if (Enemy.HasInSpellZone(98935722, true, true))
                {
                    if (Enemy.MonsterZone[3] != null && Enemy.MonsterZone[3].HasSetcode(0x10c) && Enemy.MonsterZone[3].IsFaceup()) return true;
                }
            }
            if (seq == 6)
            {
                if (Bot.MonsterZone[3] != null && Bot.MonsterZone[3].IsCode(CardId.SWPatchouli) && Bot.MonsterZone[3].IsFaceup() && !Bot.MonsterZone[3].IsDisabled()) return true;
                if (Enemy.MonsterZone[1] != null && Enemy.MonsterZone[1].IsCode(CardId.SWPatchouli) && Enemy.MonsterZone[1].IsFaceup() && !Enemy.MonsterZone[1].IsDisabled()) return true;
                if (Enemy.HasInSpellZone(98935722, true, true))
                {
                    if (Enemy.MonsterZone[6] != null && Enemy.MonsterZone[6].HasSetcode(0x10c) && Enemy.MonsterZone[6].IsFaceup()) return true;
                }
            }
            return false;
        }

        private bool IfScarlet(bool CheckHand = false, bool ActInHand = false)//返回是否具备发动绯色陷阱卡的前置条件
        {
            if (CheckHand)
            {
                bool pay = false;
                foreach (ClientCard m in Bot.Hand)
                {
                    if (m.HasSetcode(0x814) || m.IsCode(CardId.FoK) || m.IsCode(CardId.Cranberry_Trap))
                        pay = true;
                }
                if (!pay) return pay;
            }
            if (IfNotActivateOrSp()) return false;
            bool pay2 = false;
            for (int i = 0; i < 5; i++)
            {
                if ((Bot.SpellZone[i] == null) && !ThisSeqHasPachi(i)) pay2 = true;
            }
            if (pay2) Logger.DebugWriteLine("调用IfScarlet S");
            if ((GetRDMCountInMZone(false, true, false) == GetFaceupMZone() || Bot.HasInSpellZone(CardId.Scarlet_Gensokyo, true, true)) && (GetFaceupMZone() != 0))
            {
                if (pay2) Logger.DebugWriteLine("可以手发红魔魔陷");
                return pay2;
            }
            return false;
        }

        private bool IfNotActivateOrSp()
        {
            if (Enemy.HasInGraveyard(900001) && (Duel.Phase == DuelPhase.Main1)) return true;
            if (Enemy.HasInMonstersZone(35823249, true, true) || (Enemy.HasInSpellZone(19612169, true, true) && Enemy.HasInMonstersZone(2468169, true, true))) return true;
            return false;
        } 
        private int sortUnit(List<ClientCard> cards, int low, int high, int loc = 1, bool des = false)
        {
            int key = GetValueByCard(cards[low], loc, des, 0);
            ClientCard key2 = cards[low];
            while (low < high)
            {
                /*从后向前搜索比key小的值*/
                while ((GetValueByCard(cards[high], loc, des, 0) >= key) && (high > low))
                    --high;
                /*比key小的放左边*/
                cards[low] = cards[high];
                /*从前向后搜索比key大的值，比key大的放右边*/
                while ((GetValueByCard(cards[low], loc, des, 0) <= key) && high > low)
                    ++low;
                /*比key大的放右边*/
                cards[high] = cards[low];
            }
            /*左边都比key小，右边都比key大。//将key放在游标当前位置。//此时low等于high */
            cards[low] = key2;
            return high;
        }
        /**快速排序 material_list.Count - 1
        *@paramarry 
        *@return */
        private void SortByValue(List<ClientCard> cards, int low, int high, int loc = 1, bool des = false)
        {
            if (low >= high)
            {
                int[] array = new int[cards.Count];
                string[] array2 = new string[cards.Count];
                for (int i = 0; i < cards.Count; i++)
                {
                    //array[i] = cardids[i];
                    array[i] = GetValueByCardId(cards[i].Id, loc, des, 0);
                }
                for (int i = 0; i < cards.Count; i++)
                {
                    array2[i] = cards[i].Name;
                }
                string str = string.Join(",", array);
                string str2 = string.Join(",", array2);
                //Logger.DebugWriteLine(str);
                //Logger.DebugWriteLine(str2);
                return;
            }

            /*完成一次单元排序*/
            int index = sortUnit(cards, low, high, loc, des);
            /*对左边单元进行排序*/
            SortByValue(cards, low, index - 1, loc, des);
            /*对右边单元进行排序*/
            SortByValue(cards, index + 1, high, loc, des);
        }

        private int sortUnitid(List<int> cards, int low, int high, int loc = 1, bool des = false)
        {
            int key = GetValueByCardId(cards[low], loc, des, 0);
            int key2 = cards[low];
            while (low < high)
            {
                /*从后向前搜索比key小的值*/
                while ((GetValueByCardId(cards[high], loc, des, 0) >= key) && (high > low))
                    --high;
                /*比key小的放左边*/
                cards[low] = cards[high];
                /*从前向后搜索比key大的值，比key大的放右边*/
                while ((GetValueByCardId(cards[low], loc, des, 0) <= key) && high > low)
                    ++low;
                /*比key大的放右边*/
                cards[high] = cards[low];
            }
            /*左边都比key小，右边都比key大。//将key放在游标当前位置。//此时low等于high */
            cards[low] = key2;
            return high;
        }
        /**快速排序 
        *@paramarry 
        *@return */
        private void SortByValueId(List<int> cardids, int low, int high, int loc = 1, bool des = false)
        {
            if (low >= high)
            {
                int[] array = new int[cardids.Count];
                int[] array2 = new int[cardids.Count];
                for (int i = 0; i < cardids.Count; i++)
                {
                    //array[i] = cardids[i];
                    array[i] = GetValueByCardId(cardids[i], loc, des, 0);
                }
                for (int i = 0; i < cardids.Count; i++)
                {
                    array2[i] = cardids[i];
                }
                string str = string.Join(",", array);
                string str2 = string.Join(",", array2);
                Logger.DebugWriteLine(str);
                Logger.DebugWriteLine(str2);
                return;
            }

            /*完成一次单元排序*/
            int index = sortUnitid(cardids, low, high, loc, des);
            /*对左边单元进行排序*/
            SortByValueId(cardids, low, index - 1, loc, des);
            /*对右边单元进行排序*/
            SortByValueId(cardids, index + 1, high, loc, des);
        } 
        private bool IfBotCanSpSummon()
        {
            if (Enemy.HasInMonstersZone(47084486, true, true) || Enemy.HasInMonstersZone(72634965, true, true)) return false;
            return true;
        } 
        private void contact2list(List<ClientCard> cards1, List<ClientCard> cards2)
        {
            foreach (ClientCard Card in cards2)
            {
                cards1.Add(Card);
            }
        } 
        private bool BotHasLinkMonster()
        {
            bool pay = false;
            List<ClientCard> MonstersCards = Bot.GetMonsters();
            foreach (ClientCard MonstersCard in MonstersCards)
            {
                if (MonstersCard.HasType(CardType.Link) && MonstersCard.IsFaceup()) pay = true;
            }
            return pay;
        }
        private bool RDMChainning(bool onfield = false)
        {
            bool pay = needDestroyRD();
            bool count = false;
            if (ChainContainsCard3ByPlayer(CardId.ScarletWeather)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.RDMaid)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.SL_Remilia)) count = true; 
            if (ChainContainsCard3ByPlayer(CardId.NAMERedDevil)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.RDFlandre)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.SWMeilin)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.SWRemilia)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.SWSakuya)) count = true;
            if (onfield && !count) count = false;
            if (ChainContainsCard3ByPlayer(CardId.SWPatchouli, 0, CardLocation.SpellZone)) { Logger.DebugWriteLine("不要连锁"); count = true; }
            if ((count == true) && (Duel.LastChainPlayer == 1) && pay) count = false;//            Logger.DebugWriteLine("调试 2018年10月27日16:43:03");
            if (Destinying) count = true;
            if (ChainContainsCard3ByPlayer(CardId.RDFlandre, 0, CardLocation.Hand)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.RDKoakuma, 0, CardLocation.MonsterZone)) { count = true; Logger.DebugWriteLine("此时有预定的红魔效果发动，请ai不要连锁W"); }
            if (ChainContainsCard3ByPlayer(CardId.SWMeilin, 0, CardLocation.Hand)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.SWRemilia, 0, CardLocation.Hand)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.SWSakuya, 0, CardLocation.Hand)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.SWPatchouli, 0, CardLocation.Hand)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.Red_Magic, 0, CardLocation.SpellZone)) count = true;
            if (RDMChainningX) count = true;
            if (count) { Logger.DebugWriteLine("此时有预定的红魔效果发动，请ai不要连锁"); RDMChainningX = true; }

            return count;
        }

        private bool RDMChainning2()
        {
            bool count = false;
            if (ChainContainsCard3ByPlayer(CardId.ScarletWeather)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.RDMaid)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.RDHouse)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.RDFlandre)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.SWMeilin)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.SWRemilia)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.SWSakuya)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.SWPatchouli)) count = true;
            if (ChainContainsCard3ByPlayer(CardId.RDKoakuma)) count = true; 
            if (count) { Logger.DebugWriteLine("此时有预定的红魔效果发动，请ai不要连锁"); }
            return count;
        }
        private bool needDestroyRD()//需要被炸（紧急的）
        {
            List<ClientCard> material_list = new List<ClientCard>();
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if (monster.IsFaceup() && (HasSetRD(monster) || Bot.HasInSpellZone(CardId.Scarlet_Gensokyo, true, true)))
                    material_list.Add(monster);
            }
            foreach (ClientCard Spell in Bot.GetSpells())
            {
                if (Spell.IsFaceup() && HasSetRD(Spell))
                    material_list.Add(Spell);
            }
            SortByValue(material_list, 0, material_list.Count - 1, 2, true);//material_list[0]
            if (material_list.Count < 1) return false;
            if (GetValueByCard(material_list[0], 2, true, 0) <= 3) Logger.DebugWriteLine("此时有卡 " + material_list[0].Name + " 紧急需被炸  " + GetValueByCard(material_list[0], 2, true, 0));
            return GetValueByCard(material_list[0], 2, true, 0) <= 3;
        }

        private int GetExtraMInGrave()//返回AI在墓地中的额外怪兽数量
        {
            int count = 0;
            foreach (ClientCard g in Bot.GetGraveyardMonsters())
            {
                if (g.IsMonster() && (g.HasType(CardType.Fusion) || g.HasType(CardType.Synchro) || g.HasType(CardType.Xyz) || g.HasType(CardType.Link)))
                {
                    count += 1;
                }
            }
            return count;
        }

        private int GetExtraMInMZone()//返回AI在场上中的额外怪兽数量，不计一般的灵摆
        {
            int count = 0;
            foreach (ClientCard g in Bot.GetMonsters())
            {
                if (g.IsMonster() && (g.HasType(CardType.Fusion) || g.HasType(CardType.Synchro) || g.HasType(CardType.Xyz) || g.HasType(CardType.Link)))
                {
                    count += 1;
                }
            }
            return count;
        }

        private bool CanSpSummon()//需要被炸（紧急的）
        {
            if (Bot.HasInMonstersZone(CardId.SWIku, true, false, true) && !Ikued) return true;
            if ((Bot.HasInHand(CardId.RDMatch) || Bot.HasInSpellZone(CardId.RDMatch, true, true)) && !PaoChed) return true;
            if (GetDestroyCountInMZone() > 0) return true;
            if ((Bot.HasInHand(CardId.RDKoakuma) || Bot.HasInHand(CardId.RDMaid)) && !Summoned) return true;
            return false;
        }

        private int GetSCountInDeck() //统计卡组中绯色卡的数量
        {
            int count = 0;
            count += GetCountInDeck(CardId.Scarlet_Seance, 2);
            count += GetCountInDeck(CardId.Scarlet_Destiny, Scarlet_DestinyCount); 
            count += GetCountInDeck(CardId.Scarlet_Gensokyo, 1);
            //Logger.DebugWriteLine("卡组中绯色卡的数量是" + count.ToString());
            return count;
        }
        private bool KoaKuma2() ////是否发动过了小恶魔的②效果导致可以再度召唤
        {
            if (KoakumaedSummoned) return true;
            return false;
        }

        private List<ClientCard> GetMosterByRank(int rank = 7, bool extra = true, bool spell = true) //统计额外卡组中超量召唤的X阶怪兽数量， extra = false表示返回场上的素材数，除非那个X阶怪兽数量为零
        {
            List<ClientCard> material_list = new List<ClientCard>();
            List<ClientCard> material_list2 = new List<ClientCard>();
            List<ClientCard> Mosters = Bot.GetExtra();
            foreach (ClientCard extra_monster in Mosters)
            {
                if (extra_monster.HasType(CardType.Xyz) && extra_monster.Rank == rank)
                {
                    material_list.Add(extra_monster);
                    ;
                }

            }
            if ((material_list.Count == 0) || extra) return material_list;
            List<ClientCard> Mosters2 = Bot.GetMonsters();
            foreach (ClientCard monster in Mosters2)
            {
                if (monster.Level == rank && monster.IsFaceup() && !monster.IsExtraCard() && (spell || !notMonster(monster)))
                {
                    material_list2.Add(monster);
                }

            }
            return material_list2;
        }

        private List<ClientCard> GetMosterByRank2() //统计额外卡组中可被超量召唤的X阶怪兽数量，素材只按两只计
        {
            List<ClientCard> material_list = new List<ClientCard>();
            List<ClientCard> Mosters = Bot.GetExtra();
            foreach (ClientCard extra_monster in Mosters)
            {
                if (extra_monster.HasType(CardType.Xyz))
                {
                    int i = extra_monster.Rank;
                    if (GetMosterByRank(i, false).Count > 1) material_list.Add(extra_monster);
                };

            }
            return material_list;
        }

        private bool IsShouKen(ClientCard Card)
        {
            return Card.IsCode(new[] { 14558127, 23434538, 73642296 });
        }
        private List<ClientCard> GetSynMoster() //统计额外卡组中可被同调召唤的怪兽数,只计算1+1
        {
            List<ClientCard> material_list = new List<ClientCard>();
            List<ClientCard> Mosters = Bot.GetExtra();
            foreach (ClientCard extra_monster in Mosters)
            {
                if (extra_monster.HasType(CardType.Synchro))
                {
                    int levelSum = 0;
                    int levelSum2 = 0;
                    List<ClientCard> Mosters2 = Bot.GetMonsters();
                    foreach (ClientCard turner in Mosters2)
                    {
                        if (turner.HasType(CardType.Tuner))
                        {
                            levelSum += turner.Level;
                            levelSum2 += turner.Level;
                            break;
                        }
                    }
                    foreach (ClientCard no_turner in Mosters2)
                    {
                        if (!no_turner.HasType(CardType.Tuner) && (!no_turner.IsCode(CardId.Scarlet_Overlay))
                            && !(no_turner.HasType(CardType.Fusion) || no_turner.HasType(CardType.Synchro) || no_turner.HasType(CardType.Xyz) || no_turner.HasType(CardType.Link)))
                        {
                            levelSum += no_turner.Level;
                            levelSum2 -= no_turner.Level;
                            break;
                        }
                    }
                    if (levelSum == extra_monster.Level && !(extra_monster.IsCode(CardId.SL_Sakuya)) && !(extra_monster.IsCode(CardId.SL_Marisa))) material_list.Add(extra_monster);
                    if (levelSum2 == -extra_monster.Level && (extra_monster.IsCode(CardId.SL_Marisa)) && (extra_monster.IsCode(CardId.SL_Sakuya))) material_list.Add(extra_monster);
                }
            }
            return material_list;
        }
        //card.HasType(CardType.Xyz)

        private int GetCountInDeck(int cardId, int count = 3) //对于一卡名，统计其在卡组中同名卡数量
        {
            count = count - Bot.GetCountCardInZone(Bot.GetMonsters(), cardId) - Bot.GetCountCardInZone(Bot.GetSpells(), cardId);
            count = count - Bot.GetCountCardInZone(Bot.Banished, cardId) - Bot.GetCountCardInZone(Bot.Graveyard, cardId);
            count = count - Bot.GetCountCardInZone(Bot.GetHands(), cardId) - Bot.GetCountCardInZone(Bot.GetExtra(), cardId);
            count = count - GetCountInOverLay(cardId);
            if (count < 0) count = 0;
            return count;
        }
        private int GetCountInDeck2(int cardId, int count = 3) //对于一卡名，统计其在卡组中同名卡数量2
        {
            count = count - Bot.GetCountCardInZone(Bot.GetMonsters(), cardId) - Bot.GetCountCardInZone(Bot.GetSpells(), cardId);
            count = count - Bot.GetCountCardInZone(Bot.Banished, cardId) - Bot.GetCountCardInZone(Bot.Graveyard, cardId);
            count = count - Bot.GetCountCardInZone(Bot.GetHands(), cardId);
            count = count - GetCountInOverLay(cardId);
            if (count < 0) count = 0;
            return count;
        }
        private bool IfSummonRemilia(int Count = 2) //对于一卡名，统计其在卡组中同名卡数量
        {
            int count = 0;
            foreach (ClientCard extra_monster in Bot.GetMonsters())
            {
                if (extra_monster.IsFacedown()) count += 1;
            }
            foreach (ClientCard extra_monster in Bot.GetMonsters())
            {
                if (!extra_monster.IsFacedown() && extra_monster.IsSpecialSummoned && !extra_monster.IsExtraCard()) count += 1;
            }
            return count >= Count;
        }

        private int GetCountInOverLay(int cardId, int count = 0) //对于一卡名，统计其在叠光区域中同名卡数量
        {
            List<ClientCard> Mosters = Bot.GetMonsters();
            foreach (ClientCard extra_monster in Mosters)
                if (extra_monster.HasType(CardType.Xyz) && extra_monster.HasXyzMaterial(0, cardId))
                    count += 1;
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
                55410871, 41456841,
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
