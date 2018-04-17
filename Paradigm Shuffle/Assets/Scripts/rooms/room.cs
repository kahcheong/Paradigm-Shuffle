using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class room : MonoBehaviour {

    public GameObject Card1;
    public GameObject Card2;
    private GameObject enemy;
    public GameObject[] spawnPoints = new GameObject[12];
    public GameObject[] rooms = new GameObject[4]; // 0 = left, 1 = right, 2 = up,, 3 = down
    public Texture[] skin = new Texture[3];
    //public GameObject leftRoom;
    //public GameObject rightRoom;
    //public GameObject topRoom;
    //public GameObject bottomRoom;

    public GameObject[] doors = new GameObject[4];
    //public GameObject leftDoor;
    //public GameObject rightDoor;
    //public GameObject topDoor;
    //public GameObject bottomDoor;

    public GameObject itemSpawner;
    public bool cleared = false;
    public List<GameObject> enemies = new List<GameObject>();
    public int stage = 0;
    public GameObject cardDisplay;
    private int enemyCount = 0;
    private readonly Vector3 spawn = new Vector3(0, 0.5f, 0);
    private bool activate = true;

    // Use this for initialization
    void OnEnable () {

        for(int i = 0; i < 4; i++)
        {
            if (rooms[i] == null) Destroy(doors[i]);
        }
        Card1 = GameController.control.GetCard().gameObject;
        Card2 = GameController.control.GetCard().gameObject;
        StartCoroutine(wait(2.5f));
        

    }
	
	// Update is called once per frame
	void Update () {

        if (stage == 0)
        {
            GameObject card1 = Instantiate(cardDisplay, GameController.control.roomDisplay.transform);
            card1.GetComponent<Image>().sprite = Card1.GetComponent<SpriteRenderer>().sprite;
            stage++;
        }
        else if (stage == 2)
        {
            enemyCount = Random.Range(Card1.GetComponent<Card>().minInstance, Card1.GetComponent<Card>().maxInstance);
            StartCoroutine(loadSpawn(enemyCount));
            stage++;
            
        }
        else if (stage == 4)
        {
            GameObject card2 = Instantiate(cardDisplay, GameController.control.roomDisplay.transform);
            card2.GetComponent<Image>().sprite = Card2.GetComponent<SpriteRenderer>().sprite;
            StartCoroutine(wait(2.5f));
            stage++;
        }
        else if (stage == 6)
        {
            if (Card2.GetComponent<Card>().id < 10) gameObject.GetComponent<MeshRenderer>().material.mainTexture = skin[0];
            if (Card2.GetComponent<Card>().id > 9) gameObject.GetComponent<MeshRenderer>().material.mainTexture = skin[1];
            if (Card2.GetComponent<Card>().id > 19) gameObject.GetComponent<MeshRenderer>().material.mainTexture = skin[2];
            StartCoroutine(loadEnemy(Card2.GetComponent<Card>().enemy));
            stage++;
        }
        else if (stage == 8)
        {
            stage++;
            StartCoroutine(wait(1f));
        }
        else if (stage == 10)
        {
            if (activate)
            {
                foreach (GameObject n in enemies)
                {
                    n.GetComponent<Enemy>().enabled = true;
                }
                activate = false;
            }
            foreach(GameObject n in spawnPoints)
            {
                Destroy(n);
            }
            enemies.RemoveAll(item => item == null);
            if (enemies.Count == 0)
            {
                if (itemSpawner.gameObject!=null) itemSpawner.SetActive(true);
                cleared = true;
                FloorManager.floorManager.floorSize--;
                stage++;
                
            }
        }
        else if (stage == 11)
        {
            if (FloorManager.floorManager.floorSize <= 5)
            {
                int temp15 = 0; 
                for (int i = 0; i < 10; i++)
                {
                    temp15 = Random.Range(1, FloorManager.floorManager.floorSize);
                    Debug.Log(temp15);
                }
                if ( temp15 == 1 && !FloorManager.floorManager.giveExit)
                {
                    Instantiate(FloorManager.floorManager.exitLoc, new Vector3(0, 0, -0.1f), FloorManager.floorManager.exitLoc.transform.rotation,FloorManager.floorManager.currRoom.transform);
                    FloorManager.floorManager.giveExit = true;
                }
                stage++;
            }
        }
        
        

	}

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        stage++;

    }

    IEnumerator loadSpawn (int amount)
    {
        for (int i =0; i < amount; i++)
        {
            spawnPoints[i].SetActive(true);
            yield return new WaitForSeconds(0.15f);
        }
        stage++;
    }
    IEnumerator loadEnemy(GameObject Enemy)
    {
        for (int i = enemyCount-1; i >= 0; i--)
        {
            GameObject enemy = Instantiate(Enemy,spawnPoints[i].transform.position + spawn ,Enemy.transform.rotation);
            enemy.transform.parent = null;;
            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, -0.1f);
            enemy.GetComponent<Enemy>().enabled = false;
            enemies.Add(enemy);
            yield return new WaitForSeconds(0.25f);
        }
        stage++;
    }
}
