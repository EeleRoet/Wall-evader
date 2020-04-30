using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public Explosion explosion;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        FindObjectOfType<PauseMenu>().GameOver();
        //FindObjectOfType<updateScore>().CallUpdateHighscore();
        explosion.Explode();
    }

}
