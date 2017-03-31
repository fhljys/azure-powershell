﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.DataSync.Model;
using Microsoft.Azure.Commands.Sql.DataSync.Services;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;

namespace Microsoft.Azure.Commands.Sql.DataSync.Cmdlet
{
    /// <summary>
    /// Cmdlet to list all the databases connected by a specified sync agent.  
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlSyncAgentLinkedDatabase", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.None)]
    public class GetAzureSqlSyncAgentSqlServerDatabase : AzureSqlCmdletBase<IEnumerable<AzureSqlSyncAgentLinkedDatabaseModel>, AzureSqlDataSyncAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Database Server the sync agent is in.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the sync agent name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The sync agent name.")]
        [ValidateNotNullOrEmpty]
        public string SyncAgentName { get; set; }

        /// <summary>
        /// Creation and initialization of the ModelAdapter object
        /// </summary>
        /// <param name="subscription">The AzureSubscription in which the current execution is performed</param>
        /// <returns>An initialized and ready to use ModelAdapter object</returns>
        protected override AzureSqlDataSyncAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new AzureSqlDataSyncAdapter(DefaultProfile.Context);
        }

        protected override IEnumerable<AzureSqlSyncAgentLinkedDatabaseModel> GetEntity()
        {
            ModelAdapter.GetSyncAgent(this.ResourceGroupName, this.ServerName, this.SyncAgentName);
            return ModelAdapter.ListSyncAgentLinkedDatabase(this.ResourceGroupName, this.ServerName, this.SyncAgentName);
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlSyncAgentLinkedDatabaseModel> PersistChanges(IEnumerable<AzureSqlSyncAgentLinkedDatabaseModel> entity)
        {
            return entity;
        }
    }
}