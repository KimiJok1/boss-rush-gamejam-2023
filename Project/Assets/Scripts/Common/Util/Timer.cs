using UnityEngine;
using UnityEngine.Events;
using System;

namespace Common.Utilities
{
    public class Timer
    {
        public Action OnTimerDone;

        private float startTime;
        private float duration;
        private float targetTime;

        private bool isTimerDone;

        public Timer(float _duration)
        {
            duration = _duration;
        }

        public void StartTimer()
        {
            startTime = Time.time;
            targetTime = startTime + duration;
            isTimerDone = false;
        }

        public void StopTimer()
        {
            isTimerDone = true;
        }

        public void UpdateTimer()
        {
            if(isTimerDone)
                return;

            if (Time.time >= targetTime)
            {
                OnTimerDone?.Invoke();
                StopTimer();
            }
        }

    }
}

