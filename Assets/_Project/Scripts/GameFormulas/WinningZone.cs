using UnityEngine;
using UnityEngine.Events;

public class WinningZone : MonoBehaviour
{
    [SerializeField] private UnityEvent onWinning;
    [SerializeField] private CameraOrbit cameraScript;
    [SerializeField] private AudioManager audioManager;

    private void Awake()
    {
        if (cameraScript == null)
            cameraScript = Camera.main.GetComponent<CameraOrbit>();

        if (audioManager == null)
            audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hai vinto");
            cameraScript.EnableCamLock();

            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                audioManager.StopBackgroundMusic();
                audioManager.PlayWinningSound();
                onWinning.Invoke();
            }
        }
    }
}