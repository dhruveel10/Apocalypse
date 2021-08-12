using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource myAudio;
    public AudioClip[] myMusic; // declare this as Object array
    int sceneID;

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag ("Music");
        if(musicObj.Length >1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
        sceneID = SceneManager.GetActiveScene().buildIndex;
    }

    void Start()
    {
        if(sceneID == 0)
        {
            Invoke("LoadFirstScene", 10.2f);
            playRandomMusic();
        }
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame
    void Update()
    {
        if (!myAudio.isPlaying)
            playRandomMusic();
    }

    void playRandomMusic()
    {
        myAudio.clip = myMusic[Random.Range(0, myMusic.Length)] as AudioClip;
        myAudio.Play();
    }
}
