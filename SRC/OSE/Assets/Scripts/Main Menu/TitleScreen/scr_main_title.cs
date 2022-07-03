using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_main_title : MonoBehaviour
{
    private void Start() //in future change to "public void startFade()"
    {
        scr_fade_UI fade_shader = GetComponent<scr_fade_UI>();
        fade_shader.UIElement.alpha = 0;
        fade_shader.lerp_time = 0.5f; //fading time

        fade_shader.FadeInAndOut();
    }

    /*public IEnumerator timer() //timer
    {
        scr_fade_UI fade_shader = GetComponent<scr_fade_UI>();
        yield return new WaitForSeconds(9);
        fade_shader.is_ActionTriggered = true;
    }*/

    public void stopFade()
    {
        scr_fade_UI fade_shader = GetComponent<scr_fade_UI>();
        fade_shader.is_ActionTriggered = true;
    }
}
