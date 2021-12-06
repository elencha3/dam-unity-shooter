using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlane : MonoBehaviour
{
    //Related to movement
    public float rotSpeed, speed;

    //Related to shooting
    public GameObject ammoOriginal, refSpawn;
    public float nextFire, fireRate;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, speed);

        RotatePlane();
        Shoot();
    }

    void RotatePlane()
    {
        //Rotate left
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(0, -1, 0 * rotSpeed * Time.deltaTime);
        }
        //Rotate right
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0, 1, 0 * rotSpeed * Time.deltaTime);
        }
        //Rotate up
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Rotate(-1, 0, 0 * rotSpeed * Time.deltaTime);
        }
        //Rotate down
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Rotate(1, 0, 0 * rotSpeed * Time.deltaTime);
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Time to next fire
            fireRate = 1;
            nextFire = Time.time + fireRate;

            //Instantiate the ammunition
            GameObject newAmmo;
            newAmmo = (GameObject)Instantiate(ammoOriginal, refSpawn.transform.position, this.transform.rotation);

            //Get the ref of Rigidbody
            Rigidbody clonRigid;
            clonRigid = newAmmo.GetComponent<Rigidbody>();

            //Velocity
            clonRigid.velocity = refSpawn.transform.forward * Time.deltaTime * 7000;

            Destroy(newAmmo, 2);
        }
    }

}


