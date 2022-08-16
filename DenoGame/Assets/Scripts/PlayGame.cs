using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    /*
     * Timer
     */
    public Text myTextStart;
    public Text myTextEnd;
    public float timeStart;
    public float currenTime;

    /*
     * Player
     */
    public float JumForce; // nhảy
    [SerializeField]
    bool isGrounded = false;
    public bool Playstart = false; // bắt trạng thái play
    Rigidbody2D RB; // đối tượng

    /*
     * SpeedItem
     */
    public float speed;

    //item
    public float maxtime;
    float timer;
    public GameObject Cactus;
    float timerbird;
    public GameObject CactusBird;
    GameObject newcac;
    GameObject newcacBird;

    // true false
    bool brid = false;
    bool Spawn = false;
    bool pause = true;
    bool startTime;

    // Start is called before the first frame update
    public void Start()
    {
        RB = GetComponent<Rigidbody2D>(); // player
    }

    // Update is called once per frame
    void Update()
    {
        // create random item
        if (Spawn == false)
        {
            // vị trí đối tượng
            Vector2 random = new Vector2(Random.Range(9f, 12f), -3.45f);
            // thời gian phát sinh
            timer += Time.deltaTime;

            if (timer > maxtime)
            {
                timer = 0;
                // đối tượng được sinh ra
                newcac = Instantiate(Cactus, random, transform.rotation);
                // xóa đối tượng
                Destroy(newcac, 5f);
            }
            Destroy(newcac, 4f);
        }

        // bird
        if (brid == true)
        {
            Vector2 randombird = new Vector2(Random.Range(9f, 12f), -2.5f);

            timerbird += Time.deltaTime;

            if (timerbird > 7)
            {
                timerbird = 0;
                newcacBird = Instantiate(CactusBird, randombird, transform.rotation);
                Destroy(newcacBird, 5f);
            }
            Destroy(newcacBird, 4f);
        }

        // thời gian bắt đầu và kết thức
        if (startTime == true)
        {
            currenTime += Time.deltaTime;
            myTextStart.text = currenTime.ToString();
            if (currenTime > 10)
            {
                myTextEnd.text = currenTime.ToString();
            }
            else
            {
                myTextStart.text = currenTime.ToString();
            }
        }


        // Player
        //  if(Input.GetKeyDown(KeyCode.Space)) sự kiện nhấn phím
        if (Playstart == true)
        {
          //  if (Input.GetKeyDown(KeyCode.Space))
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) // bắt sự kiện màn hình cảm ứng
            {
                if (isGrounded == true)
                {
                    RB.AddForce(Vector2.up * JumForce);
                    isGrounded = false;
                }
            }
        }
        // Speed item
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    #region bắt đầu chạy
    public void Playgame()
    {
        startTime = true;
        Playstart = true;
        Spawn = true;
        brid = true;
    }
    #endregion

    public GameObject gameOver; // bắt sự kiện hide reload

    #region ReloadGame
    public void ReloadGame()
    {
        SceneManager.LoadScene("DinoGame"); // khởi tạo lại app
        Time.timeScale = 1; // start game
        gameOver.SetActive(false);
        startTime = false;
        Playstart = false;
        Spawn = false;
        brid = false;
    }
    #endregion

    #region Xử lý va chạm
    public GameObject gamePlay;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGrounded == false)
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {          
            gameOver.SetActive(true);   //dialog   
            Time.timeScale = 0; // pause game
        }

        if (collision.gameObject.tag == "Bird")
        {
            gameOver.SetActive(true); //dialog   
            Time.timeScale = 0; // pause game
        }
    }
    #endregion
}