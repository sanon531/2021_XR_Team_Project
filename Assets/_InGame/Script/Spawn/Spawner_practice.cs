using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
public class Spawner_practice : Spawner_Base
{

    public static Spawner_practice instance;

    [SerializeField]
    List<Transform> _spawnPoss;

    [SerializeField]
    List <GameObject> _checkObject;
    [SerializeField]
    List<GameObject> _currentSettedList = new List<GameObject>();

    [SerializeField]
    TextMeshProUGUI _checkCap;


    public void BeginObject()
    {
        instance = this;
    }


    [SerializeField]
    int _currentPickNum = 4;

    public void SpawnInOrder()
    {
        _currentPickNum = 4;
        int _true_i = Random.Range(0, 4);
        int i = 0;
        foreach (Transform _tranform in _spawnPoss)
        {
            GameObject _spawnObject = Instantiate(_checkObject[i], _tranform.position, Quaternion.identity, gameObject.transform);
            _currentSettedList.Add(_spawnObject);
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
        if (_currentSettedList.Contains(_argOBJ))
        {
            _currentSettedList.Remove(_argOBJ);
            Destroy(_argOBJ);
            _currentPickNum--;
            if (_isSuccess)
                PlayPanelScript.instance.RightSelected();
            else
                PlayPanelScript.instance.WrongSelected();

            if (_currentPickNum <= 0)
                SpawnInOrder();
        }

    }

    public void ClearObject()
    {
        foreach (GameObject arg_gameObject in _currentSettedList)
        {
            Destroy(arg_gameObject);
        }
    }


}
