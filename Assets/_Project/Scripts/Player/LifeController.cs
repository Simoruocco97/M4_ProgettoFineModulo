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
    private bool isDead = false;

    [Header("Unity Events")]
    [SerializeField] private UnityEvent<int, int> onHpChange;
    [SerializeField] private UnityEvent onDefeat;

    [Header("Audio Settings")]
    [SerializeField] private AudioManager audioManager;

    [Header("Animator")]
    [SerializeField] private AnimationManager animationManager;

    private void Awake()
    {
        if (fullHpOnStart) SetHp(maxHp);
        else SetHp(hpOnStart);

        if (audioManager == null)
            audioManager = FindAnyObjectByType<AudioManager>();

        if (animationManager == null)
            animationManager = GetComponent<AnimationManager>();
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
        if (isDead) return;

        SetHp(currentHp - damage);

        if (GetHp() <= minHp)
        {
            OnDeath();
        }

        if (!isDead)
        {
            animationManager.PlayDamageAnimation();
            audioManager.PlayPlayerDamageSound();
        }
    }

    public void DestroyIfDead()
    {
        onDefeat.Invoke();
        Destroy(gameObject);
    }

    private void OnDeath()
    {
        isDead = true;

        audioManager.StopBackgroundMusic();
        animationManager.DeathAnimation();
        audioManager.PlayGameOverSound();

        Invoke(nameof(DestroyIfDead), 2);
    }
}