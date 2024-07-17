//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Move : MonoBehaviour
//{
//    private Transform controller;
//    private Transform CenterEyeAnchor;

//    private void Awake()
//    {
//        controller = GetComponent<Transform>();
//        // 特定の名前の孫オブジェクトを探す
//        CenterEyeAnchor = transform.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");
//    }

//    private void FixedUpdate()
//    {
//        Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);

//        // Y軸の回転角度を取得
//        float yRotation = CenterEyeAnchor.eulerAngles.y;

//        // 回転角度をラジアンに変換
//        float radians = -yRotation * Mathf.Deg2Rad;

//        // sinとcosを使用して移動方向を調整
//        float moveX = stickR.x * Mathf.Cos(radians) - stickR.y * Mathf.Sin(radians);
//        float moveZ = stickR.x * Mathf.Sin(radians) + stickR.y * Mathf.Cos(radians);

//        Vector3 movePostiion = new Vector3(moveX / 10, 0, moveZ / 10);
//        controller.Translate(movePostiion);
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Transform controller;
    private Transform CenterEyeAnchor;
    public float moveSpeed = 1.0f; // Adjust this to control movement speed
    public float minDistance = 0.1f; // Minimum distance for collision detection

    private void Awake()
    {
        controller = GetComponent<Transform>();
        // 特定の名前の孫オブジェクトを探す
        CenterEyeAnchor = transform.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");
    }

    private void FixedUpdate()
    {
        Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        // Y軸の回転角度を取得
        float yRotation = CenterEyeAnchor.eulerAngles.y;
        // 回転角度をラジアンに変換
        float radians = -yRotation * Mathf.Deg2Rad;
        // sinとcosを使用して移動方向を調整
        float moveX = stickR.x * Mathf.Cos(radians) - stickR.y * Mathf.Sin(radians);
        float moveZ = stickR.x * Mathf.Sin(radians) + stickR.y * Mathf.Cos(radians);
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        Vector3 moveAmount = moveDirection * moveSpeed * Time.fixedDeltaTime;

        // Check for collisions
        if (!IsCollisionAhead(moveAmount, minDistance))
        {
            controller.Translate(moveAmount);
        }
    }

    // 動く方向に衝突があるかどうかを判定するメソッド
    bool IsCollisionAhead(Vector3 move, float minDistance)
    {
        float distance = move.magnitude;
        Vector3 direction = move.normalized;
        RaycastHit hit;
        // Raycast で移動方向に衝突があるかをチェック
        if (Physics.Raycast(transform.position, direction, out hit, distance + minDistance))
        {
            return true;
        }
        return false;
    }
}