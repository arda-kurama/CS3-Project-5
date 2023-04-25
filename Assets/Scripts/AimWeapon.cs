using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimWeapon : MonoBehaviour
{

    public Transform aimTransform;
    public Transform spawnPoint;
    public Camera mainCamera;

    public GameObject bulletPrefab;
    public float bulletForce;

    private float reloadTime = 4f;
    private float nextReload = 4f;
    private bool reload = false;
    private float currentTime;

    public Image reloadTimer;

    private void Start()
    {
        reloadTimer.fillAmount = 0f;
    }

    private void Update()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 aimDirection = (mousePosition - aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 localScale = Vector3.one;

        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = +1f;
        }

        aimTransform.localScale = localScale;

        if (Input.GetMouseButtonDown(0) && reload == false)
        {
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(aimDirection.normalized * bulletForce, ForceMode2D.Impulse);
            currentTime = Time.time;
            reload = true;
        }

        if (reload)
        {
            reloadTimer.fillAmount = (reloadTime - (Time.time - currentTime)) / reloadTime;

            if ((Time.time - currentTime) > 4f)
            {
                nextReload += 4f;
                reloadTimer.fillAmount = 0f;
                reload = false;
            }
        }

    }
}
