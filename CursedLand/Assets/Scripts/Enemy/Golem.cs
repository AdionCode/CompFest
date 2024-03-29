using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    [SerializeField] private int attackDamage = 40;
    [SerializeField] private float attackSpeed = 3f;
    private float canAttack;
    public float speed = 3f;
    private Transform target;

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //canAttack = attackSpeed;

    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        if (attackSpeed <= canAttack)
    //        {
    //            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    //            canAttack = 0f;
    //        }
    //        else
    //        {
    //            canAttack += Time.deltaTime;
    //        }


    //    }

    //}

    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //target = other.transform;
            //Debug.Log("Masuk");

            if (attackSpeed <= canAttack)
            {
                Debug.Log("HYA");
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                canAttack = 0f;
            }
            else
            {
                //Debug.Log(canAttack);
                //Debug.Log("CD");
                canAttack += Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //target = null;
            Debug.Log("Keluar");
        }
    }
    private void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }

    }
}
