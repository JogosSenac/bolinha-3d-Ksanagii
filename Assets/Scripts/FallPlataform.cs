using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlataform : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float fallTime;
    //Rigidbody rbRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Invoke("Falling", fallTime);
        }
    }

    void Falling()
    {
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
    }
}
