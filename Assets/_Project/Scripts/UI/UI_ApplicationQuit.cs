using UnityEngine;

public class UI_ApplicationQuit : MonoBehaviour
{
    public void OnClickedButton()
    {
        Debug.Log("Sei uscito dal gioco");
        Application.Quit();
    }
}
