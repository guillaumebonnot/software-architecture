namespace Helios.Architecture.Scrambler.Scramblers
{
    class TauswortheScrambler : IScrambler
    {
        public int Encode(int seed)
        {
            seed ^= seed >> 13;
            seed ^= seed << 18;
            seed &= 0x7FFFFFFF;
            return seed;
        }

        public int Decode(int seed)
        {
            seed ^= seed << 18;
            seed &= 0x7FFFFFFF;
            seed ^= seed >> 13;
            seed ^= seed >> 26;
            return seed;
        }
    }
}