(function () {
    "use strict";

    window.Ajax = {};
    //HTTP POST
    window.Ajax.HttpPost = function (url,data,callback)
    {
        var xhr = new XMLHttpRequest();
        xhr.open("POST", url);
        xhr.setRequestHeader("content-type", "application/json");
        xhr.onreadystatechange=function(){
            if(xhr.readyState==xhr.DONE&&xhr.status==200)
            {
                callback(JSON.parse(xhr.response));
            }
        }

        xhr.send(JSON.stringify(data));
    }
    //HTTP GET
    window.Ajax.HttpGet = function (url,callback)
    {
        var xhr = new XMLHttpRequest();
        xhr.open("GET", url);
        xhr.onreadystatechange = function ()
        {
            if (xhr.readyState == xhr.DONE && xhr.status == 200)
            {
                callback(JSON.parse(xhr.response));
            }
        }
        xhr.send("");
    }
})();