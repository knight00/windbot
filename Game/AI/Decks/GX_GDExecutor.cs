using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;


namespace WindBot.Game.AI.Decks
{
    // NOT FINISHED YET
    [Deck("GD", "AI_GD", "NotFinished")]
    public class GDExecutor : DefaultExecutor
    {
        public class CardId
        {
            //光道【AI专用】
            
            //裁决之龙 是个炸场的龙
            public const int Caijuezhilong = 57774843;
            //光道龙 格拉古尼斯
            public const int Gelagulishi = 21785144;
            //光道天使 基路伯
            public const int Jilubo = 94381039;
            public const int Jaluoshi = 59019082;
            public const int Woerfu = 58996430;
            public const int Csyuyanzhe = 66337215;
            public const int Jian = 96235275;
            public const int Lila = 22624373;
            public const int Ailin = 44178886;
            public const int Luominasi = 95503687;
            public const int Liequanleiguang = 21502796;
            public const int Xiaolizi = 11548522;
            public const int Taiyangjiaohuan = 691925;
            public const int Shanguanghuanxiang = 61962135;
            public const int Sizhezhuansheng = 74848038;
            public const int MonsterReborn = 83764718;
            public const int Yumaosao = 18144507;
            public const int Leiji = 12580477;
            public const int MirrorForce = 44095762;
            public const int Honest = 37742478;
            public const int Ciyuanzhanshi = 7572887;
            public const int ReinforcementOfTheArmy = 32807846;
            public const int TorrentialTribute = 53582587;
            public const int XMd = 83965310;
            public const int Jncq = 82732705;
            public const int Qianyuzhihu = 67169062;
            public const int Yuchunmaizhang = 81439173;



        }

        public GDExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            //这个固定格式
            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);

            AddExecutor(ExecutorType.Activate, CardId.Yumaosao, YumaosaoActive);
            AddExecutor(ExecutorType.SpellSet, CardId.Yumaosao);
            AddExecutor(ExecutorType.Activate, CardId.Leiji, DefaultDarkHole);
            AddExecutor(ExecutorType.SpellSet, CardId.Leiji);
            AddExecutor(ExecutorType.Activate, CardId.Yuchunmaizhang, yu2chun3de5di4di2mai2man2zang4_81439173Activate);
            AddExecutor(ExecutorType.SpellSet, CardId.Yuchunmaizhang);
            AddExecutor(ExecutorType.Activate, CardId.Taiyangjiaohuan);
            AddExecutor(ExecutorType.SpellSet, CardId.Taiyangjiaohuan);
            AddExecutor(ExecutorType.Activate, CardId.Honest, DefaultHonestEffect);
            AddExecutor(ExecutorType.SummonOrSet, CardId.Honest, HonestSummon);
            //裁决之龙使用技能的条件 
            AddExecutor(ExecutorType.Activate, CardId.Caijuezhilong, CaijuezhilongActive);
            //裁决之龙的召唤的条件,是特殊召唤
            AddExecutor(ExecutorType.SpSummon, CardId.Caijuezhilong,CaijuezhilongSpSummon);
            AddExecutor(ExecutorType.Summon, CardId.Luominasi);
            AddExecutor(ExecutorType.Activate, CardId.Luominasi, DefaultCallOfTheHaunted1);
            AddExecutor(ExecutorType.Summon, CardId.Lila);
            AddExecutor(ExecutorType.Activate, CardId.Lila, Lilaeffect);
            AddExecutor(ExecutorType.Summon, CardId.Jian);
            AddExecutor(ExecutorType.Summon, CardId.Ailin);
            AddExecutor(ExecutorType.Activate, CardId.Ailin);
            AddExecutor(ExecutorType.Summon, CardId.Jilubo);
            AddExecutor(ExecutorType.Activate, CardId.Jilubo);
            AddExecutor(ExecutorType.Summon, CardId.Gelagulishi);
            AddExecutor(ExecutorType.Activate, CardId.Sizhezhuansheng, Szzseffect);
            AddExecutor(ExecutorType.SpellSet, CardId.Sizhezhuansheng);
            AddExecutor(ExecutorType.Activate, CardId.MirrorForce, DefaultTrap);
            AddExecutor(ExecutorType.Activate, CardId.Shanguanghuanxiang, SGHXeffect);
            AddExecutor(ExecutorType.MonsterSet, CardId.Xiaolizi);

            AddExecutor(ExecutorType.Summon, CardId.Jaluoshi);
            AddExecutor(ExecutorType.Activate, CardId.Jaluoshi);
            AddExecutor(ExecutorType.Summon, CardId.Csyuyanzhe);
            AddExecutor(ExecutorType.Activate, CardId.Csyuyanzhe);

            AddExecutor(ExecutorType.Summon, CardId.Woerfu);



            AddExecutor(ExecutorType.Summon, CardId.Ciyuanzhanshi);
            AddExecutor(ExecutorType.Activate, CardId.Ciyuanzhanshi,CiyuzhanshiEffect);

            AddExecutor(ExecutorType.MonsterSet, CardId.Liequanleiguang);
            AddExecutor(ExecutorType.Activate, CardId.Liequanleiguang, Liequaneffect);

            


            AddExecutor(ExecutorType.Activate, CardId.MonsterReborn, DefaultCallOfTheHaunted);
            AddExecutor(ExecutorType.SpellSet, CardId.MonsterReborn);




