﻿using UnityEngine;
using System.Collections;

public class HuTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

        CardController.Instance.addCard(0, 1);
        CardController.Instance.addCard(0, 1);
        CardController.Instance.addCard(0, 1);

        CardController.Instance.addCard(0,2);
        CardController.Instance.addCard(0, 3);
        CardController.Instance.addCard(0, 4);
        CardController.Instance.addCard(0, 5);
        CardController.Instance.addCard(0, 5);
        CardController.Instance.addCard(0, 5);

        CardController.Instance.addCard(0, 6);
        CardController.Instance.addCard(0, 7);
        CardController.Instance.addCard(0, 8);

        CardController.Instance.addCard(0, 9);
        CardController.Instance.addCard(0, 9);

        Debug.Log(CardController.Instance.checkCard(true));

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
