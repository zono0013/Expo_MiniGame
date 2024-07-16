using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darts_destroy : MonoBehaviour
{
    public AudioClip explosionSound; // インスペクターで設定する破裂音
    private AudioSource audioSource;

    private void Start()
    {
        // AudioSourceコンポーネントを取得または追加
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトが的かどうかを確認
        if (collision.gameObject.CompareTag("Target"))
        {
            // 破裂音を再生
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }

            // 的をデストロイ
            Destroy(collision.gameObject);
        }
    }
}