using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
using YGOSharp.OCGWrapper.Enums;
namespace WindBot.Game.AI.Decks
{
   
   [Deck("AHDXS", "AI_AHDXS")]
    public class AHDXSExecutor: DefaultExecutor
    {
        public class CardId
        {
            // Initialize all normal monsters
            public const int bei4pi1feng1yin4zhe3de5di4di2zuo3wan4_7902349 = 7902349;
            public const int bei4pi1feng1yin4zhe3de5di4di2you4zu2ju4_8124921 = 8124921;
            public const int bei4pi1feng1yin4zhe3de5di4di2zuo3zu2ju4_44519536 = 44519536;
            public const int bei4pi1feng1yin4zhe3de5di4di2you4wan4_70903634 = 70903634;
            // Initialize all effect monsters
            public const int san1yan3guai4_26202165 = 26202165;
            public const int ju4xing2bing4du2_95178994 = 95178994;
            public const int li4zi5zi3zi2qiu2_40640058 = 40640058;
            public const int jing1shen2ji4sheng1ti3ben4ti1_4266839 = 4266839;
            public const int bu3nao3mo2_40267580 = 40267580;
            public const int hun4hun2hun3dun4zhuan4si3ling2shi1_1434352 = 1434352;
            public const int shen1yuan1de5di4di2an4sha1zhe3_16226786 = 16226786;
            public const int an4zhi1jia3jia4mian4_28933734 = 28933734;
            public const int bei4pi1feng1yin4de5di4di2ai4yi4ke4zuo3di2ya4_33396948 = 33396948;
            // Initialize all special summonable effect monsters
            // Initialize all pure special summonable effect monsters
            public const int hei1an4da4dai4xie2ye2shen2zuo3ke4nei4luo4fa3_900000098 = 900000098;
            // Initialize all link monsters
            // Initialize all spell and trap cards
            public const int si3zhe3su1sheng1_83764718 = 83764718;
            public const int feng1yin4zhi1huang2jin1ju3gui4_75500286 = 75500286;
            public const int guang1zhi1hu4feng1jian4_72302403 = 72302403;
            public const int shou1suo1su4_55713623 = 55713623;
            public const int ti4zui4yang2_73915051 = 73915051;
            public const int tian1shi3shi4de5di4di2tou2shai3zi5zi3zi2_74137509 = 74137509;
            public const int di2ren2cao1cao4zong4qi4_98045062 = 98045062;
            public const int xuan2xuan4feng1_5318639 = 5318639;
            public const int sha1sha4chen2zhi1da4dai4long2juan3juan4quan2_60082869 = 60082869;
            public const int e4e3wu4wu1mo2de5di4di2tou2shai3zi5zi3zi2_126218 = 126218;
            public const int shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762 = 44095762;
            public const int si3zhi1ka3qia3zu3po4huai4pi1pei1bing4du2_57728570 = 57728570;
            public const int mo2fa3tong3_62279055 = 62279055;
            public const int mo2shu4zhu2li3mao4_81210420 = 81210420;
            public const int liu4lu4mang2wang2xing1zhi1zhou4fu4_18807108 = 18807108;
            public const int gong1ji1wu2mo2li4hua4hua1_14315573 = 14315573;
            public const int tianshilili = 79575620;

            public const int laomoshushi = 45141844;
            public const int zhukeling = 20374520;
            public const int jinshufansheshilaimu = 26905245;
            public const int guaishouxian = 21598948;
            public const int hepingshizhe = 44656491;
            public const int yingmujingbi = 22359980;

            public const int chouhenzhadan = 93895605;
            public const int jiliuzhan = 53582587;
            public const int baodaosuo = 99788587;
            public const int diaoding = 38411870;
            public const int dalongjuan = 61068510;
            public const int anheirenou = 31829185;
            public const int sizhimoshuxian = 25774450;
            public const int caozhongsiling = 41442341;
            public const int anheizhifei = 30606547;
            public const int yibinbinduhiechen = 69954399;
            public const int qiuxinliziqiu = 33245030;
            public const int muchankanshouzhe = 11448373;

            // Initialize all useless cards
            public const int GXjimu = 3001;
            public const int GXxizhan = 3002;
            public const int GXyan = 3003;
            public const int GXshoushi = 3004;
            public const int GXtianping = 3005;
            public const int GXyaoshi = 3006;
            public const int GXzhihuilun = 3007;
            public const int GXshiban = 3008;
            public const int GXMofang = 3009;
            public const int DXSJN = 3010;


            public const int TLPD = 94212438;
            public const int TLPE = 31893528;
            public const int TLPA = 67287533;
            public const int TLPT = 94772232;
            public const int TLPH = 30170981;


        }
        public AHDXSExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            // Add Executors to all normal monsters

