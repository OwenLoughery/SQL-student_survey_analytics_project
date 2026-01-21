using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using WebApplication3.Models;

public class SqlProcedureService
{
    private readonly string _connectionString;

    public SqlProcedureService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public List<ResponseVariation> GetVariations()
    {
        var results = new List<ResponseVariation>();

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand("GetResponseRange", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        connection.Open();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var result = new ResponseVariation
            {
                QuestionName = reader["AnswerType"]?.ToString() ?? string.Empty,
                RangeValue = Convert.ToInt32(reader["RangeValue"]),
                Variance = Convert.ToSingle(reader["VarianceValue"])
            };
            results.Add(result);
        }
        return results;
    }

    public ResponseAverage GetAverages()
    {
        var result = new ResponseAverage();

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand("GetResponseAverage", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        connection.Open();

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            result.avgFeel = Convert.ToSingle(reader["avgFeel"]);
            result.avgWorkload = Convert.ToSingle(reader["avgWorkload"]);
            result.avgStress = Convert.ToSingle(reader["avgStress"]);
            result.avgExpect = Convert.ToSingle(reader["avgExpect"]);
            result.avgCurrent = Convert.ToSingle(reader["avgCurrent"]);
            result.avgCareer = Convert.ToSingle(reader["avgCareer"]);
            result.avgLove = Convert.ToSingle(reader["avgLove"]);
        }
        return result;
    }




    public List<DailyStats> GetDailyStats()
    {
        var results = new List<DailyStats>();

        using var conn = new SqlConnection(_connectionString);
        //
        using var cmd = new SqlCommand("Owen_StressWorkload", conn)
        {
            CommandType = CommandType.StoredProcedure
        };
        //
    //    var sql = @"
    //SELECT
    //    CAST(DateCreated AS DATE) AS ResponseDate,
    //    ROUND(AVG(CAST(Stress AS FLOAT)), 2) AS AvgStress,
    //    ROUND(AVG(CAST(Workload AS FLOAT)), 2) AS AvgWorkLoad
    //FROM dbo.CleanResponses
    //GROUP BY CAST(DateCreated AS DATE)
    //ORDER BY ResponseDate";

    //    using var cmd = new SqlCommand(sql, conn);
    //    cmd.CommandType = CommandType.Text;
        //
        conn.Open();
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            results.Add(new DailyStats
            {
                ResponseDate = reader.GetDateTime(0),
                AvgStress = reader.GetDouble(1),
                AvgWorkLoad = reader.GetDouble(2)
            });
        }

        return results;
    }


    public List<LoveCareer> GetLoveCareer()
    {
        var results = new List<LoveCareer>();

        using var conn = new SqlConnection(_connectionString);

        //

        using var cmd = new SqlCommand("Owen_LoveCareer", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        //
        //    var sql = @"
        //SELECT 
        //    Love, 
        //    AVG(CAST(Career AS FLOAT)) AS AvgCareer
        //FROM SurveyResponses
        //GROUP BY Love
        //ORDER BY Love";

        //    using var cmd = new SqlCommand(sql, conn);
        //    cmd.CommandType = CommandType.Text;
        //

        conn.Open();
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            results.Add(new LoveCareer
            {
                Love = reader.GetInt32(0),
                AvgCareer = reader.GetDouble(1)
            });
        }

        return results;
    }

}

