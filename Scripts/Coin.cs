using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IVRInteractible
{
    public int score = 2;

    public void OnRedy()
        {
        GameController.instance.ChangeScore(score);
        Destroy(gameObject);
    }
	
}
