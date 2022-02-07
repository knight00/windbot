using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("Youyou", "AI_Youyou", "NotFinished")]
    public class YouyouExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Maidanglao = 9951524;
            public const int Lanlianmo = 36584822;
            public const int Xiaopangbei = 9951526;
            public const int Zhenyingjushou = 14010180;
            public const int Didi = 9951525;
            public const int Huiliuli = 14558128;
            public const int LUA = 33701435;
            public const int Gengyishi = 9951160;
            public const int Eyi = 9981675;
            public const int Liwuyun = 9981725;
            public const int Xuwukongjian = 5851097;
            public const int Linghunchouqu = 73599290;
            public const int Shenzhitonggao = 40605147;
            public const int Shenzhixuangao = 41420027;
            public const int Bujiezhiyan = 9982666;
            public const int Chaohundun = 121082833;

            public const int Like = 9981797;
            public const int Jshantong = 9982522;
            public const int Jnishantong = 9982667;
            public const int Jsanjiao = 9982668;
            public const int Jjiasu = 9982670;
            public const int Jkutong = 9982674;
            public const int Jbian = 9982675;

            //骚灵让对方无效
            public const int Silquitous = 89538537;
            //G
            public const int AB_JS = 14558127;
            public const int GO_SR = 59438930;
            public const int GR_WC = 62015408;
            public const int GB_HM = 73642296;
            public const int MaxxC = 23434538;
            public const int Meluseek = 25533642;
            public const int OneForOne = 2295440;
            public const int PotofDesires = 35261759;
            public const int PotofIndulgence = 49238328;
            //泡影
            public const int Impermanence = 10045474;
            public const int WakingtheDragon = 10813327;
            public const int EvenlyMatched = 15693423;
            public const int Storm = 23924608;
            public const int Manifestation = 35146019;
            public const int Protocol = 27541563;
            public const int Spoofing = 53936268;
            public const int ImperialOrder = 61740673;
            //神之通告
            public const int SolemnStrike = 40605147;
            //神之宣告
            public const int Multifaker = 42790071;
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
            public const int DarkHole = 53129443;
            public const int NaturalBeast = 33198837;
            public const int SwordsmanLV7 = 37267041;
            public const int RoyalDecreel = 51452091;
            public const int Anti_Spell = 58921041;
            public const int Hayate = 8491308;
            public const int Raye = 26077387;
            public const int Drones_Token = 52340445;
            public const int Iblee = 10158145;
        }
        List<int> Impermanence_list = new List<int>();
        bool Lua = false;
        //选择
        List<int> should_select = new List<int>
        {
            CardId.Lanlianmo,CardId.Zhenyingjushou,CardId.Xiaopangbei,CardId.Didi, CardId.Maidanglao
        };
        public YouyouExecutor(GameAI ai, Duel duel)
     : base(ai, duel)
        {
            //礼物云
            AddExecutor(ExecutorType.Activate, CardId.Liwuyun, WuEffect);
            //DIY
            AddExecutor(ExecutorType.Activate, CardId.LUA, LUAEffect);
            //灰流丽
            AddExecutor(ExecutorType.Activate, CardId.Huiliuli, Hand_act_eff);
            //恶意
            AddExecutor(ExecutorType.Activate, CardId.Eyi, WuEffect);
            //虚无空间
            AddExecutor(ExecutorType.Activate, CardId.Xuwukongjian, XuwukongjianEffect);
            //灵魂抽取
            AddExecutor(ExecutorType.Activate, CardId.Linghunchouqu, LinghunchouquEffect);
            //神通
            AddExecutor(ExecutorType.Activate, CardId.Shenzhitonggao, SolemnStrike_activate);
            //神宣
            AddExecutor(ExecutorType.Activate, CardId.Shenzhixuangao, SolemnJudgment_activate);
            //更衣室
            AddExecutor(ExecutorType.Activate, CardId.Gengyishi, GengyishiEffect);

            //蓝魔兽
            AddExecutor(ExecutorType.Summon, CardId.Lanlianmo);
            //真影巨兽
            AddExecutor(ExecutorType.Summon, CardId.Zhenyingjushou);
            //小庞贝
            AddExecutor(ExecutorType.Summon, CardId.Xiaopangbei);
            //蒂蒂
            AddExecutor(ExecutorType.Summon, CardId.Didi);
            //麦当劳
            AddExecutor(ExecutorType.Summon, CardId.Maidanglao);

            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
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


        //灰流丽
        public bool Hand_act_eff()
        {
            if ((Bot.HasInSpellZone(CardId.Chaohundun) || Enemy.HasInSpellZone(CardId.Chaohundun)) && Lua) return false;
            {
                return (Duel.LastChainPlayer == 1);
            }
        }
        //神宣告

        public bool SolemnJudgment_activate()
        {
            if (Util.IsChainTargetOnly(Card) && Bot.HasInHand(CardId.Multifaker)) return false;
            if ((Bot.HasInSpellZone(CardId.Chaohundun) || Enemy.HasInSpellZone(CardId.Chaohundun)) && Lua) return false;
            if ((DefaultSolemnJudgment() && spell_trap_activate(true)))
            {
                ClientCard target = Util.GetLastChainCard();
                if (target != null && !target.IsMonster() && !spell_trap_activate(false, target)) return false;
                return true;
            }
            return false;
        }
        //神通
        public bool SolemnStrike_activate()
        {
            if ((Bot.HasInSpellZone(CardId.Chaohundun) || Enemy.HasInSpellZone(CardId.Chaohundun)) && Lua) return false;
            return (DefaultSolemnStrike() && spell_trap_activate(true));
        }
        //虚无空间
        private bool XuwukongjianEffect()
        {
            if ((Bot.HasInSpellZone(CardId.Chaohundun) || (Enemy.HasInSpellZone(CardId.Chaohundun)) && Lua) ||(Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0)) return false;
            return true;
        }
        //LUA
        private bool LUAEffect()
        {
            if (Duel.LastChainPlayer == 1 && Util.GetLastChainCard() != null)
            {
                if (!Bot.HasInSpellZone(CardId.Chaohundun) && !Enemy.HasInSpellZone(CardId.Chaohundun))
                {
                    int code = Util.GetLastChainCard().Id;
                    int alias = Util.GetLastChainCard().Alias;
                    if (alias != 0 && alias - code < 10) code = alias;
                    if (code == 0) return false;
                    AI.SelectAnnounceID(code);
                    return true;
                }
                else
                {
                    AI.SelectAnnounceID(CardId.Chaohundun);
                    Lua = true;
                    return true;
                }
            }
            return false;
        }
        //更衣室
        private bool GengyishiEffect()
        {
            if ((Bot.HasInSpellZone(CardId.Chaohundun) || Enemy.HasInSpellZone(CardId.Chaohundun)) && Lua) return false;
            {
                AI.SelectCard(should_select);
                return true;
            }
        }
        //无效不发动
        private bool WuEffect()
        {
            if ((Bot.HasInSpellZone(CardId.Chaohundun) || Enemy.HasInSpellZone(CardId.Chaohundun)) && Lua) return false;
            return true;
        }
        //灵魂抽取
        private bool LinghunchouquEffect()
        {
            if (Bot.LifePoints <= 1000 || ((Bot.HasInSpellZone(CardId.Chaohundun) || Enemy.HasInSpellZone(CardId.Chaohundun)) && Lua)) return false;
            return true;
        }
    }
}
