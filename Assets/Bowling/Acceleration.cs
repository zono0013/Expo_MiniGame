using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    public Transform line; // ラインのTransformをインスペクターで指定
    public float acceleration = 20f; // 加速度

    public static bool hasCrossedLine = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 球体がラインを越えたかどうかを判定
        if (!hasCrossedLine && transform.position.z > line.position.z)
        {
            hasCrossedLine = true;
            Debug.Log("Line crossed! Accelerating..."); // デバッグログ
            Accelerate(); // 加速
            
        }
    }

    void Accelerate()
    {
        rb.AddForce(new Vector3(0,0,1) * acceleration, ForceMode.Acceleration);
        Debug.Log("Acceleration applied!"); // デバッグログ
        
    }

    // IEnumerator SleepCoroutine(float seconds)
    //     {
    //         Debug.Log("Coroutine started");
    //         yield return new WaitForSeconds(seconds); // 指定秒数待機
    //         rb.velocity = Vector3.zero;
    //         hasCrossedLine = false; // 加速フラグをリセット
    //         Debug.Log(seconds + " seconds have passed");
    //     }

}