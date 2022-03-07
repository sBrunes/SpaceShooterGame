using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    public float shootSpeed = 100f;
    public bool IsBigLaser;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D r2d = GetComponent<Rigidbody2D>();

        r2d.AddForce( new Vector2(shootSpeed,0f));

        Destroy(this.gameObject, 2f);
    }

    void Update() {
        if(IsBigLaser) {
            transform.Rotate(Vector3.forward * 4f);
        }
    }

}
