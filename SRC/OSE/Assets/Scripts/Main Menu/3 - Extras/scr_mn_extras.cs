using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class scr_mn_extras : MonoBehaviour
{
    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        GameObject obj_btn_PhotoAlbum = GameObject.Find("btn_PhotoAlbum");
        EventSystem.current.SetSelectedGameObject(obj_btn_PhotoAlbum);
    }

    public void setSelected(GameObject obj)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(obj);
    }
}
