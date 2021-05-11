using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSorting : MonoBehaviour
{
    public Renderer Renderer;

    // Start is called before the first frame update
    void Awake()
    {
        Renderer = GetComponent<Renderer>();
        Renderer.sortingLayerID = 1;
        Renderer.sortingOrder = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
