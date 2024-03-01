using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private GameObject SourceCharge;
    [SerializeField] private GameObject particle;
    [SerializeField] private float charge;
    private float CouloumbsConstant = 8990000000.0f;
    List<GameObject> particles = new List<GameObject>();

    public Vector3 screenPosition;
    public Vector3 worldPosition;


    // Start is called before the first frame update
    void Start()
    {

        screenPosition = Input.mousePosition;

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        particles.Add(particle);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject particle in particles)
        {
            float distance = Vector3.Distance(particle.transform.position, SourceCharge.transform.position);
            if (distance > 0.2f)
            {
                float fieldStrength = (CouloumbsConstant * charge) / Mathf.Pow(distance, 2f);
                Vector3 force = (SourceCharge.transform.position - particle.transform.position) * fieldStrength * charge * Time.deltaTime;
                particle.GetComponent<Rigidbody>().AddForce(force);
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            screenPosition = Input.mousePosition;

            worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            GameObject newParticle = Instantiate(particle, worldPosition, Quaternion.identity);
            particles.Add(newParticle);

        }

    }
}
