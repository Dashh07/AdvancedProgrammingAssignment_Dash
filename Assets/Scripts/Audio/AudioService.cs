using UnityEngine;
using System.Collections.Generic;
using System;

public class Audio : IAudioService
{
    private readonly Dictionary<string, AudioClip> sfx;
    private readonly Dictionary<string, AudioClip> music;

    private AudioManager manager;

    public Audio(Dictionary<string, AudioClip> sfx, Dictionary<string, AudioClip> music)
    {
        this.sfx = sfx;
        this.music = music;
    }

    public void SetManager(AudioManager manager)
    {
        this.manager = manager;
    }

    public void PlaySFX(string soundName)
    {
        if (!sfx.TryGetValue(soundName, out var clip)) return;
        manager.PlaySfx(clip);
    }
    public void PlayMusic(string soundName, bool loop = true)
    {
        if (!music.TryGetValue(soundName, out var clip)) return;
        manager.musicSource.loop = loop;
        manager.PlayMusic(clip, loop);
    }

    public void StopMusic()
    {
        manager.StopMusic();
    }
    
}
