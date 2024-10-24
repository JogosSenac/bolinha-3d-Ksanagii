using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject instrucoes;

    private void Start() 
    {
        instrucoes.SetActive(false);
    }
    public void Play(string cena)
    {
        SceneManager.LoadScene(cena);
    }
    public void OcultarOuAtivarInstrucoes(bool active)
    {
        instrucoes.SetActive(active);
    }

}
