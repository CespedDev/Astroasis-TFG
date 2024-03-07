using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using RhythmSystem;

public class UIDamageController : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private float    time = 1.5f;

    IEnumerator HideUI()
    {
        yield return new WaitForSeconds(time);
        text.gameObject.SetActive(false);
    }

    public void ShowUI(TimedHit hitType)
    {
        Color color;
        color = hitType == TimedHit.Perfect ? Color.green :
                hitType == TimedHit.Good ? Color.yellow :
                Color.red;
        text.color = color;

        text.text = hitType.ToString();

        text.gameObject.SetActive(true);
        StartCoroutine(HideUI());
    }
}
