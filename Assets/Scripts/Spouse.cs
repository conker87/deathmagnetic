﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spouse : Life {

	protected void SetVitals () {

		switch (Zeus.Current.Player.Sexuality) {

		case Sexuality.BISEXUAL:
			Gender = (Random.value > 0.5f) ? Gender.MALE : Gender.FEMALE;
			break;

		case Sexuality.HOMOSEXUAL:
			Gender = (Zeus.Current.Player.Gender == Gender.MALE) ? Gender.MALE : Gender.FEMALE;
			break;

		default:
		case Sexuality.HETEROSEXUAL:
			Gender = (Zeus.Current.Player.Gender == Gender.MALE) ? Gender.FEMALE : Gender.MALE;
			break;

		}

	}

	protected void SetBasicStats () {

		// TODO: Think about maybe setting appearance from fitness or the other way around?

		Happiness = Random.value * 100f;
		Appearance = Random.value * 100f;
		Fitness = Random.value * 100f;
		Intellect = Random.value * 100f;

	}

}
