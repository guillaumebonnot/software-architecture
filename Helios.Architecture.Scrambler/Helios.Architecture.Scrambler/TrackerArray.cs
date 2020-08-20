using System.Collections.Generic;

namespace Helios.Architecture.Scrambler
{
    // this class is tracking each bit of a 32 bit integer
    public class TrackerArray
    {
        private readonly Tracker[] array = new Tracker[32];
        public IEnumerable<Tracker> GetValues() => array;

        public static TrackerArray New()
        {
            var array = new TrackerArray();
            for (int i = 0; i < 32; i++)
            {
                array.array[i] = new Tracker(i);
            }
            return array;
        }
        
        public static TrackerArray Zero()
        {
            var array = new TrackerArray();
            for (int i = 0; i < 32; i++)
            {
                array.array[i] = new Tracker(0);
            }
            return array;
        }

        public static TrackerArray XOR(TrackerArray a, TrackerArray b)
        {
            var array = new TrackerArray();
            for (int i = 0; i < 32; i++)
            {
                array.array[i] = Tracker.XOR(a.array[i], b.array[i]);
            }
            return array;
        }

        public TrackerArray ShiftLeft(int shift)
        {
            var array = Zero();
            for (int i = 1 + shift; i < 32; i++)
            {
                array.array[i - shift] = this.array[i];
            }
            return array;
        }

        public TrackerArray ShiftRight(int shift)
        {
            var array = Zero();
            for (int i = 1 + shift; i < 32; i++)
            {
                array.array[i] = this.array[i-shift];
            }
            return array;
        }
    }
}