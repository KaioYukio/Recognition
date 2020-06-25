using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerpsManager : MonoBehaviour
{
    public GameObject[] perp; //Quais criminosos podem ser escolhidos 4 no maximo

    public Dialogo dialogo;

    public int level;
    public int numOfPerps;

    public List<Transform> posPerps = new List<Transform>();


    public List<Transform> pos = new List<Transform>();

    public List<Corpo> corpoList = new List<Corpo>();



    // Start is called before the first frame update
    void Start()
    {
        //SpawnPerps();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPerps()
    {
        pos.Clear();
        corpoList.Clear();

        posPerps[level].gameObject.SetActive(true);

        for (int i = 0; i < posPerps[level].childCount; i++)
        {
            pos.Add(posPerps[level].GetChild(i));

            int rand2 = Random.Range(0, perp.Length); //Randomiza a escolha dos criminosos

            GameObject go = Instantiate(perp[rand2], pos[i].position, Quaternion.Euler(0, 180 ,0)); // Intancia o criminoso randomizado
            go.transform.position = pos[i].position;
            GameObject child = go.transform.GetChild(0).gameObject;

            child.transform.position = pos[i].position;
            child.transform.rotation = Quaternion.Euler(0, 180, 0);

            corpoList.Add(child.GetComponent<Corpo>());
            ScramblePerp(corpoList[i]);
        }

        int rand = Random.Range(0, corpoList.Count);

        PickOne(corpoList[rand]);
        
    }

    public void PickOne(Corpo corpo)
    {
        //Spawna o PERP com a personalidade desejada pelo DIALOGO
        GameObject corpoReplace = Instantiate(perp[dialogo.perpIndex], corpo.transform.position, corpo.transform.rotation);

        corpoList.Remove(corpo);
        Destroy(corpo.gameObject);

        //Troca o PERP antigo pelo novo

        Corpo corpo2 = corpoReplace.transform.GetChild(0).GetComponent<Corpo>();

        corpoList.Add(corpo2); 




        corpo2.chosen = true;

        corpo2.hasChapeu = dialogo.hasChapeu;

        corpo2.UpdateChapeu(dialogo.colorChapeu);
        corpo2.UpdateColete(dialogo.colorColete);
        corpo2.UpdateVoz(dialogo.vozGrave);

        for (int i = 0; i < posPerps[level].childCount; i++)
        {
            if (!corpoList[i].chosen)
            {
                while (corpoList[i].hasChapeu && corpo2.hasChapeu && corpoList[i].chapeuColor == corpo2.chapeuColor && corpoList[i].coleteColor == corpo2.coleteColor && corpoList[i].isVozGrave && corpo2.isVozGrave)
                {
                    ScramblePerp(corpoList[i]);
                }
            }
            
        }

    }

    public void ScramblePerp(Corpo corpo)
    {
        if (!corpo.chosen)
        {
            corpo.RandomUpdateChapeu();
            corpo.RandomUpdateColete();
            corpo.RandomUpdateVoz();
        }
    }

    public void WipeLevel()
    {
        GameObject[] garbage = GameObject.FindGameObjectsWithTag("Perp");

        int temp = posPerps[level].childCount;
        for (int i = 0; i < garbage.Length; i++)
        {
            Destroy(garbage[i].gameObject);
        }


        pos.Clear();
        corpoList.Clear();



    }
}
