using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class StartPannelScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject _evalSet;
    Button _startButton;
    ButtonFunctions[] _startFucntions;

    TextMeshProUGUI _countDownText;


    void Awake()
    {
        _evalSet = GameObject.Find("EvaluationSet");
        _evalSet.SetActive(false);
        _startButton = GameObject.Find("SP_GameStartButton").GetComponent<Button>();
        _startFucntions = GameObject.Find("SP_StartFunctions").GetComponents<ButtonFunctions>();
        _startButton.onClick.AddListener(() => PressedStartButton());
        _countDownText = GameObject.Find("SP_CountDown").GetComponent<TextMeshProUGUI>();

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


    }


}
