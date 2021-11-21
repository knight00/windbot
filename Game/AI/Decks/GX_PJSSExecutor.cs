using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
using YGOSharp.OCGWrapper.Enums;
namespace WindBot.Game.AI.Decks
{
   
   [Deck("PJSS", "AI_PJSS", "NotFinished")]
    public class PJSSExecutor: DefaultExecutor
    {
        public class CardId
        {
            // Initialize all normal monsters
            // Initialize all effect monsters
            public const int ka3qia3tong1tong4ge1bu4lin2tu1tu2ji1bu4dui4_15270885 = 15270885;
            public const int ka3qia3tong1tong4shuang1sheng1jing1ling2_42386471 = 42386471;
            public const int ka3qia3tong1tong4jia1nong2pao4bao1pao2pao1bing1_79875176 = 79875176;
            public const int yin1su4niao3diao3_57617178 = 57617178;
            public const int qian1shou3shen2_23401839 = 23401839;
            public const int rong2he2ge3zhou4yin4sheng1wu4an4_52101615 = 52101615;
            public const int mo2mu2fang3de5di4di2huan4xiang3shi1_26376390 = 26376390;
            // Initialize all special summonable effect monsters
            // Initialize all pure special summonable effect monsters
            public const int na4ji4zhai4zhi1mo2_64631466 = 64631466;
            public const int qian1yan3na4ji4zhai4shen2_63519819 = 63519819;
            public const int e4e3wu4wu1mo2xiang1_25655502 = 25655502;
            // Initialize all link monsters
            // Initialize all spell and trap cards
            public const int qiang2qiang3jiang4yu4zhi1hu2_55144522 = 55144522;
            public const int ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507 = 18144507;
            public const int ka3qia3tong1tong4mu4lu4_89997728 = 89997728;
            public const int ka3qia3tong1tong4wang2wang4guo2_43175858 = 43175858;
            public const int ka3qia3tong1tong4shi4jie4_15259703 = 15259703;
            public const int man4man2hua4zhi1shou3_33453260 = 33453260;
            public const int huan4xiang3de5di4di2yi2shi4_41426869 = 41426869;
            public const int fu4zhi4mao1mao2_88032456 = 88032456;
            public const int fan3da4dai4ge2ji2ji3ming4_99188141 = 99188141;
            public const int shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762 = 44095762;
            public const int ci4yuan2you1bi4_70342110 = 70342110;
            public const int nai4nai3luo4la4lao4luo1de5di4di2luo4la4lao4luo1xue2xue4_29401950 = 29401950;
            public const int si3zhe3su1sheng1_83764718 = 83764718;
            // Initialize all useless cards
            public const int GXqian1nian2shen2qi4qian1nian2yan3_3003 = 3003;

         }
        public PJSSExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            // Add Executors to all normal monsters
            // Add Executors to all effect monsters
            AddExecutor(ExecutorType.SpellSet, CardId.qiang2qiang3jiang4yu4zhi1hu2_55144522, qiang2qiang3jiang4yu4zhi1hu2_55144522SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.qiang2qiang3jiang4yu4zhi1hu2_55144522, qiang2qiang3jiang4yu4zhi1hu2_55144522Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507, ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507, ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.ka3qia3tong1tong4mu4lu4_89997728, ka3qia3tong1tong4mu4lu4_89997728SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.ka3qia3tong1tong4mu4lu4_89997728, ka3qia3tong1tong4mu4lu4_89997728Activate);
            AddExecutor(ExecutorType.Activate, CardId.ka3qia3tong1tong4wang2wang4guo2_43175858, ka3qia3tong1tong4wang2wang4guo2_43175858Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.ka3qia3tong1tong4wang2wang4guo2_43175858, ka3qia3tong1tong4wang2wang4guo2_43175858SpellSet);
            AddExecutor(ExecutorType.SpellSet, CardId.ka3qia3tong1tong4shi4jie4_15259703, ka3qia3tong1tong4shi4jie4_15259703SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.ka3qia3tong1tong4shi4jie4_15259703, ka3qia3tong1tong4shi4jie4_15259703Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.man4man2hua4zhi1shou3_33453260, man4man2hua4zhi1shou3_33453260SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.man4man2hua4zhi1shou3_33453260, man4man2hua4zhi1shou3_33453260Activate);
            AddExecutor(ExecutorType.SummonOrSet, CardId.ka3qia3tong1tong4ge1bu4lin2tu1tu2ji1bu4dui4_15270885, ka3qia3tong1tong4ge1bu4lin2tu1tu2ji1bu4dui4_15270885NormalSummon);
            AddExecutor(ExecutorType.Activate, CardId.ka3qia3tong1tong4ge1bu4lin2tu1tu2ji1bu4dui4_15270885, ka3qia3tong1tong4ge1bu4lin2tu1tu2ji1bu4dui4_15270885Activate);
            AddExecutor(ExecutorType.SummonOrSet, CardId.ka3qia3tong1tong4shuang1sheng1jing1ling2_42386471, ka3qia3tong1tong4shuang1sheng1jing1ling2_42386471NormalSummon);
            AddExecutor(ExecutorType.Activate, CardId.ka3qia3tong1tong4shuang1sheng1jing1ling2_42386471, ka3qia3tong1tong4shuang1sheng1jing1ling2_42386471Activate);
            AddExecutor(ExecutorType.SummonOrSet, CardId.ka3qia3tong1tong4jia1nong2pao4bao1pao2pao1bing1_79875176, ka3qia3tong1tong4jia1nong2pao4bao1pao2pao1bing1_79875176NormalSummon);
            AddExecutor(ExecutorType.Summon, CardId.yin1su4niao3diao3_57617178, yin1su4niao3diao3_57617178NormalSummon);
            AddExecutor(ExecutorType.Activate, CardId.yin1su4niao3diao3_57617178, yin1su4niao3diao3_57617178Activate);
            AddExecutor(ExecutorType.Summon, CardId.qian1shou3shen2_23401839, qian1shou3shen2_23401839NormalSummon);
            AddExecutor(ExecutorType.Activate, CardId.qian1shou3shen2_23401839, qian1shou3shen2_23401839Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.huan4xiang3de5di4di2yi2shi4_41426869, huan4xiang3de5di4di2yi2shi4_41426869SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.huan4xiang3de5di4di2yi2shi4_41426869, huan4xiang3de5di4di2yi2shi4_41426869Activate);
            AddExecutor(ExecutorType.Summon, CardId.rong2he2ge3zhou4yin4sheng1wu4an4_52101615, rong2he2ge3zhou4yin4sheng1wu4an4_52101615NormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.rong2he2ge3zhou4yin4sheng1wu4an4_52101615, rong2he2ge3zhou4yin4sheng1wu4an4_52101615MonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.rong2he2ge3zhou4yin4sheng1wu4an4_52101615, rong2he2ge3zhou4yin4sheng1wu4an4_52101615Repos);
            AddExecutor(ExecutorType.Activate, CardId.rong2he2ge3zhou4yin4sheng1wu4an4_52101615, rong2he2ge3zhou4yin4sheng1wu4an4_52101615Activate);
            AddExecutor(ExecutorType.Summon, CardId.mo2mu2fang3de5di4di2huan4xiang3shi1_26376390, mo2mu2fang3de5di4di2huan4xiang3shi1_26376390NormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.mo2mu2fang3de5di4di2huan4xiang3shi1_26376390, mo2mu2fang3de5di4di2huan4xiang3shi1_26376390MonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.mo2mu2fang3de5di4di2huan4xiang3shi1_26376390, mo2mu2fang3de5di4di2huan4xiang3shi1_26376390Repos);
            AddExecutor(ExecutorType.Activate, CardId.mo2mu2fang3de5di4di2huan4xiang3shi1_26376390, mo2mu2fang3de5di4di2huan4xiang3shi1_26376390Activate);


