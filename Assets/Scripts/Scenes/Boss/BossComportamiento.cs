using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossComportamiento : MonoBehaviour
{
    public float tiempoDisparo;
    public float startTiempoDisparo;  
    public float countdown;
    public float tiempoCambioPos;
    public float countdownPos;
    public float bossVida;
    public float vidaActual;
    public Image barraVidaBoss;
    public Transform[] transforms;
    public GameObject GhostFlame;
    void Start()
    {
        startTiempoDisparo=tiempoDisparo;
    var posicionInicial= 1;
      transform.position=transforms[posicionInicial].position;
      countdown=tiempoDisparo;
      countdownPos=tiempoCambioPos;  
    }

    public void DisparoAJugador()
    {
        GameObject summon= Instantiate(GhostFlame,transform.position, Quaternion.identity);
        AudioManager.instance.PlayAudio(AudioManager.instance.summonJefe);
    }
    public void CambioDePosicion()
    {
      var posicionInicial= Random.Range(0, transforms.Length);
      transform.position=transforms[posicionInicial].position;
    }

    public void DañoBoss()
    {
        
        vidaActual=GetComponent<Enemy>().vida;
        barraVidaBoss.fillAmount=vidaActual/bossVida;
        if(vidaActual<=0)
        {
        AudioManager.instance.bkcgMBoss.Stop();
        AudioManager.instance.PlayAudio(AudioManager.instance.bckgMusica);   
        }

    }
    public void BossScale()
    {
        if(transform.position.x > DanteMovimiento.Instance.transform.position.x)
        {
            transform.localScale=new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale=new Vector3(1,1,1);   
        }
    }
    private void OnDestroy() 
    {
        BossUI.instance.DesactivarBoss();
    }
    
    public void CountDowns ()
    {       
        countdown -= Time.deltaTime;
        countdownPos-=Time.deltaTime;
        if(countdown<0)
        {
            DisparoAJugador();
            countdown=tiempoDisparo;
        }
        if(countdownPos<=0)
        {
            countdownPos=tiempoCambioPos;
            CambioDePosicion();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CountDowns();
        DañoBoss();
        BossScale();
    
    }
}
