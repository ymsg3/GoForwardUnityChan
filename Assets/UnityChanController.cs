using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    // �A�j���[�V�������邽�߂̃R���|�[�l���g������
    Animator animator;

    // Unity�������ړ�������R���|�[�l���g������i�ǉ��P�j
    Rigidbody2D rigid2D;

    // �n�ʂ̈ʒu
    private float groundLevel = -3.0f;

    // �W�����v�̑��x�̌����i�ǉ��P�j
    private float dump = 0.8f;

    // �W�����v�̑��x�i�ǉ��P�j
    float jumpVelocity = 20;

    // �Q�[���I�[�o�[�ɂȂ�ʒu�i�ǉ��Q�j
    private float deadLine = -9;

    // Use this for initialization
    void Start ()
    {
        // �A�j���[�^�̃R���|�[�l���g�����L����
        this.animator = GetComponent<Animator> ();
        // Rigidbody2D�̃R���|�[�l���g���擾����i�ǉ��P�j
        this.rigid2D = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update ()
    {
        // ����A�j���[�V�������Đ����邽�߂ɁAAnimator�̃p�����[�^�𒲐߂���
        this.animator.SetFloat ("Horizontal", 1);

        // ���n���Ă��邩�ǂ����𒲂ׂ�
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool ("isGround", isGround);

        // �W�����v��Ԃ̂Ƃ��ɂ̓{�����[����0�ɂ���i�ǉ��R�j
        GetComponent<AudioSource> ().volume = (isGround) ? 1 : 0;


        // ���n��ԂŃN���b�N���ꂽ�ꍇ�i�ǉ��P�j
        if (Input.GetMouseButtonDown (0) && isGround)
        {
            // ������̗͂�������i�ǉ��P�j
            this.rigid2D.velocity = new Vector2 (0, this.jumpVelocity);
        }

        // �N���b�N����߂��������ւ̑��x����������i�ǉ��P�j
        if (Input.GetMouseButton (0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        // �f�b�h���C���𒴂����ꍇ�Q�[���I�[�o�[�ɂ���i�ǉ��Q�j
        if (transform.position.x < this.deadLine)
        {
            // UIController��GameOver�֐����Ăяo���ĉ�ʏ�ɁuGameOver�v�ƕ\������i�ǉ��Q�j
            GameObject.Find ("Canvas").GetComponent<UIController> ().GameOver ();

            // ���j�e�B������j������i�ǉ��Q�j
            Destroy (gameObject);
        }

    }
}
