using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string speedXname = "speedX";
    [SerializeField] private string speedZname = "speedZ";
    private bool isMoving = false;

    private void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    public void MovementAnimation(Vector3 dir)
    {
        animator.SetFloat(speedXname, dir.x);
        animator.SetFloat(speedZname, dir.z);

        isMoving = dir.sqrMagnitude > 0.01f;
        animator.SetBool("isMoving", isMoving);
    }

    public void PlayDamageAnimation()
    {
        animator.SetTrigger("Damage");
    }

    public void DeathAnimation()
    {
        animator.SetBool("isDead", true);
    }

    public void WinAnimation()
    {
        animator.SetBool("hasWon", true);
    }
}