using UnityEngine;
using System.Collections.Generic;

public class ChangePortals : MonoBehaviour
{
    public GameObject nothingPortals;
    public GameObject soundPortals;
    public GameObject visualPortals;
    public GameObject everythingPortals;
    public bool random = false;

    private List<GameObject> portalList;
    private int idx = 0;

    void Start()
    {
        portalList = new List<GameObject>();

        portalList.Add(nothingPortals);
        portalList.Add(soundPortals);
        portalList.Add(visualPortals);
        portalList.Add(everythingPortals);

        if (random) { Shuffle(portalList); }
       
        foreach (GameObject portal in portalList) {
            portal.SetActive(false);
        }
        portalList[idx].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            portalList[idx].SetActive(false);
            if(idx != portalList.Count - 1) {
                idx++;
                portalList[idx].SetActive(true);
            }
        }
    }

    private void Shuffle(List<GameObject> list)
    {
        System.Random ran = new System.Random();
        int n = list.Count;
        while (n > 1) {
            n--;
            int k = ran.Next(n + 1);
            GameObject value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}


