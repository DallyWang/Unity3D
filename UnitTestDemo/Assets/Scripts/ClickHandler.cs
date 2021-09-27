using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    public Text showText;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);

        showText = GameObject.Find("ShowText").GetComponent<Text> ();
        Debug.Log ("ClickHandler Start");
        Debug.Log("ClickHandler Start showText="+showText);
        // Debug.Log ("ClickHandler Start showText.text: "+showText.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClick(){
        Debug.Log ("Button Clicked. ClickHandler hahahaha");
    }

      public void OnAndroidMsg(string msg){
        Debug.Log("ClickHandler OnAndroidMsg msg = "+msg);
        showText.text = msg;
    }

}
