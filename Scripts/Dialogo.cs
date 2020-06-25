using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    public int perpIndex;

    public bool vozGrave;
    public int vozIndex;
    public bool hasChapeu;

    public int colorChapeu; // 0 = AMARELO / 1 = ROXO / 2 = VERDE / 3 = VERMELHO
    public int colorColete;

    public Text text;

    [TextAreaAttribute]
    public string textInput;

    public string[,] voz = new string[2,4];
    public string[] vozGraveString;
    public string[] vozAgudaString;

    public string[] amareloAdjetivo;
    public string[] roxoAdjetivo;
    public string[] verdeAdjetivo;
    public string[] vermelhoAdjetivo;

    private string[,] chapeu = new string[4,4];
    private string[,] colete = new string[4, 4];

    public string[] valentao;
    public string[] medroso;
    public string[] atrapalhado;
    public string[] inteligente;

    // Start is called before the first frame update
    void Start()
    {


        for (int i = 0; i <= 3; i++)
        {
            for (int j = 0; j <= 3; j++)
            {
                if (i == 0)
                {
                    chapeu[i, j] = amareloAdjetivo[j];
                    colete[i, j] = amareloAdjetivo[j];
                }
                else if (i ==1)
                {
                    chapeu[i, j] = roxoAdjetivo[j];
                    colete[i, j] = roxoAdjetivo[j];
                }
                else if (i == 2)
                {
                    chapeu[i, j] = verdeAdjetivo[j];
                    colete[i, j] = verdeAdjetivo[j];
                }
                else if (i == 3)
                {
                    chapeu[i,j] = vermelhoAdjetivo[j];
                    colete[i, j] = vermelhoAdjetivo[j];
                    Debug.Log("Teste");
                }

            }
        }

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j <= 3; j++)
            {
                if (i == 0)
                {
                    voz[i, j] = vozGraveString[j];
                }
                else
                {
                    voz[i, j] = vozAgudaString[j];
                }

            }
        }

        //GeneratePerpValues();

        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void GeneratePerpValues()
    {
        RandomColeteAndChapeuColor();
        int randVoiceString = Random.Range(0, 2);
        int randColeteColorString = Random.Range(0, 4);
        int randChapeuColorString = Random.Range(0,4);
        int randPersonalityString = Random.Range(0, 4);
        if (hasChapeu)
        {
            int rand = Random.Range(0, 2);
            if (rand == 1)
            {
                text.text = "The man that stole me had  " + PickVoice(randVoiceString) + " voice that i`ll never forget. His shirt had a " + colete[colorColete, randColeteColorString] + " color , while his hat was " + chapeu[colorChapeu, randChapeuColorString] + ". He seem kinda " + PickPersonality(randPersonalityString);
            }
            else
            {
                text.text = "It was a cold night. The man that robbed me wore a " + chapeu[colorChapeu, randChapeuColorString] + " Hat, a " + colete[colorColete, randColeteColorString] + " colored shirt and his voice was extremely" + PickVoice(randVoiceString) + " .He, for some reason, gave me a sensation of a " + PickPersonality(randPersonalityString) + " person.Sadly, that´s all I can remember.";
            }
        }
        else
        {
            int rand = Random.Range(0, 2);
            if (rand == 1)
            {
                text.text = "The man that stole me had  " + PickVoice(randVoiceString) + " voice that i`ll never forget. His shirt had a " + colete[colorColete, randColeteColorString] + " color. He seem kinda " + PickPersonality(randPersonalityString);
            }
            else
            {
                text.text = "It was a cold night. The man that robbed me wore a " + colete[colorColete, randColeteColorString] + " colored shirt and his voice was extremely " + PickVoice(randVoiceString) + " .He, for some reason, gave me a sensation of a " + PickPersonality(randPersonalityString) + " person.Sadly, that´s all I can remember.";
            }
        }

    }

    public string PickVoice(int rand)
    {
        vozIndex = Random.Range(0, 2);
        
        if (vozIndex == 0)
        {
            vozGrave = true;
        }
        else
        {
            vozGrave = false;
        }

       

        return voz[vozIndex, rand];
    }

    public void RandomColeteAndChapeuColor()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            hasChapeu = true;
            colorChapeu = Random.Range(0, 4);
        }
        else
        {
            hasChapeu = false;
        }

        colorColete = Random.Range(0, 4);

    }

    public string PickPersonality(int rand2)
    {
        perpIndex = Random.Range(0, 4);

        if (perpIndex == 0)
        {
            return valentao[rand2];
        }
        else if (perpIndex == 1)
        {
            return medroso[rand2];
        }
        else if (perpIndex == 2)
        {
            return inteligente[rand2];
        }
        else
        {
            return atrapalhado[rand2];
        }
    }
}
