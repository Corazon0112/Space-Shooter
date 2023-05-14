using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleLaunch : MonoBehaviour
{
    public GameObject ship;
    public GameObject missile;

    public GameObject spawn1;
    public GameObject spawn2;

    public GameObject particles;

    int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject v = null;
            if (a == 1)
            {
                v = Instantiate(missile, spawn1.transform.position, spawn1.transform.rotation, ship.transform);
                v.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
                v.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX;
                v.transform.position = new Vector3(v.transform.position.x, v.transform.position.y, 0);
                a = 0;
            }
            else
            {
                v = Instantiate(missile, spawn2.transform.position, spawn2.transform.rotation, ship.transform);
                v.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
                v.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX;
                v.transform.position = new Vector3(v.transform.position.x, v.transform.position.y, 0);
                a = 1;
            }
            v.transform.parent = null;
        }
        
    }
}
