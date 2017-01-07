using UnityEngine;
using System.Collections;

public class U3DTypeEventListener : MonoBehaviour {

    //初始化完成后回调函数
    void NotifyInitFinish(U3DTypeEvent evt)
    {
        Application.LoadLevelAsync("MainScene");
    }
    //登录操作完成后的回调函数
    void NotifyLogin(U3DTypeEvent evt)
    {
        //解析渠道登录成功返回的信息，一般有user_token,user_id...
        //CP方需要将信息解析为CP服务器约定的数据格式转发给游戏服务器以完成游戏的登录验证
        

    }
    //更新用户信息完成后回调
    void NotifyUpdateFinish(U3DTypeEvent evt)
    {

    }
    //支付结果通知回调，CP需根据支付返回结果完成相应逻辑
    void NotifyPayResult(U3DTypeEvent evt)
    {
        if (evt.evtData.GetData(U3DTypeAttName.PAY_RESULT).Equals("1"))
        { //支付成功
            
        }
        else
        {//支付失败,
            
        }

    }
    //登出结果通知回调
    void NotifyLogout(U3DTypeEvent evt)
    {

    }
    //重登录结果通知回调
    void NotifyRelogin(U3DTypeEvent evt)
    {
  
    }
    //取消退出游戏通知回调
    void NotifyCancelExit(U3DTypeEvent evt)
    {

    }
    //本地推送通知回调，游戏需根据收到的数据实现相应的游戏逻辑
    void NotifyReceiveLocalPush(U3DTypeEvent evt)
    {

    }
    //获取好友列表通知回调
    void NotifyUserFriends(U3DTypeEvent evt)
    {

    }
    //分享结果通知回调
    void NotifyShareResult(U3DTypeEvent evt)
    {

    }
	//额外功能通知回调
	void NotifyExtraFunction(U3DTypeEvent evt){

	}

    //以下部分不建议修改
    private static U3DTypeEventListener instance;
    private static object syncRoot = new object();
    private static GameObject _container;
    private static int createCount = 0;
    void Awake()
    {
        U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.EVENT_INIT_FINISH, NotifyInitFinish);
        U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.EVENT_UPDATE_FINISH, NotifyUpdateFinish);
        U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.EVENT_LOGIN_SUCCESS, NotifyLogin);
        U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.EVENT_PAY_RESULT, NotifyPayResult);
        U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.EVENT_LOGOUT, NotifyLogout);
        U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.EVENT_RELOGIN, NotifyRelogin);
        U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.EVENT_CANCEL_EXIT_GAME, NotifyCancelExit);
        U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.EVENT_SHARE_RESULT, NotifyCancelExit);
        U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.EVENT_RECEIVE_LOCAL_PUSH, NotifyCancelExit);
        U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.EVENT_GET_FRIEND_RESULT, NotifyUserFriends);
//		U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.Event_EXTRA_FUNCTION, NotifyExtraFunction);
        DontDestroyOnLoad(this.gameObject);
    }
    public static U3DTypeEventListener Instance
    {
        get
        {
            if (null == instance)
            {
                _container = new GameObject();
                _container.name = "SDKController";
                UnityEngine.Object.DontDestroyOnLoad(_container);
                lock (syncRoot)
                {
                    if (null == instance)
                    {
                        createCount++;
                        Debug.Log("createCount::::" + createCount);
                        instance = _container.AddComponent(typeof(U3DTypeEventListener)) as U3DTypeEventListener;
                    }
                }
            }
            return instance;
        }
    }
    public void InitSelf()
    {
        Debug.Log("Init U3DTypeEventListener Finished !");
    }
}
