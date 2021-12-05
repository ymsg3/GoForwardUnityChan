using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // �L���[�u�̈ړ����x
    private float speed = -12;

    // ���ňʒu
    private float deadLine = -10;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        // �L���[�u���ړ�������
        transform.Translate (this.speed * Time.deltaTime, 0, 0);

        // ��ʊO�ɏo����j������
        if (transform.position.x < this.deadLine)
        {
            Destroy (gameObject);
        }
    }

    // �ۑ�p�F
    // ���̃L���[�u�����̃I�u�W�F�N�g�ƏՓ˂������ɌĂяo�����
    private void OnCollisionEnter2D (Collision2D collision)
    {

        // �L���[�u�����n�_�t�߂łȂ���Ή������Ȃ�
        if (transform.position.x <= -2.9)
        {
            return;
        }

        // �Փˑ���̃^�O�̖��O���擾
        string tagName = collision.gameObject.tag;

        // �Փˑ��肪�L���[�u���n�ʂȂ�A���ʉ����Đ�
        if (tagName =="CubeTag"|| tagName =="GroundTag")
        {
            GetComponent<AudioSource> ().Play ();
        }

    }
}
