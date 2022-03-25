using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class scr_mn_NewGame : MonoBehaviour
{
    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        GameObject obj_btn_StoryMode = GameObject.Find("btn_StoryMode");
        EventSystem.current.SetSelectedGameObject(obj_btn_StoryMode);
    }

    public void setSelected(GameObject obj)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(obj);
    }
}
