using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Card : MonoBehaviour {

	/*
	* 1-9 are regular
	* 10 is skip
	* 11 is reverse
	* 12 is draw 2
	* 13 is wild
	* 14 is wild draw 4
	*/

	int number;
	string color;
	GameObject cardObj;
	string[] lables={"Facts","Values","Sports Events","Mobility Devices","Achievers","Deafness","Blindness","Books","Disabilities","Movies"};
	string[] bluecards={"FACTS           Disability is NOT a disease",
						"VALUES           Speak Respectfully",
						"SPORTS EVENTS           Paralympic Games",
						"MOBILITY DEVICES           Walkers",
						"ACHIEVERS           IRA Singhal is an IAS officer with a spine related disorder",
						"DEAFNESS           Cochlear Implant",
						"BLINDNESS           Guide Dog",
						"BOOKS               No Looking Back by Shivani Gupta",
						"DISABILITY           Deafblindness",
						"MOVIES            Yellow (portraying Down Syndrome)"};

	string[] greencards={
						"FACTS           Disability can be Visible and Invisible",
						"VALUES            Do not Bully",
						"SPORTS EVENTS           Deaflympics",
						"MOBILITY DEVICES           White Cane",
						"ACHIEVERS           Shekhar Naik is an Indian blind Cricketer.",
						"DEAFNESS           Lip Reading",
						"BLINDNESS           Braille Slate",
						"BOOKS             The Story of My Life by Helen Keller",
						"DISABILITY           Learning Disability",
						"MOVIES            The Colour of Paradise (portraying Blindness)"};

	string[] redcards={
						"FACTS           There are various Types and Degrees of disabilities in people",
						"VALUES           Think Before you speak",
						"SPORTS EVENTS           Special Olympics",
						"MOBILITY DEVICES           Crutches",
						"ACHIEVERS           Deepa Malik, a wheelchair user is a silver medallist in 2016 Paralympics",
						"DEAFNESS           Hearing Aids",
						"BLINDNESS           Audio Books",
						"BOOKS             One Little Finger by Malini Chib",
						"DISABILITY           Dwarfism",
						"MOVIES            Taare Zameen Par (portraying Learning Disability)"};

	string[] yellowcards={
						"FACTS           The Indian Government recognizes 21 disabilities",
						"VALUES           Have Empathy",
						"SPORTS EVENTS           World Dwarf Games",
						"MOBILITY DEVICES           Powered Wheelchairs",
						"ACHIEVERS           Arunima Sinha is the first female amputee to scale Mount Everest",
						"DEAFNESS           Sign Languages",
						"BLINDNESS           Magnifying Glass",
						"BOOKS             Flight Without Sight by Preeti Monga",
						"DISABILITY           Autism Spectrum Disorder",
						"MOVIES            Rain Man (portraying Autism Spectrum Disorder)"};

	public Card (int numb, string color, GameObject obj) { //defines the object
		number = numb;
		this.color = color;
		cardObj = obj;
	}
	public GameObject loadCard(int x, int y, Transform parent) { //when ran, it tells where to load the card on the screen
		GameObject temp = loadCard (parent);
		temp.transform.localPosition = new Vector2 (x, y+540);
		return temp;
	}
	public GameObject loadCard(Transform parent) { //does all the setup for loading. Used if card doesn't need a specific position		
		GameObject temp = Instantiate (cardObj);
		temp.name = color + number;
		if (number < 10) {
			foreach (Transform childs in temp.transform) {
				if (childs.name.Equals ("Cover"))
					break;
				if(color == "Blue"){
					childs.GetComponent<Text> ().text = bluecards[number]; //displaying
				}
				else if(color == "Green"){
					childs.GetComponent<Text> ().text = greencards[number]; //displaying
				}
				else if(color == "Red"){
					childs.GetComponent<Text> ().text = redcards[number]; //displaying
				}
				else{
					childs.GetComponent<Text> ().text = yellowcards[number]; //displaying
				}
				
			}
			temp.transform.GetChild (1).GetComponent<Text> ().color = returnColor (color);
		}
		else if (number == 10 || number == 11 || number==12) {
			temp.transform.GetChild (1).GetComponent<RawImage> ().color = returnColor (color);
		}
		else if (number == 13) {
			temp.transform.GetChild (0).GetComponent<Text> ().text = "";
			temp.transform.GetChild (2).GetComponent<Text> ().text = "";
		}

		temp.GetComponent<RawImage> ().texture = Resources.Load (color + "Card") as Texture2D;
		temp.transform.SetParent (parent);
		temp.transform.localScale = new Vector3 (1, 1, 1);
		return temp;
	}
	Color returnColor(string what) { //returns a color based on the color string
		switch (what) {
		case "Green":
			return new Color32 (0x55, 0xaa, 0x55,255);
		case "Blue":
			return new Color32 (0x55, 0x55, 0xfd,255);
		case "Red":
			return new Color32 (0xff, 0x55, 0x55,255);
		case "Yellow":
			return new Color32 (0xff, 0xaa, 0x00,255);
		}
		return new Color (0, 0, 0);
	}
	public int getNumb() { //accessor for getting the number
		return number;
	}
	public string getColor() { //accessor for getting the color
		return color;
	}
	public bool Equals(Card other) { //overides the original Equals so that color or number must be equal
		return other.getNumb () == number || other.getColor ().Equals (color);
	}
	public void changeColor(string newColor) { //mutator that changes the color of a wild card to make the color noticable
		color = newColor;
	}
}
