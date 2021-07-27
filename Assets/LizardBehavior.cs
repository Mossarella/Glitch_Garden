using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public float currentSpeed;
    public GameObject currentTarget;
    public Animator animator;

    public int damage;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
        }
    }
    public void SetMovementSpeed(float movespeed)
    {
        currentSpeed = movespeed;
    }
    public void Attack(GameObject target)
    {
        

        
        
        StrikeCurrentTarget();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        if(otherObject.CompareTag("Ally")&&otherObject.GetComponent<AllyInfo>())
        {
            currentTarget = otherObject;
            Attack(otherObject);
         
        }
    }
    
    public void StrikeCurrentTarget()
    {
        if(!currentTarget)
        {
            return;
        }

        animator.SetBool("IsAttacking", true);
       
            currentTarget.GetComponent<AllyInfo>().TakeDamage(damage);

        
        
    }
}
