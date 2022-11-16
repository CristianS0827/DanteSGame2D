using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubArmas : MonoBehaviour
{
    public int cost;
    public GameObject dagas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UsarArmaSecond();
    }
    public void UsarArmaSecond()
    {
        if(Input.GetButtonDown("Fire2")&& cost<Arrojables.instance.cantidadArrojables+1)
        {
            Arrojables.instance.Arrojable(-cost);
            GameObject nArrojable=Instantiate(dagas, transform.position, Quaternion.Euler(0,0,-132));
            

            if(transform.localScale.x <0)
            {
                nArrojable.GetComponent<Rigidbody2D>().AddForce(new Vector2(-600f,0f),ForceMode2D.Force);
                nArrojable.transform.localScale=new Vector2(-1,-1);
            }else
            {
                nArrojable.GetComponent<Rigidbody2D>().AddForce(new Vector2(600f,0f),ForceMode2D.Force);
            }

        }
    }
}
