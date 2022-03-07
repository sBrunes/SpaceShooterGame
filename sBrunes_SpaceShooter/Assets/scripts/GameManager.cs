using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject GameUI;


    // Update is called once per frame
    void Update()
    {
        if(player.activeSelf != true)
        {
            if(Input.GetButton("Jump"))
            {
                player.gameObject.SetActive(true);

                GameObject GameUI = GameObject.Find("GameUI");
                GameUI.SendMessage("hideRespawn", SendMessageOptions.DontRequireReceiver);
                player.SendMessage("Respawn", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
