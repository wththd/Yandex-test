using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace FlappyClone.Scripts.UIScreens
{
    public class PreparingScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;

        public void StartTimer(int timer, Action onDone)
        {
            StartCoroutine(UpdateTimerTextRoutine(timer, onDone));
        }

        private IEnumerator UpdateTimerTextRoutine(int timer, Action onDone)
        {
            timerText.text = timer.ToString();
            var timeLeft = timer;
            var elapsedTime = 0.0f;
            while (timeLeft > 0)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime > 1)
                {
                    timeLeft--;
                    elapsedTime--;
                    timerText.text = timeLeft.ToString();
                }

                yield return null;
            }

            onDone?.Invoke();
        }
    }
}