using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateTree : MonoBehaviour
{
    public Text calculating;
    public Dropdown genUI;
    public Text startingUI;
    public Text F_Rule;
    public Text F2_Rule;
    public Text X_Rule;
    public Text X2_Rule;
    public Slider lengthUI;
    public Slider angleUI;
    public Slider rangeUI;
    public Toggle leavesUI;
    public Toggle trunkUI;
    public Color color;

    public int gen;
    public string starting;
    public float length;
    public float angle;
    public float range;
    public Dictionary<string, string> Dic = new Dictionary<string, string>() { { "F", "" }, { "F2", "" }, { "X", "" }, { "X2", "" } };
    public bool proF, proX;
    public bool showLeaves;
    public bool haveTrunk;

    public GameObject leaf;

    public string treeString;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawTree()
    {
        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
        GetValues();
        GenerateString();
        ShowTree();
    }
    void GetValues()
    {
        gen = genUI.value + 1;
        Dic["F"] = F_Rule.text;
        Dic["F2"] = F2_Rule.text;
        if (F2_Rule.text != "")
            proF = true;
        else
            proF = false;
        Dic["X"] = X_Rule.text;
        Dic["X2"] = X2_Rule.text;
        if (X2_Rule.text != "")
            proX = true;
        else
            proX = false;
        starting = startingUI.text;
        length = lengthUI.value;
        angle = angleUI.value;
        range = rangeUI.value;
        showLeaves = leavesUI.isOn;
        haveTrunk = trunkUI.isOn;
    }

    void GenerateString()
    {
        string lastGen = starting;
        string nextGen = "";
        for (int i=0; i<gen; i++)
        {
            nextGen = "";
            foreach (char c in lastGen)
            {
                if (c == 'F')
                    if (proF)
                    {
                        int temp = Random.Range(0, 2);
                        nextGen += (temp == 1 ? Dic["F"] : Dic["F2"]);
                    }
                    else
                        nextGen += Dic["F"];
                else if (c == 'X')
                    if (proX)
                    {
                        int temp = Random.Range(0, 2);
                        nextGen += (temp == 1 ? Dic["X"] : Dic["X2"]);
                    }
                    else
                        nextGen += Dic["X"];
                else
                    nextGen += c;
            }
            lastGen = nextGen;
            Debug.Log(nextGen);
        }
        treeString = lastGen;
    }
    
    void ShowTree()
    {
        Vector3 pos = new Vector3(2.8f, -4.2f, 0f);
        float dir = 90;
        float thick = haveTrunk? 0.1f: 0.05f;
        Stack<Vector3> posStack = new Stack<Vector3>();
        Stack<float> dirStack = new Stack<float>();
        Stack<float> thickStack = new Stack<float>();

        GameObject pen;
        LineRenderer line;

        int index;
        int empty = 0;
        bool newBranch = false;
        bool drawLeaf = false;

        pen = new GameObject();
        pen.transform.SetParent(transform);
        line = pen.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = color;
        line.endColor = color;
        line.startWidth = thick;
        line.endWidth = thick;
        index = 0;
        line.positionCount = index + 1;
        line.SetPosition(index++, pos);

        foreach (char c in treeString)
        {
            switch (c)
            {
                case 'F':
                    if (newBranch)
                    {
                        pen = new GameObject();
                        pen.transform.SetParent(transform);
                        line = pen.AddComponent<LineRenderer>();
                        line.material = new Material(Shader.Find("Sprites/Default"));
                        line.startColor = color;
                        line.endColor = color;
                        line.startWidth = thick;
                        line.endWidth = thick;
                        index = 0;
                        line.positionCount = index + 1;
                        line.SetPosition(index++, pos);
                        newBranch = false;
                    }
                    pos += new Vector3(length * Mathf.Cos(dir * Mathf.Deg2Rad), length * Mathf.Sin(dir * Mathf.Deg2Rad), 0f);
                    if (line.endWidth > 0.015f && haveTrunk)
                    {
                        thick *= 0.98f;
                        line.endWidth = thick;
                    }
                    line.positionCount = index+1;
                    line.SetPosition(index++, pos);
                    empty = 0;
                    Debug.Log(empty);
                    drawLeaf = true;
                    break;
                case 'X':
                    break;
                case '+':
                    dir += angle + Random.Range(-range, range);
                    break;
                case '-':
                    dir -= angle + Random.Range(-range, range);
                    break;
                case '[':
                    posStack.Push(pos);
                    dirStack.Push(dir);
                    thickStack.Push(thick);
                    empty++;
                    Debug.Log(empty);
                    break;
                case ']':
                    empty--;
                    Debug.Log(empty);
                    if (empty < 0)
                    {
                        if (drawLeaf && showLeaves)
                        {
                            GameObject newLeaf = Instantiate(leaf, pos, Quaternion.identity);
                            newLeaf.transform.SetParent(transform);
                            newLeaf.transform.Rotate(new Vector3(0, 0, dir - 90));
                        }
                        drawLeaf = false;
                    }
                    pos = posStack.Pop();
                    dir = dirStack.Pop();
                    thick = thickStack.Pop();
                    newBranch = true;
                    break;
            }
        }
        if (showLeaves)
        {
            GameObject lastLeaf = Instantiate(leaf, pos, Quaternion.identity);
            lastLeaf.transform.SetParent(transform);
            lastLeaf.transform.Rotate(new Vector3(0, 0, dir - 90));
        }
    }
}
