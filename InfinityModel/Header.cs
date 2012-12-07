using System.Runtime.InteropServices;

namespace MvpVmSample.Core.InfinityModel
{
    [StructLayout(LayoutKind.Explicit, Size = 180, CharSet = CharSet.Ansi)]
    public struct Header
    {
        [FieldOffset(0), MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string Signature;

        [FieldOffset(0x0004), MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string Version;

        [FieldOffset(0x0008)]
        public uint GameTime;

        [FieldOffset(0x000c)]
        public ushort SelectedFormation;

        [FieldOffset(0x000e)]
        public ushort FormationButton1;

        [FieldOffset(0x0010)]
        public ushort FormationButton2;

        [FieldOffset(0x0012)]
        public ushort FormationButton3;

        [FieldOffset(0x0014)]
        public ushort FormationButton4;

        [FieldOffset(0x0016)]
        public ushort FormationButton5;

        [FieldOffset(0x0018)]
        public uint PartyGold;

        [FieldOffset(0x001c)]
        public ushort NpcStructCountForPartyEx;

        [FieldOffset(0x001e)]
        public ushort WeatherBitfield;

        [FieldOffset(0x0020)]
        public uint NpcStructOffsetForParty;

        [FieldOffset(0x0024)]
        public uint NpcStructCountForPartyInc;

        [FieldOffset(0x0028)]
        public uint Unknown1;

        [FieldOffset(0x002c)]
        public uint Unknown2;

        [FieldOffset(0x0030)]
        public uint NpcStructOffsetForNonParty;

        [FieldOffset(0x0034)]
        public uint NpcStructCountForNonParty;

        [FieldOffset(0x0038)]
        public uint GlobalNamespaceVarOffset;

        [FieldOffset(0x003c)]
        public uint GlobalNamespaceVarCount;

        [FieldOffset(0x0040), MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string MainArea;

        [FieldOffset(0x0048)]
        public uint FamilarExtraOffset;

        [FieldOffset(0x004c)]
        public uint JournalEntriesCount;

        [FieldOffset(0x0050)]
        public uint JournalEntriesOffset;

        [FieldOffset(0x0054)]
        public uint PartyReputation;

        [FieldOffset(0x0058), MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string CurrentArea;

        [FieldOffset(0x0060)]
        public uint GuiFlags;

        [FieldOffset(0x0064)]
        public uint LoadingProgress;

        [FieldOffset(0x0068)]
        public uint FamilarInfoOffset;

        [FieldOffset(0x006c)]
        public uint StoredLocOffset;

        [FieldOffset(0x0070)]
        public uint StoredLocCount;

        [FieldOffset(0x0074)]
        public uint GameTimeSec;

        [FieldOffset(0x0078)]
        public uint PocketPlaneOffset;

        [FieldOffset(0x007c)]
        public uint PocketPlaneCount;

        // [FieldOffset(0x0080), MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(MyMarshal))]
        [FieldOffset(0x0080), MarshalAs(UnmanagedType.ByValArray, SizeConst = 52)]
        public byte[] Unknown3;
    }
}
