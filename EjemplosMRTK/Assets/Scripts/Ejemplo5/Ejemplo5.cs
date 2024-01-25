using UnityEngine;

public class Ejemplo5 : MonoBehaviour
{
    [SerializeField]
    private GameObject appWindow;

    public void ShowAppWindow()
    {
        if (appWindow != null)
        {
            appWindow.SetActive(true);
        }
    }

    public void HideAppWindow()
    {
        if (appWindow != null)
        {
            appWindow.SetActive(false);
        }
    }
}