using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Vector3 crickPosition;
    [SerializeField]
    private float jumpPower = 10;
    private bool isCanJump;
    private Rigidbody rb;
    void Initialize()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            crickPosition = Input.mousePosition;
        }
        if (isCanJump &&Input.GetMouseButtonUp(0))
        {
            // クリックした座標と離した座標の座分を取得
            Vector3 dist = crickPosition - Input.mousePosition;
            // クリックとリリースが同じ座標ならば無視
            if(dist.sqrMagnitude == 0) { return; }
            // 差分を標準化し、jumpPowerをかけ合わせた値を移動量とする
            rb.velocity = dist.normalized * jumpPower;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("衝突した");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("衝突中");
        isCanJump = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("離脱した");
        isCanJump = false;
    }



    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
