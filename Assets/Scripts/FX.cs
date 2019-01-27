using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour
{
    public AudioClip[] clips;
    AudioSource src;
    public GameObject particles;

    private void Start()
    {
        src = GetComponent<AudioSource>();
    }

    AudioClip GetRandom()
    {
        int rnd = Random.Range(0, clips.Length);
        return clips[rnd];
    }

    public void PlayRandomClip()
    {
        if (clips != null && clips.Length > 0 && src != null)
        {
            src.PlayOneShot(GetRandom());

        }
    }

    public void PlayParticles()
    {
        Destroy(Instantiate(particles, transform.position, particles.transform.rotation, this.transform), 2f);
    }


}
