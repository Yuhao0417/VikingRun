using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GroundSpawner>().SpawnTerrain();
            Destroy(FindObjectOfType<GroundSpawner>().SecondPrevious);
        }
    }
}
