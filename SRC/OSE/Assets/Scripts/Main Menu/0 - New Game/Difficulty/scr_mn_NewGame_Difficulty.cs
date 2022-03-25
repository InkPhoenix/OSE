using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class scr_mn_NewGame_Difficulty : MonoBehaviour
{
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        GameObject obj_btn_Normal = GameObject.Find("btn_Normal");
        EventSystem.current.SetSelectedGameObject(obj_btn_Normal);
    }

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        GameObject obj_btn_Normal = GameObject.Find("btn_Normal");
        EventSystem.current.SetSelectedGameObject(obj_btn_Normal);
    }

    public void setSelected(GameObject obj)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(obj);
    }

    public void Easy()
    {
        Debug.Log("scn_Game loaded in 'Easy' Difficulty");
        SceneManager.LoadScene("scn_Game");
    }

    public void Normal()
    {
        Debug.Log("scn_Game loaded in 'Normal' Difficulty");
        SceneManager.LoadScene("scn_Game");
    }

    public void Hard()
    {
        Debug.Log("scn_Game loaded in 'Hard' Difficulty");
        SceneManager.LoadScene("scn_Game");
    }

    public void Extreme()
    {
        Debug.Log("scn_Game loaded in 'Extreme' Difficulty");
        SceneManager.LoadScene("scn_Game");
    }
}
