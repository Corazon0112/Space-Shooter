using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tilt : MonoBehaviour
{
    public Vector3 center;
    public GameObject p;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)&&gameObject.transform.position.x<=10)
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * 10);
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, -60, 150 * Time.deltaTime);
            transform.eulerAngles = new Vector3(-90, angle, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && gameObject.transform.position.x>=-10)
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * 10);
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 60, 150 * Time.deltaTime);
            transform.eulerAngles = new Vector3(-90, angle, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && gameObject.transform.position.y <= 2.5)
        {
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 15);
        }
        if (Input.GetKey(KeyCode.DownArrow) && gameObject.transform.position.y >= -2.5)
        {
            gameObject.transform.Translate(-Vector3.forward * Time.deltaTime * 15);
        }
        if (!Input.anyKey)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 0, 100 * Time.deltaTime);
            transform.eulerAngles = new Vector3(-90, angle, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Flying Insect(Clone)")
        {
            if (gameObject.name == "Missile(Clone)")
                Destroy(gameObject);
            Vector3 pos = center + new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
            Destroy(collision.gameObject);
            GameObject c = Instantiate(p, pos, Quaternion.Euler(0, 0, 0)) as GameObject;
            SceneManager.LoadScene("GameOverScreen");
        }
    }
}
