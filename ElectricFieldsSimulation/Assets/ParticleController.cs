using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private GameObject SourceCharge;
    [SerializeField] private GameObject SourceCharge2;
    [SerializeField] private GameObject SourceCharge3;
    [SerializeField] private float charge;
    private float CouloumbsConstant = 8990000000.0f;

    Rigidbody rig;
    float strengthField1;
    float strengthField2;
    float strengthField3;
    float distance1;
    float distance2;
    float distance3;

    float force1;
    float force2;
    float force3;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        force1 = strengthField1 * charge;
        force2 = strengthField2 * charge;
        force3 = strengthField3 * charge;
        distance1 = Vector2.Distance(rig.transform.position, SourceCharge.transform.position);
        distance2 = Vector2.Distance(rig.transform.position, SourceCharge2.transform.position);
        distance3 = Vector2.Distance(rig.transform.position, SourceCharge3.transform.position);
        if (distance1 > 0.5f)
        {
            strengthField1 = (charge * CouloumbsConstant) / Mathf.Pow(distance1, 2f);
            rig.AddForce((SourceCharge.transform.position - rig.transform.position) * force1);
        }
        if(distance2 > 0.5f)
        {
            strengthField2 = (charge * CouloumbsConstant) / Mathf.Pow(distance2, 2f);
            rig.AddForce((SourceCharge2.transform.position - rig.transform.position) * force2);
        }

        if (distance2 > 0.5f)
        {
            strengthField3 = (charge * CouloumbsConstant) / Mathf.Pow(distance3, 2f);
            rig.AddForce((SourceCharge3.transform.position - rig.transform.position) * force3);
        }

    }
}
