using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants {

	public static float PARENT_CHANCE_TO_BE_PARENT_TYPE_GENDER = 90f;

	// Death
	public static int LIFE_CHANCE_TO_CHECK_IF_MONTH_COULD_KILL_YOU = 100;

	// Age
	public static int PARENT_MIN_AGE_IN_MONTHS = 204, PARENTS_MAX_AGE_IN_MONTHS = 960;
	public static int PARENT_MAX_DISTANCE_FROM_MOTHERS_AGE = 144;

	public static int LIFE_MIN_AGE_TO_STUDY = 60;
	public static int LIFE_MIN_AGE_TO_GUITAR = 60;

	public static int LIFE_ABSOLUTE_MAX_AGE_IN_MONTHS = 1500;

	// Skill
	public static float SCHOOL_BACKGROUND_INTELLECT_GAIN_PER_MONTH = 0.3f; // [PH]
	public static float BASE_SKILL_INCREASE_PER_MONTH = 0.1f;
	public static float BASE_SKILL_CHANCE_TO_ADD_MODIFIER_MOD = 1f;
	public static float BASE_SKILL_AGE_MODIFIER_MOD = 0.003f;
	public static float SKILL_STUDYING_MODIFIER_MOD = 0.6f;

	// Health
	public static int VACCINATION_MAX_MONTH_LENGTH_FLU_PROTECTION = 10;

	public static int TEXT_CHARACTER_LIMIT = 5000;

}
