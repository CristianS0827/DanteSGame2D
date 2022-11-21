using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float vida;
    public float kbForceX;
    public float kbForceY;
    public float DamageToGive;
    public float velocidad;
    public string EnemyName;
    
    private Animator animator;
    public CombateCC posG;
    private Rigidbody2D rb;


    [SerializeField] public bool esDañado;
    [SerializeField] SpriteRenderer sprite;
    Blink material;
    public static Enemy instance;
        private void Awake() 
        {
        if(instance==null)
        {
            instance=this;
        }
    }

    private void Start()
    {
        animator=GetComponent<Animator>();
        material= GetComponent<Blink>();
        sprite= GetComponent<SpriteRenderer>();
        rb=GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {if(collision.CompareTag("Arma"))
    {
        if(!esDañado)
        vida -= 30;
        AudioManager.instance.PlayAudio(AudioManager.instance.dañoEnemigo);
        StartCoroutine(Damager());
    }
        
    }

     public void TomarDaño(float daño, float DirGolpe)
    {
        if(!esDañado)
        vida -= daño;
        AudioManager.instance.PlayAudio(AudioManager.instance.dañoEnemigo);
        if(DirGolpe<transform.position.x)
        {
            rb.AddForce(new Vector2(kbForceX,kbForceY), ForceMode2D.Force);
        }else
        {
            rb.AddForce(new Vector2(-kbForceX,kbForceY), ForceMode2D.Force);
        }
        StartCoroutine(Damager());
        // Muerte();
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
        if(vida<=0)
        {
            animator.SetTrigger("Death");
            Destroy(gameObject, (float)0.3);
            AudioManager.instance.PlayAudio(AudioManager.instance.muerteEnemigo);
        }
    }

        
        


    private void FixedUpdate() 
    {
        Muerte();
    }
       
}
