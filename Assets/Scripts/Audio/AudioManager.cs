using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [Header ("Audio Manager Settings")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    
    
    public void PlayMusic(AudioClip clip, bool loop)
    {
        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }


    public void StopMusic()
    {
        musicSource.Stop();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
