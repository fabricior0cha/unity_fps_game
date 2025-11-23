using UnityEngine;
using static Weapon;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    // Canais de áudio para diferentes categorias
    public AudioSource ShootingChannel;
    public AudioSource reloadingSoundM4_8;
    public AudioSource reloadingSoundM1991;
    public AudioSource emptyMagazine;
    public AudioSource playerChannel; // Para sons do player (dano, morte, passos)
    public AudioSource zombieChannel; // Para sons de zumbi (morte, horda, grito)
    public AudioSource ambientChannel; // Para sons ambientais (horda, início de rodada)

    // Sons de tiro
    public AudioClip M48Shot;
    public AudioClip M1991Shot;

    // Novos sons do player
    public AudioClip playerHitDamage; // HIT-Damage.mp3
    public AudioClip playerFootstep; // SOM-DO-PASSO.mp3
    public AudioClip playerDeath; // PLAYER-DEATH.wav

    // Novos sons de zumbi
    public AudioClip zombieDeath; // ZOMBIE-DEATH.wav
    public AudioClip zombieHorde; // HORDA-ZUMBI.wav
    public AudioClip zombieRoundStart; // GRITO-ZUMBI-INICIO-RODADA.mp3

    [Space]
    [SerializeField, Range(0f, 1f)] private float zombieDeathVolume = 0.2f;

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

    // Métodos existentes para tiros e recarregamento
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

    // ===== NOVOS MÉTODOS PARA OS NOVOS SONS =====

    /// <summary>
    /// Toca o som de grito de zumbi no início de uma nova rodada
    /// </summary>
    public void PlayRoundStartSound()
    {
        if (zombieRoundStart != null)
        {
            zombieChannel.PlayOneShot(zombieRoundStart);
        }
    }

    /// <summary>
    /// Toca o som quando o player toma dano
    /// </summary>
    public void PlayPlayerHitSound()
    {
        if (playerHitDamage != null)
        {
            playerChannel.Stop();
            playerChannel.clip = playerHitDamage;
            playerChannel.Play();
        }
    }

    /// <summary>
    /// Toca o som de passo do player
    /// </summary>
    public void PlayFootstepSound()
    {
        if (playerFootstep != null)
        {
            playerChannel.PlayOneShot(playerFootstep);
        }
    }

    /// <summary>
    /// Toca o som quando o player morre
    /// </summary>
    public void PlayPlayerDeathSound()
    {
        if (playerDeath != null)
        {
            playerChannel.PlayOneShot(playerDeath);
        }
    }

    /// <summary>
    /// Toca o som quando um zumbi morre
    /// </summary>
    public void PlayZombieDeathSound()
    {
        if (zombieDeath != null)
        {
            Debug.Log("Playing zombie death sound " + zombieDeath.name);
            zombieChannel.PlayOneShot(zombieDeath, zombieDeathVolume);
        }
    }

    /// <summary>
    /// Toca o som da horda de zumbis (pode ser usado em loop ou uma vez)
    /// </summary>
    public void PlayZombieHordeSound(bool loop = false)
    {
        if (zombieHorde != null)
        {
            if (loop)
            {
                ambientChannel.clip = zombieHorde;
                ambientChannel.loop = true;
                ambientChannel.Play();
            }
            else
            {
                ambientChannel.PlayOneShot(zombieHorde);
            }
        }
    }

    /// <summary>
    /// Para o som da horda de zumbis (se estiver em loop)
    /// </summary>
    public void StopZombieHordeSound()
    {
        if (ambientChannel.isPlaying && ambientChannel.clip == zombieHorde)
        {
            ambientChannel.Stop();
        }
    }
}
