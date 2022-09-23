using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        //Destroy(other.gameObject);
        other.gameObject.SetActive(false);
    }
}

