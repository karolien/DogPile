using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
  
  public GameObject doggoPrefab;    // Re-usable template for doggo
  private float dogHeight;
  private float height = 0;
  Camera mainCam = Camera.main;
  private Vector3 camVelocity = Vector3.zero;

  private GameObject current;   // Current doggo

  // Use this for initialization
  void Start()
  {
    current = createDoggo(height++);    // Our first (and hence best) doggo
    dogHeight = doggoPrefab.GetComponent<BoxCollider2D>().size.y * doggoPrefab.transform.localScale.y;
  }

  // Update is called once per frame
  void Update()
  {
    mainCam = Camera.main;
    mainCam.transform.position = Vector3.SmoothDamp(mainCam.transform.position, new Vector3(mainCam.transform.position.x, height * dogHeight - dogHeight, mainCam.transform.position.z), ref camVelocity ,3);
  }

  public void space()
  {
      current.GetComponent<Movement>().stopMoving();    // "Stay!"
      current = createDoggo(height++);
  }
  
  GameObject createDoggo(float height)  // Another doggo!!
  {
    return Instantiate(doggoPrefab, new Vector3(0, dogHeight * height, 0), Quaternion.identity);
  }

}
