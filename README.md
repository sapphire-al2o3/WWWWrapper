# WWWWrapper
Unity WWW class wrapper

Unity 2017.4

## Example

```csharp
using WWW = WWWWrapper;

public class WWWWrapperTest : MonoBehaviour
{
    [SerializeField]
    string url = "http://unity3d.com";

    IEnumerator Start()
    {
        using (WWW www = new WWW(url))
        {
            // 5s遅延
            www.delay = 5.0f;
            
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
}
```

```csharp
using WWW = WWWWrapper;

public class WWWWrapperTest : MonoBehaviour
{
    [SerializeField]
    string url = "http://unity3d.com";

    IEnumerator Start()
    {
        using (WWW www = new WWW(url))
        {
            // 強制エラー
            www.forceError = true;
            
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
}
```