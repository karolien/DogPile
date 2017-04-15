﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody2D rb;
    public IEnumerator co;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        co = MoveObject();
        StartCoroutine(co);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  void OnTriggerEvent(Collision col)
  {
    Debug.Log("hit boundary");
    if (col.gameObject.name == "GameBoundary")
    {
      Debug.Log("Game over");
    }
  }

  public void stopMoving()
  {
      rb.simulated = true;    // Enable rigibody physics
      StopCoroutine(co);      // Stop moving
  }

  private IEnumerator MoveObject()
  {
  float distance = 4F;
  float movement_time = 1.0f; // The object moves for 2 seconds
    while (true) {
      Vector3 currentPosition = this.transform.position;
      Vector3 targetPosition = new Vector3(this.transform.position.x + distance, this.transform.position.y, this.transform.position.z);
      float currentTime = 0.0f;

      while (currentTime <= movement_time)
      {
        float movementFactor = currentTime / movement_time;
        this.transform.position = Vector3.Lerp(currentPosition, targetPosition, movementFactor);
        currentTime += Time.deltaTime;
        yield return null;
      }
      currentPosition = this.transform.position;
      targetPosition = new Vector3(this.transform.position.x - distance, this.transform.position.y, this.transform.position.z);
      currentTime = 0.0f;
      while (currentTime <= movement_time)
      {
        float movementFactor = currentTime / movement_time;
        this.transform.position = Vector3.Lerp(currentPosition, targetPosition, movementFactor);
        currentTime += Time.deltaTime;
        yield return null;
      }
    }
  }
}
