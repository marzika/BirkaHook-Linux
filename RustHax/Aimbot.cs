using System.Collections.Generic;
using UnityEngine;

namespace RustHax
{
    public class Aimbot : MonoBehaviour
    {
        public static List<float> velocities = new List<float>();
        public static List<string> projectiles = new List<string>();

        public static void NoRecoil()
        {
            if (Config.Aimbot.shouldNoRecoil || Config.Aimbot.shouldNoSway || Config.Aimbot.ForceAutomatic)
            {
                foreach (BaseProjectile projectile in UpdateObjects.baseProjectileArray)
                {
                    if (projectile != null && projectile.recoil != null)
                    {
                        velocities.Clear();
                        projectiles.Clear();
                        projectiles.Add(projectile.ShortPrefabName);
                        ItemModProjectile component = projectile.primaryMagazine.ammoType
                            .GetComponent<ItemModProjectile>();
                        float velocity = component.GetAverageVelocity() * projectile.projectileVelocityScale;
                        velocities.Add(velocity);
                        if (Config.Aimbot.shouldNoRecoil)
                        {
                            projectile.recoil.recoilYawMax = 0f;
                            projectile.recoil.recoilYawMin = 0f;
                            projectile.recoil.recoilPitchMax = 0f;
                            projectile.recoil.recoilPitchMin = 0f;
                        }
                        if (Config.Aimbot.shouldNoSway)
                        {
                            projectile.aimSway = 0f;
                            projectile.aimSwaySpeed = 0f;
                        }
                        if (Config.Aimbot.ForceAutomatic)
                            projectile.automatic = true;
                    }
                }
            }
        }

        public static void DoAimbot()
        {
            Vector3 vector = GetEnemyVector();
            if (vector != Vector3.zero)
            {
                Vector3 vector2 = vector;
                Quaternion quaternion = Quaternion.LookRotation(vector2 - MainCamera.mainCamera.transform.position,
                    Vector3.right);
                float x = quaternion.eulerAngles.x;
                x = (MainCamera.mainCamera.transform.position.y < vector2.y) ? (-360f + x) : x;
                x = Mathf.Clamp(x, -89f, 89f);
                LocalPlayer.Entity.input.SetViewVars(new Vector3(x, quaternion.eulerAngles.y, 0f));
                Rendering.DrawBox(new Vector2((((float) Screen.width) / 2f) - 6f, (((float) Screen.height) / 2f) - 6f),
                    new Vector2(12f, 12f), 1f, Color.yellow);
            }
        }

