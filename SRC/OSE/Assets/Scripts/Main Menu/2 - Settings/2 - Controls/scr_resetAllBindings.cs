using UnityEngine;
using UnityEngine.InputSystem;

public class scr_resetAllBindings : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputActions;

    public void ResetBindings()
    {
        foreach (InputActionMap map in inputActions.actionMaps)
        {
            map.RemoveAllBindingOverrides();
        }
    }
}
