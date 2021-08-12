using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;    

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnShot");
        hitPoints -= damage;
        if(hitPoints <=0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
        gameObject.SetActive(false);
    }
}
