using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using System.Linq;
using System;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
namespace WindBot.Game.AI.Decks
{
    [Deck("Martyr", "AI_Martyr", "NotFinished")]
    public class MartyrExecutor : DefaultExecutor 
    {
        public class CardId
        {
            public const int Xuwudatianshi = 98710041;
            public const int Diyuzhanshen = 98710044;
            public const int Diyutianshen = 98710045;
            public const int Diyumoshen = 98710046;
            public const int Kongshuishenjiang = 98710037;
            public const int Fantianmoke = 98710047;
            public const int Heiyaqishi = 98710040;
            public const int Diyuzhudaozhe = 98710054;
            public const int Bianyimoren = 98710036;
            public const int Jinglingshe = 98710050;
            public const int Yindaojuexingzhilong = 98710055;
            public const int Kangmoshi = 98710039;
            public const int Diyuzhaohuan = 98710049;
            public const int Xijushixisuo = 98710059;
            public const int Haiwangxunchayuan = 98710060;
            public const int Diyuyoushou = 98710033;
            public const int Jishimokeda = 98710101;
            public const int Diyuzhishinanguan = 98710061;
            public const int Shihunguai = 98710062;
            public const int Diyukaizouling = 98710048;
            public const int Shuangzibaigu = 98710042;
            public const int Diyumorenshi = 98710058;
            public const int Mguilai = 98710064;
            public const int Msuming = 98710065;
            public const int Msuijichouqu = 98710075;
            public const int Mkuizeng = 98710079;
            public const int Mqijizhaohuan = 98710080;
            public const int Mmofashenghua = 98710081;
            public const int Mtianjiangdengji = 98710082;
            public const int Mwuxiantihuan = 98710085;
            public const int Mdengjiajiaohuan = 98710091;
            public const int Mjinjizhaohuan = 98710078;
            public const int Mbihu = 98710093;
            public const int Mdengjiduanlu = 98710077;
            public const int Myuzhao = 98710084;
            public const int Mxuanyan = 98710090;
            public const int Mhuihunji = 98710092;
            public const int Mhuimieyiji = 98710095;
            public const int Mnengnifengjin = 98710096;
            public const int Mjixianzhuangjia = 98710097;
            public const int Xtongcheyiji = 98710067;
            public const int Xhuizhuan = 98710069;
            public const int Xnizhuan = 98710070;
            public const int Xyouxian = 98710083;
            public const int Xciyuan = 98710088;
            public const int Xhuimiequ = 98710076;
            public const int Xshennvyouhuo = 98710087;
            public const int Xjiuyuandui = 98710089;
            public const int Xguaishou = 98710098;
            public const int Xmofa = 98710099;
            public const int Xxianjing = 98710100;

            public const int Yshuiyao = 98710038;
            public const int Ybaigu = 98710043;
        }
        int rusultNumber = Program.Rand.Next(1, 11);
        List<int> Impermanence_list = new List<int>();
        bool Mqijizhaohuan = false;
        bool Diyuyoushou = false;
        bool Diyuzhishinanguan1 = false;
        bool Diyuzhishinanguan2 = false;
        bool Diyuzhishinanguan3 = false;
        bool Msuijichouqu = false;
        bool Haiwangxunchayuan = false;
        bool Yindaojuexingzhilong = false;
        bool Mmofashenghua = false;

        bool Mtianjiangdengji = false;
        bool Mtianjiangdengji2 = false;
        bool Mtianjiangdengji3 = false;
        bool Mtianjiangdengji4 = false;
        bool Mtianjiangdengji5 = false;
        bool Jishimokeda = false;
        bool Mguilai = false;
        bool Msuming = false;

