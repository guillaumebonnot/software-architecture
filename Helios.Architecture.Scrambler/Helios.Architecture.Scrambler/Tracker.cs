using System.Collections.Generic;

namespace Helios.Architecture.Scrambler
{
    // this class is tracking where the value for this bit comes from
    public class Tracker
    {
        private readonly int[] values;
        public IEnumerable<int> GetValues() => values;
        
        public Tracker(int[] values) => this.values = values;
        public Tracker(int index) => values = new[] {index};
        
        public static Tracker XOR(Tracker a, Tracker b)
        {
            var list = new List<int>(a.values);

            foreach (var value in b.values)
            {
                if (value == 0) continue;

                // xor is cancelling itself
                if (!list.Remove(value))
                {
                    list.Add(value);
                }
            }

            list.Sort();
            return new Tracker(list.ToArray());
        }
    }
}