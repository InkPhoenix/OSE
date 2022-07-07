using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scr_start_text : MonoBehaviour
{
    public CanvasGroup UI_element;
    public CanvasGroup back_fade;
    public CanvasGroup front_fade;
    private float fade_time = 0.8f;
    private Guid uid;
    private Sequence sequence;
    private bool sequence_stopped;

    private void Start()
    {
        sequence_stopped = false;
        UI_element.alpha = 0;
        StartCoroutine(startupTextFade());
    }

    private IEnumerator startupTextFade()
    {
        yield return new WaitForSeconds(3.5f); //wait before fading-in the text
        startTextFade();
    }

    public void startTextFade()
    {
        if (sequence == null) //create if there's none before
        {
            sequence = DOTween.Sequence();
            sequence.Append(UI_element.DOFade(1, fade_time).SetEase(Ease.InQuad));
            uid = System.Guid.NewGuid();
            sequence.id = uid;
        }
        sequence.Play().SetLoops(-1, LoopType.Yoyo);
    }

    public void stopFade()
    {
        //only execute this once
        if (sequence_stopped == false)
        {
            //kill the sequence with ID uid and set sequence to NULL
            DOTween.Kill(uid);
            sequence = null;

            //set alphas to 1
            sequence_stopped = true;
            UI_element.alpha = 1;
            back_fade.alpha = 1;
            front_fade.alpha = 1;

            //start animations
            Vector3 text_original_scale = transform.localScale;
            Vector3 text_scale_to = text_original_scale * 1.8f; //scale up the text by 1.8

            UI_element.transform.DOScale(text_scale_to, 2.0f);
            back_fade.transform.DOScale(text_scale_to, 2.0f);
            front_fade.transform.DOScale(text_scale_to, 2.0f);
            UI_element.DOFade(0, 2.0f);
            back_fade.DOFade(0, 1.0f);
            front_fade.DOFade(0, 1.0f);
        }
    }
}
