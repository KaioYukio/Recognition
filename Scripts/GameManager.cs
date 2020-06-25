using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator an;
    public Bloquinho bloquinho;
    public PerpsManager perpsManager;
    public Dialogo dialogo;
    public Clock clock;
    public GameObject mouseOver;

    public GameObject menu;
    public GameObject menuWin;
    public GameObject menuLoose;
    public GameObject credits;

    public Corpo perpSelected;

    public GameObject[] lightsLevel;

    public AudioSource audioSource;
    public AudioSource relogioAudioSource;
    public AudioClip criminosoComemoracao;
    public AudioClip criminosoTriste;
    public AudioClip vitoria;
    public AudioClip derrota;
    public AudioClip telefone;
    public AudioClip relogio;

    public bool canPlay;

    public bool startedGame;
    public bool counting;
    public float timeToStart;
    private float timer;

    public int pontos;
    public int criminososPresos;
    public int highScore;

    private float lastClick;
    public float clickTimer;

    // Start is called before the first frame update
    void Start()
    {
        mouseOver.SetActive(false);
        menuWin.SetActive(false);
        menuLoose.SetActive(false);
        highScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //StartGame();
        JogadorInput();

        if (counting)
        {
            timer += Time.deltaTime;

            if (timer >= timeToStart)
            {
                bloquinho.an.SetTrigger("Down");
                clock.StartTime();
                timer = 0;
                menu.SetActive(false);
                mouseOver.SetActive(true);
                relogioAudioSource.Play();
                counting = false;
                startedGame = true;
            }
        }

        if (clock.isTimeOver && startedGame)
        {
            an.SetTrigger("Return");
            mouseOver.SetActive(true);
            menuLoose.SetActive(true);
            menuWin.SetActive(false);
            clock.Return();
            relogioAudioSource.Stop();
            if (canPlay)
            {
                audioSource.PlayOneShot(derrota);
                canPlay = false;
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Telefone"))
                {
                    audioSource.PlayOneShot(telefone);
                }
            }


        }

        clickTimer += Time.deltaTime;
    }

    void JogadorInput()
    {
        if (Input.GetMouseButtonDown(0) && startedGame && !clock.isTimeOver && clickTimer >= lastClick)
        {
            lastClick = 0;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("HIT");
                Corpo corpo = hit.transform.GetComponent<Corpo>();
                if (hit.transform.CompareTag("Telefone"))
                {
                    audioSource.PlayOneShot(telefone);
                    Debug.Log("Telefone");
                }
                if (corpo != null)
                {
                    if (perpSelected == null)
                    {
                        perpSelected = corpo;
                        perpSelected.StepForward();

                    }
                    else
                    {
                        perpSelected.StepBack();
                        perpSelected = null;
                    }

                }
                else
                {

                    if (hit.transform.CompareTag("Botao"))
                    {
                        if (perpSelected != null)
                        {
                            hit.transform.GetComponent<BotaoAcusador>().PressButton();
                            if (perpSelected.chosen) //Se o jogador acertou o criminoso
                            {

                                an.SetTrigger("Return");
                                startedGame = false;
                                mouseOver.SetActive(true);
                                //Habilitar papeis de ganhou a fase;
                                menu.SetActive(false);
                                menuWin.SetActive(true);
                                pontos += 10;
                                criminososPresos += 1;
                                audioSource.PlayOneShot(vitoria);

                                if (pontos >= highScore)
                                {
                                    highScore = pontos;
                                }
                                Debug.Log("Acertou!");
                            }
                            else
                            {
                                an.SetTrigger("Return");
                                //Habilitar papeis de game over;
                                startedGame = false;
                                mouseOver.SetActive(true);
                                menuLoose.SetActive(true);
                                menuWin.SetActive(false);
                                Debug.Log("Errou!");
                                audioSource.PlayOneShot(derrota);
                            }

                            audioSource.PlayOneShot(criminosoComemoracao);
                            audioSource.PlayOneShot(criminosoTriste);
                            canPlay = true;
                            relogioAudioSource.Stop();
                            clock.Return();
                        }
                        
                    }
                    else
                    {
                        if (perpSelected != null)
                        {
                            perpSelected.StepBack();
                            perpSelected = null;
                        }
                    }

                }
            }
        }
    }

    public void StartGame()
    {
        perpsManager.level = 0;
        criminososPresos = 0;
        dialogo.GeneratePerpValues();
        perpsManager.SpawnPerps();
        an.SetTrigger("Start");
        pontos = 0;

    }

    public void BackToMenu()
    {
        menuLoose.SetActive(false);
        menuWin.SetActive(false);
        credits.SetActive(false);

        menu.SetActive(true);

        perpsManager.WipeLevel();

    }

    public void UpdateLights() //NAO ESTA FUNCIOANDNO POR ALGUM MOTIVO
    {
        if (perpsManager.level == 1)
        {
            lightsLevel[0].SetActive(true);
            lightsLevel[1].SetActive(false);
            lightsLevel[2].SetActive(false);
        }
        else if (perpsManager.level == 2)
        {
            lightsLevel[0].SetActive(false);
            lightsLevel[1].SetActive(true);
            lightsLevel[2].SetActive(false);

        }
        else if (perpsManager.level == 3)
        {
            lightsLevel[0].SetActive(false);
            lightsLevel[1].SetActive(false);
            lightsLevel[2].SetActive(true);

        }
    }

    public void NextLevel()
    {
        dialogo.GeneratePerpValues();

        perpsManager.WipeLevel();
        if (perpsManager.level < 2)
        {
            perpsManager.level++;
        }
        UpdateLights();

        perpsManager.SpawnPerps();
        an.SetTrigger("Start");

    }

    public void UpBloquinho()
    {
        bloquinho.an.SetTrigger("Up");
        counting = true;
    }
}
