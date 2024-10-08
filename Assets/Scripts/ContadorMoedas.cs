using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorMoedas : MonoBehaviour
{
    [SerializeField] private int maxPoints;
    public bool checkPontos; // se os pontos for igual ou maior ao maximo de pontos, fica verdadeira, se nao fica falso;
    [SerializeField] private TextMeshProUGUI contador;
    private BallMoviment ballMoviment;

    void Start()
    {
        checkPontos = false;
        ballMoviment = FindObjectOfType<BallMoviment>();
    }
    // Update is called once per frame
    void Update()
    {
       contador.text = "Moedas: " + ballMoviment.pontos + " / " + maxPoints;

       if(ballMoviment.pontos >= maxPoints)
       {
            contador.color = Color.green;
            checkPontos = true;
       }
       else
       {
            contador.color = Color.yellow;
            checkPontos = false;
       }

    }
}
