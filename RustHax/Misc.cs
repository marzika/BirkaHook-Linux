using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace RustHax
{
    public class Misc : MonoBehaviour
    {
        public static Dictionary<string, float> originalRepeatDelay = new Dictionary<string, float>();
        public static float originalTimeScale = float.NaN;
        public static FieldInfo groundAngle = null;
        public static FieldInfo groundAngleNew = null;

        public static List<Color> colors = new List<Color>(new Color[]
        {
            Config.ESP.Colors.sleepingColor, Config.ESP.Colors.awakeColor, Config.ESP.Colors.friendlyColor,
            Config.ESP.Colors.storageColor,
            Config.ESP.Colors.deadColor, Config.ESP.Colors.animalColor, Config.ESP.Colors.resourceColor,
            Config.ESP.Colors.heliColor, Config.ESP.Colors.corpseColor,
            Config.ESP.Colors.cupboardColor, Config.ESP.Colors.doorsColor, Config.ESP.Colors.worldItemColor
        });

		public static void LogToConsole(String message)
		{
			typeof(ConsoleUI).InvokeMember("Log",
									BindingFlags.Instance | BindingFlags.InvokeMethod |
			                               BindingFlags.NonPublic, null, ConsoleUI.Instance,
									new object[] {message});
		}

        public static void DrawCrosshair()
        {
            if (Config.ESP.shouldDrawCrosshair)
            {
                Rendering.BoxRect(new Rect(((float) Screen.width) / 2f, (((float) Screen.height) / 2f) - 5f, 1f, 11f),
                    Color.blue);
                Rendering.BoxRect(new Rect((((float) Screen.width) / 2f) - 5f, ((float) Screen.height) / 2f, 11f, 1f),
                    Color.blue);
            }
        }

        public static void FastGathering()
        {
            foreach (AttackEntity attackEntity in UpdateObjects.attackEntityArray)
            {
                if (attackEntity != null)
                {
                    if (!originalRepeatDelay.ContainsKey(attackEntity.ShortPrefabName))
                        originalRepeatDelay.Add(attackEntity.ShortPrefabName, attackEntity.repeatDelay);
                    if (Config.Misc.FastGathering)
						attackEntity.repeatDelay = originalRepeatDelay[attackEntity.ShortPrefabName] / 2.5f;
                    else
                        attackEntity.repeatDelay = originalRepeatDelay[attackEntity.ShortPrefabName];
                }
            }
        }

		public static void NoFallDamage()
		{
			if (LocalPlayer.Entity != null && (LocalPlayer.Entity.fallDamageEffect != null))
			{
				LocalPlayer.Entity.fallDamageEffect = null;
			}
		}

        private void OnGUI()
        {
            Rendering.DrawWatermark("BirkaHack", Color.red, 12);


            DrawCrosshair();
            try
            {
                float time = TOD_Sky.Instance.Cycle.Hour;
                if ((time <= 10 || time >= 19) && Config.ESP.autoDayTime)
                {
                    TOD_Sky.Instance.Cycle.Hour = 14f;
                }
                if (Config.ESP.shouldAlwaysBeDaytime)
                    TOD_Sky.Instance.Cycle.Hour = 14f;
            }
            catch (NullReferenceException)
            {
            }
        }

        private void DebugCamera()
        {
            if (LocalPlayer.Entity != null)
            {
                if (SingletonComponent<CameraMan>.Instance == null)
                {
                    GameManager.client.CreatePrefab("assets/bundled/prefabs/system/debug/debug_camera.prefab",
                        new Vector3(), new Quaternion(), true);
                }
                else
                {
                    SingletonComponent<CameraMan>.Instance.enabled = !SingletonComponent<CameraMan>.Instance.enabled;
                }
                LocalPlayer.Entity.OnViewModeChanged();
            }
        }

        private void AddPainting()
        {
            string homePath = Environment.GetEnvironmentVariable("HOME") + "/rust/";
            string picture = homePath + "logo.jpg";

            var paintables = FindObjectsOfType<MeshPaintable>();

            if (File.Exists(picture))
            {
                var bytes = File.ReadAllBytes(picture);
                var tex = new Texture2D(1, 1, TextureFormat.ARGB32, true);

                if (tex.LoadImage(bytes))
                {
                    foreach (var paint in paintables)
                    {
                        paint.DrawTexture(Vector2.one * 0.5f, paint.textureWidth, paint.textureHeight, tex,
                            Color.white);
                        paint.Apply();
                    }
                }
            }
        }


        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.G))
                AddPainting();
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.P))
                DebugCamera();
            if (float.IsNaN(originalTimeScale))
                originalTimeScale = Time.timeScale;
			if (Config.Misc.NoFallDamage)
				NoFallDamage();
            if (Config.Misc.SpeedHack && Input.GetKey(KeyCode.LeftShift))
                Time.timeScale = Config.Misc.SpeedHackValue;
            else
                Time.timeScale = originalTimeScale;
            if (Config.Misc.ClimbHack)
            {
                try
                {
                    if (groundAngle == null)
                        groundAngle = typeof(PlayerWalkMovement).GetField("groundAngle",
                            BindingFlags.Instance | BindingFlags.NonPublic);
                    if (groundAngleNew == null)
                        groundAngleNew = typeof(PlayerWalkMovement).GetField("groundAngleNew",
                            BindingFlags.Instance | BindingFlags.NonPublic);
                    if (UpdateObjects.playerWalkMovement != null)
                    {
                        groundAngle.SetValue(UpdateObjects.playerWalkMovement, 0f);
                        groundAngleNew.SetValue(UpdateObjects.playerWalkMovement, 0f);
                    }
                }
                catch (NullReferenceException)
                {
                }
            }
            if (Config.Misc.DisableGrass)
            {
                GrassSpawn.SetEnabled(false);
            }
        }
    }
}