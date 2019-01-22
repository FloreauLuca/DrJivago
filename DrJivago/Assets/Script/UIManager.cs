using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI lifeText;

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject HUDPanel;
    [SerializeField] private TextMeshProUGUI endScoreText;

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayScore(float score)
    {
        scoreText.text = "Score : " + score.ToString();
    }


    public void DisplayLife(float life)
    {
        lifeText.text = "Life : " + life.ToString();

    }


    public void MenuButton()
    {
        GameManager.Instance.Menu();
    }

    public void StartButton()
    {
        GameManager.Instance.Restart();
    }

    public void End(int score)
    {
        endPanel.SetActive(true);
        HUDPanel.SetActive(false);
        endScoreText.text = "Score : " + score.ToString();
    }

    public void Pause(bool pause)
    {
        if (pause)
        {
            pausePanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(false);
        }

    }
}
