using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DanteMovimiento : MonoBehaviour
{
    public float Velocidad;
    public float FuerzaSalto;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    public bool PisandoSuelo;
    public Transform Check;
    public float RadioChecker;
    public LayerMask WiPiso;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D= GetComponent<Rigidbody2D>();
        Animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      // Attack();
      Horizontal = Input.GetAxisRaw("Horizontal"); 
      if (Horizontal<0.0f) transform.localScale= new Vector3(-0.3333f,0.3333f,0.3333f);
      else if(Horizontal>0.0f) transform.localScale = new Vector3(0.3333f,0.3333f,0.3333f);
      Animator.SetBool("Corriendo",Horizontal != 0.0f);
      PisandoSuelo= Physics2D.OverlapCircle(Check.position, RadioChecker,WiPiso);
      if (Input.GetKeyDown(KeyCode.W) && PisandoSuelo==true)
      {
        Jump();
      }
      
    }
    //  public void Attack()
    //   {
    //    if(Input.GetButtonDown("Fire1"))
    //    {
    //      Animator.SetBool("Att",true);
    //    }else
    //    {
    //      Animator.SetBool("Att",false);
    //    }
    //   }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up*FuerzaSalto);
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity= new Vector2(Horizontal*Velocidad, Rigidbody2D.velocity.y);
    }
    
    
    }

     



   
