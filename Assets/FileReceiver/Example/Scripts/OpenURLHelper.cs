using UnityEngine;

namespace web.utils
{
    public class OpenURLHelper : MonoBehaviour
    {
        public void OpenURL(string url)
        {
            Application.OpenURL(url);
        }
    }
}