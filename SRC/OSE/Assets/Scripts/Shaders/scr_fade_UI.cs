using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_fade_UI : MonoBehaviour
{
    public CanvasGroup UIElement;
    public float lerp_time = 0.5f; //default fade time
    bool crout_check = false;
    bool crout_check_newcycle = false;
    public bool is_ActionTriggered = false;
    public bool is_final_transparent = false;

    public void FadeInAndOut()
    {
        StartCoroutine(FadeCG(UIElement, UIElement.alpha, 1));
    }

    public IEnumerator FadeCG(CanvasGroup canvas_g, float start, float end)
    {
        crout_check = false;
        float _time_started_lerping = Time.time;
        float time_since_started = Time.time - _time_started_lerping;
        float percentage_complete = time_since_started / lerp_time;

        if (end == 0) { crout_check_newcycle = true; }
        else { crout_check_newcycle = false; }

        while (true)
        {
            time_since_started = Time.time - _time_started_lerping;
            percentage_complete = time_since_started / lerp_time;

            float current_value = Mathf.Lerp(start, end, percentage_complete);

            canvas_g.alpha = current_value;

            if (percentage_complete >= 1) //if fading has finished...
            {
                crout_check = true;
                break;
            }

            if (is_ActionTriggered == true) //if button is pressed then interrupt the fading and set alpha to 1
            {
                if (is_final_transparent == true) //if we want it to be transparent when finished
                {
                    crout_check = false;
                    canvas_g.alpha = 0;
                    break;
                }
                else
                {
                    crout_check = false;
                    canvas_g.alpha = 1;
                    break;
                }
            }

            yield return new WaitForEndOfFrame();
        }

        if (crout_check == true) //if fading has finished...
        {
            if (crout_check_newcycle == true) { StartCoroutine(FadeCG(UIElement, UIElement.alpha, 1)); } //...and it faded-out, execute a fade-in
            else { StartCoroutine(FadeCG(UIElement, UIElement.alpha, 0)); } //...and it faded-in, execute a fade-out
        }
        
        //debug.Log("Fade: done"); //DEBUG: runs after it's done fading
    }
}
