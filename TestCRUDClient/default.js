(function () {
    "use strict"

    document.getElementById("myBtn").onclick = function (evt)
    {
        var xhr=new XMLHttpRequest();
        xhr.open("POST", "http://localhost:6018/api/create/v1");
        xhr.send({ data: "TestData" });
    }
})();