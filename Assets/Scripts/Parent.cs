using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : Life {

	public Parent(Player player, NationalityDetails childNationality) {

		sNationality = player.sNationality;
		NationalityDetails = childNationality;
		// TODO: We need to 

	}


}

public enum ParentType { MOTHER, FATHER }
