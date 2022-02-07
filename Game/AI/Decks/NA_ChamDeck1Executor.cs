using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using System.Linq;
using System;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
namespace WindBot.Game.AI.Decks
{
    [Deck("ChamDeck1", "AI_ChamDeck1", "NotFinished")]
    public class ChamDeck1Executor : DefaultExecutor
    {
        public class CardId
        {
            public const int Nibilu = 27204311;
            public const int Hjixie = 63941210;
            public const int Hlei = 48770333;
            public const int Hkonglong = 93332803;
            public const int Jlong = 9069157;
            public const int Hkunchongfeng = 36956512;
            public const int Hshui = 55063751;
            public const int Hemo = 28674152;
            public const int Hkunchongdi = 29726552;
            public const int Jweixing = 9951505;
            public const int Jtanke = 9951509;
            public const int Jdaodan = 9951508;
            public const int Huiliuli = 14558127;
            public const int G = 23434538;
            public const int Sheiqiushou = 95770000;
            public const int Jyixing = 9951504;
            public const int Xiaoguozhemeng = 97268402;
            public const int Leiji = 12580477;
            public const int Yumaosao = 18144506;
            public const int Diannaowangwakuang = 57160136;
            public const int Hanmian = 99330325;
            public const int Muzhi = 24224830;
            public const int Mosha = 65681983;
            public const int Wuxianpaoying = 10045474;
            public const int Jsuoliya = 9951512;
            public const int Szhandoubaolong = 95770004;
            public const int Sjixiebaolong = 95770003;
            public const int Sbaolong = 95770002;
            public const int Syagu = 95770001;
            public const int Fangwenmayu = 86066372;
            public const int Yuanshan = 9950651;
            public const int Mohuanghou = 45819647;
            public const int Shuijingjiqiao = 50588353;
            public const int Keluosi = 9950656;
            public const int Dujiaoshou = 60303245;
        }
        List<int> Impermanence_list = new List<int>();
        List<int> should_not_negate = new List<int>
        {
            81275020, 28985331
        };
        List<int> Hselect = new List<int>
        {
            CardId.Hjixie,CardId.Hlei,CardId.Hkonglong,CardId.Hemo,CardId.Hkunchongfeng,CardId.Hkunchongdi,CardId.Hshui
        };
        int Jweixing_Id = 0;
        int attNumber = 0;
        bool SzhandoubaolongDisEffect = false;

        //特殊召唤
        bool JtankeSpSummon = false;

