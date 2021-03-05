using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTrigger : MonoBehaviour {

    private Animator anim;
    private Player player;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) {
            anim.SetBool("isFollowing", true);
        }
    }

    void OnTriggerStay2D(Collider2D Col)
    {
        if (Col.CompareTag("Player"))
        {
            anim.SetBool("isFollowing", true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            anim.SetBool("isFollowing", false);
        }
    }
}
