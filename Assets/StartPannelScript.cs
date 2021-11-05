using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class StartPannelScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static StartPannelScript instance;
    Button _startButton;
    ButtonFunctions[] _startFucntions,_endFunctions;
    TextMeshProUGUI _countDownText,_highScoreText;
    RectTransform _playPannel;


    void Awake()
    {
        instance = this;
        
        _startButton = GameObject.Find("SP_GameStartButton").GetComponent<Button>();
        _startFucntions = GameObject.Find("SP_StartFunctions").GetComponents<ButtonFunctions>();
        _endFunctions = GameObject.Find("SP_EndFunctions").GetComponents<ButtonFunctions>();
        _startButton.onClick.AddListener(() => PressedStartButton());
        _countDownText = GameObject.Find("SP_CountDown").GetComponent<TextMeshProUGUI>();
        _highScoreText = GameObject.Find("SP_HighScoreText").GetComponent<TextMeshProUGUI>();
        _highScoreText.SetText("HighScore : " + PlayerPrefs.GetFloat("HighScore", 0).ToString());
        _playPannel = GameObject.Find("PlayPanel").GetComponent<RectTransform>();
        _playPannel.gameObject.SetActive(false);
    }

    void PressedStartButton()
    {
        foreach (ButtonFunctions functions in _startFucntions)
        {
            functions.OnClick();
        }
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        _countDownText.SetText("3");
        _countDownText.rectTransform.localScale = new Vector3(0,0,0);
        _countDownText.rectTransform.DOScale(1, 1f);
        yield return new WaitForSeconds(1f);
        _countDownText.SetText("2");
        _countDownText.rectTransform.localScale = new Vector3(0, 0, 0);
        _countDownText.rectTransform.DOScale(1, 1f);
        yield return new WaitForSeconds(1f);
        _countDownText.SetText("1");
        _countDownText.rectTransform.localScale = new Vector3(0, 0, 0);
        _countDownText.rectTransform.DOScale(1, 1f);
        yield return new WaitForSeconds(1f);
        _countDownText.SetText("Start!");
        _countDownText.rectTransform.localScale = new Vector3(0, 0, 0);
        _countDownText.rectTransform.DOScale(1, 1f);
        yield return new WaitForSeconds(1f);
        _countDownText.rectTransform.localScale = new Vector3(0, 0, 0);
        ShowPlayPannel();
    }

    void ShowPlayPannel()
    {
        _playPannel.gameObject.SetActive(true);
        PlayPanelScript.instance.StartGamePlay();
    }
    void HidePlayPannel()
    {
        PlayPanelScript.instance.StartGamePlay();
        _playPannel.gameObject.SetActive(false);
    }



    public void ReturnStartMenu()
    {
        foreach (ButtonFunctions functions in _endFunctions)
        {
            functions.OnClick();
        }
        _highScoreText.SetText("HighScore : " + PlayerPrefs.GetFloat("HighScore", 0).ToString());
        PlayPanelScript.instance.TurnOffGameResult();
        _playPannel.gameObject.SetActive(false);
    }

}
