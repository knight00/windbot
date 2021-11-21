using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
using YGOSharp.OCGWrapper.Enums;
namespace WindBot.Game.AI.Decks
{
    
    [Deck("ASF", "AI_ASF")]
    public class ASFExecutor: DefaultExecutor
    {
        public class CardId
        {
            // Initialize all normal monsters
            // Initialize all effect monsters
            public const int anheidaxieshen = 900000098;
            public const int Jushenbin = 2016;
            public const int Moxinren= 9411399;
            public const int Chongciren = 81866673;
            public const int CyberDragon = 70095154;
            public const int Tiankongxia = 40044918;
            public const int Mofagonjishi = 93187568;
            public const int Qingwa = 12538374;
            public const int MingfushizheGeshi = 44330098;
            public const int XuemoD = 83965310;
            public const int Jiaoyiren = 17132130;
            public const int Mojingdaoshi = 2851070;
            public const int Lila = 22624373;
            public const int Guozaomaizhan = 70828912;
            public const int wangongtonggao = 51452091;
            // Initialize all special summonable effect monsters
            // Initialize all pure special summonable effect monsters
            public const int LongqishiD = 76263644;
            // Initialize all link monsters
            // Initialize all spell and trap cards
            public const int Yumaoshao = 18144507;
            public const int Leiji = 12580477;
            public const int Yuchunmaizhang = 81439173;
            public const int Zengyuan = 32807846;
            public const int Qiangyuzhihu = 55144522;
            public const int Mingyunchouka = 45809008;
            public const int Dijiagouwu = 38120068;
            public const int Ronghe = 24094653;
            public const int Sizhesusheng = 83764718;
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

            public const int xiaohunsiling = 23205979;
            public const int Anheishenniao = 11366119;
            public const int qijironghe = 45906428;
            public const int Youmingnvlang = 33574806;
            public const int Dalongjuanxia = 3642509;
            public const int Dadixia = 16304628;
            public const int shanguangxia = 22061412;
            public const int xinbian = 4031928;
            public const int Dadiyanshu = 80344569;
            public const int Mofengdefenxian = 58921041;
            public const int tianshilili = 79575620;
            public const int cichejie = 37694547;
            public const int dajiangjunziyan = 63176202;
            public const int pugongyinshi = 15341821;
            public const int liumangyongbing = 74131780;
            public const int mianmaoshenwu = 15341822;
            public const int mianhuatang = 31305911;
            public const int jiansironghe = 1845204;
            public const int qianyannajishen = 63519819;
            public const int cixinyuxia = 69884162;
            public const int hundunwushi = 9596126;
            public const int hundunzhanshi = 72989439;
            public const int wuzhilong = 12298909;
            public const int modaozashanren = 32362575;
            public const int wangjiachangmianzhigu = 47355498;
            public const int zhongjialubisi = 65403020;
            public const int tushuguang = 70791313;
            public const int ciyuannvzhanshi = 7572887;
            public const int ciyuanzhanshi = 37043180;
            public const int DDanshazhe = 70074904;
            public const int Tianshishishe = 79571449;

            public const int aikezuodiya = 33396948;
            public const int youwan = 70903634;
            public const int zuowan = 7902349;
            public const int youzu = 8124921;
            public const int zuozu = 44519536;

            public const int TLPD = 94212438;
            public const int TLPE = 31893528;
            public const int TLPA = 67287533;
            public const int TLPT = 94772232;
            public const int TLPH = 30170981;

            public const int mofadoushi = 39910367;
            public const int xuwutongzhizhe = 72634965;
            public const int xuwumoren = 47084486;
            public const int shenglilong = 44910027;
            public const int duotianshihushi = 67316075;
            public const int gebulinbaofahu = 70368879;
            public const int shangtang = 22589918;
            public const int shouzhaduansha = 74519184;
            public const int wanbaochui = 85852291;
            public const int mingjieshizhe = 75043725;
            public const int daojishi = 95308449;
            public const int zhenchong = 81843628;
            public const int shouzhamosha = 72892473;
            public const int Jncq = 82732705;
            public const int jiamianbiaohua = 21143940;
            public const int jiamianshenfeng = 22093873;
            public const int jiamiananzhua = 58481572;
            public const int qiangyuzhiping = 83968380;
            public const int wumoudetanxin = 37576645;
            public const int jiliushang = 72283691;
            public const int zhilianjiasuqi = 34906152;

        }
        public ASFExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            // Add Executors to all normal monsters
            // Add Executors to all effect monsters
            AddExecutor(ExecutorType.SpSummon, CardId.anheidaxieshen, AHDXSSpSummon);
            AddExecutor(ExecutorType.Activate, CardId.anheidaxieshen, AHDXSActivate);
            AddExecutor(ExecutorType.Summon, CardId.Jushenbin, ou1bei4li4si1ke4zhi1ju4shen2bing1GX_2016NormalSummon);
            AddExecutor(ExecutorType.Activate, CardId.Jushenbin, ou1bei4li4si1ke4zhi1ju4shen2bing1GX_2016Activate);
            AddExecutor(ExecutorType.SpSummon, CardId.CyberDragon);
            AddExecutor(ExecutorType.Activate, CardId.Moxinren, ming4yun4ying1xiong2mo2xing4ren2_9411399Activate);
            AddExecutor(ExecutorType.Activate, CardId.LongqishiD, long2qi2shi4Dzhong1_76263644Activate);
            AddExecutor(ExecutorType.Activate, CardId.Chongciren, ming4yun4ying1xiong2chong1chong4ci4ci1ren2_81866673Activate);
            AddExecutor(ExecutorType.Activate, CardId.Yumaoshao, ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.Yumaoshao, SpellSeteffect);
            AddExecutor(ExecutorType.Activate, CardId.Yuchunmaizhang, yu2chun3de5di4di2mai2man2zang4_81439173Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.Yuchunmaizhang, SpellSeteffect);
            AddExecutor(ExecutorType.Activate, CardId.Zengyuan, zeng1yuan2_32807846Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.Zengyuan, SpellSeteffect);            
            AddExecutor(ExecutorType.Summon, CardId.Tiankongxia, yuan2su4ying1xiong2tian1kong1kong4xia2_40044918NormalSummon);
            AddExecutor(ExecutorType.Activate, CardId.Tiankongxia, TiankongxiaActivate);
            AddExecutor(ExecutorType.Activate, CardId.jiamianbiaohua, JMBHActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.jiamianbiaohua, SpellSeteffect);
            AddExecutor(ExecutorType.Activate, CardId.Qiangyuzhihu, qiang2qiang3jiang4yu4zhi1hu2_55144522Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.Qiangyuzhihu, SpellSeteffect);
            AddExecutor(ExecutorType.Activate, CardId.hundunwushi, hundunwushiActivate);
            AddExecutor(ExecutorType.Activate, CardId.hundunzhanshi, hundunwushiActivate);
            AddExecutor(ExecutorType.Activate, CardId.XuemoD, ming4yun4ying1xiong2xue4xie3mo2D_83965310Activate);
            AddExecutor(ExecutorType.Activate, CardId.Leiji, DefaultDarkHole);
            AddExecutor(ExecutorType.SpellSet, CardId.Leiji, SpellSeteffect);
            AddExecutor(ExecutorType.SpSummon, CardId.XuemoD, ming4yun4ying1xiong2xue4xie3mo2D_83965310NormalSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Jiaoyiren, ming4yun4ying1xiong2jiao4jiao1yi4ren2_17132130NormalSummon);
            AddExecutor(ExecutorType.Activate, CardId.Jiaoyiren, ming4yun4ying1xiong2jiao4jiao1yi4ren2_17132130Activate);
            AddExecutor(ExecutorType.Summon, CardId.Chongciren, ming4yun4ying1xiong2chong1chong4ci4ci1ren2_81866673NormalSummon);
            AddExecutor(ExecutorType.Activate, CardId.Ronghe, rong2he2ge3_24094653Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.Ronghe, SpellSeteffect);
            AddExecutor(ExecutorType.Summon, CardId.Lila);
            AddExecutor(ExecutorType.Activate, CardId.Lila, Lilaeffect);
            AddExecutor(ExecutorType.SummonOrSet, CardId.xiaohunsiling);
            AddExecutor(ExecutorType.Activate, CardId.xiaohunsiling);
            AddExecutor(ExecutorType.Summon, CardId.Mojingdaoshi);
            AddExecutor(ExecutorType.Activate, CardId.Mojingdaoshi);
            AddExecutor(ExecutorType.MonsterSet, CardId.mianhuatang);
            AddExecutor(ExecutorType.Summon, CardId.Dadiyanshu);
            AddExecutor(ExecutorType.Activate, CardId.Dadiyanshu);
            AddExecutor(ExecutorType.SpSummon, CardId.Mofagonjishi, mo2fa3gong1ji1shi4_93187568NormalSummon);
            AddExecutor(ExecutorType.Activate, CardId.Mofagonjishi, mo2fa3gong1ji1shi4_93187568Activate);
            AddExecutor(ExecutorType.MonsterSet, CardId.modaozashanren);
            AddExecutor(ExecutorType.Repos, CardId.modaozashanren);
            AddExecutor(ExecutorType.Activate, CardId.modaozashanren);
            AddExecutor(ExecutorType.MonsterSet, CardId.Qingwa, huang2quan2qing1wa1_12538374MonsterSet);
            AddExecutor(ExecutorType.Activate, CardId.Qingwa, huang2quan2qing1wa1_12538374Activate);
            AddExecutor(ExecutorType.SpSummon, CardId.MingfushizheGeshi, ming2fu3zhi1shi3shi4zhe3ge2si1_44330098NormalSummon);
            AddExecutor(ExecutorType.Activate, CardId.MingfushizheGeshi, ming2fu3zhi1shi3shi4zhe3ge2si1_44330098Activate);
            AddExecutor(ExecutorType.Activate, CardId.Sizhesusheng, si3zhe3su1sheng1_83764718Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.Sizhesusheng, SpellSeteffect);
            AddExecutor(ExecutorType.Activate, CardId.qijironghe, QJHEActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.qijironghe, SpellSeteffect);
            AddExecutor(ExecutorType.Activate, CardId.Guozaomaizhan, GZMZActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.Guozaomaizhan, SpellSeteffect);
            AddExecutor(ExecutorType.Activate, CardId.wangongtonggao);
            AddExecutor(ExecutorType.SpellSet, CardId.wangongtonggao);
            AddExecutor(ExecutorType.Activate, CardId.Tianshishishe, TSSSeffcet);
            AddExecutor(ExecutorType.SpellSet, CardId.Tianshishishe, SpellSeteffect);
            AddExecutor(ExecutorType.MonsterSet, CardId.Moxinren, ming4yun4ying1xiong2mo2xing4ren2_9411399MonsterSet);

