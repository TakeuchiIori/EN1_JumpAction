using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Vector3 crickPosition;
    [SerializeField]
    private float jumpPower = 20;
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
        // 衝突している点の情報が複数格納されている
        ContactPoint[] contacts = collision.contacts;
        // 0番目の衝突情報から、衝突している点の法線を取得
        Vector3 otherNormal = contacts[0].normal;
        // 上方向を示すベクトル。長さは1
        Vector3 upVector = new Vector3(0, 1, 0);
        // 上方向と法線の内積。ベクトルはともに長さが1なので、cosθの結果がdotUN変数に入る
        float dotN = Vector3.Dot(upVector, otherNormal);
        // 内積値に逆三角関数arccosを掛けて角度を算出。それを度数方へ変換する。これで角度が算出できた
        float dotDeg = Mathf.Acos(dotN) * Mathf.Rad2Deg;
        // 二つのベクトルがなす角度が45度より小さければ再びジャンプ可能になる
        if (dotDeg <= 45)
        {
            isCanJump = true;
        }

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
