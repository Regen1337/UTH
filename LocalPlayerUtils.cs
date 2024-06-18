using System.Linq;
using UnityEngine;
using Config = UTH.Config;
using SteamChannel = SDG.Unturned.SteamChannel;
using SteamPlayer = SDG.Unturned.SteamPlayer;
using Player = SDG.Unturned.Player;
using Provider = SDG.Unturned.Provider;
using ItemGunAsset = SDG.Unturned.ItemGunAsset;

namespace UTH
{
    public class LocalPlayerUtils : MonoBehaviour
    {
        public static Player GetLocalPlayer()
        {
            return Provider.clients.Select(steamPlayer => steamPlayer.player).FirstOrDefault(player => player.channel.IsLocalPlayer);
        }

        public static ItemGunAsset GetGunAsset()
        {
            var localPlayer = GetLocalPlayer();
            if (localPlayer == null) return null;
            return localPlayer.equipment.asset as ItemGunAsset;
        }

        public static void SetNRecoil()
        {
            var gunAsset = GetGunAsset();
            if (gunAsset == null) return;

            gunAsset.recoilMin_x = 0;
            gunAsset.recoilMin_y = 0;
            gunAsset.recoilMax_x = 0;
            gunAsset.recoilMax_y = 0;

            gunAsset.shakeMin_x = 0;
            gunAsset.shakeMin_y = 0;
            gunAsset.shakeMax_x = 0;
            gunAsset.shakeMax_y = 0;
        }
    }
}