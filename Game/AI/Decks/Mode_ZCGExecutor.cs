using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using System.Linq;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
namespace WindBot.Game.AI.Decks
{
    //77238102
    [Deck("Mode", "AI_Mode")]
    class Mode_ZCGExecutor : DefaultExecutor
    {
        //77238051
        public Mode_ZCGExecutor(GameAI ai, Duel duel)
         : base(ai, duel)
        {
            AddExecutor(ExecutorType.Activate, _Activate_1);
            AddExecutor(ExecutorType.Activate, _Activate_2);
            AddExecutor(ExecutorType.Activate, _Activate_3);
            AddExecutor(ExecutorType.SpSummon, _SpSummon_1);
            AddExecutor(ExecutorType.SpSummon, _SpSummon_2);
            AddExecutor(ExecutorType.SpSummon, _SpSummon_3);
            AddExecutor(ExecutorType.MonsterSet, _MonsterSet_1);
            AddExecutor(ExecutorType.MonsterSet, _MonsterSet_2);
            AddExecutor(ExecutorType.MonsterSet, _MonsterSet_3);
            AddExecutor(ExecutorType.Summon, _Summon_1);
            AddExecutor(ExecutorType.Summon, _Summon_2);
            AddExecutor(ExecutorType.Summon, _Summon_3);
            AddExecutor(ExecutorType.SpellSet, _SpellSet_1);
            AddExecutor(ExecutorType.SpellSet, _SpellSet_2);
            AddExecutor(ExecutorType.SpellSet, _SpellSet_3);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
        }
        private enum State
        {
            All = 0x00,
            Spsummon = 0x02,
            Summon = 0x04,
            Remove = 0x08,
            Destory = 0x10,
            EffectRelease = 0x20,//效果解放
            SendToGrave = 0x40,
            SendToHand = 0x80,
            SendToDeck = 0x100,
            Control = 0x200,
            Equip = 0x400,
            Rule = 0x800,
            DisCard = 0x1000,
            MonsterRelease = 0x2000,//祭品解放
            MoveToField = 0x4000,
        }
        private bool isOnState(State state)
        {
            return state == State.Spsummon
            || state == State.Summon || state == State.Equip
            || state == State.MoveToField;
        }
        State state = 0;
        State state_2 = 0;
        CardLocation toLoc = 0;
        CardLocation toLoc_2 = 0;
        CardLocation selectZone = 0;//表示效果所选择卡片的位置
        CardLocation selectZone_2 = 0;//表示效果所选择卡片的位置
        int player = 0;//表示选择的玩家区域
        int player_2 = 0;
        bool tg = false;//表示是否可以选择为效果对象
        bool tg_2 = false;
        int toplayer = 0;//表示回到的玩家区域（比如牛对面的卡片效果）
        int toplayer_2 = 0;
        bool isSelect = false;
        bool isSelect_2 = false;
        /*
         * 为0表示是自己场上所选择的最高优先级，为1表示为对方控制时所选的最高优先级，
         * 这里的优先级卡片表示的是全部区域最高优先级
         */
        List<int> best_spsummon_cardsid_0 = new List<int>()
        {
            77238026,77238043,77238044,77238029
        };
        List<int> best_summon_cardsid_0 = new List<int>()
        {
            77238051
        };
        List<int> best_remove_cardsid_0 = new List<int>()
        {
            77238028 , 77238030,77238048,77238049,77238054,77238066,77238067
        };
        List<int> best_destory_cardsid_0 = new List<int>()
        {
            77238062,77238028 , 77238030,77238048,77238049,77238054,77238060,77238066
            ,77238067
        };
        List<int> best_effect_release_cardsid_0 = new List<int>()
        {
            77238028,77238048,77238049,77238054,77238060,77238067
        };
        List<int> best_monster_release_cardsid_0 = new List<int>()
        {
            77238067
        };
        List<int> best_sendtograve_cardsid_0 = new List<int>() {
         77238012,77238000,77238017,77238018,77238019,77238028,77238030,77238044
            ,77238048,77238049,77238060,77238066,77238067

        };
        List<int> best_sendtohand_cardsid_0 = new List<int>()
        {
            77238063,77238026,77238014, 77238021, 77238020,77238033,77238034,77238042,77238045
            ,77238047,77238049,77238057,77238062,77238064
        };
        List<int> best_sendtodeck_cardsid_0 = new List<int>()
        {
            77238066,77238067
        };
        List<int> best_control_cardsid_0 = new List<int>()
        {
        };
        List<int> best_equip_cardsid_0 = new List<int>()
        {
            77238029,77238031
        };
        List<int> best_rule_cardsid_0 = new List<int>()
        {
        };
        List<int> best_discard_cardsid_0 = new List<int>()
        {
           77238012,77238000,77238017,77238018,77238019,77238028,77238030
            ,77238031,77238035,77238044,77238048,77238049,77238050,77238031,
           77238054,77238060,77238066,77238067
        };
        //对方区域的卡片往自己场上特殊召唤
        List<int> best_spsummon_cardsid_1 = new List<int>()
        {
            77238029
        };
        List<int> best_summon_cardsid_1 = new List<int>()
        {
        };
        List<int> best_remove_cardsid_1 = new List<int>()
        {
            77238029,77238062,77238063,77238064
        };
        List<int> best_destory_cardsid_1 = new List<int>()//怪兽区域破坏移动到下面写
        {
            77238020, 77238021,77238033,77238063,77238064
        };
        List<int> best_effect_release_cardsid_1 = new List<int>()
        {
                 77238021,77238042,77238029,77238026,77238062,77238063
            ,77238064
        };
        List<int> best_monster_release_cardsid_1 = new List<int>()
        {
                  77238021,77238042,77238029,77238026,77238062,77238063,
                  77238064
        };
        List<int> best_sendtograve_cardsid_1 = new List<int>()
        {
          77238021,77238033,77238042,77238047,77238062,77238063
            ,77238064
        };
        //自己区域的卡移动到自己场上
        List<int> move_to_field_cardsId_0 = new List<int>()
        {
            77238029,77238062,77238063
        };
        //对方怪兽移动到自己场上 
        List<int> move_to_field_cardsId_1 = new List<int>()
        {
            77238029,77238062
        };
        List<int> best_sendtohand_cardsid_1 = new List<int>()
        {
            77238021,77238044
        };
        List<int> best_sendtodeck_cardsid_1 = new List<int>()
        {
            77238021,77238033,77238042,77238044,77238047,77238062,77238063,
            77238064
        };
        List<int> best_control_cardsid_1 = new List<int>()
        {
            77238013, 77238033,77238029,77238062,77238063
            ,77238064
        };
        //装备卡给对方怪兽装备
        List<int> best_equip_cardsid_1 = new List<int>()
        {
            77238029
        };
        List<int> best_rule_cardsid_1 = new List<int>()
        {
            77238021,77238062,77238063
        };
        List<int> best_discard_cardsid_1 = new List<int>()
        {
            77238013,77238033,77238034,77238062,77238063
            ,77238064
        };


        List<int> no_disabled_cardsid = new List<int>()
        {
            77238058,77238059,77238060,77238062,77238063
            ,77238064,77238065
        };//效果无效仍然可以发动的卡
        List<int> no_target_m_cardsid = new List<int>()
        {
            77238026,77238029,77238050
        };//不取效果对象的怪兽区域卡
        List<int> no_target_s_cardsid = new List<int>()
        {
        };//不取效果对象的魔陷区域卡
        List<int> no_e_destory_cardsid = new List<int>()
        {
            77238013
        };//不会被效果破坏的卡
        List<int> no_b_destory_cardsid = new List<int>()
        {
            77238049

        };//不会被战斗破坏的卡
        List<int> no_attack_cardsid = new List<int>()
        {
          77238009, 77238010, 77238011, 77238012, 77238013
        };//不会被攻击的卡
        List<int> no_imm_cardsid = new List<int>()
        {
            77238058,77238066,77238067
        };//不受影响的卡
        List<int> no_con_cardsid = new List<int>()
        {
        };//不会被改变控制权的卡
        List<int> summon_no_release_cardsid = new List<int>()
        {
            77238026
        };//不需要祭品召唤的卡

