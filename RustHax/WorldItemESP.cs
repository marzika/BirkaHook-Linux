using UnityEngine;

namespace RustHax
{
    public class WorldItemESP : MonoBehaviour
    {
        public static void DrawWorldItems()
        {
            try
            {
                if (Config.ESP.shouldDrawWorldItems)
                {
                    if (UpdateObjects.worldItemArray != null)
                    {
                        foreach (WorldItem worldItem in UpdateObjects.worldItemArray)
                        {
                            if (worldItem != null)
                            {
                                Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(worldItem.transform.position);
                                if (vector.z > 0f)
                                {
                                    int distance = (int) Vector3.Distance(LocalPlayer.Entity.transform.position,
                                        worldItem.transform.position);
                                    if (distance <= Config.ESP.drawDistanceGeneral)
                                    {
                                        vector.x += 3f;
                                        vector.y = Screen.height - (vector.y + 1f);
                                        Rendering.DrawString(new Vector2(vector.x, vector.y),
                                            string.Format("{0} [{1}m]", worldItem.name, distance),
                                            Config.ESP.Colors.worldItemColor, true, 12, true);
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
                DrawWorldItems();
            }
            catch
            {
            }
        }
    }
}