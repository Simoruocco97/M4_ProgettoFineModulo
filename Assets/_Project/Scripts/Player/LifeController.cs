using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [Header("HP Settings")]
    [SerializeField] private int maxHp = 100;
    [SerializeField] private int minHp = 0;
    [SerializeField] private bool fullHpOnStart = false;
    private int hpOnStart = 50;
    private int currentHp;

    [Header("Unity Events")]
    [SerializeField] private UnityEvent<int, int> onHpChange;
    [SerializeField] private UnityEvent onDefeat;

    private void Awake()
    {
        if (fullHpOnStart) SetHp(maxHp);
        else SetHp(hpOnStart);
    }

    public int GetMaxHp()
    {
        return maxHp;
    }

    public int GetMinHp()
    {
        return minHp;
    }

    public int GetHp()
    {
        return currentHp;
    }

    private void SetHp(int hp)
    {
        currentHp = Mathf.Clamp(hp, minHp, maxHp);
        onHpChange.Invoke(currentHp, maxHp);

        Debug.Log($"{gameObject.name} ha {GetHp()} Hp");
    }

    public void AddHp(int heal)
    {
        if (heal < 0) heal = 0;
        SetHp(currentHp + heal);
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0) damage = 0;
        SetHp(currentHp - damage);
        DestroyIfDead();
    }

    private void DestroyIfDead()
    {
        if (GetHp() <= minHp)
        {
            onDefeat.Invoke();
            Destroy(gameObject);
        }
    }
}