using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnerObjects;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == spawnerObjects)
        {
            // 回転を初期化
            transform.rotation = Quaternion.identity;

            // 速度と角速度を0に設定
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            this.transform.position = new Vector3(0, 1.75f, 0);
        }
    }
}
