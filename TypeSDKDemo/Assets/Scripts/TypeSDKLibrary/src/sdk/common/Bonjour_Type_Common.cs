using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

#if UNITY_ANDROID

public class Bonjour_Type_Common : Bonjour_Type_Base 
{
	
	public override void initSDK()
	{
		System.Console.WriteLine("CallInitSDK");
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
//		U3DTypeBaseData _in_data =  _in_platform;
//		string sendData = _in_data.DataToString();
		jo.Call("CallInitSDK");
	}
	
	public override void ShowLogin()
	{
		System.Console.WriteLine("CallLogin");

		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
	
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

		jo.Call("CallLogin","");

	}
    public override void ShowLogin(string loginType)
    {
        System.Console.WriteLine("CallYSDKLogin");

        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

        jo.Call("CallLogin", loginType);

    }
	public override void ShowLogout()
	{
		System.Console.WriteLine("CallLogout");
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
		jo.Call("CallLogout");
	}
	public override void ShowPersonCenter()
	{
		System.Console.WriteLine("CallPersonCenter");

		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
		jo.Call("CallPersonCenter");
	}
	public override void HidePersonCenter()
	{
		System.Console.WriteLine("CallHidePersonCenter");

		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
		jo.Call("CallHidePersonCenter");
	}
	public override void ShowToolBar()
	{
		System.Console.WriteLine("CallToolBar");

		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
		jo.Call("CallToolBar");
	}
	public override void HideToolBar()
	{
		System.Console.WriteLine("CallHideToolBar");

		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
		jo.Call("CallHideToolBar");
	}
	public override string PayItem(U3DTypeBaseData _in_pay)
	{
		System.Console.WriteLine("CallPayItem" + "data: "+ _in_pay.DataToString());

		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		//		System.Console.Write("write line 16 show login step"+ jo.ToString()	);
		//System.Object argArr[2] = new System.Object
		string sendData = _in_pay.DataToString();
		string billNo =  jo.Call<string>("CallPayItem",sendData);
		return billNo;
	}
	public override int LoginState()
	{
		System.Console.WriteLine("CallLoginState");

		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
	
		int value = jo.Call<int>("CallLoginState");
		return value;
	}
	public override void ShowShare(U3DTypeBaseData _in_data)
	{
		System.Console.WriteLine("CallShare" +"data: "+ _in_data.DataToString());

		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
		string sendData = _in_data.DataToString();
		jo.Call("CallShare",sendData);
	}
	public override void SetPlayerInfo(U3DTypeBaseData _in_data)
	{
		System.Console.WriteLine("CallSetPlayerInfo" + " data :" + _in_data.DataToString());

		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

		string sendData = _in_data.DataToString();
		jo.Call("CallSetPlayerInfo",sendData);

	}
	public override U3DTypeBaseData GetUserData ()
	{
		System.Console.WriteLine("CallUserData");

		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
		string value = jo.Call<string>("CallUserData");
		U3DTypeBaseData outData = new U3DTypeBaseData();
		outData.StringToData(value);
		return outData;
	}
	public override U3DTypeBaseData GetPlatformData ()
	{
		System.Console.WriteLine("CallPlatformData");

  		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        		
        string value = jo.Call<string>("CallPlatformData");
		U3DTypeBaseData outData = new U3DTypeBaseData();
		outData.StringToData(value);
		return outData;

	}

	public override void CopyClipboard (U3DTypeBaseData _in_data)
	{
		System.Console.WriteLine("CallLogout" +" data: "+ _in_data.DataToString());

		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
		string sendData = _in_data.DataToString();
		jo.Call("CallCopyClipboard",sendData);
	}
	public override bool IsHasRequest(string requestType)
	{
		System.Console.WriteLine("IsHasRequest" + " type " + requestType);

		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
		bool value = jo.Call<bool>("CallIsHasRequest",requestType);
		return value;
	}
	public override void Destory()
	{
		System.Console.WriteLine("CallDestory");

		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
		jo.Call("CallDestory");
		
	}
	public override void ExitGame()
	{
		System.Console.WriteLine("ExitGame");

		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
		jo.Call("CallExitGame");
	}
	
	/**call any undefine function if success or return error*/
	public override string DoAnyFunction(string funcName,U3DTypeBaseData _in_data)
	{
		System.Console.WriteLine("DoAnyFunction");

		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
		string value = jo.Call<string>("CallAnyFunction",funcName,_in_data.DataToString());
		return value;
	}

	public override string DoPhoneInfo()
	{
		System.Console.WriteLine("DoPhoneInfo");

		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
		string value = jo.Call<string>("CallPhoneInfo");
		return value;
	}

	public override void AddLocalPush (U3DTypeBaseData _push_data)
	{
		System.Console.WriteLine("AddLocalPush");
		
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

		string sendData = _push_data.DataToString();
		jo.Call("AddLocalPush",sendData);
	}
	public override void RemoveLocalPush (string _push_id)
	{
		System.Console.WriteLine("RemoveLocalPush");
		
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

		jo.Call("RemoveLocalPush",_push_id);
	}
	public override void RemoveAllLocalPush ()
	{
		System.Console.WriteLine("RemoveAllLocalPush");
		
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		jo.Call("RemoveAllLocalPush");
	}
	public override void GetUserFriends ()
	{
		System.Console.WriteLine("GetUserFriends");
		
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
		jo.Call("GetUserFriends");
	}
}

#endif