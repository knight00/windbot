using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;


namespace WindBot.Game.AI.Decks
{
    // NOT FINISHED YET
    [Deck("CW", "AI_CW", "NotFinished")]
    public class CWExecutor : DefaultExecutor
    {
        public class CardId
        {
          
            public const int Wmshouqianlong = 76728962;          
            public const int Htshouqianlong = 25551951;
            public const int Jwjinlong = 80280944;
            public const int Cyshenhuanzhe = 48092532;
            public const int Slzhiyan = 28297833;
            public const int Sgzhuifanzhe = 94853057;
            public const int Mianhuatang = 31305911;
            public const int Gzhizhuifanzhe = 61528025;
            public const int Tyisha = 36584821;
            public const int Ycyzhenchaji = 3773196;

            public const int Fyhuanjingui = 75500286;
            public const int Smshimo = 16762927;
            public const int Hunxishou = 68073522;
            public const int Cyliefeng = 81674782;
            public const int MirrorForce = 44095762;
            public const int Dayuzhou = 30241314;
            public const int Acyzhijiefan = 31550470;
            public const int Mogong = 77538567;


        }

        public CWExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            //这个固定格式
            AddExecutor(ExecutorType.Activate, CardId.Fyhuanjingui, Fyhuanjinguieffcet);
            AddExecutor(ExecutorType.SpellSet, CardId.Fyhuanjingui);
            AddExecutor(ExecutorType.Activate, CardId.Cyliefeng, Cyliefengeffcet);
            AddExecutor(ExecutorType.SpellSet, CardId.Cyliefeng);
            AddExecutor(ExecutorType.Activate, CardId.Smshimo, Smshimoeffect);
            AddExecutor(ExecutorType.SpellSet, CardId.Smshimo);
            AddExecutor(ExecutorType.Activate, CardId.Hunxishou, Hunxishoueffcet);
            AddExecutor(ExecutorType.SpellSet, CardId.Hunxishou);
            AddExecutor(ExecutorType.MonsterSet, CardId.Dayuzhou);
            AddExecutor(ExecutorType.Activate, CardId.Dayuzhou, DYZeffect);
            AddExecutor(ExecutorType.Activate, CardId.MirrorForce, DefaultTrap);
            AddExecutor(ExecutorType.Activate, CardId.Acyzhijiefan, Acyeffect);
            AddExecutor(ExecutorType.Activate, CardId.Mogong);
            AddExecutor(ExecutorType.Activate, CardId.Jwjinlong);
            AddExecutor(ExecutorType.Summon, CardId.Jwjinlong);
            AddExecutor(ExecutorType.Activate, CardId.Cyshenhuanzhe);
            AddExecutor(ExecutorType.Summon, CardId.Cyshenhuanzhe);
            AddExecutor(ExecutorType.Summon, CardId.Sgzhuifanzhe);
            AddExecutor(ExecutorType.Summon, CardId.Gzhizhuifanzhe, gzzfzeffect);
            AddExecutor(ExecutorType.MonsterSet, CardId.Gzhizhuifanzhe);
            AddExecutor(ExecutorType.MonsterSet, CardId.Mianhuatang);
            AddExecutor(ExecutorType.Summon, CardId.Htshouqianlong);
            AddExecutor(ExecutorType.Activate, CardId.Htshouqianlong);
            AddExecutor(ExecutorType.Activate, CardId.Wmshouqianlong, Wmshouqianlongeffect);
            AddExecutor(ExecutorType.SpSummon, CardId.Wmshouqianlong);
            AddExecutor(ExecutorType.Summon, CardId.Wmshouqianlong);
            AddExecutor(ExecutorType.Summon, CardId.Tyisha);
            AddExecutor(ExecutorType.Activate, CardId.Slzhiyan);
            AddExecutor(ExecutorType.SummonOrSet, CardId.Slzhiyan);
            AddExecutor(ExecutorType.SummonOrSet, CardId.Ycyzhenchaji); 

            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);
        }



        protected bool Wmshouqianlongeffect()
        {
            
            ClientCard target = Enemy.MonsterZone.GetLowestAttackMonster();

            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (card.IsAttack() && card.Attack >= 2000 && target != null)
                    
                     AI.SelectCard(1);
                     AI.SelectNextCard(target);
                    

                return true;
            }
            return false;
        }


        private bool Fyhuanjinguieffcet()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.Slzhiyan);
            SelectedCard.Add(CardId.Cyliefeng);
            SelectedCard.Add(CardId.Hunxishou);
            SelectedCard.Add(CardId.Wmshouqianlong);
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
        private bool Acyeffect()
        {
            List<ClientCard> spells = Bot.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.Acyzhijiefan) && !spell.IsFacedown())
                    return false;
            }
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.Wmshouqianlong);
            SelectedCard.Add(CardId.Htshouqianlong);
            SelectedCard.Add(CardId.Slzhiyan);
            SelectedCard.Add(CardId.Cyshenhuanzhe);
            AI.SelectCard(SelectedCard);
            return true;
        }

        private bool Hunxishoueffcet()
        {
           
            if (Bot.SpellZone.GetCardCount(CardId.Hunxishou) >= 2)
            {
                return false;
            }

            //召唤
            return true;
        }

        private bool Cyliefengeffcet()
        {
            List<ClientCard> spells = Bot.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.Cyliefeng) && !spell.IsFacedown())
                    return false;
            }

            //召唤
            return true;
        }
        private bool Smshimoeffect()
        {
            List<ClientCard> spells = Bot.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.Smshimo) && !spell.IsFacedown())
                    return false;
            }

            //召唤
            return true;
        }

        
        private bool gzzfzeffect()
        {
            List<ClientCard> spells = Bot.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.Smshimo) && !spell.IsFacedown())
                    return true;
            }

            //召唤
            return false;
        }





    }
}
