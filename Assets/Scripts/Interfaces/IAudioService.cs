using UnityEngine;

public interface IAudioService
{
    void PlaySFX(string soundName);
    void PlayMusic(string soundName, bool loop = true);
    void StopMusic();
  
}