        List<int> best_field_cardsId  = new List<int>
        {
            77238021
        };//优先发动的场地魔法卡

        //使用优先级
        List<int> Activate_1 = new List<int>()
        {
            77238058,77238057,77238053,77238021,77238000,77238001,77238002,77238005,77238008,77238014
            ,77238015,77238016,77238020,77238025,77238026,77238030,77238040
            ,77238033,77238062,77238065
        };
        List<int> Activate_2 = new List<int>()
        {
            77238059,77238061
        };
        List<int> SpellSet_1 = new List<int>()
        {
            77238064
        };
        List<int> SpellSet_2 = new List<int>()
        {

        };
        List<int> SpSummon_1 = new List<int>()
        {
            77238001,77238002,77238009,77238012,77238034,77238048
        };
        List<int> SpSummon_2 = new List<int>()
        {
            77238045
        };
        List<int> MonsterSet_1 = new List<int>()
        {

        };
        List<int> MonsterSet_2 = new List<int>()
        {

        };
        List<int> Summon_1 = new List<int>()
        {
            77238042,77238026,77238013,77238022,77238057
        };
        List<int> Summon_2 = new List<int>()
        {
            77238003,77238004,77238005,77238008,77238011,77238025,77238027,77238043
            ,77238055,77238056
        };
        private bool _MonsterSet_1()
        {
            if (!MonsterSet_1.Contains(Card.Id)) return false;
            return _MonsterSet();
        }
        private bool _MonsterSet_2()
        {
            if (!MonsterSet_2.Contains(Card.Id)) return false;
            return _MonsterSet();
        }
        private bool _MonsterSet_3()
        {
            return _MonsterSet();
        }
        private bool _MonsterSet()
        {
            if (Card.Attack <= 1000) return true;
            return false;
        }
        private bool _SpellSet_1()
        {
            if (!SpellSet_1.Contains(Card.Id)) return false;
            return _SpellSet();
        }
        private bool _SpellSet_2()
        {
            if (!SpellSet_2.Contains(Card.Id)) return false;
            return _SpellSet();
        }
        private bool _SpellSet_3()
        {
            return _SpellSet();
        }
        private bool _SpellSet()
        {
            List<int> nocardsId = new List<int>()
            {
                77238066,77238067
            };
            if (nocardsId.Contains(Card.Id)) return false;
            return true;
        }
        bool inversion = false;
        bool firstMonster = true;
        bool defaultSelect = true;
        bool isFaceUp = false;
        bool inversion_2 = false;
        bool firstMonster_2 = true;
        bool defaultSelect_2 = true;
        bool isFaceUp_2 = false;
        private void SetState(State state, CardLocation toLoc, CardLocation selectZone, int player, bool tg, bool isSelect = false, bool isFaceUp = false, bool defaultSelect = true, bool firstMonster = true, bool inversion = false)
        {
            this.state = state;
            this.toLoc = toLoc;
            this.selectZone = selectZone;
            this.player = player;
            this.tg = tg;
            this.isSelect = isSelect;
            this.inversion = inversion;
            this.firstMonster = firstMonster;
            this.defaultSelect = defaultSelect;
            this.isFaceUp = isFaceUp;
        }
        private void SetState_2(State state_2, CardLocation toLoc_2, CardLocation selectZone_2, int player_2, bool tg_2,bool isSelect_2 = false, bool isFaceUp_2 = false, bool defaultSelect_2 = true, bool firstMonster_2 = true, bool inversion_2 = false)
        {
            this.state_2 = state_2;
            this.toLoc_2 = toLoc_2;
            this.selectZone_2 = selectZone_2;
            this.player_2 = player_2;
            this.tg_2 = tg_2;
            this.isSelect_2 = isSelect_2;
            this.inversion_2 = inversion_2;
            this.firstMonster_2 = firstMonster_2;
            this.defaultSelect_2 = defaultSelect_2;
            this.isFaceUp_2 = isFaceUp_2;
        }
        /// <summary>
        /// 获取玩家某几个区域内的卡片组
        /// </summary>
        /// <param name="loc"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        private List<ClientCard> GetZoneCards(CardLocation loc,ClientField player)
        {
            List<ClientCard> res = new List<ClientCard>();
            List<ClientCard> temp = new List<ClientCard>();
            if ((loc & CardLocation.Hand) > 0)
            {
                temp = player.GetHands();
                if (temp.Count() > 0) res.AddRange(temp);
            }
            if ((loc & CardLocation.MonsterZone) > 0)
            {
                temp = player.GetMonsters();
                if (temp.Count() > 0) res.AddRange(temp);
            }
            if ((loc & CardLocation.SpellZone) > 0)
            {
                temp = player.GetSpells();
                if (temp.Count() > 0) res.AddRange(temp);
            }
            if ((loc & CardLocation.Grave) > 0)
            {
                temp = player.GetGraveyard();
                if (temp.Count() > 0) res.AddRange(temp);
            }
            if ((loc & CardLocation.Removed) > 0)
            {
                temp = player.Banished.Where(card=>card!=null).ToList();
                if (temp.Count() > 0) res.AddRange(temp);
            }
            if ((loc & CardLocation.Extra) > 0)
            {
                temp = player.ExtraDeck.Where(card => card != null).ToList();
                if (temp.Count() > 0) res.AddRange(temp);
            }
            return res;
        }
        private List<int> GetZoneNoOperateCardsId(State state = 0, CardLocation selectZone = 0)
        {
            if (state == 0 && this.state != 0) state = this.state;
            if (selectZone == 0 && this.selectZone != 0) selectZone = this.selectZone;
            List<int> res = new List<int>();
            if(this.player == 0)
            {
                if ((selectZone & CardLocation.Hand) > 0)
                {
                    if (!isOnState(state))
                    {
                        if (Bot.GetCountCardInZone(Bot.GetMonsters(), CardType.Monster, 0xa160) > 0)
                        {
                            res.AddRange(new List<int>()
                        {
                            77238061
                        });
                        }
                        res.AddRange(new List<int>()
                        {
                           77238063,77238064
                        });
                    }
                }
                if ((selectZone & CardLocation.MonsterZone) > 0)
                {
                    if (!isOnState(state))
                    {
                        if (Bot.GetCountCardInZone(Bot.GetMonsters(), CardType.Monster, 0xa160) > 0)
                        {
                            res.AddRange(new List<int>()
                        {
                            77238061
                        });

                        }
                        res.AddRange(new List<int>()
                        {
                        });
                    }
                }
                if ((selectZone & CardLocation.SpellZone) > 0)
                {
                    if (!isOnState(state))
                    {
                        res.AddRange(new List<int>()
                        {
                            77238063,77238064
                        });
                    }
                }
                if ((selectZone & CardLocation.Grave) > 0)
                {

                }
                if ((selectZone & CardLocation.Removed) > 0)
                {

                }
                if ((selectZone & CardLocation.Deck) > 0)
                {
                }
                if ((selectZone & CardLocation.Extra) > 0)
                {

                }
            }
            else
            {

            }
            res = res.Distinct().ToList();
            return res;
        }
        //loc表示当前自己的位置，toLoc表示卡片效果要将卡片所送去的区域，区域不同优先级不同
        private List<int> GetZoneBestCardsId(CardLocation selectZone = 0, CardLocation toLoc = 0, ClientField player = null,State state = 0)
        {
            if (selectZone == 0 && this.selectZone != 0) selectZone = this.selectZone;
            if (toLoc == 0 && this.toLoc != 0) toLoc = this.toLoc;
            if (player == null && this.player == 0) player = Bot;
            if (player == null && this.player == 1) player = Enemy;
            if (state == 0 && this.state != 0) state = this.state;
            List<int> tempCardsId = new List<int>();
            if (player == Bot)
            {
                if (state == State.Spsummon)
                {
                    tempCardsId.AddRange(best_spsummon_cardsid_0);
                    if (hasField(true))
                    {
                        tempCardsId.AddRange(new List<int>()
                        {
                            77238013,77238022
                        });
                    }
                }
                if (state == State.SendToHand)
                {
                    tempCardsId.AddRange(best_sendtohand_cardsid_0);
                    if (Bot.GetCountCardInZone(Bot.GetMonsters(), CardType.Monster, 0x21) > 0)
                    {
                        tempCardsId.AddRange(new List<int>()
                        {
                            77238001,77238002
                        });
                    }
                    if (Bot.GetCountCardInZone(Bot.GetMonsters(), CardType.Monster, 0xa160) > 0)
                    {
                        tempCardsId.AddRange(new List<int>()
                        {
                            77238061
                        });
                    }
                }
                if (state == State.SendToDeck)
                {
                    tempCardsId.AddRange(best_sendtodeck_cardsid_0);
                    if ((selectZone & CardLocation.Hand) > 0)
                    {
                        tempCardsId.AddRange(new List<int>()
                        {
                           77238000,77238031,77238049,77238048,77238050,
                           77238031,77238060
                        });
                        if (Enemy.GetMonsters().Count(card => card != null && card.IsFaceup()
                         && card.HasSetcode(0xa160)) <= 0)
                        {
                            tempCardsId.Add(77238065);
                        }
                    }
                }
                if (state == State.SendToGrave)
                {
                    tempCardsId.AddRange(best_sendtograve_cardsid_0);
                    if ((selectZone & CardLocation.Hand) > 0)
                    {
                        List<ClientCard> cards = Bot.GetHands().Where(card => card != null && card.HasType(CardType.Normal)).ToList();
                        IList<int> ids = ClientCardsToCardsId(cards,true);
                        if (ids.Count >= 0) tempCardsId.AddRange(ids);
                        tempCardsId.AddRange(new List<int>()
                        {
                           77238031,77238035,77238036,77238050,77238031
                        });
                        if (Enemy.GetMonsters().Count(card => card != null && card.IsFaceup()
                           && card.HasSetcode(0xa160)) <= 0)
                        {
                            tempCardsId.Add(77238065);
                        }
                    }
                }
                if (state == State.DisCard)
                {
                    tempCardsId.AddRange(best_discard_cardsid_0);
                    List<ClientCard> cards = Bot.GetHands().Where(card => card != null && card.HasType(CardType.Normal)).ToList();
                    IList<int> ids = ClientCardsToCardsId(cards, true);
                    if (ids.Count >= 0) tempCardsId.AddRange(ids);
                    if (Enemy.GetMonsters().Count(card => card != null && card.IsFaceup()
                    && card.HasSetcode(0xa160)) <= 0)
                    {
                        tempCardsId.Add(77238065);
                    }
                }
                if (state == State.MoveToField)
                {
                    tempCardsId.AddRange(move_to_field_cardsId_0);
                    if ((selectZone & CardLocation.Hand) == 0)
                    {
                        tempCardsId.AddRange(best_field_cardsId);
                        tempCardsId.AddRange(best_spsummon_cardsid_0);
                    }
                }
                if (state == State.Remove)
                {
                    tempCardsId.AddRange(best_remove_cardsid_0);
                    if ((selectZone & CardLocation.Grave) > 0)
                    {
                        tempCardsId.AddRange(new List<int>
                        {
                            77238051,
                        });
                    }
                }
            }
            else
            {
                if (state == State.Control)
                {
                    tempCardsId.AddRange(best_control_cardsid_1);
                }
                if (state == State.Destory)
                {
                    tempCardsId.AddRange(best_destory_cardsid_1);
                    if ((selectZone & CardLocation.MonsterZone) > 0)
                    {
                        tempCardsId.AddRange(new List<int>()
                        {
                            77238026,77238029,77238026
                        });
                    }
                }
                if (state == State.Remove)
                {
                    tempCardsId.AddRange(best_remove_cardsid_1);
                    if ((selectZone & CardLocation.MonsterZone) > 0)
                    {
                        tempCardsId.AddRange(new List<int>()
                        {
                                77238013,77238026,77238031
                        });
                    }
                    if ((selectZone & CardLocation.SpellZone) > 0)
                    {
                        tempCardsId.AddRange(new List<int>()
                        {
                                77238020
                        });
                    }
                }
                if (state == State.Equip)//
                {
                    tempCardsId.AddRange(best_equip_cardsid_1);
                    if ((selectZone & CardLocation.MonsterZone) > 0)
                    {
                        tempCardsId.AddRange(new List<int>()
                        {
                            77238013
                        });
                    }
                }
                if (state == State.SendToGrave)
                {
                    tempCardsId.AddRange(best_sendtograve_cardsid_1);
                    if ((selectZone & CardLocation.MonsterZone) > 0)
                    {
                        tempCardsId.AddRange(new List<int>()
                        {
                            77238013,77238029,77238026,77238026
                        });
                    }
                    if ((selectZone & CardLocation.Hand) > 0)
                    {
                        tempCardsId.AddRange(new List<int>()
                        {
                            77238034
                        });
                    }
                    if ((selectZone & CardLocation.Deck) > 0)
                    {
                        tempCardsId.AddRange(new List<int>()
                        {
                            77238034
                        });
                    }
                }
                if (state == State.SendToHand)
                {
                    if (toplayer == 1)
                    {
                        //牛对面的卡
                        tempCardsId.AddRange(new List<int>()
                        {
                          77238033,77238026,77238014
                        });
                    }
                    else
                    {
                        tempCardsId.AddRange(best_sendtohand_cardsid_1);
                        if ((selectZone & CardLocation.MonsterZone) > 0)
                        {
                            tempCardsId.AddRange(new List<int>()
                            {
                               77238013,77238029,77238026
                            });
                               
                        }
                    }

                }
                if (state == State.SendToDeck)
                {
                    tempCardsId.AddRange(best_sendtodeck_cardsid_1);
                    if ((selectZone & CardLocation.MonsterZone) > 0)
                    {
                        tempCardsId.AddRange(new List<int>()
                        {
                            77238013,77238026,77238029
                        });
                    }
                }
                if (state == State.Rule)
                {
                    tempCardsId.AddRange(best_rule_cardsid_1);
                    if ((selectZone & CardLocation.MonsterZone) > 0)
                    {
                        tempCardsId.AddRange(new List<int>()
                        {
                            77238013
                        });
                        if (hasField(true))
                        {
                            tempCardsId.AddRange(new List<int>()
                            {
                                77238022
                            });
                        }
                        if (!tg)
                        {
                            tempCardsId.AddRange(new List<int>()
                            {
                                77238026
                            });
                        }
                    }
                }
            }
            tempCardsId = tempCardsId.Distinct().ToList();
            return tempCardsId;
        }
        private IList<ClientCard> CardsIdToClientCards(IList<int> cardsId, IList<ClientCard> cardsList, bool uniqueId = true, bool alias = true)
        {
            if (cardsList?.Count() <= 0 || cardsId?.Count() <= 0) return new List<ClientCard>();
            List<ClientCard> res = new List<ClientCard>();
            foreach (var cardid in cardsId)
            {
                List<ClientCard> cards = cardsList.Where(card => card != null && (card.Id == cardid || ((card.Alias != 0 && cardid == card.Alias) & alias))).ToList();
                if (cards?.Count <= 0) continue;
                if (uniqueId) res.Add(cards.First());
                else res.AddRange(cards);
            }
            return res;
        }
        private IList<int> ClientCardsToCardsId(IList<ClientCard> cardsList, bool uniqueId = false, bool alias = false)
        {
            if (cardsList == null) return new List<int>();
            if (cardsList.Count <= 0) return new List<int>();
            IList<int> res = new List<int>();
            foreach (var card in cardsList)
            {
                if (card == null) continue;
                if (card.Alias != 0 && alias && !(res.Contains(card.Alias) & uniqueId)) res.Add(card.Alias);
                else if (card.Id != 0 && !(res.Contains(card.Id) & uniqueId)) res.Add(card.Id);
            }
            return res.Count < 0 ? new List<int>() : res;
        }
        /// <summary>
        /// 过滤掉卡片组中的取对象|全抗的怪兽
        /// </summary>
        /// <returns></returns>
        private List<ClientCard> CheckFilterCards(List<ClientCard> cards,CardLocation selectZone = 0, State state = 0, bool isFaceup = false, bool target = false)
        {
            if (this.selectZone != 0 && selectZone == 0) selectZone = this.selectZone;
            if (this.state != 0 && state == 0) state = this.state;
            List<ClientCard> res = new List<ClientCard>();
            List<ClientCard> temp = new List<ClientCard>();
            if (cards.Count <= 0) return res;
            List<int> NoOpCardsId = GetZoneNoOperateCardsId(state, selectZone);
            List<ClientCard> NoOpCards = CardsIdToClientCards(NoOpCardsId, cards, false).ToList();
            if ((selectZone & CardLocation.Hand) > 0)
            {
                temp = cards.Where(card => card != null && card.Location == CardLocation.Hand && !NoOpCards.Contains(card)).ToList();
                res.AddRange(temp);
            }
            if ((selectZone & CardLocation.MonsterZone) > 0)
            {
                temp = cards.Where(card => card != null &&  !NoOpCards.Contains(card) && card.Location == CardLocation.MonsterZone && (card.IsDisabled() || card.IsFacedown() || !(!card.IsFaceup() & isFaceup) && !(IsShouldNotBeTarget(card) & target) && !(no_imm_cardsid.Contains(card.Id) & !(state == State.Rule)
                && !(no_con_cardsid.Contains(card.Id) & (state == State.Control))
                 && !(no_e_destory_cardsid.Contains(card.Id) & (state == State.Destory))))).ToList();
                if (state != State.Rule)
                {
                    temp = temp.Where(card => card != null && (card.IsDisabled() || CheckOther(card))).ToList();
                }
                res.AddRange(temp);

            }
            if ((selectZone & CardLocation.SpellZone) > 0)
            {
                temp = cards.Where(card => card != null && !NoOpCards.Contains(card) && card.Location == CardLocation.SpellZone && (card.IsDisabled() || card.IsFacedown() || !(!card.IsFaceup() & isFaceup) && !(IsShouldNotBeTarget(card) & target) && !(no_imm_cardsid.Contains(card.Id) & !(state == State.Rule)
                && !(no_con_cardsid.Contains(card.Id) & (state == State.Control))
                && !(no_e_destory_cardsid.Contains(card.Id) & (state == State.Destory))))).ToList();
                if (state != State.Rule)
                {
                    temp = temp.Where(card => card != null && (card.IsDisabled() || CheckOther(card))).ToList();
                }
                res.AddRange(temp);
            }
            if ((selectZone & CardLocation.Grave) > 0)
            {
                temp = cards.Where(card => card != null && !NoOpCards.Contains(card) && card.Location == CardLocation.Grave).ToList();
                res.AddRange(temp);
            }
            if ((selectZone & CardLocation.Removed) > 0)
            {
                temp = cards.Where(card => card != null && !NoOpCards.Contains(card) && !(!card.IsFaceup() & isFaceup) && card.Location == CardLocation.Removed).ToList();
                res.AddRange(temp);
            }
            if ((selectZone & CardLocation.Deck) > 0)
            {
                temp = cards.Where(card => card != null && !NoOpCards.Contains(card) && card.Location == CardLocation.Deck).ToList();
                res.AddRange(temp);
            }
            if ((selectZone & CardLocation.Extra) > 0)
            {
                temp = cards.Where(card => card != null && !NoOpCards.Contains(card) && card.Location == CardLocation.Extra).ToList();
                res.AddRange(temp);
            }
            res = res.Distinct().ToList();
            return res;
        }
        private bool CheckOther(ClientCard card)
        {
            if (card.HasSetcode(0xa160) && Card.HasSetcode(0xa70)) return false;
            if (((CardType)Card.Type & (CardType.Spell | CardType.Trap)) > 0)
            {
                List<int> immCardsId = new List<int>()
                {
                    77238052,
                };
                if (immCardsId.Contains(card.Id)) return false;
            }
            if (((CardType)Card.Type & (CardType.Monster)) > 0)
            {
                List<int> immCardsId = new List<int>()
                {
                };
                if (immCardsId.Contains(card.Id)) return false;
            }
            return true;
        }
        List<ClientCard> copyCards = new List<ClientCard>();
        /// <summary>
        /// 获取要操作的最优卡片组
        /// 参数1:要选择的卡片位置
        /// 参数2:卡片将要去往的位置
        /// 参数3:所操作的玩家场地
        /// 参数4:所操作的卡片状态
        /// 参数5:是否加入默认筛选的卡片组
        /// 参数6:默认卡片组是否优先选择怪兽？
        /// 参数7:默认卡片组是否倒置当前怪兽的攻击力？
        /// 参数8:筛选的卡片组是否要求正面表示?
        /// 参数9:筛选的卡片组是否有只取对象的要求?bool IsDisabled = false
        /// </summary>
        /// <param name="selectZone">要选择的卡片位置</param>
        /// <param name="toLoc">卡片将要去往的位置</param>
        /// <param name="player">所操作的玩家场地</param>
        /// <param name="state">所操作的卡片状态</param>
        /// <param name="defaultSelect">是否加入默认筛选的卡片组?</param>
        /// <returns></returns>
        private List<ClientCard> GetZoneOperateCards(bool isFaceup = false, bool target = false,bool defaultSelect = true, bool firstMonster = true, bool inversion = false,CardLocation selectZone = 0, CardLocation toLoc = 0, ClientField player = null, State state = 0)
        {
            if (tg) target = true;
            if (this.isFaceUp) isFaceup = true;
            if (!this.defaultSelect) defaultSelect = false;
            if (!this.firstMonster) firstMonster = false;
            if (this.inversion) inversion = true;
            if (selectZone == 0 && this.selectZone != 0) selectZone = this.selectZone;
            if (toLoc == 0 && this.toLoc != 0) toLoc = this.toLoc;
            if (player == null && this.player == 0) player = Bot;
            if (player == null && this.player == 1) player = Enemy;
            if (state == 0 && this.state != 0) state = this.state;
            List<int> resid = new List<int>();
            List<ClientCard> res = new List<ClientCard>();
            List<ClientCard> defaultCards = GetDefaultCards(selectZone,player,state,isFaceup,target,firstMonster,inversion);
            List<int> cardsid = GetZoneBestCardsId(selectZone, toLoc, player, state);
            if (cardsid.Count <= 0) return defaultSelect ? defaultCards : res;
            if(cardsid.Count > 0) resid.AddRange(cardsid);
            resid = resid.Distinct().ToList();
            List<ClientCard> zoneCards = copyCards.Count > 0 ? new List<ClientCard>(copyCards) : GetZoneCards(selectZone, player);
            res = CardsIdToClientCards(cardsid, zoneCards, false).ToList();
            res = CheckFilterCards(res,selectZone,state,isFaceup,target);
            if (defaultSelect) res.AddRange(defaultCards);
            res = res.Distinct().ToList();
            return res;
        }
        /// <summary>
        /// 获得玩家某区域内的默认选择卡片
        /// 参数1：选择的卡片区域
        /// 参数2：所选的玩家
        /// 参数3：是否优先排序怪兽卡？
        /// 参数4：是否让排序怪兽的攻击力倒置？
        /// </summary>
        /// <param name="selectZone"></param>
        /// <param name="player"></param>
        /// <param name="firstMonster"></param>
        /// <param name="inversion"></param>
        /// <returns></returns>
        private List<ClientCard> GetDefaultCards(CardLocation selectZone, ClientField player, State state = 0, bool isFaceUp = false, bool target = false, bool firstMonster = true, bool inversion = false)
        {
            List<ClientCard> res = new List<ClientCard>();
            res = copyCards.Count()>0 ? new List<ClientCard>(copyCards): GetZoneCards(selectZone, player);
            if (res.Count <= 0) return res;
            res = CheckFilterCards(res, selectZone, state, isFaceUp, target);
            List<ClientCard> mCards = res.Where(card => card != null && (card.HasType(CardType.Monster) || card.Attack > 0)).ToList();
            List<ClientCard> sCards = res.Where(card => card != null && !card.HasType(CardType.Monster)).ToList();

            if (mCards.Count > 0)
            {
                mCards.Sort(CardContainer.CompareCardAttack);
                if ((player == Bot && inversion) || (player == Enemy && !inversion))
                {
                    mCards.Reverse();
                }
            }
            if (firstMonster) mCards.AddRange(sCards);
            else sCards.AddRange(mCards);
            return res;

        }
        private bool CheckSetCode(int setcode, int cardsid)
        {
            if (setcode == 0xa160)
            {
                List<int> sui_hun = new List<int>() { };
                for (int keyId = 77238040; keyId < 77238064; ++keyId)
                {
                    sui_hun.Add(keyId);
                }
                if (sui_hun.Contains(cardsid)) return true;
            }
            return false;
        }
        public override IList<ClientCard> OnSelectCard(IList<ClientCard> cards, int min, int max, long hint, bool cancelable)
        {
            copyCards.Clear();
            if (isSelect)
            {
                isSelect = false;
                if (state == State.Spsummon || state == State.MoveToField || state == State.Summon)
                {
                    if (GetZoneCards(CardLocation.Onfield, Enemy).Count(card => card != null
                      && card.IsFaceup() && !card.IsDisabled() && card.HasSetcode(0xa70))>0
                        && GetZoneCards(CardLocation.Onfield | CardLocation.Hand, Bot).Count(card => card != null
                      && (card.Location&CardLocation.Onfield)>0 ? !card.IsDisabled(): true && card.HasSetcode(0xa70) &&
                      ((card.Location & CardLocation.Hand) > 0 ? card.HasType(CardType.Spell | CardType.Trap) : true)) <= 0)
                    {
                        List<ClientCard> res = cards.Where(card => card != null && CheckSetCode(0xa160,card.Id)).ToList();
                        if (res.Count >= 0)
                        {
                            res.Sort(CardContainer.CompareCardAttack);
                            res.Reverse();
                            return Util.CheckSelectCount(res, cards, min, max);
                        } 
                    }
                }
                copyCards = new List<ClientCard>(cards);
                List<ClientCard> opCards = GetZoneOperateCards();
                copyCards.Clear();
                if (opCards.Count > 0) return Util.CheckSelectCount(opCards, cards, min, max);
                List<ClientCard> eCards = cards.Where(card => card != null && card.Controller != 0).ToList();
                List<ClientCard> mCards = cards.Where(card => card != null && card.Controller == 0).ToList();
                if (player == 1)
                {
                    if ((selectZone & (CardLocation.Onfield | CardLocation.Grave | CardLocation.Removed)) > 0 || state == State.Spsummon || state == State.Summon || state == State.Equip || state == State.Control)
                    {
                        if (eCards.Count >= 0) { eCards.Sort(CardContainer.CompareCardAttack); eCards.Reverse(); }
                        if (mCards.Count >= 0)
                        {
                            List<ClientCard> mCards_1 = mCards.Where(card => card != null && card.HasType(CardType.Monster)).ToList();
                            List<ClientCard> mCards_2 = mCards.Where(card => card != null && !card.HasType(CardType.Monster)).ToList();
                            if (mCards_1.Count > 0) mCards_1.Sort(CardContainer.CompareCardAttack);
                            mCards_2.AddRange(mCards_1);
                            mCards = mCards_2;
                            eCards.AddRange(mCards);
                        }
                        return Util.CheckSelectCount(eCards, cards, min, max);
                    }
                    else
                    {
                        if (eCards.Count <= 0)
                        {
                            if (mCards.Count >= 0)
                            {
                                List<ClientCard> mCards_1 = mCards.Where(card => card != null && card.HasType(CardType.Monster)).ToList();
                                List<ClientCard> mCards_2 = mCards.Where(card => card != null && !card.HasType(CardType.Monster)).ToList();
                                if (mCards_1.Count > 0) mCards_1.Sort(CardContainer.CompareCardAttack);
                                mCards_2.AddRange(mCards_1);
                                mCards = mCards_2;
                                eCards.AddRange(mCards);
                            }
                            return Util.CheckSelectCount(eCards, cards, min, max);

                        }
                        if (eCards.Count <= 0) eCards = new List<ClientCard>(cards);
                        int index = Program.Rand.Next(eCards.Count());
                        if (index < 0 || index >= eCards.Count()) return Util.CheckSelectCount(eCards, cards, min, max);
                        IList<ClientCard> res = new List<ClientCard>();
                        res.Add(eCards.ElementAtOrDefault(index));
                        return Util.CheckSelectCount(res, cards, min, max);

                    }
                }
                else
                {
                    if ((selectZone & CardLocation.Onfield) > 0)
                    {
                        mCards.Sort(CardContainer.CompareCardAttack);
                        if (state == State.Equip || state == State.Spsummon || state == State.Summon)
                        {
                            mCards.Reverse();
                            mCards.AddRange(eCards);
                            return Util.CheckSelectCount(mCards, cards, min, max);
                        }
                        else
                        {
                            mCards.AddRange(eCards);
                            return Util.CheckSelectCount(mCards, cards, min, max);
                        }

                    }
                    else
                    {
                        if (mCards.Count <= 0) mCards = new List<ClientCard>(cards);
                        int index = Program.Rand.Next(mCards.Count());
                        if (index < 0 || index >= mCards.Count()) return Util.CheckSelectCount(mCards, cards, min, max);
                        IList<ClientCard> res = new List<ClientCard>();
                        res.Add(mCards.ElementAtOrDefault(index));
                        return Util.CheckSelectCount(res, cards, min, max);
                    }
                }
            }
            ResetFlag();
            return base.OnSelectCard(cards, min, max, hint, cancelable);
        }
        private bool HasForbear(ClientCard ccard)
        {
            if (ccard == null) return false;
            if (GetZoneCards(CardLocation.Onfield, Enemy).Count(card => card != null
                     && card.IsFaceup() && !card.IsDisabled() && card.HasSetcode(0xa70)) > 0
                       && GetZoneCards(CardLocation.Onfield | CardLocation.Hand, Bot).Count(card => card != null
                     && (card.Location & CardLocation.Onfield) > 0 ? !card.IsDisabled() : true && card.HasSetcode(0xa70)
                      && ((card.Location & CardLocation.Hand) > 0 ? card.HasType(CardType.Spell | CardType.Trap) : true)) <= 0)
            {
                return ccard.HasSetcode(0xa160);
            }
            return false;
        }
        private bool HasDisForber(ClientCard ccard)
        {
            if (ccard == null) return false;
            if (GetZoneCards(CardLocation.Onfield, Enemy).Count(card => card != null
                    && card.IsFaceup() && !card.IsDisabled() && card.HasSetcode(0xa160)) > 0
                      || GetZoneCards(CardLocation.Onfield, Bot).Count(card => card != null
                    && card.IsFaceup() && !card.IsDisabled() && card.HasSetcode(0xa160)) > 0)
            {
                return ccard.HasSetcode(0xa70);
            }
            return false;
        }

