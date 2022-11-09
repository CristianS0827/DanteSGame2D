using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     private float velocidad;
     public Transform ControladorSuelo;
     public float distancia;
     private bool moviendoDerecha;
    private Animator ani;
    public float vida;
    public string EnemyName;

    private Rigidbody2D Rigidbody2D;
    

    private void Start()
    {
       Rigidbody2D=GetComponent<Rigidbody2D>();

    }
    public void TomarDaño(float daño)
    {
        vida-= daño;
        if(vida<=0)
        {
            Muerte();
        }
    }
    private void Muerte()
    {
        ani.SetTrigger("Muerte");
    }


    private void Update()
    {
       RaycastHit2D informacionSuelo= Physics2D.Raycast(ControladorSuelo.position, Vector2.down, distancia);
       Rigidbody2D.velocity=new Vector2(velocidad,Rigidbody2D.velocity.y);

       if(informacionSuelo==false)
       {
        Girar();
       }
    }
    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles= new Vector3(0, transform.eulerAngles.y+180,0);
        velocidad*= -1;
    }

    private void OnDrawGizmos() {
        Gizmos.color= Color.red;
        Gizmos.DrawLine(ControladorSuelo.transform.position, ControladorSuelo.transform.position+Vector3.down*distancia);
    }

   
}