using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using _TestObject;
public class Spawner_practice : Spawner_Base
{

    public static Spawner_practice instance;

    [SerializeField]
    List<Transform> _spawnPoss;

    [SerializeField]
    List <GameObject> _checkObject_Stage_1;
    [SerializeField]
    List<GameObject> _checkObject_Stage_2;

    [SerializeField]
    List<GameObject> _currentSettedList = new List<GameObject>();

    [SerializeField]
    TextMeshProUGUI _checkCap;


    public void BeginObject()
    {
        instance = this;
    }


    [SerializeField]
    int _currentPickNum = 3;
    int _current_StageInt;
    public void SpawnInOrder(int _currentStage)
    {
        _current_StageInt = _currentStage;
        _currentPickNum = 3;
        int _true_i = Random.Range(0, 3);
        int i = 0;
        foreach (Transform _tranform in _spawnPoss)
        {
            GameObject _spawnObject = gameObject;
            if (_currentStage == 0)
                _spawnObject = Instantiate(_checkObject_Stage_1[i], _tranform.position, Quaternion.identity, gameObject.transform);
            else
                _spawnObject = Instantiate(_checkObject_Stage_2[i], _tranform.position, Quaternion.identity, gameObject.transform);

            _currentSettedList.Add(_spawnObject);
            if (i != _true_i)
            {
                float _random = Random.Range(0f, 1f);
                if (_random > 0.5f)
                    _spawnObject.GetComponent<TestObject>().SetDefect(1);
                else
                    _spawnObject.GetComponent<TestObject>().SetDefect(0);
            }
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
                SpawnInOrder(_current_StageInt);
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
