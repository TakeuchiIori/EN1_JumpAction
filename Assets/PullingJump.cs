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
        // �Փ˂��Ă���_�̏�񂪕����i�[����Ă���
        ContactPoint[] contacts = collision.contacts;
        // 0�Ԗڂ̏Փˏ�񂩂�A�Փ˂��Ă���_�̖@�����擾
        Vector3 otherNormal = contacts[0].normal;
        // ������������x�N�g���B������1
        Vector3 upVector = new Vector3(0, 1, 0);
        // ������Ɩ@���̓��ρB�x�N�g���͂Ƃ��ɒ�����1�Ȃ̂ŁAcos�Ƃ̌��ʂ�dotUN�ϐ��ɓ���
        float dotN = Vector3.Dot(upVector, otherNormal);
        // ���ϒl�ɋt�O�p�֐�arccos���|���Ċp�x���Z�o�B�����x�����֕ϊ�����B����Ŋp�x���Z�o�ł���
        float dotDeg = Mathf.Acos(dotN) * Mathf.Rad2Deg;
        // ��̃x�N�g�����Ȃ��p�x��45�x��菬������΍ĂуW�����v�\�ɂȂ�
        if (dotDeg <= 45)
        {
            isCanJump = true;
        }

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
