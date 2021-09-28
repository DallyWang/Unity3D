using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class CanvasHandler : MonoBehaviour
{

    private const string JAVA_CLASS_NAME = "com.unity3d.player.UnityPlayer";
    private const string METHOD_NAME = "javaMethodForUnity";
    public Text showText;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.Find("Button2").GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        Debug.Log("CanvasHandler Start btn= " + btn);

        showText = GameObject.Find("Button2").GetComponentInChildren<Text>();
        // showText = GameObject.Find("Text2");
        Debug.Log("CanvasHandler Start showText= " + showText);
        Debug.Log("CanvasHandler Start");
        // Debug.Log ("CanvasHandler Start showText.text: " + showText.text.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnAndroidMsg(string msg)
    {
        Debug.Log("CanvasHandler OnAndroidMsg msg = " + msg);
        showText.text = msg;
    }

    private void OnClick()
    {
        Debug.Log("CanvasHandler OnClick");
        CallJavaMethod(METHOD_NAME, showText.text);
    }

    private void CallJavaMethod(string methodName, params object[] args)
    {
        try
        {
            AndroidJavaClass jc = new AndroidJavaClass(JAVA_CLASS_NAME);
            AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
            jo.Call(methodName, args);
        }
        catch (System.Exception ex)
        {
            Debug.Log("CanvasHandler CallJavaMethod Exception=" + ex.Message);
        }
    }
}
