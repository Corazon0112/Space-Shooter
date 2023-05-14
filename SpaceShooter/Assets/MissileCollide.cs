using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class MissileCollide : MonoBehaviour
{
    public Vector3 center, size;
    public GameObject p;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Flying Insect(Clone)")
        {
            if (gameObject.name == "Missile(Clone)")
            {
                Destroy(gameObject);
                score.text = Regex.Match(score.text, @"\d+").Value;
                score.text = "Score: " + (int)(Int32.Parse(score.text) + 10);
            }
            Vector3 pos = center + new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
            Destroy(collision.gameObject);
            GameObject c = Instantiate(p, pos, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
    }
}
