using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;
    public GameObject EnemyLaserPrefab;
    public AudioSource ShootSound;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 4f);
    }

    public void OnTriggerEnter2D( Collider2D other)
    {
        
        
        if(other.CompareTag("Laser"))
        {
            GameObject GameUI = GameObject.Find("GameUI");
            GameUI.SendMessage("addPoint", SendMessageOptions.DontRequireReceiver);

            Destroy(other.gameObject);
            health -= 1;

            if(health <= 0)
            {
                Destroy(this.gameObject);
               
            }
        }

        if(other.CompareTag("BigLaser"))
        {
            health -= 1;

            if(health <= 0)
            {
                Destroy(this.gameObject);
               
            }
        }

        if(other.CompareTag("Player"))
        {
            other.gameObject.SendMessage("EnemyCollide");
            Destroy(this.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = this.transform.position + new Vector3(-speed, 0f, 0f);
        transform.position = newPosition;

        if((Random.Range(0, 2000)) == 1) {
           Instantiate(EnemyLaserPrefab, this.transform.position, Quaternion.identity);
        }
    }
}
