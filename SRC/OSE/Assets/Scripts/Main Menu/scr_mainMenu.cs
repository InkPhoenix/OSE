using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_mainMenu : MonoBehaviour
{
    private IEnumerator fadeFromBlack()
    {
        scr_fade_levelLoader.make_fade_black_on_startup = false;
        scr_fade_levelLoader loader_script = GameObject.Find("Crossfade").GetComponent<scr_fade_levelLoader>();
        CanvasGroup loader_script_alpha = GameObject.Find("Crossfade").GetComponent<CanvasGroup>();
        loader_script_alpha.alpha = 1;
        yield return new WaitForSeconds(1.0f); //give it slight delay just to look better
        StartCoroutine(loader_script.sceneSwitchFadeOut(0.5f, false, DG.Tweening.Ease.Linear));
    }

    private void Start()
    {
        if (scr_fade_levelLoader.make_fade_black_on_startup == true) { StartCoroutine(fadeFromBlack()); }
    }
}
