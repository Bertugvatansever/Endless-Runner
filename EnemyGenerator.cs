using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Golem;
    // Start is called before the first frame update
    private void Start()
    {
    }
    public void SpawnEnemy(Vector3 Randomposition)
    {
        GameObject enemy = Instantiate(Golem);
        enemy.transform.position = Randomposition;
        enemy.SetActive(true);


    }
}
