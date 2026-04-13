using System;
using Menu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        private void OnEnable()
        {
            EventManager.Instance.OnNpcDead += EndLevel;
        }

        private void EndLevel()
        {
            SceneManager.LoadScene("MainMenu");
            MenuManager.Instance.ShowLoseMenu();
        }
    }
}