using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private GameObject[] _vCams = new GameObject[2];
    public GameObject stickman;
    public GameObject stickman1;

    public float roundTime;
    private float nextRoundTime = 10;

    public Image roundTimer;
    
    void Start()
    {
        stickman1.GetComponent<Movement>().enabled = false;
        stickman1.GetComponent<AimWeapon>().enabled = false;
    }

    void Update()
    {
        roundTimer.fillAmount = (nextRoundTime - Time.time) / roundTime;
        if (Time.time > nextRoundTime)
        {
            roundTimer.fillAmount = 0f;
            nextRoundTime = Time.time + roundTime;
            if (_vCams[0].activeSelf)
            {
                _vCams[0].SetActive(false);

                stickman.GetComponent<Movement>().enabled = false;
                stickman.GetComponent<AimWeapon>().enabled = false;

                stickman1.GetComponent<Movement>().enabled = true;
                stickman1.GetComponent<AimWeapon>().enabled = true;
            }
            else
            {
                _vCams[0].SetActive(true);

                stickman.GetComponent<Movement>().enabled = true;
                stickman.GetComponent<AimWeapon>().enabled = true;

                stickman1.GetComponent<Movement>().enabled = false;
                stickman1.GetComponent<AimWeapon>().enabled = false;
            }
        }
    }
}
