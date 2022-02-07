using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("Operator", "AI_Operator")]
    public class OperatorExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int 深海衍生物 = 79029101;
            public const int 无人机衍生物 = 79029029;
            public const int 磐蟹衍生物 = 79029377;

            public const int 杰西卡 = 79029045;
            public const int 自爆小车 = 79029360;
            public const int 风笛 = 79029466;
            public const int 香草 = 79029046;
            public const int 芙兰卡BPRS = 79029902;
            public const int 近卫小车 = 79029174;
            public const int 卡夫卡 = 79029374;
            public const int 芬 = 79029151;
            public const int 桃金娘 = 79029140;
            public const int 幽灵鲨 = 79029085;
            public const int 红 = 79029038;

            public const int 行动霓虹 = 79029031;
            public const int 行动灰烬 = 79029220;
            public const int 行动领点占据 = 79029219;
            public const int 行动目标护送 = 79029042;
            public const int 行动防线突破 = 79029047;
            public const int 行动拟真模拟 = 79029451;
            public const int 行动战术指导 = 79029253;
            public const int 行动潮汐守望 = 79029461;
            public const int 行动青色怒火 = 79029479;
            public const int 行动双龙出鞘 = 79029482;
            public const int 行动分头行动 = 79029057;
            public const int 部署精锐救援 = 79029354;
            public const int 据点重工基地 = 79029223;
            public const int 据点阿戈尔遗迹 = 79029100;

            public const int 燃灰杰西卡 = 79029258;
            public const int 铝热剑芙兰卡 = 79029437;
            public const int 卡缇 = 79029164;
            public const int 松果 = 79029364;
            public const int 暗锁 = 79029032;
            public const int 临光 = 79029097;
            public const int 近卫阿米娅 = 79029359;
            public const int stormeye = 79029318;
            public const int 推进之王跃空锤 = 79029225;
            public const int 星熊 = 79029061;
            public const int 陈绝影 = 79029480;
            public const int 珂克可 = 79029292;

            public const int 电脑网挖矿 = 57160136;
            public const int SolemnStrike = 40605147;
            public const int Impermanence = 10045474;
            public const int AshBlossom = 14558127;
        }
        List<int> normal_counter = new List<int>
        {
            53262004, 98338152, 32617464, 45041488, CardId.SolemnStrike,
            61257789, 23440231, 27354732, 12408276, 82419869, CardId.Impermanence,
            49680980, 18621798, 38814750, 17266660, 94689635,CardId.AshBlossom,
            74762582, 75286651, 4810828,  44665365, 21123811, _CardId.CrystalWingSynchroDragon,
            82044279, 82044280, 79606837, 10443957, 1621413,
            90809975, 8165596,  9753964,  53347303, 88307361, _CardId.GamecieltheSeaTurtleKaiju,
            5818294,  2948263,  6150044,  26268488, 51447164, _CardId.JizukirutheStarDestroyingKaiju,
            97268402
        };

        List<int> should_not_negate = new List<int>
        {
            81275020, 28985331
        };

        private int RockCount = 0;

        public OperatorExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            AddExecutor(ExecutorType.Activate, CardId.电脑网挖矿, 电脑网挖矿检索);
            AddExecutor(ExecutorType.Summon, CardId.杰西卡, 通招杰西卡);
            AddExecutor(ExecutorType.Activate, CardId.杰西卡, 杰西卡1效特招);
            AddExecutor(ExecutorType.SpSummon, CardId.燃灰杰西卡, 燃灰杰西卡同调);
            AddExecutor(ExecutorType.Activate, CardId.燃灰杰西卡, 燃灰杰西卡1效堆墓检索);
            AddExecutor(ExecutorType.Activate, CardId.香草, 香草2效除外);
            AddExecutor(ExecutorType.Activate, CardId.行动霓虹, 行动霓虹2效苏生);
            AddExecutor(ExecutorType.SpSummon, CardId.铝热剑芙兰卡, 铝热剑芙兰卡同调);
            AddExecutor(ExecutorType.Activate, CardId.行动领点占据, 行动领点占据2效堆墓);
            AddExecutor(ExecutorType.Activate, CardId.铝热剑芙兰卡, 铝热剑芙兰卡1效堆墓检索);
            AddExecutor(ExecutorType.Activate, CardId.行动防线突破, 行动防线突破1效2效);
            AddExecutor(ExecutorType.Activate, CardId.行动拟真模拟, 行动拟真模拟2效苏生);
            AddExecutor(ExecutorType.Activate, CardId.芙兰卡BPRS, 芙兰卡BPRS1效特招);
            AddExecutor(ExecutorType.Activate, CardId.芙兰卡BPRS, 芙兰卡BPRS2效检索或堆墓);
            AddExecutor(ExecutorType.SpSummon, CardId.芬, 芬特招);
            AddExecutor(ExecutorType.SpSummon, CardId.stormeye, stormeye同调);
            AddExecutor(ExecutorType.SpSummon, CardId.卡缇, 卡缇link召唤);
            AddExecutor(ExecutorType.Activate, CardId.卡缇, 卡缇1效检索); 
            AddExecutor(ExecutorType.Activate, CardId.据点重工基地, 据点重工基地发动和1效掷骰子);
            AddExecutor(ExecutorType.SpSummon, CardId.松果, 松果link召唤);
            AddExecutor(ExecutorType.Activate, CardId.松果, 松果1效检索2效放置);
            AddExecutor(ExecutorType.Activate, CardId.据点阿戈尔遗迹, 据点阿戈尔遗迹3效token);
            AddExecutor(ExecutorType.SpSummon, CardId.临光, 临光link召唤);
            AddExecutor(ExecutorType.Activate, CardId.临光, 临光1效苏生);
            AddExecutor(ExecutorType.SpSummon, CardId.近卫阿米娅, 近卫阿米娅link召唤);
            AddExecutor(ExecutorType.Activate, CardId.近卫阿米娅, 近卫阿米娅2效3效);
            AddExecutor(ExecutorType.Activate, CardId.行动青色怒火, 行动青色怒火效果);
            AddExecutor(ExecutorType.Summon, CardId.风笛, 通招风笛);
            AddExecutor(ExecutorType.Activate, CardId.风笛, 风笛1效2效);
            AddExecutor(ExecutorType.SpSummon, CardId.推进之王跃空锤, 推进之王跃空锤超量);
            AddExecutor(ExecutorType.Activate, CardId.推进之王跃空锤, 推进之王跃空锤效果);
            AddExecutor(ExecutorType.Summon, CardId.幽灵鲨, 通招幽灵鲨);
            AddExecutor(ExecutorType.Activate, CardId.幽灵鲨, 幽灵鲨效果);
            AddExecutor(ExecutorType.Summon, CardId.自爆小车, 通招自爆小车);
            AddExecutor(ExecutorType.Activate, CardId.自爆小车, 自爆小车效果);
            AddExecutor(ExecutorType.Activate, CardId.行动分头行动, 行动分头行动效果);
            AddExecutor(ExecutorType.Activate, CardId.行动潮汐守望, 行动潮汐守望效果);
            AddExecutor(ExecutorType.SpSummon, CardId.暗锁, 暗锁link召唤);
            AddExecutor(ExecutorType.SpSummon, CardId.星熊, 星熊超量);
            AddExecutor(ExecutorType.Activate, CardId.星熊, 星熊效果);
            AddExecutor(ExecutorType.Activate, CardId.stormeye, stormeye效果);
            AddExecutor(ExecutorType.Activate, CardId.行动目标护送, 行动目标护送2效);
            AddExecutor(ExecutorType.Activate, CardId.红, 红效果);
            AddExecutor(ExecutorType.Activate, CardId.陈绝影, 陈绝影效果);
            AddExecutor(ExecutorType.Summon, CardId.香草, 通招香草);
            AddExecutor(ExecutorType.SpSummon, CardId.珂克可, 珂克可link召唤);
            AddExecutor(ExecutorType.SpSummon, CardId.珂克可, 珂克可效果);
            AddExecutor(ExecutorType.Repos, MonsterRepos);
            AddExecutor(ExecutorType.SpellSet, CardId.行动领点占据, 行动领点占据盖放);
            AddExecutor(ExecutorType.Activate, CardId.行动领点占据, 行动领点占据1效);
            AddExecutor(ExecutorType.MonsterSet, MonsterSet);
        }
        private bool NormalSummoned = false;
        private bool 杰西卡1效已发动 = false;
        private bool 卡缇1效已发动 = false;
        private bool 松果1效已发动 = false;
        private bool 松果2效已发动 = false;
        private bool 松果3效已发动 = false;
        private bool 临光1效已发动 = false;
        private bool 风笛1效已发动 = false;
        private bool 近卫阿米娅3效已发动 = false;
        private bool 近卫阿米娅3效适用 = false;
        private bool 燃灰杰西卡已同调 = false;
        private bool 铝热剑芙兰卡已同调 = false;
        private bool stormeye已同调 = false;
        private bool 推进之王跃空锤已超量 = false;


        public override void OnNewTurn()
        {
            NormalSummoned = false;
            杰西卡1效已发动 = false;
            卡缇1效已发动 = false;
            松果1效已发动 = false;
            松果2效已发动 = false;
            松果3效已发动 = false;
            临光1效已发动 = false;
            风笛1效已发动 = false;
            近卫阿米娅3效已发动 = false;
            近卫阿米娅3效适用 = false;
            燃灰杰西卡已同调 = false;
            铝热剑芙兰卡已同调 = false;
            stormeye已同调 = false;
            推进之王跃空锤已超量 = false;

        }
        public bool MonsterRepos()
        {
            if (Card.Attack == 0) return (Card.IsAttack());

            if (Card.IsFacedown())
                return true;

            bool enemyBetter = Util.IsAllEnemyBetter(true);
            if (Card.IsAttack() && enemyBetter)
                return true;
            if (Card.IsDefense() && !enemyBetter)
                return true;
            return false;
        }
        private bool 通招杰西卡()
        {
            NormalSummoned = true;
            return true;
        }
        private bool 通招风笛()
        {
            NormalSummoned = true;
            return true;
        }
        private bool 通招幽灵鲨()
        {
            NormalSummoned = true;
            return true;
        }
        private bool 通招自爆小车()
        {
            NormalSummoned = true;
            return true;
        }
        private bool 通招香草()
        {
            NormalSummoned = true;
            return true;
        }
        private bool 燃灰杰西卡同调()
        {
            if (Duel.Phase == DuelPhase.Main1)
            {
               return true;
            }
            if (Duel.Phase == DuelPhase.Main2)
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            return false;
        }
        private bool 铝热剑芙兰卡同调()
        {
            if (铝热剑芙兰卡已同调 == true) 
            {
                return false;
            }
            else
            {
                铝热剑芙兰卡已同调 = true;
                    return true;
            }
        }
        private bool stormeye同调()
        {
            if (stormeye已同调 == true)
            {
                return false;
            }
            else
            {
                stormeye已同调 = true;
                return true;
            }
        }
        private bool 芬特招()
        {
                return true;
        }
        private bool 推进之王跃空锤超量()
        {
            if (推进之王跃空锤已超量 == true)
            {
                return false;
            }
            else if (Bot.HasInMonstersZone(CardId.卡缇) || Bot.HasInMonstersZone(CardId.松果))
            {
                AI.SelectMaterials(new List<int>() {
                        CardId.卡缇,
                        CardId.松果
                    });
                推进之王跃空锤已超量 = true;
                return true;
            }
            return false;
        }
        private bool 星熊超量()
        {
            if (Bot.HasInMonstersZone(CardId.暗锁))
            {
                AI.SelectMaterials(new List<int>() {
                        CardId.暗锁
                });
                return true;
            }
            return false;
        }
        private bool 卡缇link召唤()
        {
            if (卡缇1效已发动 == true)
            {
                return false;
            }
            else if (Bot.HasInMonstersZone(CardId.杰西卡) || Bot.HasInMonstersZone(CardId.香草) || Bot.HasInMonstersZone(CardId.自爆小车) || Bot.HasInMonstersZone(CardId.芬))
            {
                AI.SelectMaterials(new List<int>() {
                        CardId.杰西卡,
                        CardId.香草,
                        CardId.自爆小车,
                        CardId.芬
                    });
                return true;
            }
            return false;
        }
        private bool 松果link召唤()
        {
            if (松果1效已发动 == true)
            {
                return false;
            }
            else if (Bot.HasInMonstersZone(CardId.杰西卡) || Bot.HasInMonstersZone(CardId.香草) || Bot.HasInMonstersZone(CardId.自爆小车) || Bot.HasInMonstersZone(CardId.芬) || Bot.HasInMonstersZone(CardId.卡缇))
            {
                AI.SelectMaterials(new List<int>() {
                        CardId.卡缇,
                        CardId.杰西卡,
                        CardId.香草,
                        CardId.自爆小车,
                        CardId.芬
                    });
                return true;
            }
            return false;
        }
        private bool 暗锁link召唤()
        {
            if (Bot.HasInMonstersZone(CardId.幽灵鲨))
            {
                AI.SelectMaterials(new List<int>() {
                        CardId.幽灵鲨
                });
                return true;
            }
            return false;
        }
        private bool 临光link召唤()
        {
            if (临光1效已发动 == true)
            {
                return false;
            }
            else if (Bot.HasInMonstersZone(CardId.深海衍生物) || Bot.HasInMonstersZone(CardId.杰西卡) || Bot.HasInMonstersZone(CardId.香草) || Bot.HasInMonstersZone(CardId.自爆小车) || Bot.HasInMonstersZone(CardId.芬) || Bot.HasInMonstersZone(CardId.卡缇) || Bot.HasInMonstersZone(CardId.松果))
            {
                AI.SelectMaterials(new List<int>() {
                        CardId.深海衍生物,
                        CardId.松果,
                        CardId.卡缇,
                        CardId.杰西卡,
                        CardId.香草,
                        CardId.自爆小车,
                        CardId.芬
                    });
                return true;
            }
            return false;
        }
        private bool 珂克可link召唤()
        {
            if (Bot.HasInMonstersZone(CardId.杰西卡) && Bot.HasInMonstersZone(CardId.香草))
            {
                AI.SelectMaterials(new List<int>() {
                        CardId.临光,
                        CardId.深海衍生物,
                        CardId.松果,
                        CardId.卡缇,
                        CardId.杰西卡,
                        CardId.香草,
                        CardId.自爆小车,
                        CardId.芬,
                        CardId.星熊
                    });
                return true;
            }
            return false;
        }
        private bool 近卫阿米娅link召唤()
        {
            if (近卫阿米娅3效已发动 == true)
            {
                return false;
            }
            else
            {
                AI.SelectMaterials(new List<int>() {
                        CardId.深海衍生物,
                        CardId.临光,
                        CardId.松果,
                        CardId.卡缇,
                        CardId.杰西卡,
                        CardId.香草,
                        CardId.自爆小车,
                        CardId.风笛,
                        CardId.芬
                    });
                return true;
            }
        }
        private bool 杰西卡1效特招()
        {
            杰西卡1效已发动 = true;
            if (Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.行动领点占据);
                AI.SelectNextCard(CardId.香草);
                AI.SelectPosition(CardPosition.FaceUpDefence);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool 电脑网挖矿检索()
        {
            AI.SelectCard(CardId.行动霓虹,
                CardId.行动拟真模拟,
                CardId.据点阿戈尔遗迹
                );
            AI.SelectNextCard(CardId.杰西卡,
                CardId.风笛,
                CardId.香草,
                CardId.自爆小车,
                CardId.芬
                );
            return true;
        }
        private bool 燃灰杰西卡1效堆墓检索()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.行动霓虹);
                AI.SelectNextCard(CardId.芙兰卡BPRS);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool 香草2效除外()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.行动目标护送);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool 行动领点占据2效堆墓()
        {
            if (Card.Location == CardLocation.Removed)
            {
                AI.SelectCard(
                    CardId.行动防线突破,
                    CardId.行动霓虹
                    );
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool 行动霓虹2效苏生()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(
                    CardId.铝热剑芙兰卡,
                    CardId.香草,
                    CardId.燃灰杰西卡
                    );
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool 铝热剑芙兰卡1效堆墓检索()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.行动霓虹);
                AI.SelectNextCard(CardId.行动拟真模拟);
                AI.SelectOption(1);
                return true;
            }
            else
            {
                return true;
            }
        }
        private bool 行动防线突破1效2效()
        {
            if (Card.Location == CardLocation.Grave)
            {
                return true;
            }
            else if (Card.Location == CardLocation.SpellZone)
            {
                if (近卫阿米娅3效适用 == true && Duel.LastChainPlayer == 1)
                {
                    return true;
                }
                else if (近卫阿米娅3效适用 == false)
                {
                    近卫阿米娅3效适用 = true;
                    return false;
                } 
            }
            return false;
        }
        private bool 行动拟真模拟2效苏生()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.燃灰杰西卡);
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool 芙兰卡BPRS1效特招()
        {
            if (Card.Location == CardLocation.Hand)
            {
                AI.SelectCard(CardId.行动霓虹);
                AI.SelectCard(CardId.行动目标护送);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool 芙兰卡BPRS2效检索或堆墓()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.行动霓虹);
                var x = ActivateDescription;
                if (ActivateDescription == Util.GetStringId(CardId.芙兰卡BPRS, 1) || ActivateDescription == 1)
                    AI.SelectOption(1);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool 卡缇1效检索()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                卡缇1效已发动 = true;
                AI.SelectCard(CardId.据点重工基地);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool 据点重工基地发动和1效掷骰子()
        {
            if (Card.Location == CardLocation.FieldZone)
            {
                AI.SelectCard(
                        CardId.行动战术指导,
                        CardId.行动潮汐守望,
                        CardId.部署精锐救援,
                        CardId.卡夫卡,
                        CardId.自爆小车
                        );
                return true;
            }
            else
            {
                return true;
            }
        }
        private bool 松果1效检索2效放置()
        {
            if (Card.Location == CardLocation.MonsterZone && 松果1效已发动 == false)
            {
                松果1效已发动 = true;
                int target = 松果1效检索判定();
                if (target > 0)
                    AI.SelectCard(target);
                else
                    AI.SelectCard(
                    CardId.据点阿戈尔遗迹,
                    CardId.据点重工基地
                    );
                return true;
            }
            else if (Card.Location == CardLocation.Grave && 松果2效已发动 == false)
            {
                松果2效已发动 = true;
                return true;
            }
            else if (Card.Location == CardLocation.MonsterZone && Bot.HasInHand(CardId.据点阿戈尔遗迹) && 松果3效已发动 == false)
            {
                AI.SelectCard(CardId.据点阿戈尔遗迹);
            }
            return false;
        }
        private int 松果1效检索判定()
        {
            if (!Bot.HasInSpellZone(CardId.据点重工基地) && !Bot.HasInHand(CardId.据点重工基地) )
            {
                return CardId.据点重工基地;
            }
            else 
            {
                return CardId.据点阿戈尔遗迹;
            }

        }
        private bool 据点阿戈尔遗迹3效token()
        {
            if (Card.Location == CardLocation.SpellZone)
            {
                AI.SelectCard(
                        CardId.行动潮汐守望,
                        CardId.幽灵鲨
                        );
                return true;
            }
                return false;
        }
        private bool 临光1效苏生()
        {
            if (Bot.HasInGraveyard(CardId.杰西卡))
            {
                临光1效已发动 = true;
                AI.SelectCard(CardId.杰西卡);
                return true;
            }
            else if (Bot.HasInGraveyard(CardId.香草))
            {
                临光1效已发动 = true;
                AI.SelectCard(CardId.香草);
                return true;
            }
            else if (Bot.HasInGraveyard(CardId.风笛))
            {
                临光1效已发动 = true;
                AI.SelectCard(CardId.风笛);
                return true;
            }
            else if (Bot.HasInGraveyard(CardId.香草))
            {
                临光1效已发动 = true;
                AI.SelectCard(CardId.香草);
                return true;
            }
            else if (Bot.HasInGraveyard(CardId.自爆小车))
            {
                临光1效已发动 = true;
                AI.SelectCard(CardId.自爆小车);
                return true;
            }
            else if (Bot.HasInGraveyard(CardId.红))
            {
                临光1效已发动 = true;
                AI.SelectCard(CardId.红);
                return true;
            }
            else if (Bot.HasInGraveyard(CardId.芬))
            {
                临光1效已发动 = true;
                AI.SelectCard(CardId.芬);
                return true;
            }
            else
            {
                临光1效已发动 = true;
                return true;
            }
        }
        private bool 近卫阿米娅2效3效()
        {
            if (近卫阿米娅3效已发动 == false)
            {
             近卫阿米娅3效已发动 = true;
              return true;
            }
            else if (Duel.CurrentChain.Count != 0 && Duel.Player == 1)
            {
                近卫阿米娅3效适用 = true;
                return true;
            }
              return false;
        }
        private bool 风笛1效2效()
        {
            if (风笛1效已发动 == false)
            {
                风笛1效已发动 = true;
                AI.SelectNumber(8); 
                return true;
            }
            else if (风笛1效已发动 == true || Bot.HasInHand(CardId.桃金娘))
            {
                AI.SelectCard(CardId.行动霓虹,
                CardId.行动拟真模拟,
                CardId.据点阿戈尔遗迹
                );
                AI.SelectNextCard(CardId.芬,
                CardId.风笛
                );
                return true;
            }
            return false;
        }
        private bool 推进之王跃空锤效果()
        {
            AI.SelectCard(CardId.行动青色怒火,
            CardId.行动分头行动,
            CardId.行动潮汐守望
            );
            return true;
        }
        private bool 行动分头行动效果()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.行动青色怒火,
            CardId.行动潮汐守望);
                return true;
            }
            else if (Card.Location == CardLocation.Hand && Bot.HasInMonstersZone(CardId.近卫阿米娅) && Bot.HasInMonstersZone(CardId.陈绝影))
            {
                AI.SelectCard(CardId.近卫阿米娅);
                return true;
            }
                return false;
        }
        private bool 行动潮汐守望效果()
        {
            AI.SelectCard(CardId.幽灵鲨,
            CardId.据点阿戈尔遗迹);
            return true;
        }
        private bool 自爆小车效果()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.红);
                return true;
            }
            else if (Card.Location == CardLocation.Hand && (Bot.HasInHand(CardId.杰西卡) || Bot.HasInHand(CardId.香草) || Bot.HasInHand(CardId.自爆小车)))
            {
                ClientCard target = Util.GetProblematicEnemyMonster(Card.GetDefensePower());
                if (target != null)
                {
                    AI.SelectCard(
                        CardId.自爆小车,
                        CardId.香草,
                        CardId.杰西卡
                        );
                    AI.SelectNextCard(target);
                    return true;
                }
            }
            return false;
        }
        private bool 幽灵鲨效果()
        {
            return true;
        }
        private bool 行动青色怒火效果()
        {
            if (Bot.HasInMonstersZone(CardId.近卫阿米娅) && Bot.HasInExtra(CardId.陈绝影))
            { 
             AI.SelectCard(CardId.陈绝影);
            return true;
            }
            else if (Duel.LastChainPlayer == 1)
            {
                return true;
            }
            return false;
        }
        private bool 星熊效果()
        {
            if (Duel.Turn != 1 && Duel.Player == 0)
            {
                return true;
            }
            else if (Duel.Player ==1 && Duel.Phase == DuelPhase.Battle)
            {
                return true;
            }
            return false;
        }
        private bool stormeye效果()
        {
                return true;
        }
        private bool 行动目标护送2效()
        {
            if (Duel.Phase == DuelPhase.End)
            {
                AI.SelectCard(
                    CardId.芙兰卡BPRS,
                    CardId.暗锁,
                    CardId.自爆小车,
                    CardId.芬,
                    CardId.红,
                    CardId.香草
                    );
                return true;
            }
            return false;
        }
        private bool 红效果()
        {
            if (近卫阿米娅3效适用 == true && Duel.LastChainPlayer == 1)
            {
                return true;
            }
            else if (近卫阿米娅3效适用 == false)
            {
                近卫阿米娅3效适用 = true;
                return false;
            }
            return false;
        }
        private bool 陈绝影效果()
        {
            if (Bot.HasInBanished(CardId.近卫阿米娅))
            {
                AI.SelectCard(CardId.陈绝影);
                return true;
            }
            else if (Duel.LastChainPlayer == 1 && Duel.Player == 1)
            {
                return true;
            }
            return false;
        }
        public bool MonsterSet()
        {
            if (Util.GetOneEnemyBetterThanMyBest() == null && Bot.GetMonsterCount() > 0) return false;
            if (Card.Level > 4) return false;
            int rest_lp = Bot.LifePoints;
            int count = Bot.GetMonsterCount();
            List<ClientCard> list = Enemy.GetMonsters();
            list.Sort(CardContainer.CompareCardAttack);
            foreach (ClientCard card in list)
            {
                if (!card.HasPosition(CardPosition.Attack)) continue;
                if (count-- > 0) continue;
                rest_lp -= card.Attack;
            }
            if (rest_lp < 1700)
            {
                AI.SelectPosition(CardPosition.FaceDownDefence);
                return true;
            }
            return false;
        }
        private bool 行动领点占据盖放()
        {
            if (Duel.Turn == 1 || Duel.Phase == DuelPhase.Main2)
            {
                return true;
            }
            return false;
        }
        private bool 行动领点占据1效()
        {
            if (Card.Location == CardLocation.SpellZone)
            {
                AI.SelectCard(
                    CardId.陈绝影,
                    CardId.近卫阿米娅,
                    CardId.星熊,
                    CardId.临光
                    );
                return true;
            }
            return false;
        }
        public bool 珂克可效果()
        {
            return true;
        }
    }
}



