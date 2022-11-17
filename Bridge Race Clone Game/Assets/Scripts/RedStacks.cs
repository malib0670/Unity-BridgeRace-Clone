using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RedStacks : MonoBehaviour
{
    private GameObject stackParent;
    Vector3 stackPos;
    public GameObject spawnRedObjects;

    public static List<GameObject> stackListRed = new List<GameObject>();
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
        if (other.CompareTag("Red"))
        {

            stackListRed.Add(other.gameObject);
            stackIndex = stackListRed.Count;

            stackParent = other.gameObject;
            stackParent.transform.parent = GameObject.Find("Stack Parent Red").transform;
            stackParent.transform.DOLocalMove(stackPos, 0.2f);
            stackParent.transform.DOLocalRotate(stackPos, 0.2f);
            stackPos += new Vector3(0, 0.4f, 0);
        }

        if (other.CompareTag("Stair"))
        {
            int nullOfChild = GameObject.Find("Stack Parent Red").transform.childCount;

            if (stackListRed.Count > 0)
            {
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                stackPos -= new Vector3(0, 0.4f, 0);
                Instantiate(spawnRedObjects, stackListRed[stackListRed.Count - 1].gameObject.GetComponent<spawnObjects>().spawnPos, Quaternion.identity);
                other.gameObject.tag = "RedStair";
                Destroy(GameObject.Find("Stack Parent Red").transform.GetChild(nullOfChild - 1).gameObject);
                stackListRed.RemoveAt(stackListRed.Count - 1);
            }
        }

        if (other.CompareTag("GreenStair") || other.CompareTag("BlueStair"))
        {
            int nullOfChild = GameObject.Find("Stack Parent Red").transform.childCount;

            if (stackListRed.Count > 0)
            {
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                stackPos -= new Vector3(0, 0.4f, 0);
                Instantiate(spawnRedObjects, stackListRed[stackListRed.Count - 1].gameObject.GetComponent<spawnObjects>().spawnPos, Quaternion.identity);
                other.gameObject.tag = "RedStair";
                Destroy(GameObject.Find("Stack Parent Red").transform.GetChild(nullOfChild - 1).gameObject);
                stackListRed.RemoveAt(stackListRed.Count - 1);
            }
        }

        if (other.CompareTag("Wall"))
        {
            for (int i = 1; i <= 15; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-20, 20), 15.35f, Random.Range(55, 65));
                Instantiate(spawnRedObjects, spawnPos, Quaternion.identity);
            }
        }
    }
}
