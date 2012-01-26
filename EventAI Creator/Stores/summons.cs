using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventAI_Creator
{
    static class summons
    {
        public static bool Add(uint id)
        {
            summon temp = new summon(id);
            if (!map.ContainsKey(id))
            { map.Add(id, temp); return true; }
            else return false;
        }
        public static SortedList<uint,summon> map = new SortedList<uint,summon>();
        public static SortedList<uint, summon> OffList = new SortedList<uint, summon>();

        public static bool PrintSummonToFile(uint creature_id, string file)
        {
            SQLcreator.WriteSummonToFile(map[creature_id], file, false);
            return true;
        }
        public static bool PrintALLSummonsToFile(string file)
        {
            foreach (KeyValuePair<uint, summon> item in map)
            {
                SQLcreator.WriteSummonToFile(item.Value, file, true);
            }
            return true;
        }
    }

    class summon
    {
        public summon(uint idi)
        {
            id = idi;
        }
        public uint id;
        public bool changed = false;
        public bool overwritesofficial = false;
        public float position_x = 0;
        public float position_y = 0;
        public float position_z = 0;
        public float orientation = 0;
        public int spawntimesecs = 0;
        public string comment = "";
    }
}
