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

            // Marca como morto ANTES de tocar o som para evitar múltiplas chamadas
            isDead = true;

            // Toca o som de morte do zumbi
            if (SoundManager.Instance != null)
            {
                Debug.Log("Zombie: Chamando PlayZombieDeathSound()");
                SoundManager.Instance.PlayZombieDeathSound();
            }
            else
            {
                Debug.LogError("Zombie: SoundManager.Instance é null!");
            }
        } else
        {
            animator.SetTrigger("DAMAGE");
        }
    }
    
    private void Update()
    {
       
    }
}
