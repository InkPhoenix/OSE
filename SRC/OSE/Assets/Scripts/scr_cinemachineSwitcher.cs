using UnityEngine;
using UnityEngine.InputSystem;

public class scr_cinemachineSwitcher : MonoBehaviour
{
    private Animator animator;
    private bool stPersonCam = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SwitchCamera()
    {
        animator.Play("CM_1stP_Cam");
        Debug.Log("1st person cam activated");
        animator.Play("CM_3rdP_Cam");
        Debug.Log("3rd person cam activated");
    }
}
