using UnityEngine;
using System.Collections;

public class XfInitListener : AndroidJavaProxy
{

    public XfInitListener() : base("com.iflytek.cloud.InitListener")
    {

    }

    public void onInit(int code)
    {
        //ErrorCode.SUCCESS=0;
        if (code != 0)
        {
            string error = "初始化失败,错误码：" + code;
            error.showAsToast();
        }
    }
}