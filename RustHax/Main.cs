using RustHax;
using UnityEngine;
using static RustHax.Config.Aimbot;
using static RustHax.Config.ESP;
using Input = Facepunch.Input;

public class Main : MonoBehaviour
{
    public static bool shouldDrawMainMenu = false;
    private static Rect espWindowRect = new Rect(50f, 100f, 235f, 275f);
    private static Rect aimbotWindowRect = new Rect(300f, 100f, 235f, 205f);
    private static Rect filterWindowRect = new Rect(550f, 100f, 235f, 275f);
    private static Rect miscWindowRect = new Rect(800f, 100f, 235f, 205f);

    private void OnGUI()
    {
        if (shouldDrawMainMenu)
        {
            DrawMainMenu();
        }
    }

	private static void Start()
    {
        //Client.Steam.Username = "kecske";
        Input.SetBind("Delete", null);
        Input.SetBind(AimKey.ToString(), null);
    }

    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Delete))
        {
            shouldDrawMainMenu = !shouldDrawMainMenu;
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Keypad0))
        {
			shouldEnableAimbot = !shouldEnableAimbot;
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Keypad1))
        {
			shouldDrawStorage = !shouldDrawStorage;
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Keypad2))
        {
			shouldDrawResources = !shouldDrawResources;
        }


        if (UnityEngine.Input.GetKeyDown(KeyCode.Keypad3))
        {
			shouldDrawWorldItems = !shouldDrawWorldItems;
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Keypad4))
        {
			shouldDrawDoors = !shouldDrawDoors;
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Keypad5))
        {
			shouldDrawCupboards = !shouldDrawCupboards;
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Keypad6))
        {
			shouldDrawHeli = !shouldDrawHeli;
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Keypad7))
        {
			shouldDrawCorpses = !shouldDrawCorpses;
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Keypad8))
        {
			shouldAlwaysBeDaytime = !shouldAlwaysBeDaytime;
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Keypad9))
        {
			shouldNoRecoil = !shouldNoRecoil;
			shouldNoSway = !shouldNoSway;
        }
    }

    void DrawMainMenu()
    {
        espWindowRect = GUI.Window(0, espWindowRect, new GUI.WindowFunction(Rendering.DrawEspMenu), "ESP");
        aimbotWindowRect = GUI.Window(1, aimbotWindowRect, new GUI.WindowFunction(Rendering.DrawAimbotMenu), "Aimbot");
        filterWindowRect = GUI.Window(2, filterWindowRect, new GUI.WindowFunction(Rendering.DrawEspFilterMenu),
            "Loot Filters");
        miscWindowRect = GUI.Window(3, miscWindowRect, new GUI.WindowFunction(Rendering.DrawMiscMenu), "Misc");
    }
}