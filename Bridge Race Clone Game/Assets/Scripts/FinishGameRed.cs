using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameRed : MonoBehaviour
{
    public GameObject camera1, camera2;
    public GameObject greenPlayer, greenPlayerFirst, greenPlayerSecond, greenPlayerThird;
    public GameObject redPlayer, redPlayerFirst, redPlayerSecond, redPlayerThird;
    public GameObject bluePlayer, bluePlayerFirst, bluePlayerSecond, bluePlayerThird;
    public GameObject star;
    public GameObject first, second, third;

    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {
            redPlayer.SetActive(false);
            redPlayerFirst.SetActive(true);
            bluePlayer.SetActive(false);
            greenPlayer.SetActive(false);
            camera1.SetActive(false);
            camera2.SetActive(true);
            star.SetActive(false);
            first.SetActive(true);
            second.SetActive(true);
            third.SetActive(true);
            particle.Play();

            if (BlueStacks.stackListBlue.Count > StacksManager.stackList.Count)
            {
                bluePlayerSecond.SetActive(true);
                greenPlayerThird.SetActive(true);
            }

            if (BlueStacks.stackListBlue.Count < StacksManager.stackList.Count)
            {
                bluePlayerThird.SetActive(true);
                greenPlayerSecond.SetActive(true);
            }

            if (BlueStacks.stackListBlue.Count == StacksManager.stackList.Count)
            {
                bluePlayerSecond.SetActive(true);
                greenPlayerSecond.SetActive(true);
            }
        }
    }
}
