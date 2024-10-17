using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MorteMenu : MonoBehaviour
{
    BallMoviment ballMoviment;
    [SerializeField] private GameObject morteCena;

    // Start is called before the first frame update
    void Start()
    {
        ballMoviment = FindObjectOfType<BallMoviment>();
        morteCena.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        VerificaMorte();
    }
    
    public void MudarCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void VerificaMorte()
    {
        if(!ballMoviment.estaVivo)
        {
            morteCena.SetActive(true);
        }
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
