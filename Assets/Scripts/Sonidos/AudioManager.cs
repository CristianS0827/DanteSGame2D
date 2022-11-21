using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer efectos;
    public AudioMixer musica;
    public AudioSource bckgMusica,bkcgMBoss,mainMenu, ataque, muerteEnemigo, coins, colec,lanzaDaga,muerteJefe,muertePP,summonJefe,dañoEnemigo,dañoPP,salto;
    
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
        // sliderMusic.value=masterVolume;
        // sliderEffects.value=effectsVolume;
        
        sliderMusic.minValue=-80;
        sliderMusic.maxValue=10;

        sliderEffects.minValue=-80;
        sliderEffects.maxValue=10;

        sliderMusic.value=PlayerPrefs.GetFloat("MusicVolume",0f);
        sliderEffects.value=PlayerPrefs.GetFloat("EffectsVolume",0f);
    }

    // Update is called once per frame
    void Update()
    {
        // MasterVolume();
        // EffectsVolume();   
    }

    public void MasterVolume()
    {
        DataManager.instance.setMusicData(sliderMusic.value);
        musica.SetFloat("MasterVolume",PlayerPrefs.GetFloat("MusicVolume"));   
    }
    public void EffectsVolume()
    {
        DataManager.instance.setEffectsData(sliderEffects.value);
        efectos.SetFloat("EffectsVolume",PlayerPrefs.GetFloat("EffectsVolume"));
    }
    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }   
}
