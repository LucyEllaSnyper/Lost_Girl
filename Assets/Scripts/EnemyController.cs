using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AnimationsController Anim;
    [Header("Enemy variables")]
    
    public bool EnemyBite;

    private Transform Player;

    public float Speed;
    public int MinDis;
    public int MaxDis;
    public bool PlayerSighted;

    private int damage = 20;
    // Start is called before the first frame update


    void Awake()
    {
        PlayerSighted = false;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerSighted == true)
            PlayerFound();
    }

   

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == Player) {
            //GetComponent<AudioSource>().Play();
            //PlayerSighted = true;
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

    void PlayerFound()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) >= MinDis) {

            transform.LookAt(Player.transform);
            
            // enemy moves forward
            transform.position += transform.forward * Speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, Player.transform.position) <= MaxDis) {
                SimpleSampleCharacterControl characterControl = new SimpleSampleCharacterControl();
                characterControl.TakeDamage(damage);
                Anim.Attack();
            }
        }
    }
}

