using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fix_depth : MonoBehaviour
{
    public bool fixEveryFrame;
    SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.sortingLayerName = "Adelante";
        spr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
    }

    // Update is called once per frame
    void Update()
    {
        if(fixEveryFrame)
        {
            spr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
        }
    }
}
