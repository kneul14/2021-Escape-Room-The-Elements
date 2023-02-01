using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableKeyCollider : MonoBehaviour
{
    public Interaction interactionInstance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionInstance.GetComponent<Interaction>().leverPressed != false)
        {
            DestroyComponent();
        }
    }

    void DestroyComponent()
    {
        // Removes the rigidbody from the game object
        Destroy(GetComponent<BoxCollider>());
    }

}
