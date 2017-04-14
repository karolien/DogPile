using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private bool stopped;
    private Rigidbody2D rb;
    public IEnumerator co;

    public float MOVEMENT_TIME = 2.0f; // The object moves for 2 seconds
    public float MOVEMENT_DISTANCE = 1.0f; // Distance the object should move

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        co = MoveObject(MOVEMENT_DISTANCE);
        StartCoroutine(co);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void stopMoving()
    {
        rb.simulated = true;    // Enable rigibody physics
        StopCoroutine(co);      // Stop moving
        stopped = true;
    }

    private IEnumerator MoveObject(float distance)
    {
        Vector3 currentPosition = this.transform.position;
        Vector3 targetPosition = new Vector3(this.transform.position.x + distance, this.transform.position.y, this.transform.position.z);
        float currentTime = 0.0f;

        while (currentTime <= MOVEMENT_TIME)
        {
            if (stopped)
            {
                Debug.Log("yeild");
                stopped = false;
                yield break;
            }
            float movementFactor = currentTime / MOVEMENT_TIME;
            this.transform.position = Vector3.Lerp(currentPosition, targetPosition, movementFactor);
            currentTime += Time.deltaTime;
            yield return null;
        }
        currentPosition = this.transform.position;
        targetPosition = new Vector3(this.transform.position.x - distance, this.transform.position.y, this.transform.position.z);
        currentTime = 0.0f;
        while (currentTime <= MOVEMENT_TIME)
        {
            if (stopped)
            {
                Debug.Log("yeild");
                stopped = false;
                yield break;
            }
            float movementFactor = currentTime / MOVEMENT_TIME;
            this.transform.position = Vector3.Lerp(currentPosition, targetPosition, movementFactor);
            currentTime += Time.deltaTime;
            yield return null;
        }
    }
}
