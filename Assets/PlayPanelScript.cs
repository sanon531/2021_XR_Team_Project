using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 게임 도중의 매니져인 그냥 해 
public class PlayPanelScript : MonoBehaviour
{
    public static PlayPanelScript instance;
    private TextMeshProUGUI _currentTimeLeft, _currentWaveName, _currentScorePanel;
    private Image _gaugeImage;
    GameObject _evalSet;

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
    }

    public void StartGamePlay()
    {
        _isGameStart = true;
        _evalSet.SetActive(true);
        Spawner_practice.instance.SpawnInOrder();
    }


    float _currentTime = 0;
    float _currentScore = 0;
    float _waveTerm = 60f;
    float _currentWave = 0;

    bool _isGameStart = false;

    void Update()
    {
        if (_isGameStart)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > _waveTerm)
            {
                _currentTime = 0;
                _currentWaveName.SetText("Current Wave :" + _currentWave.ToString());
                if (++_currentWave > 3)
                {
                    InGameManager.instance.GameEnd();
                    _isGameStart = false;
                }
                Spawner_practice.instance.ClearObject();
            }

            float _temptTime = _waveTerm - _currentTime;
            _currentTimeLeft.SetText(Mathf.RoundToInt(_temptTime).ToString());
            _gaugeImage.fillAmount = (_temptTime/ _waveTerm);
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
}
