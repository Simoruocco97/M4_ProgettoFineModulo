using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GameStart : MonoBehaviour
{
    [SerializeField] private int sceneToLoad = 1;
    public void OnClick()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}