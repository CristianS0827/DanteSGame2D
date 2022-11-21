using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public GameObject panelBoss;
    public GameObject MuroLim;
    public static BossUI instance;

    private void Awake() {
        if(instance==null)
        {
            instance=this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        panelBoss.SetActive(false);
        MuroLim.SetActive(false);
    }
    public void ActivarBoss()
    {
        AudioManager.instance.PauseAudio(AudioManager.instance.bckgMusica);
        AudioManager.instance.PlayAudio(AudioManager.instance.bkcgMBoss);
        panelBoss.SetActive(true);
        MuroLim.SetActive(true);
    }

    public void DesactivarBoss()
    {
        AudioManager.instance.PauseAudio(AudioManager.instance.bkcgMBoss);
        AudioManager.instance.PlayAudio(AudioManager.instance.bckgMusica);
        panelBoss.SetActive(false);
        MuroLim.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
