using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class scr_fade_levelLoader : MonoBehaviour
{
    public CanvasGroup fade;
    public string scene_name;
    public static bool make_fade_black_on_startup;

    public void sometimesIHateCoroutines() { SceneManager.LoadScene(scene_name); }

    public IEnumerator sceneSwitchFadeIn(float fade_time, bool loads_level, Ease ease_type) //Fades-in and switching scenes
    {
        if (loads_level == true) { fade.DOFade(1, fade_time).SetEase(ease_type).OnStepComplete(sometimesIHateCoroutines); }
        else { fade.DOFade(1, fade_time); }
        yield return null;
    }

    public IEnumerator sceneSwitchFadeOut(float fade_time, bool loads_level, Ease ease_type) //Fades-out and switching scenes
    {
        if (loads_level == true) { fade.DOFade(0, fade_time).SetEase(ease_type).OnStepComplete(sometimesIHateCoroutines); }
        else { fade.DOFade(0, fade_time); }
        yield return null;
    }
}
