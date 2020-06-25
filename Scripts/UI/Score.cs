using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    public GameManager gameManager;
    private Text text;

    public bool isScore;

    public bool isHighScore;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isScore)
        {
            text.text = gameManager.pontos.ToString();
        }
        else
        {
            if (isHighScore)
            {
                text.text = gameManager.highScore.ToString();
            }
            else
            {
                text.text = gameManager.criminososPresos.ToString();
            }

        }

    }
}
