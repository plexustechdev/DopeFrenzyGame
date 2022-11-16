using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] audioClip;
    public AudioSource audioSource;


    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
         AudioClip clip =  getRandomAudioClip(audioClip);
        audioSource.clip = clip;
        audioSource.playOnAwake = false;
    }


    public void PlayAudio()
    {
        audioSource.Play();
    }
    public AudioClip getRandomAudioClip(AudioClip[] AC)
    {
        int x = Random.Range(0, AC.Length);
        return AC[x];
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
    
    public void SetVolume(float value)
    {
        audioSource.volume = value;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
