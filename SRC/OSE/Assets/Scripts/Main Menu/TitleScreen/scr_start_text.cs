using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class scr_start_text : MonoBehaviour
{
    public CanvasGroup UI_element;
    public CanvasGroup back_fade;
    public CanvasGroup front_fade;
    public TextMeshProUGUI UI_element_text;
    public TextMeshProUGUI back_fade_text;
    public TextMeshProUGUI front_fade_text;
    public AudioSource SFXSource;

    private float fade_time = 0.8f;
    private Guid uid;
    private Sequence sequence;
    private int sequence_stopped;
    public IEnumerator crout_id;

    public void Start()
    {
        sequence_stopped = 0;
        UI_element.alpha = 0;
        crout_id = startupTextFade();
        StartCoroutine(crout_id);
    }

    private IEnumerator startupTextFade()
    {
        yield return new WaitForSeconds(3.5f); //wait before fading-in the text
        sequence_stopped = 3;
        startTextFade();
    }

    public void startTextFade()
    {
        if (sequence == null) //create if there's none before
        {
            sequence = DOTween.Sequence();
            sequence.Append(UI_element.DOFade(1, fade_time).SetEase(Ease.InQuad));
            uid = System.Guid.NewGuid();
            sequence.id = uid;
        }
        sequence.Play().SetLoops(-1, LoopType.Yoyo);
    }

    public void stopFade()
    {
        switch (sequence_stopped)
        {
            case 0: //code to skip animation
                sequence_stopped++;
                UI_element.alpha = 0;
                StopCoroutine(crout_id);
                startTextFade();
            break;

            case 1:
                sequence_stopped++;
                break;

            case 2:
                sequence_stopped++;
                break;

            case 3: //code to change scenes
                //kill the sequence with ID uid and set sequence to NULL
                DOTween.Kill(uid);
                sequence = null;

                //set alphas to 1
                sequence_stopped++;
                UI_element.alpha = 1;
                back_fade.alpha = 1;
                front_fade.alpha = 1;

                //play SFX
                SFXSource.Play();

                //start animations
                Vector3 text_original_scale = transform.localScale;
                float text_scale_to = text_original_scale.x * 1.35f; //scale up the text by 1.35

                //Tween the text spacing
                DOTween.To(() => UI_element_text.characterSpacing, x => UI_element_text.characterSpacing = x, 1.5f, 0.75f);
                DOTween.To(() => back_fade_text.characterSpacing, x => back_fade_text.characterSpacing = x, 1.5f, 0.75f);
                DOTween.To(() => front_fade_text.characterSpacing, x => front_fade_text.characterSpacing = x, 1.5f, 0.75f);

                //Tween the text scale
                UI_element.transform.DOScaleX(text_scale_to, 0.75f);
                back_fade.transform.DOScaleX(text_scale_to, 0.75f);
                front_fade.transform.DOScaleX(text_scale_to, 0.75f);

                //Tween the text fade
                UI_element.DOFade(0, 0.75f);
                back_fade.DOFade(0, 0.25f);
                front_fade.DOFade(0, 0.25f);
            break;

            default:
            break;
        }
    }
}
