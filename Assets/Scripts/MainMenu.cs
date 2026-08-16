using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsPanel;

    public GameObject controlsButton;
    public GameObject backButton;

    public void OpenControls()
    {
        controlsPanel.SetActive(true);
        StartCoroutine(SelectButton(backButton));
    }

    public void CloseControls()
    {
        controlsPanel.SetActive(false);
        StartCoroutine(SelectButton(controlsButton));
    }

    private IEnumerator SelectButton(GameObject button)
    {
        yield return null;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button);
    }
}