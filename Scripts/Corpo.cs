using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpo : MonoBehaviour
{
    public bool chosen;
    private bool playSound;
    public GameObject chapeu;
    public Material[] chapeuColor;

    public GameObject colete;
    public Material[] coleteColor;
    public bool hasChapeu;

    public Animator an;

    public AudioSource audioSource;

    public bool isVozGrave;

    public AudioClip[] vozGrave;
    public AudioClip[] vozAguda;


    // Start is called before the first frame update
    void Start()
    {
        //chosen = false;
        playSound = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateChapeu(int i)
    {
        if (hasChapeu)
        {
            chapeu.SetActive(true);
            chapeu.GetComponent<MeshRenderer>().material = chapeuColor[i];
        }
        else
        {
            chapeu.SetActive(false);
        }
    }

    public void UpdateColete(int i)
    {
        colete.GetComponent<SkinnedMeshRenderer>().material = coleteColor[i];
        Debug.Log(i);
        Debug.Log("UpdateColete");
    }

    public void UpdateVoz(bool isVozGrave)
    {
        int rand = Random.Range(0, vozGrave.Length);
        if (isVozGrave)
        {
            audioSource.clip = vozGrave[rand];
        }
        else
        {
            audioSource.clip = vozAguda[rand];
        }
    }

    public void RandomUpdateChapeu()
    {
        int rand = Random.Range(0, 3);
        if (rand >= 2)
        {
            hasChapeu = false;
        }
        else
        {
            hasChapeu = true;
        }

        if (hasChapeu)
        {
            int rand2 = Random.Range(0, 3);
            chapeu.GetComponent<MeshRenderer>().material = chapeuColor[rand2];
        }
        else
        {
            chapeu.SetActive(false);
        }
    }

    public void RandomUpdateColete()
    {
        int rand = Random.Range(0, 3);
        //materials[1] = coleteColor[0];
        colete.GetComponent<SkinnedMeshRenderer>().material = chapeuColor[rand];

    }

    public void RandomUpdateVoz()
    {
        int rand = Random.Range(0, 3);
        if (rand >= 2)
        {
            isVozGrave = false;
        }
        else
        {
            isVozGrave = true;
        }

        int rand2 = Random.Range(0, vozGrave.Length);
        if (isVozGrave)
        {
            audioSource.clip = vozGrave[rand2];
        }
        else
        {
            audioSource.clip = vozAguda[rand2];
        }
    }

    public void StepForward()
    {
        an.SetTrigger("Step_Forward");
        Invoke("Speak", 0.3f);
        playSound = true;
    }

    public void StepBack()
    {
        an.SetTrigger("Step_Back");
    }

    public void Speak()
    {
        if (playSound)
        {
            audioSource.PlayOneShot(audioSource.clip);
            playSound = false;
        }

    }
}
