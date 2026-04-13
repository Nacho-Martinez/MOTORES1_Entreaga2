using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void OnPlayButtonClicked()
        {
            SceneManager.LoadScene(GameData.Instance.GetCurrentLevel());
            MenuManager.Instance.ClearScene();
        }

        public void OnQuitButtonClicked()
        {
            Application.Quit();
        }
    }
}