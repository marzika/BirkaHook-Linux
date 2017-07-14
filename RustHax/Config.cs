using System;
using System.Collections.Generic;
using UnityEngine;

namespace RustHax
{
	public class Config
	{
		public static void Init()
		{
			Aimbot.shouldNoRecoil = false;

			Aimbot.shouldNoSway = false;

			Aimbot.shouldEnableAimbot = false;

			Aimbot.maxFOV = 200f;

			Aimbot.AimAtHead = true;

			Aimbot.AimKey = KeyCode.LeftAlt;

			Aimbot.BulletDropPrediction = true;

			Aimbot.VelocityPrediction = false;

			Aimbot.ForceAutomatic = false;

			ESP.shouldDrawCupboards = false;

			ESP.shouldDrawDoors = false;

			ESP.shouldDrawCorpses = false;

			ESP.shouldDrawHeli = false;

			ESP.shouldDrawWorldItems = false;

			ESP.autoDayTime = false;

			ESP.shouldDrawHealthBar = false;

			ESP.shouldDrawEquipedItem = false;

			ESP.shouldDrawSleepers = false;

			ESP.shouldDrawPlayers = false;

			ESP.shouldDrawStorage = false;

			ESP.shouldDrawCrosshair = false;

			ESP.shouldDrawResources = false;

			ESP.shouldDrawCollectible = false;

			ESP.shouldDrawAnimals = false;

			ESP.shouldAlwaysBeDaytime = false;

			ESP.drawDistanceGeneral = 5000;

			ESP.drawDistanceLoot = 150;

			ESP.Filters.shouldDrawWoodenBoxes = false;

			ESP.Filters.shouldDrawSupplyDrops = false;

			ESP.Filters.shouldDrawBarrels = false;

			ESP.Filters.shouldDrawTrash = false;

			ESP.Filters.shouldDrawFurnaces = false;

			ESP.Filters.shouldDrawFridges = false;

			ESP.Filters.shouldDrawCrates = false;

			ESP.Filters.shouldDrawStashes = false;

			ESP.Filters.shouldDrawRepairBenches = false;

			ESP.Filters.shouldDrawRecyclers = false;

			ESP.Filters.shouldDrawFoodboxes = false;

			ESP.Filters.shouldDrawCampfires = false;

			ESP.Filters.shouldDrawFuelStorages = false;

			ESP.Filters.shouldDrawWaterCatchers = false;

			ESP.Filters.shouldDrawLightSources = false;

			ESP.Filters.shouldDrawRefineries = false;

			ESP.Filters.shouldDrawQuarries = false;

			ESP.Filters.shouldDrawTurrets = false;

			ESP.Filters.shouldDrawVendingMachines = false;

			ESP.Filters.shouldDrawOthers = false;

			ESP.Colors.sleepingColor = new Color(0f, 0f, 1f);

			ESP.Colors.awakeColor = new Color(1f, 0f, 0f);

			ESP.Colors.friendlyColor = new Color(0.35f, 0.965f, 0.945f);

			ESP.Colors.storageColor = new Color(0.588f, 0f, 0.196f);

			ESP.Colors.deadColor = new Color(0f, 0.588f, 0.588f);

			ESP.Colors.animalColor = new Color(0.219f, 0.7529f, 0.1137f);

			ESP.Colors.resourceColor = new Color(1f, 1f, 0f);

			ESP.Colors.collectibleColor = new Color(0.515625f, 0.46875f, 0.91015625f);

			ESP.Colors.heliColor = new Color(0.4546f, 0.92549f, 0.6274f);

			ESP.Colors.corpseColor = new Color(0.2392f, 0.576f, 0.447f);

			ESP.Colors.cupboardColor = new Color(0.4431f, 0.23137f, 0.1568f);

			ESP.Colors.doorsColor = new Color(0.2431f, 0.32156f, 0.34117f);

			ESP.Colors.worldItemColor = new Color(0.77647f, 0.858823f, 0.83529f);

			ESP.friendlyList = new List<string>();

			ESP.friendlyList.Add("STEAMID");

			Misc.FastGathering = false;

			Misc.SpeedHack = false;

			Misc.SpeedHackValue = 1.4f;

			Misc.ClimbHack = false;

			Misc.DisableGrass = false;

			Misc.NoFallDamage = false;
		}

		internal static class Aimbot
		{
			public static bool shouldNoRecoil;

			public static bool shouldNoSway;

			public static bool shouldEnableAimbot;

			public static float maxFOV;

			public static bool AimAtHead;

			public static KeyCode AimKey;

			public static bool BulletDropPrediction;

			public static bool ForceAutomatic;

			public static bool VelocityPrediction;
		}

		internal static class ESP
		{
			public static bool shouldDrawCupboards;

			public static bool shouldDrawDoors;

			public static bool shouldDrawCorpses;

			public static bool shouldDrawHeli;

			public static bool shouldDrawWorldItems;

			public static bool autoDayTime;

			public static bool shouldDrawHealthBar;

			public static bool shouldDrawEquipedItem;

			public static bool shouldDrawSleepers;

			public static bool shouldDrawPlayers;

			public static bool shouldDrawStorage;

			public static bool shouldDrawCrosshair;

			public static bool shouldDrawResources;

			public static bool shouldDrawCollectible;

			public static bool shouldDrawAnimals;

			public static bool shouldAlwaysBeDaytime;

			public static int drawDistanceGeneral;

			public static int drawDistanceLoot;

			public static List<String> friendlyList;


			public static class Filters
			{
				public static bool shouldDrawWoodenBoxes;

				public static bool shouldDrawSupplyDrops;

				public static bool shouldDrawBarrels;

				public static bool shouldDrawTrash;

				public static bool shouldDrawFurnaces;

				public static bool shouldDrawFridges;

				public static bool shouldDrawCrates;

				public static bool shouldDrawStashes;

				public static bool shouldDrawRepairBenches;

				public static bool shouldDrawRecyclers;

				public static bool shouldDrawFoodboxes;

				public static bool shouldDrawCampfires;

				public static bool shouldDrawFuelStorages;

				public static bool shouldDrawWaterCatchers;

				public static bool shouldDrawLightSources;

				public static bool shouldDrawRefineries;

				public static bool shouldDrawQuarries;

				public static bool shouldDrawTurrets;

				public static bool shouldDrawVendingMachines;

				public static bool shouldDrawOthers;
			}

			public static class Colors
			{
				public static Color sleepingColor;

				public static Color awakeColor;

				public static Color friendlyColor;

				public static Color storageColor;

				public static Color deadColor;

				public static Color animalColor;

				public static Color resourceColor;

				public static Color collectibleColor;

				public static Color heliColor;

				public static Color corpseColor;

				public static Color cupboardColor;

				public static Color doorsColor;

				public static Color worldItemColor;
			}
		}

		public static class Misc
		{
			public static bool FastGathering;

			public static bool SpeedHack;

			public static float SpeedHackValue;

			public static bool ClimbHack;

			public static bool DisableGrass;

			public static bool NoFallDamage;
		}
	}
}
