using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class scr_mn_Settings : MonoBehaviour
{
    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        GameObject obj_btn_Audio = GameObject.Find("btn_Audio");
        EventSystem.current.SetSelectedGameObject(obj_btn_Audio);
    }

    public void setSelected(GameObject obj)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(obj);
    }
}
