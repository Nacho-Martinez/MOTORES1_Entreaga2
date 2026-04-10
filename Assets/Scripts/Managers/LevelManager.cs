using System;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        private MyInputActions controls;

        private void Awake()
        {
            controls = new MyInputActions();
            controls.Ui.Disable();
        }
    }
}