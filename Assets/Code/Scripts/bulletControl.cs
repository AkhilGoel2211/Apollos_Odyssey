using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody bulletBody;
    [SerializeField] float bulletSpeed;

    private void Awake()
    {
        bulletBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        bulletBody.velocity = transform.forward * bulletSpeed;
    }
    private void OnTriggerEnter(Collider otherBody)
    {
        Destroy(gameObject);
    }
}
