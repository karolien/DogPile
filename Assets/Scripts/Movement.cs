using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

  private Rigidbody2D rb;
  public IEnumerator co;
  private Controls controller;
  // Use this for initialization
  void Start () {
    controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controls>();
    rb = GetComponent<Rigidbody2D>();
    co = MoveObject();
    StartCoroutine(co);
	}
	
	// Update is called once per frame
	void Update() { 
    if (Input.GetMouseButtonDown(0))
    {
      //Touch anywhere
      controller.space();
    } 
		
	}
  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.name == "GameBoundary")
    {
      controller.gameOver();
    }
  }

  public void stopMoving()
  {
    rb.simulated = true;    // Enable rigibody physics
    StopCoroutine(co);      // Stop moving
    StartCoroutine(waitThenFreeze());
  }

  private IEnumerator waitThenFreeze() {
    yield return new WaitForSeconds(10);
    rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
  }

  private IEnumerator MoveObject()
  {
    float distance = 4F;
    /*float movement_time = 0.8f;*/
    float movement_time = Random.Range (0.5f, 2f);
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
