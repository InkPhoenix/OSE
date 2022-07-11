using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class scr_fade_levelLoader : MonoBehaviour
{
    public CanvasGroup fade;
    public Sequence sequence_fade;
    public Guid uid_fade;
    public string scene_name;
    public static bool make_fade_black_on_startup;

    public void sometimesIHateCoroutines()
    {
        killSequence();
        SceneManager.LoadScene(scene_name);
    }

    public void killSequence()
    {
        DOTween.Kill(uid_fade);
        sequence_fade = null;
    }

    public IEnumerator sceneSwitchFadeIn(float fade_time, bool loads_level, Ease ease_type) //Fades-in and switching scenes
    {
        if (sequence_fade == null) //create if there's none before
        {
            sequence_fade = DOTween.Sequence();
            if (loads_level == true) { sequence_fade.Append(fade.DOFade(1, fade_time).SetEase(ease_type).OnComplete(sometimesIHateCoroutines)); }
            else { sequence_fade.Append(fade.DOFade(1, fade_time).OnComplete(killSequence)); }
            uid_fade = System.Guid.NewGuid();
            sequence_fade.id = uid_fade;
        }
        sequence_fade.Play();
        yield return null;
    }

    public IEnumerator sceneSwitchFadeOut(float fade_time, bool loads_level, Ease ease_type) //Fades-out and switching scenes
    {
        if (sequence_fade == null) //create if there's none before
        {
            sequence_fade = DOTween.Sequence();
            if (loads_level == true) { sequence_fade.Append(fade.DOFade(0, fade_time).SetEase(ease_type).OnComplete(sometimesIHateCoroutines)); }
            else { sequence_fade.Append(fade.DOFade(0, fade_time).OnComplete(killSequence)); }
            uid_fade = System.Guid.NewGuid();
            sequence_fade.id = uid_fade;
        }
        sequence_fade.Play();
        yield return null;
    }
}
