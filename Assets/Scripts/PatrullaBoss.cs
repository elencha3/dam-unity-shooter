using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrullaBoss : MonoBehaviour
{

    public GameObject player;
    public NavMeshAgent myAgent;
    float nextFire;
    float fireRate;

    public GameObject refSpawn;
    public GameObject ammoOriginal;

    public float angleVis;

    // Start is called before the first frame update
    void Start()
    {
        myAgent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Follow the player
        myAgent.SetDestination(player.transform.position);
        //Shoot the player if inside FOV
        ShootPlayer();
    }


    void ShootPlayer()
    {
        //Check FOV

        Vector3 distPlayer = player.transform.position - this.transform.position;

        RaycastHit resultRay;

        if (Physics.Raycast(this.transform.position, distPlayer, out resultRay, 10))
        {
            if (resultRay.transform.tag == "Player")
            {
                float angle = Vector3.Angle(this.transform.forward, distPlayer);

                if (angle < angleVis)
                {
                    if (distPlayer.magnitude < 4)
                    {
                        this.transform.LookAt(player.transform.position);
                        Shoot();
                    }
                }
            }
        }
    }

    void Shoot()
    {
        //Shoot with delay
        if (Time.time > nextFire)
        {
            fireRate = 1;
            nextFire = Time.time + fireRate;
            GameObject newAmmo;
            newAmmo = (GameObject)Instantiate(ammoOriginal, refSpawn.transform.position, this.transform.rotation);
            Destroy(newAmmo, 2);

            //Get the ref of Rigidbody
            Rigidbody clonRigid;
            clonRigid = newAmmo.GetComponent<Rigidbody>();

            //Velocity
            clonRigid.velocity = refSpawn.transform.forward * Time.deltaTime * 700;
        }

    }
}
