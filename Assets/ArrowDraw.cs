using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField]
    private Image arrowImage;
    private Vector3 crickPosition;
    bool SetAlive = true;
    void MouseUpdate()
    {
        if (arrowImage == null)
        {
            Debug.LogError("arrowImage is null in MouseUpdate.");
            return;
        }
        if (SetAlive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                crickPosition = Input.mousePosition;
                arrowImage.gameObject.SetActive(true);
            }
            if (Input.GetMouseButton(0))
            {
               
                Vector3 dist = crickPosition - Input.mousePosition;
                Debug.Log(dist);
                // �x�N�g���̒������Z�o
                float size = dist.magnitude;
                // �x�N�g������p�x�i�ʓx�@�j���Z�o
                float angleRad = Mathf.Atan2(dist.y, dist.x);
                // ���̉摜���N���b�N�����ꏊ�ɉ摜���ړ�
                arrowImage.rectTransform.position = crickPosition;
                // ���̉摜���x�N�g������Z�o�����p�x��x�����ɕϊ�����Z����]
                arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
                // ���̉摜�̑傫�����h���b�O���������ɍ��킹��
                arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
            }
            if (Input.GetMouseButtonUp(0))
            {
                arrowImage.gameObject.SetActive(false); // Hide the arrow image when the mouse button is released
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (arrowImage == null)
        {
            Debug.LogError("arrowImage is not set. Please assign an Image component in the inspector.");
        }
        else
        {
            arrowImage.gameObject.SetActive(false); // Ensure the arrow image is initially hidden
        }
    }

    // Update is called once per frame
    void Update()
    {
        MouseUpdate();
    }
}
