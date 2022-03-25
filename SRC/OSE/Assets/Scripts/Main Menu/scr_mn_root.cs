using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class scr_mn_root : MonoBehaviour
{
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        GameObject obj_btn_NewGame = GameObject.Find("btn_NewGame");
        EventSystem.current.SetSelectedGameObject(obj_btn_NewGame);

        /*if (EventSystem.current.currentSelectedGameObject == obj_btn_NewGame) //checks what the current selected button is
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            Debug.Log("this works, yay");
        }*/
    }

    public void setSelected(GameObject obj)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(obj);
    }
}

