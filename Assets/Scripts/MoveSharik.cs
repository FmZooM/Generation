using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class MoveSharik : MonoBehaviour
{
    public float speed = 5f, hSpeed = 10f, _thrust = 500f;
    private Rigidbody _rb;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * hSpeed * Time.fixedDeltaTime;
        float v = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;


        _rb.linearVelocity = transform.TransformDirection(new Vector3(v, _rb.linearVelocity.y, -h));


    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Block")
        {
            _rb.AddForce(new Vector3(0,0,-1) * _thrust);
        }


    }

    private void OnCollisionStay(Collision other)
    {
        //Debug.Log("Collide");


    }
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("Collide");

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Trigger")
        {
            Debug.Log("Player enter to Trigger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Trigger")
        {
            Debug.Log("Player in the trap!");
            Destroy(gameObject);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Trigger")
        {
            Debug.Log("Player staying in Trigger");
        }

    }






}
