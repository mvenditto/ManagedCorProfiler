namespace CorProf.Bindings
{
    public partial struct IMAGE_COR_ILMETHOD_SECT_FAT
    {
        public uint _bitfield;

        [NativeTypeName("unsigned int : 8")]
        public uint Kind
        {
            get
            {
                return _bitfield & 0xFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~0xFFu) | (value & 0xFFu);
            }
        }

        [NativeTypeName("unsigned int : 24")]
        public uint DataSize
        {
            get
            {
                return (_bitfield >> 8) & 0xFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFFFFFu << 8)) | ((value & 0xFFFFFFu) << 8);
            }
        }
    }
}
