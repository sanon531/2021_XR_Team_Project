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
    List<GameObject> _currentSettedList = new List<GameObject>();

    [SerializeField]
    TextMeshProUGUI _checkCap;


    public void BeginObject()
    {
        instance = this;
    }



    int _currentPickNum = 4;

    public void WaveChanged(GameObject _argCheckOBJ)
    {
        _checkObject = _argCheckOBJ;
    }
    public void SpawnInOrder()
    {
        _currentPickNum = 4;
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



    public void DeleteObject(GameObject _argOBJ, bool _isSuccess)
    {
        _currentSettedList.Remove(_argOBJ);
        Destroy(_argOBJ);

        if (_isSuccess)
            PlayPanelScript.instance.RightSelected();
        else
            PlayPanelScript.instance.WrongSelected();

        if (--_currentPickNum <= 0)
            SpawnInOrder();
    }

    public void ClearObject()
    {
        foreach (GameObject arg_gameObject in _currentSettedList)
        {
            _currentSettedList.Remove(arg_gameObject);
            Destroy(arg_gameObject);
        }

        _currentPickNum = 4;
    }


}
