using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.IO;
using System.Reflection;
using System.Threading;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using MessagePack;

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
            Setup();
            var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
            Logger.LogWarning("Press ` to open the console after loading a save...");
            Logger.LogWarning("Enter 'EnableCheats' to enable the commands...");
            Logger.LogWarning("Enter 'help' to see the list of available commands...");
        }

        private void Setup()
        {
            Harmony.CreateAndPatchAll(typeof(Hooks));
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
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == OpCodes.Ldstr && (string)codes[i].operand == "EndDemoTriggered")
                {
                    for (int j = 0; j < 6; j++)
                    {
                        codes.RemoveAt(i);
                    }
                    break;
                }
            }
            return codes;
        }
    }

    [HarmonyPatch(typeof(GameState))]
    [HarmonyPatch("DoEndDayLogic")]
    public static class GameStatePatch
    {
        static bool Prefix(GameState __instance, int daysPassed)
        {
            MethodInfo runCoreEndDayLogicMethod = typeof(GameState).GetMethod("RunCoreEndDayLogic", BindingFlags.NonPublic | BindingFlags.Instance);
            if (runCoreEndDayLogicMethod == null)
            {
                Debug.LogError("RunCoreEndDayLogic method not found!");
                return false;
            }
            FieldInfo onDayEndEvField = typeof(GameState).GetField("OnDayEndEv", BindingFlags.NonPublic | BindingFlags.Instance);
            if (onDayEndEvField != null)
            {
                Action onDayEndEv = (Action)onDayEndEvField.GetValue(__instance);
                onDayEndEv?.Invoke();
            }
            bool flag = true;
            foreach (LocalPlayerController localPlayerController in PlayersManager.Instance.LocalPlayers)
            {
                if (localPlayerController != null)
                {
                    var playerData = localPlayerController.Data;
                    if (flag)
                    {
                        flag = false;
                        if (localPlayerController.Level != null && !localPlayerController.Level.IsDungeon())
                        {
                            playerData.Instance.GameUI.Fade.FadeOut(() =>
                            {
                                runCoreEndDayLogicMethod.Invoke(__instance, new object[] { playerData, daysPassed });
                            });
                        }
                        else
                        {
                            runCoreEndDayLogicMethod.Invoke(__instance, new object[] { playerData, daysPassed });
                        }
                    }
                    else if (localPlayerController.Level != null && !localPlayerController.Level.IsDungeon())
                    {
                        playerData.Instance.GameUI.Fade.FadeOut(null);
                    }
                }
            }
            return false;
        }
    }

    [HarmonyPatch(typeof(SaveGame))]
    [HarmonyPatch("HostSave")]
    public static class SaveGamePatch
    {
        static bool Prefix(SaveGame __instance)
        {
            if (Network.Instance != null && !Network.IsHost)
            {
                return false;
            }
            string text = SaveGame.GetFullPath(__instance.FileName, Environment.SpecialFolder.MyDocuments, "Saves");
            string text2 = text + "_new";
            string text3 = text + "_backup";
            byte[] array = MessagePackSerializer.Serialize(__instance, SaveGame.GetSerializerOptions(), default(CancellationToken));
            FileStream fileStream = File.Create(text2);
            fileStream.Write(array);
            fileStream.Close();
            if (!File.Exists(text))
            {
                File.Move(text2, text);
            }
            else
            {
                File.Replace(text2, text, text3);
            }
            MethodInfo createOrUpdateHeaderMethod = typeof(SaveGame).GetMethod("CreateOrUpdateHeader", BindingFlags.NonPublic | BindingFlags.Instance);
            if (createOrUpdateHeaderMethod != null)
            {
                createOrUpdateHeaderMethod.Invoke(__instance, null);
            }
            else
            {
                Debug.LogError("Could not find CreateOrUpdateHeader method!");
            }
            text = SaveGame.GetFullPath(__instance.HeaderFileName, Environment.SpecialFolder.MyDocuments, "Saves");
            text2 = text + "_new";
            text3 = text + "_backup";
            array = MessagePackSerializer.Serialize(__instance.Header, SaveGame.GetSerializerOptions(), default(CancellationToken));
            FileStream fileStream2 = File.Create(text2);
            fileStream2.Write(array);
            fileStream2.Close();
            if (!File.Exists(text))
            {
                File.Move(text2, text);
            }
            else
            {
                File.Replace(text2, text, text3);
            }
            Debug.Log("Saved game success");
            return false;
        }
    }
}
