using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : Life {

	public ParentType ParentType;

	public virtual void Create() {

		#region Sexuality
		if (ParentType == ParentType.MOTHER) {

			// We first decide the sexuality of the first parent (which is always the mother, easier that way)
			//	The chance to Heterosexual is 90%, with being Bi or Homosexual given both 5% chances.
			//	I could look up actual populations of Bisexual and Homosexual people in the world to get an accurate chance, but I'm lazy.
			Sexuality = (Random.value > (1f - (Constants.PARENT_CHANCE_TO_BE_PARENT_TYPE_GENDER / 100f)) ? Sexuality.HETEROSEXUAL :
								((Random.value > 0.5f) ? Sexuality.BISEXUAL : Sexuality.HOMOSEXUAL));

			// "Default"
			if (Sexuality == Sexuality.HETEROSEXUAL) {

				Gender = Gender.FEMALE;

			}

			// If the Mother is not Heterosexual, then the chance for adoption due to not being able to bilogically conceive increases from 0% to 25%.
			//	25%, and not 50%, because there is stll another 50% chance for the Father to be randomly picked as the opposing gender.
			if (Sexuality != Sexuality.HETEROSEXUAL) {

				Gender = (Random.value > 0.5f) ? Gender.FEMALE : Gender.MALE;

			}

			// The age of the mother is then assigned, default values are minimum age of 17 and maximum age of 85.
			Age = Random.Range (Constants.PARENT_MIN_AGE_IN_MONTHS, Constants.PARENTS_MAX_AGE_IN_MONTHS);

		}

		if (ParentType == ParentType.FATHER) {
			
			if (Zeus.Current.Mother.Sexuality == Sexuality.HETEROSEXUAL) {

				Gender = (Zeus.Current.Mother.Gender == Gender.MALE) ? Gender.FEMALE : Gender.MALE;
				Sexuality = (Random.value < Constants.PARENT_CHANCE_TO_BE_PARENT_TYPE_GENDER) ? Sexuality.HETEROSEXUAL : Sexuality.BISEXUAL;

			}

			if (Zeus.Current.Mother.Sexuality == Sexuality.BISEXUAL) {

				if (Zeus.Current.Mother.Gender == Gender.MALE) {

					Gender = Gender.MALE;

				} else {

					Gender = (Random.value > 0.5f) ? Gender.FEMALE : Gender.MALE;

				}

				if (Zeus.Current.Mother.Gender == Gender) {

					Sexuality = (Random.value > 0.5f) ? Sexuality.BISEXUAL : Sexuality.HOMOSEXUAL;

				} else {

					Sexuality = (Random.value > 0.05f) ? Sexuality.HETEROSEXUAL : Sexuality.BISEXUAL;

				}

			}

			if (Zeus.Current.Mother.Sexuality == Sexuality.HOMOSEXUAL) {

				Gender = Zeus.Current.Mother.Gender;
				Sexuality = Zeus.Current.Mother.Sexuality;

			}

			Age = Mathf.Clamp 	(
									Random.Range	(
														Zeus.Current.Mother.Age - (Constants.PARENT_MAX_DISTANCE_FROM_MOTHERS_AGE / 2),
														Zeus.Current.Mother.Age + (Constants.PARENT_MAX_DISTANCE_FROM_MOTHERS_AGE / 2)
													),
									Constants.PARENT_MIN_AGE_IN_MONTHS,
									Constants.LIFE_ABSOLUTE_MAX_AGE_IN_MONTHS
								);

		}
		#endregion

		#region Basic Stats
		Happiness = Random.value * 100f;
		Appearance = Random.value * 100f;
		Fitness = Random.value * 100f;
		Intellect = Random.value * 100f;
		#endregion

		if (ParentType == ParentType.MOTHER) {

			Nationality = Zeus.SetNationality ();

		}

		if (ParentType == ParentType.FATHER) {

			Nationality = (Random.value < Constants.PARENT_CHANCE_TO_BE_PARENT_TYPE_GENDER) ? Zeus.Current.Mother.Nationality : Zeus.SetNationality ();

		}

	}

}

public enum ParentType { MOTHER, FATHER }
