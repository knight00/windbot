using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
using YGOSharp.OCGWrapper.Enums;
namespace WindBot.Game.AI.Decks
{
   
   [Deck("PC", "AI_PC")]
    public class PCExecutor: DefaultExecutor
    {
        public class CardId
        {
            // Initialize all normal monsters
            // Initialize all effect monsters
            public const int ming2fu3zhi1shi3shi4zhe3ge2si1_44330098 = 44330098;
            public const int sha1sha4chen2zhi1e4e3wu4wu1ling2_89111398 = 89111398;
            public const int ji1gang1ti2di1shi2si1_47606319 = 47606319;
            public const int dian4chong2hui3_24725825 = 24725825;
            public const int kui3gui1lei3zhi2wu4_51119924 = 51119924;
            public const int kui3gui1lei3chong2hui3_87514539 = 87514539;
            public const int da4dai4di4de5yan3shu3_80344569 = 80344569;
            public const int huang2quan2qing1wa1_12538374 = 12538374;
            // Initialize all special summonable effect monsters
            // Initialize all pure special summonable effect monsters
            public const int xie2ye2xin1ying1xiong2an4hei1di4de5mo2_58332301 = 58332301;
            // Initialize all link monsters
            // Initialize all spell and trap cards
            public const int xin1bian4_4031928 = 4031928;
            public const int an4hei1shen2zhao4shao4zhao1_12071500 = 12071500;
            public const int lei2ji1_12580477 = 12580477;
            public const int ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144506 = 18144506;
            public const int da4dai4feng1bao4pu4_19613556 = 19613556;
            public const int qiang2qiang3jiang4yu4zhi1hu2_55144522 = 55144522;
            public const int ge1bu4lin2bao4pu4fa1fa4hu4_70368879 = 70368879;
            public const int yu2chun3de5di4di2mai2man2zang4_81439173 = 81439173;
            public const int si3zhe3su1sheng1_83764718 = 83764718;
            // Initialize all useless cards

         }

