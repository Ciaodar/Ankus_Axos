using UnityEngine;

public class WaterSoundTrigger : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // AudioSource objeye atanmadıysa hata almamak için kontrol ekledik
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Stop();
        }
    }
}