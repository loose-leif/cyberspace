using idbrii.navgen.runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestDriver : MonoBehaviour
{

    public Camera cam;
    public ZombieAI zombie;
    //public NavMeshAgent navMeshAgent;

    public bool StartButton;
    public bool StopButton;
    public bool RebuildNavMesh;

    public static TestDriver main;
    TestDriver()
    {
        main = this;
    }

    void Awake()
    {
        //navMeshAgent.updatePosition = false;
        //navMeshAgent.updateRotation = false;
        //navMeshAgent.updateUpAxis = false;
    }

    //========================�ؽ�NavMesh======================
    private void Start()
    {
        Application.targetFrameRate = 120;

        //Debug.Log("�ؽ�����֮ǰ:" + NavLinkGenerator_Runtime.HasNavMesh);

        //��ʼ��һ��ɥʧ
        zombie = Instantiate(Resources.Load<GameObject>("Zombie")).GetComponent<ZombieAI>();

        cam.gameObject.transform.parent = zombie.transform;
        //cam.gameObject.transform.Rotate(new Vector3(0,90,0));
        cam.transform.position = new Vector3(0,0,0);
        
    }

    private void Update()
    {
        zombie.UpdateTargetPos = transform.position;

        if (RebuildNavMesh)
        {
            NavLinkGenerator_Runtime.RebuildAll();
            RebuildNavMesh = false;
        }
        if (StartButton)
        {
            zombie.SetChasing = true;
            StartButton = false;
        }
        if (StopButton)
        {
            zombie.SetChasing = false;
            StopButton = false;
        }
        //Debug.Log("Target״̬:" + navMeshAgent.Warp(transform.position));
    }

}
