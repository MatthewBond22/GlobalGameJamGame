using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public int curHP;
    public int maxHP;

    private void Start()
    {
        curHP = maxHP;
    }

    private void Update()
    {
        if (curHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int damage)
    {
        curHP -= damage;
    }
}
