using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloquinho : MonoBehaviour
{
    public Animator an;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Up()
    {
        an.SetTrigger("Up");
    }

    public void Down()
    {
        an.SetTrigger("Down");
    }
}
