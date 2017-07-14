using UnityEngine;

namespace RustHax
{
    public class DoorESP : MonoBehaviour
    {
        public static void DrawDoors()
        {
            try
            {
                if (Config.ESP.shouldDrawDoors)
                {
                    if (UpdateObjects.doorArray != null)
                    {
                        foreach (Door door in UpdateObjects.doorArray)
                        {
                            if (door != null)
                            {
                                Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(door.transform.position);
                                if (vector.z > 0f)
                                {
                                    int distance = (int) Vector3.Distance(LocalPlayer.Entity.transform.position,
                                        door.transform.position);
                                    if (distance <= Config.ESP.drawDistanceLoot)
                                    {
                                        vector.x += 3f;
                                        vector.y = Screen.height - (vector.y + 1f);
                                        Rendering.DrawString(new Vector2(vector.x, vector.y),
                                            string.Format("{0} [{1}m]",
                                                door.ShortPrefabName.Replace(".prefab", "").Replace("_deployed", ""),
                                                distance), Config.ESP.Colors.doorsColor, true, 12, true);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void OnGUI()
        {
            try
            {
                DrawDoors();
            }
            catch
            {
            }
        }
    }
}