            //  Add Executors to all special summonable effect monsters
            //  Add Executors to all pure special summonable effect monsters

            AddExecutor(ExecutorType.Summon, CardId.na4ji4zhai4zhi1mo2_64631466, na4ji4zhai4zhi1mo2_64631466Repos);
            AddExecutor(ExecutorType.Activate, CardId.na4ji4zhai4zhi1mo2_64631466, na4ji4zhai4zhi1mo2_64631466Activate);
            AddExecutor(ExecutorType.SpSummon, CardId.na4ji4zhai4zhi1mo2_64631466, na4ji4zhai4zhi1mo2_64631466SpSummon);

            AddExecutor(ExecutorType.Summon, CardId.qian1yan3na4ji4zhai4shen2_63519819, qian1yan3na4ji4zhai4shen2_63519819Repos);
            AddExecutor(ExecutorType.Activate, CardId.qian1yan3na4ji4zhai4shen2_63519819, qian1yan3na4ji4zhai4shen2_63519819Activate);
            AddExecutor(ExecutorType.SpSummon, CardId.qian1yan3na4ji4zhai4shen2_63519819, qian1yan3na4ji4zhai4shen2_63519819SpSummon);
            AddExecutor(ExecutorType.Repos, CardId.e4e3wu4wu1mo2xiang1_25655502, e4e3wu4wu1mo2xiang1_25655502Repos);
            AddExecutor(ExecutorType.Activate, CardId.e4e3wu4wu1mo2xiang1_25655502, e4e3wu4wu1mo2xiang1_25655502Activate);
            AddExecutor(ExecutorType.SpSummon, CardId.e4e3wu4wu1mo2xiang1_25655502, e4e3wu4wu1mo2xiang1_25655502SpSummon);
            //  Add Executors to all Link monsters
            //  Add Executors to all spell and trap cards







