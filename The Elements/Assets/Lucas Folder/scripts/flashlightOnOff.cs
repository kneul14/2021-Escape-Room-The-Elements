using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightOnOff : MonoBehaviour
{
    public GameObject playr;
    public GameObject flashlight;
   
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        //if flashlight collides with player
        if (flashlight.gameObject.GetComponent<CapsuleCollider>().bounds.Intersects(playr.gameObject.GetComponent<CapsuleCollider>().bounds))
        {
            //if flashlight is child of player
            if (flashlight.gameObject.GetComponent<CapsuleCollider>().transform.IsChildOf(playr.transform))
            {
                //if player presses left mouse button

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    //if flashlight isnt on
                    if (flashlight.gameObject.GetComponent<Light>().enabled != true)
                    {
                        flashlight.gameObject.GetComponent<Light>().enabled = true;
                    } else
                    {
                        flashlight.gameObject.GetComponent<Light>().enabled = false;
                    }


                }
            }

        }
    }
}
