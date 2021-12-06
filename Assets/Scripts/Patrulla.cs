using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrulla : MonoBehaviour
{
    public GameObject p1, p2, p3, p4, player;
    public int currentPoint;
    public float margin = 1;
    public float range = 2;
    public NavMeshAgent myAgent;

    public GameObject ammoOriginal;
    float nextFire;
    float fireRate;

    public GameObject refSpawn;

    public float angleVis;



    // Start is called before the first frame update
    void Start()
    {
        myAgent = this.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
        SpotPlayer();

    }

    void Patrol()
    {

        Vector3 distance = this.transform.position - myAgent.destination;

        //Set the destination of the enemy depending on the current point of patrol
        if (distance.magnitude < margin)
        {
            if (currentPoint == 1)
            {
                currentPoint = 2;
                myAgent.SetDestination(p2.transform.position);
                Debug.Log("Me dirijo al punto de patrulla2");
            }
            else if (currentPoint == 2)
            {
                currentPoint = 3;
                myAgent.SetDestination(p3.transform.position);
                Debug.Log("Me dirijo al punto de patrulla3");
            }
            else if (currentPoint == 3)
            {
                currentPoint = 4;
                myAgent.SetDestination(p4.transform.position);
                Debug.Log("Me dirijo al punto de patrulla4");
            }
            else if (currentPoint == 4)
            {
                currentPoint = 1;
                myAgent.SetDestination(p1.transform.position);
                Debug.Log("Me dirijo al punto de patrulla1");
            }
        }
    }

    void SpotPlayer()
    {
        Vector3 distPlayer = player.transform.position - this.transform.position;

        RaycastHit resultRay;

        if (Physics.Raycast(this.transform.position, distPlayer, out resultRay, 10))
        {
            if (resultRay.transform.tag == "Player")
            {
                float angle = Vector3.Angle(this.transform.forward, distPlayer);

                //if player in FOV, lookAt and shoot
                if (angle < angleVis)
                {
                    if (distPlayer.magnitude < 4)
                    {
                        this.transform.LookAt(player.transform.position);
                        Shoot();
                    }
                    else
                    {
                        myAgent.SetDestination(player.transform.position);
                        Shoot();
                    }

                }

            }
        }
        else
        {
            myAgent.speed = 2;
        }
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            //Shooting delay
            fireRate = 1;
            nextFire = Time.time + fireRate;
            //Instantiate the ammo
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
