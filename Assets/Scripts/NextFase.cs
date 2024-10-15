using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextFase : MonoBehaviour
{
    private ContadorMoedas contadorMoedas;
    public GameObject portal;
    [SerializeField] Material corPortal;
    [SerializeField] private Color transparente = new Color (1,0,0,1);
    [SerializeField] private Color portalAtivo = new Color (1,0,0,1);

    // Start is called before the first frame update
    void Start()
    {
        contadorMoedas = FindObjectOfType<ContadorMoedas>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!contadorMoedas.checkPontos)
        {
            corPortal.color = transparente;
        }
        else
        {
            corPortal.color = portalAtivo;
        }
        
    }
    
}
