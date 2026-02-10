using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_ChangeLevel : MonoBehaviour
{
    [SerializeField] private int firstLevelInt;
    [SerializeField] private int secondLevelInt;

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(firstLevelInt);
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(secondLevelInt);
    }
}
