using UnityEngine;

public class UI_WinningZone : MonoBehaviour
{
    [Header("UI Infos")]
    [SerializeField] private GameObject winningUI;
    [SerializeField] private CameraOrbit cameraScript;
    [SerializeField] private CursorController cursor;

    private void Awake()
    {
        if (cursor == null)
            cursor = FindAnyObjectByType<CursorController>();

        if (cameraScript == null)
            cameraScript = FindAnyObjectByType<CameraOrbit>();

        if (winningUI != null)
            winningUI.SetActive(false);
    }

    public void ShowWinningUI()
    {
        if (winningUI == null) return;

        if (cameraScript != null)
            cameraScript.EnableCamLock();

        winningUI.SetActive(true);

        if (cursor != null)
            cursor.UnlockCursor();

        Time.timeScale = 0f;
    }
}