            AddExecutor(ExecutorType.SpellSet, CardId.fu4zhi4mao1mao2_88032456, fu4zhi4mao1mao2_88032456SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.fu4zhi4mao1mao2_88032456, fu4zhi4mao1mao2_88032456Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.fan3da4dai4ge2ji2ji3ming4_99188141, fan3da4dai4ge2ji2ji3ming4_99188141SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.fan3da4dai4ge2ji2ji3ming4_99188141, DefaultTrap);
            AddExecutor(ExecutorType.SpellSet, CardId.shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762, shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762, shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.ci4yuan2you1bi4_70342110, ci4yuan2you1bi4_70342110SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.ci4yuan2you1bi4_70342110, ci4yuan2you1bi4_70342110Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.nai4nai3luo4la4lao4luo1de5di4di2luo4la4lao4luo1xue2xue4_29401950, nai4nai3luo4la4lao4luo1de5di4di2luo4la4lao4luo1xue2xue4_29401950SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.nai4nai3luo4la4lao4luo1de5di4di2luo4la4lao4luo1xue2xue4_29401950, nai4nai3luo4la4lao4luo1de5di4di2luo4la4lao4luo1xue2xue4_29401950Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.si3zhe3su1sheng1_83764718, si3zhe3su1sheng1_83764718SpellSet);
            AddExecutor(ExecutorType.Activate, CardId.si3zhe3su1sheng1_83764718, DefaultCallOfTheHaunted);

