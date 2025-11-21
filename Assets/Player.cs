using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
  public int HP = 100;
    public GameObject gameOverUI;

    public static Player Instance { get; set; }

   
    public void TakeDamage(int damage)
 {
     HP -= damage;

     if (HP <= 0)
     {
            PlayerStats.Instance.health = 0;

            GetComponent<MouseMovement>().enabled = false;
    GetComponent<PlayerMovement>().enabled = false;
                GetComponent<ScreenFader>().StartFade();
            StartCoroutine(ShowGameOver());

        } else
        {
            PlayerStats.Instance.health = HP;
            print("Player took " + damage + " damage, remaining HP: " + HP);
        }
    }

    private IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(1f);
        gameOverUI.gameObject.SetActive(true);
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

