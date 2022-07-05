using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scr_intro : MonoBehaviour
{
    public CanvasGroup logo_alpha;
    public CanvasGroup fade;
    private float fade_time = 1.3f; //fading time
    private scr_fade_levelLoader script_fade; //reference to level loader fade

    public IEnumerator timer() //timer
    {
        logo_alpha.alpha = 1; //just to be sure
        yield return new WaitForSeconds(1.4f); //wait X seconds before fading-out
        logo_alpha.DOFade(0, fade_time).OnStepComplete(changeScene);
    }

    public void Start()
    {
        //reference an object that includes the level loade fade script, set fade value to 0 to be sure
        scr_fade_levelLoader loader_script = GameObject.Find("Crossfade").GetComponent<scr_fade_levelLoader>();
        loader_script.fade.alpha = 0;

        logo_alpha.alpha = 0;
        logo_alpha.DOFade(1, fade_time).OnStepComplete(onComplete); //fade-in
    }

    private void onComplete() //start timer after fade-in is complete
    {
        StartCoroutine(timer());
    }

    private IEnumerator sceneSwitch() //wait 0.5 seconds before switching scenes
    {
        yield return new WaitForSeconds(0.5f);
        scr_fade_levelLoader loader_script = GameObject.Find("Crossfade").GetComponent<scr_fade_levelLoader>();
        loader_script.scene_name = "scn_MainMenu";
        loader_script.fade_time = 0.5f;
        yield return loader_script.sceneSwitchFadeIn();
    }

    private void changeScene() { StartCoroutine(sceneSwitch()); }
}
