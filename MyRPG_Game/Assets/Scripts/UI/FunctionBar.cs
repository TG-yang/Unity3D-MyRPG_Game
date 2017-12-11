using UnityEngine;
using System.Collections;

public class FunctionBar : MonoBehaviour {

    public void OnStatusClick()
    {
        Status._instance.TransformState();
    }

    public void OnBagButtonClick()
    {
       
        Inventory._instance.TransformState();
        
    }

    public void OnEqiupButtonClick()
    {
        Equipment._instance.TransformState();
    }

    public void OnSkillButtonClick()
    {
        
    }

    public void OnSettingButtonClick()
    {
        
    }
}
