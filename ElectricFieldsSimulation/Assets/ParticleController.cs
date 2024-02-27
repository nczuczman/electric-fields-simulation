using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private GameObject SourceCharge;
    [SerializeField] private float charge;
    private float CouloumbsConstant = 8990000000.0f;

    Rigidbody rig;
    float strengthField1;
    float distance1;
    float force1;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        force1 = strengthField1 * charge;
        distance1 = Vector2.Distance(rig.transform.position, SourceCharge.transform.position);
        if (distance1 > 0.1f)
        {
            strengthField1 = (charge * CouloumbsConstant) / Mathf.Pow(distance1, 2f);
            rig.AddForce((SourceCharge.transform.position - rig.transform.position) * force1);
        }

    }
}
