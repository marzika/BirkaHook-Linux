using System;
using UnityEngine;

namespace RustHax
{
    public class AnimalESP : MonoBehaviour
    {
        public static void DrawAnimals()
        {
            try
            {
                if (Config.ESP.shouldDrawAnimals)
                {
                    if (UpdateObjects.baseNPCArray != null)
                    {
                        foreach (BaseNpc npc in UpdateObjects.baseNPCArray)
                        {
                            if (npc != null)
                            {
                                Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(npc.transform.position);
                                if (vector.z > 0f)
                                {
                                    int distance = (int) Vector3.Distance(LocalPlayer.Entity.transform.position,
                                        npc.transform.position);
                                    if (distance <= Config.ESP.drawDistanceGeneral)
                                    {
                                        vector.x += 3f;
                                        vector.y = Screen.height - (vector.y + 1f);
                                        Rendering.DrawString(new Vector2(vector.x, vector.y),
                                            string.Format("{0} [{1}m]",
                                                npc.ShortPrefabName.Replace(".prefab", "").Replace("_deployed", ""),
                                                distance), Config.ESP.Colors.animalColor, true, 12, true);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
            }
        }

        private void OnGUI()
        {
            try
            {
                DrawAnimals();
            }
            catch
            {
            }
        }
    }
}