        //效果发动
        bool Jyixing = false;
        bool Jdaodan = false;
        public ChamDeck1Executor(GameAI ai, Duel duel)
  : base(ai, duel)
        {
            //暴龙兽
            AddExecutor(ExecutorType.Activate, CardId.Sbaolong, SbaolongEffect);
            //机械战斗暴龙兽
            AddExecutor(ExecutorType.Activate, CardId.Sjixiebaolong, SjixiebaolongEffect);
            //坏兽 
            AddExecutor(ExecutorType.SpSummon, CardId.Hjixie,Hsummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Hlei, Hsummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Hkonglong, Hsummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Hkunchongfeng, Hsummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Hkunchongdi, Hsummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Hshui, Hsummon);
            AddExecutor(ExecutorType.SpSummon, CardId.Hemo,Hsummon);

            AddExecutor(ExecutorType.SpSummon, CardId.Hshui, Hsummon2);
            AddExecutor(ExecutorType.SpSummon, CardId.Hemo, Hsummon2);
            AddExecutor(ExecutorType.SpSummon, CardId.Hkunchongdi, Hsummon2);
            AddExecutor(ExecutorType.SpSummon, CardId.Hkunchongfeng, Hsummon2);
            AddExecutor(ExecutorType.SpSummon, CardId.Hkonglong, Hsummon2);
            AddExecutor(ExecutorType.SpSummon, CardId.Hlei, Hsummon2);
            AddExecutor(ExecutorType.SpSummon, CardId.Hjixie, Hsummon2);
            //雷击
            AddExecutor(ExecutorType.Activate, CardId.Leiji);
            //羽毛扫
            AddExecutor(ExecutorType.Activate, CardId.Yumaosao);
            //抹杀
            AddExecutor(ExecutorType.Activate, CardId.Mosha, MoshaEffect);
            //灰流丽
            AddExecutor(ExecutorType.Activate, CardId.Huiliuli, Hand_act_eff);
            //G
            AddExecutor(ExecutorType.Activate, CardId.G, G_activate);
            //效果遮蒙
            AddExecutor(ExecutorType.Activate, CardId.Xiaoguozhemeng, XiaoguozhemengEffect);
            //无限泡影
            AddExecutor(ExecutorType.Activate, CardId.Wuxianpaoying, Impermanence_activate);
            //墓指
            AddExecutor(ExecutorType.Activate, CardId.Muzhi, DefaultCalledByTheGrave);
            //龙机人
            AddExecutor(ExecutorType.Activate, CardId.Jlong, JlongEffect);
            //电脑网挖矿
            AddExecutor(ExecutorType.Activate, CardId.Diannaowangwakuang, DiannaowangwakuangEffect);
            //黑球兽
            AddExecutor(ExecutorType.Summon, CardId.Sheiqiushou);
            //黑球兽
            AddExecutor(ExecutorType.Activate, CardId.Sheiqiushou);
            //亚古兽
            AddExecutor(ExecutorType.SpSummon, CardId.Syagu);
            //暴龙兽
            AddExecutor(ExecutorType.SpSummon, CardId.Sbaolong);
            //机械战斗暴龙兽
            AddExecutor(ExecutorType.SpSummon, CardId.Sjixiebaolong);
            //战斗暴龙兽
            AddExecutor(ExecutorType.SpSummon, CardId.Szhandoubaolong);
            //战斗暴龙兽
            AddExecutor(ExecutorType.Activate, CardId.Szhandoubaolong, SzhandoubaolongEffect);
            //克洛斯 效果
            AddExecutor(ExecutorType.Activate, CardId.Keluosi, KeluosiEffect);
            //一型机人
            AddExecutor(ExecutorType.Summon, CardId.Jyixing);
            AddExecutor(ExecutorType.Activate, CardId.Jyixing, JyixingEffect);
            //坦克机人 召唤
            AddExecutor(ExecutorType.SpSummon, CardId.Jtanke, JtankeSummon);
            //坦克机人 发动
            AddExecutor(ExecutorType.Activate, CardId.Jtanke);
            //卫星机人
            AddExecutor(ExecutorType.Activate, CardId.Jweixing, JweixingEffect);
            //导弹机人
            AddExecutor(ExecutorType.Activate, CardId.Jdaodan, JdaodanEffect);
            //坏兽安眠
            AddExecutor(ExecutorType.Activate, CardId.Hanmian, HanmianEffect);
            //索利得机人
            AddExecutor(ExecutorType.SpSummon, CardId.Jsuoliya);
            AddExecutor(ExecutorType.Activate, CardId.Jsuoliya);
            //导弹机人 召唤
            AddExecutor(ExecutorType.Summon, CardId.Jdaodan);
            //独角兽
            AddExecutor(ExecutorType.SpSummon, CardId.Dujiaoshou);
            //原始生命形态
            AddExecutor(ExecutorType.Activate, CardId.Hjixie);
            //魔皇后 效果
            AddExecutor(ExecutorType.Activate, CardId.Mohuanghou);

            //亚古兽 效果
            AddExecutor(ExecutorType.Activate, CardId.Syagu);
            //水晶机巧
            AddExecutor(ExecutorType.Activate, CardId.Shuijingjiqiao);
            //卫星机人
            AddExecutor(ExecutorType.Summon, CardId.Jweixing, JweixingSummon);

            //水晶机巧
            AddExecutor(ExecutorType.SpSummon, CardId.Shuijingjiqiao, ShuijingjiqiaoSummon);
            //克洛斯
            AddExecutor(ExecutorType.SpSummon, CardId.Keluosi, KeluosiSummon);
            //魔皇后
            AddExecutor(ExecutorType.SpSummon, CardId.Mohuanghou, MohuanghouSummon);
            //远山
            AddExecutor(ExecutorType.SpSummon, CardId.Yuanshan, YuanshanSummon);
            //远山
            AddExecutor(ExecutorType.Activate, CardId.Yuanshan, YuanshanEffect);

            //访问
            AddExecutor(ExecutorType.SpSummon, CardId.Fangwenmayu, FangwenmayuSummon);
            //访问
            AddExecutor(ExecutorType.Activate, CardId.Fangwenmayu, FangwenmayuEffect);

            //魔陷盖放
            AddExecutor(ExecutorType.SpellSet, SpellSet);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
        }
        public int Link(int id)
        {
            if (id == CardId.Fangwenmayu) return 4;
            else if (id == CardId.Yuanshan || id == CardId.Mohuanghou) return 3;
            else if (id == CardId.Shuijingjiqiao || id == CardId.Keluosi) return 2;
            else if (id == CardId.Szhandoubaolong || id == CardId.Jsuoliya) return -1;
            return 1;
        }
        public override void OnNewTurn()
        {
            SzhandoubaolongDisEffect = false;

            JtankeSpSummon = false;
            Jyixing = false;
            Jdaodan = false;
            Jweixing_Id = 0;
        }
        public bool is_should_not_negate()
        {
            ClientCard last_card = Util.GetLastChainCard();
            if (last_card != null
                && last_card.Controller == 1 && last_card.IsCode(should_not_negate))
                return true;
            return false;
        }
        //格子
        public int SelectSTPlace(ClientCard card = null, bool avoid_Impermanence = false)
        {
            List<int> list = new List<int> { 0, 1, 2, 3, 4 };
            int n = list.Count;
            while (n-- > 1)
            {
                int index = Program.Rand.Next(n + 1);
                int temp = list[index];
                list[index] = list[n];
                list[n] = temp;
            }
            foreach (int seq in list)
            {
                int zone = (int)System.Math.Pow(2, seq);
                if (Bot.SpellZone[seq] == null)
                {
                    if (card != null && card.Location == CardLocation.Hand && avoid_Impermanence && Impermanence_list.Contains(seq)) continue;
                    return zone;
                };
            }
            return 0;
        }
        //卡组检查
        public int CheckRemainInDeck(int id)
        {
            switch (id)
            {
                case CardId.Jlong:
                    return Bot.GetRemainingCount(CardId.Jlong, 3);
                case CardId.Jweixing:
                    return Bot.GetRemainingCount(CardId.Jweixing, 1);
                case CardId.Jtanke:
                    return Bot.GetRemainingCount(CardId.Jtanke, 1);
                case CardId.Jdaodan:
                    return Bot.GetRemainingCount(CardId.Jdaodan, 1);
                case CardId.Nibilu:
                    return Bot.GetRemainingCount(CardId.Nibilu, 1);
                case CardId.Hjixie:
                    return Bot.GetRemainingCount(CardId.Hjixie, 2);
                case CardId.Hlei:
                    return Bot.GetRemainingCount(CardId.Hlei, 1);
                case CardId.Hkonglong:
                    return Bot.GetRemainingCount(CardId.Hkonglong, 1);
                case CardId.Hkunchongfeng:
                    return Bot.GetRemainingCount(CardId.Hkunchongfeng, 1);
                case CardId.Hshui:
                    return Bot.GetRemainingCount(CardId.Hshui, 2);
                case CardId.Hemo:
                    return Bot.GetRemainingCount(CardId.Hemo, 1);
                case CardId.Hkunchongdi:
                    return Bot.GetRemainingCount(CardId.Hkunchongdi, 2);
                case CardId.Huiliuli:
                    return Bot.GetRemainingCount(CardId.Huiliuli, 2);
                case CardId.G:
                    return Bot.GetRemainingCount(CardId.G, 2);
                case CardId.Sheiqiushou:
                    return Bot.GetRemainingCount(CardId.Sheiqiushou, 3);
                case CardId.Xiaoguozhemeng:
                    return Bot.GetRemainingCount(CardId.Xiaoguozhemeng, 2);
                case CardId.Leiji:
                    return Bot.GetRemainingCount(CardId.Leiji, 1);
                case CardId.Yumaosao:
                    return Bot.GetRemainingCount(CardId.Yumaosao, 1);
                case CardId.Diannaowangwakuang:
                    return Bot.GetRemainingCount(CardId.Diannaowangwakuang, 3);
                case CardId.Hanmian:
                    return Bot.GetRemainingCount(CardId.Hanmian, 2);
                case CardId.Muzhi:
                    return Bot.GetRemainingCount(CardId.Muzhi, 2);
                case CardId.Mosha:
                    return Bot.GetRemainingCount(CardId.Mosha, 1);
                case CardId.Wuxianpaoying:
                    return Bot.GetRemainingCount(CardId.Wuxianpaoying, 3);
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
        //访问 效果
        private bool FangwenmayuEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Fangwenmayu, 0))
            {
                AI.SelectCard(CardId.Yuanshan, CardId.Mohuanghou);
                return true;
            }
            else
            {
                IList<ClientCard> list = new List<ClientCard>();
                List<ClientCard> m_Monster = Bot.GetMonsters();
                List<ClientCard> g_Monster = Bot.Graveyard.GetMonsters();
                foreach (ClientCard card in g_Monster)
                {
                    if (card.HasType(CardType.Link))
                    {
                        list.Add(card);
                    }
                }
                foreach (ClientCard card2 in m_Monster)
                {
                    if (card2.HasType(CardType.Link) && card2.Id != Card.Id)
                    {
                        list.Add(card2);
                    }
                }
                if (list.Count <= 0) return false;
                int att1 = list.Count(card => card != null && card.HasAttribute(CardAttribute.Dark));
                int att2 = list.Count(card => card != null && card.HasAttribute(CardAttribute.Divine));
                int att3 = list.Count(card => card != null && card.HasAttribute(CardAttribute.Earth));
                int att4 = list.Count(card => card != null && card.HasAttribute(CardAttribute.Fire));
                int att5 = list.Count(card => card != null && card.HasAttribute(CardAttribute.Light));
                int att6 = list.Count(card => card != null && card.HasAttribute(CardAttribute.Water));
                int att7 = list.Count(card => card != null && card.HasAttribute(CardAttribute.Wind));
                for (int i = 0; i < 7; i++)
                {
                    string att="att"+((i+1).ToString());
                    if (int.Parse(att) > 0)
                    {
                        attNumber += 1;
                    }
                }
                ClientCard card3 = Util.GetBestEnemyCard();
                if (card3 != null && attNumber>0)
                {
                    AI.SelectCard(list);
                    AI.SelectNextCard(card3);
                    attNumber -= 1;
                    return true;
                }
                return false;
            }
        }
        //效果遮蒙
        private bool XiaoguozhemengEffect()
        {
            ClientCard disCard = Util.GetLastChainCard();
            if (disCard != null && (Duel.Phase == DuelPhase.Main1 || Duel.Phase == DuelPhase.Main2) && Duel.LastChainPlayer == 1)
            {
                AI.SelectCard(disCard);
                return true;
            }
            else
            {
                foreach (ClientCard card in Enemy.GetMonsters())
                {
                    if (!card.IsDisabled())
                    {
                        AI.SelectCard(card);
                        return true;
                    }
                }
                return false;
            }
        }
        //远山 效果
        private bool YuanshanEffect()
        {
            ClientCard card = Util.GetBestEnemyMonster();
            if (card == null) return false;
            AI.SelectCard(card);
            return true;
        }
        //克洛斯 效果
        private bool KeluosiEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                ClientCard monster = Util.GetBestEnemyMonster();
                ClientCard spell = Util.GetBestEnemySpell();
                if (monster == null || spell == null) return false;
                AI.SelectCard(CardLocation.Grave);
                AI.SelectNextCard(monster);
                AI.SelectThirdCard(spell);
                return true;
            }
            else if (Card.Location == CardLocation.Grave)
            {
                ClientCard card = Util.GetBestEnemyCard();
                if(card!=null)
                {
                    AI.SelectCard(card);
                    return true;
                }
                return false;
            }
            return false;
        }
        public int GetCountCardInZone(IEnumerable<ClientCard> cards, CardType type)
        {
            return cards.Count(card => card != null && card.HasType(type) && card.IsFaceup());
        }
        //魔皇后
        private bool MohuanghouSummon()
        {
            if (GetCountCardInZone(Enemy.Graveyard, CardType.Spell) + GetCountCardInZone(Enemy.SpellZone, CardType.Spell) + GetCountCardInZone(Bot.Graveyard, CardType.Spell) + GetCountCardInZone(Bot.SpellZone, CardType.Spell) < 3) return false;
            int link_count = 0;
            IList<ClientCard> list = new List<ClientCard>();
            foreach (ClientCard card in Bot.GetMonstersInExtraZone())
            {
                if ((Link(card.Id) == 2 || card.LinkMarker == 2) && card.HasType(CardType.Effect) && card.IsFaceup())
                {
                    link_count += 2;
                    list.Add(card);
                }
            }
            List<ClientCard> monsters = Bot.GetMonstersInMainZone();
            monsters.Sort(CardContainer.CompareCardAttack);
            foreach (ClientCard card2 in monsters)
            {
                if (Link(card2.Id) == 1 && card2.Id == Jweixing_Id && card2.HasType(CardType.Effect) && card2.IsFaceup())
                {
                    link_count += 1;
                    list.Add(card2);
                    if (link_count >= 3) break;
                }
            }
            foreach (ClientCard card3 in monsters)
            {
                if ((Link(card3.Id) == 1 || card3.LinkMarker == 1) && card3.HasType(CardType.Effect) && card3.IsFaceup())
                {
                    link_count += 1;
                    list.Add(card3);
                    if (link_count >= 3) break;
                }
            }
            int spellCasterNumber = 0;
            foreach (ClientCard card4 in list)
            {
                if (card4.HasRace(CardRace.SpellCaster))
                {
                    spellCasterNumber = 1;
                }
            }
            if (list.Count < 2 || link_count > 3 || spellCasterNumber==0) return false;
            AI.SelectMaterials(list);
            return true;
        }
        //访问
        private  bool FangwenmayuSummon()
        {
            if (Enemy.GetMonsterCount() + Enemy.GetSpellCount() > 0)
            {
                int link_count = 0;
                IList<ClientCard> list = new List<ClientCard>();
                foreach (ClientCard card in Bot.GetMonstersInExtraZone())
                {
                    if ((Link(card.Id) == 2 || card.LinkMarker == 2) && card.HasType(CardType.Effect) && card.IsFaceup())
                    {
                        link_count += 2;
                        list.Add(card);
                    }
                    if ((Link(card.Id) == 3 || card.LinkMarker == 3) && card.HasType(CardType.Effect) && card.IsFaceup())
                    {
                        link_count += 3;
                        list.Add(card);
                    }
                }
                List<ClientCard> monsters = Bot.GetMonstersInMainZone();
                monsters.Sort(CardContainer.CompareCardAttack);
                foreach (ClientCard card2 in monsters)
                {
                    if (Link(card2.Id) == 1 && card2.Id == Jweixing_Id && card2.HasType(CardType.Effect) && card2.IsFaceup())
                    {
                        link_count += 1;
                        list.Add(card2);
                        if (link_count >= 4) break;
                    }
                    if (Link(card2.Id) == 2 && card2.HasType(CardType.Effect) && card2.IsFaceup())
                    {
                        link_count += 2;
                        list.Add(card2);
                        if (link_count >= 4) break;
                    }
                }
                foreach (ClientCard card3 in monsters)
                {
                    if ((Link(card3.Id) == 1 || card3.LinkMarker == 1) && card3.HasType(CardType.Effect) && card3.IsFaceup())
                    {
                        link_count += 1;
                        list.Add(card3);
                        if (link_count >= 4) break;
                    }
                }
                if (list.Count < 2 || link_count > 4) return false;
                AI.SelectMaterials(list);
                return true;
            }
            return false;
        }
        //远山
        private bool YuanshanSummon()
        {
            if (YuanshanSummonYesNo()==true || Enemy.GetMonsterCount()+Enemy.GetSpellCount()>0)
            {
                int link_count = 0;
                IList<ClientCard> list = new List<ClientCard>();
                foreach (ClientCard card in Bot.GetMonstersInExtraZone())
                {
                    if ((Link(card.Id) == 2 || card.LinkMarker == 2) && card.HasType(CardType.Effect) && card.IsFaceup())
                    {
                        link_count += 2;
                        list.Add(card);
                    }
                }
                List<ClientCard> monsters = Bot.GetMonstersInMainZone();
                monsters.Sort(CardContainer.CompareCardAttack);
                foreach (ClientCard card2 in monsters)
                {
                    if (Link(card2.Id) == 1 && card2.Id==Jweixing_Id && card2.HasType(CardType.Effect) && card2.IsFaceup())
                    {
                        link_count += 1;
                        list.Add(card2);
                        if (link_count >= 3) break;
                    }
                }
                foreach (ClientCard card3 in monsters)
                {
                    if ((Link(card3.Id) == 1 || card3.LinkMarker == 1) && card3.HasType(CardType.Effect) && card3.IsFaceup())
                    {
                        link_count += 1;
                        list.Add(card3);
                        if (link_count >= 3) break;
                    }
                }
                if (list.Count <2 || link_count > 3) return false;
                AI.SelectMaterials(list);
                return true;
            }
            return false;

        }
        public bool YuanshanSummonYesNo()
        {
            foreach (ClientCard card in Bot.GetMonsters())
            {
                if (card.Id == Jweixing_Id && card.IsFaceup() && card.HasType(CardType.Effect)) return true;
            }
            return false;
        }
        //水晶机巧
        private bool ShuijingjiqiaoSummon()
        {
            int link_count = 0;
            bool tunerMonster = false;
            IList<ClientCard> list = new List<ClientCard>();
            foreach (ClientCard card in Bot.GetMonstersInExtraZone())
            {
                if ((Link(card.Id) == 1 || card.LinkMarker == 1) && card.IsFaceup())
                {
                    if (card.HasType(CardType.Tuner))
                    {
                        tunerMonster = true;
                    }
                    link_count += 1;
                    list.Add(card);
                }
            }
            List<ClientCard> monsters = Bot.GetMonstersInMainZone();
            monsters.Sort(CardContainer.CompareCardAttack);
            foreach (ClientCard card2 in monsters)
            {
                if ((Link(card2.Id) == 1 || card2.LinkMarker == 1) && card2.IsFaceup())
                {
                    if (card2.HasType(CardType.Tuner))
                    {
                        tunerMonster = true;
                    }
                    link_count += 1;
                    list.Add(card2);
                    if (link_count >= 2) break;
                }
            }
            if (list.Count != 2 || link_count > 2 || tunerMonster==false) return false;
            AI.SelectMaterials(list);
            return true;
        }
        //克洛斯
        private bool KeluosiSummon()
        {
            int link_count = 0;
            IList<ClientCard> list = new List<ClientCard>();
            foreach (ClientCard card in Bot.GetMonstersInExtraZone())
            {
                if ((Link(card.Id) == 1 || card.LinkMarker == 1) && card.HasType(CardType.Effect) && card.IsFaceup())
                {
                    link_count += 1;
                    list.Add(card);
                }
            }
            List<ClientCard> monsters = Bot.GetMonstersInMainZone();
            monsters.Sort(CardContainer.CompareCardAttack);
            foreach (ClientCard card2 in monsters)
            {
                if ((Link(card2.Id) == 1 || card2.LinkMarker == 1) && card2.HasType(CardType.Effect) && card2.IsFaceup())
                {
                    link_count += 1;
                    list.Add(card2);
                    if (link_count >= 2) break;
                }
            }
            if (list.Count != 2 || link_count > 2) return false;
            AI.SelectMaterials(list);
            return true;
        }
        //坏兽特殊召唤
        private bool Hsummon2()
        {
            if (Bot.GetCountCardInZone(Bot.Hand, CardType.Monster, 0xd3) > 1)
            {
                ClientCard card = Util.GetBestEnemyMonster();
                if (card != null)
                {
                    AI.SelectCard(card);
                    return true;
                }
                return false;
            }
            return false;
        }
            private bool Hsummon()
        {
            if (Enemy.GetCountCardInZone(Enemy.MonsterZone, CardType.Monster, 0xd3) <= 0)
            {
                int BotAttack = Util.GetBestAttack(Bot);
                int EnAttack = Util.GetBestAttack(Enemy);
                if (BotAttack <= EnAttack && Card.Attack < EnAttack)
                {
                    ClientCard card = Util.GetBestEnemyMonster();
                    if (card != null)
                    {
                        AI.SelectCard(card);
                        return true;
                    }
                    return false;
                }
                return false;
            }
            else if(Enemy.GetCountCardInZone(Enemy.MonsterZone, CardType.Monster, 0xd3)>0)
            {
                int EnAttack = Util.GetBestAttack(Enemy);
                ClientCard card2 = Util.GetBestEnemyMonster();
                foreach (ClientCard card in Bot.Hand.GetMonsters())
                {
                    if (card.HasSetcode(0xd3) && card.Attack >= EnAttack)
                    {
                        return Card.Id == card.Id;
                    }
                    else return card.HasSetcode(0xd3);
                }

            }
            return false;
        }
        //坦克机人召唤
        private bool JtankeSummon()
        {
            JtankeSpSummon = true;
            return true;
        }
        //抹杀
        private bool MoshaEffect()
        {
            ClientCard chainCard = Util.GetLastChainCard();
            if (chainCard != null && Duel.LastChainPlayer == 1)
            {
                int code = chainCard.Id;
                int alias = chainCard.Alias;
                if (alias != 0 && alias - code < 10) code = alias;
                if (CheckRemainInDeck(code) > 0)
                {
                    AI.SelectAnnounceID(code);
                    return true;
                }
                return false;
            }
            return false;
        }
        //魔陷盖放
        private bool SpellSet()
        {
            return Bot.GetSpellCountWithoutField() < 5 && (Card.HasType(CardType.Trap) || Card.HasType(CardType.QuickPlay));
        }
        //无限泡影
        public bool Impermanence_activate()
        {
            // negate before effect used
            foreach (ClientCard m in Enemy.GetMonsters())
            {
                if (m.IsMonsterShouldBeDisabledBeforeItUseEffect() && !m.IsDisabled() && Duel.LastChainPlayer != 0)
                {
                    if (Card.Location == CardLocation.SpellZone)
                    {
                        for (int i = 0; i < 5; ++i)
                        {
                            if (Bot.SpellZone[i] == Card)
                            {
                                Impermanence_list.Add(i);
                                break;
                            }
                        }
                    }
                    if (Card.Location == CardLocation.Hand)
                    {
                        AI.SelectPlace(SelectSTPlace(Card, true));
                    }
                    AI.SelectCard(m);
                    return true;
                }
            }

            ClientCard LastChainCard = Util.GetLastChainCard();

            // negate spells
            if (Card.Location == CardLocation.SpellZone)
            {
                int this_seq = -1;
                int that_seq = -1;
                for (int i = 0; i < 5; ++i)
                {
                    if (Bot.SpellZone[i] == Card) this_seq = i;
                    if (LastChainCard != null
                        && LastChainCard.Controller == 1 && LastChainCard.Location == CardLocation.SpellZone && Enemy.SpellZone[i] == LastChainCard) that_seq = i;
                    else if (Duel.Player == 0 && Util.GetProblematicEnemySpell() != null
                        && Enemy.SpellZone[i] != null && Enemy.SpellZone[i].IsFloodgate()) that_seq = i;
                }
                if ((this_seq * that_seq >= 0 && this_seq + that_seq == 4)
                    || (Util.IsChainTarget(Card))
                    || (LastChainCard != null && LastChainCard.Controller == 1 && LastChainCard.IsCode(_CardId.HarpiesFeatherDuster)))
                {
                    List<ClientCard> enemy_monsters = Enemy.GetMonsters();
                    enemy_monsters.Sort(CardContainer.CompareCardAttack);
                    enemy_monsters.Reverse();
                    foreach (ClientCard card in enemy_monsters)
                    {
                        if (card.IsFaceup() && !card.IsShouldNotBeTarget() && !card.IsShouldNotBeSpellTrapTarget())
                        {
                            AI.SelectCard(card);
                            Impermanence_list.Add(this_seq);
                            return true;
                        }
                    }
                }
            }
            if ((LastChainCard == null || LastChainCard.Controller != 1 || LastChainCard.Location != CardLocation.MonsterZone
                || LastChainCard.IsDisabled() || LastChainCard.IsShouldNotBeTarget() || LastChainCard.IsShouldNotBeSpellTrapTarget()))
                return false;
            // negate monsters
            if (is_should_not_negate() && LastChainCard.Location == CardLocation.MonsterZone) return false;
            if (Card.Location == CardLocation.SpellZone)
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (Bot.SpellZone[i] == Card)
                    {
                        Impermanence_list.Add(i);
                        break;
                    }
                }
            }
            if (Card.Location == CardLocation.Hand)
            {
                AI.SelectPlace(SelectSTPlace(Card, true));
            }
            if (LastChainCard != null) AI.SelectCard(LastChainCard);
            else
            {
                List<ClientCard> enemy_monsters = Enemy.GetMonsters();
                enemy_monsters.Sort(CardContainer.CompareCardAttack);
                enemy_monsters.Reverse();
                foreach (ClientCard card in enemy_monsters)
                {
                    if (card.IsFaceup() && !card.IsShouldNotBeTarget() && !card.IsShouldNotBeSpellTrapTarget())
                    {
                        AI.SelectCard(card);
                        return true;
                    }
                }
            }
            return true;
        }
        //卫星机人 召唤
        private bool JweixingSummon()
        {
            foreach (ClientCard card in Bot.GetMonsters())
            {
                if (card.Attack <= 1000)
                {
                    AI.SelectCard(card);
                    return true;
                }
            }
            return false;
        }
        //坏兽休眠
        private bool HanmianEffect()
        {
            if (Card.Location != CardLocation.Grave)
            {

                if (Bot.GetMonsterCount() == 0 || Bot.GetMonsterCount() < Enemy.GetMonsterCount())
                {
                    AI.SelectCard(CardId.Hjixie, CardId.Hlei, CardId.Hkonglong, CardId.Hemo, CardId.Hkunchongfeng, CardId.Hkunchongdi, CardId.Hshui);
                    AI.SelectNextCard(CardId.Hshui, CardId.Hkunchongdi, CardId.Hkunchongfeng, CardId.Hemo, CardId.Hkonglong, CardId.Hlei, CardId.Hjixie);
                    return true;
                }
                return false;
            }
            else if (Card.Location == CardLocation.Grave)
            {
                if (Enemy.GetCountCardInZone(Enemy.MonsterZone, CardType.Monster, 0xd3) > 0)
                {
                    AI.SelectCard(Hselect);
                    return true;
                }
                else
                {
                    Hselect.Reverse();
                    AI.SelectCard(Hselect);
                    return true;
                }
            }
            return false;
        }
        //灰流丽
        public bool Hand_act_eff()
        {
            return Duel.LastChainPlayer == 1;
        }
        //G
        public bool G_activate()
        {
            return Duel.Player == 1;
        }
        public int FlagEffect(int id)
        {
            return id;
        }
        //卫星机人
        private bool JweixingEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                if (Bot.HasInGraveyard(CardId.Jyixing) && !Jyixing)
                {
                    foreach (ClientCard card in Bot.Graveyard.GetMonsters())
                    {
                        if (card.Id == CardId.Jyixing)
                        {
                            if (Jweixing_Id == 0)
                            {
                                Jweixing_Id=FlagEffect(card.Id);
                            }
                            AI.SelectCard(card);
                            return true;
                        }
                    }
                    return false;
                }
                else if (Bot.HasInGraveyard(CardId.Jtanke) && JtankeSpSummon)
                {
                    foreach (ClientCard card in Bot.Graveyard.GetMonsters())
                    {
                        if (card.Id == CardId.Jtanke)
                        {
                            if (Jweixing_Id == 0)
                            {
                                Jweixing_Id = FlagEffect(card.Id);
                            }
                            AI.SelectCard(card);
                            return true;
                        }
                    }
                    return false;
                }
                else if (Bot.HasInGraveyard(CardId.Jdaodan) && (!Jdaodan || Duel.Phase < DuelPhase.BattleStep && Enemy.LifePoints <= 1000 && Duel.Player != 0))
                {
                    foreach (ClientCard card in Bot.Graveyard.GetMonsters())
                    {
                        if (card.Id == CardId.Jdaodan)
                        {
                            if (Jweixing_Id == 0)
                            {
                                Jweixing_Id = FlagEffect(card.Id);
                            }
                            AI.SelectCard(card);
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    if (Jweixing_Id == 0)
                    {
                        Jweixing_Id = FlagEffect(CardId.Jweixing);
                    }
                    AI.SelectCard(CardId.Jweixing);
                    return true;
                }
            }
            else
            {
                ClientCard card = Util.GetBestEnemySpell();
                if (card != null)
                {
                    AI.SelectCard(BadCardInHand());
                    AI.SelectNextCard(card);
                    return true;
                }
                return false;
            }
        }
        public List<ClientCard> BadCardInHand()
        {
            List<ClientCard> cards = new List<ClientCard>();
            cards = Bot.GetHands();
            foreach (ClientCard card in cards)
            {
                if (card.Id == CardId.Huiliuli || card.Id == CardId.G)
                {
                    cards.Remove(card);
                }
            }
            if (cards.Count > 0)
            {
                return cards;
            }
            return Bot.GetHands();
        }
        //导弹机人
        private bool JdaodanEffect()
        {
            Jdaodan = true;
            return true;
        }
        //电脑网挖矿
        private bool DiannaowangwakuangEffect()
        {
            AI.SelectCard(CardId.Jyixing,CardId.Diannaowangwakuang,CardId.Sheiqiushou,CardId.Hjixie, CardId.Jlong);
            AI.SelectNextCard(CardId.Sheiqiushou);
            return true;
        }
        //龙机人
        private bool JlongEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (CheckRemainInDeck(CardId.Jweixing) > 0 || CheckRemainInDeck(CardId.Jtanke) > 0 || CheckRemainInDeck(CardId.Jdaodan) > 0 || CheckRemainInDeck(CardId.Jyixing) > 0)
                {
                    AI.SelectOption(0);
                    AI.SelectCard(CardId.Jyixing);
                    return true;
                }
                return true;
            }
            return true;
        }
        //一型机人
        private bool JyixingEffect()
        {
            AI.SelectCard(CardId.Jweixing,CardId.Jtanke);
            Jyixing = true;
            return true;
        }
        //暴龙兽 
        private bool SbaolongEffect()
        {
            if (Enemy.GetMonsterCount() + Enemy.GetSpellCount() > 0)
            {
                ClientCard card = Util.GetBestEnemyCard();
                if (card != null)
                {
                    AI.SelectCard(CardId.Sheiqiushou);
                    AI.SelectNextCard(card);
                    return true;
                }
                return false;
            }
            return false;
        }
        //机械战斗暴龙兽
        private bool SjixiebaolongEffect()
        {
            return Enemy.GetMonsterCount() + Enemy.GetSpellCount() > 0;
        }
        //战斗暴龙兽
        private bool SzhandoubaolongEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Szhandoubaolong, 1))
            {
               
                        int BotAttack = Util.GetBestAttack(Bot);
                        int EnAttack = Util.GetBestAttack(Enemy);
                        ClientCard chainCard = Util.GetLastChainCard();
                        if (SzhandoubaolongDisEffect || Card.Overlays.Count <= 0)
                        {
                            if (chainCard != null && Duel.LastChainPlayer == 1 && (chainCard.HasType(CardType.Continuous) || chainCard.HasType(CardType.Monster) || chainCard.HasType(CardType.Field)) && (chainCard.Location == CardLocation.MonsterZone || chainCard.Location == CardLocation.SpellZone))
                            {
                             return true;
                            }
                             return false;
                        }
                        return BotAttack <= EnAttack || Enemy.GetMonsterCount() + Enemy.GetSpellCount() >= Bot.GetMonsterCount() + Enemy.GetSpellCount();

            }
            else if (Card.Overlays.Contains(CardId.Sjixiebaolong) && Duel.CurrentChain.Count>0)
            {
                if (Duel.LastChainPlayer != 0 && ActivateDescription != Util.GetStringId(CardId.Szhandoubaolong, 1))
                {
                    AI.SelectCard(CardId.Sheiqiushou, CardId.Syagu, CardId.Sbaolong, CardId.Szhandoubaolong);
                    SzhandoubaolongDisEffect = true;
                    return true;
                }
                return false;
            }
            else
            {
                ClientCard card = Util.GetBestEnemyMonster();
                if (Enemy.GetMonsterCount() <= 0) return false;
                if (card != null)
                {
                    AI.SelectCard(card);
                    return true;
                }
            }
            return false;
        }
    }

}
