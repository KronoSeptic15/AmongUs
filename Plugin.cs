using BepInEx;
using BepInEx.Configuration;
using System;
using Utilla;
using GorillaLocomotion;
namespace HiddenMonke{
#pragma warning disable IDE0051 // IDE0051: Remove unused member
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    [ModdedGamemode("AMONGUS", "AmongUs", Utilla.Models.BaseGamemode.Infection)]
    public class Plugin : BaseUnityPlugin{
        public static bool inRoom;
        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
        }
        public void FixedUpdate()
        {
            if (inRoom)
            {
                Player.Instance.disableMovement = false;
                Player.Instance.jumpMultiplier = 1.1f;
                Player.Instance.maxJumpSpeed = 6.5f;
            }
        }
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            if (gamemode.Contains("AMONGUS"))
                inRoom = true;
        }
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode){
            inRoom = false;
        }
    }
}
