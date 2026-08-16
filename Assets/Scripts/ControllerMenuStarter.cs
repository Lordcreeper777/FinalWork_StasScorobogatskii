using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerMenuStarter : MonoBehaviour
{
    public GameObject firstButton;

    private bool controllerStarted = false;

    void Update()
    {
        if (controllerStarted)
            return;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(horizontal) > 0.5f || Mathf.Abs(vertical) > 0.5f)
        {
            EventSystem.current.SetSelectedGameObject(firstButton);
            controllerStarted = true;
        }
    }
}