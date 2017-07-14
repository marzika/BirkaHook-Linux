using System;
using UnityEngine;

namespace RustHax
{
	public class CollectibleESP : MonoBehaviour
	{
		public static void DrawCollectible()
		{
			try
			{
				if (Config.ESP.shouldDrawCollectible)
				{
					if (UpdateObjects.collectibleArray != null)
					{
						foreach (CollectibleEntity collectible in UpdateObjects.collectibleArray)
						{
							if (collectible != null)
							{
								Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(collectible.transform.position);
								if (vector.z > 0f)
								{
									int distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position,
										collectible.transform.position);
									if (distance <= Config.ESP.drawDistanceLoot)
									{
										vector.x += 3f;
										vector.y = Screen.height - (vector.y + 1f);
										Rendering.DrawString(new Vector2(vector.x, vector.y),
											//string.Format("{0} [{1}m]",
											//	collectible.ShortPrefabName.Replace(".prefab", "")
											//		.Replace("_deployed", ""), distance),
										    string.Format("{0} [{1}m]", collectible.itemName.english, distance),
											Config.ESP.Colors.collectibleColor, true, 12, true);

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
				DrawCollectible();
			}
			catch
			{
			}
		}
	}
}