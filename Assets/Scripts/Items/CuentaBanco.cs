using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuentaBanco : MonoBehaviour
{
    public Text TextoBanco;
    public float banco;

    public static CuentaBanco instance;
    private void Awake() 
    {
       if(instance==null)
       {
        instance=this;
       } 
    }
        void Start()
    {
       TextoBanco.text="x "+banco.ToString(); 
    }
    public void Dinero(float DineroRecogido)
    {
        banco+=DineroRecogido;
        TextoBanco.text="x "+banco.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
