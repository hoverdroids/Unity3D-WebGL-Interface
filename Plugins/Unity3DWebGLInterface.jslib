mergeInto(LibraryManager.library, {
    //TODO look into module->backgroundColor
    //TODO look into the logo under the gameInstance object...we maybe able to customize splash screen - doubt it, as i think it's in the build
    //NOTE: many of the methods that return js objects that are not serializable and return empty strings to c#. They are meant to be called from JS but
    //      must be called from c# so unity doesn't strip them when building the WebGL instance
    consoleLogThis: function(){
        //It's the page object. Just noting what "this" is, in the context of a jslib in UNity JS.
        console.log("This:");
        console.log(this);
    },
    getGameInstance: function(debug, csIsCalling, gameInstanceName, onlyReturnData){///Returned JS OBJECT is useless to C# 
        gameInstanceName = csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName;
        
        //In the majority of cases there will only be one webgl player on the page and it is named gameInstance - the default Unity template 
        //So, get that instance if the name is empty. But, return an empty name so the other functions can essentially call "this" when the name is empty
        var name = gameInstanceName === '' ? "gameInstance" : gameInstanceName; 
        var game = {name: gameInstanceName, instance: window[name]};
        if(debug){
            console.log("gameInstanceName:" + name);
            console.log(onlyReturnData ? game.instance : game);
        }
        return onlyReturnData ? game.instance : game;
    },
    consoleLogGameInstance: function(csIsCalling, gameInstanceName, onlyReturnData){      
        _getGameInstance(true, csIsCalling, gameInstanceName, onlyReturnData);
    },
    getGameInstanceModule: function(debug, csIsCalling, gameInstanceName, onlyReturnData){//Returned JS OBJECT is useless to C# 
        var game = _getGameInstance(false, csIsCalling, gameInstanceName, false);
        game = {name:game.name, instance:game.instance.Module};
        if(debug){
            console.log("gameInstanceName:" + (game.name === '' ? 'THIS' : game.name) + " Module:");
            console.log(onlyReturnData ? game.instance : game);
        }
        return onlyReturnData ? game.instance : game;
    },
    consoleLogGameInstanceModule: function(csIsCalling, gameInstanceName, onlyReturnData){
        _getGameInstanceModule(true, csIsCalling, gameInstanceName, onlyReturnData);
    },
    getGameInstanceModuleAsmLibArg: function(debug, csIsCalling, gameInstanceName, onlyReturnData){//Returned JS OBJECT is useless to C#
        var game = _getGameInstance(false, csIsCalling, gameInstanceName, false);
        game = {name: game.name, instance: game.instance.Module.asmLibraryArg};
        if(debug){
            console.log("gameInstanceName:" + (game.name === '' ? 'THIS' : game.name) + " Module.asmLibraryArg:");
            console.log(onlyReturnData ? game.instance : game);
        }
        return onlyReturnData ? game.instance : game;
    },
    consoleLogGameInstanceModuleAsmLibArg: function(csIsCalling, gameInstanceName, onlyReturnData){
        _getGameInstanceModuleAsmLibArg(true, csIsCalling, gameInstanceName, onlyReturnData);
    },
    getGLctx: function(debug, csIsCalling, gameInstanceName, onlyReturnData){//Returned JS OBJECT is useless to C#
        gameInstanceName = csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName;
        var glctx = {name: gameInstanceName, instance: gameInstanceName === '' ? GLctx : window[gameInstanceName].Module["canvas"]["GLctxObject"]["GLctx"]};
        if(debug){
            console.log("GLctx gameInstanceName:" + (gameInstanceName === '' ? 'THIS' : gameInstanceName));
            console.log(onlyReturnData ? glctx.instance : glctx);
        }
        return onlyReturnData ? glctx.instance : glctx;
    },
    consoleLogGLctx: function(csIsCalling, gameInstanceName, onlyReturnData){
        _getGLctx(true, csIsCalling, gameInstanceName, onlyReturnData);
    },
    getOptObj: function(debug, csIsCalling, gameInstanceName, optName, isCanvasOpt, onlyReturnData){//Returned JS OBJECT is useless to C#
        optName = csIsCalling ? Pointer_stringify(optName) : optName;
        var glctx = _getGLctx(false, csIsCalling, gameInstanceName, false);  
        var a = isCanvasOpt ? glctx.instance["canvas"] : glctx.instance;
        var b = isCanvasOpt ? glctx.instance["canvas"][optName] : glctx.instance[optName];
        var opt = {name: glctx.name, option: optName, instance: optName === '' ? a : b};        
        
        if(debug){
            console.log( (isCanvasOpt ? "Canvas " : "GLctx ") + optName + " typeOf: " + (typeof opt.instance) + " gameInstanceName:" + (opt.name === '' ? 'THIS' : opt.name));
            console.log(onlyReturnData ? opt.instance : opt);//call separately just in case it's an object
        }
        return onlyReturnData ? opt.instance : opt;
    },
    getOptObjMixed: function(debug, csIsCalling, gameInstanceName, optName, isCanvasOpt, onlyReturnData){
        //This allows c# to call one of the canvas methods without writing a conversion line for every method. It's mixed because c# can be used for gameInstance name but optName is going to be a js string that doesn't need the same conversion
        return _getOptObj(debug, false, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), optName, isCanvasOpt, onlyReturnData);
    },
    getCanvas: function(debug, csIsCalling, gameInstanceName, onlyReturnData){//Returned JS OBJECT is useless to C#
        return _getOptObjMixed(debug, csIsCalling, gameInstanceName, "", true, onlyReturnData);
    },
    consoleLogCanvas: function(csIsCalling, gameInstanceName, onlyReturnData){
        _getCanvas(true, csIsCalling, gameInstanceName, onlyReturnData);       
    },
    getWebGLCanvasParentElement: function(debug, csIsCalling, gameInstanceName, onlyReturnData){//Returned JS OBJECT is useless to C#
        return _getOptObjMixed(debug, csIsCalling, gameInstanceName, "parentElement", true, onlyReturnData);//NOTE: the returned object is ready for manipulation with jQuery
    },
    consoleLogWebGLCanvasParentElement: function(csIsCalling, gameInstanceName, onlyReturnData){
        //Show the Canvas's Parent Element in the browser console. The CanvasParentElement object reference cannot be serialized,
        //it just returns empty {}. Use the canvas get methods to retrieve the information from the parent instead of retrieving the entire parent element. 
        _getWebGLCanvasParentElement(true, csIsCalling, gameInstanceName, onlyReturnData);
    },
    getWebGLCanvasParentNode: function(debug, csIsCalling, gameInstanceName, onlyReturnData){//Returned JS OBJECT is useless to C#
        return _getOptObjMixed(debug, csIsCalling, gameInstanceName, "parentNode", true, onlyReturnData);//NOTE: the returned object is ready for manipulation with jQuery
    },
    consoleLogWebGLCanvasParentNode: function(csIsCalling, gameInstanceName, onlyReturnData){
        //Show the Canvas's Parent Node in the browser console. The CanvasParentElement object reference cannot be serialized,
        //it just returns empty {}. Use the canvas get methods to retrieve the information from the parent instead of retrieving the entire parent element. 
        _getWebGLCanvasParentNode(true, csIsCalling, gameInstanceName, onlyReturnData);
    },
    stringToBuffer: function(str, csIsCalling, returnBuffer){
        //We need to know if the call is from c# or JS because Pointer_stringify must be applied for C# calls, 
        //and cannot be applied to JS calls.
        str = csIsCalling ? Pointer_stringify(str) : str;//The c# string must be converted
        str = typeof str !== 'undefined' ? str : "UNDEFINED";//TODO is there a better way?
        if(returnBuffer ){//Sometimes JS calls want the buffer and not the string, so we can't just return buffer if csIsCalling
            var bufferSize = lengthBytesUTF8(str) + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(str, buffer, bufferSize);
            return buffer
        }
        return str;
    },
    serializeOpt: function(debug, csIsCalling, returnBuffer, gameInstanceName, optName, doSerialize, isCanvasOpt, onlyReturnData){
        //If gameInstanceName is '' (ie empty) then this will return this game instance's info. Else, it will return that of the named gameInstance
        //http://thisinterestsme.com/json-stringify-empty-string/
        //https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/JSON/stringify  
        var opt = _getOptObj(false, csIsCalling, gameInstanceName, optName, isCanvasOpt, false);        
        var str = doSerialize ? jQuery( opt.instance ).serialize() : JSON.stringify( opt.instance );//Apply preferred serialization method
        str = opt.name === '' ? _stringToBuffer( str, false, returnBuffer) : window[opt.name].Module.asmLibraryArg._stringToBuffer( str, false, returnBuffer);
        opt = {name: opt.name, option: opt.option, instance: str};  
        if(debug){
            console.log("SerializeOpt " + (isCanvasOpt ? "Canvas " : "GLctx ") + opt.option + " gameInstanceName:" + (opt.name === '' ? 'THIS' : opt.name));
            console.log(onlyReturnData ? opt.instance : opt);//call separately just in case it's an object
        }
        return onlyReturnData ? opt.instance : opt;
    },
    serializeCanvasOpt: function(debug, csIsCalling, returnBuffer, gameInstanceName, optName, doSerialize, onlyReturnData){
        return _serializeOpt(debug, csIsCalling, returnBuffer, gameInstanceName, optName, doSerialize, true, onlyReturnData);
    },
    serializeCanvasOptMixed: function(debug, csIsCalling, returnBuffer, gameInstanceName, optName, doSerialize, onlyReturnData){
        //This allows c# to call one of the canvas methods without writing a conversion line for every method. It's mixed because c# can be used for gameInstance name but optName is going to be a js string that doesn't need the same conversion
        return _serializeOpt(debug, false, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), optName, doSerialize, true, onlyReturnData);
    },
    serializeGameInstanceOpt: function(debug, csIsCalling, returnBuffer, gameInstanceName, optName, doSerialize, onlyReturnData){
        optName = csIsCalling ? Pointer_stringify(optName) : optName;

        var game =_getGameInstance(false, csIsCalling, gameInstanceName, false);   
        var opt = optName === '' ? game.instance : game.instance[optName];//It is really not advisable to serialize the entire game instance object as it adds a huge delay  
        
        var str = doSerialize ? jQuery( opt ).serialize() : JSON.stringify( opt );//Apply preferred serialization method
        str = game.name === '' ? _stringToBuffer( str, false, returnBuffer) : window[game.name].Module.asmLibraryArg._stringToBuffer( str, false, returnBuffer);
        opt = {name: game.name, option: optName, instance: str};  
        if(debug){
            console.log("SerializeGameOpt " + opt.option + " gameInstanceName:" + (opt.name === '' ? 'THIS' : opt.name));
            console.log(onlyReturnData ? opt.instance : opt);//call separately just in case it's an object
        }
        return onlyReturnData ? opt.instance : opt;
    },

    serializeGLctxOpt: function(debug, csIsCalling, returnBuffer, gameInstanceName, optName, doSerialize, onlyReturnData){
        return _serializeOpt(debug, csIsCalling, returnBuffer, gameInstanceName, optName, doSerialize, false, onlyReturnData);
    },
    webGLGLctxBindVertexArray: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLGLctxCreateVertexArray: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLGLctxDeleteVertexArray: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLGLctxDisjointTimerQueryExt: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLGLctxDrawArraysInstanced: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLGLctxDrawElementsInstanced: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    getWebGLGLctxDrawingBufferHeight: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeGLctxOpt(debug, false, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), "drawingBufferHeight", doSerialize, onlyReturnData);
    },
    getWebGLGLctxDrawingBufferWidth: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeGLctxOpt(debug, false, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), "drawingBufferWidth", doSerialize, onlyReturnData);
    },
    webGLGLctxIsVertexArray: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLGLctxVertexAttribDivisor: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    getGameInstanceUrl: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeGameInstanceOpt(debug, false, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), "url", doSerialize, onlyReturnData);
    },
    getWebGLCanvasAccessKey: function (debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData) {
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "accessKey", doSerialize, onlyReturnData);  
    },
    getWebGLCanvasAssignedSlot: function (debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData) {
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "assignedSlot", doSerialize, onlyReturnData);  
    },
    getWebGLCanvasAttributeStyleMap: function (debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData) {
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "attributeStyleMap", doSerialize, onlyReturnData);  
    },
    getWebGLCanvasAttributes: function (debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData) {
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "attributes", doSerialize, onlyReturnData);  
    },
    getWebGLCanvasAutoCapitalize: function (debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData) {
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "autocapitalize", doSerialize, onlyReturnData);  
    },
    getWebGLCanvasBaseURI: function (debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData) {
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "baseURI", doSerialize, onlyReturnData);  
    },
    getWebGLCanvasChildElementCount: function (debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData) {
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "childElementCount", doSerialize, onlyReturnData);  
    },
    getWebGLCanvasClassName: function (debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData) {
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "className", doSerialize, onlyReturnData);  
    },
    getWebGLCanvasClientHeight: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "clientHeight", doSerialize, onlyReturnData); 
    },
    getWebGLCanvasClientLeft: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "clientLeft", doSerialize, onlyReturnData); 
    },
    getWebGLCanvasClientTop: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "clientTop", doSerialize, onlyReturnData); 
    },
    getWebGLCanvasClientWidth: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "clientWidth", doSerialize, onlyReturnData);
    },
    getWebGLCanvasDir: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "dir", doSerialize, onlyReturnData);
    },
    getWebGLCanvasHeight: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "height", doSerialize, onlyReturnData);
    },
    getWebGLCanvasHeightNative: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "heightNative", doSerialize, onlyReturnData);
    },
    getWebGLCanvasId: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "id", doSerialize, onlyReturnData);
    },
    getWebGLCanvasIsConnected: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "isConnected", doSerialize, onlyReturnData);
    },
    getWebGLCanvasOffsetHeight: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "offsetHeight", doSerialize, onlyReturnData);
    },
    getWebGLCanvasOffsetLeft: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "offsetLeft", doSerialize, onlyReturnData);
    },
    getWebGLCanvasOffsetTop: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "offsetTop", doSerialize, onlyReturnData);
    },
    getWebGLCanvasOffsetWidth: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "offsetWidth", doSerialize, onlyReturnData);
    },
    getWebGLCanvasScrollHeight: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "scrollHeight", doSerialize, onlyReturnData);
    },
    getWebGLCanvasScrollLeft: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "scrollLeft", doSerialize, onlyReturnData);
    },
    getWebGLCanvasScrollTop: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "scrollTop", doSerialize, onlyReturnData);
    },
    getWebGLCanvasScrollWidth: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "scrollWidth", doSerialize, onlyReturnData);
    },
    getWebGLCanvasWidth: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "width", doSerialize, onlyReturnData);
    },
    getWebGLCanvasWidthNative: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "widthNative", doSerialize, onlyReturnData);
    },
    getWebGLCanvasTitle: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOptMixed(debug, csIsCalling, returnBuffer, gameInstanceName, "title", doSerialize, onlyReturnData);
    }
  });