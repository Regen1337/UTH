using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using LocalPlayerUtils = UTH.LocalPlayerUtils;
using Provider = SDG.Unturned.Provider;
using SteamPlayer = SDG.Unturned.SteamPlayer;
using Player = SDG.Unturned.Player;
using SteamChannel = SDG.Unturned.SteamChannel;
using Config = UTH.Config;

namespace UTH
{
    class ESP : MonoBehaviour
    {
        public enum ESPObject
        {
            Player,
            Airdrop,
            Vehicle,
            Item,
            Zombie,
            Animal,
            Resource,
            Barricade,
            Structure,
            Bed,
            Storage,
        }
        public class ESPObj
        {
            public ESPObject type;
            public object obj;
            public GameObject GO;

            public ESPObj(ESPObject type, object obj, GameObject GO)
            {
                this.type = type;
                this.obj = obj;
                this.GO = GO;
            }
        }

        public static List<SteamPlayer> SteamPlayerObjects = new List<SteamPlayer>();
        public static List<ESPObj> ESPObjects = new List<ESPObj>();

        public static IEnumerator UpdateEspObjectList()
        {
            while (true)
            {
                var LocalPlayer = LocalPlayerUtils.GetLocalPlayer();
                if (Provider.isConnected && Globals.mainCamera != null && LocalPlayer != null)
                {
                    SteamPlayerObjects = Provider.clients.ToList();
                    ESPObjects.Clear();
                    foreach (var steamPlayer in SteamPlayerObjects)
                    {
                        var player = steamPlayer.player;
                        if (player == null || player == LocalPlayer) continue;
                        var GO = player.gameObject;

                        ESPObj espObj = new ESPObj(ESPObject.Player, player, GO);
                        ESPObjects.Add(espObj);
                    }
                }
                yield return new WaitForSeconds(4f);
            }
        }

        void Start()
        {
            StartCoroutine(UpdateEspObjectList());
        }
    }

    public class ESPRenderer : MonoBehaviour
    {
        public static void DrawESP()
        {
            if (Globals.mainCamera == null || !Provider.isConnected || Globals.beingSpiedOn) return;
            foreach (var espObj in ESP.ESPObjects)
            {
                var GO = espObj.GO;
                var type = espObj.type;
                if (GO == null) continue;
                var screenPos = Globals.mainCamera.WorldToScreenPoint(GO.transform.position);
                if (screenPos.z > 0)
                {
                    switch (type)
                    {
                        case ESP.ESPObject.Player:
                            DrawPlayerESP(screenPos);
                            break;
                    }
                }
            }
        }

        public static void DrawPlayerESP(Vector3 screenPos)
        {
            var rect = new Rect(screenPos.x, Screen.height - screenPos.y, 100, 100);
            GUI.Box(rect, "Player");
        }

        void OnGUI()
        {
            if (Config.Main.ESPToggle) {
                DrawESP();
            }
        }
    }
}
