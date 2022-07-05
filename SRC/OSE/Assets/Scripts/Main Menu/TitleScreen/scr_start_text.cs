using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scr_start_text : MonoBehaviour
{
    public CanvasGroup UI_element;
    private float fade_time = 0.5f;
    private Guid uid;
    private Sequence sequence;
    private bool sequence_stopped = false;

    private void Start()
    {
        startFade();
    }

    public void startFade()
    {
        if (sequence == null) //create if there's none before
        {
            sequence = DOTween.Sequence();
            sequence.Append(UI_element.DOFade(0, fade_time));
            uid = System.Guid.NewGuid();
            sequence.id = uid;
        }
        sequence.Play().SetLoops(-1, LoopType.Yoyo);
    }

    public void stopFade()
    {
        //kill the sequence with ID uid and set sequence to NULL
        DOTween.Kill(uid);
        sequence = null;

        //set alpha to 1
        if (UI_element.alpha != 1 && sequence_stopped == false)
        {
            UI_element.alpha = 1;
            sequence_stopped = true; //do this in case the alpha value happens to be 1 when button is pressed
        }
    }
}
