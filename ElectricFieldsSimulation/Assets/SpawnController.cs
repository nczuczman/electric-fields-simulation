using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField] public GameObject particle;
    // Start is called before the first frame update
    public Vector3 screenPosition;
    public Vector3 worldPosition;

    void Start()
    {
        screenPosition = Input.mousePosition;

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            screenPosition = Input.mousePosition;

            worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            Instantiate(particle, worldPosition, Quaternion.identity);
        }
    }
}
