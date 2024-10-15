using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using GameLogic;

namespace LumaIslandDemoCheat
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Luma Island.exe")]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;

        private void Awake()
        {
            Logger = base.Logger;
            var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
            Logger.LogInfo("Patching complete...");
            Logger.LogWarning("Press ` to open the console after loading a save...");
            Logger.LogWarning("Enter 'EnableCheats' to enable the commands...");
            Logger.LogWarning("Enter 'help' to see the list of available commands...");
        }
    }

    [HarmonyPatch(typeof(ConsoleUI))]
    [HarmonyPatch("Awake")]
    public class ConsoleUIPatch
    {
        static void Postfix(ConsoleUI __instance)
        {
            var m_commandsField = AccessTools.Field(typeof(ConsoleUI), "m_commands");
            var m_commands = (System.Collections.Generic.Dictionary<string, Action<string[]>>)m_commandsField.GetValue(__instance);
            void AddCommand(string commandName, Action<string[]> action)
            {
                if (!m_commands.ContainsKey(commandName))
                {
                    m_commands.Add(commandName, action);
                }
                else
                {
                    Plugin.Logger.LogWarning($"Command {commandName} already exists.");
                }
            }
            AddCommand("help", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "Help")));
            AddCommand("explore", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "Explore")));
            AddCommand("freestuff", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "FreeStuff")));
            AddCommand("alchemy", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "Alchemy")));
            AddCommand("begin", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "Begin")));
            AddCommand("tools", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "Tools")));
            AddCommand("coppertools", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "CopperTools")));
            AddCommand("irontools", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "IronTools")));
            AddCommand("moonstonetools", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "MoonstoneTools")));
            AddCommand("volcanictools", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "VolcanicTools")));
            AddCommand("giveitem", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "GiveItem")));
            AddCommand("gi", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "GiveItem")));
            AddCommand("ti", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "TakeItem")));
            AddCommand("giveallitems", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "GiveAllItems")));
            AddCommand("givemoney", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "GiveMoney")));
            AddCommand("gm", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "GiveMoney")));
            AddCommand("endday", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "EndDay")));
            AddCommand("unlockblueprint", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "UnlockBlueprint")));
            AddCommand("unlockrecipe", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "UnlockRecipe")));
            AddCommand("unlockall", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "UnlockAll")));
            AddCommand("unlockalldrawings", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "UnlockAllDrawings")));
            AddCommand("unlockallrecipes", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "UnlockAllRecipes")));
            AddCommand("unlockallshops", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "UnlockAllShopItems")));
            AddCommand("lockrecipe", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "LockRecipe")));
            AddCommand("freeblueprints", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "FreeBlueprints")));
            AddCommand("settime", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "SetTime")));
            AddCommand("givetokens", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "GiveTokens")));
            AddCommand("startminigame", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "StartMinigame")));
            AddCommand("growforest", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "GrowForest")));
            AddCommand("growgrass", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "GrowGrass")));
            AddCommand("cleargrass", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "ClearGrass")));
            AddCommand("getlightamount", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "GetLightAmount")));
            AddCommand("rebakenavmesh", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "RebakeNavmesh")));
            AddCommand("listunlockedrecipes", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "ListUnlockedRecipes")));
            AddCommand("clear", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "ClearLog")));
            AddCommand("setrtpc", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "SetRTPC")));
            AddCommand("setglobalstate", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "SetGlobalState")));
            AddCommand("getglobalstate", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "GetGlobalState")));
            AddCommand("setplayerstate", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "SetPlayerState")));
            AddCommand("getplayerstate", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "GetPlayerState")));
            AddCommand("xpbomb", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "XPBomb")));
            AddCommand("dropxp", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "DropXP")));
            AddCommand("givexp", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "GiveXP")));
            AddCommand("resetcaves", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "ResetCaves")));
            AddCommand("resetcave", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "ResetCave")));
            AddCommand("startdanger", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "StartDanger")));
            AddCommand("setsimulationspeed", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "SetSimulationSpeed")));
            AddCommand("setgamespeed", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "SetGameSpeed")));
            AddCommand("freeseeds", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "FreeSeeds")));
            AddCommand("growcrops", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "GrowCrops")));
            AddCommand("spawnasloot", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "SpawnAsLoot")));
            AddCommand("moneyasloot", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "MoneyAsLoot")));
            AddCommand("teleport", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "Teleport")));
            AddCommand("startcutscene", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "StartCutscene")));
            AddCommand("godmode", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "EnableGodMode")));
            AddCommand("disablegodmode", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "DisableGodMode")));
            AddCommand("addtally", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "AddTally")));
            AddCommand("fillinventory", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "FillPlayerInventory")));
            AddCommand("clearinventory", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "ClearPlayerInventory")));
            AddCommand("startquest", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "StartQuest")));
            AddCommand("startquestlocal", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "StartQuestLocal")));
            AddCommand("forcecompletetask", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "ForceCompleteTask")));
            AddCommand("forcecompletetasklocal", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "ForceCompleteTaskLocal")));
            AddCommand("forcecompletetrackedtask", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "ForceCompleteTrackedTask")));
            AddCommand("givealllumas", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "GiveAllLumas")));
            AddCommand("upgradetool", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "UpgradeTool")));
            AddCommand("ascendtool", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "AscendTool")));
            AddCommand("setday", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "SetDay")));
            AddCommand("hide", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "HideUI")));
            AddCommand("show", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "ShowUI")));
            AddCommand("hidegameui", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "HideGameUI")));
            AddCommand("showgameui", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "ShowGameUI")));
            AddCommand("hideworldui", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "HideWorldUI")));
            AddCommand("showworldui", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "ShowWorldUI")));
            AddCommand("showwindow", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "ShowWindow")));
            AddCommand("hidewindow", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "HideWindow")));
            AddCommand("coords", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "PrintCoords")));
            AddCommand("next", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "NextTempleRoom")));
            AddCommand("ignorecost", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "IgnoreCost")));
            AddCommand("spider", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "SpawnSpiderInCave")));
            AddCommand("setprof", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "SetProfession")));
            AddCommand("allprofs", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "AllProfessions")));
            AddCommand("chestcheat", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "ChestCheat")));
            AddCommand("resetchests", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "ResetChests")));
            AddCommand("setcraftingspeed", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "SetCraftingSpeed")));
            AddCommand("setcropspeed", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "SetCropSpeed")));
            AddCommand("spawnspider", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "SpawnSpider")));
            AddCommand("killspiders", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "KillSpiders")));
            AddCommand("spawnghost", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "SpawnGhost")));
            AddCommand("spawnblueprint", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "SpawnBlueprint")));
            AddCommand("unstuck", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "Unstuck")));
            AddCommand("teleporttotile", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "TeleportPlayerToTile")));
            AddCommand("bait", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "AddBait")));
            AddCommand("printwindowstate", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "PrintWindowState")));
            AddCommand("enablewindowlog", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "EnableWindowLog")));
            AddCommand("disablewindowlog", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "DisableWindowLog")));
            AddCommand("enddemo", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "EndDemo")));
            AddCommand("nuke", (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), __instance, AccessTools.Method(typeof(ConsoleUI), "Nuke")));
            var m_inputField = AccessTools.Field(typeof(ConsoleUI), "m_input");
            var m_input = (TMP_InputField)m_inputField.GetValue(__instance);
            var updateSuggestionsMethod = AccessTools.Method(typeof(ConsoleUI), "UpdateSuggestions");
            m_input.onValueChanged.AddListener(new UnityAction<string>(input => updateSuggestionsMethod.Invoke(__instance, new object[] { input })));
            TMP_InputField.OnValidateInput originalValidator = m_input.onValidateInput;
            m_input.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(originalValidator, new TMP_InputField.OnValidateInput(__instance.IgnoreBackquote));
        }
    }

    [HarmonyPatch(typeof(GameLogic.SetGlobalStateNode), "DoFlow")]
    public static class SetGlobalStateNodePatch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            Plugin.Logger.LogInfo("Transpiler for EndDemoTriggered is running...");
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == OpCodes.Ldstr && (string)codes[i].operand == "EndDemoTriggered")
                {
                    Plugin.Logger.LogInfo("Removing 'EndDemoTriggered' check.");
                    for (int j = 0; j < 6; j++)
                    {
                        codes.RemoveAt(i);
                    }
                    Plugin.Logger.LogWarning("'EndDemoTriggered' logic removed.");
                    break;
                }
            }
            return codes;
        }
    }

    // TODO: Fix this? Anim still plays, but whatever. Day continues.
    /*
    [HarmonyPatch(typeof(GameState), "DoEndDayLogic")]
    public static class DoEndDayLogicPatch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            Plugin.Logger.LogInfo("Transpiler for DoEndDayLogic is running...");
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == OpCodes.Ldfld && codes[i].operand.ToString().Contains("m_earthquakeDuringLoadFX"))
                {
                    Plugin.Logger.LogInfo("Found 'm_earthquakeDuringLoadFX' field.");
                    for (int j = 0; j < 16; j++)
                    {
                        codes[i + j].opcode = OpCodes.Nop;
                        codes[i + j].operand = null;
                    }
                    Plugin.Logger.LogWarning("Earthquake trigger logic replaced with NOPs.");
                    break;
                }
            }
            return codes;
        }
    }
    */
}
