using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject SettingDeactive;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene= SceneManager.GetActiveScene();
        if(scene.name=="MainMenuM")
        {
            AudioManager.instance.bckgMusica.Stop();
            AudioManager.instance.PlayAudio(AudioManager.instance.mainMenu);
        }
        Time.timeScale=1;
        SettingDeactive.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
        print("Game Closed");
    }
    public void ActivarSettins()
    {
        SettingDeactive.SetActive(true);
    }
    public void CerrarSettings()
    {
        SettingDeactive.SetActive(false);        
    }
    public void IrMainMenu()
    {
        SceneManager.LoadScene(0);   
    }
    
}
