using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SphereChecker : MonoBehaviour
{
    public GameObject headPrefab;   // Cubeのプレハブ
    public List<GameObject> spheres = new List<GameObject>(); // 監視するSphereのリスト
    private bool hasGenerated = false; // 生成フラグ

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
        // 生成フラグが立っている場合は処理しない
        if (hasGenerated)
            return;

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
            if (!hasGenerated){
                Instantiate(headPrefab, new Vector3(5.5f, 0.8f, -25f), Quaternion.Euler(180, 0, 0));
                hasGenerated = true;
                spheres.Clear();
            }

            
        }
    }
}
