using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environment_destroy : MonoBehaviour
{
    public string destroyState;
    public float timeForDisable;
    Animator animacion;
    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
    }

    IEnumerator OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ataque")
        {
            animacion.Play(destroyState);
            yield return new WaitForSeconds(timeForDisable);

            foreach (Collider2D c in GetComponents<Collider2D>())
            {
                c.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animacion.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName(destroyState) && stateInfo.normalizedTime >= 1)
        {
            Destroy(gameObject);
        }
    }
}
