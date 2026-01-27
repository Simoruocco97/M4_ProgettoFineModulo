using UnityEngine;
using UnityEngine.UI;

public class UI_LifeController : MonoBehaviour
{
    [SerializeField] private Image lifebar;
    [SerializeField] private Gradient gradient;

    public void UpdateLifebar(int currentHp, int maxHp)
    {
        lifebar.fillAmount = (float)currentHp / maxHp;
        lifebar.color = gradient.Evaluate(lifebar.fillAmount);
    }
}