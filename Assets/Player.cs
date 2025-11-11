using UnityEngine;

public class Player : MonoBehaviour
{
  public int HP = 100;

 public void TakeDamage(int damage)
 {
     HP -= damage;
     if (HP <= 0)
     {
       print("Player is dead");
        } else
        {
            print("Player took " + damage + " damage, remaining HP: " + HP);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZombieHand"))
       {
            print("Player hit by Zombie Hand");
            TakeDamage(other.gameObject.GetComponent<ZombieHand>().damage);
       }
    }
}

