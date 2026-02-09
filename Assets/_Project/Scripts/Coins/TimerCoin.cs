using UnityEngine;

public class TimerCoin : MonoBehaviour
{
    [SerializeField] private float timerCoinValue = 10f;
    [SerializeField] private Timer timer;

    private void Awake()
    {
        if (timer == null)
            timer = GameObject.FindGameObjectWithTag("GameMode").GetComponent<Timer>();
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
        Destroy(gameObject);
    }
}
