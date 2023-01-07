//using AgendamentoHospital.DTO;
//using System.Data.SqlClient;
//using System.Data;
//using System.Collections.Generic;

//namespace AgendamentoHospital.Repositories
//{
//    public class BeneficiaryRepository
//    {
//        public String ConnectionString { get; set; }
//        public BeneficiaryRepository()
//        {
//            this.ConnectionString = new ConfigurationBuilder()
//             .SetBasePath(Directory.GetCurrentDirectory())
//             .AddJsonFile("appsettings.json")
//             .Build()
//             .GetConnectionString("Projeto");
//        }

//        public void Create(BeneficiaryDto beneficiaryDto)
//        {
//            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
//            {
//                String query = "INSERT INTO Beneficiario (Nome, Cpf, Telefone, Endereco, NumeroCarteirinha, Ativo, Email, Senha ) " +
//                    "VALUES (@Name, @Cpf, @Phone, @Address, @NumberCard, @Active, @Email, @Password)";
             
//                SqlCommand command = new SqlCommand(query, connection);

//                // Add valor ao comando
//                /*command.Parameters.Add("@idConfig", SqlDbType.Int);
//                command.Parameters["@idConfig"].Value = scheduleSettingDto.IdConfig;*/
//                command.Parameters.Add("@Name", SqlDbType.VarChar);
//                command.Parameters["@Name"].Value = beneficiaryDto.Name;

//                command.Parameters.Add("@Cpf", SqlDbType.VarChar);
//                command.Parameters["@Cpf"].Value = beneficiaryDto.Cpf;

//                command.Parameters.Add("@Phone", SqlDbType.VarChar);
//                command.Parameters["@Phone"].Value = beneficiaryDto.Phone;

//                command.Parameters.Add("@Address", SqlDbType.VarChar);
//                command.Parameters["@Address"].Value = beneficiaryDto.Address;

//                command.Parameters.Add("@NumberCard", SqlDbType.VarChar);
//                command.Parameters["@NumberCard"].Value = beneficiaryDto.NumberCard;

//                command.Parameters.Add("@Active", SqlDbType.Bit);
//                command.Parameters["@Active"].Value = beneficiaryDto.Active;

//                command.Parameters.Add("@Email", SqlDbType.VarChar);
//                command.Parameters["@Email"].Value = beneficiaryDto.Email;

//                command.Parameters.Add("@Password", SqlDbType.VarChar);
//                command.Parameters["@Password"].Value = beneficiaryDto.Email;

//                //Abrindo conexão...
//                connection.Open();
//                command.ExecuteNonQuery();
//                connection.Close();
//            }
//        }

//        public IList<BeneficiaryDto> GetBeneficiaryData()
//        {
//            IList<BeneficiaryDto> list = new List<BeneficiaryDto>();
//            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
//            {
//                String query = "SELECT IdBeneficiario, Nome, Cpf, Telefone, Endereco, NumeroCarteirinha, Ativo, Email, Senha" +
//                    " FROM Beneficiario ORDER BY IdBeneficiario";

//                SqlCommand command = new SqlCommand(query, connection);
//                connection.Open();
//                SqlDataReader dataReader = command.ExecuteReader();

//                while (dataReader.Read())
//                {
//                    //Recuperando dados...
//                    BeneficiaryDto beneficiaryDto = new BeneficiaryDto();

//                    beneficiaryDto.IdBeneficiary = Convert.ToInt32(dataReader["IdBeneficiario"]);
//                    beneficiaryDto.Name = Convert.ToString(dataReader["Nome"]);
//                    beneficiaryDto.Cpf = Convert.ToString(dataReader["Cpf"]);
//                    beneficiaryDto.Phone = Convert.ToString(dataReader["Telefone"]);
//                    beneficiaryDto.Address = Convert.ToString(dataReader["Endereco"]);
//                    beneficiaryDto.NumberCard = Convert.ToString(dataReader["NumeroCarteirinha"]);
//                    beneficiaryDto.Active = Convert.ToBoolean(dataReader["Ativo"]);
//                    beneficiaryDto.Email = Convert.ToString(dataReader["Email"]);
//                    beneficiaryDto.Password = Convert.ToString(dataReader["Senha"]);

//                    //Adicionado o modelo da lista...
//                    list.Add(beneficiaryDto);
//                }
//                connection.Close();
//            } // Finaliza o objeto connection

//            // Retorna a lista
//            return list;
//        }

