using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hand_Presence : MonoBehaviour
{
    public bool _showController = false;
    public InputDeviceCharacteristics _controllerChar;
    public List<GameObject> _controllerPrefabs;
    private InputDevice _targetDevice;
    public GameObject _handModelPrefab;

    private GameObject _spawnedController;
    [SerializeField]
    private GameObject _spawnedHandModel;
    [SerializeField]
    private Animator _handAnimator;

    private void Start()
    {
        TryInitialize();
    }

    // Start is called before the first frame update
    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(_controllerChar, devices);

        if (devices.Count > 0)
        {
            _targetDevice = devices[0];
            GameObject prefab = _controllerPrefabs.Find(controller=> controller.name == _targetDevice.name);

            if (prefab)
            {
                _spawnedController = Instantiate(prefab, transform);

            }
            else
            {
                Debug.LogError("Did not find controller");
                _spawnedController = Instantiate(_controllerPrefabs[0]);
            }
            _spawnedHandModel = Instantiate(_handModelPrefab, transform);
            _handAnimator = _spawnedHandModel.GetComponent<Animator>();
        }

    }

    void UpdateHandAnimation()
    {
        if (_targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            _handAnimator.SetFloat("Trigger", triggerValue);
        else
            _handAnimator.SetFloat("Trigger", 0);

        if (_targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            _handAnimator.SetFloat("Grip", gripValue);
        else
            _handAnimator.SetFloat("Grip", 0);

    }


    // Update is called once per frame
    void Update() 
    {
        if (!_targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            if (_showController)
            {
                _spawnedHandModel.SetActive(false);
                _spawnedController.SetActive(true);
            }
            else
            {
                _spawnedHandModel.SetActive(true);
                _spawnedController.SetActive(false);
                UpdateHandAnimation();
            }
        }



    }
}