        bool Mmofashenghua2 = false;
        public MartyrExecutor(GameAI ai, Duel duel)
       : base(ai, duel)
        {
            //镜灵蛇
            AddExecutor(ExecutorType.Activate, CardId.Jinglingshe);
            //殉道者 地狱天神效果
            AddExecutor(ExecutorType.Activate, CardId.Diyutianshen, DiyutianshenEffect);
            //引导觉醒之龙
            AddExecutor(ExecutorType.Activate, CardId.Yindaojuexingzhilong, YindaojuexingzhilongEffect);
            //放置（魔法升华）
            AddExecutor(ExecutorType.SpellSet, SpellSetByShengHuaEffect);
            //殉道者 魔法升华
            AddExecutor(ExecutorType.Activate, CardId.Mmofashenghua, MmofashenghuaEffect);
            //殉道者 归来
            AddExecutor(ExecutorType.Activate, CardId.Mguilai, MguilaiEffect);
            //殉道者 预兆
            AddExecutor(ExecutorType.Activate, CardId.Myuzhao);
            //殉道者 天降等级
            AddExecutor(ExecutorType.Activate, CardId.Mtianjiangdengji, MtianjiangdengjiEffect);
            //殉道者 无限替换
            AddExecutor(ExecutorType.Activate, CardId.Mwuxiantihuan, MwuxiantihuanEffect);
            //殉道者 奇迹召唤
            AddExecutor(ExecutorType.Activate, CardId.Mqijizhaohuan, MqijizhaohuanEffect);
            //殉道者 宣言（发动）
            AddExecutor(ExecutorType.Activate, CardId.Mxuanyan, MxuanyanEffect);
            //殉道者 随机抽取
            AddExecutor(ExecutorType.Activate, CardId.Msuijichouqu, MsuijichouquEffect);
            //殉道者 等价交换
            AddExecutor(ExecutorType.Activate, CardId.Mdengjiajiaohuan);
            //殉道者 馈赠
            AddExecutor(ExecutorType.Activate, CardId.Mkuizeng,MkuizengEffect);
            //殉道者 宿命
            AddExecutor(ExecutorType.Activate, CardId.Msuming, MsumingEffect);
            //殉道者 禁忌召唤
            AddExecutor(ExecutorType.Activate, CardId.Mjinjizhaohuan);
            //殉道者 等级短路
            AddExecutor(ExecutorType.Activate, CardId.Mdengjiduanlu);
            //殉道者 庇护
            AddExecutor(ExecutorType.Activate, CardId.Mbihu, MbihuEffect);
            //殉道者 回魂技 (发动)
            AddExecutor(ExecutorType.Activate, CardId.Mhuihunji, MhuihunjiEffect);
            //殉道者 地狱天神
            AddExecutor(ExecutorType.SpSummon, CardId.Diyutianshen,DiyutianshenSummon);
            //殉道者 能力封禁
            AddExecutor(ExecutorType.Activate, CardId.Mnengnifengjin, MnengnifengjinEffect);
            //殉道者 痛彻一击
            AddExecutor(ExecutorType.Activate, CardId.Xtongcheyiji, XtongcheyijiEffect);
            //殉道者 回转
            AddExecutor(ExecutorType.Activate, CardId.Xhuizhuan, XhuizhuanEffect);
            //殉道者 逆转
            AddExecutor(ExecutorType.Activate, CardId.Xnizhuan);
            //殉道者 悠闲
            AddExecutor(ExecutorType.Activate, CardId.Xyouxian);
            //殉道者 次元
            AddExecutor(ExecutorType.Activate, CardId.Xciyuan);
            //殉道者 毁灭区
            AddExecutor(ExecutorType.Activate, CardId.Xhuimiequ, XhuimiequEffect);
            //殉道者 神女的诱惑
            AddExecutor(ExecutorType.Activate, CardId.Xshennvyouhuo);
            //殉道者 救援队
            AddExecutor(ExecutorType.Activate, CardId.Xjiuyuandui);
            //殉道者 怪兽
            AddExecutor(ExecutorType.Activate, CardId.Xguaishou, XguaishouEffect);
            //殉道者 魔法
            AddExecutor(ExecutorType.Activate, CardId.Xmofa);
            //殉道者 陷阱
            AddExecutor(ExecutorType.Activate, CardId.Xxianjing);
            //噬魂怪
            AddExecutor(ExecutorType.Activate, CardId.Shihunguai);
            //水妖衍生物
            AddExecutor(ExecutorType.Activate, CardId.Yshuiyao);
            //祭师
            AddExecutor(ExecutorType.Activate, CardId.Jishimokeda, JishimokedaEffect);
            //地狱右手
            AddExecutor(ExecutorType.Activate, CardId.Diyuyoushou, DiyuyoushouEffect);
            //双子白骨
            AddExecutor(ExecutorType.Activate, CardId.Shuangzibaigu);
            //海王巡查员
            AddExecutor(ExecutorType.Activate, CardId.Haiwangxunchayuan, HaiwangxunchayuanEffect);
            //殉道者 回魂技
            AddExecutor(ExecutorType.Activate, CardId.Mhuihunji, MhuihunjiEffect2);
            //地狱灵
            AddExecutor(ExecutorType.Activate, CardId.Diyukaizouling, DiyukaizoulingEffect);
            //殉道者 宣言(变异魔人手卡发动)
            AddExecutor(ExecutorType.Activate, CardId.Mxuanyan, MxuanyanEffect2);
            //地狱指示男
            AddExecutor(ExecutorType.Activate, CardId.Diyuzhishinanguan, DiyuzhishinanguanEffect);
            //变异魔人
            AddExecutor(ExecutorType.SpSummon, CardId.Bianyimoren, BianyimorenSummon);
            //卡组特召
            AddExecutor(ExecutorType.SpSummon, DeckSummon);
            //地狱指示男
            AddExecutor(ExecutorType.Summon, CardId.Diyuzhishinanguan, DiyuzhishinanguanSummon);
            //地狱右手通召
            AddExecutor(ExecutorType.Summon, CardId.Diyuyoushou);
            //戏剧师 西索
            AddExecutor(ExecutorType.Summon, CardId.Xijushixisuo, XijushixisuoSummon);
            //戏剧师 西索
            AddExecutor(ExecutorType.Activate, CardId.Xijushixisuo);
            //地狱魔人 效果
            AddExecutor(ExecutorType.Activate, CardId.Diyumorenshi, DiyumorenshiEffect);
            //地狱魔人
            AddExecutor(ExecutorType.Summon, CardId.Diyumorenshi);
            //地狱主导者
            AddExecutor(ExecutorType.SpSummon, CardId.Diyuzhudaozhe, DiyuzhudaozheSummon);
            //控水神将
            AddExecutor(ExecutorType.SpSummon, CardId.Kongshuishenjiang, KongshuishenjiangSummon);
            //控水神将 效果
            AddExecutor(ExecutorType.Activate, CardId.Kongshuishenjiang, KongshuishenjiangEffect);
            //地狱灵
            AddExecutor(ExecutorType.Summon, CardId.Diyukaizouling, DiyukaizoulingSummon);
            //海王巡查员
            AddExecutor(ExecutorType.Summon, CardId.Haiwangxunchayuan, HaiwangxunchayuanSummon);
            //地狱召唤 效果
            AddExecutor(ExecutorType.Activate, CardId.Diyuzhaohuan, DiyuzhaohuanEffect);
            //祭师
            AddExecutor(ExecutorType.Summon, CardId.Jishimokeda);
            //双子白骨召唤+放置
            AddExecutor(ExecutorType.MonsterSet, CardId.Shuangzibaigu);
            //地狱召唤
            AddExecutor(ExecutorType.Summon, CardId.Diyuzhaohuan, DiyuzhaohuanSummon);
            //抗魔师
            AddExecutor(ExecutorType.Summon, CardId.Kangmoshi, KangmoshiSummon);
            //镜灵蛇
            AddExecutor(ExecutorType.Summon, CardId.Jinglingshe, JinglingsheSummon);
            //噬魂怪
            AddExecutor(ExecutorType.MonsterSet, CardId.Shihunguai);
            //殉道者 地狱灵
            AddExecutor(ExecutorType.MonsterSet, CardId.Diyukaizouling);
            //放置
            AddExecutor(ExecutorType.SpellSet, SpellSetEffect);
            //放置
            AddExecutor(ExecutorType.SpellSet, SpellSetEffect2);
            //殉道者 极限装甲
            AddExecutor(ExecutorType.Activate, CardId.Mjixianzhuangjia, MjixianzhuangjiaEffect);
            //殉道者 毁灭一击
            AddExecutor(ExecutorType.Activate, CardId.Mhuimieyiji, MhuimieyijiEffect);
            //地狱指示
            AddExecutor(ExecutorType.Summon, CardId.Diyuzhishinanguan);
            //卡组发动
            AddExecutor(ExecutorType.Activate, DeckEffect);
            //殉道者 宣言效果
            AddExecutor(ExecutorType.Activate, CardId.Mxuanyan, MxuanyanEffect3);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);

        }
        List<int> Select_list = new List<int>
        {
            CardId.Mkuizeng, CardId.Myuzhao, CardId.Mwuxiantihuan, CardId.Mqijizhaohuan, CardId.Mxuanyan
        };
        List<int> Should_select_list = new List<int>
        {
           CardId.Shihunguai,CardId.Shuangzibaigu, CardId.Diyumorenshi,CardId.Diyukaizouling,CardId.Jishimokeda,CardId.Diyuzhishinanguan,
           CardId.Xijushixisuo,CardId.Haiwangxunchayuan,CardId.Diyuzhaohuan,CardId.Yindaojuexingzhilong,CardId.Heiyaqishi,CardId.Diyuzhudaozhe,
           CardId.Fantianmoke,CardId.Yshuiyao,CardId.Ybaigu
        };
        List<int> Should_select_list2 = new List<int>
        {
           CardId.Shihunguai,CardId.Shuangzibaigu, CardId.Diyumorenshi,CardId.Diyukaizouling,CardId.Diyuzhishinanguan,
           CardId.Xijushixisuo,CardId.Jishimokeda,CardId.Haiwangxunchayuan,CardId.Diyuzhaohuan,CardId.Yindaojuexingzhilong,CardId.Heiyaqishi,CardId.Diyuzhudaozhe,
           CardId.Fantianmoke,CardId.Yshuiyao,CardId.Ybaigu
        };
        //计数专用
        public override void OnNewTurn()
        { 
            Mqijizhaohuan = false;
            Diyuyoushou = false;
            Diyuzhishinanguan1 = false;
            Diyuzhishinanguan2 = false;
            Diyuzhishinanguan3 = false;
            Msuijichouqu = false;
            Haiwangxunchayuan = false;
            Yindaojuexingzhilong = false;
            Jishimokeda = false;
            Mmofashenghua2 = false;
            Mguilai = false;
            Msuming = false;
        }
        //宿命
        private bool MsumingEffect()
        {
            if (!Msuming)
            {
                Msuming = true;
                return true;
            }
            return false;
        }
        //归来
        private bool MguilaiEffect()
        {
            if (!Mguilai)
            {
                Mguilai = true;
                return true;
            }
            return false;
        }
            //卡组检查
            public int CheckRemainInDeck(int id)
        {
            switch (id)
            {
                case CardId.Xuwudatianshi:
                    return Bot.GetRemainingCount(CardId.Xuwudatianshi, 1);
                case CardId.Diyutianshen:
                    return Bot.GetRemainingCount(CardId.Diyutianshen, 1);
                case CardId.Diyumoshen:
                    return Bot.GetRemainingCount(CardId.Diyumoshen, 1);
                case CardId.Kongshuishenjiang:
                    return Bot.GetRemainingCount(CardId.Kongshuishenjiang, 1);
                case CardId.Fantianmoke:
                    return Bot.GetRemainingCount(CardId.Fantianmoke, 1);
                case CardId.Heiyaqishi:
                    return Bot.GetRemainingCount(CardId.Heiyaqishi, 1);
                case CardId.Diyuzhudaozhe:
                    return Bot.GetRemainingCount(CardId.Diyuzhudaozhe, 1);
                case CardId.Bianyimoren:
                    return Bot.GetRemainingCount(CardId.Bianyimoren, 1);
                case CardId.Jinglingshe:
                    return Bot.GetRemainingCount(CardId.Jinglingshe, 1);
                case CardId.Yindaojuexingzhilong:
                    return Bot.GetRemainingCount(CardId.Yindaojuexingzhilong, 3);
                case CardId.Kangmoshi:
                    return Bot.GetRemainingCount(CardId.Kangmoshi, 1);
                case CardId.Diyuzhaohuan:
                    return Bot.GetRemainingCount(CardId.Diyuzhaohuan, 1);
                case CardId.Xijushixisuo:
                    return Bot.GetRemainingCount(CardId.Xijushixisuo, 1);
                case CardId.Haiwangxunchayuan:
                    return Bot.GetRemainingCount(CardId.Haiwangxunchayuan, 2);
                case CardId.Diyuyoushou:
                    return Bot.GetRemainingCount(CardId.Diyuyoushou, 3);
                case CardId.Jishimokeda:
                    return Bot.GetRemainingCount(CardId.Jishimokeda, 1);
                case CardId.Diyuzhishinanguan:
                    return Bot.GetRemainingCount(CardId.Diyuzhishinanguan, 1);
                case CardId.Shihunguai:
                    return Bot.GetRemainingCount(CardId.Shihunguai, 1);
                case CardId.Diyukaizouling:
                    return Bot.GetRemainingCount(CardId.Diyukaizouling, 1);
                case CardId.Shuangzibaigu:
                    return Bot.GetRemainingCount(CardId.Shuangzibaigu, 1);
                case CardId.Diyumorenshi:
                    return Bot.GetRemainingCount(CardId.Diyumorenshi, 1);
                case CardId.Mguilai:
                    return Bot.GetRemainingCount(CardId.Mguilai, 1);
                case CardId.Msuming:
                    return Bot.GetRemainingCount(CardId.Msuming, 1);
                case CardId.Msuijichouqu:
                    return Bot.GetRemainingCount(CardId.Msuijichouqu, 1);
                case CardId.Mkuizeng:
                    return Bot.GetRemainingCount(CardId.Mkuizeng, 1);
                case CardId.Mqijizhaohuan:
                    return Bot.GetRemainingCount(CardId.Mqijizhaohuan, 3);
                case CardId.Mmofashenghua:
                    return Bot.GetRemainingCount(CardId.Mmofashenghua, 1);
                case CardId.Mtianjiangdengji:
                    return Bot.GetRemainingCount(CardId.Mtianjiangdengji, 1);
                case CardId.Mwuxiantihuan:
                    return Bot.GetRemainingCount(CardId.Mwuxiantihuan, 3);
                case CardId.Mdengjiajiaohuan:
                    return Bot.GetRemainingCount(CardId.Mdengjiajiaohuan, 1);
                case CardId.Mjinjizhaohuan:
                    return Bot.GetRemainingCount(CardId.Mjinjizhaohuan, 1);
                case CardId.Mbihu:
                    return Bot.GetRemainingCount(CardId.Mbihu, 1);
                case CardId.Mdengjiduanlu:
                    return Bot.GetRemainingCount(CardId.Mdengjiduanlu, 1);
                case CardId.Myuzhao:
                    return Bot.GetRemainingCount(CardId.Myuzhao, 1);
                case CardId.Mxuanyan:
                    return Bot.GetRemainingCount(CardId.Mxuanyan, 1);
                case CardId.Mhuihunji:
                    return Bot.GetRemainingCount(CardId.Mhuihunji, 1);
                case CardId.Mhuimieyiji:
                    return Bot.GetRemainingCount(CardId.Mhuimieyiji, 1);
                case CardId.Mnengnifengjin:
                    return Bot.GetRemainingCount(CardId.Mnengnifengjin, 1);
                case CardId.Mjixianzhuangjia:
                    return Bot.GetRemainingCount(CardId.Mjixianzhuangjia, 1);
                case CardId.Xtongcheyiji:
                    return Bot.GetRemainingCount(CardId.Xtongcheyiji, 1);
                case CardId.Xhuizhuan:
                    return Bot.GetRemainingCount(CardId.Xhuizhuan, 1);
                case CardId.Xnizhuan:
                    return Bot.GetRemainingCount(CardId.Xnizhuan, 1);
                case CardId.Xyouxian:
                    return Bot.GetRemainingCount(CardId.Xyouxian, 1);
                case CardId.Xciyuan:
                    return Bot.GetRemainingCount(CardId.Xciyuan, 1);
                case CardId.Xhuimiequ:
                    return Bot.GetRemainingCount(CardId.Xhuimiequ, 1);
                case CardId.Xshennvyouhuo:
                    return Bot.GetRemainingCount(CardId.Xshennvyouhuo, 1);
                case CardId.Xjiuyuandui:
                    return Bot.GetRemainingCount(CardId.Xjiuyuandui, 1);
                case CardId.Xguaishou:
                    return Bot.GetRemainingCount(CardId.Xguaishou, 1);
                case CardId.Xmofa:
                    return Bot.GetRemainingCount(CardId.Xmofa, 1);
                case CardId.Xxianjing:
                    return Bot.GetRemainingCount(CardId.Xxianjing, 1);
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
        //地狱天神
        private bool DiyutianshenSummon()
        {
            if (Bot.GetMonstersInMainZone().Count >= 5) return false;
            return true;
        }
        //抗魔师
        private bool KangmoshiSummon()
        {
            if (Bot.HasInMonstersZone(Should_select_list2))
            {
                AI.SelectCard(Should_select_list2);
                return true;
            }
            return false;
        }
        //镜灵蛇
        private bool JinglingsheSummon()
        {
            if (Enemy.Graveyard.Count + Bot.Graveyard.Count > 0 && Bot.HasInMonstersZone(Should_select_list2))
            {
                AI.SelectCard(Should_select_list2);
                return true;
            }
            return false;
        }
        //极限装甲
        private bool MjixianzhuangjiaEffect()
        {
            ClientCard target = Util.GetBestBotMonster(true);
            if (Bot.HasInMonstersZone(CardId.Jinglingshe) || Bot.HasInMonstersZone(CardId.Kangmoshi) || Bot.HasInMonstersZone(CardId.Diyuzhanshen) || Bot.HasInMonstersZone(CardId.Xuwudatianshi))
            {
                AI.SelectCard(CardId.Jinglingshe, CardId.Kangmoshi, CardId.Diyuzhanshen, CardId.Xuwudatianshi);
                return true;
            }
            else if (target != null)
            {
                AI.SelectCard(target);
                return true;
            }
            return false;

        }
        //封禁
        private bool MnengnifengjinEffect()
        {
            ClientCard target = Util.GetBestEnemyMonster(true, true);
            if (target != null)
            {
                AI.SelectCard(target);
                return true;
            }
            return false;
        }
        //怪兽
        private bool XguaishouEffect()
        {
            AI.SelectCard(Should_select_list2);
            return true;
        }
        //随机抽取
        private bool MsuijichouquEffect()
        {
            Msuijichouqu = true;
            return true;
        }
        //地狱召唤效果
        private bool DiyuzhaohuanEffect()
        {
            AI.SelectCard(CardId.Shihunguai);
            return true;
        }
        //地狱魔人
        private bool DiyumorenshiEffect()
        {
            IList<ClientCard> targets = new List<ClientCard>();
            foreach (ClientCard newCard in Bot.Deck)
            {
                for (int card = 0; card < Bot.Deck.Count-2; card++)
                {
                    targets.Add(newCard);
                }
            }
            AI.SelectNextCard(targets);
            return true;
        }
        //地狱召唤
        private bool DiyuzhaohuanSummon()
        {
            if (Bot.GetMonstersInMainZone().Count <= 4)
            {
                if (Card.Level < 5 || (Bot.GetMonstersInMainZone().Count <= 4 && Bot.HasInMonstersZone(Should_select_list2)))
                {
                    AI.SelectCard(Should_select_list2);
                    return true;
                }
                return false;
            }
            return false;
        }
        //殉道者 回转
        private bool XhuizhuanEffect()
        {
            IList<ClientCard> targets = new List<ClientCard>();
            foreach (ClientCard newCard in Bot.Graveyard)
            {
                for (int card = 0; card <GetCountSetCodeCardInZone(Bot.Graveyard, 0x70c1) ; card++)
                {
                    targets.Add(newCard);
                }
            }
            AI.SelectCard(targets);
            return true;
        }
        public int GetCountSetCodeCardInZone(IEnumerable<ClientCard> cards, int setcode)
        {
            return cards.Count(card => card != null && card.HasSetcode(setcode));
        }
        //地狱灵
        private bool DiyukaizoulingSummon()
        {
            if (Bot.HasInHand(CardId.Bianyimoren) || (Bot.HasInGraveyard(Should_select_list) || Bot.HasInGraveyard(CardId.Jinglingshe))) return true;
            return false;
        }
        //殉道者 宣言
        private bool MxuanyanEffect2()
        {
            if (Bot.HasInHand(CardId.Bianyimoren) && ((Diyuzhishinanguan3 && (GetCountLevelDownCardInZone(Bot.MonsterZone, 6, 0x70c1) > 0)) ||( Bot.HasInMonstersZone(Should_select_list) &&  ((Enemy.Hand.Count + Enemy.GetMonsters().Count > Bot.Hand.Count + Bot.GetMonsters().Count) ||(Enemy.Hand.Count >= 3 && Bot.Hand.Count + Enemy.Hand.Count < 3)))))
            {
                AI.SelectOption(1);
                return true;
            }
            return false;
        }
        public int GetCountLevelDownCardInZone(IEnumerable<ClientCard> cards, int level, int setcode)
        {
            return cards.Count(card => card != null && card.Level <= level && card.HasSetcode(setcode));
        }
        //殉道者 宣言 效果
        private bool MxuanyanEffect3()
        {
            if (GetCountCardInZone(Enemy.SpellZone, false) > 1)
            {
                AI.SelectOption(2);
                return true;
            }
            else
            {
                AI.SelectOption(0);
                return true;
            }
        }
        public int GetCountCardInZone(IEnumerable<ClientCard> cards, bool face)
        {
            if (face == true)
            {
                return cards.Count(card => card != null && card.IsFaceup());
            }
            else
            {
                return cards.Count(card => card != null && card.IsFacedown());
            }
        }
        //殉道者 地狱天神
        private bool DiyutianshenEffect()
        {
            if (Card.IsDisabled()) return false;
            {
                AI.SelectCard(CardId.Diyutianshen);
                return true;
            }
        }
        //毁灭一击
        private bool MhuimieyijiEffect()
        {
            if (Bot.HasInMonstersZone(Should_select_list))
            {
                AI.SelectCard(Should_select_list);
                if (Bot.HasInGraveyard(Select_list))
                {
                    AI.SelectOption(0);
                    AI.SelectNextCard(Select_list);
                    return true;
                }
                else if (Enemy.Hand.Count > 0)
                {
                    AI.SelectOption(1);
                    return true;
                }
                else
                {
                    AI.SelectOption(0);
                    return true;
                }
            }
            return false;
        }
        //控水神将 效果
        private bool KongshuishenjiangEffect()
        {
            ClientCard target = Util.GetBestEnemyMonster(true, true);
            if (target != null)
            {
                AI.SelectCard(target);
                return true;
            }
            return false;
        }
        //海王巡查员
        private bool HaiwangxunchayuanSummon()
        {
            if (Bot.HasInMonstersZone(Should_select_list) && (Bot.GetMonsters().Count < 3 || !Diyuyoushou))
            {
                AI.SelectCard(Should_select_list);
                return true;
            }
            return false;
        }
        //戏剧师 西索
        private bool XijushixisuoSummon()
        {
            if (Card.Location == CardLocation.Hand && Bot.GetMonstersInMainZone().Count<=4)
            {
                if (Card.Level < 5 && GetCountSetCodeTypeCardInZone(Bot.Hand, 0x70c1, CardType.Monster) > 1) return true;
                else if (Bot.HasInMonstersZone(CardId.Shihunguai))
                {
                    AI.SelectCard(CardId.Shihunguai);
                    return true;
                }
                return false;
            }
            return false;
        }
        public int GetCountSetCodeTypeCardInZone(IEnumerable<ClientCard> cards, int setcode, CardType type)
        {
            return cards.Count(card => card != null && card.HasSetcode(setcode) && card.HasType(type));
        }
        //控水神将
        private bool KongshuishenjiangSummon()
        {
            if (GetCountLevelDownCardInZone(Bot.MonsterZone, 6) >= 3)
            {
                AI.SelectCard(CardId.Shihunguai, CardId.Jishimokeda, CardId.Diyuzhishinanguan, CardId.Haiwangxunchayuan);
                return true;
            }
            return false;
        }
        public int GetCountLevelDownCardInZone(IEnumerable<ClientCard> cards, int level)
        {
            return cards.Count(card => card != null && card.Level <= level);
        }
        //变异魔人
        private bool BianyimorenSummon()
        {
            if ((Diyuzhishinanguan3 && (GetCountLevelDownCardInZone(Bot.MonsterZone,6, 0x70c1)>0 && (Enemy.Hand.Count + Enemy.GetMonsters().Count > Bot.Hand.Count + Bot.GetMonsters().Count)) || (Bot.HasInMonstersZone(Should_select_list)) && ((Enemy.Hand.Count+Enemy.GetMonsters().Count> Bot.Hand.Count + Bot.GetMonsters().Count) || (Enemy.Hand.Count>=3 && Bot.Hand.Count+Enemy.Hand.Count<3))))
            {
                AI.SelectCard(CardId.Shihunguai, CardId.Diyuzhishinanguan);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }
        //殉道者 馈赠
        private bool MkuizengEffect()
        {
            if (Bot.Hand.Count > 20 || (Bot.Hand.Count-1)*2>=Bot.Deck.Count) return false;
            {
                IList<ClientCard> targets = new List<ClientCard>();
                foreach (ClientCard newCard in Bot.Hand)
                {
                    for (int card = 0; card < Bot.Hand.Count; card++)
                    {
                        targets.Add(newCard);
                    }
                }
                AI.SelectCard(targets);
                return true;
            }
        }
        //升华
        private bool MmofashenghuaEffect()
        {
            if (Bot.HasInSpellZone(CardId.Mtianjiangdengji))
            {
                AI.SelectCard(CardId.Mtianjiangdengji, CardId.Mqijizhaohuan, CardId.Mkuizeng, CardId.Msuijichouqu, CardId.Mguilai);
                Mmofashenghua = true;
                Mmofashenghua2 = true;
                return true;
            }
            else if (Bot.HasInSpellZone(CardId.Mkuizeng))
            {
                AI.SelectCard(CardId.Mkuizeng, CardId.Mqijizhaohuan, CardId.Mkuizeng, CardId.Msuijichouqu, CardId.Mguilai);
                Mmofashenghua2 = true;
                return true;
            }
            else
            {
                AI.SelectCard(CardId.Mtianjiangdengji, CardId.Mqijizhaohuan, CardId.Mkuizeng, CardId.Msuijichouqu, CardId.Mguilai);
                Mmofashenghua2 = true;
                return true;
            }
        }
        //升华效果放置
        private bool SpellSetByShengHuaEffect()
        {
            if (Bot.HasInHandOrInSpellZone(CardId.Mmofashenghua) && !Mmofashenghua2)
            {
                return  !Card.HasType(CardType.Continuous) && !Card.HasType(CardType.QuickPlay) && !Card.HasType(CardType.Equip) && Card.IsSpell() && Card.HasSetcode(0x70c1) && Bot.GetSpellCountWithoutField() <= 5;
            }
            return false;
        }
        //殉道者 宣言
        private bool MxuanyanEffect()
        {
            if (Card.Location == CardLocation.Hand || (Card.Location == CardLocation.SpellZone && Card.IsFacedown())) return true;
            return false;
        }
        //痛彻一击
        private bool XtongcheyijiEffect()
        {
            if (Duel.Player == 1)
            {
                if (Bot.GetMonsterCount() >= 2 && CheckRemainInDeck(CardId.Xuwudatianshi) > 0 && Enemy.Hand.Count >= 3) return true;
                else if (Bot.Hand.Count >= 1 && !Bot.HasInHandOrHasInMonstersZone(CardId.Fantianmoke) && !Bot.HasInBanished(CardId.Fantianmoke) && Enemy.Hand.Count >= 1) return true;
                else if (Bot.HasInMonstersZone(CardId.Shihunguai) && Enemy.Hand.Count >= 1) return true;
                else if (Enemy.Hand.Count >= Bot.Hand.Count) return true;
                return false;
            }
            return false;
        }
        //魔陷放置
        private bool SpellSetEffect()
        {
            if (Bot.HasInHand(CardId.Diyuzhudaozhe) && Enemy.Hand.Count >= 3 && Bot.GetSpellCountWithoutField() < 5)
            {
                if (Card.IsCode(CardId.Mjinjizhaohuan)) return true;
                return false;
            }
            else if (Card.IsCode(CardId.Xshennvyouhuo) && Bot.GetSpellCountWithoutField() < 5) return true;
            else if (Card.IsCode(CardId.Xyouxian) && Bot.GetSpellCountWithoutField() < 5) return true;
            else if (Card.IsCode(CardId.Xjiuyuandui) && Bot.GetSpellCountWithoutField() < 5) return true;
            else if (Card.IsCode(CardId.Xhuimiequ) && Bot.GetSpellCountWithoutField() < 5) return true;
            else if (Card.IsCode(CardId.Xguaishou) && Bot.GetSpellCountWithoutField() < 5) return true;
            else if (Card.IsCode(CardId.Xmofa) && Bot.GetSpellCountWithoutField() < 5) return true;
            else if (Card.IsCode(CardId.Xxianjing) && Bot.GetSpellCountWithoutField() < 5) return true;
            else return (Card.IsTrap() && Card.HasSetcode(0x70c1)) && Bot.GetSpellCountWithoutField() <= 5;
        }
        private bool SpellSetEffect2()
        {
            return (Card.IsTrap() && Card.HasSetcode(0x70c1)) && Bot.GetSpellCountWithoutField() <= 5;
        }
        //天降等级
        private bool MtianjiangdengjiEffect()
        {
            if (Card.Location == CardLocation.SpellZone && Card.IsFacedown() && Mmofashenghua)
            {
                if (!Mtianjiangdengji)
                {
                    int option;
                    if (Mqijizhaohuan || Bot.HasInHandOrHasInMonstersZone(CardId.Diyuyoushou) || Bot.HasInHandOrHasInMonstersZone(CardId.Jishimokeda))
                    {
                        option = 1;
                    }
                    else
                    {
                        option = 0;
                    }
                    if (ActivateDescription != Util.GetStringId(CardId.Mtianjiangdengji, option))
                        return false;
                    Mtianjiangdengji = true;
                    return true;
                }
                else if (!Mtianjiangdengji2)
                {
                    int option;
                    if (Mqijizhaohuan || Bot.HasInHandOrHasInMonstersZone(CardId.Diyuyoushou) || Bot.HasInHandOrHasInMonstersZone(CardId.Jishimokeda))
                    {
                        option = 1;
                    }
                    else
                    {
                        option = 0;
                    }
                    if (ActivateDescription != Util.GetStringId(CardId.Mtianjiangdengji, option))
                        return false;
                    Mtianjiangdengji2 = true;
                    return true;
                }
                else if (!Mtianjiangdengji3)
                {
                    int option;
                    if (Mqijizhaohuan || Bot.HasInHandOrHasInMonstersZone(CardId.Diyuyoushou) || Bot.HasInHandOrHasInMonstersZone(CardId.Jishimokeda))
                    {
                        option = 1;
                    }
                    else
                    {
                        option = 0;
                    }
                    if (ActivateDescription != Util.GetStringId(CardId.Mtianjiangdengji, option))
                        return false;
                    Mtianjiangdengji3 = true;
                    return true;
                }
                else if (!Mtianjiangdengji4)
                {
                    int option;
                    if (Mqijizhaohuan || Bot.HasInHandOrHasInMonstersZone(CardId.Diyuyoushou) || Bot.HasInHandOrHasInMonstersZone(CardId.Jishimokeda))
                    {
                        option = 1;
                    }
                    else
                    {
                        option = 0;
                    }
                    if (ActivateDescription != Util.GetStringId(CardId.Mtianjiangdengji, option))
                        return false;
                    Mtianjiangdengji4 = true;
                    return true;
                }
                else if (!Mtianjiangdengji5)
                {
                    int option;
                    if (Mqijizhaohuan || Bot.HasInHandOrHasInMonstersZone(CardId.Diyuyoushou) || Bot.HasInHandOrHasInMonstersZone(CardId.Jishimokeda))
                    {
                        option = 1;
                    }
                    else
                    {
                        option = 0;
                    }
                    if (ActivateDescription != Util.GetStringId(CardId.Mtianjiangdengji, option))
                        return false;
                    Mtianjiangdengji5 = true;
                    return true;
                }
                return false;
            }
            else
            {
                int option;
                if (Mqijizhaohuan || Bot.HasInHandOrHasInMonstersZone(CardId.Diyuyoushou) || Bot.HasInHandOrHasInMonstersZone(CardId.Jishimokeda))
                {
                    option = 1;
                }
                else
                {
                    option = 0;
                }
                if (ActivateDescription != Util.GetStringId(CardId.Mtianjiangdengji, option))
                    return false;
                return true;
            }
        }
        //地狱主导者
        private bool DiyuzhudaozheSummon()
        {
            if (Enemy.Hand.Count >= 3)
            {
                if (Bot.HasInSpellZone(CardId.Mjinjizhaohuan) || Bot.HasInSpellZone(CardId.Xhuizhuan) || Bot.HasInSpellZone(CardId.Xciyuan))
                {
                    AI.SelectCard(CardId.Mjinjizhaohuan, CardId.Xhuizhuan,CardId.Xciyuan);
                    return true;
                }
                return false;
            }
            return false;
        }
        //殉道者 毁灭区
        private bool XhuimiequEffect()
        {/*
            if (Enemy.LifePoints <= 2000)
            {
                AI.SelectOption(2);
            }
            else if (Bot.LifePoints <= 4000)
            {
                AI.SelectOption(1);
            }
            else if (Bot.GetMonstersInMainZone().Count <= 4)
            {
                AI.SelectOption(0);
            }
            else
            {
                AI.SelectOption(2);
            }
            return true;
            */
            int option;
            if (Enemy.LifePoints <= 2000)
            {
                option = 2;
            }
            else if (Bot.LifePoints <= 4000)
            {
                option = 1;
            }
            else if (Bot.GetMonstersInMainZone().Count <= 4)
            {
                option = 0;
            }
            else
            {
                option = 2;
            }
            if (ActivateDescription != Util.GetStringId(CardId.Xhuimiequ, option))
                return false;
            return true;
        }
        //殉道者 庇护
        private bool MbihuEffect()
        {
            if (Bot.HasInHand(CardId.Xijushixisuo) || Bot.HasInHand(CardId.Jinglingshe)|| Bot.HasInHand(CardId.Haiwangxunchayuan) || Bot.HasInHand(CardId.Kangmoshi) || Bot.HasInHand(CardId.Diyumoshen))
            {
                if (!Bot.HasInMonstersZone(Should_select_list2)) return false;
                {
                    if (Bot.HasInMonstersZone(CardId.Haiwangxunchayuan) && !Haiwangxunchayuan) return false;
                    else if (Bot.HasInMonstersZone(CardId.Jishimokeda) && !Jishimokeda) return false;
                    else if (Bot.Graveyard.Count + Enemy.Graveyard.Count > 0 && Bot.HasInHand(CardId.Jinglingshe))
                    {
                        AI.SelectCard(Should_select_list2);
                        AI.SelectCard(CardId.Jinglingshe);
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                    }
                    else if (GetCountSetCodeTypeCardInZone(Bot.Hand, 0x70c1, CardType.Monster) > 1 && Bot.HasInHand(CardId.Xijushixisuo))
                    {
                        AI.SelectCard(Should_select_list2);
                        AI.SelectCard(CardId.Xijushixisuo);
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                    }
                    else if (GetCountSetCodeTypeCardInZone(Bot.Graveyard, 0x70c1, CardType.Monster) > 0 && Bot.HasInHand(CardId.Haiwangxunchayuan))
                    {
                        AI.SelectCard(Should_select_list2);
                        AI.SelectCard(CardId.Haiwangxunchayuan);
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                    }
                    else
                    {
                        AI.SelectCard(Should_select_list2);
                        AI.SelectCard(CardId.Diyumoshen, CardId.Kangmoshi,CardId.Diyukaizouling,CardId.Diyuzhaohuan,CardId.Diyumoshen,CardId.Diyuzhanshen);
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                    }
                    return true;
                }
            }
            return false;
        }
        //殉道者 奇迹召唤
        private bool MqijizhaohuanEffect()
        {
            if (Bot.Deck.Count <= 5) return false;
            else if (Card.Location == CardLocation.SpellZone && Card.IsFacedown() && Mqijizhaohuan)
            {
                if (Enemy.Hand.Count + Enemy.GetMonsters().Count + Enemy.Banished.Count + Enemy.Graveyard.Count + Enemy.GetSpells().Count >= Bot.Hand.Count + Bot.GetMonsters().Count + Bot.Banished.Count + Bot.Graveyard.Count + Bot.GetSpells().Count)
                {
                    if (CheckRemainInDeck(CardId.Diyutianshen) > 0)
                    {
                        if (rusultNumber == 1 || rusultNumber == 2)
                        {
                            AI.SelectCard(CardId.Diyutianshen);
                        }
                        else if (rusultNumber == 3 || rusultNumber == 4 || rusultNumber == 5 || rusultNumber == 6)
                        {
                            AI.SelectCard(CardId.Kongshuishenjiang);
                        }
                        else
                        {
                            AI.SelectCard(CardId.Diyumoshen);
                        }
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                    }
                    else if (Bot.Hand.Count + Bot.GetMonsterCount() + Bot.GetSpellCount() < Enemy.Hand.Count + Enemy.GetMonsterCount() + Enemy.GetSpellCount() && CheckRemainInDeck(CardId.Bianyimoren) > 0)
                    {
                        AI.SelectCard(CardId.Bianyimoren);
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                    }
                    else
                    {
                        AI.SelectCard(CardId.Kongshuishenjiang, CardId.Kangmoshi, CardId.Xuwudatianshi, CardId.Jinglingshe);
                        AI.SelectPosition(CardPosition.FaceUpAttack);
                    }
                    return true;
                }
                return false;
            }
            else
            {
                //&& (Bot.Hand.Count < Enemy.Hand.Count || Bot.LifePoints <= 4000 || Bot.LifePoints < Enemy.LifePoints)
                if (CheckRemainInDeck(CardId.Diyutianshen) > 0)
                {
                    // AI.SelectCard(CardId.Diyutianshen);
                    //, CardId.Kangmoshi, CardId.Diyuzhaohuan
                    if (rusultNumber == 1 || rusultNumber == 2)
                    {
                        AI.SelectCard(CardId.Diyutianshen);
                    }
                    else if (rusultNumber == 3 || rusultNumber == 4 || rusultNumber == 5 || rusultNumber == 6)
                    {
                        AI.SelectCard(CardId.Kongshuishenjiang);
                    }
                    else
                    {
                        AI.SelectCard(CardId.Diyumoshen);
                    }
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                }
                else if (Bot.Hand.Count + Bot.GetMonsterCount() + Bot.GetSpellCount() < Enemy.Hand.Count + Enemy.GetMonsterCount() + Enemy.GetSpellCount() && CheckRemainInDeck(CardId.Bianyimoren) > 0)
                {
                    AI.SelectCard(CardId.Bianyimoren);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                }
                else
                {
                    AI.SelectCard(CardId.Kongshuishenjiang, CardId.Kangmoshi, CardId.Xuwudatianshi, CardId.Jinglingshe);
                    AI.SelectPosition(CardPosition.FaceUpAttack);
                }
                Mqijizhaohuan = true;
                return true;
            }
        }
        //回魂技
        private bool MhuihunjiEffect2()
        {
            if (Bot.GetCountCardInZone(Bot.Graveyard, CardId.Shuangzibaigu) == Bot.GetGraveyardMonsters().Count) return false;
            {
                AI.SelectCard(CardId.Xuwudatianshi, CardId.Heiyaqishi, CardId.Diyuyoushou, CardId.Diyumorenshi, CardId.Shihunguai);
                return true;
            }
        }
        //发动 回魂技
        private bool MhuihunjiEffect()
        {
            if (Card.Location == CardLocation.Hand || (Card.Location == CardLocation.SpellZone && Card.IsFacedown())) return true;
            return false;
        }
        //无限替换
        private bool MwuxiantihuanEffect()
        {
            if (Bot.Deck.Count == CheckRemainInDeck(CardId.Mwuxiantihuan)) return false;
            else if (CheckRemainInDeck(CardId.Mkuizeng) > 0 && (Bot.HasInHand(CardId.Msuijichouqu) || Msuijichouqu))
            {
                AI.SelectCard(CardId.Mkuizeng);
            }
            else if (Bot.GetCountCardInZone(Bot.Hand, CardId.Diyuyoushou) > 1 && Bot.Hand.Count > 3 && CheckRemainInDeck(CardId.Mkuizeng) > 0)
            {
                AI.SelectCard(CardId.Mkuizeng);
            }
            else if (!Bot.HasInHandOrInSpellZone(CardId.Mqijizhaohuan) && !Mqijizhaohuan && CheckRemainInDeck(CardId.Mqijizhaohuan) > 0)
            {
                AI.SelectCard(CardId.Mqijizhaohuan);
            }
            else if (!Bot.HasInHandOrHasInMonstersZone(CardId.Diyuyoushou) && !Yindaojuexingzhilong && CheckRemainInDeck(CardId.Mqijizhaohuan) > 0)
            {
                AI.SelectCard(CardId.Mqijizhaohuan);
            }
            else if (!Bot.HasInHandOrInSpellZone(CardId.Myuzhao) && CheckRemainInDeck(CardId.Myuzhao) > 0)
            {
                AI.SelectCard(CardId.Myuzhao);
            }
            else if (Bot.GetMonsterCount() == 0 && CheckRemainInDeck(CardId.Yindaojuexingzhilong) > 0 && CheckRemainInDeck(CardId.Diyuyoushou) > 0)
            {
                AI.SelectCard(CardId.Yindaojuexingzhilong);
            }
            else if (Bot.Hand.Count > 2 && CheckRemainInDeck(CardId.Mkuizeng) > 0)
            {
                AI.SelectCard(CardId.Mkuizeng);
            }
            else if (GetCountTypeCardInZone(Bot.Graveyard, CardType.Spell) > 0 && GetCountTypeCardInZone(Bot.Graveyard, CardType.Trap) > 0 && GetCountTypeCardInZone(Bot.Graveyard, CardType.Monster) > 0 && CheckRemainInDeck(CardId.Mdengjiajiaohuan) > 0)
            {
                AI.SelectCard(CardId.Mdengjiajiaohuan);
            }
            else
            {
                AI.SelectCard(CardId.Mqijizhaohuan, CardId.Diyuyoushou, CardId.Mtianjiangdengji, CardId.Mdengjiduanlu);
            }
            return true;
        }
        public int GetCountTypeCardInZone(IEnumerable<ClientCard> cards, CardType type)
        {
            return cards.Count(card => card != null && card.HasType(type));
        }
        //引导觉醒之龙
        private bool YindaojuexingzhilongEffect()
        {
            AI.SelectCard(CardId.Diyuyoushou, CardId.Jishimokeda);
            Yindaojuexingzhilong = true;
            return true;
        }
        //卡组发动
        private bool DeckEffect()
        {
            if (!Diyuyoushou && (Bot.HasInSpellZone(CardId.Xmofa) || Bot.HasInSpellZone(CardId.Xxianjing)) || Bot.Hand.Count>3) return false;
            else if ((Bot.HasInSpellZone(CardId.Xmofa) || Bot.HasInSpellZone(CardId.Xxianjing)) && Bot.Hand.Count > 0) return false;
            return Card.Location == CardLocation.Deck;
        }
       //卡组特召
        private bool DeckSummon()
        {
            return Card.Location == CardLocation.Deck && Bot.GetMonstersInMainZone().Count<5;
        }
        //地狱右手
        private bool DiyuyoushouEffect()
        {
            if (Card.IsDisabled()) return false;
            else if (ActivateDescription != Util.GetStringId(CardId.Diyuyoushou, 3))
            {
                return (Duel.LastChainPlayer == -1 && Duel.LastSummonPlayer != 0) || Duel.LastChainPlayer == 1;
            }
            else
            {
                    if ((Bot.GetCountCardInZone(Bot.MonsterZone, CardId.Diyuyoushou) + Bot.GetCountCardInZone(Bot.Graveyard, CardId.Diyuyoushou)) > 1 && CheckRemainInDeck(CardId.Shihunguai) > 0)
                    {
                        AI.SelectCard(CardId.Shihunguai);
                        Diyuyoushou = true;
                        return true;
                    }
                    else if (CheckRemainInDeck(CardId.Jishimokeda) > 0)
                    {
                        AI.SelectCard(CardId.Jishimokeda);
                        Diyuyoushou = true;
                        return true;
                    }
                    else if (CheckRemainInDeck(CardId.Haiwangxunchayuan) > 0 && Bot.GetMonstersInMainZone().Count <= 4)
                    {
                        AI.SelectCard(CardId.Haiwangxunchayuan);
                        Diyuyoushou = true;
                        return true;
                    }
                    else if (CheckRemainInDeck(CardId.Diyukaizouling) > 0 && Bot.GetMonstersInMainZone().Count <= 4)
                    {
                        AI.SelectCard(CardId.Diyukaizouling);
                        Diyuyoushou = true;
                        return true;
                    }
                    else if (CheckRemainInDeck(CardId.Diyuzhishinanguan) > 0)
                    {
                        AI.SelectCard(CardId.Diyuzhishinanguan);
                        Diyuyoushou = true;
                        return true;
                    }
                    else if (CheckRemainInDeck(CardId.Kangmoshi) > 0)
                    {
                        AI.SelectCard(CardId.Kangmoshi);
                        Diyuyoushou = true;
                        return true;
                    }
                    return false;
            }
        }
        //地狱指示男官
        private bool DiyuzhishinanguanSummon()
        {
            if (Diyuyoushou) return true;
            return false;
        }
        //祭师
        private bool JishimokedaEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Jishimokeda, 1))
            {
                if (Bot.GetMonstersInMainZone().Count >= 5) return false;
                else if (Card.IsDisabled()) return false;
                else if (Bot.HasInHandOrInSpellZone(CardId.Xguaishou) && CheckRemainInDeck(CardId.Shihunguai) > 0)
                {
                    AI.SelectCard(CardId.Shihunguai);
                }
                else if (Bot.HasInGraveyard(CardId.Diyuyoushou) && (CheckRemainInDeck(CardId.Haiwangxunchayuan) > 0 || CheckRemainInDeck(CardId.Diyukaizouling) > 0))
                {
                    AI.SelectCard(CardId.Haiwangxunchayuan, CardId.Diyukaizouling);
                }
                else
                {
                    AI.SelectCard(CardId.Diyuyoushou, CardId.Shuangzibaigu, CardId.Kangmoshi);
                }
                Jishimokeda = true;
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Jishimokeda, 0)) return true;
            return false;
        }
        //海王巡查员
         private bool HaiwangxunchayuanEffect()
         {
            AI.SelectCard(CardId.Diyuyoushou);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            Haiwangxunchayuan = true;
            return true;
         }
        //地狱灵
        private bool DiyukaizoulingEffect()
        {
            AI.SelectCard(CardId.Diyuyoushou);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //地狱指示男
        private bool DiyuzhishinanguanEffect()
        {
            if (Card.IsDisabled()) return false;
            else if (!Diyuzhishinanguan1)
            {
                if (GetCountSetCodeCardInZone(Bot.MonsterZone, 0x70c1) >= 5)
                {
                    AI.SelectCard(CardId.Shihunguai, CardId.Yindaojuexingzhilong, CardId.Jishimokeda, CardId.Haiwangxunchayuan,
                 CardId.Diyukaizouling, CardId.Shuangzibaigu, CardId.Diyuzhaohuan, CardId.Xijushixisuo,
                  CardId.Diyumorenshi, CardId.Diyuzhishinanguan, CardId.Diyuyoushou
                   );
                }
                else
                {
                    AI.SelectCard(CardId.Shihunguai, CardId.Yindaojuexingzhilong, CardId.Jishimokeda, CardId.Haiwangxunchayuan,
                       CardId.Diyuyoushou, CardId.Diyukaizouling, CardId.Shuangzibaigu, CardId.Diyuzhaohuan, CardId.Xijushixisuo,
                       CardId.Diyumorenshi, CardId.Diyuzhishinanguan
                        );
                }
                Diyuzhishinanguan1 = true;
                return true;
            }
            else if (!Diyuzhishinanguan2)
            {
                if (GetCountSetCodeCardInZone(Bot.MonsterZone, 0x70c1) >= 5)
                {
                    AI.SelectCard(CardId.Shihunguai, CardId.Yindaojuexingzhilong, CardId.Jishimokeda, CardId.Haiwangxunchayuan,
                 CardId.Diyukaizouling, CardId.Shuangzibaigu, CardId.Diyuzhaohuan, CardId.Xijushixisuo,
                  CardId.Diyumorenshi, CardId.Diyuzhishinanguan, CardId.Diyuyoushou
                   );
                }
                else
                {
                    AI.SelectCard(CardId.Shihunguai, CardId.Yindaojuexingzhilong, CardId.Jishimokeda, CardId.Haiwangxunchayuan,
                       CardId.Diyuyoushou, CardId.Diyukaizouling, CardId.Shuangzibaigu, CardId.Diyuzhaohuan, CardId.Xijushixisuo,
                       CardId.Diyumorenshi, CardId.Diyuzhishinanguan
                        );
                }
                Diyuzhishinanguan2 = true;
                return true;
            }
            else if (!Diyuzhishinanguan3)
            {
                if (GetCountSetCodeCardInZone(Bot.MonsterZone, 0x70c1) >= 5)
                {
                    AI.SelectCard(CardId.Shihunguai, CardId.Yindaojuexingzhilong, CardId.Jishimokeda, CardId.Haiwangxunchayuan,
                 CardId.Diyukaizouling, CardId.Shuangzibaigu, CardId.Diyuzhaohuan, CardId.Xijushixisuo,
                  CardId.Diyumorenshi, CardId.Diyuzhishinanguan, CardId.Diyuyoushou
                   );
                }
                else
                {
                    AI.SelectCard(CardId.Shihunguai, CardId.Yindaojuexingzhilong, CardId.Jishimokeda, CardId.Haiwangxunchayuan,
                       CardId.Diyuyoushou, CardId.Diyukaizouling, CardId.Shuangzibaigu, CardId.Diyuzhaohuan, CardId.Xijushixisuo,
                       CardId.Diyumorenshi, CardId.Diyuzhishinanguan
                        );
                }
                Diyuzhishinanguan3 = true;
                return true;
            }
            else
            {
                if (GetCountSetCodeCardInZone(Bot.MonsterZone, 0x70c1) >= 5)
                {
                    AI.SelectCard(CardId.Shihunguai, CardId.Yindaojuexingzhilong, CardId.Jishimokeda, CardId.Haiwangxunchayuan,
                 CardId.Diyukaizouling, CardId.Shuangzibaigu, CardId.Diyuzhaohuan, CardId.Xijushixisuo,
                  CardId.Diyumorenshi, CardId.Diyuzhishinanguan, CardId.Diyuyoushou
                   );
                }
                else
                {
                    AI.SelectCard(CardId.Shihunguai, CardId.Yindaojuexingzhilong, CardId.Jishimokeda, CardId.Haiwangxunchayuan,
                       CardId.Diyuyoushou, CardId.Diyukaizouling, CardId.Shuangzibaigu, CardId.Diyuzhaohuan, CardId.Xijushixisuo,
                       CardId.Diyumorenshi, CardId.Diyuzhishinanguan
                        );
                }
                return true;
            }
              
        }
    }
}
