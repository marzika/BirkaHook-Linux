using System.Collections;
using UnityEngine;

namespace RustHax
{
    public class UpdateObjects : MonoBehaviour
    {
        public static StorageContainer[] storageContainerArray;
        public static ResourceEntity[] baseResourceArray;
	public static CollectibleEntity[] collectibleArray;
	public static BaseNpc[] baseNPCArray;
        public static BuildingPrivlidge[] cupboardArray;
        public static Door[] doorArray;
        public static LootableCorpse[] corpseArray;
        public static BaseHelicopter[] heliArray;
        public static WorldItem[] worldItemArray;
        public static BaseProjectile[] baseProjectileArray;
        public static AttackEntity[] attackEntityArray;
        public static PlayerWalkMovement playerWalkMovement;

        private void Start()
        {
            base.StartCoroutine(this.updateObjects());
        }

        private IEnumerator updateObjects()
        {
            while (true)
            {
                if (Config.ESP.shouldDrawStorage)
                {
                    try
                    {
                        storageContainerArray = FindObjectsOfType<StorageContainer>();
                    }
                    catch
                    {
                    }
                    yield return new WaitForSeconds(1f);
                }


                if (Config.Misc.ClimbHack)
                {
                    try
                    {
                        playerWalkMovement = FindObjectOfType<PlayerWalkMovement>();
                    }
                    catch
                    {
                    }
                    yield return new WaitForSeconds(1f);
                }

                try
                {
                    if (Config.Misc.FastGathering)
                    {
                        attackEntityArray = FindObjectsOfType<AttackEntity>();
                        Misc.FastGathering();
                    }
                    else
                    {
                        Misc.FastGathering();
                    }
                }
                catch
                {
                }
                yield return new WaitForSeconds(1f);

                if (Config.Aimbot.shouldNoRecoil || Config.Aimbot.shouldNoSway || Config.Aimbot.ForceAutomatic)
                {
                    try
                    {
                        baseProjectileArray = FindObjectsOfType<BaseProjectile>();
                        Aimbot.NoRecoil();
                    }
                    catch
                    {
                    }
                    yield return new WaitForSeconds(1f);
                }

                if (Config.ESP.shouldDrawResources)
                {
                    try
                    {
                        baseResourceArray = FindObjectsOfType<ResourceEntity>();
                    }
                    catch
                    {
                    }
                    yield return new WaitForSeconds(1f);
                }

                if (Config.ESP.shouldDrawAnimals)
                {
                    try
                    {
                        baseNPCArray = FindObjectsOfType<BaseNpc>();
                    }
                    catch
                    {
                    }
                    yield return new WaitForSeconds(1f);
                }

		if (Config.ESP.shouldDrawCollectible)
		{
			try
			{
				collectibleArray = FindObjectsOfType<CollectibleEntity>();
			}
			catch
			{
			}
			yield return new WaitForSeconds(1f);
		}

                if (Config.ESP.shouldDrawCupboards)
                {
                    try
                    {
                        cupboardArray = FindObjectsOfType<BuildingPrivlidge>();
                    }
                    catch
                    {
                    }
                    yield return new WaitForSeconds(1f);
                }

                if (Config.ESP.shouldDrawDoors)
                {
                    try
                    {
                        doorArray = FindObjectsOfType<Door>();
                    }
                    catch
                    {
                    }
                    yield return new WaitForSeconds(1f);
                }

                if (Config.ESP.shouldDrawCorpses)
                {
                    try
                    {
                        corpseArray = FindObjectsOfType<LootableCorpse>();
                    }
                    catch
                    {
                    }
                    yield return new WaitForSeconds(1f);
                }

                if (Config.ESP.shouldDrawHeli)
                {
                    try
                    {
                        heliArray = FindObjectsOfType<BaseHelicopter>();
                    }
                    catch
                    {
                    }
                    yield return new WaitForSeconds(1f);
                }

                if (Config.ESP.shouldDrawWorldItems)
                {
                    try
                    {
                        worldItemArray = FindObjectsOfType<WorldItem>();
                    }
                    catch
                    {
                    }
                    yield return new WaitForSeconds(1f);
                }
            }
            yield break;
        }
    }
}
