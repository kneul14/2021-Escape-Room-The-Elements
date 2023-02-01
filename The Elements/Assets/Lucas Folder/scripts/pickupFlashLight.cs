using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupFlashLight : MonoBehaviour
{
    public GameObject playr;
    public GameObject flashlight;
    Vector3 initialPosition;
    Vector3 initialCameraPosition;
    GameObject Camera;
    Quaternion rotation;
    bool isE = true;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = flashlight.gameObject.transform.position;
        rotation = flashlight.transform.rotation;
        Camera = playr.transform.GetChild(0).gameObject;
        initialCameraPosition = new Vector3(Camera.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (flashlight.gameObject.GetComponent<CapsuleCollider>().bounds.Intersects(playr.gameObject.GetComponent<CapsuleCollider>().bounds))
        {
            if (Input.GetKeyDown(KeyCode.E) && isE == true)
            {

                flashlight.gameObject.GetComponent<BoxCollider>().enabled = false;
                flashlight.transform.SetParent(Camera.transform);
                flashlight.gameObject.GetComponent<Rigidbody>().useGravity = false;
                flashlight.transform.localPosition = new Vector3(0.25f, -0.14f, 0.5f);
                flashlight.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                
            }

        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            flashlight.gameObject.GetComponent<BoxCollider>().enabled = true;
            flashlight.gameObject.GetComponent<Rigidbody>().useGravity = true;
            flashlight.transform.SetParent(null);
            StartCoroutine(ExampleCoroutine());


        }
        if (!Camera.transform.Find(flashlight.gameObject.name))
        {
            //Debug.Log("not sun");
            flashlight.gameObject.GetComponent<BoxCollider>().enabled = true;
            flashlight.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
        if(Camera.transform.Find(flashlight.gameObject.name))
        {
            flashlight.gameObject.GetComponent<BoxCollider>().enabled = false;
            flashlight.transform.SetParent(Camera.transform);
            flashlight.gameObject.GetComponent<Rigidbody>().useGravity = false;
            flashlight.transform.localPosition = new Vector3(0.25f, -0.14f, 0.5f);
            flashlight.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

    }
    IEnumerator ExampleCoroutine()
    {
        isE = false;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.5f);
        isE = true;
    }
}