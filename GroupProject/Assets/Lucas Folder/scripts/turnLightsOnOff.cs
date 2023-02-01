using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnLightsOnOff : MonoBehaviour
{
    public GameObject Light;
    public GameObject lightswitch;
    public GameObject playr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if lightswitch collider collides with player collieder
        if (lightswitch.gameObject.GetComponent<BoxCollider>().bounds.Intersects(playr.gameObject.GetComponent<CapsuleCollider>().bounds)) 
        {

            if (Input.GetKeyDown(KeyCode.E)) //if E is pressed
            {
                if (Light.gameObject.GetComponent<Light>().enabled != false) // if light isnt 0
                {

                    Light.gameObject.GetComponent<Light>().enabled = false;
                }
                else
                {
                    Light.gameObject.GetComponent<Light>().enabled = true;
                }

            }
        }

        } 
    
}
