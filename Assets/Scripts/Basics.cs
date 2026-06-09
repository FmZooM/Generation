using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Basics : MonoBehaviour
{
    //public GameObject[] objs = new GameObject[3];
    //public Transform target;
    //public BoxCollider box;
    //public Light _light;

    public Transform[] transforms = new Transform[3];
    public float speed = 5.0f, rotateSpeed = 10f;

    public void Start()
    {
        //obj.SetActive(false);
        //obj.GetComponent<BoxCollider>().enabled = true;
        //if (obj.GetComponent<BoxCollider>().enabled == false)

        //    Debug.Log("BoxCollider in Cube: False");

        //else

        //    Debug.Log("BoxCollider in Cube: True");
        //target.position = new Vector3(10, 0, 5);
        //_light.intensity = 0.5f;

        
        //for(int i = 0; i < objs.Length; i++)
        //{
        //    objs[i].SetActive(false);
            
        //}
    }
    private void Update()
    {
        for (int i = 0; i < transforms.Length; i++)
        {
            if (transforms[i] == null)
                continue;

            
            transforms[i].Rotate(new Vector3(1, 0, 0) * rotateSpeed * Time.deltaTime);




            //transforms[i].Translate(new Vector3(0, 0, 0) * speed * Time.deltaTime);
            //float posX = transforms[i].position.x;
            //if (posX < -10f && transforms[i].gameObject.name == "Cube")
            //    Destroy(transforms[i].gameObject);
        }
    }
}
