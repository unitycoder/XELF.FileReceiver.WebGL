using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace web.utils
{
    public class FileReceiver : MonoBehaviour
    {
        private IEnumerator LoadFile(string url)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();

                if (!request.isNetworkError && !request.isHttpError)
                {
                    byte[] fileData = request.downloadHandler.data;
                    Debug.Log(fileData.Length + " bytes loaded");
                }
                else
                {
                    Debug.LogError("Error loading file: " + request.error);
                }
            }
        }

        public void FileSelected(string url)
        {
            StartCoroutine(LoadFile(url));
        }
    }
}
