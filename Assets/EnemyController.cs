using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy variables")]
    public bool PlayerSighted;
    public bool EnemyBite;
    public GameObject Player;
    public float Speed;
    public int MinDis;
    public int MaxDis;


    // Start is called before the first frame update
    void Start()
    {
        PlayerSighted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerSighted == true)
            PlayerFound();
    }

    void PlayerFound()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) >= MinDis) {
            move();
            if (Vector3.Distance(transform.position, Player.transform.position) <= MaxDis) {
                EnemyBite = true;
            }
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == Player) {
            GetComponent<AudioSource>().Play();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform == Player.transform) {

            PlayerSighted = true;
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform == Player.transform) {
            PlayerSighted = false;
        }
    }
    
    void move()
    {
        transform.LookAt(Player.transform);
        // enemy moves forward
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

}
