using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour
{

    public Text text;

	// Use this for initialization
	void Start()
    {

	}

	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            text.text =
                "You and your wife, Catelyn, are on a trip to the city " +
                "to set up shop in the market. It's been a rough year, " +
                "and the last of your wares are with you in your cart. " +
                "As you're traveling along the past through the forest " +
                "that lies between your home and the city, you come upon " +
                "a camp that seems to be empty. As soon as you've past " +
                "it men start rushing out from behind the trees.\n\n" +
                "1. Fight them\n" +
                "2. Talk to them\n" +
                "3. Ignore them";
        }
	}

}
