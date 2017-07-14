using UnityEngine;

namespace RustHax
{
    public class CupboardESP : MonoBehaviour
    {
        public static void DrawCupboards()
        {
            try
            {
                if (Config.ESP.shouldDrawCupboards)
                {
                    if (UpdateObjects.cupboardArray != null)
                    {
                        foreach (BuildingPrivlidge cupboard in UpdateObjects.cupboardArray)
                        {
                            if (cupboard != null)
                            {
                                Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(cupboard.transform.position);
                                if (vector.z > 0f)
                                {
                                    int distance = (int) Vector3.Distance(LocalPlayer.Entity.transform.position,
                                        cupboard.transform.position);
                                    if (distance <= Config.ESP.drawDistanceLoot)
                                    {
                                        vector.x += 3f;
                                        vector.y = Screen.height - (vector.y + 1f);
                                        Rendering.DrawString(new Vector2(vector.x, vector.y),
                                            string.Format("{0} [{1}m]",
                                                cupboard.ShortPrefabName.Replace(".prefab", "")
                                                    .Replace(".deployed", ""), distance),
                                            Config.ESP.Colors.cupboardColor, true, 12, true);
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
                DrawCupboards();
            }
            catch
            {
            }
        }
    }
}