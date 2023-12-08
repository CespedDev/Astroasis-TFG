using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioSystem
{
    public class TimedHitController : MonoBehaviour
    {
        public event Action OnActionEvent;

        void Start()
        {
            Conductor.instance.OnTimeEvent += OnTime;
            OnActionEvent += Conductor.instance.OnAction;
        }

        public void Action()
        {
            OnActionEvent.Invoke();
        }

        private void OnTime(TimedHit timedHit)
        {
            switch (timedHit)
            {
                case TimedHit.Perfect:
                    Debug.Log($"PERFECT {Conductor.instance.loopPositionInBeatsNormalize}");
                    break;

                case TimedHit.Good:
                    Debug.Log($"GOOD {Conductor.instance.loopPositionInBeatsNormalize}");
                    break;

                case TimedHit.Bad:
                    Debug.Log($"BAD {Conductor.instance.loopPositionInBeatsNormalize}");
                    break;
            }
        }
    }
}

