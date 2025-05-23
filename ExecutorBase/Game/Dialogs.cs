using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace WindBot.Game.AI
{
    [DataContract]
    public class DialogsData
    {
        [DataMember]
        public string[] welcome { get; set; }
        [DataMember]
        public string[] deckerror { get; set; }
        [DataMember]
        public string[] duelstart { get; set; }
        [DataMember]
        public string[] newturn { get; set; }
        [DataMember]
        public string[] endturn { get; set; }
        [DataMember]
        public string[] directattack { get; set; }
        [DataMember]
        public string[] attack { get; set; }
        [DataMember]
        public string[] ondirectattack { get; set; }
        [DataMember]
        public string facedownmonstername { get; set; }
        [DataMember]
        public string[] activate { get; set; }
        [DataMember]
        public string[] summon { get; set; }
        [DataMember]
        public string[] setmonster { get; set; }
        [DataMember]
        public string[] chaining { get; set; }                                          
    }
    public class Dialogs
    {

        private string[] _welcome;
        private string[] _deckerror;
        private string[] _duelstart;
        private string[] _newturn;
        private string[] _endturn;
        private string[] _directattack;
        private string[] _attack;
        private string[] _ondirectattack;
        private string _facedownmonstername;
        private string[] _activate;
        private string[] _summon;
        private string[] _setmonster;
        private string[] _chaining;

        private Action<string, bool> Chat;

        private static Random Rand = new Random();

        public Dialogs(string dialogfilename, Action<string, bool> chat, string path)
        {
            Chat = chat;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DialogsData));
            using (FileStream fs = File.OpenRead(Path.Combine(path, "Dialogs/", dialogfilename + ".json")))
            {
                DialogsData data = (DialogsData)serializer.ReadObject(fs);
                _welcome = data.welcome;
                _deckerror = data.deckerror;
                _duelstart = data.duelstart;
                _newturn = data.newturn;
                _endturn = data.endturn;
                _directattack = data.directattack;
                _attack = data.attack;
                _ondirectattack = data.ondirectattack;
                _facedownmonstername = data.facedownmonstername;
                _activate = data.activate;
                _summon = data.summon;
                _setmonster = data.setmonster;
                _chaining = data.chaining;
            }
        }

        public void SendSorry()
        {
            InternalSendMessageForced(new[] { "Sorry, an error occurs." });
        }

        public void SendDeckSorry(string card)
        {
            if (card == "DECK")
                InternalSendMessageForced(new[] { "Deck illegal. Please check the database of your YGOPro and WindBot." });
            else
                InternalSendMessageForced(_deckerror, card);
        }
        ///// diy/////
        public void SendDownloadPrompt(int index)
        {
            switch (index)
            {
                case 0:
                    InternalSendMessageForced(new[] { "提示-本人机需先下载额外卡包（人机用卡包+ZCG卡包）解压至KCG主目录才可进行决斗！！！" });
                    InternalSendMessageForced(new[] { "详情请在KCG群文件中查找下载！！！" });
                    break;
                case 1:
                    InternalSendMessageForced(new[] { "模式指定人机【殉道者】|【六芒星】暂无法使用，暂未对指定卡片进行转换写入" });
                    InternalSendMessageForced(new[] { "模式ZCG万能人机仍在完善中，因人力原因，全部完成大概需几月左右时间，敬请期待！" });
                    break;
                default:
                    break;
            }

        }
        ///// diy/////
        public void SendWelcome()
        {
            InternalSendMessage(_welcome);
        }

        public void SendDuelStart()
        {
            InternalSendMessage(_duelstart);
        }

        public void SendNewTurn()
        {
            InternalSendMessage(_newturn);
        }

        public void SendEndTurn()
        {
            InternalSendMessage(_endturn);
        }

        public void SendDirectAttack(string attacker)
        {
            InternalSendMessage(_directattack, attacker);
        }

        public void SendAttack(string attacker, string defender)
        {
            if (defender=="monster")
            {
                defender = _facedownmonstername;
            }
            InternalSendMessage(_attack, attacker, defender);
        }

        public void SendOnDirectAttack(string attacker)
        {
            if (string.IsNullOrEmpty(attacker))
            {
                attacker = _facedownmonstername;
            }
            InternalSendMessage(_ondirectattack, attacker);
        }
        public void SendOnDirectAttack()
        {
            InternalSendMessage(_ondirectattack);
        }

        public void SendActivate(string spell)
        {
            InternalSendMessage(_activate, spell);
        }

        public void SendSummon(string monster)
        {
            InternalSendMessage(_summon, monster);
        }

        public void SendSetMonster()
        {
            InternalSendMessage(_setmonster);
        }

        public void SendChaining(string card)
        {
            InternalSendMessage(_chaining, card);
        }

        private void InternalSendMessage(IList<string> array, params object[] opts)
        {
            string message = string.Format(array[Rand.Next(array.Count)], opts);
            if (message != "")
                Chat(message, false);
        }

        private void InternalSendMessageForced(IList<string> array, params object[] opts)
        {
            string message = string.Format(array[Rand.Next(array.Count)], opts);
            if (message != "")
                Chat(message, true);
        }
    }
}
