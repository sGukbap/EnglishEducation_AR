using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class ButtonManager : MonoBehaviour
{
     public GameObject[] objList; // 오브젝트 리스트 배열
     
    public void PrefActive()
    {
        // 1. 오브젝트 리스트를 다 검사해서
          for (int j = 0; j < objList.Length; j++)
          {
              // 2. 눌린 버튼과 이름이 같은 오브젝트가 있으면
              if (EventSystem.current.currentSelectedGameObject.name == objList[j].name )
              {
                 // 3. 해당 오브젝트를 활성화한다
                 objList[j].SetActive(true);
              }
              // 4. 그렇지않고 버튼과 이름이 다른 오브젝트들은
              else if (EventSystem.current.currentSelectedGameObject.name != objList[j].name)
              {
                 // 5. 비활성화한다
                 objList[j].SetActive(false);
              }
            }

        }

    }




  
