using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WWW = WWWWrapper;

public class WWWWrapperTest : MonoBehaviour
{
    [SerializeField]
    bool forceError = false;

    [SerializeField]
    float delay = 0.0f;

    [SerializeField]
    string url = "http://unity3d.com";

    IEnumerator Start()
    {
        using (WWW www = new WWW(url))
        {
            www.delay = delay;
            www.forceError = forceError;

            yield return www;

            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.text);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
