using UnityEngine;

namespace Menu
{
    public class MenuManager : MonoBehaviour
    {
        public static MenuManager Instance { get; private set; }
    
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject winMenu;
        [SerializeField] private GameObject loseMenu;

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

        public void ShowWinMenu()
        {
            mainMenu.SetActive(false);
            winMenu.SetActive(true);
            loseMenu.SetActive(false);
        }
        public void ShowLoseMenu()
        {
            mainMenu.SetActive(false);
            winMenu.SetActive(false);
            loseMenu.SetActive(true);
        }

        public void ClearScene()
        {
            mainMenu.SetActive(false);
            winMenu.SetActive(false);
            loseMenu.SetActive(false);
        }
    }
}