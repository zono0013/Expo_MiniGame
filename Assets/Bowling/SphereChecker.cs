using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SphereChecker : MonoBehaviour
{
    public GameObject headPrefab;   // Cubeのプレハブ
    public List<GameObject> spheres = new List<GameObject>(); // 監視するSphereのリスト

    void Start()
    {
        // Find all Spheres in the scene
        foreach(GameObject sphere in GameObject.FindGameObjectsWithTag("Sphere"))
        {
            spheres.Add(sphere);
        }
    }

    void Update()
    {
        // すべてのSphereのY座標がマイナスかどうかチェック
        bool minus = true;
        foreach (GameObject sphere in spheres)
        {
            if (sphere.transform.position.y >= 0)
            {
                minus = false;
                break;
            }
        }

        // すべてのY座標がマイナスならCubeを生成
        if (minus)
        {
            Instantiate(headPrefab, new Vector3(0, 0.05f, 0.1f), Quaternion.identity);
            spheres.Clear();
        }
    }
}