        public PCExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            // Add Executors to all normal monsters
            // Add Executors to all effect monsters
            AddExecutor(ExecutorType.SpellSet, CardId.yu2chun3de5di4di2mai2man2zang4_81439173, yu2chun3de5di4di2mai2man2zang4_81439173SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.yu2chun3de5di4di2mai2man2zang4_81439173, yu2chun3de5di4di2mai2man2zang4_81439173Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.qiang2qiang3jiang4yu4zhi1hu2_55144522, qiang2qiang3jiang4yu4zhi1hu2_55144522SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.qiang2qiang3jiang4yu4zhi1hu2_55144522, qiang2qiang3jiang4yu4zhi1hu2_55144522Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.ge1bu4lin2bao4pu4fa1fa4hu4_70368879, ge1bu4lin2bao4pu4fa1fa4hu4_70368879SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.ge1bu4lin2bao4pu4fa1fa4hu4_70368879, ge1bu4lin2bao4pu4fa1fa4hu4_70368879Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144506, ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144506SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144506, ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144506Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.da4dai4feng1bao4pu4_19613556, da4dai4feng1bao4pu4_19613556SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.da4dai4feng1bao4pu4_19613556, da4dai4feng1bao4pu4_19613556Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.xin1bian4_4031928, xin1bian4_4031928SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.xin1bian4_4031928, xin1bian4_4031928Activate);
            AddExecutor(ExecutorType.Summon, CardId.sha1sha4chen2zhi1e4e3wu4wu1ling2_89111398, sha1sha4chen2zhi1e4e3wu4wu1ling2_89111398NormalSummon);
            AddExecutor(ExecutorType.Activate, CardId.sha1sha4chen2zhi1e4e3wu4wu1ling2_89111398, sha1sha4chen2zhi1e4e3wu4wu1ling2_89111398Activate);
            AddExecutor(ExecutorType.MonsterSet, CardId.huang2quan2qing1wa1_12538374, huang2quan2qing1wa1_12538374MonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.huang2quan2qing1wa1_12538374, huang2quan2qing1wa1_12538374Repos);
            AddExecutor(ExecutorType.Activate, CardId.huang2quan2qing1wa1_12538374, huang2quan2qing1wa1_12538374Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.lei2ji1_12580477, lei2ji1_12580477SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.lei2ji1_12580477, lei2ji1_12580477Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.si3zhe3su1sheng1_83764718, DefaultCallOfTheHaunted);
            AddExecutor(ExecutorType.Activate, CardId.si3zhe3su1sheng1_83764718, MonsterReborn);
            AddExecutor(ExecutorType.Summon, CardId.da4dai4di4de5yan3shu3_80344569, da4dai4di4de5yan3shu3_80344569NormalSummon);
            AddExecutor(ExecutorType.Activate, CardId.da4dai4di4de5yan3shu3_80344569, da4dai4di4de5yan3shu3_80344569Activate);
            AddExecutor(ExecutorType.SpSummon, CardId.ji1gang1ti2di1shi2si1_47606319, ji1gang1ti2di1shi2si1_47606319NormalSummon);
            AddExecutor(ExecutorType.Activate, CardId.ji1gang1ti2di1shi2si1_47606319, ji1gang1ti2di1shi2si1_47606319Activate);
            AddExecutor(ExecutorType.Activate, CardId.dian4chong2hui3_24725825, dian4chong2hui3_24725825Activate);
            AddExecutor(ExecutorType.MonsterSet, CardId.dian4chong2hui3_24725825, dian4chong2hui3_24725825MonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.dian4chong2hui3_24725825, dian4chong2hui3_24725825Repos);
            AddExecutor(ExecutorType.Activate, CardId.kui3gui1lei3zhi2wu4_51119924, kui3gui1lei3zhi2wu4_51119924Activate);
            AddExecutor(ExecutorType.MonsterSet, CardId.kui3gui1lei3zhi2wu4_51119924, kui3gui1lei3zhi2wu4_51119924MonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.kui3gui1lei3zhi2wu4_51119924, kui3gui1lei3zhi2wu4_51119924Repos);
            AddExecutor(ExecutorType.Activate, CardId.kui3gui1lei3chong2hui3_87514539, kui3gui1lei3chong2hui3_87514539Activate);
            AddExecutor(ExecutorType.MonsterSet, CardId.kui3gui1lei3chong2hui3_87514539, kui3gui1lei3chong2hui3_87514539MonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.kui3gui1lei3chong2hui3_87514539, kui3gui1lei3chong2hui3_87514539Repos);
            AddExecutor(ExecutorType.SpSummon, CardId.ming2fu3zhi1shi3shi4zhe3ge2si1_44330098, ming2fu3zhi1shi3shi4zhe3ge2si1_44330098NormalSummon);
            AddExecutor(ExecutorType.Activate, CardId.ming2fu3zhi1shi3shi4zhe3ge2si1_44330098, ming2fu3zhi1shi3shi4zhe3ge2si1_44330098Activate);
            AddExecutor(ExecutorType.Activate, CardId.an4hei1shen2zhao4shao4zhao1_12071500, an4hei1shen2zhao4shao4zhao1_12071500Activate);
            AddExecutor(ExecutorType.SpSummon, CardId.xie2ye2xin1ying1xiong2an4hei1di4de5mo2_58332301, xie2ye2xin1ying1xiong2an4hei1di4de5mo2_58332301SpSummon);
            AddExecutor(ExecutorType.Activate, CardId.xie2ye2xin1ying1xiong2an4hei1di4de5mo2_58332301, xie2ye2xin1ying1xiong2an4hei1di4de5mo2_58332301Activate);

            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);

        }


        public override BattlePhaseAction OnSelectAttackTarget(ClientCard attacker, IList<ClientCard> defenders)
        {
            foreach (ClientCard defender in defenders)
            {
                attacker.RealPower = attacker.Attack;
                defender.RealPower = defender.GetDefensePower();
                if (!OnPreBattleBetween(attacker, defender))
                    continue;

                if (attacker.RealPower > defender.RealPower || (attacker.RealPower >= defender.RealPower && attacker.IsLastAttacker && defender.IsAttack()))
                    return AI.Attack(attacker, defender);
            }

            if (attacker.CanDirectAttack)
                return AI.Attack(attacker, null);
            if (Bot.HasInMonstersZone(CardId.da4dai4di4de5yan3shu3_80344569))
                return AI.Attack(attacker, attacker);

            return null;
        }

        private bool MonsterReborn()
        {
            List<ClientCard> cards = new List<ClientCard>(Bot.Graveyard.GetMatchingCards(card => card.IsCanRevive()));
            cards.Sort(CardContainer.CompareCardAttack);
            ClientCard selectedCard = null;
            for (int i = cards.Count - 1; i >= 0; --i)
            {
                ClientCard card = cards[i];
                if (card.Attack < 1000)
                    break;
                if (card.IsMonster())
                {
                    selectedCard = card;
                    break;
                }
            }
            cards = new List<ClientCard>(Enemy.Graveyard.GetMatchingCards(card => card.IsCanRevive()));
            cards.Sort(CardContainer.CompareCardAttack);
            for (int i = cards.Count - 1; i >= 0; --i)
            {
                ClientCard card = cards[i];
                if (card.Attack < 1000)
                    break;
                if (card.IsMonster() && card.HasType(CardType.Normal) && (selectedCard == null || card.Attack > selectedCard.Attack))
                {
                    selectedCard = card;
                    break;
                }
            }
            if (selectedCard != null)
            {
                AI.SelectCard(selectedCard);
                return true;
            }
            return false;
        }
        private bool ming2fu3zhi1shi3shi4zhe3ge2si1_44330098NormalSummon()
        {

            return true;
        }

        private bool ming2fu3zhi1shi3shi4zhe3ge2si1_44330098MonsterSet()
        {

            return true;
        }

        private bool ming2fu3zhi1shi3shi4zhe3ge2si1_44330098Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool ming2fu3zhi1shi3shi4zhe3ge2si1_44330098Activate()
        {

            return true;
        }

        private bool sha1sha4chen2zhi1e4e3wu4wu1ling2_89111398NormalSummon()
        {
            if (Bot.MonsterZone.GetCardCount(CardId.ming2fu3zhi1shi3shi4zhe3ge2si1_44330098) >= 1)
            {
                return false;
            }
            if (Bot.MonsterZone.GetCardCount(CardId.xie2ye2xin1ying1xiong2an4hei1di4de5mo2_58332301) >= 1)
            {
                return false;
            }
            return true;
        }

        private bool sha1sha4chen2zhi1e4e3wu4wu1ling2_89111398MonsterSet()
        {

            return true;
        }

        private bool sha1sha4chen2zhi1e4e3wu4wu1ling2_89111398Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool sha1sha4chen2zhi1e4e3wu4wu1ling2_89111398Activate()
        {

            return true;
        }

        private bool ji1gang1ti2di1shi2si1_47606319NormalSummon()
        {

            return true;
        }

        private bool ji1gang1ti2di1shi2si1_47606319MonsterSet()
        {

            return true;
        }

        private bool ji1gang1ti2di1shi2si1_47606319Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool ji1gang1ti2di1shi2si1_47606319Activate()
        {

            return true;
        }

        private bool dian4chong2hui3_24725825NormalSummon()
        {

            return true;
        }

        private bool dian4chong2hui3_24725825MonsterSet()
        {

            return true;
        }

        private bool dian4chong2hui3_24725825Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool dian4chong2hui3_24725825Activate()
        {

            return true;
        }

        private bool kui3gui1lei3zhi2wu4_51119924NormalSummon()
        {

            return true;
        }

        private bool kui3gui1lei3zhi2wu4_51119924MonsterSet()
        {

            return true;
        }

        private bool kui3gui1lei3zhi2wu4_51119924Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool kui3gui1lei3zhi2wu4_51119924Activate()
        {

            return true;
        }

        private bool kui3gui1lei3chong2hui3_87514539NormalSummon()
        {

            return true;
        }

        private bool kui3gui1lei3chong2hui3_87514539MonsterSet()
        {

            return true;
        }

        private bool kui3gui1lei3chong2hui3_87514539Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool kui3gui1lei3chong2hui3_87514539Activate()
        {

            return true;
        }

        private bool da4dai4di4de5yan3shu3_80344569NormalSummon()
        {

            return true;
        }

        private bool da4dai4di4de5yan3shu3_80344569MonsterSet()
        {

            return true;
        }

        private bool da4dai4di4de5yan3shu3_80344569Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool da4dai4di4de5yan3shu3_80344569Activate()
        {

            return true;
        }

        private bool huang2quan2qing1wa1_12538374NormalSummon()
        {

            return true;
        }

        private bool huang2quan2qing1wa1_12538374MonsterSet()
        {

            return true;
        }

        private bool huang2quan2qing1wa1_12538374Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool huang2quan2qing1wa1_12538374Activate()
        {
            AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;

        }

            // All Special Summonable Effect Monster Methods

            // All Pure Special Summonable Effect Monster Methods

        private bool xie2ye2xin1ying1xiong2an4hei1di4de5mo2_58332301Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool xie2ye2xin1ying1xiong2an4hei1di4de5mo2_58332301Activate()
        {

            return true;
        }

        private bool xie2ye2xin1ying1xiong2an4hei1di4de5mo2_58332301SpSummon()
        {

            return true;
        }

            // All Link Monster Methods

            // All Spell and Trap Card Methods

        private bool xin1bian4_4031928SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool xin1bian4_4031928Activate()
        {

            return true;
        }

        private bool an4hei1shen2zhao4shao4zhao1_12071500SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool an4hei1shen2zhao4shao4zhao1_12071500Activate()
        {
            //在自己主要阶段，对方有一只怪兽比自己场上的怪兽都高时，发动奇迹融合。优先选择大龙卷侠，其次大地侠。
            if (Util.IsOneEnemyBetter() && Duel.Phase == DuelPhase.Main1 )
            {
                IList<int> SelectedCard = new List<int>();

                AI.SelectCard(SelectedCard);

                return true;

            }

            return false;
        }

        private bool lei2ji1_12580477SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool lei2ji1_12580477Activate()
        {

            return true;
        }

        private bool ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144506SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144506Activate()
        {

            return true;
        }

        private bool da4dai4feng1bao4pu4_19613556SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool da4dai4feng1bao4pu4_19613556Activate()
        {

            return true;
        }

        private bool qiang2qiang3jiang4yu4zhi1hu2_55144522SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool qiang2qiang3jiang4yu4zhi1hu2_55144522Activate()
        {

            return true;
        }

        private bool ge1bu4lin2bao4pu4fa1fa4hu4_70368879SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool ge1bu4lin2bao4pu4fa1fa4hu4_70368879Activate()
        {

            return true;
        }

        private bool yu2chun3de5di4di2mai2man2zang4_81439173SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool yu2chun3de5di4di2mai2man2zang4_81439173Activate()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.huang2quan2qing1wa1_12538374);
            SelectedCard.Add(CardId.ming2fu3zhi1shi3shi4zhe3ge2si1_44330098);
            SelectedCard.Add(CardId.da4dai4di4de5yan3shu3_80344569);
            SelectedCard.Add(CardId.kui3gui1lei3chong2hui3_87514539);
            SelectedCard.Add(CardId.dian4chong2hui3_24725825);
            AI.SelectCard(SelectedCard);
            return true;
        }

        private bool si3zhe3su1sheng1_83764718SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool si3zhe3su1sheng1_83764718Activate()
        {

            return true;
        }

    }
}