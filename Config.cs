using System;
using System.Collections.Generic;
using UnityEngine;

namespace UTH
{
    public class Config
    {
        public static void Init()
        {
            Config.Main.Enabled = true;
            Config.Main.NoRecoil = true;
            Config.Main.ESPToggle = true;
        }

        public static class Main
        {
            public static bool Enabled;
            public static bool NoRecoil;
            public static bool ESPToggle;
        }

        public static class ESP
        {
            public static bool Boxes = false;
            public static bool Names = false;
            public static bool Distance = false;

            public static Color FriendlyBoxColor = Color.green;
            public static Color BoxColor = Color.white;
            public static Color NameColor = Color.white;
            public static Color DistanceColor = Color.white;

        }
    }
}