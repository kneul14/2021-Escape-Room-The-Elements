using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDrag : MonoBehaviour
{
    private Vector3 mOffset;

    public float rotX, rotY, rotZ;

    private float mZCoord;
    private Rigidbody rb;

    public GameObject OutOfBounds;

    private bool drop=false;
    private bool mouse_down = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
  
    }

    
    

    void OnMouseDown()
    {
       
        mouse_down = true;
        if(drop == false)
        {
            mZCoord = Camera.main.WorldToScreenPoint(

            gameObject.transform.position).z;



            // Store offset = gameobject world pos - mouse world pos

            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        }
        

    }
   
    void OnMouseUp()
    {

       
        mouse_down = false;
        drop = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.freezeRotation = false;
    }


    private Vector3 GetMouseAsWorldPoint()

    {
     

            // Pixel coordinates of mouse (x,y)

            Vector3 mousePoint = Input.mousePosition;



            // z coordinate of game object on screen

            mousePoint.z = mZCoord;



            // Convert it to world points

            
        
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnCollisionEnter(Collision collision)
    {
       
       
           // Debug.Log("ENTer");
            drop = true;
        
        

    }

    void OnTriggerEnter(Collider other)
    {
        

        // Debug.Log("ENTer");
        drop = true;
    }

    void OnCollisionExit(Collision collision)
    {
       
            //Debug.Log("exit");
            drop = false;
        
    }

    void OnMouseDrag()
    {
        if (Input.GetMouseButtonDown(1))
        {
            
            transform.eulerAngles = new Vector3(rotX, rotY, rotZ);
        }
        //mouse_down = true;
        if (drop == false)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            rb.freezeRotation = true;
            //transform.position = GetMouseAsWorldPoint() + mOffset;
            rb.MovePosition(GetMouseAsWorldPoint() + mOffset);
        }
    }

}
