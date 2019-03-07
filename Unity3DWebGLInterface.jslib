mergeInto(LibraryManager.library, {
    //TODO look into module->backgroundColor
    //TODO look into the logo under the gameInstance object...we maybe able to customize splash screen - doubt it, as i think it's in the build
    consoleLogThis: function(){
        //It's the page object. Just noting what "this" is, in the context of a jslib in UNity JS.
        console.log("This:");
        console.log(this);
    },
    getGameInstance: function(debug, gameInstanceName){//ONLY CALL FROM JS
        gameInstanceName === '' ? "gameInstance" : gameInstanceName; //In the majority of cases there will only be one webgl player on the page and it is named gameInstance - the default Unity template 
        if(debug){
            console.log("gameInstanceName:" + (gameInstanceName === '' ? 'THIS' : gameInstanceName));
            console.log(window[gameInstanceName]);
        }
        return window[gameInstanceName];
    },
    consoleLogGameInstance: function(csIsCalling, gameInstanceName){      
        _getGameInstance(true, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName));
    },
    getGameInstanceModule: function(debug, gameInstanceName){//ONLY CALL FROM JS
        var gameInst = _getGameInstance(false, gameInstanceName);
        if(debug){
            console.log("gameInstanceName:" + (gameInstanceName === '' ? 'THIS' : gameInstanceName) + " Module:");
            console.log(gameInst.Module);
        }
        return gameInst.Module;
    },
    consoleLogGameInstanceModule: function(csIsCalling, gameInstanceName){
        _getGameInstanceModule(true, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName));
    },
    getGameInstanceModuleAsmLibArg: function(debug, gameInstanceName){//ONLY CALL FROM JS
        var gameInst = _getGameInstance(false, gameInstanceName);
        if(debug){
            console.log("gameInstanceName:" + (gameInstanceName === '' ? 'THIS' : gameInstanceName) + " Module.asmLibraryArg:");
            console.log(gameInst.Module.asmLibraryArg);
        }
        return gameInst.Module.asmLibraryArg;
    },
    consoleLogGameInstanceModuleAsmLibArg: function(csIsCalling, gameInstanceName){
        _getGameInstanceModuleAsmLibArg(true, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName));
    },
    getGLctx: function(debug, gameInstanceName){//ONLY CALL FROM JS
        var glctx = gameInstanceName === '' ? GLctx : window[gameInstanceName].Module["canvas"]["GLctxObject"]["GLctx"];
        if(debug){
            console.log("GLctx gameInstanceName:" + (gameInstanceName === '' ? 'THIS' : gameInstanceName));
            console.log(glctx);
        }
        return glctx;
    },
    consoleLogGLctx: function(csIsCalling, gameInstanceName){
        _getGLctx(true, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName));
    },
    getCanvas: function(debug, gameInstanceName){//ONLY CALL FROM JS
        return _getOptObj(debug, gameInstanceName, "", true);
    },
    consoleLogCanvas: function(csIsCalling, gameInstanceName){
        _getCanvas(true, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName));       
    },
    stringToBuffer: function(str, csIsCalling, returnBuffer){
        //We need to know if the call is from c# or JS because Pointer_stringify must be applied for C# calls, 
        //and cannot be applied to JS calls.
        str = csIsCalling ? Pointer_stringify(str) : str;//The c# string must be converted
        if(returnBuffer){//Sometimes JS calls want the buffer and not the string, so we can't just return buffer if csIsCalling
            var bufferSize = lengthBytesUTF8(str) + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(str, buffer, bufferSize);
            return buffer
        }
        return str;
    },
    serializeGameInstanceOpt: function(debug, csIsCalling, returnBuffer, gameInstanceName, optName, doSerialize){
        if(csIsCalling){
            gameInstanceName = Pointer_stringify(gameInstanceName);
            optName = Pointer_stringify(optName);
        }
        var gameInst = _getGameInstance(false, gameInstanceName);
        var opt = optName === '' ? gameInst : gameInst[optName];        
                
        var str = doSerialize ? jQuery( opt ).serialize() : JSON.stringify( opt );//Allows dev's prefered serialization method to apply 
        
        if(debug){
            console.log( "GameInstance option:" + optName + " typeOf: " + (typeof opt) + " gameInstanceName:" + (gameInstanceName === '' ? 'THIS' : gameInstanceName));
            console.log(opt);//call separately just in case it's an object
        }

        return gameInstanceName === '' ? _stringToBuffer( str, false, returnBuffer) : window[gameInstanceName].Module.asmLibraryArg._stringToBuffer( str, false, returnBuffer);
    },
    serializeCanvasOpt: function(debug, csIsCalling, returnBuffer, gameInstanceName, optName, doSerialize){
        return _serializeOpt(debug, false, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), (csIsCalling ? Pointer_stringify(optName) : optName), doSerialize, true);
    },
    serializeGLctxOpt: function(debug, csIsCalling, returnBuffer, gameInstanceName, optName, doSerialize){
        return _serializeOpt(debug, false, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), (csIsCalling ? Pointer_stringify(optName) : optName), doSerialize, false);
    },
    serializeOpt: function(debug, csIsCalling, returnBuffer, gameInstanceName, optName, doSerialize, isCanvasOpt){
        //If gameInstanceName is '' (ie empty) then this will return this game instance's info. Else, it will return that of the named gameInstance
        //http://thisinterestsme.com/json-stringify-empty-string/
        //https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/JSON/stringify
        if(csIsCalling){
            gameInstanceName = Pointer_stringify(gameInstanceName);
            optName = Pointer_stringify(optName);
        }
           
        var opt = _getOptObj(debug, gameInstanceName, optName, isCanvasOpt);        
        var str = doSerialize ? jQuery( opt ).serialize() : JSON.stringify( opt );//Allows dev's prefered serialization method to apply
         
        return gameInstanceName === '' ? _stringToBuffer( str, false, returnBuffer) : window[gameInstanceName].Module.asmLibraryArg._stringToBuffer( str, false, returnBuffer);
    },
    getOptObj: function(debug, gameInstanceName, optName, isCanvasOpt){//ONLY CALL FROM JS
        var glctx = _getGLctx(false, gameInstanceName);       
        var opt = optName === '' ? (isCanvasOpt ? glctx["canvas"] : glctx) : (isCanvasOpt ? glctx["canvas"][optName] : glctx[optName]);        
               
        if(debug){
            console.log( (isCanvasOpt ? "Canvas " : "GLctx ") + optName + " typeOf: " + (typeof opt) + " gameInstanceName:" + (gameInstanceName === '' ? 'THIS' : gameInstanceName));
            console.log(opt);//call separately just in case it's an object
        }
        return opt;
    },
    getGameInstanceUrl: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize){
              //serializeGameInstanceOpt: function(debug, csIsCalling, returnBuffer, gameInstanceName, optName, doSerialize)
        return _serializeGameInstanceOpt(debug, false, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), "url", doSerialize);
    },
    getWebGLCanvasParentElement: function(debug, gameInstanceName){//ONLY CALL FROM JS
        return _getOptObj(debug, gameInstanceName, "parentElement", true);//NOTE: the returned object is ready for manipulation with jQuery
    },
    consoleLogWebGLCanvasParentElement: function(csIsCalling, gameInstanceName){
        //Show the Canvas's Parent Element in the browser console. The CanvasParentElement object reference cannot be serialized,
        //it just returns empty {}. Use the canvas get methods to retrieve the information from the parent instead of retrieving the entire parent element. 
        _serializeCanvasOpt(true, false, false, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), "parentElement", true);
    },
    getWebGLCanvasParentNode: function(debug, gameInstanceName){//ONLY CALL FROM JS
        return _getOptObj(debug, gameInstanceName, "parentNode", true);//NOTE: the returned object is ready for manipulation with jQuery
    },
    consoleLogWebGLCanvasParentNode: function(csIsCalling, gameInstanceName){
        //Show the Canvas's Parent Node in the browser console. The CanvasParentElement object reference cannot be serialized,
        //it just returns empty {}. Use the canvas get methods to retrieve the information from the parent instead of retrieving the entire parent element. 
        _serializeCanvasOpt(true, false, false, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), "parentNode", true);
    },
    getWebGLCanvasParentAttr: function(debug, csIsCalling, returnBuffer, gameInstanceName, attrName){   
        //If gameInstanceName is '' (ie empty) then this will return this game instance's info. Else, it will return that of the named gameInstance
        if(csIsCalling){
            gameInstanceName = Pointer_stringify(gameInstanceName);
            attrName = Pointer_stringify(attrName);
        }
        var glctx = _getGLctx(false, gameInstanceName);
        var str = JSON.stringify( jQuery(glctx["canvas"]["parentElement"]).attr(attrName) );
        if(debug) console.log("Canvas parentAttr" + attrName + ":" + str);
                                                                  
        return gameInstanceName === '' ? _stringToBuffer( str, false, returnBuffer) : window[gameInstanceName].Module.asmLibraryArg._stringToBuffer( str, false, returnBuffer);
    },
    getWebGLCanvasParentId: function(debug, csIsCalling, returnBuffer, gameInstanceName){
        return _getWebGLCanvasParentAttr(debug, false, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), "id");
    },
    getWebGLCanvasParentName: function(debug, csIsCalling, returnBuffer, gameInstanceName){
        return _getWebGLCanvasParentAttr(debug, false, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), "name");
    },
    getWebGLCanvasParentClass: function(debug, csIsCalling, returnBuffer, gameInstanceName){
        return _getWebGLCanvasParentAttr(debug, false, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), "class");
    },
    getWebGLCanvasParentStyle: function(debug, csIsCalling, returnBuffer, gameInstanceName){
        return _getWebGLCanvasParentAttr(debug, false, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), "style");
    },
    getWebGLCanvasParentTitle: function(debug, csIsCalling, returnBuffer, gameInstanceName){
        return _getWebGLCanvasParentAttr(debug, false, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), "title");
    },
    getWebGLCanvasClass: function (debug, csIsCalling, returnBuffer, gameInstanceName) {
        return _serializeCanvasOpt(debug, false, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), "className", false);  
    },    
    getWebGLCanvasClientWidth: function(debug, csIsCalling, returnBuffer, gameInstanceName){
        return _serializeCanvasOpt(debug, false, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), "clientWidth", false);
    },
    getWebGLCanvasClientHeight: function(debug, csIsCalling, returnBuffer, gameInstanceName){
        return _serializeCanvasOpt(debug, false, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), "clientHeight", false); 
    },
    webGLBindVertexArray: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLCreateVertexArray: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLDeleteVertexArray: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLDisjointTimerQueryExt: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLDrawArraysInstanced: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLDrawElementsInstanced: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    getWebGLDrawingBufferHeight: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize){
        return _serializeGLctxOpt(debug, csIsCalling, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), "drawingBufferHeight", doSerialize);
    },
    getWebGLDrawingBufferWidth: function(debug, csIsCalling, returnBuffer, gameInstanceName, doSerialize){
        return _serializeGLctxOpt(debug, csIsCalling, returnBuffer, (csIsCalling ? Pointer_stringify(gameInstanceName) : gameInstanceName), "drawingBufferWidth", doSerialize);
    },
    webGLIsVertexArray: function(){/* Not sure if it's useful to access this, but here for completeness*/},
    webGLVertexAttribDivisor: function(){/* Not sure if it's useful to access this, but here for completeness*/},
});