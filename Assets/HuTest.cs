using UnityEngine;
using System.Collections;

public class HuTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CardController.Instance.addCard(1, 2);
        CardController.Instance.addCard(1, 3);
        CardController.Instance.addCard(1, 4);

        CardController.Instance.addCard(1, 6);
        CardController.Instance.addCard(1, 7);
        CardController.Instance.addCard(1, 8);

        CardController.Instance.addCard(2,4);
        CardController.Instance.addCard(2, 4);
        CardController.Instance.addCard(2, 5);
        CardController.Instance.addCard(2, 6);
        CardController.Instance.addCard(2, 7);

        CardController.Instance.addCard(2, 8);
        CardController.Instance.addCard(2, 8);
        CardController.Instance.addCard(2, 8);

        Debug.Log(CardController.Instance.checkCard(true));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
