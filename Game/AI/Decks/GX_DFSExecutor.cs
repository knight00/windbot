using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;


namespace WindBot.Game.AI.Decks
{
    // NOT FINISHED YET
    [Deck("DFS", "AI_DFS", "NotFinished")]
    public class DFSExecutor : DefaultExecutor
    {
        public class CardId
        {

            public const int minjieshizhe = 75043725;
            public const int sanyanguai = 26202165;
            public const int mianhuatang = 31305911;
            public const int jieweishi = 77121851;
            public const int leilong = 31786629;
            public const int xunjiewushu = 22567609;
            public const int jiujifengyinshen = 13893596;

            public const int aikezuodiya = 33396948;
            public const int youwan = 70903634;
            public const int zuowan = 7902349;
            public const int youzu = 8124921;
            public const int zuozu = 44519536;

            public const int Shouzhamosha = 72892473;
            public const int yuchunmaizhan = 81439173;
            public const int chaozhongliwang = 85742772;
            public const int shenhuanbaozha = 57953380;
            public const int anheibaofa = 674561;
            public const int tanlanzhihu = 67169062;
            public const int gelinbubaofahu = 70368879;
            public const int guangzhihufengjian = 72302403;
            public const int anzhiliangchan = 90928333;
            public const int anheizhifei = 30606547;
            public const int bataizhiwu = 30461781;
            public const int qiangyuzhihu = 55144522;
            public const int qiangyuzhiping = 83968380;
            public const int huosiren = 97077563;
            public const int sushenxianzhi = 27551;
            public const int gebulinshouwan = 9744376;
            public const int wumodetanxin = 37576645;

        }

        public DFSExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            //这个固定格式
            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);

            AddExecutor(ExecutorType.SummonOrSet, CardId.minjieshizhe);
            AddExecutor(ExecutorType.Activate, CardId.minjieshizhe);
            AddExecutor(ExecutorType.SummonOrSet, CardId.sanyanguai);
            AddExecutor(ExecutorType.Activate, CardId.sanyanguai);
            AddExecutor(ExecutorType.MonsterSet, CardId.mianhuatang);
            AddExecutor(ExecutorType.Activate, CardId.jieweishi, jieweieffect);
            AddExecutor(ExecutorType.SummonOrSet, CardId.jieweishi);
            
            AddExecutor(ExecutorType.SummonOrSet, CardId.xunjiewushu);
            AddExecutor(ExecutorType.Activate, CardId.xunjiewushu);
            AddExecutor(ExecutorType.Activate, CardId.leilong);
            AddExecutor(ExecutorType.SummonOrSet, CardId.leilong);
            AddExecutor(ExecutorType.SpSummon, CardId.jiujifengyinshen, jiujiettect);
            AddExecutor(ExecutorType.Activate, CardId.jiujifengyinshen, jiuji1ettect);

