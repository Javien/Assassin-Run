﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed;
    public float increment;
    public float maxY;
    public float minY;

    private Vector2 targetPos;

    public int health;

    public GameObject moveEffect;
    public Animator camAnim;
    public Text healthDisplay;

    public GameObject spawner;
    public GameObject restartDisplay;

    private void Update()
    {

        if (health <= 0) {
            spawner.SetActive(false);
            restartDisplay.SetActive(true);
            Destroy(gameObject);
        }

        //(hp)

        healthDisplay.text = health.ToString();

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        //(Player movement. Check if player presses arrow keys respond dependent on player input)

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY) {
        //(Effect if character position changes)
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY) {
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
        }
    }
}
