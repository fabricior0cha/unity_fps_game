using UnityEngine;

public class Zombie1 : MonoBehaviour
{

    public ZombieHand zombieHand;

    public int zombieDamage;
    void Start()
    {
        zombieHand.damage = zombieDamage;
    }

}
