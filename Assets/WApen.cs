using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WApen : MonoBehaviour
{
    public float damage = 21;
    public float fireRate = 1;
    public float force = 155;
    public float range = 15;
    public ParticleSystem muzzleFlash;
    public Transform bulletSpawn;
    public AudioClip shot;
    public AudioSource _audioSource;
    public Collider Jill_HiRes_Gown_Geo;
    public Camera _cam;
    private Animator myAnim;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        _audioSource.PlayOneShot(shot);
        Instantiate(muzzleFlash,bulletSpawn.position,bulletSpawn.rotation);
        muzzleFlash.Play();

        RaycastHit hit;
        if(Physics.Raycast(_cam.transform.position,_cam.transform.forward,out hit, range))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
                
            }
            
            if (hit.collider == Jill_HiRes_Gown_Geo)
            {
                myAnim.SetBool("Idle", false);
                myAnim.SetBool("Run", false);
                myAnim.SetBool("Atack", false);
                myAnim.SetBool("Dying", true); 
            }
        }
    }
}
