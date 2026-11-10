using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip coinSFX;

    public void PlaySFX(string clipToPlay)
    {
        if (clipToPlay == "Coin")
        {
            AudioSource.clip = coinSFX;
        }
        AudioSource.Play();
    }
}
