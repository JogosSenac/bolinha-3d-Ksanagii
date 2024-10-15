using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMoviment : MonoBehaviour
{
    private float moveH;
    private float moveV;
    private Rigidbody rb;
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    [HideInInspector] public int pontos;
    public bool estaVivo = true;

    [Header("Sons da Bolinha")]
    [SerializeField] private AudioClip pulo;
    [SerializeField] private AudioClip pegaCubo;
    private AudioSource audioPlayer;
    private ContadorMoedas contadorMoedas;
    [SerializeField] private string ProximaFase;
    private bool podePular;


    void Start()
    {
        contadorMoedas = FindObjectOfType<ContadorMoedas>();
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
        pontos = 0;
    }

    void Update()
    {
        if(estaVivo)
        {
            moveH = Input.GetAxis("Horizontal");
            moveV = Input.GetAxis("Vertical");

            transform.position += new Vector3(-1 * moveV * velocidade * Time.deltaTime, 0, moveH * velocidade * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space) && podePular)
            {
                rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
                audioPlayer.PlayOneShot(pulo);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CuboBrilhante"))
        {
            Destroy(other.gameObject);
            audioPlayer.PlayOneShot(pegaCubo);
            pontos++;
        }

        if(other.gameObject.CompareTag("Portal") && contadorMoedas.checkPontos)
        {

            SceneManager.LoadScene(ProximaFase);
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Agua"))
        {
            estaVivo = false;
        }

        if(other.gameObject.CompareTag("Chao"))
        {
            podePular = true;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        
    }

        private void OnCollisionExit(Collision other) {
        
        if(other.gameObject.CompareTag("Chao"))
        {
            podePular = false;
        }
    }

}
