using UnityEngine;

namespace RustHax
{
    public class CorpseESP : MonoBehaviour
    {
        public static void DrawCorpses()
        {
            try
            {
                if (Config.ESP.shouldDrawCorpses)
                {
                    if (UpdateObjects.corpseArray != null)
                    {
                        foreach (LootableCorpse corpse in UpdateObjects.corpseArray)
                        {
                            if (corpse != null)
                            {
                                Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(corpse.transform.position);
                                if (vector.z > 0f)
                                {
                                    int distance = (int) Vector3.Distance(LocalPlayer.Entity.transform.position,
                                        corpse.transform.position);
                                    if (distance <= Config.ESP.drawDistanceLoot)
                                    {
                                        vector.x += 3f;
                                        vector.y = Screen.height - (vector.y + 1f);
                                        Rendering.DrawString(new Vector2(vector.x, vector.y),
                                            string.Format("Corpse:{0} [{1}m]", corpse.playerName, distance),
                                            Config.ESP.Colors.corpseColor, true, 12, true);
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
                DrawCorpses();
            }
            catch
            {
            }
        }
    }
}