            AddExecutor(ExecutorType.Activate, CardId.ReinforcementOfTheArmy, ReinforcementOfTheArmyEffect);
            AddExecutor(ExecutorType.Activate, CardId.TorrentialTribute, DefaultTorrentialTribute);
            AddExecutor(ExecutorType.Activate, CardId.Qianyuzhihu, DefaultCallOfTheHaunted1);
            AddExecutor(ExecutorType.SpellSet, CardId.Qianyuzhihu);

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
            if (Bot.HasInMonstersZone(CardId.Ailin) && Enemy.HasDefendingMonster())
                return AI.Attack(attacker, attacker);
            foreach (ClientCard card in Enemy.GetMonsters())
            {
                if (Bot.HasInMonstersZone(CardId.Jian) && card.IsAttack() && card.Attack <= 2099)
                {
                    return AI.Attack(attacker, attacker);
                }
            }
            return null;
        }


        //裁决之龙的召唤
        private bool CaijuezhilongSpSummon()
        {
            //如果场上有一只以上了,就别召唤了，容易翻车
            if(Bot.MonsterZone.GetCardCount(CardId.Caijuezhilong) >= 1)
            {
                return false;
            }

            //召唤
            return true;
        }

        //发动裁决之龙的条件
        private bool CaijuezhilongActive()
        {
            //对面有一个nb的怪,炸
            if (Enemy.SpellZone.GetCardCount(CardId.Jncq) >= 1)
            {
                return false;
            }
            if (Enemy.MonsterZone.GetCardCount(CardId.XMd) >= 1)
            {
                return false;
            }
            if (Enemy.GetMonsterCount() >= 1)
            {
                return true;
            }
            //如果对面魔法区域1张盖卡一张，炸
            if (Enemy.GetSpellCount() >= 1)
            {
                return true;
            }
            //别炸
            return false;
        }
        private bool yu2chun3de5di4di2mai2man2zang4_81439173Activate()
        {
            IList<int> SelectedCard = new List<int>();
            SelectedCard.Add(CardId.Woerfu);
            SelectedCard.Add(CardId.Luominasi);
            SelectedCard.Add(CardId.Gelagulishi);
            SelectedCard.Add(CardId.Jian);
            SelectedCard.Add(CardId.Lila);
            AI.SelectCard(SelectedCard);
            return true;
        }

        private bool Ailinatteck()
        {
            ClientCard monster = Enemy.GetMonsters().GetHighestDefenseMonster(true);

            if (monster != null)
            {
                return true;
            }

            //召唤
            return false;
        }

        private bool SGHXeffect()
        {
            List<ClientCard> spells = Bot.GetSpells();
            foreach (ClientCard spell in spells)
            {
                if (spell.IsCode(CardId.Shanguanghuanxiang) && !spell.IsFacedown())
                    return false;
            }

            IList<int> targets = new[]
                   {
                    CardId.Gelagulishi,
                    CardId.Jilubo,
                    CardId.Woerfu,
                    CardId.Jian,
                    CardId.Luominasi,
                    CardId.Lila,

                    };
            if (Bot.HasInGraveyard(targets))
            {
                AI.SelectCard(targets);
                return true;
            }
            return false;
        }
        private bool Lilaeffect()
        {
            
            if (Enemy.SpellZone.GetCardCount(CardId.Jncq) >= 1)
            {
                return false;
            }
            if (Enemy.MonsterZone.GetCardCount(CardId.XMd) >= 1)
            {
                return false;
            }
            //如果对面魔法区域1张盖卡一张，炸
            if (Enemy.GetSpellCount() >= 1)
            {
                return true;
            }
            //别炸
            return false;
        }

        private bool HonestSummon()
        {
            //如果场上有一只以上了,就别召唤了，容易翻车
            if (Bot.GetHandCount() <= 1 && Bot.GetMonsterCount() < 1)
            {
                return true;
            }

            //召唤
            return false;
        }

        private bool Szzseffect()
        {
            IList<int> targets = new[] 
                   {
                    CardId.Caijuezhilong,
                    CardId.Csyuyanzhe,
                    };
            if (Bot.HasInGraveyard(targets))
            {
                AI.SelectCard(targets);
                return true;
            }
            return false;
        }

        protected bool Liequaneffect()
        {

            ClientCard target = Util.GetBestEnemyMonster() ;
            if (target != null)
            {
                AI.SelectCard(1);
                AI.SelectNextCard(target);
                return true;
            }
            return false;
        }
        //发动羽毛扫的条件
        private bool YumaosaoActive()
        {
            //如果对面魔法区域1张盖卡一张，炸
            if (Enemy.GetSpellCount() >= 1)
            {
                return true;
            }
            //别炸
            return false;
        }

        private bool HiddenTemplesOfNecrovalleyEffect()
        {
            //如果在手卡,而且有魔法区域
            if (Card.Location == CardLocation.Hand && Bot.HasInSpellZone((int)Card.Id))
                return false;
            return true;
        }

        private bool NecrovalleyActivate()
        {
            //如果有永续魔法区域
            if (Bot.SpellZone[5] != null)
                return false;
            return true;
        }
        private bool ReinforcementOfTheArmyEffect()
        {
            if (!Bot.HasInHand(CardId.Ciyuanzhanshi))
            {
                AI.SelectCard(CardId.Ailin);
                return true;
            }
            else if (!Bot.HasInHand(CardId.Ailin))
            {
                AI.SelectCard(CardId.Ciyuanzhanshi);
                return true;
            }
            else if (!Bot.HasInHand(CardId.Jian))
            {
                AI.SelectCard(CardId.Ciyuanzhanshi);
                return true;
            }
            else if (!Bot.HasInHand(CardId.Jaluoshi))
            {
                return true;
            }
            AI.SelectCard(CardId.Ciyuanzhanshi);
            return true;
        }
        private bool CiyuzhanshiEffect()
        {

            if (Util.IsOneEnemyBetter())

            {
                return true;
            }

            return false;
        }
        private bool MaleficStardustDragonSummon()
        {
            //如果有魔法区域
            if (Bot.SpellZone[5] != null)
                return true;
            return false;
        }

    }
}
