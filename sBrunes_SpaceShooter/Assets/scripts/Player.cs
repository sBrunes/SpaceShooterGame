using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject laserPrefab;
    public GameObject BigLaserPrefab;
    public float speed = 15f;
    private Rigidbody2D r2d;
    private float health;
    public float maxHealth;
    private GameObject GameUI;
    private Animator animator;
    private bool canFire = true;
    private float FireTimer;

    public GameObject ShieldSprite;

    private bool canShield = true;
    private bool isShielding;
    private float shieldTimer;
    private float shieldCooldownTimer;

    public AudioSource shootSound;
    public AudioSource BigLaserShootSound;
    public AudioSource ShieldUpSound;
    public AudioSource ShieldDownSound;

    public GameObject Explosion;
    //public AudioSource explodeSound;

    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        GameUI = GameObject.Find("GameUI");
        health = maxHealth;
        animator = GetComponent<Animator>();

        ShieldSprite.SetActive(false);
    }

    public void EnemyCollide() 
    {
        if(!isShielding) {
            health -= 1;
            GameUI.SendMessage("setHealthPercent", health / maxHealth);
            GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);

            if(health <= 0)
            {
            
            GameUI.SendMessage("showRespawn", SendMessageOptions.DontRequireReceiver);

            this.gameObject.SetActive(false);
            }
        }
    }

    public void Respawn() 
    {
        health = maxHealth;
        GameUI.SendMessage("setHealthPercent", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVec = new Vector2();

        moveVec.y = Input.GetAxis("Vertical") * speed;

        r2d.AddForce(moveVec);

        animator.SetFloat("speed", Mathf.Abs(moveVec.y));

        if( Input.GetButtonDown("Jump")) {
            if(canShield)
            {
                ShieldSprite.SetActive(true);

                ShieldUpSound.Play();

                canShield = false;

                isShielding = true;

                shieldTimer = 2f;

                shieldCooldownTimer = 5f;
            }
        }

        if(!canShield)
        {
            if(shieldTimer >= 0f) {
                shieldTimer -= Time.deltaTime;
            }
            if((shieldTimer <= 0f) && isShielding) {
                isShielding = false;
                ShieldSprite.SetActive(false);
                ShieldDownSound.Play();
            }
            if(!isShielding)
            {
                if(shieldCooldownTimer >= 0) {
                    shieldCooldownTimer -= Time.deltaTime;
                }
                if(shieldCooldownTimer <= 0f) {
                    canShield = true;
                }
            }
        }

        //shoot response
        if( Input.GetButtonDown("Fire1"))      
        {
            Instantiate(laserPrefab, this.transform.position, Quaternion.identity);

            shootSound.Play();

        }

        if( Input.GetButtonDown("Fire2"))
        {
            if(canFire)
            {
                canFire = false;

                FireTimer = 2f;

                Instantiate(BigLaserPrefab, this.transform.position, Quaternion.identity);

                BigLaserShootSound.Play();
            }
        }

        if(!canFire)
        {
            FireTimer -= Time.deltaTime;

            if(FireTimer <= 0f) 
            {
                canFire = true;
            }
        }
    }
}
