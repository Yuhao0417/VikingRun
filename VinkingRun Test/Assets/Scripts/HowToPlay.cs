using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour, IPointerClickHandler
{
    public int SceneIndexDestination = 3;

    public void OnPointerClick(PointerEventData e)
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Current scene name = " + scene.name + "and scene index = " + scene.buildIndex);

        SceneManager.LoadScene(SceneIndexDestination);
    }
}
