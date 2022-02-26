using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    // NOT FINISHED YET
    [Deck("ALHG", "AI_ALHG", "NotFinished")]
    public class NA_ALHGExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Jushenbing = 10031;
            public const int Xiemodao = 10018;
            public const int Zuoshou = 10043;
            public const int Youshou = 10044;
            public const int Shanxuan = 10041;
            public const int Baozha = 10004;
            public const int Hu = 10030;
            public const int Baima = 20163;
            public const int Sheshen = 10045;
            public const int Nuosi = 10042;
            public const int Hundunjuhe = 8824590;
            public const int Tianshen = 10010;
            public const int Jixuan = 117960683;
            public const int Zhuxuan = 17266660;
            public const int Yishenlong = 10023;
            public const int Guangxuan = 121074344;
            public const int Tiankonglong = 10034;
            public const int Shengyuelong = 8824691;
            public const int BlueEyesSpiritDragon = 59822133;
            public const int AzureEyesSilverDragon = 40908371;
            public const int WhiteDragon = 89631139;
            public const int Baishi = 117981478;
            public const int Dadi = 79029378;
            public const int Anxuan = 82221015;
            public const int ChaosForm = 21082832;
            public const int BlueEyesChaosMaxDragon = 55410871;
            public const int Kesi = 10050;
            public const int Yue = 10049;
            public const int Doushi = 82208117;
            public const int Taoyuan = 82208136;
            public const int Shu = 84610022;
            public const int Lan = 84610004;
            public const int Huiye = 86937530;
            public const int Bguansuoguo = 82208100;
            public const int Qingyanhuanlong = 118817732;
            public const int Niuqi = 85115440;
            public const int Hupao = 11510448;
            public const int Gouhuan = 41375811;
            public const int Longqiang = 48905153;
            public const int Elongqiang = 114890515;
            public const int Tyan = 87209160;
            public const int QW = 63504681;
            public const int Tnv = 56196385;
            public const int Tfeng = 14816857;
            public const int Simofu = 72330894;
            public const int Xiazhigu = 29587993;
            public const int Keshenyi = 14000952;
            public const int Renwushi = 14000951;
            public const int Mohelp = 8824690;
            public const int WSzhaohuan = 50007862;
            public const int WSchangdi = 50007866;
            public const int Xianhelp = 8824692;
            public const int Guaihelp = 8824693;
            public const int WSbianjie = 50007890;
            public const int WSshen = 950038;
            public const int WSN = 50007876;
            public const int WShaima = 50007872;
            public const int WSjian = 50007873;
            public const int WSS = 50007867;
            public const int GQ = 26674724;
            public const int YNK = 89463537;
            public const int EXchuangsheng = 82221014;
            public const int HJN = 99185129;
            public const int MWC = 52846880;
            public const int EXwanhua = 51124303;
            public const int EXfanhun = 97211663;
            public const int QQ = 8824699;
            public const int Huigui = 79029456;
        }

        List<int> Impermanence_list = new List<int>();
        bool NiuqiSpsummoned = false;
        bool HupaoSpsummoned = false;
        bool GouhuanSpsummoned = false;
        bool LongqiangSpsummoned = false;
        bool ElongqiangSpsummoned = false;
        bool HundunjuheXiaoguo = false;
        bool HuiyeXiaoguo = false;
        bool GQXiaoguo = false;
        bool TyanXiaoguo = false;
        bool HG = false;

        public NA_ALHGExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            //回归逐流
            AddExecutor(ExecutorType.Activate, CardId.Huigui, HuiguiEffect);
            //禁断之书
            AddExecutor(ExecutorType.Activate, CardId.Shu, ShuEffect);
            //选择
            AddExecutor(ExecutorType.SpSummon, CardId.QQ, QQEffect);
            //无视召唤
            AddExecutor(ExecutorType.Activate, CardId.WSzhaohuan, WSzhaohuanEffect);
            //无视场地
            AddExecutor(ExecutorType.Activate, CardId.WSchangdi, WSchangdiEffect);
            //无视海马之剑
            AddExecutor(ExecutorType.Activate, CardId.WSjian);
            //我要回农村
            AddExecutor(ExecutorType.Activate, CardId.WSN);
            //闭关锁国
            AddExecutor(ExecutorType.Activate, CardId.Bguansuoguo, DefaultTorrentialTribute);
            //魔法援助
            AddExecutor(ExecutorType.Activate, CardId.Mohelp);
            //陷阱援助
            AddExecutor(ExecutorType.Activate, CardId.Xianhelp);
            //奥利哈刚 天神荡
            AddExecutor(ExecutorType.Activate, CardId.Tianshen);
            //铁兽 兽战士
            AddExecutor(ExecutorType.Activate, CardId.Tyan, TyanEffect);
            //铁兽 鸟兽
            AddExecutor(ExecutorType.Activate, CardId.Tfeng, TfengEffect);
            //奥利哈刚调和宝牌
            AddExecutor(ExecutorType.Activate, CardId.Baozha, BaozhaEffect);
            //奥利哈刚 壶
            AddExecutor(ExecutorType.Activate, CardId.Hu, HuEffect);
            //刃心刻神仪
            AddExecutor(ExecutorType.Activate, CardId.Keshenyi, KeshenyiEffect);
            //奥利哈刚 月
            AddExecutor(ExecutorType.Activate, CardId.Yue);
            //混沌形态
            AddExecutor(ExecutorType.Activate, CardId.ChaosForm, ChaosFormeff);
            //白马
            AddExecutor(ExecutorType.Activate, CardId.Baima, BaimaEffect);

            //怪兽援助
            AddExecutor(ExecutorType.Activate, CardId.Guaihelp);
            //无视边界
            AddExecutor(ExecutorType.Activate, CardId.WSbianjie);
            //无视毁灭神
            AddExecutor(ExecutorType.Activate, CardId.WSshen);
            //无视神
            AddExecutor(ExecutorType.Activate, CardId.WSS);
            //无视海马
            AddExecutor(ExecutorType.Activate, CardId.WShaima);
            //十二兽 牛骑
            AddExecutor(ExecutorType.Activate, CardId.Niuqi, NiuqiEffect);
            //奥利哈刚 奇杰拉
            AddExecutor(ExecutorType.SpSummon, CardId.Shanxuan);
            //光枪影灵衣
            AddExecutor(ExecutorType.Activate, CardId.GQ, GQEffect);
            //影灵衣创生术
            AddExecutor(ExecutorType.Activate, CardId.EXchuangsheng, EXchuangshenEffect);
            //影灵衣返魂术
            AddExecutor(ExecutorType.Activate, CardId.EXfanhun, EXfanhunEffect);
            //影灵衣万华镜
            AddExecutor(ExecutorType.Activate, CardId.EXwanhua, WanhuaEffect);
            //挥剑鸟影灵衣
            AddExecutor(ExecutorType.Activate, CardId.HJN, HJNEffect);
            //灭亡虫影灵衣
            AddExecutor(ExecutorType.Activate, CardId.MWC);
            //无视毁灭神
            AddExecutor(ExecutorType.SpSummon, CardId.WSshen);
            //无视神
            AddExecutor(ExecutorType.SpSummon, CardId.WSS, WSSSummon);
            //无视海马
            AddExecutor(ExecutorType.SpSummon, CardId.WShaima);
            //铁兽 兽战士
            AddExecutor(ExecutorType.Summon, CardId.Tyan, TyanSummon);
            //企鹅大帝
            AddExecutor(ExecutorType.Summon, CardId.Dadi);
            //青眼圣约龙
            AddExecutor(ExecutorType.SpSummon, CardId.Shengyuelong);
            //奥利哈刚 巨神兵 
            AddExecutor(ExecutorType.SpSummon, CardId.Jushenbing);
            //奥利哈刚 天空龙
            AddExecutor(ExecutorType.SpSummon, CardId.Tiankonglong, TiankonglongSummon);
            //奥利哈刚 翼神龙 
            AddExecutor(ExecutorType.SpSummon, CardId.Yishenlong, YishenlongSummon);
            //甘蓝
            AddExecutor(ExecutorType.Summon, CardId.Lan);
            //奥利哈刚 邪魔导
            AddExecutor(ExecutorType.Summon, CardId.Xiemodao, XiemodaoSummon);
            //辉夜
            AddExecutor(ExecutorType.Summon, CardId.Huiye);

            //无视边界
            AddExecutor(ExecutorType.SpSummon, CardId.WSbianjie);
            //十二兽 牛骑
            AddExecutor(ExecutorType.SpSummon, CardId.Niuqi, NiuqiSummon);
            //甘蓝
            AddExecutor(ExecutorType.Activate, CardId.Lan);
            //青眼幻龙
            AddExecutor(ExecutorType.SpSummon, CardId.Qingyanhuanlong);
            //奥利哈刚 蛇神
            AddExecutor(ExecutorType.SpSummon, CardId.Sheshen);
            //奥利哈刚 诺斯
            AddExecutor(ExecutorType.SpSummon, CardId.Nuosi);
            //青眼精灵龙
            AddExecutor(ExecutorType.SpSummon, CardId.BlueEyesSpiritDragon);
            //暗之宣告者
            AddExecutor(ExecutorType.SpSummon, CardId.Anxuan);
            //十二兽 牛骑
            AddExecutor(ExecutorType.SpSummon, CardId.Niuqi, NiuqiXYZSummon);
            //十二兽 虎炮
            AddExecutor(ExecutorType.SpSummon, CardId.Hupao, HupaoSummon);
            //十二兽 狗环
            AddExecutor(ExecutorType.SpSummon, CardId.Gouhuan, GouhuanSummon);
            //十二兽 龙枪
            AddExecutor(ExecutorType.SpSummon, CardId.Longqiang, LongqiangSummon);
            //十二兽 EX龙枪
            AddExecutor(ExecutorType.SpSummon, CardId.Elongqiang, ElongqiangSummon);

            //卡欧斯 混沌聚合
            AddExecutor(ExecutorType.Activate, CardId.Hundunjuhe, HundunjuheEffect);
            //桃花源
            AddExecutor(ExecutorType.Activate, CardId.Taoyuan, TaoyuanEffect);
            //辉夜
            AddExecutor(ExecutorType.Activate, CardId.Huiye, HuiyeEffect);
            //凶兽斗士 
            AddExecutor(ExecutorType.Activate, CardId.Doushi, DoushiEffect);
            //闪光的白石
            AddExecutor(ExecutorType.Activate, CardId.Baishi, BaishiEffect);
            // 企鹅大帝
            AddExecutor(ExecutorType.Activate, CardId.Dadi);
            //青眼圣约龙
            AddExecutor(ExecutorType.Activate, CardId.Shengyuelong);
            //青眼幻龙
            AddExecutor(ExecutorType.Activate, CardId.Qingyanhuanlong, QingyanhuanlongEffect);
            //青眼精灵龙
            AddExecutor(ExecutorType.Activate, CardId.BlueEyesSpiritDragon, BlueEyesSpiritDragonEffect);
            //奥利哈刚 奇杰拉
            AddExecutor(ExecutorType.Activate, CardId.Shanxuan);
            //十二兽 龙枪
            AddExecutor(ExecutorType.Activate, CardId.Longqiang, LongqiangEffect);
            //十二兽 EX龙枪
            AddExecutor(ExecutorType.Activate, CardId.Elongqiang, ElongqiangEffect);
            //铁兽 兽
            AddExecutor(ExecutorType.Activate, CardId.Tnv, TnvEffect);
            //斯摩夫鸟
            AddExecutor(ExecutorType.Activate, CardId.Simofu, SimofuEffect);
            //霞之谷神鸟
            AddExecutor(ExecutorType.Activate, CardId.Xiazhigu, XiazhiguEffect);
            //英豪枪王
            AddExecutor(ExecutorType.Activate, CardId.QW);
            //奥利哈刚 巨神兵 
            AddExecutor(ExecutorType.Activate, CardId.Jushenbing);
            //奥利哈刚 天空龙 
            AddExecutor(ExecutorType.Activate, CardId.Tiankonglong);
            //奥利哈刚 翼神龙 
            AddExecutor(ExecutorType.Activate, CardId.Yishenlong, YishenlongEffect);
            //奥利哈刚 右手
            AddExecutor(ExecutorType.Activate, CardId.Youshou);
            //奥利哈刚 诺斯
            AddExecutor(ExecutorType.Activate, CardId.Nuosi);
            //苍眼银龙
            AddExecutor(ExecutorType.Activate, CardId.AzureEyesSilverDragon, AzureEyesSilverDragonEffect);
            //极光之宣告者
            AddExecutor(ExecutorType.Activate, CardId.Jixuan, JixuanEffect);
            //闪光之宣告者
            AddExecutor(ExecutorType.Activate, CardId.Guangxuan, GuangEffect);
            //朱光之宣告者
            AddExecutor(ExecutorType.Activate, CardId.Zhuxuan, ZhEffect);
            //刻神仪 刃舞士
            AddExecutor(ExecutorType.Activate, CardId.Renwushi, RenwushiEffect);
            //刻神仪 刃舞士
            AddExecutor(ExecutorType.Activate, CardId.Renwushi, RenwushiSummon);
            //暗之宣告者效果
            AddExecutor(ExecutorType.Activate, CardId.Anxuan, AnxuanEffect);
            //铁兽 鸟兽
            AddExecutor(ExecutorType.Summon, CardId.Tfeng, TfengSummon);

            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
        }
        //计数专用
        public override void OnNewTurn()
        {
            // reset
            NiuqiSpsummoned = false;
            HupaoSpsummoned = false;
            GouhuanSpsummoned = false;
            LongqiangSpsummoned = false;
            ElongqiangSpsummoned = false;
            HundunjuheXiaoguo = false;
            HuiyeXiaoguo = false;
            GQXiaoguo = false;
            TyanXiaoguo = false;
            HG = false;

        }
        private bool HuiguiEffect()
        {
            if (!HG)
            {
                HG = true;
                return true;
            }
            return false;
        }
        private bool WSSSummon()
        {
            return Bot.GetMonstersInMainZone().Count < 5;
        }
        //奥利哈刚 天空龙召唤
        private bool TiankonglongSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Jushenbing) || Bot.HasInMonstersZone(CardId.Yishenlong))
                {
                return false;
            }
            return true;
        }
        //无视召唤
        private bool WSzhaohuanEffect()
        {
            AI.SelectCard(CardId.Keshenyi);
            AI.SelectNextCard(CardId.Sheshen, CardId.Jushenbing, CardId.Tiankonglong, CardId.Nuosi);
            AI.SelectPosition(CardPosition.FaceDownAttack);
            return true;
        }
        //无视场地
        private bool WSchangdiEffect()
        {
            int i = 0;
            do
            {
                if (i == 0)
                {
                    AI.SelectCard(CardId.Sheshen, CardId.Jushenbing, CardId.Tiankonglong, CardId.Nuosi);
                    AI.SelectPosition(CardPosition.FaceDownAttack);
                    i++;
                    return true;
                }
                else if (i == 1)
                {
                    AI.SelectCard(CardId.Tianshen, CardId.Baozha, CardId.Hu, CardId.Mohelp);
                    i++;
                    return true;
                }
            }
            while (i >= 2); return false;
        }
        //奥利哈刚 翼神龙召唤
        private bool YishenlongSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Jushenbing) || Bot.HasInMonstersZone(CardId.Tiankonglong))
            {
                return false;
            }
            return true;
        }
        //影灵衣创生术
        private bool EXchuangshenEffect()
        {
            if (Duel.CurrentChain.Count > 0 && Duel.LastChainPlayer == 0) return false;
            else if (!GQXiaoguo && Bot.HasInHand(CardId.GQ) && !Bot.HasInHand(CardId.YNK) && !Bot.HasInMonstersZone(CardId.YNK) && !Bot.HasInGraveyard(CardId.YNK) && !Bot.HasInBanished(CardId.YNK) && !Bot.HasInSpellZone(CardId.YNK))
            {
                return false;
            }
            else if (Bot.HasInExtra(CardId.Anxuan) && Bot.HasInHand(CardId.YNK))
            {
                AI.SelectCard(CardId.EXwanhua);
                AI.SelectNextCard(CardId.Anxuan);
            }
            else
            {
                AI.SelectCard(CardId.EXfanhun);
                return true;
            }
            return true;
        }
        //影灵衣返魂术
        private bool EXfanhunEffect()
        {
            if (Bot.HasInHand(CardId.Shanxuan) && Bot.MonsterZone[5] != null) return false;
            return true;
        }
        //鸟兽族铁兽
        private bool TfengSummon()
        {
            if (!Bot.HasInExtra(CardId.Simofu) || !Bot.HasInExtra(CardId.Simofu)) return false;
            return true;
        }
        //斯摩夫鸟
        private bool SimofuEffect()
        {
            if (!Bot.HasInMonstersZone(CardId.Xiazhigu))
            {
                AI.SelectCard(CardId.Xiazhigu);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            else
            {
                AI.SelectCard(CardId.Tfeng);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
        }
        //书
        private bool ShuEffect()
        {
                AI.SelectCard(
                         CardId.Lan,
                         CardId.Huiye
                         );
                return true;
        }
        //牛骑特招
        private bool NiuqiSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Hupao) && !NiuqiSpsummoned)
            {
                AI.SelectMaterials(CardId.Hupao);
                AI.SelectYesNo(true);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                NiuqiSpsummoned = true;
                return true;
            }
            if (Bot.HasInMonstersZone(CardId.Gouhuan) && !NiuqiSpsummoned)
            {
                AI.SelectMaterials(CardId.Gouhuan);
                AI.SelectYesNo(true);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                NiuqiSpsummoned = true;
                return true;
            }
            return false;
        }
        //虎炮特招
        private bool HupaoSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Niuqi) && !HupaoSpsummoned)
            {
                AI.SelectMaterials(CardId.Niuqi);
                AI.SelectYesNo(true);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                HupaoSpsummoned = true;
                return true;
            }
            if (Bot.HasInMonstersZone(CardId.Gouhuan) && !NiuqiSpsummoned)
            {
                AI.SelectMaterials(CardId.Gouhuan);
                AI.SelectYesNo(true);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                HupaoSpsummoned = true;
                return true;
            }
            return false;
        }
        //狗环特招
        private bool GouhuanSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Hupao) && !GouhuanSpsummoned)
            {
                AI.SelectMaterials(CardId.Hupao);
                AI.SelectYesNo(true);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                GouhuanSpsummoned = true;
                return true;
            }
            return false;
        }
        //龙枪效果
        private bool LongqiangEffect()
        {
            ClientCard target = Util.GetBestEnemyCard(true);
            if (!Bot.HasInMonstersZone(CardId.Nuosi))
            {
                if (Card.IsDisabled()) return false;
                if (Duel.LastChainPlayer == 0)
                    return false;
                if (target == null && !Bot.HasInMonstersZone(CardId.Nuosi))
                    return false;
                    AI.SelectCard(
                      CardId.Anxuan,
                      CardId.Niuqi,
                      CardId.Hupao,
                      CardId.Gouhuan,
                      CardId.Lan,
                      CardId.Huiye
                      );
                    AI.SelectNextCard(target);
                    return true;
            }
            else if (Bot.HasInMonstersZone(CardId.Nuosi))
            {
                if (Card.IsDisabled()) return false;
                AI.SelectCard(
                CardId.Anxuan,
                CardId.Niuqi,
                CardId.Hupao,
                CardId.Gouhuan,
                CardId.Lan,
                CardId.Huiye
                 );
                AI.SelectNextCard(CardId.Nuosi);
                return true;
            }
            return false;
        }
        //EX龙枪效果
        private bool ElongqiangEffect()
        {
            if (Card.IsDisabled()) return false;
            AI.SelectCard(
                CardId.QW
                );
            return true;
        }
        //牛骑效果
        private bool NiuqiEffect()
        {
            if (Card.IsDisabled()) return false;
            AI.SelectCard(
                CardId.Tyan
                );
            return true;
        }
            //龙枪特招
            private bool LongqiangSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Gouhuan) && !LongqiangSpsummoned)
            {
                AI.SelectMaterials(CardId.Gouhuan);
                AI.SelectYesNo(true);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                LongqiangSpsummoned = true;
                return true;
            }
            return false;
        }
        //EX龙枪特招
        private bool ElongqiangSummon()
        {
            if (Bot.HasInMonstersZone(CardId.Longqiang) && !ElongqiangSpsummoned)
            {
                AI.SelectMaterials(CardId.Longqiang);
                AI.SelectYesNo(true);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                ElongqiangSpsummoned = true;
                return true;
            }
            return false;
        }
        //牛骑超量召
        private bool NiuqiXYZSummon()
        {
            AI.SelectYesNo(false);
            AI.SelectPosition(CardPosition.FaceUpDefence);
            AI.SelectMaterials(new[]
                {
                    CardId.YNK,
                    CardId.Huiye,
                    CardId.Lan,
                    CardId.Tyan,
                    CardId.Zuoshou,
                    CardId.Renwushi,
                    CardId.Youshou
                });
            return true;
        }
        //混沌聚合
        private bool HundunjuheEffect()
        {
            if (Bot.HasInMonstersZone(CardId.Huiye) && !HuiyeXiaoguo)
            {
                return false;
            }
            else
            {
                HundunjuheXiaoguo = true;
                return true;
            }
        }
        //白马
        private bool BaimaEffect()
        {
            if (Bot.HasInMonstersZone(CardId.Huiye) && !HuiyeXiaoguo) return false;
            if (Bot.HasInExtra(CardId.Hundunjuhe) && !HundunjuheXiaoguo) return false;
            foreach (ClientCard m in Enemy.GetMonsters())
            {
                if (m.IsMonster() && Duel.LastChainPlayer != 0)
                {
                    if (Card.Location == CardLocation.SpellZone || Card.Location == CardLocation.Hand) return true;
                  
                }
                return false;

            }
            return true;
        }
        //铁兽通召
        private bool TyanSummon()
        {
            if (Bot.HasInGraveyard(CardId.Tyan))
            {
                return true;
            }
            return false;
        }
        //奥利哈刚 调和宝牌
        private bool BaozhaEffect()
        {
            IList<int> targets = new[] {
                    CardId.Jushenbing,
                    CardId.Tiankonglong,
                    CardId.Yishenlong,
                    CardId.Zuoshou,
                    CardId.Youshou,
                    CardId.Kesi
                };
            if (Bot.HasInHand(CardId.Shanxuan) || Bot.HasInMonstersZone(CardId.Shanxuan))
            {
                AI.SelectCard(targets);
            }
            else
            {
                AI.SelectCard(CardId.Shanxuan);
            }
            return true;
        }
        //桃花源
        public bool TaoyuanEffect()
        {
            return (Duel.Player == 1);
        }
        //辉夜效果
        private bool HuiyeEffect()
        {
            ClientCard target = Util.GetBestEnemyMonster(true);
            List<ClientCard> monster = Bot.GetMonsters();
            foreach (ClientCard card in monster)
                if (card != null)
                {
                 AI.SelectCard(
                   CardId.Lan,
                   CardId.Huiye
                  );
                   return true;
                }
                else if (Card.Location == CardLocation.MonsterZone)
                {
                    if (target == null && !Enemy.HasInMonstersZone(CardId.Hundunjuhe))
                    {
                        return false;
                    }
                    if (target != null && !Enemy.HasInMonstersZone(CardId.Hundunjuhe))
                    {
                        AI.SelectCard(target);
                        return true;
                    }
                    if (Enemy.HasInMonstersZone(CardId.Hundunjuhe))
                    {
                        AI.SelectCard(CardId.Hundunjuhe);
                        HuiyeXiaoguo = true;
                        return true;
                    }
                }
            return false;
        }
    //混沌形态
    private bool ChaosFormeff()
        {
            ClientCard check = null;
            foreach (ClientCard m in Bot.Graveyard)
            {
                if (m.IsCode( CardId.BlueEyesChaosMaxDragon, CardId.WhiteDragon))
                    check = m;

            }

            if (check != null)
            {
                AI.SelectCard(CardId.BlueEyesChaosMaxDragon);
                AI.SelectNextCard(check);
                return true;
            }
            foreach (ClientCard m in Bot.Hand)
            {
                if (m.IsCode(CardId.WhiteDragon))
                    check = m;
            }
            if (check != null)
            {
                AI.SelectCard(CardId.BlueEyesChaosMaxDragon);
                AI.SelectNextCard(check);
                return true;
            }
            return false;
        }
        //斗士
        private bool DoushiEffect()
        {
            ClientCard target = Util.GetBestEnemyCard();
            if (target != null)
            {
                AI.SelectCard(target);
                return true;
            }
            if (target == null)
            {
                return false;
            }
                return false;
        }
        //青眼精灵龙
        private bool BlueEyesSpiritDragonEffect()
        {
            if (ActivateDescription == -1 || ActivateDescription == Util.GetStringId(CardId.BlueEyesSpiritDragon, 0))
            {
                return Duel.LastChainPlayer == 1;
            }
            else if (Duel.Player == 1 && (Duel.Phase == DuelPhase.BattleStart || Duel.Phase == DuelPhase.End))
            {
                AI.SelectCard(CardId.AzureEyesSilverDragon);
                return true;
            }
            else
            {
                if (Util.IsChainTarget(Card))
                {
                    AI.SelectCard(CardId.AzureEyesSilverDragon);
                    return true;
                }
                return false;
            }
        }
        //苍眼银龙
        private bool AzureEyesSilverDragonEffect()
        {
            if (Enemy.GetSpellCount() > 0)
            {
                AI.SelectCard(CardId.WhiteDragon);
            }
            else
            {
                AI.SelectCard(CardId.WhiteDragon);
            }
            return true;
        }
        //奥利哈刚 邪魔导
        private bool XiemodaoSummon()
        {
            List<ClientCard> monster = Bot.GetMonsters();
            foreach (ClientCard card in monster)
                if (card != null && card.IsCode(CardId.Shanxuan))
                    return true;
            return false;
        }
        //暗之宣告者效果
        private bool AnxuanEffect()
        {
            if (Duel.CurrentChain.Count > 0)
            {
                return Duel.LastChainPlayer == 1;
            }
            else
            {
                AI.SelectCard(
                CardId.Keshenyi,
                CardId.GQ,
                CardId.HJN,
                CardId.MWC,
                CardId.EXfanhun,
                CardId.EXwanhua,
                CardId.Renwushi,
                CardId.YNK
                );
                return true;
                
            }
        }
        //青眼幻龙
        private bool QingyanhuanlongEffect()
        {
            ClientCard card = Util.GetLastChainCard();
            if (Card.IsDisabled() || (card!=null && card.IsCode(CardId.Lan)) ) return false;
            AI.SelectCard(
                CardId.Shengyuelong,
                CardId.WhiteDragon
                );
            return true;
        }
        //霞之谷神鸟
        private bool XiazhiguEffect()
        {
            return DefaultTrap();
        }
        //极光之宣告者
        private bool JixuanEffect()
        {
            if (Bot.HasInHand(CardId.Zhuxuan))
            {
                AI.SelectCard(
                    CardId.Guangxuan,
                    CardId.Zhuxuan
                    );
                return true;
            }
            else
            {
                AI.SelectCard(
                    CardId.Zhuxuan,
                    CardId.Guangxuan
                    );
                return true;
            }
        }
        //影灵衣万华镜
        private bool WanhuaEffect()
        {
            if (Bot.HasInGraveyard(CardId.YNK) && (Bot.HasInMonstersZone(CardId.Niuqi) || Bot.HasInMonstersZone(CardId.Hupao) || Bot.HasInMonstersZone(CardId.Gouhuan) || Bot.HasInMonstersZone(CardId.Longqiang) || Bot.HasInMonstersZone(CardId.Elongqiang))) return false;
            if (Bot.HasInExtra(CardId.Anxuan) && Bot.HasInHand(CardId.YNK))
            {
                AI.SelectCard(
                    CardId.Anxuan
                    );
                AI.SelectNextCard(
                   CardId.YNK
                   );
                return true;
            }
            if (!Bot.HasInExtra(CardId.Anxuan) || !Bot.HasInHand(CardId.YNK))
            {
                return true;
            }
            return false;
        }
        //朱光宣告者
        private bool ZhEffect()
        {
            AI.SelectOption(1);
            return true;
        }
        //选择
        private bool QQEffect()
        {
            AI.SelectCard(
                CardId.EXchuangsheng,
                CardId.GQ,
                CardId.YNK,
                CardId.HJN,
                CardId.MWC
                );
            return true;
        }
        //闪光宣告者
        private bool GuangEffect()
        {
            AI.SelectOption(1);
            return true;
        }
        //光枪影灵衣
        private bool GQEffect()
        {
            List<ClientCard> enemy_monsters = Enemy.GetMonsters();
            foreach (ClientCard target in enemy_monsters)
                if (Card.Location == CardLocation.MonsterZone)
                {
                    if (Duel.LastChainPlayer == 0)
                    {
                        return false;
                    }
                    if ((target.HasType(CardType.Fusion) || target.HasType(CardType.Synchro) || target.HasType(CardType.Xyz) || target.HasType(CardType.Link)) && !target.HasSetcode(8824590))
                    {
                        AI.SelectCard(target);
                        return true;
                    }
                    if ((target.HasType(CardType.Fusion) || target.HasType(CardType.Synchro) || target.HasType(CardType.Xyz) || target.HasType(CardType.Link)) && target.HasSetcode(8824590))
                    {
                        AI.SelectCard(CardId.Hundunjuhe);
                        return true;
                    }
                }
                else if (Card.Location == CardLocation.Hand)
                {
                    AI.SelectCard(
                    CardId.YNK,
                    CardId.HJN,
                    CardId.MWC
                    );
                   GQXiaoguo= true;
                   return true;
                }
            return false;
        }
        //挥剑鸟影灵衣
        private bool HJNEffect()
        {
            List<ClientCard> enemy_monsters = Enemy.GetMonsters();
            foreach (ClientCard target in enemy_monsters)
                if (Card.Location == CardLocation.MonsterZone)
                {
                    if (Duel.LastChainPlayer == 0)
                    {
                        return false;
                    }
                    if ((target.HasType(CardType.Fusion) || target.HasType(CardType.Synchro) || target.HasType(CardType.Xyz) || target.HasType(CardType.Link)) && !target.HasSetcode(8824590))
                    {
                        AI.SelectCard(target);
                        return true;
                    }
                    if ((target.HasType(CardType.Fusion) || target.HasType(CardType.Synchro) || target.HasType(CardType.Xyz) || target.HasType(CardType.Link)) && target.HasSetcode(8824590))
                    {
                        AI.SelectCard(CardId.Hundunjuhe);
                        return false;
                    }
                }
                else if (Card.Location == CardLocation.Hand)
                {
                    AI.SelectCard(
                    CardId.EXfanhun,
                    CardId.EXwanhua,
                    CardId.EXchuangsheng
                    );
                    return true;
                }
            return false;
        }
        //铁兽 兽战士
        private bool TyanEffect()
        {
            if (Card.Location == CardLocation.Hand || Card.Location == CardLocation.MonsterZone)
            {
                if (!TyanXiaoguo && Card.Location == CardLocation.MonsterZone && !Bot.HasInExtra(CardId.Simofu)) return false;
                if (Card.Location == CardLocation.Hand)
                {
                    AI.SelectCard(
                        CardId.Tnv,
                        CardId.Tfeng,
                        CardId.Simofu
                        );
                    return true;
                }
                if (Card.Location == CardLocation.MonsterZone && Bot.HasInExtra(CardId.Simofu))
                {
                        TyanXiaoguo = true;
                        return true;
                }
                if (TyanXiaoguo && Card.Location == CardLocation.MonsterZone)
                {
                    AI.SelectCard(
                        CardId.Tnv,
                        CardId.Tfeng,
                        CardId.Simofu
                        );
                    return true;
                }
                return false;
            }
            return false;
        }
        //铁兽 兽
        private bool TnvEffect()
        {
            AI.SelectCard(
                CardId.Tfeng,
                CardId.Tyan
                );
            return true;
        }
        //铁兽 鸟兽
        private bool TfengEffect()
        {
            AI.SelectCard(
                CardId.Tyan,
                CardId.Tnv
                );
            return true;
        }
        //刃舞士召唤
        private bool RenwushiSummon()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(
                    CardId.Tnv,
                    CardId.Tfeng,
                    CardId.Jixuan,
                    CardId.Baima);
                return true;
            }
            return false;
        }
        //刃舞士效果
        private bool RenwushiEffect()
        {
            if (Card.Location == CardLocation.MonsterZone || Card.Location == CardLocation.Hand)
            {
                ClientCard target = Util.GetBestEnemyMonster(true);
                if (Duel.LastChainPlayer == 0) return false;
                if (target == null && Duel.LastChainPlayer != 0) return false;
                if (target != null && Duel.LastChainPlayer != 0)
                {
                    AI.SelectCard(target);
                    return true;
                }
                else if(Card.Location == CardLocation.Grave)
                {
                    return true;
                }
            }
            return false;
        }
        //刻神仪
        private bool KeshenyiEffect()
        {
            AI.SelectCard(
                    CardId.Tnv,
                    CardId.Tfeng,
                    CardId.Jixuan,
                    CardId.Baima
                );
            AI.SelectYesNo(true);
            return true;
        }
        //闪光的白石
        private bool BaishiEffect()
        {
            AI.SelectCard(
                    CardId.Tnv,
                    CardId.Tfeng,
                    CardId.Jixuan,
                    CardId.Baima
                    );
            ClientCard target = Util.GetBestEnemyCard();
            if (target != null)
            {
                AI.SelectNextCard(
                       CardId.Shengyuelong
                       );
            }
            else
                AI.SelectNextCard(
                    CardId.WhiteDragon,
                    CardId.Dadi
                    );
                return true;
        }
        //奥利哈刚 翼神龙
        private bool YishenlongEffect()
        {
            ClientCard target = Util.GetBestEnemyCard();
            if (target != null)
            {
                AI.SelectCard(target);
                return true;
            }
            return false;
        }
        //奥利哈刚 壶
        private bool HuEffect()
        {
            List<ClientCard> monster = Bot.GetMonsters();
            foreach (ClientCard card in monster)
                if (card != null && card.IsCode(CardId.Shanxuan, CardId.Jushenbing, CardId.Xiemodao, CardId.Zuoshou, CardId.Youshou, CardId.Sheshen, CardId.Nuosi, CardId.Kesi))
                    return true;
            return false;
        }

    }
}
