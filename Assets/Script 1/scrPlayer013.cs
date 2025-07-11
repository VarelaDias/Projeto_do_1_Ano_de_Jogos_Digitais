using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scrPlayer013 : MonoBehaviour
{
    public float x;
    public float y;
    [SerializeField] Transform transformparede;
    
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    private SpriteRenderer spriteRenderer;


    [SerializeField] Transform[] Paredao = new Transform[3];
    [SerializeField] Vector2[] localParedes = new Vector2[3];

    public Vector2 saidaLabirinto;

    public TMP_Text TXTTimer;
    public int segundos;
    public int minutos;

    public scrGameMaster scrGameMaster;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void Timer()
    {
        segundos++;
        if (segundos == 60)
        {
            minutos++;
            segundos = 0;
        }

       TXTTimer.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }
    // Update is called once per frame
    void Update()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        for (int i = 0; i <= 110; i++)
        {
            localParedes[i] = new Vector2(Paredao[i].transform.position.x, Paredao[i].transform.position.y);
        }

        x = transform.position.x;
        y = transform.position.y;


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x++;
            SetSprite(spriteRight);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x--;
            SetSprite(spriteLeft);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            y++;
            SetSprite(spriteUp);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            y--;
            SetSprite(spriteDown);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            x++;
            SetSprite(spriteRight);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            x--;
            SetSprite(spriteLeft);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            y++;
            SetSprite(spriteUp);

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            y--;
            SetSprite(spriteDown);
        }
        void SetSprite(Sprite sprite)
        {
            if (spriteRenderer != null && sprite != null)
            {
                spriteRenderer.sprite = sprite;
            }
        }

        Vector2 localDestino = new Vector2(x, y);

        bool possoandar = true;

        for (int i = 0; i <= 110; i++)
        {
            if (localDestino == localParedes[i])
            {
                possoandar = false;
            }
        }
        if (possoandar == false)
        {
            Debug.Log("to na parede");
        }
        else
        {
            transform.position = new Vector2(x, y);
            if (localDestino == saidaLabirinto)
            {
                GetComponent<scrPlayer013>().enabled = false;
                CancelInvoke("Timer");

                scrGameMaster.TelaTerminou.SetActive(true);
                scrGameMaster.TelaInicial.SetActive(false);
                scrGameMaster.TeladoJogo.SetActive(false);
            }
        }
    }
}
