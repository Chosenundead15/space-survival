using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotSpeed = 10.0f;
    public int life = 3;

    public GameObject bullet;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }

        float move_v = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float move_h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (mousePos - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.Translate(move_h, move_v, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, Time.deltaTime * rotSpeed);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy")) {
            life -= col.GetComponent<Enemy>().damage;
            GetComponent<Animator>().enabled = true;
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(EnableCollision(1));
        }

        if (life <= 0) {
            Destroy(gameObject);
        }
    }

    private IEnumerator EnableCollision(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Animator>().enabled = false;
    }
}
