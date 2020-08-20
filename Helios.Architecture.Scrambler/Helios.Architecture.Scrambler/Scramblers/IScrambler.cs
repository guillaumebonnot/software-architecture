namespace Helios.Architecture.Scrambler.Scramblers
{
    public interface IScrambler
    {
        int Encode(int index);
        int Decode(int encoded);
    }
}