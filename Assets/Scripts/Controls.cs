using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
  
  public GameObject doggoPrefab;    // Re-usable template for doggo
  private float height = 0;
  Camera mainCam;

  private GameObject current;   // Current doggo

  // Use this for initialization
  void Start()
  {
    current = createDoggo(height++);    // Our first (and hence best) doggo
  }

  // Update is called once per frame
  void Update()
  {
  }

  public void space()
  {
      current.GetComponent<Movement>().stopMoving();    // "Stay!"
      current = createDoggo(height++);
    }
  
  GameObject createDoggo(float height)  // Another doggo!!
  {
    return Instantiate(doggoPrefab, new Vector3(0, 2 * height, 0), Quaternion.identity);
  }

}
