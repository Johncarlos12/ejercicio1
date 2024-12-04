using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace semana12
{
    public class HazardSpawner : MonoBehaviour
    {
        [SerializeField] private float spawnDelay;
        [SerializeField] private GameObject hazardPrefab;


        private void Start()
        {
            StartCoroutine(Spawn());
        }

        IEnumerator Spawn()
        {
            while(true)
            {
                GameObject obj = Instantiate(hazardPrefab);
                obj.transform.position=transform.position;
                obj.transform.position += Vector3.right * Random.Range(-3, 3);
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }

}