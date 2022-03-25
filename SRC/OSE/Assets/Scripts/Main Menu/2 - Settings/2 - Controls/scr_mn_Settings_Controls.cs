using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class scr_mn_Settings_Controls : MonoBehaviour
{
    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        GameObject obj_btn_keyboard = GameObject.Find("btn_keyboard");
        EventSystem.current.SetSelectedGameObject(obj_btn_keyboard);
    }

    public void setSelected(GameObject obj)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(obj);
    }
}
