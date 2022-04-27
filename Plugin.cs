using BepInEx;
using BepInEx.Configuration;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using Utilla;
using Photon.Pun;
using GorillaLocomotion;
using System.Collections.Generic;

namespace HiddenMonke{
#pragma warning disable IDE0051 // IDE0051: Remove unused member
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    [ModdedGamemode("HIDDENMONKE", "HIDDEN MONKE", Utilla.Models.BaseGamemode.Infection)]
    public class Plugin : BaseUnityPlugin{
        public static bool inRoom;
        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
        }
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            if (gamemode.Contains("HIDDENMONKE"))
            {
                inRoom = true;
                Player.Instance.disableMovement = false;
                Player.Instance.jumpMultiplier = 1.1f;
                Player.Instance.maxJumpSpeed = 6.5f;
            }
        }
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode){
            inRoom = false;
            GorillaTagger.Instance.sphereCastRadius = 0.05f;
        }
    }
}
