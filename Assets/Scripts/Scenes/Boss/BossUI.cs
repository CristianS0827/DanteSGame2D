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
        AudioManager.instance.bckgMusica.Stop();
        AudioManager.instance.PlayAudio(AudioManager.instance.bkcgMBoss);
        panelBoss.SetActive(true);
        MuroLim.SetActive(true);
    }

    public void DesactivarBoss()
    {
        panelBoss.SetActive(false);
        MuroLim.SetActive(false);
        AudioManager.instance.bkcgMBoss.Stop();
        AudioManager.instance.PlayAudio(AudioManager.instance.bckgMusica);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
