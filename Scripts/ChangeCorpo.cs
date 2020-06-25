using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCorpo : MonoBehaviour
{
    public PerpsManager perpsManager;
    public Dialogo dialogo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickOne(Corpo corpo)
    {


        corpo.chosen = true; //Substituir pelas variaveis de dialogo

        corpo.hasChapeu = false;

        corpo.RandomUpdateChapeu();


    }
}
