using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;


namespace WindBot.Game.AI.Decks
{
    // NOT FINISHED YET
    [Deck("HH", "AI_HH", "NotFinished")]
    public class HHExecutor : DefaultExecutor
    {
        public class CardId
        {
          
            public const int xuanfeng = 5318639;          
            public const int huhuohua = 48686504;
            public const int juxinzhiwu = 53257892;
            public const int zaizhaosishen = 39180960;
            public const int zhiwushizi = 20546916;
            public const int dugengwang = 40320754;
            public const int jinzhiyaojin = 91559748;
            public const int pugongyin = 15341821;
            public const int jinjiaojiachong = 49645921;
            public const int shandian = 69162969;

            public const int Fyhuanjingui = 75500286;
            public const int guangfeng = 72302403;
            public const int yuchongmaizang = 81439173;
            public const int MonsterReborn = 83764718;
            public const int MirrorForce = 44095762;
            public const int Nailuo = 29401950;
            public const int zhaliezhuangjia = 56120475;
            public const int ciyuanyoubi = 70342110;
            public const int wangnengdilei = 77754944;
            public const int zhentongxuetong = 35539880;
            public const int huosiren = 97077563;
            public const int fandageming = 99188141;

        }

        public HHExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            //这个固定格式
            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);

            AddExecutor(ExecutorType.Activate, CardId.xuanfeng, DefaultMysticalSpaceTyphoon);
            AddExecutor(ExecutorType.SpellSet, CardId.xuanfeng);
            AddExecutor(ExecutorType.Summon, CardId.huhuohua, HHHeffect);
            AddExecutor(ExecutorType.Activate, CardId.huhuohua);
            AddExecutor(ExecutorType.Summon, CardId.juxinzhiwu);
            AddExecutor(ExecutorType.Activate, CardId.juxinzhiwu);
            AddExecutor(ExecutorType.SummonOrSet, CardId.zaizhaosishen);
            AddExecutor(ExecutorType.Activate, CardId.zaizhaosishen, ZZSSeffect);
            AddExecutor(ExecutorType.Summon, CardId.zhiwushizi);
            AddExecutor(ExecutorType.SummonOrSet, CardId.dugengwang);
            AddExecutor(ExecutorType.Activate, CardId.dugengwang, DGWeffect);
            AddExecutor(ExecutorType.MonsterSet, CardId.jinzhiyaojin);
            AddExecutor(ExecutorType.Activate, CardId.jinzhiyaojin);
            AddExecutor(ExecutorType.MonsterSet, CardId.pugongyin);
            AddExecutor(ExecutorType.Activate, CardId.pugongyin);
            AddExecutor(ExecutorType.Summon, CardId.jinjiaojiachong);
            AddExecutor(ExecutorType.Activate, CardId.shandian, DefaultDarkHole);
            AddExecutor(ExecutorType.SpellSet, CardId.shandian);
            AddExecutor(ExecutorType.Activate, CardId.Fyhuanjingui, Fyhuanjinguieffcet);
            AddExecutor(ExecutorType.SpellSet, CardId.Fyhuanjingui);
            AddExecutor(ExecutorType.Activate, CardId.yuchongmaizang, YCMZeffect);
            AddExecutor(ExecutorType.SpellSet, CardId.yuchongmaizang);
            AddExecutor(ExecutorType.Activate, CardId.MonsterReborn, DefaultCallOfTheHaunted);
            AddExecutor(ExecutorType.SpellSet, CardId.MonsterReborn);
            AddExecutor(ExecutorType.Activate, CardId.Nailuo);
            AddExecutor(ExecutorType.SpellSet, CardId.Nailuo);
            AddExecutor(ExecutorType.Activate, CardId.MirrorForce, DefaultTrap);
            AddExecutor(ExecutorType.Activate, CardId.zhaliezhuangjia, DefaultTrap);
            AddExecutor(ExecutorType.Activate, CardId.ciyuanyoubi, DefaultTrap);
            AddExecutor(ExecutorType.Activate, CardId.wangnengdilei, DefaultTrap);
            AddExecutor(ExecutorType.Activate, CardId.zhentongxuetong, ZTXTeffect);
            AddExecutor(ExecutorType.Activate, CardId.huosiren, DefaultTrap);
            AddExecutor(ExecutorType.Activate, CardId.fandageming, DefaultTrap);


 

            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
        }



        private bool HHHeffect()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.huhuohua);
            SelectedCard.Add(CardId.juxinzhiwu);
            SelectedCard.Add(CardId.zhiwushizi);
            SelectedCard.Add(CardId.dugengwang);
            AI.SelectCard(SelectedCard);
            return true;
        }
        private bool ZZSSeffect()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.pugongyin);
            SelectedCard.Add(CardId.juxinzhiwu);
            SelectedCard.Add(CardId.jinjiaojiachong);
            AI.SelectCard(SelectedCard);
            return true;
        }
        private bool DGWeffect()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.juxinzhiwu);
            SelectedCard.Add(CardId.huhuohua);
            SelectedCard.Add(CardId.zhiwushizi);
            AI.SelectCard(SelectedCard);
            return true;
        }
        private bool Fyhuanjinguieffcet()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.huhuohua);
            SelectedCard.Add(CardId.MonsterReborn);
            SelectedCard.Add(CardId.shandian);
            SelectedCard.Add(CardId.yuchongmaizang);
            AI.SelectCard(SelectedCard);
            return true;
        }
        private bool YCMZeffect()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.pugongyin);
            SelectedCard.Add(CardId.jinjiaojiachong);
            SelectedCard.Add(CardId.juxinzhiwu);
            SelectedCard.Add(CardId.zhiwushizi);
            AI.SelectCard(SelectedCard);
            return true;
        }
        private bool ZTXTeffect()
        {
            List<ClientCard> spells = Bot.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.zhentongxuetong) && !spell.IsFacedown())
                    return false;
            }
            return true;
        }













    }
}
