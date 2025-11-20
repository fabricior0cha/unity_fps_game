using UnityEngine;
using UnityEngine.Video;

public class MenuController : MonoBehaviour
{
public VideoPlayer videoPlayer;
public GameObject menuOpcoes, rawImage;
private Animator animatorRawImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuOpcoes.SetActive(false);
        rawImage.SetActive(false);
        animatorRawImage = rawImage.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!videoPlayer.isPlaying && Input.anyKeyDown)
        {
            videoPlayer.Play();
            animatorRawImage.SetTrigger("fadeIn");
            rawImage.SetActive(true);
            menuOpcoes.SetActive(true);
        }
    }
}
