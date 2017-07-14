using RustHax;
using UnityEngine;
using static RustHax.Config.Aimbot;
using static RustHax.Config.ESP;
using static RustHax.Config.Misc;

public class Rendering
{
    private static Color color_0;
    private static GUIStyle guistyle_0 = new GUIStyle(GUI.skin.label);
    private static Texture2D texture2D_0 = new Texture2D(1, 1);

	public static void BoxRect(Rect rect, Color color)
    {
        if (color != color_0)
        {
            texture2D_0.SetPixel(0, 0, color);
            texture2D_0.Apply();
            color_0 = color;
        }
        GUI.DrawTexture(rect, texture2D_0);
    }

    public static void DrawBox(Vector2 pos, Vector2 size, float thick, Color color, bool ducked = false)
    {
		if (ducked)
		{
			size.y = size.y * 0.611f;
			pos.y = pos.y - 1.5f;
		}
			
        BoxRect(new Rect(pos.x, pos.y, size.x, thick), color); 
        BoxRect(new Rect(pos.x, pos.y, thick, size.y), color);
        BoxRect(new Rect(pos.x + size.x, pos.y, thick, size.y), color);
        BoxRect(new Rect(pos.x, pos.y + size.y, size.x + thick, thick), color);
    }

    public static void DrawHealth(Vector2 pos, float health, bool center = false)
    {
        if (center)
        {
            pos -= new Vector2(26f, 0f);
        }
        pos -= new Vector2(0f, 8f);
        BoxRect(new Rect(pos.x, pos.y, 52f, 5f), Color.black);
        pos += new Vector2(1f, 1f);
        Color green = Color.green;
        if (health <= 60f)
        {
            green = Color.yellow;
        }
        if (health <= 25f)
        {
            green = Color.red;
        }
        BoxRect(new Rect(pos.x, pos.y, 0.5f * health, 3f), green);
    }

    public static void DrawString(Vector2 pos, string text, Color color, bool center = true, int size = 12,
        bool outline = false, int lines = 1)
    {
        guistyle_0.fontSize = size;
        guistyle_0.normal.textColor = color;
        GUIContent content = new GUIContent(text);
        if (center)
        {
            pos.x -= guistyle_0.CalcSize(content).x / 2f;
        }
        Rect rect = new Rect(pos.x, pos.y, 300f, lines * 25f);
        if (!outline)
        {
            GUI.Label(rect, content, guistyle_0);
        }
        else
        {
            DrawOutlinedString(rect, text, color);
        }
    }

    public static void DrawWatermark(string text, Color color, int size = 12)
    {
        guistyle_0.fontSize = size;
        guistyle_0.normal.textColor = color;
        GUIContent content = new GUIContent(text);
        GUI.Label(new Rect(1, 1, 300f, 25f), content, guistyle_0);
    }

    public static void DrawWatermark2(string text, Color color, int size = 12)
    {
        guistyle_0.fontSize = size;
        guistyle_0.normal.textColor = color;
        GUIContent content = new GUIContent(text);
        GUI.Label(new Rect(250, 250, 300f, 25f), content, guistyle_0);
    }

    public static void DrawOutlinedString(Rect rect, string text, Color color)
    {
        GUIStyle backupStyle = guistyle_0;
        guistyle_0.normal.textColor = Color.black;
        rect.x--;
        GUI.Label(rect, text, guistyle_0);
        rect.x += 2;
        GUI.Label(rect, text, guistyle_0);
        rect.x--;
        rect.y--;
        GUI.Label(rect, text, guistyle_0);
        rect.y += 2;
        GUI.Label(rect, text, guistyle_0);
        rect.y--;
        guistyle_0.normal.textColor = color;
        GUI.Label(rect, text, guistyle_0);
        guistyle_0 = backupStyle;
    }

