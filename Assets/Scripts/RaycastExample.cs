using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExample : MonoBehaviour
{
 void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red, 1.0f);
            if (Physics.Raycast(ray, out hit, 5f))
            {
                Debug.Log("Hit: " + hit.collider.name);
            }
            else
            {
                Debug.Log("Nothing Hit");
            }
        }
    }
}
