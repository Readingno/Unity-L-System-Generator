using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public InputField starting;
    public InputField F_rule;
    public InputField F2_rule;
    public InputField X_rule;
    public InputField X2_rule;
    public Dropdown pre;
    public Dropdown gen;
    public Slider length;
    public InputField lengthNum;
    public Slider angle;
    public InputField angleNum;
    public Slider range;
    public InputField rangeNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangePreset()
    {
        switch (pre.value)
        {
            case 0:// F     F -> F[+F]F[-F]F
                starting.text = "F";
                F_rule.text = "F[+F]F[-F]F";
                F2_rule.text = "";
                X_rule.text = "";
                X2_rule.text = "";
                length.value = 0.1f;
                angle.value = 25.7f;
                break;
            case 1:// F     F -> F[+F]F[-F][F]
                starting.text = "F";
                F_rule.text = "F[+F]F[-F][F]";
                F2_rule.text = "";
                X_rule.text = "";
                X2_rule.text = "";
                length.value = 0.1f;
                angle.value = 20f;
                break;
            case 2:// F     F -> FF-[-F+F+F]+[+F-F-F]
                starting.text = "F";
                F_rule.text = "FF-[-F+F+F]+[+F-F-F]";
                F2_rule.text = "";
                X_rule.text = "";
                X2_rule.text = "";
                length.value = 0.1f;
                angle.value = 22.5f;
                break;
            case 3:// X     X -> F[+X]F[-X]+X       F -> FF
                starting.text = "X";
                F_rule.text = "FF";
                F2_rule.text = "";
                X_rule.text = "F[+X]F[-X]+X";
                X2_rule.text = "";
                length.value = 0.1f;
                angle.value = 20f;
                break;
            case 4:// X     X -> F[+X][-X]FX       F -> FF
                starting.text = "X";
                F_rule.text = "FF";
                F2_rule.text = "";
                X_rule.text = "F[+X][-X]FX";
                X2_rule.text = "";
                length.value = 0.1f;
                angle.value = 25.7f;
                break;
            case 5:// X     X -> F-[[X]+X]+F[+FX]-X       F -> FF
                starting.text = "X";
                F_rule.text = "FF";
                F2_rule.text = "";
                X_rule.text = "F-[[X]+X]+F[+FX]-X";
                X2_rule.text = "";
                length.value = 0.1f;
                angle.value = 22.5f;
                break;
            case 6:// F     F -> F[+F]F[-F]F        F2 -> F[+F]F
                starting.text = "F";
                F_rule.text = "F[+F]F[-F]F";
                F2_rule.text = "F[+F]F";
                X_rule.text = "";
                X2_rule.text = "";
                length.value = 0.1f;
                angle.value = 25.7f;
                break;
            case 7:// X     X -> F-[[X]+X]+F[+FX]-X        X2 -> F+[[X]-X]-F[-FX]+X       F -> FF
                starting.text = "X";
                F_rule.text = "FF";
                F2_rule.text = "";
                X_rule.text = "F-[[X]+X]+F[+FX]-X";
                X2_rule.text = "F+[[X]-X]-F[-FX]+X";
                length.value = 0.1f;
                angle.value = 25.7f;
                break;
            case 8:// F     F -> F[+F]F[-F]F        F2 -> FF-[-F+F+F]+[+F-F-F]
                starting.text = "F";
                F_rule.text = "F[+F]F[-F]F";
                F2_rule.text = "FF-[-F+F+F]+[+F-F-F]";
                X_rule.text = "";
                X2_rule.text = "";
                length.value = 0.1f;
                angle.value = 25.7f;
                break;
            case 9:// F     F -> FF+[+F-F-F]-[-F+F+F]        F2 -> FF-[-F+F+F]+[+F-F-F]
                starting.text = "F";
                F_rule.text = "FF+[+F-F-F]-[-F+F+F]";
                F2_rule.text = "FF-[-F+F+F]+[+F-F-F]";
                X_rule.text = "";
                X2_rule.text = "";
                length.value = 0.1f;
                angle.value = 22.5f;
                break;
        }
    }

    public void Length_S2In()
    {
        lengthNum.text = length.value.ToString();
    }
    public void Length_In2S()
    {
        length.value = float.Parse(lengthNum.text);
    }
    public void Angle_S2In()
    {
        angleNum.text = angle.value.ToString();
    }
    public void Angle_In2S()
    {
        angle.value = float.Parse(angleNum.text);
    }
    public void Range_S2In()
    {
        rangeNum.text = range.value.ToString();
    }
    public void Range_In2S()
    {
        range.value = float.Parse(rangeNum.text);
    }

}
