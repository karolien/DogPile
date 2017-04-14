using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
  private Controls player;

  void Start()
  {
    player = FindObjectOfType<Controls>();
  }

  public void Space()
  {
    player.space = true;
  }
}
