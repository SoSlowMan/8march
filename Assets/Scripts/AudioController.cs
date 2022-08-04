using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioSource myRoomMusic, ksuMusic, mainMenuMusic, roadMusic, pickupSound, explosionSound, shootMusic, shootSound, engineSound;

    private void Awake()
    {
        instance = this;
    }

    public void PlayMyRoomMusic()
    {
        myRoomMusic.Stop();
        myRoomMusic.Play();
    }

    public void PlayMainMenuMusic()
    {
        mainMenuMusic.Stop();
        mainMenuMusic.Play();
    }

    public void PlayKsuMusic()
    {
        ksuMusic.Stop();
        ksuMusic.Play();
    }

    public void PlayRoadMusic()
    {
        roadMusic.Stop();
        roadMusic.Play();
    }

    public void PlayPickupSound()
    {
        pickupSound.Stop();
        pickupSound.Play();
    }

    public void PlayExplosionSound()
    {
        explosionSound.Stop();
        explosionSound.Play();
    }

    public void PlayShootMusic()
    {
        shootMusic.Stop();
        shootMusic.Play();
    }

    public void PlayShootSound()
    {
        shootSound.Stop();
        shootSound.Play();
    }

    public void PlayEngineSound()
    {
        engineSound.Stop();
        engineSound.volume = 0f;
        engineSound.Play();
    }
}
