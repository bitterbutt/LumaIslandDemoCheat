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
            Logger.LogInfo("Patching...");
            Setup();
            var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
            Logger.LogInfo("Patching complete...");
            Logger.LogWarning("Press ` to open the console after loading a save...");
            Logger.LogWarning("Enter 'EnableCheats' to enable the commands...");
            Logger.LogWarning("Enter 'help' to see the list of available commands...");
        }

        private void Setup()
        {
            Harmony.CreateAndPatchAll(typeof(Hooks));
            Logger.LogWarning("Debug.isDebugBuild == " + Debug.isDebugBuild.ToString());
        }

        public static void NoOpMethod()
        {
            // Do nothing
        }
    }

    internal static class Hooks
    {
        [HarmonyPostfix, HarmonyPatch(typeof(UnityEngine.Debug), nameof(UnityEngine.Debug.isDebugBuild), MethodType.Getter)]
        private static void Patch_isDebugBuild(ref bool __result) => __result = true;
    }

    [HarmonyPatch(typeof(Debug), "isDebugBuild", MethodType.Getter)]
    public static class DebugIsDebugBuildAndIsEditorPatch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            Plugin.Logger.LogInfo("Transpiler removing isDebugBuild check...");
            Plugin.Logger.LogInfo("Transpiler removing isEditor check...");
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == OpCodes.Call && codes[i].operand.ToString().Contains("get_isDebugBuild"))
                {
                    codes.RemoveAt(i);
                    codes.Insert(i, new CodeInstruction(OpCodes.Ldc_I4_1));
                }

                if (codes[i].opcode == OpCodes.Call && codes[i].operand.ToString().Contains("get_isEditor"))
                {
                    codes.RemoveAt(i);
                    codes.Insert(i, new CodeInstruction(OpCodes.Ldc_I4_1));
                }
            }
            return codes;
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

    [HarmonyPatch(typeof(GameState), "DoEndDayLogic")]
    public static class DoEndDayLogicPatch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            Plugin.Logger.LogInfo("Transpiler for DoEndDayLogic is running...");
            bool foundEarthquakeTrigger = false;
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == OpCodes.Callvirt || codes[i].opcode == OpCodes.Call)
                {
                    // Plugin.Logger.LogInfo($"Found method call at index {i}: {codes[i].operand}");
                    if (codes[i].operand != null && (codes[i].operand.ToString().Contains("TriggerAll") || codes[i].operand.ToString().Contains("FXTrigger")))
                    {
                        Plugin.Logger.LogInfo("Found the FXTrigger method call. Replacing it with NoOpMethod.");
                        codes[i].opcode = OpCodes.Call;
                        codes[i].operand = AccessTools.Method(typeof(Plugin), nameof(Plugin.NoOpMethod));
                        Plugin.Logger.LogWarning("Replaced FXTrigger method with NoOpMethod.");
                        foundEarthquakeTrigger = true;
                    }
                }
            }

            if (!foundEarthquakeTrigger)
            {
                Plugin.Logger.LogError("Could not find the FXTrigger method to replace.");
            }
            return codes;
        }
    }

    [HarmonyPatch(typeof(SaveGame), "HostSave")]
    public static class SaveGame_HostSavePatch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            Plugin.Logger.LogInfo("Transpiler for HostSave is running...");
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == OpCodes.Ldfld && codes[i + 1].opcode == OpCodes.Ldc_I4_4 && codes[i + 2].opcode == OpCodes.Bge)
                {
                    Plugin.Logger.LogInfo("Found 'DaysPassed >= 4' check. Removing it.");
                    codes[i + 2].opcode = OpCodes.Nop;
                    Plugin.Logger.LogWarning("DaysPassed >= 4 check removed.");
                }
            }
            return codes;
        }
    }
}
