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

    public void ShowUI(RhythmBonusSO bonus)
    {
        Color color;
        //text.color = color;

        text.text = bonus.name;

        text.gameObject.SetActive(true);
        StartCoroutine(HideUI());
    }
}
