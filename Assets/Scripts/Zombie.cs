using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private int HP = 100;

    private Animator animator;

    private NavMeshAgent navAgent;

    public bool isDead = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if(isDead)
        {
            return;
        }

        if (HP <= 0)
        {

            int randomValue = Random.Range(0, 2);

            if(randomValue == 0)
            {

                animator.SetTrigger("DIE1");
            } else
            {

                animator.SetTrigger("DIE2");
            }

           isDead = true;
        } else
        {
            animator.SetTrigger("DAMAGE");
        }
    }
    
    private void Update()
    {
       
    }
}
