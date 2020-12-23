using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text timer;
    public float time = 180;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timer.text = time.ToString("0");

    }
}
