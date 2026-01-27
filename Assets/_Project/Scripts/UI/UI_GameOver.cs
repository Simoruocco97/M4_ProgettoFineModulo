using UnityEngine;

public class UI_GameOver : MonoBehaviour
{
    [Header("UI Infos")]
    [SerializeField] private GameObject gameOverUI;

    private void Awake()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }

    public void ShowGameOver()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(true);
    }
}