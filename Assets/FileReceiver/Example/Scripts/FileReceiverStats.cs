using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace web.utils
{
    /// <summary>
    /// File Receiver: file stats display edition
    /// </summary>
    public class FileReceiverStats : MonoBehaviour
    {
        public TMPro.TextMeshProUGUI Url;
        public TMPro.TextMeshProUGUI Size;
        public TMPro.TextMeshProUGUI Error;

        private IEnumerator LoadFile(string url)
        {
            using (UnityWebRequest www = UnityWebRequest.Get(url))
            {
                yield return www.SendWebRequest();

                if (!www.isNetworkError && !www.isHttpError)
                {
                    Error.text = www.error;
                }
                else
                {
                    Url.text = url;
                    Size.text = www.downloadHandler.data.Length.ToString();
                    Error.text = string.Empty;
                }
            }
        }

        public void FileSelected(string url)
        {
            StartCoroutine(LoadFile(url));
        }
    }
}
