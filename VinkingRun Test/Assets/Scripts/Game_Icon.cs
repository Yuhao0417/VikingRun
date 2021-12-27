using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Icon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
