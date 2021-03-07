using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Space]
    [SerializeField]
    private float speed = 1f;
    public float lerpRotateSpeed;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var hitPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                if ((hitPoint - transform.position).magnitude>1)
                {
                    rb.velocity = (hitPoint - transform.position).normalized * speed;
                    transform.forward = Vector3.Lerp(transform.forward, (hitPoint - transform.position).normalized, lerpRotateSpeed * Time.deltaTime);
                }
                
            }
        }
    }
}
