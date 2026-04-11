using System;
using UnityEngine;

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
            Debug.Log("Se ha perdido este nivel");
        }
    }
}