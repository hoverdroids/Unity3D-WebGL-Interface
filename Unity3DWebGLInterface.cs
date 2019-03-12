using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
  
public class WebGLCanvasInterface : MonoBehaviour{

#if UNITY_WEBGL
  
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

    [DllImport("__Internal")]
    private static extern string getPageUrl(bool debug, bool returnBuffer, string gameInstanceName, bool doSerialize, bool onlyReturnData);
    
    [DllImport("__Internal")]
    private static extern bool isMobile(bool debug);

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
        initializeJSLIB();  
        allMethods();
    }

    // Update is called once per frame
    void Update(){
        if(printMethodsOnUpdate){
            allMethods();
        }
    }

    public void togglePrintMethodsOnUpdate(){
        printMethodsOnUpdate = !printMethodsOnUpdate;
    }
    private void initializeJSLIB(){
        /* When jslib methods are called from c# or other jslib methods, the methdos must be imported in c# if low-stripping is enabled and then executed if
           high-stripping is enabled. If not, Unity will strip them and any dependent functions in the jslib will throw "function not found" exceptions.
           As long as this methods is called in Start, you won't have to worry about required functions gettings stripped as they are listed and handled below.

           Also, while you can call these functions on any gameInstance object, you should initialize the following functions for all gameInstance objects so that
           they are always accessible regardless of what is calling them
        */
        getGameInstance(false, "", true);//Returned JS OBJECT returns empty string to C#
        getGameInstanceModule(false, "", true);//Returned JS OBJECT returns empty string to C#
        getGameInstanceModuleAsmLibArg(false, "", true);//Returned JS OBJECT returns empty string to C#
        getGLctx(false, "", true);//Returned JS OBJECT returns empty string to C#
        getOptObj(false, "", "", false, true);//Returned JS OBJECT returns empty string to C#
        getCanvas(false, "", true);//Returned JS OBJECT returns empty string to C#
        getWebGLCanvasParentElement(false, "", true);//Returned JS OBJECT returns empty string to C#
        getWebGLCanvasParentNode(false, "", true);//Returned JS OBJECT returns empty string to C#
        stringToBuffer("", true);
        serializeOpt(false, true, "", "drawingBufferHeight", false, false, true);//Use drawingBufferHeight to initialize the function to avoid a big delay due to attempting to serialize a large object - the canvas object
        serializeCanvasOpt(false, true, "", "baseURI", false, true);//Use baseURI to initialize the function to avoid a big delay due to attempting to serialize a large object - the canvas object
    }

    private void allMethods(){
        /*  The name of the JS variable used when instantiating the gameInstance. All of the functions work with any number of WebGL instances on the page, so
            long as you use unique variable names for each gameInstance (e.g. gameInstance1 and gameInstance2). If only one instance is used on the page, use the
            "" empty string for gameInstanceName and the functions will assume gameInstanceName = "gameInstance" like in all Unity examples.
            
            EX: Pass "gameInstance" for the standard unity webgl template
                var gameInstance = UnityLoader.instantiate(...)
        */
        string gameInstanceName = "gameInstance"; 

        consoleLogImportantJSObjects(gameInstanceName);  
        gameInstanceMethods(gameInstanceName);
        glctxMethods(gameInstanceName);
        canvasMethods(gameInstanceName);
        canvasContainerMethods(gameInstanceName);
        otherUsefulMethods(gameInstanceName);
    }

    private void consoleLogImportantJSObjects(string gameInstanceName){
        /*  The following show useful objects in the browser console for debugging:
            -gameInstance                       : The entire gameInstance object for the object with the corresponding JS var name
            -gameInstance.Module                : The gameInstance Module, which contains useful info like the asmLibraryArg, SendMessage function, TOTAL_MEMORY, and a lot more         
            -gameInstance.Module.asmLibraryArg  : Contains the functions from all .JSLIBs and a lot more
            -GLctx                              : The WebGL context object. It contains everything needed to interact with the WebGL, its canvas, and the canvas's container
            These are not required, just useful during development.
        */
        consoleLogThis();//This ends up being the entire window object
        consoleLogGameInstance(gameInstanceName, true);
        consoleLogGameInstanceModule(gameInstanceName, true);
        consoleLogGameInstanceModuleAsmLibArg(gameInstanceName, true);
        consoleLogGLctx(gameInstanceName, true);
    }

    private void gameInstanceMethods(string gameInstanceName){
        /* Methods for accessing top-level gameInstace objects and functions. The gameInstance object has more references but honestly, the most relevant option
           in this object is gameInstanceUrl. Most likely you'll only ever use Canvas options - in that case, look into
           the canvas functions. This is here for completeness just in case other useful info is added in the future.
        */
        serializeGameInstanceOpt(false, true, gameInstanceName, "url", false, true);//You only need to call this if call one of the two functions below or create a functions that depends on it. The url option is here to prevent attempting to serialize the whole massive gameInstance object
        Debug.Log("C# GameInstanceUrl:" + getGameInstanceUrl(false, true, gameInstanceName, false, true));
    }

    private void glctxMethods(string gameInstanceName){
        /* Methods for accessing top-level GLctx objects and functions. The GLctx object has more references but honestly, the most relevant options
           in this object are drawingBufferHeight, drawingBufferWidth, and canvas. Most likely you'll only ever use Canvas options - in that case, look into
           the canvas functions. This is here for completeness just in case other useful info is added in the future.
        */
        serializeGLctxOpt(false, true, gameInstanceName, "drawingBufferHeight", false, true);//You only need to call this if call one of the two functions below or create a functions that depends on it
        Debug.Log("C# GLctx DrawingBufferHeight:" + getWebGLGLctxDrawingBufferHeight(false, true, gameInstanceName, false, true));
        Debug.Log("C# GLctx DrawingBufferWidth:" + getWebGLGLctxDrawingBufferWidth(false, true, gameInstanceName, false, true));
    }

    private void canvasMethods(string gameInstanceName){
        /* Useful methods for accessing canvas information */
        consoleLogCanvas(gameInstanceName, true);
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
    }

    private void canvasContainerMethods(string gameInstanceName){
        /* Useful methods for accessing canvas container information */     
        consoleLogWebGLCanvasParentElement(gameInstanceName, true);
        consoleLogWebGLCanvasParentNode(gameInstanceName, true);
        
        /* Canvas Parent Attributes */ 
        Debug.Log("C# Canvas ParentAttr-id:" + getWebGLCanvasParentAttr(false, true, gameInstanceName, "id", false, true));//Use id to initialize the function to avoid a big delay due to attempting to serialize a large object - the canvas parent object
        Debug.Log("C# Canvas ParentID:" + getWebGLCanvasParentId(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ParentName:" + getWebGLCanvasParentName(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ParentClass:" + getWebGLCanvasParentClass(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ParentStyle:" + getWebGLCanvasParentStyle(false, true, gameInstanceName, false, true));
        Debug.Log("C# Canvas ParentTitle:" + getWebGLCanvasParentTitle(false, true, gameInstanceName, false, true));
    }

    private void otherUsefulMethods(string gameInstanceName){
        Debug.Log("C# PageUrl:" + getPageUrl(true, true, gameInstanceName, false, true));
        Debug.Log("C# IsMobile:" + isMobile(true));
    }
#endif
}