using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour
{
    private GameObject TargetObject; /// 目標位置
    NavMeshAgent m_navMeshAgent; /// NavMeshAgent
    public bool findtrigger;
    private Animator animator;
    public bool alivetrigger;


    private Vector3 distination;
    public float distance;
    public bool arrivetrigger;

    public float Playerdistance;

    public GameObject Cross;


    private GameObject deadeffect;

    private GameObject scorecontroller;

    private GameObject obj;
    public GameObject deadscoretext;


    // Use this for initialization
    void Start()
    {
        // NavMeshAgentコンポーネントを取得
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        findtrigger = false;
        arrivetrigger = false;
        SetDistination();
        animator = GetComponent<Animator>();
        alivetrigger = true;
        TargetObject = GameObject.Find("Player");
        deadeffect = transform.Find("HitBlood").gameObject;
        scorecontroller = GameObject.Find("ScoreController");
    }
    // Update is called once per frame
    void Update()
    {
        if (alivetrigger == true)
        {
            Playerdistance = Vector3.Distance(transform.position, TargetObject.transform.position);
            if (m_navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
            {

                if (findtrigger == false)
                {
                    //animator.SetBool("Run", false);
                    distance = Vector3.Distance(transform.position, distination);
                    if (arrivetrigger == false)
                    {
                        m_navMeshAgent.SetDestination(distination);

                        if (distance < 1.0f)
                        {
                            SetDistination();
                        }
                    }
                }

                if (findtrigger == true)
                {
                    // NavMeshAgentに目的地をセット
                    m_navMeshAgent.SetDestination(TargetObject.transform.position);
                    this.animator.SetBool("Run", true);
                    GetComponent<NavMeshAgent>().speed = 3.5f;
                }
            }
        }
        else if (alivetrigger == false)
        {
            m_navMeshAgent.SetDestination(transform.position);
        }


    }
    //発見の切り替え
    public void Find()
    {
        findtrigger = true;
    }

    //未発見時の目的地設定
    public void SetDistination()
    {
       float offsetX= Random.Range(-5.0f, 5.0f);
       float offsetZ = Random.Range(-5.0f, 5.0f);
       distination = new Vector3(transform.position.x + offsetX, transform.position.y, transform.position.z + offsetZ);
       arrivetrigger = false;
    }

    //パーティクルにあたったとき（ミサイル・焼夷弾用）
    public void OnParticleCollision(GameObject other)
    {
        DeadStart();
        //animator.SetTrigger("Dead");
        //deadscore();
        //deadeffect.GetComponent<ParticleSystem>().Play();
        //alivetrigger = false;
    }

   

    //MGで死ぬコールチン開始
    public void MG()
    {
        StartCoroutine(MGdead());
    }

    //MGのコールチン
    public IEnumerator MGdead()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<AudioSource>().Play();
        Camera.main.GetComponent<CameraController>().MSShake();
        DeadStart();
        //deadeffect.GetComponent<ParticleSystem>().Play();
        //animator.SetTrigger("Dead");
        //deadscore();
        //alivetrigger = false;
    }
    //スコア生成
    public void deadscore()
    {
        obj = Instantiate(deadscoretext, Camera.main.WorldToScreenPoint(transform.position),Quaternion.identity );
        obj.transform.parent = GameObject.Find("Canvas").transform;
    }
    
    //死ぬ開始の関数
    public void DeadStart()
    {
        GetComponent<CapsuleCollider>().enabled = !GetComponent<CapsuleCollider>().enabled;
        animator.SetTrigger("Dead");
        deadscore();
        deadeffect.GetComponent<ParticleSystem>().Play();
        alivetrigger = false;
        
    }

    //死んだ最後の関数
    public void DeadEnd()
    {
        scorecontroller.GetComponent<ScoreController>().scoreUP();
        Destroy(this.gameObject);
    }


}
