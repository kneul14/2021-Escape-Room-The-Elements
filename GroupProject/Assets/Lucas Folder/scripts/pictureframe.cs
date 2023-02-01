using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pictureframe : MonoBehaviour
{
    public GameObject frame;
    public GameObject playr;
    // Start is called before the first frame update
    void Start()
    {
        frame.gameObject.GetComponent<BoxCollider>().enabled = false;
        frame.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void OnTriggerStay()
    {
        if (frame.gameObject.GetComponent<CapsuleCollider>().bounds.Intersects(playr.gameObject.GetComponent<CapsuleCollider>().bounds))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                //make the object drop
                frame.gameObject.GetComponent<BoxCollider>().enabled = true;
                frame.gameObject.GetComponent<Rigidbody>().useGravity = true;

            }
        }
    }
}
