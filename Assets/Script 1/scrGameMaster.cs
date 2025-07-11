using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrGameMaster : MonoBehaviour
{
    public GameObject TelaInicial;
    public GameObject TelaTerminou;
    public GameObject TeladoJogo;
    public scrPlayer013 scrPlayer013;
    // Start is called before the first frame update
    void Start()
    {

        TelaInicial.SetActive(true);
        TelaTerminou.SetActive(false);
        TeladoJogo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Jogar()
    {
        TelaInicial.SetActive(false);
        TelaTerminou.SetActive(false);
        TeladoJogo.SetActive(true);


        scrPlayer013.segundos = 0;
        scrPlayer013.minutos = 0;
        scrPlayer013.InvokeRepeating("Timer", 0f, 1f);
        scrPlayer013.transform.position = new Vector2(-9f,4f);
        scrPlayer013.GetComponent<scrPlayer013>().enabled = true;

    }
    public void Voltar()
    {
        TelaInicial.SetActive(true);
        TelaTerminou.SetActive(false);
        TeladoJogo.SetActive(false);

        Debug.Log("Voltei para o inicio");

    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Fechei o jogo");
    }
}
