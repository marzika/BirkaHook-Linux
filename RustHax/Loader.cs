using UnityEngine;

namespace RustHax
{
    public class Loader
    {
        private static GameObject gameObject;


        public static void Load()
        {
            Config.Init();
            gameObject = new GameObject();

            gameObject.AddComponent<Main>();

            gameObject.AddComponent<Aimbot>();

            gameObject.AddComponent<AnimalESP>();
            gameObject.AddComponent<CorpseESP>();
            gameObject.AddComponent<CupboardESP>();
            gameObject.AddComponent<DoorESP>();
            gameObject.AddComponent<HelicopterESP>();
            gameObject.AddComponent<LootESP>();
            gameObject.AddComponent<Misc>();
            gameObject.AddComponent<PlayerESP>();
            gameObject.AddComponent<ResourceESP>();
			gameObject.AddComponent<CollectibleESP>();
            gameObject.AddComponent<WorldItemESP>();

            gameObject.AddComponent<UpdateObjects>();

            Object.DontDestroyOnLoad(gameObject);
        }
    }
}