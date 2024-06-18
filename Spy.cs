using HarmonyLib;
using SDG.Unturned;
using Globals = UTH.Globals;
using UnityEngine;
using Time = SDG.Unturned.Time;

namespace UTH
{
    [HarmonyPatch(typeof(Player), "ReceiveTakeScreenshot")]
    public class NoSpyPatch
    {
        public static float lastSpyTime;
        static bool Prefix() // Prefix patch - executes before the original method
        {
            Globals.beingSpiedOn = true; 
            lastSpyTime = Time.realtimeSinceStartup; 

            return true; // Continue to execute the original method
        }

        static void Postfix() // Postfix patch - executes after the original method
        {
            Globals.beingSpiedOn = false; 
        }
    }
}