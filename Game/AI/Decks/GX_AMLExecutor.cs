using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
using YGOSharp.OCGWrapper.Enums;
namespace WindBot.Game.AI.Decks
{
   
   [Deck("AML", "AI_AML")]
    public class AMLExecutor: DefaultExecutor
    {
        public class CardId
        {
            // Initialize all normal monsters
            // Initialize all effect monsters
            public const int tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776 = 48453776;
            public const int hun4hun2hun3dun4zhuan4huan4ying3_30312361 = 30312361;
            public const int ju4long2zhi1shou3hu4qi2shi4_33460840 = 33460840;
            public const int lie4yan4huo3xing1_15033525 = 15033525;
            public const int an4hei1jie4de5di4di2shu4zhu2shi1si1nuo4_60228941 = 60228941;
            public const int an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233 = 34230233;
            public const int guang1yu3yu4yu2an4zhi1long2_47297616 = 47297616;
            // Initialize all special summonable effect monsters
            // Initialize all pure special summonable effect monsters
            public const int qian4qian1kan4he2ge3yao4yao1sai4se4sai1long2_79229522 = 79229522;
            // Initialize all link monsters
            // Initialize all spell and trap cards
            public const int yu2chun3de5di4di2mai2man2zang4_81439173 = 81439173;
            public const int ming2tui1li3_58577036 = 58577036;
            public const int qiang2qiang3jiang4yu4zhi1hu2_55144522 = 55144522;
            public const int di3jia4jie4jie5gou4wu4_38120068 = 38120068;
            public const int ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507 = 18144507;
            public const int lei2ji1_12580477 = 12580477;
            public const int guo4guo1zao3de5di4di2mai2man2zang4_70828912 = 70828912;
            public const int si3zhe3su1sheng1_83764718 = 83764718;
            public const int tian1shi3shi4de5di4di2shi1she4she3_79571449 = 79571449;
            public const int shou3zha2mo3ma1mo4sha1_72892473 = 72892473;
            // Initialize all useless cards
            public const int GXqian1nian2shen2qi4qian1nian2zhi4hui4lun2_3007 = 3007;
            public const int wangjiachangmianzhigu = 47355498;

        }
        public AMLExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            // Add Executors to all normal monsters
            // Add Executors to all effect monsters
            AddExecutor(ExecutorType.SpellSet, CardId.yu2chun3de5di4di2mai2man2zang4_81439173, yu2chun3de5di4di2mai2man2zang4_81439173SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.yu2chun3de5di4di2mai2man2zang4_81439173, yu2chun3de5di4di2mai2man2zang4_81439173Activate);
            AddExecutor(ExecutorType.SpSummon, CardId.tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776);
            AddExecutor(ExecutorType.Activate, CardId.tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776);
            AddExecutor(ExecutorType.Repos, CardId.tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776, tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776Repos);
            AddExecutor(ExecutorType.Activate, CardId.tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776, tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.ming2tui1li3_58577036, ming2tui1li3_58577036SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.ming2tui1li3_58577036, ming2tui1li3_58577036Activate);
            AddExecutor(ExecutorType.Summon, CardId.hun4hun2hun3dun4zhuan4huan4ying3_30312361, hun4hun2hun3dun4zhuan4huan4ying3_30312361NormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.hun4hun2hun3dun4zhuan4huan4ying3_30312361, hun4hun2hun3dun4zhuan4huan4ying3_30312361MonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.hun4hun2hun3dun4zhuan4huan4ying3_30312361, hun4hun2hun3dun4zhuan4huan4ying3_30312361Repos);
            AddExecutor(ExecutorType.Activate, CardId.hun4hun2hun3dun4zhuan4huan4ying3_30312361, hun4hun2hun3dun4zhuan4huan4ying3_30312361Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.qiang2qiang3jiang4yu4zhi1hu2_55144522, qiang2qiang3jiang4yu4zhi1hu2_55144522SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.qiang2qiang3jiang4yu4zhi1hu2_55144522, qiang2qiang3jiang4yu4zhi1hu2_55144522Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.di3jia4jie4jie5gou4wu4_38120068, di3jia4jie4jie5gou4wu4_38120068SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.di3jia4jie4jie5gou4wu4_38120068, di3jia4jie4jie5gou4wu4_38120068Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507, ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507, ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.lei2ji1_12580477, lei2ji1_12580477SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.lei2ji1_12580477, DefaultDarkHole);
            AddExecutor(ExecutorType.SpSummon, CardId.ju4long2zhi1shou3hu4qi2shi4_33460840, JLQSspsummon);
            AddExecutor(ExecutorType.Summon, CardId.ju4long2zhi1shou3hu4qi2shi4_33460840, ju4long2zhi1shou3hu4qi2shi4_33460840NormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.ju4long2zhi1shou3hu4qi2shi4_33460840, ju4long2zhi1shou3hu4qi2shi4_33460840MonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.ju4long2zhi1shou3hu4qi2shi4_33460840, ju4long2zhi1shou3hu4qi2shi4_33460840Repos);
            AddExecutor(ExecutorType.Activate, CardId.ju4long2zhi1shou3hu4qi2shi4_33460840, ju4long2zhi1shou3hu4qi2shi4_33460840Activate);
            AddExecutor(ExecutorType.SpSummon, CardId.lie4yan4huo3xing1_15033525);
            AddExecutor(ExecutorType.Repos, CardId.lie4yan4huo3xing1_15033525, lie4yan4huo3xing1_15033525Repos);
            AddExecutor(ExecutorType.Activate, CardId.lie4yan4huo3xing1_15033525, lie4yan4huo3xing1_15033525Activate);
            AddExecutor(ExecutorType.Summon, CardId.an4hei1jie4de5di4di2shu4zhu2shi1si1nuo4_60228941, an4hei1jie4de5di4di2shu4zhu2shi1si1nuo4_60228941NormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.an4hei1jie4de5di4di2shu4zhu2shi1si1nuo4_60228941, an4hei1jie4de5di4di2shu4zhu2shi1si1nuo4_60228941MonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.an4hei1jie4de5di4di2shu4zhu2shi1si1nuo4_60228941, an4hei1jie4de5di4di2shu4zhu2shi1si1nuo4_60228941Repos);
            AddExecutor(ExecutorType.Activate, CardId.an4hei1jie4de5di4di2shu4zhu2shi1si1nuo4_60228941, an4hei1jie4de5di4di2shu4zhu2shi1si1nuo4_60228941Activate);
            AddExecutor(ExecutorType.SpSummon, CardId.an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233);
            AddExecutor(ExecutorType.Repos, CardId.an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233, an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233Repos);
            AddExecutor(ExecutorType.Activate, CardId.an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233, an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.guo4guo1zao3de5di4di2mai2man2zang4_70828912, guo4guo1zao3de5di4di2mai2man2zang4_70828912SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.guo4guo1zao3de5di4di2mai2man2zang4_70828912, guo4guo1zao3de5di4di2mai2man2zang4_70828912Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.si3zhe3su1sheng1_83764718, si3zhe3su1sheng1_83764718SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.si3zhe3su1sheng1_83764718, si3zhe3su1sheng1_83764718Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.tian1shi3shi4de5di4di2shi1she4she3_79571449, tian1shi3shi4de5di4di2shi1she4she3_79571449SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.tian1shi3shi4de5di4di2shi1she4she3_79571449, tian1shi3shi4de5di4di2shi1she4she3_79571449Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.shou3zha2mo3ma1mo4sha1_72892473, shou3zha2mo3ma1mo4sha1_72892473SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.shou3zha2mo3ma1mo4sha1_72892473, shou3zha2mo3ma1mo4sha1_72892473Activate);
            AddExecutor(ExecutorType.Summon, CardId.guang1yu3yu4yu2an4zhi1long2_47297616, guang1yu3yu4yu2an4zhi1long2_47297616NormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.guang1yu3yu4yu2an4zhi1long2_47297616, guang1yu3yu4yu2an4zhi1long2_47297616MonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.guang1yu3yu4yu2an4zhi1long2_47297616, guang1yu3yu4yu2an4zhi1long2_47297616Repos);
            AddExecutor(ExecutorType.Activate, CardId.guang1yu3yu4yu2an4zhi1long2_47297616, guang1yu3yu4yu2an4zhi1long2_47297616Activate);


