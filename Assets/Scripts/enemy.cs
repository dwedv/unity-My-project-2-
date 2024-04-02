using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
    }


}
