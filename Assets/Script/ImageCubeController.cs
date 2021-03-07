using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCubeController : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            Destroy(collision.gameObject);
        }
    }
}
