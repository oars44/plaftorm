using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time_control : MonoBehaviour
{
    public Text timer;
    public float start_time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer.text = start_time.ToString("f0");
        start_time -= Time.deltaTime;

        if (start_time < 0)
        {
            Debug.Log("Time elapsed: Game Over!");
        }
    }
}