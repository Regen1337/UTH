using UnityEngine;

namespace UTH
{
    public class Loader
    {
        private static GameObject gameObject;

        public static void Load()
        {
            Config.Init();
            gameObject = new GameObject();
            gameObject.AddComponent<Main>();
            gameObject.AddComponent<LocalPlayerUtils>();
            gameObject.AddComponent<ESP>();
            gameObject.AddComponent<ESPRenderer>();

            Object.DontDestroyOnLoad(gameObject);
        }
    }
}