using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VoiceBehavior : MonoBehaviour
{
    //按钮
    public Button speakButton;
    public Button synthButton;
    public Button englishButton;

    // Use this for initialization
    void Start()
    {
        if (speakButton != null)
        {
            speakButton.onClick.AddListener(delegate
            {

                //以下两种方法可供选择
                //1.采用静态类调用
                //string text1 = "您好，感谢您对MemoryC的支持！";
                //IFlyVoice.startSpeaking(text1);
                ////2.采用MemoryC对string的扩展方法调用，推荐使用该方法
                //string text2 = "MemoryC祝您工作顺利！";
                //text2.speak();

                //关于选择不同人发音
                //对于以上任意一种方法，在函数参数里面加一个人名参数即可，如：
                IFlyVoice.startSpeaking("Hello world, I'm Henry.", "henry");
                //又如：
                //"我是小梅，感谢您阅读MemoryC的系列文章".speak("xiaomei");

                //////具体有哪些发音人，我附在文章后面////////

                /// //////////////////////////以上方法不可同时执行///////////////////////////////
                /// //////////////////////////////////请选择一种////////////////////////////////////
            });
        }


        if (synthButton != null)
        {
            synthButton.onClick.AddListener(delegate
            {
                //开始识别 普通话
                IFlyVoice.startRecognize();
            });
        }
        if (englishButton != null)
        {
            englishButton.onClick.AddListener(delegate
            {
                //关于选择不同识别语种
                //对于以上方法，在函数参数里面加一个语种参数即可，如：
                IFlyVoice.startRecognize("henry");//粤语
                                                  //////具体有哪些语种，我附在文章后面////////

                /// //////////////////////////以上方法不可同时执行///////////////////////////////
                /// //////////////////////////////////请选择一种////////////////////////////////////

            });
        }
    }
}