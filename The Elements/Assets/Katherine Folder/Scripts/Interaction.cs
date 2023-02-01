using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public LayerMask CarboardBoxmask;
    public LayerMask KeyMask;
    public LayerMask LeverMask;
    public GameObject grabPosition;
    public static GameObject grabbedObject = null;
    
    //This is used to check what has been pressed
    public bool leverPressed = false;
    public bool hasKey;

    public LeverScript leverScriptInstance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Key" && this.transform.IsChildOf(grabPosition.transform))
        {
            hasKey = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2f, CarboardBoxmask))
                {
                    Debug.Log("picked up");
                    if (hit.collider.GetComponent<InteractiveObject>() != null)
                    {
                        hit.collider.GetComponent<InteractiveObject>().OnStartInteraction();
                        
                    }
                }
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2f, LeverMask))
                {
                    Debug.Log("Lever pulled");
                    if (hit.collider.GetComponent<InteractiveObject>() != null)
                    {
                        hit.collider.GetComponent<InteractiveObject>().OnStartInteraction();
                        
                        leverPressed = true;
                    }
                }
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2f, KeyMask))
                {                    
                    //Debug.Log("Key Picked up");
                    if (hit.collider.GetComponent<InteractiveObject>() != null)
                    {
                        hit.collider.GetComponent<InteractiveObject>().OnStartInteraction();
                                         
                    }
                   
                }
             
            }
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            if (grabbedObject != null)
            {
                grabbedObject.transform.parent = null;
                grabbedObject.GetComponent<InteractiveObject>().OnEndInteraction();
                grabbedObject = null;
            }
        }
    
        if (grabbedObject != null)
        {
            grabbedObject.transform.parent = grabPosition.transform;
            grabbedObject.transform.position = Vector3.Lerp(grabbedObject.transform.position, grabPosition.transform.position, Time.deltaTime * 10f);
            grabbedObject.transform.rotation = Quaternion.Slerp(grabbedObject.transform.rotation, grabPosition.transform.rotation, Time.deltaTime * 10f);
        }
    
    }
}

