using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackCooldown;
    public float startCooldown;

    public Transform attackPos;
    public LayerMask whatisEnemies;
    public float attackRangeX;
    public float attackRangeY;
    public int damage;
    private void Update()
    {
        Attack();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
    void Attack()
    {
        // player is able to attack if not on cooldown
        if (attackCooldown <= 0)
        {
            //then you can attack
            if (Input.GetKey(KeyCode.Space))
            {
                // Check if Player hit enemy hitbox
                Collider2D[] enemy = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 30, whatisEnemies);
                for (int i = 0; i < enemy.Length; i++)
                {
                    enemy[i].GetComponent<enemies>().TakeDamage(damage);
                }
                // Start Cooldown
                attackCooldown = startCooldown;
            }
        }
        else
        {
            attackCooldown -= Time.deltaTime;
        }
    }
}
