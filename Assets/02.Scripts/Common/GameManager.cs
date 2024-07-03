using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//enemy�� �¾�� ������ ���Ҿ� ������ü�� �ƿ츣�� ����� ����, �� ���� ��ü�� ���� Ŭ����
//1. �� ������, 2. �¾ ��ġ 3. �ð� ����(���ʸ��� �¾�°�) 4. ��� ���� �¾�°�
//���ӸŴ����� ���� ��ü�� ��Ʈ�� �ؾ��ϹǷ� ������ �������, static������ ������ �� ������ ��ǥ�ؼ� ���ӸŴ����� �����ϵ��� �Ѵ�.
//�̰��� ���к��� ��ü ������ ���� �ϳ��� �����ϰ� �ϴ� ����̴�. -> �̱��� ���
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text Killtxt;
    public static int Killcount = 0;

    public GameObject Zom_fb; //1��
    public GameObject Monster_fb;
    public GameObject Skel_fb;
    public Transform[] point; //2��
    public GameObject[] Mob;

    private float timePrev_Z; //3�� - ���Ž� �����
    private float timePrev_M; //�迭�� ������ ����ҵ�
    private float timePrev_S;
    private float timePrev;

    private float SpawnTime_Z = 3.0f; //3�� - 3�ʰ���
    private float SpawnTime_M = 8.0f;
    private float SpawnTime_S = 5.0f;
    private float SpawnTime = 3.0f;

    private int MaxCount_Z = 10; //4��
    private int MaxCount_M = 3;
    private int MaxCount_S = 5;
    private int MaxCount_MOB = 10;

    private string Zom = "ZOMBIE";
    private string Mon = "MONSTER";
    private string Skel = "SKELETON";
    private string mob = "MOB";
    private string SP = "SpawnPoints";
    public string player = "Player";
    void Start()
    {
        //���̶�Ű���� SpawnPoints��� ������Ʈ�� ã�� �� ������Ʈ�� ���� ��ġ ������Ʈ���� �����Ѵ�.(##�ڱ� �ڽ���ġ ���� ����##)
        point = GameObject.Find(SP).GetComponentsInChildren<Transform>(); //���� �Ҵ�
        timePrev_Z = Time.time; // ������Ʈ�� �������� ���Žð��� ��.
        timePrev_M = Time.time;
        timePrev_S = Time.time;
        timePrev = Time.time;
        

        Instance = this; // ��ü�� 1���� ����, Instance�� ���� �ش� Ŭ�����ȿ� public���� ������ ������ �żҵ忡 ���� �� �� �ִ�.
    }


    void Update()
    {
        //Spawn_Zom();
        //Spawn_Mon();
        //Spawn_Skel();
        Spawn_Mob();
    }

    public void KillScore(int score)
    {
        Killcount += score;
        Killtxt.text = $"KILL : <color=#FF0000>{Killcount.ToString()}</color>";
    }

    private void Spawn_Mob()
    {
        timePrev += Time.deltaTime;
        int mobcounter = GameObject.FindGameObjectsWithTag(mob).Length;
        if (timePrev > SpawnTime)
        {
            if (mobcounter < MaxCount_MOB)
            {
                int pos = Random.Range(1, point.Length);
                int i = Random.Range(0, Mob.Length);
                Instantiate(Mob[i].gameObject, point[pos].position, point[pos].rotation);
                timePrev = 0f;
            }
        }
    }

    private void Spawn_Skel()
    {
        if (Time.time - timePrev_S > SpawnTime_S)
        {
            int Skelcounter = GameObject.FindGameObjectsWithTag(Skel).Length;
            if (Skelcounter < MaxCount_S)
            {
                int randPos_S = Random.Range(1, point.Length);
                Instantiate(Skel_fb, point[randPos_S].position, point[randPos_S].rotation);
                timePrev_S = Time.time;
            }
        }
    }

    private void Spawn_Mon()
    {
        if (Time.time - timePrev_M > SpawnTime_M)
        {
            int Moncounter = GameObject.FindGameObjectsWithTag(Mon).Length;
            if (Moncounter < MaxCount_M)
            {
                int randPos_M = Random.Range(1, point.Length);
                Instantiate(Monster_fb, point[randPos_M].position, point[randPos_M].rotation);
                timePrev_M = Time.time;
            }
        }
    }

    private void Spawn_Zom()
    {
        if (Time.time - timePrev_Z >= SpawnTime_Z)
        {
            //���̶�Ű���� ���� �±׸� ���� ������Ʈ�� ������ ī��Ʈ�ؼ� �ѱ�
            int Zomcounter = GameObject.FindGameObjectsWithTag(Zom).Length;
            if (Zomcounter < MaxCount_Z)
            {
                int randPos_Z = Random.Range(1, point.Length);
                Instantiate(Zom_fb, point[randPos_Z].position, point[randPos_Z].rotation);
                timePrev_Z = Time.time; //���Žð� ������Ʈ
            }
        }
    }
}
