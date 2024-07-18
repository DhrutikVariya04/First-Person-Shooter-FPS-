using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GunFire : MonoBehaviour
{
    Vector3 CenterPos = new Vector3(0.5f, 0.5f, 0);
    Camera Camera;
    //LineRenderer laserLine;
    Animator animator;
    ParticleSystem Firpartical;

    [SerializeField]
    Image Image;

    [SerializeField]
    Transform GunPos;

    [Space]
    [SerializeField]
    [Range(0, 100)]
    float GunRange = 40;

    [SerializeField]
    GameObject Ammo, AmmoPos, Player;

    void Start()
    {
        //laserLine = GetComponent<LineRenderer>();
        Camera = Camera.main;
        animator = GetComponent<Animator>();
        Firpartical = GetComponentInChildren<ParticleSystem>();
        Firpartical.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    private void Aim()
    {
        var AimOrigin = Camera.ViewportToWorldPoint(CenterPos);
        RaycastHit Hit;

        /*//For Fire Laser :--
        laserLine.enabled = false;
        laserLine.SetPosition(0, GunPos.position);
        Debug.DrawRay(AimOrigin, Camera.transform.forward * GunRange, Color.green);*/

        if (Input.GetMouseButton(0))
        {
            Firpartical.Play();
            animator.SetBool("Fire", true);

            if (Physics.Raycast(AimOrigin, Camera.transform.forward, out Hit, GunRange))
            {
                if (Hit.rigidbody != null)
                {
                    Image.gameObject.SetActive(true);
                    //laserLine.SetPosition(1, Hit.point);
                    Hit.rigidbody.AddForce(-Hit.normal * 10);
                    StartCoroutine(FireEff());
                }
            }
            else
            {
                //laserLine.SetPosition(1, AimOrigin + (Camera.transform.forward * 50f));
            }
        }
        else
        {
            animator.SetBool("Fire", false);
        }
    }

    IEnumerator FireEff()
    {
        yield return new WaitForSeconds(0.1f);
        Image.gameObject.SetActive(false);
    }
}
