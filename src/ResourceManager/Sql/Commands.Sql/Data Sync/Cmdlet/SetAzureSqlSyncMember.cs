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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.DataSync.Model;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.DataSync.Cmdlet
{
    /// <summary>
    /// Cmdlet to update an existing sync member
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlSyncMember", SupportsShouldProcess = true, 
        ConfirmImpact = ConfirmImpact.Medium)]
    [CmdletBinding(DefaultParameterSetName = "All")]
    public class SetAzureSqlSyncMember : AzureSqlSyncMemberCmdletBase
    {
        /// <summary>
        /// Gets or sets the sync member name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The sync member name.")]
        [ValidateNotNullOrEmpty]
        public string SyncMemberName { get; set; }

        /// <summary>
        /// Gets or sets the database type of the member database. Only AzureSqlDatabase's credential can be updated. So we make DatabaseType required.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The database type.")]
        [ValidateSet("AzureSqlDatabase", IgnoreCase = true)]
        public string DatabaseType { get; set; }

        /// <summary>
        /// Gets or sets the credential (username and password) of Azure SQL database. 
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The credential (username and password) of Azure SQL database.")]
        [ValidateNotNull]
        public PSCredential Credential { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlSyncMemberModel> GetEntity()
        {
            return new List<AzureSqlSyncMemberModel>() { 
               ModelAdapter.GetSyncMember(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.SyncGroupName, this.SyncMemberName)
            };
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlSyncMemberModel> ApplyUserInputToModel(IEnumerable<AzureSqlSyncMemberModel> model)
        {
            AzureSqlSyncMemberModel newModel = model.First();

            if (MyInvocation.BoundParameters.ContainsKey("Credential"))
            {
                newModel.UserName = this.Credential.UserName;
                newModel.Password = this.Credential.Password;
            }
            else
            {
                newModel.UserName = null;
                newModel.Password = null;
            }

            return model;
        }

        /// <summary>
        /// Update the sync member
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlSyncMemberModel> PersistChanges(IEnumerable<AzureSqlSyncMemberModel> entity)
        {
            return new List<AzureSqlSyncMemberModel>() {
                ModelAdapter.UpdateSyncMember(entity.First())
            };
        }
    }
}
