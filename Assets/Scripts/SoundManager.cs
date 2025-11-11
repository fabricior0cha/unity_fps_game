using UnityEngine;
using static Weapon;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }


    public AudioSource ShootingChannel;

    public AudioClip M48Shot;
    public AudioClip M1991Shot;

    public AudioSource reloadingSoundM4_8;
    public AudioSource reloadingSoundM1991;

    public AudioSource emptyMagazine;

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

    public void PlayShootingSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.PistolM1911:
                ShootingChannel.PlayOneShot(M1991Shot);
                break;
            case WeaponModel.M4_8:
                ShootingChannel.PlayOneShot(M48Shot);
                break;
        }
    }


    public void PlayReloadSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.PistolM1911:
                reloadingSoundM1991.Play();
                break;
            case WeaponModel.M4_8:
                reloadingSoundM4_8.Play();
                break;
        }
    }
}
