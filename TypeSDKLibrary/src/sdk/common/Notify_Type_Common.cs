using UnityEngine;
using System.Collections;

public class Notify_Type_Common :MonoBehaviour
{

//	public static const string MSG_LOGIN="NotifyLogin";
//	public static const string MSG_LOGOUT="NotifyLogout";
//	public static const string MSG_PAYRESULT="NotifyPayResult";
	//登录响应
	public void NotifyLogin(string _in_data)
	{
		Debug.Log("u3d part notify login "+ _in_data);
		U3DTypeSDK.Instance.GetUserData().StringToData(_in_data);
		U3DTypeBaseData resultDat = U3DTypeSDK.Instance.GetUserData();
		U3DTypeSDK.Instance.SendEvent(TypeEventType.EVENT_LOGIN_SUCCESS,resultDat);
	}
	//登出响应
	public void NotifyLogout(string _in_data)
	{
		U3DTypeBaseData resultDat = new U3DTypeBaseData();
		resultDat.StringToData(_in_data);
		U3DTypeSDK.Instance.SendEvent(TypeEventType.EVENT_LOGOUT,resultDat);
	}
	//支付结果响应
	public void NotifyPayResult(string _in_data)
	{
		U3DTypeBaseData resultDat = new U3DTypeBaseData();
		resultDat.StringToData(_in_data);
		U3DTypeSDK.Instance.SendEvent(TypeEventType.EVENT_PAY_RESULT,resultDat);
	}
	//更新完毕响应
	public void NotifyUpdateFinish(string _in_data)
	{
		U3DTypeBaseData resultDat = new U3DTypeBaseData();
		resultDat.StringToData(_in_data);
		U3DTypeSDK.Instance.SendEvent(TypeEventType.EVENT_UPDATE_FINISH,resultDat);
	}
	//初始化完毕响应
	public void NotifyInitFinish(string _in_data)
	{
		U3DTypeBaseData resultDat = new U3DTypeBaseData();

		resultDat.StringToData(_in_data);
		U3DTypeSDK.Instance.SendEvent(TypeEventType.EVENT_INIT_FINISH,resultDat);
	}
	//重新登录响应
	public void NotifyRelogin(string _in_data)
	{
		U3DTypeBaseData resultDat = new U3DTypeBaseData();
		resultDat.StringToData(_in_data);
		U3DTypeSDK.Instance.SendEvent(TypeEventType.EVENT_RELOGIN,resultDat);
	}
	public void NotifyCancelExitGame(string _in_data)
	{
		U3DTypeBaseData resultDat = new U3DTypeBaseData();
		resultDat.StringToData(_in_data);
		U3DTypeSDK.Instance.SendEvent(TypeEventType.EVENT_CANCEL_EXIT_GAME,resultDat);
	}

	/**收到本地推送相应（非必接）*/
	public void NotifyReceiveLocalPush(string _in_data)
	{
		U3DTypeBaseData resultDat = new U3DTypeBaseData();
		resultDat.StringToData(_in_data);
		U3DTypeSDK.Instance.SendEvent(TypeEventType.EVENT_RECEIVE_LOCAL_PUSH,resultDat);
	
	}

	public void NotifyUserFriends(string _json_string)
	{
		U3DTypeBaseData resultDat = new U3DTypeBaseData();
		resultDat.StringToData(_json_string);
		U3DTypeSDK.Instance.SendEvent(TypeEventType.EVENT_GET_FRIEND_RESULT,resultDat);
	}
	public void NotifyShareResult(string _json_string)
	{
		U3DTypeBaseData resultDat = new U3DTypeBaseData();
		resultDat.StringToData(_json_string);
		U3DTypeSDK.Instance.SendEvent(TypeEventType.EVENT_SHARE_RESULT,resultDat);
	}
	void NotifyExtraFunction(string _json_string)
	{
		U3DTypeBaseData resultDat = new U3DTypeBaseData();
		resultDat.StringToData(_json_string);
		U3DTypeSDK.Instance.SendEvent(TypeEventType.Event_EXTRA_FUNCTION,resultDat);
	}
}
