using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    bool EsPausado;
    // Start is called before the first frame update
    void Awake()
    {
            Time.timeScale=1;
            pauseMenu.SetActive(false);
            EsPausado=false;
    }

    // Update is called once per frame
    void Update()
    {
     Pause();   
    }
    public void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !EsPausado)
        {
            Time.timeScale=0;
            pauseMenu.SetActive(true);
            EsPausado=true;
        }else if((Input.GetKeyDown(KeyCode.Escape) && EsPausado))
        {
            Time.timeScale=1;
            pauseMenu.SetActive(false);
            EsPausado=false;
        }
    }
}
