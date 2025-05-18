using UnityEngine;

public class KalpEfekti : MonoBehaviour
{
    private AudioSource sesKaynagi;
    private ParticleSystem partikuller;

    void Start()
    {
        sesKaynagi = GetComponent<AudioSource>();
        partikuller = GetComponent<ParticleSystem>();

        if (sesKaynagi != null)
            sesKaynagi.Play();

        if (partikuller != null)
            partikuller.Play();

        Destroy(gameObject, 2f); // Efekti 2 saniye sonra sahneden sil
    }
}


