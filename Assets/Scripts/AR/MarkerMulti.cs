using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[System.Serializable]public class MarkerInfo // 마커정보 클래스
{
    public string name; // 사진 이름
    public GameObject obj; // 뜨게할 프리펩 오브젝트

}
public class MarkerMulti : MonoBehaviour
{
    public MarkerInfo[] markerList; // 마커 배열
    public ARTrackedImageManager manager; // AR트랙이미지매니저 변수

    
    private void OnEnable()
    {
        manager.trackedImagesChanged += OnTrackedImagesChanged;
    }
    private void OnDisable()
    {
        manager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        // 검출된 마커를 다 검사해서
        for (int i = 0; i < args.updated.Count; i++)
        {
            ARTrackedImage image = args.updated[i];
            // 만약 검출된 마커의 이름과 내가 보유한 마커의 이름이 같다면
            for (int j = 0; j < markerList.Length; j++)
            {
                if (image.referenceImage.name == markerList[j].name)
                {
                    // 만약 그 마커가 추적중이라면
                    if (image.trackingState == TrackingState.Tracking)
                    {
                        // 그 마커의 게임오브젝트를 활성화하고 
                        markerList[j].obj.SetActive(true);
                        // 위치도 동기화 하고싶다
                        markerList[j].obj.transform.position = image.transform.position;

                    }
                    // 그렇지않고 추적중이 아니라면
                    else
                    {
                        // 그 마커의 게임오브젝트를 비활성화 하고싶다
                        markerList[j].obj.SetActive(false);
                    }
                }
                    
            }
            

        }





    }

    void Update()
    {
        
    }
}
