using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
  private Controls controller;

  void Start()
  {
    controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controls>();
  }

  public void Space()
  {
    controller.space();
  }
  public void Restart() {
    controller.newGame();
  }
}
