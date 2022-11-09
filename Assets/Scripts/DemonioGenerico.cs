using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonioGenerico : MonoBehaviour
{
    public int rutina;
    public float crono;
    public Animator ani;
    public int direccion;
    public float veloc_cami;
    public float veloc_corriendo;
    public GameObject target;
    public bool atacando;
    public float vida;



    // Start is called before the first frame update
    void Start()
    {
      ani= GetComponent<Animator>();
      target= GameObject.Find("Dante");
    }

    public void Comportamientos ()
    {
        ani.SetBool("cami", false);
        crono+= 1 * Time.deltaTime;
        if (crono >= 4)
        {
            rutina = Random.Range(0, 1);
            crono=0;
        }
        switch (rutina)
        {
            case 0:
                    ani.SetBool("cami", false);
                    break;
            case 1:
                    direccion = Random.Range(0, 2);
                    rutina++;
                    break;
            case 2:
                switch (direccion)
                    {
                        case 0:
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.right * veloc_cami * Time.deltaTime);
                            break;

                        case 1:
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                            transform.Translate(Vector3.right * veloc_cami * Time.deltaTime);
                            break;
                    }
                ani.SetBool("cami",true);
                break;
        }

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

    // Update is called once per frame
    void Update()
    {
       Comportamientos(); 
    }
}
