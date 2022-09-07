
using System.Data.SqlClient;
using System.IO;




string connect = @"Server=DESKTOP-15FAUDE\SQLEXPRESS;Database=NORTHWND;Trusted_Connection=True";

SqlConnection con = new SqlConnection(connect);
con.Open();

SqlCommand cmd = new SqlCommand("SELECT table_name FROM information_schema.tables", con);
if (con.State == System.Data.ConnectionState.Closed)
    con.Open();

SqlDataReader dr = cmd.ExecuteReader();
if (!Directory.Exists(@"C:\Users\HP\Desktop\PypTasks\Ado.Net\Ado.Net\Models"))
{
    Directory.CreateDirectory(@"C:\Users\HP\Desktop\PypTasks\Ado.net\Ado.net\\Models");
}
string path = @"C:\Users\HP\Desktop\PypTasks\Ado.Net\Ado.Net\Models\";
while (dr.Read())
{
    var data = dr[0].ToString().Replace(" ", String.Empty);
    Console.WriteLine(data);

    List<string> files = new List<string>();
    files.Add($"internal class {data}   {{}}");



    await File.WriteAllLinesAsync($"{path}\\{data}.cs", files);

}

dr.Close();
con.Close();
