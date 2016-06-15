/// <reference path="APIUtility.js" />
(function () {
    "use strict"
    var serverPath = "You path";
    window.onload = function()
    {
        //get all the status list
        window.caseStatus.getAll(function (data) {
            for (var i = 0; i < data.length; i++)
            {
                addRow(data[i]);
            }
        });

        init();
    };

    function init() {
        //add item
        document.getElementById("addStatus").onclick = function ()
        {
            var dataToAdd = {statusName: "testStatus" };
            window.caseStatus.createItemWithResult(dataToAdd, function (result) {
                if (result.Status_Id) {
                    addRow(result);
                    alert("added successfully");
                } else {
                    alert("add record failed");
                }
                
            });
        }
    }

    function addRow(data)
    {
        //init elements
        var tblBody = document.getElementById("statusList");
        var trRow = document.createElement("tr");
        tblBody.appendChild(trRow);
        var tdId = document.createElement("td");
        var tdName = document.createElement("td");
        var tdDelete = document.createElement("td");
        trRow.appendChild(tdId);
        trRow.appendChild(tdName);
        trRow.appendChild(tdDelete);
        var inputName = document.createElement("input");
        tdName.appendChild(inputName);
        var btnDelete = document.createElement("button");
        tdDelete.appendChild(btnDelete);
        //init data
        trRow.id = data.Status_Id;
        tdId.innerText = data.Status_Id;
        inputName.value = data.Status_Name;
        btnDelete.innerText = "Delete";
        btnDelete.onclick = deleteData;
        inputName.onchange = editRow;
    }

    function deleteData(evt)
    {
        var id = evt.srcElement.parentElement.parentElement.id;
        window.caseStatus.deleteById(id, function (result) {
            removeRow(id);
            alert("remove successfully");
        });
    }

    function removeRow(id)
    {
        try {
            var tblBody = document.getElementById("statusList");
            var row = document.getElementById(id);
            tblBody.removeChild(row);
        }
        catch (e)
        {
            console.log(e);
        }
    }

    function editRow(evt)
    {
        var id = evt.srcElement.parentElement.parentElement.id;
        var status = {
            statusId: id,
            statusName: evt.srcElement.value
        }
        window.caseStatus.editRecord(status, function (result) {
            alert("edited successfully");
        })
    }

    
})();