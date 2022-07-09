using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scr_intro : MonoBehaviour
{
    public CanvasGroup logo_alpha;
    public CanvasGroup fade;
    private float fade_time = 1.3f; //fading time

    public IEnumerator timer() //timer
    {
        logo_alpha.alpha = 1; //just to be sure
        yield return new WaitForSeconds(1.4f); //wait X seconds before fading-out
        logo_alpha.DOFade(0, fade_time).OnStepComplete(changeScene);
    }

    public void Start()
    {
        //reference an object that includes the level loader fade script
        scr_fade_levelLoader loader_script = GameObject.Find("Crossfade").GetComponent<scr_fade_levelLoader>();

        loader_script.fade.alpha = 0; //set fade value to 0 just to be sure
        logo_alpha.alpha = 0;
        logo_alpha.DOFade(1, fade_time).OnStepComplete(onComplete); //fade-in
    }

    private void onComplete() //start timer after fade-in is complete
    {
        StartCoroutine(timer());
    }

    private IEnumerator sceneSwitch() //wait 0.5 seconds before switching scenes
    {
        scr_fade_levelLoader loader_script = GameObject.Find("Crossfade").GetComponent<scr_fade_levelLoader>();
        loader_script.scene_name = "scn_titlescreen";
        scr_fade_levelLoader.make_fade_black_on_startup = true; //make the fade be of alpha 1 on startup of next scene
        yield return loader_script.sceneSwitchFadeIn(0.1f, true, Ease.Linear);
    }

    private void changeScene() { StartCoroutine(sceneSwitch()); }
}
