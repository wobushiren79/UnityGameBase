using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        List<int> testList = new List<int>();
        testList.Add(1);
        testList.Add(2);
        testList.Add(3);
        testList.Add(4);
        testList.Add(5);
        testList.Add(6);
        testList.Add(7);
        testList.Add(8);
        testList.Add(9);
        testList.Add(10);
        RandomUtil.GetRandomListByList<int>(testList);
        foreach (int item in  testList )
        {
            LogUtil.Log(item+"");
        }
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
