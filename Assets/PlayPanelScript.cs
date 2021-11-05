using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 게임 도중의 매니져인 그냥 해 
public class PlayPanelScript : MonoBehaviour
{
    public static PlayPanelScript instance;
    private TextMeshProUGUI _currentTimeLeft, _currentWaveName, _currentScorePanel,
        _endScore, _endHighScore;
    private Image _gaugeImage;
    GameObject _evalSet, _resultPanel;
    ParticleSystem _HighScoreParticle;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        _evalSet = GameObject.Find("EvaluationSet");
        _evalSet.SetActive(false);
        _currentTimeLeft = GameObject.Find("PP_CurrentTimeText").GetComponent<TextMeshProUGUI>();
        _currentWaveName = GameObject.Find("PP_CurrentWaveText").GetComponent<TextMeshProUGUI>();
        _currentScorePanel = GameObject.Find("PP_Score").GetComponent<TextMeshProUGUI>();
        _gaugeImage = GameObject.Find("PP_TimerSprite").GetComponent<Image>();


        _resultPanel = GameObject.Find("ResultPanel");
        _endScore = GameObject.Find("RP_CurrentScore").GetComponent<TextMeshProUGUI>();
        _endHighScore = GameObject.Find("RP_HighScore").GetComponent<TextMeshProUGUI>();
        _resultPanel.SetActive(false);
    }

    public void StartGamePlay()
    {
        _isGameStart = true;
        _evalSet.SetActive(true);
        Spawner_practice.instance.SpawnInOrder();
    }


    float _currentTime = 0;
    float _currentScore = 0;
    [SerializeField]
    float _waveTerm = 20f;
    int _currentWave = 0;

    bool _isGameStart = false;

    void Update()
    {
        if (_isGameStart)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > _waveTerm)
            {
                _currentTime = 0;
                ++_currentWave;
                Spawner_practice.instance.ClearObject();

                if (_currentWave > 2)
                {
                    InGameManager.instance.GameEnd();
                    ShowGameResult();
                    return;
                }

                Spawner_practice.instance.SpawnInOrder();
                _currentWaveName.SetText("Current Wave :" + (_currentWave+1).ToString());
            }

            float _temptTime = _waveTerm - _currentTime;
            _currentTimeLeft.SetText(Mathf.RoundToInt(_temptTime).ToString());
            _gaugeImage.fillAmount = (_temptTime / _waveTerm);
        }

    }

    public void RightSelected()
    {
        _currentScore += 100;
        _currentScorePanel.SetText(_currentScore.ToString());
    }
    public void WrongSelected()
    {
        _currentTime += 10f;
        _currentScorePanel.SetText(_currentScore.ToString());

    }


    void ShowGameResult()
    {
        _isGameStart = false;
        _resultPanel.SetActive(true);
        _endScore.SetText(" Result : "+ _currentScore.ToString());
        float _ex_highScore = PlayerPrefs.GetFloat("HighScore", 0);

        if (_currentScore > _ex_highScore)
        {
            PlayerPrefs.SetFloat("HighScore", _currentScore);
            _ex_highScore = _currentScore;
        }
        _endHighScore.SetText("HighScore : "+_ex_highScore.ToString());

    }

    public void TurnOffGameResult()
    {
        _resultPanel.SetActive(false);
    }


    public void EndGamePlay()
    {
        _isGameStart = false;
        _evalSet.SetActive(false);
        Spawner_practice.instance.ClearObject();
    }

}
