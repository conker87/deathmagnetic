using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MajorEvent {

	public string EventName;
	public int Age;
	public string EventDescription;

	public int Index = 0;

	public MajorEvent(string eventName, int age, string eventDescription, int index) {

		Age = age;
		EventName = eventName;
		EventDescription = eventDescription;
		Index = index;

	}

}
