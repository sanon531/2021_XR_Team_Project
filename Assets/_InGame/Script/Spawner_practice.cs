using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Spawner_practice : MonoBehaviour
{

    public static Spawner_practice instance;

    [SerializeField]
    List<Transform> _spawnPoss;

    [SerializeField]
    int _currentCapacity,_maxCapacity = 0 ;

    [SerializeField]
    GameObject _checkObject;

    [SerializeField]
    Image _timerClock, _leftTime;

    [SerializeField]
    TextMeshProUGUI _checkCap;

    float _spawnTerm = 5f;
    List<float> _termList = new List<float>(); 

    public void BeginObject(List<float> _argtermList,int _argMaxCap)
    {
        instance = this;
        _termList = _argtermList;
        _spawnTerm = _termList[0];
        _maxCapacity = _argMaxCap;
    }


    float _currentTime=0;
    int i_count = 0;
    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
            SpawnInOrder();

        _timerClock.fillAmount = (_currentTime / _spawnTerm);
        if (_currentTime > _spawnTerm)
        {
            _currentTime = 0;
            SpawnInOrder();
            i_count++;
            if (i_count < _termList.Count)
                _spawnTerm = _termList[i_count];
            else
            { }
        }


    }

    public void SpawnInOrder()
    {
        foreach (Transform _tranform in _spawnPoss)
        {
            GameObject _spawnObject = Instantiate(_checkObject, _tranform.position, Quaternion.identity, gameObject.transform);

            CheckObject _check = _spawnObject.GetComponent<CheckObject>();
            if (Random.Range(0,2) == 1)
            {
                _spawnObject.name = "flawed";
                
                _check._objectStatus = ObjectStatus.Defect_PartsLoss;
            }

            _check.InitializeObject();
            _currentCapacity++;
        }
        SetCapToText();
        InGameManager.instance.CheckCapacityOver(_currentCapacity);
    }



    public void DeleteObject(bool _isSuccess)
    {
        if (_isSuccess)
        {
            _currentCapacity--;
        }
        SetCapToText();
    }


    void SetCapToText()
    {
        _checkCap.text = "현재 물건 : ";
        _checkCap.text += _currentCapacity.ToString();
        _checkCap.text += "/";
        _checkCap.text += _maxCapacity.ToString();

    }
}
