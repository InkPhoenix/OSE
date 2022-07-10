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
    public AudioSource musicSource;

    private IEnumerator fadeFromBlack()
    {
        scr_fade_levelLoader.make_fade_black_on_startup = false;
        scr_fade_levelLoader loader_script = GameObject.Find("Crossfade").GetComponent<scr_fade_levelLoader>();
        CanvasGroup loader_script_alpha = GameObject.Find("Crossfade").GetComponent<CanvasGroup>();
        loader_script_alpha.alpha = 1;
        yield return new WaitForSeconds(0.1f); //give it slight delay just to look better
        StartCoroutine(loader_script.sceneSwitchFadeOut(1.25f, false, Ease.Linear));
    }

    private IEnumerator startupFade()
    {
        yield return new WaitForSeconds(1.0f); //wait before playing the BGM
        musicSource.Play();
        yield return new WaitForSeconds(0.5f); //wait before fading-in the title
        startFade();
    }

    private void Start()
    {
        sequence_stopped = false;
        UI_element.alpha = 0;
        if (scr_fade_levelLoader.make_fade_black_on_startup == true) { StartCoroutine(fadeFromBlack()); }
        StartCoroutine(startupFade());
    }

    public void startFade() { UI_element.DOFade(1, fade_time); }

    public void stopFade()
    {
        if (sequence_stopped == false) //do this to only activate once
        {
            sequence_stopped = true;
            UI_element.alpha = 1;

            scn_switch(); //start scene switching fade

            //animate title fade-out
            Vector3 title_original_scale = transform.localScale;
            Vector3 title_scale_to = title_original_scale * 1.8f; //scale up the title by 1.8
            
            UI_element.transform.DOScale(title_scale_to, 2.0f);
            UI_element.DOFade(0, 2.0f);

            DOTween.To(() => musicSource.volume, x => musicSource.volume = x, 0, 2.0f).SetEase(Ease.InSine); //fade-out BGM volume
        }
    }

    private void scn_switch() { StartCoroutine(switch_scenes()); }

    private IEnumerator switch_scenes()
    {
        yield return new WaitForSeconds(0.15f);
        scr_fade_levelLoader loader_script = GameObject.Find("Crossfade").GetComponent<scr_fade_levelLoader>();
        loader_script.scene_name = "scn_MainMenu";
        scr_fade_levelLoader.make_fade_black_on_startup = true; //make the fade be of alpha 1 on startup of next scene
        yield return loader_script.sceneSwitchFadeIn(2.0f, true, Ease.InCubic);
    }
}
