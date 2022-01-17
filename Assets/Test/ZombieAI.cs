using idbrii.navgen.runtime;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.AI;

public class ZombieAI : MonoBehaviour
{
    //Debug
    PathDebuger pathDebuger;

    //PathMove
    bool NavVaild { get { return NavLinkGenerator_Runtime.HasNavMesh; } }
    NavMeshAgent navMeshAgent;
    NavMeshPath tempPath;

    bool ChasingState = false; 

    //==================================����==================================
    public bool SetChasing;
    [SerializeField]
    Vector3 VaildPos;
    [SerializeField]
    Vector3 unVaildPos;
    [SerializeField]
    Vector3 currentTargetPos;
    [SerializeField]
    Vector3 _UpdateTargetPos;
    [SerializeField]
    float lastOutsideTick;
    public Vector3 UpdateTargetPos
    {
        get { return _UpdateTargetPos; }
        set
        {
            if (_UpdateTargetPos != value && IsPosChange(_UpdateTargetPos, value))
            {
                if (NavVaild && SetChasing)
                {
                    //Debug.Log("Ŀ��λ�øı�,�������¼���Path");
                    ReGoto(value);
                }
            }
            _UpdateTargetPos = value;
            //else
            //    Debug.Log("Pass������");
        }
    }
    void Awake()
    {
        //Debugger
        if (pathDebuger == null)
            pathDebuger = gameObject.AddComponent<PathDebuger>();

        if (navMeshAgent == null)
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = true;

        tempPath = new NavMeshPath();

        //ע��·������
        NavLinkGenerator_Runtime.RebuildNavMesh_CallBack += OnNavMeshRebuild;
    }

    void Update()
    {
        //״̬��� ����
        if (navMeshAgent.isStopped)
        {
            ChasingState = false;
            Debug.Log("ֹͣ:" + navMeshAgent.isStopped);
        }

        //��ת�ڲ�ת(Ҫ���ڲ�����)
        if (SetChasing && !ChasingState && (_UpdateTargetPos != unVaildPos))
            //Debug.Log("��ת�ڲ�ת:"+ SetChasing + !ChasingState + (_UpdateTargetPos.ToString() + unVaildPos));
            ReGoto(_UpdateTargetPos);
        

        //��ת�ⲻת(Ҫ���ڲ�ֹͣ)
        if (!SetChasing && ChasingState)
            EndGoTo();
    }
    void OnNavMeshRebuild()
    {
        //Debug.Log("������·������:"+ navMeshAgent.isPathStale);
        //·����Ч, ��׷����
        if (ChasingState && NavVaild)
        {
            EndGoTo();
            SetChasing = true;
            //StartGoto(UpdateTargetPos);//���¼���·��׷��
        }
    }

    bool IsPosChange(Vector3 old, Vector3 newpos)
    {
        //if (Vector3.Distance(transform.position, newpos) > 30)
        //    return false;

        var dis = Vector3.Distance(old, newpos);
        bool changed = dis > 1f;
        //Debug.Log("IsPosChange:"+ changed+"|"+ dis);
        return true;
    }

    void ReGoto(Vector3 thisPos)
    {
        if (!NavVaild)
        {
            Debug.LogError("·��δ��ʼ��,StartGoto Pass:" + NavVaild);
            return;
        }

        if (thisPos == unVaildPos)
        {
            Debug.LogError("Pass��Ч��");
            return;
        }

        if (navMeshAgent.isOnOffMeshLink)
            return;//������ʱ�����¼���

        //����·��
        bool recalCulate = navMeshAgent.CalculatePath(thisPos, tempPath);

        //Ŀ����·��֮��
        if (!recalCulate)
        {
            float thistime = Time.time;
            if (thistime - lastOutsideTick < 1)
            {
                //Debug.Log("�����˳�");
                return;
            }
            else
            {
                lastOutsideTick = thistime;
                //Debug.Log("������Tick:" + thistime);
            }
        }
        bool resetPath = navMeshAgent.SetPath(tempPath);
        Debug.Log("Tick");

        //�滮·��ʧ��
        if (!recalCulate || !resetPath)
        {
            //Debug.Log("����ʧ��");
            //�ؼ���
            if (NavMesh.SamplePosition(thisPos, out NavMeshHit nearstPoint, 10, NavMesh.AllAreas))
            {
                //ʹ�������
                thisPos = nearstPoint.position;
                Debug.Log("ʹ�������:" + thisPos);
            }
            else
            {
                //û�������
                //����Ч��
                if (VaildPos != Vector3.zero)
                {
                    thisPos = VaildPos;
                    if (VaildPos == currentTargetPos)
                    {
                        Debug.Log("�����ظ�����Ч��");
                        return;
                    }
                    else
                        Debug.Log("ʹ����Ч��:" + thisPos + recalCulate);
                    //Debug.Log(navMeshAgent.destination.ToString() + VaildPos);
                    //if (navMeshAgent.pathEndPosition == VaildPos)
                    //    Debug.Log("��Ч�����ѱ��趨");
                }
                else {
                    //û����Ч��
                    unVaildPos = thisPos;//��¼�����Ч��(û�������, û����Ч��)
                    EndGoTo();//ֹͣ
                    Debug.LogError("ֹͣ: û�������,û����Ч��");
                    return;
                }
            }

            //�ع滮(����� �� ��Ч��)
            recalCulate = navMeshAgent.CalculatePath(thisPos, tempPath);
            resetPath = navMeshAgent.SetPath(tempPath);
        }

        //�ɹ�(����� �� ��Ч��)
        if (recalCulate && resetPath)
        {
            currentTargetPos = VaildPos;
            VaildPos = thisPos;//��¼��Ч
            pathDebuger.DebugPath(tempPath);
            ChasingState = true;
        }
        //ʧ��
        else
        {
            unVaildPos = thisPos;//��¼��Ч
            EndGoTo();
            //Debug.LogError("����������ʧ��: " + recalCulate + "|" + resetPath + "|" + navMeshAgent.pathStatus);
            Debug.DrawLine(thisPos, new Vector3(0, 100, 0), Color.red, 3);
        }
    }

    void EndGoTo() {
        ChasingState = false;
        navMeshAgent.ResetPath();
        pathDebuger.OnDestroy();
    }

}
