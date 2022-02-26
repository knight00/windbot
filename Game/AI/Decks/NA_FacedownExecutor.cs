using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
namespace WindBot.Game.AI.Decks
{
    [Deck("Facedown", "AI_Facedown", "NotFinished")]
    public class FacedownExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Sdizangwang = 20156;
            public const int Syingzheng = 20135;
            public const int Jiqiaoshe = 71197066;
            public const int As = 60150817;
            public const int Dtianqiong = 83000100;
            public const int Xzhencetianma = 30000997;
            public const int Xshizuoyuanxing = 30000993;
            public const int Sbianchengwang = 20153;
            public const int Sdushiwang = 20155;
            public const int Ybusiniao = 72100318;
            public const int Yrenzhe = 72100316;
            public const int Schujiangwang = 20149;
            public const int Swuguanwang = 20151;
            public const int Yxiangcaobuding = 72100322;
            public const int Ybeijidemitu = 72100317;
            public const int Yjlei = 72100319;
            public const int Yjdian = 72100320;
            public const int Yyinghuacha = 72100321;
            public const int Smengpo = 20147;
            public const int Xjihe = 30000995;
            public const int Baoshishou = 63845230;
            public const int Yonghengyueding = 33710913;
            public const int Tanhu = 35261759;
            public const int Manhu = 49238328;
            public const int Dzhongta = 83000090;
            public const int Dtianqiu = 83000091;
            public const int Dshuilifang = 83000092;
            public const int Dshen = 83000093;
            public const int Dqingxie = 83000094;
            public const int Dzhongmo = 83000095;
            public const int Dcichang = 83000097;
            public const int Dshanguangyouhun = 83000099;
            //额外
            public const int kelaibagong = 8824591;
            public const int Tiansha = 14060006;
            public const int Wanshichuangshang = 14010088;
            public const int Shuangxing = 9950324;
            public const int Tianqidijun = 82224036;
            public const int Jianjilingyu = 49130429;
            public const int Jianjiciyuanzhan = 148731141;
            public const int Lanmei = 9950647;
            public const int Shikonghuixuanji = 30001007;
            public const int Meilansha = 9950652;
            public const int Yulongshe = 130001055;
            public const int Dian = 72100328;
            public const int Lei = 72100327;
            public const int Modao = 63791000;
            public const int Dluanliu = 83000098;
            public const int Dqinshi = 83000096;
            public const int Shikongzhongcaijiguan = 30001012;
            public const int Simayi = 20158;
            public const int Yiciyuan = 8824680;
            public const int Taojinniang = 9950655;
        }
        List<int> Impermanence_list = new List<int>();
        //云
        bool Ybusiniao = false;
        bool Ybusiniao2 = false;
        bool Yrenzhe = false;
        bool Yrenzhe2 = false;
        bool Yxiangcaobuding = false;
        bool Yxiangcaobuding2 = false;
        bool Ybeijidemitu = false;
        bool Ybeijidemitu2 = false;
        bool Yjlei = false;
        bool Yjlei2 = false;
        bool Yjdian = false;
        bool Yjdian2 = false;
        bool Yyinghuacha = false;
        bool Yyinghuacha2 = false;

        bool meilanshaSummon = false;
        List<int> Link_list = new List<int> {
          CardId.Smengpo, CardId.Lei,CardId.Schujiangwang, CardId.Sbianchengwang,CardId.Sdushiwang,CardId.Xjihe, CardId.Xzhencetianma,
          CardId.As,CardId.Ybusiniao,CardId.Yrenzhe,CardId.Yxiangcaobuding,CardId.Ybeijidemitu,CardId.Yjlei,CardId.Yjdian,CardId.Yyinghuacha, CardId.Swuguanwang,CardId.Dtianqiong,CardId.Jiqiaoshe,
          CardId.Baoshishou,CardId.Yiciyuan,CardId.Baoshishou,CardId.Dtianqiong
        };
        List<int> Summon_list = new List<int> {
          CardId.Ybusiniao,CardId.Yrenzhe,CardId.Yxiangcaobuding,CardId.Ybeijidemitu,CardId.Yjlei,CardId.Yjdian,CardId.Yyinghuacha,CardId.Dtianqiong,CardId.Jiqiaoshe, CardId.Tanhu
        };
        public FacedownExecutor(GameAI ai, Duel duel)
        : base(ai, duel)
        {
            //玫兰莎
            AddExecutor(ExecutorType.Activate, CardId.Meilansha, MeilanshaEffect);
            //邪魂 时空回旋机
            AddExecutor(ExecutorType.Activate, CardId.Shikonghuixuanji, ShikonghuixuanjiEffect);
            //魔陷放置 天穹在场
            AddExecutor(ExecutorType.SpellSet, SpellSetWhenTianQiongBeingEffect);
            //狱龙蛇
            AddExecutor(ExecutorType.Activate, CardId.Yulongshe, YulongsheEffect);
            //桃金娘
            AddExecutor(ExecutorType.Activate, CardId.Taojinniang);
            //天启
            AddExecutor(ExecutorType.Activate, CardId.Tianqidijun);
            //邪魂 时空仲裁
            //AddExecutor(ExecutorType.Activate, CardId.Shikongzhongcaijiguan);
            //万物创伤
            AddExecutor(ExecutorType.Activate, CardId.Wanshichuangshang);
            //霜星效果
            AddExecutor(ExecutorType.Activate, CardId.Shuangxing);
            //剑姬 领域
            AddExecutor(ExecutorType.Activate, CardId.Jianjilingyu, JianjilingyuEffect);
            //剑姬 次元斩
            AddExecutor(ExecutorType.Activate, CardId.Jianjiciyuanzhan, JianjiciyuanzhanEffect);
            //卡组特召
            AddExecutor(ExecutorType.SpSummon, SummonInDeckEffect);
            //阎罗王
            AddExecutor(ExecutorType.SpSummon, CardId.Sdushiwang);
            AddExecutor(ExecutorType.SpSummon, CardId.Smengpo);
            AddExecutor(ExecutorType.SpSummon, CardId.Swuguanwang);
            AddExecutor(ExecutorType.SpSummon, CardId.Schujiangwang);
            AddExecutor(ExecutorType.SpSummon, CardId.Sbianchengwang);
            AddExecutor(ExecutorType.SpSummon, CardId.Syingzheng);
            AddExecutor(ExecutorType.SpSummon, CardId.Sdizangwang);

            //阎罗王 效果
            AddExecutor(ExecutorType.Activate, CardId.Sdushiwang);
            AddExecutor(ExecutorType.Activate, CardId.Smengpo);
            AddExecutor(ExecutorType.Activate, CardId.Swuguanwang);
            AddExecutor(ExecutorType.Activate, CardId.Schujiangwang);
            AddExecutor(ExecutorType.Activate, CardId.Sbianchengwang);
            AddExecutor(ExecutorType.Activate, CardId.Syingzheng, SyingzhengEffect);
            AddExecutor(ExecutorType.Activate, CardId.Sdizangwang, SdizangwangEffect);

            //贪欲壶
            AddExecutor(ExecutorType.Activate, CardId.Tanhu);
            //永恒的约定
            AddExecutor(ExecutorType.Activate, CardId.Yonghengyueding);
            //癫狂 中塔
            AddExecutor(ExecutorType.Activate, CardId.Dzhongta, DzhongtaEffect);
            //癫狂 天球 选择
            AddExecutor(ExecutorType.Activate, CardId.Dtianqiu, DtianqiuEffect2);
            //癫狂 天球
            AddExecutor(ExecutorType.Activate, CardId.Dtianqiu, DtianqiuEffect);
            //癫狂 水立方
            AddExecutor(ExecutorType.Activate, CardId.Dshuilifang, DshuilifangEffect);
            //癫狂 神选择
            AddExecutor(ExecutorType.Activate, CardId.Dshen, DshenEffect2);
            //癫狂 神
            AddExecutor(ExecutorType.Activate, CardId.Dshen, DshenEffect);
            //癫狂 倾泻 选择
            AddExecutor(ExecutorType.Activate, CardId.Dqingxie, DqingxieEffect2);
            //癫狂 倾泻
            AddExecutor(ExecutorType.Activate, CardId.Dqingxie, DqingxieEffect);
            //癫狂 终末
            AddExecutor(ExecutorType.Activate, CardId.Dzhongmo, DzhongmoEffect);
            //癫狂 磁场 选择
            AddExecutor(ExecutorType.Activate, CardId.Dcichang, DcichangEffect2);
            //癫狂 磁场
            AddExecutor(ExecutorType.Activate, CardId.Dcichang, DcichangEffect);
            //癫狂 乱流
            AddExecutor(ExecutorType.Activate, CardId.Dluanliu, DluanliuEffect);
            //癫狂 侵蚀
            AddExecutor(ExecutorType.Activate, CardId.Dqinshi, DqinshiEffect);
            //癫狂 天穹 
            AddExecutor(ExecutorType.Activate, CardId.Dtianqiong, DtianqiongEffect);

            //机巧蛇
            AddExecutor(ExecutorType.Activate, CardId.Jiqiaoshe, JiqiaosheEffect);
            //爱莎
            AddExecutor(ExecutorType.SpSummon, CardId.As, AsSummon);
            //月下 雷
            AddExecutor(ExecutorType.SpSummon, CardId.Lei, DianSummon);
            //月下 雷
            AddExecutor(ExecutorType.Activate, CardId.Lei, LeiEffect);
            //玫兰莎
            AddExecutor(ExecutorType.SpSummon, CardId.Meilansha, MeilanshaSummon);
            //云 不死鸟
            AddExecutor(ExecutorType.Activate, CardId.Ybusiniao, YbusiniaoEffect);
            //云 忍者
            AddExecutor(ExecutorType.Activate, CardId.Yrenzhe, YrenzheEffect);
            //云 布丁
            AddExecutor(ExecutorType.Activate, CardId.Yxiangcaobuding, YxiangcaobudingEffect);
            //云 北极
            AddExecutor(ExecutorType.Activate, CardId.Ybeijidemitu, YbeijidemituEffect);
            //云 雷
            AddExecutor(ExecutorType.Activate, CardId.Yjlei, YjleiEffect);
            //云 电
            AddExecutor(ExecutorType.Activate, CardId.Yjdian, YjdianEffect);
            //云 樱花
            AddExecutor(ExecutorType.Activate, CardId.Yyinghuacha, YyinghuachaEffect);

            //月下 电
            //AddExecutor(ExecutorType.SpSummon, CardId.Dian, DianSummon);
            //月下 电
            AddExecutor(ExecutorType.Activate, CardId.Dian, DianEffect);
            //狱龙蛇
            AddExecutor(ExecutorType.SpSummon, CardId.Yulongshe, YulongsheSummon);
            //邪魂 时空回旋机
            AddExecutor(ExecutorType.SpSummon, CardId.Shikonghuixuanji, ShikonghuixuanjiSummon);

            //邪魂 侦测天马
            AddExecutor(ExecutorType.Activate, CardId.Xzhencetianma, XzhencetianmaEffect);
            //邪魂 试做原型
            AddExecutor(ExecutorType.Activate, CardId.Xshizuoyuanxing, XshizuoyuanxingEffect);
            //邪魂 机核
            AddExecutor(ExecutorType.Activate, CardId.Xjihe, XjiheEffect);

            //霜星
            AddExecutor(ExecutorType.SpSummon, CardId.Shuangxing, ShuangxingSummon);

            //异次元空间怪人 特殊召唤
            AddExecutor(ExecutorType.SpSummon, CardId.Yiciyuan, YiciyuanSummon);
            //异次元空间怪人 除外效果
            AddExecutor(ExecutorType.Activate, CardId.Yiciyuan, YiciyuanInRemoveEffect);

            //剑姬 领域
            AddExecutor(ExecutorType.SpSummon, CardId.Jianjilingyu, JianjilingyuSummon);
            //邪魂 时空仲裁
            AddExecutor(ExecutorType.SpSummon, CardId.Shikongzhongcaijiguan, ShikongzhongcaijiguanSummon);
            //剑姬 次元斩
            AddExecutor(ExecutorType.SpSummon, CardId.Jianjiciyuanzhan, JianjiciyuanzhanSummon);

            //通常召唤
            AddExecutor(ExecutorType.Summon, CardId.Ybusiniao);
            AddExecutor(ExecutorType.Summon, CardId.Yrenzhe);
            AddExecutor(ExecutorType.Summon, CardId.Yxiangcaobuding);
            AddExecutor(ExecutorType.Summon, CardId.Ybeijidemitu);
            AddExecutor(ExecutorType.Summon, CardId.Yjlei);
            AddExecutor(ExecutorType.Summon, CardId.Yjdian);
            AddExecutor(ExecutorType.Summon, CardId.Yyinghuacha);

            //桃金娘
            AddExecutor(ExecutorType.SpSummon, CardId.Taojinniang, TaojinniangSummon);
            //天启
            AddExecutor(ExecutorType.SpSummon, CardId.Tianqidijun, TianqidijunSummon);

            //魔导
            AddExecutor(ExecutorType.Activate, CardId.Modao, ModaoEffect);

            //癫狂 天穹 墓地效果
            AddExecutor(ExecutorType.Activate, CardId.Dtianqiong, DtianqiongEffect2);

            //魔陷放置
            AddExecutor(ExecutorType.SpellSet, SpellSetEffect);

            //暴食兽
            AddExecutor(ExecutorType.SpSummon, CardId.Baoshishou, BaoshishouSummon);
            //暴食兽
            AddExecutor(ExecutorType.Activate, CardId.Baoshishou, JianjiciyuanzhanEffect);

            //异次元空间怪人 额外
            AddExecutor(ExecutorType.Activate, CardId.Yiciyuan, YiciyuanInExtraEffect);
            //克莱
            AddExecutor(ExecutorType.Activate, CardId.kelaibagong);

            //卡组发动
            AddExecutor(ExecutorType.Activate, ActivateInDeckEffect);



            //试试选择的列表写法 AI.SelectCard(new[] { CardId.MechaPhantomBeastAuroradon, CardId.CrystronHalqifibrax, CardId.PredaplantVerteAnaconda });
        }
        //转生炎兽写法：if (Bot.MonsterZone.GetMatchingCardsCount(card => card.IsCode(materials) && !card.IsSpecialSummoned) == 0) //得到相匹配的卡片，如果卡片在素材内且卡片不是特殊召唤
        public override void OnNewTurn()
        {
            // reset
            //云
            Ybusiniao = false;
            Ybusiniao2 = false;
            Yrenzhe = false;
            Yrenzhe2 = false;
            Yxiangcaobuding = false;
            Yxiangcaobuding2 = false;
            Ybeijidemitu = false;
            Ybeijidemitu2 = false;
            Yjlei = false;
            Yjlei2 = false;
            Yjdian = false;
            Yjdian2 = false;
            Yyinghuacha = false;
            Yyinghuacha2 = false;

            meilanshaSummon = false;
        }
        public int Link(int id)
        {
            if (id == CardId.Wanshichuangshang) return 8;
            else if (id == CardId.Shuangxing || id == CardId.Tianqidijun) return 5;
            else if (id == CardId.Shikongzhongcaijiguan || id == CardId.Jianjilingyu || id == CardId.Jianjiciyuanzhan) return 4;
            else if (id == CardId.Shikonghuixuanji || id == CardId.Taojinniang) return 3;
            else if (id == CardId.Meilansha || id == CardId.Yulongshe || id == CardId.Dian || id == CardId.Modao) return 2;
            return 1;
        }

        public bool SpellSetEffect()
        {
            return Card.IsTrap() || Card.HasType(CardType.QuickPlay);
        }
        public bool SpellSetWhenTianQiongBeingEffect()
        {
            return Card.IsTrap() && Card.HasSetcode(0xbf2) && Bot.HasInMonstersZone(CardId.Dtianqiong);
        }
        public bool HandSummon()
        {
            if (Card.Location == CardLocation.Hand)
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }
        //卡组检查
        public int CheckRemainInDeck(int id)
        {
            switch (id)
            {
                case CardId.Sdizangwang:
                    return Bot.GetRemainingCount(CardId.Sdizangwang, 1);
                case CardId.Syingzheng:
                    return Bot.GetRemainingCount(CardId.Syingzheng, 1);
                case CardId.Jiqiaoshe:
                    return Bot.GetRemainingCount(CardId.Jiqiaoshe, 1);
                case CardId.As:
                    return Bot.GetRemainingCount(CardId.As, 1);
                case CardId.Dtianqiong:
                    return Bot.GetRemainingCount(CardId.Dtianqiong, 1);
                case CardId.Xzhencetianma:
                    return Bot.GetRemainingCount(CardId.Xzhencetianma, 1);
                case CardId.Xshizuoyuanxing:
                    return Bot.GetRemainingCount(CardId.Xshizuoyuanxing, 1);
                case CardId.Sbianchengwang:
                    return Bot.GetRemainingCount(CardId.Sbianchengwang, 2);
                case CardId.Sdushiwang:
                    return Bot.GetRemainingCount(CardId.Sdushiwang, 2);
                case CardId.Ybusiniao:
                    return Bot.GetRemainingCount(CardId.Ybusiniao, 3);
                case CardId.Yrenzhe:
                    return Bot.GetRemainingCount(CardId.Yrenzhe, 3);
                case CardId.Schujiangwang:
                    return Bot.GetRemainingCount(CardId.Schujiangwang, 2);
                case CardId.Swuguanwang:
                    return Bot.GetRemainingCount(CardId.Swuguanwang, 2);
                case CardId.Yxiangcaobuding:
                    return Bot.GetRemainingCount(CardId.Yxiangcaobuding, 3);
                case CardId.Ybeijidemitu:
                    return Bot.GetRemainingCount(CardId.Ybeijidemitu, 3);
                case CardId.Yjlei:
                    return Bot.GetRemainingCount(CardId.Yjlei, 3);
                case CardId.Yjdian:
                    return Bot.GetRemainingCount(CardId.Yjdian, 3);
                case CardId.Yyinghuacha:
                    return Bot.GetRemainingCount(CardId.Yyinghuacha, 3);
                case CardId.Smengpo:
                    return Bot.GetRemainingCount(CardId.Smengpo, 2);
                case CardId.Xjihe:
                    return Bot.GetRemainingCount(CardId.Xjihe, 1);
                case CardId.Baoshishou:
                    return Bot.GetRemainingCount(CardId.Baoshishou, 2);
                case CardId.Yonghengyueding:
                    return Bot.GetRemainingCount(CardId.Yonghengyueding, 1);
                case CardId.Tanhu:
                    return Bot.GetRemainingCount(CardId.Tanhu, 2);

                case CardId.Dzhongta:
                    return Bot.GetRemainingCount(CardId.Dzhongta, 1);
                case CardId.Dtianqiu:
                    return Bot.GetRemainingCount(CardId.Dtianqiu, 2);
                case CardId.Dshuilifang:
                    return Bot.GetRemainingCount(CardId.Dshuilifang, 1);
                case CardId.Dshen:
                    return Bot.GetRemainingCount(CardId.Dshen, 2);
                case CardId.Dqingxie:
                    return Bot.GetRemainingCount(CardId.Dqingxie, 2);
                case CardId.Dzhongmo:
                    return Bot.GetRemainingCount(CardId.Dzhongmo, 2);
                case CardId.Dcichang:
                    return Bot.GetRemainingCount(CardId.Dcichang, 2);
                case CardId.Dqinshi:
                    return Bot.GetRemainingCount(CardId.Dqinshi, 2);
                case CardId.Dluanliu:
                    return Bot.GetRemainingCount(CardId.Dluanliu, 2);
                default:
                    return 0;
            }
        }
        //公共方法：卡组检测
        public int CheckRemainInDeck(params int[] ids)
        {
            int result = 0;
            foreach (int cardid in ids)
            {
                result += CheckRemainInDeck(cardid);
            }
            return result;
        }
        //公共方法：手卡跳怪
        public void HandSummonEffect()
        {
            AI.SelectPosition(CardPosition.FaceUpAttack);
        }
        //公共方法：返回卡组
        public void ReturnDeckEffect()
        {
            if (Bot.Banished.Count <= 12)
            {
                AI.SelectCard(CardId.Syingzheng, CardId.Sdizangwang, CardId.Xjihe, CardId.Xzhencetianma, CardId.Xshizuoyuanxing,
                    CardId.Dian, CardId.Lei, CardId.Ybusiniao, CardId.Yrenzhe, CardId.Yxiangcaobuding,
                    CardId.Ybeijidemitu, CardId.Yjdian, CardId.Yyinghuacha, CardId.Baoshishou);
            }
            else if (Bot.ExtraDeck.Count <= 5)
            {
                AI.SelectCard(CardId.Syingzheng, CardId.Lei, CardId.Dian, CardId.Yiciyuan, CardId.kelaibagong, CardId.Wanshichuangshang, CardId.Shuangxing, CardId.Tianqidijun, CardId.Meilansha,
                  CardId.Yulongshe, CardId.Jianjiciyuanzhan, CardId.Jianjilingyu, CardId.Lanmei, CardId.Modao, CardId.Shikonghuixuanji, CardId.Shikongzhongcaijiguan,
                  CardId.Yiciyuan,CardId.Xjihe, CardId.Xzhencetianma, CardId.Xshizuoyuanxing,
                  CardId.Dian, CardId.Lei, CardId.Ybusiniao, CardId.Yrenzhe, CardId.Yxiangcaobuding,
                  CardId.Ybeijidemitu, CardId.Yjdian, CardId.Yyinghuacha, CardId.Baoshishou);
            }
            else
            {
                AI.SelectCard(CardId.Sdizangwang, CardId.Syingzheng, CardId.Xjihe, CardId.Xzhencetianma, CardId.Xshizuoyuanxing,
                   CardId.Dian, CardId.Lei, CardId.Ybusiniao, CardId.Yrenzhe, CardId.Yxiangcaobuding,
                   CardId.Ybeijidemitu, CardId.Yjlei, CardId.Yjdian, CardId.Yyinghuacha, CardId.Baoshishou);
            }
        }
        //卡组特召怪兽条件
        private bool SummonInDeckEffect()
        {
            if (Card.Location == CardLocation.Deck) return true;
            return false;
        }
        //卡组发动效果
        private bool ActivateInDeckEffect()
        {
            if (Card.Location == CardLocation.Deck) return true;
            return false;
        }
        //嬴政
        private bool SyingzhengEffect()
        {
            if (Card.Location == CardLocation.MonsterZone && Duel.Phase == DuelPhase.End)
            {
                return Bot.GetHandCount() < Enemy.GetHandCount();
            }
            else if (Card.Location != CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.Sdizangwang, CardId.Sbianchengwang, CardId.Swuguanwang, CardId.Sbianchengwang);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }
        //十殿阎罗 地藏王
        private bool SdizangwangEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Sdizangwang, 2))
            {
                if (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 1)
                {
                    ReturnDeckEffect();
                    return true;
                }
                return false;
            }
            else return true;
        }
        //异次元空间怪人
        private bool YiciyuanInExtraEffect()
        {
            if (Duel.Player == 0 && !Bot.HasInHand(Summon_list))
            {
                return Card.Location == CardLocation.Extra;
            }
            return false;
        }
        //邪魂 侦测天马
        private bool XzhencetianmaEffect()
        {
            ReturnDeckEffect();
            return true;
        }
        //邪魂 试做原型
        private bool XshizuoyuanxingEffect()
        {
            ReturnDeckEffect();
            AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }
        //邪魂 机核
        private bool XjiheEffect()
        {
            ReturnDeckEffect();
            return true;
        }

        //异次元空间怪人
        private bool YiciyuanSummon()
        {
            AI.SelectCard(CardId.Sdizangwang, CardId.Syingzheng, CardId.Xjihe, CardId.Xzhencetianma, CardId.Xshizuoyuanxing,
                    CardId.Dian, CardId.Lei, CardId.Ybusiniao, CardId.Yrenzhe, CardId.Yxiangcaobuding,
                    CardId.Ybeijidemitu, CardId.Yjdian, CardId.Yyinghuacha, CardId.Baoshishou);
            AI.SelectNextCard(CardId.Sdizangwang, CardId.Syingzheng, CardId.Xjihe, CardId.Xzhencetianma, CardId.Xshizuoyuanxing,
                    CardId.Dian, CardId.Lei, CardId.Ybusiniao, CardId.Yrenzhe, CardId.Yxiangcaobuding,
                    CardId.Ybeijidemitu, CardId.Yjdian, CardId.Yyinghuacha, CardId.Baoshishou);
            AI.SelectThirdCard(CardId.Sdizangwang, CardId.Syingzheng, CardId.Xjihe, CardId.Xzhencetianma, CardId.Xshizuoyuanxing,
                    CardId.Dian, CardId.Lei, CardId.Ybusiniao, CardId.Yrenzhe, CardId.Yxiangcaobuding,
                    CardId.Ybeijidemitu, CardId.Yjdian, CardId.Yyinghuacha, CardId.Baoshishou);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //异次元空间怪人 效果
        private bool YiciyuanInRemoveEffect()
        {
            if (Card.Location == CardLocation.Removed)
            {
                ReturnDeckEffect();
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            return false;
        }
        //暴食兽
        private bool BaoshishouSummon()
        {
            if (Bot.GetMonstersInMainZone().Count >= 5) return false;
            AI.SelectPosition(CardPosition.FaceUpAttack);
            IList<ClientCard> targets = new List<ClientCard>();
            foreach (ClientCard e_c in Bot.ExtraDeck)
            {
                targets.Add(e_c);
                if (targets.Count >= Bot.ExtraDeck.Count)
                {
                    AI.SelectCard(targets);
                    return true;
                }
            }
            foreach (ClientCard s_c in Bot.GetSpells())
            {
                targets.Add(s_c);
                if (targets.Count >= 5)
                {
                    AI.SelectCard(targets);
                    return true;
                }
            }
            return false;
            /*
            AI.SelectCard(new[] {
                        CardId.Modao,
                        CardId.Lei,
                        CardId.Dian,
                        CardId.Yulongshe,
                        CardId.Meilansha,
                        CardId.Shikonghuixuanji,
                        CardId.Shikongzhongcaijiguan,
                        CardId.Lanmei,
                        CardId.Jianjiciyuanzhan,
                        CardId.Jianjilingyu,
                        CardId.Tianqidijun,
                        CardId.Shuangxing,
                        CardId.Wanshichuangshang,
                        CardId.kelaibagong,
                        CardId.Yiciyuan,
                    });
            return true;
            */
        }
        //爱莎
        private bool AsSummon()
        {
           AI.SelectCard(CardId.Sdizangwang, CardId.Syingzheng, CardId.Xjihe, CardId.Xzhencetianma, CardId.Xshizuoyuanxing,
              CardId.Dian, CardId.Lei, CardId.Ybusiniao, CardId.Yrenzhe, CardId.Yxiangcaobuding,
              CardId.Ybeijidemitu, CardId.Yjlei, CardId.Yjdian, CardId.Yyinghuacha, CardId.Baoshishou);
            AI.SelectPosition(CardPosition.FaceUpAttack);
            return true;
        }
        //剑姬 领域
        private bool JianjilingyuEffect()
        {
            if (Duel.CurrentChain.Count > 0)
            {
                return Duel.LastChainPlayer == 1;
            }
            return false;
        }
        //剑姬 次元斩
        private bool JianjiciyuanzhanEffect()
        {
            if (Enemy.BattlingMonster.HasPosition(CardPosition.Attack) && (Bot.BattlingMonster.Attack - Enemy.BattlingMonster.GetDefensePower() >= Enemy.LifePoints)) return false;
            return true;
        }
        //月下 雷
        private bool DianSummon()
        {
            if (Card.Location == CardLocation.Extra)
            {
                foreach (ClientCard card in Bot.Banished)
                {
                    if ((card.IsCode(CardId.Ybusiniao) && !Ybusiniao2) || (card.IsCode(CardId.Yrenzhe) && !Yrenzhe2) || (card.IsCode(CardId.Yxiangcaobuding) && !Yxiangcaobuding2) || (card.IsCode(CardId.Ybeijidemitu) && !Ybeijidemitu2) || (card.IsCode(CardId.Yjlei) && !Yjlei2) || (card.IsCode(CardId.Yjdian) && !Yjdian2) || (card.IsCode(CardId.Yyinghuacha) && !Yyinghuacha2) || card.IsCode(CardId.Dtianqiong) || card.IsCode(CardId.Sdizangwang) || card.IsCode(CardId.Syingzheng) || card.IsCode(CardId.Baoshishou) || card.IsCode(CardId.Xjihe) || card.IsCode(CardId.Xzhencetianma) || card.IsCode(CardId.Xshizuoyuanxing) || card.IsCode(CardId.As))
                    //if (card.IsCode(CardId.Ybusiniao) || card.IsCode(CardId.Yrenzhe) || card.IsCode(CardId.Yxiangcaobuding) || card.IsCode(CardId.Ybeijidemitu) || card.IsCode(CardId.Yjlei) ||card.IsCode(CardId.Yjdian)  || card.IsCode(CardId.Yyinghuacha) || card.IsCode(CardId.Dtianqiong) || card.IsCode(CardId.Sdizangwang) || card.IsCode(CardId.Syingzheng) || card.IsCode(CardId.Baoshishou) || card.IsCode(CardId.Xjihe) || card.IsCode(CardId.Xzhencetianma)  || card.IsCode(CardId.Xshizuoyuanxing) || card.IsCode(CardId.As))
                    {
                        AI.SelectMaterials(new List<int>()
                            {
                               CardId.Ybusiniao,
                               CardId.Yrenzhe
                            });
                        AI.SelectCard(card);
                        return true;
                    }
                }
                foreach (ClientCard card2 in Bot.Graveyard)
                {
                    if ((card2.IsCode(CardId.Ybusiniao) && !Ybusiniao2) || (card2.IsCode(CardId.Yrenzhe) && !Yrenzhe2) || (card2.IsCode(CardId.Yxiangcaobuding) && !Yxiangcaobuding2) || (card2.IsCode(CardId.Ybeijidemitu) && !Ybeijidemitu2) || (card2.IsCode(CardId.Yjlei) && !Yjlei2) || (card2.IsCode(CardId.Yjdian) && !Yjdian2) || (card2.IsCode(CardId.Yyinghuacha) && !Yyinghuacha2) || card2.IsCode(CardId.Sdizangwang) || card2.IsCode(CardId.Syingzheng) || card2.IsCode(CardId.Baoshishou) || card2.IsCode(CardId.Xjihe) || card2.IsCode(CardId.Xzhencetianma) || card2.IsCode(CardId.Xshizuoyuanxing) || card2.IsCode(CardId.As))
                    // else if (card.IsCode(CardId.Ybusiniao) || card.IsCode(CardId.Yrenzhe) || card.IsCode(CardId.Yxiangcaobuding) || card.IsCode(CardId.Ybeijidemitu) || card.IsCode(CardId.Yjlei) || card.IsCode(CardId.Yjdian) || card.IsCode(CardId.Yyinghuacha) || card.IsCode(CardId.Dtianqiong) || card.IsCode(CardId.Sdizangwang) || card.IsCode(CardId.Syingzheng) || card.IsCode(CardId.Baoshishou) || card.IsCode(CardId.Xjihe) || card.IsCode(CardId.Xzhencetianma) || card.IsCode(CardId.Xshizuoyuanxing) || card.IsCode(CardId.As))
                    {
                        AI.SelectMaterials(new List<int>()
                            {
                               CardId.Ybusiniao,
                               CardId.Yrenzhe
                            });
                        AI.SelectCard(card2);
                        return true;
                    }
                }

                {
                    AI.SelectMaterials(new List<int>()
                             {
                               CardId.Ybusiniao,
                               CardId.Yrenzhe
                            });
                    AI.SelectCard(CardLocation.Removed | CardLocation.Grave | CardLocation.MonsterZone);
                    return true;
                }
            }
            return false;
        }
        //魔导
        private bool ModaoEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.Dtianqiong, CardId.As);
                return true;
            }
            return false;
        }
        //月下 电
        private bool DianEffect()
        {
            return true;
        }
        //月下 雷
        private bool LeiEffect()
        {
            AI.SelectCard(CardId.Yxiangcaobuding);
            return true;
        }
        //霜星
        private bool ShuangxingSummon()
        {
            int link_count = 0;
            IList<ClientCard> list = new List<ClientCard>();
            foreach (ClientCard l_check in Bot.GetMonstersInExtraZone())
            {
                if (l_check.IsFacedown() || Link(l_check.Id) >= 5) continue;
                if (Link(l_check.Id) == 3)
                {
                    list.Add(l_check);
                    link_count += 3;
                }
                else if (Link(l_check.Id) == 2)
                {
                    list.Add(l_check);
                    link_count += 2;
                }
                else if (Link(l_check.Id) == 4)
                {
                    list.Add(l_check);
                    link_count += 4;
                }
            }
            foreach (ClientCard t_check in Bot.GetMonstersInMainZone())
            {
                if (t_check.IsFacedown() || Link(t_check.Id) >= 5 || Card.IsCode(CardId.Syingzheng,CardId.Sdizangwang)) continue;
                if (link_count <= 3)
                {
                    if (Link(t_check.Id) == 2)
                    {
                        list.Add(t_check);
                        link_count += 2;
                        if (link_count >= 5) break;
                    }
                    else if (Link(t_check.Id) == 1)
                    {
                        list.Add(t_check);
                        link_count += 1;
                        if (link_count >= 5) break;
                    }
                }
                else if (link_count == 4)
                {
                    if (t_check.IsFacedown() || Link(t_check.Id) >= 5 || Card.IsCode(CardId.Syingzheng, CardId.Shikongzhongcaijiguan)) continue;
                    else if (Link(t_check.Id) == 1)
                    {
                        list.Add(t_check);
                        link_count += 1;
                        if (link_count >= 5) break;
                    }
                    else if (Link(t_check.Id) == 2)
                    {
                        list.Add(t_check);
                        link_count += 2;
                        if (link_count >= 5) break;
                    }
                }
            }
           if (link_count >= 5)
           {
               AI.SelectMaterials(list);
               AI.SelectPlace(Zones.ExtraMonsterZones);
               return true;
           }
           return false;
       }
        //桃金娘
        private bool TaojinniangSummon()
        {
            int link_count = 0;
            IList<ClientCard> list = new List<ClientCard>();
            foreach (ClientCard l_check in Bot.GetMonstersInExtraZone())
            {
                if (l_check.IsFacedown() || Link(l_check.Id) >= 3) continue;
                if (Link(l_check.Id) == 2)
                {
                    list.Add(l_check);
                    link_count += 2;
                }
                else break;
            }
            foreach (ClientCard t_check in Bot.GetMonstersInMainZone())
            {
                if (t_check.IsFacedown() || Link(t_check.Id) >= 3 || t_check.IsCode(CardId.Syingzheng,CardId.Sdizangwang)) continue;
                    if (Link(t_check.Id) == 1)
                    {
                        list.Add(t_check);
                        link_count += 1;
                        if (link_count >= 3) break;
                    }
            }
            if (link_count >= 3)
            {
                AI.SelectMaterials(list);
                return true;
            }
            return false;
        }
        //剑姬 领域  
        private bool JianjilingyuSummon()
        {
            int link_count = 0;
            IList<ClientCard> list = new List<ClientCard>();
            foreach (ClientCard l_check in Bot.GetMonstersInExtraZone())
            {
                if (l_check.IsFacedown() || Link(l_check.Id) >= 4) continue;
                if (Link(l_check.Id) == 3)
                {
                    list.Add(l_check);
                    link_count += 3;
                }
                else if (Link(l_check.Id) == 2)
                {
                    list.Add(l_check);
                    link_count += 2;
                }
                else break;
            }
            foreach (ClientCard t_check in Bot.GetMonstersInMainZone())
            {
                if (t_check.IsFacedown() || Link(t_check.Id) >= 4 || t_check.IsCode(CardId.Syingzheng, CardId.Sdizangwang)) continue;
                if (link_count >= 3)
                {
                    if (Link(t_check.Id) == 1)
                    {
                        list.Add(t_check);
                        link_count += 1;
                        if (link_count >= 4) break;
                    }
                    else if (Link(t_check.Id) == 2)
                    {
                        list.Add(t_check);
                        link_count += 2;
                        if (link_count >= 4) break;
                    }
                }
                else if(link_count <=2)
                {
                    if (Link(t_check.Id) == 2)
                    {
                        list.Add(t_check);
                        link_count += 2;
                        if (link_count >= 4) break;
                    }
                    else if (Link(t_check.Id) == 1)
                    {
                        list.Add(t_check);
                        link_count += 1;
                        if (link_count >= 4) break;
                    }
                }
            }
            if (link_count >= 4)
            {
                AI.SelectMaterials(list);
                return true;
            }
            return false;
        }
        //天启
        private bool TianqidijunSummon()
        {
            int link_count = 0;
            IList<ClientCard> list = new List<ClientCard>();
            foreach (ClientCard l_check in Bot.GetMonstersInExtraZone())
            {
                if (l_check.IsFacedown() || Link(l_check.Id) >= 3) continue;
                if (Link(l_check.Id) == 2)
                {
                    list.Add(l_check);
                    link_count += 2;
                }
                else break;
            }
            foreach (ClientCard t_check in Bot.GetMonstersInMainZone())
            {
                if (t_check.IsFacedown() || Link(t_check.Id) >= 4 || Link(t_check.Id) >= 3 || t_check.IsCode(CardId.Syingzheng, CardId.Sdizangwang)) continue;
                if (Link(t_check.Id) == 1)
                {
                    list.Add(t_check);
                    link_count += 1;
                    if (link_count >= 5) break;
                }
                else if (Link(t_check.Id) == 3)
                {
                    list.Add(t_check);
                    link_count += 3;
                    if (link_count >= 5) break;
                }
                else if (Link(t_check.Id) == 2)
                {
                    list.Add(t_check);
                    link_count += 2;
                    if (link_count >= 5) break;
                }

            }
            if (link_count >= 5)
            {
                AI.SelectMaterials(list);
                return true;
            }
            return false;
        }
        //邪魂 时空仲裁机关
        private bool ShikongzhongcaijiguanSummon()
        {
            int link_count = 0;
            IList<ClientCard> list = new List<ClientCard>();
            foreach (ClientCard l_check in Bot.GetMonstersInExtraZone())
            {
                if (l_check.IsFacedown() || Link(l_check.Id) >= 3) continue;
                if (Link(l_check.Id) == 2)
                {
                    list.Add(l_check);
                    link_count += 2;
                }
                else break;
            }
            foreach (ClientCard t_check in Bot.GetMonstersInMainZone())
            {
                if (t_check.IsFacedown() || Link(t_check.Id) >= 4 || Link(t_check.Id) >= 3 || t_check.IsCode(CardId.Syingzheng, CardId.Sdizangwang)) continue;
                    if (Link(t_check.Id) == 1)
                    {
                        list.Add(t_check);
                        link_count += 1;
                        if (link_count >= 4) break;
                    }
                    else if (Link(t_check.Id) == 2)
                    {
                        list.Add(t_check);
                        link_count += 2;
                        if (link_count >= 4) break;
                    }
                
            }
            if (link_count >= 4)
            {
                AI.SelectMaterials(list);
                return true;
            }
            return false;
        }
        //剑姬 次元斩
        private bool JianjiciyuanzhanSummon()
        {
            int link_count = 0;
            IList<ClientCard> list = new List<ClientCard>();
            foreach (ClientCard l_check in Bot.GetMonstersInExtraZone())
            {
                if (l_check.IsFacedown() || Link(l_check.Id) >= 4) continue;
                if (Link(l_check.Id) == 3)
                {
                    list.Add(l_check);
                    link_count += 3;
                }
                else if (Link(l_check.Id) == 2)
                {
                    list.Add(l_check);
                    link_count += 2;
                }
                else break;
            }
            foreach (ClientCard t_check in Bot.GetMonstersInMainZone())
            {
                if (t_check.IsFacedown() || Link(t_check.Id) >= 4 || t_check.IsCode(CardId.Syingzheng, CardId.Sdizangwang)) continue;
                if (link_count >= 3)
                {
                    if (Link(t_check.Id) == 1)
                    {
                        list.Add(t_check);
                        link_count += 1;
                        if (link_count >= 4) break;
                    }
                    else if (Link(t_check.Id) == 2)
                    {
                        list.Add(t_check);
                        link_count += 2;
                        if (link_count >= 4) break;
                    }
                }
                else if (link_count <= 2)
                {
                    if (Link(t_check.Id) == 3)
                    {
                        list.Add(t_check);
                        link_count += 3;
                        if (link_count >= 4) break;
                    }
                    else if (Link(t_check.Id) == 2)
                    {
                        list.Add(t_check);
                        link_count += 2;
                        if (link_count >= 4) break;
                    }
                    else if (Link(t_check.Id) == 1)
                    {
                        list.Add(t_check);
                        link_count += 1;
                        if (link_count >= 4) break;
                    }
                }
            }
            if (link_count >= 4)
            {
                AI.SelectMaterials(list);
                return true;
            }
            return false;
        }
       //邪魂 时空回旋机
       private bool ShikonghuixuanjiSummon()
       {
           if (CheckRemainInDeck(CardId.Xjihe) >= 1 || CheckRemainInDeck(CardId.Xzhencetianma) >= 1 || CheckRemainInDeck(CardId.Xshizuoyuanxing) >= 1 || Bot.HasInHand(CardId.Xjihe) || Bot.HasInHand(CardId.Xzhencetianma) || Bot.HasInHand(CardId.Xshizuoyuanxing))
           {
               int link_count = 0;
               IList<ClientCard> list = new List<ClientCard>();
               foreach (ClientCard l_check in Bot.GetMonstersInExtraZone())
               {
                   if (l_check.IsFacedown() || Link(l_check.Id) >= 3) continue;
                   if (Link(l_check.Id) == 2)
                   {
                       list.Add(l_check);
                       link_count += 2;
                   }
                   else if (Link(l_check.Id) == 1)
                   {
                       list.Add(l_check);
                       link_count += 1;
                   }
               }
               foreach (ClientCard t_check in Bot.GetMonstersInMainZone())
               {
                    if (t_check.IsFacedown() || Link(t_check.Id) >= 3) continue;
                     if (link_count >= 2)
                    {
                        if (Link(t_check.Id) == 1)
                        {
                            list.Add(t_check);
                            link_count += 1;
                            if (link_count >= 3) break;
                        }
                        else if (Link(t_check.Id) == 2)
                        {
                            list.Add(t_check);
                            link_count += 2;
                            if (link_count >= 3) break;
                        }
                    }
                    else if (link_count <= 1)
                    {
                        if (Link(t_check.Id) == 2)
                        {
                            list.Add(t_check);
                            link_count += 2;
                            if (link_count >= 3) break;
                        }
                        else if (Link(t_check.Id) == 1)
                        {
                            list.Add(t_check);
                            link_count += 1;
                            if (link_count >= 3) break;
                        }
                    }
               }
               /*
               List<ClientCard> monsters = Bot.GetMonsters();
               monsters.Sort(CardContainer.CompareCardAttack);
               foreach (ClientCard card in monsters)
               {
                   if (!list.Contains(card) && card.LinkCount < 3)
                   {
                       if (card.IsFacedown()) continue;
                       list.Add(card);
                       link_count += (card.HasType(CardType.Link) ? card.LinkCount : 1);
                       if (link_count >= 3) break;
                   }
               }
               */
            if (link_count >= 3)
                {
                    AI.SelectMaterials(list);
                    return true;
                }
                return false;
            }
            return false;
        }
        //邪魂 时空回旋机
        private bool ShikonghuixuanjiEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.Xjihe, CardId.Xzhencetianma, CardId.Xzhencetianma);
                AI.SelectNextCard(CardId.Dshen, CardId.Dqingxie, CardId.Dtianqiu, CardId.Dqinshi, CardId.Dshuilifang, CardId.Dzhongmo, CardId.Dcichang, CardId.Dluanliu);
                return true;
            }
            else if (Card.Location == CardLocation.Removed)
            {
                ReturnDeckEffect();
                return true;
            }
            else if (Card.Location == CardLocation.Grave) return false;
            return false;
        }
        //狱龙蛇
        private bool YulongsheSummon()
        {
            foreach (ClientCard l_check in Bot.GetMonstersInExtraZone())
            if ((CheckRemainInDeck(CardId.As) < 1 && CheckRemainInDeck(CardId.Dtianqiong) < 1 && !meilanshaSummon) || (Bot.HasInMonstersZone(CardId.Shikonghuixuanji) && Bot.HasInExtra(CardId.Shuangxing)) || Link(l_check.Id) >= 3)
            {
                foreach (ClientCard monster in Bot.GetMonsters())
                {
                    if (!monster.IsCode(Link_list)) return false;
                    AI.SelectMaterials(Link_list);
                    meilanshaSummon = true;
                    return true;
                }
            }
            return false;
        }
        //狱龙蛇 效果
        private bool YulongsheEffect()
        {
            int a = 0;
            do
            {
                if (a == 0)
                {
                    AI.SelectCard(CardId.Tanhu, CardId.Smengpo, CardId.Swuguanwang, CardId.Schujiangwang, CardId.Sdushiwang, CardId.Sbianchengwang, CardId.Xjihe, CardId.Xzhencetianma, CardId.Xshizuoyuanxing);
                    a++;
                    return true;
                }
                else if (a==1)
                {
                    
                       ClientCard self_card_1 = Bot.MonsterZone[1];
                       ClientCard self_card_3 = Bot.MonsterZone[3];
                       ClientCard self_card_5 = Bot.MonsterZone[5];
                       ClientCard self_card_6 = Bot.MonsterZone[6];
                       foreach (ClientCard card in Bot.GetMonstersInExtraZone())
                           if (self_card_5 != null && card.IsCode(CardId.Yulongshe))
                           {
                               if (self_card_1 != null) return false;
                               AI.SelectCard(CardId.Xzhencetianma, CardId.Yrenzhe);
                               AI.SelectPosition(CardPosition.FaceUpAttack);
                               AI.SelectPlace(Zones.z1);
                               a++;
                               return true;
                           }
                           else if (self_card_6 != null && card.IsCode(CardId.Yulongshe))
                           {
                               if (self_card_3 != null) return false;
                               AI.SelectCard(CardId.Xzhencetianma, CardId.Yrenzhe);
                               AI.SelectPosition(CardPosition.FaceUpAttack);
                               AI.SelectPlace(Zones.z3);
                               a++;
                               return true;
                           }
                }

            }
            while (a >= 2);return false;
        }
        //玫兰莎
        private bool MeilanshaSummon()
        {
            if (Bot.Banished.Count >= 35 || ((CheckRemainInDeck(CardId.As) >= 1 || CheckRemainInDeck(CardId.Dtianqiong) >= 1) && Bot.HasInExtra(CardId.Modao)))
            {
                foreach (ClientCard monster in Bot.GetMonsters())
                { 
                    if (!monster.IsCode(Link_list)) return false;
                    AI.SelectMaterials(Link_list);
                    meilanshaSummon = true;
                    return true;
                }
            }
            return false;
        }
        //玫兰莎
        private bool MeilanshaEffect()
        {
            if (Bot.LifePoints > 900 && Bot.HasInExtra(CardId.Modao) && (CheckRemainInDeck(CardId.As) >= 1 || CheckRemainInDeck(CardId.Dtianqiong) >= 1))
            {
                AI.SelectCard(CardId.Modao, CardId.kelaibagong);
                return true;
            }
            else if (Bot.LifePoints > 500 && Bot.HasInExtra(CardId.kelaibagong) && (!Bot.HasInHand(CardId.Syingzheng) || !Bot.HasInHand(CardId.Sdizangwang)))
            {
                AI.SelectCard(CardId.kelaibagong);
                return true;
            }
            else if (Bot.Graveyard.Count >= 18 && Bot.HasInExtra(CardId.Wanshichuangshang)&& Bot.LifePoints > 3000)
            {
                AI.SelectCard(CardId.Wanshichuangshang);
                return true;
            }
            return false;

        }
        //机巧蛇
        private bool JiqiaosheEffect()
        {
            ClientCard target = Util.GetBestEnemyMonster(true, true);
            if (Card.Location == CardLocation.Hand || Card.Location == CardLocation.Grave)
            {
                HandSummonEffect();
                return true;
            }
            else if (Card.Location == CardLocation.MonsterZone)
            {
                if (target != null)
                {
                    AI.SelectCard(CardId.Tianqidijun,CardId.Wanshichuangshang,CardId.Dian);
                    AI.SelectNextCard(target);
                    return true;
                }
                return false;
            }
            return false;
        }

        //云 不死鸟
        private bool YbusiniaoEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.Deck.Count <= 7) return false;
                HandSummonEffect();
                Ybusiniao = true;
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Ybusiniao, 1))
            {
                Ybusiniao2 = true;
                return true;
            }
            return false;
        }
        //云 忍者
        private bool YrenzheEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.Deck.Count <= 7) return false;
                HandSummonEffect();
                Yrenzhe = true;
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Yrenzhe, 1))
            {
                if (CheckRemainInDeck(CardId.Ybusiniao) > 0 && !Ybusiniao)
                {
                    AI.SelectCard(CardId.Ybusiniao);
                }
                else if (CheckRemainInDeck(CardId.Yrenzhe) > 0 && !Yrenzhe)
                {
                    AI.SelectCard(CardId.Yrenzhe);
                }
                else if (CheckRemainInDeck(CardId.Yxiangcaobuding) > 0 && !Yxiangcaobuding)
                {
                    AI.SelectCard(CardId.Yxiangcaobuding);
                }
                else if (CheckRemainInDeck(CardId.Ybeijidemitu) > 0 && !Ybeijidemitu)
                {
                    AI.SelectCard(CardId.Ybeijidemitu);
                }
                else if (CheckRemainInDeck(CardId.Yjlei) > 0 && !Yjlei)
                {
                    AI.SelectCard(CardId.Yjlei);
                }
                else if (CheckRemainInDeck(CardId.Yjdian) > 0 && !Yjdian)
                {
                    AI.SelectCard(CardId.Yjdian);
                }
                else if (CheckRemainInDeck(CardId.Yyinghuacha) > 0 && !Yyinghuacha)
                {
                    AI.SelectCard(CardId.Yyinghuacha);
                }
                else
                {
                    AI.SelectCard(CardId.Yjdian);
                }
                Yrenzhe2 = true;
                return true;

            }
            return false;
        }
        //云 布丁
        private bool YxiangcaobudingEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.Deck.Count <= 7) return false;
                HandSummonEffect();
                Yxiangcaobuding = true;
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Yxiangcaobuding, 1))
            {
                AI.SelectCard(CardId.Smengpo, CardId.Swuguanwang,CardId.Schujiangwang,CardId.Sdushiwang, CardId.Sbianchengwang, CardId.Tanhu,CardId.Xzhencetianma,CardId.Xshizuoyuanxing ,CardId.Xzhencetianma, CardId.Xshizuoyuanxing, CardId.Xjihe);
                Yxiangcaobuding2 = true;
                return true;

            }
            return false;
        }
        //云 北极
        private bool YbeijidemituEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.Deck.Count <= 7) return false;
                HandSummonEffect();
                Ybeijidemitu = true;
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Ybeijidemitu, 1))
            {
                Ybeijidemitu2 = true;
                AI.SelectCard(CardId.Sdizangwang, CardId.Syingzheng, CardId.As, CardId.Baoshishou, CardId.Dluanliu, CardId.Dqinshi, CardId.Dzhongmo, CardId.Dcichang, CardId.Dshen, CardId.Dqingxie, CardId.Dshuilifang, CardId.Dtianqiu, CardId.Dzhongta);
                return true;

            }
            return false;
        }
        //云 雷
        private bool YjleiEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.Deck.Count <= 7) return false;
                HandSummonEffect();
                Yjlei = true;
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Yjlei, 1))
            {
                AI.SelectCard(CardId.Sdizangwang, CardId.Syingzheng, CardId.Xjihe, CardId.Xzhencetianma, CardId.Xshizuoyuanxing, CardId.Baoshishou,CardId.As);
                Yjlei2 = true;
                return true;

            }
            return false;
        }
        //云 电
        private bool YjdianEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.Deck.Count <= 7) return false;
                HandSummonEffect();
                Yjdian = true;
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Yjdian, 1))
            {
                Yjdian2 = true;
                return true;

            }
            return false;
        }
        //云 樱花
        private bool YyinghuachaEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                if (Bot.Deck.Count <= 7) return false;
                HandSummonEffect();
                Yyinghuacha = true;
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Yyinghuacha, 1))
            {
                if (Bot.HasInBanished(CardId.Ybusiniao) && !Ybusiniao)
                {
                    AI.SelectCard(CardId.Ybusiniao);
                }
                else if (Bot.HasInBanished(CardId.Yrenzhe) && !Yrenzhe)
                {
                    AI.SelectCard(CardId.Yrenzhe);
                }
                else if (Bot.HasInBanished(CardId.Yxiangcaobuding) && !Yxiangcaobuding)
                {
                    AI.SelectCard(CardId.Yxiangcaobuding);
                }
                else if (Bot.HasInBanished(CardId.Ybeijidemitu) && !Ybeijidemitu)
                {
                    AI.SelectCard(CardId.Ybeijidemitu);
                }
                else if (Bot.HasInBanished(CardId.Yjlei) && !Yjlei)
                {
                    AI.SelectCard(CardId.Yjlei);
                }
                else if (Bot.HasInBanished(CardId.Yjdian) && !Yjdian)
                {
                    AI.SelectCard(CardId.Yjdian);
                }
                else if (Bot.HasInBanished(CardId.Yyinghuacha) && !Yyinghuacha)
                {
                    AI.SelectCard(CardId.Yyinghuacha);
                }
                else
                {
                    AI.SelectCard(CardId.Yyinghuacha);
                }
                AI.SelectNextCard(CardId.Dluanliu, CardId.Dshen, CardId.Dqinshi, CardId.Dzhongmo, CardId.Dqingxie, CardId.Dtianqiu, CardId.Dshuilifang, CardId.Dcichang);
                AI.SelectThirdCard(CardId.Smengpo, CardId.Swuguanwang, CardId.Schujiangwang, CardId.Sdushiwang, CardId.Sbianchengwang, CardId.Tanhu, CardId.Sdizangwang, CardId.Syingzheng, CardId.Xzhencetianma, CardId.Xshizuoyuanxing, CardId.Xjihe);
                Yyinghuacha2 = true;
                return true;

            }
            return false;
        }
        //癫狂 天穹
        private bool DtianqiongEffect()
        {
            //foreach (ClientCard card in Bot.Banished)
            if(ActivateDescription == Util.GetStringId(CardId.Dtianqiong, 1))
            {
                    if (CheckRemainInDeck(CardId.Dshen) > 0)
                    {
                        AI.SelectCard(CardId.Dshen);
                    }
                    else if (Enemy.Hand.Count >= 1 && CheckRemainInDeck(CardId.Dtianqiu) > 0)
                    {
                        AI.SelectCard(CardId.Dtianqiu);
                    }
                    else if (Bot.Hand.Count <= 3 && CheckRemainInDeck(CardId.Dshuilifang) > 0)
                    {
                        AI.SelectCard(CardId.Dshuilifang);
                    }
                    else if (Bot.Banished.Count >= 30 && CheckRemainInDeck(CardId.Dcichang) > 0)
                    {
                        AI.SelectCard(CardId.Dcichang);
                    }
                    /*
                    else if (card != null && card.HasType(CardType.Trap))
                    {
                        AI.SelectCard(CardId.Dqingxie);
                    }*/
                    else
                    {
                        AI.SelectCard(CardId.Dluanliu,CardId.Dqinshi,CardId.Dzhongmo);
                    }
                    return true;

                }
            else if (Card.Location == CardLocation.MonsterZone)
            {
                return true;
            }
            return false;
        }
        //癫狂 天穹
        private bool DtianqiongEffect2()
        {
            if (Card.Location == CardLocation.Grave || Card.Location == CardLocation.Removed)
            {
                if (Bot.GetMonstersInMainZone().Count == 3 && Bot.HasInHand(CardId.Baoshishou) && Bot.ExtraDeck.Count >= 4 && (Bot.HasInHand(CardId.Sdizangwang) || Bot.HasInHand(CardId.Syingzheng))) return false;             
                ReturnDeckEffect();
                return true;
            }
            return false;
        }
        //癫狂 钟塔
        private bool DzhongtaEffect()
        {
            if (Card.Location == CardLocation.Hand) return true;
            else if (Card.Location == CardLocation.SpellZone) return true;
            else if (Card.Location == CardLocation.Grave)
            {
                return true;
            }
            return false;
        }
        //癫狂 天球选择
        private bool DtianqiuEffect2()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Dtianqiu, 0))
            {
                ClientCard target = Util.GetBestEnemyCard();
                if (target != null)
                {
                    AI.SelectCard(target);
                }
                else
                {
                    AI.SelectCard(CardLocation.Grave);
                }
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Dtianqiu, 1))return true;
            return false;
        }
        //癫狂 天球
        private bool DtianqiuEffect()
        {
            if (Card.Location == CardLocation.SpellZone)
            {
                int option;
                if (Enemy.GetHandCount() <= 0)
                {
                    option = 0;
                }
                else
                {
                    option = 1;
                }
                if (ActivateDescription != Util.GetStringId(CardId.Dtianqiu, option))
                    return false;
                return true;
            }
            else if (Card.Location == CardLocation.Grave || Card.Location == CardLocation.Removed)
            {
                ReturnDeckEffect();
                return true;
            }
            return false;
        }
        //癫狂 水立方
        private bool DshuilifangEffect()
        {
            if (Card.Location == CardLocation.SpellZone)
            {
                ClientCard target = Util.GetBestEnemyMonster();
                int option;
                if (Bot.Deck.Count < 4 && target == null) return false; 
                else if (Bot.Deck.Count >= 4)
                {
                    option = 1;
                }
                else
                {
                    option = 0;
                }
                if (ActivateDescription != Util.GetStringId(CardId.Dshuilifang, option))
                    return false;
                return true;
            }
            else if (Card.Location == CardLocation.Grave || Card.Location == CardLocation.Removed)
            {
                ReturnDeckEffect();
                return true;
            }
            return false;
        }
        //癫狂 神 选择
        private bool DshenEffect2()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Dshen, 0))
            {
                AI.SelectCard(CardId.Dtianqiu, CardId.Dshuilifang);
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Dshen, 1))
            {
                AI.SelectOption(1);
                return true;
            }
            return false;
        }

        //癫狂 神
        private bool DshenEffect()
        {          
            if (Card.Location == CardLocation.SpellZone)
            {
                int option;
                if (CheckRemainInDeck(CardId.Dzhongta) >= 1 && !Bot.HasInMonstersZone(CardId.Dtianqiong))
                {
                    option = 1;
                }
                else
                {
                    option = 0;
                }
                if (ActivateDescription != Util.GetStringId(CardId.Dshen, option))
                    return false;
                return true;
            }
            else if (Card.Location == CardLocation.Grave || Card.Location == CardLocation.Removed)
            {
                ReturnDeckEffect();
                return true;
            }
            return false;
        }
        //癫狂 倾泻 选择
        private bool DqingxieEffect2()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Dqingxie, 0))
            {
                if (Enemy.Hand.Count > 0)
                {
                    AI.SelectCard(CardId.Dtianqiu, CardId.Dqingxie, CardId.Dshuilifang, CardId.Dshen);
                    return true;
                }
                else if (Bot.HasInHand(CardId.Syingzheng) || Bot.HasInHand(CardId.Sdizangwang))
                {
                    AI.SelectCard(CardId.Dqingxie, CardId.Dtianqiu, CardId.Dshuilifang, CardId.Dshen);
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Dluanliu, CardId.Dqinshi);
                    return true;
                }
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Dqingxie, 1))
            {
                ClientCard target = Util.GetBestEnemyMonster(true);
                if (target != null)
                {
                    AI.SelectCard(target);
                    return true;
                }
                return false;
            }
            return false;
        }
        //癫狂 倾泻
        private bool DqingxieEffect()
        {
            ClientCard target = Util.GetBestEnemyMonster(true);
            if ((Util.ChainContainsCard(CardId.Dtianqiu) || (Util.ChainContainsCard(CardId.Dqingxie)) && Duel.LastChainPlayer == 0)) return false;
             foreach (ClientCard card in Bot.Banished)
            if (Card.Location == CardLocation.SpellZone)
            {
                int option;
                if (!card.HasType(CardType.Trap) && target==null) return false;
                else if (card!=null && card.HasType(CardType.Trap))
                {
                    option = 0;
                }
                else
                {
                    option = 1;
                }
                if (ActivateDescription != Util.GetStringId(CardId.Dqingxie, option))
                    return false;
                return true;
            }
            else if (Card.Location == CardLocation.Grave || Card.Location == CardLocation.Removed)
            {
                    ReturnDeckEffect();
                    return true;
            }
            return false;
        }
        //癫狂 终末
        private bool DzhongmoEffect()
        {
            if (Card.Location == CardLocation.SpellZone)
            {
                if (Duel.Player == 0)
                {
                    int option;
                    if (CheckRemainInDeck(CardId.Dtianqiong) < 1 && !Bot.HasInGraveyard(CardId.Dtianqiong) && !Bot.HasInBanished(CardId.Dtianqiong)) return false;
                    else
                    {
                        option = 0;
                    }
                    if (ActivateDescription != Util.GetStringId(CardId.Dzhongmo, option))
                        return false;
                    return true;
                }
                else if(Duel.Player == 1)
                {
                    int option;
                    option = 1;
                    if (ActivateDescription != Util.GetStringId(CardId.Dzhongmo, option))
                        return false;
                    return true;
                }
            }
            else if (Card.Location == CardLocation.Grave || Card.Location == CardLocation.Removed)
            {
                ReturnDeckEffect();
                return true;
            }
            return false;
        }
        //癫狂 磁场 选择
        private bool DcichangEffect2()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Dcichang, 0))
            {
                AI.SelectCard(CardId.Dshuilifang, CardId.Dshen);
                return true;
            }
            else if (ActivateDescription == Util.GetStringId(CardId.Dcichang, 1)) return true;
            return false;
        }
        //癫狂 磁场
        private bool DcichangEffect()
        {
                if (Card.Location == CardLocation.SpellZone)
                {
                    int option;
                    if (Bot.Banished.Count<=12)
                    {
                        option = 1;
                    }
                    else
                    {
                        option = 0;
                    }
                    if (ActivateDescription != Util.GetStringId(CardId.Dcichang, option))
                        return false;
                    return true;
                }
                else if (Card.Location == CardLocation.Grave || Card.Location == CardLocation.Removed)
                {
                   ReturnDeckEffect();
                   return true;
                }
            return false;
        }
        //癫狂 乱流
        private bool  DluanliuEffect()
        {
            if (Card.Location == CardLocation.SpellZone)
            {
                if (Duel.LastChainPlayer != 0)
                {
                    return true;
                }
                return false;
            }
            else if (Card.Location == CardLocation.Grave || Card.Location == CardLocation.Removed)
            {
                ReturnDeckEffect();
                return true;
            }
            return false;
        }
        //癫狂 侵蚀
        private bool DqinshiEffect()
        {
            if (Card.Location == CardLocation.SpellZone)
            {
                return Duel.LastChainPlayer == -1 && Duel.LastSummonPlayer != 0;
            }
            else if (Card.Location == CardLocation.Grave || Card.Location == CardLocation.Removed)
            {
                ReturnDeckEffect();
                return true;
            }
            return false;
        }
    }
}
