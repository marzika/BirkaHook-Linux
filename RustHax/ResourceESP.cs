using System;
using UnityEngine;

namespace RustHax
{
    public class ResourceESP : BaseMonoBehaviour
    {
        public static void DrawResources()
        {
            try
            {
                if (Config.ESP.shouldDrawResources)
                {
                    if (UpdateObjects.baseResourceArray != null)
                    {
                        foreach (ResourceEntity resource in UpdateObjects.baseResourceArray)
                        {
                            if (resource != null)
                            {
                                Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(resource.transform.position);
                                if (vector.z > 0f)
                                {
                                    int distance = (int) Vector3.Distance(LocalPlayer.Entity.transform.position,
                                        resource.transform.position);
                                    if (distance <= Config.ESP.drawDistanceLoot)
                                    {
                                        vector.x += 3f;
                                        vector.y = Screen.height - (vector.y + 1f);
                                        Rendering.DrawString(new Vector2(vector.x, vector.y),
                                            string.Format("{0} [{1}m]",
                                                resource.ShortPrefabName.Replace(".prefab", "")
                                                    .Replace("_deployed", ""), distance),
                                            Config.ESP.Colors.resourceColor, true, 12, true);
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
                DrawResources();
            }
            catch
            {
            }
        }
    }
}
