using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player"); // The player
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y);
    }
}
