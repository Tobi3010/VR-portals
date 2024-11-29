using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Coli : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "object")
        {
            print("SPHERE!");
        }
    }

    void OnTriggerStay(Collider other)
    {

    }

    void OnTriggerExit(Collider other)
    {
        if (other != this)
        {
            print("no longer");
        }
    }

}

