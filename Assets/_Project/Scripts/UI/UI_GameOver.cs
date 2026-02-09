using UnityEngine;

public class UI_GameOver : MonoBehaviour
{
    [Header("UI Infos")]
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private CameraOrbit cameraScript;
    [SerializeField] private CursorController cursor;

    private void Awake()
    {
        if (cameraScript == null)
            cameraScript = FindAnyObjectByType<CameraOrbit>();

        if (cursor == null)
            cursor = FindAnyObjectByType<CursorController>();

        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }

    public void ShowGameOver()
    {
        if (gameOverUI == null)
            return;

        if (cameraScript != null)
            cameraScript.EnableCamLock();

        if (cursor != null)
            cursor.UnlockCursor();

        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}