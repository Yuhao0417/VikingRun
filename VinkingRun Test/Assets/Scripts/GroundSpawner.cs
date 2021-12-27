using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] roadType;
    private Vector3 nextSpawnPoint;

    private GameObject previousTerrain = null;
    private GameObject secondPrevious = null;
    private GameObject currentTerrain = null;

    private bool initial = false;

    [SerializeField]
    private Transform player;

    private float[] angleList = { 0, 270, 180 };

    private Random rand = new Random();
    public void SpawnTerrain()
    {
        secondPrevious = previousTerrain;
        previousTerrain = currentTerrain;
        GameObject nextTile;
        if(rand.Next(0, 4) == 0 || !initial)
        {
            nextTile = Instantiate(roadType[0], nextSpawnPoint, Quaternion.Euler(0, player.eulerAngles.y + angleList[0], 0));
        }
        else if (rand.Next(0, 4) == 1)
        {
            nextTile = Instantiate(roadType[1], nextSpawnPoint, Quaternion.Euler(0, player.eulerAngles.y + angleList[1], 0));
        }
        else if (rand.Next(0, 4) == 2)
        {
            nextTile = Instantiate(roadType[2], nextSpawnPoint, Quaternion.Euler(0, player.eulerAngles.y + angleList[2], 0));
        }
        else
        {
            nextTile = Instantiate(roadType[3], nextSpawnPoint, Quaternion.Euler(0, player.eulerAngles.y + angleList[0], 0));
        }
        //tile = Instantiate(roadType[0], nextSpawnPoint, Quaternion.Euler(0, player.eulerAngles.y + angleList[0], 0));
        nextTile.transform.parent = transform;
        nextSpawnPoint = nextTile.transform.GetChild(0).transform.position;
        currentTerrain = nextTile;
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnTerrain();
        initial = true;
    }

    public GameObject PreviouTerrain => previousTerrain;
    public GameObject SecondPrevious => secondPrevious;
    public GameObject CurrentTerrain => currentTerrain;

}