    public static void DrawEspMenu(int integer)
    {
		shouldDrawPlayers = GUI.Toggle(new Rect(10f, 25f, 110f, 20f), shouldDrawPlayers,
            string.Format("Players ESP"));
		shouldDrawSleepers = GUI.Toggle(new Rect(10f, 50f, 110f, 20f), shouldDrawSleepers,
            string.Format("Sleepers ESP"));
		shouldDrawHealthBar = GUI.Toggle(new Rect(10f, 75f, 110f, 20f), shouldDrawHealthBar,
            string.Format("Health ESP"));
		shouldDrawEquipedItem = GUI.Toggle(new Rect(10f, 100f, 110f, 20f), shouldDrawEquipedItem,
            string.Format("Item ESP"));
		shouldDrawStorage = GUI.Toggle(new Rect(10f, 125f, 110f, 20f), shouldDrawStorage,
            string.Format("Loot ESP"));
		shouldDrawCrosshair = GUI.Toggle(new Rect(10f, 150f, 110f, 20f), shouldDrawCrosshair,
            string.Format("Crosshair"));
		shouldDrawResources = GUI.Toggle(new Rect(10f, 175f, 100f, 20f), shouldDrawResources,
            string.Format("Resource ESP"));
		shouldDrawAnimals = GUI.Toggle(new Rect(10f, 200f, 100f, 20f), shouldDrawAnimals,
            string.Format("Animals ESP"));
		shouldDrawHeli = GUI.Toggle(new Rect(10f, 225f, 110f, 20f), shouldDrawHeli,
            "Helicopter ESP");
		shouldDrawWorldItems = GUI.Toggle(new Rect(10f, 250f, 110f, 20f), shouldDrawWorldItems,
            "WorldItem ESP");
		shouldAlwaysBeDaytime = GUI.Toggle(new Rect(125f, 25f, 100f, 20f), shouldAlwaysBeDaytime,
            string.Format("Always DayTime"));
		autoDayTime = GUI.Toggle(new Rect(125f, 50f, 100f, 20f), autoDayTime,
            string.Format("Auto-DayTime"));
        GUI.Label(new Rect(125f, 75f, 100f, 20f), string.Format("Distance: {0}", drawDistanceGeneral));
		drawDistanceGeneral = (int) GUI.HorizontalSlider(new Rect(125f, 100f, 100f, 20f),
            (float)drawDistanceGeneral, 0f, 5000f);
        GUI.Label(new Rect(125f, 125f, 100f, 20f), string.Format("Dist. of Loot: {0}", drawDistanceLoot));
		drawDistanceLoot = (int) GUI.HorizontalSlider(new Rect(125f, 150f, 100f, 20f),
            (float)drawDistanceLoot, 0f, 5000f);
		shouldDrawCollectible = GUI.Toggle(new Rect(125f, 175f, 100f, 20f), shouldDrawCollectible,
			string.Format("Collectible ESP"));
		shouldDrawCupboards = GUI.Toggle(new Rect(125f, 200f, 100f, 20f), shouldDrawCupboards,
            string.Format("Cupboard ESP"));
		shouldDrawDoors = GUI.Toggle(new Rect(125f, 225f, 100f, 20f), shouldDrawDoors,
            string.Format("Doors ESP"));
		shouldDrawCorpses = GUI.Toggle(new Rect(125f, 250f, 100f, 20f), shouldDrawCorpses,
            string.Format("Corpses ESP"));
        GUI.DragWindow();
    }

    public static void DrawAimbotMenu(int integer)
    {
		shouldNoRecoil = GUI.Toggle(new Rect(10f, 25f, 200f, 20f), shouldNoRecoil,
            string.Format("NoRecoil"));
		shouldNoSway = GUI.Toggle(new Rect(10f, 50f, 200f, 20f), shouldNoSway, "NoSway");
		shouldEnableAimbot = GUI.Toggle(new Rect(10f, 75f, 200f, 20f), shouldEnableAimbot,
            string.Format("Aimbot: {0}", AimKey));
		AimAtHead = GUI.Toggle(new Rect(10f, 100f, 200f, 20f), AimAtHead, "AimAtHead");
		BulletDropPrediction = GUI.Toggle(new Rect(10f, 125f, 200f, 20f),
BulletDropPrediction, "BulletDropPrediction");
		VelocityPrediction = GUI.Toggle(new Rect(10f, 150f, 200f, 20f), VelocityPrediction,
            "VelocityPrediction");
		ForceAutomatic = GUI.Toggle(new Rect(10f, 175f, 200f, 20f), ForceAutomatic,
            "Force Automatic");
        GUI.DragWindow();
    }

