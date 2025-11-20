using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public Slider health;
    public TextMeshProUGUI ammo;

    public void SetHealth(float v) => health.value = v;
    public void SetAmmo(int cur, int max) => ammo.text = cur + " / " + max;
}