            //  Add Executors to all special summonable effect monsters
            //  Add Executors to all pure special summonable effect monsters
            AddExecutor(ExecutorType.Repos, CardId.qian4qian1kan4he2ge3yao4yao1sai4se4sai1long2_79229522, qian4qian1kan4he2ge3yao4yao1sai4se4sai1long2_79229522Repos);
            AddExecutor(ExecutorType.Activate, CardId.qian4qian1kan4he2ge3yao4yao1sai4se4sai1long2_79229522, qian4qian1kan4he2ge3yao4yao1sai4se4sai1long2_79229522Activate);
            AddExecutor(ExecutorType.SpSummon, CardId.qian4qian1kan4he2ge3yao4yao1sai4se4sai1long2_79229522, qian4qian1kan4he2ge3yao4yao1sai4se4sai1long2_79229522SpSummon);
            //  Add Executors to all Link monsters
            //  Add Executors to all spell and trap cards

            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);


        }

            // All Normal Monster Methods

            // All Effect Monster Methods

        private bool tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776NormalSummon()
        {

            return true;
        }

        private bool tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776MonsterSet()
        {

            return true;
        }

        private bool tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776Activate()
        {

            return true;
        }

        private bool hun4hun2hun3dun4zhuan4huan4ying3_30312361NormalSummon()
        {
            if (Bot.HasInGraveyard(CardId.tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776) && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                return true;
            }
            IList<int> targets = new[] 
                {
                    CardId.tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776,
                    CardId.lie4yan4huo3xing1_15033525,
                    CardId.an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233,

                };
            if (Bot.HasInGraveyard(targets) && Util.IsOneEnemyBetter() && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {                
                return true;
            }
            return false;
        }

        private bool hun4hun2hun3dun4zhuan4huan4ying3_30312361MonsterSet()
        {
            IList<int> targets = new[]
    {
                    CardId.tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776,
                    CardId.lie4yan4huo3xing1_15033525,
                    CardId.an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233,

                };
            if (!Bot.HasInGraveyard(targets) && Bot.GetMonsterCount() == 0 && Enemy.GetMonsterCount() >= 2)
            {
                return true;
            }
            return false;
        }

        private bool hun4hun2hun3dun4zhuan4huan4ying3_30312361Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool hun4hun2hun3dun4zhuan4huan4ying3_30312361Activate()
        {
            if (Bot.HasInGraveyard(CardId.tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776) && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                AI.SelectCard(CardId.tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776);
                return true;
            }
            IList<int> targets = new[]
                {
                    CardId.tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776,
                    CardId.lie4yan4huo3xing1_15033525,
                    CardId.an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233,
                    CardId.guang1yu3yu4yu2an4zhi1long2_47297616,

                };
            if (Bot.HasInGraveyard(targets) && Util.IsOneEnemyBetter() && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Enemy.GetMonsterCount() + Enemy.GetSpellCount() + Enemy.GetHandCount() >= 1 && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                return true;
            }
            return false;
        }

        private bool ju4long2zhi1shou3hu4qi2shi4_33460840NormalSummon()
        {
            if (Bot.HasInGraveyard(CardId.guang1yu3yu4yu2an4zhi1long2_47297616) && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                return true;
            }
            if (Bot.HasInHand(CardId.guang1yu3yu4yu2an4zhi1long2_47297616) && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                return true;
            }
            return false;
        }

        private bool JLQSspsummon()
        {
            AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }
        

        private bool ju4long2zhi1shou3hu4qi2shi4_33460840MonsterSet()
        {
            if (Bot.GetMonsterCount() == 0 && Enemy.GetMonsterCount() >= 2)
            {
                return true;
            }
            return false;
        }

        private bool ju4long2zhi1shou3hu4qi2shi4_33460840Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool ju4long2zhi1shou3hu4qi2shi4_33460840Activate()
        {

            if (Bot.HasInGraveyard(CardId.guang1yu3yu4yu2an4zhi1long2_47297616) && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                return true;
            }
            if (Bot.HasInHand(CardId.guang1yu3yu4yu2an4zhi1long2_47297616) && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                return true;
            }
            return false;
        }


        private bool lie4yan4huo3xing1_15033525Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool lie4yan4huo3xing1_15033525Activate()
        {
            IList<int> targets = new[]
               {
                    CardId.hun4hun2hun3dun4zhuan4huan4ying3_30312361,
                    CardId.an4hei1jie4de5di4di2shu4zhu2shi1si1nuo4_60228941,
                    CardId.guang1yu3yu4yu2an4zhi1long2_47297616,
                    CardId.an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233,
                    CardId.ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507,
                    CardId.lie4yan4huo3xing1_15033525,

                };

            if (Bot.GetMonsterCount() == 0 && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.lie4yan4huo3xing1_15033525) && Duel.Phase < DuelPhase.Main1 && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Bot.HasInHand(CardId.lie4yan4huo3xing1_15033525) && Duel.Phase < DuelPhase.Main1 && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Bot.HasInGraveyard(CardId.lie4yan4huo3xing1_15033525) && Duel.Phase > DuelPhase.Main1 && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Bot.HasInHand(CardId.lie4yan4huo3xing1_15033525) && Duel.Phase > DuelPhase.Main1 && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Enemy.LifePoints <=1000 && Bot.GetMonsterCount() >= 3 && Duel.Phase == DuelPhase.Main1 && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                AI.SelectCard(targets);
                return true;
            }
            if (Enemy.LifePoints <= 500 && Bot.GetMonsterCount() >= 2 && Duel.Phase == DuelPhase.Main1 && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                AI.SelectCard(targets);
                return true;
            }
            return false;
        }

        private bool an4hei1jie4de5di4di2shu4zhu2shi1si1nuo4_60228941NormalSummon()
        {

            return true;
        }

        private bool an4hei1jie4de5di4di2shu4zhu2shi1si1nuo4_60228941MonsterSet()
        {

            return true;
        }

        private bool an4hei1jie4de5di4di2shu4zhu2shi1si1nuo4_60228941Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool an4hei1jie4de5di4di2shu4zhu2shi1si1nuo4_60228941Activate()
        {

            return true;
        }


        private bool an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233Activate()
        {

            if (!Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                return true;
            }
            return false;
        }

        private bool guang1yu3yu4yu2an4zhi1long2_47297616NormalSummon()
        {

            return true;
        }

        private bool guang1yu3yu4yu2an4zhi1long2_47297616MonsterSet()
        {

            return true;
        }

        private bool guang1yu3yu4yu2an4zhi1long2_47297616Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool guang1yu3yu4yu2an4zhi1long2_47297616Activate()
        {
            if (Bot.HasInGraveyard(CardId.ju4long2zhi1shou3hu4qi2shi4_33460840))
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                AI.SelectCard(CardId.ju4long2zhi1shou3hu4qi2shi4_33460840);                
                return true;
            }
            IList<int> targets = new[]
                {
                    CardId.lie4yan4huo3xing1_15033525,
                    CardId.an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233,

                };
            if (Bot.HasInGraveyard(targets))
            {
                AI.SelectCard(targets);
                if (Util.IsOneEnemyBetter())
                {
                    AI.SelectPosition(CardPosition.FaceUpDefence);
                    return true;
                }
                return true;
            }
            AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }

            // All Special Summonable Effect Monster Methods

            // All Pure Special Summonable Effect Monster Methods

        private bool qian4qian1kan4he2ge3yao4yao1sai4se4sai1long2_79229522Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool qian4qian1kan4he2ge3yao4yao1sai4se4sai1long2_79229522Activate()
        {

            return true;
        }

        private bool qian4qian1kan4he2ge3yao4yao1sai4se4sai1long2_79229522SpSummon()
        {

            return true;
        }

            // All Link Monster Methods

            // All Spell and Trap Card Methods

        private bool yu2chun3de5di4di2mai2man2zang4_81439173SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool yu2chun3de5di4di2mai2man2zang4_81439173Activate()
        {
            if (!Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                IList<int> SelectedCard = new List<int>();
                SelectedCard.Add(CardId.tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776);
                SelectedCard.Add(CardId.an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233);
                SelectedCard.Add(CardId.lie4yan4huo3xing1_15033525);
                SelectedCard.Add(CardId.guang1yu3yu4yu2an4zhi1long2_47297616);
                AI.SelectCard(SelectedCard);
                return true;
            }
            return false;

        }

        private bool ming2tui1li3_58577036SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool ming2tui1li3_58577036Activate()
        {

            if (!Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                return true;
            }
            return false;
        }

        private bool qiang2qiang3jiang4yu4zhi1hu2_55144522SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool qiang2qiang3jiang4yu4zhi1hu2_55144522Activate()
        {

            if (!Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                return true;
            }
            return false;
        }

        private bool di3jia4jie4jie5gou4wu4_38120068SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool di3jia4jie4jie5gou4wu4_38120068Activate()
        {

            if (!Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                return true;
            }
            return false;
        }

        private bool ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507Activate()
        {

            //如果对面魔法区域2张以上，发动羽毛扫效果。
            if (Enemy.GetSpellCount() >= 2 && Duel.Turn >= 6 && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                return true;
            }
            if (Enemy.HasInSpellZone(CardId.wangjiachangmianzhigu) && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                return true;
            }
            List<ClientCard> spells = Bot.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (Enemy.GetSpellCount() >= 1 && !spell.IsFacedown() && Duel.Turn >= 6 && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616) )
                    return true;
            }

            return false;
        }

        private bool lei2ji1_12580477SpellSet()
        {

            return DefaultSpellSet();
        }


        private bool guo4guo1zao3de5di4di2mai2man2zang4_70828912SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool guo4guo1zao3de5di4di2mai2man2zang4_70828912Activate()
        {

            IList<int> targets = new[]
               {
                    CardId.an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233,
                    CardId.lie4yan4huo3xing1_15033525,
                    CardId.ju4long2zhi1shou3hu4qi2shi4_33460840,
                    CardId.an4hei1jie4de5di4di2shu4zhu2shi1si1nuo4_60228941,

                };
            if (Bot.HasInGraveyard(targets) && Bot.LifePoints >800 && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                AI.SelectCard(targets);
                return true;
            }
            return false;
        }

        private bool si3zhe3su1sheng1_83764718SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool si3zhe3su1sheng1_83764718Activate()
        {
            if (Bot.HasInGraveyard(CardId.hun4hun2hun3dun4zhuan4huan4ying3_30312361) && Bot.HasInGraveyard(CardId.tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776) && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                AI.SelectCard(CardId.hun4hun2hun3dun4zhuan4huan4ying3_30312361);
                return true;
            }
            IList<int> targets = new[]
               {
                    CardId.an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233,                    
                    CardId.ju4long2zhi1shou3hu4qi2shi4_33460840,
                    CardId.lie4yan4huo3xing1_15033525,

                };
            if (Bot.HasInGraveyard(targets) && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                AI.SelectCard(targets);
                return true;
            }
            return false;
        }

        private bool tian1shi3shi4de5di4di2shi1she4she3_79571449SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool tian1shi3shi4de5di4di2shi1she4she3_79571449Activate()
        {
            if (!Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                IList<int> SelectedCard = new List<int>();
                SelectedCard.Add(CardId.tian1mo2shen2nuo4lei2la1la2la3la4si1_48453776);
                SelectedCard.Add(CardId.an4hei1jie4de5di4di2long2shen2ge2la1la2la3la4fa3_34230233);
                SelectedCard.Add(CardId.guang1yu3yu4yu2an4zhi1long2_47297616);
                SelectedCard.Add(CardId.lie4yan4huo3xing1_15033525);
                SelectedCard.Add(CardId.di3jia4jie4jie5gou4wu4_38120068);
                AI.SelectCard(SelectedCard);
                return true;
            }
            return false;


        }

        private bool shou3zha2mo3ma1mo4sha1_72892473SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool shou3zha2mo3ma1mo4sha1_72892473Activate()
        {
            if (Bot.GetHandCount() >= 4 && !Bot.HasInMonstersZone(CardId.guang1yu3yu4yu2an4zhi1long2_47297616))
            {
                return true;
            }
            return false;
        }

    }
}