using HarmonyLib;
using UnityEngine;

namespace HiddenMonke.Patches
{
    [HarmonyPatch(typeof(GorillaTagManager))]
    [HarmonyPatch("MyMatIndex", MethodType.Normal)]
    internal class MogusPatch
    {
        public static bool sussy;
        static bool Prefix(ref int __result)
        {
            if (Plugin.inRoom)
            {
                __result = 0;
                sussy = true;
                return false;
            }
            return true;
        }
    }
}
