// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Net.Http.Headers;
using Dapper;
using DapperHelper;
using DapperHelper.Console.Database;
using DapperHelper.Console.model;
using DapperHelper.Helper;
using Oracle.ManagedDataAccess.Client;

Console.WriteLine("Hello, World!");
FromDatabase database = new FromDatabase();

Console.WriteLine(database.GetInsertSql<LabAllocationModel>());
Console.WriteLine("---------");
Console.WriteLine(database.GetSelectAllSql<LabAttendanceModel>());
Console.WriteLine("---------");
Console.WriteLine(database.GetDeleteSql<LabAttendanceModel>());

// string connectionString = "";
// CancellationToken cancellationToken = new CancellationToken();
// using IDbConnection dbconn = new OracleConnection(connectionString);
// dbconn.Open();
// using var transaction  = dbconn.BeginTransaction();

// await dbconn.ExecuteAsync(InsertSqlforAttendance,new LabAttendanceModel[]{
//     new LabAttendanceModel(){

//     },
//     new LabAttendanceModel(){

//     },
//     new LabAttendanceModel(){

//     }
// }, transaction);

// transaction.Commit();

