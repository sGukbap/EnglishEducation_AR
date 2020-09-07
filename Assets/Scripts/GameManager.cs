using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
   

    private void Awake()
    {
        // 1. 싱글턴 선언
        if (instance == null) { instance = this; DontDestroyOnLoad(this.gameObject); }
        else { Destroy(this.gameObject); }

    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
