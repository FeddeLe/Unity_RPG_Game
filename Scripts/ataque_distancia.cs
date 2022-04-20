using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataque_distancia : MonoBehaviour
{
    public float waitBeforeDestroy;

    [HideInInspector]
    public Vector2 mov;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(mov.x, mov.y, 0) * speed * Time.deltaTime;
    }

    IEnumerator OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "env_object")
        {
            yield return new WaitForSeconds(waitBeforeDestroy);
            Destroy(gameObject);
        }
        else if(other.tag != "Player" && other.tag != "Ataque")
        {
            Destroy(gameObject);
        }
    }
}
