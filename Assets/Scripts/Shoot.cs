using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    float nextFire;
    float fireRate;
    public GameObject ammoOriginal;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }
    void Shooting()
    {
        //create clon of the ammo and shot when mouse is clicked.
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            fireRate = 1;
            nextFire = Time.time + fireRate;

            //Get the ref of the new clon
            GameObject newAmmo;
            newAmmo = (GameObject)Instantiate(ammoOriginal, this.transform.position, this.transform.rotation);
            Destroy(newAmmo, 2);

            //Get the ref of Rigidbody
            Rigidbody clonRigid;
            clonRigid = newAmmo.GetComponent<Rigidbody>();

            //Velocity
            clonRigid.velocity = this.transform.forward * Time.deltaTime * 750;

        }
    }
}
