using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
        else if(instance !=null)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void setMusicData(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume",value);
    }
    public void setEffectsData(float value)
    {
        PlayerPrefs.SetFloat("EffectsVolume",value);
    }
     public void currentArrojables(int value)
     {
         PlayerPrefs.SetInt("cantidadArrojables",value);
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