            //  Add Executors to all special summonable effect monsters
            //  Add Executors to all pure special summonable effect monsters

            AddExecutor(ExecutorType.SpSummon, CardId.LongqishiD, long2qi2shi4Dzhong1_76263644SpSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Youmingnvlang, YSspsummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Dalongjuanxia, YSspsummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Dadixia, YSspsummon);
            AddExecutor(ExecutorType.SpSummon, CardId.shanguangxia, YSspsummon);
            AddExecutor(ExecutorType.Activate, CardId.Dadixia, dadixiaactivate);
            AddExecutor(ExecutorType.Activate, CardId.shanguangxia);
            AddExecutor(ExecutorType.SpSummon, CardId.qianyannajishen);
            AddExecutor(ExecutorType.Repos, CardId.qianyannajishen);



            AddExecutor(ExecutorType.Activate, CardId.GXjimu);
            AddExecutor(ExecutorType.Activate, CardId.GXxizhan, GXxizhaneffect);
            AddExecutor(ExecutorType.Activate, CardId.GXtianping, GXTPeffect);
            AddExecutor(ExecutorType.Activate, CardId.GXyaoshi, ysoshieffect);
            AddExecutor(ExecutorType.Activate, CardId.GXzhihuilun, DefaultTrap);
            AddExecutor(ExecutorType.Activate, CardId.GXMofang, GXMFeffect);
            //  Add Executors to all Link monsters
            //  Add Executors to all spell and trap cards
            AddExecutor(ExecutorType.Activate, CardId.xinbian, xinbianeffect);
            AddExecutor(ExecutorType.SpellSet, CardId.xinbian, SpellSeteffect);
            AddExecutor(ExecutorType.Activate, CardId.jiansironghe, JYRHActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.jiansironghe, SpellSeteffect);
            AddExecutor(ExecutorType.Activate, CardId.qianyannajishen, NJActivate);
            AddExecutor(ExecutorType.SpSummon, CardId.hundunwushi, hundunwushispsunnon);
            AddExecutor(ExecutorType.SpSummon, CardId.hundunzhanshi, hundunwushispsunnon);
            AddExecutor(ExecutorType.Activate, CardId.Mingyunchouka, ming4yun4chou1ka3qia3_45809008Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.Mingyunchouka, SpellSeteffect);
            AddExecutor(ExecutorType.MonsterSet, CardId.pugongyinshi);
            AddExecutor(ExecutorType.Activate, CardId.pugongyinshi);
            AddExecutor(ExecutorType.SummonOrSet, CardId.cixinyuxia);
            AddExecutor(ExecutorType.Summon, CardId.wuzhilong, WZLsummon);
            AddExecutor(ExecutorType.Activate, CardId.wuzhilong, DefaultTrap);
            AddExecutor(ExecutorType.Activate, CardId.Dijiagouwu, di3jia4jie4jie5gou4wu4_38120068Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.Dijiagouwu, SpellSeteffect);
            AddExecutor(ExecutorType.Summon, CardId.liumangyongbing);
            AddExecutor(ExecutorType.Activate, CardId.liumangyongbing, liumangActivate);
            AddExecutor(ExecutorType.SpSummon, CardId.jiamianshenfeng);
            AddExecutor(ExecutorType.SpSummon, CardId.jiamiananzhua);
            AddExecutor(ExecutorType.Activate, CardId.jiamiananzhua);
            AddExecutor(ExecutorType.Activate, CardId.jiamianshenfeng);

            AddExecutor(ExecutorType.Repos, DefaultSFMonsterRepos);


        }
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
            if (Bot.HasInMonstersZone(CardId.anheidaxieshen))
            {
                return AI.Attack(attacker, attacker);
            }
            if (Bot.HasInMonstersZone(CardId.Dadiyanshu))
                return AI.Attack(attacker, attacker);

