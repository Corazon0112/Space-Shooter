using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side : MonoBehaviour
{
    Rigidbody rb;
    Vector3 force;
    float xVal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xVal = gameObject.transform.position.x;
        switch (xVal)
        {
            case -5f:
                force = Vector3.right;
                break;
            case 5f:
                force = Vector3.left;
                break;
        }
        if (gameObject.transform.position.y <= 1.5)
        {
            rb = gameObject.GetComponent<Rigidbody>();
            if (xVal==5f||xVal==-5f)
            {
                rb.AddForce(force * 15);
            }             
        }
    }
}
