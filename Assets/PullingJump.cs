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
            // �N���b�N�������W�Ɨ��������W�̍������擾
            Vector3 dist = crickPosition - Input.mousePosition;
            // �N���b�N�ƃ����[�X���������W�Ȃ�Ζ���
            if(dist.sqrMagnitude == 0) { return; }
            // ������W�������AjumpPower���������킹���l���ړ��ʂƂ���
            rb.velocity = dist.normalized * jumpPower;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�Փ˂���");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("�Փ˒�");
        isCanJump = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("���E����");
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
