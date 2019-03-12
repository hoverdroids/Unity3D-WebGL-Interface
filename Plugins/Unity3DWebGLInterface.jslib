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
    getGameInstance: function(debug, gameInstanceName, onlyReturnData){///Returned JS OBJECT is useless to C# 
        gameInstanceName = typeof gameInstanceName == 'number' ? Pointer_stringify(gameInstanceName) : gameInstanceName;
        
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
    consoleLogGameInstance: function(gameInstanceName, onlyReturnData){      
        _getGameInstance(true, gameInstanceName, onlyReturnData);
    },
    getGameInstanceModule: function(debug, gameInstanceName, onlyReturnData){//Returned JS OBJECT is useless to C# 
        var game = _getGameInstance(false, gameInstanceName, false);
        game = {name:game.name, instance:game.instance.Module};
        if(debug){
            console.log("gameInstanceName:" + (game.name === '' ? 'THIS' : game.name) + " Module:");
            console.log(onlyReturnData ? game.instance : game);
        }
        return onlyReturnData ? game.instance : game;
    },
    consoleLogGameInstanceModule: function(gameInstanceName, onlyReturnData){
        _getGameInstanceModule(true, gameInstanceName, onlyReturnData);
    },
    getGameInstanceModuleAsmLibArg: function(debug, gameInstanceName, onlyReturnData){//Returned JS OBJECT is useless to C#
        var game = _getGameInstance(false, gameInstanceName, false);
        game = {name: game.name, instance: game.instance.Module.asmLibraryArg};
        if(debug){
            console.log("gameInstanceName:" + (game.name === '' ? 'THIS' : game.name) + " Module.asmLibraryArg:");
            console.log(onlyReturnData ? game.instance : game);
        }
        return onlyReturnData ? game.instance : game;
    },
    consoleLogGameInstanceModuleAsmLibArg: function(gameInstanceName, onlyReturnData){
        _getGameInstanceModuleAsmLibArg(true, gameInstanceName, onlyReturnData);
    },
    getGLctx: function(debug, gameInstanceName, onlyReturnData){//Returned JS OBJECT is useless to C#  
        gameInstanceName = typeof gameInstanceName == 'number' ? Pointer_stringify(gameInstanceName) : gameInstanceName;
        var glctx = {name: gameInstanceName, instance: gameInstanceName === '' ? GLctx : window[gameInstanceName].Module["canvas"]["GLctxObject"]["GLctx"]};
        if(debug){
            console.log("GLctx gameInstanceName:" + (gameInstanceName === '' ? 'THIS' : gameInstanceName));
            console.log(onlyReturnData ? glctx.instance : glctx);
        }
        return onlyReturnData ? glctx.instance : glctx;
    },
    consoleLogGLctx: function(gameInstanceName, onlyReturnData){
        _getGLctx(true, gameInstanceName, onlyReturnData);
    },
    getOptObj: function(debug, gameInstanceName, optName, isCanvasOpt, onlyReturnData){//Returned JS OBJECT is useless to C#
        optName = typeof optName == 'number' ? Pointer_stringify(optName) : optName;
        var glctx = _getGLctx(false, gameInstanceName, false);  
        var a = isCanvasOpt ? glctx.instance["canvas"] : glctx.instance;
        var b = isCanvasOpt ? glctx.instance["canvas"][optName] : glctx.instance[optName];
        var opt = {name: glctx.name, option: optName, instance: optName === '' ? a : b};        
        
        if(debug){
            console.log( (isCanvasOpt ? "Canvas " : "GLctx ") + optName + " typeOf: " + (typeof opt.instance) + " gameInstanceName:" + (opt.name === '' ? 'THIS' : opt.name));
            console.log(onlyReturnData ? opt.instance : opt);//call separately just in case it's an object
        }
        return onlyReturnData ? opt.instance : opt;
    },
    getCanvas: function(debug, gameInstanceName, onlyReturnData){//Returned JS OBJECT is useless to C#
        return _getOptObj(debug, gameInstanceName, "", true, onlyReturnData);
    },
    consoleLogCanvas: function(gameInstanceName, onlyReturnData){
        _getCanvas(true, gameInstanceName, onlyReturnData);       
    },
    getWebGLCanvasParentElement: function(debug, gameInstanceName, onlyReturnData){//Returned JS OBJECT is useless to C#
        return _getOptObj(debug, gameInstanceName, "parentElement", true, onlyReturnData);//NOTE: the returned object is ready for manipulation with jQuery
    },
    consoleLogWebGLCanvasParentElement: function(gameInstanceName, onlyReturnData){
        //Show the Canvas's Parent Element in the browser console. The CanvasParentElement object reference cannot be serialized,
        //it just returns empty {}. Use the canvas get methods to retrieve the information from the parent instead of retrieving the entire parent element. 
        _getWebGLCanvasParentElement(true, gameInstanceName, onlyReturnData);
    },
    getWebGLCanvasParentNode: function(debug, gameInstanceName, onlyReturnData){//Returned JS OBJECT is useless to C#
        return _getOptObj(debug, gameInstanceName, "parentNode", true, onlyReturnData);//NOTE: the returned object is ready for manipulation with jQuery
    },
    consoleLogWebGLCanvasParentNode: function(gameInstanceName, onlyReturnData){
        //Show the Canvas's Parent Node in the browser console. The CanvasParentElement object reference cannot be serialized,
        //it just returns empty {}. Use the canvas get methods to retrieve the information from the parent instead of retrieving the entire parent element. 
        _getWebGLCanvasParentNode(true, gameInstanceName, onlyReturnData);
    },
    stringToBuffer: function(str, returnBuffer){
        //We need to know if the call is from c# or JS because Pointer_stringify must be applied for C# calls, 
        //and cannot be applied to JS calls.
        str = typeof str == 'number' ? Pointer_stringify(str) : str;//The c# string must be converted
        str = typeof str !== 'undefined' ? str : "UNDEFINED";//Sometimes the attr doesn't exist and passes the value of undefined. An error is thrown without this
        if(returnBuffer){//Sometimes JS calls want the buffer and not the string, so we can't just return buffer if the call is from c#
            var bufferSize = lengthBytesUTF8(str) + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(str, buffer, bufferSize);
            return buffer
        }
        return str;
    },
    serializeOpt: function(debug, returnBuffer, gameInstanceName, optName, doSerialize, isCanvasOpt, onlyReturnData){
        //If gameInstanceName is '' (ie empty) then this will return this game instance's info. Else, it will return that of the named gameInstance
        //http://thisinterestsme.com/json-stringify-empty-string/
        //https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/JSON/stringify  
        var opt = _getOptObj(false, gameInstanceName, optName, isCanvasOpt, false);        
        var str = doSerialize ? jQuery( opt.instance ).serialize() : JSON.stringify( opt.instance );//Apply preferred serialization method
        str = opt.name === '' ? _stringToBuffer(str, returnBuffer) : window[opt.name].Module.asmLibraryArg._stringToBuffer(str, returnBuffer);
        opt = {name: opt.name, option: opt.option, instance: str};  
        if(debug){
            console.log("SerializeOpt " + (isCanvasOpt ? "Canvas " : "GLctx ") + opt.option + " gameInstanceName:" + (opt.name === '' ? 'THIS' : opt.name));
            console.log(onlyReturnData ? opt.instance : opt);//call separately just in case it's an object
        }
        return onlyReturnData ? opt.instance : opt;
    },
    serializeCanvasOpt: function(debug, returnBuffer, gameInstanceName, optName, doSerialize, onlyReturnData){
        return _serializeOpt(debug, returnBuffer, gameInstanceName, optName, doSerialize, true, onlyReturnData);
    },
    serializeGameInstanceOpt: function(debug, returnBuffer, gameInstanceName, optName, doSerialize, onlyReturnData){
        optName = typeof optName == 'number' ? Pointer_stringify(optName) : optName;

        var game =_getGameInstance(false, gameInstanceName, false);   
        var opt = optName === '' ? game.instance : game.instance[optName];//It is really not advisable to serialize the entire game instance object as it adds a huge delay  
        
        var str = doSerialize ? jQuery( opt ).serialize() : JSON.stringify( opt );//Apply preferred serialization method
        str = game.name === '' ? _stringToBuffer(str, returnBuffer) : window[game.name].Module.asmLibraryArg._stringToBuffer(str, returnBuffer);
        opt = {name: game.name, option: optName, instance: str};  
        if(debug){
            console.log("SerializeGameOpt " + opt.option + " gameInstanceName:" + (opt.name === '' ? 'THIS' : opt.name));
            console.log(onlyReturnData ? opt.instance : opt);//call separately just in case it's an object
        }
        return onlyReturnData ? opt.instance : opt;
    },
    serializeGLctxOpt: function(debug, returnBuffer, gameInstanceName, optName, doSerialize, onlyReturnData){
        return _serializeOpt(debug, returnBuffer, gameInstanceName, optName, doSerialize, false, onlyReturnData);
    },
    webGLGLctxBindVertexArray: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLGLctxCreateVertexArray: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLGLctxDeleteVertexArray: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLGLctxDisjointTimerQueryExt: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLGLctxDrawArraysInstanced: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLGLctxDrawElementsInstanced: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    getWebGLGLctxDrawingBufferHeight: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeGLctxOpt(debug, returnBuffer, gameInstanceName, "drawingBufferHeight", doSerialize, onlyReturnData);
    },
    getWebGLGLctxDrawingBufferWidth: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeGLctxOpt(debug, returnBuffer, gameInstanceName, "drawingBufferWidth", doSerialize, onlyReturnData);
    },
    webGLGLctxIsVertexArray: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLGLctxVertexAttribDivisor: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    getGameInstanceUrl: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeGameInstanceOpt(debug, returnBuffer, gameInstanceName, "url", doSerialize, onlyReturnData);
    },
    getWebGLCanvasAccessKey: function (debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData) {
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "accessKey", doSerialize, onlyReturnData);  
    },
    getWebGLCanvasAssignedSlot: function (debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData) {
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "assignedSlot", doSerialize, onlyReturnData);  
    },
    getWebGLCanvasAttributeStyleMap: function (debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData) {
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "attributeStyleMap", doSerialize, onlyReturnData);  
    },
    getWebGLCanvasAttributes: function (debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData) {
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "attributes", doSerialize, onlyReturnData);  
    },
    getWebGLCanvasAutoCapitalize: function (debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData) {
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "autocapitalize", doSerialize, onlyReturnData);  
    },
    getWebGLCanvasBaseURI: function (debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData) {
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "baseURI", doSerialize, onlyReturnData);  
    },
    getWebGLCanvasChildElementCount: function (debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData) {
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "childElementCount", doSerialize, onlyReturnData);  
    },
    getWebGLCanvasClassName: function (debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData) {
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "className", doSerialize, onlyReturnData);  
    },
    getWebGLCanvasClientHeight: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "clientHeight", doSerialize, onlyReturnData); 
    },
    getWebGLCanvasClientLeft: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "clientLeft", doSerialize, onlyReturnData); 
    },
    getWebGLCanvasClientTop: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "clientTop", doSerialize, onlyReturnData); 
    },
    getWebGLCanvasClientWidth: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "clientWidth", doSerialize, onlyReturnData);
    },
    getWebGLCanvasDir: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "dir", doSerialize, onlyReturnData);
    },
    getWebGLCanvasHeight: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "height", doSerialize, onlyReturnData);
    },
    getWebGLCanvasHeightNative: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "heightNative", doSerialize, onlyReturnData);
    },
    getWebGLCanvasId: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "id", doSerialize, onlyReturnData);
    },
    getWebGLCanvasIsConnected: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "isConnected", doSerialize, onlyReturnData);
    },
    getWebGLCanvasOffsetHeight: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "offsetHeight", doSerialize, onlyReturnData);
    },
    getWebGLCanvasOffsetLeft: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "offsetLeft", doSerialize, onlyReturnData);
    },
    getWebGLCanvasOffsetTop: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "offsetTop", doSerialize, onlyReturnData);
    },
    getWebGLCanvasOffsetWidth: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "offsetWidth", doSerialize, onlyReturnData);
    },
    getWebGLCanvasScrollHeight: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "scrollHeight", doSerialize, onlyReturnData);
    },
    getWebGLCanvasScrollLeft: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "scrollLeft", doSerialize, onlyReturnData);
    },
    getWebGLCanvasScrollTop: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "scrollTop", doSerialize, onlyReturnData);
    },
    getWebGLCanvasScrollWidth: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "scrollWidth", doSerialize, onlyReturnData);
    },
    getWebGLCanvasWidth: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "width", doSerialize, onlyReturnData);
    },
    getWebGLCanvasWidthNative: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "widthNative", doSerialize, onlyReturnData);
    },
    getWebGLCanvasTitle: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _serializeCanvasOpt(debug, returnBuffer, gameInstanceName, "title", doSerialize, onlyReturnData);
    },
    getWebGLCanvasParentAttr: function(debug, returnBuffer, gameInstanceName, attrName, doSerialize, onlyReturnData){  
        //Strings cannot be passed directly from C# to here. Instead, the memory pointer (a number) is passed. This pointer must be used to get the string.
        attrName = typeof attrName == 'number' ? Pointer_stringify(attrName) : attrName;

        var parent = _getWebGLCanvasParentElement(false, gameInstanceName, false);      
        var attr = attrName === '' ? parent.instance : jQuery(parent.instance).attr(attrName);        
        var str = doSerialize ? jQuery( attr ).serialize() : JSON.stringify( attr );//Apply preferred serialization method
        str = parent.name === '' ? _stringToBuffer(str, returnBuffer) : window[parent.name].Module.asmLibraryArg._stringToBuffer(str, returnBuffer);
        attr = {name:parent.name, option:attrName, instance:str};
        if(debug){
            console.log("CanvasParentAttr " + attr.option + " gameInstanceName:" + (attr.name === '' ? 'THIS' : attr.name));
            console.log(onlyReturnData ? attr.instance : attr);//call separately just in case it's an object
        }                                                    
        return onlyReturnData ? attr.instance : attr;
    },
    getWebGLCanvasParentId: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _getWebGLCanvasParentAttr(debug, returnBuffer, gameInstanceName, "id", doSerialize, onlyReturnData);
    },
    getWebGLCanvasParentName: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _getWebGLCanvasParentAttr(debug, returnBuffer, gameInstanceName, "name", doSerialize, onlyReturnData);
    },
    getWebGLCanvasParentClass: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _getWebGLCanvasParentAttr(debug, returnBuffer, gameInstanceName, "class", doSerialize, onlyReturnData);
    },
    getWebGLCanvasParentStyle: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _getWebGLCanvasParentAttr(debug, returnBuffer, gameInstanceName, "style", doSerialize, onlyReturnData);
    },
    getWebGLCanvasParentTitle: function(debug, returnBuffer, gameInstanceName, doSerialize, onlyReturnData){
        return _getWebGLCanvasParentAttr(debug, returnBuffer, gameInstanceName, "title", doSerialize, onlyReturnData);
    },
  });