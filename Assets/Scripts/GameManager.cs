using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public enum GamePhases
    {
        StartPhase, LevelSelect, PlayPhase, TutorialPlayPhase, OptionsPhase, ResultsPhase
    }

    public GamePhases currentGamePhase = GamePhases.StartPhase;


    #region RHYTHM GAME VARIABLES
    public int currentScore;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;
    public int scorePerNote = 100;
    public int scorePerPerfectNote = 150;
    public int scorePerGoodNote = 125;
    public float currentProgress = 0f;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHiits;
    public string rankVal = "";

    public SongInfo selectedSong;

    //TODO: Make something in rhythm scene get updated text values
    //public Text scoreText;
    //public Text multiText;
    #endregion

    public void ReportSelectedSong(SongInfo song)
    {
        selectedSong = song;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartCurrentPhaseBehavior();
    }
    // Update is called once per frame
    void Update()
    {
        switch (currentGamePhase)
        {
            case GamePhases.PlayPhase:
            case GamePhases.TutorialPlayPhase:

                BeatScroller theBS = GameObject.FindObjectOfType<BeatScroller>();
                if (Input.anyKeyDown)
                {
                    if (theBS != null)
                    {
                        if (theBS.hasStarted == false)
                        {
                            theBS.hasStarted = true;

                            GameObject musicObject = GameObject.FindGameObjectWithTag("MusicAudioSource");
                            if (musicObject)
                            {
                                AudioSource musicAudioSource = musicObject.GetComponent<AudioSource>();
                                if (musicAudioSource != null)
                                {
                                    if (selectedSong) musicAudioSource.clip = selectedSong.musicClip;
                                    musicAudioSource.Play();
                                }
                            }
                        }
                        else
                        {
                            
                        }
                    }

                    

                }
                if (theBS.hasStarted)
                {
                    float progress = 0f;
                    GameObject musicObject = GameObject.FindGameObjectWithTag("MusicAudioSource");
                    AudioSource musicAudioSource = musicObject.GetComponent<AudioSource>();
                    if (musicAudioSource)
                    {
                        progress = musicAudioSource.time / musicAudioSource.clip.length;
                        currentProgress = Mathf.Clamp(progress, 0f, 1f);
                    }
                }
                break;
            case GamePhases.StartPhase:
                break;
            case GamePhases.LevelSelect:
                break;
            case GamePhases.ResultsPhase:
                break;
        }
    }
    public void SetNextPhase(GamePhases nextPhase)
    {
        EndCurrentPhaseBehavior();
        currentGamePhase = nextPhase;
        StartCurrentPhaseBehavior();
    }

    void StartCurrentPhaseBehavior()
    {
        switch (currentGamePhase)
        {
            case GamePhases.StartPhase:
                //load data
                //get microtransactions

                if (SceneManager.GetActiveScene().buildIndex != 0)
                    SceneManager.LoadScene(0);

                OnUnPaused();
                break;
            case GamePhases.PlayPhase:
                SceneManager.LoadScene(4);
                currentProgress = 0f;
                //shouldn't play music until the player hits a key
                //Debug.Log("Play the music!");
                //AudioManager.instance.PlayMusic(AudioManager.MusicTypes.Gameplay, true);

                OnUnPaused();
                break;
            case GamePhases.LevelSelect:
                SceneManager.LoadScene(1);
                break;
            case GamePhases.TutorialPlayPhase:
                SceneManager.LoadScene(3);
                break;
            case GamePhases.OptionsPhase:
                SceneManager.LoadScene(2);
                break;
            case GamePhases.ResultsPhase:
                SceneManager.LoadScene(5);
                break;
        }
    }


    void EndCurrentPhaseBehavior()
    {
        switch (currentGamePhase)
        {
            case GamePhases.StartPhase:
                break;
            case GamePhases.TutorialPlayPhase:
            case GamePhases.PlayPhase:
                SetResultsScreenValues();
                break;
        }
    }

    public void OnStartGamePressed()
    {
        SetNextPhase(GamePhases.PlayPhase);
    }

    public void OnPlayQuitPressed()
    {
        SetNextPhase(GamePhases.StartPhase);
    }

    public void OnPlayExitPressed()
    {
        SetNextPhase(GamePhases.LevelSelect);
    }

    public void OnPlayOptionsPressed()
    {
        SetNextPhase(GamePhases.OptionsPhase);
    }

    public void OnLevelComplete()
    {
        SetNextPhase(GamePhases.ResultsPhase);
    }


    public void OnPaused()
    {
        Time.timeScale = 0f;
    }
    public void OnUnPaused()
    {
        Time.timeScale = 1f;
    }

    #region RHYTHM GAME METHODS

    void SetResultsScreenValues()
    {
        /*
        resultsScreen.SetActive(true); 
        normals.text = "" + normalHits;
        goodsText.text = goodhits.ToString();
        perfectsText.text = perfecthits.ToString();
        missesText.text = misshits.ToString();
        */
        float totalHit = normalHits + goodHits + perfectHits;

        float percentHit = (totalHit / totalNotes) * 100f;
        //percentHitText.text = percentHit.ToString("F1") + "%";

        rankVal = "F";
        if (percentHit > 40)
        {
            rankVal = "D";
            if (percentHit > 55)
            {
                rankVal = "C";
            }
            if (percentHit > 70)
            {
                rankVal = "B";
            }
            if (percentHit > 85)
            {
                rankVal = "A";
            }
            if (percentHit > 95)
            {
                rankVal = "S";
            }
        }
        //rankText.text = rankValue;  
        //finalScoreText.text = currentScore.ToString();
    }



    public void NoteHit()
    {
        Debug.Log("Hit On Time");
        currentScore += scorePerNote * currentMultiplier;
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;
            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        //TODO - Make something in the rhythm game scene receive update
        //multiText.text = "Multiplier: x" + currentMultiplier;
        //scoreText.text = "Score: " + currentScore;
    }
    public void NoteMissed()
    {
        Debug.Log("Missed Note");
        currentMultiplier = 1;
        multiplierTracker = 0;
        missedHiits++;
        //TODO - Make something in the rhythm game scene receive update
        //multiText.text = "Multiplier: x" + currentMultiplier;
    }
    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        normalHits++;
    }
    public void GoodHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        goodHits++;
    }
    public void PerfectHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        perfectHits++;
    }
    public void ReportLastNoteHit()
    {
        //record some information before we move onto...
        SetNextPhase(GamePhases.ResultsPhase);
    }

    #endregion
}
