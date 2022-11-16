using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrojables : MonoBehaviour
{
    public Text arrojablesText;
    public int cantidadArrojables;
    public static Arrojables instance;

    private void Awake() {
        if(instance==null)
        {
            instance=this;
        }
    }
        void Start()
    {
       arrojablesText.text="x "+cantidadArrojables.ToString(); 
    }



    public void Arrojable(int montoArrojable)
    {
        cantidadArrojables+= montoArrojable;
        arrojablesText.text="x "+cantidadArrojables.ToString(); 
    }
}
