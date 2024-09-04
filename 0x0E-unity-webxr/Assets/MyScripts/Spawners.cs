using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    public GameObject BallKiller;
    public GameObject AlleyWay;
    public GameObject Folder;

    public string SawTag = "Saw";

    public MeshCollider AlleyWayCollider;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            for (int i = 0; i <= 10;  i++)
            {
                Vector3 spawnAt = GetRandomPos();
                GameObject saw = Instantiate(BallKiller, spawnAt, Quaternion.Euler(90, 0, 0));
                saw.transform.SetParent(Folder.transform);
                saw.tag = SawTag;

                MeshCollider meshCollider = saw.AddComponent<MeshCollider>();
                meshCollider.convex = true;
                meshCollider.isTrigger = true;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            RemoveAllChildren();
        }
    }

    private void RemoveAllChildren()
    {
        foreach (Transform child in Folder.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private Vector3 GetRandomPos()
    {
        Bounds bounds = AlleyWayCollider.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);

        float y = 0.88f;

        return new Vector3 (x, y, z);
    }
}
