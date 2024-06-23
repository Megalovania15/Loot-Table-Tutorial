using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private LootTable lootTable;

    // Start is called before the first frame update
    void Start()
    {
        lootTable = GetComponent<LootTable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Death()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            lootTable.InstantiateLoot(transform.position);
            Destroy(other.gameObject);
            Death();
        }
    }
}
