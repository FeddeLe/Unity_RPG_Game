using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasd : MonoBehaviour
{
public float speed = 6f;
Vector2 mov;
Rigidbody2D rb2d;
Animator animacionPlayer;
CircleCollider2D attackCollider;
public GameObject ataqueDistanciaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animacionPlayer = GetComponent<Animator>();
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        mov = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

     void FixedUpdate() 
    {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
        animacionPlayer.SetFloat("movX", mov.x);
        animacionPlayer.SetFloat("movY", mov.y);

        //Se detecta movimiento en alguno de los dos ejes o en ambos
        if(mov != Vector2.zero)
        {
            animacionPlayer.SetBool("cambio_estado", true);
            attackCollider.offset = new Vector2(mov.x/2, mov.y/2);
        }
        else
        {
            animacionPlayer.SetBool("cambio_estado", false);
        }
        //Se detecta que apreto la tecla p, disparo el trigger atacando dentro del animator
        if(Input.GetKeyDown("p"))
        {
            animacionPlayer.SetTrigger("atacando");
        }
        AnimatorStateInfo stateInfo = animacionPlayer.GetCurrentAnimatorStateInfo(0);
        bool atacando = stateInfo.IsName("atacar");
        bool cargandoAtaque = stateInfo.IsName("ataque_distancia");

        if (Input.GetKeyDown("o"))
        {
            animacionPlayer.SetTrigger("cargando_ataque");
        }
        else if(Input.GetKeyUp("o"))
        {
            animacionPlayer.SetTrigger("atacando");
            float angle = Mathf.Atan2(animacionPlayer.GetFloat("movY"), animacionPlayer.GetFloat("movX")) * Mathf.Rad2Deg;

            GameObject heartAttack = Instantiate(ataqueDistanciaPrefab, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));

            ataque_distancia disparo = heartAttack.GetComponent<ataque_distancia>();
            disparo.mov.x = animacionPlayer.GetFloat("movX");
            disparo.mov.y = animacionPlayer.GetFloat("movY");
        }

        if(atacando)
        {
            float playbackTime = stateInfo.normalizedTime;
            if(playbackTime > 0.33 && playbackTime < 0.66)
            {
                attackCollider.enabled = true;
            }
            else
            {
                attackCollider.enabled = false;
            }
        }
        if (cargandoAtaque)
        {
            mov = Vector2.zero;
        }
    }
}
