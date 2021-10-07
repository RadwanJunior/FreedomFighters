using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour
{
    public int health;
    public float speed;
    private Transform target;
    public ParticleSystem damagedEffect;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDead();
        FollowPlayer();
    }
    public void TakeDamage(int damage)
    {
        damagedEffect.Play();
        StartCoroutine(Dazed());
        health -= damage;
        Debug.Log("damage Taken");
    }
    public void CheckIfDead()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, target.position) > 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
    IEnumerator Dazed()
    {
        speed = 0;
        yield return new WaitForSeconds(0.5f);
        speed = 1;
    }
}
