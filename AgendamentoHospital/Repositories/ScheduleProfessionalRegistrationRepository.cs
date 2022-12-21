using AgendamentoHospital.DTO;
using System.Data;
using System.Data.SqlClient;

namespace AgendamentoHospital.Repositories
{
    public class ScheduleProfessionalRegistrationRepository
    {
        public String ConnectionString { get; set; }


        public ScheduleProfessionalRegistrationRepository()
        {
            this.ConnectionString = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build()
              .GetConnectionString("Projeto");
        }

        public void CreateProfessionalRegistration(ScheduleProfessionalRegistrationDto scheduleProfessionalRegistrationDto)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                String query = "INSERT INTO Profissional (Nome, Telefone, Endereço, Ativo) " +
                    "VALUES (@name, @phone, @address, @active)";

                SqlCommand command = new SqlCommand(query, connection);

                // Add valor ao comando
                command.Parameters.Add("@name", SqlDbType.VarChar);
                command.Parameters["@name"].Value = scheduleProfessionalRegistrationDto.Name;
                command.Parameters.Add("@phone", SqlDbType.VarChar);
                command.Parameters["@phone"].Value = scheduleProfessionalRegistrationDto.Phone;
                command.Parameters.Add("@address", SqlDbType.VarChar);
                command.Parameters["@address"].Value = scheduleProfessionalRegistrationDto.Address;
                command.Parameters.Add("@active", SqlDbType.Bit);
                command.Parameters["@active"].Value = scheduleProfessionalRegistrationDto.Active;

                //Abrindo conexão...
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public IList<ScheduleProfessionalRegistrationDto> ListingProfessionalRegistrationData()
        {
            IList<ScheduleProfessionalRegistrationDto> list = new List<ScheduleProfessionalRegistrationDto>();

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                String query = "SELECT IdProfissional, Nome, Telefone, Endereço, Ativo  FROM Profissional";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    //Recuperando dados...
                    ScheduleProfessionalRegistrationDto scheduleProfessionalRegistrationDto = new ScheduleProfessionalRegistrationDto();
                    scheduleProfessionalRegistrationDto.IdProfessional = Convert.ToInt32(dataReader["IdProfissional"]);
                    scheduleProfessionalRegistrationDto.Name = Convert.ToString(dataReader["Nome"]);
                    scheduleProfessionalRegistrationDto.Phone = Convert.ToString(dataReader["Telefone"]);
                    scheduleProfessionalRegistrationDto.Address = Convert.ToString(dataReader["Endereço"]);
                    scheduleProfessionalRegistrationDto.Active = Convert.ToBoolean(dataReader["Ativo"]);

                    //Adicionado o modelo da lista...
                    list.Add(scheduleProfessionalRegistrationDto);
                }
                connection.Close();
            } // Finaliza o objeto connection

            // Retorna a lista
            return list;
        }

        public ScheduleProfessionalRegistrationDto GetProfessionalRegistrationById(int id)
        {
            ScheduleProfessionalRegistrationDto scheduleProfessionalRegistrationDto = new ScheduleProfessionalRegistrationDto();

            var connectionString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("Projeto");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query = "SELECT IdProfissional, Nome, Telefone, Endereço, Ativo FROM Profissional WHERE IdProfissional = @idProfessional";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@idProfessional", SqlDbType.Int);
                command.Parameters["@idProfessional"].Value = id;

                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    //Recuperando dados
                    scheduleProfessionalRegistrationDto.IdProfessional = (int)dataReader["IdProfissional"];
                    scheduleProfessionalRegistrationDto.Name = (string)dataReader["Nome"];
                    scheduleProfessionalRegistrationDto.Phone = (string)dataReader["Telefone"];
                    scheduleProfessionalRegistrationDto.Address = (string)dataReader["Endereço"];
                    scheduleProfessionalRegistrationDto.Active = (bool)dataReader["Ativo"];
                }
                connection.Close();
            }
            return scheduleProfessionalRegistrationDto;
        }

        public void UpdateProfessionalRegistration(ScheduleProfessionalRegistrationDto scheduleProfessionalRegistrationDto)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                String query = "UPDATE Profissional SET Nome = @name, Telefone = @phone, Endereço = @address" +
                    ", Ativo = @active where IdProfissional = @idProfessional";

                SqlCommand command = new SqlCommand(query, connection);

                // Add valor ao comando
                command.Parameters.Add("@idProfessional", SqlDbType.Int);
                command.Parameters["@idProfessional"].Value = scheduleProfessionalRegistrationDto.IdProfessional;
                command.Parameters.Add("@name", SqlDbType.VarChar);
                command.Parameters["@name"].Value = scheduleProfessionalRegistrationDto.Name;
                command.Parameters.Add("@phone", SqlDbType.VarChar);
                command.Parameters["@phone"].Value = scheduleProfessionalRegistrationDto.Phone;
                command.Parameters.Add("@address", SqlDbType.VarChar);
                command.Parameters["@address"].Value = scheduleProfessionalRegistrationDto.Address;
                command.Parameters.Add("@active", SqlDbType.Bit);
                command.Parameters["@active"].Value = scheduleProfessionalRegistrationDto.Active;

                //Abrindo conexão...
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteProfessionalRegistration(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                String query = "DELETE FROM Profissional WHERE IdProfissional = @idProfessional";

                SqlCommand command = new SqlCommand(query, connection);

                // Add valor ao comando
                command.Parameters.Add("@idProfessional", SqlDbType.Int);
                command.Parameters["@idProfessional"].Value = id;
                
                //Abrindo conexão...
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}