using System.Collections.Generic;
using YGOSharp.OCGWrapper.Enums;

namespace WindBot.Game.AI.Decks
{
    // NOT FINISHED YET
    [Deck("Monv", "AI_Monv", "NotFinished")]
    public class MonvExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Wunv = 8824701;
            public const int Chixielong = 82208127;
            public const int Qihuanwang = 82208118;
            public const int Bailongqishi = 82208131;
            public const int Xielingwushi = 82208120;
            public const int Jianpanlong = 82208133;
            public const int Moshujia = 82208125;
            public const int Daxian = 82208103;
            public const int SP = 8824702;
            public const int Shiyuan = 14000055;
            public const int Rongheshu = 14000056;
            public const int Zaidan = 14000059;
            public const int Huhuan = 14000066;
            public const int Fusu = 82208123;
            public const int Yongchang = 14000058;
            public const int Daozhou = 14000068;
            public const int Shengjiejie = 8824700;
            public const int Guichen = 14000071;
            public const int Zhongya = 82208132;
            public const int Heitian = 14000069;
            public const int Zitian = 14000070;
            public const int Mengyan = 79029582;
            public const int Kuishi = 14000060;
            public const int Chongsheng = 14000061;
            public const int Huanglei = 14000062;
            public const int Baolie = 14000063;
            public const int Dizhen = 14000065;
            public const int Zhicai = 82208128;
            public const int Fawang = 88581108;
            public const int Qihuanhou = 82208126;
            public const int Mohuanghou = 45819647;
            public const int Jingling = 82208124;
            public const int Diannao = 65801012;
            public const int Mosi = 79029054;
            public const int Kugu = 14001014;
            public const int Jiuhunmao = 28981598;
            public const int Moshushi = 130006009;
            public const int Shuimu = 82224065;
            public const int Mowangshu = 08824638;
            public const int Yiyan = 85602018;
            public const int Kuse = 74191942;
            public const int CS = 8824708;
            public const int Zumu = 14010167;
        }
        List<int> Impermanence_list = new List<int>();
        bool Xielingwushi = false;
        bool Xielingwushi2 = false;
        bool Qihuanhou = false;
        bool Jianpanlong = false;
        bool Daxian = false;
        bool Kuishi = false;
        bool Huanglei = false;
        bool Fawang = false;
        public MonvExecutor(GameAI ai, Duel duel)
              : base(ai, duel)
        {
            //祖母书
            AddExecutor(ExecutorType.Activate, CardId.Zumu, ZumuEffect);
            //检索融合
            AddExecutor(ExecutorType.Activate, CardId.SP);
            //测试
            AddExecutor(ExecutorType.Activate, CardId.CS);
            //圣结界
            AddExecutor(ExecutorType.Activate, CardId.Shengjiejie, ShengjiejieEffect);
            //遗言
            AddExecutor(ExecutorType.Activate, CardId.Yiyan, YiyanEffect);
            //苦涩
            AddExecutor(ExecutorType.Activate, CardId.Kuse, KuseEffect);
            //源始魔术 再诞
            AddExecutor(ExecutorType.Activate, CardId.Zaidan, ZaidanEffect);
            //源始魔术 呼唤
            AddExecutor(ExecutorType.Activate, CardId.Huhuan, HuhuanEffect);
            //源始魔术 窥视
            AddExecutor(ExecutorType.Activate, CardId.Kuishi, KuishiEffect);
            //源始魔术 地震
            AddExecutor(ExecutorType.Activate, CardId.Dizhen);
            //源始魔术 雷
            AddExecutor(ExecutorType.Activate, CardId.Huanglei, HuangleiEffect);
            //源始魔术 爆裂
            AddExecutor(ExecutorType.Activate, CardId.Baolie, BaolieEffect);
            //源始魔术 重生
            AddExecutor(ExecutorType.Activate, CardId.Chongsheng);
            //大仙
            AddExecutor(ExecutorType.Activate, CardId.Daxian, DaxianEffect);
            //龙法师 皇后
            AddExecutor(ExecutorType.Activate, CardId.Qihuanhou, QihuanhouEffect);
            //龙法师 邪灵巫师
            AddExecutor(ExecutorType.Activate, CardId.Xielingwushi, XielingwushiEffect);
            //龙法师 地龙
            AddExecutor(ExecutorType.Activate, CardId.Jianpanlong, JianpanlongEffect);
            //龙法师 龙骑士
            AddExecutor(ExecutorType.Activate, CardId.Bailongqishi, BailongqishiEffect);
            //龙法师 王
            AddExecutor(ExecutorType.Activate, CardId.Qihuanwang, QihuanwangEffect);
            //龙法师 机器龙
            AddExecutor(ExecutorType.SpSummon, CardId.Chixielong);
            //龙法师 机器龙
            AddExecutor(ExecutorType.Activate, CardId.Chixielong);
            //龙法师 死球重压
            AddExecutor(ExecutorType.Activate, CardId.Zhongya, ZhongyaEffect);
            //龙法师 精灵
            AddExecutor(ExecutorType.SpSummon, CardId.Jingling, JinglingEffect);
            //龙法师 皇后
            AddExecutor(ExecutorType.SpSummon, CardId.Qihuanhou);
            //龙法师 魔皇后
            AddExecutor(ExecutorType.SpSummon, CardId.Mohuanghou, MohuanghouSummon);
            //九魂猫
            AddExecutor(ExecutorType.SpSummon, CardId.Jiuhunmao, NineSummon1);
            //九魂猫
            AddExecutor(ExecutorType.Activate, CardId.Jiuhunmao, JiuhunmaoEffect);
            //真龙
            AddExecutor(ExecutorType.SpSummon, CardId.Fawang, NineSummon2);
            //魔王树
            AddExecutor(ExecutorType.SpSummon, CardId.Mowangshu, MowangshuSummon);
            //源始魔术 融合
            AddExecutor(ExecutorType.Activate, CardId.Rongheshu, RongheshuEffect);
            //源始魔术 咏唱
            AddExecutor(ExecutorType.Activate, CardId.Yongchang);
            //源始魔术 祷宙
            AddExecutor(ExecutorType.Activate, CardId.Daozhou, DaozhouEffect);
            //源始魔术 归尘
            AddExecutor(ExecutorType.Activate, CardId.Guichen);
            //龙法师 精灵
            AddExecutor(ExecutorType.Activate, CardId.Jingling, JinglingEffect);
            //梦魇
            AddExecutor(ExecutorType.Activate, CardId.Mengyan);
            //龙法师 魔皇后
            AddExecutor(ExecutorType.Activate, CardId.Mohuanghou, MohuanghouEffect);
            //骷髅
            AddExecutor(ExecutorType.SpSummon, CardId.Kugu, KuguSummon);
            //骷髅
            AddExecutor(ExecutorType.Activate, CardId.Kugu, KuguEffect);
            //龙法师 命运复苏
            AddExecutor(ExecutorType.Activate, CardId.Fusu, FusuEffect);
            //龙法师 铁拳
            AddExecutor(ExecutorType.Activate, CardId.Zhicai);
            //真龙
            AddExecutor(ExecutorType.Activate, CardId.Fawang, FawangEffect);
            //魔术师
            AddExecutor(ExecutorType.SpSummon, CardId.Moshushi, MoshushiSummon);
            //魔术师
            AddExecutor(ExecutorType.Activate, CardId.Moshushi);
            //水母
            AddExecutor(ExecutorType.SpSummon, CardId.Shuimu);
            //水母
            AddExecutor(ExecutorType.Activate, CardId.Moshushi, ShuimuEffect);
            //魔王树
            AddExecutor(ExecutorType.Activate, CardId.Mowangshu, MowangshuEffect);
            //女巫
            AddExecutor(ExecutorType.SpSummon, CardId.Wunv, WunvSummon);
            //女巫
            AddExecutor(ExecutorType.Activate, CardId.Wunv);
            //龙法师 魔术家
            AddExecutor(ExecutorType.Activate, CardId.Moshujia, MoshujiaEffect);
            //电脑网
            AddExecutor(ExecutorType.Activate, CardId.Diannao, DiannaoEffect);
            //龙法师 铁拳
            AddExecutor(ExecutorType.SpSummon, CardId.Zhicai);
            //干员
            AddExecutor(ExecutorType.SpSummon, CardId.Mosi);
            //干员
            AddExecutor(ExecutorType.Activate, CardId.Mosi);
            //龙法师 魔术家
            AddExecutor(ExecutorType.Summon, CardId.Moshujia);
            //龙法师 地龙
            AddExecutor(ExecutorType.Summon, CardId.Jianpanlong);
            //龙法师 巫师
            AddExecutor(ExecutorType.Summon, CardId.Xielingwushi);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);

        }
        //link
        public int Link(int id)
        {
            if (id == CardId.Kugu) return 4;
            else if (id == CardId.Mohuanghou) return 3;
            else return 1;

        }
        public override CardPosition OnSelectPosition(int cardId, IList<CardPosition> positions)
        {
            switch (cardId)
            {
                case CardId.Kuishi:
                case CardId.Huanglei:
                case CardId.Dizhen:
                case CardId.Qihuanwang:
                    return CardPosition.FaceUpAttack;
                default:
                    return base.OnSelectPosition(cardId, positions);
            }     
        }
        public override void OnNewTurn()
        {
            // reset
            Xielingwushi = false;
            Qihuanhou = false;
            Jianpanlong = false;
            Daxian = false;
            Xielingwushi2 = false;
            Kuishi = false;
            Huanglei = false;
            Fawang = false;
        }
        //祖母
        private bool ZumuEffect()
        {
            AI.SelectCard(CardId.Jianpanlong, CardId.Daxian,CardId.Diannao);
            return true;
        }
        //圣结界
        private bool ShengjiejieEffect()
        {
            if (!Bot.HasInHand(CardId.Zaidan) && (Bot.HasInHand(CardId.Jianpanlong) || Bot.HasInHand(CardId.Xielingwushi) || Bot.HasInHand(CardId.Moshujia)))
            {
                AI.SelectCard(CardId.Zaidan);
                return true;
            }
            else if (Bot.HasInHand(CardId.Zaidan) && (Bot.HasInHand(CardId.Jianpanlong) || Bot.HasInHand(CardId.Xielingwushi) || Bot.HasInHand(CardId.Moshujia)))
            {
                AI.SelectCard(CardId.Huhuan);
                return true;
            }
            else if (!Bot.HasInHand(CardId.Jianpanlong) && !Bot.HasInHand(CardId.Xielingwushi) && !Bot.HasInHand(CardId.Moshujia))
            {
                AI.SelectCard(CardId.Zumu);
                return true;
            }
            return false;
        }
        //魔王树
        private bool MowangshuSummon()
        {
            if (Bot.GetMonsterCount() >= 5 || Bot.HasInMonstersZone(CardId.Wunv)) return false;
            AI.SelectCard(CardId.Shiyuan, CardId.Zhicai, CardId.Dizhen, CardId.Huanglei, CardId.Daxian, CardId.Qihuanwang, CardId.Moshujia, CardId.Xielingwushi,
                CardId.Mohuanghou, CardId.Jingling);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //魔王树
        private bool MowangshuEffect()
        {
                    AI.SelectCard(CardId.Shiyuan, CardId.Zhicai, CardId.Dizhen, CardId.Huanglei, CardId.Daxian, CardId.Qihuanwang, CardId.Moshujia, CardId.Xielingwushi,
                    CardId.Mohuanghou, CardId.Jingling, CardId.Rongheshu, CardId.Yongchang, CardId.Guichen, CardId.Zhongya, CardId.Huhuan, CardId.Zaidan, CardId.Shiyuan);
                    return true;

        }
        //水母
        private bool ShuimuEffect()
        {
            AI.SelectCard(CardId.Moshujia);
            AI.SelectNextCard(CardId.Qihuanwang, CardId.Jianpanlong, CardId.Bailongqishi);
            return true;
        }
        //苦涩
        private bool KuseEffect()
        {
            AI.SelectCard(CardId.Jianpanlong, CardId.Jianpanlong, CardId.Xielingwushi, CardId.Xielingwushi, CardId.Xielingwushi);
            return true;
        }
        //遗言
        private bool YiyanEffect()
        {
            AI.SelectCard(CardId.Jianpanlong, CardId.Xielingwushi, CardId.Moshujia, CardId.Bailongqishi);
            AI.SelectPosition(CardPosition.FaceUpDefence); 
            return true;
        }
        //骷髅效果
        private bool KuguEffect()
        {
            AI.SelectOption(1);
            AI.SelectCard(CardId.Mengyan, CardId.Kuishi, CardId.Huanglei, CardId.Dizhen, CardId.Qihuanwang);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //骷髅
        private bool KuguSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Mohuanghou) && Bot.HasInMonstersZone(CardId.Mohuanghou + 1))
            {
                AI.SelectCard(CardId.Mohuanghou, CardId.Mohuanghou + 1);
                return true;
            }
            foreach (ClientCard extra_card in Bot.GetMonstersInExtraZone())
            {
                if (Link(extra_card.Id) >= 4) return false;
            }
            IList<ClientCard> targets = new List<ClientCard>();
            foreach (ClientCard t_check in Bot.GetMonsters())
            {
                if (t_check.IsFacedown()) continue;
                if (t_check.IsCode(CardId.Mohuanghou))
                {
                    targets.Add(t_check);
                    break;
                }
            }
            if (targets.Count == 0) return false;
            List<ClientCard> m_list = new List<ClientCard>(Bot.GetMonsters());
            m_list.Sort(CardContainer.CompareCardAttack);
            foreach (ClientCard e_check in m_list)
            {
                if (e_check.IsFacedown()) continue;
                if (Link(e_check.Id) <= 2 && !e_check.IsCode(CardId.Fawang, CardId.Mengyan, CardId.Wunv))
                {
                    targets.Add(e_check);
                    break;
                }
            }
            if (targets.Count <= 1) return false;
            AI.SelectMaterials(targets);
            return true;
        }
        //九魂猫
        private bool JiuhunmaoEffect()
        {
            if (Card.IsDisabled()) return false;
            AI.SelectCard(
                   CardId.Kuishi,
                   CardId.Huanglei,
                   CardId.Dizhen
                   );
            AI.SelectNextCard(CardId.Kuishi,
                   CardId.Huanglei,
                   CardId.Dizhen);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //魔皇后
        private bool MohuanghouSummon()
        {
            foreach (ClientCard t_check in Bot.GetMonsters())
            if (t_check.IsFacedown() || t_check.IsCode(CardId.Mengyan, CardId.Fawang, CardId.Wunv)) continue;
            AI.SelectMaterials(new List<int>() {
                CardId.Jingling,
                CardId.Moshujia,
                CardId.Xielingwushi,
                CardId.Qihuanwang,
                CardId.Qihuanhou,
                CardId.Chixielong,
                CardId.Huanglei,
                CardId.Kuishi,
                CardId.Dizhen,
                CardId.Baolie,
                CardId.Zhicai,
                CardId.Bailongqishi,
                CardId.Jianpanlong
                });
            return true;
        }
        //9星超量
        private bool NineSummon1()
        {
            foreach (ClientCard card in Bot.GetGraveyardMonsters())
            if (!card.IsCode(CardId.Mengyan, CardId.Kuishi, CardId.Huanglei, CardId.Dizhen) || !Fawang) return false;
            foreach (ClientCard t_check in Bot.GetMonsters())
                if (t_check.IsFacedown() || t_check.IsCode(CardId.Mengyan)) continue;
                AI.SelectMaterials(new List<int>() {
                CardId.Kuishi,
                CardId.Huanglei,
                CardId.Dizhen
                });
                AI.SelectPosition(CardPosition.FaceUpDefence);
             return true;
        }
        //9星超量
        private bool NineSummon2()
        {
            if (Bot.HasInMonstersZone(CardId.Mengyan)) return false;
            foreach (ClientCard t_check in Bot.GetMonsters())
                if (t_check.IsFacedown() || t_check.IsCode(CardId.Mengyan)) continue;
            AI.SelectMaterials(new List<int>() {
                CardId.Kuishi,
                CardId.Huanglei,
                CardId.Dizhen
                });
            AI.SelectPosition(CardPosition.FaceUpAttack);
            Fawang = true;
            return true;
        }
        //魔术师
        private bool MoshushiSummon()
        {
            if (!Daxian || !Bot.HasInMonstersZone(CardId.Shiyuan)) return false;
            else
            {
                AI.SelectMaterials(new List<int>() {
                CardId.Shiyuan
                });
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
        }
        //魔皇后效果
        private bool MohuanghouEffect()
        {
            if (Bot.HasInGraveyard(CardId.Huanglei) || Bot.HasInGraveyard(CardId.Kuishi) || Bot.HasInGraveyard(CardId.Qihuanwang))
            {
                AI.SelectCard(CardId.Qihuanwang, CardId.Huanglei, CardId.Kuishi);
                return true;
            }
            else return true;
        }
        //巫女
        private bool WunvSummon()
        {
            if (Bot.GetMonsterCount() == 3 && (Bot.HasInMonstersZone(CardId.Mowangshu) || Bot.HasInMonstersZone(CardId.Mengyan) || Bot.HasInMonstersZone(CardId.Fawang))) return false;
            AI.SelectCard(new List<int>(){CardId.Shiyuan,
                  CardId.Shiyuan,
                  CardId.Shiyuan,
                  CardId.Daxian,
                  CardId.Bailongqishi,
                  CardId.Moshujia,
                  CardId.Chixielong,
                  CardId.Xielingwushi,
                  CardId.Jianpanlong,
                  CardId.Jianpanlong,
                  CardId.Kuishi,
                  CardId.Kuishi,
                  CardId.Huanglei,
                  CardId.Dizhen,
                  CardId.Mohuanghou,
                  CardId.Kugu,
                  CardId.Zhicai,CardId.Mowangshu,CardId.Fawang });
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //龙法师 精灵
        private bool JinglingSummon()
        {
            AI.SelectMaterials(new List<int>() {
                CardId.Moshujia,
                CardId.Xielingwushi,
                CardId.Qihuanwang,
                CardId.Qihuanhou
                });
            return true;
        }
        //祷宙
        private bool DaozhouEffect()
        {
            if (Card.Location == CardLocation.SpellZone)
            {
                ClientCard target2 = Util.GetBestEnemyMonster();
                AI.SelectMaterials(new List<int>() {
                CardId.Daxian,
                CardId.Bailongqishi,
                CardId.Moshujia,
                CardId.Chixielong,
                CardId.Xielingwushi,
                CardId.Jianpanlong,
                CardId.Shiyuan,
                CardId.Kuishi,
                CardId.Huanglei,
                CardId.Dizhen,
                CardId.Mohuanghou
                });
                foreach (ClientCard g in Bot.GetGraveyardMonsters())
                    if (!Kuishi)
                    {
                        AI.SelectNextCard(CardId.Kuishi, CardId.Huanglei, CardId.Dizhen);
                    }
                    else if (Kuishi && Enemy.GetHandCount() >= 0)
                    {
                        AI.SelectNextCard(CardId.Huanglei, CardId.Dizhen);

                    }
                    else if (Kuishi && g != null)
                    {
                        AI.SelectNextCard(CardId.Chongsheng, CardId.Kuishi, CardId.Huanglei, CardId.Dizhen);
                    }
                    else if (target2 != null && (Kuishi || Huanglei))
                    {
                        AI.SelectNextCard(CardId.Baolie, CardId.Dizhen, CardId.Kuishi, CardId.Huanglei, CardId.Dizhen);
                    }
                    else
                    {
                        AI.SelectNextCard(CardId.Dizhen, CardId.Kuishi, CardId.Huanglei, CardId.Dizhen);
                    }
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }
        //电脑网
        private bool DiannaoEffect()
        {
            AI.SelectMaterials(new List<int>() {
                CardId.Daxian,
                CardId.Bailongqishi,
                CardId.Moshujia,
                CardId.Xielingwushi,
                CardId.Jianpanlong,
                CardId.Shiyuan,
                CardId.Kuishi,
                CardId.Huanglei,
                CardId.Dizhen
                });
            AI.SelectCard(CardId.Mengyan);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //融合术
        private bool RongheshuEffect()
        {
            if (Card.Location == CardLocation.Hand || Card.Location == CardLocation.SpellZone)
            {
                ClientCard target2 = Util.GetBestEnemyMonster();
                AI.SelectMaterials(new List<int>() {
                CardId.Daxian,
                CardId.Bailongqishi,
                CardId.Moshujia,
                CardId.Xielingwushi,
                CardId.Jianpanlong,
                CardId.Shiyuan,
                CardId.Kuishi,
                CardId.Huanglei,
                CardId.Dizhen
                });
                foreach (ClientCard g in Bot.GetGraveyardMonsters())
                    if (!Kuishi)
                    {
                        AI.SelectCard(CardId.Kuishi, CardId.Huanglei, CardId.Dizhen);
                    }
                    else if (Kuishi && Enemy.GetHandCount() >= 0)
                    {
                        AI.SelectCard(CardId.Huanglei, CardId.Dizhen);

                    }
                    else if (Kuishi && g != null)
                    {
                        AI.SelectCard(CardId.Chongsheng, CardId.Kuishi, CardId.Huanglei, CardId.Dizhen);
                    }
                    else if (target2 != null && (Kuishi || Huanglei))
                    {
                        AI.SelectCard(CardId.Baolie, CardId.Dizhen, CardId.Kuishi, CardId.Huanglei, CardId.Dizhen);
                    }
                    else
                    {
                        AI.SelectCard(CardId.Dizhen, CardId.Kuishi, CardId.Huanglei, CardId.Dizhen);
                    }
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            else if (Card.Location == CardLocation.Grave)
            {
                if (Bot.GetMonstersExtraZoneCount() > 0 && Bot.GetMonsterCount() >= 5 && !Bot.HasInExtra(CardId.Moshushi)) return false;
                else if (Bot.GetMonstersExtraZoneCount() == 0 && Bot.GetMonsterCount() >= 4 && !Bot.HasInExtra(CardId.Moshushi)) return false;
                else return true;
            }
            return false;
        }
        //源始魔术 再诞
        private bool ZaidanEffect()
        {
            if (Bot.HasInHand(CardId.Rongheshu))
            {
                AI.SelectCard(CardId.Shiyuan);
                AI.SelectNextCard(CardId.Rongheshu);
                return true;
            }
            else
           {
                AI.SelectCard(CardId.Rongheshu);
                AI.SelectNextCard(CardId.Shiyuan);
                return true;
           }
        }
        //龙法师 死球重压
        private bool ZhongyaEffect()
        {
            foreach (ClientCard card in Bot.GetMonsters())
            if (Duel.Player == 0 && Bot.HasInSpellZone(CardId.Shengjiejie) && Bot.GetMonsterCount() > 0 && card.HasAttribute(CardAttribute.Light)) return false;
            if (Daxian) return false; 
            if (Duel.Player == 0 && Jianpanlong && Xielingwushi2 && Duel.CurrentChain.Count == 0) return true;
            if (Duel.Player == 1) return true;
            return false;
        }
        //源始魔术 呼唤
        private bool HuhuanEffect()
        {
            if (!Bot.HasInExtra(CardId.Mohuanghou))
            {
                AI.SelectCard(CardId.Dizhen, CardId.Baolie, CardId.Huanglei, CardId.Chongsheng, CardId.Kuishi, CardId.Shiyuan);
                AI.SelectNextCard(CardId.Kuishi, CardId.Huanglei, CardId.Dizhen);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            else if (Bot.HasInExtra(CardId.Mohuanghou) && !Bot.HasInGraveyard(CardId.Guichen))
            {
                AI.SelectCard(CardId.Shiyuan, CardId.Dizhen, CardId.Baolie, CardId.Huanglei, CardId.Chongsheng, CardId.Kuishi);
                AI.SelectNextCard(CardId.Kuishi, CardId.Huanglei, CardId.Dizhen);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            else if (Bot.HasInExtra(CardId.Mohuanghou) && Bot.HasInGraveyard(CardId.Guichen))
            {
                AI.SelectCard(CardId.Dizhen, CardId.Baolie, CardId.Huanglei, CardId.Chongsheng, CardId.Kuishi, CardId.Shiyuan);
                AI.SelectNextCard(CardId.Kuishi, CardId.Huanglei, CardId.Dizhen);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            else if (Enemy.GetHandCount() != 0)
            {
                AI.SelectCard(CardId.Dizhen, CardId.Baolie, CardId.Huanglei, CardId.Chongsheng, CardId.Kuishi, CardId.Shiyuan);
                AI.SelectNextCard(CardId.Huanglei, CardId.Dizhen);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            else
            {
                AI.SelectCard(CardId.Dizhen, CardId.Baolie, CardId.Huanglei, CardId.Chongsheng, CardId.Kuishi, CardId.Shiyuan);
                AI.SelectNextCard(CardId.Dizhen, CardId.Chongsheng, CardId.Heitian, CardId.Baolie);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
        }
        //龙法师 邪灵巫师
        private bool XielingwushiEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (!Bot.HasInHand(CardId.Jianpanlong))
                {
                    AI.SelectCard(CardId.Jianpanlong);
                    Xielingwushi2 = true;
                    return true;
                }
                else if (Bot.HasInHand(CardId.Jianpanlong) )
                {
                    AI.SelectCard(CardId.Chixielong, CardId.Fusu, CardId.Moshujia);
                    Xielingwushi2 = true;
                    return true;
                }
            }
            else if (Card.Location == CardLocation.Grave)
            {
                if (!Xielingwushi && Duel.Player == 0)
                {
                    Xielingwushi = true;
                    return true;

                }
                else if (!Xielingwushi && Duel.Player == 1)
                {
                    if ((Duel.CurrentChain.Count > 0) && Duel.LastChainPlayer != 0)
                    {
                        Xielingwushi = true;
                        return true;
                    }
                    return false;
                }
                else if (Bot.Deck.Count <= 1)
                {
                    Xielingwushi = true;
                    return true;
                }
                return false;
            }
            return false;
        }
        //龙法师 地龙
        private bool JianpanlongEffect()
        {
            ClientCard target = Util.GetBestEnemyCard();
            if (Card.Location == CardLocation.Hand)
            {
                Jianpanlong = true;
                return true;
            }
            else if (Card.Location == CardLocation.MonsterZone)
            {
                if (Bot.HasInHandOrInGraveyard(CardId.Chixielong) || Bot.HasInHandOrInGraveyard(CardId.Qihuanwang))
               { 
                    AI.SelectCard(CardId.Bailongqishi);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Qihuanwang, CardId.Moshujia, CardId.Xielingwushi);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
            }
            else if (Card.Location == CardLocation.Grave) ;
            {
                AI.SelectCard(CardId.Qihuanwang);
                if (target != null)
                {
                    AI.SelectNextCard(target);
                }
                else return false;
            }
            return false;
        }
        //龙法师 龙骑士
        private bool BailongqishiEffect()
        {
            if (Card.Location == CardLocation.Grave || Card.Location == CardLocation.Hand)
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            else if (Card.Location == CardLocation.MonsterZone) return true;
            return false;
        }
        //龙法师 王
        private bool QihuanwangEffect()
        {
            int i = 0;
            List<ClientCard> bot_monsters = Bot.GetGraveyardMonsters();
            ClientCard target2 = Util.GetBestEnemyCard();
            foreach (ClientCard target in bot_monsters)
                do
                {
                    if (target2 == null)
                    {
                        if ((Bot.HasInGraveyard(CardId.Rongheshu) || Bot.HasInHand(CardId.Rongheshu)) && !Bot.HasInHand(CardId.Huhuan))
                        {
                            AI.SelectCard(CardId.Shiyuan, CardId.Daxian, CardId.Huhuan, CardId.Yongchang, CardId.Diannao, CardId.Wunv);
                            i++;
                        }
                        else
                        {
                            AI.SelectCard(CardId.Huhuan, CardId.Daxian, CardId.Yongchang, CardId.Diannao,CardId.Wunv);
                            i++;
                        }
                    }
                    else if(target2 != null)
                    {
                        AI.SelectCard(target2);
                        i++;
                    }
                }
                while (i < target.Attribute);
            return true;
              
        }
        //大仙
        private bool DaxianEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Duel.Player == 0 && !Daxian)
                {
                    AI.SelectOption(1);
                    Daxian = true;
                    return true;
                }
                else if (Duel.Player == 1 && !Daxian && Bot.HasInSpellZone(CardId.Shengjiejie) && Bot.GetMonsterCount() > 0)
                {
                    AI.SelectOption(1);
                    Daxian = true;
                    return true;
                }
                else if (Duel.Player == 1 && !Daxian && Bot.HasInSpellZone(CardId.Shengjiejie) && Bot.GetMonsterCount() == 0 && (Bot.HasInHand(CardId.Jianpanlong) || Bot.HasInHand(CardId.Xielingwushi) || Bot.HasInHand(CardId.Bailongqishi))) return false;
                else if (Duel.Player == 1 && !Daxian && (!Bot.HasInSpellZone(CardId.Shengjiejie) || Bot.GetMonsterCount() == 0) && (!Bot.HasInHand(CardId.Jianpanlong) && !Bot.HasInHand(CardId.Xielingwushi) && !Bot.HasInHand(CardId.Bailongqishi)))
                {
                    AI.SelectOption(0);
                    Daxian = true;
                    return true;
                }
            }
            else if (Card.Location == CardLocation.Deck)
                return false;
            return false;
        }
        //真龙 法王
        private bool FawangEffect()
        {
            if (Duel.Player == 1)
            {
                AI.SelectCard(CardId.Kuishi, CardId.Huanglei);
                AI.SelectAttribute(CardAttribute.Light);
                return true;
            }
            return false;
        }
        //魔术家
        private bool MoshujiaEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0) return false;
                if (!Bot.HasInHand(CardId.Jianpanlong) && !Jianpanlong)
                {
                    AI.SelectCard(CardId.Bailongqishi, CardId.Chixielong, CardId.Qihuanwang, CardId.Xielingwushi);
                    AI.SelectNextCard(CardId.Jianpanlong);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                else if (Jianpanlong)
                {
                    AI.SelectCard(CardId.Bailongqishi, CardId.Chixielong, CardId.Qihuanwang, CardId.Xielingwushi);
                    AI.SelectNextCard(CardId.Bailongqishi, CardId.Chixielong, CardId.Qihuanwang);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
                else if (Bot.HasInHand(CardId.Jianpanlong) && !Jianpanlong) return false;
            }
            else if (Card.Location == CardLocation.Grave)
            {
                return Bot.Deck.Count >= 10;
            }
            return false;
        }
        //龙法师 复苏
        private bool FusuEffect()
        {
            foreach (ClientCard card in Bot.Graveyard)
            {
                if (card != null && card.HasSetcode(0x6299))
                {
                 
                        AI.SelectCard(CardId.Qihuanwang, CardId.Xielingwushi, CardId.Fusu, CardId.Jingling, CardId.Moshujia, CardId.Qihuanhou, CardId.Chixielong, CardId.Zhicai, CardId.Bailongqishi, CardId.Zhongya, CardId.Jianpanlong);
                }
                return true;
            }
            return false;
        }
        //龙法师 精灵
        private bool JinglingEffect()
        {
            if (!Jianpanlong && Bot.HasInHand(CardId.Jianpanlong))
            {
                AI.SelectCard(CardId.Jianpanlong);
                return true;
            }
            else
            {
                AI.SelectCard(CardId.Xielingwushi, CardId.Bailongqishi);
                return true;
            }
        }
        //龙法师 皇后
        private bool QihuanhouEffect()
        {
            {
                AI.SelectCard(CardId.Fusu, CardId.Zhongya);
                return true;
            }
        }
        //源始 窥视
        private bool KuishiEffect()
        {

                    ClientCard target = Util.GetBestBotMonster();
                    if (target != null)
                    {
                        AI.SelectCard(target);
                        Kuishi = true;
                        return true;
                    }
                    return false;
             
        }
        //源始 荒雷
        private bool HuangleiEffect()
        {
            ClientCard target = Util.GetBestBotMonster();
            if (target != null)
            {
                AI.SelectCard(target);
                Kuishi = true;
                return true;
            }
            return false;
        }
        //源始 爆裂
        private bool BaolieEffect()
        {
            ClientCard target = Util.GetBestBotMonster();
            if (target != null)
            {
                AI.SelectCard(target);
                Kuishi = true;
                return true;
            }
            return false;
        }
        //龙法师 魔术家
        private bool MoshujiaSummon()
        {
            if (Bot.HasInExtra(CardId.Qihuanhou) || Bot.HasInExtra(CardId.Jingling))
            {
                return true;
            }
            return false;
        }

    }

}
