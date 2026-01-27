using TMPro;
using UnityEngine;

public class UI_Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Gradient gradient;

    public void UpdateTimer(float timeRemaining, float totalTime)
    {
        timerText.text = timeRemaining.ToString("F1");
        float timePercent = timeRemaining / totalTime;

        timerText.color = gradient.Evaluate(timePercent);
    }
}