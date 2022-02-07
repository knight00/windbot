using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("Honglianmo", "AI_Honglianmo", "NotFinished")]
    public class HonglianmoExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Potianyucuier = 98983701;
            public const int Wanglongyucuier = 98983702;
            public const int Jiqiaoshe = 71197066;
            public const int Haiguihuaishou = 55063751;
            public const int Ageliqiao = 9950769;
            public const int Aluosuo = 9950759;
            public const int Abulu = 9950760;
            public const int Sanhualing = 72100051;
            public const int Honglianmo = 36584821;
            public const int gululingbo = 9950621;
            public const int DDzhanshou = 9981632;
            public const int Cunzaitanta = 14010240;
            public const int Hu = 35261759;
            public const int Xianrenzhaohuan = 14010079;
            public const int LUA = 33701435;
            public const int Chaoronghe = 48130397;
            public const int Jiamianbianhua = 93600443;
            public const int Zuizhongaoyi = 9950510;
            public const int Eyi = 9981675;
            public const int Dayuzhou = 30241314;
            public const int Ciyuanbi = 33700905;
            public const int Wanggongsheming = 61740673;
            public const int Shenzhitonggao = 40605147;
            public const int Shenzhixuangao = 41420027;
            public const int Buzhihuo = 97820005;
            public const int Jiamianyalang = 9982287;
            public const int Ronghelong = 41209828;
            public const int Aluobu = 9950767;
            public const int Hkulou = 59531356;
            public const int Xuli = 33701394;
            public const int Hkulouche = 83656563;
            public const int Pigu = 63790005;
            public const int Ageluobu = 9950771;
            public const int Ashuijingluobu = 9950772;
            public const int Lingxia = 14151617;
            public const int Lishuwen = 9950834;
            public const int Kunquery = 52927340;
            public const int Marionetter = 53143898;
            public const int Multifaker = 42790071;
            public const int AB_JS = 14558127;
            public const int GO_SR = 59438930;
            public const int GR_WC = 62015408;
            public const int GB_HM = 73642296;

            //骚灵让对方无效
            public const int Silquitous = 89538537;
            //G
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
        public HonglianmoExecutor(GameAI ai, Duel duel)
          : base(ai, duel)
        {
            //海龟坏兽
            AddExecutor(ExecutorType.SpSummon, CardId.Haiguihuaishou);
            //屁股
            AddExecutor(ExecutorType.SpSummon, CardId.Pigu);
            //格丽乔
            AddExecutor(ExecutorType.Summon, CardId.Ageliqiao, AgeliqiaoSummon);
            //格丽乔
            AddExecutor(ExecutorType.Activate, CardId.Ageliqiao);
            //格丽乔
            AddExecutor(ExecutorType.SpSummon, CardId.Ageliqiao);
            //布鲁
            AddExecutor(ExecutorType.Summon, CardId.Abulu, AluosuoSummon);
            //罗索
            AddExecutor(ExecutorType.Summon, CardId.Aluosuo, AluosuoSummon);
            //水晶罗布
            AddExecutor(ExecutorType.SpSummon, CardId.Ashuijingluobu, AshuijingluobuSummon);
            //格罗布
            AddExecutor(ExecutorType.SpSummon, CardId.Ageluobu);
            //格罗布
            AddExecutor(ExecutorType.Activate, CardId.Ageluobu, BuzhihuoEffect);
            //罗布
            AddExecutor(ExecutorType.SpSummon, CardId.Aluobu);
            //罗布
            AddExecutor(ExecutorType.Activate, CardId.Aluobu);
            //水晶罗布
            AddExecutor(ExecutorType.Activate, CardId.Ashuijingluobu, BuzhihuoEffect);
            //红莲魔兽
            AddExecutor(ExecutorType.Summon, CardId.Honglianmo, HonglianmoSummon);
            //咕噜波
            AddExecutor(ExecutorType.Activate, CardId.gululingbo, NoEffect);
            //DD斩首
            AddExecutor(ExecutorType.Activate, CardId.DDzhanshou, NoEffect);
            //存在坍塌
            AddExecutor(ExecutorType.Activate, CardId.Cunzaitanta, Zuizhongaoyi2Effect);
            //假面变化二型
            AddExecutor(ExecutorType.Activate, CardId.Jiamianbianhua, JiamianbianhuaEffect);
            //超融合
            AddExecutor(ExecutorType.Activate, CardId.Chaoronghe, ChaorongheEffect);
            //仙人的召还
            AddExecutor(ExecutorType.Activate, CardId.Xianrenzhaohuan, NoEffect);
            //壶
            AddExecutor(ExecutorType.Activate, CardId.Hu, NoEffect);
            //最终奥义
            AddExecutor(ExecutorType.Activate, CardId.Zuizhongaoyi, ZuizhongaoyiEffect);
            //恶意
            AddExecutor(ExecutorType.Activate, CardId.Eyi);
            //大宇宙
            AddExecutor(ExecutorType.Activate, CardId.Dayuzhou);
            //次元壁
            AddExecutor(ExecutorType.Activate, CardId.Ciyuanbi, CiyuanbiEffect);
            //王宫的舍命
            AddExecutor(ExecutorType.Activate, CardId.Wanggongsheming);
            //神通
            AddExecutor(ExecutorType.Activate, CardId.Shenzhitonggao, SolemnStrike_activate);
            //神宣
            AddExecutor(ExecutorType.Activate, CardId.Shenzhixuangao, SolemnJudgment_activate);
            //不知火流
            AddExecutor(ExecutorType.Activate, CardId.Buzhihuo, BuzhihuoEffect);
            //DIY
            AddExecutor(ExecutorType.Activate, CardId.LUA, LUAEffect);
            //破天 雨卒尔
            AddExecutor(ExecutorType.SpSummon, CardId.Potianyucuier, PotianyucuierSummon);
            //亡龙 雨卒尔
            AddExecutor(ExecutorType.SpSummon, CardId.Wanglongyucuier, PotianyucuierSummon);
            //机巧蛇
            AddExecutor(ExecutorType.Activate, CardId.Jiqiaoshe, JiqiaosheEffect);
            //罗索
            AddExecutor(ExecutorType.Activate, CardId.Aluosuo);
            //布鲁
            AddExecutor(ExecutorType.Activate, CardId.Abulu);
            //散华灵
            AddExecutor(ExecutorType.Activate, CardId.Sanhualing, SanhualingEffect);
            //融合龙
            AddExecutor(ExecutorType.Activate, CardId.Ronghelong);
            //虚拟
            AddExecutor(ExecutorType.Activate, CardId.Xuli);
            //零下
            AddExecutor(ExecutorType.Activate, CardId.Lingxia);
            //李书文
            AddExecutor(ExecutorType.Activate, CardId.Lishuwen);
            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);
            AddExecutor(ExecutorType.SpellSet, CardId.Shenzhitonggao);
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
        //神宣告

        public bool SolemnJudgment_activate()
        {
            if (Util.IsChainTargetOnly(Card) && Bot.HasInHand(CardId.Multifaker)) return false;
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
            return (DefaultSolemnStrike() && spell_trap_activate(true));
        }
        //不能发动
        public bool NoEffect()
        {
            if (Bot.HasInSpellZone(CardId.Wanggongsheming) || Enemy.HasInSpellZone(CardId.Wanggongsheming)) return false;
            return true;
        }
        //罗布/罗索
        private bool AluosuoSummon()
        {
            if (Bot.HasInHand(CardId.Ageliqiao)) return false;
            return true;

        }
        //散华灵
        private bool SanhualingEffect()
        {  
            if (Duel.Player == 0) return false;
            foreach (ClientCard card in Enemy.GetMonsters())
                if (Duel.Player == 1)
                {
                    if (card != null)
                    {
                        if (card.HasType(CardType.Link))
                        {
                            AI.SelectOption(4);
                            return true;
                        }
                        else if (card.HasType(CardType.Fusion))
                        {
                            AI.SelectOption(1);
                            return true;
                        }
                        else if (card.HasType(CardType.Synchro))
                        {
                            AI.SelectOption(2);
                            return true;
                        }
                        else if (card.HasType(CardType.Ritual))
                        {
                            AI.SelectOption(0);
                            return true;
                        }
                        else if (card.HasType(CardType.Xyz))
                        {
                            AI.SelectOption(3);
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
            return false;

        }
        //格丽乔
        private bool AgeliqiaoSummon()
        {
            if (Bot.HasInHand(CardId.Abulu) || Bot.HasInHand(CardId.Aluosuo)) return true;
            return false;
        }
        //不知火
        private bool BuzhihuoEffect()
        {
            if (Duel.CurrentChain.Count > 0)
            {
                return Duel.LastChainPlayer == 1;
            }
            return false;
        }
        private bool HonglianmoSummon()
        {
            if ((Bot.HasInHand(CardId.Potianyucuier) && Bot.ExtraDeck.Count != 0) || (Bot.Banished.Count>=6)) return true;
            return false;
        }
        //水晶罗布
        private bool AshuijingluobuSummon()
        {
            if (Bot.HasInSpellZone(CardId.Dayuzhou) && Bot.HasInExtra(CardId.Ageluobu)) return false;
            return true;
        }
        //雨卒尔
        private bool PotianyucuierSummon()
        {
            if ((Bot.GetMonsterCount() >= 5 && Bot.GetMonstersExtraZoneCount() == 0) || (Bot.GetMonsterCount() >= 6 && Bot.GetMonstersExtraZoneCount() >= 1)) return false;
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
        }
        //存在坍塌
        private bool Zuizhongaoyi2Effect()
        {
            if (Bot.HasInSpellZone(CardId.Wanggongsheming) || Enemy.HasInSpellZone(CardId.Wanggongsheming)) return false;
            if (Bot.GetMonsterCount() < Enemy.GetMonsterCount()) return true;
            return false;
        }
        //最终奥义
        private bool ZuizhongaoyiEffect()
        {
            if ((Bot.GetMonsterCount() <= Enemy.GetMonsterCount()) || (Bot.GetSpellCount() <= Enemy.GetSpellCount())) return true;
            return false;
        }
        //次元壁
        private bool CiyuanbiEffect()
        {
            return (Duel.Player == 1);
        }
        //机巧蛇
        private bool JiqiaosheEffect()
        {
            ClientCard target = Util.GetBestEnemyMonster(true, true);
            if (Card.Location == CardLocation.Hand || Card.Location == CardLocation.Grave)
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            else if (Card.Location == CardLocation.MonsterZone)
            {
                if (target != null)
                {
                    AI.SelectCard(CardId.Hkulouche, CardId.Hkulou,CardId.Ronghelong);
                    AI.SelectNextCard(target);
                    return true;
                }
                return false;
            }
            return false;
        }
        //LUA
        private bool LUAEffect()
        {
            if (Bot.HasInSpellZone(CardId.Wanggongsheming) || Enemy.HasInSpellZone(CardId.Wanggongsheming)) return false;
            if (Duel.LastChainPlayer == 1 && Util.GetLastChainCard() != null)
            {
                int code = Util.GetLastChainCard().Id;
                int alias = Util.GetLastChainCard().Alias;
                if (alias != 0 && alias - code < 10) code = alias;
                if (code == 0) return false;
                    AI.SelectAnnounceID(code);
                    return true;
            }
            return false;
        }
        //超融合
        private bool ChaorongheEffect()
        {
            if (Enemy.GetMonsterCount() <= 1 || Bot.HasInSpellZone(CardId.Wanggongsheming) || Enemy.HasInSpellZone(CardId.Wanggongsheming)) return false;
            {
                ClientCard target = Util.GetBestEnemyMonster();
                AI.SelectCard(CardId.Jiqiaoshe);
                AI.SelectNextCard(target);
                AI.SelectThirdCard(CardId.Pigu, CardId.Ronghelong);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }

        }
        //假面变化
        private bool JiamianbianhuaEffect()
        {
            if (Bot.HasInSpellZone(CardId.Wanggongsheming) || Enemy.HasInSpellZone(CardId.Wanggongsheming)) return false;
            {
                AI.SelectCard(CardId.Jiqiaoshe);
                AI.SelectNextCard(CardId.Honglianmo, CardId.Abulu, CardId.Aluosuo, CardId.Ageliqiao);
                AI.SelectThirdCard(CardId.Jiamianyalang);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }

        }
    }
}
