using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float JumForce;
    [SerializeField]
    bool isGrounded = false;
    public bool Playstart = false;
    Rigidbody2D RB;
    Touch touch;
    // Start is called before the first frame update
    public void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        //  if(Input.GetKeyDown(KeyCode.Space)) sự kiện nhấn phím
       // if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) // bắt sự kiện màn hình cảm ứngcảm ứng
       if (Playstart == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded == true)
                {
                    RB.AddForce(Vector2.up * JumForce);
                    isGrounded = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded == true)
                {
                    RB.AddForce(Vector2.up * JumForce);
                    isGrounded = false;
                }
            }
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGrounded == false)
        {
            isGrounded = true;
        }
    }
}