using UnityEngine;
using System.Collections.Generic;

public class GPScript  : MonoBehaviour {

	public int applicationId = 0;
	public string secret = "secret";
	public bool debug = true;
	public GrowthPush.Environment environment = GrowthPush.Environment.development;
	public GrowthPush.Option option = GrowthPush.Option.All;
	public string senderID = "senderID";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake () {
		GrowthPush.initialize(applicationId, secret, environment, debug, option);
		GrowthPush.register(senderID);

		GrowthPush.launchWithNotification(data => {
			object growthpushObj = null;
			if(data.TryGetValue("growthpush", out growthpushObj)) {
				object notificationId = null;
				if((growthpushObj as Dictionary<string, object >).TryGetValue("notificationId", out notificationId)) {
					GrowthPush.trackEvent("Launch via push notification " + notificationId);
				}
			}
		});
	}

	void OnGUI () {
		if(GUI.Button(new Rect(10, 10, 100, 100), "trackEvent launch!")) {
			GrowthPush.trackEvent("launch!");
		}

		if(GUI.Button(new Rect(10, 120, 100, 100), "setTag launch")) {
			GrowthPush.setTag("launch");
		}
	}
}
