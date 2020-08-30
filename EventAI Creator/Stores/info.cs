﻿using System;
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
        public static string[,] EventListInfo = new string[,]
        {
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
/*17 | 18*/{"SUMMONED_UNIT","CreatureId","RepeatMin","RepeatMax","","Expires after creature with entry = (param1) is spawned or for all spawns if param1 = 0. Will repeat every (Param2) and (Param3) ."},
/*18 | 19*/{"TARGET_MANA","ManaMax%","ManaMin%","RepeatMin","RepeatMax","Expires when current target's Mana is between (Param1) and (Param2). Will repeat every (Param3) and (Param4)."},
/*19 | 20*/{"QUEST_ACCEPT","","","","","Event not implemented in core - use at your own risk"},
/*20 | 21*/{"QUEST_COMPLETE","","","","","Event not implemented in core - use at your own risk"},
/*21 | 22*/{"REACHED_HOME","","","","","Expires when a creature reaches it's home (spawn) location after evade."},
/*22 | 23*/{"RECEIVE_EMOTE","EmoteId","Condition","CondValue1","CondValue2","Expires when a creature receives an emote with emote text id (enum TextEmotes) in (Param1). Conditions can be defined (Param2) with optional values (Param3,Param4), see enum ConditionType."},
/*23 | 24*/{"AURA","SpellID","Stacks","RepeatMin","RepeatMax","Expires when a creature has spell (Param1) auras applied in a stack greater or equal to value provided in (Param2). Will repeat every (Param3) and (Param4)."},
/*24 | 25*/{"TARGET_AURA","SpellID","Stacks","RepeatMin","RepeatMax","Expires when the current target unit has spell (Param1) auras applied in a stack greater or equal to value provided in (Param2). Will repeat every (Param3) and (Param4)."},
/*25 | 26*/{"SUMMONED_JUST_DIED","CreatureId","RepeatMin","RepeatMax","","Expires after creature with entry = (Param1) is die (Param1 = 0 means all spawns). Will repeat every (Param2) and (Param3)."},
/*26 | 27*/{"SUMMONED_JUST_DESPAWN","CreatureId","RepeatMin","RepeatMax","","Expires before creature with entry = (Param1) is despawn (Param1 = 0 means all spawns). Will repeat every (Param2) and (Param3)."},
/*27 | 28*/{"MISSING_AURA","SpellID","Stacks","RepeatMin","RepeatMax","Expires when a creature not has spell (Param1) auras applied in a stack greater or equal to value provided in (Param2). Will repeat every (Param3) and (Param4)."},
/*28 | 29*/{"TARGET_MISSING_AURA","SpellID","Stacks","RepeatMin","RepeatMax","Expires when when the current target unit not has spell (Param1) auras applied in a stack greater or equal to value provided in (Param2). Will repeat every (Param3) and (Param4)."},
/*29 | 30*/{"TIMER_GENERIC","InitialMin","InitialMax","RepeatMin","RepeatMax","Expires at first between (Param1) and (Param2) and then will repeat between every (Param3) and (Param4)." },
/*30 | 31*/{"RECEIVE_AI_EVENT","AIEventType","SenderEntry","","","Expires when the creature receives an AIEvent of type (Param1), sent by creature (Param2 != 0). If (Param2 = 0) then sent by any creature"},
/*31 | 32*/{"ENERGY","EnergyMax","EnergyMin","RepeatMin","RepeatMax","Expires once Energy% is between (Param1) and (Param2). Will repeat every (Param3) and (Param4)."},
/*32 | 33*/{"SELECT_ATTACKING_TARGET","MinRange","MaxRange","RepeatMin","RepeatMax","Expires once Energy% is between (Param1) and (Param2). Will repeat every (Param3) and (Param4)."},
/*33 | 34*/{"FACING_TARGET","Back/Front","","RepeatMin","RepeatMax","Expires if (Param1) is 0 and source is behind the target or if (Param1) is 1 and source is in from of the target. Will repeat every (Param3) and (Param4)."},
/*34 | 35*/{"SPELLHIT_TARGET","SpellId","School","RepeatMin","RepeatMax","Expires once the spell Id (Param1) or spell school (Param2) hits the target. Will repeat every (Param3) and (Param4)."},
/*35 | 36*/{"DEATH_PREVENTED","","","","","Expires if the creature is prevented from dying."},
        };

        public static string[,] ActionListInfo = new string[,]
        {
/*00 | 01 */{"NONE","","","","Does nothign"},
/*01 | 01 */{"TEXT","-TextId","-TextId","-TextId","Simply displays the specified -TextId. When -TextId2 and -TextId3 are specified, the selection will be randomized. Text types are defined, along with other options for the text, in a table below. All values needs to be negative."},
/*02 | 01 */{"SET_FACTION","FactionId","TempFactionFlag","","Changes faction for a creature. When param1 is zero, creature will revert to it's default faction. Flags will determine when faction is restored to default (evade, respawn etc)"},
/*03 | 01 */{"MORPH_TO_MODEL_OR_ENTRY","CreatureEntry","ModelId","","Set either model from creature_template.entry (Param1) OR explicit modelId (Param2). If (Param1) AND (Param2) are both 0, demorph and revert to the default model."},
/*04 | 01 */{"SOUND","SoundId","","","Plays Sound"},
/*05 | 01 */{"EMOTE","EmoteId","","","Does emote"},
/*06 | 01 */{"RANDOM_SAY","","","","Not implemented in core"},
/*07 | 01 */{"RANDOM_YELL","","","","Not implemented in core"},
/*08 | 01 */{"RANDOM_TEXTEMOTE","","","","Not implemented in core"},
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
/*21 | 01 */{"COMBAT_MOVEMENT","AllowCombatMove","StopMeleeCombat","","0 = stop combat based movement, anything else continue/allow combat based movement (targeted movement generator)"},
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
/*38 | 01 */{"ZONE_COMBAT_PULSE","","","","Places all players within the instance into combat with the creature. Only works in combat and only works inside of instances."},
/*39 | 01 */{"CALL_FOR_HELP","Radius","","","Call any friendly out-of-combat creatures in a radius (Param1) to attack current creature's target."},
/*40 | 01 */{"SET_SHEATH","Sheath","","","Sets sheath state for a creature (0 = no weapon, 1 = melee weapon, 2 = ranged weapon)."},
/*41 | 01 */{"FORCE_DESPAWN","Delay","","","Despawns the creature, if delay = 0 immediate otherwise will despawn after delay time set in Param1 (in ms)."},
/*42 | 01 */{"INVINCIBILITY_HP_LEVEL","HP_Level","HP_Percent","","Set min. health level for creature that can be set at damage as flat value or percent from max health"},
/*43 | 01 */{"MOUNT_TO_ENTRY_OR_MODEL","CreatureEntry","ModelId","","Set mount model from creature_template.entry (Param1) OR explicit modelId (Param2). If (Param1) AND (Param2) are both 0, unmount."},
/*44 | 01 */{"CHANCED_TEXT","Chance","-TextId1","-TextId2","Displays by Chance (1..100) the specified -TextId. When -TextId2 is specified, the selection will be randomized. Text types are defined, along with other options for the text, in a table below. Param2 and Param3 needs to be negative."},
/*45 | 01 */{"THROW_AI_EVENT","EventType","Radius","","Throws an AIEvent of type (Param1) to nearby friendly Npcs in range of (Param2)"},
/*46 | 01 */{"SET_THROW_MASK","EventTypeMask","","","Marks for which AIEvents the npc will throw AIEvents on its own."},
/*47 | 01 */{"SET_STAND_STATE","StandState","","","Set the unit stand state (Param1) of the current creature."},
/*48 | 01 */{"CHANGE_MOVEMENT","MovementType","WanderDistance","","Change the unit movement type (Param1). If the movement type is Random Movement (1), the WanderDistance (Param2) must be provided."},
/*49 | 01 */{"DYNAMIC_MOVEMENT","Enable","","","Change the unit movement type (Param1). If the movement type is Random Movement (1), the WanderDistance (Param2) must be provided."},
/*50 | 01 */{"SET_REACT_STATE","ReactState","","","Change the unit movement type (Param1). If the movement type is Random Movement (1), the WanderDistance (Param2) must be provided."},
/*51 | 01 */{"PAUSE_WAYPOINTS","DoPause","","","Change the unit movement type (Param1). If the movement type is Random Movement (1), the WanderDistance (Param2) must be provided."},
/*52 | 01 */{"INTERRUPT_SPELL","SpellType","","","Change the unit movement type (Param1). If the movement type is Random Movement (1), the WanderDistance (Param2) must be provided."},
/*53 | 01 */{"START_RELAY_SCRIPT","RelayScriptId","Target","","Change the unit movement type (Param1). If the movement type is Random Movement (1), the WanderDistance (Param2) must be provided."},
/*54 | 01 */{"TEXT_NEW","TextID","Target","TemplateId","Change the unit movement type (Param1). If the movement type is Random Movement (1), the WanderDistance (Param2) must be provided."},
/*55 | 01 */{"ATTACK_START","Target","","","Change the unit movement type (Param1). If the movement type is Random Movement (1), the WanderDistance (Param2) must be provided."},
/*56 | 01 */{"DESPAWN_GUARDIANS","GuardianEntryID","","","Change the unit movement type (Param1). If the movement type is Random Movement (1), the WanderDistance (Param2) must be provided."},
/*57 | 01 */{"SET_RANGED_MODE","RangeModeType","ChaseDistance","","Change the unit range mode type (Param1) and set the chase distance (Param2)."},
/*58 | 01 */{"SET_WALK","WalkModeType","","","Change the unit walk type (Param1)"},
/*59 | 01 */{"SET_FACING","TargetEntry","Reset","","Set facing to the target with entry (Param1) provided by the target selection. If reset is set to 1 (Param2) the creature will reset to respawn coords."},
/*60 | 01 */{"SET_SPELL_SET","SpellSetID","","","Change the unit spell set to the one provided by (Param1)."},
/*61 | 01 */{"SET_IMMOBILIZED_STATE","Apply","CombatOnly","","Toggle the unit immobilized state based on (Param1). (Param2) defines if this takes place only during combat."},
        };

        public static string[] EventFlags = new string[]
        {
            "REPEATABLE",
            "DIFFICULTY_0",
            "DIFFICULTY_1",
            "DIFFICULTY_2",
            "DIFFICULTY_3",
            "RANDOM_ACTION",
            "DUMMY_FLAG",
            "DEBUG_ONLY",
            "RANGED_MODE_ONLY",
            "MELEE_MODE_ONLY",
            "COMBAT_ACTION",
        };

        public static string[] SpellSchoolMask = new string[]
        {
            "SPELL_SCHOOL_NORMAL",
            "SPELL_SCHOOL_HOLY",
            "SPELL_SCHOOL_FIRE",
            "SPELL_SCHOOL_NATURE",
            "SPELL_SCHOOL_FROST",
            "SPELL_SCHOOL_SHADOW",
            "SPELL_SCHOOL_ARCANE"
        };

        public static string[] CastFlags = new string[]
        {
            "CAST_INTURRUPT_PREVIOUS",
            "CAST_TRIGGERED",
            "CAST_FORCE_CAST",
            "CAST_NO_MELEE_IF_OOM",
            "CAST_FORCE_TARGET_SELF",
            "CAST_AURA_NOT_PRESENT",
            "CAST_IGNORE_UNSELECTABLE_TARGET",
            "CAST_SWITCH_CASTER_TARGET",
            "CAST_MAIN_SPELL",
            "CAST_PLAYER_ONLY",
            "CAST_DISTANCE_YOURSELF",
        };

        public static string[] SheathState = new string[]
        {
            "SHEATH_UNARMED",
            "SHEATH_MELEE",
            "SHEATH_RANGED"
        };

        public static string[] Boolean = new string[] {"FALSE", "TRUE"};

        public static string[] InstanceData = new string[]
        {
            "NOT_STARTED",
            "IN_PROGRESS",
            "FAIL",
            "DONE",
            "SPECIAL"
        };

        public static string[] RangedModeType = new string[]
        {
            "NONE",
            "FULL_CASTER",
            "PROXIMITY",
            "NO_MELEE_MODE"
        };

        public static string[] ReactStates = new string[]
        {
            "PASSIVE",
            "DEFENSIVE",
            "AGGRESSIVE"
        };

        public static string[] WalkModeType = new string[]
        {
            "RUN_DEFAULT",
            "WALK_DEFAULT",
            "RUN_CHASE",
            "WALK_CHASE"
        };

        public static string[] TargetType = new string[]
        {
            "SELF",
            "HOSTILE",
            "HOSTILE_SECOND_AGGRO",
            "HOSTILE_LAST_AGGRO",
            "HOSTILE_RANDOM",
            "HOSTILE_RANDOM_NOT_TOP",
            "ACTION_INVOKER",
            "ACTION_INVOKER_OWNER",
            "HOSTILE_RANDOM_PLAYER",
            "HOSTILE_RANDOM_NOT_TOP_PLAYER",
            "EVENT_SENDER",
            "HOSTILE_RANDOM_PLAYER",
            "HOSTILE_RANDOM_NOT_TOP_PLAYER",
            "SPAWNER",
            "EVENT_SPECIFIC",
            "PLAYER_INVOKER",
            "PLAYER_TAPPED",
            "NONE",
            "HOSTILE_RANDOM_MANA",
            "NEAREST_AOE_TARGET",
            "HOSTILE_FARTHEST_AWAY"
        };

        public static string[] FactionFlag = new string[]
        {
        //  "TEMPFACTION_NONE",
            "TEMPFACTION_RESTORE_RESPAWN",
            "TEMPFACTION_RESTORE_COMBAT_STOP",
            "TEMPFACTION_RESTORE_REACH_HOME",
            "TEMPFACTION_TOGGLE_NON_ATTACKABLE",
            "TEMPFACTION_TOGGLE_IMMUNE_TO_PLAYER",
            "TEMPFACTION_TOGGLE_IMMUNE_TO_NPC",
            "TEMPFACTION_TOGGLE_PACIFIED",
            "TEMPFACTION_TOGGLE_NOT_SELECTABLE"
        };

        public static string[] TeamTemplate = new string[] {"ALLIANCE", "HORDE"};

        public static string[] UnitFlags = new string[]
        {
            "UNIT_FLAG_UNK_0",
            "UNIT_FLAG_NON_ATTACKABLE",
            "UNIT_FLAG_CLIENT_CONTROL_LOST",
            "UNIT_FLAG_PLAYER_CONTROLLED",
            "UNIT_FLAG_RENAME",
            "UNIT_FLAG_PREPARATION",
            "UNIT_FLAG_UNK_6",
            "UNIT_FLAG_NOT_ATTACKABLE_1",
            "UNIT_FLAG_IMMUNE_TO_PLAYER",
            "UNIT_FLAG_IMMUNE_TO_NPC",
            "UNIT_FLAG_LOOTING",
            "UNIT_FLAG_PET_IN_COMBAT",
            "UNIT_FLAG_PVP_DEPRECATED",
            "UNIT_FLAG_SILENCED",
            "UNIT_FLAG_UNK_14",
            "UNIT_FLAG_SWIMMING",
            "UNIT_FLAG_NON_ATTACKABLE_2",
            "UNIT_FLAG_PACIFIED",
            "UNIT_FLAG_STUNNED",
            "UNIT_FLAG_IN_COMBAT",
            "UNIT_FLAG_TAXI_FLIGHT",
            "UNIT_FLAG_DISARMED",
            "UNIT_FLAG_CONFUSED",
            "UNIT_FLAG_FLEEING",
            "UNIT_FLAG_POSSESSED",
            "UNIT_FLAG_NOT_SELECTABLE",
            "UNIT_FLAG_SKINNABLE",
            "UNIT_FLAG_MOUNT",
            "UNIT_FLAG_UNK_28",
            "UNIT_FLAG_UNK_29",
            "UNIT_FLAG_SHEATHE",
            "UNIT_FLAG_IMMUNE"
        };

        public static string[] EventPhases = new string[]
        {
            "PHASE 1",
            "PHASE 2",
            "PHASE 3",
            "PHASE 4",
            "PHASE 5",
            "PHASE 6",
            "PHASE 7",
            "PHASE 8",
            "PHASE 9",
            "PHASE 10",
            "PHASE 11",
            "PHASE 12",
            "PHASE 13",
            "PHASE 14",
            "PHASE 15",
            "PHASE 16",
            "PHASE 17",
            "PHASE 18",
            "PHASE 19",
            "PHASE 20",
            "PHASE 21",
            "PHASE 22",
            "PHASE 23",
            "PHASE 24",
            "PHASE 25",
            "PHASE 26",
            "PHASE 27",
            "PHASE 28",
            "PHASE 29",
            "PHASE 30",
            "PHASE 31",
            "PHASE 32"
        };

        public static string[] InvincibilityTemplate = new string[] { "VALUE", "RATE" };

        public static string[] CreditTemplate = new string[] { "PERSONAL", "GROUP" };

        public static string[] MovementTemplate = new string[] { "IDLE", "RANDOMP", "WAYPOINT" };

        public static string[] ScriptTemplate = new string[]
        {
            "CREATURE_AI_SCRIPTS",
            "DBSCRIPTS_ON_CREATURE_DEATH",
            "DBSCRIPTS_ON_CREATURE_MOVEMENT",
            "DBSCRIPTS_ON_EVENT",
            "DBSCRIPTS_ON_GOSSIP",
            "DBSCRIPTS_ON_GO_USE",
            "DBSCRIPTS_ON_GO_TEMPLATE_USE",
            "DBSCRIPTS_ON_QUEST_END",
            "DBSCRIPTS_ON_QUEST_START",
            "DBSCRIPTS_ON_RELAY",
            "DBSCRIPTS_ON_SPELL"
        };

        public static string[] ScriptFlags = new string[]
        {
            "BUDDY_AS_TARGET",
            "REVERSE_DIRECTION",
            "SOURCE_TARGETS_SELF",
            "COMMAND_ADDITIONAL",
            "BUDDY_BY_GUID",
            "BUDDY_IS_PET",
            "BUDDY_IS_DESPAWNED",
            "BUDDY_BY_POOL"
        };

        public static string[] GameObjectFlags = new string[]
        {
            "GO_LOCK",
            "GO_UNLOCK",
            "GO_NONINTERACT",
            "GO_INTERACT"
        };

        public static string[] CurrentSpellTypes = new string[]
        {
            "MELEE_SPELL",
            "GENERIC_SPELL",
            "AUTOREPEAT_SPELL",
            "CHANNELED_SPELL"
        };

        public static string[] StandStateTemplate = new string[]
        {
            "STAND",
            "SIT",
            "SIT_CHAIR",
            "SLEEP",
            "SIT_LOW_CHAIR",
            "SIT_MEDIUM_CHAIR",
            "SIT_HIGH_CHAIR",
            "DEAD",
            "KNEEL",
            "CUSTOM",
        };

        public static string[] NpcFlags = new string[]
        {
            "NONE",
            "GOSSIP",
            "QUESTGIVER",
            "UNK1",
            "UNK2",
            "TRAINER",
            "TRAINER_CLASS",
            "TRAINER_PROFESSION",
            "VENDOR",
            "VENDOR_AMMO",
            "VENDOR_FOOD",
            "VENDOR_POISON",
            "VENDOR_REAGENT",
            "REPAIR",
            "FLIGHTMASTER",
            "SPIRITHEALER",
            "SPIRITGUIDE",
            "INNKEEPER",
            "BANKER",
            "PETITIONER",
            "TABARDDESIGNER",
            "BATTLEMASTER",
            "AUCTIONEER",
            "STABLEMASTER",
            "GUILD_BANKER",
            "SPELLCLICK",
            "PLAYER_VEHICLE"
        };

        public static string[] AIEvents = new string[]
        {
            "JUST_DIED",                                // Sender = Killed Npc, Invoker = Killer
            "CRITICAL_HEALTH",                          // Sender = Hurt Npc, Invoker = DamageDealer
            "LOST_HEALTH",                              // Sender = Hurt Npc, Invoker = DamageDealer
            "LOST_SOME_HEALTH",                         // Sender = Hurt Npc, Invoker = DamageDealer
            "GOT_FULL_HEALTH",                          // Sender = Healed Npc, Invoker = Healer
            "CUSTOM_EVENTAI_A",                         // Sender = Npc that throws custom event, Invoker = TARGET_T_ACTION_INVOKER (if exists)
            "CUSTOM_EVENTAI_B",                         // Sender = Npc that throws custom event, Invoker = TARGET_T_ACTION_INVOKER (if exists)
            "CUSTOM_EVENTAI_C",                         // Sender = Npc that throws custom event, Invoker = TARGET_T_ACTION_INVOKER (if exists)
            "CUSTOM_EVENTAI_D",                         // Sender = Npc that throws custom event, Invoker = TARGET_T_ACTION_INVOKER (if exists)
            "CUSTOM_EVENTAI_E",                         // Sender = Npc that throws custom event, Invoker = TARGET_T_ACTION_INVOKER (if exists)
            "CUSTOM_EVENTAI_F",                         // Sender = Npc that throws custom event, Invoker = TARGET_T_ACTION_INVOKER (if exists)
            "GOT_CCED",                                 // Sender = CCed Npc, Invoker = Caster that CCed
        };

        public static string[] NpcFlagsSelect = new string[] {"TOGGLE","ADD","REMOVE"};

        public static string[] PauseWaypoints = new string[] { "UNPAUSE", "PAUSE" };

        public static string[] SoundBitmask = new string[] {"ANYONE/TARGET", "DISTANCE DEPENDENT", "SOUND_TO_MAP", "SOUND_TO_ENTIRE_ZONE" };

        public static string[,] ScriptCommands = new string[,]
        {
            // command name         // datalong     // datalong2        // datalong 3   // source       // target       // command add              // details
/* 0 */     {"TALK",                "Template Id",  "",                 "",             "WorldObject*", "Unit/none*",   "",                         "Creature say/whisper/yell/textemote."},
/* 1 */     {"EMOTE",               "Emote Id",     "",                 "",             "Unit*",        "Unit/none*",   "",                         "Play emote on creature."},
/* 2 */     {"FIELD_SET",           "Field Id",     "Field Value",      "",             "any",          "",             "",                         "Change the value at an index for the unit."},
/* 3 */     {"MOVE_TO",             "",             "Travel Speed",     "",             "Creature*",    "",             "teleport unit to position","Relocate creature to a destination"},
/* 4 */     {"FLAG_SET",            "Field Id",     "Bitmask",          "",             "any",          "",             "",                         "Turns on bits on a flag field at an index for the worldobject."},
/* 5 */     {"FLAG_REMOVE",         "Field Id",     "Bitmask",          "",             "any",          "",             "",                         "Turns off bits on a flag field at an index for the worldobject."},
/* 6 */     {"TELEPORT_TO",         "Map Id",       "",                 "",             "Player|",      "Player|",      "",                         "Teleports the player to a location."},
/* 7 */     {"QUEST_EXPLORED",      "quest_id",     "distance",         "",             "GO/Creature^", "Player^",      "",                         "Satisfies the explore requirement for a quest."},
/* 8 */     {"KILL_CREDIT",         "Creature Entry","Group Credit",    "",             "Player|",      "Player|",      "",                         "Satisfies the kill credit requirement for a quest."},
/* 9 */     {"RESPAWN_GAMEOBJECT",  "DB Guid",      "Despawn Delay",    "",             "any",          "any",          "",                         "Spawns a despawned gameobject."},
/* 10 */    {"TEMP_SUMMON_CREATURE","Creature Entry","Despawn Delay",   "Path Id",      "any",          "any",          "summon as active object",  "Temporarily summon a creature."},
/* 11 */    {"OPEN_DOOR",           "DB Guid",      "Reset Delay",      "",             "any",          "",             "",                         "Opens a door gameobject (type == 0)."},
/* 12 */    {"CLOSE_DOOR",          "DB Guid",      "Reset Delay",      "",             "any",          "",             "",                         "Closes a door gameobject (type == 0)."},
/* 13 */    {"ACTIVATE_OBJECT",     "",             "",                 "",             "unit",         "GO",           "",                         "Activates an object."},
/* 14 */    {"REMOVE_AURA",         "Spell Id",     "",                 "",             "Unit*",        "",             "",                         "Removes an aura due to a spell."},
/* 15 */    {"CAST_SPELL",          "Spell Id",     "Cast Flags",       "",             "Unit*",        "Unit*",        "cast triggered",           "Casts a spell."},
/* 16 */    {"PLAY_SOUND",          "Sound Id",     "Sound Flags",      "",             "any object",   "any/player",   "",                         "Plays a sound."},
/* 17 */    {"CREATE_ITEM",         "Item Entry",   "Amount",           "",             "player|",      "player|",      "",                         "Creates an item."},
/* 18 */    {"DESPAWN_SELF",        "Despawn Delay","",                 "",             "Creature*",    "",             "",                         "Despawns an npc with some delay."},
/* 19 */    {"PLAY_MOVIE",          "movie id",     "",                 "",             "",             "player",       "",                         "Plays a movie."},
/* 20 */    {"MOVEMENT",            "MovementType", "Wander / Path Id", "Timer",        "Creature*",    "",             "RandomMovement",           "Change Movement of a creature."},
/* 21 */    {"SET_ACTIVEOBJECT",    "True / False", "",                 "",             "Creature*",    "",             "",                         "Sets the active object state of the creature"},
/* 22 */    {"SET_FACTION",         "Faction Id",   "TemporaryFactionFlags","",         "Creature*",    "",             "",                         "Sets the faction id from the creature."},
/* 23 */    {"MORPH_TO_ENTRY_OR_MODEL","Entry  /Modelid","",            "",             "Creature*",    "",             "",                         "Morphs the creature to the model specified."},
/* 24 */    {"MOUNT_TO_ENTRY_OR_MODEL","Entry / Modelid","",            "",             "Creature*",    "",             "",                         "Mounts the creature with the model specified."},
/* 25 */    {"SET_RUN",             "True / False", "",                 "",             "Creature*",    "",             "",                         "Changes the run capacity of the creature."},
/* 26 */    {"ATTACK_START",        "",             "",                 "",             "Creature*",    "unit*",        "",                         "Makes a creature attack a unit"},
/* 27 */    {"GO_LOCK_STATE",       "Flag",         "",                 "",             "GO*",          "",             "",                         "Lock/Unlock a gameobject"},
/* 28 */    {"STAND_STATE",         "Stand State",  "",                 "",             "Creature*",    "",             "",                         "Set the stand state of a creature"},
/* 29 */    {"MODIFY_NPC_FLAGS",    "NPC Flags",    "Bitmask",          "",             "Creature*",    "",             "",                         "Modify the NPC flags of a creature"},
/* 30 */    {"SEND_TAXI_PATH",      "Taxi Path id", "",                 "",             "Player|",      "Player|",      "",                         "Send player in Taxi path"},
/* 31 */    {"TERMINATE_SCRIPT",    "NPC Entry",    "Search Distance",  "Pool Id",      "Creature|",    "Creature|",    "not alive / alive",        "Terminate current script execution"},
/* 32 */    {"PAUSE_WAYPOINTS",     "unpause/pause","",                 "",             "Creature|",    "Creature|",    "",                         "Unpause/pause waypoint movement"},
/* 33 */    {"XP_USER",             "Off / On",     "",                 "",             "Player|",      "Player|",      "",                         "Allow the player to stop or resume XP gain"},
/* 34 */    {"TERMINATE_COND",      "Condition Id", "fail-quest",       "",             "",             "",             "terminate when condition is false", "Terminate a script based on a condition"},
/* 35 */    {"SEND_AI_EVENT",       "AIEventType",  "Radius",           "",             "Creature*",    "Unit*",        "",                         "Send AI event around or target - limited to eventAI events only"},
/* 36 */    {"SET_FACING",          "Reset facing", "",                 "",             "Creature*",    "WorldObject",  "set target guid",          "Set facing of the creature source to the target"},
/* 37 */    {"MOVE_DYNAMIC",        "Max Dist",     "Min Dist",         "Fixed Dist",   "Creature*",    "WorldObject",  "use random point",         "Move source to a random point between source and target."},
/* 38 */    {"SEND_MAIL",           "Template Id",  "Alt Sender",       "",             "WorldObject",  "Player*",      "",                         "Send email to player"},
/* 39 */    {"SET_FLY",             "True / False", "",                 "",             "Creature*",    "",             "set/unset byte flag",      "Changes the fly capacity of the creature."},
/* 40 */    {"DESPAWN_GO",          "",             "",                 "",             "GO*",          "",             "",                         "Despawn an GO with some instant."},
/* 41 */    {"RESPAWN",             "",             "",                 "",             "Creature*",    "",             "",                         "Respawn an npc with some instant."},
/* 42 */    {"SET_EQUIPMENT_SLOTS", "Reset Default","",                 "",             "Creature*",    "",             "",                         "Set the equipment slots."},
/* 43 */    {"RESET_GO",            "",             "",                 "",             "",             "GO",           "",                         "Reset Door or Button"},
/* 44 */    {"UPDATE_TEMPLATE",     "New Template Id","",               "",             "Creature*",    "",             "",                         "Update creature entry"},
/* 45 */    {"START_RELAY_SCRIPT",  "Relay Id",     "Relay Template Id","",             "Unit*",        "",             "",                         "Start relay script. Use Template Id if provided"},
/* 46 */    {"CAST_CUSTOM_SPELL",   "Spell Id",     "Cast Flags",       "",             "Unit*",        "Unit*",        "",                         "Cast custom spell"},
/* 47 */    {"INTERRUPT_SPELL",     "Current Spell Type","",            "",             "Unit*",    "",             "",                             "Interrupt spell by type"},
        };
    }
}
