using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private string speedXname = "speedX";
    [SerializeField] private string speedZname = "speedZ";
    [SerializeField] private string speedYname = "speedY";
    [SerializeField] private string onJumpPerformName = "OnJumpPerform";
    private bool isMoving = false;

    private void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    public void MovementAnimation(Vector3 dir)
    {
        if (animator == null)
            return;

        animator.SetFloat(speedXname, dir.x);
        animator.SetFloat(speedZname, dir.z);

        isMoving = dir.sqrMagnitude > 0.01f;
        animator.SetBool("isMoving", isMoving);
    }

    public void TriggerJump()
    {
        if (animator != null && rb != null)
            animator.SetTrigger("Jump");
    }

    public void JumpAnimation()
    {
        if (animator != null)
            animator.SetFloat(speedYname, rb.velocity.y);
    }

    public void SetJumpState(bool isGrounded)
    {
        animator.SetBool(onJumpPerformName, isGrounded);
    }

    public void PlayDamageAnimation()
    {
        if (animator != null)
            animator.SetTrigger("Damage");
    }

    public void DeathAnimation()
    {
        if (animator != null)
            animator.SetBool("isDead", true);
    }
}