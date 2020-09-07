using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Information
{
    public string name; // 오디오 이름
    public float volume; // 오디오 볼륨
    public bool isLoop; // 반복재생
    public AudioClip clip; // 오디오 파일
}

public class SoundManager : MonoBehaviour
{
    static public SoundManager instance; // 싱글턴

    [SerializeField] Information[] bgmInfo = null; // 배경음악 오디오 정보
    private AudioSource bgmPlayer;
    private int currentBgmIndex;

    [SerializeField] Information[] seInfo = null;
    private List<AudioSource> sePlayer;

    #region Awake()
    private void Awake()
    {
        // 1. 싱글턴 선언
        if (instance == null) { instance = this; DontDestroyOnLoad(this.gameObject); }
        else { Destroy(this.gameObject); }

        // 2. 오디오재생 플레이어에 오디오소스 컴포넌트를 붙인다
        bgmPlayer = this.gameObject.AddComponent<AudioSource>();

        sePlayer = new List<AudioSource>();
        for (int i = 0; i < seInfo.Length; i++)
        { sePlayer.Add(this.gameObject.AddComponent<AudioSource>()); }
    }
    #endregion Awake()

    #region BGM
    private void PlayBGM(string _name)
    {
        // 1. bgmInfo의 배열만큼 반복실행
        for (int i = 0; i < bgmInfo.Length; i++)
        {
            // 2. 만약 파라메타로 넘어온 이름이 있다면
            if (_name == bgmInfo[i].name)
            {
                // 3. bgmIfo에 담겨있는 오디오 클립을 재생한다
                bgmPlayer.clip = bgmInfo[i].clip;
                bgmPlayer.volume = bgmInfo[i].volume;
                bgmPlayer.loop = bgmInfo[i].isLoop;
                bgmPlayer.Play();
                currentBgmIndex = i;
                return;
            }
        }
    }
    private void StopBGM()
    { bgmPlayer.Stop(); }

    private void PauseBGM()
    { bgmPlayer.Pause(); }

    private void UnPauseBGM()
    { bgmPlayer.UnPause(); }
    #endregion BGM

    #region SE
    private void PlaySE(string _name)
    {
        // 1. seInfo의 배열만큼 반복실행
        for (int i = 0; i < seInfo.Length; i++)
        {
            // 2. 파라메타 이름과 같은것이 있으면
            if (_name == seInfo[i].name)
            {
                // 효과음 플레이어의 갯수만큼 반복실행
                for (int j = 0; j < sePlayer.Count; j++)
                {
                    // 4. 재생한다
                    sePlayer[j].clip = seInfo[j].clip;
                    sePlayer[j].volume = seInfo[j].volume;
                    sePlayer[j].PlayOneShot(sePlayer[j].clip);
                }
               
            }
        }
    }
    private void StopAllSE()
    {
        for (int i = 0; i < sePlayer.Count; i++)
        {
            sePlayer[i].Stop();
        }
    }
    #endregion SE

    public void PlayAudio(string _name, string _type)
    {
        if (_type == "BGM") PlayBGM(_name);
        else if (_type == "SE") PlaySE(_name);
    }

    public void StopAudio(string _type)
    {
        if (_type == "BGM") StopBGM();
        else if (_type == "SE") StopAllSE();
    }

    public void PlayNextBGM()
    {
        if(currentBgmIndex + 1 == bgmInfo.Length)
        {
            PlayBGM(bgmInfo[0].name);
        }
        else
        {
            PlayBGM(bgmInfo[currentBgmIndex + 1].name);
        }
    }

}