            //  Add Executors to all special summonable effect monsters
            //  Add Executors to all pure special summonable effect monsters
            AddExecutor(ExecutorType.Activate, CardId.DXSJN);
            AddExecutor(ExecutorType.Repos, CardId.hei1an4da4dai4xie2ye2shen2zuo3ke4nei4luo4fa3_900000098, hei1an4da4dai4xie2ye2shen2zuo3ke4nei4luo4fa3_900000098Repos);
            AddExecutor(ExecutorType.SpSummon, CardId.hei1an4da4dai4xie2ye2shen2zuo3ke4nei4luo4fa3_900000098, hei1an4da4dai4xie2ye2shen2zuo3ke4nei4luo4fa3_900000098SpSummon);
            AddExecutor(ExecutorType.Activate, CardId.hei1an4da4dai4xie2ye2shen2zuo3ke4nei4luo4fa3_900000098, hei1an4da4dai4xie2ye2shen2zuo3ke4nei4luo4fa3_900000098Activate);
            AddExecutor(ExecutorType.MonsterSet, CardId.shen1yuan1de5di4di2an4sha1zhe3_16226786, shen1yuan1de5di4di2an4sha1zhe3_16226786MonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.shen1yuan1de5di4di2an4sha1zhe3_16226786, shen1yuan1de5di4di2an4sha1zhe3_16226786Repos);
            AddExecutor(ExecutorType.Activate, CardId.shen1yuan1de5di4di2an4sha1zhe3_16226786, shen1yuan1de5di4di2an4sha1zhe3_16226786Activate);
            AddExecutor(ExecutorType.MonsterSet, CardId.laomoshushi);
            AddExecutor(ExecutorType.Repos, CardId.laomoshushi);
            AddExecutor(ExecutorType.Activate, CardId.laomoshushi, shen1yuan1de5di4di2an4sha1zhe3_16226786Activate);
            AddExecutor(ExecutorType.MonsterSet, CardId.an4zhi1jia3jia4mian4_28933734, an4zhi1jia3jia4mian4_28933734MonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.an4zhi1jia3jia4mian4_28933734, an4zhi1jia3jia4mian4_28933734Repos);
            AddExecutor(ExecutorType.Activate, CardId.an4zhi1jia3jia4mian4_28933734, an4zhi1jia3jia4mian4_28933734Activate);
            AddExecutor(ExecutorType.MonsterSet, CardId.muchankanshouzhe);
            AddExecutor(ExecutorType.SummonOrSet, CardId.ju4xing2bing4du2_95178994, ju4xing2bing4du2_95178994NormalSummon);
            AddExecutor(ExecutorType.Repos, CardId.ju4xing2bing4du2_95178994, ju4xing2bing4du2_95178994Repos);
            AddExecutor(ExecutorType.Activate, CardId.ju4xing2bing4du2_95178994, ju4xing2bing4du2_95178994Activate);
            AddExecutor(ExecutorType.SummonOrSet, CardId.san1yan3guai4_26202165, san1yan3guai4_26202165NormalSummon);
            AddExecutor(ExecutorType.Repos, CardId.san1yan3guai4_26202165, san1yan3guai4_26202165Repos);
            AddExecutor(ExecutorType.Activate, CardId.san1yan3guai4_26202165, san1yan3guai4_26202165Activate);
            AddExecutor(ExecutorType.MonsterSet, CardId.jing1shen2ji4sheng1ti3ben4ti1_4266839, jing1shen2ji4sheng1ti3ben4ti1_4266839MonsterSet);
            AddExecutor(ExecutorType.Activate, CardId.jing1shen2ji4sheng1ti3ben4ti1_4266839, jing1shen2ji4sheng1ti3ben4ti1_4266839Activate);
            AddExecutor(ExecutorType.Summon, CardId.hun4hun2hun3dun4zhuan4si3ling2shi1_1434352, hun4hun2hun3dun4zhuan4si3ling2shi1_1434352NormalSummon);
            AddExecutor(ExecutorType.Repos, CardId.hun4hun2hun3dun4zhuan4si3ling2shi1_1434352, hun4hun2hun3dun4zhuan4si3ling2shi1_1434352Repos);
            AddExecutor(ExecutorType.Activate, CardId.hun4hun2hun3dun4zhuan4si3ling2shi1_1434352, hun4hun2hun3dun4zhuan4si3ling2shi1_1434352Activate);
            AddExecutor(ExecutorType.Activate, CardId.li4zi5zi3zi2qiu2_40640058, li4zi5zi3zi2qiu2_40640058Activate);
            AddExecutor(ExecutorType.Activate, CardId.qiuxinliziqiu, QXLZQActivate);
            AddExecutor(ExecutorType.Activate, CardId.caozhongsiling, CZSLactivate);
            AddExecutor(ExecutorType.Summon, CardId.caozhongsiling);
            AddExecutor(ExecutorType.Activate, CardId.anheirenou, shen1yuan1de5di4di2an4sha1zhe3_16226786Activate);
            AddExecutor(ExecutorType.SpSummon, CardId.anheirenou);
            AddExecutor(ExecutorType.SpellSet, CardId.xuan2xuan4feng1_5318639, xuan2xuan4feng1_5318639SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.xuan2xuan4feng1_5318639, DefaultMysticalSpaceTyphoon);
            AddExecutor(ExecutorType.SpellSet, CardId.guang1zhi1hu4feng1jian4_72302403, guang1zhi1hu4feng1jian4_72302403SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.guang1zhi1hu4feng1jian4_72302403, guang1zhi1hu4feng1jian4_72302403Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.anheizhifei);
            AddExecutor(ExecutorType.Activate, CardId.anheizhifei);
            AddExecutor(ExecutorType.SpellSet, CardId.yibinbinduhiechen);
            AddExecutor(ExecutorType.Activate, CardId.yibinbinduhiechen, shen1yuan1de5di4di2an4sha1zhe3_16226786Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.yingmujingbi);
            AddExecutor(ExecutorType.Activate, CardId.yingmujingbi, YMJBactivate);
            AddExecutor(ExecutorType.SpellSet, CardId.si3zhi1ka3qia3zu3po4huai4pi1pei1bing4du2_57728570, si3zhi1ka3qia3zu3po4huai4pi1pei1bing4du2_57728570SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.si3zhi1ka3qia3zu3po4huai4pi1pei1bing4du2_57728570, si3zhi1ka3qia3zu3po4huai4pi1pei1bing4du2_57728570Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.jiliuzhan);
            AddExecutor(ExecutorType.Activate, CardId.jiliuzhan, DefaultDarkHole);
            AddExecutor(ExecutorType.SpellSet, CardId.diaoding);
            AddExecutor(ExecutorType.Activate, CardId.diaoding);
            AddExecutor(ExecutorType.SpellSet, CardId.gong1ji1wu2mo2li4hua4hua1_14315573, gong1ji1wu2mo2li4hua4hua1_14315573SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.gong1ji1wu2mo2li4hua4hua1_14315573, gong1ji1wu2mo2li4hua4hua1_14315573Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.chouhenzhadan);
            AddExecutor(ExecutorType.Activate, CardId.chouhenzhadan, CHZAeffect);
            AddExecutor(ExecutorType.SpellSet, CardId.mo2fa3tong3_62279055, mo2fa3tong3_62279055SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.mo2fa3tong3_62279055, mo2fa3tong3_62279055Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762, shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762, DefaultDarkHole);
            AddExecutor(ExecutorType.SpellSet, CardId.di2ren2cao1cao4zong4qi4_98045062, di2ren2cao1cao4zong4qi4_98045062SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.di2ren2cao1cao4zong4qi4_98045062, di2ren2cao1cao4zong4qi4_98045062Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.si3zhe3su1sheng1_83764718, si3zhe3su1sheng1_83764718SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.si3zhe3su1sheng1_83764718, si3zhe3su1sheng1_83764718Activate);
            AddExecutor(ExecutorType.Activate, CardId.GXjimu);
            AddExecutor(ExecutorType.Activate, CardId.GXxizhan, GXxizhaneffect);
            AddExecutor(ExecutorType.Activate, CardId.GXtianping, GXTPeffect);
            AddExecutor(ExecutorType.Activate, CardId.GXyaoshi, ysoshieffect);
            AddExecutor(ExecutorType.Activate, CardId.GXzhihuilun, DefaultTrap);
            AddExecutor(ExecutorType.Activate, CardId.GXMofang, GXMFeffect);
            AddExecutor(ExecutorType.Activate, CardId.DXSJN);


