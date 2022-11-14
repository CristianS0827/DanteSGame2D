using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateCC : MonoBehaviour
{
    // Start is called before the first frame update

     public Transform ControladorGolpe;
    [SerializeField] public float radioGolpe;
    [SerializeField] public float dañoGolpe;
    [SerializeField] public bool esDañado;
    [SerializeField] private float tiempoEntreAtt;
    public float posGolpe;
    [SerializeField] private float tiempoSigAtt;
    private Animator animator;

     void Start()
    {
     animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(tiempoSigAtt>0){
            tiempoSigAtt-= Time.deltaTime;
        }
        if(Input.GetButton("Fire1")&& tiempoSigAtt<=0)
        {
            Golpe();
            tiempoSigAtt=tiempoEntreAtt;
        }
    }
    private void Golpe()
    {
        animator.SetTrigger("Attack");
        Collider2D[] objetos= Physics2D.OverlapCircleAll(ControladorGolpe.position, radioGolpe);
        posGolpe=ControladorGolpe.position.x;
                print(posGolpe);
        foreach (Collider2D colisionador in objetos)
        {
            if(colisionador.CompareTag("Enemy"))
            {
                colisionador.transform.GetComponent<Enemy>().TomarDaño(dañoGolpe,posGolpe);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(ControladorGolpe.position, radioGolpe);
    }
   

    // Update is called once per frame
    
}
