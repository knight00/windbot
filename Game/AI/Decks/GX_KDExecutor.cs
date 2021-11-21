using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;


namespace WindBot.Game.AI.Decks
{
    // NOT FINISHED YET
    [Deck("KD", "AI_KD", "NotFinished")]
    public class KDExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int CyberDragon = 70095154;
            public const int Cixinyuxia = 69884162;
            public const int Leiwang = 71564252;
            public const int Mianhuatang = 31305911;
            public const int Mojindaoshi = 2851070;
            public const int Honest = 37742478;
            public const int Ciyuanzhanshi = 7572887;
            public const int Zhixushouhuzhe = 71799173;


            public const int Leiji = 12580477;
            public const int Yumaosao = 18144507;
            public const int MirrorForce = 44095762;
            public const int Qianyuzhihu = 55144522;
            public const int Dahanbo = 60682203;
            public const int Tangyuzhihu = 67169062;
            public const int Xinbian = 4031928;
            public const int Nailuo = 29401950;
            public const int MonsterReborn = 83764718;
            public const int PotOfDuality = 98645731;
            public const int TheHugeRevolutionIsOver = 99188141;

        }

        public KDExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            //这个固定格式
            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);

            AddExecutor(ExecutorType.Activate, CardId.Yumaosao, YumaosaoActive);
            AddExecutor(ExecutorType.SpellSet, CardId.Yumaosao);
            AddExecutor(ExecutorType.Activate, CardId.Leiji, DefaultDarkHole);
            AddExecutor(ExecutorType.Activate, CardId.Qianyuzhihu);
            AddExecutor(ExecutorType.SpellSet, CardId.Qianyuzhihu);
            AddExecutor(ExecutorType.Activate, CardId.PotOfDuality, PotOfDuality);
            AddExecutor(ExecutorType.SpellSet, CardId.PotOfDuality);
            AddExecutor(ExecutorType.SummonOrSet, CardId.Honest, HonestSummon);
            AddExecutor(ExecutorType.Activate, CardId.Honest, DefaultHonestEffect);
            AddExecutor(ExecutorType.SpSummon, CardId.CyberDragon);
            AddExecutor(ExecutorType.SummonOrSet, CardId.Leiwang);
            AddExecutor(ExecutorType.Activate, CardId.Leiwang);
            AddExecutor(ExecutorType.SpSummon, CardId.Zhixushouhuzhe);
            AddExecutor(ExecutorType.SummonOrSet, CardId.Cixinyuxia);
            AddExecutor(ExecutorType.Summon, CardId.Mojindaoshi);
            AddExecutor(ExecutorType.Activate, CardId.Mojindaoshi);
            AddExecutor(ExecutorType.SummonOrSet, CardId.Ciyuanzhanshi);
            AddExecutor(ExecutorType.Activate, CardId.Ciyuanzhanshi, CiyuzhanshiEffect);
            AddExecutor(ExecutorType.MonsterSet, CardId.Mianhuatang);
            AddExecutor(ExecutorType.Activate, CardId.Mianhuatang);
            AddExecutor(ExecutorType.Activate, CardId.MonsterReborn, DefaultCallOfTheHaunted);
            AddExecutor(ExecutorType.SpellSet, CardId.MonsterReborn);
            AddExecutor(ExecutorType.Activate, CardId.MirrorForce, DefaultTrap);
            AddExecutor(ExecutorType.SpellSet, CardId.Nailuo);
            AddExecutor(ExecutorType.Activate, CardId.Nailuo);
            AddExecutor(ExecutorType.Activate, CardId.TheHugeRevolutionIsOver, DefaultTrap);
            AddExecutor(ExecutorType.SpellSet, CardId.TheHugeRevolutionIsOver);

            AddExecutor(ExecutorType.SummonOrSet, CardId.Zhixushouhuzhe);
            AddExecutor(ExecutorType.Activate, CardId.Dahanbo);
            AddExecutor(ExecutorType.SpellSet, CardId.Dahanbo);
            AddExecutor(ExecutorType.Activate, CardId.Tangyuzhihu, DefaultCallOfTheHaunted1);
            AddExecutor(ExecutorType.SpellSet, CardId.Tangyuzhihu);
            AddExecutor(ExecutorType.Activate, CardId.Xinbian);
            AddExecutor(ExecutorType.SpellSet, CardId.Xinbian);

            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
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
            if (Bot.HasInMonstersZone(CardId.Ciyuanzhanshi))
                return AI.Attack(attacker, attacker);

            return null;
        }

        private bool PotOfDuality()
        {
            List<int> cards = new List<int>();

            if (Util.IsOneEnemyBetter())
            {
                cards.Add(CardId.Leiji);
                cards.Add(CardId.MirrorForce);
            }

            if (Bot.SpellZone[5] == null)
            {
                cards.Add(CardId.Qianyuzhihu);
                cards.Add(CardId.Nailuo);
            }

            cards.Add(CardId.Yumaosao);
            cards.Add(CardId.MonsterReborn);
            cards.Add(CardId.Honest);

            if (cards.Count > 0)
            {
                AI.SelectCard(cards);
                return true;
            }

            return true;
        }
        private bool HonestSummon()
        {
            //如果场上有一只以上了,就别召唤了，容易翻车
            if (Bot.GetHandCount()  <= 1 && Bot.GetMonsterCount() < 1)
            {
                return true;
            }

            //召唤
            return false;
        }


        //发动羽毛扫的条件
        private bool YumaosaoActive()
        {
            //如果对面魔法区域1张盖卡一张，炸
            if (Enemy.GetSpellCount() >= 1)
            {
                return true;
            }
            //别炸
            return false;
        }

        private bool CiyuzhanshiEffect()
        {

            if (Util.IsOneEnemyBetter())

            {
                return true;
            }

            return false;
        }

    }
}
