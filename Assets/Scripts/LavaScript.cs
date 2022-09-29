using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            CharacterStats stats = other.gameObject.GetComponent<CharacterStats>();
            if (stats != null)
            {
                Debug.Log("Lava!!!");
                stats.TakeDamage(stats.GetHealth());
            }
        }
        else if (other.gameObject.layer == 8)
        {
            Destroy(other.gameObject);
        }
    }
}

