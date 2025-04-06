using System;
using MySqlConnector;

public class MySQLInserter
{
    private string connectionString = "Server=localhost;Database=centralitatel;User ID=root;Password=zoykape65;";

    public void InsertLlamada(Llamada llamada)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();

                string query = "INSERT INTO registro (NumOrigen, NumDestino, Duracion, Precio) VALUES (@NumOrigen, @NumDestino, @Duracion, @Precio)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NumOrigen", llamada.NumOrigen);
                    cmd.Parameters.AddWithValue("@NumDestino", llamada.NumDestino);
                    cmd.Parameters.AddWithValue("@Duracion", llamada.Duracion);
                    cmd.Parameters.AddWithValue("@Precio", llamada.CalcularPrecio());

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Se ha insertado la llamada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hay un error al insertar la llamada: " + ex.Message);
            }
        }
    }
}