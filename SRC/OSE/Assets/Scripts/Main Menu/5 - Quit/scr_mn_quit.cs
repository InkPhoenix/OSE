using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class scr_mn_quit : MonoBehaviour
{
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        GameObject obj_btn_No = GameObject.Find("btn_No");
        EventSystem.current.SetSelectedGameObject(obj_btn_No);
    }

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        GameObject obj_btn_No = GameObject.Find("btn_No");
        EventSystem.current.SetSelectedGameObject(obj_btn_No);
    }

    public void setSelected(GameObject obj)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(obj);
    }

    public void GameEnd()
    {
        Debug.Log("game.end");
        Application.Quit();
    }
}
