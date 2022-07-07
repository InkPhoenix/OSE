using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scr_main_title : MonoBehaviour
{
    public CanvasGroup UI_element;
    private float fade_time = 2.0f;
    private Guid uid;
    private Sequence sequence;
    private bool sequence_stopped;

    private IEnumerator fadeFromBlack()
    {
        scr_fade_levelLoader.make_fade_black_on_startup = false;
        scr_fade_levelLoader loader_script = GameObject.Find("Crossfade(titlescreen)").GetComponent<scr_fade_levelLoader>();
        CanvasGroup loader_script_alpha = GameObject.Find("Crossfade(titlescreen)").GetComponent<CanvasGroup>();
        loader_script_alpha.alpha = 1;
        yield return new WaitForSeconds(0.1f); //give it slight delay just to look better
        StartCoroutine(loader_script.sceneSwitchFadeOut(1.25f, false));
    }

    private IEnumerator startupFade()
    {
        yield return new WaitForSeconds(1.5f); //wait before fading-in the title
        startFade();
    }

    private void Start()
    {
        sequence_stopped = false;
        UI_element.alpha = 0;
        if (scr_fade_levelLoader.make_fade_black_on_startup == true) { StartCoroutine(fadeFromBlack()); }
        StartCoroutine(startupFade());
    }

    public void startFade()
    {
        /*if (sequence == null) //create if there's none before
        {
            sequence = DOTween.Sequence();
            sequence.Append(UI_element.DOFade(1, fade_time));
            uid = System.Guid.NewGuid();
            sequence.id = uid;
        }
        sequence.Play();*/
        UI_element.DOFade(1, fade_time);
    }

    public void stopFade()
    {
        //kill the sequence with ID uid and set sequence to NULL
        /*DOTween.Kill(uid);
        sequence = null;

        //set alpha to 1
        if (UI_element.alpha != 1 && sequence_stopped == false)
        {
            UI_element.alpha = 1;
            sequence_stopped = true; //do this in case the alpha value happens to be 1 when button is pressed
        }*/

        if (sequence_stopped == false) //do this to only activate once
        {
            UI_element.alpha = 1;

            Vector3 title_original_scale = transform.localScale;
            Vector3 title_scale_to = title_original_scale * 1.8f; //scale up the title by 2.2

            sequence_stopped = true;

            UI_element.transform.DOScale(title_scale_to, 2.0f);
            UI_element.DOFade(0, 2.0f);
            Debug.Log("triggered");
        }
    }
}