//        public BeneficiaryDto GetByID(int id)
//        {
//            BeneficiaryDto beneficiaryDto = new BeneficiaryDto();

//            var connectionString = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json")
//                .Build()
//                .GetConnectionString("Projeto");

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                String query = "SELECT IdBeneficiario, Nome, Cpf, Telefone, Endereco, NumeroCarteirinha, Ativo, Email, Senha" +
//                    " FROM Beneficiario WHERE IdBeneficiario = @IdBeneficiary";

//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.Add("@IdBeneficiary", SqlDbType.Int);
//                command.Parameters["@IdBeneficiary"].Value = id;

//                connection.Open();

//                SqlDataReader dataReader = command.ExecuteReader();

//                while (dataReader.Read())
//                {
//                    //Recuperando dados
//                    beneficiaryDto.IdBeneficiary = (int)dataReader["IdBeneficiario"];
//                    beneficiaryDto.Name = (string)dataReader["Nome"];
//                    beneficiaryDto.Cpf = (string)dataReader["Cpf"];
//                    beneficiaryDto.Phone = (string)dataReader["Telefone"];
//                    beneficiaryDto.Address = (string)dataReader["Endereco"];
//                    beneficiaryDto.NumberCard = (string)dataReader["NumeroCarteirinha"];
//                    beneficiaryDto.Active = (bool)dataReader["Ativo"];
//                    beneficiaryDto.Email = (string)dataReader["Email"];
//                    beneficiaryDto.Password = (string)dataReader["Senha"];
                   
//                }
//                connection.Close();
//            }
//            return beneficiaryDto;

//        }
//        public void UpdateBeneficiary(BeneficiaryDto beneficiaryDto)
//        {
//            var connectionString = new ConfigurationBuilder()
//               .SetBasePath(Directory.GetCurrentDirectory())
//               .AddJsonFile("appsettings.json")
//               .Build()
//               .GetConnectionString("Projeto");

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                String query = "UPDATE Beneficiario SET Nome = @Name, Cpf = @Cpf, Telefone = @Phone, Endereco = @Address," +
//                    "NumeroCarteirinha = @NumberCard, Ativo = @Active, Email = @Email, Senha = @Password " +
//                    "WHERE IdBeneficiario = @IdBeneficiary";

//                SqlCommand command = new SqlCommand(query, connection);

//                command.Parameters.Add("@IdBeneficiary", SqlDbType.Int);
//                command.Parameters["@IdBeneficiary"].Value = beneficiaryDto.IdBeneficiary;

//                command.Parameters.Add("@Name", SqlDbType.VarChar);
//                command.Parameters["@Name"].Value = beneficiaryDto.Name;

//                command.Parameters.Add("@Cpf", SqlDbType.VarChar);
//                command.Parameters["@Cpf"].Value = beneficiaryDto.Cpf;

//                command.Parameters.Add("@Phone", SqlDbType.VarChar);
//                command.Parameters["@Phone"].Value = beneficiaryDto.Phone;

//                command.Parameters.Add("@Address", SqlDbType.VarChar);
//                command.Parameters["@Address"].Value = beneficiaryDto.Address;

//                command.Parameters.Add("@NumberCard", SqlDbType.VarChar);
//                command.Parameters["@NumberCard"].Value = beneficiaryDto.NumberCard;

//                command.Parameters.Add("@Active", SqlDbType.Bit);
//                command.Parameters["@Active"].Value = beneficiaryDto.Active;

//                command.Parameters.Add("@Email", SqlDbType.VarChar);
//                command.Parameters["@Email"].Value = beneficiaryDto.Email;

//                command.Parameters.Add("@Password", SqlDbType.VarChar);
//                command.Parameters["@Password"].Value = beneficiaryDto.Password;

//                connection.Open();
//                command.ExecuteNonQuery();
//                connection.Close();
//            }
//        }

//        public void DeleteBeneficiary(int id)
//        {
//            var connectionString = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json")
//                .Build()
//                .GetConnectionString("Projeto");

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                String query = "DELETE Beneficiario WHERE IdBeneficiario = @IdBeneficiary";

//                SqlCommand command = new SqlCommand(query, connection);

//                command.Parameters.Add("@IdBeneficiary", SqlDbType.Int);
//                command.Parameters["@IdBeneficiary"].Value = id;

//                connection.Open();
//                command.ExecuteNonQuery();
//                connection.Close();
//            }
//        }
        



//    }
//}
