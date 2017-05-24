---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmSqlSyncGroup

## SYNOPSIS
Creates an Azure SQL Database Sync Group.

## SYNTAX

```
New-AzureRmSqlSyncGroup -SyncGroupName <String> [-Interval <Int32>] [-HubDatabaseCredential <PSCredential>]
 [-ConflictResolutionPolicy <String>] [-SyncDatabaseName <String>] [-SyncDatabaseServerName <String>]
 [-SyncDatabaseResourceGroupName <String>] [-SchemaFile <String>] [-ServerName] <String>
 [-DatabaseName] <String> [-ResourceGroupName] <String>
```

## DESCRIPTION
The **New-AzureRmSqlSyncGroup** cmdlet creates an Azure SQL Database Sync Group.

## EXAMPLES

### Example 1: Create a sync group for a SQL Azure database.
```
PS C:\> $credential = Get-Credential
PS C:\> New-AzureRmSqlSyncGroup -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" -SyncGroupName "SyncGroup01" -ConflictResolutionPolicy "HubWin"
-HubDatabaseCredential $credential -Interval 100 -SyncDatabaseServerName "syncDatabaseServer01" -SyncDatabaseName "syncDatabaseName01" -SyncDatabaseResourceGroupName "syncDatabaseResourceGroup01" -Schema ".\schema.json"
ResourceId                  : /subscriptions/{subscriptionId}/resourceGroups/{ResourceGroup01}/servers/{Server01}/databases/{Database01}/syncGroups/{SyncGroup01}
ResourceGroupName           : ResourceGroup01
ServerName                  : Server01
DatabaseName                : Database01
SyncGroupName               : SyncGroup01
SyncDatabaseId              : subscriptions/{subscriptionId}/resourceGroups/{syncDatabaseResourceGroup01}/servers/{syncDatabaseServer01}/databases/{syncDatabaseName01}
Interval                    : 100
ConflictResolutionPolicy:   : "HubWin"
HubDatabaseUserName         : 
HubDatabasePassword         : 
SyncState                   : "Good"
LastSyncTime                : 
Schema                      :  
```

This command creates a sync group for a SQL Azure database. "schema.json" is a file in the local disk. It contains the shema payload in json format. An example of the schema json is:
{"Tables":  [{"Columns":  [{"QuotedName":  "b3ee3a7f-7614-4644-ad07-afa832620b4bManualTestsm4column1"}, {"QuotedName":  "b3ee3a7f-7614-4644-ad07-afa832620b4bManualTestsm4column2"}], "QuotedName":  "MayQuotedTable1"},
{"Columns":  [{"QuotedName":  "b3ee3a7f-7614-4644-ad07-afa832620b4bManualTestsm4column1"}, {"QuotedName":  "b3ee3a7f-7614-4644-ad07-afa832620b4bManualTestsm4column2"}], "QuotedName":  "MayQuotedTable2"}],
"MasterSyncMemberName":  null
}

## PARAMETERS

### -ConflictResolutionPolicy
The policy of resolving confliction between hub and member database in the sync group.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: HubWin, MemberWin

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseName
SQL Database name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -HubDatabaseCredential
The SQL authentication credetial of hub database.

```yaml
Type: PSCredential
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Interval
The frequency (in seconds) of doing data synchronization.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SchemaFile
The path of the schema file.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerName
SQL Database server name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SyncDatabaseName
The database used to store sync related metadata.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncDatabaseResourceGroupName
The resource group syncDB belongs to.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncDatabaseServerName
The server on which syncDB is hosted.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncGroupName
The sync group name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

