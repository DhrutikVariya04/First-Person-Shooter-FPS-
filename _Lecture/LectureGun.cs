using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectureGun : MonoBehaviour
{

    public Transform gunPoint;

    LineRenderer lineRenderer;

    Vector3 centerPos = new Vector3(.5f, .5f, 0);

    public Camera cam;

    public float weaponRange;

    public GameObject bulletPrefab;

    public float bulletForce;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, gunPoint.position);

        var rayOrigin = cam.ViewportToWorldPoint(centerPos);

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, (cam.transform.forward * weaponRange), out hit))
        {
            lineRenderer.SetPosition(1, hit.point);

            if (Input.GetMouseButtonDown(0))
            {

                var b = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);
                var rb = b.GetComponent<Rigidbody>();
                //b.transform.position = gunPoint.position;

                gunPoint.LookAt(hit.point);

                rb.AddForce(gunPoint.forward.normalized * bulletForce);
            }

        }
        else
        {
            lineRenderer.SetPosition(1, rayOrigin + (cam.transform.forward * weaponRange));
        }


    }

}
