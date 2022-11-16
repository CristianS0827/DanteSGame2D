using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform PuntoA;
    public Transform PuntoB;
    public Transform ControladorSuelo;
    public Transform ControladorPared;
    public Transform ControladorPresi;
    public LayerMask WiPiso;

    Rigidbody2D rb;
    Animator ani;
    public float velocidad;
    
    public bool Estatico;
    public bool Patruyando;
    public bool Caminando;
    public bool moviendoDerecha;
    public bool DebeEsp;
    private bool EstaEsp;
    public bool HayPared;
    public bool HaySuelo;
    public bool HayPresi;
    public bool IrA;
    public bool IrB;

    public float RadioDeteccion;
    public float TiempoEsp;



    // Start is called before the first frame update
    void Start()
    {
        IrA=true;
        moviendoDerecha=true;
        velocidad= GetComponent<Enemy>().velocidad;
        rb= GetComponent<Rigidbody2D>();
        ani= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HayPresi=!Physics2D.OverlapCircle(ControladorPresi.position,RadioDeteccion,WiPiso);
        HayPared=Physics2D.OverlapCircle(ControladorPared.position,RadioDeteccion,WiPiso);
        HaySuelo=Physics2D.OverlapCircle(ControladorSuelo.position,RadioDeteccion,WiPiso);
        if(HayPresi|| HayPared && HaySuelo)
        {
            Girar();
        }
        
    }
    private void FixedUpdate() 
    {
      {
        if(Estatico)
        {
            ani.SetBool("Idle",true);
            rb.constraints=RigidbodyConstraints2D.FreezeAll;
        }
        if(Caminando)
        {
            rb.constraints=RigidbodyConstraints2D.FreezeRotation;
            ani.SetBool("Idle",false);
            if(!moviendoDerecha)
            {
                rb.velocity=new Vector2(-velocidad, rb.velocity.y);
            }else
            {
                rb.velocity=new Vector2(velocidad, rb.velocity.y);
            }
        }
        if(Patruyando)
       {
        if(IrA)
        {
            if(!EstaEsp)
            {
                ani.SetBool("Idle",false);
                rb.velocity=new Vector2(velocidad, rb.velocity.y);
            }
            
            if(Vector2.Distance(transform.position,PuntoA.position)<0.2f)
            {
                if(DebeEsp)
                {
                    StartCoroutine(Esperar());
                }

                Girar();
                IrA=false;
                IrB=true;
            }
        }
        if(IrB)
        {
            if(!EstaEsp)
            {
                ani.SetBool("Idle",false);
                rb.velocity=new Vector2(-velocidad, rb.velocity.y);
            }
            
            if(Vector2.Distance(transform.position,PuntoB.position)<0.2f)
            {
                if(DebeEsp)
                {
                    StartCoroutine(Esperar());
                }

                Girar();
                IrA=true;
                IrB=false;
            }
        }
      }
        
    }  
     
    }
    IEnumerator Esperar()
    {
        ani.SetBool("Idle",true);
        EstaEsp=true;
        Girar();
        yield return new WaitForSeconds(TiempoEsp);
        EstaEsp=false;
        ani.SetBool("Idle",false);
        Girar();
    }
    private void Girar()
    {
         moviendoDerecha = !moviendoDerecha;
        //  transform.eulerAngles= new Vector3(0, transform.eulerAngles.y+180,0);
        //  velocidad*= -1;
          transform.localScale*= new Vector2(-1,transform.localScale.y);
    }
}
