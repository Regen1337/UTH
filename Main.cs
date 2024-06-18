using UnityEngine;
using LocalPlayerUtils = UTH.LocalPlayerUtils;
using Rendering = UTH.Rendering;
using Globals = UTH.Globals;

namespace UTH
{
    public class Main : MonoBehaviour
    {
        public static Rect windowRect = new Rect(20f, 20f, 200f, 200f);
        private Camera _camera;
        private bool _ismainCameraNull;

        private static void DrawMainMenu()
        {
            windowRect = GUI.Window(0, windowRect, new GUI.WindowFunction(Rendering.DrawMiscMenu), "Miscellaneous");
        }

        private static void SetupHooks()
        {
        }
        
        private static void Setup() 
        {
            if (!Globals.ranSetup)
            {
                SetupHooks();

                Globals.ranSetup = true;
            }
        }

        void Start()
        {
            _ismainCameraNull = Globals.mainCamera == null;
            _camera = Camera.main;
            Setup();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Delete))
            {
                Globals.shouldDrawMainMenu = !Globals.shouldDrawMainMenu;
            }

            if (Config.Main.NoRecoil)
            {
                LocalPlayerUtils.SetNRecoil();
            }
        }
        private void OnGUI()
        {
            if (_ismainCameraNull)
            {
                //Hooks.NoSpy.Init();
                Globals.mainCamera = _camera;
            }

            if (Globals.shouldDrawMainMenu)
            {
                DrawMainMenu();
            }
        }
    }
}
