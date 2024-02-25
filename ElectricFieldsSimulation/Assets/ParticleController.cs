using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private GameObject SourceCharge;
    private float speed = 1.0f;
    [SerializeField] private float mass = 1.0f;
    [SerializeField] private float charge = 1.0f;
    private float force = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        force = SourceCharge.getComponent<FieldStrength>() * charge;
        transform.position = Vector2.MoveTowards(transform.position, SourceCharge.transform.position, speed * Time.deltaTime);
    }
}
