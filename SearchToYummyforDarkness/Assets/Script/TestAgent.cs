using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//NavMeshagent���g�����߂ɋL�q����

public class TestAgent : MonoBehaviour
{



    public Vector3[] wayPoints = new Vector3[3];//�p�j����|�C���g�̍��W��������Vector3�^�̕ϐ���z��ō��
    private int currentRoot;//���ݖڎw���|�C���g��������ϐ�
    private int Mode;//�G�̍s���p�^�[���𕪂��邽�߂̕ϐ�
    [SerializeField]
    public Transform player;//�v���C���[�̈ʒu���擾���邽�߂�Transform�^�̕ϐ�
    public Transform enemypos;//�G�̈ʒu���擾���邽�߂�Transform�^�̕ϐ�
    private NavMeshAgent agent;//NavMeshAgent�̏����擾���邽�߂�Navmeshagent�^�̕ϐ�

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();//NavMeshAgent�̏���agent�ɑ��
    }

    void Update()
    {
        Vector3 pos = wayPoints[currentRoot];//Vector3�^��pos�Ɍ��݂̖ړI�n�̍��W����
        float distance = Vector3.Distance(enemypos.position, player.transform.position);//�G�ƃv���C���[�̋��������߂�

        if (distance > 1)
        {//�����v���C���[�ƓG�̋�����5�ȏ�Ȃ�
            Mode = 0;//Mode��0�ɂ���
        }

        if (distance < 1)
        {//�����v���C���[�ƓG�̋�����5�ȉ��Ȃ�
            Mode = 1;//Mode��1�ɂ���
        }

        switch (Mode)
        {//Mode�̐؂�ւ���

            case 0://case0�̏ꍇ

                if (Vector3.Distance(transform.position, pos) < 1f)
                {//�����G�̈ʒu�ƌ��݂̖ړI�n�Ƃ̋�����1�ȉ��Ȃ�
                    currentRoot += 1;//currentRoot��+1����
                    if (currentRoot > wayPoints.Length - 1)
                    {//����currentRoot��wayPoints�̗v�f��-1���傫���Ȃ�
                        currentRoot = 0;//currentRoot��0�ɂ���
                    }
                }
                GetComponent<NavMeshAgent>().SetDestination(pos);//NavMeshAgent�̏����擾���ړI�n��pos�ɂ���
                break;//switch���̊e�p�^�[���̍Ō�ɂ���

            case 1://case1�̏ꍇ
                agent.destination = player.transform.position;//�v���C���[�Ɍ������Đi��		
                break;//switch���̊e�p�^�[���̍Ō�ɂ���
        }
    }
}
