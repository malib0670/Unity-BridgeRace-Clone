using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
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
            greenPlayer.SetActive(false);
            greenPlayerFirst.SetActive(true);
            redPlayer.SetActive(false);
            bluePlayer.SetActive(false);
            camera1.SetActive(false);
            camera2.SetActive(true);
            star.SetActive(false);
            first.SetActive(true);
            second.SetActive(true);
            third.SetActive(true);
            particle.Play();

            if (RedStacks.stackListRed.Count > BlueStacks.stackListBlue.Count)
            {
                redPlayerSecond.SetActive(true);
                bluePlayerThird.SetActive(true);
            }

            if (RedStacks.stackListRed.Count < BlueStacks.stackListBlue.Count)
            {
                redPlayerThird.SetActive(true);
                bluePlayerSecond.SetActive(true);
            }

            if (RedStacks.stackListRed.Count == BlueStacks.stackListBlue.Count)
            {
                redPlayerSecond.SetActive(true);
                bluePlayerSecond.SetActive(true);
            }
        }
    }
}
