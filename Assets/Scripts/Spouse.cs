using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spouse : Life {

	protected override void SetVitals () {

		base.SetVitals ();

		switch (Player.Current.Sexuality) {

		case Sexuality.BISEXUAL:
			Gender = (Random.value > 0.5f) ? Gender.MALE : Gender.FEMALE;
			break;

		case Sexuality.HOMOSEXUAL:
			Gender = (Player.Current.Gender == Gender.MALE) ? Gender.MALE : Gender.FEMALE;
			break;

		default:
		case Sexuality.HETEROSEXUAL:
			Gender = (Player.Current.Gender == Gender.MALE) ? Gender.FEMALE : Gender.MALE;
			break;

		}

	}

	protected override void SetBasicStats () {

		// TODO: Think about maybe setting appearance from fitness or the other way around?

		Happiness = Random.Range (0, 100f);
		Appearance = Random.Range (0, 100f);
		Fitness = Random.Range (0, 100f);
		Intellect = Random.Range (0, 100f);

	}

}
