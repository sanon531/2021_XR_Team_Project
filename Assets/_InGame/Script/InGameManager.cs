using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;

    public int _max_Capacity;
    private Spawner_practice _spawner_Practice;
    public List<float> _currentList = new List<float>() { 5f,5f,5f,5f };
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        _spawner_Practice = GameObject.Find("Spawner").GetComponent<Spawner_practice>();
        _spawner_Practice.BeginObject();
    }

    public void GameEnd()
    {


    }

 



}
