using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class XfRecognizerListener : AndroidJavaProxy
{

    public XfRecognizerListener() : base("com.iflytek.cloud.RecognizerListener")
    {

    }

    public string resultString = "";

    public void onVolumeChanged(int volume, byte[] data)
    {
        string showText = "当前正在说话，音量大小：" + volume;
        showText.showAsToast();
        Debug.Log("返回音频数据：" + data.Length);
    }

    public void onResult(AndroidJavaObject result, bool isLast)
    {
        string text = "";
        if (null != result)
        {
            try
            {
                AndroidJavaObject res = result.Call<AndroidJavaObject>("getResultString");
                byte[] resultByte = res.Call<byte[]>("getBytes");
                text = System.Text.Encoding.Default.GetString(resultByte);

            }
            catch (Exception error)
            {
                Debug.LogError(error.ToString());
            }
        }
        resultString = resultString + text;
        if (isLast)
        {
            //TODO 最后的结果
            Debug.Log(resultString);
            resultString.showAsToast();
        }
    }

    public void onEndOfSpeech()
    {
        // 此回调表示：检测到了语音的尾端点，已经进入识别过程，不再接受语音输入                
        "结束说话".showAsToast();
    }

    public void onBeginOfSpeech()
    {
        // 此回调表示：sdk内部录音机已经准备好了，用户可以开始语音输入
        resultString = "";
    }

    public void onError(AndroidJavaObject error)
    {
        //error code=10118 代表您没有说话，请查看APP是否被安全软件禁用了录音功能
        string errorText = "onError Code：" + error.Call<int>("getErrorCode");
        errorText.showAsToast();
    }

    public void onEvent(int eventType, int arg1, int arg2, AndroidJavaObject BundleObj)
    {
        // 以下代码用于获取与云端的会话id，当业务出错时将会话id提供给讯飞云的技术支持人员，可用于查询会话日志，定位出错原因
        //        if (SpeechEvent.EVENT_SESSION_ID == eventType) {
        //                String sid = obj.getString(SpeechEvent.KEY_EVENT_SESSION_ID);
        //                Log.d(TAG, "session id =" + sid);
        //        }
    }
}