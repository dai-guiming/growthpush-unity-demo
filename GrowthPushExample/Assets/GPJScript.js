#pragma strict

var applicationId : int = 0;
var secret : String = "secret";
var environment : GrowthPush.Environment = GrowthPush.Environment.development;
var option : GrowthPush.Option = GrowthPush.Option.All;
var debug : boolean = true;
var senderId : String = "senderId";

function Awake () {
	GrowthPush.initialize(applicationId, secret, environment, option, debug);
	GrowthPush.register(senderId);
}

function Start () {

}

function Update () {

}

function OnGUI () {
		if(GUI.Button(new Rect(10, 10, 100, 100), "tap button")) {
			GrowthPush.trackEvent("tap button");
		}

		if(GUI.Button(new Rect(10, 120, 100, 100), "setTag tappbutton")) {
			GrowthPush.setTag("tap button");
		}
	}