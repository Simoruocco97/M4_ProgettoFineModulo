using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private bool cursorLock = true;

    private void Awake()
    {
        SetCursor(cursorLock);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = !cursorLock;
            SetCursor(cursorLock);
        }
    }
    private void SetCursor(bool checkLock)
    {
        if (checkLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}