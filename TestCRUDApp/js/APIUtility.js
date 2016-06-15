/// <reference path="Utility.js" />
(function () {
    "use strict";
    window.caseStatus = {};
    var serverPath = "http://localhost:6018/";
    //case status CRUD
    window.caseStatus.getAll = function (callback)
    {
        window.Ajax.HttpGet(serverPath + "api/casestatus/getall/v1", callback);
    };
    window.caseStatus.getById = function (id, callback)
    {
        window.Ajax.HttpGet(serverPath + "api/casestatus/getbyid/v2/" + id, callback);
    }
    window.caseStatus.createItem = function (data, callback)
    {
        window.Ajax.HttpPost(serverPath + "api/casestatus/create/v1", data, callback);
    }
    window.caseStatus.createItemWithResult = function (data, callback)
    {
        window.Ajax.HttpPost(serverPath + "api/casestatus/createWithResult/v1", data, callback);
    }
    window.caseStatus.deleteById = function (id, callback)
    {
        window.Ajax.HttpGet(serverPath + "api/casestatus/deletebyid/v1/" + id, callback);
    }
    window.caseStatus.editRecord = function (data, callback)
    {
        window.Ajax.HttpPost(serverPath + "api/casestatus/edit/v1", data, callback);
    }
    
})();