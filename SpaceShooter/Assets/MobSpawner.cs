using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobSpawner : MonoBehaviour
{
    public Vector3 center, size;
    public GameObject o;
    GameObject[] g = new GameObject[4];
    Rigidbody rb;
    private float time = 0.0f;
    int wave = 0;
    int xVal;
    bool first = true;
    int rounds = 0;
    public Text text;
    
    // Use this for initialization
    void Start()
    {

    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 12||first)
        {
            time = 0.0f;
            rounds++;
            text.text = "Wave " + rounds;
            text.CrossFadeAlpha(1000.0f, 2f, false);
            text.CrossFadeAlpha(0.0f, 2f, false);
            SpawnObject();
            first = false;
        }
        
    }
    public void SpawnObject()
    {
        switch (wave) {
            case 0: xVal = -5;
                    wave++;
                    break;
            case 1: xVal = 5;
                    wave++;
                    break;
            case 2: xVal = 0;
                    wave = 0;
                    break;
        }
        for (int i = 0; i < 5; i++)
        {
            Vector3 pos = center + new Vector3(xVal, transform.position.y+i*2, transform.position.z);
            GameObject c = Instantiate(o, pos, Quaternion.Euler(90, 180, 0)) as GameObject;
            rb = c.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.down * 100);
        }
    }
}
