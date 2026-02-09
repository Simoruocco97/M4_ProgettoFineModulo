using UnityEngine;

public class UI_PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private CursorController cursor;
    [SerializeField] private CameraOrbit cameraScript;
    private bool isPaused = false;

    private void Awake()
    {
        if (cameraScript == null)
            cameraScript = FindAnyObjectByType<CameraOrbit>();

        if (cursor == null)
            cursor = FindAnyObjectByType<CursorController>();

        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            EnableMenu();
    }
    private void EnableMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        cursor.UnlockCursor();
        isPaused = true;
        cameraScript.EnableCamLock();
    }

    public void OnResumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        cursor.LockCursor();
        isPaused = false;
        cameraScript.DisableCamLock();
    }
}