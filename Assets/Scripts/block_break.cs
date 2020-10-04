using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class block_break : MonoBehaviour
{
    public Text Score;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        int score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = score.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "breakable")
        {
            score += 100;
            Destroy(collision.gameObject);
        }
    }
}
