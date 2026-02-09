using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_SwapToMenu : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}
