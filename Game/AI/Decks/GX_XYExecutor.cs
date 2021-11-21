using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;


namespace WindBot.Game.AI.Decks
{
    // NOT FINISHED YET
    [Deck("XY", "AI_XY", "NotFinished")]
    public class XYExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Hundunmosushi = 40737112;
            public const int Anheiqinnuezhe = 56647086;
            public const int Anheiheiyanlong = 66214679;
            public const int Suojia = 77585513;
            public const int Qinjinelong = 97811903;
            public const int Jushenbin = 2016;


            public const int Tianshishishe = 79571449;
            public const int Yumaosao = 18144507;
            public const int Ciyuanronghe = 23557835;
            public const int Qianyuzhihu = 55144522;
            public const int Anzhixiuhuo = 1475311;
            public const int Dijiagouwu = 38120068;
            public const int Ciyuanliefeng = 81674782;
            public const int Ciyuanguihuan = 27174286;
            public const int Shoumoshimo = 16762927;
            public const int Anciyuanjiefang = 31550470;
            public const int Shouzhamosha = 72892473;
            public const int Leiji = 12580477;
            public const int Dayuzhou = 30241314;
            public const int Mogong = 77538567;
            public const int TheHugeRevolutionIsOver = 99188141;
            public const int MirrorForce = 44095762;
            public const int Hunxishou = 68073522;
            public const int Nailou = 29401950;
            public const int Fyhuanjingui = 75500286;
            public const int Jwjinlong = 80280944;

        }

        public XYExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            //这个固定格式
            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);

            AddExecutor(ExecutorType.Activate, CardId.Yumaosao, YumaosaoActive);
            AddExecutor(ExecutorType.SpellSet, CardId.Yumaosao);
            AddExecutor(ExecutorType.Activate, CardId.Leiji, DefaultDarkHole);
            AddExecutor(ExecutorType.Activate, CardId.Fyhuanjingui, Fyhuanjinguieffcet);
            AddExecutor(ExecutorType.SpellSet, CardId.Fyhuanjingui);
            AddExecutor(ExecutorType.Activate, CardId.Qianyuzhihu);
            AddExecutor(ExecutorType.SpellSet, CardId.Qianyuzhihu);
            AddExecutor(ExecutorType.Activate, CardId.Anzhixiuhuo, AZXHeffect);
            AddExecutor(ExecutorType.SpellSet, CardId.Anzhixiuhuo);
            AddExecutor(ExecutorType.Activate, CardId.Dijiagouwu);
            AddExecutor(ExecutorType.SpellSet, CardId.Dijiagouwu);
            AddExecutor(ExecutorType.Activate, CardId.Shoumoshimo, SMSMeffect);
            AddExecutor(ExecutorType.SpellSet, CardId.Shoumoshimo, SMSMeffect);
            AddExecutor(ExecutorType.Activate, CardId.Ciyuanliefeng, CYLFeffect);
            AddExecutor(ExecutorType.SpellSet, CardId.Ciyuanliefeng, CYLFeffect);
            AddExecutor(ExecutorType.Activate, CardId.Hunxishou);
            AddExecutor(ExecutorType.SpellSet, CardId.Hunxishou);
            AddExecutor(ExecutorType.SpellSet, CardId.Ciyuanguihuan, CYGHeffect);
            AddExecutor(ExecutorType.Activate, CardId.Ciyuanguihuan, CYGHeffect);
            AddExecutor(ExecutorType.SpellSet, CardId.Dayuzhou);
            AddExecutor(ExecutorType.Activate, CardId.Dayuzhou, DYZeffect);
            AddExecutor(ExecutorType.SpellSet, CardId.MirrorForce);
            AddExecutor(ExecutorType.Activate, CardId.MirrorForce, DefaultTrap);
            AddExecutor(ExecutorType.SpellSet, CardId.TheHugeRevolutionIsOver);
            AddExecutor(ExecutorType.Activate, CardId.TheHugeRevolutionIsOver, DefaultTrap);
            AddExecutor(ExecutorType.SpellSet, CardId.Anciyuanjiefang);
            AddExecutor(ExecutorType.Activate, CardId.Anciyuanjiefang, ACYJFeffect);
            AddExecutor(ExecutorType.Activate, CardId.Tianshishishe, TSSSeffcet);
            AddExecutor(ExecutorType.SpellSet, CardId.Tianshishishe);
            AddExecutor(ExecutorType.Activate, CardId.Shouzhamosha);
            AddExecutor(ExecutorType.Activate, CardId.Ciyuanronghe, CYRHeffect);
            AddExecutor(ExecutorType.Summon, CardId.Jwjinlong);
            AddExecutor(ExecutorType.Activate, CardId.Jwjinlong);
            AddExecutor(ExecutorType.SpSummon, CardId.Jwjinlong);
            AddExecutor(ExecutorType.Summon, CardId.Jushenbin);
            AddExecutor(ExecutorType.Activate, CardId.Jushenbin, JSBEffect);
            AddExecutor(ExecutorType.Summon, CardId.Suojia);
            AddExecutor(ExecutorType.Activate, CardId.Qinjinelong, QJELeffect);
            AddExecutor(ExecutorType.Activate, CardId.Hundunmosushi, HDMSSeffect);
 
            AddExecutor(ExecutorType.SpellSet, CardId.Mogong);
            AddExecutor(ExecutorType.Activate, CardId.Mogong);
            AddExecutor(ExecutorType.SpellSet, CardId.Nailou);
            AddExecutor(ExecutorType.Activate, CardId.Nailou, DefaultDarkHole);

            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
            
        }


        private bool Fyhuanjinguieffcet()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.Jwjinlong);
            SelectedCard.Add(CardId.Jushenbin);
            SelectedCard.Add(CardId.Anheiheiyanlong);
            SelectedCard.Add(CardId.Hundunmosushi);
            SelectedCard.Add(CardId.Anheiqinnuezhe);
            SelectedCard.Add(CardId.Suojia);
            AI.SelectCard(SelectedCard);
            return true;
        }
        private bool TSSSeffcet()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.Jushenbin);
            SelectedCard.Add(CardId.Anheiheiyanlong);
            SelectedCard.Add(CardId.Hundunmosushi);
            SelectedCard.Add(CardId.Anheiqinnuezhe);
            SelectedCard.Add(CardId.Suojia);
            AI.SelectCard(SelectedCard);
            return true;
        }

        //因为有的怪物有两个技能,所以做选择技能的时候,会调用这里,让我们选择发动第几个效果,返回0代表第一个,返回1代表第二个

        private bool JSBEffect()
        {

            if (Enemy.HasAttackingMonster())
            {
                AI.SelectOption(0);
                return true;
            }
            if (Enemy.GetMonsterCount() <= 0)
            {
                AI.SelectOption(0);
                return true;
            }
            AI.SelectOption(1);
            return true;
        }

        private bool CYGHeffect()
        {
            List<ClientCard> spells = Bot.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.Ciyuanguihuan) && !spell.IsFacedown())
                    return false;
            }
            
            if (Duel.Player == 0 && Duel.Phase == DuelPhase.Main1)
                {
                    return true;
                }
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (card.IsAttack() && card.Attack > 2000 && Bot.GetMonsterCount() <= 0)
                    return true;
            }

            return false;
            
        }

        private bool ACYJFeffect()
        {
            List<ClientCard> spells = Bot.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.Anciyuanjiefang) && !spell.IsFacedown())
                    return false;
            }
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.Hundunmosushi);
            SelectedCard.Add(CardId.Anheiheiyanlong);
            SelectedCard.Add(CardId.Anheiqinnuezhe);
            AI.SelectCard(SelectedCard);

            return true;

        }
        private bool DYZeffect()
        {
            List<ClientCard> spells = Bot.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.Dayuzhou) && !spell.IsFacedown())
                    return false;
            }

            return true;

        }

        private bool AZXHeffect()
        {
            int[] firstMats = new[] {
                CardId.Hundunmosushi,
                CardId.Anheiheiyanlong,
                CardId.Anheiqinnuezhe,
                CardId.Suojia,
            };
            if (Bot.Hand.GetMatchingCardsCount(card => card.IsCode(firstMats)) >= 1)
            {
                return true;
            }
            return false;

        }

        private bool HDMSSeffect()
        {
            List<int> cards = new List<int>();

            if (Util.IsOneEnemyBetter())
            {
                cards.Add(CardId.Ciyuanronghe);
                cards.Add(CardId.Leiji);
            }

            if (Bot.SpellZone[5] == null)
            {
                cards.Add(CardId.Ciyuanronghe);
                cards.Add(CardId.Qianyuzhihu);
            }

            cards.Add(CardId.Yumaosao);
            cards.Add(CardId.Anzhixiuhuo);
            cards.Add(CardId.Tianshishishe);

            if (cards.Count > 0)
            {
                AI.SelectCard(cards);
                return true;
            }

            return true;
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



        private bool CYLFeffect()
        {
            
            if (Bot.SpellZone.GetCardCount(CardId.Ciyuanliefeng) >= 1)
            {
                return false;
            }

            return true;
        }

        private bool SMSMeffect()
        {

            if (Bot.SpellZone.GetCardCount(CardId.Shoumoshimo) >= 1)
            {
                return false;
            }

            return true;
        }



        private bool CYRHeffect()
        {
            if (Bot.Banished.GetCardCount(CardId.Hundunmosushi) >= 1 && Bot.LifePoints >2000)
            {
                return true;
            }
            if (Bot.Banished.GetCardCount(CardId.Anheiheiyanlong) >= 1 && Bot.LifePoints > 2000)
            {
                return true;
            }
            if (Bot.Banished.GetCardCount(CardId.Anheiqinnuezhe) >= 1 && Bot.LifePoints > 2000)
            {
                return true;
            }
            if (Bot.Banished.GetCardCount(CardId.Suojia) >= 1 && Bot.LifePoints > 2000)
            {
                return true;
            }
            if (Bot.Banished.GetCardCount(CardId.Jushenbin) >= 1 && Bot.LifePoints > 2000)
            {
                return true;
            }

            return false;
        }
        private bool QJELeffect()
        {
            if (Bot.LifePoints < 2000)
            {
                return false;
            }


            return true;
        }


    }
}
