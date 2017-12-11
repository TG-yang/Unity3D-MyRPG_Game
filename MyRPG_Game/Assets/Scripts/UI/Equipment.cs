using UnityEngine;
using System.Collections;
using UnityEditor;
using ADBannerView = UnityEngine.iOS.ADBannerView;

public class Equipment : MonoBehaviour
{
    public static Equipment _instance;
    private TweenPosition tween;
    private bool isShow = false;

    

    void Awake()
    {
        _instance = this;
        tween = this.GetComponent<TweenPosition>();
    }

    public void TransformState()
    {
        if (isShow == false)
        {
            tween.PlayForward();
            isShow = true;
        }
        else
        {
            tween.PlayReverse();
        }
    }

	
}
