using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCode : MonoBehaviour
{
    public GameObject playr;
    public GameObject canvas;
    public GameObject digit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (digit.gameObject.GetComponent<BoxCollider>().bounds.Intersects(playr.gameObject.GetComponent<CapsuleCollider>().bounds)){
            if (Input.GetKeyDown(KeyCode.E)== true)
            {
                //Debug.Log("close");
                playr.gameObject.GetComponent<MonoBehaviour>().enabled = false;
                canvas.gameObject.active = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            if (Input.GetKeyDown(KeyCode.Escape) == true)
            {
                playr.gameObject.GetComponent<MonoBehaviour>().enabled = true;
                canvas.gameObject.active = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
