using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpeed : MonoBehaviour
{
    Vector2 random;
    bool brid = false;
    float timer;
    GameObject newcac;
    public float maxtime = 0f;
    public GameObject Cactus;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // create random item
        if (brid == true)
        {
            random = new Vector2(Random.Range(9f, 12f), -3.45f);

            timer += Time.deltaTime;

            if (timer > maxtime)
            {
                timer = 0;
                newcac = Instantiate(Cactus, random, transform.rotation);
                Destroy(newcac, 5f);
            }
            Destroy(newcac, 4f);
        }
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}
