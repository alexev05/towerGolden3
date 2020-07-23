using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
	public int life = 5;
    public int enemyDamage;
    public Text lifeNumberText;
    public int randomMoneymin;
    public int randomMoneymax;
    public int randomMoney;
    private Transform target;
	private Transform gameControl;
	private int waveIndex = 0;
    

	public void UpdategameControl(Transform _gameControl)
	{
		gameControl = _gameControl;	
	}

	void Start () 
	{

        randomMoney = Random.Range(randomMoneymin, randomMoneymax);
        target = Wavepoints.points[0];
        lifeNumberText = GameObject.Find("Life").GetComponent<Text>();

    }

	// Update is called once per frame
	void Update () 
	{
		if (gameControl.gameObject.GetComponent<Spawner> ().IsGameEnded ())
			
		{
			return;
		}
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);
	
		if (Vector3.Distance (transform.position, target.position) <= 0.4f)
		{
			GetNext ();
		}
			
		if (life <= 0) {
			gameControl.gameObject.GetComponent<Spawner> ().DecreaseNumberOfEnemies();
			Destroy (gameObject);
		}

    }

	public void GetNext()
	{
		if (waveIndex >= Wavepoints.points.Length - 1)
		{
            gameControl.gameObject.GetComponent<Spawner> ().DecreaseNumberOfEnemies();
            gameControl.gameObject.GetComponent<Spawner>().numberOfLifes -= enemyDamage;
            gameControl.gameObject.GetComponent<Spawner> ().DecreaseNumberOfLifes();
            Destroy (gameObject);
			return;
		}
        
        waveIndex++;
		target = Wavepoints.points [waveIndex];
        
    }


}
