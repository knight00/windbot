using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using System.Linq;
using System;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
namespace WindBot.Game.AI.Decks
{
    [Deck("Hades", "AI_Hades", "NotFinished")]
    public class HadesExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Mwangling = 77240303;
            public const int Mmantuo = 77240309;
            public const int Mlong = 77239052;
            public const int Mbusimo = 77239042;
            public const int Mshouhulong = 77240312;
            public const int Merquan = 77240308;
            public const int Mshouhuzhe = 77239046;
            public const int Mainieasi = 77240311;
            public const int Mqishi = 77239047;
            public const int Mhuaidela = 77239059;
            public const int Myongshi = 77239050;
            public const int Mxulasi = 77240314;
            public const int Mmaomi = 77239045;
            public const int Mtailameng = 77239058;
            public const int Zumu = 77239021;
            public const int Kongjianchuansuo = 77239055;
            public const int Frive = 77239068;
            public const int Yuwang = 77239011;
            public const int Tongxinglingpai = 77240307;
            public const int Bianda = 77240306;
            public const int Shanguang = 77239057;
            public const int Fuchou = 77240005;
            public const int AIcards = 97710053;
        }
        bool Mtailameng = false;
        public HadesExecutor(GameAI ai, Duel duel): base(ai, duel)
        {
            //5除2
            AddExecutor(ExecutorType.Activate, CardId.Frive, FriveEffect);
            //祖母暗之书
            AddExecutor(ExecutorType.Activate, CardId.Zumu, ZumuEffect);
            //欲望的代价
            AddExecutor(ExecutorType.Activate, CardId.Yuwang, YuwangEffect);
            //空间穿梭
            AddExecutor(ExecutorType.Activate, CardId.Kongjianchuansuo, KongjianchuansuoEffect);
            //闪光爆发
            AddExecutor(ExecutorType.Activate, CardId.Shanguang, ShanguangEffect);
            //冥界复仇
            AddExecutor(ExecutorType.Activate, CardId.Fuchou, FuchouEffect);
            //冥界的通行牌
            AddExecutor(ExecutorType.Activate, CardId.Tongxinglingpai, TongxinglingpaiActivate);
            //冥界的鞭打
            AddExecutor(ExecutorType.Activate, CardId.Bianda, BiandaEffect);

            //冥界 曼托
            AddExecutor(ExecutorType.Activate, CardId.Mmantuo, MmantuoEffect);
            //冥界 曼托
            AddExecutor(ExecutorType.SpSummon, CardId.Mmantuo);

            //冥界 不死魔
            AddExecutor(ExecutorType.Activate, CardId.Mbusimo);

            //冥界 守护者
            AddExecutor(ExecutorType.Activate, CardId.Mshouhuzhe, MshouhuzheEffect);


            //冥界 守护龙
            AddExecutor(ExecutorType.Activate, CardId.Mshouhulong);

            //冥界 太拉蒙
            AddExecutor(ExecutorType.Activate, CardId.Mtailameng, MtailamengEffect);

            //冥界 勇士-效果
            AddExecutor(ExecutorType.Activate, CardId.Myongshi);
            //冥界 勇士
            AddExecutor(ExecutorType.Summon, CardId.Myongshi);

            //冥界 骑士-效果
            AddExecutor(ExecutorType.Activate, CardId.Mqishi, MqishiEffect);

            //冥界 淮德拉
            AddExecutor(ExecutorType.Summon, CardId.Mhuaidela);

            //冥界 恶犬
            AddExecutor(ExecutorType.Summon, CardId.Merquan);
            //冥界 恶犬-效果
           AddExecutor(ExecutorType.Activate, CardId.Merquan, MerquanEffect);

            //冥界 埃涅阿斯
            AddExecutor(ExecutorType.Activate, CardId.Mainieasi);
            //冥界 埃涅阿斯
            AddExecutor(ExecutorType.Summon, CardId.Mainieasi);
            //冥界 不死魔
            AddExecutor(ExecutorType.Summon, CardId.Mbusimo);
            //冥界 龙
            AddExecutor(ExecutorType.Summon, CardId.Mlong);

            //冥界 许拉斯
            AddExecutor(ExecutorType.SummonOrSet, CardId.Mxulasi);
            // 冥界 猫咪
            AddExecutor(ExecutorType.MonsterSet, CardId.Mmaomi);

            //冥界 亡灵
            AddExecutor(ExecutorType.SpSummon, CardId.Mwangling, MwanglingSummon);

            AddExecutor(ExecutorType.SpellSet, DefaultSet);
            AddExecutor(ExecutorType.Repos, MonsterRepos);

            //冥界的通行牌
            AddExecutor(ExecutorType.Activate, CardId.Tongxinglingpai, TongxinglingpaiEffect);

        }
        //新回合
        public override void OnNewTurn()
        {
            Mtailameng = false;
        }
        public override CardPosition OnSelectPosition(int cardId, IList<CardPosition> positions)
        {
            YGOSharp.OCGWrapper.NamedCard cardData = YGOSharp.OCGWrapper.NamedCard.Get(cardId);
            if (cardData != null)
            {
                if (cardData.Id == CardId.Mxulasi || cardData.Id == CardId.Mmaomi || cardData.Id == CardId.Mtailameng)
                {
                    return CardPosition.FaceUpDefence;
                }
                else if (Util.IsAllEnemyBetterThanValue(cardData.Attack, true) && !(cardData.HasType(CardType.Xyz) && !Card.IsDisabled()))
                    return CardPosition.FaceUpDefence;
                return CardPosition.FaceUpAttack;
            }
            return 0;
        }
        //卡组检查
        public int CheckRemainInDeck(int id)
        {
            switch (id)
            {
                case CardId.Mwangling:
                    return Bot.GetRemainingCount(CardId.Mwangling, 1);
                case CardId.Mmantuo:
                    return Bot.GetRemainingCount(CardId.Mmantuo, 2);
                case CardId.Mlong:
                    return Bot.GetRemainingCount(CardId.Mlong, 1);
                case CardId.Mbusimo:
                    return Bot.GetRemainingCount(CardId.Mbusimo, 2);
                case CardId.Mshouhulong:
                    return Bot.GetRemainingCount(CardId.Mshouhulong, 1);
                case CardId.Merquan:
                    return Bot.GetRemainingCount(CardId.Merquan, 3);
                case CardId.Mshouhuzhe:
                    return Bot.GetRemainingCount(CardId.Mshouhuzhe, 1);
                case CardId.Mainieasi:
                    return Bot.GetRemainingCount(CardId.Mainieasi, 1);
                case CardId.Mqishi:
                    return Bot.GetRemainingCount(CardId.Mqishi, 2);
                case CardId.Mhuaidela:
                    return Bot.GetRemainingCount(CardId.Mhuaidela, 2);
                case CardId.Myongshi:
                    return Bot.GetRemainingCount(CardId.Myongshi, 3);
                case CardId.Mxulasi:
                    return Bot.GetRemainingCount(CardId.Mxulasi, 1);
                case CardId.Mmaomi:
                    return Bot.GetRemainingCount(CardId.Mmaomi, 1);
                case CardId.Mtailameng:
                    return Bot.GetRemainingCount(CardId.Mtailameng, 3);
                default:
                    return 0;

            }
        }
        public int CheckRemainInDeck(params int[] ids)
        {
            int result = 0;
            foreach (int cardid in ids)
            {
                result += CheckRemainInDeck(cardid);
            }
            return result;

        }
        //表示形式
        private bool MonsterRepos()
        {
            if ((Card.Id == CardId.Mmaomi || Card.Id == CardId.Mtailameng)
                && Enemy.LifePoints > Card.Attack && Card.IsDefense() && Enemy.GetMonsterCount() == 0)
            {
                return false;
            }
            if (Card.IsMonsterInvincible())
                return Card.IsDefense();

            if (Card.Attack == 0)
            {
                if (Card.IsFaceup() && Card.IsAttack())
                    return true;
                if (Card.IsFaceup() && Card.IsDefense())
                    return false;
            }

            if (Enemy.HasInMonstersZone(_CardId.BlueEyesChaosMAXDragon, true) &&
                Card.IsAttack() && (4000 - Card.Defense) * 2 > (4000 - Card.Attack))
                return false;
            if (Enemy.HasInMonstersZone(_CardId.BlueEyesChaosMAXDragon, true) &&
                Card.IsDefense() && Card.IsFaceup() &&
                (4000 - Card.Defense) * 2 > (4000 - Card.Attack))
                return true;

            bool enemyBetter = Util.IsAllEnemyBetter();
            if (Card.IsAttack() && enemyBetter)
                return true;
            if (Card.IsDefense() && !enemyBetter && (Card.Attack >= Card.Defense || Card.Attack >= Util.GetBestPower(Enemy)))
                return true;

            return false;
        }
        //曼托
        private bool MmantuoEffect()
        {
            if (Card.IsDisabled()) return false;
            if (ActivateDescription==Util.GetStringId(CardId.Mmantuo, 2))
            {
                if (Bot.HasInGraveyard(CardId.Mwangling))
                {
                    AI.SelectCard(CardId.Mwangling);
                    return true;
                }
                else if (Bot.HasInGraveyard(CardId.Mshouhuzhe) && Card.Attack / 2 >= Enemy.LifePoints && Card.IsAttack())
                {
                    AI.SelectCard(CardId.Mshouhuzhe);
                    return true;
                }
                else if (Bot.HasInGraveyard(CardId.Mhuaidela))
                {
                    AI.SelectCard(CardId.Mhuaidela);
                    return true;
                }
                else if (Bot.HasInGraveyard(CardId.Mshouhulong))
                {
                    AI.SelectCard(CardId.Mshouhulong);
                    return true;
                }
                else if (Bot.HasInGraveyard(CardId.Mxulasi)) 
                {
                    AI.SelectCard(CardId.Mxulasi);
                    return true;
                }
                else if (Bot.HasInGraveyard(CardId.Merquan) && Bot.GetCountCardInZone(Bot.Graveyard,CardType.Monster, 0xa13)>3)
                {
                    AI.SelectCard(CardId.Merquan);
                    return true;
                }
                else if (Bot.HasInGraveyard(CardId.Mmaomi))
                {
                    AI.SelectCard(CardId.Mmaomi);
                    return true;
                }
                return false;
            } 
            if (ActivateDescription == Util.GetStringId(CardId.Mshouhulong, 1))
            {
                return Card.Attack >= Enemy.LifePoints;
            }
            return true;
        }
        //亡灵 （正常状态下不特召）
        private bool MwanglingSummon()
        {
            if (Card.Location == CardLocation.Hand) return true;
            else
            {
                return Bot.GetMonsterCount() == 0 && Bot.GetSpellCount() == 0;
            }
        }
        //闪光爆发
        private bool ShanguangEffect()
        {
            AI.SelectCard(CardId.Mhuaidela, CardId.Mshouhuzhe, CardId.Mqishi, CardId.Mainieasi);
            return true;
        }
        //鞭打
        private bool BiandaEffect()
        {
            ClientCard card = Util.GetBestEnemyMonster();
            if (card != null && !card.IsDisabled())
            {
                AI.SelectCard(card);
                return true;
            }
            return false;
        }
        //冥界 守护者
        private bool MshouhuzheEffect()
        {
            return Enemy.LifePoints <= Card.Attack / 2;
        }
        //冥界骑士
        private bool MqishiEffect()
        {
            AI.SelectCard(CardId.Mhuaidela);
            return true;
        }
        //祖母书
        private bool ZumuEffect()
        {
            AI.SelectCard(CardId.Yuwang, CardId.Frive);
            return true;
        }
        //冥界令牌 发动
        private bool TongxinglingpaiActivate()
        {
            return Card.Location == CardLocation.Hand || (Card.Location == CardLocation.SpellZone && Card.IsFacedown());
        }
        //令牌
        private bool TongxinglingpaiEffect()
        {
            if (Bot.HasInHand(CardId.Mshouhulong) || Bot.HasInHand(CardId.Mshouhuzhe) || Bot.HasInHand(CardId.Mwangling))
            {
                AI.SelectCard(CardId.Mshouhulong, CardId.Mshouhuzhe, CardId.Mwangling);
                return true;
            }
            return false;
        }
        //欲望
        private bool YuwangEffect()
        {
            ClientCard card = Util.GetLastChainCard();
            if (card != null && card.IsCode(CardId.Yuwang) && card.Controller == 0) return false;
            AI.SelectCard(CardId.Mhuaidela, CardId.Mbusimo, CardId.Mshouhuzhe,
                            CardId.Mlong, CardId.Mainieasi, CardId.Mmaomi, CardId.Mxulasi);
            return true;
        }
        //冥界 太拉蒙
        private bool MtailamengEffect()
        {
            if (!Mtailameng && Duel.Player != 0)
            {
                Mtailameng = true;
                return true ;
            }
            return false;
        }
        //冥界 复仇
        private bool FuchouEffect()
        {
            return Bot.LifePoints > 1;
        }
        //空间穿梭
        private bool KongjianchuansuoEffect()
        {
            if (CheckRemainInDeck(CardId.Mbusimo) > 0)
            {
                AI.SelectCard(CardId.Mbusimo);
                return true;
            }
            else if (CheckRemainInDeck(CardId.Mlong) > 0)
            {
                AI.SelectCard(CardId.Mlong);
                return true;
            }
            else if (CheckRemainInDeck(CardId.Mhuaidela) > 0)
            {
                AI.SelectCard(CardId.Mhuaidela);
                return true;
            }
            else if (CheckRemainInDeck(CardId.Mshouhuzhe) > 0)
            {
                AI.SelectCard(CardId.Mshouhuzhe);
                return true;
            }
            else if (CheckRemainInDeck(CardId.Mainieasi) > 0)
            {
                AI.SelectCard(CardId.Mainieasi);
                return true;
            }
            else if (CheckRemainInDeck(CardId.Mqishi) > 0)
            {
                AI.SelectCard(CardId.Mqishi);
                return true;
            }
            else if (CheckRemainInDeck(CardId.Merquan) > 0)
            {
                AI.SelectCard(CardId.Merquan);
                return true;
            }
            return false;
        }
        private bool DefaultSet()
        {
            return (Card.IsTrap() || (Card.HasType(CardType.QuickPlay) && !Card.IsCode(CardId.Yuwang) || DefaultSpellMustSetFirst()) && Bot.GetSpellCountWithoutField() < 5);
        }
        //冥界 恶犬 
        private bool MerquanEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Merquan, 1))
            {
                AI.SelectCard(CardId.Mmantuo, CardId.Mlong, CardId.Mshouhulong, CardId.Mhuaidela);
                return true;
            }
            else
            {
                AI.SelectCard(CardId.Mbusimo, CardId.Mshouhulong);
                return true;
            }
        }
        //5除2
        private bool FriveEffect()
        {
            return Bot.Deck.Count > 5;
        }
    }
}
