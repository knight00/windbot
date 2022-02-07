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
            public const int 呼啸骑士团学徒 = 79040001;
            public const int 锋盔骑士团学徒 = 79040002;
            public const int 沸血骑士团学徒 = 79040003;
            public const int 训练用钳兽 = 79040004;
            public const int 锋盔训练 = 79040005;
            public const int 饲养技巧 = 79040006;
        }

        private int RockCount = 0;

        public Crisis1(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
            AddExecutor(ExecutorType.Activate, CardId.饲养技巧, 饲养技巧效果);
            AddExecutor(ExecutorType.Activate, CardId.锋盔训练, 锋盔训练效果);
            AddExecutor(ExecutorType.SpSummon, CardId.呼啸骑士团学徒, 呼啸骑士团学徒特招);
            AddExecutor(ExecutorType.SpSummon, CardId.锋盔骑士团学徒, 锋盔骑士团学徒特招);
            AddExecutor(ExecutorType.SpSummon, CardId.沸血骑士团学徒, 沸血骑士团学徒特招);
        }


        private bool 饲养技巧效果()
        {
            return true;
        }
        private bool 锋盔训练效果()
        {
            return true;
        }
        private bool 呼啸骑士团学徒特招()
        {
            return true;
        }
        private bool 锋盔骑士团学徒特招()
        {
            return true;
        }
        private bool 沸血骑士团学徒特招()
        {
            return true;
        }

    }
}
