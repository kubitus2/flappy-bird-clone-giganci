using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource effect;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioClip flapSound;

    private void OnEnable()
    {
        AudioButton.OnStateChange += ChangeMuteState;
        BirdController.OnFlap += PlayFlapSound;
    }
    
    private void OnDisable()
    {
        AudioButton.OnStateChange -= ChangeMuteState;
        BirdController.OnFlap -= PlayFlapSound;
    }

    private void ChangeMuteState(bool state)
    {
        Action action = state ? Unmute : Mute;
        action?.Invoke();
    }

    public void PlayMusic()
    {
        music.Play();
    }

    public void StopMusic()
    {
        music.Stop();
    }

    private void Mute()
    {
        mixer.SetFloat("MasterVolume", -80f);
    }

    private void Unmute()
    {
        mixer.SetFloat("MasterVolume", 0f);
    }

    private void PlayFlapSound()
    {
        effect.PlayOneShot(flapSound);
    }
}
