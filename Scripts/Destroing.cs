﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroing : MonoBehaviour, IVRInteractible
{
  public void OnRedy()
    {
        Destroy(gameObject);
    }
}
