using System;
using System.Collections;
using System.Text;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace AmongUs.Patches
{
    internal class DecidingPatch : MonoBehaviour
    {
        [HarmonyPatch(typeof(GorillaTagManager))]
        [HarmonyPatch("ChangeCurrentIt", MethodType.Normal)]
        internal class MogusPatch
        {
            public static Text Text;
            static bool Prefix(ref int __result)
            {   
                IEnumerator tellTag()
                {
                    yield return new WaitForSeconds(1);
                    Text.text = "Imposter";
                    yield return new WaitForSeconds(2);
                }
                return true;
            }
        }
    }
}
