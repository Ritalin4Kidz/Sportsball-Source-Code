using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MyAudioScript : MonoBehaviour {
    public AudioClip[] songs;
    public Canvas songDisplayRef;
    Canvas songDisplay;
    public int songPlayed = 0;
    static MyAudioScript instance = null;
    bool delayOn2 = false;
    public GameObject uniGame;
    public string[] songNames;
    public string[] artistNames;
    public string[] details;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        // Use this for initialization
    }
    public void SongPlay(int songNo)
    {
        songPlayed = songNo;
        this.GetComponent<AudioSource>().clip = songs[songPlayed];
        this.GetComponent<AudioSource>().Play();
        songDisplay = Instantiate(songDisplayRef);
        songDisplay.GetComponent<songScripts>().songNameTxt.text = songNames[songPlayed];
        songDisplay.GetComponent<songScripts>().artistNameTxt.text = artistNames[songPlayed];
        songDisplay.GetComponent<songScripts>().detailsText.text = details[songPlayed];
    }
    void Start()
    {
        this.GetComponent<AudioSource>().volume = uniGame.GetComponent<UniGameManager>().songVolume;
        this.GetComponent<AudioSource>().clip = songs[songPlayed];
        this.GetComponent<AudioSource>().Play();
        songDisplay = Instantiate(songDisplayRef);
        songDisplay.GetComponent<songScripts>().songNameTxt.text = songNames[songPlayed];
        songDisplay.GetComponent<songScripts>().artistNameTxt.text = artistNames[songPlayed];
        songDisplay.GetComponent<songScripts>().detailsText.text = details[songPlayed];
    }
    public void AudioVolumeChange()
    {
        this.GetComponent<AudioSource>().volume = uniGame.GetComponent<UniGameManager>().songVolume;
    }
    // Update is called once per frame
    void Update()
    {
        if (uniGame.GetComponent<UniGameManager>().boolStopAudio)
        {
            uniGame.GetComponent<UniGameManager>().boolStopAudio = false;
            instance = null;
            Destroy(this.gameObject);
        }
        if (SceneManager.GetActiveScene().name != "splashScreen" && SceneManager.GetActiveScene().name != "MenuMockUp" && SceneManager.GetActiveScene().name != "BookOfLore" && SceneManager.GetActiveScene().name != "TournamentMode" && SceneManager.GetActiveScene().name != "ReadyScreen" && SceneManager.GetActiveScene().name != "Training" && SceneManager.GetActiveScene().name != "Missions")
        {
            instance = null;
            Destroy(this.gameObject);
        }
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
            songPlayed++;
            if (songPlayed > songs.Length - 1)
            {
                songPlayed = 0;
            }
            this.GetComponent<AudioSource>().clip = songs[songPlayed];
            this.GetComponent<AudioSource>().Play();
            if (songDisplay != null)
            {
                songDisplay.GetComponent<songScripts>().erase();
            }
            songDisplay = Instantiate(songDisplayRef);
            songDisplay.GetComponent<songScripts>().songNameTxt.text = songNames[songPlayed];
            songDisplay.GetComponent<songScripts>().artistNameTxt.text = artistNames[songPlayed];
            songDisplay.GetComponent<songScripts>().detailsText.text = details[songPlayed];
        }
        if (Input.GetAxis("Player1DpadX") > 0)
        {
            if (!delayOn2)
            {
                delayOn2 = true;
                songPlayed++;
                if (songPlayed > songs.Length - 1)
                {
                    songPlayed = 0;
                }
                this.GetComponent<AudioSource>().clip = songs[songPlayed];
                this.GetComponent<AudioSource>().Play();
                if (songDisplay != null)
                {
                    songDisplay.GetComponent<songScripts>().erase();
                }
                songDisplay = Instantiate(songDisplayRef);
                songDisplay.GetComponent<songScripts>().songNameTxt.text = songNames[songPlayed];
                songDisplay.GetComponent<songScripts>().artistNameTxt.text = artistNames[songPlayed];
                songDisplay.GetComponent<songScripts>().detailsText.text = details[songPlayed];
            }
        }
        if (Input.GetAxis("Player1DpadX") < 0)
        {
            if (!delayOn2)
            {
                delayOn2 = true;
                songPlayed--;
                if (songPlayed < 0)
                {
                    songPlayed = songs.Length - 1;
                }
                this.GetComponent<AudioSource>().clip = songs[songPlayed];
                this.GetComponent<AudioSource>().Play();
                if (songDisplay != null)
                {
                    songDisplay.GetComponent<songScripts>().erase();
                }
                songDisplay = Instantiate(songDisplayRef);
                songDisplay.GetComponent<songScripts>().songNameTxt.text = songNames[songPlayed];
                songDisplay.GetComponent<songScripts>().artistNameTxt.text = artistNames[songPlayed];
                songDisplay.GetComponent<songScripts>().detailsText.text = details[songPlayed];
            }
        }
        if (Input.GetAxis("Player1DpadX") == 0)
        {
            delayOn2 = false;
        }
    }
}
