using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scr_main_title : MonoBehaviour
{
    public CanvasGroup UI_element;
    private float fade_time = 0.5f;
    private Guid uid;
    private Sequence sequence;
    private bool sequence_stopped = false;

    private IEnumerator fadeFromBlack()
    {
        scr_fade_levelLoader.make_fade_black_on_startup = false;
        scr_fade_levelLoader loader_script = GameObject.Find("Crossfade(titlescreen)").GetComponent<scr_fade_levelLoader>();
        CanvasGroup loader_script_alpha = GameObject.Find("Crossfade(titlescreen)").GetComponent<CanvasGroup>();
        loader_script_alpha.alpha = 1;
        yield return new WaitForSeconds(0.1f); //give it slight delay just to look better
        StartCoroutine(loader_script.sceneSwitchFadeOut(1.25f, false));
    }

    private void Start()
    {
        //startFade();
        if (scr_fade_levelLoader.make_fade_black_on_startup == true) { StartCoroutine(fadeFromBlack()); }
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
