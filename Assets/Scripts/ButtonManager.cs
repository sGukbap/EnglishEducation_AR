using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject[] obj; // 누르면 뜨게될 오브젝트 변수 배열
    

    
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnActiveObj()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            obj[i].SetActive(false);
        }
    }
}
