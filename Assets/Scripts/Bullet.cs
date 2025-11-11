using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int bulletDamage = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision objectWeHit)
    {
        if (objectWeHit.gameObject.CompareTag("Target"))
        {
            print("hit " + objectWeHit.gameObject.name + " !");

            CreateBulletImpactEffect(objectWeHit);
            Destroy(gameObject);
        }

        if (objectWeHit.gameObject.CompareTag("Wall"))
        {
            print("hit a wall!");
            CreateBulletImpactEffect(objectWeHit);
            Destroy(gameObject);
        }

        if(objectWeHit.gameObject.CompareTag("Zombie"))
        {
            Zombie zombieScript = objectWeHit.gameObject.GetComponent<Zombie>();
            
            zombieScript.TakeDamage(bulletDamage);

            Destroy(gameObject);
        }
    }

    void CreateBulletImpactEffect(Collision objectWeHit)
    {
        ContactPoint contact = objectWeHit.contacts[0];

        GameObject hole = Instantiate(
            GlobalReferences.Instance.bulletImpactEffectPrefab,
            contact.point,
            Quaternion.LookRotation(contact.normal)
            );


        hole.transform.SetParent(objectWeHit.transform);
    }
}
