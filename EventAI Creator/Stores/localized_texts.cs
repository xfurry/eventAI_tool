using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventAI_Creator
{
    static class localized_texts
    {
        public static bool Add(uint id)
        {
            localized_text temp = new localized_text(id);
            if(!map.ContainsKey(id))
            { map.Add(id, temp); return true; } 
            else return false;
        }
        public static SortedList<uint, localized_text> map = new SortedList<uint,localized_text>();
        public static SortedList<uint, localized_text> OffList = new SortedList<uint, localized_text>();

        public static bool PrintLocalToFile(uint creature_id, string file)
        {
            SQLcreator.WriteLocalizedTextToFile(map[creature_id], file, false);
            return true;
        }
        public static bool PrintALLLocalsToFile(string file)
        {
            foreach (KeyValuePair<uint, localized_text> item in map)
            {
                SQLcreator.WriteLocalizedTextToFile(item.Value, file, true);
            }
            return true;
        }
    }

    class localized_text
    {
        public localized_text(uint idi)
        {
            id = idi;
        }
        public uint id;
        public bool changed = false;
        public bool overwritesofficial = false;
        public string locale_0 = "";
        public string locale_1 = "";
        public string locale_2 = "";
        public string locale_3 = ""; //German
        public string locale_4 = "";
        public string locale_5 = "";
        public string locale_6 = "";
        public string locale_7 = "";
        public string locale_8 = "";
        public string comment = "";
    }
}
