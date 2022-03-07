using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float shootSpeed = 100f;

    public void OnTriggerEnter2D( Collider2D other)
    {

        Debug.Log("TEST");
        if(other.CompareTag("Player"))
        {
            other.gameObject.SendMessage("EnemyCollide");
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D r2d = GetComponent<Rigidbody2D>();

        r2d.AddForce( new Vector2(-shootSpeed,0f));

        Destroy(this.gameObject, 3f);
    }
}
