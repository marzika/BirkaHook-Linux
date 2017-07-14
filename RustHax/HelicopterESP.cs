using UnityEngine;

namespace RustHax
{
    public class HelicopterESP : MonoBehaviour
    {
        public static void DrawHelis()
        {
            try
            {
                if (Config.ESP.shouldDrawHeli)
                {
                    if (UpdateObjects.heliArray != null)
                    {
                        foreach (BaseHelicopter heli in UpdateObjects.heliArray)
                        {
                            if (heli != null)
                            {
                                Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(heli.transform.position);
                                if (vector.z > 0f)
                                {
                                    int distance = (int) Vector3.Distance(LocalPlayer.Entity.transform.position,
                                        heli.transform.position);
                                    if (distance <= Config.ESP.drawDistanceGeneral)
                                    {
                                        vector.x += 3f;
                                        vector.y = Screen.height - (vector.y + 1f);
                                        Rendering.DrawString(new Vector2(vector.x, vector.y),
                                            string.Format("Heli [{0}m] {1}HP", distance, heli.health),
                                            Config.ESP.Colors.heliColor, true, 12, true);
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
                DrawHelis();
            }
            catch
            {
            }
        }
    }
}