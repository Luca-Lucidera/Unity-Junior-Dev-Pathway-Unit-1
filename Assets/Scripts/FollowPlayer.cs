using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    private Vector3 offset = new(0, 5, -9);

    // Update is called once per frame
    void LateUpdate()
    {
        //imposto la telecamera alla posizione del player + un distaccamento
        transform.position = player.transform.position + offset;
    }
}
