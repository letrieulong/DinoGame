using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawn : MonoBehaviour
{
    public float maxtime = 2f;
    float timer;
    public GameObject Cactus;
    public float speed;
    GameObject newcac;
    Rigidbody2D RB;
    bool isGrounded = false;
    public float JumForce;
    bool tree = true;
    Vector2 random;
    // Start is called before the first frame update
    public void Start()
    {
        RB = GetComponent<Rigidbody2D>(); // player
    }
    void Update()
    {  // create random item
        if (tree == true)
        {
            random = new Vector2(Random.Range(9f, 12f), -3.45f);

            timer += Time.deltaTime;

            if (timer > maxtime)
            {
                newcac = Instantiate(Cactus, random, transform.rotation);
                timer = 0;
                Destroy(newcac, 5f);
            }
            Destroy(newcac, 4f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        // if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) // bắt sự kiện màn hình cảm ứngcảm ứng
        {
            if (isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumForce);
                isGrounded = false;
            }
        }
        // Speed item
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGrounded == false)
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == ("tree"))
        {
            Time.timeScale = 0; // stop
        }
    }
}
