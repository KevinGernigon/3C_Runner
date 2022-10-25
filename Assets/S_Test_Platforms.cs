using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Test_Platforms : MonoBehaviour
{
    [SerializeField]
    private GameObject _centerPlatforms;
    public bool _platformsMoving = false;
    private float _timeCount;
    private float _speed = 3000f;
    private float _speed_time = 135f;
    //private Vector3 _originalRotation;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space) && _platformsMoving == false) 
        {
            _originalRotation = _centerPlatforms.transform.eulerAngles;
            _timeCount = 0;
            _platformsMoving = true;
           StartCoroutine(MovePlatforms(_centerPlatforms));
        }*/

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && _platformsMoving == false)
        {
            //_originalRotation = _centerPlatforms.transform.eulerAngles;
            _timeCount = 0;
            _platformsMoving = true;
            StartCoroutine(MovePlatformsWheel(_centerPlatforms, true));
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && _platformsMoving == false)
        {
            //_originalRotation = _centerPlatforms.transform.eulerAngles;
            _timeCount = 0;
            _platformsMoving = true;
            StartCoroutine(MovePlatformsWheel(_centerPlatforms, false));
        }
    }

    /*IEnumerator MovePlatforms(GameObject platforms)
    {
        while(_platformsMoving)
        {
            _centerPlatforms.transform.Rotate(Vector3.right * _speed * Time.deltaTime);
            _timeCount += Time.deltaTime * _speed_time;
            if (_timeCount>=2)
            {
                Debug.Log("time spent");
                _platformsMoving = false;
            }
            yield return new WaitForSeconds(0.025f);
        }
    }*/

    IEnumerator MovePlatformsWheel(GameObject platforms, bool orientation)
    {
        while (_platformsMoving)
        {
            if (orientation == true)
            {
                _centerPlatforms.transform.Rotate(Vector3.right * _speed * Time.deltaTime);
                _timeCount += Time.deltaTime * _speed_time;
                if (_timeCount >= 2)
                {
                    Debug.Log("time spent");
                    _platformsMoving = false;
                }
                yield return new WaitForSeconds(0.025f);
            }
            else if (orientation == false)
            {
                _centerPlatforms.transform.Rotate(Vector3.left * _speed * Time.deltaTime);
                _timeCount += Time.deltaTime * _speed_time;
                if (_timeCount >= 2)
                {
                    Debug.Log("time spent");
                    _platformsMoving = false;
                }
                yield return new WaitForSeconds(0.025f);
            }
        }
    }

}

