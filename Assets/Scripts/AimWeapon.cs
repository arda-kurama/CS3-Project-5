using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour {

    public Transform aimTransform;
    public Transform spawnPoint;
    public Camera mainCamera;

    public GameObject bulletPrefab;
    public float bulletForce;

    private void Update() {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 aimDirection = (mousePosition - aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 localScale = Vector3.one;
        if (angle > 90 || angle < -90) {
            localScale.y = -1f;
        } else {
            localScale.y = +1f;
        }
        aimTransform.localScale = localScale;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(aimDirection.normalized * bulletForce, ForceMode2D.Impulse);
        }
    }
}
