using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 50f;

    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>(); 
    }

    public void AttackHitEvent()      //animation
    {
        if (target == null) return;
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }
}