            return null;
        }
        private bool AHDXSActivate()
        {
            //30个回合后，自己的回合，场上没有大邪神时，发动除外效果
            if (!Bot.HasInMonstersZone(CardId.Jushenbin) && !Bot.HasInMonstersZone(CardId.anheidaxieshen) && Duel.Turn >= 30 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1)
            {
                return true;
            }
            //生命值低于1000，自己的回合，场上没有大邪神时，发动除外效果
            if (!Bot.HasInMonstersZone(CardId.Jushenbin) && !Bot.HasInMonstersZone(CardId.anheidaxieshen) && Bot.LifePoints <=1000 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1)
            {
                return true;
            }
            //生命值低于4000，场上没有大邪神时，对方有4只怪兽以上时，发动除外效果
            if (!Bot.HasInMonstersZone(CardId.Jushenbin) && !Bot.HasInMonstersZone(CardId.anheidaxieshen) && Bot.LifePoints <= 4000 && Enemy.GetMonsterCount() >= 4)
            {
                return true;
            }

            //生命值相差5000以上时，自己的回合，场上没有大邪神时，发动除外效果
            if (!Bot.HasInMonstersZone(CardId.Jushenbin) && !Bot.HasInMonstersZone(CardId.anheidaxieshen) && Enemy.LifePoints - Bot.LifePoints >= 5000 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1)
            {
                return true;
            }
            //对方场上有图书馆，场上没有大邪神时，发动除外效果
            if (!Bot.HasInMonstersZone(CardId.Jushenbin) && Enemy.HasInMonstersZone(CardId.tushuguang) && !Bot.HasInMonstersZone(CardId.anheidaxieshen))
            { 
                return true;
            }
            if (!Bot.HasInMonstersZone(CardId.Jushenbin) && Enemy.HasInMonstersZone(CardId.mofadoushi) && !Bot.HasInMonstersZone(CardId.anheidaxieshen))
            {
                return true;
            }
            if (!Bot.HasInMonstersZone(CardId.Jushenbin) && Enemy.HasInMonstersZone(CardId.xuwutongzhizhe) && !Bot.HasInMonstersZone(CardId.anheidaxieshen))
            {
                return true;
            }
            if (!Bot.HasInMonstersZone(CardId.Jushenbin) && Enemy.HasInMonstersZone(CardId.xuwumoren) && !Bot.HasInMonstersZone(CardId.anheidaxieshen))
            {
                return true;
            }
            if (!Bot.HasInMonstersZone(CardId.Jushenbin) && Enemy.HasInMonstersZone(CardId.duotianshihushi) && !Bot.HasInMonstersZone(CardId.anheidaxieshen))
            {
                return true;
            }
            //卡组少于15张时，场上没有大邪神时，发动除外效果。
            if (!Bot.HasInMonstersZone(CardId.Jushenbin) && !Bot.HasInMonstersZone(CardId.anheidaxieshen) && Bot.GetdeckCount() <= 15 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1)
            {
                return true;
            }
            if (!Bot.HasInMonstersZone(CardId.Jushenbin) && !Bot.HasInMonstersZone(CardId.anheidaxieshen) && Bot.GetdeckCount() <= 15 && Enemy.HasInGraveyard(CardId.Qiangyuzhihu))
            {
                return true;
            }
            //对方场上有图书馆，发动大邪神摇色子效果。
            if (!Bot.HasInMonstersZone(CardId.Jushenbin) && Enemy.HasInMonstersZone(CardId.tushuguang) && Bot.HasInMonstersZone(CardId.anheidaxieshen))
            {
                return true;
            }
            //自己回合，对方有2只以上的怪兽在场，发动大邪神摇色子效果。
            if (Bot.HasInMonstersZone(CardId.anheidaxieshen) && !Bot.HasInMonstersZone(CardId.Jushenbin) && Enemy.GetMonsterCount() >= 2 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1)
            {
                return true;
            }
            // 对方有通灵盘在场，发动
            if (Bot.HasInMonstersZone(CardId.anheidaxieshen) && Enemy.HasInSpellZone(CardId.TLPD))
            {
                return true;
            }
            //自己回合，对方攻击表示怪兽在场，发动大邪神摇色子效果。
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (Bot.HasInMonstersZone(CardId.anheidaxieshen) && !Bot.HasInMonstersZone(CardId.Jushenbin) && card.IsAttack() && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1)

                    return true;
            }
            //对方有攻击力大于等于5000的怪兽时，发动除外效果
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (!Bot.HasInMonstersZone(CardId.anheidaxieshen) && !Bot.HasInMonstersZone(CardId.Jushenbin) && card.BaseAttack >=5000 )

                    return true;
            }
            //对方有攻击力大于等于我方生命值，场上怪兽大于等于3只，发动除外效果
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (!Bot.HasInMonstersZone(CardId.anheidaxieshen) &&  card.BaseAttack >= Bot.LifePoints && Enemy.GetSpellCount() >= 3)

                    return true;
            }
            //对方怪兽大于等于4只，魔陷大于等于2张时，发动除外效果。
            if (Enemy.GetMonsterCount() >= 4 && !Bot.HasInMonstersZone(CardId.anheidaxieshen) && !Bot.HasInMonstersZone(CardId.Jushenbin) && Enemy.GetSpellCount() >=2 )
            {
                return true;
            }
            if (Enemy.GetMonsterCount()+ Enemy.GetSpellCount() >= 6 && !Bot.HasInMonstersZone(CardId.anheidaxieshen) && !Bot.HasInMonstersZone(CardId.Jushenbin) && Enemy.GetSpellCount() >= 2)
            {
                return true;
            }
            if (Enemy.GetMonsterCount() + Enemy.GetSpellCount() >= 4 && !Bot.HasInMonstersZone(CardId.anheidaxieshen) && Enemy.HasInSpellZone(CardId.zhilianjiasuqi) )
            {
                return true;
            }
            if (Enemy.GetMonsterCount()  >= 3 && !Bot.HasInMonstersZone(CardId.anheidaxieshen) && Enemy.HasInMonstersZone(CardId.Jushenbin) && Bot.LifePoints <=4000 )
            {
                return true;
            }
            return false;
        }

        private bool AHDXSSpSummon()
        {

            //对方手牌有大法师零件时，特招大邪神。
            if (Enemy.HasInHand(CardId.aikezuodiya))
            {
                return true;
            }
            if (Enemy.HasInHand(CardId.youwan))
            {
                return true;
            }
            if (Enemy.HasInHand(CardId.youzu))
            {
                return true;
            }
            if (Enemy.HasInHand(CardId.zuowan))
            {
                return true;
            }
            if (Enemy.HasInHand(CardId.zuozu))
            {
                return true;
            }
            //30个回合后，自己的回合，特招大邪神。
            if ( Duel.Turn >= 30 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1)
            {
                return true;
            }
            // 对方有通灵盘在场，特招大邪神
            if (Enemy.HasInSpellZone(CardId.TLPD) && Enemy.HasInSpellZone(CardId.TLPE) && Enemy.HasInSpellZone(CardId.TLPA))
            {
                return true;
            }
            //生命值低于1000时，特招大邪神
            if (Bot.LifePoints <= 1000)
            {
                return true;
            }
            //生命值相差5000以上时，自己的回合，特招大邪神
            if ( Enemy.LifePoints - Bot.LifePoints >= 5000 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1)
            {
                return true;
            }
            //对方场上有图书馆、魔法都市、胜利龙、堕天使护士、魔导杂商人，特招大邪神
            if (Enemy.HasInMonstersZone(CardId.tushuguang))
            {
                return true;
            }
            if (Enemy.HasInMonstersZone(CardId.mofadoushi))
            {
                return true;
            }
            if (Enemy.HasInMonstersZone(CardId.shenglilong))
            {
                return true;
            }
            if (Enemy.HasInMonstersZone(CardId.duotianshihushi))
            {
                return true;
            }
            if (Enemy.HasInMonstersZone(CardId.modaozashanren))
            {
                return true;
            }
            if (Enemy.HasInGraveyard(CardId.modaozashanren))
            {
                return true;
            }
            //卡组少于15张时，召唤大邪神
            if (Bot.GetdeckCount() <= 15)
            {
                return true;
            }
            //墓地有这些卡的时候，召唤
            IList<int> tragets = new List<int>();
            tragets.Add(CardId.daojishi);
            tragets.Add(CardId.shangtang);
            tragets.Add(CardId.wanbaochui);
            tragets.Add(CardId.mingjieshizhe);
            tragets.Add(CardId.Tianshishishe);
            tragets.Add(CardId.duotianshihushi);
            tragets.Add(CardId.shouzhaduansha);
            tragets.Add(CardId.gebulinbaofahu);
            tragets.Add(CardId.zhenchong);
            tragets.Add(CardId.shouzhamosha);
            tragets.Add(CardId.wumoudetanxin);
            tragets.Add(CardId.qiangyuzhiping);


            if (Enemy.HasInGraveyard(tragets))
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
            foreach (ClientCard card in Enemy.ExtraDeck)
            {
                if (card.IsCode(SelectedCard) && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1)

                    return true;
            }

            return false;
        }

        private bool JMBHActivate()
        {
            List<int> cards = new List<int>();
            if (Duel.Player == 0 && Duel.Phase < DuelPhase.Main2 && Duel.Phase > DuelPhase.BattleStart && Bot.MonsterZone.GetCardCount(CardId.Tiankongxia) >= 1)
            {
                cards.Add(CardId.Tiankongxia);
                AI.SelectCard(CardId.Tiankongxia);
                return true;
            }
            if (Duel.Player == 0 && Duel.Phase < DuelPhase.Main2 && Duel.Phase > DuelPhase.BattleStart && Enemy.GetMonsterCount() == 0)
            {
                return true;
            }
            if (Bot.MonsterZone.GetCardCount(CardId.Moxinren) >= 1)
            {
                cards.Add(CardId.Moxinren);
                AI.SelectCard(CardId.Moxinren);
                return true;

            }
            if (Bot.HasInMonstersZone(CardId.Chongciren))
            {
                cards.Add(CardId.Chongciren);
                AI.SelectCard(CardId.Chongciren);
                return true;
            }
            if (Bot.HasInMonstersZone(CardId.jiamiananzhua))
            {
                return false;
            }
            if (Bot.HasInMonstersZone(CardId.jiamianshenfeng))
            {
                return false;
            }
            //对方场上有攻击力比天空侠高时，发动。
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (Duel.Player == 1 && Duel.Phase > DuelPhase.Main1 && card.IsAttack() && card.Attack >= 1800)

                    return true;
            }
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (Duel.Player == 0 && card.IsAttack() && card.Attack >= 1800 && !Bot.HasInMonstersZone(CardId.XuemoD))

                    return true;
            }

            return false;

        }
        private bool TSSSeffcet()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.Jushenbin);
            SelectedCard.Add(CardId.Qingwa);
            SelectedCard.Add(CardId.Moxinren);
            SelectedCard.Add(CardId.Chongciren);
            SelectedCard.Add(CardId.CyberDragon);
            SelectedCard.Add(CardId.Jiaoyiren);
            SelectedCard.Add(CardId.modaozashanren);

            if(Bot.HasInHand(SelectedCard))
            {
                AI.SelectCard(SelectedCard);
                return true;
            }
            return false;
        }

        // All Normal Monster Methods

        // All Effect Monster Methods
        private bool Lilaeffect()
        {

            if (Enemy.SpellZone.GetCardCount(CardId.Jncq) >= 1)
            {
                return false;
            }
            if (Enemy.MonsterZone.GetCardCount(CardId.XuemoD) >= 1)
            {
                return false;
            }
            //如果对面魔法区域1张盖卡一张，炸
            if (Enemy.GetSpellCount() >= 1)
            {
                return true;
            }
            //别炸
            return false;
        }
        private bool GXxizhaneffect()
        {
            //对方场上有攻击力比我方生命值高的怪兽时，发动。
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (card.IsAttack() && Enemy.BattlingMonster.Attack >= Bot.LifePoints )
     
                return true;
            }
           //对方场上有攻击力4000以上的怪兽时，发动
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (Enemy.BattlingMonster.Attack >= 4000 && card.IsAttack() )

                    return true;
            }

            //对方生命值大于2000，有天使莉莉发动攻击时，我方生命值少于天使莉莉发动效果后的攻击力值，发动权杖效果。
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (card.IsCode(CardId.tianshilili) && card.IsAttack() &&  Enemy.BattlingMonster.Attack + 3000 >= Bot.LifePoints && Enemy.LifePoints >2000 )
                {
                    return true;
                }
            }
            return false;
        }
        private bool GXMFeffect()
        {
            IList<int> targets = new[] {
                            
                    CardId.Jushenbin,
                    CardId.CyberDragon,
                    CardId.MingfushizheGeshi,
                    CardId.Mofagonjishi,
                    CardId.Moxinren,
                    CardId.Chongciren,
                    CardId.XuemoD,
                    CardId.Jiaoyiren,
                    CardId.LongqishiD,
                    CardId.modaozashanren,
                    CardId.Qingwa,
                    CardId.hundunzhanshi,
                    CardId.mianhuatang,
                    CardId.xiaohunsiling,
                    CardId.Dadiyanshu,
                    CardId.tianshilili,
                    CardId.qianyannajishen,
                    CardId.ciyuannvzhanshi,
                    CardId.ciyuanzhanshi,
                    CardId.DDanshazhe,

                };

            if (Enemy.MonsterZone.GetCardCount(CardId.tushuguang) >= 1 )
            {
                return true;
            }
            if (Bot.HasInBanished(targets))
            {
                return true;
            }
            if(Bot.LifePoints <=1000 && Bot.MonsterZone.GetCardCount(CardId.anheidaxieshen) <1)
            {
                return true;
            }
            return false;
        }
        private bool GXTPeffect()
        {
            //自己手牌少于等于2，场上没卡时，发动效果。
            if (Bot.GetHandCount() <= 2 && Bot.GetMonsterCount() <=0 && Bot.GetSpellCount() <=0 )
            {
                return true;
            }
            //自己场上没卡，对方手牌大于等于5张，怪兽卡大于等于2个时，发动效果
            if (Enemy.GetHandCount() >= 5 && Enemy.GetMonsterCount() >= 2 && Bot.GetMonsterCount() <= 0 && Bot.GetSpellCount() <= 0 )
            {
                return true;
            }
            //对方手牌、场怪兽卡，魔陷卡比我方都多时，发动效果。
            if (Enemy.GetHandCount() > Bot.GetHandCount() && Enemy.GetMonsterCount() > Bot.GetMonsterCount() && Enemy.GetSpellCount() >= Bot.GetSpellCount() )
            {
                return true;
            }
            //对方手牌、场怪兽卡比我方都多时,魔陷区少于等于1时，发动效果。
            if (Enemy.GetHandCount() > Bot.GetHandCount() && Enemy.GetMonsterCount() > Bot.GetMonsterCount() && Bot.GetSpellCount() <= 1 )
            {
                return true;
            }
            //对方手牌比我方都多,我方场上没有卡时，发动效果。
            if (Enemy.GetHandCount() > Bot.GetHandCount() && Bot.GetMonsterCount() <=0 && Bot.GetSpellCount() <= 0)
            {
                return true;
            }

            return false;
        }

        private bool SpellSeteffect()
        {
            if (Bot.GetHandCount() >=7 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main2 )
            {
                return true;
            }
            if (Bot.GetHandCount() >= 7 )
            {
                return true;
            }
            if (Bot.HasInMonstersZone(CardId.LongqishiD) && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1 && Bot.GetHandCount() >= 7)
            {
                return true;
            }
            if (Enemy.SpellZone.GetCardCount(CardId.Mofengdefenxian) >= 1)
            {
                return true;
            }

            return false;
        }

        private bool YSspsummon()
        {
            if (Bot.HasInHand(CardId.XuemoD))
            {
                return false;
            }
            if (Bot.HasInHand(CardId.Jiaoyiren))
            {
                return false;
            }
            return true;
        }
        private bool dadixiaactivate()
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
        private bool hundunwushiActivate()
        {
            IList<int> targets = new[] {
                    
                    CardId.mianhuatang,
                    CardId.xiaohunsiling,
                    CardId.Dadiyanshu,
                    CardId.tianshilili,
                    CardId.qianyannajishen,
                    CardId.ciyuannvzhanshi,
                    CardId.ciyuanzhanshi,
                    CardId.DDanshazhe,

                };

            // monsters 选择对方场上攻击力最高的怪兽。

            List<int> cards = new List<int>();

            foreach (ClientCard card in Enemy.GetMonsters())
            {
                ClientCard target = Enemy.MonsterZone.GetLowestAttackMonster();
                if (target != null && card.Attack >= 2300 )
                {
                    
                    AI.SelectCard(target);
                    return true;
                }

            }
            if(Enemy.HasInMonstersZone(targets))
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Duel.Player == 0 && Duel.Phase > DuelPhase.BattleStart && Duel.Phase < DuelPhase.Main2 )
            {
                return true;
            }

            return false;
        }




        private bool hundunwushispsunnon()
        {
                if (Enemy.HasInSpellZone(CardId.wangjiachangmianzhigu))
                {

                    return false;
                }
                if (Enemy.HasInMonstersZone(CardId.zhongjialubisi))
                {

                    return false;
                }
            
            return true;
        }
        private bool JYRHActivate()
        {

            // 我方生命值大于1000，发动简易融合效果

                if (Bot.LifePoints > 1000   )
                {
                    return true;

                }               
        
            return false;
        }
        private bool NJActivate()
        {

            // monsters 选择对方场上攻击力最高的怪兽。
            ClientCard target = Enemy.MonsterZone.GetLowestAttackMonster();

            AI.SelectCard(target);

                 return true;

        }
        private bool xinbianeffect()
        {
            ClientCard target = Enemy.MonsterZone.GetLowestAttackMonster();


            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (card.IsAttack() && card.Attack > 2000 && Bot.GetMonsterCount() <= 0 && Duel.Player ==0 && Duel.Phase == DuelPhase.Main1 )
                {
                    AI.SelectCard(target);
                }
                return true;
            }
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (card.IsAttack() && card.Attack > Enemy.LifePoints && Enemy.GetMonsterCount() == 1 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1 )
                {
                    AI.SelectCard(target);
                }
                return true;
            }

                if (Bot.HasInHand(CardId.XuemoD) && Bot.GetMonsterCount() == 2 && Enemy.GetMonsterCount() >= 2 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1 )
            {
                   AI.SelectCard(target);
                   return true;
                }
                if (Bot.HasInHandOrHasInMonstersZone(CardId.Jushenbin) && Bot.GetMonsterCount() == 2 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1 )
            {
                   AI.SelectCard(target);
                   return true;
                }
                if (Bot.HasInHand(CardId.Jiaoyiren) && Bot.MonsterZone.GetCardCount(CardId.Moxinren)>=1 && Bot.GetMonsterCount() == 2 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1 )
            {
                   AI.SelectCard(target);
                   return true;
                }
                if (Bot.HasInHand(CardId.Jiaoyiren) && Bot.MonsterZone.GetCardCount(CardId.Chongciren) >= 1 && Bot.GetMonsterCount() == 2 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1 )
            {
                   AI.SelectCard(target);
                   return true;
                }
                if ( Bot.MonsterZone.GetCardCount(CardId.Jushenbin) >= 1 && Bot.GetMonsterCount() >= 2 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1 )
            {
                   AI.SelectCard(target);
                   return true;
                }
                if ( Enemy.MonsterZone.GetCardCount(CardId.dajiangjunziyan)>=1 && Duel.Player == 0 && Duel.Phase == DuelPhase.Main1 )
            {
                AI.SelectCard(CardId.dajiangjunziyan);
                return true;
            }



            return false;
        }
        private bool ysoshieffect()
        {
            List<int> cards = new List<int>();

            if (Util.IsOneEnemyBetter())
            {
                AI.SelectCard(CardId.Leiji);
                return true;
            }
            if (Enemy.GetMonsterCount() >=3)
            {
                AI.SelectCard(CardId.Leiji);
                return true;
            }
            
            if (Enemy.GetSpellCount() >= 2)
            {
                AI.SelectCard(CardId.Yumaoshao);
                return true;
            }
            if (Enemy.HasInSpellZone(CardId.wangjiachangmianzhigu))
            {
                AI.SelectCard(CardId.Yumaoshao);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.Jushenbin))
            {
                AI.SelectCard(CardId.Sizhesusheng);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.qianyannajishen))
            {
                AI.SelectCard(CardId.Sizhesusheng);
                return true;
            }
            if (Bot.HasInHandOrHasInMonstersZone(CardId.XuemoD) && Bot.HasInHand(CardId.Ronghe))
            {
                AI.SelectCard(CardId.Tiankongxia);
                return true;
            }
            if (Bot.HasInHandOrHasInMonstersZone(CardId.Jiaoyiren) && Bot.HasInHand(CardId.Ronghe) )
            {
                AI.SelectCard(CardId.Tiankongxia);
                return true;
            }
            if (Bot.HasInHandOrHasInMonstersZone(CardId.Jiaoyiren) && Bot.HasInHandOrHasInMonstersZone(CardId.XuemoD))
            {
                AI.SelectCard(CardId.Ronghe);
                return true;
            }


            return false;
        }
        private bool ou1bei4li4si1ke4zhi1ju4shen2bing1GX_2016NormalSummon()
        {
            if (Bot.MonsterZone.GetCardCount(CardId.LongqishiD) >=2 )
            {
                return false;
            }
            return true;
        }

        private bool ou1bei4li4si1ke4zhi1ju4shen2bing1GX_2016MonsterSet()
        {

            return true;
        }

        private bool ou1bei4li4si1ke4zhi1ju4shen2bing1GX_2016Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool ou1bei4li4si1ke4zhi1ju4shen2bing1GX_2016Activate()
        {
            if (Enemy.LifePoints <=4000 && Duel.Phase == DuelPhase.Main1)
            {
                AI.SelectOption(1);
                return true;
            }
            if (Enemy.HasAttackingMonster() && Duel.Phase == DuelPhase.Main1 )
            {
                AI.SelectOption(0);
                return true;
            }
            if (!Enemy.HasAttackingMonster() && Enemy.GetMonsterCount() >=1 && Duel.Phase == DuelPhase.Main1)
            {
                AI.SelectOption(1);
                return true;
            }
            if (Enemy.HasInSpellZone(CardId.jiliushang) && Duel.Phase == DuelPhase.Main1)
            {
                AI.SelectOption(1);
                return true;
            }
            if (Enemy.GetMonsterCount() <= 0 && Duel.Phase == DuelPhase.Main1 )
            {
                AI.SelectOption(0);
                return true;
            }
            if (Enemy.GetMonsterCount() >=1 && Duel.Phase == DuelPhase.Main2)
            {
                AI.SelectOption(1);
                return true;
            }
            
            return false;
            
        }
        private bool TiankongxiaActivate()
        {
            List<int> cards = new List<int>();
            ClientCard target = Util.GetBestEnemySpell();

            IList<int> targets = new[] {
                    CardId.XuemoD,
                    CardId.Jiaoyiren,
                    CardId.cixinyuxia,
                    CardId.Moxinren,
                    CardId.Chongciren,
                    CardId.Dadixia,
                    CardId.Dalongjuanxia,
                    CardId.Youmingnvlang,
                };
            

            if (Enemy.GetSpellCount() >= 1 && Bot.MonsterZone.GetCardCount(CardId.Tiankongxia) >= 2)
            {
                AI.SelectOption(0);
                AI.SelectCard(target);
                AI.SelectNextCard(target);
                return true;
            }
            if (Enemy.GetSpellCount()>=1 && Bot.HasInMonstersZone(targets) )
            {
                AI.SelectOption(0);
                AI.SelectCard(target);
                AI.SelectNextCard(target);
                return true;
            }
            if (Enemy.GetSpellCount() >= 1 && !Bot.HasInMonstersZone(targets) && !Bot.HasInHand(CardId.XuemoD) && !Bot.HasInHand(CardId.Jiaoyiren))
            {
                AI.SelectOption(1);
                cards.Add(CardId.XuemoD);
                AI.SelectCard(CardId.XuemoD);
                return true;
            }
            if (Enemy.GetSpellCount() == 0 && !Bot.HasInHand(CardId.XuemoD) && !Bot.HasInHand(CardId.Jiaoyiren))
            {
                AI.SelectOption(1);
                cards.Add(CardId.XuemoD);
                AI.SelectCard(CardId.XuemoD);
                return true;
            }
            if (Enemy.GetSpellCount() == 0 && Bot.HasInHand(CardId.XuemoD))
            {
                AI.SelectOption(1);
                cards.Add(CardId.Jiaoyiren);
                AI.SelectCard(CardId.Jiaoyiren);
                return true;
            }
            if (Enemy.GetSpellCount() == 0 && Bot.HasInMonstersZone(CardId.XuemoD))
            {
                AI.SelectOption(1);
                cards.Add(CardId.Jiaoyiren);
                AI.SelectCard(CardId.Jiaoyiren);
                return true;
            }
            if (Enemy.GetSpellCount() == 0 && Bot.HasInHand(CardId.Jiaoyiren))
            {
                AI.SelectOption(1);
                cards.Add(CardId.XuemoD);
                AI.SelectCard(CardId.XuemoD);
                return true;
            }
            if (Enemy.GetSpellCount() == 0 && Bot.HasInMonstersZone(CardId.Jiaoyiren))
            {
                AI.SelectOption(1);
                cards.Add(CardId.XuemoD);
                AI.SelectCard(CardId.XuemoD);
                return true;
            }
            if (Enemy.GetSpellCount() == 0 && Bot.HasInHand(CardId.hundunwushi))
            {
                AI.SelectOption(1);
                cards.Add(CardId.cixinyuxia);
                AI.SelectCard(CardId.cixinyuxia);
                return true;
            }
            if (Enemy.GetSpellCount() == 0 && Bot.HasInHandOrHasInMonstersZone(CardId.Jiaoyiren) && Bot.HasInHandOrHasInMonstersZone(CardId.XuemoD))
            {
                AI.SelectOption(1);
                cards.Add(CardId.Tiankongxia);
                AI.SelectCard(CardId.Tiankongxia);
                return true;
            }
            if (Enemy.GetSpellCount() >= 1 && !Bot.HasInMonstersZone(targets) && Bot.HasInHand(CardId.Jiaoyiren))
            {
                AI.SelectOption(1);
                cards.Add(CardId.XuemoD);
                AI.SelectCard(CardId.XuemoD);
                return true;
            }
            if (Enemy.GetSpellCount() >= 1 && !Bot.HasInMonstersZone(targets) && Bot.HasInHand(CardId.XuemoD))
            {
                AI.SelectOption(1);
                cards.Add(CardId.Jiaoyiren);
                AI.SelectCard(CardId.Jiaoyiren);
                return true;
            }
            if (Enemy.GetSpellCount() >= 1 && !Bot.HasInMonstersZone(targets) && Bot.HasInHand(CardId.XuemoD) && Bot.HasInHand(CardId.Jiaoyiren))
            {
                AI.SelectOption(1);
                cards.Add(CardId.Tiankongxia);
                AI.SelectCard(CardId.Tiankongxia);
                return true;
            }
            if (Enemy.GetSpellCount() >= 1 && !Bot.HasInMonstersZone(targets) && Bot.HasInHand(CardId.hundunwushi))
            {
                AI.SelectOption(1);
                cards.Add(CardId.cixinyuxia);
                AI.SelectCard(CardId.cixinyuxia);
                return true;
            }


            return true;
        }


        private bool ming4yun4ying1xiong2mo2xing4ren2_9411399NormalSummon()
        {

            return true;
        }

        private bool ming4yun4ying1xiong2mo2xing4ren2_9411399MonsterSet()
        {
            List<int> cards = new List<int>();
            if (Bot.MonsterZone.GetCardCount(CardId.Qingwa) >= 1 && Bot.GetMonsterCount() ==1 )
            {
                cards.Add(CardId.Qingwa);
                AI.SelectCard(CardId.Qingwa);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.Moxinren) >= 1 && Bot.GetMonsterCount() == 1)
            {
                cards.Add(CardId.Moxinren);
                AI.SelectCard(CardId.Moxinren);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.mianmaoshenwu) >= 1)
            {
                cards.Add(CardId.mianmaoshenwu);
                AI.SelectCard(CardId.mianmaoshenwu);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.pugongyinshi) >= 1)
            {
                cards.Add(CardId.pugongyinshi);
                AI.SelectCard(CardId.pugongyinshi);
                return true;

            }
            return false;
        }

        private bool ming4yun4ying1xiong2mo2xing4ren2_9411399Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool ming4yun4ying1xiong2mo2xing4ren2_9411399Activate()
        {
            if(Util.IsOneEnemyBetter())
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }

        private bool ming4yun4ying1xiong2chong1chong4ci4ci1ren2_81866673NormalSummon()
        {
            List<int> cards = new List<int>();
            if (Bot.MonsterZone.GetCardCount(CardId.Qingwa) >= 1)
            {
                cards.Add(CardId.Qingwa);
                AI.SelectCard(CardId.Qingwa);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.Moxinren) >= 1)
            {
                cards.Add(CardId.Moxinren);
                AI.SelectCard(CardId.Moxinren);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.mianmaoshenwu) >= 1 && Bot.MonsterZone.GetCardCount(CardId.XuemoD) <=0 )
            {
                cards.Add(CardId.mianmaoshenwu);
                AI.SelectCard(CardId.mianmaoshenwu);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.mianmaoshenwu) >= 1 && Bot.MonsterZone.GetCardCount(CardId.hundunwushi) <= 0)
            {
                cards.Add(CardId.mianmaoshenwu);
                AI.SelectCard(CardId.mianmaoshenwu);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.mianmaoshenwu) >= 1 && Bot.MonsterZone.GetCardCount(CardId.Jushenbin) <= 0)
            {
                cards.Add(CardId.mianmaoshenwu);
                AI.SelectCard(CardId.mianmaoshenwu);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.mianmaoshenwu) >= 1 && Bot.MonsterZone.GetCardCount(CardId.MingfushizheGeshi) <= 0)
            {
                cards.Add(CardId.mianmaoshenwu);
                AI.SelectCard(CardId.mianmaoshenwu);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.mianmaoshenwu) >= 1 && Bot.MonsterZone.GetCardCount(CardId.Jiaoyiren) <= 0)
            {
                cards.Add(CardId.mianmaoshenwu);
                AI.SelectCard(CardId.mianmaoshenwu);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.pugongyinshi) >= 1)
            {
                cards.Add(CardId.pugongyinshi);
                AI.SelectCard(CardId.pugongyinshi);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.cixinyuxia) >= 1)
            {
                cards.Add(CardId.cixinyuxia);
                AI.SelectCard(CardId.cixinyuxia);
                return true;

            }

            return false;
        }
        private bool WZLsummon()
        {
            List<int> cards = new List<int>();
            if (Bot.MonsterZone.GetCardCount(CardId.Qingwa) >= 1)
            {
                cards.Add(CardId.Qingwa);
                AI.SelectCard(CardId.Qingwa);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.Moxinren) >= 1)
            {
                cards.Add(CardId.Moxinren);
                AI.SelectCard(CardId.Moxinren);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.mianmaoshenwu) >= 1)
            {
                cards.Add(CardId.mianmaoshenwu);
                AI.SelectCard(CardId.mianmaoshenwu);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.pugongyinshi) >= 1)
            {
                cards.Add(CardId.pugongyinshi);
                AI.SelectCard(CardId.pugongyinshi);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.cixinyuxia) >= 1)
            {
                cards.Add(CardId.cixinyuxia);
                AI.SelectCard(CardId.cixinyuxia);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.Chongciren) >= 1)
            {
                cards.Add(CardId.Chongciren);
                AI.SelectCard(CardId.Chongciren);
                return true;

            }

            return false;
        }

        private bool ming4yun4ying1xiong2chong1chong4ci4ci1ren2_81866673MonsterSet()
        {

            return true;
        }

        private bool ming4yun4ying1xiong2chong1chong4ci4ci1ren2_81866673Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool ming4yun4ying1xiong2chong1chong4ci4ci1ren2_81866673Activate()
        {
            List<int> cards = new List<int>();
            if (Bot.MonsterZone.GetCardCount(CardId.Qingwa) >= 1)
            {
                cards.Add(CardId.Qingwa);
                AI.SelectCard(CardId.Qingwa);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.Moxinren) >= 1)
            {
                cards.Add(CardId.Moxinren);
                AI.SelectCard(CardId.Moxinren);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.mianmaoshenwu) >= 1)
            {
                cards.Add(CardId.mianmaoshenwu);
                AI.SelectCard(CardId.mianmaoshenwu);
                return true;

            }
            if (Bot.MonsterZone.GetCardCount(CardId.pugongyinshi) >= 1)
            {
                cards.Add(CardId.pugongyinshi);
                AI.SelectCard(CardId.pugongyinshi);
                return true;

            }
            return false;
            
        }

        private bool yuan2su4ying1xiong2tian1kong1kong4xia2_40044918NormalSummon()
        {

            return true;
        }

        private bool yuan2su4ying1xiong2tian1kong1kong4xia2_40044918MonsterSet()
        {

            return true;
        }

        private bool yuan2su4ying1xiong2tian1kong1kong4xia2_40044918Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool yuan2su4ying1xiong2tian1kong1kong4xia2_40044918Activate()
        {

            return true;
        }

        private bool mo2fa3gong1ji1shi4_93187568NormalSummon()
        {
            if (Bot.MonsterZone.GetCardCount(CardId.Jushenbin) >= 1 && Bot.GetMonsterCount() >=2 )
            {
                return true;
            }
            if (Bot.HasInHand(CardId.Jushenbin) && Bot.GetMonsterCount() >= 2 && Duel.Phase == DuelPhase.Main1 )
            {
                return true;
            }
            if (Bot.HasInHand(CardId.XuemoD) && Bot.GetMonsterCount() >= 2 && Duel.Phase == DuelPhase.Main1 )
            {
                return true;
            }
            if (Bot.HasInHand(CardId.Jiaoyiren) && Bot.GetMonsterCount() >= 2 && Duel.Phase == DuelPhase.Main1 )
            {
                return true;
            }
            if (Enemy.GetMonsterCount() >=1 && Bot.GetMonsterCount() <= 0)
            {
                return true;
            }
            if (Bot.GetHandCount() >= 7 && Duel.Phase == DuelPhase.Main2 )
            {
                return true;
            }
            return false;
        }

        private bool mo2fa3gong1ji1shi4_93187568MonsterSet()
        {

            return true;
        }

        private bool mo2fa3gong1ji1shi4_93187568Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool mo2fa3gong1ji1shi4_93187568Activate()
        {
            return true;
        }

        private bool huang2quan2qing1wa1_12538374NormalSummon()
        {

            return true;
        }

        private bool huang2quan2qing1wa1_12538374MonsterSet()
        {

            return true;
        }

        private bool huang2quan2qing1wa1_12538374Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool huang2quan2qing1wa1_12538374Activate()
        {
            AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }

        private bool ming2fu3zhi1shi3shi4zhe3ge2si1_44330098NormalSummon()
        {

            return true;
        }

        private bool ming2fu3zhi1shi3shi4zhe3ge2si1_44330098MonsterSet()
        {

            return true;
        }

        private bool ming2fu3zhi1shi3shi4zhe3ge2si1_44330098Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool ming2fu3zhi1shi3shi4zhe3ge2si1_44330098Activate()
        {

            return true;
        }

        private bool ming4yun4ying1xiong2xue4xie3mo2D_83965310NormalSummon()
        {
            if (Bot.MonsterZone.GetCardCount(CardId.Jushenbin) >= 1 )
            {
                return false;
            }
            if (Bot.MonsterZone.GetCardCount(CardId.LongqishiD) >= 1 )
            {
                return false;
            }
            if (Bot.MonsterZone.GetCardCount(CardId.XuemoD) >= 1)
            {
                return false;
            }
            if (Bot.MonsterZone.GetCardCount(CardId.Dalongjuanxia) >= 1)
            {
                return false;
            }
            if (Enemy.GetMonsterCount() == 0)
            {
                return false;
            }

            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.Qingwa);
            SelectedCard.Add(CardId.Moxinren);
            SelectedCard.Add(CardId.Chongciren);
            SelectedCard.Add(CardId.Dadiyanshu);
            SelectedCard.Add(CardId.Tiankongxia);
            SelectedCard.Add(CardId.xiaohunsiling);
            AI.SelectCard(SelectedCard);


            return true;
        }

        private bool ming4yun4ying1xiong2xue4xie3mo2D_83965310MonsterSet()
        {

            return true;
        }

        private bool ming4yun4ying1xiong2xue4xie3mo2D_83965310Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool ming4yun4ying1xiong2xue4xie3mo2D_83965310Activate()
        {
            // monsters
            ClientCard target = Enemy.MonsterZone.GetLowestAttackMonster();

            if (target!= null)
            {
                AI.SelectCard(target);
                return true;
            }

            return true;
        }

        private bool ming4yun4ying1xiong2jiao4jiao1yi4ren2_17132130NormalSummon()
        {
            if (Bot.MonsterZone.GetCardCount(CardId.Jushenbin) >= 1)
            {
                return false;
            }
            if (Bot.MonsterZone.GetCardCount(CardId.LongqishiD) >= 1)
            {
                return false;
            }
            if (Bot.MonsterZone.GetCardCount(CardId.XuemoD) >= 1)
            {
                return false;
            }
            if (Bot.MonsterZone.GetCardCount(CardId.Dalongjuanxia) >= 1)
            {
                return false;
            }
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.Qingwa);
            SelectedCard.Add(CardId.Moxinren);
            SelectedCard.Add(CardId.Chongciren);
            SelectedCard.Add(CardId.Dadiyanshu);
            SelectedCard.Add(CardId.Tiankongxia);
            SelectedCard.Add(CardId.xiaohunsiling);
            AI.SelectCard(SelectedCard);
            return true;
        }

        private bool ming4yun4ying1xiong2jiao4jiao1yi4ren2_17132130MonsterSet()
        {

            return true;
        }

        private bool ming4yun4ying1xiong2jiao4jiao1yi4ren2_17132130Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool ming4yun4ying1xiong2jiao4jiao1yi4ren2_17132130Activate()
        {

            return true;
        }

            // All Special Summonable Effect Monster Methods

            // All Pure Special Summonable Effect Monster Methods

        private bool long2qi2shi4Dzhong1_76263644Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool long2qi2shi4Dzhong1_76263644Activate()
        {
            //当对方场上有怪兽的攻击力大于对方生命值时，发动龙骑士d终的效果。
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (card.Attack >= Enemy.LifePoints)
                {
                    return true;
                }
            }
            //当自己场上有巨神兵，对方场上有攻击表示的怪兽，自己场上有3只怪兽时，不发动龙骑士d终效果。
            if (Bot.MonsterZone.GetCardCount(CardId.Jushenbin) >= 1 && Enemy.HasAttackingMonster() && Bot.GetMonsterCount() >=3 )
            {
                return false;
            }
            //当自己场上有巨神兵，对方场上有守备表示的怪兽，自己场上有3只怪兽时，不发动龙骑士d终效果。
            if (Bot.MonsterZone.GetCardCount(CardId.Jushenbin) >= 1 && Enemy.HasDefendingMonster() && Bot.GetMonsterCount() >= 3)
            {
                return false;
            }
            // monsters 对方场上有2只以上怪兽，有攻击力1500以下表侧表示，且全部怪兽都没有我方怪兽强时，不发动d终效果。


            //当对方场上只有一只攻击表示的怪兽并且攻击力少于1500时不发动龙骑士d终效果。
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (card.IsAttack() && card.Attack <= 1500 && Enemy.GetMonsterCount() <=1 )

                    return false;
            }
            // monsters 对方场上有2只以上怪兽，有攻击力1500以下表侧表示，且全部怪兽都没有我方怪兽强时，不发动d终效果。
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (!Util.IsAllEnemyBetter() && Enemy.GetMonsterCount() >= 2 && card.IsAttack() && card.Attack <= 1500)
                {
                    return false;
                }
            }
            // monsters 选择对方场上攻击力最高的怪兽。
            ClientCard target = Enemy.MonsterZone.GetLowestAttackMonster();

            if (target!= null)
            {
                AI.SelectCard(target);
                return true;
            }
            return true;
            
        }

        private bool long2qi2shi4Dzhong1_76263644SpSummon()
        {

            return true;
        }

            // All Link Monster Methods

            // All Spell and Trap Card Methods

        private bool ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507Activate()
        {
            //如果对面魔法区域2张以上，发动羽毛扫效果。
            if (Enemy.GetSpellCount() >= 2)
            {
                return true;
            }
            if (Enemy.HasInSpellZone(CardId.wangjiachangmianzhigu))
            {
                return true;
            }
            List<ClientCard> spells = Bot.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (Enemy.GetSpellCount() >= 1 && !spell.IsFacedown())
                    return true;
            }

            return false;
        }

        private bool lei2ji1_12580477SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool lei2ji1_12580477Activate()
        {

            return true;
        }

        private bool yu2chun3de5di4di2mai2man2zang4_81439173SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool yu2chun3de5di4di2mai2man2zang4_81439173Activate()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.Qingwa);
            SelectedCard.Add(CardId.Moxinren);
            SelectedCard.Add(CardId.pugongyinshi);
            SelectedCard.Add(CardId.Chongciren);
            SelectedCard.Add(CardId.Jushenbin);
            AI.SelectCard(SelectedCard);
            return true;
        }
        private bool liumangActivate()
        {
            // monsters
            ClientCard target = Enemy.MonsterZone.GetLowestAttackMonster();

            if (target != null && Util.IsOneEnemyBetter())
            {
                AI.SelectCard(target);
                return true;
            }
            if (Util.IsAllEnemyBetter())
            {
                AI.SelectCard(target);
                return true;
            }
            return false;
        }

        private bool QJHEActivate()
        {
            if (Enemy.HasInSpellZone(CardId.wangjiachangmianzhigu))
            {

                return false;
            }
            if (Enemy.HasInMonstersZone(CardId.zhongjialubisi))
            {

                return false;
            }
            //在自己主要阶段，对方有一只怪兽比自己场上的怪兽都高时，发动奇迹融合。优先选择大龙卷侠，其次大地侠。
            if (Util.IsOneEnemyBetter()  && Bot.Graveyard.GetCardCount(CardId.LongqishiD) ==0 )
            {
                IList<int> SelectedCard = new List<int>();
                SelectedCard.Add(CardId.Dalongjuanxia);
                SelectedCard.Add(CardId.Dadixia);
                SelectedCard.Add(CardId.shanguangxia);
                SelectedCard.Add(CardId.Youmingnvlang);
                AI.SelectCard(SelectedCard);

                return true;

            }

            return false;
        }

        private bool zeng1yuan2_32807846SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool zeng1yuan2_32807846Activate()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.Tiankongxia);
            SelectedCard.Add(CardId.cixinyuxia);
            SelectedCard.Add(CardId.Mofagonjishi);
            AI.SelectCard(SelectedCard);
            return true;
        }

        private bool qiang2qiang3jiang4yu4zhi1hu2_55144522SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool qiang2qiang3jiang4yu4zhi1hu2_55144522Activate()
        {

            return true;
        }

        private bool ming4yun4chou1ka3qia3_45809008SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool ming4yun4chou1ka3qia3_45809008Activate()
        {
            List<int> cards = new List<int>();
            if (Bot.HasInHand(CardId.Moxinren))
            {
                cards.Add(CardId.Moxinren);
                AI.SelectCard(CardId.Moxinren);
                return true;
            }
            if (Bot.HasInHand(CardId.Chongciren))
            {
                cards.Add(CardId.Chongciren);
                AI.SelectCard(CardId.Chongciren);
                return true;
            }

            return true;
        }

        private bool di3jia4jie4jie5gou4wu4_38120068SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool di3jia4jie4jie5gou4wu4_38120068Activate()
        {

            return true;
        }

        private bool rong2he2ge3_24094653SpellSet()
        {
            return true;
        }

        private bool rong2he2ge3_24094653Activate()
        {
            //当对方场上有一只怪兽攻击力比我方所有怪兽都高时，发动融合。优先选择龙骑士d终，其次大龙卷侠，最后大地侠。
            IList<int> SelectedCard = new List<int>();
            if (Util.IsOneEnemyBetter() && Duel.Phase == DuelPhase.Main1 )
            {
                SelectedCard.Add(CardId.LongqishiD);
                SelectedCard.Add(CardId.Dalongjuanxia);
                SelectedCard.Add(CardId.Dadixia);
                SelectedCard.Add(CardId.shanguangxia);
                SelectedCard.Add(CardId.Youmingnvlang);
                AI.SelectCard(SelectedCard);

                return true;

            }
            //当自己手牌或者场上有血魔d和教义人的时候，发动融合。
            if(Bot.HasInHandOrHasInMonstersZone(CardId.XuemoD) && Bot.HasInHandOrHasInMonstersZone(CardId.Jiaoyiren) )
            {
                SelectedCard.Add(CardId.LongqishiD);
                AI.SelectCard(SelectedCard);

                return true;

            }

            return false;
        }



