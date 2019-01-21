using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private PlayerController player;
    public PlayerController Player
    {
        get => player;
        set => player = value;
    }

    private int score = 0;

    private float time = 0;

    private bool pause = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }

        time += Time.deltaTime;
        UIManager.Instance.DisplayTime(time);
    }
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        Time.timeScale = 0;

    }

    private void Start()
    {
        Setup();
    }

    public void Restart()
    {
        score = 0;
        time = 0;
        Time.timeScale = 1;
        UIManager.Instance.DisplayScore(score);
        UIManager.Instance.DisplayTime(time);
        player.enabled = true;
    }

    public void Menu()
    {
        LoadLevel("Luca");
    }

    public void Setup()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        player.enabled = false;
    }

    public void Pause()
    {
        if (pause)
        {
            pause = false;
            Time.timeScale = 0;
        }
        else
        {

            pause = true;
            Time.timeScale = 0;
        }

        UIManager.Instance.Pause(pause);
    }

    public void LoadLevel(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }

    public void AddScore()
    {
        score++;
        UIManager.Instance.DisplayScore(score);
    }

    public void End()
    {
        UIManager.Instance.End(score);
        Time.timeScale = 0;
        player.enabled = false;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
}