            //unuesing


            AddExecutor(ExecutorType.SpellSet, CardId.feng1yin4zhi1huang2jin1ju3gui4_75500286, feng1yin4zhi1huang2jin1ju3gui4_75500286SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.feng1yin4zhi1huang2jin1ju3gui4_75500286, feng1yin4zhi1huang2jin1ju3gui4_75500286Activate);
            AddExecutor(ExecutorType.MonsterSet, CardId.bu3nao3mo2_40267580, bu3nao3mo2_40267580MonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.bu3nao3mo2_40267580, bu3nao3mo2_40267580Repos);
            AddExecutor(ExecutorType.Activate, CardId.bu3nao3mo2_40267580, bu3nao3mo2_40267580Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.hepingshizhe);
            AddExecutor(ExecutorType.Activate, CardId.hepingshizhe, GWXactivate);
            AddExecutor(ExecutorType.SpellSet, CardId.guaishouxian);
            AddExecutor(ExecutorType.Activate, CardId.guaishouxian, GWXactivate);
            AddExecutor(ExecutorType.SpellSet, CardId.zhukeling);
            AddExecutor(ExecutorType.Activate, CardId.zhukeling);
            AddExecutor(ExecutorType.SpellSet, CardId.jinshufansheshilaimu);
            AddExecutor(ExecutorType.Activate, CardId.jinshufansheshilaimu);
            AddExecutor(ExecutorType.SpellSet, CardId.shou1suo1su4_55713623, shou1suo1su4_55713623SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.shou1suo1su4_55713623, shou1suo1su4_55713623Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.dalongjuan);
            AddExecutor(ExecutorType.Activate, CardId.dalongjuan);
            AddExecutor(ExecutorType.SpellSet, CardId.baodaosuo);
            AddExecutor(ExecutorType.Activate, CardId.baodaosuo);
            AddExecutor(ExecutorType.SpellSet, CardId.tian1shi3shi4de5di4di2tou2shai3zi5zi3zi2_74137509, tian1shi3shi4de5di4di2tou2shai3zi5zi3zi2_74137509SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.tian1shi3shi4de5di4di2tou2shai3zi5zi3zi2_74137509, tian1shi3shi4de5di4di2tou2shai3zi5zi3zi2_74137509Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.e4e3wu4wu1mo2de5di4di2tou2shai3zi5zi3zi2_126218, e4e3wu4wu1mo2de5di4di2tou2shai3zi5zi3zi2_126218SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.e4e3wu4wu1mo2de5di4di2tou2shai3zi5zi3zi2_126218, e4e3wu4wu1mo2de5di4di2tou2shai3zi5zi3zi2_126218Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.mo2shu4zhu2li3mao4_81210420, mo2shu4zhu2li3mao4_81210420SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.mo2shu4zhu2li3mao4_81210420, mo2shu4zhu2li3mao4_81210420Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.liu4lu4mang2wang2xing1zhi1zhou4fu4_18807108, liu4lu4mang2wang2xing1zhi1zhou4fu4_18807108SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.liu4lu4mang2wang2xing1zhi1zhou4fu4_18807108, liu4lu4mang2wang2xing1zhi1zhou4fu4_18807108Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.sha1sha4chen2zhi1da4dai4long2juan3juan4quan2_60082869, sha1sha4chen2zhi1da4dai4long2juan3juan4quan2_60082869SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.sha1sha4chen2zhi1da4dai4long2juan3juan4quan2_60082869, sha1sha4chen2zhi1da4dai4long2juan3juan4quan2_60082869Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.ti4zui4yang2_73915051, ti4zui4yang2_73915051SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.ti4zui4yang2_73915051, ti4zui4yang2_73915051Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.sizhimoshuxian);
            AddExecutor(ExecutorType.Activate, CardId.sizhimoshuxian);

