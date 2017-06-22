﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetriminoController : MonoBehaviour {
    public GameObject tetrimino;
    public GameObject tetriminoWithSpinner;

    private HingeJoint2D fix;

    void Start() {
        Debug.Log("A wild tetrimino appeared!");
    }

    
    Vector2 GetMousePosition() {
        Camera camera = Camera.main;

        Vector2 mousePos = Input.mousePosition;
        Vector2 MouseCoordinates = camera.ScreenToWorldPoint(mousePos);
        return MouseCoordinates;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(tetriminoWithSpinner,
                        new Vector2(GetMousePosition().x, 32),
                        Quaternion.identity);
        }
        if (Input.GetMouseButtonDown(1)) {
            Instantiate(tetrimino,
                        new Vector2(GetMousePosition().x, 32),
                        Quaternion.identity);
        }
    }

    private bool hasJoint = false;
    void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Tetrimino") && !hasJoint) {
            if (collision.relativeVelocity.magnitude == 0) {
                fix = gameObject.AddComponent<HingeJoint2D>();
                fix.connectedBody = collision.gameObject.rigidbody;
                hasJoint = true;
            }
        }
    }
}
