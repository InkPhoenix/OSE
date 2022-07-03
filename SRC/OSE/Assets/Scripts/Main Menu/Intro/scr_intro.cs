using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_intro : MonoBehaviour
{
    public CanvasGroup logo_alpha;
    private float fade_time = 1.3f; //fading time

    public IEnumerator timer() //timer
    {
        logo_alpha.alpha = 1; //just to be sure
        yield return new WaitForSeconds(1.4f); //wait X seconds before fading-out
        logo_alpha.LeanAlpha(0, fade_time).setOnComplete(changeScene);
    }

    private void Start()
    {
        logo_alpha.alpha = 0;
        logo_alpha.LeanAlpha(1, fade_time).setOnComplete(onComplete); //fade-in
    }

    private void onComplete() //start timer after fade-in is complete
    {
        StartCoroutine(timer());
    }

    private IEnumerator sceneSwitch() //wait of 0.5 seconds before switching scenes
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("scn_MainMenu");
    }

    private void changeScene() { StartCoroutine(sceneSwitch()); }
}
