## Connection Strings Modification Project

This project aims to modify several development connection strings for projects in the same directory.

## How to use?

To add data that will appear in the console, you should add it to the JSON file named "Connections."

The standard format for adding data is as follows:
```
{
  "dataSource": "server",
  "initialCatalog": "database",
  "UserId": "user",
  "Password": "Password"
}
```

**Important Note:** If you do not provide "UserId" and "Password" data, default login and password will be added.

## How to run?

To run locally, remember to change the directories for the **jsonFilePath** and **directories** variables.