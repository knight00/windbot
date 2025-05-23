﻿namespace YGOSharp.Network.Enums
{
    public enum CtosMessage
    {
        Response = 0x1,
        UpdateDeck = 0x2,
        HandResult = 0x3,
        TpResult = 0x4,
        PlayerInfo = 0x10,
        CreateGame = 0x11,
        JoinGame = 0x12,
        LeaveGame = 0x13,
        Surrender = 0x14,
        TimeConfirm = 0x15,
        Chat = 0x16,
        HsToDuelist = 0x20,
        HsToObserver = 0x21,
        /////kdiy//////////
        //HsReady = 0x22,
        HsReady = 0x28,
        /////kdiy//////////
        HsNotReady = 0x23,
        HsKick = 0x24,
        HsStart = 0x25,
        RematchResponse = 0xf0
    }
}
