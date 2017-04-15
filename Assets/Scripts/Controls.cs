using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
  
  public GameObject doggoPrefab;    // Re-usable template for doggo
  private float dogHeight;
  private float height = 0;
  Camera mainCam;
  private Vector3 camVelocity = Vector3.zero;
  public bool newDog = false;
  public int score = 0;
  public Text scoreText;
  public Canvas gameOverScreen;
  public Canvas gamePlayingScreen;
  private bool gameEnded;
  private GameObject current;   // Current doggo

  // Use this for initialization
  void Start()
  {
    gamePlayingScreen.enabled = true;
    current = createDoggo(height++);    // Our first (and hence best) doggo
    dogHeight = doggoPrefab.GetComponent<BoxCollider2D>().size.y * doggoPrefab.transform.localScale.y;
    mainCam = Camera.main;
    newDog = true;
    gameOverScreen.enabled = false;
    gameEnded = false;
  }

  // Update is called once per frame
  void Update()
  {
    mainCam.transform.position = Vector3.SmoothDamp(mainCam.transform.position, new Vector3(mainCam.transform.position.x, height * dogHeight - dogHeight, mainCam.transform.position.z), ref camVelocity ,3);
  }

  public void space()
  {
    if(newDog) {
      current.GetComponent<Movement>().stopMoving();    // "Stay!"
      newDog = false;
      StartCoroutine(WaitThenDo());
    }
  }
  public void gameOver() {
    gameEnded = true;
    gameOverScreen.enabled = true;
    gamePlayingScreen.enabled = false;
    newDog = false;
  }
  public void newGame() {
    GameObject[] dogs = GameObject.FindGameObjectsWithTag("dog");
    foreach (GameObject item in dogs)
    {
      Destroy(item);
    }
    height = 0;
    score = 0;
    UpdateScore();
    gameOverScreen.enabled = false;
    Start();
  }
  
  GameObject createDoggo(float height)  // Another doggo!!
  {
    return Instantiate(doggoPrefab, new Vector3(-1, dogHeight * height, 0), Quaternion.identity);
  }

  void UpdateScore()
  {
    scoreText.text = "Dogs Piled: " + score;
  }

  IEnumerator WaitThenDo()
  {
    yield return new WaitForSeconds(1);
    if(!gameEnded) {
      current = createDoggo(height++);
      newDog = true;
      score++;
      Debug.Log("score: " + score);
      UpdateScore();
    }
  }

}