private bool si3zhe3su1sheng1_83764718SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool si3zhe3su1sheng1_83764718Activate()
        {

            IList<int> targets = new[] {
                    CardId.Jushenbin,
                    CardId.LongqishiD,
                    CardId.qianyannajishen,
                    CardId.hundunzhanshi,
                    CardId.MingfushizheGeshi,
                    CardId.Tiankongxia,
                    CardId.cixinyuxia,
                    CardId.Chongciren,
                    CardId.Dadiyanshu,

                };
            IList<int> target1s = new[] {
                    CardId.wangjiachangmianzhigu,
                    CardId.zhongjialubisi,
                };
            if (Enemy.HasInSpellZone(CardId.wangjiachangmianzhigu))
            {
                
                return false;
            }
            if (Enemy.HasInMonstersZone(CardId.zhongjialubisi))
            {

                return false;
            }

            if (Bot.HasInHandOrHasInMonstersZone(CardId.Jushenbin) && Bot.GetMonsterCount() >= 1 && Duel.Phase == DuelPhase.Main1 && Bot.Hand.GetCardCount(CardId.Sizhesusheng) + Bot.Hand.GetCardCount(CardId.Guozaomaizhan) >= 2 )
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Bot.HasInHand(CardId.XuemoD) && Bot.GetMonsterCount() >= 1 && Duel.Phase == DuelPhase.Main1 && Bot.Hand.GetCardCount(CardId.Sizhesusheng) + Bot.Hand.GetCardCount(CardId.Guozaomaizhan) >= 2 )
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Bot.HasInHandOrHasInMonstersZone(CardId.Jushenbin) && Bot.GetMonsterCount() >= 2 && Duel.Phase == DuelPhase.Main1)
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Bot.HasInHandOrHasInMonstersZone(CardId.XuemoD) && Bot.GetMonsterCount() >= 2 && Duel.Phase == DuelPhase.Main1)
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Bot.HasInHandOrHasInMonstersZone(CardId.Jiaoyiren) && Bot.GetMonsterCount() >= 2 && Duel.Phase == DuelPhase.Main1)
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.Jushenbin) && Bot.GetMonsterCount() >= 2 && Duel.Phase == DuelPhase.Main1 )
            {
                AI.SelectCard(CardId.Jushenbin);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.Jushenbin) && Enemy.GetMonsterCount() <= 0 && Duel.Phase == DuelPhase.Main1)
            {
                AI.SelectCard(CardId.Jushenbin);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.Jushenbin) && Enemy.HasAttackingMonster() && Enemy.GetMonsterCount() <= 1 && Duel.Phase == DuelPhase.Main1)
            {
                AI.SelectCard(CardId.Jushenbin);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.Jushenbin) && Enemy.HasAttackingMonster() && Enemy.LifePoints <=2000 && Duel.Phase == DuelPhase.Main1)
            {
                AI.SelectCard(CardId.Jushenbin);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.LongqishiD) && Duel.Phase == DuelPhase.Main1)
            {
                AI.SelectCard(CardId.LongqishiD);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.hundunzhanshi) )
            {
                AI.SelectCard(CardId.hundunzhanshi);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.qianyannajishen) )
            {
                AI.SelectCard(CardId.qianyannajishen);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.xiaohunsiling) && !Bot.HasInGraveyard(targets) && Bot.GetMonsterCount() == 0)
            {
                AI.SelectCard(CardId.xiaohunsiling);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.mianhuatang) && !Bot.HasInGraveyard(targets) && Bot.GetMonsterCount() == 0)
            {
                AI.SelectCard(CardId.mianhuatang);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            if (Bot.HasInGraveyard(targets) && Bot.GetMonsterCount() == 0 && Enemy.GetMonsterCount() == 0 && Duel.Phase == DuelPhase.Main1)
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Bot.HasInGraveyard(targets) && Bot.GetMonsterCount() == 0 && Enemy.GetMonsterCount() >= 2)
            {
                AI.SelectCard(targets);
                return true;
            }

            if (Enemy.HasInGraveyard(targets) && Bot.GetMonsterCount() == 0 && Enemy.GetMonsterCount() >= 2)
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Enemy.HasInGraveyard(CardId.Tiankongxia) && Bot.HasInMonstersZone(CardId.Tiankongxia) && Enemy.GetSpellCount() >= 1)
            {
                AI.SelectCard(CardId.Tiankongxia);
                return true;
            }

            return false;
            
        }
        private bool GZMZActivate()
        {

            IList<int> targets = new[] {
                    CardId.Jushenbin,
                    CardId.LongqishiD,
                    CardId.qianyannajishen,
                    CardId.hundunzhanshi,
                    CardId.MingfushizheGeshi,
                    CardId.Tiankongxia,
                    CardId.cixinyuxia,
                    CardId.Chongciren,
                    CardId.Dadiyanshu,

                };
            IList<int> target1s = new[] {
                    CardId.wangjiachangmianzhigu,
                    CardId.zhongjialubisi,
                };
            if (Enemy.HasInSpellZone(CardId.wangjiachangmianzhigu))
            {

                return false;
            }
            if (Enemy.HasInMonstersZone(CardId.zhongjialubisi))
            {

                return false;
            }

            if (Bot.HasInHandOrHasInMonstersZone(CardId.Jushenbin) && Bot.GetMonsterCount() >= 1 && Duel.Phase == DuelPhase.Main1 && Bot.Hand.GetCardCount(CardId.Sizhesusheng) + Bot.Hand.GetCardCount(CardId.Guozaomaizhan) >= 2 && Bot.LifePoints > 800)
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Bot.HasInHand(CardId.XuemoD) && Bot.GetMonsterCount() >= 1 && Duel.Phase == DuelPhase.Main1 && Bot.Hand.GetCardCount(CardId.Sizhesusheng) + Bot.Hand.GetCardCount(CardId.Guozaomaizhan) >= 2 && Bot.LifePoints > 800)
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Bot.HasInHandOrHasInMonstersZone(CardId.Jushenbin) && Bot.GetMonsterCount() >= 2 && Duel.Phase == DuelPhase.Main1 && Bot.LifePoints >800 )
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Bot.HasInHandOrHasInMonstersZone(CardId.XuemoD) && Bot.GetMonsterCount() >= 2 && Duel.Phase == DuelPhase.Main1 && Bot.LifePoints > 800)
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Bot.HasInHandOrHasInMonstersZone(CardId.Jiaoyiren) && Bot.GetMonsterCount() >= 2 && Duel.Phase == DuelPhase.Main1 && Bot.LifePoints > 800)
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.Jushenbin) && Bot.GetMonsterCount() >= 2 && Duel.Phase == DuelPhase.Main1 && Bot.LifePoints > 800)
            {
                AI.SelectCard(CardId.Jushenbin);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.Jushenbin) && Enemy.GetMonsterCount() <= 0 && Duel.Phase == DuelPhase.Main1 && Bot.LifePoints > 800)
            {
                AI.SelectCard(CardId.Jushenbin);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.Jushenbin) && Enemy.HasAttackingMonster() && Enemy.GetMonsterCount() <= 1 && Duel.Phase == DuelPhase.Main1 && Bot.LifePoints > 800)
            {
                AI.SelectCard(CardId.Jushenbin);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.Jushenbin) && Enemy.HasAttackingMonster() && Enemy.LifePoints <= 2000 && Duel.Phase == DuelPhase.Main1 && Bot.LifePoints > 800)
            {
                AI.SelectCard(CardId.Jushenbin);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.LongqishiD) && Duel.Phase == DuelPhase.Main1 && Bot.LifePoints > 800)
            {
                AI.SelectCard(CardId.LongqishiD);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.hundunzhanshi) && Bot.LifePoints > 800)
            {
                AI.SelectCard(CardId.hundunzhanshi);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.qianyannajishen) && Bot.LifePoints > 800)
            {
                AI.SelectCard(CardId.qianyannajishen);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }

            if (Bot.HasInGraveyard(targets) && Bot.GetMonsterCount() == 0 && Enemy.GetMonsterCount() == 0 && Duel.Phase == DuelPhase.Main1 && Bot.LifePoints > 800)
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Bot.HasInGraveyard(targets) && Bot.GetMonsterCount() == 0 && Enemy.GetMonsterCount() >= 2  && Bot.LifePoints > 800)
            {
                AI.SelectCard(targets);
                return true;
            }


            return false;
        }

    }
}
