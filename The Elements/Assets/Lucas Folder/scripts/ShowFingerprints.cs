using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFingerprints : MonoBehaviour
{
    public GameObject Flashlight;
    public GameObject Fingerprint;
    public GameObject Light;
    public int distance;
    protected Vector3 flashlightPos;
    protected Vector3 fingerprintPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fingerprintPos = new Vector3(Fingerprint.transform.position.x, Fingerprint.transform.position.y, Fingerprint.transform.position.z);
        flashlightPos = new Vector3(Flashlight.transform.position.x, Flashlight.transform.position.y, Flashlight.transform.position.z);
       // Debug.Log("fingerpos: " + fingerprintPos + "\n");
       // Debug.Log("flashpos: " + flashlightPos + "\n");
        if (Vector3.Distance(fingerprintPos, flashlightPos) <= distance)
        {
            if (Light.gameObject.GetComponent<Light>().enabled == false)
            {


                if (Flashlight.gameObject.GetComponent<Light>().enabled == true)
                {
                    Fingerprint.gameObject.GetComponent<SpriteRenderer>().enabled = true;

                }else
                    Fingerprint.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else
            Fingerprint.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    

}
