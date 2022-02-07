using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    // NOT FINISHED YET
    [Deck("SGS", "AI_SGS", "NotFinished")]
    public class SGSExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Zhuanlunwang = 20134;
            public const int Dizangwang = 20156;
            public const int Simahui = 20029;
            public const int Guanyu = 20066;
            public const int Zhangfei = 20067;
            public const int Zhaoyun = 20068;
            public const int Huangzhong = 20069;
            public const int Machao = 20070;
            public const int Xuchu = 20105;
            public const int Caoxiu = 20122;
            public const int Huanggai = 20080;
            public const int Caoren = 20102;
            public const int Jiangwei = 20073;
            public const int Sunshangxiang = 20051;
            public const int Zhugeliang = 20002;
            public const int Pangtong = 20027;
            public const int Zhenji = 20001;
            public const int Huangyueying = 20015;
            public const int Guoshi = 20020;
            public const int Bulianshi = 20042;
            public const int Ganshi = 20054;
            public const int Mishi = 20055;
            public const int Caiwenji = 20062;
            public const int Spcaiwenji = 20063;
            public const int Fazheng = 20072;
            public const int Luxun = 20076;
            public const int Xunyou = 20100;
            public const int Chengyu = 20104;
            public const int Guojia = 20106;
            public const int Xunyu = 20107;
            public const int Jiaxu = 20109;
            public const int Caojie = 20114;
            public const int Zhangchunhua = 20119;
            public const int Guozhao = 20144;
            public const int Bianshi = 20145;
            public const int Xushu = 20161;
            public const int Wuzhongshengyou = 20004;
            public const int Tiesuolianhuan = 20025;
            public const int Dazhanhongtu = 20074;
            public const int Wushutimeng = 20087;
            public const int Caiyanshuangjue = 20096;
            public const int Tao = 20137;
            public const int Jiu = 20138;
            public const int Muliuniuma = 20024;
            public const int Jiupingzhongzheng = 20035;
            public const int Qilingong = 20048;
            public const int Guanshifu = 20049;
            public const int Sanguosha = 20091;
            public const int Yuceqianjun = 20103;
            public const int Fujiaochansheng = 20111;
            public const int Wuxiekeji = 20139;
            public const int Sunhao = 20093;
            public const int Wuli = 20056;
            public const int Binuhu = 20034;
            public const int Spsunshangxiang = 20057;
            public const int Spzhugeliang = 20136;
            public const int Fushou = 20113;
            public const int Zuoci = 20132;
            public const int Sunquan = 20041;
            public const int Liubei = 20053;
            public const int Caocao = 20058;
            public const int Caoying = 20130;
            public const int Zhugejing = 20082;
            public const int Sphuangyueying = 20016;
            public const int Sunluban = 20043;
            public const int Pangdegong = 20160;
            public const int QQ = 8824699;
            public const int Mouding = 20164;
            public const int Shibing = 20092;
            public const int Zhangren = 20129;
            public const int Diaochan = 20157;
            public const int Shunshou = 20037;
        }

        public int Link(int id)
        {
            if (id == CardId.Pangdegong) return 4;
            else if (id == CardId.Caocao || id == CardId.Sunquan || id == CardId.Liubei) return 3;
            else if (id == CardId.Caoying || id == CardId.Zhugejing) return 2;
            return 1;
        }

        public int GetTotalATK(IList<ClientCard> list)
        {
            int atk = 0;
            foreach (ClientCard c in list)
            {
                if (c == null) continue;
                atk += c.Attack;
            }
            return atk;
        }

        List<int> Impermanence_list = new List<int>();
        bool Sanguosha = false;
        bool Guanyu1 = false;
        bool Summoned = false;
        bool Dazhanhongtu = false;
        bool Liubei = false;
        bool Caoren = false;
        bool Caojie = false;
        bool Pangdegong = false;
        bool Caoren2 = false;
        bool Yuceqianjun = false;
        bool Tao = false;

        public SGSExecutor(GameAI ai, Duel duel)
           : base(ai, duel)
        {
            //司马徽
            AddExecutor(ExecutorType.Activate, CardId.Simahui, SimahuiEffect);
            //才颜双绝
            AddExecutor(ExecutorType.Activate, CardId.Caiyanshuangjue);
            //谋定天下
            AddExecutor(ExecutorType.Activate, CardId.Mouding, MoudingEffect);
            //曹仁
            AddExecutor(ExecutorType.SpSummon, CardId.Caoren, CaorenSummon);
            //转轮王
            AddExecutor(ExecutorType.SpSummon, CardId.Zhuanlunwang, ZhuanlunwangSummon);
            //转轮王
            AddExecutor(ExecutorType.Activate, CardId.Zhuanlunwang);
            //地藏王
            AddExecutor(ExecutorType.SpSummon, CardId.Dizangwang);
            //地藏王
            AddExecutor(ExecutorType.Activate, CardId.Dizangwang);
            //曹仁效果
            AddExecutor(ExecutorType.Activate, CardId.Caoren, CaorenEffect);
            //赵云
            AddExecutor(ExecutorType.SpSummon, CardId.Zhaoyun, ZhaoyunSummon);
            //三国杀
            AddExecutor(ExecutorType.Activate, CardId.Sanguosha, SanguoshaEffect);
            //大展宏图
            AddExecutor(ExecutorType.Activate, CardId.Dazhanhongtu, DazhanhongtuEffect);
            //无中生有
            AddExecutor(ExecutorType.Activate, CardId.Wuzhongshengyou);
            //顺手牵羊
            AddExecutor(ExecutorType.Activate, CardId.Shunshou);
            //黄盖
            AddExecutor(ExecutorType.Activate, CardId.Huanggai, DisEffect);
            //铁索连环
            AddExecutor(ExecutorType.Activate, CardId.Tiesuolianhuan);
            //吴蜀
            AddExecutor(ExecutorType.Activate, CardId.Wushutimeng, WushutimengEffect);
            //桃
            AddExecutor(ExecutorType.Activate, CardId.Tao, TaoEffect);
            //酒
            AddExecutor(ExecutorType.Activate, CardId.Jiu);
            //木牛流马
            AddExecutor(ExecutorType.Activate, CardId.Muliuniuma, MuliuniumaEffect);
            //九品中正
            AddExecutor(ExecutorType.Activate, CardId.Jiupingzhongzheng, JiupingzhongzhengEffect);
            //御策千军
            AddExecutor(ExecutorType.Activate, CardId.Yuceqianjun, YuceqianjunEffect);
            //永续陷阱炸卡
            AddExecutor(ExecutorType.Activate, CardId.Fujiaochansheng, FujiaochanshengEffect);
            //吴蜀
            AddExecutor(ExecutorType.Activate, CardId.Wushutimeng);
            //马超
            AddExecutor(ExecutorType.Summon, CardId.Machao, MachaoSummon);
            //张飞
            AddExecutor(ExecutorType.Summon, CardId.Zhangfei);
            //张飞效果
            AddExecutor(ExecutorType.Activate, CardId.Zhangfei, ZhangfeiEffect);
            //关羽
            AddExecutor(ExecutorType.Summon, CardId.Guanyu, XiaoguoSummon);
            //关羽效果1
            AddExecutor(ExecutorType.Activate, CardId.Guanyu, GuanyuEffect);
            //黄忠
            AddExecutor(ExecutorType.SpSummon, CardId.Huangzhong);
            //郭嘉
            AddExecutor(ExecutorType.Activate, CardId.Guojia, GuojiaEffect);
            //诸葛瑾
            AddExecutor(ExecutorType.SpSummon, CardId.Zhugejing, ZhugejingSummon);
            //曹休
            AddExecutor(ExecutorType.SpSummon, CardId.Caoxiu);
            //张春华
            AddExecutor(ExecutorType.SpSummon, CardId.Zhangchunhua);
            //曹休效果
            AddExecutor(ExecutorType.Activate, CardId.Caoxiu);
            //诸葛瑾效果
            AddExecutor(ExecutorType.Activate, CardId.Zhugejing);
            //黄忠效果
            AddExecutor(ExecutorType.Activate, CardId.Huangzhong, HuangzhongEffect);
            //姜维效果
            AddExecutor(ExecutorType.Activate, CardId.Jiangwei, JiangweiEffect);
            //孙权
            AddExecutor(ExecutorType.SpSummon, CardId.Sunquan, SunquanSummon);
            //步练师
            AddExecutor(ExecutorType.SpSummon, CardId.Bulianshi, BulianshiSummon);
            //步练师效果
            AddExecutor(ExecutorType.Activate, CardId.Bulianshi, BulianshiEffect);
            //黄月英
            AddExecutor(ExecutorType.SpSummon, CardId.Huangyueying);
            //黄月英
            AddExecutor(ExecutorType.Activate, CardId.Huangyueying);
            //Sp黄月英
            AddExecutor(ExecutorType.SpSummon, CardId.Sphuangyueying);
            //Sp黄月英
            AddExecutor(ExecutorType.Activate, CardId.Sphuangyueying, SphuangyueyingEffect);
            //孙鲁班
            AddExecutor(ExecutorType.SpSummon, CardId.Sunluban, SunlubanSummon);
            //孙鲁班效果
            AddExecutor(ExecutorType.Activate, CardId.Sunluban, SunlubanEffect);
            //孙权效果
            AddExecutor(ExecutorType.Activate, CardId.Sunquan, SunquanEffect);
            //SP孙尚香
            AddExecutor(ExecutorType.SpSummon, CardId.Spsunshangxiang, SpsunshangxiangSummon);
            //SP蔡文姬
            AddExecutor(ExecutorType.SpSummon, CardId.Spcaiwenji);
            //郭氏
            AddExecutor(ExecutorType.Activate, CardId.Guoshi, GuoshiEffect);
            //伏寿
            AddExecutor(ExecutorType.SpSummon, CardId.Fushou, FushouSummon);
            //伏寿效果
            AddExecutor(ExecutorType.Activate, CardId.Fushou, FushouEffect);
            //SP孙尚香
            AddExecutor(ExecutorType.Activate, CardId.Spsunshangxiang, SpsunshangxiangEffect);
            //孙尚香
            AddExecutor(ExecutorType.Activate, CardId.Sunshangxiang, SunshangxiangEffect);
            //诸葛亮
            AddExecutor(ExecutorType.Activate, CardId.Zhugeliang);
            //郭氏
            AddExecutor(ExecutorType.Summon, CardId.Guoshi, XiaoguoSummon);
            //庞统
            AddExecutor(ExecutorType.SpSummon, CardId.Pangtong);
            //甘氏
            AddExecutor(ExecutorType.SpSummon, CardId.Ganshi, GanshiSummon);
            //甘氏
            AddExecutor(ExecutorType.Activate, CardId.Ganshi);
            //麋氏
            AddExecutor(ExecutorType.SpSummon, CardId.Mishi);
            //麋氏
            AddExecutor(ExecutorType.Activate, CardId.Mishi, MishiEffect);
            //SP蔡文姬
            AddExecutor(ExecutorType.Activate, CardId.Spcaiwenji, SpcaiwenjiEffect);
            //蔡文姬
            AddExecutor(ExecutorType.SpSummon, CardId.Caiwenji);
            //蔡文姬
            AddExecutor(ExecutorType.Activate, CardId.Caiwenji);
            //法正
            AddExecutor(ExecutorType.Summon, CardId.Fazheng, XiaoguoSummon);
            //法正
            AddExecutor(ExecutorType.Activate, CardId.Fazheng, FazhengEffect);
            //郭嘉
            AddExecutor(ExecutorType.Summon, CardId.Guojia, XiaoguoSummon);
            //陆逊
            AddExecutor(ExecutorType.Summon, CardId.Luxun, XiaoguoSummon);
            //陆逊
            AddExecutor(ExecutorType.Activate, CardId.Luxun, LuxunEffect);
            //荀攸
            AddExecutor(ExecutorType.Activate, CardId.Xunyou, XunyouEffect);
            //黄月英
            AddExecutor(ExecutorType.Summon, CardId.Huangyueying, ExSummon);
            //糜夫人
            AddExecutor(ExecutorType.Summon, CardId.Mishi, ExSummon);
            //孙尚香
            AddExecutor(ExecutorType.Summon, CardId.Sunshangxiang, ExSummon);
            //程昱
            AddExecutor(ExecutorType.Summon, CardId.Chengyu, XiaoguoSummon);
            //程昱
            AddExecutor(ExecutorType.Activate, CardId.Chengyu, ChengyuEffect);
            //荀彧
            AddExecutor(ExecutorType.Activate, CardId.Xunyu, XunyuEffect);
            //贾诩
            AddExecutor(ExecutorType.Summon, CardId.Jiaxu, XiaoguoSummon);
            //贾诩
            AddExecutor(ExecutorType.Activate, CardId.Jiaxu, JiaxuEffect);
            //张春华
            AddExecutor(ExecutorType.Activate, CardId.Zhangchunhua);
            //卞夫人
            AddExecutor(ExecutorType.SpSummon, CardId.Bianshi, BianshiSummon);
            //卞夫人
            AddExecutor(ExecutorType.Activate, CardId.Bianshi);
            //郭照
            AddExecutor(ExecutorType.SpSummon, CardId.Guozhao);
            //郭照
            AddExecutor(ExecutorType.Activate, CardId.Guozhao, GuozhaoEffect);
            //庞统
            AddExecutor(ExecutorType.Activate, CardId.Pangtong, PangtongEffect);
            //甄姬
            AddExecutor(ExecutorType.Activate, CardId.Zhenji);
            //徐庶效果
            AddExecutor(ExecutorType.Activate, CardId.Xushu, XushuEffect);
            //曹节效果
            AddExecutor(ExecutorType.Activate, CardId.Caojie, CaojieEffect);
            //无懈可击
            AddExecutor(ExecutorType.Activate, CardId.Wuxiekeji, SpzhugeliangEffect);
            //Sp诸葛亮
            AddExecutor(ExecutorType.SpSummon, CardId.Spzhugeliang, SpzhugeliangSummon);
            //曹婴
            AddExecutor(ExecutorType.SpSummon, CardId.Caoying, CaoyingSummon);
            AddExecutor(ExecutorType.SpellSet, SpellSet);
            //曹婴效果
            AddExecutor(ExecutorType.Activate, CardId.Caoying, CaoyingEffect);
            //庞德公
            AddExecutor(ExecutorType.SpSummon, CardId.Pangdegong, PangdegongSummon);
            //庞德公效果
            AddExecutor(ExecutorType.Activate, CardId.Pangdegong, PangdegongEffect);
            //Sp诸葛亮效果
            AddExecutor(ExecutorType.Activate, CardId.Spzhugeliang, SpzhugeliangEffect);
            //姜维
            AddExecutor(ExecutorType.Summon, CardId.Jiangwei);
            //黄盖
            AddExecutor(ExecutorType.Summon, CardId.Huanggai, XiaoguoSummon);
            //许褚
            AddExecutor(ExecutorType.Summon, CardId.Xuchu, XiaoguoSummon);
            //曹休
            AddExecutor(ExecutorType.Summon, CardId.Caoxiu);
            //曹节
            AddExecutor(ExecutorType.Summon, CardId.Caojie);
            //许褚效果
            AddExecutor(ExecutorType.Activate, CardId.Xuchu);
            //转轮王
            AddExecutor(ExecutorType.SpSummon, CardId.Zhuanlunwang);
            //转轮王
            AddExecutor(ExecutorType.Activate, CardId.Zhuanlunwang);
            //地藏王
            AddExecutor(ExecutorType.SpSummon, CardId.Dizangwang);
            //地藏王
            AddExecutor(ExecutorType.Activate, CardId.Dizangwang);

            //吴皇后
            AddExecutor(ExecutorType.SpSummon, CardId.Wuli);
            //吴皇后
            AddExecutor(ExecutorType.Activate, CardId.Wuli);
            //倭女王
            AddExecutor(ExecutorType.SpSummon, CardId.Binuhu);
            //倭女王
            AddExecutor(ExecutorType.Activate, CardId.Binuhu);
            //倭女王
            AddExecutor(ExecutorType.SpSummon, CardId.Zuoci, ZuociSummon);
            //左慈
            AddExecutor(ExecutorType.Activate, CardId.Zuoci, ZuociEffect);
            //刘备
            AddExecutor(ExecutorType.SpSummon, CardId.Liubei, LiubeiSummon);
            //刘备
            AddExecutor(ExecutorType.Activate, CardId.Liubei, LiubeiEffect);
            //曹操
            AddExecutor(ExecutorType.SpSummon, CardId.Caocao, CaocaoSummon);
            //曹操
            AddExecutor(ExecutorType.Activate, CardId.Caocao, CaocaoEffect);
            //孙尚香
            AddExecutor(ExecutorType.Activate, CardId.Sunshangxiang);
            //斧头
            AddExecutor(ExecutorType.Activate, CardId.Guanshifu, ZhuangbeiEffect);
            //弓箭效果
            AddExecutor(ExecutorType.Activate, CardId.Qilingong, QilingongEffect);
            //孙皓
            AddExecutor(ExecutorType.Activate, CardId.Sunhao);
            //张任
            AddExecutor(ExecutorType.SpSummon, CardId.Zhangren, ZhangrenSummon);
            //张任
            AddExecutor(ExecutorType.Activate, CardId.Zhangren, ZhangrenEffect);
            //貂蝉
            AddExecutor(ExecutorType.SpSummon, CardId.Diaochan);
            //貂蝉
            AddExecutor(ExecutorType.Activate, CardId.Diaochan);

            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);

        }
        //计数专用
        public override void OnNewTurn()
        {
            // reset
            Sanguosha = false;
            Guanyu1 = false;
            Summoned = false;
            Dazhanhongtu = false;
            Liubei = false;
            Caoren = false;
            Caojie = false;
            Pangdegong = false;
            Caoren2 = false;
            Yuceqianjun = false;
            Tao = false;
        }
        //放置
        public bool SpellSet()
        {
            if (Bot.HasInMonstersZone(CardId.Caoying)) return true;
            else
            {
                return true;
            }
        }
        //荀攸
        public bool XunyouEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (!Bot.HasInHand(CardId.Xunyu))
                {
                    AI.SelectCard(CardId.Mishi, CardId.Zhuanlunwang, CardId.Ganshi, CardId.Bulianshi, CardId.Bianshi, CardId.Muliuniuma, CardId.Caiyanshuangjue);
                    return true;
                }
                else if(Bot.HasInHand(CardId.Xunyu) && Bot.GetHandCount() <= 4)
                {
                    AI.SelectCard(CardId.Xunyu, CardId.Mishi, CardId.Zhuanlunwang, CardId.Ganshi, CardId.Bulianshi, CardId.Bianshi, CardId.Muliuniuma, CardId.Caiyanshuangjue);
                    return true;

                }
            }
            return false;
        }
        //SP黄月英
        private bool SphuangyueyingEffect()
        {
            AI.SelectCard(CardId.Mishi, CardId.Zhuanlunwang, CardId.Ganshi, CardId.Bulianshi, CardId.Bianshi, CardId.Muliuniuma, CardId.Caiyanshuangjue);
            AI.SelectNextCard(CardId.Xunyu, CardId.Chengyu, CardId.Jiaxu, CardId.Mishi, CardId.Guojia, CardId.Wuxiekeji, CardId.Shunshou, CardId.Fazheng);
            return true;
        }
        
        //孙尚香
        private bool SunshangxiangEffect()
        {
            if (Card.Location == CardLocation.MonsterZone) return false;
            if (Card.Location == CardLocation.Hand)
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }
        //曹操
        private bool CaocaoEffect()
        {
            if (Bot.GetHandCount() < 3)
            {
                AI.SelectCard(CardId.Xunyu, CardId.Xuchu, CardId.Zhangchunhua);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            else if (Bot.GetHandCount() >= 3)
            {
                AI.SelectCard(CardId.Xuchu, CardId.Zhangchunhua);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }
        //调整召唤
        private bool ExSummon()
        {
            if (Bot.HasInExtra(CardId.Fushou))
            {
                Summoned = true;
                return true;
            }
            else if (!Bot.HasInExtra(CardId.Fushou) && (Bot.HasInHandOrHasInMonstersZone(CardId.Spcaiwenji) || Bot.HasInHandOrHasInMonstersZone(CardId.Zhangchunhua) || Bot.HasInHandOrHasInMonstersZone(CardId.Guozhao)))
            {
                Summoned = true;
                return true;
            }
            return false;

        }
        //召唤
        private bool XiaoguoSummon()
        {
            {
                Summoned = true;
                return true;
            }
        }
        //左慈
        private bool ZuociSummon()
        {
            foreach (ClientCard card in Bot.MonsterZone)
            if (Bot.HasInMonstersZoneOrInGraveyard(CardId.Pangdegong) && card != null && card.Level == 3 && card.HasSetcode(0x667) && !card.IsCode(CardId.Guozhao))
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                AI.SelectMaterials(card);
                return true;
            }
            return false;
        }
        //左慈
        private bool ZuociEffect()
        {
            if (Card.IsDisabled()) return false;
            if (!Bot.HasInMonstersZone(CardId.Pangdegong))
            {
                AI.SelectCard(CardId.Pangdegong, CardId.Dizangwang, CardId.Sunluban, CardId.Sunquan);
                return true;
            }
            else if (Bot.HasInMonstersZone(CardId.Pangdegong))
            {
                AI.SelectCard(CardId.Spsunshangxiang, CardId.Sunquan, CardId.Dizangwang, CardId.Sunluban, CardId.Sunquan);
                return true;
            }
            return false;
        }

        //御策千军
        private bool YuceqianjunEffect()
        {
            {
                AI.SelectCard(CardId.Jiaxu, CardId.Chengyu, CardId.Guojia);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                Yuceqianjun = true;
                return true;
            }
        }
        //程昱
        private bool ChengyuEffect()
        {
            if (Card.Location == CardLocation.Hand && !Yuceqianjun && Bot.HasInSpellZone(CardId.Yuceqianjun)) return false;
            else  if (Card.Location == CardLocation.Hand && !Bot.HasInSpellZone(CardId.Yuceqianjun))
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            else if (Card.Location == CardLocation.MonsterZone) return true;
            return false;
        }
        //谋定天下
        private bool MoudingEffect()
        {
            if(!Bot.HasInBanished(CardId.Zhuanlunwang))
            {
                AI.SelectCard(CardId.Zhuanlunwang, CardId.Dizangwang);
                return true;
            }
            if (Bot.HasInBanished(CardId.Zhuanlunwang))
            {
                AI.SelectCard(CardId.Dizangwang, CardId.Zhuanlunwang);
                return true;
            }
            return false;
        }
        //弓箭
        private bool QilingongEffect()
        {
            ClientCard target3 = Util.GetBestEnemySpell();
            if (ActivateDescription == Util.GetStringId(CardId.Qilingong, 0))
            {
                AI.SelectCard(target3);
                return true;
            }
            else return true;
        }
        //转轮王
        private bool ZhuanlunwangSummon()
        {
            if (Bot.GetMonsterCount()<Enemy.GetMonsterCount()) return true;
            return false;
        }
        //郭皇后
        private bool GuoshiEffect()
        {
            if(!Dazhanhongtu)
            {
                AI.SelectCard(CardId.Dazhanhongtu,
                    CardId.Sanguosha
                    );
                return true;
            }
            else
            {
                AI.SelectCard(CardId.Sanguosha);
                return true;
            }
        }
        //无效不发动效果
        private bool DisEffect()
        {
            if (Card.IsDisabled()) return false;
            return true;
        }
        //庞统效果
        private bool PangtongEffect()
        {
            if (Card.IsDisabled()) return false;
            if (Card.Location == CardLocation.Grave && Bot.GetMonsterCount() < 5)
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            else if (Card.Location == CardLocation.MonsterZone)
            {
                return true;
            }
            return false;
        }
        //吴蜀
        private bool WushutimengEffect()
        {
            if (Bot.HasInHand(CardId.Caoren) && !Caoren2) return false;
            int option;
            if (Bot.GetMonsterCount() == 0)
            {
                {
                    option = 0;
                    AI.SelectCard(CardId.Huanggai,
                    CardId.Bulianshi);
                    AI.SelectPosition(CardPosition.FaceUpDefence);
                }

            }
            else if (Bot.GetMonsterCount() != 0)
            {
                {
                    option = 1;
                }
            }
            else
            {
                {
                    option = 0;
                    AI.SelectCard(CardId.Huanggai,
                    CardId.Bulianshi);
                    AI.SelectPosition(CardPosition.FaceUpDefence);
                }
            }
            if (ActivateDescription != Util.GetStringId(CardId.Pangdegong, option))
                return false;
            return true;
        }
        //九品中正
        private bool JiupingzhongzhengEffect()
        {      
            {
                AI.SelectCard(CardId.Chengyu, CardId.Jiaxu);
                return true;
            }
        }
        //装备
        private bool ZhuangbeiEffect()
        {
            ClientCard target = Util.GetBestEnemyCard();
            ClientCard target2 = Util.GetBestBotMonster();
            if (!Bot.HasInMonstersZone(CardId.Spsunshangxiang) && target == null) return false;
            if (target != null)
            {
                AI.SelectCard(target2);
                return true;
            }
            return false;
        }
        //马超
        private bool MachaoSummon()
        {
            {
                Summoned = true;
                return true;
            }
        }
        //法正
        private bool FazhengEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            else
            {
                AI.SelectCard(CardId.Sanguosha, CardId.Wuzhongshengyou);
                return true;
            }
        }
        //贾诩
        private bool JiaxuEffect()
        {
            {
                AI.SelectCard(CardId.Guojia,
                    CardId.Chengyu);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
        }
        //曹仁
        private bool CaorenSummon()
        {
            int AIMonster = Bot.GetMonsterCount();
            if (AIMonster == 0)
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                Caoren2 = true;
                return true;
            }
            return false;
        }
        //荀彧
        private bool XunyuEffect()
        {
            if (Card.Location != CardLocation.MonsterZone) return true;
             ClientCard target = Util.GetBestEnemyCard();
            if (target != null && Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(target);
                return true;
            }
            else if (Card.Location == CardLocation.Hand)
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
                return false;
        }
        //桃效果
        private bool TaoEffect()
        {
            if (Bot.HasInMonstersZone(CardId.Spsunshangxiang) || Bot.HasInMonstersZone(CardId.Ganshi) || Bot.LifePoints <= 4000 || Tao)
            {
                Tao = true;
                return true;
            }
            return false;
        }
        //陆逊
        private bool LuxunEffect()
        {
            {
                AI.SelectCard(CardId.Sunshangxiang,
                    CardId.Bulianshi);
                    return true;
            }
        }
        //步练师
        private bool BulianshiEffect()
        {
            if (Bot.HasInHand(CardId.Guojia) && Bot.GetMonsterCount() < 5)
            {
                AI.SelectCard(CardId.Guojia);
                return true;
            }
            else
            {
                AI.SelectCard(CardId.Ganshi,
                    CardId.Bianshi,
                    CardId.Zhuanlunwang,
                    CardId.Dizangwang,
                    CardId.Caiyanshuangjue,
                    CardId.Mishi);
                return true;
            }
        }
        //SP蔡文姬效果
        private bool SpcaiwenjiEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.Fushou,
                              CardId.Simahui);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }

           //司马徽
        private bool SimahuiEffect()
        {
            if (Card.Location==CardLocation.Hand && !Summoned)
            {
                if (!Bot.HasInHand(CardId.Guanyu))
                {
                    AI.SelectCard(CardId.Guanyu,
                    CardId.Jiangwei
                                   );
                    return true;
                }
                if (Bot.HasInHand(CardId.Guanyu))
                {
                    AI.SelectCard(CardId.Machao,
                                  CardId.Zhangfei
                                  );
                    return true;
                }
            }
            else if (Card.Location == CardLocation.Hand && Summoned)
            {
                AI.SelectCard(CardId.Jiangwei,
                    CardId.Spcaiwenji,
                CardId.Guozhao,
                CardId.Zhangchunhua,
                 CardId.Chengyu
                               );
                return true;
            }
            else if (Bot.HasInMonstersZone(CardId.Machao))
            {
                AI.SelectCard(CardId.Guanyu,
                CardId.Jiangwei
                               );
                return true;
            }
            return false;
        }
        //三国杀
        private bool SanguoshaEffect()
        {
            if (!Sanguosha)
            {
                        if (!Bot.HasInHand(CardId.Guanyu) && !Summoned)
                        {
                            AI.SelectYesNo(true);
                            AI.SelectCard(CardId.Simahui,
                            CardId.Guanyu,
                            CardId.Spcaiwenji
                                           );
                            Sanguosha = true;
                            return true;
                        }
                        if (!Bot.HasInHand(CardId.Guanyu) && Summoned)
                        {
                             AI.SelectYesNo(true);
                              AI.SelectCard(CardId.Simahui,
                               CardId.Spcaiwenji,
                                CardId.Guozhao
                                   );
                             Sanguosha = true;
                             return true;
                        }

                foreach (ClientCard card in Bot.GetGraveyardSpells())
                        foreach (ClientCard card2 in Bot.GetGraveyardTraps())
                        if (Bot.HasInHand(CardId.Guanyu) && card == null && card2 == null)
                        {
                            AI.SelectYesNo(true);
                            AI.SelectCard(CardId.Zhaoyun,
                                 CardId.Spcaiwenji
                                           );
                            Sanguosha = true;
                            return true;
                        }
                        foreach (ClientCard card in Bot.GetGraveyardSpells())
                        foreach (ClientCard card2 in Bot.GetGraveyardTraps())
                        if (Bot.HasInHand(CardId.Guanyu) && (card != null || card2 != null))
                        {
                            AI.SelectYesNo(true);
                            AI.SelectCard(CardId.Machao,
                            CardId.Zhangfei,
                            CardId.Spcaiwenji
                                           );
                            Sanguosha = true;
                            return true;
                        }
            }
            else if (Sanguosha && (Bot.HasInGraveyard(CardId.Zhenji) || Bot.HasInBanished(CardId.Zhenji)))
            {
                AI.SelectYesNo(true);
                AI.SelectCard(CardId.Spcaiwenji,
                    CardId.Chengyu,
                    CardId.Caoren,
                CardId.Guanyu
                               );
                Sanguosha = true;
                return true;
            }
            else if (Sanguosha && !Bot.HasInGraveyard(CardId.Zhenji) && !Bot.HasInBanished(CardId.Zhenji ))
            {
                AI.SelectYesNo(true);
                AI.SelectCard(CardId.Guozhao,
                    CardId.Spcaiwenji,
                    CardId.Chengyu,
                    CardId.Caoren,
                CardId.Guanyu
                               );
                Sanguosha = true;
                return true;
            }
            else if (Duel.Phase != DuelPhase.Main1)
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }
        //大展宏图
        private bool DazhanhongtuEffect()
        {
            if (Bot.HasInHand(CardId.Sanguosha) || Bot.HasInSpellZone(CardId.Sanguosha))
            {
                AI.SelectCard(CardId.Sanguosha,
                    CardId.Wuzhongshengyou,
                    CardId.Wuxiekeji,
                    CardId.Yuceqianjun
                    );
                Dazhanhongtu = true;
                return true;
            }
            if (!Bot.HasInHand(CardId.Sanguosha) || !Bot.HasInSpellZone(CardId.Sanguosha))
            {
                AI.SelectCard(CardId.Sanguosha);
                Dazhanhongtu = true;
                return true;
            }
            return false;
            
        }
        //关羽
        private bool GuanyuEffect()
        {
            ClientCard target = Util.GetBestEnemyCard();
            if (!Guanyu1)
            {
                AI.SelectCard(CardId.Simahui,
                CardId.Huangzhong,
                CardId.Jiangwei,
                CardId.Zhaoyun
                               );
                Guanyu1 = true;
                return true;
            }
            else if (Guanyu1 && target != null && Enemy.LifePoints <= 1950)
                return true;
            return false;
        }
        //SP孙尚香
        private bool SpsunshangxiangEffect()
        {
                    int[] matids = new[]{
                    CardId.Fushou,
                    CardId.Zhenji,
                    CardId.Simahui,
                    CardId.Zhugejing,
                     };
            if (Card.IsDisabled()) return false;
            if (Card.Location == CardLocation.MonsterZone)
            {
                foreach (ClientCard card in Bot.GetSpells())
                {
                    if (card.HasType(CardType.Equip) && card.IsFaceup())
                    {
                        AI.SelectCard(card);
                        return true;
                    }
                    else if (Bot.HasInGraveyard(matids))
                    {
                        AI.SelectCard(
                          CardId.Sunshangxiang,
                           CardId.Spcaiwenji
                           );
                        AI.SelectNextCard(matids);
                        return true;
                    }
                    return false;
                }
            }
            else if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.Sunshangxiang);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }
        //诸葛瑾
        public bool ZhugejingSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Sunquan)) return false;
            if (!Bot.HasInMonstersZoneOrInGraveyard(CardId.Huangzhong) && !Bot.HasInMonstersZoneOrInGraveyard(CardId.Jiangwei) && Bot.GetMonsterCount()<=2) return false;
                List<ClientCard> mats = new List<ClientCard>(Bot.GetMonstersInMainZone());
                mats.Sort(CardContainer.CompareCardAttack);
                mats.Reverse();

                int link = 0;
                bool doubleused = false;
                IList<ClientCard> selected = new List<ClientCard>();
                if (Bot.HasInMonstersZone(CardId.Zhuanlunwang) && Bot.GetMonsterCount() > Enemy.GetMonsterCount()) return false;
                foreach (ClientCard card in mats)
                {
                    selected.Add(card);
                    if (card.IsFacedown() || card.IsCode(CardId.Spzhugeliang, CardId.Fushou, CardId.Guozhao, CardId.Pangdegong, CardId.Zhuanlunwang)) continue;
                    if (!doubleused && card.LinkCount == 1)
                    {
                        doubleused = true;
                        link += 1;
                    }
                    else
                        link++;
                    if (link >= 2)
                        break;
                }

                foreach (ClientCard card in mats)
                    if (link >= 2)
                    {
                        AI.SelectMaterials(selected);
                        return true;
                    }
                return false;
            }
            //黄忠效果
            private bool HuangzhongEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                if (!Bot.HasInHand(CardId.Jiangwei))
                {
                    AI.SelectCard(CardId.Jiangwei,
                        CardId.Huangyueying,
                        CardId.Mishi
                        );
                    return true;
                }
                else if (Bot.HasInHand(CardId.Jiangwei))
                {
                    AI.SelectCard(CardId.Zhaoyun,
                     CardId.Fazheng,
                     CardId.Huangyueying,
                     CardId.Mishi
                     );
                    return true;
                }
            }
            return false;

        }
        //姜维效果
        private bool JiangweiEffect()
        {
            ClientCard target = Util.GetBestEnemyMonster(true);
            if (Card.Location == CardLocation.Hand)
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            else if (target != null && Card.Location == CardLocation.MonsterZone && Duel.Player == 1 && Duel.Phase == DuelPhase.End)
            {
                AI.SelectCard(target);
                return true;
            }
            else if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.Zhugeliang,
                    CardId.Spzhugeliang
                    );
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;

        }
        //伏寿召唤
        private bool FushouSummon()
        {
            foreach (ClientCard card in Bot.MonsterZone)
            if (card != null && card.HasType(CardType.Tuner) && card.HasRace(CardRace.SpellCaster) && card.Level==3 && card.HasSetcode(0x667))
            {
                AI.SelectMaterials(card);
                AI.SelectYesNo(true);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }
        //张任召唤
        private bool ZhangrenSummon()
        {
            foreach (ClientCard card in Bot.MonsterZone)
                if (card != null && card.Level == 4 && card.HasSetcode(0x667))
                {
                    AI.SelectMaterials(card);
                    AI.SelectYesNo(true);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                    return true;
                }
            return false;
        }
        //庞德公召唤
        private bool PangdegongSummon()
        {
            List<ClientCard> mats = new List<ClientCard>(Bot.GetMonstersInMainZone());
            mats.Sort(CardContainer.CompareCardAttack);
            mats.Reverse();

            int link = 0;
            bool doubleused = false;
            IList<ClientCard> selected = new List<ClientCard>();
            foreach (ClientCard card in mats)
            {
                if (card.IsFacedown() || card.IsCode(CardId.Spzhugeliang, CardId.Fushou, CardId.Guozhao)) continue;
                selected.Add(card);
                if (!doubleused && card.LinkCount == 2)
                {
                    doubleused = true;
                    link += 2;
                }
                else
                    link++;
                if (link >= 4)
                    break;
            }

            foreach (ClientCard card in mats)
            if (link >= 4)
            {      
                AI.SelectMaterials(selected);
                return true;
            }
            return false;
        }
        //孙权
        public bool SunquanSummon()
        { 
            if (Bot.HasInMonstersZone(CardId.Zhugejing) && Bot.HasInMonstersZone(CardId.Zhugejing + 1))
            {
                AI.SelectCard(CardId.Zhugejing, CardId.Zhugejing + 1);
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
                if (t_check.IsCode(CardId.Zhugejing))
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
                if (Link(e_check.Id) <= 2 && !e_check.IsCode(CardId.Liubei, CardId.Caocao, CardId.Sunquan))
                {
                    targets.Add(e_check);
                    break;
                }
            }
            if (targets.Count <= 1) return false;
            AI.SelectMaterials(targets);
            return true;
        }
        //孙权效果
        private bool SunquanEffect()
        {
            {
                AI.SelectCard(CardId.Sunshangxiang,
                    CardId.Huanggai,
                    CardId.Luxun,
                    CardId.Bulianshi,
                    CardId.Jiangwei,
                    CardId.Zhuanlunwang,
                    CardId.Dizangwang,
                    CardId.Muliuniuma,
                    CardId.Bianshi,
                    CardId.Ganshi,
                    CardId.Caiyanshuangjue,
                    CardId.Luxun
                   );
                AI.SelectNextCard(CardId.Jiangwei,
                    CardId.Zhuanlunwang,
                    CardId.Dizangwang,
                    CardId.Muliuniuma,
                    CardId.Bianshi,
                    CardId.Ganshi,
                    CardId.Caiyanshuangjue,
                    CardId.Luxun);
                AI.SelectThirdCard(CardId.Jiangwei,
                    CardId.Zhuanlunwang,
                    CardId.Dizangwang,
                    CardId.Muliuniuma,
                    CardId.Bianshi,
                    CardId.Ganshi,
                    CardId.Caiyanshuangjue,
                    CardId.Luxun);
                return true;
            }

        }
        //刘备效果
        private bool LiubeiEffect()
        {
            if (Liubei) return false;
            if (!Bot.HasInExtra(CardId.Spzhugeliang))
            {
                AI.SelectCard(CardId.Huangyueying,
                    CardId.Mishi,
                    CardId.Guanyu,
                    CardId.Zhangfei
                    );
                Liubei = true;
                return true;
            }
            else if (Bot.HasInExtra(CardId.Spzhugeliang))
            {
                AI.SelectCard(CardId.Zhugeliang);
                Liubei = true;
                return true;
            }
            return false;
        }
        //张飞效果
        private bool ZhangfeiEffect()
        {
            {
                AI.SelectCard(CardId.Guanyu
                    );
                return true;
            }

        }
        //刘备召唤
        public bool LiubeiSummon()
        {
            List<ClientCard> mats = new List<ClientCard>(Bot.GetMonstersInMainZone());
            mats.Sort(CardContainer.CompareCardAttack);
            mats.Reverse();

            int link = 0;
            bool doubleused = false;
            IList<ClientCard> selected = new List<ClientCard>();
            if (Bot.HasInMonstersZone(CardId.Zhuanlunwang) && Bot.GetMonsterCount() > Enemy.GetMonsterCount()) return false;
            foreach (ClientCard card in mats)
            {
                selected.Add(card);
                if (card.IsFacedown() || card.IsCode(CardId.Spzhugeliang, CardId.Fushou, CardId.Guozhao, CardId.Pangdegong, CardId.Zhuanlunwang)) continue;
                if (!doubleused && card.LinkCount == 2)
                {
                    doubleused = true;
                    link += 2;
                }
                else
                    link++;
                if (link >= 3)
                    break;
            }

            foreach (ClientCard card in mats)
                if (link >= 3)
                {
                    AI.SelectMaterials(selected);
                    return true;
                }
                    return false;
        }
        //曹操召唤
        public bool CaocaoSummon()
        {
            List<ClientCard> mats = new List<ClientCard>(Bot.GetMonstersInMainZone());
            mats.Sort(CardContainer.CompareCardAttack);
            mats.Reverse();

            int link = 0;
            bool doubleused = false;
            IList<ClientCard> selected = new List<ClientCard>();
            if (Bot.HasInMonstersZone(CardId.Zhuanlunwang) && Bot.GetMonsterCount() > Enemy.GetMonsterCount()) return false;
            foreach (ClientCard card in mats)
            {
                selected.Add(card);
                if (card.IsFacedown() || card.IsCode(CardId.Spzhugeliang, CardId.Fushou, CardId.Guozhao,CardId.Pangdegong, CardId.Zhuanlunwang)) continue;
                if (!doubleused && card.LinkCount == 2)
                {
                    doubleused = true;
                    link += 2;
                }
                else
                    link++;
                if (link >= 3)
                    break;
            }

            foreach (ClientCard card in mats)
                if (link >= 3)
                {
                    AI.SelectMaterials(selected);
                    return true;
                }
            return false;
        }
        //步练师召唤
        public bool BulianshiSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Sunquan) && (Card.Location == CardLocation.Deck || Card.Location == CardLocation.Hand))
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }
        //甘氏召唤
        public bool GanshiSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Liubei) && (Card.Location == CardLocation.Deck || Card.Location == CardLocation.Hand))
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }
        //卞氏召唤
        public bool BianshiSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Caocao) && (Card.Location == CardLocation.Deck || Card.Location == CardLocation.Hand))
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }
        //SP孙尚香
        private bool SpsunshangxiangSummon()
        {
            if (Bot.HasInExtra(CardId.Fushou) && Bot.GetMonsterCount() <= 2) return false;
            if (Bot.HasInMonstersZone(CardId.Sunshangxiang))
            {
                AI.SelectMaterials(CardId.Sunshangxiang);
                AI.SelectYesNo(true);
                return true;
            }
            return false;
        }
        //孙鲁班
        private bool SunlubanSummon()
        {
            int[] matids = new[] {
                CardId.Bulianshi,
            };
            if (Bot.MonsterZone.GetMatchingCardsCount(card => card.IsCode(matids)) >= 1)
            {
                AI.SelectMaterials(matids);
                return true;
            }
            return false;
        }
        //孙鲁班效果
        private bool SunlubanEffect()
        {
            foreach (ClientCard card in Bot.Graveyard)
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (Bot.GetMonsterCount() < 5)
                {
                    {
                        AI.SelectCard(CardId.Xushu,
                            CardId.Mishi,
                            CardId.Pangtong
                            );
                        return true;
                    }
                }
                else
                {
                    AI.SelectCard(CardId.Mishi,
                          CardId.Pangtong
                          );
                    return true;
                }
            }
            else if (Card.Location == CardLocation.Grave && card.HasAttribute(CardAttribute.Wind) && !card.IsCode(CardId.Sunluban))
            {
                AI.SelectCard(CardId.Bulianshi,
                CardId.Huanggai,
                CardId.Luxun,
                CardId.Sunquan
                    );
                return true;
            }
            return false;
        }
        //徐庶效果
        private bool XushuEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.Caojie,
                   CardId.Fazheng,
                   CardId.Jiangwei,
                  CardId.Pangtong
                    );
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            else if (Card.Location == CardLocation.Hand)
            {
                if (Bot.HasInMonstersZone(CardId.Pangdegong) && Enemy.GetMonsterCount() != 0)
                {
                    return (Duel.Player == 1);
                }
                else if (!Bot.HasInMonstersZone(CardId.Pangdegong))
                {
                    return (Duel.Player == 1);
                }
                else if (Bot.HasInMonstersZone(CardId.Pangdegong) && Enemy.GetMonsterCount() == 0) return false;
            }
            return false;

        }
        //曹节效果
        private bool CaojieEffect()
        {
            if (Bot.GetMonsterCount() >= 5)
            {
                AI.SelectCard(CardId.Wuxiekeji,
                                    CardId.Yuceqianjun,
                                    CardId.Wushutimeng
                                    );
                Caojie = true;
                return true;
            }
            else if (Dazhanhongtu && Sanguosha)
            {
                AI.SelectCard(CardId.Wuxiekeji,
                    CardId.Yuceqianjun,
                    CardId.Wushutimeng
                    );
                Caojie = true;
                return true;
            }
            else if (!Dazhanhongtu)
            {
                AI.SelectCard(CardId.Dazhanhongtu
                                  );
                Caojie = true;
                return true;
            }
            else if (Bot.GetHandCount() < Enemy.GetHandCount())
            {
                return true;
            }
            return false;
        }
        //伏寿效果
        private bool FushouEffect()
        {
            if (Duel.Player == 0)
            {
                if (Caojie) return false;
                else
                {
                    AI.SelectPosition(CardPosition.FaceUpDefence);
                    return true;
                }
            }
            else if (Duel.Player == 1)
            {
                return true;
            }
            return false;
        }
        //SP诸葛亮
        private bool SpzhugeliangSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Zhugeliang))
            {
                AI.SelectMaterials(CardId.Zhugeliang);
                AI.SelectYesNo(true);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }
        //SP诸葛亮效果
        private bool SpzhugeliangEffect()
        {
            if (Duel.CurrentChain.Count > 0)
            {
                return Duel.LastChainPlayer == 1;
            }
            else
            {
                if (Bot.Hand.Count != 0)
                {
                    AI.SelectCard(CardId.Zhuanlunwang,
                        CardId.Luxun,
                        CardId.Dizangwang
                        );
                    return true;
                }
            }
            return false;
        }
        //张任
        private bool ZhangrenEffect()
        {
            ClientCard target = Util.GetBestBotMonster();
            if (Card.IsDisabled()) return false;
            foreach (ClientCard card in Bot.GetMonstersInMainZone())
            if (target != null && target.HasPosition(CardPosition.FaceUpAttack))
            {
                AI.SelectCard(CardId.Jiangwei);
                AI.SelectNextCard(target);
                return true;
            }
            else if (card.HasPosition(CardPosition.FaceUpAttack))
            {
                AI.SelectCard(CardId.Jiangwei);
                AI.SelectNextCard(card);
                return true;
            }
            return false;

        }
        //糜夫人
        private bool MishiEffect()
        {
            ClientCard target = Util.GetBestEnemyCard();
            ClientCard target2 = Util.GetBestBotMonster();
            if (Card.IsDisabled()) return false;
            if (Card.Location==CardLocation.Grave)
            {
                if (Duel.CurrentChain.Count > 0)
                {
                    return Duel.LastChainPlayer == 1;
                }
                else if (Card.Location == CardLocation.Hand)
                {
                    if (target != null && Bot.GetMonsterCount() < 5)
                    {
                        AI.SelectCard(target);
                        AI.SelectPosition(CardPosition.FaceUpDefence);
                        return true;
                    }
                    else if (target == null && Bot.GetMonsterCount() < 5)
                    {
                        AI.SelectCard(CardId.Wuxiekeji, CardId.Fujiaochansheng);
                        AI.SelectPosition(CardPosition.FaceUpDefence);
                        return true;
                    }
                }
                else if (Card.Location == CardLocation.MonsterZone)
                {
                    if (target2 != null && target2.HasPosition(CardPosition.FaceUpAttack))
                    {
                        AI.SelectCard(target2);
                        return true;
                    }
                    else return false;
                }

            }
            return false;
        }
        //郭照效果
        private bool GuozhaoEffect()
        {
            if (Duel.CurrentChain.Count > 0)
            {
                return Duel.LastChainPlayer == 1;
            }
            else
            {
                    AI.SelectCard(CardId.Simahui,
                     CardId.Jiaxu,
                     CardId.Guojia,
                     CardId.Chengyu
                     );
                    return true;
            }
        }
        //曹婴
        private bool CaoyingSummon()
        {
            foreach (ClientCard card2 in Bot.GetMonstersInMainZone())
            if (Bot.HasInExtra(CardId.Zhugejing) && card2.HasAttribute(CardAttribute.Fire) && !Bot.HasInMonstersZone(CardId.Spsunshangxiang) && Bot.GetMonsterCount() <= 1) return false;
            if (Bot.HasInMonstersZone(CardId.Sunluban) && Bot.HasInMonstersZone(CardId.Sunluban + 1))
            {
                AI.SelectCard(CardId.Sunluban, CardId.Sunluban + 1);
                return true;
            }
            IList<ClientCard> targets = new List<ClientCard>();
            if (Bot.HasInMonstersZone(CardId.Zhuanlunwang) && Bot.GetMonsterCount() > Enemy.GetMonsterCount()) return false;
            foreach (ClientCard t_check in Bot.GetMonsters())
            {
                if (t_check.IsFacedown()) continue;
                if (t_check.IsCode(CardId.Spcaiwenji, CardId.Huangzhong, CardId.Guanyu, CardId.Zhangfei, CardId.Machao, CardId.Zhaoyun, CardId.Jiangwei, CardId.Mishi, CardId.Pangtong, CardId.Fazheng, CardId.Spsunshangxiang, CardId.Sunluban))
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
                if (Link(e_check.Id) <= 2 && !e_check.IsCode(CardId.Caoying, CardId.Zhugejing, CardId.Spzhugeliang, CardId.Fushou, CardId.Guozhao))
                {
                    targets.Add(e_check);
                    break;
                }
            }
            if (targets.Count <= 1) return false;
            AI.SelectMaterials(targets);
            return true;
        }
        //曹婴效果
        private bool CaoyingEffect()
        {
            AI.SelectCard(CardId.Bulianshi,
               CardId.Guojia
                );
            AI.SelectPosition(CardPosition.FaceUpDefence);
            foreach (ClientCard card in Bot.SpellZone)
            if (!Bot.HasInSpellZone(CardId.Jiupingzhongzheng) && Bot.HasInSpellZone(CardId.Sanguosha))
            {
                AI.SelectNextCard(CardId.Sanguosha,
                    CardId.Bulianshi,
                     CardId.Guojia
                  );
            }
            else if (!Bot.HasInSpellZone(CardId.Jiupingzhongzheng) && !Bot.HasInSpellZone(CardId.Sanguosha) && card != null)
            {
                    AI.SelectNextCard(card);
            }
            else if (Bot.HasInSpellZone(CardId.Jiupingzhongzheng))
            {
                AI.SelectNextCard(CardId.Bulianshi,
                    CardId.Guojia,
                    CardId.Sanguosha
                                  );
            }
            else
            {
                AI.SelectNextCard(CardId.Sanguosha,
                                  CardId.Bulianshi,
                                  CardId.Guojia
                                 );
            }
            return true;
        }
        //木牛流马
        private bool MuliuniumaEffect()
        {
            int option;
            if (Bot.GetHandCount() != 0 && Card.Location==CardLocation.SpellZone && Duel.Phase != DuelPhase.End)
            {
                option = 0;
                if (ActivateDescription != Util.GetStringId(CardId.Muliuniuma, option))
                return false;
                return false;
            }
            if (Bot.GetHandCount() != 0 && Card.Location == CardLocation.SpellZone && Duel.Phase != DuelPhase.End)
            {
                option = 1;
                if (ActivateDescription != Util.GetStringId(CardId.Muliuniuma, option))
                    return false;
                return true;
            }
            if (Duel.Phase == DuelPhase.End) return true;
            return false;
        }
        //永续陷阱
        private bool FujiaochanshengEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Fujiaochansheng, 1))
            {
                if (Pangdegong)
                {
                    AI.SelectYesNo(true);
                    return true;
                }
                else
                {
                    AI.SelectYesNo(false);
                    return true;
                }
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Fujiaochansheng, 2))
            {
                ClientCard target = Util.GetBestEnemyCard(true);
                if (target != null)
                {
                    AI.SelectCard(CardId.Shibing,
                       CardId.Xushu,
                       CardId.Pangdegong,
                       CardId.Pangtong,
                       CardId.Spsunshangxiang,
                       CardId.Bulianshi
                       );
                    AI.SelectNextCard(target);
                    return true;
                }
                else return false;
            }
            return false;
        }
        //庞德公效果
        private bool PangdegongEffect()
        {
            ClientCard target = Util.GetBestEnemyMonster(true);
            if (Card.Location==CardLocation.MonsterZone)
            {
                int option;
                if (Duel.Player == 0 && Enemy.GetMonsterCount() == 1 && Enemy.HasInMonstersZone(CardId.Xushu) && Bot.GetMonsterCount() < 5)
                {
                    option = 4;
                }
                else if (Enemy.GetMonsterCount() == 1 && Bot.GetMonsterCount() < 5)
                {
                    option = 4;
                }
                else if (Duel.Player == 0 && target == null && Bot.GetSpellCountWithoutField() < 4)
                {
                    option = 1;
                }
                else if (Duel.Player == 0 && target != null)
                {
                    option = 2;
                    AI.SelectCard(target);
                }
                else if (Duel.Player == 1 && target != null && Bot.LifePoints >= 4000)
                {
                    option = 2;
                    AI.SelectCard(target);
                }
                else if (Duel.Player == 1 && target != null && Bot.LifePoints <= 4000)
                {
                    option = 3;
                    Pangdegong = true;
                }
                else
                {
                    option = 3;
                    Pangdegong = true;
                }
                if (ActivateDescription != Util.GetStringId(CardId.Pangdegong, option))
                    return false;
                return true;
            }
            else if(Card.Location != CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.Xushu,
                   CardId.Spzhugeliang,
                   CardId.Simahui,
                   CardId.Pangtong
              );
                AI.SelectPosition(CardPosition.FaceUpDefence);
                AI.SelectAnnounceID(CardId.Fushou);
                return true;
            }
            return false;
        }
        //赵云
        private bool ZhaoyunSummon()
        {
            foreach (ClientCard card in Bot.Graveyard)
            {
                if (card != null && (card.HasType(CardType.Spell) || card.HasType(CardType.Trap) )) return false;
            }
            return true;
        }
        //曹仁效果
        private bool CaorenEffect()
        {
            if (Duel.CurrentChain.Count > 0)
            {
                return Duel.LastChainPlayer == 1;
            }
            else
            {
                if (!Caoren)
                {
                    AI.SelectCard(CardId.Jiupingzhongzheng,
                        CardId.Fujiaochansheng
                        );
                    Caoren = true;
                    return true;
                }
                else if (Caoren)
                    return false;
            }
            return false;
        }
        //郭嘉效果
        private bool GuojiaEffect()
        {
            foreach (ClientCard card in Bot.GetMonstersInMainZone())
                if (Duel.CurrentChain.Count > 0)
                {
                    return Duel.LastChainPlayer == 1;
                }
                else
                {
                    if (card != null && card.HasAttribute(CardAttribute.Fire) && (Bot.HasInExtra(CardId.Sunquan) || Bot.HasInExtra(CardId.Zhugejing) || Bot.HasInExtra(CardId.Liubei)))
                    {
                        AI.SelectCard(CardId.Simahui,
                            CardId.Huangzhong);
                        return true;
                    }
                    else
                    {
                        AI.SelectCard(CardId.Simahui,
                            CardId.Spcaiwenji,
                            CardId.Guozhao,
                            CardId.Chengyu,
                            CardId.Zhangchunhua
                            );
                        return true;
                    }
                }
            if (!Bot.HasInMonstersZone(CardId.Guojia)) return true;
            return false;
        }
    }
}   
