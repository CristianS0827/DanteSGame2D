using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer efectos;
    public AudioMixer musica;
    public AudioSource bckgMusica, ataque, muerteEnemigo, coins, colec,lanzaDaga,muerteJefe,muertePP,summonJefe,dañoEnemigo,dañoPP,salto;

    public static AudioManager instance;
    private void Awake() {
        if(instance==null)
        {
            instance=this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayAudio(bckgMusica);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
    

    
    
}
