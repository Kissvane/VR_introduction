using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrPointer : MonoBehaviour
{
    public LineRenderer LineRenderer;
    [SerializeField]
    private float PointerLength = 100f;
    public Transform Hand;

    //HOVER MANAGEMENT
    [HideInInspector]
    public GameObject Hovered;
    [HideInInspector]
    public GameObject LastHovered;

    public Material HoveredMaterial;
    Material OriginalMaterial;

    public LayerMask LayerMask;

    // Start is called before the first frame update
    void Awake()
    {
        Hand = transform; 
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Hand.position, Hand.forward);
        RaycastHit hit;
        
        
        if (Physics.Raycast(ray, out hit,PointerLength, LayerMask))
        {
            LineRenderer.enabled = true;
            LineRenderer.SetPosition(0, Hand.position);
            LineRenderer.SetPosition(1, hit.point);
            Hovered = hit.collider.gameObject;
            HoverOut();

            //HOVER IN
            if (Hovered != LastHovered)
            {
                //STOCKER le materiel original
                OriginalMaterial = Hovered.GetComponent<Renderer>().material;
                //appliquer le highlight
                Hovered.GetComponent<Renderer>().material = HoveredMaterial;
            }
        }
        else
        {
            Hovered = null;

            HoverOut();
            LineRenderer.enabled = false;
            //LineRenderer.SetPosition(1, Hand.position + Hand.forward * PointerLength);
        }

        LastHovered = Hovered;
    }

    void HoverOut()
    {
        //HOVER OUT
        if (LastHovered != null && Hovered != LastHovered)
        {
            //appliquer le material original à l'objet
            LastHovered.GetComponent<Renderer>().material = OriginalMaterial;
            OriginalMaterial = null;
        }
    }
}