            AddExecutor(ExecutorType.Activate, CardId.GXqian1nian2shen2qi4qian1nian2yan3_3003);

            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);

        }

            // All Normal Monster Methods

            // All Effect Monster Methods

        private bool ka3qia3tong1tong4ge1bu4lin2tu1tu2ji1bu4dui4_15270885NormalSummon()
        {

            return true;
        }

        private bool ka3qia3tong1tong4ge1bu4lin2tu1tu2ji1bu4dui4_15270885MonsterSet()
        {

            return true;
        }

        private bool ka3qia3tong1tong4ge1bu4lin2tu1tu2ji1bu4dui4_15270885Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool ka3qia3tong1tong4ge1bu4lin2tu1tu2ji1bu4dui4_15270885Activate()
        {

            return true;
        }

        private bool ka3qia3tong1tong4shuang1sheng1jing1ling2_42386471NormalSummon()
        {

            return true;
        }

        private bool ka3qia3tong1tong4shuang1sheng1jing1ling2_42386471MonsterSet()
        {

            return true;
        }

        private bool ka3qia3tong1tong4shuang1sheng1jing1ling2_42386471Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool ka3qia3tong1tong4shuang1sheng1jing1ling2_42386471Activate()
        {

            return true;
        }

        private bool ka3qia3tong1tong4jia1nong2pao4bao1pao2pao1bing1_79875176NormalSummon()
        {

            return true;
        }

        private bool ka3qia3tong1tong4jia1nong2pao4bao1pao2pao1bing1_79875176MonsterSet()
        {

            return true;
        }

        private bool ka3qia3tong1tong4jia1nong2pao4bao1pao2pao1bing1_79875176Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool ka3qia3tong1tong4jia1nong2pao4bao1pao2pao1bing1_79875176Activate()
        {

            return true;
        }

        private bool yin1su4niao3diao3_57617178NormalSummon()
        {

            return true;
        }

        private bool yin1su4niao3diao3_57617178MonsterSet()
        {

            return true;
        }

        private bool yin1su4niao3diao3_57617178Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool yin1su4niao3diao3_57617178Activate()
        {

            return true;
        }

        private bool qian1shou3shen2_23401839NormalSummon()
        {

            return true;
        }

        private bool qian1shou3shen2_23401839MonsterSet()
        {

            return true;
        }

        private bool qian1shou3shen2_23401839Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool qian1shou3shen2_23401839Activate()
        {

            return true;
        }

        private bool rong2he2ge3zhou4yin4sheng1wu4an4_52101615NormalSummon()
        {
            if (Bot.MonsterZone.GetCardCount(CardId.na4ji4zhai4zhi1mo2_64631466) >= 1)
            {
                return true;
            }
            return false;
        }

        private bool rong2he2ge3zhou4yin4sheng1wu4an4_52101615MonsterSet()
        {

            return true;
        }

        private bool rong2he2ge3zhou4yin4sheng1wu4an4_52101615Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool rong2he2ge3zhou4yin4sheng1wu4an4_52101615Activate()
        {

            return true;
        }

        private bool mo2mu2fang3de5di4di2huan4xiang3shi1_26376390NormalSummon()
        {

            return true;
        }

        private bool mo2mu2fang3de5di4di2huan4xiang3shi1_26376390MonsterSet()
        {

            return true;
        }

        private bool mo2mu2fang3de5di4di2huan4xiang3shi1_26376390Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool mo2mu2fang3de5di4di2huan4xiang3shi1_26376390Activate()
        {

            return true;
        }

            // All Special Summonable Effect Monster Methods

            // All Pure Special Summonable Effect Monster Methods

        private bool na4ji4zhai4zhi1mo2_64631466Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool na4ji4zhai4zhi1mo2_64631466Activate()
        {

            return true;
        }

        private bool na4ji4zhai4zhi1mo2_64631466SpSummon()
        {

            return true;
        }

        private bool qian1yan3na4ji4zhai4shen2_63519819Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool qian1yan3na4ji4zhai4shen2_63519819Activate()
        {

            return true;
        }

        private bool qian1yan3na4ji4zhai4shen2_63519819SpSummon()
        {

            return true;
        }

        private bool e4e3wu4wu1mo2xiang1_25655502Repos()
        {

            return DefaultMonsterRepos();
        }

        private bool e4e3wu4wu1mo2xiang1_25655502Activate()
        {

            return true;
        }

        private bool e4e3wu4wu1mo2xiang1_25655502SpSummon()
        {

            return true;
        }

            // All Link Monster Methods

            // All Spell and Trap Card Methods

        private bool qiang2qiang3jiang4yu4zhi1hu2_55144522SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool qiang2qiang3jiang4yu4zhi1hu2_55144522Activate()
        {

            return true;
        }

        private bool ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool ying1shen1juan1nu3ru3yao1de5di4di2yu3mao2sao3sao4_18144507Activate()
        {

            return true;
        }

        private bool ka3qia3tong1tong4mu4lu4_89997728SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool ka3qia3tong1tong4mu4lu4_89997728Activate()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.ka3qia3tong1tong4wang2wang4guo2_43175858);
            SelectedCard.Add(CardId.ka3qia3tong1tong4shi4jie4_15259703);
            SelectedCard.Add(CardId.ka3qia3tong1tong4ge1bu4lin2tu1tu2ji1bu4dui4_15270885);
            SelectedCard.Add(CardId.ka3qia3tong1tong4shuang1sheng1jing1ling2_42386471);
            AI.SelectCard(SelectedCard);
            return true;
        }

        private bool ka3qia3tong1tong4wang2wang4guo2_43175858SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool ka3qia3tong1tong4wang2wang4guo2_43175858Activate()
        {
            if(Duel.Player == 0 && Duel.Phase >= DuelPhase.Main1 && Duel.Phase <= DuelPhase.End && Bot.HasInSpellZone(CardId.ka3qia3tong1tong4wang2wang4guo2_43175858))
            {
                return false;
            }
            return true;
        }

        private bool ka3qia3tong1tong4shi4jie4_15259703SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool ka3qia3tong1tong4shi4jie4_15259703Activate()
        {

            return true;
        }

        private bool man4man2hua4zhi1shou3_33453260SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool man4man2hua4zhi1shou3_33453260Activate()
        {

            return true;
        }

        private bool huan4xiang3de5di4di2yi2shi4_41426869SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool huan4xiang3de5di4di2yi2shi4_41426869Activate()
        {

            return true;
        }

        private bool fu4zhi4mao1mao2_88032456SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool fu4zhi4mao1mao2_88032456Activate()
        {

            return true;
        }

        private bool fan3da4dai4ge2ji2ji3ming4_99188141SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool fan3da4dai4ge2ji2ji3ming4_99188141Activate()
        {

            return true;
        }

        private bool shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool shen2sheng4fang2hu4zhao4fan3she4shi2ye4jing4li4_44095762Activate()
        {

            return true;
        }

        private bool ci4yuan2you1bi4_70342110SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool ci4yuan2you1bi4_70342110Activate()
        {

            return true;
        }

        private bool nai4nai3luo4la4lao4luo1de5di4di2luo4la4lao4luo1xue2xue4_29401950SpellSet()
        {

            return DefaultSpellSet();
        }

        private bool nai4nai3luo4la4lao4luo1de5di4di2luo4la4lao4luo1xue2xue4_29401950Activate()
        {

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