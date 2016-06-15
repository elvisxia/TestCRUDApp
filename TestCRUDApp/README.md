#Guide

###Config
1. open `Web.config` file and fill the connection string of your sql server in the following tag:
    
        <connectionStrings>
               <add name="CaseManagementAzure" connectionString="data source=franklinchen.eastasia.cloudapp.azure.com;initial catalog=TestDB;user id=elvis;password=elvisxia;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
        </connectionStrings>
2. open `caseStatusManagement.js` and set your local server address:

        "use strict"
          var serverPath = "You Local Server Path";
          window.onload = function()
         ...

