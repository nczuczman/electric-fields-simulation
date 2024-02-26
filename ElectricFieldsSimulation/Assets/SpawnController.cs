using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField] public GameObject particle;
    // Start is called before the first frame update
    System.Random random = new System.Random();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(particle, transform.position, Quaternion.identity);

            int x = random.Next(-100, 100);
            int y = random.Next(-50, 50);

            Vector3 newPos = new Vector3(x, y, 0);
            transform.position = newPos;

        }
    }
}
