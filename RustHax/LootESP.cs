using System;
using UnityEngine;

namespace RustHax
{
    public class LootESP : MonoBehaviour
    {
        public static void DrawStorages()
        {
            try
            {
                if (Config.ESP.shouldDrawStorage)
                {
                    if (UpdateObjects.storageContainerArray != null)
                    {
                        foreach (StorageContainer container in UpdateObjects.storageContainerArray)
                        {
                            if (container != null)
                            {
                                Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(container.transform.position);
                                if (vector.z > 0f)
                                {
                                    int distance = (int) Vector3.Distance(LocalPlayer.Entity.transform.position,
                                        container.transform.position);
                                    if (distance <= Config.ESP.drawDistanceLoot)
                                    {
                                        vector.x += 3f;
                                        vector.y = Screen.height - (vector.y + 1f);
                                        if (container.ShortPrefabName.Contains("wood") &&
                                            Config.ESP.Filters.shouldDrawWoodenBoxes)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("supply_drop") &&
                                                 Config.ESP.Filters.shouldDrawSupplyDrops)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("barrel") &&
                                                 Config.ESP.Filters.shouldDrawBarrels)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("trash") &&
                                                 Config.ESP.Filters.shouldDrawTrash)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("furnace") &&
                                                 Config.ESP.Filters.shouldDrawFurnaces)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("fridge") &&
                                                 Config.ESP.Filters.shouldDrawFridges)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("crate") &&
                                                 Config.ESP.Filters.shouldDrawCrates)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("stash") &&
                                                 Config.ESP.Filters.shouldDrawStashes)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("repair") &&
                                                 Config.ESP.Filters.shouldDrawRepairBenches)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("recycler") &&
                                                 Config.ESP.Filters.shouldDrawRecyclers)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("food") &&
                                                 Config.ESP.Filters.shouldDrawFoodboxes)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("campfire") &&
                                                 Config.ESP.Filters.shouldDrawCampfires)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("fuelstorage") &&
                                                 Config.ESP.Filters.shouldDrawFuelStorages)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("catcher") &&
                                                 Config.ESP.Filters.shouldDrawWaterCatchers)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("lantern") &&
                                                 Config.ESP.Filters.shouldDrawLightSources)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("light") &&
                                                 Config.ESP.Filters.shouldDrawLightSources)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("refinery") &&
                                                 Config.ESP.Filters.shouldDrawRefineries)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("hopperoutput") &&
                                                 Config.ESP.Filters.shouldDrawQuarries)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("turret") &&
                                                 Config.ESP.Filters.shouldDrawTurrets)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (container.ShortPrefabName.Contains("vendingmachines") &&
                                                 Config.ESP.Filters.shouldDrawVendingMachines)
                                        {
                                            Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                string.Format("{0} [{1}m]",
                                                    container.ShortPrefabName.Replace(".prefab", "")
                                                        .Replace("_deployed", ""), distance),
                                                Config.ESP.Colors.storageColor, true, 12, true);
                                            continue;
                                        }
                                        else if (Config.ESP.Filters.shouldDrawOthers)
                                        {
                                            int counter = 0;
                                            string[] stringArray =
                                            {
                                                "turret", "hopperoutput", "refinery", "light", "lantern", "catcher",
                                                "fuelstorage", "campfire", "food", "recycler", "repair", "stash",
                                                "crate", "fridge", "furnace", "trash", "barrel", "supply_drop", "wood",
                                                "vendingmachines"
                                            };
                                            foreach (string x in stringArray)
                                            {
                                                if (!container.ShortPrefabName.Contains(x))
                                                    counter++;
                                            }
                                            if (counter == stringArray.Length)
                                            {
                                                Rendering.DrawString(new Vector2(vector.x, vector.y),
                                                    string.Format("{0} [{1}m]",
                                                        container.ShortPrefabName.Replace(".prefab", "")
                                                            .Replace("_deployed", ""), distance),
                                                    Config.ESP.Colors.storageColor, true, 12, true);
                                                continue;
                                            }
                                        }
                                        //woodbox, supply_drop, oil_barrel, box.wooden.large, loot_barrel_1, loot_barrel_2, trash-pile-1, furnace, furnace.large, fridge.deployed, crate_normal_2, crate_normal_2_food, small_stash, create_tools, repairbench_static, recycler_static, foodbox, refinery_small, refinery_large, campfire, fuelstorage, water_catcher_small, water_catcher_large, refinery, hopperoutput, jackolantern.happy, jackolantern.angry, ceilinglight.deployed, tunalight.deployed, vendingmachines, autoturret, flameturret, wall.frame.shopfront.metal, survivalfishtrap.deployed
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
                DrawStorages();
            }
            catch
            {
            }
        }
    }
}