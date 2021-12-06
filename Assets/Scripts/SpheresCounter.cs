using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpheresCounter : MonoBehaviour
{
    GameObject newSphere;
    public GameObject sphereOriginal, particleOriginal;
    int sphereCounter;
    public Text counterTxt;


    // Start is called before the first frame update
    void Start()
    {

        newSphere = (GameObject)Instantiate(sphereOriginal, new Vector3(Random.Range(-60f, 60f), 30, Random.Range(-50f, 55f)), Quaternion.identity);
        newSphere = (GameObject)Instantiate(sphereOriginal, new Vector3(Random.Range(-60f, 60f), 30, Random.Range(-50f, 55f)), Quaternion.identity);
        newSphere = (GameObject)Instantiate(sphereOriginal, new Vector3(Random.Range(-60f, 60f), 30, Random.Range(-50f, 55f)), Quaternion.identity);
        newSphere = (GameObject)Instantiate(sphereOriginal, new Vector3(Random.Range(-60f, 60f), 30, Random.Range(-50f, 55f)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sphere")
        {
            sphereCounter += 1;
            Debug.Log("Contador de esferas: " + sphereCounter);
            Destroy(collision.gameObject);
            GameObject newParticle;
            newParticle = (GameObject)Instantiate(particleOriginal, collision.transform.position, this.transform.rotation);
            Destroy(newParticle, 3);
            newSphere = (GameObject)Instantiate(sphereOriginal, new Vector3(Random.Range(-60f, 60f), 30, Random.Range(-50f, 55f)), Quaternion.identity);
            counterTxt.text = "Esferas: " + sphereCounter;
        }


    }
}
