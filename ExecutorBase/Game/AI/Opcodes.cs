namespace WindBot.Game.AI
{
    public static class Opcodes
    {
        public const long OPCODE_ADD = 0x4000000000000000,
        OPCODE_SUB = 0x4000000100000000,
        OPCODE_MUL = 0x4000000200000000,
        OPCODE_DIV = 0x4000000300000000,
        OPCODE_AND = 0x4000000400000000,
        OPCODE_OR = 0x4000000500000000,
        OPCODE_NEG = 0x4000000600000000,
        OPCODE_NOT = 0x4000000700000000,
        OPCODE_BAND = 0x4000000800000000,
        OPCODE_BOR = 0x4000000900000000,
        OPCODE_BNOT = 0x4000001000000000,
        OPCODE_BXOR = 0x4000001100000000,
        OPCODE_LSHIFT = 0x4000001200000000,
        OPCODE_RSHIFT = 0x4000001300000000,
        OPCODE_ALLOW_ALIASES = 0x4000001400000000,
        OPCODE_ALLOW_TOKENS = 0x4000001500000000,
        ////////kdiy/////////////
        OPCODE_ISOTYPE      = 0x4000009000000000,
        ////////kdiy/////////////
        OPCODE_ISCODE = 0x4000010000000000,
        OPCODE_ISSETCARD = 0x4000010100000000,
        OPCODE_ISTYPE = 0x4000010200000000,
        OPCODE_ISRACE = 0x4000010300000000,
        OPCODE_ISATTRIBUTE = 0x4000010400000000,
        OPCODE_GETCODE = 0x4000010500000000,
        OPCODE_GETSETCARD = 0x4000010600000000,
        OPCODE_GETTYPE = 0x4000010700000000,
        OPCODE_GETRACE = 0x4000010800000000,
        OPCODE_GETATTRIBUTE = 0x4000010900000000;
    }
}
