using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectLook : MonoBehaviour
{
    public float distancia = 3f;
    public Camera cam;
    public TMP_Text valorText;

    private Weapon armaAtual = null;

    void Update()
    {
        MostrarValorDaArma();
    }

    void MostrarValorDaArma()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distancia))
        {
            Weapon weapon = hit.collider.GetComponent<Weapon>();
            AmmoBox ammoBox = hit.collider.GetComponent<AmmoBox>();
            if (weapon != null)
            {
                armaAtual = weapon;

                Vector3 posTela = cam.WorldToScreenPoint(weapon.transform.position);

                posTela.y -= 40f;  

                valorText.transform.position = posTela;

                valorText.text = $"M48 - ${armaAtual.weaponPrice} [F]";
                valorText.gameObject.SetActive(true);

                return;
            }

            if(ammoBox != null)
            {
                Vector3 posTela = cam.WorldToScreenPoint(ammoBox.transform.position);
                posTela.y -= 40f;  
                valorText.transform.position = posTela;
                valorText.text = $"Munição - $30 [F]";
                valorText.gameObject.SetActive(true);
                return;
            }

        }

        // Se não está olhando para nada:
        armaAtual = null;
        valorText.text = "";
        valorText.gameObject.SetActive(false);
    }
}
