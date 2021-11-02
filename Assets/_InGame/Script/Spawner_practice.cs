using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Spawner_practice : Spawner_Base
{

    public static Spawner_practice instance;

    [SerializeField]
    List<Transform> _spawnPoss;


    [SerializeField]
    GameObject _checkObject;

    [SerializeField]
    Text _currentWaveName;

    [SerializeField]
    TextMeshProUGUI _checkCap;


    public void BeginObject()
    {
        instance = this;
    }


    float _currentTime=0;
    float _waveTerm = 60f;
    float _currentWave = 0;
    bool _isGameStart = false;


    private void Update()
    {
        if (_isGameStart)
            _currentTime += Time.deltaTime;

        if (_currentTime > _waveTerm)
            _currentTime = 0;



    }

    public void WaveChanged(GameObject _argCheckOBJ)
    {
        _checkObject = _argCheckOBJ;
    }
    public void SpawnInOrder()
    {
        int _true_i = Random.Range(0, 4);
        int i = 0;
        foreach (Transform _tranform in _spawnPoss)
        {
            GameObject _spawnObject = Instantiate(_checkObject, _tranform.position, Quaternion.identity, gameObject.transform);

            CheckObject _check = _spawnObject.GetComponent<CheckObject>();

            if (i != _true_i)
            {
                ObjectStatus _falseState = (ObjectStatus)Random.Range(1, 4);
                _spawnObject.name = _falseState.ToString();
                _check._objectStatus = _falseState;
            }
            _check.InitializeObject();
            i++;
        }
    }



    public void DeleteObject(bool _isSuccess)
    {
        if (_isSuccess)
        {
            //yEAH
        }
    }


}
