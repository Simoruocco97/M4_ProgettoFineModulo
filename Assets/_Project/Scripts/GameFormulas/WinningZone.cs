using UnityEngine;
using UnityEngine.Events;

public class WinningZone : MonoBehaviour
{
    [SerializeField] private UnityEvent onWinning;
    [SerializeField] private CameraOrbit cameraScript;

    private void Awake()
    {
        if (cameraScript == null)
            cameraScript = Camera.main.GetComponent<CameraOrbit>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cameraScript.EnableCamLock();
            Debug.Log("Hai vinto");
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                onWinning.Invoke();
            }
        }
    }
}