using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[System.Serializable]
public class MarkerInfo
{
    public string name;
    public GameObject gobj;
}

// 다수개의 마커를 인식하고 싶다.
// 마커와 마커가 추적되었을때 보여질 GameObject
public class MarkerMulti : MonoBehaviour
{
    public MarkerInfo[] markerList;
    public ARTrackedImageManager manager;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        manager.trackedImagesChanged += OntrackedImagesChanged;
    }

    private void OnDisable()
    {
        manager.trackedImagesChanged -= OntrackedImagesChanged;
    }

    private void OntrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        // 검출된 마커를 다 검사해서
        for (int i = 0; i < args.updated.Count; i++)
        {
            ARTrackedImage image = args.updated[i];
            // 만약 검출된 마커의 이름과 내가 보유한 마커(markerList)의 이름이 같다면
            for (int j = 0; j < markerList.Length; j++)
            {
                if (image.referenceImage.name == markerList[j].name)
                {
                    //  만약 그 마커가 추적중이라면
                    if (image.trackingState == TrackingState.Tracking)
                    {
                        // 그 마커의 게임오브젝트를 활성화하고
                        markerList[j].gobj.SetActive(true);
                        // 위치도 동기화 하고싶다.
                        markerList[j].gobj.transform.position = image.transform.position;
                    }
                    //  그렇지않고 추적중이 아니라면
                    else
                    {
                        // 그 마커의 게임오브젝트를 비활성화 하고싶다.
                        markerList[j].gobj.SetActive(false);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

