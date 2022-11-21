using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer efectos;
    public AudioMixer musica;
    public AudioSource bckgMusica,bkcgMBoss, ataque, muerteEnemigo, coins, colec,lanzaDaga,muerteJefe,muertePP,summonJefe,dañoEnemigo,dañoPP,salto;
    
    public static AudioManager instance;
    [Range(-80,10)]
    public float masterVolume, effectsVolume;
    public Slider sliderMusic,sliderEffects;
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
        if(BossUI.instance.MuroLim==false)
        {
            PauseAudio(bkcgMBoss);
        }
        sliderMusic.value=masterVolume;
        sliderEffects.value=effectsVolume;
        
        sliderMusic.minValue=-80;
        sliderMusic.maxValue=10;

        sliderEffects.minValue=-80;
        sliderEffects.maxValue=10;
    }

    // Update is called once per frame
    void Update()
    {
        MasterVolume();
        EffectsVolume();   
    }

    public void MasterVolume()
    {
        musica.SetFloat("MasterVolume",sliderMusic.value);   
    }
    public void EffectsVolume()
    {
        efectos.SetFloat("EffectsVolume",sliderEffects.value);   
    }
    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
    public void PauseAudio(AudioSource audio)
    {
        audio.Pause();
    }
    

    
    
}
