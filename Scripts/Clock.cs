using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Animator an;


    public bool isTimeOver;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        isTimeOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        an.SetFloat("Speed", speed);
    }

    public void StartTime()
    {
        isTimeOver = false;
        an.SetTrigger("Start");
    }

    public void TimeOver()
    {
        isTimeOver = true;
    }

    public void Return()
    {
        an.Play("Relogio_Idle", -1, 0);
;    }
}
