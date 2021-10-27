using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Spawner_practice : MonoBehaviour
{
    [SerializeField]
    List<Transform> _spawnPoss;

    [SerializeField]
    List<GameObject> _gameobjectList = new List<GameObject>();

    [SerializeField]
    GameObject _checkObject;

    [SerializeField]
    Image _timerClock;

    [SerializeField]
    float _spawnTerm = 5f;


    void Start()
    {
        
    }

    float _currentTime, _lastSpawn=0;

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

        }


    }




    public void SpawnInOrder()
    {
        foreach (Transform _tranform in _spawnPoss)
        {
            GameObject _spawnObject = Instantiate(_checkObject, _tranform.position, Quaternion.identity, gameObject.transform);
            _gameobjectList.Add(_spawnObject);

            CheckObject _check = _spawnObject.GetComponent<CheckObject>();
            if (Random.Range(0,2) == 1)
            {
                _spawnObject.name = "flawed";
                Debug.Log(_check.name);
                _check._objectStatus = ObjectStatus.Defect_PartsLoss;
            }

            _check.InitializeObject();

        }

    }

}
