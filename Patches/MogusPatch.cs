using HarmonyLib;

namespace AmongUs.Patches
{
    [HarmonyPatch(typeof(GorillaTagManager))]
    [HarmonyPatch("MyMatIndex", MethodType.Normal)]
    internal class MogusPatch
    {
        static bool Prefix(ref int __result)
        {
            if (Plugin.inRoom)
            {
                __result = 0;
                return false;
            }
            return true;
        }
    }
}