        private void ClearFlag()
        {
                state_2 = 0;
                state = 0;
                selectZone_2 = 0;
                selectZone = 0;
                toLoc_2 = 0;
                toLoc = 0;
                tg_2 = false;
                tg = false;
                player_2 = 0;
                player = 0;
                toplayer_2 = 0;
                toplayer = 0;
                isSelect_2 = false;
                isSelect = false;
                isFaceUp_2 = false;
                isFaceUp = false;
                inversion_2 = false;
                inversion = false;
                firstMonster_2 = true;
                firstMonster = true;
                defaultSelect_2 = true;
                defaultSelect = true;
        }
        private void ResetFlag()
        {
            if (state_2 != 0)
            {
                state = state_2;
                state_2 = 0;
            }
            else
            {
                state = 0;
            }
            if (selectZone_2 != 0)
            {
                selectZone = selectZone_2;
                selectZone_2 = 0;
            }
            else
            {
                selectZone = 0;
            }
            if (toLoc_2 != 0)
            {
                toLoc = toLoc_2;
                toLoc_2 = 0;
            }
            else
            {
                toLoc = 0;
            }
            if (tg_2 != false)
            {
                tg = tg_2;
                tg_2 = false;
            }
            else
            {
                tg = false;
            }
            if (player_2 != 0)
            {
                player = player_2;
                player_2 = 0;
            }
            else
            {
                player = 0;
            }
            if (toplayer_2 != 0)
            {
                toplayer = toplayer_2;
                toplayer_2 = 0;
            }
            else
            {
                toplayer = 0;
            }
            if (isSelect_2 != false)
            {
                isSelect = isSelect_2;
                isSelect_2 = false;
            }
            else
            {
                isSelect = false;
            }
            if (isFaceUp_2 != false)
            {
                isFaceUp = isFaceUp_2;
                isFaceUp_2 = false;
            }
            else
            {
                isFaceUp = false;
            }
            if (inversion_2 != false)
            {
                inversion = inversion_2;
                inversion_2 = false;
            }
            else
            {
                inversion = false;
            }
            if (firstMonster_2 != true)
            {
                firstMonster = firstMonster_2;
                firstMonster_2 = true;
            }
            else
            {
                firstMonster = true;
            }
            if (defaultSelect_2 != true)
            {
                defaultSelect = defaultSelect_2;
                defaultSelect_2 = true;
            }
            else
            {
                defaultSelect = true;
            }
        }
        public override int OnSelectOption(IList<long> options)
        {
            if (options.Contains(Util.GetStringId(77238026, 0)))
            {
                return options.IndexOf(Util.GetStringId(77238026, 0));
            }
            return base.OnSelectOption(options);
        }
        public override CardPosition OnSelectPosition(int cardId, IList<CardPosition> positions)
        {
            return base.OnSelectPosition(cardId, positions);
        }
        public override bool OnSelectYesNo(long desc)
        {
            return base.OnSelectYesNo(desc);
        }
        private int GetBestPlayer(bool onlyATK)
        {
            int bo_attk = Util.GetBestPower(Bot, onlyATK);
            int en_attk = Util.GetBestPower(Enemy, onlyATK);
            if (bo_attk > en_attk) return 0;
            return 1;
        }
        private bool FieldActivate(ClientCard card) 
        {
            if (!card.HasType(CardType.Continuous | CardType.Field)) return true;
            if (((card.Location & CardLocation.Onfield) > 0 || card.Location == CardLocation.FieldZone) && card.IsFaceup()) return true;
            ClientCard fieldCard = Bot.GetFieldSpellCard();
            if (card.HasType(CardType.Field) && card.Location == CardLocation.Hand && fieldCard != null)
            {
                if (fieldCard.IsDisabled()) return true;
                if (best_field_cardsId.Contains(fieldCard.Id)) return false;
                if (best_field_cardsId.Contains(card.Id)) return true;
                return false;
            }
            return card.Location == CardLocation.Hand || (card.Location == CardLocation.SpellZone && card.IsFacedown());
        }
        private bool IsShouldNotBeTarget(ClientCard card)
        {
            if (card.IsDisabled() || card.IsFacedown()) return false;
            if (card.IsShouldNotBeTarget()) return true;
            if ((card.Location & CardLocation.MonsterZone) > 0)
            { 
             if (no_target_m_cardsid.Contains(card.Id)) return true;
            }
            if ((card.Location & CardLocation.SpellZone) > 0)
            {
                if (no_target_s_cardsid.Contains(card.Id)) return true;
            }
            return false;
        }
        private bool _Activate_1()
        {
            if (!Activate_1.Contains(Card.Id)) return false;
            return _Activate();
        }
        private bool _Activate_2()
        {
            if (!Activate_2.Contains(Card.Id)) return false;
            return _Activate();
        }
        private bool _Activate_3()
        {
            return _Activate();
        }
        private bool isShouldDisable(ClientCard card)
        {
            if (card == null) return true;
            if (card.Controller == 0) return false;
            if (card.IsDisabled()) return true;
            if (no_imm_cardsid.Contains(card.Id) || no_disabled_cardsid.Contains(card.Id)) return false;
            return true;
        }
        //效果发动
        private bool _Activate()
        {
            //if (HasForbear(Card)) return true;
            //if (HasDisForber(Card)) return false;
            if (Card.IsDisabled() && !no_disabled_cardsid.Contains(Card.Id)) return false;
            if (!FieldActivate(Card)) return false;
            if ((Card.Location == CardLocation.Hand || ((Card.Location == CardLocation.SpellZone || Card.Location == CardLocation.FieldZone) && Card.IsFacedown()))
                && Card.HasType(CardType.Continuous | CardType.Field))
            {
                return true;
            }
            switch (Card.Id)
            {
                case 77238100:
                    SetState(State.EffectRelease, CardLocation.Grave, CardLocation.MonsterZone,0,false,true);
                    return true;
                case 77238065:
                    SetState(State.Spsummon, CardLocation.MonsterZone,CardLocation.Grave,0,false,true,false,true,true,true);
                    return true;
                case 77238062:
                    if (Duel.Phase==DuelPhase.Standby)
                    {
                        SetState(State.Spsummon, CardLocation.MonsterZone, CardLocation.Deck | CardLocation.Hand | CardLocation.Grave, 0,false,true,false,true,true,true);
                    }
                    return true;
                case 77238059:
                    ClientCard card = Util.GetLastChainCard();
                    if (card == null) return false;
                    if (card.Controller == 0)
                    {
                        SetState(0, 0, 0, 1, true, true);

                    }
                    else
                    {
                        SetState(0, 0, 0, 0, true,true);
                    }
                    return true;
                case 77238057:
                    SetState(State.Spsummon, CardLocation.MonsterZone, CardLocation.Deck,0,false,true,false,true,true,true);
                    return true;
                case 77238053:
                    SetState(State.Control, CardLocation.MonsterZone, CardLocation.MonsterZone, 1,true,true,false);
                    return true;
                case 77238052:
                    if (Duel.Phase >= DuelPhase.Battle)
                    {
                        SetState(State.Destory, CardLocation.Grave, CardLocation.MonsterZone, 1,false,true);
                        return true;
                    }
                    return true;
                case 77238042:
                    SetState(State.Destory, CardLocation.Grave, CardLocation.MonsterZone,1,false,true);
                    return true;
                case 77238030:
                    SetState(0,CardLocation.Deck,CardLocation.Deck,0,false,true,false,false);
                    return true;
                case 77238022: //地缚神 欧西科(ZCG)
                    if (!hasField(true)) return false;
                    if (ActivateDescription == Util.GetStringId(77238022, 1))
                    {
                        ClientCard chaincard77238022 = Util.GetLastChainCard();
                        if (chaincard77238022 == null) return false;
                        if (!isShouldDisable(chaincard77238022)) return false;
                        List<ClientCard> card77238022 = Bot.GetMonsters().Where(_card77238022 => _card77238022 != null && _card77238022 != Card).ToList();
                        copyCards = new List<ClientCard>(card77238022);
                        SetState(State.EffectRelease, CardLocation.Grave, CardLocation.MonsterZone, 0, false, false, false, true);
                        card77238022 = GetZoneOperateCards();
                        copyCards.Clear();
                        if (card77238022.Count >= 0) AI.SelectCard(card77238022);

                    }
                    else
                    {
                        SetState(State.MoveToField, CardLocation.SpellZone, CardLocation.Deck, 0,false,true,false,false);
                    }
                    return true;
                case 77238051:
                    if (ActivateDescription == Util.GetStringId(77238051, 0))
                    {
                        SetState(State.DisCard,CardLocation.Grave,CardLocation.Hand,0,false,true,false);
                        List<int> cardsId = GetZoneBestCardsId();
                        if (cardsId.Count <= 0)
                        {
                            if ((Bot.GetHandCount() - GetZoneNoOperateCardsId().Count) <= 0)
                            {
                                ClearFlag();
                                return false;
                            }
                        }
                        SetState_2(State.SendToHand, CardLocation.Hand, CardLocation.Deck,0,false,true,false,false);
                    }
                    return true; 
                case 77238046:
                    if (Card.Location == CardLocation.Grave)
                    {
                        SetState(State.SendToHand, CardLocation.Hand, CardLocation.Grave, 0, false,true,false,false);
                    }
                    return true;
                case 77238043://碎魂者 狂野的战狼(ZCG)
                    if (Duel.Phase == DuelPhase.Battle)
                    {
                        List<ClientCard> cards = Enemy.GetSpells();
                        SetState(State.Destory, CardLocation.Grave, CardLocation.SpellZone, 0, false, false, false, false);
                        IList<ClientCard> m_cards = GetZoneOperateCards();
                        if (m_cards.Count >= 0) cards.AddRange(m_cards);
                        if (cards.Count <= 0) { ClearFlag(); return false; }
                        AI.SelectCard(cards);
                        return true;
                    }
                    return true;
                case 77238040://碎魂者 遥控魔女(ZCG)
                    if (ActivateDescription == Util.GetStringId(77238040, 0))
                    {
                        SetState(State.Control, CardLocation.MonsterZone, CardLocation.MonsterZone, 1, true,true,false,true);
                    }
                    return true;
                case 77238035://殉道者 毁灭狂龙(ZCG)
                    return Bot.LifePoints <= 1500;
                case 77238033://小偷盗贼(ZCG)
                    return true;
                case 77238027://地缚神 雷轰鲑(ZCG)
                    if (Duel.Phase == DuelPhase.End)
                    {
                        SetState(State.Spsummon, CardLocation.MonsterZone, CardLocation.Removed, 0,false,true,false,true,true,true);
                    }
                    return true;
                case 77238026://地缚神 赫比(ZCG)
                    if (Duel.Phase != DuelPhase.Standby)
                    {
                        isSelect = true;
                        List<ClientCard> cards77238026 = Enemy.GetMonsters().Where(_cards77238026 => _cards77238026 != null
                        && _cards77238026.IsFaceup() && !IsShouldNotBeTarget(_cards77238026) && _cards77238026.Attack > 0).ToList();
                        copyCards = new List<ClientCard>(cards77238026);
                        SetState(0, 0, CardLocation.MonsterZone, 1, true, false, true, true);
                        cards77238026 = GetZoneOperateCards();
                        if (cards77238026.Count >= 0)
                        {
                            AI.SelectCard(cards77238026);
                            return true;
                        }
                        return false;
                    }
                    return true;
                case 77238021:
                    if (Duel.Phase == DuelPhase.End)
                    {
                        SetState(State.Spsummon, CardLocation.MonsterZone, CardLocation.Hand |CardLocation.Deck, 0, false,true,false,true,true,true);
                    }
                    return true;
                case 77238017:
                    SetState(State.DisCard, CardLocation.Grave, CardLocation.Hand, 0, false);
                    return true;
                case 77238016:
                     SetState(State.SendToHand, CardLocation.Hand, CardLocation.Deck, 0, false,true,false,false);
                    return true;
                case 77238000:
                    return Bot.LifePoints > 300;
                case 77238001:
                    if (Card.Location == CardLocation.Grave)
                    {
                        SetState(State.SendToHand, CardLocation.Hand, CardLocation.Grave,0,false);
                        List<ClientCard> cards = GetZoneOperateCards();
                        if (cards.Count >= 0) AI.SelectCard(cards);
                    }
                    if (Card.Location == CardLocation.MonsterZone)
                    {
                        SetState(State.Destory,CardLocation.Grave, CardLocation.Onfield, 1 , true);
                        List<ClientCard> cards = GetZoneOperateCards(false,true);
                        if (cards.Count >= 0) AI.SelectCard(cards);
                    }
                    return true;
                case 77238004:
                    return Bot.GetSpellCount() <= Enemy.GetSpellCount();
                case 77238005://地缚神 库西略指引者(ZCG)
                    if (ActivateDescription == Util.GetStringId(77238005, 1))
                    {
                        if (Bot.LifePoints <= 1000) return false;
                        SetState(State.SendToHand, CardLocation.Hand, CardLocation.MonsterZone,1, true);
                        List<ClientCard> card77238005 = GetZoneOperateCards();
                        if (card77238005.Count >= 0) AI.SelectCard(card77238005);
                    }
                    return true;
                case 77238006://地缚神 卡帕克指引者(ZCG)
                    if (ActivateDescription == Util.GetStringId(77238006, 1))
                    {
                        if (Enemy.Hand.Count <= 0) return false;
                        if (Bot.GetMonsterCount() + Bot.GetSpellCount() < 1) return false;
                        SetState(State.SendToGrave, CardLocation.Grave, CardLocation.Onfield, 0, false);
                        List<ClientCard> card77238006 = GetZoneOperateCards(false,false,true,false);
                        if (card77238006.Count <= 0) return false;
                        AI.SelectCard(card77238006);
                    }
                    return true;
                case 77238007://地缚神 卡拉指引者(ZCG)
                    if (ActivateDescription == Util.GetStringId(77238007, 1))
                    {
                        if (Enemy.LifePoints <= 500) return true;
                        SetState(State.SendToGrave, CardLocation.Grave, CardLocation.Hand, 0, false);
                        List<ClientCard> card77238007 = GetZoneOperateCards(false,false,false);
                        if (card77238007.Count <= 0) return false;
                        AI.SelectCard(card77238007);
                    }
                    return true;
                case 77238009:
                    SetState(State.SendToDeck, CardLocation.Deck, CardLocation.Hand, 0, false);
                    List<ClientCard> card77238009 = GetZoneOperateCards(false, false, false);
                    if (card77238009.Count <= 0) return false;
                    AI.SelectCard(card77238009);
                    return false;
                case 77238015:
                    if ((Bot.GetMonsterCount() < Enemy.GetMonsterCount() && GetBestPlayer(true) != 0)
                        || (GetBestPlayer(true) != 0))
                    {
                        SetState(State.Remove, CardLocation.Removed, CardLocation.MonsterZone, 0, false,true);
                        SetState_2(State.Spsummon, CardLocation.MonsterZone, CardLocation.Grave |CardLocation.Deck, 0, false,true,false,true,true,true);
                        return true;
                    }
                    return false;
                case 77238014://暗黑的爆发(ZCG)
                    SetState(State.Control, CardLocation.MonsterZone, CardLocation.MonsterZone, 1, true, true);
                    SetState_2(State.Spsummon, CardLocation.MonsterZone, CardLocation.Hand | CardLocation.Deck | CardLocation.Grave, 0, false, true,false,true,true,true);
                    return true;
                default:
                    ClearFlag();
                    return true;
            }
        }
        private List<ClientCard> GetBotOnfield()
        {
            List<ClientCard> m = Bot.GetMonsters();
            List<ClientCard> s = Bot.GetSpells();
            if (s.Count() >= 0) m.AddRange(s);
            return s;
        }
        private List<ClientCard> SortCards(List<ClientCard> cards,ClientField player)
        {
            if (player == Bot)
            {
                List<ClientCard> s = cards.Where(card => card != null && card.HasType(CardType.Spell | CardType.Trap)).ToList();
                List<ClientCard> m = cards.Where(card => card != null && card.HasType(CardType.Monster)).ToList();
                if (m.Count >= 0) m.Sort(CardContainer.CompareCardAttack);
                s.AddRange(m);
                return s;
            }
            else
            {
                List<ClientCard> m = cards.Where(card => card != null && card.HasType(CardType.Monster)).ToList();
                List<ClientCard> s = cards.Where(card => card != null && card.HasType(CardType.Spell | CardType.Trap)).ToList();
                if (m.Count >= 0) { m.Sort(CardContainer.CompareCardAttack); m.Reverse(); }
                m.AddRange(s);
                return m;
            }
        }
        private List<int> GetZoneRemainCardsId(List<int> cardsId, CardLocation loc,ClientField player)
        {
            List<int> ids = new List<int>();
            if ((loc & CardLocation.Hand)>0) ids.AddRange(ClientCardsToCardsId(SortCards(player.GetHands(), player)));
            else if ((loc & CardLocation.MonsterZone) > 0) ids.AddRange(ClientCardsToCardsId(SortCards(player.GetMonsters(), player)));
            else if ((loc & CardLocation.SpellZone) > 0) ids.AddRange(ClientCardsToCardsId(SortCards(player.GetSpells(), player)));
            else if ((loc & CardLocation.Grave) > 0) ids.AddRange(ClientCardsToCardsId(SortCards(player.GetGraveyard(), player)));
            else if ((loc & CardLocation.Removed) > 0) ids.AddRange(ClientCardsToCardsId(SortCards(player.Banished.Where(card => card != null).ToList(), player)));
            else if ((loc & CardLocation.Extra) > 0) ids.AddRange(ClientCardsToCardsId(SortCards(player.ExtraDeck.Where(card => card != null).ToList(), player)));
            else return ids;
            if (cardsId.Count() <= 0) return ids;
            List<int> res = new List<int>();
            foreach (var id in ids)
            {
                if (!cardsId.Contains(id)) res.Add(id);
            }
            return res;
        }

