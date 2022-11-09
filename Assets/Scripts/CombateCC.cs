using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateCC : MonoBehaviour
{
    public Transform ControladorAtt;
    public float radioGolpe;
    public float dañoGolpe;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Golpe();
        }
    }
    private void Golpe()
    {
        Collider2D[] objetos= Physics2D.OverlapCircleAll(ControladorAtt.position,radioGolpe);
        foreach (Collider2D colisionador in objetos)
        {
            // if(colisionador.CompareTag("Enemigo"))
            // {
            //     colisionador.transform.GetComponent<Enemies>().TomarDaño(dañoGolpe);
            // }   
        }
    }
    private void OnDrawGizmos(){
        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere(ControladorAtt.position,radioGolpe);
    }
    void Start()
    {
        
    }

    // Update is called once per frame

}