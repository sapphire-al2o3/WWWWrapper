using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WWWWrapper : CustomYieldInstruction, IDisposable
{
    public enum ErrorPlatform
    {
        Android,
        PC
    }

    static string[] Error =
    {
        // Android 接続なし
        "java.net.UnknownHostException: Unable to resolve host \"{0}\": No address associated with hostname",
        // PC 接続なし
        //"Couldn't resolve host name"
        "Cannot resolve destination host"
    };

	float delayStartTime = 0.0f;


    ErrorPlatform errorPlatform = ErrorPlatform.Android;

	public bool forceError
	{
		set; get;
	}

	public float delay
	{
		set; get;
	}

	public WWW www
	{
		private set; get;
	}

	public WWWWrapper(string url)
	{
		www = new WWW(url);
		delayStartTime = Time.realtimeSinceStartup;
	}

	public WWWWrapper(string url, WWWForm form)
	{
		www = new WWW(url, form);
		delayStartTime = Time.realtimeSinceStartup;
	}

	public WWWWrapper(string url, byte[] postData)
	{
		www = new WWW(url, postData);
		delayStartTime = Time.realtimeSinceStartup;
	}

	public WWWWrapper(string url, byte[] postData, Dictionary<string, string> headers)
	{
		www = new WWW(url, postData, headers);
		delayStartTime = Time.realtimeSinceStartup;
	}

	public void Dispose()
	{
		www.Dispose();
	}

    public override bool keepWaiting
    {
        get
        {
            if (delay > 0)
            {
                return Time.realtimeSinceStartup - delayStartTime < delay;
            }
            else
            {
                return www.keepWaiting;
            }
        }
    }

    public string text
	{
		get
		{
			if (forceError)
			{
				return string.Empty;
			}
			else
			{
				return www.text;
			}
		}
	}

	public string error
	{
		get
		{
			if (forceError)
			{
				return string.Format(Error[(int)errorPlatform], url);
			}
			else
			{
				return www.error;
			}
		}
	}

	public bool isDone
	{
		get
		{
			if (delay > 0.0f)
			{
				return Time.realtimeSinceStartup - delayStartTime >= delay;
			}
			else
			{
				return www.isDone;
			}
		}
	}

	public float progress
	{
		get { return www.progress; }
	}

	public string url
	{
		get { return www.url; }
	}

	public Dictionary<string, string> responseHeaders
	{
		get
		{
			if (forceError)
			{
				return new Dictionary<string, string>();
			}
			else
			{
				return www.responseHeaders;
			}
		}
	}
}
