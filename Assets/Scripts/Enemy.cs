using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateController
{
    public float speed = 5.0f;
    public float nextWaypointDistance = 3f;
    public float rotSpeed = 200.0f;
    public int life = 1;
    public int damage = 1;
    
    public delegate void SpawnEnemy();
    public static event SpawnEnemy OnDeath;

    public Chase chaseState;

    public int currentWaypoint = 0;
    public bool reachedEndOfPath = false;


    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        currentState = chaseState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("FProjectile")) {
            life -= col.GetComponent<Bullet>().damage;
        }

        if (life <= 0) {
            Destroy(gameObject);
            OnDeath?.Invoke();
        }
    }
}
