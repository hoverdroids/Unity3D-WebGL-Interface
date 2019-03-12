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
    private static extern void getOptObj(bool debug, string gameInstanceName, string optName, bool isCanvasOpt, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string serializeOpt(bool debug,  bool returnBuffer, string gameInstanceName, string optName, bool doSerialize, bool isCanvasOpt, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string serializeCanvasOpt(bool debug, bool returnBuffer, string gameInstanceName, string optName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string stringToBuffer(string str, bool returnBuffer);

    /*----------------------------------------    gameInstance    -------------------------------------------------------*/
    [DllImport("__Internal")]
    private static extern void getGameInstance(bool debug, string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void consoleLogGameInstance(string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void getGameInstanceModule(bool debug, string gameInstanceName, bool onlyReturnData);
    
    [DllImport("__Internal")]
    private static extern void consoleLogGameInstanceModule(string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void getGameInstanceModuleAsmLibArg(bool debug, string gameInstanceName, bool onlyReturnData);
    
    [DllImport("__Internal")]
    private static extern void consoleLogGameInstanceModuleAsmLibArg(string gameInstanceName, bool onlyReturnData);    

    [DllImport("__Internal")]
    private static extern void serializeGameInstanceOpt(bool debug, bool returnBuffer, string gameInstanceName, string optName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getGameInstanceUrl(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    /*----------------------------------------    GLctx (Enscripten WebGL Context)     -------------------------------------------------------*/
    [DllImport("__Internal")]
    private static extern void getGLctx(bool debug, string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void consoleLogGLctx(string gameInstanceName, bool onlyReturnData);
    
    [DllImport("__Internal")]
    private static extern string serializeGLctxOpt(bool debug, bool returnBuffer, string gameInstanceName, string optName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLGLctxDrawingBufferHeight(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLGLctxDrawingBufferWidth(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    /*----------------------------------------    Canvas    -------------------------------------------------------*/    
    [DllImport("__Internal")]
    private static extern void getCanvas(bool debug, string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void consoleLogCanvas(string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void getWebGLCanvasParentElement(bool debug, string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void consoleLogWebGLCanvasParentElement(string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void getWebGLCanvasParentNode(bool debug, string gameInstanceName, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern void consoleLogWebGLCanvasParentNode(string gameInstanceName, bool onlyReturnData);


   /*    
    [DllImport("__Internal")]
    private static extern string serializeCanvasAttr(bool debug, bool returnBuffer, string gameInstanceName, string optName, string attrName, bool doSerialize);

  */
  

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasAccessKey(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasAssignedSlot(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasAttributeStyleMap(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasAttributes(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasAutoCapitalize(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasBaseURI(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasChildElementCount(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasClassName(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasClientHeight(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasClientLeft(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasClientTop(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasClientWidth(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasDir(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasHeight(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasHeightNative(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasId(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasIsConnected(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasOffsetHeight(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasOffsetLeft(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasOffsetTop(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasOffsetWidth(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasScrollHeight(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasScrollLeft(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasScrollTop(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasScrollWidth(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasWidth(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasWidthNative(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasTitle(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);
    
    [DllImport("__Internal")]
    private static extern string getWebGLCanvasParentAttr(bool debug, bool returnBuffer, string gameInstanceName, string attrName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasParentId(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasParentName(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasParentClass(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasParentStyle(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

    [DllImport("__Internal")]
    private static extern string getWebGLCanvasParentTitle(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);

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
        getGameInstance(false, gameInstanceName, true);//This will not return an object that is useful to C#, only to js.
        getGameInstanceModule(false, gameInstanceName, true);
        getGameInstanceModuleAsmLibArg(false, gameInstanceName, true);
        getGLctx(false, gameInstanceName, true);
        getOptObj(false, gameInstanceName, "drawingBufferHeight", false, true);
        stringToBuffer("Str Cannot Be empty!", true);//TODO check if this ca be emtpy
        serializeOpt(false, true, gameInstanceName, "drawingBufferHeight", false, false, true);
        
        /* The following are the primary objects that are exposed through this library */
        consoleLogThis();
        consoleLogGameInstance(gameInstanceName, true);
        consoleLogGameInstanceModule(gameInstanceName, true);
        consoleLogGameInstanceModuleAsmLibArg(gameInstanceName, true);
        consoleLogGLctx(gameInstanceName, true);

        /* GLctx Options
           Honestly, the most relevant options for this object are drawingBufferHeight, drawingBufferWidth, and canvas. Most likely you'll only ever
           use Canvas options. But, this was here for completeness and in case other useful info is added to the WebGL context in the future.
        */
        serializeGLctxOpt(false, true, gameInstanceName, "drawingBufferHeight", false, true);//Your only need to call this if you need to call one of the two functions below
        Debug.Log("C# GLctx DrawingBufferHeight:" + getWebGLGLctxDrawingBufferHeight(false, true, gameInstanceName, false, true));//TODO not working
        Debug.Log("C# GLctx DrawingBufferWidth:" + getWebGLGLctxDrawingBufferWidth(false, true, gameInstanceName, false, true));//TODO not working

        /* GameInstance Options */
        serializeGameInstanceOpt(false, true, gameInstanceName, "url", false, true);//The url option is here to prevent attempting to serialize the whole massive gameInstance object
        Debug.Log("C# GameInstanceUrl:" + getGameInstanceUrl(false, true, gameInstanceName, false, true));//TODO not working
        
        /*Canvas Options */
        serializeCanvasOpt(false, true, gameInstanceName, "baseURI", false, true);
        getCanvas(false, gameInstanceName, true);
        consoleLogCanvas(gameInstanceName, true);
        getWebGLCanvasParentElement(false, gameInstanceName, true);
        consoleLogWebGLCanvasParentElement(gameInstanceName, true);
        getWebGLCanvasParentNode(false, gameInstanceName, true);
        consoleLogWebGLCanvasParentNode(gameInstanceName, true);
        Debug.Log("C# Canvas AccessKey:" + getWebGLCanvasAccessKey(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas AssignedSlot:" + getWebGLCanvasAssignedSlot(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas AttributesStyleMap:" + getWebGLCanvasAttributeStyleMap(false, true, gameInstanceName, true, true));
        Debug.Log("C# Canvas Attributes:" + getWebGLCanvasAttributes(false, true, gameInstanceName, true, true));
        Debug.Log("C# Canvas AutoCapitalize:" + getWebGLCanvasAutoCapitalize(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas BaseUri:" + getWebGLCanvasBaseURI(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ChildElementCount:" + getWebGLCanvasChildElementCount(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ClassName:" + getWebGLCanvasClassName(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ClientHeight:" + getWebGLCanvasClientHeight(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ClientLeft:" + getWebGLCanvasClientLeft(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ClientTop:" + getWebGLCanvasClientTop(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ClientWidth:" + getWebGLCanvasClientWidth(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas Dir:" + getWebGLCanvasDir(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas Height:" + getWebGLCanvasHeight(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas HeightNative:" + getWebGLCanvasHeightNative(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ID:" + getWebGLCanvasId(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas IsConnected:" + getWebGLCanvasIsConnected(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas OffsetHeight:" + getWebGLCanvasOffsetHeight(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas OffsetLeft:" + getWebGLCanvasOffsetLeft(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas OffsetTop:" + getWebGLCanvasOffsetTop(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas OffsetWidth:" + getWebGLCanvasOffsetWidth(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ScrollHeight:" + getWebGLCanvasScrollHeight(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ScrollLeft:" + getWebGLCanvasScrollLeft(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ScrollTop:" + getWebGLCanvasScrollTop(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ScrollWidth:" + getWebGLCanvasScrollWidth(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas Width:" + getWebGLCanvasWidth(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas WidthNative:" + getWebGLCanvasWidthNative(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas Title:" + getWebGLCanvasTitle(false, true, gameInstanceName, false, true));
     
        /* Canvas Parent Attributes */ 
        Debug.Log("C# Canvas ParentAttr-Style...test:" + getWebGLCanvasParentAttr(false, true, gameInstanceName, "id", false, true));
        Debug.Log("C# Canvas ParentID:" + getWebGLCanvasParentId(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ParentName:" + getWebGLCanvasParentName(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ParentClass:" + getWebGLCanvasParentClass(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ParentStyle:" + getWebGLCanvasParentStyle(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ParentTitle:" + getWebGLCanvasParentTitle(false, true, gameInstanceName, false, true));
    }
}