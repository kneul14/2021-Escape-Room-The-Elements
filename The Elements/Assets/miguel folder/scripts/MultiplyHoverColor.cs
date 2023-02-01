using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyHoverColor : MonoBehaviour
{
    //this will store the initial material
    Material initMat;
    //the objects to turn red when looking at one
    public GameObject ObjectMultiplyedFrom;
    //the objects to turn red when looking at one
    public GameObject[] multiplyhover;
    //this will save the border material, used to paint objects hovered
    public Material Border;
    //this will store the old materials
    public Material[] oldMaterials;
    // Start is called before the first frame update
    void Start()
    {
        initMat = ObjectMultiplyedFrom.gameObject.GetComponent<MeshRenderer>().material;


    }

    // Update is called once per frame
    void Update()
    {
        //if the object is red
        if (ObjectMultiplyedFrom.gameObject.GetComponent<MeshRenderer>().material!= initMat)
        {
            //for all objects to multiply
            for(int i = 0; i<multiplyhover.Length; i++)
            {
                //change the material to the red one
                multiplyhover[i].gameObject.GetComponent<MeshRenderer>().material = Border;
            }
        }
        else 
        {
            //for all objects to multipluy
            for (int i = 0; i < multiplyhover.Length; i++)
            {
                multiplyhover[i].gameObject.GetComponent<MeshRenderer>().material = oldMaterials[i];
            }
        }
    }
}