            //Default

            AddExecutor(ExecutorType.Repos, DefaultSFMonsterRepos);

        }

        // All Normal Monster Methods
        public override BattlePhaseAction OnSelectAttackTarget(ClientCard attacker, IList<ClientCard> defenders)
        {
            foreach (ClientCard defender in defenders)
            {
                attacker.RealPower = attacker.Attack;
                defender.RealPower = defender.GetDefensePower();
                if (!OnPreBattleBetween(attacker, defender))
                    continue;

                if (attacker.RealPower > defender.RealPower || (attacker.RealPower >= defender.RealPower && attacker.IsLastAttacker && defender.IsAttack()))
                    return AI.Attack(attacker, defender);
            }

            if (attacker.CanDirectAttack)
                return AI.Attack(attacker, null);

                if (Bot.HasInMonstersZone(CardId.hei1an4da4dai4xie2ye2shen2zuo3ke4nei4luo4fa3_900000098))
                {
                    return AI.Attack(attacker, attacker);
                }
            
            return null;
        }
        private bool CHZAeffect()
        {
            List<ClientCard> spells = Bot.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.gong1ji1wu2mo2li4hua4hua1_14315573) && !spell.IsFacedown())
                    return false;
            }
            return true;
        }
        private bool YMJBactivate()
        {
            if(Bot.LifePoints <=2100)
            {
                AI.OnSelectYesNo(1);
                return false;
            }
            return true;
        }
        private bool QXLZQActivate()
        {
            if (Bot.HasInHand(CardId.li4zi5zi3zi2qiu2_40640058))
            {
                return false;
            }
            return true;
        }
        private bool CZSLactivate()
        {
            ClientCard target = Bot.Graveyard.GetLowestAttackMonster();

            if (target != null && Bot.LifePoints >2000 )
            {
                AI.SelectCard(target);
                return true;
            }
            return false;
        }


        private bool GWXactivate()
        {
            if (Bot.LifePoints <= 500)
            {
                return false;
            }
            return true;
        }

        private bool GXxizhaneffect()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762);
            SelectedCard.Add(CardId.mo2fa3tong3_62279055);
            SelectedCard.Add(CardId.gong1ji1wu2mo2li4hua4hua1_14315573);

            if(Bot.HasInSpellZone(SelectedCard))
            {
                return false;
            }
            if (Bot.HasInHand(CardId.li4zi5zi3zi2qiu2_40640058) )
            {
                return false;
            }
            if (Bot.HasInHand(CardId.qiuxinliziqiu))
            {
                return false;
            }
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (card.IsAttack() && Enemy.BattlingMonster.Attack >= Bot.LifePoints && !Bot.HasInSpellZone(SelectedCard))

                    return true;
            }
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (card.IsAttack() && Enemy.BattlingMonster.Attack >= 4000 && !Bot.HasInSpellZone(SelectedCard) )

                    return true;
            }
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (card.IsCode(CardId.tianshilili) && card.IsAttack() && Enemy.BattlingMonster.Attack + 3000 >= Bot.LifePoints && Enemy.LifePoints > 2000 && !Bot.HasInSpellZone(SelectedCard))
                {
                    return true;
                }
            }

            return false;
        }
        private bool GXMFeffect()
        {
            return true;
        }

        private bool ysoshieffect()
        {
            List<int> cards = new List<int>();

            if (Util.IsOneEnemyBetter())
            {
                AI.SelectCard(CardId.shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762);
                return true;
            }
            if (Enemy.GetMonsterCount() >= 3)
            {
                AI.SelectCard(CardId.shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762);
                return true;
            }

            if (Enemy.GetSpellCount() >= 1)
            {
                AI.SelectCard(CardId.xuan2xuan4feng1_5318639);
                return true;
            }


            return false;
        }
        private bool GXTPeffect()
        {
            //自己手牌少于等于2，场上没卡时，发动效果。
            if (Bot.GetHandCount() <= 2 && Bot.GetMonsterCount() <= 0 && Bot.GetSpellCount() <= 0)
            {
                return true;
            }
            //自己场上没卡，对方手牌大于等于5张，怪兽卡大于等于2个时，发动效果
            if (Enemy.GetHandCount() >= 5 && Enemy.GetMonsterCount() >= 2 && Bot.GetMonsterCount() <= 0 && Bot.GetSpellCount() <= 0)
            {
                return true;
            }
            //对方手牌、场怪兽卡，魔陷卡比我方都多时，发动效果。
            if (Enemy.GetHandCount() > Bot.GetHandCount() && Enemy.GetMonsterCount() > Bot.GetMonsterCount() && Enemy.GetSpellCount() >= Bot.GetSpellCount())
            {
                return true;
            }
            //对方手牌、场怪兽卡比我方都多时,魔陷区少于等于1时，发动效果。
            if (Enemy.GetHandCount() > Bot.GetHandCount() && Enemy.GetMonsterCount() > Bot.GetMonsterCount() && Bot.GetSpellCount() <= 1)
            {
                return true;
            }
            //对方手牌比我方都多,我方场上没有卡时，发动效果。
            if (Enemy.GetHandCount() > Bot.GetHandCount() && Bot.GetMonsterCount() <= 0 && Bot.GetSpellCount() <= 0)
            {
                return true;
            }

            return false;
        }
        private bool bei4pi1feng1yin4zhe3de5di4di2zuo3wan4_7902349NormalSummon()
        {

            return true;
        }

        private bool bei4pi1feng1yin4zhe3de5di4di2zuo3wan4_7902349MonsterSet()
        {

            return true;
        }

        private bool bei4pi1feng1yin4zhe3de5di4di2zuo3wan4_7902349Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool bei4pi1feng1yin4zhe3de5di4di2you4zu2ju4_8124921NormalSummon()
        {

            return true;
        }

        private bool bei4pi1feng1yin4zhe3de5di4di2you4zu2ju4_8124921MonsterSet()
        {

            return true;
        }

        private bool bei4pi1feng1yin4zhe3de5di4di2you4zu2ju4_8124921Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool bei4pi1feng1yin4zhe3de5di4di2zuo3zu2ju4_44519536NormalSummon()
        {

            return true;
        }

        private bool bei4pi1feng1yin4zhe3de5di4di2zuo3zu2ju4_44519536MonsterSet()
        {

            return true;
        }

        private bool bei4pi1feng1yin4zhe3de5di4di2zuo3zu2ju4_44519536Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool bei4pi1feng1yin4zhe3de5di4di2you4wan4_70903634NormalSummon()
        {

            return true;
        }

        private bool bei4pi1feng1yin4zhe3de5di4di2you4wan4_70903634MonsterSet()
        {

            return true;
        }

        private bool bei4pi1feng1yin4zhe3de5di4di2you4wan4_70903634Repos()
        {

            return DefaultMonsterRepos();
        }

            // All Effect Monster Methods

        private bool san1yan3guai4_26202165NormalSummon()
        {

            return true;
        }

        private bool san1yan3guai4_26202165MonsterSet()
        {

            return true;
        }

        private bool san1yan3guai4_26202165Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool san1yan3guai4_26202165Activate()
        {

            return true;
        }

        private bool ju4xing2bing4du2_95178994NormalSummon()
        {

            return true;
        }

        private bool ju4xing2bing4du2_95178994MonsterSet()
        {

            return true;
        }

        private bool ju4xing2bing4du2_95178994Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool ju4xing2bing4du2_95178994Activate()
        {

            return true;
        }

        private bool li4zi5zi3zi2qiu2_40640058NormalSummon()
        {

            return true;
        }

        private bool li4zi5zi3zi2qiu2_40640058MonsterSet()
        {

            return true;
        }

        private bool li4zi5zi3zi2qiu2_40640058Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool li4zi5zi3zi2qiu2_40640058Activate()
        {

            return true;
        }

        private bool jing1shen2ji4sheng1ti3ben4ti1_4266839NormalSummon()
        {

            return true;
        }

        private bool jing1shen2ji4sheng1ti3ben4ti1_4266839MonsterSet()
        {

            return true;
        }

        private bool jing1shen2ji4sheng1ti3ben4ti1_4266839Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool jing1shen2ji4sheng1ti3ben4ti1_4266839Activate()
        {

            return true;
        }

        private bool bu3nao3mo2_40267580NormalSummon()
        {

            return true;
        }

        private bool bu3nao3mo2_40267580MonsterSet()
        {

            return true;
        }

        private bool bu3nao3mo2_40267580Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool bu3nao3mo2_40267580Activate()
        {
            // monsters 选择对方场上攻击力最高的怪兽。
            ClientCard target = Enemy.MonsterZone.GetLowestAttackMonster();

            if (target != null)
            {
                AI.SelectCard(target);
                return true;
            }
            return true;
        }

        private bool hun4hun2hun3dun4zhuan4si3ling2shi1_1434352NormalSummon()
        {

            return true;
        }

        private bool hun4hun2hun3dun4zhuan4si3ling2shi1_1434352MonsterSet()
        {

            return true;
        }

        private bool hun4hun2hun3dun4zhuan4si3ling2shi1_1434352Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool hun4hun2hun3dun4zhuan4si3ling2shi1_1434352Activate()
        {

            return true;
        }

        private bool shen1yuan1de5di4di2an4sha1zhe3_16226786NormalSummon()
        {

            return true;
        }

        private bool shen1yuan1de5di4di2an4sha1zhe3_16226786MonsterSet()
        {

            return true;
        }

        private bool shen1yuan1de5di4di2an4sha1zhe3_16226786Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool shen1yuan1de5di4di2an4sha1zhe3_16226786Activate()
        {
            ClientCard target = Enemy.MonsterZone.GetLowestAttackMonster();

            if (target != null)
            {
                AI.SelectCard(target);
                return true;
            }
            return true;
        }

        private bool an4zhi1jia3jia4mian4_28933734NormalSummon()
        {

            return true;
        }

        private bool an4zhi1jia3jia4mian4_28933734MonsterSet()
        {

            return true;
        }

        private bool an4zhi1jia3jia4mian4_28933734Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool an4zhi1jia3jia4mian4_28933734Activate()
        {

            return true;
        }

        private bool bei4pi1feng1yin4de5di4di2ai4yi4ke4zuo3di2ya4_33396948NormalSummon()
        {

            return true;
        }

        private bool bei4pi1feng1yin4de5di4di2ai4yi4ke4zuo3di2ya4_33396948MonsterSet()
        {

            return true;
        }

        private bool bei4pi1feng1yin4de5di4di2ai4yi4ke4zuo3di2ya4_33396948Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool bei4pi1feng1yin4de5di4di2ai4yi4ke4zuo3di2ya4_33396948Activate()
        {

            return true;
        }

            // All Special Summonable Effect Monster Methods

            // All Pure Special Summonable Effect Monster Methods

        private bool hei1an4da4dai4xie2ye2shen2zuo3ke4nei4luo4fa3_900000098Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool hei1an4da4dai4xie2ye2shen2zuo3ke4nei4luo4fa3_900000098Activate()
        {
            //10个回合后，自己的回合，场上没有大邪神时，发动除外效果
            if (!Bot.HasInMonstersZone(CardId.hei1an4da4dai4xie2ye2shen2zuo3ke4nei4luo4fa3_900000098) && Duel.Turn >= 10 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1)
            {
                return true;
            }
            //卡组少于15张时，场上没有大邪神时，发动除外效果。
            if (!Bot.HasInMonstersZone(CardId.hei1an4da4dai4xie2ye2shen2zuo3ke4nei4luo4fa3_900000098) && Bot.GetdeckCount() <= 15 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1)
            {
                return true;
            }
            //10个回合后，自己回合，对方有2只以上的怪兽在场，发动大邪神摇色子效果。
            if (Enemy.GetMonsterCount() >= 2 && Duel.Turn >= 10 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1 )
            {
                return true;
            }
            //10个回合后，自己回合，对方攻击表示怪兽在场，发动大邪神摇色子效果。
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (card.IsAttack() && Duel.Turn >= 10 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1 )

                    return true;
            }
            return false;
        }

        private bool hei1an4da4dai4xie2ye2shen2zuo3ke4nei4luo4fa3_900000098SpSummon()
        {


            if (Enemy.HasInHand(CardId.bei4pi1feng1yin4de5di4di2ai4yi4ke4zuo3di2ya4_33396948))
            {
                return true;
            }
            if (Enemy.HasInHand(CardId.bei4pi1feng1yin4zhe3de5di4di2you4wan4_70903634))
            {
                return true;
            }
            if (Enemy.HasInHand(CardId.bei4pi1feng1yin4zhe3de5di4di2you4zu2ju4_8124921))
            {
                return true;
            }
            if (Enemy.HasInHand(CardId.bei4pi1feng1yin4zhe3de5di4di2zuo3wan4_7902349))
            {
                return true;
            }
            if (Enemy.HasInHand(CardId.bei4pi1feng1yin4zhe3de5di4di2zuo3zu2ju4_44519536))
            {
                return true;
            }
            // 对方有通灵盘在场，召唤
            if (Enemy.HasInSpellZone(CardId.TLPD) && Enemy.HasInSpellZone(CardId.TLPE) && Enemy.HasInSpellZone(CardId.TLPA))
            {
                return true;
            }
            //生命值低于3000时，召唤
            if (Bot.LifePoints <=3000)
            {
                return true;
            }

            //10回合后，召唤
            if (Duel.Player ==0 && Duel.Turn >=10)
            {
                return true;
            }
            //卡组少于15张时，召唤大邪神
            if (Bot.GetdeckCount() <= 15)
            {
                return true;
            }
            //对方卡组有千年神器时，召唤大邪神
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.GXjimu);
            SelectedCard.Add(CardId.GXyaoshi);
            SelectedCard.Add(CardId.GXshoushi);
            SelectedCard.Add(CardId.GXtianping);
            SelectedCard.Add(CardId.GXxizhan);
            SelectedCard.Add(CardId.GXyan);
            SelectedCard.Add(CardId.GXzhihuilun);
            foreach (ClientCard card in Enemy.ExtraDeck  )
            {
                if (card.IsCode(SelectedCard) && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1)

                    return true;
            }
            return false;
        }

            // All Link Monster Methods

            // All Spell and Trap Card Methods

        private bool si3zhe3su1sheng1_83764718SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool si3zhe3su1sheng1_83764718Activate()
        {

            ClientCard target = Enemy.Graveyard.GetLowestAttackMonster();

            if (target != null && Util.IsOneEnemyBetter())
            {
                AI.SelectCard(target);
                return true;
            }
            return false;
        }

        private bool feng1yin4zhi1huang2jin1ju3gui4_75500286SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool feng1yin4zhi1huang2jin1ju3gui4_75500286Activate()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.si3zhe3su1sheng1_83764718);
            SelectedCard.Add(CardId.bei4pi1feng1yin4de5di4di2ai4yi4ke4zuo3di2ya4_33396948);
            SelectedCard.Add(CardId.bei4pi1feng1yin4zhe3de5di4di2you4wan4_70903634);
            SelectedCard.Add(CardId.bei4pi1feng1yin4zhe3de5di4di2you4zu2ju4_8124921);
            SelectedCard.Add(CardId.bei4pi1feng1yin4zhe3de5di4di2zuo3wan4_7902349);
            SelectedCard.Add(CardId.bei4pi1feng1yin4zhe3de5di4di2zuo3zu2ju4_44519536);
            AI.SelectCard(SelectedCard);
            return true;

        }


        private bool guang1zhi1hu4feng1jian4_72302403SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool guang1zhi1hu4feng1jian4_72302403Activate()
        {

            return true;
        }

        private bool shou1suo1su4_55713623SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool shou1suo1su4_55713623Activate()
        {

            // monsters 选择对方场上攻击力最高的怪兽。
            ClientCard target = Enemy.MonsterZone.GetLowestAttackMonster();

            if (target != null)
            {
                AI.SelectCard(target);
                return true;
            }

            return false;
        }

        private bool ti4zui4yang2_73915051SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool ti4zui4yang2_73915051Activate()
        {

            return true;
        }

        private bool tian1shi3shi4de5di4di2tou2shai3zi5zi3zi2_74137509SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool tian1shi3shi4de5di4di2tou2shai3zi5zi3zi2_74137509Activate()
        {

            return true;
        }

        private bool di2ren2cao1cao4zong4qi4_98045062SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool di2ren2cao1cao4zong4qi4_98045062Activate()
        {
            if(Duel.Player == 1 && Duel.Phase > DuelPhase.BattleStart && Duel.Phase < DuelPhase.Main2)
            {
                AI.SelectOption(0);
                return true;
            }
            if (Duel.Player == 0 && Duel.Phase == DuelPhase.Main1 )
            {
                AI.SelectOption(1);
                return true;
            }
            return false;
        }

        private bool xuan2xuan4feng1_5318639SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool xuan2xuan4feng1_5318639Activate()
        {

            return true;
        }

        private bool sha1sha4chen2zhi1da4dai4long2juan3juan4quan2_60082869SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool sha1sha4chen2zhi1da4dai4long2juan3juan4quan2_60082869Activate()
        {

            return true;
        }

        private bool e4e3wu4wu1mo2de5di4di2tou2shai3zi5zi3zi2_126218SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool e4e3wu4wu1mo2de5di4di2tou2shai3zi5zi3zi2_126218Activate()
        {

            return true;
        }

        private bool shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762Activate()
        {
            List<ClientCard> spells = Bot.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.gong1ji1wu2mo2li4hua4hua1_14315573) && !spell.IsFacedown())
                    return false;
            }
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.chouhenzhadan) && !spell.IsFacedown())
                    return false;
            }
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.mo2fa3tong3_62279055) && !spell.IsFacedown())
                    return false;
            }

            return true;

        }

        private bool si3zhi1ka3qia3zu3po4huai4pi1pei1bing4du2_57728570SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool si3zhi1ka3qia3zu3po4huai4pi1pei1bing4du2_57728570Activate()
        {

            return true;
        }

        private bool mo2fa3tong3_62279055SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool mo2fa3tong3_62279055Activate()
        {
            List<ClientCard> spells = Bot.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.gong1ji1wu2mo2li4hua4hua1_14315573) && !spell.IsFacedown())
                    return false;
            }
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.chouhenzhadan) && !spell.IsFacedown())
                    return false;
            }
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762) && !spell.IsFacedown())
                    return false;
            }
            return true;
        }

        private bool mo2shu4zhu2li3mao4_81210420SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool mo2shu4zhu2li3mao4_81210420Activate()
        {

            return true;
        }

        private bool liu4lu4mang2wang2xing1zhi1zhou4fu4_18807108SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool liu4lu4mang2wang2xing1zhi1zhou4fu4_18807108Activate()
        {
            List<ClientCard> spells = Bot.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.gong1ji1wu2mo2li4hua4hua1_14315573) && !spell.IsFacedown())
                    return false;
            }
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.chouhenzhadan) && !spell.IsFacedown())
                    return false;
            }

            return true;
        }

        private bool gong1ji1wu2mo2li4hua4hua1_14315573SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool gong1ji1wu2mo2li4hua4hua1_14315573Activate()
        {
            List<ClientCard> spells = Bot.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.mo2fa3tong3_62279055) && !spell.IsFacedown())
                    return false;
            }
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.chouhenzhadan) && !spell.IsFacedown())
                    return false;
            }
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762) && !spell.IsFacedown())
                    return false;
            }
            return true;
            
        }

    }
}