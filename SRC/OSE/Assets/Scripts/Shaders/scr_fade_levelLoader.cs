using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class scr_fade_levelLoader : MonoBehaviour
{
    public CanvasGroup fade;
    public string scene_name;
    public float fade_time;

    private void sometimesIHateCoroutines() { SceneManager.LoadScene(scene_name); }

    public IEnumerator sceneSwitchFadeIn() //Fades-out before switching scenes
    {
        fade.DOFade(1, fade_time).OnStepComplete(sometimesIHateCoroutines);
        yield return null;
    }

    public IEnumerator sceneSwitchFadeOut() //Fades-out before switching scenes
    {
        fade.DOFade(0, fade_time).OnStepComplete(sometimesIHateCoroutines);
        yield return null;
    }

    /*public IEnumerator switchScene(bool fadeInOrOut, float fade_time) //true = Fade-In ; false = Fade-Out || fade time (float)
    {
        if (fadeInOrOut == true)
        {
            fade.alpha = 1;
            fade.LeanAlpha(0, fade_time);
        }
        else
        {
            fade.alpha = 0;
            fade.LeanAlpha(1, fade_time);
        }
        yield return null;
    }*/
}
