using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    private void Start()
    {
         SoundManager.instance.PlayAudio("브금1", "BGM");
    }
    public void ChnageMainScene()
    {
        // 
        SoundManager.instance.PlayAudio("뾰로롱", "SE");
        SoundManager.instance.StopAudio("BGM");
        // 메인씬으로 넘어감
        SceneManager.LoadScene("MainScene");
    }

    public void ChangeARScene()
    {
        SoundManager.instance.PlayAudio("뾰로롱", "SE");
        SceneManager.LoadScene("ARScene");
    }

}
