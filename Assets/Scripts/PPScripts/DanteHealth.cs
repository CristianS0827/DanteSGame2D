using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DanteHealth : MonoBehaviour
{
    public float VidaPP;
    public float maxVidaPP;
    public Image VidaImage;

    public bool EsInmune;
    public float TiempoInmu;
    SpriteRenderer sprite;
    Blink material;
    public float kbForceX;
    public float kbForceY;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        material= GetComponent<Blink>();
        sprite= GetComponent<SpriteRenderer>();
        
        VidaPP=maxVidaPP;
    }

    // Update is called once per frame
    void Update()
    {
        VidaImage.fillAmount=VidaPP/200;
        if(VidaPP>maxVidaPP)
        {
            VidaPP=maxVidaPP;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Enemy")&& !EsInmune)
        {
            VidaPP -= collision.GetComponent<Enemy>().DamageToGive;
            StartCoroutine(Inmunity());
            AudioManager.instance.PlayAudio(AudioManager.instance.dañoPP);
            if(collision.transform.position.x > transform.position.x)
            {
                rb.AddForce(new Vector2 (-kbForceX, kbForceY),ForceMode2D.Force);
            }else
            {
                rb.AddForce(new Vector2 (kbForceX, kbForceY),ForceMode2D.Force);
            }
            if(VidaPP <=0)
            {
                print("player dead");
            }
        }
        IEnumerator Inmunity()
        {
            EsInmune=true;
            sprite.material=material.blink;
            yield return new WaitForSeconds(TiempoInmu);
            sprite.material=material.original;
            EsInmune=false;
        }
    }
}
