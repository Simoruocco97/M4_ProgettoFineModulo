using UnityEngine;

public class TimerCoin : MonoBehaviour
{
    [SerializeField] private float timerCoinValue = 10f;
    [SerializeField] private Timer timer;
    [SerializeField] private AudioManager audioManager;

    private void Awake()
    {
        if (timer == null)
            timer = GameObject.FindGameObjectWithTag("GameMode").GetComponent<Timer>();

        if (audioManager == null)
            audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (timer == null)
            timer = collision.GetComponent<Timer>();

        if (timer == null)
            return;

        timer.AddTime(timerCoinValue);
        audioManager.PlayCoinPickup();
        Destroy(gameObject);
    }
}
