using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public bool canClick;
    public GameManager gameManager;
    public GameObject sprite;
    public GameObject howToPlay;
    public GameObject exit;

    public Animator riscoPlayAn;
    public Animator riscoHowAn;
    public Animator riscoQuitAn;

    // Start is called before the first frame update
    void Start()
    {
        canClick = true;
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if (Physics.Raycast(ray, out hit) && canClick)
        //{
        //    if (hit.transform.CompareTag("Start"))
        //    {
        //        sprite.transform.position = hit.transform.position;

        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            gameManager.StartGame();
        //            canClick = false;
        //        }
        //    }
        //    else if (hit.transform.CompareTag("HowTo"))
        //    {
        //        sprite.transform.position = hit.transform.position;

        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            HowToPlay();
        //            canClick = false;
        //        }

        //    }
        //    else if (hit.transform.CompareTag("Exit"))
        //    {
        //        sprite.transform.position = hit.transform.position;

        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            Exit();
        //            canClick = false;
        //        }

        //    }

        //}
        //else
        //{
        //    sprite.transform.position = new Vector3(0, 1000, 0);
        //}
    }

    public void StartGame()
    {
        gameManager.StartGame();
    }

    public void HowToPlay()
    {
        howToPlay.SetActive(true);
    }

    public void Exit()
    {
        exit.SetActive(true);
    }

    public void BackToMenu()
    {
        howToPlay.SetActive(false);
        exit.SetActive(false);
        canClick = true;
    }


    public void Quit()
    {
        Application.Quit();
    }


}
