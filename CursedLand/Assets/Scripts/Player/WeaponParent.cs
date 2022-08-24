using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }
    public Animator animator;

    public float delay = 0.3f;
    private bool attackBlocked;

    public Transform circleOrigin;
    public float radius;

    public bool IsAttacking { get; private set; }

    [SerializeField]
    public int dmg;

    public void ResetIsAttacking()
    {
        IsAttacking = false;
    }

    private void Update()
    {
        if (IsAttacking)
            return;
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;
        //Debug.Log(direction.x);

        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
            
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
            
        }

        transform.localScale = scale;
    }

    public void Attack()
    {
        Debug.Log("SERANG");
        if (attackBlocked)
            return;
        animator.SetTrigger("Attack");
        IsAttacking=true;
        attackBlocked = true;
        StartCoroutine(DelayAttack());
        DetectColliders(dmg);
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    public void DetectColliders(int dmg)
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position,radius))
        {
            Debug.Log(collider.name);
            Debug.Log(dmg);
            Health health;
            if(health = collider.GetComponent<Health>())
            {
                health.GetHit(dmg, transform.parent.gameObject);
            }
        }
    }

}
