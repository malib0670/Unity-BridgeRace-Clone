using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting.Antlr3.Runtime.Collections;

public class BlueStacks : MonoBehaviour
{
    private GameObject stackParent;
    Vector3 stackPos;
    public GameObject spawnBlueObjects;

    public static List<GameObject> stackListBlue = new List<GameObject>();
    int stackIndex = 0;


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
        if (other.CompareTag("Blue"))
        {

            stackListBlue.Add(other.gameObject);
            stackIndex = stackListBlue.Count;

            stackParent = other.gameObject;
            stackParent.transform.parent = GameObject.Find("Stack Parent Blue").transform;
            stackParent.transform.DOLocalMove(stackPos, 0.2f);
            stackParent.transform.DOLocalRotate(stackPos, 0.2f);
            stackPos += new Vector3(0, 0.4f, 0);
        }

        if (other.CompareTag("Stair"))
        {
            int nullOfChild = GameObject.Find("Stack Parent Blue").transform.childCount;

            if (stackListBlue.Count > 0)
            {
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;        
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                stackPos -= new Vector3(0, 0.4f, 0);
                Instantiate(spawnBlueObjects, stackListBlue[stackListBlue.Count - 1].gameObject.GetComponent<spawnObjects>().spawnPos, Quaternion.identity);
                other.gameObject.tag = "BlueStair";
                Destroy(GameObject.Find("Stack Parent Blue").transform.GetChild(nullOfChild - 1).gameObject);
                stackListBlue.RemoveAt(stackListBlue.Count - 1);
            }
        }

        if (other.CompareTag("GreenStair") || other.CompareTag("RedStair"))
        {
            int nullOfChild = GameObject.Find("Stack Parent Blue").transform.childCount;

            if (stackListBlue.Count > 0)
            {
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                stackPos -= new Vector3(0, 0.4f, 0);
                Instantiate(spawnBlueObjects, stackListBlue[stackListBlue.Count - 1].gameObject.GetComponent<spawnObjects>().spawnPos, Quaternion.identity);
                other.gameObject.tag = "BlueStair";
                Destroy(GameObject.Find("Stack Parent Blue").transform.GetChild(nullOfChild - 1).gameObject);
                stackListBlue.RemoveAt(stackListBlue.Count - 1);
            }
        }

        if (other.CompareTag("Wall"))
        {
            for (int i = 1; i <= 15; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-20, 20), 15.35f, Random.Range(55, 65));
                Instantiate(spawnBlueObjects, spawnPos, Quaternion.identity);
            }
        }
    }
}
