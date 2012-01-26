using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MySql.Data;

using System.Net;
using System.Net.Sockets;
using System.Globalization;
using Tamir.SharpSsh.jsch;
using Tamir.SharpSsh.jsch.jce;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace EventAI_Creator
{
    class Datastores
    {
        public static bool dbused = false;


        public static void ReloadDB()
        {
            MySqlDataReader reader = null;

            try
            {
                string sQuery = "SELECT information_schema.TABLES.table_name FROM information_schema.TABLES " +
                "where information_schema.TABLES.table_name IN ('creature_ai_scripts','creature_ai_summons','creature_ai_texts') and information_schema.TABLES.Table_schema='" + Properties.Settings.Default.DBMANGOS + "'";
                MySqlCommand comm = new MySqlCommand(sQuery, SQLConnection.conn);
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Your database doesn't contain the eventAI tables. The application won't use the database anymore");
                        dbused = false;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            reader.Close();

            if (Datastores.dbused)
            {
                MySqlCommand c = new MySqlCommand("SELECT * FROM creature_ai_scripts", SQLConnection.conn);
                reader = c.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        if (creatures.npcList.ContainsKey(reader.GetUInt32("creature_id")))
                        {
                        }
                        else
                        {
                            creature temp = new creature(reader.GetUInt32("creature_id"));
                            creatures.npcList.Add(reader.GetUInt32("creature_id"), temp);
                        }
                        Event_dataset item = new Event_dataset();

                        item.event_type = reader.GetInt32("event_type");
                        item.event_inverse_phase_mask = reader.GetUInt32("event_inverse_phase_mask");
                        item.event_chance = reader.GetInt32("event_chance");
                        item.event_flags = reader.GetInt32("event_flags");
                        item.event_param1 = reader.GetInt32("event_param1");
                        item.event_param2 = reader.GetInt32("event_param2");
                        item.event_param3 = reader.GetInt32("event_param3");
                        item.event_param4 = reader.GetInt32("event_param4");
                        item.action1_type = reader.GetInt32("action1_type");
                        item.action1_param1 = reader.GetInt32("action1_param1");
                        item.action1_param2 = reader.GetInt32("action1_param2");
                        item.action1_param3 = reader.GetInt32("action1_param3");
                        item.action2_type = reader.GetInt32("action2_type");
                        item.action2_param1 = reader.GetInt32("action2_param1");
                        item.action2_param2 = reader.GetInt32("action2_param2");
                        item.action2_param3 = reader.GetInt32("action2_param3");
                        item.action3_type = reader.GetInt32("action3_type");
                        item.action3_param1 = reader.GetInt32("action3_param1");
                        item.action3_param2 = reader.GetInt32("action3_param2");
                        item.action3_param3 = reader.GetInt32("action3_param3");
                        item.comment = reader.GetString("comment");
                        creatures.npcList[reader.GetUInt32("creature_id")].line.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                reader.Close();
                //c.CommandText = "SELECT * FROM `eventai_scripts_official`";
                //reader = c.ExecuteReader();

                //try
                //{
                //    while (reader.Read())
                //    {
                //        if (creatures.OffNpcList.ContainsKey(reader.GetUInt32("creature_id")))
                //        {
                //        }
                //        else
                //        {
                //            creature temp = new creature(reader.GetUInt32("creature_id"));
                //            creatures.OffNpcList.Add(reader.GetUInt32("creature_id"), temp);
                //        }
                //        Event_dataset item = new Event_dataset();

                //        item.event_type = reader.GetInt32("event_type");
                //        item.event_inverse_phase_mask = reader.GetUInt32("event_inverse_phase_mask");
                //        item.event_chance = reader.GetInt32("event_chance");
                //        item.event_flags = reader.GetInt32("event_flags");
                //        item.event_param1 = reader.GetInt32("event_param1");
                //        item.event_param2 = reader.GetInt32("event_param2");
                //        item.event_param3 = reader.GetInt32("event_param3");
                //        item.event_param4 = reader.GetInt32("event_param4");
                //        item.action1_type = reader.GetInt32("action1_type");
                //        item.action1_param1 = reader.GetInt32("action1_param1");
                //        item.action1_param2 = reader.GetInt32("action1_param2");
                //        item.action1_param3 = reader.GetInt32("action1_param3");
                //        item.action2_type = reader.GetInt32("action2_type");
                //        item.action2_param1 = reader.GetInt32("action2_param1");
                //        item.action2_param2 = reader.GetInt32("action2_param2");
                //        item.action2_param3 = reader.GetInt32("action2_param3");
                //        item.action3_type = reader.GetInt32("action3_type");
                //        item.action3_param1 = reader.GetInt32("action3_param1");
                //        item.action3_param2 = reader.GetInt32("action3_param2");
                //        item.action3_param3 = reader.GetInt32("action3_param3");
                //        item.comment = reader.GetString("comment");
                //        creatures.OffNpcList[reader.GetUInt32("creature_id")].line.Add(item);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}

                c.CommandText = "SELECT * FROM creature_ai_summons";
                reader.Close();
                reader = c.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        summon item = new summon(reader.GetUInt32("id"));
                        item.comment = reader.GetString("comment");
                        item.orientation = reader.GetFloat("orientation");
                        item.position_x = reader.GetFloat("position_x");
                        item.position_y = reader.GetFloat("position_y");
                        item.position_z = reader.GetFloat("position_z");
                        item.spawntimesecs = reader.GetInt32("spawntimesecs");
                        summons.map.Add(reader.GetUInt32("id"), item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //c.CommandText = "SELECT * FROM `eventai_summons_official`";
                //reader.Close();
                //reader = c.ExecuteReader();

                //try
                //{
                //    while (reader.Read())
                //    {
                //        summon item = new summon(reader.GetUInt32("id"));
                //        item.comment = reader.GetString("comment");
                //        item.orientation = reader.GetFloat("orientation");
                //        item.position_x = reader.GetFloat("position_x");
                //        item.position_y = reader.GetFloat("position_y");
                //        item.position_z = reader.GetFloat("position_z");
                //        item.spawntimesecs = reader.GetInt32("spawntimesecs");
                //        summons.OffList.Add(reader.GetUInt32("id"), item);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}

                //c.CommandText = "SELECT * FROM `eventai_texts_custom`";
                //reader.Close();

                //reader = c.ExecuteReader();

                //try
                //{
                //    while (reader.Read())
                //    {
                //        localized_text item = new localized_text(reader.GetUInt32("id"));
                //        item.comment = reader.GetString("comment");
                //        item.locale_0 = reader.GetString("text");
                //        localized_texts.map.Add(reader.GetUInt32("id"), item);
                //    }

                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}

                c.CommandText = "SELECT * FROM creature_ai_texts";
                reader.Close();

                reader = c.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        localized_text item = new localized_text(reader.GetUInt32("entry"));
                        item.locale_1 = reader.GetString("content_loc1");
                        item.locale_2 = reader.GetString("content_loc2");
                        item.locale_3 = reader.GetString("content_loc3");
                        item.locale_4 = reader.GetString("content_loc4");
                        item.locale_5 = reader.GetString("content_loc5");
                        item.locale_6 = reader.GetString("content_loc6");
                        item.locale_7 = reader.GetString("content_loc7");
                        item.locale_8 = reader.GetString("content_loc8");
                        if (!localized_texts.map.ContainsKey(reader.GetUInt32("entry")))
                            localized_texts.map.Add(reader.GetUInt32("entry"), item);
                        else
                        {
                            localized_texts.map[reader.GetUInt32("entry")].locale_1 = item.locale_1;
                            localized_texts.map[reader.GetUInt32("entry")].locale_2 = item.locale_2;
                            localized_texts.map[reader.GetUInt32("entry")].locale_3 = item.locale_3;
                            localized_texts.map[reader.GetUInt32("entry")].locale_4 = item.locale_4;
                            localized_texts.map[reader.GetUInt32("entry")].locale_5 = item.locale_5;
                            localized_texts.map[reader.GetUInt32("entry")].locale_6 = item.locale_6;
                            localized_texts.map[reader.GetUInt32("entry")].locale_7 = item.locale_7;
                            localized_texts.map[reader.GetUInt32("entry")].locale_8 = item.locale_8;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                reader.Close();
                //c.CommandText = "SELECT * FROM `eventai_texts_official`";

                //reader = c.ExecuteReader();

                //try
                //{
                //    while (reader.Read())
                //    {
                //        localized_text item = new localized_text(reader.GetUInt32("id"));
                //        item.comment = reader.GetString("comment");
                //        item.locale_0 = reader.GetString("text");
                //        localized_texts.OffList.Add(reader.GetUInt32("id"), item);
                //    }

                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
                //reader.Close();

                //c.CommandText = "SELECT * FROM `eventai_localized_texts_official`";

                //reader = c.ExecuteReader();

                //try
                //{
                //    while (reader.Read())
                //    {
                //        localized_text item = new localized_text(reader.GetUInt32("id"));
                //        item.locale_1 = reader.GetString("locale_1");
                //        item.locale_2 = reader.GetString("locale_2");
                //        item.locale_3 = reader.GetString("locale_3");
                //        item.locale_4 = reader.GetString("locale_4");
                //        item.locale_5 = reader.GetString("locale_5");
                //        item.locale_6 = reader.GetString("locale_6");
                //        item.locale_7 = reader.GetString("locale_7");
                //        item.locale_8 = reader.GetString("locale_8");
                //        if (!localized_texts.OffList.ContainsKey(reader.GetUInt32("id")))
                //            localized_texts.OffList.Add(reader.GetUInt32("id"), item);
                //        else
                //        {
                //            localized_texts.OffList[reader.GetUInt32("id")].locale_1 = item.locale_1;
                //            localized_texts.OffList[reader.GetUInt32("id")].locale_2 = item.locale_2;
                //            localized_texts.OffList[reader.GetUInt32("id")].locale_3 = item.locale_3;
                //            localized_texts.OffList[reader.GetUInt32("id")].locale_4 = item.locale_4;
                //            localized_texts.OffList[reader.GetUInt32("id")].locale_5 = item.locale_5;
                //            localized_texts.OffList[reader.GetUInt32("id")].locale_6 = item.locale_6;
                //            localized_texts.OffList[reader.GetUInt32("id")].locale_7 = item.locale_7;
                //            localized_texts.OffList[reader.GetUInt32("id")].locale_8 = item.locale_8;
                //        }
                //    }

                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
                //reader.Close();

                SQLConnection.conn.ChangeDatabase(SQLConnection.dbworld);
                c.CommandText = "SELECT entry FROM `creature_template` WHERE AIName = 'EventAI';";
                reader = c.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        if (creatures.npcList.ContainsKey(reader.GetUInt32("entry")))
                        {
                            creatures.npcList[reader.GetUInt32("entry")].activectemplate = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                reader.Close();

                c.CommandText = "SELECT entry FROM creature_template;";
                reader = c.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        creatures.npcsAvailable.Add(reader.GetUInt32("entry"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                reader.Close();

                //string delete = "";
                //SQLConnection.conn.ChangeDatabase(SQLConnection.dbsd2);

                //c.CommandText = "SELECT * FROM info_summons;";
                //reader = c.ExecuteReader();

                //try
                //{
                //    while (reader.Read())
                //    {
                //        if (summons.map.ContainsKey(reader.GetUInt32("entry")))
                //            summons.map[reader.GetUInt32("entry")].overwritesofficial = true;
                //        else
                //        {
                //            delete = delete + Convert.ToUInt32(reader.GetUInt32("entry"));
                //        }
                //    }
                //    reader.Close();
                //    if (delete.Length != 0)
                //    {
                //        SQLConnection.DoNONREADSD2Query("DELETE FROM info_locals WHERE entry IN(" + delete + ");", false);
                //        delete = "";
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}

                //c.CommandText = "SELECT * FROM info_scripts;";
                //reader = c.ExecuteReader();

                //try
                //{
                //    while (reader.Read())
                //    {
                //        if (creatures.npcList.ContainsKey(reader.GetUInt32("entry")))
                //            creatures.npcList[reader.GetUInt32("entry")].overwritesofficial = true;
                //        else
                //        {
                //            delete = delete + Convert.ToUInt32(reader.GetUInt32("entry"));
                //        }
                //    }
                //    reader.Close();
                //    if (delete.Length != 0)
                //    {
                //        SQLConnection.DoNONREADSD2Query("DELETE FROM info_scripts WHERE entry IN(" + delete + ");", false);
                //        delete = "";
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}

                //c.CommandText = "SELECT * FROM info_locals;";
                //reader = c.ExecuteReader();

                //try
                //{
                //    while (reader.Read())
                //    {
                //        if (localized_texts.map.ContainsKey(reader.GetUInt32("entry")))
                //        localized_texts.map[reader.GetUInt32("entry")].overwritesofficial = true;
                //        else
                //        {
                //            delete = delete + Convert.ToUInt32(reader.GetUInt32("entry"));
                //        }
                //    }
                //    reader.Close();
                //    if (delete.Length != 0)
                //    {
                //        SQLConnection.DoNONREADSD2Query("DELETE FROM info_locals WHERE entry IN(" + delete + ");", false);
                //        delete = "";
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
        }
    }
    static class SQLcreator
    {
        public static bool WriteCreatureToFile(creature npc, string file, bool reihe)
        {
            if (npc == null || npc.line.Count == 0)
                return false;

            StreamWriter sqlpatchfile = new StreamWriter(file, reihe);
            sqlpatchfile.WriteLine("## " + npc.creature_name);
            sqlpatchfile.WriteLine(SQLcreator.CreateDeleteQuery(npc, ""));
            sqlpatchfile.WriteLine(SQLcreator.CreateCreateQuery(npc, ""));
            sqlpatchfile.Close();
            return true;
        }
        public static bool WriteSummonToFile(summon npc, string file, bool reihe)
        {
            if (npc == null)
                return false;

            StreamWriter sqlpatchfile = new StreamWriter(file, reihe);
            sqlpatchfile.WriteLine("## " + npc.comment + npc.id);
            sqlpatchfile.WriteLine(SQLcreator.CreateDeleteQuery(npc, ""));
            sqlpatchfile.WriteLine(SQLcreator.CreateCreateQuery(npc, ""));
            sqlpatchfile.Close();
            return true;
        }
        public static bool WriteLocalizedTextToFile(localized_text npc, string file, bool reihe)
        {
            if (npc == null)
                return false;

            StreamWriter sqlpatchfile = new StreamWriter(file, reihe);
            sqlpatchfile.WriteLine("## " + npc.comment + npc.id);
            sqlpatchfile.WriteLine(SQLcreator.CreateDeleteQuery(npc, ""));
            sqlpatchfile.WriteLine(SQLcreator.CreateCreateQuery(npc, ""));
            sqlpatchfile.Close();
            return true;
        }

        public static string CreateDeleteQuery(object item,string tableparam)
        {
            string table = "eventai_summons_custom";
            string argument = "id < 0";
            string customquery = "";
            string table2 = "";

            if(item is creature)
            {
                creature copy = item as creature;
                table = "`eventai_scripts_custom`";
                argument = "creature_id IN ("+copy.creature_id+")";
            }
            if (item is List<creature>)
            {
                List<creature> copy = item as List<creature>;
                table = "`eventai_scripts_custom`";
                argument = "creature_id IN (";
                foreach (creature itemf in copy)
                {
                    argument = argument + itemf.creature_id+",";
                }
                argument.Remove(argument.Length);
                argument = argument+")";
            }
            if (item is creatures)
            {
                SortedList<uint,creature> copy = creatures.npcList;
                table = "`eventai_scripts_custom`";
                argument = "creature_id IN(";
                foreach(KeyValuePair<uint,creature> itemf in copy)
                {
                    argument = argument + itemf.Key + ",";
                }
                argument.Remove(argument.Length);
                argument = argument + ")";
            }

            if (item is summon)
            {
                summon copy = item as summon;
                table = "`eventai_summons_custom`";
                argument = "id IN ("+ copy.id+")";
            }
            if (item is List<summon>)
            {
                List<summon> copy = item as List<summon>;
                table = "`eventai_summons_custom`";
                argument = "id IN(";
                foreach (summon itemf in copy)
                {
                    argument = argument + itemf.id + ",";
                }
                argument.Remove(argument.Length);
                argument = argument+")";
            }
            if (item is summons)
            {
                SortedList<uint, summon> copy = summons.map;
                table = "`eventai_summons_custom`";
                argument = "id IN (";
                foreach (KeyValuePair<uint, summon> itemf in copy)
                {
                    argument = argument + itemf.Key + ",";
                }
                argument.Remove(argument.Length);
                argument = argument + ")";
            }

            if (item is localized_text)
            {
                localized_text copy = item as localized_text;
                table = "`eventai_localized_texts_custom`";
                table2 = "`eventai_texts_custom`";
                if (tableparam == "eventai_localized_texts")
                {
                    table = tableparam;
                    table2 = "eventai_texts";
                }
                customquery = "DELETE FROM " + table + " WHERE id = " + copy.id + ";DELETE FROM " + table2 + " WHERE id = " + copy.id + ";";

            }
            if (item is List<localized_text>)
            {
                List<localized_text> copy = item as List<localized_text>;
                table = "`eventai_localized_texts_custom`";
                argument = "id IN(";
                foreach (localized_text itemf in copy)
                {
                    argument = argument + itemf.id + ",";
                }
                argument.Remove(argument.Length);
                argument = argument + ")";
                MessageBox.Show("LOL, this should never happen, REPORT!");
            }
            if (item is localized_texts)
            {
                SortedList<uint, localized_text> copy = localized_texts.map;
                table = "`eventai_localized_texts_custom`";
                table2 = "`eventai_texts_custom`";
                if (tableparam == "eventai_localized_texts")
                {
                    table = tableparam;
                    table2 = "eventai_texts";
                }
                foreach (KeyValuePair<uint, localized_text> itemf in copy)
                {
                    customquery = customquery + "DELETE FROM " + table + " WHERE id = " + itemf.Key + ";DELETE FROM " + table2 + "WHERE id = " + itemf.Key + ";";
                }
            }

            if (tableparam.Length != 0)
            {
                table = tableparam;
            }
            string result = "";
            if (customquery.Length != 0)
            {
                result = customquery;
            }
            else result = "DELETE FROM " + table + " WHERE " + argument + ";";
            return result;
        }

        public static string CreateCreatureTemplateQuery(object item,bool remove)
        {
            string arguments = "";

            if (item is creature)
            {
                creature copy = item as creature;
                arguments = copy.creature_id.ToString();
            }
            if (item is List<creature>)
            {
                List<creature> copy = item as List<creature>;
                bool first = true;

                foreach (creature itemf in copy)
                {
                    if (first)
                    { first = false; arguments = itemf.creature_id.ToString(); }
                    else arguments = arguments + "," + itemf.creature_id;
                }
            }
            if (item is creatures)
            {
                SortedList<uint, creature> copy = creatures.npcList;
                bool first = true;

                foreach (KeyValuePair<uint, creature> itemf in copy)
                {
                    if (first)
                    { first = false; arguments = itemf.Key.ToString(); }
                    else arguments = arguments + "," + itemf.Key;
                }
            }
            if (item is uint)
                arguments = item.ToString();
            string scriptname;
            if (remove)
                scriptname = "''";
            else scriptname = "'mob_eventai'";
            string result = "UPDATE creature_template SET scriptname = "+scriptname+" WHERE entry IN("+arguments+");";

            return result;
        }

        public static string CreateCreateQuery(object item,string tableparam)
        {
            string table = "";
            string lines = "";
            string customquery = "";
            string table2 = "";

            if(item is localized_text)
            {
                table = "`eventai_localized_texts_custom`";
                table2 = "`eventai_texts_custom`";
                if (tableparam == "eventai_localized_texts")
                {
                    table = tableparam;
                    table2 = "eventai_texts";
                }
                localized_text copy = item as localized_text;
                customquery = "INSERT INTO " + table2 + " VALUES(" + copy.id + ",'" + MySqlHelper.EscapeString(copy.locale_0) + "','" + MySqlHelper.EscapeString(copy.comment) + "');";
                customquery = customquery + "INSERT INTO " + table + " VALUES('" + copy.id + "','" + MySqlHelper.EscapeString(copy.locale_1) + "','" + MySqlHelper.EscapeString(copy.locale_2) + "','" + MySqlHelper.EscapeString(copy.locale_3) + "','" + MySqlHelper.EscapeString(copy.locale_4) + "','" + MySqlHelper.EscapeString(copy.locale_5) + "','" + MySqlHelper.EscapeString(copy.locale_6) + "','" + MySqlHelper.EscapeString(copy.locale_7) + "','" + MySqlHelper.EscapeString(copy.locale_8) + "','" + MySqlHelper.EscapeString(copy.comment) + "');";
             }
            if (item is List<localized_text>)
            {
                table = "`eventai_localized_texts_custom`";
                List<localized_text> copy = item as List<localized_text>;
                foreach (localized_text itemf in copy)
                {
                    lines = lines+"('" + itemf.id + "','" + MySqlHelper.EscapeString(itemf.locale_0) + "','" + MySqlHelper.EscapeString(itemf.locale_1) + "','" + MySqlHelper.EscapeString(itemf.locale_2) + "','" + MySqlHelper.EscapeString(itemf.locale_3) + "','" + MySqlHelper.EscapeString(itemf.locale_4) + "','" + MySqlHelper.EscapeString(itemf.locale_5) + "','" + MySqlHelper.EscapeString(itemf.locale_6) + "','" + MySqlHelper.EscapeString(itemf.locale_7) + "','" + MySqlHelper.EscapeString(itemf.locale_8) + "','" + MySqlHelper.EscapeString(itemf.comment) + "'),";
                }
                lines.Remove(lines.Length);
                lines = lines + ";";
                MessageBox.Show("WOOOOOOOOOOOOT,THIS should NEVER HAPPEN!!!!");
            }
            if (item is localized_texts)
            {
                table = "`eventai_localized_texts_custom`";
                table2 = "`eventai_texts_custom`";
                if (tableparam == "eventai_localized_texts")
                {
                    table = tableparam;
                    table2 = "eventai_texts";
                }
                SortedList<uint, localized_text> copy = localized_texts.map;
                foreach (KeyValuePair<uint, localized_text> itemf in copy)
                {
                    customquery = customquery + "INSERT INTO "+table2+" VALUES("+localized_texts.map[itemf.Key].id+",'"+ MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_0) + "','"+MySqlHelper.EscapeString(localized_texts.map[itemf.Key].comment)+"');";
                    customquery = customquery + "INSERT INTO "+table+" VALUES('" + localized_texts.map[itemf.Key].id + "','" + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_1) + "','" + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_2) + "','" + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_3) + "','" + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_4) + "','" + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_5) + "','" + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_6) + "','" + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_7) + "','" + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_8) + "','" + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].comment) + "');";
                }
            }

            if (item is summon)
            {
                table = "`eventai_summons_custom`";
                summon copy = item as summon;
                lines = "('" + copy.id + "','" + copy.position_x.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + copy.position_y.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + copy.position_z.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + copy.orientation.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + copy.spawntimesecs + "','" + MySqlHelper.EscapeString(copy.comment) + "');";
            }
            if (item is List<summon>)
            {
                table = "`eventai_summons_custom`";
                List<summon> copy = item as List<summon>;
                foreach (summon itemf in copy)
                {
                    lines = "('" + itemf.id + "','" + itemf.position_x.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + itemf.position_y.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + itemf.position_z.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + itemf.orientation.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + itemf.spawntimesecs + "','" + MySqlHelper.EscapeString(itemf.comment) + "'),";
                }
                lines.Remove(lines.Length);
                lines = lines + ";";
            }
            if (item is summons)
            {
                table = "`eventai_summons_custom`";
                SortedList<uint, summon> copy = summons.map;
                foreach (KeyValuePair<uint, summon> itemf in copy)
                {
                    lines = "('" + summons.map[itemf.Key].id + "','" + summons.map[itemf.Key].position_x.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + summons.map[itemf.Key].position_y.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + summons.map[itemf.Key].position_z.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + summons.map[itemf.Key].orientation.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + summons.map[itemf.Key].spawntimesecs + "','" + MySqlHelper.EscapeString(summons.map[itemf.Key].comment) + "'),";
                }
                lines.Remove(lines.Length);
                lines = lines + ";";
            }

            if (item is creature)
            {
                table = "`eventai_scripts_custom`";
                creature copy = item as creature;

                for (int i = 0; i < copy.line.Count; i++)
                {
                    lines = lines + "('" + copy.creature_id + i.ToString("00") + "','" +
                    copy.creature_id + "','" +
                    copy.line[i].event_type + "','" +
                    copy.line[i].event_inverse_phase_mask + "','" +
                    copy.line[i].event_chance + "','" +
                    copy.line[i].event_flags + "','" +
                    copy.line[i].event_param1 + "','" +
                    copy.line[i].event_param2 + "','" +
                    copy.line[i].event_param3 + "','" +
                    copy.line[i].event_param4 + "','" +
                    copy.line[i].action1_type + "','" +
                    copy.line[i].action1_param1 + "','" +
                    copy.line[i].action1_param2 + "','" +
                    copy.line[i].action1_param3 + "','" +
                    copy.line[i].action2_type + "','" +
                    copy.line[i].action2_param1 + "','" +
                    copy.line[i].action2_param2 + "','" +
                    copy.line[i].action2_param3 + "','" +
                    copy.line[i].action3_type + "','" +
                    copy.line[i].action3_param1 + "','" +
                    copy.line[i].action3_param2 + "','" +
                    copy.line[i].action3_param3 + "','" +
                    MySqlHelper.EscapeString(copy.line[i].comment) + "')";
                    if (i + 1 < copy.line.Count)
                        lines =lines+",";
                    else lines =lines+";";
                }
            }
            if (item is List<creature>)
            {
                table = "`eventai_scripts_custom`";
                List<creature> copy = item as List<creature>;

                foreach (creature itemf in copy)
                {
                    for (int i = 0; i < itemf.line.Count; i++)
                    {
                        lines = lines + "('" + itemf.creature_id + i.ToString("00") + "','" +
                        itemf.creature_id + "','" +
                        itemf.line[i].event_type + "','" +
                        itemf.line[i].event_inverse_phase_mask + "','" +
                        itemf.line[i].event_chance + "','" +
                        itemf.line[i].event_flags + "','" +
                        itemf.line[i].event_param1 + "','" +
                        itemf.line[i].event_param2 + "','" +
                        itemf.line[i].event_param3 + "','" +
                        itemf.line[i].event_param4 + "','" +
                        itemf.line[i].action1_type + "','" +
                        itemf.line[i].action1_param1 + "','" +
                        itemf.line[i].action1_param2 + "','" +
                        itemf.line[i].action1_param3 + "','" +
                        itemf.line[i].action2_type + "','" +
                        itemf.line[i].action2_param1 + "','" +
                        itemf.line[i].action2_param2 + "','" +
                        itemf.line[i].action2_param3 + "','" +
                        itemf.line[i].action3_type + "','" +
                        itemf.line[i].action3_param1 + "','" +
                        itemf.line[i].action3_param2 + "','" +
                        itemf.line[i].action3_param3 + "','" +
                        MySqlHelper.EscapeString(itemf.line[i].comment) + "'),";
                    }
                }
                lines.Remove(lines.Length);
                lines = lines + ";";
            }
            if (item is creatures)
            {
                table = "`eventai_scripts_custom`";
                SortedList<uint,creature> copy = creatures.npcList;

                foreach(KeyValuePair<uint,creature> itemf in copy)
                {
                    for (int i = 0; i < creatures.npcList[itemf.Key].line.Count; i++)
                    {
                        lines = lines + "('" + creatures.npcList[itemf.Key].creature_id + i.ToString("00") + "','" +
                        creatures.npcList[itemf.Key].creature_id + "','" +
                        creatures.npcList[itemf.Key].line[i].event_type + "','" +
                        creatures.npcList[itemf.Key].line[i].event_inverse_phase_mask + "','" +
                        creatures.npcList[itemf.Key].line[i].event_chance + "','" +
                        creatures.npcList[itemf.Key].line[i].event_flags + "','" +
                        creatures.npcList[itemf.Key].line[i].event_param1 + "','" +
                        creatures.npcList[itemf.Key].line[i].event_param2 + "','" +
                        creatures.npcList[itemf.Key].line[i].event_param3 + "','" +
                        creatures.npcList[itemf.Key].line[i].event_param4 + "','" +
                        creatures.npcList[itemf.Key].line[i].action1_type + "','" +
                        creatures.npcList[itemf.Key].line[i].action1_param1 + "','" +
                        creatures.npcList[itemf.Key].line[i].action1_param2 + "','" +
                        creatures.npcList[itemf.Key].line[i].action1_param3 + "','" +
                        creatures.npcList[itemf.Key].line[i].action2_type + "','" +
                        creatures.npcList[itemf.Key].line[i].action2_param1 + "','" +
                        creatures.npcList[itemf.Key].line[i].action2_param2 + "','" +
                        creatures.npcList[itemf.Key].line[i].action2_param3 + "','" +
                        creatures.npcList[itemf.Key].line[i].action3_type + "','" +
                        creatures.npcList[itemf.Key].line[i].action3_param1 + "','" +
                        creatures.npcList[itemf.Key].line[i].action3_param2 + "','" +
                        creatures.npcList[itemf.Key].line[i].action3_param3 + "','" +
                        MySqlHelper.EscapeString(creatures.npcList[itemf.Key].line[i].comment) + "'),";
                    }
                }
                lines.Remove(lines.Length);
                lines = lines + ";";
            }
            string result="";
            if (tableparam.Length != 0)
                table = tableparam;
            
                if (customquery.Length != 0)
                {
                    result = customquery;
                }
                else if (lines.Length != 0) result = "INSERT INTO " + table + " VALUES " + lines;
            return result;
        }
    }

    static class SQLConnection
    {
        public static bool Connect(string tdbhost,string tdbuser,string tdbpass, /*string tdbsd2,*/string tdbworld)
        {
            try
            {
                dbhost = tdbhost;
                dbuser = tdbuser;
                dbpass = tdbpass;
                //dbsd2 = tdbsd2;
                dbworld = tdbworld;
                string connStr = String.Format("server={0};user id={1};password={2}; database={3}; pooling=false", dbhost, dbuser, dbpass, tdbworld);

                conn = new MySqlConnection(connStr);
                conn.Open();
                conn.ChangeDatabase(tdbworld);
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }
        public static void DisConnect()
        {
            if(!(conn == null))
            conn.Close();
        }

        public static void DoNONREADSD2Query(string query,bool showsucces)
        {
            if(!Datastores.dbused)
                return;
            SQLConnection.conn.ChangeDatabase(SQLConnection.dbsd2);
            MySqlCommand c = new MySqlCommand(query, SQLConnection.conn);
            try
            {
                c.ExecuteNonQuery();
                if (showsucces)
                    MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string dbhost;
        public static string dbuser;
        public static string dbpass;
        public static string dbworld;
        public static string dbsd2;
        public static Exception error;
        public static MySqlConnection conn;
    }

    static class SSHConnection
    {
        public static bool Connect(string thost,string tuser,string tpass,string tport)
        {
            try
            {
                JSch jsch = new JSch();
                host = thost;
                user = tuser;
                pass = tpass;
                sshPort = Convert.ToInt32(tport);

                session = jsch.getSession(user, host, sshPort);
                session.setHost(host);
                session.setPassword(pass);
                UserInfo ui = new MyUserInfo();
                session.setUserInfo(ui);
                session.connect();
                session.setPortForwardingL(lPort, "127.0.0.1", rPort);
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }
        public static void DisConnect()
        {
            if(!(session == null))
            session.disconnect();
        }

        public static string host;
        public static string user;
        public static string pass;
        public static int sshPort;
        public static int rPort = 3306;
        public static int lPort = 3306;
        public static Exception error;

        public static Session session;
    }

    static class SQLCommonExecutes
    {
        public static bool setScriptnameInCreature_template(uint id,bool setnow)
        {
            string query = SQLcreator.CreateCreatureTemplateQuery(id, setnow);
            MySqlCommand c = new MySqlCommand(query,SQLConnection.conn);

            try
            {
                SQLConnection.conn.ChangeDatabase(SQLConnection.dbworld);
                c.ExecuteNonQuery();
                SQLConnection.conn.ChangeDatabase(SQLConnection.dbsd2);
                return true;
            }
            catch(Exception ex)
            {
                SQLConnection.conn.ChangeDatabase(SQLConnection.dbsd2);
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        public static bool CompileQuery(object item)
        {
            if (!Datastores.dbused)
                return false;
            string query = "";
            if(item is SortedList<uint,creature>)
            {
                foreach (KeyValuePair<uint, creature> itemf in (item as SortedList<uint,creature>))
                {
                    if (creatures.OffNpcList.ContainsKey(itemf.Key))
                    {
                        if (itemf.Value.overwritesofficial)
                        {
                            query = query + SQLcreator.CreateDeleteQuery(itemf.Value, "eventai_scripts");
                            query = query + SQLcreator.CreateCreateQuery(itemf.Value, "eventai_scripts");
                        }
                    }
                    else
                    {
                    }
                }
                SQLConnection.DoNONREADSD2Query("INSERT INTO `eventai_scripts` SELECT  * FROM `eventai_scripts_custom` WHERE `eventai_scripts_custom`.`creature_id` NOT IN (SELECT creature_id FROM eventai_scripts_official);", false);
            }
            if (item is SortedList<uint, summon>)
            {
                foreach (KeyValuePair<uint, summon> itemf in (item as SortedList<uint,summon>))
                {
                    if (summons.OffList.ContainsKey(itemf.Key))
                    {
                        if (itemf.Value.overwritesofficial)
                        {
                            query = query + SQLcreator.CreateDeleteQuery(itemf.Value, "eventai_summons");
                            query = query + SQLcreator.CreateCreateQuery(itemf.Value, "eventai_summons");
                        }
                    }
                    else
                    {
                    }
                }
                SQLConnection.DoNONREADSD2Query("INSERT INTO `eventai_summons` SELECT  * FROM `eventai_summons_custom` WHERE `eventai_summons_custom`.`id` NOT IN (SELECT id FROM eventai_summons_official);", false);

            }
            if (item is SortedList<uint, localized_text>)
            {
                foreach (KeyValuePair<uint, localized_text> itemf in (item as SortedList<uint,localized_text>))
                {
                    if (localized_texts.OffList.ContainsKey(itemf.Key))
                    {
                        if (itemf.Value.overwritesofficial)
                        {
                            query = query + SQLcreator.CreateDeleteQuery(itemf.Value, "eventai_localized_texts");
                            query = query + SQLcreator.CreateCreateQuery(itemf.Value, "eventai_localized_texts");
                        }
                    }
                    else
                    {
                    }
                }
                SQLConnection.DoNONREADSD2Query("INSERT INTO `eventai_localized_texts` SELECT  * FROM `eventai_localized_texts_custom` WHERE `eventai_localized_texts_custom`.`id` NOT IN (SELECT id FROM eventai_localized_texts_official);", false);

            }
            if(query != "")
            SQLConnection.DoNONREADSD2Query(query,true);
            return true;
        }

        public static bool SaveOneItemTODB(object item)
        {
            if (Datastores.dbused)
            {
                string query = SQLcreator.CreateDeleteQuery(item,"");
                query = query + SQLcreator.CreateCreateQuery(item,"");
                MySqlCommand c = new MySqlCommand(query, SQLConnection.conn);
                try
                {
                    c.ExecuteNonQuery();
                    
                    MessageBox.Show("Successful");
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else {MessageBox.Show("No DB Connection");return false;}
        }

        public static bool SaveAllItemsToDB(object item)
        {
            if (Datastores.dbused)
            {
                string query = "";

                if (item.Equals(localized_texts.map))
                {
                    foreach (KeyValuePair<uint, localized_text> itemf in localized_texts.map)
                    {
                        if (itemf.Value.changed)
                        {
                            query = query + SQLcreator.CreateDeleteQuery(itemf.Value,"");
                            query = query + SQLcreator.CreateCreateQuery(itemf.Value,"");
                        }
                    }
                }
                if (item.Equals(summons.map))
                {
                    foreach (KeyValuePair<uint, summon> itemf in summons.map)
                    {
                        if (itemf.Value.changed)
                        {
                            query = query + SQLcreator.CreateDeleteQuery(itemf.Value,"");
                            query = query + SQLcreator.CreateCreateQuery(itemf.Value,"");
                        }
                    }
                }
                if (item.Equals(creatures.npcList))
                {
                    foreach (KeyValuePair<uint, creature> itemf in creatures.npcList)
                    {
                        if (itemf.Value.changed)
                        {
                            query = query + SQLcreator.CreateDeleteQuery(itemf.Value,"");
                            query = query + SQLcreator.CreateCreateQuery(itemf.Value,"");
                        }
                    }
                }
                MySqlCommand c = new MySqlCommand(query, SQLConnection.conn);
                try
                {
                    if (query != "")
                    {
                        c.ExecuteNonQuery();
                        MessageBox.Show("Successful");
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else { MessageBox.Show("No DB Connection"); return false; }
        }
    }

    public class MyUserInfo : UserInfo
    {
        /// &lt;summary&gt;
        /// Holds the user password
        /// &lt;/summary&gt;
        private String passwd;

        /// &lt;summary&gt;
        /// Returns the user password
        /// &lt;/summary&gt;
        public String getPassword() { return passwd; }

        /// &lt;summary&gt;
        /// Prompt the user for a Yes/No input
        /// &lt;/summary&gt;
        public bool promptYesNo(String str)
        {
            return true;
        }

        /// &lt;summary&gt;
        /// Returns the user passphrase (passwd for the private key file)
        /// &lt;/summary&gt;
        public String getPassphrase() { return null; }

        /// &lt;summary&gt;
        /// Prompt the user for a passphrase (passwd for the private key file)
        /// &lt;/summary&gt;
        public bool promptPassphrase(String message) { return true; }

        /// &lt;summary&gt;
        /// Prompt the user for a password
        /// &lt;/summary&gt;
        public bool promptPassword(String message) { return true; }

        /// &lt;summary&gt;
        /// Shows a message to the user
        /// &lt;/summary&gt;
        public void showMessage(String message) { }

    }

}
