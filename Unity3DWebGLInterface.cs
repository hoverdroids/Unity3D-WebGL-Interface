using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
  
public class WebGLCanvasInterface : MonoBehaviour{
    //REQUIRED CALL from c# else unity strips it and no other functions will work
    //NOTE you must call the following at least once so the other js functions can call them, else Unity strips the functions and the js functions can't use them

    /*----------------------------------------    General Use    -------------------------------------------------------*/
    [DllImport("__Internal")]
    private static extern void consoleLogThis();

    [DllImport("__Internal")]
    private static extern void getOptObj(bool debug, bool csIsCalling, string gameInstanceName, string optName, bool isCanvasOpt, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void getOptObjMixed(bool debug, bool csIsCalling, string gameInstanceName, string optName, bool isCanvasOpt, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string serializeOpt(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, string optName, bool doSerialize, bool isCanvasOpt, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string serializeCanvasOpt(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, string optName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string serializeCanvasOptMixed(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, string optName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string stringToBuffer(string str, bool csIsCalling, bool returnBuffer);

    /*----------------------------------------    gameInstance    -------------------------------------------------------*/
    [DllImport("__Internal")]
    private static extern void getGameInstance(bool debug, bool csIsCalling, string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void consoleLogGameInstance(bool csIsCalling, string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void getGameInstanceModule(bool debug, bool csIsCalling, string gameInstanceName, bool onlyReturnData);
    
    [DllImport("__Internal")]
    private static extern void consoleLogGameInstanceModule(bool csIsCalling, string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void getGameInstanceModuleAsmLibArg(bool debug, bool csIsCalling, string gameInstanceName, bool onlyReturnData);
    
    [DllImport("__Internal")]
    private static extern void consoleLogGameInstanceModuleAsmLibArg(bool csIsCalling, string gameInstanceName, bool onlyReturnData);    

    [DllImport("__Internal")]
    private static extern void serializeGameInstanceOpt(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, string optName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getGameInstanceUrl(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    /*----------------------------------------    GLctx (Enscripten WebGL Context)     -------------------------------------------------------*/
    [DllImport("__Internal")]
    private static extern void getGLctx(bool debug, bool csIsCalling, string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void consoleLogGLctx(bool csIsCalling, string gameInstanceName, bool onlyReturnData);
    
    [DllImport("__Internal")]
    private static extern string serializeGLctxOpt(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, string optName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLGLctxDrawingBufferHeight(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLGLctxDrawingBufferWidth(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    /*----------------------------------------    Canvas    -------------------------------------------------------*/    
    [DllImport("__Internal")]
    private static extern void getCanvas(bool debug, bool csIsCalling, string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void consoleLogCanvas(bool csIsCalling, string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void getWebGLCanvasParentElement(bool debug, bool csIsCalling, string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void consoleLogWebGLCanvasParentElement(bool csIsCalling, string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void getWebGLCanvasParentNode(bool debug, bool csIsCalling, string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void consoleLogWebGLCanvasParentNode(bool csIsCalling, string gameInstanceName, bool onlyReturnData);


   /*    
    [DllImport("__Internal")]
    private static extern string serializeCanvasAttr(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, string optName, string attrName, bool doSerialize);

  */
  

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasAccessKey(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasAssignedSlot(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasAttributeStyleMap(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasAttributes(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasAutoCapitalize(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasBaseURI(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasChildElementCount(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasClassName(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasClientHeight(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasClientLeft(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasClientTop(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasClientWidth(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasDir(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasHeight(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasHeightNative(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasId(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasIsConnected(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasOffsetHeight(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasOffsetLeft(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasOffsetTop(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasOffsetWidth(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasScrollHeight(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasScrollLeft(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasScrollTop(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasScrollWidth(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasWidth(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasWidthNative(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasTitle(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);
    
    [DllImport("__Internal")]
    private static extern string getWebGLCanvasParentAttr(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, string attrName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasParentId(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasParentName(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasParentClass(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasParentStyle(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasParentTitle(bool debug, bool csIsCalling, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    private bool printMethodsOnUpdate = false;

    void Start(){         
       printAllMethods();
    }

    // Update is called once per frame
    void Update(){
        if(printMethodsOnUpdate){
            printAllMethods();
        }
    }

    public void togglePrintMethodsOnUpdate(){
        printMethodsOnUpdate = !printMethodsOnUpdate;
    }

    public void printAllMethods(){
        //The WebGLCanvasInterface.jslib functions can reference the current WebGL game instance or call the functions of any other WebGL game
        //instance that is a child to the window object. Pass the empty string "" to reference this instance or the global variable name of another instance.
        //EX:   Pass "gameInstance" for the standard unity webgl template
        //      var gameInstance = UnityLoader.instantiate(...)
        string gameInstanceName = "gameInstance";

        //NOTE: if you know that you are only calling local js function - ie not that of other gameInstances - then there is no need to
        //first call the "required" functions as they'll be called naturally when/if they're used. Note that this also means other gameInstance
        //objects cannot call those functions on this gameInstance as the functions will be stripped out when not used

        //TODO the following function MUST be called at least once since they are dependencies for other functions. If you don't call them then they
        //will be stripped when building with high strip settings.
        //The console log methods are only useful during development as they output to the browser console
        //You MUST actually call this function when max stripping; if lite stripping, then just list above
        
        //It is really not advisable to serialize the entire game instance object, canvas, or GLctx objects as it adds a huge delay. But, the functions
        //below must get called or they will be stripped by unity. So, we call them with optNames that we know will minimize the affects on loading time
        getGameInstance(false, true, gameInstanceName, true);//This will not return an object that is useful to C#, only to js.
        getGameInstanceModule(false, true, gameInstanceName, true);
        getGameInstanceModuleAsmLibArg(false, true, gameInstanceName, true);
        getGLctx(false, true, gameInstanceName, true);
        getOptObj(false, true, gameInstanceName, "drawingBufferHeight", false, true);
        getOptObjMixed(false, true, gameInstanceName, "drawingBufferHeight", false, true);
        stringToBuffer("Str Cannot Be empty!", true, true);
        serializeOpt(false, true, true, gameInstanceName, "drawingBufferHeight", false, false, true);
        
        
        /* The following are the primary objects that are exposed through this library */
        consoleLogThis();
        consoleLogGameInstance(true, gameInstanceName, true);
        consoleLogGameInstanceModule(true, gameInstanceName, true);
        consoleLogGameInstanceModuleAsmLibArg(true, gameInstanceName, true);
        consoleLogGLctx(true, gameInstanceName, true);

        /* GLctx Options
           Honestly, the most relevant options for this object are drawingBufferHeight, drawingBufferWidth, and canvas. Most likely you'll only ever
           use Canvas options. But, this was here for completeness and in case other useful info is added to the WebGL context in the future.
        */
        Debug.Log("C# serializeGLctxOpt \"\":" + serializeGLctxOpt(false, true, true, gameInstanceName, "drawingBufferHeight", false, true));//Your only need to call this if you need to call one of the two functions below
        Debug.Log("C# GLctx DrawingBufferHeight:" + getWebGLGLctxDrawingBufferHeight(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# GLctx DrawingBufferWidth:" + getWebGLGLctxDrawingBufferWidth(true, true, true, gameInstanceName, false, true));

        /* GameInstance Options */
        serializeGameInstanceOpt(false, true, true, gameInstanceName, "url", false, true);//The url option is here to prevent attempting to serialize the whole massive gameInstance object
        Debug.Log("C# GameInstanceUrl:" + getGameInstanceUrl(true, true, true, gameInstanceName, false, true));
        
        /*Canvas Options */
        serializeCanvasOpt(false, true, true, gameInstanceName, "baseURI", false, true);
        serializeCanvasOptMixed(false, true, true, gameInstanceName, "baseURI", false, true);
        getCanvas(false, true, gameInstanceName, true);
        consoleLogCanvas(true, gameInstanceName, true);
        getWebGLCanvasParentElement(false, true, gameInstanceName, true);
        consoleLogWebGLCanvasParentElement(true, gameInstanceName, true);
        getWebGLCanvasParentNode(false, true, gameInstanceName, true);
        consoleLogWebGLCanvasParentNode(true, gameInstanceName, true);
        Debug.Log("C# Canvas AccessKey:" + getWebGLCanvasAccessKey(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas AssignedSlot:" + getWebGLCanvasAssignedSlot(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas AttributesStyleMap:" + getWebGLCanvasAttributeStyleMap(true, true, true, gameInstanceName, true, true));
        Debug.Log("C# Canvas Attributes:" + getWebGLCanvasAttributes(true, true, true, gameInstanceName, true, true));
        Debug.Log("C# Canvas AutoCapitalize:" + getWebGLCanvasAutoCapitalize(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas BaseUri:" + getWebGLCanvasBaseURI(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ChildElementCount:" + getWebGLCanvasChildElementCount(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ClassName:" + getWebGLCanvasClassName(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ClientHeight:" + getWebGLCanvasClientHeight(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ClientLeft:" + getWebGLCanvasClientLeft(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ClientTop:" + getWebGLCanvasClientTop(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ClientWidth:" + getWebGLCanvasClientWidth(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas Dir:" + getWebGLCanvasDir(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas Height:" + getWebGLCanvasHeight(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas HeightNative:" + getWebGLCanvasHeightNative(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ID:" + getWebGLCanvasId(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas IsConnected:" + getWebGLCanvasIsConnected(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas OffsetHeight:" + getWebGLCanvasOffsetHeight(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas OffsetLeft:" + getWebGLCanvasOffsetLeft(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas OffsetTop:" + getWebGLCanvasOffsetTop(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas OffsetWidth:" + getWebGLCanvasOffsetWidth(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ScrollHeight:" + getWebGLCanvasScrollHeight(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ScrollLeft:" + getWebGLCanvasScrollLeft(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ScrollTop:" + getWebGLCanvasScrollTop(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ScrollWidth:" + getWebGLCanvasScrollWidth(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas Width:" + getWebGLCanvasWidth(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas WidthNative:" + getWebGLCanvasWidthNative(true, true, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas Title:" + getWebGLCanvasTitle(true, true, true, gameInstanceName, false, true));
     
        /*
        
        Debug.Log("C# Canvas ParentAttr-Style:" + getWebGLCanvasParentAttr(true, true, true, gameInstanceName, "style", false));
        Debug.Log("C# Canvas ParentID:" + getWebGLCanvasParentId(true, true, true, gameInstanceName, false));
        Debug.Log("C# Canvas ParentName:" + getWebGLCanvasParentName(true, true, true, gameInstanceName, false));
        Debug.Log("C# Canvas ParentClass:" + getWebGLCanvasParentClass(true, true, true, gameInstanceName, false));
        Debug.Log("C# Canvas ParentStyle:" + getWebGLCanvasParentStyle(true, true, true, gameInstanceName, false));
        Debug.Log("C# Canvas ParentTitle:" + getWebGLCanvasParentTitle(true, true, true, gameInstanceName, false));
        */
    }
}