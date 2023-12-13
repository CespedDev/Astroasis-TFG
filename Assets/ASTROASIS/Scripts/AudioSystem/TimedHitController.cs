using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioSystem
{
    public class TimedHitController : MonoBehaviour
    {
        public event Action<GameObject> OnActionEvent;

        void Start()
        {
            Conductor.instance.OnTimeEvent += OnTime;
            OnActionEvent += Conductor.instance.OnAction;
        }

        public void Action(RaycastHit hit)
        {
            if (hit.transform.tag == "Enemy")
            {
                OnActionEvent.Invoke(hit.transform.gameObject);
            }
        }

        public void Action(Transform hit)
        {
            if (hit.tag == "Enemy")
            {
                OnActionEvent.Invoke(hit.transform.gameObject);
            }
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

