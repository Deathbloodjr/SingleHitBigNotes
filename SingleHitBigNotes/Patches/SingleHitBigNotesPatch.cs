using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleHitBigNotes.Patches
{
    internal class SingleHitBigNotesPatch
    {
        [HarmonyPatch(typeof(EnsoInput))]
        [HarmonyPatch(nameof(EnsoInput.GetLastInputForCore))]
        [HarmonyPatch(MethodType.Normal)]
        [HarmonyPostfix]
        public static void EnsoInput_GetLastInputForCore_Postfix(EnsoInput __instance, ref TaikoCoreTypes.UserInputType __result, int player)
        {
            switch (__result)
            {
                case TaikoCoreTypes.UserInputType.Don_Pad:
                    __result = TaikoCoreTypes.UserInputType.Don_Strong;
                    break;
                case TaikoCoreTypes.UserInputType.Katsu_Pad:
                    __result = TaikoCoreTypes.UserInputType.Katsu_Strong;
                    break;
            }
        }
    }
}
