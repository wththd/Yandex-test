using System;
using UnityEngine;

namespace FlappyClone.Scripts.UIScreens
{
    public class PauseScreen : MonoBehaviour
    {
        public event Action BackPressed;
        public event Action ContinuePressed;

        public void OnBackPress()
        {
            BackPressed?.Invoke();
        }

        public void OnContinuePress()
        {
            ContinuePressed?.Invoke();
        }
    }
}