using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Spawner : MonoBehaviour {

    public List<GameObject> prefabenemyList = new List<GameObject>();
    public List<GameObject> spawnList = new List<GameObject>();
    public float timeBetweenWaves;
    public int totalNumberOfEnemys;
	public int totalNumberOfLifes;
    public int wavenum;
    public int numberOfLifes;

    [Header("Game UI Fields")]

	public GameObject waveCountdownText;
    private TextMeshProUGUI waveCountdownTexttextmeshPro;
    public GameObject enemyText;
    private TextMeshProUGUI enemyTexttextmeshPro;
    public GameObject lifeNumberText;
    private TextMeshProUGUI lifeNumberTexttextmeshPro;
    public GameObject wavenumText;
    private TextMeshProUGUI wavenumTexttextmeshPro;
    public GameObject gameOverUI;
	

	private float countdown = 2f;
	private int waveIndex = 0;
    private int numberOfEnemysForLevel;
	private bool gameEnded;

    void Start()
    {
        waveCountdownTexttextmeshPro = waveCountdownText.GetComponent<TextMeshProUGUI>();
        enemyTexttextmeshPro = enemyText.GetComponent<TextMeshProUGUI>();
        lifeNumberTexttextmeshPro = lifeNumberText.GetComponent<TextMeshProUGUI>();
        wavenumTexttextmeshPro = wavenumText.GetComponent<TextMeshProUGUI>();

        numberOfEnemysForLevel = totalNumberOfEnemys;
        numberOfLifes = totalNumberOfLifes;
        gameEnded = false;
        gameOverUI.SetActive(false);


    }

    public void DecreaseNumberOfEnemies()
	{
		numberOfEnemysForLevel--;

    }



    public void DecreaseNumberOfLifes()
    {
        if (numberOfLifes == 0)
        {
            EndGame();
        }
    }




    public bool IsGameEnded()
	{
		return gameEnded;
	}


		
	void Update () {
		


		if(countdown <= 0f && 
			waveIndex * waveIndex - waveIndex <= totalNumberOfEnemys * 2)
		{
			StartCoroutine (SpawnWave ());
			countdown = timeBetweenWaves;
		}

		countdown -= Time.deltaTime;
        waveCountdownTexttextmeshPro.SetText(Mathf.Floor(countdown).ToString());
        lifeNumberTexttextmeshPro.SetText("Lives " + numberOfLifes + "/" + totalNumberOfLifes);
        wavenumTexttextmeshPro.SetText("Waves  " + waveIndex + "/" + wavenum);
        enemyTexttextmeshPro.SetText("Enemies " + numberOfEnemysForLevel + "/" + totalNumberOfEnemys);


    }

	IEnumerator SpawnWave()
	{
		waveIndex++;
        
		for (int i = 0; i < waveIndex; i++) 
		{
            if (i == wavenum) { EndGame(); }
			SpawnEnemy ();
            yield return new WaitForSeconds (0.5f);
		}
	}

	void SpawnEnemy()
	{
        int prefabIndex = UnityEngine.Random.Range(0, 2);
        int spawnIndex = UnityEngine.Random.Range(0, 2);

        GameObject enemyGO = Instantiate (prefabenemyList[prefabIndex], spawnList[spawnIndex].transform.position, spawnList[spawnIndex].transform.rotation).gameObject;
		Enemy enemy = enemyGO.GetComponent<Enemy> ();
		enemy.UpdategameControl (this.transform);
	}



    public void EndGame()
	{
		gameEnded = true;
		gameOverUI.SetActive (true);
	}
		
}

