using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager instance { get { return _instance; } }

    [SerializeField] AudioSource musicAS;
    [SerializeField] AudioSource sfxAS;
    [SerializeField] float musicVolume;
    [SerializeField] float sfxVolume;

    public SoundType[] audioClips;

    private void Awake()
    {
        if (_instance)
        {
            Destroy(this.gameObject);

        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start()
    {
        musicAS.volume = musicVolume;
        sfxAS.volume = sfxVolume;
        PlayMusic(Sounds.BackGround);
    }
    public void PlaySfx(Sounds sound)
    {
        AudioClip soundClip = GetClip(sound);
        if (soundClip != null)
        {
            sfxAS.PlayOneShot(soundClip);
        }
    }
    public void PlayMusic(Sounds sound)
    {
        AudioClip soundClip = GetClip(sound);
        if (soundClip != null)
        {
            musicAS.clip = soundClip;
            musicAS.Play();
        }
    }
    public AudioClip GetClip(Sounds _clipType)
    {
        SoundType item = Array.Find(audioClips, i => i.clipType == _clipType);
        if (item != null) return item.clip;
        return null;
    }
    public void StopMusic()
    {
        musicAS.volume = 0f;
    }
    public void Mute()
    {
        musicAS.volume = 0f;
        sfxAS.volume = 0f;
    }

    public void ResetSounds()
    {
        musicAS.volume = musicVolume;
        sfxAS.volume = sfxVolume;
    }
}

[Serializable]
public class SoundType
{
    public Sounds clipType;
    public AudioClip clip;
}

public enum Sounds
{
    BackGround,
    ButtonClick,
    FoodPickup,
    PowerupPickup,
    GameOver
}
