using System.Data.SqlClient;

string connection = "Server=DESKTOP-1BB3LE6;Database=BoltFood;Trusted_Connection=True;TrustServerCertificate=True;";
var sqlConnection = new SqlConnection(connection);

bool IsRun = true;
Console.WriteLine("1. create");
Console.WriteLine("2. ShowAll");
Console.WriteLine("3. Remove");
Console.WriteLine("4. Update");
Console.WriteLine("5. GetById");
Console.WriteLine("6. ShowGroups");
int.TryParse(Console.ReadLine(), out int request);
while (IsRun)
{
    switch (request)
    {
        case 1:
            Console.Clear();
            break;
        case 2:
            Console.Clear();
            break;
        case 3:
            Console.Clear();
            break;
        case 4:
            Console.Clear();
            break;
        case 5:
            Console.Clear();
            break;
        case 6:
            Console.Clear();
            break;
        case 0:
            return;

        default:
            Console.WriteLine("Add valid option");
            break;
    }

    Console.WriteLine("1. create");
    Console.WriteLine("2. ShowAll");
    Console.WriteLine("3. Remove");
    Console.WriteLine("4. Update");
    Console.WriteLine("5. GetById");
    Console.WriteLine("6. ShowCategories");

    int.TryParse(Console.ReadLine(), out request);
}


void CreateProduct()
{
    sqlConnection.Open();
    Console.WriteLine("Add product name");
    string productName = Console.ReadLine();

    Console.WriteLine("Enter category Id");
    int.TryParse(Console.ReadLine(), out int Id);
   
    SqlCommand sqlCommand = new SqlCommand($"INSERT INTO Products VALUES($'{productName},{Id}')", sqlConnection);
    sqlCommand.ExecuteNonQuery();
    sqlConnection.Close();

}


void UpdateProduct()
{

    Console.WriteLine("Enter product Id");
    int.TryParse(Console.ReadLine(), out int Id);
    SqlCommand sqlCommand1 = new SqlCommand($"Select * FROM Products WHERE Id = {Id}", sqlConnection);
    sqlConnection.Open();
    SqlDataReader dataReader = sqlCommand1.ExecuteReader(); 
    sqlConnection.Close();

    if (dataReader.Read())
    {
        sqlConnection.Open();
        Console.WriteLine("Add product name");
        string productName = Console.ReadLine();

        SqlCommand sqlCommand2 = new SqlCommand($"Update Products Set Name($'{productName},{Id}')", sqlConnection);
        sqlCommand2.ExecuteNonQuery();
        sqlConnection.Close();
    }
    else
    {
        Console.WriteLine("Enter correct product id");
    }
}