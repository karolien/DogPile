using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
  public Rigidbody2D rb;
  public bool space;
  public float height = 1;
  Camera mainCam;
  private bool stopped;
  public IEnumerator co;
  private const float MOVEMENT_TIME = 2.0f; // The object moves for 2 seconds
  private const float MOVEMENT_DISTANCE = 1.0f; // Distance the object should move

  // Use this for initialization
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    mainCam = Camera.main;
    co = MoveObject(MOVEMENT_DISTANCE);
    StartCoroutine(co);
  }

  // Update is called once per frame
  void Update()
  {
    if (space)
    {
      stopped = true;
      StopCoroutine(co);
      rb.simulated = true;
      space = false;
      Instantiate(rb, new Vector3(0, 2*height, 0), Quaternion.identity);
      height ++;
      /*mainCam.transform.position += new Vector3(0, 1.5F, 0);*/
      /*rb.transform.position = Vector3.Lerp(rb.transform.position, rb.transform.position += (new Vector3(1, 0, 0)), 10.0f);*/
      
      
      rb.simulated = false;
    }
  }
  private IEnumerator MoveObject(float distance)
  {
    Vector3 currentPosition = this.transform.position;
    Vector3 targetPosition = new Vector3(this.transform.position.x + distance, this.transform.position.y, this.transform.position.z);
    float currentTime = 0.0f;

    while (currentTime <= MOVEMENT_TIME)
    {
      if (stopped) {
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
