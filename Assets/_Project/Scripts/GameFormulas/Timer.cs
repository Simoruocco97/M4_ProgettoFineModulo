using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [Header("Timer Infos")]
    [SerializeField] private UnityEvent<float, float> onTimerDecrease;
    [SerializeField] private float maxTime = 150;
    private float timeRemaining;

    [Header("Player Info")]
    [SerializeField] private LifeController playerLifeController;

    private void Awake()
    {
        if (playerLifeController == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
                playerLifeController = player.GetComponent<LifeController>();
        }

        timeRemaining = maxTime;
        onTimerDecrease.Invoke(timeRemaining, maxTime);
    }

    private void Update()
    {
        if (timeRemaining <= 0) return;

        timeRemaining -= Time.deltaTime;
        onTimerDecrease.Invoke(timeRemaining, maxTime);

        if (timeRemaining <= 0)
        {
            timeRemaining = 0f;
            if (playerLifeController != null)
                playerLifeController.TakeDamage(999);
        }
    }

    public void AddTime(float time)
    {
        timeRemaining += time;
        onTimerDecrease.Invoke(timeRemaining, maxTime);
    }
}