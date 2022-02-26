using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using System.Linq;
using System;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
namespace WindBot.Game.AI.Decks
{
    [Deck("TrueKing", "AI_TrueKing", "NotFinished")]
    public class TrueKingExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int Zshiti = 88710017;
            public const int Zfeng = 94160895;
            public const int Zshui = 82321037;
            public const int Zlv8 = 72100042;
            public const int Zlv6 = 94982447;
            public const int Xinniang = 63790505;
            public const int Buludun = 9950799;
            public const int Zlv2 = 72100043;
            public const int Menhui = 9951558;
            public const int Mshijieshu = 9982135;
            public const int Mgaizao = 73628505;
            public const int Mjicheng = 49430782;
            public const int Myuhua = 72100044;
            public const int Mshitu = 75425320;
            public const int Mlongshenzhen = 13035077;
            public const int Mdiwanglingyu = 83000066;
            public const int Xzaixing = 20426907;
            public const int Xfuhuo = 35125879;
            public const int Xjiefang = 118776531;

            public const int Zfawangshou = 88581108;
            public const int Zfawang = 88710018;
        }
        //使徒魔法卡
        bool MjichengActivate = false;
        bool MshituActivate = false;

        bool XjiefangSummon = false;
        bool XjiefangActivate = false;

        bool ZfawangSpsummon = false;
        bool ZfawangSpsummonv2 = false;
        bool ZfawangActivateInGrave = false;

        bool MyuhuaActivate = false;
        bool Mlongshenzhen = false;

        bool ZfengActivate = false;
        bool ZshuiActivate = false;

        bool Zlv2Activate = false;
        bool XjiefangActivateInHand = false;
        bool ZshitiSummonInHand = false;
        public TrueKingExecutor(GameAI ai, Duel duel)
   : base(ai, duel)
        {

            //魔 继承 抽卡
            AddExecutor(ExecutorType.Activate, CardId.Mjicheng, MshituEffect2);
            //魔 使徒 抽卡
            AddExecutor(ExecutorType.Activate, CardId.Mshitu, MshituEffect2);

            //覆盖真龙魔陷
            AddExecutor(ExecutorType.SpellSet, SpellZaiXing);
            //魔 世界树
            AddExecutor(ExecutorType.Activate, CardId.Mshijieshu, MshijieshuEffect);
            //魔 星球改造
            AddExecutor(ExecutorType.Activate, CardId.Mgaizao, MgaizaoEffect);
            //布鲁顿
            AddExecutor(ExecutorType.Activate, CardId.Buludun, MgaizaoEffect);
            //魔 龙神阵
            AddExecutor(ExecutorType.Activate, CardId.Mlongshenzhen, MlongshenzhenEffect);
            //魔 羽化
            AddExecutor(ExecutorType.Activate, CardId.Myuhua, MyuhuaEffect);

            //魔 恩惠
            AddExecutor(ExecutorType.Activate, CardId.Menhui);

            //真龙复制效果
            AddExecutor(ExecutorType.Activate, CopyEffect);

            //陷 解放
            AddExecutor(ExecutorType.Activate, CardId.Xjiefang, XjiefangEffect);

            //魔 龙神阵-发动
            AddExecutor(ExecutorType.Activate, CardId.Mlongshenzhen, MlongshenzhenHandEffect);

            //盖放发动
            AddExecutor(ExecutorType.Activate, ActiveEffect);

            //真龙 LV2
            AddExecutor(ExecutorType.Summon, CardId.Zlv2);

            //真龙 噬体
            AddExecutor(ExecutorType.Activate, CardId.Zshiti, ZshitiEffect);

            //魔 继承
            AddExecutor(ExecutorType.Activate, CardId.Mjicheng, MshituEffect);
            //魔 使徒
            AddExecutor(ExecutorType.Activate, CardId.Mshitu, MshituEffect);
            //陷 复活
            AddExecutor(ExecutorType.Activate, CardId.Xfuhuo , MshituEffect);

            //陷 再兴
            AddExecutor(ExecutorType.Activate, CardId.Xzaixing, XzaixingEffect);
            //真龙 风
            AddExecutor(ExecutorType.Activate, CardId.Zfeng, ZfengEffect);
            //真龙 水
            AddExecutor(ExecutorType.Activate, CardId.Zshui, ZshuiEffect);


            //新娘
            AddExecutor(ExecutorType.Summon, CardId.Xinniang);
            //新娘
            AddExecutor(ExecutorType.Activate, CardId.Xinniang, XinniangEffect);

            //真龙 噬体
           //AddExecutor(ExecutorType.Summon, CardId.Zshiti, ZshitiSummon);

            //真龙 LV2
            AddExecutor(ExecutorType.Activate, CardId.Zlv2, Zlv2Effect);

            //真龙 LV6
            AddExecutor(ExecutorType.Summon, CardId.Zlv6, Zlv8Summon);
            //真龙 LV6
            AddExecutor(ExecutorType.Activate, CardId.Zlv6, Zlv6Effect);


            //真龙 LV8
            AddExecutor(ExecutorType.Summon, CardId.Zlv8, Zlv8Summon);
            //真龙 LV8
            AddExecutor(ExecutorType.Activate, CardId.Zlv8, Zlv8Effect);

            //覆盖真龙魔陷
            AddExecutor(ExecutorType.SpellSet, SpellEffect);


            //真龙 法王
            AddExecutor(ExecutorType.SpSummon, CardId.Zfawang, ZfawangSummon);
            //真龙 法王
            AddExecutor(ExecutorType.Activate, CardId.Zfawang, ZfawangEffect);

            //真龙 法王兽
            AddExecutor(ExecutorType.SpSummon, CardId.Zfawangshou, ZfawangshouSummon);
            //真龙 法王兽
            AddExecutor(ExecutorType.Activate, CardId.Zfawangshou, ZfawangshouEffect);

            //陷 复活
            AddExecutor(ExecutorType.Activate, CardId.Xfuhuo, XfuhuoEffect);
            //帝王领域
            AddExecutor(ExecutorType.Activate, CardId.Mdiwanglingyu, MdiwanglingyuEffect);
            //陷 解放
            AddExecutor(ExecutorType.Activate, CardId.Xjiefang, XjiefangEffect2);
            //真龙 法王
            AddExecutor(ExecutorType.Activate, CardId.Zfawang, ZfawangEffect2);

            //覆盖真龙魔陷2
            AddExecutor(ExecutorType.SpellSet, SpellZaiXing2);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
        }
        //新回合
        public override void OnNewTurn()
        {
            Mlongshenzhen = false;

            XjiefangSummon = false;
            XjiefangActivate = false;

            ZfawangSpsummon = false;
            ZfawangSpsummonv2 = false;
            ZfawangActivateInGrave = false;

            ZfengActivate = false;
            ZshuiActivate = false;

            Zlv2Activate = false;

            MyuhuaActivate = false;

            //永续魔法 抽卡
            MjichengActivate = false;
            MshituActivate = false;

            XjiefangActivateInHand = false;
            ZshitiSummonInHand = false;
        }
        //卡组检查
        public int CheckRemainInDeck(int id)
        {
            switch (id)
            {
                case CardId.Zshiti:
                    return Bot.GetRemainingCount(CardId.Zshiti, 3);
                case CardId.Zfeng:
                    return Bot.GetRemainingCount(CardId.Zfeng, 3);
                case CardId.Zshui:
                    return Bot.GetRemainingCount(CardId.Zshui, 3);
                case CardId.Zlv8:
                    return Bot.GetRemainingCount(CardId.Zlv8, 2);
                case CardId.Zlv6:
                    return Bot.GetRemainingCount(CardId.Zlv6, 2);
                case CardId.Xinniang:
                    return Bot.GetRemainingCount(CardId.Xinniang, 1);
                case CardId.Buludun:
                    return Bot.GetRemainingCount(CardId.Buludun, 1);
                case CardId.Zlv2:
                    return Bot.GetRemainingCount(CardId.Zlv2, 3);
                case CardId.Menhui:
                    return Bot.GetRemainingCount(CardId.Menhui, 3);
                case CardId.Mshijieshu:
                    return Bot.GetRemainingCount(CardId.Mshijieshu, 3);
                case CardId.Mgaizao:
                    return Bot.GetRemainingCount(CardId.Mgaizao, 3);
                case CardId.Mjicheng:
                    return Bot.GetRemainingCount(CardId.Mjicheng, 1);
                case CardId.Myuhua:
                    return Bot.GetRemainingCount(CardId.Myuhua, 3);
                case CardId.Mshitu:
                    return Bot.GetRemainingCount(CardId.Mshitu, 1);
                case CardId.Mlongshenzhen:
                    return Bot.GetRemainingCount(CardId.Mlongshenzhen, 3);
                case CardId.Mdiwanglingyu:
                    return Bot.GetRemainingCount(CardId.Mdiwanglingyu, 1);
                case CardId.Xzaixing:
                    return Bot.GetRemainingCount(CardId.Xzaixing, 1);
                case CardId.Xfuhuo:
                    return Bot.GetRemainingCount(CardId.Xfuhuo, 1);
                case CardId.Xjiefang:
                    return Bot.GetRemainingCount(CardId.Xjiefang, 2);
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
        public override CardPosition OnSelectPosition(int cardId, IList<CardPosition> positions)
        {
            YGOSharp.OCGWrapper.NamedCard cardData = YGOSharp.OCGWrapper.NamedCard.Get(cardId);
            if (cardData != null)
            {
                if (Util.IsAllEnemyBetterThanValue(cardData.Attack, true) && !(cardData.HasType(CardType.Xyz) && !Card.IsDisabled()))
                    return CardPosition.FaceUpDefence;
                return CardPosition.FaceUpAttack;
            }
            return 0;
        }
        public override bool OnSelectYesNo(long desc)
        {
            if (desc == 94)
            {
                return false;
            }
            return base.OnSelectYesNo(desc);
        }
        public override IList<ClientCard> OnSelectCard(IList<ClientCard> _cards, int min, int max, long hint, bool cancelable)
        {
            ClientCard chainCard = Util.GetLastChainCard();
            if ((_cards.Contains(Bot.SpellZone[0]) || _cards.Contains(Bot.SpellZone[4]))
                 && !_cards.Contains(Enemy.MonsterZone[0]) && !_cards.Contains(Bot.SpellZone[5])
                 && !_cards.Contains(Bot.Hand[0]) && !chainCard.IsCode(CardId.Zfawang)
                 && !ZshitiSummonInHand  && !_cards.Contains(Bot.ExtraDeck[0]))

            {
                {
                    IList<ClientCard> clients = new List<ClientCard>(_cards);
                    if (max > clients.Count)
                    {
                        max = clients.Count;
                    }
                    List<ClientCard> result = new List<ClientCard>();
                    result.AddRange(clients.Where(card => !card.IsCode(CardId.Zshiti)));
                    for (int num = 0; num < result.Count; num++)
                    {
                        if (result[num].Id == CardId.Xjiefang || result[num].Id == CardId.Zlv2
                            || result[num].Id == CardId.Zlv6 || result[num].Id == CardId.Zfawang)
                        {
                            ClientCard card = result[0];
                            result[0] = result[num];
                            result[num] = card;
                        }
                    }
                    if (result.Count > 1)
                    {
                        for (int num = 1; num < result.Count; num++)
                        {
                            if (result[num].Location == CardLocation.SpellZone)
                            {
                                ClientCard card = result[num];
                                result[1] = result[num];
                                result[num] = card;
                            }
                        }
                    }
                    return Util.CheckSelectCount(result, clients, min, max);
                }
            }
            return null;
        }
        //机壳 再星
        private bool SpellZaiXing()
        {
            return Card.IsCode(CardId.Xzaixing) && Bot.GetSpellCountWithoutField()<4;
        }
        //机壳 再星
        private bool SpellZaiXing2()
        {
            return Card.IsCode(CardId.Xzaixing);
        }
        //陷 再星
        private bool XzaixingEffect()
        {
            return Card.IsFacedown() && Card.Location!=CardLocation.Hand
                   && (Bot.HasInMonstersZone(CardId.Zshiti,false,false,true)
                   || Bot.HasInSpellZone(CardId.Zshiti, false, true));
        }
        //盖放发放
        private bool ActiveEffect()
        {
            if (Card.Location == CardLocation.Hand && !Card.IsCode(CardId.Xjiefang) && !Card.IsCode(CardId.Xzaixing))
            {
                if (Card.HasType(CardType.Continuous) && Card.HasSetcode(0xf9))
                {
                    return Bot.GetSpellCountWithoutField() < 5;
                }
            }
            if (Card.Location == CardLocation.SpellZone)
            {
                if (Card.IsFacedown() && Card.HasType(CardType.Continuous) && Card.HasSetcode(0xf9))
                {
                    return true;
                }
            }
            return false;
        }
        //陷阱 复活
        private bool XfuhuoEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Xfuhuo, 0))
            {
                ClientCard card = Util.GetLastChainCard();
                if (card != null && Duel.CurrentChain.Count > 0 && Duel.Player==0) return false;
                if (Duel.Player == 0 && Duel.Phase == DuelPhase.Main1) return false;
                if (Bot.HasInSpellZone(CardId.Myuhua, true, true))
                {
                    AI.SelectCard(CardId.Zlv8,CardId.Zshui, CardId.Zfeng);
                }
                else
                {
                    AI.SelectCard(CardId.Zshui, CardId.Zfeng, CardId.Zlv8);
                }
                return true;
            }
            return false;
        }
        //真龙 法王兽
        private bool ZfawangshouEffect()
        {
            if (Duel.Player == 1)
            {
                ClientCard card = Util.GetLastChainCard();
                if (card != null && card.IsCode(CardId.Zfawangshou) && card.Controller == 0)
                    return false;
                AI.SelectAttribute(CardAttribute.Divine);
                return true;
            }
            return false;
        }
        //帝王领域
        private bool MdiwanglingyuEffect()
        {
            if (Card.Location == CardLocation.Hand || (Card.IsFacedown()
               && Card.Location == CardLocation.SpellZone))
            {
                return true;
            }
            if (ActivateDescription == Util.GetStringId(CardId.Mdiwanglingyu, 0))
            {
                if (Bot.GetMonsterCount() < 1) return false;
                AI.SelectCard(CardId.Zshiti,CardId.Zfawangshou,CardId.Zlv8);
                return true;
            }
            if (ActivateDescription == Util.GetStringId(CardId.Mdiwanglingyu, 1))
            {
                ClientCard card = Util.GetLastChainCard();
                if (!Bot.HasInHand(CardId.Zshiti) && !Bot.HasInHand(CardId.Zlv6)) return false;
                else if (card != null && card.Controller == 0) return false;
                else if (Bot.HasInHand(CardId.Zshiti) && !Bot.HasInMonstersZone(CardId.Zshiti) && GetCountCardInZone(Bot.SpellZone) > 0)
                {
                    AI.SelectCard(CardId.Zshiti, CardId.Zlv6);
                    return true;
                }
                else if (Bot.HasInHand(CardId.Zlv6))
                {
                    AI.SelectCard(CardId.Zlv6, CardId.Zshiti);
                    return true;
                }
                else if (Bot.HasInHand(CardId.Zlv8) && !Bot.HasInMonstersZone(CardId.Zlv8))
                {
                    int number = 0;
                    for (int num = 1; num < 4; num++)
                    {
                        if (Bot.SpellZone[num] != null && Bot.SpellZone[num].HasType(CardType.Continuous))
                        {
                            number += 1;
                        }
                    }
                    if (Bot.GetMonsterCount() + number < 2 || number < 1) return false;
                    AI.SelectCard(CardId.Zlv8, CardId.Zlv6, CardId.Zshiti);
                    return true;
                }
                return false;
            }
            return false;
        }
        //真龙 法王兽
        private bool ZfawangshouSummon()
        {
            foreach (ClientCard check in Bot.GetMonsters())
            {
                if (check.IsCode(CardId.Zfawangshou) && check.Overlays.Count > 0
                    && !check.IsDisabled())
                {
                    return false;
                }
            }
            List<ClientCard> monsters = Bot.GetMonsters();
            IList<ClientCard> clients = new List<ClientCard>();
            int materials = 0;
            monsters.Sort(CardContainer.CompareCardAttack);
            foreach (ClientCard card in monsters)
            {
                if (materials >= 2) break;
                if (card.IsFaceup() && card.Level == 9)
                {         
                    clients.Add(card);
                    materials += 1;
                }
            }
            if (clients.Count < 2) return false;
            AI.SelectMaterials(clients);
            return true;
        }
        //真龙复制效果
        private bool CopyEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Zshiti, 2) &&
                (Card.Id!=CardId.Zshiti || Card.Type!=(int)CardType.Pendulum))
            {
                if (CheckRemainInDeck(CardId.Myuhua) > 1 && Bot.GetSpellCountWithoutField()<4)
                {
                    AI.SelectCard(CardId.Myuhua);
                    AI.SelectOption(0);
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Xzaixing, CardId.Mjicheng, CardId.Mshitu,CardId.Xjiefang);
                    AI.SelectOption(0);
                    return true;
                }
            }
            if (ActivateDescription == Util.GetStringId(CardId.Zshiti, 4) &&
                (Card.Id != CardId.Zshiti || Card.Type != (int)CardType.Pendulum))
            {
                AI.SelectCard(CardId.Zlv8);
                AI.SelectOption(1);
                AI.SelectAnnounceID(CardId.Zshiti);
                return true;
            }
            return false;
        }
        //覆盖魔陷
        private bool SpellEffect()
        {
            return Card.HasSetcode(0xf9) || (Card.HasSetcode(0xaa) && Card.HasType(CardType.Trap));
        }
        //真龙 LV6
        private bool Zlv6Effect()
        {
            if (Card.Location != CardLocation.MonsterZone)
            {
                if (CheckRemainInDeck(CardId.Zfeng) > 0 && !ZfengActivate)
                {
                    AI.SelectCard(CardId.Zfeng);
                }
                else if (CheckRemainInDeck(CardId.Zshui) > 0 && !ZshuiActivate)
                {
                    AI.SelectCard(CardId.Zshui);
                }
                else if (CheckRemainInDeck(CardId.Zlv2) > 0)
                {
                    AI.SelectCard(CardId.Zlv2);
                }
                else
                {
                    AI.SelectCard(CardId.Zlv2);
                }
                return true;
            }
            return false;
        }
        //真龙 LV8
        private bool Zlv8Effect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Zlv8, 1))
            {
                ClientCard card = Util.GetLastChainCard();
                if (!Bot.HasInHand(CardId.Zshiti) && !Bot.HasInHand(CardId.Zlv6)) return false;
                else if (card != null && card.Controller == 0) return false;
                else if (Bot.HasInHand(CardId.Zshiti) && !Bot.HasInMonstersZone(CardId.Zshiti) && GetCountCardInZone(Bot.SpellZone) > 0)
                {
                    AI.SelectCard(CardId.Zshiti, CardId.Zlv6);
                    return true;
                }
                else if (Bot.HasInHand(CardId.Zlv6))
                {
                    AI.SelectCard(CardId.Zlv6, CardId.Zshiti);
                    return true;
                }
                else if (Bot.HasInHand(CardId.Zlv8) && !Bot.HasInMonstersZone(CardId.Zlv8))
                {
                    int number = 0;
                    for (int num = 1; num < 4; num++)
                    {
                        if (Bot.SpellZone[num] != null && Bot.SpellZone[num].HasType(CardType.Continuous))
                        {
                            number += 1;
                        }
                    }
                    if (Bot.GetMonsterCount() + number < 2 || number < 1) return false;
                    AI.SelectCard(CardId.Zlv8, CardId.Zlv6, CardId.Zshiti);
                    return true;
                }
                return false;
            }
            else
            {        
                AI.SelectCard(CardId.Mdiwanglingyu);
                AI.SelectOption(0);
                return true;
            }
        }
        //真龙 噬体
        private bool ZshitiSummon()
        {
            if ((Bot.HasInMonstersZone(CardId.Zshiti) && Bot.GetMonsterCount() < 2)||
                (Bot.HasInMonstersZone(CardId.Zfawangshou) && Bot.HasInMonstersZone(CardId.Zshiti)))
                return false;
            ZshitiSummonInHand = true;
            IList<ClientCard> list = new List<ClientCard>();
            List<ClientCard> monsters = Bot.GetMonsters();
            monsters.Sort(CardContainer.CompareCardAttack);
            foreach (ClientCard card in monsters)
            {
                if ((!card.IsCode(CardId.Zshiti) && !card.IsCode(CardId.Zfawangshou) && (card.HasSetcode(0xf9) || card.HasSetcode(0xaa)
                   || card.HasSetcode(0xbe) || card.HasSetcode(0xe0)))
                   || (card.IsCode(CardId.Zfawangshou) && card.Overlays.Count <= 0))
                {

                    list.Add(card);
                }
            }
            if (list.Count < 1) return false;
            IList<int> cardid = new List<int>()
            {
              CardId.Xjiefang,CardId.Myuhua,CardId.Zfawangshou
            };
            foreach (ClientCard check in list)
            {
                cardid.Add(check.Id);
            }
            AI.SelectCard(cardid);
            ZshitiSummonInHand = false;
            /*
            AI.SelectCard(CardId.Zlv2, CardId.Zfawang, CardId.Zlv6
                          , CardId.Zlv8, CardId.Zshui, CardId.Zfeng
                          , CardId.Xjiefang, CardId.Myuhua, CardId.Xfuhuo,
                          CardId.Mjicheng, CardId.Mshitu, CardId.Zfawangshou);
                          */
            return true;
        }
        //真龙 噬体
        private bool ZshitiEffect()
        {
            //卡片检索
            if (ActivateDescription == Util.GetStringId(CardId.Zshiti, 2))
            {
                if (Bot.GetMonsterCount() < 2 && CheckRemainInDeck(CardId.Xzaixing) > 1)
                {
                    AI.SelectCard(CardId.Xzaixing);
                    AI.SelectOption(0);
                    return true;
                }
                else if (CheckRemainInDeck(CardId.Myuhua) > 1)
                {
                    AI.SelectCard(CardId.Myuhua);
                    AI.SelectOption(0);
                    return true;
                }
                else if (CheckRemainInDeck(CardId.Mjicheng) > 0 && !MjichengActivate)
                {
                    AI.SelectCard(CardId.Mjicheng);
                    AI.SelectOption(0);
                    return true;
                }
                else if (CheckRemainInDeck(CardId.Mshitu) > 0 && !MshituActivate)
                {
                    AI.SelectCard(CardId.Mshitu);
                    AI.SelectOption(0);
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Xzaixing);
                    AI.SelectOption(0);
                    return true;
                }
            }
            //宣言
            if (ActivateDescription == Util.GetStringId(CardId.Zshiti, 4))
            {
                AI.SelectCard(CardId.Zlv8);
                AI.SelectOption(1);
                AI.SelectAnnounceID(CardId.Zshiti);
                return true;
            }
            //发动无效
            if (ActivateDescription == Util.GetStringId(CardId.Zshiti, 6))
            {
                ClientCard card = Util.GetLastChainCard();
                if (card != null && card.Controller != 0)
                {
                    return true;
                }
                return false;
            }
            if (Card.Location == CardLocation.MonsterZone || Card.Location == CardLocation.Hand)
            {
                AI.SelectYesNo(true);
                if (Bot.HasInHand(CardId.Mlongshenzhen) && CheckRemainInDeck(CardId.Zfeng) > 0 && !ZfengActivate)
                {
                    AI.SelectCard(CardId.Zfeng);
                }
                else if (Bot.HasInHand(CardId.Mlongshenzhen) && CheckRemainInDeck(CardId.Zshui) > 0 && !ZshuiActivate)
                {
                    AI.SelectCard(CardId.Zshui);
                }
                else if (CheckRemainInDeck(CardId.Zlv2) > 0)
                {
                    AI.SelectCard(CardId.Zlv2);
                }
                else
                {
                    AI.SelectCard(CardId.Zlv2);
                }
                return true;
            }
            return false;
        }
        //真龙 使徒
        private bool MshituEffect()
        {
            if (Card.Location == CardLocation.Grave)
            {
                List<ClientCard> list = Enemy.MonsterZone.GetSpells();
                foreach (ClientCard card in list)
                {
                    if (card.IsShouldNotBeTarget() && !card.IsDisabled())
                    {
                        list.Remove(card);
                    }
                }
                List<ClientCard> list2 = Enemy.GetSpells();
                foreach (ClientCard card2 in list2)
                {
                    if (card2.IsShouldNotBeTarget() && !card2.IsDisabled())
                    {
                        list2.Remove(card2);
                    }
                }
                var clientList = list.Union(list2).ToList();
                if (clientList.Count < 1) return false;
                AI.SelectCard(clientList);
                return true;
            }
            else
            {
                //继承 抽卡
                if (ActivateDescription == Util.GetStringId(CardId.Mjicheng, 0))
                {
                    MjichengActivate = true;
                    return true;
                }
                //继承 召唤 + 使徒 召唤+复活 召唤
                if (ActivateDescription == Util.GetStringId(CardId.Mjicheng, 1)
                    || ActivateDescription == Util.GetStringId(CardId.Mshitu, 1)
                    || ActivateDescription == Util.GetStringId(CardId.Xfuhuo, 1))
                {
                    if (Bot.HasInHand(CardId.Zshiti) && !Bot.HasInMonstersZone(CardId.Zshiti)
                      && (ZfawangSpsummon || Bot.GetMonsterCount() > 1) && GetCountCardInZone(Bot.SpellZone) > 0)
                    {
                        AI.SelectCard(CardId.Zshiti, CardId.Zlv6);
                        return true;
                    }
                    else if (Bot.HasInHand(CardId.Zlv6))
                    {
                        AI.SelectCard(CardId.Zlv6, CardId.Zshiti);
                        return true;
                    }
                    else if (Bot.HasInHand(CardId.Zlv8) && !Bot.HasInMonstersZone(CardId.Zlv8))
                    {
                        int number = 0;
                        for (int num = 1; num < 4; num++)
                        {
                            if (Bot.SpellZone[num] != null && Bot.SpellZone[num].HasType(CardType.Continuous))
                            {
                                number += 1;
                            }
                        }
                        if (Bot.GetMonsterCount() + number < 2 || number < 1) return false;
                        AI.SelectCard(CardId.Zlv8, CardId.Zlv6, CardId.Zshiti);
                        return true;
                    }
                    return false;
                }
                //使徒 抽卡
                if (ActivateDescription == Util.GetStringId(CardId.Mshitu, 0))
                {
                    AI.SelectCard(CardId.Zfawangshou, CardId.Myuhua, CardId.Xjiefang, CardId.Zshui, CardId.Zfeng);
                    MshituActivate = true;
                    return true;
                }
                return false;

            }
        }
        //真龙 使徒
        private bool MshituEffect2()
        {
            //使徒 抽卡
            if (ActivateDescription == Util.GetStringId(CardId.Mshitu, 0))
            {
                AI.SelectCard(CardId.Zfawangshou, CardId.Myuhua, CardId.Xjiefang, CardId.Zshui, CardId.Zfeng);
                MshituActivate = true;
                return true;
            }
            return false;
        }
        //真龙 LV8
        private bool Zlv8Summon()
        {
            if (Bot.HasInSpellZone(CardId.Xjiefang, false, true) && XjiefangSummon)
            {
                AI.SelectCard(CardId.Xjiefang);
                return true;
            }
            else
            {
                AI.SelectCard(CardId.Xjiefang,CardId.Myuhua);
                return true;
            }

        }
        //真龙 法王
        private bool ZfawangSummon()
        {
            if (!ZfawangSpsummon)
            {
                if (Bot.GetCountCardInZone(Bot.MonsterZone, CardType.Monster, 0xf9) < 2
                   && Bot.HasInMonstersZone(CardId.Zshiti, false, false, true))
                    return false;
                if (Bot.GetCountCardInZone(Bot.MonsterZone, CardId.Zshiti) >= Bot.GetMonsterCount())
                    return false;
                if (Bot.HasInMonstersZone(CardId.Zfawangshou, true, true, true)) return false;
                IList<ClientCard> cards = new List<ClientCard>();
                foreach (ClientCard card in Bot.GetMonsters())
                {
                    if (card.HasSetcode(0xf9) && card.HasType(CardType.Monster))
                    {
                        cards.Add(card);
                    }
                }
                List<ClientCard> list = new List<ClientCard>(cards);
                list.Sort(CardContainer.CompareCardAttack);
                list.Sort(CardContainer.CompareCardLevel);
                for (int num = 0;num < list.Count; num++)
                {
                    if (list[num].IsCode(CardId.Zlv6))
                    {
                        ClientCard card = list[0];
                        list[0] = list[num];
                        list[num] = card;
                    }
                }
                AI.SelectCard(list);
                ZfawangSpsummon = true;
                return true;
            }
            if (ZfawangSpsummon && Bot.HasInMonstersZone(CardId.Zfawang,false,false,true)
                && !ZfawangSpsummonv2 && !ZfawangActivateInGrave)
            {
                AI.SelectCard(CardId.Zfawang);
                ZfawangSpsummonv2 = true;
                return true;
            }
            return false;
        }

        //真龙 水
        private bool ZshuiEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                AI.SelectCard(CardId.Zshiti,CardId.Zshui,CardId.Xinniang,CardId.Zfeng);
                return true;
            }
            if (Card.Location != CardLocation.Hand)
            {
                if (!Bot.HasInHand(CardId.Zlv2) && !Zlv2Activate && CheckRemainInDeck(CardId.Zlv2) > 0)
                {
                    AI.SelectCard(CardId.Zlv2);
                    ZshuiActivate = true;
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Zfeng,CardId.Zlv8,CardId.Zlv6);
                    ZshuiActivate = true;
                    return true;
                }
            }
            return false;
        }

        //真龙 风
        private bool ZfengEffect()
        {
            if (Card.Location == CardLocation.Hand)
            {
                AI.SelectCard(CardId.Zshiti, CardId.Zfeng, CardId.Xinniang, CardId.Zshui);
                return true;
            }
            if (Card.Location != CardLocation.Hand)
            {
                if (!Bot.HasInHandOrHasInMonstersZone(CardId.Zlv2) && !Zlv2Activate && CheckRemainInDeck(CardId.Zlv2) > 0)
                {
                    AI.SelectCard(CardId.Zlv2);
                }
                else if (CheckRemainInDeck(CardId.Zshui) > 0 && !ZshuiActivate)
                {
                    AI.SelectCard(CardId.Zshui, CardId.Zlv6);
                }
                else if (CheckRemainInDeck(CardId.Zlv2) > 0 && !Bot.HasInHand(CardId.Zlv2))
                {
                    AI.SelectCard(CardId.Zlv2);
                }
                else
                {
                    AI.SelectCard(CardId.Zlv2,CardId.Zlv6);
                }
                ZfengActivate = true;
                return true;
            }
            return false;
        }
        //魔 世界树
        private bool MshijieshuEffect()
        {
            AI.SelectCard(CardId.Zshiti,CardId.Xzaixing);
            return true;
        }
        //魔 星球改造
        private bool MgaizaoEffect()
        {
            AI.SelectCard(CardId.Mlongshenzhen, CardId.Mdiwanglingyu);
            return true;
        }
        //真龙 法王
        private bool ZfawangEffect2()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Zfawang, 2))
            {
                if (Bot.GetMonsterCount() < 2) return false;
                AI.SelectNumber(9);
                return true;
            }
            return false;

        }
        //真龙 法王
        private bool ZfawangEffect()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(CardId.Mlongshenzhen,CardId.Zshiti);
                return true;
            }
            else if (Card.Location == CardLocation.Grave)
            {
                if (ActivateDescription != Util.GetStringId(CardId.Zfawang, 2))
                {
                    if (Enemy.GetMonsterCount() + Enemy.GetSpellCount() > 0)
                    {
                        List<ClientCard> list = Enemy.MonsterZone.GetSpells();
                        foreach (ClientCard card in list)
                        {
                            if (card.IsShouldNotBeTarget() && !card.IsDisabled())
                            {
                                list.Remove(card);
                            }
                        }
                        List<ClientCard> list2 = Enemy.GetSpells();
                        foreach (ClientCard card2 in list2)
                        {
                            if (card2.IsShouldNotBeTarget() && !card2.IsDisabled())
                            {
                                list2.Remove(card2);
                            }
                        }
                        var clientList = list.Union(list2).ToList();
                        if (clientList.Count < 1) return false;
                        AI.SelectCard(clientList);
                        ZfawangActivateInGrave = true;
                        return true;
                    }
                    else
                    {
                        if (Bot.HasInSpellZone(CardId.Mlongshenzhen))
                        {
                            AI.SelectCard(CardId.Mlongshenzhen);
                        }
                        else if (Bot.SpellZone[0] != null && Bot.SpellZone[0].Id != CardId.Zshiti
                                && Bot.SpellZone[0].IsFaceup())
                        {
                            AI.SelectCard(Bot.SpellZone[0]);
                        }
                        else
                        {
                            AI.SelectCard(CardId.Mlongshenzhen);
                        }
                        ZfawangActivateInGrave = true;                   
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
        public int GetCountCardInZone(IEnumerable<ClientCard> cards)
        {
            return cards.Count(card => card != null  && (card.HasSetcode(0xf9) || card.HasSetcode(0xaa)
                   || card.HasSetcode(0xbe) || card.HasSetcode(0xe0)));
        }
        //真龙 LV2
        private bool Zlv2Effect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Zlv2, 1))
            {
                ClientCard card = Util.GetLastChainCard();
                if (Duel.CurrentChain.Count > 0 && (card.Id == Card.Id || card.Controller == 0)) return false;
                else
                {
                    if (Bot.HasInHand(CardId.Zshiti) && !Bot.HasInMonstersZone(CardId.Zshiti)
                        && (ZfawangSpsummon || Bot.GetMonsterCount()>1) && GetCountCardInZone(Bot.SpellZone)>0)
                    {
                        AI.SelectCard(CardId.Zshiti,CardId.Zlv6);
                        return true;
                    }
                    else if (Bot.HasInHand(CardId.Zlv6))
                    {
                        AI.SelectCard(CardId.Zlv6, CardId.Zshiti);
                        return true;
                    }
                    else if (Bot.HasInHand(CardId.Zlv8) && !Bot.HasInMonstersZone(CardId.Zlv8))
                    {
                        int number = 0;
                        for (int num = 1; num < 4; num++)
                        {
                            if (Bot.SpellZone[num] != null && Bot.SpellZone[num].HasType(CardType.Continuous))
                            {
                                number += 1;
                            }
                        }
                        if (Bot.GetMonsterCount() + number < 2 || number < 1) return false;
                        AI.SelectCard(CardId.Zlv8,CardId.Zlv6, CardId.Zshiti);
                        return true;
                    }
                    return false;
                }
            }
            else if (ActivateDescription != Util.GetStringId(CardId.Zlv2, 0))
            {
                AI.SelectCard(CardId.Zlv8);
                Zlv2Activate = true;
                return true;
            }
            return false;
        }
        //陷 解放
        private bool XjiefangEffect2()
        {
             if (Card.Location == CardLocation.Hand)
             {
                if (Bot.HasInSpellZone(CardId.Xjiefang, false, true)) return false;
                if (XjiefangActivate) return false;
                return Bot.GetSpellCountWithoutField() < 4;
             }
            return false;
        }
        //陷 解放
        private bool XjiefangEffect()
        {
            if (Card.Location == CardLocation.SpellZone)
            {
                ClientCard card = Util.GetLastChainCard();
                if (Duel.LastChainPlayer == 0 && card != null && card.IsCode(CardId.Zlv2)) return false;
                else if (Bot.HasInHand(CardId.Zshiti) && !Bot.HasInMonstersZone(CardId.Zshiti)
                      && (ZfawangSpsummon || Bot.GetMonsterCount() > 1) && GetCountCardInZone(Bot.SpellZone) > 0)
                {
                    AI.SelectCard(CardId.Zshiti, CardId.Zlv6);
                    XjiefangSummon = true;
                    return true;
                }
                else if (Bot.HasInHand(CardId.Zlv6))
                {
                    AI.SelectCard(CardId.Zlv6, CardId.Zshiti);
                    XjiefangSummon = true;
                    return true;
                }
                else if (Bot.HasInHand(CardId.Zlv8) && !Bot.HasInMonstersZone(CardId.Zlv8))
                {
                    int number = 0;
                    for (int num = 1; num < 4; num++)
                    {
                        if (Bot.SpellZone[num] != null && Bot.SpellZone[num].HasType(CardType.Continuous))
                        {
                            number += 1;
                        }
                    }
                    if (Bot.GetMonsterCount() + number < 2 || number < 1) return false;
                    AI.SelectCard(CardId.Zlv8, CardId.Zlv6, CardId.Zshiti);
                    XjiefangSummon = true;
                    return true;
                }                   
                return false;
            }
            else if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(CardId.Myuhua);
                XjiefangActivate = true;
                return true;
            }
            else if (Card.Location == CardLocation.Hand)
            {
                if (Bot.HasInSpellZone(CardId.Xjiefang,false,true) || XjiefangActivateInHand) return false;
                XjiefangActivateInHand = true;
                return true;
            }
            return false;
        }
        //魔 羽化
        private bool MyuhuaEffect()
        {
            if (Duel.LastChainPlayer != 0 && Duel.CurrentChain.Count>0) return true;
            else
            {
                AI.SelectYesNo(true);
                if (CheckRemainInDeck(CardId.Xjiefang) > 0 && !XjiefangActivate &&
                   !Bot.HasInHandOrInSpellZone(CardId.Xjiefang))
                {
                    AI.SelectCard(CardId.Xjiefang);
                }
                else if (CheckRemainInDeck(CardId.Mjicheng) > 0)
                {
                    AI.SelectCard(CardId.Mjicheng);
                }
                else if (CheckRemainInDeck(CardId.Mshitu) > 0)
                {
                    AI.SelectCard(CardId.Mshitu);
                }
                else
                {
                    AI.SelectCard(CardId.Mshitu);
                }
                MyuhuaActivate = true;
                return true;
            }

        }
        //魔 龙神阵 发动
        private bool MlongshenzhenHandEffect()
        {
            if (Card.Location == CardLocation.Hand) return true;
            return false;
        }
        //魔 龙神阵
        private bool MlongshenzhenEffect()
        {
            if (Card.Location != CardLocation.Hand)
            {
                if (Bot.HasInHand(CardId.Zshui) && !ZshuiActivate)
                {
                    AI.SelectCard(CardId.Zshui);
                    if (Bot.GetCountCardInZone(Bot.Hand, CardId.Zshiti) > 1)
                    {
                        AI.SelectNextCard(CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    }
                    else
                    {
                        AI.SelectNextCard(CardId.Zshiti, CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    }
                    Mlongshenzhen = true;
                    return true;
                }
                else if (Bot.HasInHand(CardId.Zfeng) && !ZfengActivate)
                {
                    AI.SelectCard(CardId.Zfeng);
                    if (Bot.GetCountCardInZone(Bot.Hand, CardId.Zshiti) > 1)
                    {
                        AI.SelectNextCard(CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    }
                    else
                    {
                        AI.SelectNextCard(CardId.Zshiti, CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    }
                    Mlongshenzhen = true;
                    return true;
                }
                else if (Bot.HasInHand(CardId.Zshiti) && (Bot.HasInMonstersZone(CardId.Zshui)
                        || Bot.HasInMonstersZone(CardId.Zfeng)) && !MyuhuaActivate)
                {
                    AI.SelectCard(CardId.Zshui, CardId.Zfeng, CardId.Zlv2, CardId.Mshijieshu,
                                 CardId.Zlv6, CardId.Zlv8, CardId.Xinniang, CardId.Menhui);
                    AI.SelectNextCard(CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    Mlongshenzhen = true;
                    return true;

                }
                else if (Bot.HasInHand(CardId.Zshiti))
                {
                    AI.SelectCard(CardId.Zshiti);
                    if (Bot.GetCountCardInZone(Bot.Hand, CardId.Zshiti) > 1)
                    {
                        AI.SelectNextCard(CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    }
                    else
                    {
                        AI.SelectNextCard(CardId.Zshiti, CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    }
                    Mlongshenzhen = true;
                    return true;
                }
                else if (Bot.HasInMonstersZone(CardId.Zshui) && !ZshuiActivate)
                {
                    AI.SelectCard(CardId.Zshui);
                    if (Bot.GetCountCardInZone(Bot.Hand, CardId.Zshiti) > 1)
                    {
                        AI.SelectNextCard(CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    }
                    else
                    {
                        AI.SelectNextCard(CardId.Zshiti, CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    }
                    Mlongshenzhen = true;
                    return true;
                }
                else if (Bot.HasInMonstersZone(CardId.Zfeng) && !ZfengActivate)
                {
                    AI.SelectCard(CardId.Zfeng);
                    if (Bot.GetCountCardInZone(Bot.Hand, CardId.Zshiti) > 1)
                    {
                        AI.SelectNextCard(CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    }
                    else
                    {
                        AI.SelectNextCard(CardId.Zshiti, CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    }
                    Mlongshenzhen = true;
                    return true;
                }
                else if (Bot.SpellZone[0] != null && Bot.SpellZone[0].Id != CardId.Zshiti && Bot.SpellZone[0].IsFaceup())
                {
                    AI.SelectCard(Bot.SpellZone[0]);
                    if (Bot.GetCountCardInZone(Bot.Hand, CardId.Zshiti) > 1)
                    {
                        AI.SelectNextCard(CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    }
                    else
                    {
                        AI.SelectNextCard(CardId.Zshiti, CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    }
                    Mlongshenzhen = true;
                    return true;
                }
                else if (Bot.HasInHandOrHasInMonstersZone(CardId.Xinniang))
                {
                    AI.SelectCard(CardId.Xinniang);
                    if (Bot.GetCountCardInZone(Bot.Hand, CardId.Zshiti) > 1)
                    {
                        AI.SelectNextCard(CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    }
                    else
                    {
                        AI.SelectNextCard(CardId.Zshiti, CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    }
                    Mlongshenzhen = true;
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.Zfawang, CardId.Xjiefang, CardId.Xinniang, CardId.Zlv8, CardId.Zlv6);
                    if (Bot.GetCountCardInZone(Bot.Hand, CardId.Zshiti) > 1)
                    {
                        AI.SelectNextCard(CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    }
                    else
                    {
                        AI.SelectNextCard(CardId.Zshiti, CardId.Myuhua, CardId.Xjiefang, CardId.Mjicheng, CardId.Mshitu);
                    }
                    Mlongshenzhen = true;
                    return true;
                }
            }
            return false;
        }
        //新娘
        private bool XinniangEffect()
        {
            if (ActivateDescription == Util.GetStringId(CardId.Xinniang, 0))
            {
                return false;
            }
            if (ActivateDescription == Util.GetStringId(CardId.Xinniang, 1))
            {
                AI.SelectAnnounceID(CardId.Zshui);
                return true;
            }
            if (Card.Location == CardLocation.SpellZone) return false;
            else
            {
                AI.SelectPlace(Zones.z4);
                return true;
            }
        }
    }
    
}
