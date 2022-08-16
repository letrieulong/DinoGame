using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSpeed : MonoBehaviour
{
    public Text myText;
    public Text myText1;
    public float timeStart;
    public float currenTime;
    public bool startTime;
    // Start is called before the first frame update
    void Start()
    {
        currenTime = timeStart * 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime == true)
        {
            currenTime += Time.deltaTime;
            myText.text = currenTime.ToString();
            if (currenTime > 10)
            {
                myText1.text = currenTime.ToString();
            }
            else
            {
                myText.text = currenTime.ToString();
            }
        }
    }   
}