        public static Vector3 GetEnemyVector()
        {
            Vector3 result = Vector3.zero;
            Vector2 middleScreen = new Vector2((float) (Screen.width / 2), (float) (Screen.height / 2));
            float maxDistance = 4999f;
            foreach (BasePlayer player in BasePlayer.VisiblePlayerList)
            {
                if (((player != null) && (player.health > 0f)) && (!player.IsSleeping() && !player.IsLocalPlayer()) &&
                    !Config.ESP.friendlyList.Contains(player.displayName))
                {
                    Vector3 enemyPosition;
                    if (Config.Aimbot.AimAtHead)
                        enemyPosition = GetBonePosition(player.GetModel(), "headCenter");
                    else
                        enemyPosition = GetBonePosition(player.GetModel(), "spine1");

                    if (enemyPosition != Vector3.zero)
                    {
                        bool flag = IsVisible(enemyPosition);

                        if (flag)
                        {
                            Vector3 vector4 = MainCamera.mainCamera.WorldToScreenPoint(enemyPosition);
                            Vector2 enemyOnScreen = new Vector2(vector4.x, Screen.height - vector4.y);
                            float fov = Mathf.Abs(Vector2.Distance(middleScreen, enemyOnScreen));
                            if ((fov <= Config.Aimbot.maxFOV) && (fov <= maxDistance))
                            {
                                result = enemyPosition;
                                Item activeItem = LocalPlayer.Entity.Belt.GetActiveItem();
                                if (activeItem != null && (activeItem.info.shortname.Contains("bow") ||
                                                           activeItem.info.shortname.Contains("smg.") ||
                                                           activeItem.info.shortname.Contains("pistol.") ||
                                                           activeItem.info.shortname.Contains("lmg.") ||
                                                           activeItem.info.shortname.Contains("rifle")))
                                {
                                    if (Config.Aimbot.BulletDropPrediction || Config.Aimbot.VelocityPrediction)
                                    {
                                        float bulletSpeed = 250f;
                                        switch (activeItem.info.shortname)
                                        {
                                            case "rifle.bolt":
                                                bulletSpeed = 656.25f;
                                                break;
                                            case "rifle.ak":
                                                bulletSpeed = 375f;
                                                break;
                                            case "rifle.lr300":
                                                bulletSpeed = 375f;
                                                break;
                                            case "rifle.semiauto":
                                                bulletSpeed = 375f;
                                                break;
                                            case "smg.mp5":
                                                bulletSpeed = 180f;
                                                break;
                                            case "smg.thompson":
                                                bulletSpeed = 300f;
                                                break;
                                            case "smg.2":
                                                bulletSpeed = 240f;
                                                break;
                                            case "pistol.m92":
                                                bulletSpeed = 300f;
                                                break;
                                            case "pistol.semiauto":
                                                bulletSpeed = 300f;
                                                break;
                                            case "pistol.python":
                                                bulletSpeed = 300f;
                                                break;
                                            case "bow.hunting":
                                                bulletSpeed = 50f;
                                                break;
                                            case "crossbow":
                                                bulletSpeed = 75f;
                                                break;
                                            default:
                                                break;
                                        }
                                        if (Config.Aimbot.VelocityPrediction)
                                        {
                                            float flTime =
                                                Vector3.Distance(LocalPlayer.Entity.transform.position, enemyPosition) /
                                                bulletSpeed;
                                            Vector3 velocity = (Vector3) player.playerModel.GetFieldValue("velocity");
                                            result.x += (velocity.x * flTime);
                                            result.y += (velocity.y * flTime);
                                        }
                                        if (Config.Aimbot.BulletDropPrediction)
                                            result.y =
                                                result.y +
                                                BulletDrop(LocalPlayer.Entity.transform.position, enemyPosition,
                                                    bulletSpeed);
                                    }
                                }
                                maxDistance = fov;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static bool IsVisible(Vector3 vector3_0)
        {
            Vector3 vector = MainCamera.mainCamera.transform.position - vector3_0;
            float magnitude = vector.magnitude;
            if (magnitude < Mathf.Epsilon)
            {
                return true;
            }
            Vector3 direction = (Vector3) (vector / magnitude);
            Vector3 vector3 = (Vector3) (direction * Mathf.Min(magnitude, 0.01f));
            return LocalPlayer.Entity.IsVisible(new Ray(vector3_0 + vector3, direction), magnitude);
        }

        public static Vector3 GetBonePosition(Model playerModel, string boneName)
        {
            Vector3 zero = Vector3.zero;
            if (playerModel == null)
            {
                return zero;
            }
            if (boneName == "headCenter")
            {
                return new Vector3(playerModel.headBone.position.x, playerModel.eyeBone.position.y,
                    playerModel.headBone.position.z);
            }
            return playerModel.FindBone(boneName).position;
        }

        public static float BulletDrop(Vector3 v1, Vector3 v2, float BulletSpeed)
        {
            float Dist = Vector3.Distance(v1, v2);

            if (Dist < 0.001)
                return 0;

            float m_gravity = 9.81f;
            float m_time = Dist / BulletSpeed;

            return (float) (0.5 * m_gravity * m_time * m_time);
        }

        private void OnGUI()
        {
            if (Config.Aimbot.shouldEnableAimbot && LocalPlayer.Entity != null &&
                Input.GetKey(Config.Aimbot.AimKey))
                DoAimbot();
        }
    }
}