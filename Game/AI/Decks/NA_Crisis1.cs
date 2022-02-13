using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("Crisis1", "AI_Crisis1")]
    public class Crisis1 : DefaultExecutor
    {
        public class CardId
        {
            public const int Huxiao = 79040001;
            public const int Fengkui = 79040002;
            public const int Feixue = 79040003;
            public const int Xunlian = 79040004;
            public const int FengkuiXun = 79040005;
            public const int Siyang = 79040006;
        }

        private int RockCount = 0;

        public Crisis1(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
            AddExecutor(ExecutorType.Activate, CardId.Siyang, SiyangEffect);
            AddExecutor(ExecutorType.Activate, CardId.FengkuiXun, FengkuiXunEffect);
            AddExecutor(ExecutorType.SpSummon, CardId.Huxiao, HuxiaoSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Fengkui, FengkuiSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Feixue, FeixueSummon);
        }


        private bool SiyangEffect()
        {
            return true;
        }
        private bool FengkuiXunEffect()
        {
            return true;
        }
        private bool HuxiaoSummon()
        {
            return true;
        }
        private bool FengkuiSummon()
        {
            return true;
        }
        private bool FeixueSummon()
        {
            return true;
        }

    }
}
