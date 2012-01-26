using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventAI_Creator
{
    class info
    {
    }

    static class Info
    {
        public static string[,] EventListInfo = new string[,]{
/*00 | 01*/{"TIMER","InitialMin","InitialMax","RepeatMin","RepeatMax","Expires first between (Param1) and (Param2) and then between every (Param3) and (Param4).  but only in combat."},
/*01 | 02*/{"TIMER_OOC","InitialMin","InitialMax","RepeatMin","RepeatMax","Expires first between (Param1) and (Param2) and then between every (Param3) and (Param4).  but only out of combat."},
/*02 | 03*/{"HP","HPMax%","HPMin%","RepeatMin","RepeatMax ","Expires when HP is between (Param1) and (Param2). Will repeat every (Param3) and (Param4)."},
/*03 | 04*/{"MANA","ManaMax%","ManaMin%","RepeatMin","RepeatMax","Expires once Mana% is between (Param1) and (Param2). Will repeat every (Param3) and (Param4)."},
/*04 | 05*/{"AGGRO","","","","","Expires upon initial aggro (does not repeat)."},
/*05 | 06*/{"KILL","RepeatMin","RepeatMax","","","Expires upon killing a player. Will repeat every (Param3) and (Param4)."},
/*06 | 07*/{"DEATH","","","","","Expires upon Death."},
/*07 | 08*/{"EVADE","","","","","Expires upon creature EnterEvadeMode()."},
/*08 | 09*/{"SPELLHIT","SpellID","School","RepeatMin","RepeatMax","Expires upon Spell hit. If (param1) is set will only expire on that spell. If (param2) will only expire on spells of that school. Will repeat every (Param3) and (Param4) ."},
/*09 | 10*/{"RANGE","MinDist","MaxDist","RepeatMin","RepeatMax","Expires when the highest threat target distance is greater than (Param1) and less than (Param2). Will repeat every (Param3) and (Param4) ."},
/*00 | 11*/{"OOC_LOS","NoHostile","NoFriendly","RepeatMin","RepeatMax","Expires when a Player moves within visible distance to creature. Does not expire for Hostile Players if (Param1) is not 0. Does not expire for Friendly Players if (Param2) is not 0. Will repeat every (Param3) and (Param4) . Does not expire for creatures or pet or when the creature is in combat."},
/*11 | 12*/{"SPAWNED","","","","","Expires at initial spawn and at creature respawn (useful for setting ranged movement type)"},
/*12 | 13*/{"TARGET_HP","HPMax%","HPMin%","RepeatMin","RepeatMax","Expires when Current Target's HP is between (Param1) and (Param2). Will repeat every (Param3) and (Param4) ."},
/*13 | 14*/{"TARGET_CASTING","RepeatMin","RepeatMax","","","Expires when the player is casting a spell. Will repeat every (Param1) and (Param2) ."},
/*14 | 15*/{"FRIENDLY_HP","HPDeficit","Radius","RepeatMin","RepeatMax","Expires when a friendly unit in radius has at least (param1) hp missing. Will repeat every (Param3) and (Param4) ."},
/*15 | 16*/{"FRIENDLY_IS_CC","DispelType","Radius","RepeatMin","RepeatMax","Expires when a friendly unit is Crowd controlled within the given radius (param2). Will repeat every (Param3) and (Param4) ."},
/*16 | 17*/{"MISSING_BUFF","SpellId","Radius","RepeatMin","RepeatMax","Expires when a friendly unit is missing aura's given by spell (param1) within radius (param2). Will repeat every (Param3) and (Param4) ."},
/*17 | 18*/{"SUMMONED_UNIT","CreatureId","RepeatMin","RepeatMax","","Expires after creature with entry = (param1) is spawned or for all spawns if param1 = 0. Will repeat every (Param2) and (Param3) ."}
       };

        public static string[,] ActionListInfo = new string[,]{
/*00 | 01 */{"NONE","","","","Does nothign"},
/*01 | 01 */{"SAY","TextId","","","Says text"},
/*02 | 01 */{"YELL","TextId","","","Yellls text"},
/*03 | 01 */{"TEXTEMOTE","TextId","","","Text Emotes text"},
/*04 | 01 */{"SOUND","SoundId","","","Plays Sound"},
/*05 | 01 */{"EMOTE","EmoteId","","","Does emote"},
/*06 | 01 */{"RANDOM_SAY","TextId1","TextId2","TextId3","Says random text between 3 params*"},
/*07 | 01 */{"RANDOM_YELL","TextId1","TextId2","TextId3","Yells random text between 3 params*"},
/*08 | 01 */{"RANDOM_TEXTEMOTE","TextId1","TextId2","TextId3","Text Emotes random text between 3 params*"},
/*09 | 01 */{"RANDOM_SOUND","SoundId1","SoundId2","SoundId3","Plays random sound between 3 params*"},
/*10 | 01 */{"RANDOM_EMOTE","EmoteId1","EmoteId2","EmoteId3","Emotes random emote between 3 params"},
/*11 | 01 */{"CAST","SpellId","Target","CastFlags","Casts spell (param1) on target type (param2). Uses Cast Flags (specified below target types)"},
/*12 | 01 */{"SUMMON","CreatureID","Target","Duration","Summons creature (param1) to attack target (param2) for (param3) duration. Spawns on top of current creature."},
/*13 | 01 */{"THREAT_SINGLE_PCT","Threat%","Target","","Modifies threat by (param1) on target type (param2)"},
/*14 | 01 */{"THREAT_ALL_PCT","Threat%","",""," Modifies threat by (param1) on all targets (using -100% on all will result in full aggro dump)"},
/*15 | 01 */{"QUEST_EVENT","QuestID","Target","","Calls AreaExploredOrEventHappens with (param1) for target type (Param2)"},
/*16 | 01 */{"QUEST_CASTCREATUREGO","QuestID","SpellId","Target","Sends CastCreatureOrGo for Quest (param1) with SpellId (param2) for target (param3)"},
/*17 | 01 */{"SET_UNIT_FIELD","Field_Number","Value","Target","Sets Unit Field (param1) to Value (param2) on target type (param3)"},
/*18 | 01 */{"SET_UNIT_FLAG","Flags","Target","","Sets flag (flags can be binary OR together to modify multiple flags at once) on for Target type (param2)"},
/*19 | 01 */{"REMOVE_UNIT_FLAG","Flags","Target","","Removes flag (flags can be binary OR together to modify multiple flags at once) on for Target type (param2)"},
/*20 | 01 */{"AUTO_ATTACK","AllowAutoAttack","","","0 = stop melee attack, anything else means continue attacking/allow melee attacking"},
/*21 | 01 */{"COMBAT_MOVEMENT","AllowCombatMovement","","","0 = stop combat based movement, anything else continue/allow combat based movement (targeted movement generator)"},
/*22 | 01 */{"SET_PHASE","Phase","","","Sets the current phase to (param1)"},
/*23 | 01 */{"INC_PHASE","Value","","","Increments the phase by (param1). May be negative to decrement phase but should not be 0."},
/*24 | 01 */{"EVADE","","","","Forces the creature to evade. Wiping all threat and dropping combat."},
/*25 | 01 */{"FLEE","","","","Causes the creature to flee. Please use this action instead of directly casting this spell so we may change this when a more correct approach is found."},
/*26 | 01 */{"QUEST_EVENT_ALL","QuestId","","","Calls GroupEventHappens with (param1). Only used if it's _expected_ event should complete for all players in current party"},
/*27 | 01 */{"CASTCREATUREGO_ALL","QuestId","SpellId","","Calls CastedCreatureOrGo for all players on the threat list with QuestID(Param1) and SpellId(Param2)"},
/*28 | 01 */{"REMOVEAURASFROMSPELL","Target","Spellid","","Removes all auras on Target caused by Spellid"},
/*29 | 01 */{"RANGED_MOVEMENT","Distance","Angle","","Changes the movement generator type to a ranged type. Note: Default melee type can still be done with this. Specify 0 angle and 0 distance."},
/*30 | 01 */{"RANDOM_PHASE","PhaseId1","PhaseId2","PhaseId3","Sets the phase to the id between 3 params*"},
/*31 | 01 */{"RANDOM_PHASE_RANGE","PhaseMin","PhaseMax","","Sets the phase to a random id (Phase = PhaseMin + rnd % PhaseMin-PhaseMax). PhaseMax must be greater than PhaseMin."},
/*32 | 01 */{"SUMMON","CreatureID","Target","SummonID","Summons creature (param1) to attack target (param2) at location specified by EventAI_Summons (param3)."},
/*33 | 01 */{"KILLED_MONSTER","CreatureID","Target","","Calls KilledMonster (param1) for target of type (param2)"},
/*34 | 01 */{"SET_INST_DATA","Field","Data","","Calls ScriptedInstance::SetData with field (param1) and data (param2)"},
/*35 | 01 */{"SET_INST_DATA64","Field","Target","","Calls ScriptedInstance::SetData64 with field (param1) and data (param2) target's GUID."},
/*36 | 01 */{"UPDATE_TEMPLATE","TemplateId","Team","","Changes the creature to a new creature template of (param1) with team = Alliance if (param2) = false or Horde if (param2) = true"},
/*37 | 01 */{"DIE","","","","Kills the creature"},
/*38 | 01 */{"ZONE_COMBAT_PULSE","","","","Places all players within the instance into combat with the creature. Only works in combat and only works inside of instances."}
        };
    }
}
