using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int SceneIndexDestination = 2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Scene scene = SceneManager.GetActiveScene();
            Debug.Log("Current scene name = " + scene.name + "and scene index = " + scene.buildIndex);

            SceneManager.LoadScene(SceneIndexDestination);
        }
    }
}
