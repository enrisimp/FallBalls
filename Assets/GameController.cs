using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject ball;
    public Transform spawnPoint;

    public float maxX;
    public float maxZ;

    GameObject[] cubes;

    public float waitingTime;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();

        InvokeRepeating("SpawnBall", 1f, 2f);

        //DestroyAllCubes();
        //Invoke("DestroyAllCubes", 2f);

        //StartCoroutine("DestroyCubes");
        //StartCoroutine(DestroyCubes());

        //StartCoroutine(DestroyCubes(2));
        StartCoroutine(DestroyCubes(waitingTime));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBall();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;

            mousePos.z = 10;

            Vector3 spawnPos = Camera.main.ScreenToWorldPoint(mousePos);

            Instantiate(ball, spawnPos, Quaternion.identity);

        }
    }

    void SpawnBall()
    {
        float randomX = Random.Range(-maxX,maxX);
        float randomZ = Random.Range(-maxZ,maxZ);

        Vector3 randomSpawnPos = new Vector3(randomX, 10f, randomZ);
        Instantiate(ball, randomSpawnPos, Quaternion.identity);

        //Instantiate(ball, spawnPoint.position, Quaternion.identity);
    }

    void DestroyAllCubes()
    {
        cubes = GameObject.FindGameObjectsWithTag("Cube");

        foreach (GameObject g in cubes)
        {
            Destroy(g);
        }
    }

    //IEnumerator DestroyCubes()
    IEnumerator DestroyCubes(float waitTime)
    {
        //yield return new WaitForSeconds(2);

        cubes = GameObject.FindGameObjectsWithTag("Cube");

        foreach (GameObject g in cubes)
        {
            //yield return new WaitForSeconds(2);
            yield return new WaitForSeconds(waitTime);

            Destroy(g);
        }

    }
}
