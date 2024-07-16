using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Transform controller;
    private Transform CenterEyeAnchor;

    private void Awake()
    {
        controller = GetComponent<Transform>();
        // 特定の名前の孫オブジェクトを探す
        CenterEyeAnchor = transform.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");
    }

    private void FixedUpdate()
    {
        //Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        // キーボードの入力を取得
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 stickR = new Vector2(moveHorizontal, moveVertical);

        // Y軸の回転角度を取得
        float yRotation = CenterEyeAnchor.eulerAngles.y;

        // 回転角度をラジアンに変換
        float radians = -yRotation * Mathf.Deg2Rad;

        // sinとcosを使用して移動方向を調整
        float moveX = stickR.x * Mathf.Cos(radians) - stickR.y * Mathf.Sin(radians);
        float moveZ = stickR.x * Mathf.Sin(radians) + stickR.y * Mathf.Cos(radians);

        Vector3 movePostiion = new Vector3(moveX / 10, 0, moveZ / 10);
        controller.Translate(movePostiion);
    }
}

