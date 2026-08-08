using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsPanel;

    public void OpenControls()
    {
        controlsPanel.SetActive(true);
    }

    public void CloseControls()
    {
        controlsPanel.SetActive(false);
    }
}