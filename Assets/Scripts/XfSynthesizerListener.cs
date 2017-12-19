using UnityEngine;
using System.Collections;

public class XfSynthesizerListener : AndroidJavaProxy
{

    //缓冲进度
    private int mPercentForBuffering = 0;
    //播放进度
    private int mPercentForPlaying = 0;

    public XfSynthesizerListener() : base("com.iflytek.cloud.SynthesizerListener")
    {

    }

    public void onSpeakBegin()
    {
        showTip("开始播放");
    }

    public void onSpeakPaused()
    {
        showTip("暂停播放");
    }

    public void onSpeakResumed()
    {
        showTip("继续播放");
    }

    public void onBufferProgress(int percent, int beginPos, int endPos,
            AndroidJavaObject info)
    {
        // 合成进度
        mPercentForBuffering = percent;
        Debug.Log("缓冲进度为" + mPercentForBuffering + "%，播放进度为" + mPercentForPlaying + "%");
    }

    public void onSpeakProgress(int percent, int beginPos, int endPos)
    {
        // 播放进度
        mPercentForPlaying = percent;
        Debug.Log("缓冲进度为" + mPercentForBuffering + "%，播放进度为" + mPercentForPlaying + "%");
    }

    public void onCompleted(AndroidJavaObject error)
    {
        if (null != error)
        {
            showTip("播放失败");
        }
        else
        {
            showTip("播放完成");
        }
    }

    public void onEvent(int eventType, int arg1, int arg2, AndroidJavaObject BundleObj)
    {
        // 以下代码用于获取与云端的会话id，当业务出错时将会话id提供给技术支持人员，可用于查询会话日志，定位出错原因
        // 若使用本地能力，会话id为null
        //        if (SpeechEvent.EVENT_SESSION_ID == eventType) {
        //                String sid = obj.getString(SpeechEvent.KEY_EVENT_SESSION_ID);
        //                Log.d(TAG, "session id =" + sid);
        //        }
    }

    void showTip(string text)
    {
        Debug.Log(text);
        text.showAsToast();
    }
}