using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DentaCare.Implementation.Commands
{
    public class RawSqlCreateRoleCommand : ICreateRoleCommand
    {
        private readonly IDbConnection dbConnection;

        public RawSqlCreateRoleCommand(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public int Id => 2;

        public string Name => "Create role using raw SQL";

        public void Execute(RoleDto request)
        {
            var query = "INSERT INTO ROLES(RoleName) VALUES ('"+ request.RoleName +"')";
            var command = dbConnection.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
        }
    }
}