            AddExecutor(ExecutorType.Activate, CardId.anheibaofa, baofaeffect);
            AddExecutor(ExecutorType.SpellSet, CardId.anheibaofa);
            AddExecutor(ExecutorType.Activate, CardId.tanlanzhihu, tanlaneffcet);
            AddExecutor(ExecutorType.SpellSet, CardId.tanlanzhihu);
            AddExecutor(ExecutorType.Activate, CardId.gelinbubaofahu);
            AddExecutor(ExecutorType.SpellSet, CardId.gelinbubaofahu);
            AddExecutor(ExecutorType.Activate, CardId.guangzhihufengjian, guanfengeffect);
            AddExecutor(ExecutorType.SpellSet, CardId.guangzhihufengjian);
            AddExecutor(ExecutorType.Activate, CardId.anzhiliangchan);
            AddExecutor(ExecutorType.SpellSet, CardId.anzhiliangchan);
            AddExecutor(ExecutorType.Activate, CardId.qiangyuzhihu);
            AddExecutor(ExecutorType.SpellSet, CardId.qiangyuzhihu);
            AddExecutor(ExecutorType.Activate, CardId.anheizhifei);
            AddExecutor(ExecutorType.SpellSet, CardId.anheizhifei);
            AddExecutor(ExecutorType.SpellSet, CardId.bataizhiwu);
            AddExecutor(ExecutorType.Activate, CardId.bataizhiwu);
            AddExecutor(ExecutorType.SpellSet, CardId.gebulinshouwan);
            AddExecutor(ExecutorType.Activate, CardId.gebulinshouwan);
            AddExecutor(ExecutorType.SpellSet, CardId.wumodetanxin);
            AddExecutor(ExecutorType.Activate, CardId.wumodetanxin);
            AddExecutor(ExecutorType.SpellSet, CardId.qiangyuzhiping);
            AddExecutor(ExecutorType.Activate, CardId.qiangyuzhiping);
            AddExecutor(ExecutorType.SpellSet, CardId.huosiren, huosirenset);
            AddExecutor(ExecutorType.Activate, CardId.huosiren, huosireneffect);
            AddExecutor(ExecutorType.SpellSet, CardId.sushenxianzhi, sushenset);
            AddExecutor(ExecutorType.Activate, CardId.sushenxianzhi, susheneffect);
            AddExecutor(ExecutorType.Activate, CardId.yuchunmaizhan, yuchuneffect);
            AddExecutor(ExecutorType.SpellSet, CardId.chaozhongliwang);
            AddExecutor(ExecutorType.Activate, CardId.chaozhongliwang);
            AddExecutor(ExecutorType.Activate, CardId.shenhuanbaozha);
            AddExecutor(ExecutorType.Activate, CardId.Shouzhamosha);


            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
        }


        private bool baofaeffect()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.aikezuodiya);
            SelectedCard.Add(CardId.youwan);
            SelectedCard.Add(CardId.youzu);
            SelectedCard.Add(CardId.zuowan);
            SelectedCard.Add(CardId.zuozu);
            SelectedCard.Add(CardId.sanyanguai);
            AI.SelectCard(SelectedCard);
            return true;
        }
        private bool jiujiettect()
        {

            if (Bot.Graveyard.GetCardCount(CardId.aikezuodiya) >= 1)
            {
                return true;
            }
            if (Bot.Graveyard.GetCardCount(CardId.zuowan) >= 1)
            {
                return true;
            }
            if (Bot.Graveyard.GetCardCount(CardId.zuozu) >= 1)
            {
                return true;
            }
            if (Bot.Graveyard.GetCardCount(CardId.youwan) >= 1)
            {
                return true;
            }
            if (Bot.Graveyard.GetCardCount(CardId.youzu) >= 1)
            {
                return true;
            }

            return false;
        }
        private bool jiuji1ettect()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.leilong);
            SelectedCard.Add(CardId.jieweishi);
            SelectedCard.Add(CardId.xunjiewushu);
            SelectedCard.Add(CardId.sanyanguai);
            SelectedCard.Add(CardId.minjieshizhe);
            AI.SelectCard(SelectedCard);
            return true;
        }
        private bool tanlaneffcet()
        {

            if (Bot.Graveyard.GetCardCount(CardId.aikezuodiya) >= 1)
            {
                IList<int> SelectedCard = new List<int>();
                SelectedCard.Add(CardId.aikezuodiya);
                SelectedCard.Add(CardId.youwan);
                SelectedCard.Add(CardId.youzu);
                SelectedCard.Add(CardId.zuowan);
                SelectedCard.Add(CardId.zuozu);
                SelectedCard.Add(CardId.sanyanguai);
                AI.SelectCard(SelectedCard);
                return true;
            }
            if (Bot.Graveyard.GetCardCount(CardId.zuowan) >= 1)
            {
                IList<int> SelectedCard = new List<int>();
                SelectedCard.Add(CardId.aikezuodiya);
                SelectedCard.Add(CardId.youwan);
                SelectedCard.Add(CardId.youzu);
                SelectedCard.Add(CardId.zuowan);
                SelectedCard.Add(CardId.zuozu);
                SelectedCard.Add(CardId.sanyanguai);
                AI.SelectCard(SelectedCard);
                return true;
            }
            if (Bot.Graveyard.GetCardCount(CardId.zuozu) >= 1)
            {
                IList<int> SelectedCard = new List<int>();
                SelectedCard.Add(CardId.aikezuodiya);
                SelectedCard.Add(CardId.youwan);
                SelectedCard.Add(CardId.youzu);
                SelectedCard.Add(CardId.zuowan);
                SelectedCard.Add(CardId.zuozu);
                SelectedCard.Add(CardId.sanyanguai);
                AI.SelectCard(SelectedCard);
                return true;
            }
            if (Bot.Graveyard.GetCardCount(CardId.youwan) >= 1)
            {
                IList<int> SelectedCard = new List<int>();
                SelectedCard.Add(CardId.aikezuodiya);
                SelectedCard.Add(CardId.youwan);
                SelectedCard.Add(CardId.youzu);
                SelectedCard.Add(CardId.zuowan);
                SelectedCard.Add(CardId.zuozu);
                SelectedCard.Add(CardId.sanyanguai);
                AI.SelectCard(SelectedCard);
                return true;
            }
            if (Bot.Graveyard.GetCardCount(CardId.youzu) >= 1)
            {
                IList<int> SelectedCard = new List<int>();
                SelectedCard.Add(CardId.aikezuodiya);
                SelectedCard.Add(CardId.youwan);
                SelectedCard.Add(CardId.youzu);
                SelectedCard.Add(CardId.zuowan);
                SelectedCard.Add(CardId.zuozu);
                SelectedCard.Add(CardId.sanyanguai);
                AI.SelectCard(SelectedCard);
                return true;
            }

            return false;
        }

        private bool guanfengeffect()
        {
            
            if (Bot.SpellZone.GetCardCount(CardId.guangzhihufengjian) >= 1)
            {
                return false;
            }

            return true;
        }
        private bool jieweieffect()
        {

            if (Bot.MonsterZone.GetCardCount(CardId.jieweishi) >= 1)
            {
                return false;
            }
            if (Bot.SpellZone.GetCardCount(CardId.shenhuanbaozha) >= 1)
            {
                return true;
            }

            return true;

        }

            private bool yuchuneffect()
        {

            if (Bot.MonsterZone.GetCardCount(CardId.xunjiewushu) >= 1)
            {
                AI.SelectCard(CardId.jieweishi);
                return true;
            }
            if (Bot.MonsterZone.GetCardCount(CardId.jieweishi) >= 1)
            {
                AI.SelectCard(CardId.jieweishi);
                return true;
            }
            if (Bot.Hand.GetCardCount(CardId.xunjiewushu) >= 1)
            {
                AI.SelectCard(CardId.jieweishi);
                return true;
            }
            if (Bot.Hand.GetCardCount(CardId.jieweishi) >= 1)
            {
                AI.SelectCard(CardId.jieweishi);
                return true;
            }

            return false;
        }
        private bool baozhaeffect()
        {

            if (Bot.SpellZone.GetCardCount(CardId.shenhuanbaozha) >= 1)
            {
                return false;
            }

            return true;
        }

        private bool huosirenset ()
        {

            if (Bot.HasInSpellZone(CardId.huosiren))
            {
                return false;
            }

            return true;
        }
        private bool huosireneffect ()
        {

            IList<int> targets = new[]
                   {
                    CardId.sanyanguai,
                    CardId.minjieshizhe,
                    };
            if (Bot.HasInGraveyard(targets))
            {
                AI.SelectCard(targets);
                return true;
            }
            return false;

        }



        private bool sushenset()
        {

            if (Bot.HasInSpellZone(CardId.sushenxianzhi))
            {
                return false;
            }

            return true;
        }
        private bool susheneffect()
        {

            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.sanyanguai);
            AI.SelectCard(SelectedCard);
            return true;

        }


    }
}
