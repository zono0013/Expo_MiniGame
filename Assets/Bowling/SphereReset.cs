using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SphereReset : MonoBehaviour

{
    private Vector3 initialPosition = new Vector3(5.5f, 0.65f, -27f); // 初期位置
    private Rigidbody rb;

    void Start()
    {
        // Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 球の現在のY座標をチェック
        if (transform.position.y <= 0)
        {
            // 初期位置にリセット
            transform.position = initialPosition;
            Debug.Log("Sphere reset to initial position.");
            // 回転を初期化
            transform.rotation = Quaternion.identity;

            // 速度と角速度を0に設定
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                Acceleration.hasCrossedLine = false;
            }
        }
    }
}

