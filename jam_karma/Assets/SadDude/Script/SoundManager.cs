using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] sounds;
    public float minInterval = 3f;
    public float maxInterval = 10f;

    private AudioSource audioSource;
    private bool canPlaySound = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomSound());
    }

    private IEnumerator PlayRandomSound()
    {
        while (true)
        {
            if (canPlaySound)
            {
                canPlaySound = false;
                float interval = Random.Range(minInterval, maxInterval);
                yield return new WaitForSeconds(interval);
                PlayRandomClip();
                canPlaySound = true;
            }
            else
            {
                yield return null;
            }
        }
    }

    private void PlayRandomClip()
    {
        if (sounds.Length > 0)
        {
            int randomIndex = Random.Range(0, sounds.Length);
            AudioClip clip = sounds[randomIndex];
            audioSource.PlayOneShot(clip);
        }
    }
}
