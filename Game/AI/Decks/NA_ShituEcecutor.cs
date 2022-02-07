using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
namespace WindBot.Game.AI.Decks
{
    [Deck("Shitu", "AI_Shitu", "NotFinished")]
    public class ShituExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Slieren = 77582580;
            public const int Sxianzhi = 77582581;
            public const int Sshenghuan = 77582582;
            public const int Sheian = 77582585;
            public const int Sxiwang = 77582586;
            public const int Syuangu = 77582587;
            public const int Shundun = 77582588;
            public const int Snvwushen = 77582598;
            public const int Sxunyou = 77582589;
            public const int Linjiagecao = 11110587;
            public const int Hu = 55144522;
            public const int Mingtuili = 58577036;
            public const int Tianshideshishe = 79571449;
            public const int Sfangzhen = 77582593;
            public const int Smizong = 77582595;
            public const int Slingyu = 77582583;
            public const int Sshilian = 77582592;
            public const int Smijing = 77582594;
            public const int Sxinsheng = 77582591;
            public const int Sguanxing = 77582597;
            public const int Schuangzaozhe = 77582590;
            public const int Syindaozhe = 77582596;
            public const int Cangji = 77583001;
        }
        //选择
        List<int> should_select = new List<int>
        {
           CardId.Sfangzhen, CardId.Sshilian, CardId.Smijing, CardId.Slingyu, CardId.Smizong,CardId.Sxunyou,CardId.Sxianzhi,CardId.Shundun,
           CardId.Syindaozhe,CardId.Sshenghuan,CardId.Slieren,CardId.Sxianzhi,CardId.Sheian
        };
        //选择2
        List<int> should2_select = new List<int>
        {
          CardId.Sxinsheng, CardId.Slieren, CardId.Sxianzhi, CardId.Sshenghuan, CardId.Sheian, CardId.Sxiwang, CardId.Syuangu, CardId.Shundun, CardId.Sxunyou,
        };
        List<int> Impermanence_list = new List<int>();
        bool Syindaozhe = false;
        bool Schuangzaozhe = false;
        bool Syindaozhe2 = false;
        public ShituExecutor(GameAI ai, Duel duel)
         : base(ai, duel)
        {
            //名推理
            AddExecutor(ExecutorType.Activate, CardId.Mingtuili);
            //割草
            AddExecutor(ExecutorType.Activate, CardId.Linjiagecao);
            //使徒 方阵
            AddExecutor(ExecutorType.Activate, CardId.Sfangzhen, SfangzhenEffect);
            //壶
            AddExecutor(ExecutorType.Activate, CardId.Hu);
            //使徒 巡游
            AddExecutor(ExecutorType.Summon, CardId.Sxunyou);
            //天使的施舍
            AddExecutor(ExecutorType.Activate, CardId.Tianshideshishe, TianshideshisheEffect);
            //使徒 巡游
            AddExecutor(ExecutorType.Activate, CardId.Sxunyou);
            //使徒 女武神
            AddExecutor(ExecutorType.SpSummon, CardId.Snvwushen);
            //使徒 女武神
            //AddExecutor(ExecutorType.SpSummon, CardId.Snvwushen, SnvwushenSummon);
            //使徒 领域
            AddExecutor(ExecutorType.Activate, CardId.Slingyu, SlingyuEffect);
            //使徒 迷踪
            AddExecutor(ExecutorType.Activate, CardId.Smizong, SmizongEffect);
            //使徒 烈刃
            AddExecutor(ExecutorType.SpSummon, CardId.Slieren, SlierenSummon);
            //使徒 烈刃
            AddExecutor(ExecutorType.Activate, CardId.Slieren, SlierenEffect);
            //使徒 新生
            AddExecutor(ExecutorType.SpSummon, CardId.Sxinsheng);
            //使徒 新生
            AddExecutor(ExecutorType.Activate, CardId.Sxinsheng, SxinshengEffect);
            //使徒 引导
            AddExecutor(ExecutorType.SpSummon, CardId.Syindaozhe, SyindaozheSummon);
            //使徒 引导
            AddExecutor(ExecutorType.Activate, CardId.Syindaozhe, SyindaozheEffect);
            //使徒 圣环
            AddExecutor(ExecutorType.SpSummon, CardId.Sshenghuan, SshenghuanSummon);
            //使徒 圣环
            AddExecutor(ExecutorType.Activate, CardId.Sshenghuan, SshenghuanEffect);
            //使徒 先知
            AddExecutor(ExecutorType.SpSummon, CardId.Sxianzhi, SxianzhiSummon);
            //使徒 先知
            AddExecutor(ExecutorType.Activate, CardId.Sxianzhi, SxianzhiEffect);
            //使徒 黑暗
            AddExecutor(ExecutorType.SpSummon, CardId.Sheian, SheianSummon);
            //使徒 黑暗
            AddExecutor(ExecutorType.Activate, CardId.Sheian, SheianEffect);
            //使徒 希望
            AddExecutor(ExecutorType.SpSummon, CardId.Sxiwang, SxiwangSummon);
            //使徒 希望
            AddExecutor(ExecutorType.Activate, CardId.Sxiwang, SxiwangEffect);
            //使徒 远古
            AddExecutor(ExecutorType.SpSummon, CardId.Syuangu, SyuanguSummon);
            //使徒 远古
            AddExecutor(ExecutorType.Activate, CardId.Syuangu, SyuanguEffect);
            //使徒 混沌
            AddExecutor(ExecutorType.SpSummon, CardId.Shundun, ShundunSummon);
            //使徒 混沌
            AddExecutor(ExecutorType.Activate, CardId.Shundun, ShundunEffect);
            //使徒 创造者
            AddExecutor(ExecutorType.SpSummon, CardId.Schuangzaozhe, SchuangzaozheSummon);
            //使徒 观星
            AddExecutor(ExecutorType.Activate, CardId.Sguanxing);
            //使徒 观星
            AddExecutor(ExecutorType.SpSummon, CardId.Sguanxing, SguanxingSummon);

            //使徒 秘境
            AddExecutor(ExecutorType.Activate, CardId.Smijing);
            //使徒 试炼
            AddExecutor(ExecutorType.Activate, CardId.Sshilian, SshilianEffect);

            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);
        }
        //计数专用
        public override void OnNewTurn()
        {
            // reset
            Syindaozhe = false;
            Schuangzaozhe = false;
            Syindaozhe2 = false;
        }
            //天使的施舍
        private bool TianshideshisheEffect()
        {
            AI.SelectCard(should_select);
            return true;
        }
        //使徒 烈刃
        private bool SlierenSummon()
        {
            AI.SelectCard(should_select);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //使徒 圣环
        private bool SshenghuanSummon()
        {
            AI.SelectCard(should_select);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //使徒 领域
        private bool SlingyuEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.HasInSpellZone(CardId.Slingyu)) return false;
                return true;
            }
            else if (Card.Location == CardLocation.SpellZone)
            {
                return true;
            }
            return false;
        }
        //使徒 希望
        private bool SxiwangSummon()
        {
            AI.SelectCard(should_select);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //使徒 先知
        private bool SxianzhiSummon()
        {
            AI.SelectCard(should_select);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //使徒 远古
        private bool SyuanguSummon()
        {
            AI.SelectCard(should_select);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //使徒 混沌
        private bool ShundunSummon()
        {
            AI.SelectCard(should_select);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //使徒 新生
        private bool SxinshengEffect()
        {
            AI.SelectCard(should2_select);
            return true;
        }
        //使徒 先知
        private bool SxianzhiEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Sxianzhi, 0))
            {
                foreach (ClientCard card in Enemy.SpellZone)
                    if (card != null) return true;
                return false;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Sxianzhi, 1))
            {
                if (Duel.LastChainPlayer != 0)
                {
                    AI.SelectCard(should_select);
                    return true;
                }
                return false;
            }
            return false;
        }
        //使徒 黑暗
        private bool SheianSummon()
        {
            AI.SelectCard(should_select);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //使徒 试炼
        private bool SshilianEffect()
        {
            if (Card.Location == CardLocation.SpellZone)
            {
                ClientCard target = Util.GetBestEnemyCard();
                if (target != null && (target.HasType(CardType.Continuous) || target.HasType(CardType.Effect)))
                {
                    AI.SelectCard(target);
                    AI.SelectNextCard(should_select);
                    AI.SelectThirdCard(should_select);
                    return true;
                }
                else if (target == null)
                {
                    AI.SelectCard(CardId.Sshilian);
                    AI.SelectNextCard(should_select);
                    AI.SelectThirdCard(should_select);
                    return true;
                }
                return false;
            }
            else if (Card.Location == CardLocation.Hand || Card.Location == CardLocation.Removed || Card.Location == CardLocation.Grave) return true;
            return false;


        }
        //使徒 女武神
        private bool SnvwushenSummon()
        {
            if (Bot.LifePoints <= 500) return false;
            return true;
        }
        //使徒 黑暗
        private bool SheianEffect()
        {
            foreach (ClientCard card in Enemy.Graveyard)
                if (Util.ChainContainsCard(CardId.Sshenghuan) && Duel.LastChainPlayer == 0) return false;
                else if (card != null)
                {
                    AI.SelectCard(should_select);
                    AI.SelectNextCard(card);
                    return true;
                }
               return false;
        }
        //使徒 希望
        private bool SxiwangEffect()
        {
            foreach (ClientCard card in Enemy.Graveyard)
            if (ActivateDescription == Util.GetStringId(CardId.Sxiwang, 0)) return true;
            else if (ActivateDescription == Util.GetStringId(CardId.Sxiwang, 1))
            {
                    if ((Util.ChainContainsCard(CardId.Sshenghuan) || Util.ChainContainsCard(CardId.Sheian)) && Duel.LastChainPlayer == 0) return false;
                    else if (card != null)
                    {
                        AI.SelectCard(should_select);
                        AI.SelectNextCard(card);
                        return true;
                    }
                    return false;
            }
            return false;
        }
        //使徒 远古
        private bool SyuanguEffect()
        {
            foreach (ClientCard card in Enemy.Graveyard)
                if (ActivateDescription == Util.GetStringId(CardId.Syuangu, 0)) return true;
                else if (ActivateDescription == Util.GetStringId(CardId.Syuangu, 1))
                {
                    if ((Util.ChainContainsCard(CardId.Sshenghuan) || Util.ChainContainsCard(CardId.Sheian) || Util.ChainContainsCard(CardId.Sxiwang)) && Duel.LastChainPlayer == 0) return false;
                    else if (card != null)
                    {
                        AI.SelectCard(should_select);
                        AI.SelectNextCard(card);
                        return true;
                    }
                    return false;
                }
            return false;
        }
        //使徒  圣环
        private bool SshenghuanEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Sshenghuan, 0))
            {
                ClientCard target = Util.GetBestEnemyCard();
                if (target != null)
                {
                    AI.SelectCard(target);
                    return true;
                }
                return false;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Sshenghuan, 1))
            {
                foreach (ClientCard card in Enemy.Graveyard)
                    if (card != null)
                    {
                        AI.SelectCard(should_select);
                        AI.SelectNextCard(card);
                        return true;
                    }
                return false;
            }
            return false;
        }
        //使徒 烈刃
        private bool SlierenEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Slieren, 0))
            {
                if (Bot.GetMonsterCount() == 1 || Enemy.GetMonsterCount() >= Bot.GetMonsterCount()) return true;
                return false;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Slieren, 1))
            {
                if (Duel.LastChainPlayer != 0)
                {
                    AI.SelectCard(should_select);
                    return true;
                }
                return false;
            }
            return false;
        }
        //使徒 混沌
        private bool ShundunEffect()
        {
            if ((Util.ChainContainsCard(CardId.Sshenghuan) || Util.ChainContainsCard(CardId.Sheian) || Util.ChainContainsCard(CardId.Sxiwang) || Util.ChainContainsCard(CardId.Syuangu)) && Duel.LastChainPlayer == 0) return false;
            return true;
        }
        //使徒 引导
        private bool SyindaozheSummon()
        {
            if (Syindaozhe || Syindaozhe2) return false;
            {
                AI.SelectMaterials(new List<int>() {
                CardId.Sxunyou
            });
                Syindaozhe2 = true;
                return true;
            }
        }
        //使徒 引导
        private bool SyindaozheEffect()
        {
            foreach (ClientCard card in Bot.Graveyard)
                foreach (ClientCard card2 in Bot.Graveyard)
                    if (card.IsCode(should2_select) || card2.IsCode(should2_select))
                    {
                        AI.SelectCard(CardId.Sfangzhen, CardId.Smizong);
                    }
                    else
                    {
                        AI.SelectCard(CardId.Smizong, CardId.Sfangzhen);
                    }
            Syindaozhe = true;
            return true;
        }
        //使徒 方阵
        private bool SfangzhenEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                return true;
            }
            else if (Card.Location == CardLocation.SpellZone)
            {
                AI.SelectCard(CardId.Shundun);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            else if (Card.Location == CardLocation.Grave || Card.Location == CardLocation.Removed)
            {
                return true;
            }
            return false;
        }
        //使徒 创造者
        private bool SchuangzaozheSummon()
        {
            if (!Schuangzaozhe)
            {
                AI.SelectMaterials(new List<int>() {
                CardId.Sxunyou,
                CardId.Syindaozhe,
                CardId.Snvwushen,
                CardId.Slieren,
            });
                Schuangzaozhe = true;
                return true;
            }
            return false;
        }
        //使徒 迷踪
        private bool SmizongEffect()
        {
            if (Card.Location == CardLocation.SpellZone)
            {
                AI.SelectCard(CardId.Mingtuili, CardId.Linjiagecao);
                return true;
            }
            else
            {
                AI.SelectCard(should_select);
                return true;
            }
        }
        //使徒 观星
        private bool SguanxingSummon()
        {
            AI.SelectMaterials(new List<int>() {
                CardId.Sguanxing,
                CardId.Sshenghuan,
                CardId.Sguanxing
            });
            AI.SelectYesNo(true);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
    }
}