    public static void DrawEspFilterMenu(int integer)
    {
		Filters.shouldDrawWoodenBoxes = GUI.Toggle(new Rect(10f, 25f, 110f, 20f),
Filters.shouldDrawWoodenBoxes, string.Format("Wooden Boxes"));
		Filters.shouldDrawSupplyDrops = GUI.Toggle(new Rect(10f, 50f, 110f, 20f),
Filters.shouldDrawSupplyDrops, string.Format("Supply Drops"));
		Filters.shouldDrawBarrels = GUI.Toggle(new Rect(10f, 75f, 110f, 20f),
Filters.shouldDrawBarrels, string.Format("Barrels"));
		Filters.shouldDrawTrash = GUI.Toggle(new Rect(10f, 100f, 110f, 20f),
Filters.shouldDrawTrash, string.Format("Trash"));
		Filters.shouldDrawFurnaces = GUI.Toggle(new Rect(10f, 125f, 110f, 20f),
Filters.shouldDrawFurnaces, string.Format("Furnaces"));
		Filters.shouldDrawFridges = GUI.Toggle(new Rect(10f, 150f, 110f, 20f),
Filters.shouldDrawFridges, string.Format("Fridges"));
		Filters.shouldDrawCrates = GUI.Toggle(new Rect(10f, 175f, 110f, 20f),
Filters.shouldDrawCrates, string.Format("Crates"));
		Filters.shouldDrawStashes = GUI.Toggle(new Rect(10f, 200f, 110f, 20f),
Filters.shouldDrawStashes, string.Format("Stashes"));
		Filters.shouldDrawRepairBenches = GUI.Toggle(new Rect(10f, 225f, 110f, 20f),
Filters.shouldDrawRepairBenches, string.Format("Repair Benches"));
		Filters.shouldDrawRecyclers = GUI.Toggle(new Rect(10f, 250f, 110f, 20f),
Filters.shouldDrawRecyclers, string.Format("Recyclers"));
		Filters.shouldDrawFoodboxes = GUI.Toggle(new Rect(125f, 25f, 110f, 20f),
Filters.shouldDrawFoodboxes, string.Format("Foodboxes"));
		Filters.shouldDrawCampfires = GUI.Toggle(new Rect(125f, 50f, 110f, 20f),
Filters.shouldDrawCampfires, string.Format("Campfires"));
		Filters.shouldDrawFuelStorages = GUI.Toggle(new Rect(125f, 75f, 110f, 20f),
Filters.shouldDrawFuelStorages, string.Format("Fuel Storages"));
		Filters.shouldDrawWaterCatchers = GUI.Toggle(new Rect(125f, 100f, 110f, 20f),
Filters.shouldDrawWaterCatchers, string.Format("Water Catchers"));
		Filters.shouldDrawLightSources = GUI.Toggle(new Rect(125f, 125f, 110f, 20f),
Filters.shouldDrawLightSources, string.Format("Light Sources"));
		Filters.shouldDrawRefineries = GUI.Toggle(new Rect(125f, 150f, 110f, 20f),
Filters.shouldDrawRefineries, string.Format("Refineries"));
		Filters.shouldDrawQuarries = GUI.Toggle(new Rect(125f, 175f, 110f, 20f),
Filters.shouldDrawQuarries, string.Format("Quarries"));
		Filters.shouldDrawTurrets = GUI.Toggle(new Rect(125f, 200f, 110f, 20f),
Filters.shouldDrawTurrets, string.Format("Turrets"));
		Filters.shouldDrawVendingMachines = GUI.Toggle(new Rect(125f, 225f, 110f, 20f),
Filters.shouldDrawVendingMachines, string.Format("Vending Machines"));
		Filters.shouldDrawOthers = GUI.Toggle(new Rect(125f, 250f, 110f, 20f),
Filters.shouldDrawOthers, string.Format("Others"));
        GUI.DragWindow();
    }

    public static void DrawMiscMenu(int integer)
    {
		FastGathering = GUI.Toggle(new Rect(10f, 25f, 200f, 20f), FastGathering,
            "FastGathering");
		SpeedHack = GUI.Toggle(new Rect(10f, 50f, 200f, 20f), SpeedHack,
            "SpeedHack: LeftShift");
        GUI.Label(new Rect(10f, 75f, 200f, 20f), string.Format("SpeedHackValue: {0}", SpeedHackValue));
		SpeedHackValue = GUI.HorizontalSlider(new Rect(10f, 100f, 200f, 20f),
            (float)SpeedHackValue, 1.028f, 4f);
		ClimbHack = GUI.Toggle(new Rect(10f, 125f, 200f, 20f), ClimbHack, "ClimbHack");
		DisableGrass = GUI.Toggle(new Rect(10f, 150f, 200f, 20f), DisableGrass, "DisableGrass");
		NoFallDamage = GUI.Toggle(new Rect(10f, 175f, 200f, 20f), NoFallDamage, "NoFallDamage");
        GUI.DragWindow();
    }
}