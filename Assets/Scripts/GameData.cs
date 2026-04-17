using UnityEngine;

namespace DefaultNamespace
{
    public class GameData : MonoBehaviour
    {
        [field: SerializeField] public string[] LevelsList { get; private set; }
        private int actualLevel = 0;
        public static GameData Instance { get; private set; }
        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public string GetCurrentLevel()
        {
            return LevelsList[actualLevel];
        }

        public void Advancelevel()
        {
            if (actualLevel <= 2)
            {
              actualLevel++;
            }
            
        }
    }
}