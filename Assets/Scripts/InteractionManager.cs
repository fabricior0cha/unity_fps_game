using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance { get; set; }

    public Weapon hoveredWeapon;
    public AmmoBox hoveredAmmoBox;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) { 
            
            GameObject objectHitByRaycast = hit.transform.gameObject;

            if (objectHitByRaycast.GetComponent<Weapon>() && objectHitByRaycast.GetComponent<Weapon>().isActiveWeapon == false)
            {
                hoveredWeapon = objectHitByRaycast.gameObject.GetComponent<Weapon>();
                hoveredWeapon.GetComponent<Outline>().enabled = true;


                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (ScoreController.Instance.score >= hoveredWeapon.weaponPrice )
                    {
                        ScoreController.Instance.RemoveScore(hoveredWeapon.weaponPrice);
                        
                        WeaponManager.Instance.BuyWeapon(objectHitByRaycast.gameObject);
                    }
                   
                }

               

            } else
            {
                if (hoveredWeapon)
                {
                    hoveredWeapon.GetComponent<Outline>().enabled = false;

                }
            }

   

            //Ammo box
            if (objectHitByRaycast.GetComponent<AmmoBox>())
            {
                hoveredAmmoBox = objectHitByRaycast.gameObject.GetComponent<AmmoBox>();
                hoveredAmmoBox.GetComponent<Outline>().enabled = true;


                if (Input.GetKeyDown(KeyCode.F) && ScoreController.Instance.score >= 30)
                {
                    WeaponManager.Instance.PickupTotalAmmo(100, 150);
                    ScoreController.Instance.RemoveScore(30);
                }

            }
            else
            {
                if (hoveredAmmoBox)
                {
                    hoveredAmmoBox.GetComponent<Outline>().enabled = false;

                }
            }
        }


    }
}

