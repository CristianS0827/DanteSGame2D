using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossComportamiento : MonoBehaviour
{
    public float tiempoDisparo; 
    public float countdown;
    public float tiempoCambioPos;
    public float countdownPos;
    public Transform[] transforms;
    public GameObject GhostFlame;
    void Start()
    {
      var posicionInicial= Random.Range(0, transforms.Length);
      transform.position=transforms[posicionInicial].position;  
    }

    public void disparoAJugador()
    {
        GameObject summon= Instantiate(GhostFlame,transform.position, Quaternion.identity);

    }
    public void cambioDePosicion()
    {
      var posicionInicial= Random.Range(0, transforms.Length);
      transform.position=transforms[posicionInicial].position;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown<0)
        {
            disparoAJugador();
            countdown=tiempoDisparo;
            cambioDePosicion();
        }
        
    }
}
