using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public Explosion explosion;
    public float timer = 2;
    public bool GameoverStart = false;

    private void Update()
    {

        if (GameoverStart == true)
        {

           timer-= Time.deltaTime;
           if(timer <= 0)
           {

                FindObjectOfType<PauseMenu>().GameOver();
                //FindObjectOfType<updateScore>().CallUpdateHighscore();
           }

       }

    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        //FindObjectOfType<PauseMenu>().GameOver();
        //FindObjectOfType<updateScore>().CallUpdateHighscore();
        explosion.Explode();
        GameoverStart = true;
    }

}
