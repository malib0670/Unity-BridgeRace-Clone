using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class StacksManager : MonoBehaviour
{
    Vector3 stackPos;
    Rigidbody playerRb;
    private GameObject stackParent;
    PlayerMovement player;

    public GameObject spawnObject;

    public static List<GameObject> stackList = new List<GameObject>();
    int stackIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        stackPos = Vector3.zero;
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Green"))
        {

            stackList.Add(other.gameObject);
            stackIndex = stackList.Count;

            stackParent = other.gameObject;
            stackParent.transform.parent = GameObject.Find("Stack Parent").transform;
            stackParent.transform.DOLocalMove(stackPos, 0.2f);
            stackParent.transform.DOLocalRotate(stackPos, 0.2f);
            stackPos += new Vector3(0, 0.4f, 0);
        }

        if (other.CompareTag("Stair"))
        {
            int nullOfChild = GameObject.Find("Stack Parent").transform.childCount;

            if (stackList.Count > 0)
            {
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                stackPos -= new Vector3(0, 0.4f, 0);
                Instantiate(spawnObject, stackList[stackList.Count - 1].gameObject.GetComponent<spawnObjects>().spawnPos, Quaternion.identity);
                other.gameObject.tag = "GreenStair";
                Destroy(GameObject.Find("Stack Parent").transform.GetChild(nullOfChild - 1).gameObject);
                stackList.RemoveAt(stackList.Count - 1);
            }

            if (stackList.Count == 0)
            {
                player.speed = 0;
            }
        }

        if (other.CompareTag("BlueStair") || other.CompareTag("RedStair"))
        {
            int nullOfChild = GameObject.Find("Stack Parent").transform.childCount;

            if (stackList.Count > 0)
            {
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                stackPos -= new Vector3(0, 0.4f, 0);
                Instantiate(spawnObject, stackList[stackList.Count - 1].gameObject.GetComponent<spawnObjects>().spawnPos, Quaternion.identity);
                other.gameObject.tag = "GreenStair";
                Destroy(GameObject.Find("Stack Parent").transform.GetChild(nullOfChild - 1).gameObject);
                stackList.RemoveAt(stackList.Count - 1);
            }

            if (stackList.Count == 0)
            {
                player.speed = 0;
            }
        }

        if (other.CompareTag("Wall"))
        {        
            for (int i = 1; i <= 10; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-20, 20), 15.35f, Random.Range(55, 70));
                Instantiate(spawnObject, spawnPos, Quaternion.identity);                
            }
        }
    }

    IEnumerator stackSpawnTime()
    {
        yield return new WaitForSeconds(10);
        spawnStacks();
    }

    public void spawnStacks()
    {
        Vector3 stackPoint = new Vector3(Random.Range(15, -19), 0.35f, Random.Range(-11, 8));
        Instantiate(spawnObject, stackPoint, Quaternion.identity);
    }

    public IEnumerator stackSpawnTime2()
    {
        yield return new WaitForSeconds(5);
        spawnStacks2();
    }

    public void spawnStacks2()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-20, 20), 15.35f, Random.Range(55, 70));
        Instantiate(spawnObject, spawnPos, Quaternion.identity);
    }
}
