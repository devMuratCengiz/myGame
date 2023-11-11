using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifesParent : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    
    void Update()
    {
        transform.position = player.transform.position;
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
