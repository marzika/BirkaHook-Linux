using UnityEngine;

namespace RustHax
{
    public class PlayerESP : MonoBehaviour
    {
        public static void DrawPlayers()
        {
            if (Config.ESP.shouldDrawPlayers || Config.ESP.shouldDrawSleepers)
            {
                foreach (BasePlayer player in BasePlayer.VisiblePlayerList)
                {
					if ((player != null) && !player.IsLocalPlayer() && !player.IsAdmin)
					//	if ((player != null) && !player.IsAdmin)
                    {
                        Vector3 position = player.transform.position;
                        Vector3 vector3 = MainCamera.mainCamera.WorldToScreenPoint(position);
                        if (vector3.z > 0f)
                        {
                            int distance = (int) Vector3.Distance(LocalPlayer.Entity.transform.position, position);
                            if (distance <= Config.ESP.drawDistanceGeneral)
                            {
                                Color color;
								if (!player.IsSleeping() && player.IsAlive() && !player.HasPlayerFlag(BasePlayer.PlayerFlags.IsAdmin))
                                {
                                    Vector3 vector2 =
                                        MainCamera.mainCamera.WorldToScreenPoint(position + new Vector3(0f, 1.7f, 0f));
                                    float y = Mathf.Abs((float) (vector3.y - vector2.y));
                                    float x = y / 2f;
                                    color = Color.red;
                                    if (Config.ESP.friendlyList.Contains(player.UserIDString))
                                        color = Config.ESP.Colors.friendlyColor;
                                    if (Config.ESP.shouldDrawHealthBar)
                                    {
                                        Rendering.DrawHealth(new Vector2(vector2.x, Screen.height - vector2.y),
                                            player.health, true);
                                    }
                                    Rendering.DrawBox(new Vector2(vector2.x - (x / 2f), Screen.height - vector2.y),
									                  new Vector2(x, y), 1f, color, player.IsDucked());
                                    if (Config.ESP.shouldDrawEquipedItem)
                                    {
                                        Item activeItem = player.Belt.GetActiveItem();
                                        HeldEntity heldEntity = player.GetHeldEntity();

                                        if (activeItem != null)
                                        {
                                            if (heldEntity != null && heldEntity.GetItem() != null && heldEntity
                                                    .GetItem()
                                                    .info.shortname.Equals(activeItem.info.shortname))
                                            {
                                                Rendering.DrawString(new Vector2(vector3.x, Screen.height - vector3.y),
                                                    string.Format("{0}\n[{1}m]\n{2}HP\n[{3}]", player.displayName,
												                  distance, (int) player.health, activeItem.info.displayName.english),
                                                    color, true, 12, true, 4);
                                            }
                                            else
                                                Rendering.DrawString(new Vector2(vector3.x, Screen.height - vector3.y),
                                                    string.Format("{0}\n[{1}m]\n{2}HP\n{3}", player.displayName,
                                                        distance,
                                                        (int) player.health, activeItem.info.displayName.english), color, true,
                                                    12,
                                                    true, 4);
                                        }
                                        else
                                        {
                                            Rendering.DrawString(new Vector2(vector3.x, Screen.height - vector3.y),
                                                string.Format("{0}\n[{1}m]\n{2}HP", player.displayName, distance,
                                                    (int) player.health), color, true, 12, true, 3);
                                        }
                                    }
                                    else
                                    {
                                        Rendering.DrawString(new Vector2(vector3.x, Screen.height - vector3.y),
                                            string.Format("{0}\n[{1}m]\n{2}HP", player.displayName, distance,
                                                (int) player.health), color, true, 12, true, 3);
                                    }
                                }
                                else if (Config.ESP.shouldDrawSleepers && player.health > 0f)
                                {
                                    color = Config.ESP.Colors.sleepingColor;
                                    Rendering.DrawString(new Vector2(vector3.x, Screen.height - vector3.y),
                                        string.Format("{0}\n[{1}m]\n{2}HP", player.displayName, distance,
                                            (int) player.health), color, true, 12, true, 3);
                                }
                                else if (player.IsDead())
                                {
                                    color = Config.ESP.Colors.deadColor;
                                    Rendering.DrawString(new Vector2(vector3.x, Screen.height - vector3.y),
                                        string.Format("{0}\n[{1}m]\nDEAD", player.displayName, distance), color, true,
                                        12, true, 3);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void OnGUI()
        {
            try
            {
                DrawPlayers();
            }
            catch
            {
            }
        }
    }
}