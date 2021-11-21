using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    // NOT FINISHED YET
    [Deck("NWS", "AI_NWS", "NotFinished")]
    public class NWSExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Leiji = 12580477;
            public const int Yumaosao = 18144507;
            public const int Yilisi = 74968065;
            public const int Shenzhijuwei = 1353770;
            public const int Qianyuzhihu = 55144522;
            public const int NWSthreenv = 3026686;
            public const int Qixing = 65687442;
            public const int Erzuoju = 92182447;
            public const int MonsterReborn = 83764718;
            public const int MirrorForce = 44095762;
            public const int NWSzhanche = 19190082;
            public const int NWStwonv = 30411385;
            public const int Luogezhiyan = 18478530;
            public const int Yadianna = 48964966;
            public const int NWSxidaer = 2204038;
            public const int Hualijinxin = 5644210;
            public const int NWSonenv = 66809920;
            public const int NWSaierda = 83705073;
            public const int Zhongmuzhiguang = 17956906;

        }

        public NWSExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            

            AddExecutor(ExecutorType.Activate, CardId.MonsterReborn, DefaultCallOfTheHaunted);
            AddExecutor(ExecutorType.SpellSet, CardId.MonsterReborn);
            AddExecutor(ExecutorType.Activate, CardId.Leiji, DefaultDarkHole);
            AddExecutor(ExecutorType.SpellSet, CardId.Leiji);
            AddExecutor(ExecutorType.Activate, CardId.Yumaosao, YumaosaoActive);
            AddExecutor(ExecutorType.SpellSet, CardId.Yumaosao);
            AddExecutor(ExecutorType.Activate, CardId.MirrorForce, DefaultTrap);
            AddExecutor(ExecutorType.Activate, CardId.Yilisi, Yilisieffect);
            AddExecutor(ExecutorType.Activate, CardId.Qianyuzhihu);
            AddExecutor(ExecutorType.Activate, CardId.Shenzhijuwei, SJWeffcet);
            AddExecutor(ExecutorType.Activate, CardId.NWSthreenv, treenveffect);
            AddExecutor(ExecutorType.Summon, CardId.NWSthreenv);
            AddExecutor(ExecutorType.Activate, CardId.Qixing, qixingeffect);
            AddExecutor(ExecutorType.SpellSet, CardId.Erzuoju, EZJeffcet);
            AddExecutor(ExecutorType.Activate, CardId.Erzuoju);
            AddExecutor(ExecutorType.Activate, CardId.NWStwonv, twonveffcet);
            AddExecutor(ExecutorType.Activate, CardId.NWSonenv, onenveffcet);
            AddExecutor(ExecutorType.Activate, CardId.NWSaierda);
            AddExecutor(ExecutorType.Activate, CardId.NWSxidaer);
            AddExecutor(ExecutorType.Summon, CardId.NWSzhanche);
            AddExecutor(ExecutorType.Activate, CardId.NWSzhanche, zhancheeffcet);
            AddExecutor(ExecutorType.SpellSet, CardId.Luogezhiyan);
            AddExecutor(ExecutorType.Activate, CardId.Luogezhiyan);
            AddExecutor(ExecutorType.Activate, CardId.Zhongmuzhiguang, ZMZGeffect);
            AddExecutor(ExecutorType.SummonOrSet, CardId.Yilisi, Yilisisumon);
            AddExecutor(ExecutorType.SpSummon, CardId.NWSaierda);
            AddExecutor(ExecutorType.SpSummon, CardId.NWSonenv);
            AddExecutor(ExecutorType.SpSummon, CardId.NWSthreenv);
            AddExecutor(ExecutorType.SpSummon, CardId.NWStwonv);
            AddExecutor(ExecutorType.SpSummon, CardId.NWSxidaer);
            AddExecutor(ExecutorType.SpSummon, CardId.NWSzhanche);
            AddExecutor(ExecutorType.SpSummon, CardId.Yadianna);


            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
        }

        protected bool twonveffcet()
        {
            ClientCard target = Util.GetBestEnemyMonster();
            if (target != null)
            {
                AI.SelectCard(target);
                return true;
            }
            return true;
        }
        protected bool onenveffcet()
        {

            IList<int> targets = new[]
                   {
                    CardId.Erzuoju,
                    };
            if (Bot.HasInGraveyard(targets))
            {
                
                AI.SelectCard(targets);
                return true;
            }
            
            return true;
        }

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
        private bool EZJeffcet()
        {
            return false;
        }

        private bool Yilisieffect()
        {

            if (Bot.SpellZone.GetCardCount(CardId.Shenzhijuwei) < 1)
            {
                return true;
            }

            //召唤
            return false;
        }
        private bool Yilisisumon()
        {

            if (Bot.GetMonsterCount() <= 0)
            {
                return true;
            }

            //不召唤
            return false;
        }

        private bool SJWeffcet()
        {
                IList<int> SelectedCard = new List<int>();
                SelectedCard.Add(CardId.NWSaierda);
                SelectedCard.Add(CardId.NWSxidaer);
                SelectedCard.Add(CardId.NWStwonv);
                SelectedCard.Add(CardId.NWSonenv);
                AI.SelectCard(SelectedCard);
            if (Card.Location == CardLocation.Hand)
            {
                //AI.SelectPlace(Zones.z2, 2);
                return UniqueFaceupSpell();
            }
            return true;

        }

        private bool treenveffect()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.Qixing);
            SelectedCard.Add(CardId.NWSzhanche);
            SelectedCard.Add(CardId.NWStwonv);
            SelectedCard.Add(CardId.NWSonenv);
            AI.SelectCard(SelectedCard);
            return true;
        }

        private bool qixingeffect()
        {
            if (Enemy.GetHandCount()  == 5 && Enemy.LifePoints >= 8000 && Enemy.GetMonsterCount() <=0 && Enemy.GetSpellCount() <=0)
            {
                return false;
            }
            IList<int> targets = new[]
                   {
                    CardId.NWSzhanche,
                    CardId.NWSxidaer,
                    CardId.NWSonenv,
                    CardId.NWSaierda,
                    CardId.NWStwonv,
                    CardId.NWSthreenv,
                    };
            if (Bot.HasInHand(targets))
            {
                AI.SelectCard(targets);
                return true;
            }

            return true;
        }
        private bool ZMZGeffect()
        {
            if (Bot.LifePoints >= 2000)
            {
                IList<int> SelectedCard = new List<int>();
                SelectedCard.Add(CardId.NWSxidaer);
                SelectedCard.Add(CardId.NWSzhanche);
                SelectedCard.Add(CardId.NWSaierda);
                SelectedCard.Add(CardId.NWStwonv);
                AI.SelectCard(SelectedCard);
                return true;
            }

            return false;
        }

        private bool zhancheeffcet()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.NWSxidaer);
            SelectedCard.Add(CardId.NWSaierda);
            SelectedCard.Add(CardId.NWStwonv);
            SelectedCard.Add(CardId.NWSonenv);
            AI.SelectCard(SelectedCard);
            return true;
        }

        private bool GaleTheWhirlwindEffect()
        {
            if (Card.Position == (int)CardPosition.FaceUp)
            {
                AI.SelectCard(Enemy.GetMonsters().GetHighestAttackMonster());
                return true;
            }
            return false;
        }


    }
}