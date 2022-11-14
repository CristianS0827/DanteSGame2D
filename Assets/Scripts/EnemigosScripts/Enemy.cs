using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float velocidad;
    public Transform ControladorSuelo;
    public float distancia;
    
    private bool moviendoDerecha;
    private Animator animator;
    public float vida;
    public float kbForceX;
    public float kbForceY;
    public string EnemyName;
    public float DamageToGive;
    public float velocidadcorr;
    private Rigidbody2D rb;
    [SerializeField] public bool esDañado;
    [SerializeField] SpriteRenderer sprite;
    Blink material;
    public CombateCC posG;
    
    

    private void Start()
    {
        posG=GetComponent<CombateCC>();
        material= GetComponent<Blink>();
        sprite= GetComponent<SpriteRenderer>();
        rb=GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
    }
    public void TomarDaño(float daño)
    {
        if(!esDañado)
        {
        vida -= daño;
        if(posG.posGolpe.x>transform.position.x)
        {
        rb.AddForce(new Vector2(kbForceX,kbForceY), ForceMode2D.Force);
        }else
        rb.AddForce(new Vector2(kbForceX,kbForceY), ForceMode2D.Force);
        StartCoroutine(Damager());
        }
        if(vida<=0)
        {
            Muerte();
        }
    }
    IEnumerator Damager()
    {
        esDañado=true;
        sprite.material=material.blink;
        yield return new WaitForSeconds(0.5f);
        esDañado=false;
        sprite.material=material.original;
    }
    private void Muerte()
    {
        animator.SetTrigger("Muerte");
        Destroy(gameObject, (float)0.3);
    }


    private void Update()
    {
       RaycastHit2D informacionSuelo= Physics2D.Raycast(ControladorSuelo.position, Vector2.down, distancia);
       rb.velocity=new Vector2(velocidad,rb.velocity.y);

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