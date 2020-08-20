namespace Helios.Architecture.Scrambler.Scramblers
{
    class IndexScrambler : IScrambler
    {
        private readonly int salt;
        private readonly TauswortheScrambler scrambler = new TauswortheScrambler();

        public IndexScrambler(int salt)
        {
            this.salt = salt;
        }

        public int Encode(int index)
        {
            return scrambler.Encode(index ^ salt);
        }

        public int Decode(int encoded)
        {
            return scrambler.Decode(encoded) ^ salt;
        }
    }
}