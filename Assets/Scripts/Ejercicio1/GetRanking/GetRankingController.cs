using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace semana12
{
    public class GetRankingController : MonoBehaviour
    {
        public void Execute(Action<UserDataModel> OnCallback)
        {
            StartCoroutine(SendRequest(OnCallback));
        }

        IEnumerator SendRequest(Action<UserDataModel> OnCallback)
        {
            using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/programacion/semana12-ejercicio1/get_ranking.php"))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ProtocolError ||
                    www.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.Log("Error!");
                }
                else
                {
                    OnCallback?.Invoke(JsonUtility.FromJson<UserDataModel>(www.downloadHandler.text));
                }
            }
        }
    }

}