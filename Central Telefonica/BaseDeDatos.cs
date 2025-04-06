using System;
using MySqlConnector;

public class MySQLInserter
{
    private string connectionString = "Server=localhost;Database=centralitatel;User ID=root;Password=zoykape65;";

    public void InsertarLlamada(Llamada llamada)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();

                string query = "INSERT INTO registro (Num_Origen, Num_Destino, Duracion, Precio) VALUES (@Num_Origen, @Num_Destino, @Duracion, @Precio)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Num_Origen", llamada.NumOrigen);
                    cmd.Parameters.AddWithValue("@Num_Destino", llamada.NumDestino);
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