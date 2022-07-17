using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    public float speed = 3f;
    private Transform target;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log("inRange");
            if (attackSpeed<=canAttack)
            {
                Debug.Log("NYEH");
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                canAttack = 0f;
            }
            else
            {
                //Debug.Log("gob_CD");
                canAttack += Time.deltaTime;
            }
            
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = other.transform;
            Debug.Log("Masuk");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = null;
            Debug.Log("Keluar");
        }
    }
    private void Update()
    {
        if(target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
        
    }
}
