using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private GameObject[] _vCams = new GameObject[2];
    public GameObject stickman;
    public GameObject stickman1;
    public GameObject body;
    public GameObject body1;

    public float roundTime;
    private float nextRoundTime = 10;

    public Image roundTimer;
    public Image reloadTimer;
    public Image reloadTimer1;

    void Start()
    {
        stickman1.GetComponent<Movement>().enabled = false;
        body1.GetComponent<LadderMovement>().enabled = false;
        stickman1.GetComponent<AimWeapon>().enabled = false;
    }

    void Update()
    {
        roundTimer.fillAmount = (nextRoundTime - Time.time) / roundTime;
        if (Time.time > nextRoundTime)
        {
            reloadTimer.fillAmount = 0f;
            reloadTimer1.fillAmount = 0f;
            roundTimer.fillAmount = 0f;
            nextRoundTime = Time.time + roundTime;
            if (_vCams[0].activeSelf)
            {
                _vCams[0].SetActive(false);

                stickman.GetComponent<Movement>().enabled = false;
                body.GetComponent<LadderMovement>().enabled = false;
                stickman.GetComponent<AimWeapon>().enabled = false;

                stickman1.GetComponent<Movement>().enabled = true;
                body1.GetComponent<LadderMovement>().enabled = true;
                stickman1.GetComponent<AimWeapon>().enabled = true;
            }
            else
            {
                _vCams[0].SetActive(true);

                stickman.GetComponent<Movement>().enabled = true;
                body.GetComponent<LadderMovement>().enabled = true;
                stickman.GetComponent<AimWeapon>().enabled = true;

                stickman1.GetComponent<Movement>().enabled = false;
                body1.GetComponent<LadderMovement>().enabled = false;
                stickman1.GetComponent<AimWeapon>().enabled = false;
            }
        }
    }
}