        private bool _SpSummon_1()
        {
            if (!SpSummon_1.Contains(Card.Id)) return false;
            return _SpSummon();
        }
        private bool _SpSummon_2()
        {
            if (!SpSummon_2.Contains(Card.Id)) return false;
            return _SpSummon();
        }
        private bool _SpSummon_3()
        {
            return _SpSummon();
        }
        //特殊召唤怪兽
        private bool _SpSummon()
        {
            ClearFlag();
            if (HasForbear(Card)) return true;
            if (HasDisForber(Card)) return false;
            switch (Card.Id)
            {
                case 77238045://碎魂者 铁爪死神(ZCG)
                    SetState(State.DisCard, CardLocation.Grave, CardLocation.Hand, 0, false,true);
                    return true;
                case 77238034://殉道者 天翼魔蝠(ZCG)
                case 77238047://碎魂者 拟人怪(ZCG)
                    List<ClientCard> cards = Bot.GetHands();
                    cards.Remove(Card);
                    if (cards.Count <= 0) return false;
                    cards.Sort(CardContainer.CompareCardAttack);
                    cards.Reverse();
                    AI.SelectCard(cards);
                    return true;
                case 77238002://地缚神 瑟梭·亚库(ZCG)
                    SetState(State.MonsterRelease, CardLocation.Grave, CardLocation.MonsterZone, 0, false);
                    List<ClientCard> cards77238002 = GetZoneOperateCards();
                    if (cards77238002.Count >= 0)
                    {
                        cards77238002 = cards77238002.Where(card => card != null && card.HasSetcode(0x21)
                        && (card.Id!= 77238001 && card.Id!= 77238013 && card.Id != 77238022 && card.Id != 77238026
                         || card.IsDisabled())).ToList();
                        if (cards77238002.Count <= 0) return false;
                        AI.SelectCard(cards77238002);
                    } 
                    return true;
                case 77238009:
                    return true;
                case 77238012:
                    return Bot.LifePoints > 1000;
                default:
                    return true;
            }
        }
        private bool hasField(bool all)
        {
            ClientCard card = Bot.GetFieldSpellCard();
            ClientCard card_2 = Enemy.GetFieldSpellCard();
            if (!all)
            {
                return card != null && card.IsFaceup();
            }
            else
            {
                return (card != null && card.IsFaceup()) || (card_2 != null && card_2.IsFaceup());
            }

        }
        private bool _Summon_1()
        {
            if (!Summon_1.Contains(Card.Id)) return false;
            return _Summon();
        }
        private bool _Summon_2()
        {
            if (!Summon_2.Contains(Card.Id)) return false;
            return _Summon();
        }
        private bool _Summon_3()
        {
            return _Summon();
        }
        //召唤怪兽
        private bool _Summon()
        {
            ClearFlag();
            if (HasForbear(Card)) return true;
            if (HasDisForber(Card)) return Card.Level < 5;
            if (summon_no_release_cardsid.Contains(Card.Id)) return true;
            switch (Card.Id)
            {
                case 77238042://碎魂者 熔海邪神(ZCG)
                    SetState(State.MonsterRelease, CardLocation.Grave, CardLocation.MonsterZone, 1, false,true,false);
                    return true;
                case 77238048:
                    return false;
                case 77238050:
                    return Bot.GetMonsters().Count(card => card != null && card.IsFaceup() && card.HasSetcode(0xa160)) > 1;
                default:
                    break;
            }
            List<int> DiFuShenId = new List<int>(){ 77238009, 77238010, 77238011 , 77238012
            ,77238013};
            if (DiFuShenId.Contains(Card.Id))
            {
                if (!hasField(true)) return false;
                if (Enemy.LifePoints <= Card.Attack) return true;
            }
            if (Card.Level > 4 && Card.Level < 7)
            {
                List<ClientCard> cards = Bot.GetMonsters();
                if (cards.Count <= 0) return false;
                cards.Sort(CardContainer.CompareCardAttack);
                if (cards[0].Attack >= Card.Attack) return false;
                //解放召唤
                return true;
                
            }
            if (Card.Level > 6)
            {
                List<ClientCard> cards = Bot.GetMonsters();
                if (cards.Count <= 1) return false;
                cards.Sort(CardContainer.CompareCardAttack);
                switch (Card.Id)
                {
                    case 77238013:
                        AI.SelectCard(cards);
                        return true;
                    default:
                        break;
                }
                if (cards[0].Attack >= Card.Attack || cards[1].Attack >= Card.Attack) return false;
                AI.SelectCard(cards);
                return true;
            }
            return true;
        }
    }
}
