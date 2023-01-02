using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using System.Linq;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
namespace WindBot.Game.AI.Decks
{
    [Deck("Mode", "AI_Mode")]
    class Mode_ZCGExecutor : DefaultExecutor
    {
        public class CardId
        {

        }
        public Mode_ZCGExecutor(GameAI ai, Duel duel)
         : base(ai, duel)
        {
            AddExecutor(ExecutorType.Activate);
            AddExecutor(ExecutorType.SpSummon);
            AddExecutor(ExecutorType.Summon);
        }
    }
}
